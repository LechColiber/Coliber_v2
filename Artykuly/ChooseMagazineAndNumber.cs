using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Artykuly
{
    public partial class ChooseMagazineAndNumber : Form
    {
        public DataGridViewRow MagazineRow;
        public DataGridViewRow NumberRow;

        private string SearchText;
        private Dictionary<string, string> _translationsDictionary;
        public ChooseMagazineAndNumber()
        {
            InitializeComponent();

            setControlsText();

            ClearSearch();

            MagazineRow = null;
            NumberRow = null;

            NumbersDGV.AutoGenerateColumns = false;

            LoadMagazines("1");
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(Magazine, "magazine_title");
            mapping.Add(Sygnatura, "signature");

            mapping.Add(Year, "year");
            mapping.Add(Number, "number");

            mapping.Add(ChooseButton, "select");
            mapping.Add(EscapeButton, "exit");
            mapping.Add(SortLabel, "sort_by");
            mapping.Add(SygRadioButton, "signature_genitive");
            mapping.Add(TitleRadioButton, "title_genitive");

            mapping.Add(this, "choose_magazine_and_magazine_number");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void ClearSearch()
        {
            SearchText = "";
            label1.Text = SearchText;
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void LoadMagazines(string sort)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC ZwrocCzasopisma @sort;";
            Command.Parameters.AddWithValue("@sort", sort);

            MagazinesDGV.DataSource = CommonFunctions.ReadData(Command, ref Settings.Connection);
        }

        private void MagazinesDGV_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (MagazinesDGV.SelectedRows.Count > 0)
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC ZwrocZNumeramiArtykuly @id_cza_syg;";
                //Command.Parameters.AddWithValue("@kod", MagazinesDGV.SelectedRows[0].Cells["id"].Value);
                Command.Parameters.AddWithValue("@id_cza_syg", MagazinesDGV.SelectedRows[0].Cells[id_cza_sygDGVC.Name].Value);
                
                NumbersDGV.DataSource = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (NumbersDGV.Rows.Count > 0)
                {
                    NumbersDGV.Rows[0].Selected = true;
                }
            }
        }

        private void ChooseButon_Click(object sender, EventArgs e)
        {
            SelectData();
        }

        private void SelectData()
        {
            if (MagazinesDGV.SelectedRows.Count > 0)
                MagazineRow = MagazinesDGV.SelectedRows[0];

            if (NumbersDGV.SelectedRows.Count > 0)
                NumberRow = NumbersDGV.SelectedRows[0];

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void MagazinesDGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                if (SearchText.Length > 0)
                {
                    SearchText = SearchText.Remove(SearchText.Length - 1);
                    label1.Text = SearchText;
                }
                e.Handled = true;
            }
            else
            {
                SearchText += e.KeyChar.ToString();
                label1.Text = SearchText;
            }

            //WYSZUKANIE WG WPISANEGO TEKSTU
            for (int i = 0; i < MagazinesDGV.Rows.Count; i++)
            {
                if (/*dataGridView1.Columns.Contains("id") &&*/ ((MagazinesDGV.Columns.Contains("Magazine") && MagazinesDGV.Rows[i].Cells["Magazine"].Value.ToString().ToLower().StartsWith(SearchText.ToLower())) || (MagazinesDGV.Columns.Contains("Sygnatura") && MagazinesDGV.Rows[i].Cells["Sygnatura"].Value.ToString().ToLower().StartsWith(SearchText.ToLower())) || (MagazinesDGV.Columns.Contains("tytul_artykulu") && MagazinesDGV.Rows[i].Cells["tytul_artykulu"].Value.ToString().ToLower().StartsWith(SearchText.ToLower())) || (MagazinesDGV.Columns.Contains("Język") && MagazinesDGV.Rows[i].Cells["Język"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))))
                {
                    MagazinesDGV.ClearSelection();
                    MagazinesDGV.Rows[i].Selected = true;

                    /*if (MagazinesDGV.Columns.Contains("syg"))
                        MagazinesDGV.CurrentCell = MagazinesDGV["syg", i];
                    else if (MagazinesDGV.Columns.Contains("tytul_gl"))
                        MagazinesDGV.CurrentCell = MagazinesDGV["tytul_gl", i];
                    else if (MagazinesDGV.Columns.Contains("tytul_artykulu"))
                        MagazinesDGV.CurrentCell = MagazinesDGV["tytul_artykulu", i];
                    else if (MagazinesDGV.Columns.Contains("Język"))
                        MagazinesDGV.CurrentCell = MagazinesDGV["Język", i];*/

                    for (int j = 0; j < MagazinesDGV.Columns.Count; j++)
                    {
                        if (MagazinesDGV.Columns[j].Visible == true)
                        {
                            MagazinesDGV.CurrentCell = MagazinesDGV[j, i];
                            break;
                        }
                    }

                    MagazinesDGV.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void MagazinesDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearSearch();
        }

        private void MagazinesDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                ClearSearch();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void ChooseMagazineAndNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
            else if (e.KeyCode == Keys.Enter)
            {
                //if (NumbersDGV.SelectedRows.Count > 0)
                    SelectData();
            }
        }

        private void TitleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (MagazinesDGV.Rows.Count == 0)
                return;

            WaitForm WF = new WaitForm();
            this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });

            string[] TextToSearch = { "", "" };

            if (SygRadioButton.Checked)
            {
                TextToSearch[0] = MagazinesDGV.SelectedRows[0].Cells["Sygnatura"].Value.ToString().ToLower();
                TextToSearch[1] = MagazinesDGV.SelectedRows[0].Cells["Magazine"].Value.ToString().ToLower();

                LoadMagazines("2");

                for (int i = 0; i < MagazinesDGV.Rows.Count; i++)
                {
                    if (MagazinesDGV.Rows[i].Cells["Magazine"].Value.ToString().ToLower().StartsWith(TextToSearch[1].ToLower()) && MagazinesDGV.Rows[i].Cells["Sygnatura"].Value.ToString().ToLower().StartsWith(TextToSearch[0].ToLower()))
                    {
                        MagazinesDGV.ClearSelection();
                        MagazinesDGV.Rows[i].Selected = true;
                        MagazinesDGV.CurrentCell = MagazinesDGV["Magazine", i];
                        MagazinesDGV.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
            else if (TitleRadioButton.Checked)
            {
                TextToSearch[0] = MagazinesDGV.SelectedRows[0].Cells["Sygnatura"].Value.ToString().ToLower();
                TextToSearch[1] = MagazinesDGV.SelectedRows[0].Cells["Magazine"].Value.ToString().ToLower();

                LoadMagazines("1");

                for (int i = 0; i < MagazinesDGV.Rows.Count; i++)
                {
                    if (MagazinesDGV.Rows[i].Cells["Magazine"].Value.ToString().ToLower().StartsWith(TextToSearch[1].ToLower()) && MagazinesDGV.Rows[i].Cells["Sygnatura"].Value.ToString().ToLower().StartsWith(TextToSearch[0].ToLower()))
                    {
                        MagazinesDGV.ClearSelection();
                        MagazinesDGV.Rows[i].Selected = true;
                        MagazinesDGV.CurrentCell = MagazinesDGV[1, i];
                        MagazinesDGV.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }

            WF.Close();

            MagazinesDGV.Focus();
        }
    }
}
