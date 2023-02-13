using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class ModifyDistributorForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        public string[] Kolporter;
        private bool EditMode;
        private string ID;

        public String Ciag
        {
            get { return this.NameTextBox.Text.Trim(); }
        }
        public ModifyDistributorForm()
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            ToolTip SelectToolTip = new ToolTip();
            SelectToolTip.SetToolTip(CountryButton, _T("choose_country"));

            EditMode = false;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "adding");
            mapping.Add(EscapeButton, "cancel");
            mapping.Add(OKButton, "confirm");
            mapping.Add(label7, "contact_details");
            mapping.Add(label12, "country");
            mapping.Add(label8, "fax");
            mapping.Add(label5, "phone");
            mapping.Add(label6, "code");
            mapping.Add(label3, "city");
            mapping.Add(label4, "address");
            mapping.Add(label2, "short_name");
            mapping.Add(label1, "name");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        public ModifyDistributorForm(string Name, string Short, string Address, string Place, string Zip, string Country, string Phone, string Phone2, string Fax, string ID)
            : this()
        {                
            this.Text = _T("edit");

            EditMode = true;

            this.ID = ID;
            this.NameTextBox.Text = Name;
            this.ShortTextBox.Text = Short;
            this.AddressTextBox.Text = Address;
            this.PlaceTextBox.Text = Place;
            this.ZipTextBox.Text = Zip;
            this.CountryTextBox.Text = Country;
            this.PhoneTextBox.Text = Phone;
            this.Phone2TextBox.Text = Phone2;
            this.FaxTextBox.Text = Fax;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Kolporter = new string[] { NameTextBox.Text.Trim(), ShortTextBox.Text.Trim(), AddressTextBox.Text.Trim(), PlaceTextBox.Text.Trim(), ZipTextBox.Text.Trim(), CountryTextBox.Text.Trim(), PhoneTextBox.Text.Trim(), Phone2TextBox.Text.Trim(), FaxTextBox.Text.Trim() };

            SqlCommand Command = new SqlCommand();
            if (!EditMode)
            {
                Command.CommandText += "EXEC Czasop_AddDistributor @p_nazwa_k, @p_sk_nazwa_k, @p_id_panst_k, @p_kod_k, @p_miasto_k, @p_adres_k, @p_telefon_k, @p_telefon2_k, @p_fax_k, @id; ";
                Command.Parameters.AddWithValue("@id", -1);
            }
            else
            {
                Command.CommandText += "EXEC PA_EditDistributor @p_nazwa_k, @p_sk_nazwa_k, @p_id_panst_k, @p_kod_k, @p_miasto_k, @p_adres_k, @p_telefon_k, @p_telefon2_k, @p_fax_k, @id; ";
                Command.Parameters.AddWithValue("@id", this.ID);
            }
            
            Command.Parameters.AddWithValue("@p_nazwa_k", Kolporter[0]);
            Command.Parameters.AddWithValue("@p_sk_nazwa_k", Kolporter[1]);
            Command.Parameters.AddWithValue("@p_id_panst_k", Kolporter[5]);
            Command.Parameters.AddWithValue("@p_kod_k", Kolporter[4]);
            Command.Parameters.AddWithValue("@p_miasto_k", Kolporter[3]);
            Command.Parameters.AddWithValue("@p_adres_k", Kolporter[2]);
            Command.Parameters.AddWithValue("@p_telefon_k", Kolporter[6]);
            Command.Parameters.AddWithValue("@p_telefon2_k", Kolporter[7]);
            Command.Parameters.AddWithValue("@p_fax_k", Kolporter[8]);
            

            if (CommonFunctions.WriteData(Command, ref Settings.coliberConnection))
            {
                MessageBox.Show(!EditMode ? _T("added") : _T("modified"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
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
            Columns[0].HeaderText = _T("code");
            Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "p_sk_nazwa";
            Columns[1].Name = "Państwo";
            Columns[1].HeaderText = _T("country");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Publisher = new ShowForm(Command, Columns, "Państwo");
            Publisher.Text = _T("choose_country");
            Publisher.Width = 400;

            if (Publisher.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CountryTextBox.Text = Publisher.Dt.Cells["Kod"].Value.ToString();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
