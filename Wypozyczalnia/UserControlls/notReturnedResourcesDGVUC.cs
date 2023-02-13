using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace Wypozyczalnia
{
    public partial class notReturnedResourcesDGVUC : UserControl
    {
        int userId;
        bool asc;
        public Action<int> OnReturnBorrow { get; set; }
        private Dictionary<string, string> _translationsDictionary;
        public notReturnedResourcesDGVUC()
        {
            InitializeComponent();

            setControlsText();

            Dictionary<int, string> searchFieldsDictionary = new Dictionary<int, string>();
            searchFieldsDictionary.Add(0, _translationsDictionary.getStringFromDictionary("all_borrowed", "Wszystkie wypożyczone"));
            searchFieldsDictionary.Add(1, _translationsDictionary.getStringFromDictionary("borrowed_books", "Wypożyczone książki"));
            searchFieldsDictionary.Add(2, _translationsDictionary.getStringFromDictionary("borrowed_magazines", "Wypożyczone czasopisma"));
            searchFieldsDictionary.Add(3, "Wypożyczone artykuły");
            searchFieldsDictionary.Add(4, "Wypożyczone normy");

            typesComboBox.DisplayMember = "Value";
            typesComboBox.ValueMember = "Key";
            typesComboBox.DataSource = new BindingSource(searchFieldsDictionary, null);

            Manager manager = new Manager(-1, Settings.ConnectionString);
            barcodeNotReturnedDGVC.Visible = manager.WypozyczalniaConfiguration.ShowBarcodeColumn;            
        }
        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(descNotReturnedDGVC, "description");
            mapping.Add(authorsNotReturnedDGVC, "authors");
            mapping.Add(NoInvNotReturnedDGVC, "inventory_number");
            mapping.Add(sygNotReturnedDGVC, "signature");
            mapping.Add(barcodeNotReturnedDGVC, "barcode");
            mapping.Add(borrowDateNotReturnedDGVC, "borrow_date");
            mapping.Add(limitNotReturnedDGVC, "limit");
            mapping.Add(dateNotReturnedDGVC, "expected_date_of_return");            

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        public void LoadNotReturned(int userID, bool asc)
        {
            this.userId = userID;
            this.asc = asc;

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_uzytkownik_zasoby_niezwrocone @user_id, @group_id, @order_asc; ";
            Command.Parameters.AddWithValue("@user_id", userID);
            Command.Parameters.AddWithValue("@group_id", typesComboBox.SelectedValue);
            Command.Parameters.AddWithValue("@order_asc", asc);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (notReturnedDGV.Rows.Count > 0)
                notReturnedDGV.Rows.Clear();

            int idx = 0;

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                idx = notReturnedDGV.Rows.Add(Dt.Rows[i]["wypoz_id"], Dt.Rows[i]["opis"], Dt.Rows[i]["autor"], Dt.Rows[i]["syg"], Dt.Rows[i]["numer_inw"], Dt.Rows[i]["k_kreskowy"], Dt.Rows[i]["data_wypoz2"], Dt.Rows[i]["limit_czasu"], Dt.Rows[i]["data_przewidywana"], GeneralBase.ConvertToBool(Dt.Rows[i]["przedawnione"].ToString()));

                if (Dt.Rows[i]["przedawnione"].ToString() == "1")
                    notReturnedDGV.Rows[idx].Cells["dateNotReturnedDGVC"].Style.ForeColor = Color.Red;
            }            
        }

        private void zawrotZasobuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnResource();
        }

        public void ReturnResource()
        {
            if (notReturnedDGV.SelectedRows.Count > 0)
            {
                ZwrotForm ZF = new ZwrotForm(notReturnedDGV.SelectedRows[0].Cells[wypozIDNotReturnedDGVC.Name].Value.ToString(), null, false);
                ZF.ShowDialog();

                LoadNotReturned(this.userId, asc);

                if (this.ParentForm is UserForm)
                    (this.ParentForm as UserForm).UpdateTabsNames(true);

                if (OnReturnBorrow != null)
                {
                    // Wywołujemy akcję
                    OnReturnBorrow(this.userId);
                }
            }
        }

        #region private void notReturnedDGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        private void notReturnedDGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                notReturnedDGV.CurrentCell = notReturnedDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];

                notReturnedDGV.Rows[e.RowIndex].Selected = true;
                notReturnedDGV.Focus();
            }
        }
        #endregion

        private void typesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadNotReturned(userId, asc);            
        }

        private void drukujUpomnienieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (notReturnedDGV.SelectedRows.Count > 0 && (bool)notReturnedDGV.SelectedRows[0].Cells[expiredDGVC.Name].Value)
            {
                ReportParameter[] parameters = new ReportParameter[2];
                parameters[0] = new ReportParameter("wypoz_id", notReturnedDGV.SelectedRows[0].Cells[wypozIDNotReturnedDGVC.Name].Value.ToString());
                parameters[1] = new ReportParameter("uzytk_id", userId.ToString());
                RdlViewer.MainForm printForm = new RdlViewer.MainForm("Upomnienia.rdl", parameters, "coliber", Settings.ConnectionString);

                printForm.ShowDialog();
            }
            else
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("there_are_no_reminders_for_this_resource", "Brak upomnień dla danego zasobu. Termin zwrotu nie został przekroczony."), _translationsDictionary.getStringFromDictionary("there_are_no_reminders", "Brak upomnień"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
