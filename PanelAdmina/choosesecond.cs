using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class ChooseSecond : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        public int IDChoosen;

        private string SearchText;

        public ChooseSecond(DataSet Ds)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();
            
            Ds.Tables[0].Columns.Add("L.p.");
            Ds.Tables[0].Columns["L.p."].SetOrdinal(0);

            for (int i = 0; i < Ds.Tables[0].Rows.Count; i++)
                Ds.Tables[0].Rows[i]["L.p."] = i + 1;

            dataGridView1.DataSource = Ds.Tables[0];

            dataGridView1.Columns["L.p."].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
           
            if (dataGridView1.Columns.Contains("ISSN"))
                dataGridView1.Columns["ISSN"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            if (dataGridView1.Columns.Contains("Tytuł serii"))
            {
                dataGridView1.Columns["Tytuł serii"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dataGridView1.Columns["Tytuł serii"].HeaderText = _T("series_title");
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (!(dataGridView1.Rows.Count > 0))
                ChooseButton.Enabled = false;

            if (dataGridView1.Columns.Contains("id"))
                dataGridView1.Columns["id"].Visible = false;

            if (dataGridView1.Columns.Contains("Księgozbiór"))
            {
                dataGridView1.Columns["Księgozbiór"].Visible = false;
            }

            if (dataGridView1.Columns.Contains("Kody"))
            {
                dataGridView1.Columns["Kody"].Visible = false;
            }

            if (dataGridView1.Columns.Contains("Nazwisko")) dataGridView1.Columns["Nazwisko"].HeaderText = _T("last_name");
            if (dataGridView1.Columns.Contains("Imię")) dataGridView1.Columns["Imię"].HeaderText = _T("first_name");
            if (dataGridView1.Columns.Contains("Nazwa")) dataGridView1.Columns["Nazwa"].HeaderText = _T("name");
            if (dataGridView1.Columns.Contains("Instytucja sprawcza")) dataGridView1.Columns["Instytucja sprawcza"].HeaderText = _T("institution");
            if (dataGridView1.Columns.Contains("Tytuł podserii")) dataGridView1.Columns["Tytuł podserii"].HeaderText = _T("subseries_title");
            if (dataGridView1.Columns.Contains("Nazwa części")) dataGridView1.Columns["Nazwa części"].HeaderText = _T("part_name");
            if (dataGridView1.Columns.Contains("Numer części")) dataGridView1.Columns["Numer części"].HeaderText = _T("part_number");
            if (dataGridView1.Columns.Contains("Odpowiedzialność")) dataGridView1.Columns["Odpowiedzialność"].HeaderText = _T("responsibility");
            if (dataGridView1.Columns.Contains("nazwa_k")) dataGridView1.Columns["nazwa_k"].HeaderText = _T("name");
            if (dataGridView1.Columns.Contains("miasto_k")) dataGridView1.Columns["miasto_k"].HeaderText = _T("city");
            if (dataGridView1.Columns.Contains("sk_nazwa_k")) dataGridView1.Columns["sk_nazwa_k"].HeaderText = _T("short_name");
            if (dataGridView1.Columns.Contains("id_panst_k")) dataGridView1.Columns["id_panst_k"].HeaderText = _T("country");
            if (dataGridView1.Columns.Contains("kod_k")) dataGridView1.Columns["kod_k"].HeaderText = _T("zip");
            if (dataGridView1.Columns.Contains("Adres_k")) dataGridView1.Columns["Adres_k"].HeaderText = _T("address");
            if (dataGridView1.Columns.Contains("telefon_k")) dataGridView1.Columns["telefon_k"].HeaderText = _T("phone");
            if (dataGridView1.Columns.Contains("telefon2_k")) dataGridView1.Columns["telefon2_k"].HeaderText = _T("phone");
            if (dataGridView1.Columns.Contains("fax_k")) dataGridView1.Columns["fax_k"].HeaderText = _T("fax");

            dataGridView1.Columns["L.p."].HeaderText = _T("oridinal_short");

            SearchText = "";
            label1.Text = "";
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "select");
            mapping.Add(label4, "searching");
            mapping.Add(ChooseButton, "select");
            mapping.Add(button2, "cancel");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseButton_Click(object sender, EventArgs e)
        {
            IDChoosen = Int32.Parse(dataGridView1["id", dataGridView1.CurrentRow.Index].Value.ToString());

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        public int ReturnID()
        {
            return IDChoosen;
        }

        private void ChooseSecond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search(e.KeyChar.ToString());
        }

        private void Search(string Letter)
        {
            if (Letter == '\b'.ToString())
            {
                if (SearchText.Length > 0)
                {
                    SearchText = SearchText.Remove(SearchText.Length - 1);
                    label1.Text = SearchText;
                }
            }
            else if (Letter == '\r'.ToString())
            {

            }
            else
            {
                SearchText += Letter;
                label1.Text = SearchText;
            }

            string Column = "";

            if (dataGridView1.Columns.Contains("Nazwisko"))
                Column = "Nazwisko";
            else if (dataGridView1.Columns.Contains("Tytuł serii"))
                Column = "Tytuł serii";
            else if (dataGridView1.Columns.Contains("Klucze"))
                Column = "Klucze";
            else if (dataGridView1.Columns.Contains("Nazwa"))
                Column = "Nazwa";

            bool BreakLoop = false;

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                /*if (dataGridView1.Rows[i].Cells[Column].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    dataGridView1.CurrentCell = dataGridView1[Column, i];
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }*/

                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Visible && dataGridView1.Rows[i].Cells[j].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;

                        dataGridView1.CurrentCell = dataGridView1[j, i];

                        dataGridView1.FirstDisplayedScrollingRowIndex = i;

                        BreakLoop = true;
                        break;
                    }
                }

                if (BreakLoop)
                    break;  
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                SearchText = "";
                label1.Text = "";
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ChooseButton_Click(sender, e);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SearchText = "";
            label1.Text = "";
        }
    }
}
