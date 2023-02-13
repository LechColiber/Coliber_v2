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
    public partial class EditSeriesForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        Connection NewConnection;
        Dictionary<int, string> IDRodzajDictionary;

        private int Mode;
        private string Kody;

        public EditSeriesForm(Connection NewConnection, int Mode, int id_rodzaj)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();
            this.NewConnection = NewConnection;

            IDRodzajDictionary = new Dictionary<int, string>();
            GenerateRodzajeValues(id_rodzaj);

            this.Mode = Mode;

        }

        public EditSeriesForm(Connection NewConnection, int Mode, int id_rodzaj, string Kody, string Title, string ISSN, string Inst, string Place)
            : this(NewConnection, Mode, id_rodzaj)
        {
            this.TitleTextBox.Text = Title;
            //this.SecondTitileTextBox.Text = Second;
            //this.AdditionalTitleTextBox.Text = Additional;
            this.ISSNTextBox.Text = ISSN;
            this.InstTextBox.Text = Inst;
            this.PlaceTextBox.Text = Place;
            this.Kody = Kody;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "series");
            mapping.Add(CancelButton, "cancel");
            mapping.Add(OkButton, "confirm");
            mapping.Add(label7, "books_collection");
            mapping.Add(label6, "series_site");
            mapping.Add(label5, "series_institution");
            mapping.Add(label4, "issn");
            mapping.Add(label1, "series_title");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;

                if (Mode == 1)
                {
                    Command.CommandText = "EXEC ModifySeries ?, "+/*?, ?,*/ "?, ?, ?, ?, -1, 1; ";

                    Command.Parameters.AddWithValue("@p_tytul", TitleTextBox.Text);
                    /*Command.Parameters.AddWithValue("@p_rownolegly", SecondTitileTextBox.Text);
                    Command.Parameters.AddWithValue("@p_dodatkowy", AdditionalTitleTextBox.Text);*/
                    Command.Parameters.AddWithValue("@p_issn", ISSNTextBox.Text);
                    Command.Parameters.AddWithValue("@p_inst_serii", InstTextBox.Text);
                    Command.Parameters.AddWithValue("@p_siedziba", PlaceTextBox.Text);
                    Command.Parameters.AddWithValue("@p_id_rodzaj", KindComboBox.SelectedValue);
                }
                else if (Mode == 2)
                {
                    Command.CommandText = "EXEC ModifySeries ?, "+/*?, ?,*/ "?, ?, ?, ?, ?, 2; ";

                    Command.Parameters.AddWithValue("@p_tytul", TitleTextBox.Text);
                    /*Command.Parameters.AddWithValue("@p_rownolegly", SecondTitileTextBox.Text);
                    Command.Parameters.AddWithValue("@p_dodatkowy", AdditionalTitleTextBox.Text);*/
                    Command.Parameters.AddWithValue("@p_issn", ISSNTextBox.Text);
                    Command.Parameters.AddWithValue("@p_inst_serii", InstTextBox.Text);
                    Command.Parameters.AddWithValue("@p_siedziba", PlaceTextBox.Text);
                    Command.Parameters.AddWithValue("@p_id_rodzaj", KindComboBox.SelectedValue);
                    Command.Parameters.AddWithValue("@p_kody", this.Kody);
                }

                OdbcDataReader Reader = Command.ExecuteReader();

                string InfoFromDb = "";

                while (Reader.Read())
                {
                    InfoFromDb += Reader.GetValue(0).ToString();
                }

                if (InfoFromDb.Trim() != "")
                    MessageBox.Show(InfoFromDb);
                else
                {
                    if (Mode == 1)
                        MessageBox.Show(_T("serie_added"), _T("serie_adding"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Mode == 2)
                        MessageBox.Show(_T("data_was_modified"), _T("serie_edit"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }

                Reader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }            
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

            if (id_rodzaj == -1 && KindComboBox.Items.Count > 0)// || !KindComboBox.Items.Contains(id_rodzaj))
                KindComboBox.SelectedIndex = 0;
            else
                KindComboBox.SelectedValue = id_rodzaj;
        }

        private void EditSeriesForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }
    }
}
