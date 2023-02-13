using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class ModifyOdpowiedzialnosciForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private string ID;

        public String Ciag
        {
            get { return this.StringTextBox.Text.Trim(); }
        }

        public enum ModeEnum
        {
            Add,
            Edit
        }

        private ModeEnum CurrentMode;

        public ModifyOdpowiedzialnosciForm(ModeEnum Mode, string ID = "", string Value = "")
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.CurrentMode = Mode;
            this.ID = ID;
            this.StringTextBox.Text = Value;

            if (this.CurrentMode == ModeEnum.Add) this.Text = _T("adding");
            else this.Text = _T("edit");

            this.StringTextBox.Select();

        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "responsibility");
            mapping.Add(EscapeButton, "cancel");
            mapping.Add(OkButton, "confirm");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void ModifyOdpowiedzialnosciForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand();

            if (CurrentMode == ModeEnum.Add)
            {
                Command.CommandText = "PA_AddResponsibility @ciag; ";
                Command.Parameters.AddWithValue("@ciag", this.StringTextBox.Text.Trim());
            }
            else if (CurrentMode == ModeEnum.Edit)
            {
                Command.CommandText = "PA_EditResponsibility @ID, @ciag; ";

                Command.Parameters.AddWithValue("@ID", this.ID);
                Command.Parameters.AddWithValue("@ciag", this.StringTextBox.Text.Trim());
            }

            if (CommonFunctions.WriteData(Command, ref Settings.coliberConnection))
            {
                MessageBox.Show(CurrentMode == ModeEnum.Add ? _T("added") : _T("modified"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
