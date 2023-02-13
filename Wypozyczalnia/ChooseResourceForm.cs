using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Wypozyczalnia
{
    public partial class ChooseResourceForm : Form
    {
        private Manager _manager;
        public enum WorkMode { ManageResource, SelectResource };
        private WorkMode _currentMode;
        private Form _parent;
        public int CurrentResourceId { get { return resultDGV.SelectedRows.Count > 0 ? (int)resultDGV.SelectedRows[0].Cells[resourceIdDGVC.Name].Value : -1; } }
        private Dictionary<string, string> _translationsDictionary;

        public ChooseResourceForm(int EmployeeId, WorkMode Mode, Form Parent)
        {
            InitializeComponent();

            Settings.SetSettings();

            setControlsText();

            if (Parent != null)
            {
                this.MdiParent = Parent;
            }

            _currentMode = Mode;

            setResourceTypeCombobox();
            setSearchCombobox();

            _manager = new Manager(EmployeeId, Settings.ConnectionString);

            searchFieldComboBox.SelectedValue = _manager.WypozyczalniaConfiguration.ManualSearchField;
            
            compareComboBox.SelectedValue = _manager.WypozyczalniaConfiguration.Compare;
            selectButton.Enabled = resultDGV.Rows.Count > 0;
            barcodeDGVC.Visible = _manager.WypozyczalniaConfiguration.ShowBarcodeColumn;

            /*
            foreach (DataGridViewColumn col in resultDGV.Columns)
                col.SortMode = DataGridViewColumnSortMode.Programmatic;
            */

        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(borrowedCheckBox, "borrowed");
            mapping.Add(notBorrowedCheckBox, "not_borrowed");
            mapping.Add(descriptionDGVC, "title");
            mapping.Add(authorDGVC, "author");
            mapping.Add(barcodeDGVC, "barcode");
            mapping.Add(noInvDGVC, "inventory_number");
            mapping.Add(signatureDGVC, "signature");

            mapping.Add(selectButton, "select");
            mapping.Add(exitButton, "exit");


            mapping.Add(this, "choose_resource");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void GetData(string searchText, int field, bool? borrowed, int compareType, int resourceType, int sort1, int sort2, int sort3, int sort4)
        {
            if (string.IsNullOrWhiteSpace(searchText))
                searchText = "%";

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_szukaj @searchText, @field, @borrowed, @compareType, @resourceType, @sort1, @sort2, @sort3, @sort4; ";
            Command.Parameters.AddWithValue("@searchText", searchText.Trim());
            Command.Parameters.AddWithValue("@field", field);

            if(borrowed == null)
                Command.Parameters.AddWithValue("@borrowed", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@borrowed", borrowed);

            Command.Parameters.AddWithValue("@compareType", compareType);
            Command.Parameters.AddWithValue("@resourceType", resourceType);
            Command.Parameters.AddWithValue("@sort1", sort1);
            Command.Parameters.AddWithValue("@sort2", sort2);
            Command.Parameters.AddWithValue("@sort3", sort3);
            Command.Parameters.AddWithValue("@sort4", sort4);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            resultDGV.Rows.Clear();

            for(int i = 0; i < Dt.Rows.Count; i++)
            {                
                int idx = resultDGV.Rows.Add(Dt.Rows[i]["zasob_id"], Dt.Rows[i]["opis"], Coliber.App.NVL(Dt.Rows[i]["autor"]), Dt.Rows[i]["k_kreskowy"], Dt.Rows[i]["numer_inw"], Dt.Rows[i]["syg"]);

                if ((int)Dt.Rows[i]["wypozyczony"] == 1)
                    resultDGV.Rows[idx].DefaultCellStyle.BackColor = Color.LightSkyBlue;
            }            
        }

        private void setResourceTypeCombobox()
        {
            Dictionary<int, string> resourceTypesDictionary = new Dictionary<int, string>();
            resourceTypesDictionary.Add(1, _translationsDictionary.getStringFromDictionary("book", "Książki"));
            resourceTypesDictionary.Add(2,_translationsDictionary.getStringFromDictionary("magazines", "Czasopisma"));
            resourceTypesDictionary.Add(3, "Artykuły");
            resourceTypesDictionary.Add(4, "Normy");

            resourceTypeComboBox.DisplayMember = "Value";
            resourceTypeComboBox.ValueMember = "Key";
            resourceTypeComboBox.DataSource = new BindingSource(resourceTypesDictionary, null);
        }

        private void setSearchCombobox()
        {
            Dictionary<Configuration.SearchFieldMode, string> searchFieldsDictionary = new Dictionary<Configuration.SearchFieldMode, string>();
            searchFieldsDictionary.Add(Configuration.SearchFieldMode.Title, _translationsDictionary.getStringFromDictionary("title", "Tytuł"));
            searchFieldsDictionary.Add(Configuration.SearchFieldMode.Signature, _translationsDictionary.getStringFromDictionary("signature", "Sygnatura"));
            searchFieldsDictionary.Add(Configuration.SearchFieldMode.InvertoryNo, _translationsDictionary.getStringFromDictionary("inventory_number", "Numer inwentarzowy"));
            searchFieldsDictionary.Add(Configuration.SearchFieldMode.Barcode, _translationsDictionary.getStringFromDictionary("barcode", "Kod kreskowy"));

            searchFieldComboBox.DisplayMember = "Value";
            searchFieldComboBox.ValueMember = "Key";
            searchFieldComboBox.DataSource = new BindingSource(searchFieldsDictionary, null);

            Dictionary<Configuration.CompareMode, string> compareDictionary = new Dictionary<Configuration.CompareMode, string>();
            compareDictionary.Add(Configuration.CompareMode.Equals,_translationsDictionary.getStringFromDictionary("equals",  "równa się"));
            compareDictionary.Add(Configuration.CompareMode.StartsWith, _translationsDictionary.getStringFromDictionary("starts_with", "zaczyna się"));
            compareDictionary.Add(Configuration.CompareMode.Contains, _translationsDictionary.getStringFromDictionary("contains", "zawiera").ToLower());

            compareComboBox.DisplayMember = "Value";
            compareComboBox.ValueMember = "Key";
            compareComboBox.DataSource = new BindingSource(compareDictionary, null);
        }

        private void ChooseResourceForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            bool? borrowed;
            borrowed = ((borrowedCheckBox.Checked && notBorrowedCheckBox.Checked) || (!borrowedCheckBox.Checked && !notBorrowedCheckBox.Checked)) ? null : (bool?)borrowedCheckBox.Checked;

            GetData(searchTextBox.Text, (int)searchFieldComboBox.SelectedValue, borrowed, (int)compareComboBox.SelectedValue, (int)resourceTypeComboBox.SelectedValue, (int)_manager.WypozyczalniaConfiguration.Sort1, (int)_manager.WypozyczalniaConfiguration.Sort2, (int)_manager.WypozyczalniaConfiguration.Sort3, (int)_manager.WypozyczalniaConfiguration.Sort4);

            selectButton.Enabled = resultDGV.Rows.Count > 0;

            if (resultDGV.Rows.Count == 0)
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("there_is_no_searching_resource", "Brak szukanego zasobu."), _translationsDictionary.getStringFromDictionary("searching", "Wyszukiwanie"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Search();
        }

        private void resultDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (resultDGV.SelectedRows.Count > 0 && e.KeyCode == Keys.Enter)
                selectRecord((int)resultDGV.SelectedRows[0].Cells[resourceIdDGVC.Name].Value);
        }

        private void selectRecord(int id)
        {
            if(_currentMode == WorkMode.ManageResource)
            {
                ResourceForm resource = new ResourceForm(id, _manager.EmployeeId, this);
                resource.Show();
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }

        private void selectButton_Click(object sender, EventArgs e)
        {
            if (resultDGV.SelectedRows.Count > 0)
                selectRecord((int)resultDGV.SelectedRows[0].Cells[resourceIdDGVC.Name].Value);
        }

        private void resultDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (resultDGV.SelectedRows.Count > 0 && e.RowIndex != -1)
                selectRecord((int)resultDGV.SelectedRows[0].Cells[resourceIdDGVC.Name].Value);
        }
    }
}
