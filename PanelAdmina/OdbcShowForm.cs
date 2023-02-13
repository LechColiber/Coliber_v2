using System;
using System.Data;
using System.Windows.Forms;
using System.Data.Odbc;

namespace WindowsFormsApplication1
{
    public partial class OdbcShowForm : Form
    {
        public string First;
        public string Second;
        public string ID;
        private string SearchText;
        private Connection NewConnection;
        private string SearchColumnName;

        public DataGridViewRow Dt;

        public OdbcShowForm(Connection NewConnection, string Command, string SearchColumnName)
        {
            InitializeComponent();
            this.NewConnection = NewConnection;

            this.SearchColumnName = SearchColumnName;

            GetDataFromDb(Command);

            ClearSearch();
        }

        private void ClearSearch()
        {
            SearchText = "";
            label1.Text = SearchText;
        }

        private void GetDataFromDbWithoutRodzaj(string CommandString)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = CommandString;

                OdbcDataReader Reader = Command.ExecuteReader();

                DataTable Dt = new DataTable();
                Dt.Load(Reader);

                dataGridView1.DataSource = Dt;

                if (dataGridView1.Columns.Contains("id"))
                    dataGridView1.Columns["id"].Visible = false;

                Reader.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void GetDataFromDb(string CommandString)
        {
            try
            {
                OdbcCommand Command = new OdbcCommand();
                Command.Connection = NewConnection.AppConnection;
                Command.CommandText = CommandString;

                OdbcDataReader Reader = Command.ExecuteReader();

                DataTable Dt = new DataTable();
                Dt.Load(Reader);

                dataGridView1.DataSource = Dt;

                if (dataGridView1.Columns.Contains("id"))
                    dataGridView1.Columns["id"].Visible = false;
                if (dataGridView1.Columns.Contains("ISSN"))
                    dataGridView1.Columns["ISSN"].Visible = false;//.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (dataGridView1.Columns.Contains("Nazwa części"))
                    dataGridView1.Columns["Nazwa części"].Visible = false;//.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (dataGridView1.Columns.Contains("Numer części"))
                    dataGridView1.Columns["Numer części"].Visible = false;//.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (dataGridView1.Columns.Contains("Nazwa podczęści"))
                    dataGridView1.Columns["Nazwa podczęści"].Visible = false;//.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                if (dataGridView1.Columns.Contains("Numer podczęści"))
                    dataGridView1.Columns["Numer podczęści"].Visible = false;//.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                Reader.Close();
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
                /*this.First = dataGridView1[Column1, dataGridView1.CurrentCell.RowIndex].Value.ToString();
                if (dataGridView1.Columns.Contains(Column2))
                    this.Second = dataGridView1[Column2, dataGridView1.CurrentCell.RowIndex].Value.ToString();

                if (dataGridView1.Columns.Contains("id") && dataGridView1.SelectedRows.Count > 0)
                    ID = dataGridView1["id", dataGridView1.CurrentCell.RowIndex].Value.ToString();
                */
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
                /*if (label1.Text.Length > 0)
                    label1.Text = label1.Text.Remove(label1.Text.Length - 1);*/
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

            if (!string.IsNullOrEmpty(SearchColumnName))
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((dataGridView1.Columns.Contains(SearchColumnName) && dataGridView1.Rows[i].Cells[SearchColumnName].Value.ToString().ToLower().StartsWith(SearchText.ToLower())))
                    {
                        dataGridView1.ClearSelection();
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.CurrentCell = dataGridView1[1, i];
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((dataGridView1.Columns.Contains("id") && dataGridView1.Rows[i].Cells[1].Value.ToString().ToLower().StartsWith(SearchText.ToLower())) || dataGridView1.Rows[i].Cells[0].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
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
                SelectButton_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            SelectButton_Click(sender, e);
        }
    }
}
