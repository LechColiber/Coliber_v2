using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Wypozyczalnia
{
    public partial class ShowForm : Form
    {
        public string First;
        public string Second;
        public string ID;
        //private string Column1;
        //private string Column2;
        private string SearchText;
        private string SearchColumnName;

        private SqlCommand Command;

        public DataGridViewRow Dt;

        public ShowForm()
        {
            InitializeComponent();
            setControlsText();
            ClearSearch();
        }

        public ShowForm(Dictionary<string, string> Dict, DataGridViewColumn[] ColumnsDefinition, string SearchColumnName = null) : this()
        {
            for (int i = 0; i < ColumnsDefinition.Length; i++)
            {
                dataGridView1.Columns.Add(ColumnsDefinition[i]);
            }

            foreach (var Pair in Dict)
            {
                dataGridView1.Rows.Add(Pair.Value, Pair.Key);
            }

            //dataGridView1.ColumnHeadersVisible = false;

            this.SearchColumnName = SearchColumnName;
        }

        public ShowForm(SqlCommand Command, DataGridViewColumn[] ColumnsDefinition, string SearchColumnName = null) : this()
        {
            dataGridView1.AutoGenerateColumns = false;

            for (int i = 0; i < ColumnsDefinition.Length; i++)
            {
                dataGridView1.Columns.Add(ColumnsDefinition[i]);
            }

            this.Command = Command;

            this.SearchColumnName = SearchColumnName;

            SQLGetDataFromDb(Command);            
        }

        public ShowForm(SqlCommand Command, DataGridViewColumn[] ColumnsDefinition, List<string> permissionsList, string SearchColumnName = null) : this(Command, ColumnsDefinition, SearchColumnName)
        {
            dataGridView1.AutoGenerateColumns = false;

            for (int i = 0; i < permissionsList.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    if (dataGridView1.Rows[j].Cells["id"].Value.ToString() == permissionsList[i])
                    {
                        dataGridView1.Rows.RemoveAt(j);
                        break;                        
                    }
                }
            }
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(SelectButton, "select");
            mapping.Add(cancelButton, "cancel");

            mapping.Add(this, "select");

            CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name);
        }

        //WYCZYSZCZENIE LABELA SZUKANIA
        private void ClearSearch()
        {
            SearchText = "";
            SearchLabel.Text = SearchText;
        }

        private void SQLGetDataFromDb(SqlCommand Command)
        {
            try
            {
                dataGridView1.DataSource = CommonFunctions.ReadData(Command, ref Settings.Connection);                
               
                if (dataGridView1.Columns.Contains("id"))
                    dataGridView1.Columns["id"].Visible = false;

                /*if(!string.IsNullOrEmpty(this.Column1))
                    dataGridView1.Columns[Column1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (!string.IsNullOrEmpty(this.Column2))
                    dataGridView1.Columns[Column2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;*/
                    
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                /*if (Column1 != null && dataGridView1.Columns.Contains(Column1))
                    this.First = dataGridView1[Column1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                if (Column1 != null && dataGridView1.Columns.Contains(Column2))
                    this.Second = dataGridView1[Column2, dataGridView1.CurrentCell.RowIndex].Value.ToString();*/

                if (dataGridView1.Columns.Contains("id") && dataGridView1.SelectedRows.Count > 0)
                    ID = dataGridView1["id", dataGridView1.CurrentCell.RowIndex].Value.ToString();

                Dt = dataGridView1.CurrentRow;

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
                    SearchLabel.Text = SearchText;
                }
                e.Handled = true;
            }
            else 
            {
                SearchText += e.KeyChar.ToString();
                SearchLabel.Text = SearchText;
            }

            //WYSZUKANIE WG WPISANEGO TEKSTU
            if (string.IsNullOrEmpty(SearchColumnName))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((dataGridView1.Columns.Contains("id") && dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower().StartsWith(SearchText.ToLower())) || dataGridView1.Rows[i].Cells[0].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;

                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            if (dataGridView1.Columns[j].Visible)
                            { 
                                dataGridView1.CurrentCell = dataGridView1[j, i];
                                break;
                            }
                        }

                        //dataGridView1.CurrentCell = dataGridView1[1, i];
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[SearchColumnName].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[SearchColumnName, i];
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
                SelectButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectButton_Click(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearSearch();
        }
    }
}
