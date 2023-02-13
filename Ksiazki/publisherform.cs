using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Ksiazki
{
    public partial class PublisherForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        public string[] Publisher;

        public PublisherForm(string PublisherName, string Place)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            ToolTip SelectToolTip = new ToolTip();
            SelectToolTip.SetToolTip(SelectButton, _T("choose_country"));

            ToolTip CleanToolTip = new ToolTip();
            CleanToolTip.SetToolTip(CleanPublisherCountryButton, _T("to_clean"));

            FullNameTextBox.Text = PublisherName;
            ShortTextBox.Text = PublisherName;
            PlaceTextBox.Text = Place;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "publisher");
            mapping.Add(CancelButton, "cancel");
            mapping.Add(OKButton, "confirm");
            mapping.Add(label6, "publishers_country");
            mapping.Add(label5, "contact");
            mapping.Add(label4, "url_address");
            mapping.Add(label3, "place_of_publication");
            mapping.Add(label2, "publisher_name_abb");
            mapping.Add(label1, "publisher_name");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC CountryList;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[2];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "kod";
            Columns[0].Name = "Kod";
            Columns[0].HeaderText = _T("code");
            Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "p_sk_nazwa";
            Columns[1].Name = "Państwo";
            Columns[1].HeaderText = _T("country");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Publisher = new ShowForm(Command, Columns, false, "Państwo");
            Publisher.Width = 400;
            Publisher.Text = _T("choose_country");

            if (Publisher.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CountryTextBox.Text = Publisher.Dt.Cells["Kod"].Value.ToString();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FullNameTextBox.Text.Trim()))
            {
                MessageBox.Show(_T("enter_name_of_publisher"), "data_fillout", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DialogResult = DialogResult.None;
                return;
            }

            Publisher = new string[] {FullNameTextBox.Text, ShortTextBox.Text, PlaceTextBox.Text, AddressTextBox.Text, ContactTextBox.Text, CountryTextBox.Text, "new" };
            this.Close();
        }

        private void PublisherForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void CleanPublisherCountryButton_Click(object sender, EventArgs e)
        {
            CountryTextBox.Text = "";
        }
    }
}
