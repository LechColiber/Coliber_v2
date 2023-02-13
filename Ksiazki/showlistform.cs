using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using System.Collections.Generic;

namespace Ksiazki
{
    public partial class ShowListForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private string SearchText;
        private bool NewRow;

        public ShowListForm(DataGridView KeyDGV, SqlCommand Command, DataGridViewColumn[] ColumnsName, bool OdpowVisible = false)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            ClearSearch();

            Odpow1Button.Visible = OdpowVisible;
            OdpowTextBox.Visible = OdpowVisible;
            AddRoleButton.Visible = OdpowVisible;
            CleanRoleButton.Visible = OdpowVisible;
            RoleLabel.Visible = OdpowVisible;

            LoadGrids(Command, ColumnsName, KeyDGV);
            LoadDataToSelectedGrid(KeyDGV);

            ToolTip AddToListToolTip = new ToolTip();
            AddToListToolTip.SetToolTip(AddRoleButton, _T("add_to_list"));

            ToolTip CleanRoleButtonToolTip = new ToolTip();
            CleanRoleButtonToolTip.SetToolTip(CleanRoleButton, _T("to_clean"));

            ToolTip Odpow1ButtonToolTip = new ToolTip();
            Odpow1ButtonToolTip.SetToolTip(Odpow1Button, _T("list_of_responsibilities"));
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "select");
            mapping.Add(RoleLabel, "responsibility");
            mapping.Add(label2, "select_by_enter_or_double_click");
            mapping.Add(ExitButton, "exit");
            mapping.Add(OKButton, "confirm");
            mapping.Add(SelectedGroupBox, "list_of_selected_items");
            //mapping.Add(CoNameDGVC, "last_name");
            //mapping.Add(CoFNameDGVC, "first_name");
            //mapping.Add(OdpowiedzialnoscDGVC, "responsibility");
            mapping.Add(AvailableGroupBox, "list_of_available_items");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
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

        private void LoadGrids(SqlCommand Command, DataGridViewColumn[] ColumnsName, DataGridView DGV)
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
                    Column.HeaderText = DGV.Columns[i].HeaderText;
                    Column.Visible = DGV.Columns[i].Visible;

                    AvailableDataGridView.Columns.Add(Column);
                    //SelectedDataGridView.Columns.Add(ColumnsName[i]);
                }

                for (int i = 0; i < DGV.Columns.Count; i++)
                {
                    Column = new DataGridViewColumn(new DataGridViewTextBoxCell());
                    Column.Name = DGV.Columns[i].Name;
                    Column.DataPropertyName = DGV.Columns[i].DataPropertyName;
                    Column.HeaderText = DGV.Columns[i].HeaderText;
                    Column.Visible = DGV.Columns[i].Visible;

                    //AvailableDataGridView.Columns.Add(Column);
                    SelectedDataGridView.Columns.Add(Column);
                }

                //SelectedDataGridView.Columns["id"].Visible = false;

                AvailableDataGridView.DataSource = CommonFunctions.ReadData(Command, ref Settings.Connection);
                //AvailableDataGridView.Columns["id"].Visible = false;
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
            else if (e.KeyCode == Keys.Escape)
                this.Dispose();
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
                if (AvailableDataGridView.SelectedRows.Count > 0 && a.Cells[0].Value != null && a.Cells[0].Value.ToString() == AvailableDataGridView.SelectedRows[0].Cells["id"].Value.ToString())
                    NewRow = false;
            }

            if (NewRow)
            {
                DataGridViewRow Row = (DataGridViewRow)AvailableDataGridView.SelectedRows[0].Clone();

                for (int i = 0; i < AvailableDataGridView.SelectedRows[0].Cells.Count; i++)
                    Row.Cells[i].Value = AvailableDataGridView.SelectedRows[0].Cells[i].Value;

                SelectedDataGridView.Rows.Add(Row);

                Row.Selected = true;
                SelectedDataGridView.CurrentCell = Row.Cells[1];
                //SelectedDataGridView.Rows.Add(AvailableDataGridView[0, AvailableDataGridView.CurrentRow.Index].Value.ToString(), AvailableDataGridView[1, AvailableDataGridView.CurrentRow.Index].Value.ToString());
                NewRow = true;
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
                this.Dispose();
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
                this.Dispose();
        }

        private void Odpow1Button_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_OdpowiedzialnoscList; ";

            ShowForm Formka = new ShowForm(Command, "Odpowiedzialność", "");

            if (Formka.ShowDialog() == DialogResult.OK)
            {
                //SelectedDataGridView.SelectedRows[0].Cells["OdpowiedzialnoscDGVC"].Value = Formka.First;
                //SelectedDataGridView.SelectedRows[0].Cells["CoRoleIDDGVC"].Value = Formka.Dt.Cells["id"].Value.ToString();

                OdpowTextBox.Text = Formka.First;
            }
        }

        private void SelectedDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            Odpow1Button.Enabled = SelectedDataGridView.SelectedRows.Count > 0;
            OdpowTextBox.Enabled = SelectedDataGridView.SelectedRows.Count > 0;
            AddRoleButton.Enabled = SelectedDataGridView.SelectedRows.Count > 0;
            CleanRoleButton.Enabled = SelectedDataGridView.SelectedRows.Count > 0;

            if (SelectedDataGridView.Columns.Contains("OdpowiedzialnoscDGVC") && SelectedDataGridView.SelectedRows.Count > 0 && SelectedDataGridView.SelectedRows[0].Cells["OdpowiedzialnoscDGVC"].Value != null)
                OdpowTextBox.Text = SelectedDataGridView.SelectedRows[0].Cells["OdpowiedzialnoscDGVC"].Value.ToString();
            else            
                OdpowTextBox.ResetText();           
        }

        #region CheckOdpowExists(SqlCommand Command, string Odpow, out string OdpowID) - GOOD
        private bool CheckOdpowExists(SqlCommand Command, string Odpow, out string OdpowID)
        {
            try
            {
                if (Odpow == null)
                    Odpow = "-1";

                if (string.IsNullOrEmpty(Odpow.Trim()))
                {
                    OdpowID = "-1";
                    return true;
                }

                Command.Parameters.AddWithValue("@p_Name", Odpow.Trim());

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                Command.Parameters.Clear();

                if (Dt.Rows.Count > 0)
                {
                    OdpowID = Dt.Rows[0][0].ToString();

                    return OdpowID != "-1";
                }
            }
            catch (Exception)
            {

            }

            OdpowID = "-1";
            return false;
        }
        #endregion

        private void AddRoleButton_Click(object sender, EventArgs e)
        {
            AddRole();
        }

        private void OdpowTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)            
                AddRole();            
        }

        private void AddRole()
        {
            if (SelectedDataGridView.SelectedRows.Count > 0)
            {
                string OdpowID;
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Ksiazki_OdpowiedzialnoscExists @p_Name; ";
                CheckOdpowExists(Command, OdpowTextBox.Text, out OdpowID);

                SelectedDataGridView.SelectedRows[0].Cells["CoRoleIDDGVC"].Value = OdpowID;
                SelectedDataGridView.SelectedRows[0].Cells["OdpowiedzialnoscDGVC"].Value = OdpowTextBox.Text;
            }
        }

        private void CleanRoleButton_Click(object sender, EventArgs e)
        {
            if (SelectedDataGridView.SelectedRows.Count > 0)
            {
                SelectedDataGridView.SelectedRows[0].Cells["CoRoleIDDGVC"].Value = -1;
                SelectedDataGridView.SelectedRows[0].Cells["OdpowiedzialnoscDGVC"].Value = "";
                OdpowTextBox.Text = "";
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
