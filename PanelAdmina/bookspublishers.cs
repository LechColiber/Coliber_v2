using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class BooksPublishers : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        Connection NewConnection;
        string SelectedTable;
        string Table = "dbo.wydawca_k";

        OdbcDataAdapter Adapter;
        DataSet Ds;
        DataTable RodzajDataTable;

        List<int> CodesList;

        private string SearchText;

        // OK
        public BooksPublishers(Connection NewConnection, string Caption, string SelectedTable)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();
            this.StartPosition = FormStartPosition.CenterParent;

            this.NewConnection = NewConnection;

            this.Text += " " + Caption;
            this.SelectedTable = SelectedTable;

            RodzajDataTable = ReturnDataTable();
            SetIDRodzajListToComboBox(ReturnIDRodzajList(RodzajDataTable));
            SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

            SearchText = "";
            label1.Text = "";
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "editors");
            mapping.Add(label4, "searching");
            mapping.Add(EditButton, "edit");
            mapping.Add(label3, "books_collection");
            mapping.Add(ShowBooksButton, "show_books");
            mapping.Add(label2, "in_articles");
            mapping.Add(label12, "key_appears_in");
            mapping.Add(ExitButton, "exit");
            mapping.Add(PrintButton, "print");
            mapping.Add(MergeButton, "merge");
            mapping.Add(AddButton, "add");
            mapping.Add(DelButton, "delete");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        // OK
        private void SelectFromDb(int id_rodzaj)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                if (IDRodzajComboBox.SelectedValue.ToString().ToLower().Trim() == _T("all").ToLower())
                {
                    Command.CommandText = "SELECT id_wydawcy AS [ID wydawcy], LTRIM(RTRIM(nazwa_w)) AS Nazwa, " +
                                          "LTRIM(RTRIM(sk_nazwa_w)) AS [Nazwa skrócona], " +                                          
                                           "LTRIM(RTRIM(miasto_w)) AS [Miasto], " +
                                           "LTRIM(RTRIM(kontakt_w)) AS [Kontakt], " +
                                           "LTRIM(RTRIM(adres_w)) AS [Adres], " +
                                           "LTRIM(RTRIM(id_panst_w)) AS [Kraj wydawcy], " +
                                           "LTRIM(RTRIM(rodzaje.nazwa)) AS [Księgozbiór], " + this.Table + ".id_rodzaj " +
                                           "FROM " + this.Table + " " +
                                           "JOIN rodzaje ON rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " +
                                           "ORDER BY nazwa_w";
                }
                else
                {
                    Command.CommandText = "SELECT id_wydawcy AS [ID wydawcy], LTRIM(RTRIM(nazwa_w)) AS Nazwa, " +
                                          "LTRIM(RTRIM(sk_nazwa_w)) AS [Nazwa skrócona], " +                                          
                                           "LTRIM(RTRIM(miasto_w)) AS [Miasto], " +
                                           "LTRIM(RTRIM(kontakt_w)) AS [Kontakt], " +
                                           "LTRIM(RTRIM(adres_w)) AS [Adres], " +
                                           "LTRIM(RTRIM(id_panst_w)) AS [Kraj wydawcy], " +
                                           "LTRIM(RTRIM(rodzaje.nazwa)) AS [Księgozbiór], " + this.Table + ".id_rodzaj " +
                                           "FROM " + this.Table + " " +
                                           "JOIN rodzaje ON rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " +
                                           "WHERE " + this.Table + ".id_rodzaj = ? ORDER BY nazwa_w";

                    Command.Parameters.AddWithValue("id_rodzaj", id_rodzaj);
                }
                //Clipboard.SetText(Command.CommandText);
                Adapter = new OdbcDataAdapter();
                Adapter.SelectCommand = Command;

                Ds = new DataSet();

                Adapter.Fill(Ds);
                Ds.Tables[0].Columns.Add("L.p.");
                Ds.Tables[0].Columns["L.p."].SetOrdinal(0);

                for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                    Ds.Tables[0].Rows[i]["L.p."] = i + 1;

                Ds.Tables[0].Columns["ID wydawcy"].ReadOnly = true;
                dataGridView1.DataSource = Ds.Tables[0];

                DataGridViewTextBoxColumn NameColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Nazwa"];
                NameColumn.MaxInputLength = 120;
                DataGridViewTextBoxColumn ShortNameColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Nazwa skrócona"];
                ShortNameColumn.MaxInputLength = 120;
                DataGridViewTextBoxColumn IDCountryColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Kraj wydawcy"];
                IDCountryColumn.MaxInputLength = 3;
                DataGridViewTextBoxColumn CityColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Miasto"];
                CityColumn.MaxInputLength = 30;
                DataGridViewTextBoxColumn ContactColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Kontakt"];
                ContactColumn.MaxInputLength = 200;
                DataGridViewTextBoxColumn AddressColumn = (DataGridViewTextBoxColumn)dataGridView1.Columns["Adres"];
                AddressColumn.MaxInputLength = 120;

                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

                dataGridView1.Columns["L.p."].HeaderText = _T("oridinal_short");
                dataGridView1.Columns["Nazwa"].HeaderText = _T("name");
                dataGridView1.Columns["Nazwa skrócona"].HeaderText = _T("short_name");
                dataGridView1.Columns["Miasto"].HeaderText = _T("city");
                dataGridView1.Columns["Kontakt"].HeaderText = _T("contact");
                dataGridView1.Columns["Adres"].HeaderText = _T("address");
                dataGridView1.Columns["Kraj wydawcy"].HeaderText = _T("publishers_country");

                dataGridView1.Columns["Księgozbiór"].Visible = false;
                dataGridView1.Columns["ID wydawcy"].Visible = false;
                dataGridView1.Columns["id_rodzaj"].Visible = false;

                dataGridView1.Refresh();

                if (dataGridView1.Rows.Count < 1)
                    CountTextBox.Text = "";
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        // OK
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {                       
            SqlCommand Command = new SqlCommand();                
            Command.CommandText = "SELECT COUNT(*) AS count " +
                                  "FROM dbo.ksiazki_new " +
                                  "WHERE id_wyd1 = @id OR id_wyd2 = @id; ";
            Command.Parameters.AddWithValue("@id", Int32.Parse(dataGridView1["ID wydawcy", e.RowIndex].Value.ToString()));

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.coliberConnection);

            if(Dt.Rows.Count > 0)
            {
                CountTextBox.Text = Dt.Rows[0]["count"].ToString();
            }                      
        }

        // OK
        private void ShowBooksButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                SearchText = "";
                label1.Text = "";

                if (CountTextBox.Text != "")
                {                    
                    ShowList ShowListForm = new ShowList(GetListWherePublisherOccured(Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID wydawcy"].Value.ToString())), _T("for") + " " + dataGridView1.SelectedRows[0].Cells["Nazwa"].Value.ToString());
                    ShowListForm.ShowDialog();
                }
                dataGridView1.Focus();
            }
        }

        // OK
        private List<string> GetListWherePublisherOccured(int IDPublisher)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT tytul_gl " +
                                      "FROM dbo.ksiazki_new " +
                                      "WHERE id_wyd1 = ? OR id_wyd2 = ? " +
                                      "ORDER BY tytul_gl";

                Command.Parameters.AddWithValue("Pub", IDPublisher);
                Command.Parameters.AddWithValue("Pub", IDPublisher);

                OdbcDataReader Reader;
                Reader = Command.ExecuteReader();

                List<string> List = new List<string>();

                while (Reader.Read())
                {
                    List.Add(Reader.GetValue(0).ToString());
                }

                Reader.Close();
                Command.Parameters.Clear();

                return List;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return null;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // OK
        private void AddButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";
            int idRodzaj;
            idRodzaj = ReturnIDRodzaj(RodzajDataTable);
            if (IDRodzajComboBox.SelectedValue.ToString().ToLower().Trim() == _T("all").ToLower())
            {
                MessageBox.Show(_T("choose_invertory_to_add_new"), _T("information"), MessageBoxButtons.OK);
            }
            else
            {
                EditPublisherForm EPF = new EditPublisherForm(NewConnection, "", "", "", "", "", "", ReturnIDRodzaj(RodzajDataTable), 'k', -1, 1);
                EPF.ShowDialog();
                SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
            }
        }

        // OK
        private DataTable ReturnDataTable()
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT id_rodzaj, LTRIM(RTRIM(nazwa)) AS [nazwa] FROM dbo.rodzaje; ";

                OdbcDataReader Reader = Command.ExecuteReader();
                DataTable Dt = new DataTable();
                Dt.Load(Reader);
                Reader.Close();

                return Dt;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return null;
        }

        // OK
        private List<string> ReturnIDRodzajList(DataTable Dt)
        {
            try
            {
                List<string> List = new List<string>();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    List.Add(Dt.Rows[i][1].ToString());
                }

                List.Add(_T("all"));
                List.Sort();
                return List;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return null;
        }

        // OK
        private void SetIDRodzajListToComboBox(List<string> List)
        {
            IDRodzajComboBox.DataSource = List;
        }

        // OK
        private int ReturnIDRodzaj(DataTable Dt)
        {
            int id_rodzaj = 0;

            try
            {
                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    if (Dt.Rows[i][1].ToString() == IDRodzajComboBox.SelectedValue.ToString())
                        id_rodzaj = Int32.Parse(Dt.Rows[i][0].ToString());
                }

                return id_rodzaj;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            return 0;
        }

        // OK
        private void IDRodzajComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            SelectFromDb(ReturnIDRodzaj(RodzajDataTable));
        }

        // OK
        private void MergeButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                try
                {
                    OdbcCommand Command = new OdbcCommand();
                    Command.Connection = NewConnection.AppConnection;
                    Command.CommandText = "SELECT id_wydawcy AS [id], LTRIM(RTRIM(nazwa_w)) AS [Nazwa] FROM " + this.Table + " " + "LEFT JOIN dbo.rodzaje ON dbo.rodzaje.id_rodzaj = " + this.Table + ".id_rodzaj " + "WHERE id_wydawcy != ? ORDER BY nazwa_w; ";
                    Command.Parameters.AddWithValue("@IDPublisher", Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID wydawcy"].Value.ToString()));

                    OdbcDataAdapter Adapter = new OdbcDataAdapter();
                    Adapter.SelectCommand = Command;

                    DataSet ChooseDs = new DataSet();
                    Adapter.Fill(ChooseDs);

                    ChooseSecond ChSForm = new ChooseSecond(ChooseDs);

                    if (ChSForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        int ID = ChSForm.ReturnID();
                        int Row = 0;

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (Int32.Parse(dataGridView1["ID wydawcy", i].Value.ToString()) == ID)
                            {
                                Row = i;
                                break;
                            }
                        }

                        if (MessageBox.Show(_T("merge_q") + "\"" + dataGridView1.SelectedRows[0].Cells["Nazwa"].Value.ToString() + "\"" + _T("with") + "\"" + dataGridView1["Nazwa", Row].Value.ToString() + "\"?", _T("data_merge"), MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                        {
                            OdbcCommand MergeCommand = new OdbcCommand();
                            MergeCommand.Connection = NewConnection.AppConnection;

                            MergeCommand.CommandText = "UPDATE " + this.SelectedTable + " " + 
                                                        "SET " + 
                                                        "id_wyd1 = (CASE WHEN id_wyd1 = ? THEN ? ELSE id_wyd1 END), " + 
                                                        "id_wyd2 = (CASE WHEN id_wyd2 = ? THEN ? ELSE id_wyd2 END) " + 
                                                        " WHERE id_wyd1 = ? OR id_wyd2 = ?";
                            MergeCommand.Parameters.AddWithValue("@IDPublisher", Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID wydawcy"].Value.ToString()));
                            MergeCommand.Parameters.AddWithValue("@IDPublisher", Int32.Parse(dataGridView1["ID wydawcy", Row].Value.ToString()));

                            MergeCommand.Parameters.AddWithValue("@IDPublisher", Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID wydawcy"].Value.ToString()));
                            MergeCommand.Parameters.AddWithValue("@IDPublisher", Int32.Parse(dataGridView1["ID wydawcy", Row].Value.ToString()));

                            MergeCommand.Parameters.AddWithValue("@IDPublisher", Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID wydawcy"].Value.ToString()));
                            MergeCommand.Parameters.AddWithValue("@IDPublisher", Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID wydawcy"].Value.ToString()));

                            MergeCommand.ExecuteNonQuery();

                            DeletePublisher(Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID wydawcy"].Value.ToString()));

                            SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1["ID wydawcy", i].Value.ToString() == ID.ToString())
                                {
                                    dataGridView1.ClearSelection();
                                    dataGridView1.Rows[i].Cells["Nazwa"].Selected = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        // OK
        private void DelButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (CountTextBox.TextLength > 0 && Int32.Parse(CountTextBox.Text) > 0)
                {
                    if (MessageBox.Show(_T("show_res_q") + " " + dataGridView1.SelectedRows[0].Cells["Nazwa"].Value.ToString() + "?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        ShowList ShowListForm = new ShowList(GetListWherePublisherOccured(Int32.Parse(dataGridView1.SelectedRows[0].Cells["Id wydawcy"].Value.ToString())), dataGridView1.SelectedRows[0].Cells["Nazwa"].Value.ToString());
                        ShowListForm.ShowDialog();
                    }
                }
                if (MessageBox.Show(_T("to_delete") + " " + dataGridView1.SelectedRows[0].Cells["Nazwa"].Value.ToString() + "?", _T("db_deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    DeletePublisher(Int32.Parse(dataGridView1.SelectedRows[0].Cells["ID wydawcy"].Value.ToString()));
                }
            }
        }

        // OK
        private void DeletePublisher(int IDPublisher)
        {
            try
            {
                int FirstDisplayedRow = dataGridView1.FirstDisplayedScrollingRowIndex;
                int CurrentRow = dataGridView1.CurrentRow.Index;

                OdbcCommand DeleteCommand = new OdbcCommand();
                DeleteCommand.Connection = NewConnection.AppConnection;

                //DeleteCommand.CommandText = "DELETE FROM " + this.Table + " WHERE id_wydawcy = ?";
                DeleteCommand.CommandText = "ModifyPublisher '', '', '', '', '', '', 'FALSE', '', 1, ?, 'k', 3; ";
                
                DeleteCommand.Parameters.AddWithValue("@ID", IDPublisher);

                DeleteCommand.ExecuteNonQuery();

                MessageBox.Show(_T("completed"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

                if (dataGridView1.Rows.Count > 0)
                {
                    if (CurrentRow > dataGridView1.CurrentRow.Index)
                        CurrentRow--;

                    dataGridView1.CurrentCell = dataGridView1["Nazwa", CurrentRow];
                    dataGridView1.FirstDisplayedScrollingRowIndex = FirstDisplayedRow;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        // OK
        private void BooksPublishers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void Search(string Letter)
        {
            if (Letter == '\b'.ToString())
            {
                if (SearchText.Length > 0)
                {
                    SearchText = SearchText.Remove(SearchText.Length - 1);
                    label1.Text = SearchText;
                }
            }
            else if (Letter == '\r'.ToString())
            {

            }
            else
            {
                SearchText += Letter;
                label1.Text = SearchText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["Nazwa"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1["Nazwa", i];
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        // OK
        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search(e.KeyChar.ToString());
        }

        // OK
        private void EditButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            if (dataGridView1.CurrentRow != null)
            {
                string ID_current = dataGridView1.CurrentRow.Cells["ID wydawcy"].Value.ToString();

                EditPublisherForm EPF = new EditPublisherForm(NewConnection, dataGridView1.CurrentRow.Cells["Nazwa"].Value.ToString(), dataGridView1.CurrentRow.Cells["Nazwa skrócona"].Value.ToString(), dataGridView1.CurrentRow.Cells["Kraj wydawcy"].Value.ToString(), dataGridView1.CurrentRow.Cells["Miasto"].Value.ToString(), dataGridView1.CurrentRow.Cells["Kontakt"].Value.ToString(), dataGridView1.CurrentRow.Cells["Adres"].Value.ToString(), Int32.Parse(dataGridView1.CurrentRow.Cells["id_rodzaj"].Value.ToString()), 'k', Int32.Parse(dataGridView1.CurrentRow.Cells["ID wydawcy"].Value.ToString()), 2);

                if (EPF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SelectFromDb(ReturnIDRodzaj(RodzajDataTable));

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (dataGridView1["ID wydawcy", i].Value.ToString() == ID_current)
                        {
                            dataGridView1.ClearSelection();
                            dataGridView1.Rows[i].Cells["Nazwa"].Selected = true;
                        }
                    }
                }
            }
        }

        // OK
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            SearchText = "";
            label1.Text = "";            
        }

        // OK
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SearchText = "";
                label1.Text = "";
            }
        }
        
        // OK
        private void PrintButton_Click(object sender, EventArgs e)
        {
            SearchText = "";
            label1.Text = "";

            try
            {
                OdbcCommand ReportCommand = new OdbcCommand();
                ReportCommand.Connection = NewConnection.AppConnection;

                ReportCommand.CommandText = "SELECT LTRIM(RTRIM(nazwa_w)) AS nazwa_w, LTRIM(RTRIM(sk_nazwa_w)) AS sk_nazwa_w, LTRIM(RTRIM(id_panst_w)) AS id_panst_w, LTRIM(RTRIM(miasto_w)) AS miasto_w, LTRIM(RTRIM(kontakt_w)) AS kontakt_w, LTRIM(RTRIM(adres_w)) AS adres_w FROM wydawca_k ORDER BY nazwa_w;";

                ShowReport Report = new ShowReport(ReportCommand, "BookPublisherReport");

                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                Report.ShowDialog();

                Wait.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
    }
}
