using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Wypozyczalnia
{
    public partial class returnedResourcesDGVUC : UserControl
    {
        int userId;
        private Dictionary<string, string> _translationsDictionary;
        public returnedResourcesDGVUC()
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
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(descNotReturnedDGVC, "description");
            mapping.Add(authorsNotReturnedDGVC, "authors");
            mapping.Add(NoInvNotReturnedDGVC, "signature");
            mapping.Add(sygNotReturnedDGVC, "inventory_number");
            mapping.Add(barcodeNotReturnedDGVC, "barcode");
            mapping.Add(borrowDateNotReturnedDGVC, "borrow_date");
            mapping.Add(limitNotReturnedDGVC, "limit");
            mapping.Add(dateNotReturnedDGVC, "date_of_return");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        public void LoadReturned(int userID)
        {
            this.userId = userID;            

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_uzytkownik_zasoby_zwrocone @user_id, @group_id; ";
            Command.Parameters.AddWithValue("@user_id", userID);
            Command.Parameters.AddWithValue("@group_id", typesComboBox.SelectedValue);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (returnedDGV.Rows.Count > 0)
                returnedDGV.Rows.Clear();

            int idx = 0;

            for (int i = 0; i < Dt.Rows.Count; i++)
            {                
                //idx = returnedDGV.Rows.Add(Dt.Rows[i]["wypoz_id"], Dt.Rows[i]["data_wypoz2"], Dt.Rows[i]["opis"], Dt.Rows[i]["autor"], Dt.Rows[i]["limit_czasu"], Dt.Rows[i]["data_przewidywana"], Dt.Rows[i]["syg"], Dt.Rows[i]["numer_inw"], Dt.Rows[i]["k_kreskowy"]);
                idx = returnedDGV.Rows.Add(Dt.Rows[i]["wypoz_id"], Dt.Rows[i]["data_wypoz2"], Dt.Rows[i]["data_zwrot"], Dt.Rows[i]["opis"], Dt.Rows[i]["autor"], Dt.Rows[i]["limit_czasu"], Dt.Rows[i]["syg"], Dt.Rows[i]["numer_inw"], Dt.Rows[i]["k_kreskowy"]);

                /*if (Dt.Rows[i]["przedawnione"].ToString() == "1")
                    returnedDGV.Rows[idx].Cells["dateNotReturnedDGVC"].Style.ForeColor = Color.Red;*/
            }

            if (this.ParentForm is UserForm)
                (this.ParentForm as UserForm).UpdateTabsNames();
        }

        #region private void returnedDGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        private void returnedDGV_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                returnedDGV.CurrentCell = returnedDGV.Rows[e.RowIndex].Cells[e.ColumnIndex];

                returnedDGV.Rows[e.RowIndex].Selected = true;
                returnedDGV.Focus();
            }
        }
        #endregion

        private void typesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            LoadReturned(userId);
        }
    }
}
