using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Czasopisma
{
    public partial class DistributorForm : Form
    {
        public string[] Kolporter;
        private Dictionary<string, string> _translationsDictionary;
        public DistributorForm(string[] Kolporter = null)
        {
            InitializeComponent();

            setControlsText();

            ToolTip SelectToolTip = new ToolTip();
            SelectToolTip.SetToolTip(CountryButton, _translationsDictionary.getStringFromDictionary("choose_country", "Wybór państwa z listy"));

            if (Kolporter != null)
            {
                this.NameTextBox.Text = Kolporter[0];
                this.ShortTextBox.Text = Kolporter[1];
                this.AddressTextBox.Text = Kolporter[2];
                this.PlaceTextBox.Text = Kolporter[3];
                this.ZipTextBox.Text = Kolporter[4];
                this.CountryTextBox.Text = Kolporter[5];
                this.PhoneTextBox.Text = Kolporter[6];
                this.Phone2TextBox.Text = Kolporter[7];
                this.FaxTextBox.Text = Kolporter[8];
            }
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(nameLabel, "name");
            mapping.Add(shortNameLabel, "short_name");
            mapping.Add(addressLabel, "address");
            mapping.Add(cityLabel, "city");
            mapping.Add(zipLabel, "zip");
            mapping.Add(countryLabel, "country");
            mapping.Add(contactDetailsLabel, "contact_details");
            mapping.Add(phoneLabel, "phone");
            mapping.Add(faxLabel, "fax");            

            mapping.Add(OKButton, "confirm");
            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "supplier");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(NameTextBox.Text.Trim()))
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("enter_name_of_supplier", "Proszę podać nazwę dostawcy"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Popraw dane"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                NameTextBox.Focus();
                return;
            }

            Kolporter = new string[] { NameTextBox.Text.Trim(), ShortTextBox.Text.Trim(), AddressTextBox.Text.Trim(), PlaceTextBox.Text.Trim(), ZipTextBox.Text.Trim(), CountryTextBox.Text.Trim(), PhoneTextBox.Text.Trim(), Phone2TextBox.Text.Trim(), FaxTextBox.Text.Trim() };
            this.Close();
        }

        private void DistributorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void CountryButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC CountryList;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[2];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "kod";
            Columns[0].Name = "Kod";
            Columns[0].HeaderText = _translationsDictionary.getStringFromDictionary("code", "Kod");
            Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "p_sk_nazwa";
            Columns[1].Name = "Państwo";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("country", "Państwo");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Publisher = new ShowForm(Command, Columns);
            Publisher.Text = _translationsDictionary.getStringFromDictionary("choose_contry", "Wybierz państwo");

            if (Publisher.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CountryTextBox.Text = Publisher.Dt.Cells["Kod"].Value.ToString();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
