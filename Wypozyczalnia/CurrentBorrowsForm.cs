using System.Threading;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Wypozyczalnia
{
    public partial class CurrentBorrowsForm : Form
    {
        int CurrentSort;
        private enum ActiveForm { mainForm, returnResourceForm, userForm, selectUser };
        private ActiveForm currentActiveForm;
        private Form currentForm;

        int type;
        string title, author, sig, noInv, userName;
        bool dateSearch;
        DateTime startDate, endDate;

        private Dictionary<string, string> _translationsDictionary;

        public CurrentBorrowsForm(int EmployeeID, Form MdiParent)
        {
            InitializeComponent();

            setControlsText();

            this.MdiParent = MdiParent;
            Settings.SetSettings();
            Settings.employeeID = EmployeeID;

            Manager manager = new Manager(EmployeeID, Settings.ConnectionString);
            barcodeDGVC.Visible = manager.WypozyczalniaConfiguration.ShowBarcodeColumn;

            currentActiveForm = ActiveForm.mainForm;
            
            Dictionary<int, string> searchFieldsDictionary = new Dictionary<int, string>();
            searchFieldsDictionary.Add(0, _translationsDictionary.getStringFromDictionary("all_borrowed", "Wszystkie wypożyczone"));
            searchFieldsDictionary.Add(1, _translationsDictionary.getStringFromDictionary("borrowed_books", "Wypożyczone książki"));
            searchFieldsDictionary.Add(2, _translationsDictionary.getStringFromDictionary("borrowed_magazines", "Wypożyczone czasopisma"));
            searchFieldsDictionary.Add(3, "Wypożyczone artykuły");
            searchFieldsDictionary.Add(4, "Wypożyczone normy");

            typesComboBox.DisplayMember = "Value";
            typesComboBox.ValueMember = "Key";
            typesComboBox.DataSource = new BindingSource(searchFieldsDictionary, null);

            CurrentSort = 7;

            usersSuggest();


            startDateSearchDTP.Value = DateTime.Now;

            /*
            this.borrowsDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.borrowsDGV_ColumnHeaderMouseClick);
            foreach(DataGridViewColumn col in borrowsDGV.Columns)
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            */
            
            Search();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(descriptionDGVC, "description");
            mapping.Add(authorDGVC, "author1");
            mapping.Add(barcodeDGVC, "barcode");
            mapping.Add(noInvDGVC, "inventory_number");
            mapping.Add(sigDGVC, "signature");
            mapping.Add(resourceKindDGVC, "kind");
            mapping.Add(userNameDGVC, "user");
            mapping.Add(dataWypDGVC, "borrow_date");
            mapping.Add(dataPrzewDGVC, "expected_date_of_return");
            mapping.Add(onlyExpiredCheckBox, "only_expired");
            mapping.Add(titleLabel, "title");
            mapping.Add(authorLabel, "author");
            mapping.Add(signatureLabel, "signature");
            mapping.Add(invertoryNumberLabel, "inventory_number");
            mapping.Add(userLabel, "user");
            mapping.Add(dateSearchCheckBox, "borrow_date");
            mapping.Add(fromLabel, "from");
            mapping.Add(toLabel, "to");
            mapping.Add(SearchButton, "filter");
            mapping.Add(CleanSearchButton, "to_clean");
            mapping.Add(exitButton, "exit");

            mapping.Add(this, "borrowed_resources");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        #region void usersSuggest()
        private void usersSuggest()
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "EXEC w2_uzytkownicy_podpowiedzi; ";

            DataTable dt = CommonFunctions.ReadData(command, ref Settings.Connection);

            var source = new AutoCompleteStringCollection();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                source.Add(dt.Rows[i]["nazwa"].ToString());
            }

            userNameSearchTextBox.AutoCompleteCustomSource = source;
        }
        #endregion

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Search(bool saveCriteria = true)
        {
            type = (int)typesComboBox.SelectedValue;
            if (saveCriteria)
            {
                title = TitleSearchTextBox.Text.Trim();
                author = authorSearchTextBox.Text.Trim();
                sig = sigSearchTextBox.Text.Trim();
                noInv = noInvSearchTextBox.Text.Trim();
                userName = userNameSearchTextBox.Text.Trim();
                dateSearch = dateSearchCheckBox.Checked;
                startDate = startDateSearchDTP.Value;
                endDate = endDateSearchDTP.Value;
            }

            //LoadNotReturned((int)typesComboBox.SelectedValue, CurrentSort, TitleSearchTextBox.Text.Trim(), authorSearchTextBox.Text.Trim(), sigSearchTextBox.Text.Trim(), noInvSearchTextBox.Text.Trim(), userNameSearchTextBox.Text.Trim(), dateSearchCheckBox.Checked, startDateSearchDTP.Value, endDateSearchDTP.Value, onlyExpiredCheckBox.Checked, false);
            LoadNotReturned(type, CurrentSort, title, author, sig, noInv, userName, dateSearch, startDate, endDate, onlyExpiredCheckBox.Checked, false);
        }

        private void CurrentBorrowsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            else if (e.KeyCode == Keys.Enter /*&& IsSomethingReadyToSearch()*/)
            {
                if(startDateSearchDTP.Focused)
                {
                    endDateSearchDTP.Focus();
                    startDateSearchDTP.Focus();                    
                }
                else if (endDateSearchDTP.Focused)
                {
                    startDateSearchDTP.Focus();
                    endDateSearchDTP.Focus();
                }

                //LoadNotReturned((int)typesComboBox.SelectedValue, CurrentSort, TitleSearchTextBox.Text.Trim(), authorSearchTextBox.Text.Trim(), sigSearchTextBox.Text.Trim(), noInvSearchTextBox.Text.Trim(), userNameSearchTextBox.Text.Trim(), dateSearchCheckBox.Checked, startDateSearchDTP.Value, endDateSearchDTP.Value, onlyExpiredCheckBox.Checked);
                Search();
            }
        }
        private bool IsSomethingReadyToSearch()
        {
            return !string.IsNullOrWhiteSpace(TitleSearchTextBox.Text)
                || !string.IsNullOrWhiteSpace(authorSearchTextBox.Text)
                || !string.IsNullOrWhiteSpace(sigSearchTextBox.Text)
                || !string.IsNullOrWhiteSpace(noInvSearchTextBox.Text)
                || !string.IsNullOrWhiteSpace(userNameSearchTextBox.Text)
                || dateSearchCheckBox.Checked;
        }

        private void borrowsDGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                borrowsDGV.CurrentCell = borrowsDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];

                borrowsDGV.Rows[e.RowIndex].Selected = true;
                borrowsDGV.Focus();
            }
        }

        public void LoadNotReturned(int groupId, int sort, string title, string author, string signature, string noInv, string user, bool searchByDate, DateTime startDate, DateTime endDate, bool onlyExpired, bool showMessage = true)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_wypozyczone @group_id, @sort, @title, @author, @signature, @noInv, @user, @searchByDate, @startDate, @endDate, @przeterminowane; ";
            Command.Parameters.AddWithValue("@group_id", groupId);
            Command.Parameters.AddWithValue("@sort", sort);
            Command.Parameters.AddWithValue("@title", title);
            Command.Parameters.AddWithValue("@author", author);
            Command.Parameters.AddWithValue("@signature", signature);
            Command.Parameters.AddWithValue("@noInv", noInv);
            Command.Parameters.AddWithValue("@user", user);
            Command.Parameters.AddWithValue("@searchByDate", searchByDate);
            Command.Parameters.AddWithValue("@startDate", startDate);
            Command.Parameters.AddWithValue("@endDate", endDate);
            Command.Parameters.AddWithValue("@przeterminowane", onlyExpired);

            /* Sortowanie:
             * 1 opis
             * 2 autor
             * 3 kod kreskowy
             * 4 numer inwentarzowy
             * 5 sygnatura             
             * 6 użytkownik
             * 7 data wypożyczenia
             * 8 przew. data zwrotu
             * 9 rodzaj
             * */
            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (borrowsDGV.Rows.Count > 0)
                borrowsDGV.Rows.Clear();

            if (Dt.Rows.Count == 0 && showMessage)
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("not_found", "Brak wyników spełniających kryteria."), _translationsDictionary.getStringFromDictionary("filtration", "Filtrowanie"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int idx = 0;
            string cDataPrzew = "";
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                idx = borrowsDGV.Rows.Add(Dt.Rows[i]["wypoz_id"], Dt.Rows[i]["opis"], Coliber.App.NVL(Dt.Rows[i]["autor"]), Dt.Rows[i]["k_kreskowy"], Dt.Rows[i]["numer_inw"], Dt.Rows[i]["syg"], Dt.Rows[i]["rodzaj"], Dt.Rows[i]["uzytk_id"], Dt.Rows[i]["uzytkownik"], Dt.Rows[i]["data_wypoz"],cDataPrzew, GeneralBase.ConvertToBool(Dt.Rows[i]["przedawnione"].ToString()));
                if (Dt.Rows[i]["data_przewidywana"] == null || Dt.Rows[i]["data_przewidywana"] == DBNull.Value) cDataPrzew = "";
                else cDataPrzew = Dt.Rows[i]["data_przewidywana"].ToString();
                if (Dt.Rows[i]["przedawnione"].ToString() == "1")
                    borrowsDGV.Rows[idx].Cells[dataPrzewDGVC.Name].Style.ForeColor = Color.Red;
            }            
        }

        private void typesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //LoadNotReturned((int)typesComboBox.SelectedValue, CurrentSort, TitleSearchTextBox.Text.Trim(), authorSearchTextBox.Text.Trim(), sigSearchTextBox.Text.Trim(), noInvSearchTextBox.Text.Trim(), userNameSearchTextBox.Text.Trim(), dateSearchCheckBox.Checked, startDateSearchDTP.Value, endDateSearchDTP.Value, onlyExpiredCheckBox.Checked);
            Search(false);
        }

        private void borrowsDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int previousSort = CurrentSort;

                if (e.ColumnIndex == borrowsDGV.Columns[descriptionDGVC.Name].Index)
                    CurrentSort = 1;
                else if (e.ColumnIndex == borrowsDGV.Columns[authorDGVC.Name].Index)
                    CurrentSort = 2;
                else if (e.ColumnIndex == borrowsDGV.Columns[barcodeDGVC.Name].Index)
                    CurrentSort = 3;
                else if (e.ColumnIndex == borrowsDGV.Columns[noInvDGVC.Name].Index)
                    CurrentSort = 4;
                else if (e.ColumnIndex == borrowsDGV.Columns[sigDGVC.Name].Index)
                    CurrentSort = 5;
                else if (e.ColumnIndex == borrowsDGV.Columns[userNameDGVC.Name].Index)
                    CurrentSort = 6;
                else if (e.ColumnIndex == borrowsDGV.Columns[dataWypDGVC.Name].Index)
                    CurrentSort = 7;
                else if (e.ColumnIndex == borrowsDGV.Columns[dataPrzewDGVC.Name].Index)
                    CurrentSort = 8;
                else if (e.ColumnIndex == borrowsDGV.Columns[resourceKindDGVC.Name].Index)
                    CurrentSort = 9;

                if (previousSort != CurrentSort)
                    //LoadNotReturned((int)typesComboBox.SelectedValue, CurrentSort, TitleSearchTextBox.Text.Trim(), authorSearchTextBox.Text.Trim(), sigSearchTextBox.Text.Trim(), noInvSearchTextBox.Text.Trim(), userNameSearchTextBox.Text.Trim(), dateSearchCheckBox.Checked, startDateSearchDTP.Value, endDateSearchDTP.Value, onlyExpiredCheckBox.Checked);
                    Search(false);
            }    
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            //LoadNotReturned((int)typesComboBox.SelectedValue, CurrentSort, TitleSearchTextBox.Text.Trim(), authorSearchTextBox.Text.Trim(), sigSearchTextBox.Text.Trim(), noInvSearchTextBox.Text.Trim(), userNameSearchTextBox.Text.Trim(), dateSearchCheckBox.Checked, startDateSearchDTP.Value, endDateSearchDTP.Value, onlyExpiredCheckBox.Checked);
            Search(true);
        }

        private void SearchCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            startDateSearchDTP.Enabled = dateSearchCheckBox.Checked;
            endDateSearchDTP.Enabled = dateSearchCheckBox.Checked;
        }

        private void CleanSearchButton_Click(object sender, EventArgs e)
        {
            TitleSearchTextBox.Text = "";
            authorSearchTextBox.Text = "";
            sigSearchTextBox.Text = "";
            noInvSearchTextBox.Text = "";
            userNameSearchTextBox.Text = "";

            dateSearchCheckBox.Checked = false;
            startDateSearchDTP.Value = DateTime.Now;
            endDateSearchDTP.Value = DateTime.Now;

            typesComboBox.SelectedValue = 0;

            Search();
            //LoadNotReturned((int)typesComboBox.SelectedValue, CurrentSort, TitleSearchTextBox.Text.Trim(), authorSearchTextBox.Text.Trim(), sigSearchTextBox.Text.Trim(), noInvSearchTextBox.Text.Trim(), userNameSearchTextBox.Text.Trim(), dateSearchCheckBox.Checked, startDateSearchDTP.Value, endDateSearchDTP.Value, onlyExpiredCheckBox.Checked);
        }

        private void onlyExpiredCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            Search(false);
            //LoadNotReturned((int)typesComboBox.SelectedValue, CurrentSort, TitleSearchTextBox.Text.Trim(), authorSearchTextBox.Text.Trim(), sigSearchTextBox.Text.Trim(), noInvSearchTextBox.Text.Trim(), userNameSearchTextBox.Text.Trim(), dateSearchCheckBox.Checked, startDateSearchDTP.Value, endDateSearchDTP.Value, onlyExpiredCheckBox.Checked);
        }

        private void zwrotZasobuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (borrowsDGV.SelectedRows.Count > 0)
            {
                currentActiveForm = ActiveForm.returnResourceForm;

                ZwrotForm ZF = new ZwrotForm(borrowsDGV.SelectedRows[0].Cells[wypozIdDGVC.Name].Value.ToString(), this, false);
                ZF.Show();                
            }
        }

        private void CurrentBorrowsForm_Activated(object sender, EventArgs e)
        {
            if (currentActiveForm == ActiveForm.returnResourceForm/* || currentActiveForm == ActiveForm.userForm*/)
                //LoadNotReturned((int)typesComboBox.SelectedValue, CurrentSort, TitleSearchTextBox.Text.Trim(), authorSearchTextBox.Text.Trim(), sigSearchTextBox.Text.Trim(), noInvSearchTextBox.Text.Trim(), userNameSearchTextBox.Text.Trim(), dateSearchCheckBox.Checked, startDateSearchDTP.Value, endDateSearchDTP.Value, onlyExpiredCheckBox.Checked);
                Search(false);
            else if (currentActiveForm == ActiveForm.selectUser)
            {
                if (currentForm is UsersListForm && currentForm.DialogResult == DialogResult.OK)
                    userNameSearchTextBox.Text = (currentForm as UsersListForm).CurrentUserName;
            }

            currentActiveForm = ActiveForm.mainForm;
        }

        private void selectUserButton_Click(object sender, EventArgs e)
        {
            currentActiveForm = ActiveForm.selectUser;

            UsersListForm userList = new UsersListForm(UsersListForm.Mode.SelectUser, this, Settings.employeeID);
            userList.Show();

            currentForm = userList;
        }

        private void informacjeOUżytkownikuToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (borrowsDGV.SelectedRows.Count > 0)
            {
                currentActiveForm = ActiveForm.userForm;

                UserForm user = new UserForm(borrowsDGV.SelectedRows[0].Cells[userIdDGVC.Name].Value.ToString(), this);
                user.Show();
            }
        }

        private void startDateSearchDTP_ValueChanged(object sender, EventArgs e)
        {
            endDateSearchDTP.MinDate = startDateSearchDTP.Value;
        }

        private void drukujUpomnienieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (borrowsDGV.SelectedRows.Count > 0 && (bool)borrowsDGV.SelectedRows[0].Cells[expiredDGVC.Name].Value)
            {
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("wypoz_id", borrowsDGV.SelectedRows[0].Cells[wypozIdDGVC.Name].Value.ToString());
                parameters[1] = new ReportParameter("uzytk_id", borrowsDGV.SelectedRows[0].Cells[userIdDGVC.Name].Value.ToString());
                RdlViewer.MainForm printForm = new RdlViewer.MainForm("Upomnienia.rdl", parameters, "coliber", Settings.ConnectionString);

                printForm.ShowDialog();
            }
            else
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("there_are_no_reminders_for_this_resource", "Brak upomnień dla danego zasobu. Termin zwrotu nie został przekroczony."), _translationsDictionary.getStringFromDictionary("there_are_no_reminders", "Brak upomnień"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
