using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace Ksiazki
{
    public partial class SygsToChooseForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        public string id_sygnatValues 
        {
            get { return GetIds(); }
        }
        public SygsToChooseForm(string BookID, bool isTome)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            GetData(BookID, isTome);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "signature_genitive");
            mapping.Add(ExitButton, "exit");
            mapping.Add(SelectButton, "print");
            mapping.Add(chooseDGVC, "check_all");
            mapping.Add(sygDGVC, "signature");
            mapping.Add(descDGVC, "short_description");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void GetData(string BookID, bool isTome)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_WyborSygnaturDoWydrukuKartyKatalogowej @kod, @isTome;";
            Command.Parameters.AddWithValue("@kod", BookID);
            Command.Parameters.AddWithValue("@isTome", isTome);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                sygsDataGridView.Rows.Add(Dt.Rows[i]["id_sygnat"], false, Dt.Rows[i]["syg"], Dt.Rows[i]["opis"]);
            }
        }

        private string GetIds()
        {
            StringBuilder ids = new StringBuilder();

            for (int i = 0; i < sygsDataGridView.Rows.Count; i++)
            {
                if (sygsDataGridView.Rows[i].Cells[chooseDGVC.Index].Value.ToString() == "1")
                    ids.Append(sygsDataGridView.Rows[i].Cells[id_sygnatDGVC.Index].Value.ToString() + ";");
            }

            return ids.ToString();
        }

        private void SygsToChooseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SelectButton_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(id_sygnatValues))
            {
                MessageBox.Show("Proszę zaznaczyć sygnatury do wydruku.", "Drukowanie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.None;
                return;
            }

            this.Close();
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
