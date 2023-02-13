using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Coliber
{
    public partial class ChooseInvertoryForm : Form
    {
        public int IDRodzaj
        {
            get
            {
                return Id_rodzaj;
            }
        }

        private int Id_rodzaj;
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }

        public ChooseInvertoryForm()
        {
            InitializeComponent();

            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            Id_rodzaj = 0;

            LoadData();
            DbsDGV.Columns[2].HeaderText = _T("description");
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(label1, "choose_invertory_to_add_new");
            mapping.Add(Inwentarz, "inventory001");
//            mapping.Add(DescriptionDGVC, "description");
            mapping.Add(OkButton, "select");
            mapping.Add(EscapeButton, "cancel");
            mapping.Add(this, "invertory_choice");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void LoadData()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC InventoryList; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            DbsDGV.DataSource = Dt;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {        
            if (DbsDGV.SelectedRows.Count > 0)
            {
                Int32.TryParse(DbsDGV.SelectedRows[0].Cells["id_rodzaj"].Value.ToString(), out Id_rodzaj);
                Settings.InvertoryName = DbsDGV.SelectedRows[0].Cells["inwentarz"].Value.ToString();

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(_translationsDictionary.ContainsKey("no_selected_invertory") ? _translationsDictionary["no_selected_invertory"] : "Nie został wybrany żaden inwentarz!", _translationsDictionary.ContainsKey("choose_invertory") ? _translationsDictionary["choose_invertory"] : "Wybierz inwentarz", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }            
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
