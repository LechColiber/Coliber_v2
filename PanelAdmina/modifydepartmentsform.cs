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
    public partial class ModifyDepartmentsForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private Connection NewConnection;
        private int Mode;
        private int ID;

        public ModifyDepartmentsForm(Connection NewConnection, string Name, int ID, int Mode)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.ID = ID;
            this.Mode = Mode;
            this.NewConnection = NewConnection;

            this.NameTextBox.Text = Name;

            if (Mode == 1)
                this.Text = _T("department_add");
            else if (Mode == 2)
                this.Text = _T("department_modify");
        }
            

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "department_add");
            mapping.Add(CancelButton, "cancel");
            mapping.Add(OkButton, "confirm");
            mapping.Add(label1, "name");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
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
                    Command.CommandText = "EXEC ModifyDepartment ?, ?, 1; ";

                    Command.Parameters.AddWithValue("@p_nazwa", NameTextBox.Text);
                    Command.Parameters.AddWithValue("@p_id", this.ID);
                }
                else if (Mode == 2)
                {
                    Command.CommandText = "EXEC ModifyDepartment ?, ?, 2; ";

                    Command.Parameters.AddWithValue("@p_nazwa", NameTextBox.Text);
                    Command.Parameters.AddWithValue("@p_id", this.ID);
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
                        MessageBox.Show(_T("added"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else if (Mode == 2)
                        MessageBox.Show(_T("modified"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }

                Reader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void ModifyDepartmentsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }
    }
}
