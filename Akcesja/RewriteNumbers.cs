using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Akcesja
{
    public partial class RewriteNumbers : Form
    {
        public DataTable DtV;
        private Dictionary<string, string> _translationsDictionary;

        public RewriteNumbers(string Code)
        {
            InitializeComponent();
            setControlsText();

            DGV.AutoGenerateColumns = false;

            DtV = new DataTable();
            DtV.Columns.Add("id_volumes");
            DtV.Columns.Add("Rok");
            //DtV.Columns.Add("Wolumin");
            
            GetData(Code);

            DGV.Focus();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(CheckCheckBox, "check_all");
            mapping.Add(OKButton, "update");
            mapping.Add(CancelButton, "cancel");

            mapping.Add(sygDGVC, "signature");
            mapping.Add(Rok, "year");
            mapping.Add(Wolumin, "volume");

            mapping.Add(this, "numbers_updating");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void GetData(string Code)
        {
            try
            {
                SqlCommand Command = new SqlCommand();

                //Command.CommandText = "SELECT id_volumes, volumes.rok1 AS rok, LTRIM(RTRIM(volumes.volumin)) AS volumin FROM volumes WHERE volumes.kod = @kod; ";
                Command.CommandText = "EXEC Akcesja_ListaWoluminowDoAktualizacjiNumerow @kod; ";                
                Command.Parameters.AddWithValue("@kod", Code);

                DGV.DataSource = CommonFunctions.ReadData(Command, ref Settings.Connection);
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _translationsDictionary.ContainsKey("error") ? _translationsDictionary["error"] : "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RewriteNumbers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }

        private void CheckCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckCheckBox.Checked == true)
            {
                for (int i = 0; i < DGV.Rows.Count; i++)
                    DGV.Rows[i].Cells["Check"].Value = true;
            }
            else
            {
                for (int i = 0; i < DGV.Rows.Count; i++)
                    DGV.Rows[i].Cells["Check"].Value = false;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Dispose();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {            
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                if (DGV.Rows[i].Cells["Check"].Value != null && Boolean.Parse(DGV.Rows[i].Cells["Check"].Value.ToString()) == true)
                    //DtV.Rows.Add(DGV.Rows[i].Cells["id_volumesDGVC"].Value.ToString(), DGV.Rows[i].Cells["Rok"].Value.ToString(), DGV.Rows[i].Cells["Wolumin"].Value.ToString());
                    DtV.Rows.Add(DGV.Rows[i].Cells["id_volumesDGVC"].Value.ToString(), DGV.Rows[i].Cells["Rok"].Value.ToString());
            }
            
            if (DtV.Rows.Count == 0)
            {
                string message = _translationsDictionary.ContainsKey("any_volume_selected") ? _translationsDictionary["any_volume_selected"] : "Nie wybrano żadnych woluminów!";
                string caption = _translationsDictionary.ContainsKey("select_volume") ? _translationsDictionary["select_volume"] : "Wybierz wolumin";

                //MessageBox.Show("Nie wybrano żadnych woluminów!", "Wybierz wolumin", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}