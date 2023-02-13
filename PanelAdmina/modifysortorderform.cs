using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class ModifySortOrderForm : Form
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

        public ModifySortOrderForm(ModeEnum Mode, string ID = "", string Value = "")
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.CurrentMode = Mode;
            this.ID = ID;
            this.StringTextBox.Text = Value;

            this.StringTextBox.Select();

        }
        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "sort_order");
            mapping.Add(EscapeButton, "cancel");
            mapping.Add(OkButton, "confirm");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
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
                Command.CommandText = "EXEC PA_AddInvertoryOrderItem @ciag; ";
                Command.Parameters.AddWithValue("@ciag", this.StringTextBox.Text.Trim());
            }
            else if (CurrentMode == ModeEnum.Edit)
            {
                Command.CommandText = "EXEC PA_EditInvertoryOrderItem @ID, @ciag; ";

                Command.Parameters.AddWithValue("@ID", this.ID);                
                Command.Parameters.AddWithValue("@ciag", this.StringTextBox.Text.Trim());
            }

            Command.CommandText += "EXEC PA_UpdateInvertoryOrder; ";

            if (CommonFunctions.WriteData(Command, ref Settings.coliberConnection))
            {
                MessageBox.Show(CurrentMode == ModeEnum.Add ? _T("added") : _T("modified"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ModifySortOrderForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
