using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Artykuly
{
    public partial class ShowListForm : Form
    {
        private string SearchText;
        private bool NewRow;
        private Form _parent;        

        public ShowListForm(DataGridView KeyDGV, SqlCommand Command, DataGridViewColumn[] ColumnsName, Form parent)
        {
            InitializeComponent();

            setControlsText();

            this.MdiParent = parent.MdiParent;
            _parent = parent;
            _parent.Enabled = false;

            ClearSearch();

            LoadGrids(Command, ColumnsName);
            LoadDataToSelectedGrid(KeyDGV);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(AvailableGroupBox, "list_of_available_items");
            mapping.Add(SelectedGroupBox, "list_of_selected_items");

            mapping.Add(OKButton, "confirm");
            mapping.Add(ExitButton, "exit");

            mapping.Add(infoLabel, "select_by_enter_or_double_click");

            mapping.Add(this, "select");

            CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name);
        }

        private void LoadDataToSelectedGrid(DataGridView KeyDGV)
        {
            /*foreach (DataGridViewRow Row in KeyDGV.Rows)
            {
                SelectedDataGridView.Rows.Add(KeyDGV[0, Row.Index].Value.ToString(), KeyDGV[1, Row.Index].Value.ToString());
            }*/

            DataGridViewRow Row;

            for (int i = 0; i < KeyDGV.Rows.Count; i++)
            {
                Row = (DataGridViewRow)KeyDGV.Rows[i].Clone();

                for (int j = 0; j < KeyDGV.Rows[i].Cells.Count; j++)
                {
                    Row.Cells[j].Value = KeyDGV.Rows[i].Cells[j].Value;
                }

                SelectedDataGridView.Rows.Add(Row);
            }
        }

        private void LoadGrids(SqlCommand Command, DataGridViewColumn[] ColumnsName)
        {
            try
            {
                AvailableDataGridView.AutoGenerateColumns = false;
                SelectedDataGridView.AutoGenerateColumns = false;

                DataGridViewColumn Column;                

                for(int i = 0; i < ColumnsName.Length; i++)
                {
                    Column = new DataGridViewColumn(new DataGridViewTextBoxCell());
                    Column.Name = ColumnsName[i].Name;
                    Column.DataPropertyName = ColumnsName[i].DataPropertyName;
                    Column.HeaderText = ColumnsName[i].HeaderText;

                    AvailableDataGridView.Columns.Add(Column);
                    SelectedDataGridView.Columns.Add(ColumnsName[i]);
                }          

                SelectedDataGridView.Columns["id"].Visible = false;

                AvailableDataGridView.DataSource = CommonFunctions.ReadData(Command, ref Settings.Connection);
                AvailableDataGridView.Columns["id"].Visible = false;
                AvailableDataGridView.Focus();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AvailabeDataGridView_KeyPress(object sender, KeyPressEventArgs e)
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
            else if (e.KeyChar == (char)13)
                return;
            else
            {
                SearchText += e.KeyChar.ToString();
                label1.Text = SearchText;
            }

            for (int i = 0; i < AvailableDataGridView.Rows.Count; i++)
            {
                if (AvailableDataGridView.Rows[i].Cells[1].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    AvailableDataGridView.ClearSelection();
                    AvailableDataGridView.Rows[i].Selected = true;
                    AvailableDataGridView.CurrentCell = AvailableDataGridView[1, i];
                    AvailableDataGridView.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void AvailabeDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                ClearSearch();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                AddNewKey();
                ClearSearch();

                e.Handled = true;
            }
        }

        private void AvailabeDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearSearch();
        }

        private void ClearSearch()
        {
            SearchText = "";
            label1.Text = SearchText;
        }

        private void AddNewKey()
        {
            NewRow = true;

            foreach (DataGridViewRow a in SelectedDataGridView.Rows)
            {
                if (AvailableDataGridView.SelectedRows.Count > 0 && a.Cells["id"].Value != null && a.Cells["id"].Value.ToString() == AvailableDataGridView.SelectedRows[0].Cells["id"].Value.ToString())
                    NewRow = false;
            }

            if (NewRow)
            {
                DataGridViewRow Row = (DataGridViewRow)AvailableDataGridView.SelectedRows[0].Clone();

                for (int i = 0; i < AvailableDataGridView.SelectedRows[0].Cells.Count; i++)
                    Row.Cells[i].Value = AvailableDataGridView.SelectedRows[0].Cells[i].Value;

                int idx = SelectedDataGridView.Rows.Add(Row);
                //SelectedDataGridView.Rows.Add(AvailableDataGridView[0, AvailableDataGridView.CurrentRow.Index].Value.ToString(), AvailableDataGridView[1, AvailableDataGridView.CurrentRow.Index].Value.ToString());
                NewRow = true;

                SelectedDataGridView.ClearSelection();
                SelectedDataGridView.Rows[idx].Selected = true;                

                SelectedDataGridView.Rows[idx].Cells[SelectedDataGridView.Columns.Cast<DataGridViewColumn>().First(x => x.Visible).Name].Selected = true;
            }
        }

        private void AvailabeDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddNewKey();
        }

        private void SelectedDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                DeleteRow();
        }

        private void DeleteRow()
        {
            if (SelectedDataGridView.Rows.Count > 0 && SelectedDataGridView.Rows.Count > SelectedDataGridView.CurrentRow.Index)
                SelectedDataGridView.Rows.RemoveAt(SelectedDataGridView.CurrentRow.Index);
        }

        private void SelectedDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DeleteRow();
        }

        private void ShowKeyListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ShowListForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _parent.Enabled = true;
            _parent.Activate();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
