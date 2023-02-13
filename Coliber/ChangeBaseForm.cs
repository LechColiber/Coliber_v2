using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Coliber
{
    public partial class ChangeBaseForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }

        public ChangeBaseForm()
        {
            InitializeComponent();

            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            LoadData();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(label1, "change_invertory");
            mapping.Add(label2, "choose_invertory_and_press_key");
            mapping.Add(this, "change_invertory");
            mapping.Add(AllDbCheckBox, "all_invertories");
            mapping.Add(DescriptionDGVC, "description");
            mapping.Add(OkButton, "select");
            mapping.Add(EscapeButton, "cancel");
            mapping.Add(Inwentarz, "inventory001");            

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void LoadData()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC InventoryList; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            DbsDGV.DataSource = Dt;

            AllDbCheckBox.Checked = Settings.ID_rodzaj == 0;
            DbsDGV.Enabled = Settings.ID_rodzaj != 0;
        }

        private void AllDbCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DbsDGV.Enabled = !AllDbCheckBox.Checked;
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (AllDbCheckBox.Checked)
            {
                Settings.ID_rodzaj = 0;
                Settings.InvertoryName = _translationsDictionary.ContainsKey("all_invertories") ? _translationsDictionary["all_invertories"] : "Wszystkie księgi inwentarzowe";

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                if (DbsDGV.SelectedRows.Count > 0)
                {
                    Int32.TryParse(DbsDGV.SelectedRows[0].Cells["id_rodzaj"].Value.ToString(), out Settings.ID_rodzaj);
                    Settings.InvertoryName = DbsDGV.SelectedRows[0].Cells["inwentarz"].Value.ToString();

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (_translationsDictionary.ContainsKey("no_selected_invertory") && _translationsDictionary.ContainsKey("choose_invertory"))
                        MessageBox.Show(_translationsDictionary["no_selected_invertory"], _translationsDictionary["choose_invertory"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    else
                        MessageBox.Show(_T("inventory_not_chosen"), _T("choose_invertory"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }            
        }

        private void DbsDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (DbsDGV.SelectedRows.Count > 0)
                DescriptionRTB.Text = DbsDGV.SelectedRows[0].Cells["DescriptionDGVC"].Value.ToString();
        }

        private void ChangeBaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
