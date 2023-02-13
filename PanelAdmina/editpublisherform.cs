using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class EditPublisherForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private Connection NewConnection;
        private Dictionary<int, string> IDRodzajDictionary;
        private int Mode;
        private int PubID;
        private char PubKind;

        public EditPublisherForm(Connection NewConnection, string Name, string ShortName, string Country, string Place, string Contact, string Address, int id_rodzaj, char PubKind, int PubID, int Mode)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.NewConnection = NewConnection;
            this.Mode = Mode;
            this.NameTextBox.Text = Name;
            this.ShortTextBox.Text = ShortName;
            this.IDCountryTextBox.Text = Country;
            this.PlaceTextBox.Text = Place;
            this.ContactTextBox.Text = Contact;
            this.AddressTextBox.Text = Address;
            this.PubKind = PubKind;
            this.PubID = PubID;
            this.Mode = Mode;

            IDRodzajDictionary = new Dictionary<int, string>();

            GenerateRodzajeValues(id_rodzaj);

        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "publisher");
            mapping.Add(label7, "books_collection");
            mapping.Add(label6, "url_address");
            mapping.Add(label5, "contact");
            mapping.Add(label4, "city");
            mapping.Add(label3, "publishers_country");
            mapping.Add(CancelButton, "cancel");
            mapping.Add(OkButton, "confirm");
            mapping.Add(label2, "short_name");
            mapping.Add(label1, "full_name");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void EditPublisherForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;

                if (Mode == 1)
                {
                    Command.CommandText = "EXEC ModifyPublisher ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 1";

                    Command.Parameters.AddWithValue("@p_nazwa", NameTextBox.Text);
                    Command.Parameters.AddWithValue("@p_nazwa_krotka", ShortTextBox.Text);
                    Command.Parameters.AddWithValue("@p_id_panstwa",  IDCountryTextBox.Text);
                    Command.Parameters.AddWithValue("@p_miasto", PlaceTextBox.Text);
                    Command.Parameters.AddWithValue("@p_kontakt", ContactTextBox.Text);
                    Command.Parameters.AddWithValue("@p_adres", AddressTextBox.Text);
                    Command.Parameters.AddWithValue("@p_odsylacz", 0);
                    Command.Parameters.AddWithValue("@p_rodzaj_wydawcy", 0);
                    Command.Parameters.AddWithValue("@p_id_rodzaj", KindComboBox.SelectedValue.ToString());
                    Command.Parameters.AddWithValue("@p_id_wydawcy", -1);
                    Command.Parameters.AddWithValue("@p_typ_wydawcy", PubKind);
                }
                else if (Mode == 2)
                {
                    Command.CommandText = "EXEC ModifyPublisher ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, 2";

                    Command.Parameters.AddWithValue("@p_nazwa", NameTextBox.Text);
                    Command.Parameters.AddWithValue("@p_nazwa_krotka", ShortTextBox.Text);
                    Command.Parameters.AddWithValue("@p_id_panstwa", IDCountryTextBox.Text);
                    Command.Parameters.AddWithValue("@p_miasto", PlaceTextBox.Text);
                    Command.Parameters.AddWithValue("@p_kontakt", ContactTextBox.Text);
                    Command.Parameters.AddWithValue("@p_adres", AddressTextBox.Text);
                    Command.Parameters.AddWithValue("@p_odsylacz", 0);
                    Command.Parameters.AddWithValue("@p_rodzaj_wydawcy", 0);
                    Command.Parameters.AddWithValue("@p_id_rodzaj", KindComboBox.SelectedValue.ToString());
                    Command.Parameters.AddWithValue("@p_id_wydawcy", PubID);
                    Command.Parameters.AddWithValue("@p_typ_wydawcy", PubKind);
                }

                OdbcDataReader Reader = Command.ExecuteReader();

                string InfoFromDb = "";

                while (Reader.Read())
                {
                    InfoFromDb += Reader.GetValue(0).ToString();
                }

                if (InfoFromDb != "")
                    MessageBox.Show(InfoFromDb);
                else
                {
                    if (Mode == 1)
                        MessageBox.Show(_T("publisher_added"), _T("publisher_adding"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Mode == 2)
                        MessageBox.Show(_T("publisher_edited"), _T("publisher_edit"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }

                Reader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }         
        }

        private void GenerateRodzajeValues(int id_rodzaj)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = "SELECT id_rodzaj, nazwa FROM dbo.rodzaje ORDER BY nazwa; ";

                OdbcDataReader Reader = Command.ExecuteReader();

                while (Reader.Read())
                {
                    IDRodzajDictionary.Add(Int32.Parse(Reader.GetValue(0).ToString()), Reader.GetValue(1).ToString());
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            KindComboBox.DataSource = new BindingSource(IDRodzajDictionary, null);
            KindComboBox.ValueMember = "Key";
            KindComboBox.DisplayMember = "Value";
            
            if (id_rodzaj == -1)
                KindComboBox.SelectedIndex = 0;
            else
                KindComboBox.SelectedValue = id_rodzaj;

            if (KindComboBox.SelectedItem == null && KindComboBox.Items.Count > 0)
                KindComboBox.SelectedIndex = 0;
        }

        private void ShowButton_Click(object sender, EventArgs e)
        {            
            OdbcShowForm OdbcShow = new OdbcShowForm(NewConnection, "SELECT LTRIM(RTRIM(panstwo)) AS [Kod], LTRIM(RTRIM(p_sk_nazwa)) AS [Państwo] FROM panstwa ORDER BY [Państwo], [Kod]; ", "Państwo");
            OdbcShow.Width = 400;

            if (OdbcShow.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                IDCountryTextBox.Text = OdbcShow.Dt.Cells["Kod"].Value.ToString();
            }
        }
    }
}
