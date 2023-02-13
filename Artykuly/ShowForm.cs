using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Artykuly
{
    public partial class ShowForm : Form
    {
        public string First;
        public string Second;
        public string ID;

        private string SearchText;
        private SqlCommand Command;

        public DataGridViewRow Dt;
        private Dictionary<string, string> _translationsDictionary;

        public ShowForm(SqlCommand Command, DataGridViewColumn[] ColumnsDefinition)
        {
            InitializeComponent();

            setControlsText();

            dataGridView1.AutoGenerateColumns = false;

            for (int i = 0; i < ColumnsDefinition.Length; i++)
            {
                dataGridView1.Columns.Add(ColumnsDefinition[i]);
            }

            this.Command = Command;

            GetDataFromDb(Command);

            ClearSearch();            
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(SelectButton, "select");
            mapping.Add(ExitButton, "exit");

            mapping.Add(SortLabel, "sort_by");
            mapping.Add(SygRadioButton, "signature_genitive");
            mapping.Add(TitleRadioButton, "title_genitive");

            mapping.Add(this, "select");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        public void ShowRadioButtons()
        {
            SygRadioButton.Visible = true;
            TitleRadioButton.Visible = true;
            SortLabel.Visible = true;
        }

        //WYCZYSZCZENIE LABELA SZUKANIA
        private void ClearSearch()
        {
            SearchText = "";
            label1.Text = SearchText;
        }

        //POBRANIE DANYCH Z BAZY
        private void GetDataFromDb(SqlCommand Command)
        {
            try
            {
                dataGridView1.SuspendLayout();
                dataGridView1.DataSource = CommonFunctions.ReadData(Command, ref Settings.Connection);
                dataGridView1.ResumeLayout();

                if (dataGridView1.Columns.Contains("id"))
                    dataGridView1.Columns["id"].Visible = false;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _translationsDictionary.getStringFromDictionary("error", "Błąd"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //OBSŁUGA PRZYCISKU WYBORU
        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Dt = dataGridView1.CurrentRow;

                if (dataGridView1.SelectedRows.Count > 0)
                    Dt = dataGridView1.SelectedRows[0];

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                this.DialogResult = System.Windows.Forms.DialogResult.No;
            
            this.Close();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
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
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (/*dataGridView1.Columns.Contains("id") &&*/ ((dataGridView1.Columns.Contains("syg") && dataGridView1.Rows[i].Cells["syg"].Value.ToString().ToLower().StartsWith(SearchText.ToLower())) || (dataGridView1.Columns.Contains("tytul_gl") && dataGridView1.Rows[i].Cells["tytul_gl"].Value.ToString().ToLower().StartsWith(SearchText.ToLower())) || (dataGridView1.Columns.Contains("tytul_artykulu") && dataGridView1.Rows[i].Cells["tytul_artykulu"].Value.ToString().ToLower().StartsWith(SearchText.ToLower())) || (dataGridView1.Columns.Contains("Język") && dataGridView1.Rows[i].Cells["Język"].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))))
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.Rows[i].Selected = true;
                    if (dataGridView1.Columns.Contains("syg"))
                        dataGridView1.CurrentCell = dataGridView1["syg", i];
                    else if (dataGridView1.Columns.Contains("tytul_gl"))
                        dataGridView1.CurrentCell = dataGridView1["tytul_gl", i];
                    else if (dataGridView1.Columns.Contains("tytul_artykulu"))
                        dataGridView1.CurrentCell = dataGridView1["tytul_artykulu", i];
                    else if (dataGridView1.Columns.Contains("Język"))
                        dataGridView1.CurrentCell = dataGridView1["Język", i];
                    
                    dataGridView1.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                ClearSearch();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                ClearSearch();
                SelectButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectButton_Click(sender, e);
        }

        private void TitleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;            

            WaitForm WF = new WaitForm();
            this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });

            string[] TextToSearch = { "", "" };
            string Column = "tytul_gl";            

            if (SygRadioButton.Checked && (sender as RadioButton) != SygRadioButton)
            {
                TextToSearch[0] = dataGridView1.SelectedRows[0].Cells["syg"].Value.ToString().ToLower();
                TextToSearch[1] = dataGridView1.SelectedRows[0].Cells["tytul_gl"].Value.ToString().ToLower();

                Command.Parameters["@sort"].Value = "2";

                GetDataFromDb(Command);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[Column].Value.ToString().ToLower().StartsWith(TextToSearch[1].ToLower()) && dataGridView1.Rows[i].Cells["syg"].Value.ToString().ToLower().StartsWith(TextToSearch[0].ToLower()))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[1, i];
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
            else if (TitleRadioButton.Checked && (sender as RadioButton) != TitleRadioButton)
            {
                TextToSearch[0] = dataGridView1.SelectedRows[0].Cells["syg"].Value.ToString().ToLower();
                TextToSearch[1] = dataGridView1.SelectedRows[0].Cells["tytul_gl"].Value.ToString().ToLower();

                Command.Parameters["@sort"].Value = "1";

                GetDataFromDb(Command);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[Column].Value.ToString().ToLower().StartsWith(TextToSearch[1].ToLower()) && dataGridView1.Rows[i].Cells["syg"].Value.ToString().ToLower().StartsWith(TextToSearch[0].ToLower()))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[1, i];
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }

            WF.Close();

            dataGridView1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearSearch();
        }

        private void SortLabel_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
