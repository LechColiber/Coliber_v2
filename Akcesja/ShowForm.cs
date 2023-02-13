using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using Akcesja.Properties;

namespace Akcesja
{
    public partial class ShowForm : Form
    {
        private string SearchText;
        private string Mode;
        private string SearchColumnName;
        private SqlCommand Command;

        public DataGridViewRow DGVRow;
        private DataTable Dt;
        private Dictionary<string, string> _translationsDictionary;
        public ShowForm()
        {
            InitializeComponent();
            setControlsText();
        }
        public ShowForm(SqlCommand Command, DataGridViewColumn[] Columns, string Crit, string SearchColumnName, string Mode) : this(Command, Columns, Mode)
        {
            this.SearchColumnName = SearchColumnName;            

            if (!string.IsNullOrEmpty(Crit.Trim()))
                Search(Crit);
        }

        public ShowForm(SqlCommand Command, DataGridViewColumn[] Columns, string Mode) : this()
        {
            this.Mode = Mode;
            this.Command = Command;

            dataGridView1.AutoGenerateColumns = false;

            for (int i = 0; i < Columns.Length; i++)
            {
                dataGridView1.Columns.Add(Columns[i]);
            }

            GetDataFromDb(Command);

            ClearSearch();

            if (Settings.ReadOnlyModeForCatalog)
            {
                SelectButton.Text = "Anuluj";
                SelectButton.Image = Resources.fileclose1;
                this.Text = "Podgląd";
            }
        }
        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(SelectButton, "select");
            mapping.Add(ExitButton, "exit");

            mapping.Add(SearchLabel, "sort_by");
            mapping.Add(SygRadioButton, "signature_genitive");
            mapping.Add(TitleRadioButton, "title_genitive");

            mapping.Add(this, "select");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void ClearSearch()
        {
            SearchText = "";
            label1.Text = SearchText;
        }

        private void GetDataFromDb(SqlCommand Command)
        {
            try
            {
                this.Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);                

                dataGridView1.DataSource = Dt;

                if (dataGridView1.Columns.Contains("tytul") && dataGridView1.Columns.Contains("sygnatury"))
                {
                    SearchLabel.Visible = true;
                    SygRadioButton.Visible = true;
                    TitleRadioButton.Visible = true;
                }

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (Settings.ReadOnlyModeForCatalog)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    DGVRow = dataGridView1.SelectedRows[0];

                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    this.DialogResult = System.Windows.Forms.DialogResult.No;

                this.Close();
            }
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            catch (Exception Ex)
            {

            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Search(e.KeyChar.ToString());
        }

        private void Search(string Letter)
        {
            string Sort;

            if (SygRadioButton.Checked == true)
                Sort = "sygnatury";
            else if (TitleRadioButton.Checked == true && Mode.ToLower().Trim() == "nowa_karta")
                Sort = "tytul";
            else if (TitleRadioButton.Checked == true && Mode.ToLower().Trim() == "dopisz")
                Sort = "tytul";
            else
                Sort = SearchColumnName;

            if (Letter == '\b'.ToString())
            {
                if (SearchText.Length > 0)
                {
                    SearchText = SearchText.Remove(SearchText.Length - 1);
                    label1.Text = SearchText;
                }                
            }
            else
            {
                SearchText += Letter;
                label1.Text = SearchText;
            }

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Sort != "1")
                {
                    if (dataGridView1.Rows[i].Cells[Sort].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[Sort, i];
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
                else
                {
                    if (dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[1, i];
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
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

                if (!Settings.ReadOnlyModeForCatalog)
                    SelectButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1_CellEnter(sender, e);

            if (!Settings.ReadOnlyModeForCatalog)
                SelectButton_Click(sender, e);
        }

        private void SygRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
                return;

            if (SygRadioButton.Checked)
            {
                Command.Parameters["@sort"].Value = 2;
                GetDataFromDb(Command);
            }
            /*string[] TextToSearch = {"",""};
            string Column = "tytul";

            if (SygRadioButton.Checked)
            {
                TextToSearch[0] = dataGridView1.SelectedRows[0].Cells["sygnatury"].Value.ToString().ToLower();
                TextToSearch[1] = dataGridView1.SelectedRows[0].Cells["tytul"].Value.ToString().ToLower();              

                AlphanumComparator<string> Comparer = new AlphanumComparator<string>();
                Dt.DefaultView.Sort = "sygnatury ASC";
                Dt = Dt.DefaultView.ToTable();
                Dt = Dt.DefaultView.Table.AsEnumerable().OrderBy(x => x.Field<string>("sygnatury"), Comparer).CopyToDataTable();

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Dt;

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[Column].Value.ToString().ToLower().StartsWith(TextToSearch[1].ToLower()) && dataGridView1.Rows[i].Cells["sygnatury"].Value.ToString().ToLower().StartsWith(TextToSearch[0].ToLower()))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[1, i];
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }               
            }*/

            dataGridView1.Focus();
        }

        private void TitleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if( dataGridView1.Rows.Count == 0)
                return;

            if (TitleRadioButton.Checked)
            {
                Command.Parameters["@sort"].Value = 1;
                GetDataFromDb(Command);
            }
            /*string[] TextToSearch = { "", "" };
            string Column = "tytul";

            if (TitleRadioButton.Checked)
            {
                TextToSearch[0] = dataGridView1.SelectedRows[0].Cells["sygnatury"].Value.ToString().ToLower();

                if (Mode.ToLower().Trim() == "nowa_karta")
                {
                    TextToSearch[1] = dataGridView1.SelectedRows[0].Cells["tytul"].Value.ToString().ToLower();

                    AlphanumComparator<string> Comparer = new AlphanumComparator<string>();

                    Dt.DefaultView.Sort = "tytul ASC";
                    Dt = Dt.DefaultView.ToTable();
                    Dt = Dt.DefaultView.Table.AsEnumerable().OrderBy(x => x.Field<string>("tytul"), Comparer).CopyToDataTable();
                    
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Dt;               
                }
                else if (Mode.ToLower().Trim() == "dopisz")
                {
                    TextToSearch[1] = dataGridView1.SelectedRows[0].Cells["tytul"].Value.ToString().ToLower();

                    AlphanumComparator<string> Comparer = new AlphanumComparator<string>();

                    Dt.DefaultView.Sort = "tytul ASC";
                    Dt = Dt.DefaultView.ToTable();
                    Dt = Dt.DefaultView.Table.AsEnumerable().OrderBy(x => x.Field<string>("tytul"), Comparer).CopyToDataTable();
                    
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = Dt;
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[Column].Value.ToString().ToLower().StartsWith(TextToSearch[1].ToLower()) && dataGridView1.Rows[i].Cells["sygnatury"].Value.ToString().ToLower().StartsWith(TextToSearch[0].ToLower()))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[1, i];
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                } 
            }*/

            dataGridView1.Focus();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label1.Text = "";

            dataGridView1_CellEnter(sender, e);
        }

        private void dataGridView1_DataSourceChanged(object sender, EventArgs e)
        {
            if (dataGridView1.Columns.Contains("tytul") && dataGridView1.Columns.Contains("sygnatury"))
            {
                SearchLabel.Visible = true;
                SygRadioButton.Visible = true;
                TitleRadioButton.Visible = true;
            }
        }
    }
}
