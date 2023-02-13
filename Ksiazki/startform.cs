using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace Ksiazki
{
    public partial class StartForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        public StartForm()
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
//            setControlsText();

            /*IniFile Configs = new IniFile("coliber.ini", "coliber");
            Settings.ConnectionString = Configs.ReadIni("SqlServer", "ConnectionString");
            Settings.SetSettings(-1);*/

            Settings.SetSettings(-1);
            
            GetKsiegiInw();
        }

        private void GetKsiegiInw()
        {
            try
            {
                SqlCommand Command = new SqlCommand();                
                Command.CommandText = "SELECT id_rodzaj AS [ID bazy], LTRIM(RTRIM(nazwa)) AS [Baza danych] FROM rodzaje ORDER BY [ID bazy]; ";

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                dataGridView1.DataSource = Dt;
                dataGridView1.Columns["ID bazy"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Start();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         //   dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void StartForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Application.Exit();
        }

        private void Start()
        {
            this.Hide();            
            //ChooseServerForm a = new ChooseServerForm(Int32.Parse(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value.ToString()));
            this.Dispose();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Start();
        }
    }
}
