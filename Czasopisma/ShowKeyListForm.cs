using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Czasopisma
{
    public partial class ShowKeyListForm : Form
    {
        private string SearchText;
        private bool NewRow;

        private Dictionary<string, string> _translationsDictionary;

        public ShowKeyListForm(DataGridView KeyDGV)
        {
            InitializeComponent();

            setControlsText();

            ClearSearch();

            LoadGrids();
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

            mapping.Add(this, "keys");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void LoadDataToSelectedGrid(DataGridView KeyDGV)
        {
            foreach (DataGridViewRow Row in KeyDGV.Rows)
            {
                SelectedDataGridView.Rows.Add(KeyDGV[0, Row.Index].Value.ToString(), KeyDGV[1, Row.Index].Value.ToString());
            }
        }

        private void LoadGrids()
        {
            try
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Czasop_KeysList @id_rodzaj;";
                Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

                AvailabeDataGridView.DataSource = CommonFunctions.ReadData(Command, ref Settings.Connection);

                SelectedDataGridView.Columns.Add("id", "id");
                SelectedDataGridView.Columns.Add("Key", _translationsDictionary.getStringFromDictionary("key", "Klucz"));

                SelectedDataGridView.Columns["id"].Visible = false;

                AvailabeDataGridView.Focus();
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

            for (int i = 0; i < AvailabeDataGridView.Rows.Count; i++)
            {
                if (AvailabeDataGridView.Rows[i].Cells[1].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    AvailabeDataGridView.ClearSelection();
                    AvailabeDataGridView.Rows[i].Selected = true;
                    AvailabeDataGridView.CurrentCell = AvailabeDataGridView[1, i];
                    AvailabeDataGridView.FirstDisplayedScrollingRowIndex = i;
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
            else if (e.KeyCode == Keys.Escape)
                this.Close();
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
                if (a.Cells["id"].Value.ToString() == AvailabeDataGridView.CurrentRow.Cells["id"].Value.ToString())
                    NewRow = false;
            }

            if (NewRow)
            {
                int idx = SelectedDataGridView.Rows.Add(AvailabeDataGridView[0, AvailabeDataGridView.CurrentRow.Index].Value.ToString(), AvailabeDataGridView[1, AvailabeDataGridView.CurrentRow.Index].Value.ToString());
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
            if (e.KeyCode == Keys.Escape)
                this.Close();
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

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
