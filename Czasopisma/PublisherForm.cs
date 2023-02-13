using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Czasopisma
{
    public partial class PublisherForm : Form
    {
        public string[] Publisher;
        private Dictionary<string, string> _translationsDictionary;

        public PublisherForm(string[] Publisher = null)
        {
            InitializeComponent();
            setControlsText();

            ToolTip SelectToolTip = new ToolTip();
            SelectToolTip.SetToolTip(SelectButton, _translationsDictionary.getStringFromDictionary("choose_country", "Wybór państwa z listy"));

            if (Publisher != null)
            {
                FullNameTextBox.Text = Publisher[0];
                ShortTextBox.Text = Publisher[1];
                PlaceTextBox.Text = Publisher[2];
                AddressTextBox.Text = Publisher[3];
                ContactTextBox.Text = Publisher[4];
                CountryTextBox.Text = Publisher[5];
            }
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(nameLabel, "name");
            mapping.Add(shortNameLabel, "short_name");
            mapping.Add(placeLabel, "place_of_publication");
            mapping.Add(addressLabel, "address");
            mapping.Add(contactLabel, "contact");
            mapping.Add(countryLabel, "country");

            mapping.Add(OKButton, "confirm");
            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "publisher");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void SelectButton_Click(object sender, EventArgs e)
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
            Publisher.Text = _translationsDictionary.getStringFromDictionary("choose_country", "Wybierz państwo");

            if (Publisher.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CountryTextBox.Text = Publisher.Dt.Cells["Kod"].Value.ToString();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FullNameTextBox.Text.Trim()))
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("enter_name_of_publisher", "Proszę podać nazwę wydawcy"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Popraw dane"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                FullNameTextBox.Focus();
                return;
            }

            Publisher = new string[] {FullNameTextBox.Text, ShortTextBox.Text, PlaceTextBox.Text, AddressTextBox.Text, ContactTextBox.Text, CountryTextBox.Text, "new" };
            this.Close();
        }

        private void PublisherForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
