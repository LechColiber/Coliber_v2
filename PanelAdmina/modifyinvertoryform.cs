using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Globalization;

namespace WindowsFormsApplication1
{
    public partial class ModifyInvertoryForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private bool EditMode;
        private string ID;

        public String Ciag
        {
            get { return this.NameTextBox.Text.Trim(); }
        }
        public ModifyInvertoryForm()
        {
            InitializeComponent();

            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();
            label2.Text = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(label2.Text);
            EditMode = false;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "invertory_name");
            mapping.Add(EscapeButton, "cancel");
            mapping.Add(OKButton, "confirm");
            mapping.Add(label2, "description");
            mapping.Add(label1, "name");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        public ModifyInvertoryForm(string invertoryName, string description, string ID)
            : this()
        {                

            EditMode = true;

            this.ID = ID;
            this.NameTextBox.Text = invertoryName;
            this.descTextBox.Text = description;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand();

            if (!EditMode)
            {
                Command.CommandText += "EXEC PA_AddInvertory @nazwa, @opis; ";
            }
            else
            {
                Command.CommandText += "EXEC PA_EditInvertory @id, @nazwa, @opis; ";
                Command.Parameters.AddWithValue("@id", this.ID);
            }
            
            Command.Parameters.AddWithValue("@nazwa", NameTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@opis", descTextBox.Text.Trim());
            

            if (CommonFunctions.WriteData(Command, ref Settings.coliberConnection))
            {
                MessageBox.Show(!EditMode ? _T("inv_was_added") : _T("inv_was_modified"), !EditMode ? _T("inv_adding") : _T("inv_edit"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void DistributorForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
