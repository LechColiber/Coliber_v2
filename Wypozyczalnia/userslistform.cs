using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Wypozyczalnia
{
    public partial class UsersListForm : Form
    {
        public enum Mode { ManageUser, SelectUser };
        private Mode _currentMode;
        private Form _parent;
        private ActiveMdiForm _currentMdiForm;
        private enum ActiveMdiForm { mainForm, UserForm, NewUserForm };
        public string CurrentUserName { get { return usersDGV.SelectedRows.Count > 0 ? usersDGV.SelectedRows[0].Cells[userNameDGVC.Name].Value.ToString() : ""; } }
        public int CurrentUserId { get { return usersDGV.SelectedRows.Count > 0 ? (int)usersDGV.SelectedRows[0].Cells[idUsersDGVC.Name].Value : -1; } }
        string SearchText;
        private int selectedUserId;
        private object selectedGroupId;
        private Dictionary<string, string> _translationsDictionary;
        public UsersListForm(Mode Mode, Form Parent, int EmployeeID)
        {            
            InitializeComponent();

            setControlsText();

            Settings.SetSettings();
            Settings.employeeID = EmployeeID;
            _currentMdiForm = ActiveMdiForm.mainForm;

            if (Parent != null)
            {
                this.MdiParent = Parent.MdiParent;
                _parent = Parent;
                _parent.Enabled = false;
            }

            this._currentMode = Mode;
            SetControlls(Mode);

            LoadGroups();

            ClearSearch();

            usersDGV.Select();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(groupsLabel, "groups");
            mapping.Add(nameLabel, "name_last_name");
            mapping.Add(usersLabel, "users");
            mapping.Add(haveCheckBox, "only_with_borrows");
            mapping.Add(newUserButton, "new");
            mapping.Add(selectUserButton, "select_001");
            mapping.Add(escapeButton, "exit");

            mapping.Add(this, "choose_user");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void SetControlls(Mode Mode)
        {
            newUserButton.Visible = Mode == UsersListForm.Mode.ManageUser;
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoadGroups()
        {
            groupsDGV.Rows.Clear();

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_uzytkownicy_grupy_liczby @onlyWithBorrows; ";
            Command.Parameters.AddWithValue("@onlyWithBorrows", haveCheckBox.Checked);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {
                groupsDGV.Rows.Add(-1, "[Wszyscy] (" + Dt.Rows[0]["liczba_wszystkich"] + ")");
                groupsDGV.Rows.Add(DBNull.Value, "- BRAK - (" + Dt.Rows[0]["bez_grupy"] + ")");
            }

            Command = new SqlCommand();
            Command.CommandText = "EXEC w2_lista_grup 1, NULL, @onlyWithBorrows; ";
            Command.Parameters.AddWithValue("@onlyWithBorrows", haveCheckBox.Checked);

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                groupsDGV.Rows.Add(Dt.Rows[i]["grupa_id"], Dt.Rows[i]["nazwa"]);
            }

            groupsDGV.Focus();
        }
        private void LoadUsers(object groupId, bool onlyWithBorrows, string userName = "")
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_lista_uzytkownikow @grupa_id, @userName, @withBorrows; ";

            /*if(groupId is DBNull)
                Command.Parameters.AddWithValue("@grupa_id", groupId);*/

            Command.Parameters.AddWithValue("@grupa_id", groupId is DBNull ? DBNull.Value : groupId);
            Command.Parameters.AddWithValue("@userName", userName);
            Command.Parameters.AddWithValue("@withBorrows", onlyWithBorrows);            

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if(usersDGV.Rows.Count > 0)
                usersDGV.Rows.Clear();

            string locked = "";
            
            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Boolean.Parse(Dt.Rows[i]["zablokowany"].ToString()))
                    locked = _T("blocked");

                usersDGV.Rows.Add(Dt.Rows[i]["uzytk_id"], Dt.Rows[i]["nazwa"], locked);

                locked = "";
            }

            selectUserButton.Enabled = Dt.Rows.Count > 0;

            usersDGV.Focus();
        }

        private void UsersListForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                this.Close();
            }
            else if(e.KeyCode == Keys.Enter && usersDGV.SelectedRows.Count > 0)
            {
                CloseWindow();
            }
        }

        private void groupsDGV_SelectionChanged(object sender, EventArgs e)
        {
            ClearSearch();
            if(groupsDGV.SelectedRows.Count > 0)
                LoadUsers(groupsDGV.SelectedRows[0].Cells["idGroupsDGVC"].Value, haveCheckBox.Checked);
        }

        private void searchUserButton_Click(object sender, EventArgs e)
        {
            if (groupsDGV.SelectedRows.Count > 0)
                LoadUsers(groupsDGV.SelectedRows[0].Cells["idGroupsDGVC"].Value, haveCheckBox.Checked, searchUserTextBox.Text.Trim());
        }

        private void haveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (groupsDGV.SelectedRows.Count > 0)
            {
                string currentSelectedGroup = groupsDGV.SelectedRows[0].Cells["idGroupsDGVC"].Value.ToString();

                LoadGroups();
                LoadUsers(groupsDGV.SelectedRows[0].Cells["idGroupsDGVC"].Value, haveCheckBox.Checked);

                for(int i = 0; i < groupsDGV.Rows.Count; i++)
                {
                    if(groupsDGV.Rows[i].Cells["idGroupsDGVC"].Value.ToString() == currentSelectedGroup)
                    {
                        groupsDGV.ClearSelection();
                        groupsDGV.Rows[i].Selected = true;
                        groupsDGV.Rows[i].Cells[groupNameDGVC.Name].Selected = true;
                        break;
                    }
                }
            }
        }

        private void searchUserTextBox_TextChanged(object sender, EventArgs e)
        {
            ClearSearch();
            SearchUserInDGV(searchUserTextBox.Text.Trim());
        }

        private void SearchUserInDGV(string userName)
        {
            for (int i = 0; i < usersDGV.Rows.Count; i++)
            {
                if (usersDGV.Rows[i].Cells["userNameDGVC"].Value.ToString().ToLower().StartsWith(userName.ToLower()))
                {
                    usersDGV.ClearSelection();
                    usersDGV.Rows[i].Selected = true;
                    usersDGV.FirstDisplayedScrollingRowIndex = i;

                    usersDGV.CurrentCell = usersDGV.Rows[i].Cells["userNameDGVC"];

                    break;
                }
            }
        }

        private void newUserButton_Click(object sender, EventArgs e)
        {
            int groupid = -1;

            if ((groupsDGV.SelectedRows[0].Cells[idGroupsDGVC.Name].Value is int) && ((int)groupsDGV.SelectedRows[0].Cells[idGroupsDGVC.Name].Value) > 0)
                groupid = (int)groupsDGV.SelectedRows[0].Cells[idGroupsDGVC.Name].Value;

            UserForm Uf = new UserForm(this, groupid);
            Uf.Show();

            _currentMdiForm = ActiveMdiForm.NewUserForm;
        }

        private void selectUserButton_Click(object sender, EventArgs e)
        {
            CloseWindow();
        }

        private void usersDGV_DoubleClick(object sender, EventArgs e)
        {
            CloseWindow();
        }

        private void CloseWindow()
        {
            if (_currentMode == Mode.ManageUser)
                OpenUserForm();
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void OpenUserForm()
        {
            if (usersDGV.SelectedRows.Count == 0)
                return;

            selectedUserId = (int) usersDGV.SelectedRows[0].Cells["idUsersDGVC"].Value;
            selectedGroupId = groupsDGV.SelectedRows[0].Cells[idGroupsDGVC.Name].Value;

            UserForm Uf = new UserForm(usersDGV.SelectedRows[0].Cells["idUsersDGVC"].Value.ToString(), this);
            Uf.Show();

            _currentMdiForm = ActiveMdiForm.UserForm;
        }

        private void UsersListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_parent != null)
            {
                _parent.Enabled = true;
                _parent.Focus();
            }
        }

        private void ClearSearch()
        {
            SearchText = "";
            SearchLabel.Text = SearchText;
        }

        private void usersDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.Handled = true;
            else if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                ClearSearch();
            }
        }

        private void groupsDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                e.Handled = true;
        }

        private void UsersListForm_Activated(object sender, EventArgs e)
        {
            if (_currentMdiForm == ActiveMdiForm.UserForm)
            {
                LoadGroups();
                DataGridViewRow groupRow = groupsDGV.Rows.AsParallel().Cast<DataGridViewRow>().SingleOrDefault(x => x.Cells[idGroupsDGVC.Name].Value.ToString() == selectedGroupId.ToString());

                if (groupRow != null)
                {
                    groupsDGV.ClearSelection();
                    groupsDGV.Rows[groupRow.Index].Selected = true;
                    groupsDGV.Rows[groupRow.Index].Cells[groupsDGV.Columns.Cast<DataGridViewColumn>().First(x => x.Visible).Name].Selected = true;
                }

                LoadUsers(groupsDGV.SelectedRows[0].Cells[idGroupsDGVC.Name].Value, haveCheckBox.Checked);
                searchUserTextBox.Text = "";
                ClearSearch();

                //int idx = usersDGV.Rows.AsParallel().Cast<DataRow>().FirstOrDefault(x => (int)x[""] == selectedUserId).;
                DataGridViewRow row = usersDGV.Rows.AsParallel().Cast<DataGridViewRow>().SingleOrDefault(x => (int)x.Cells[idUsersDGVC.Name].Value == selectedUserId);

                if(row != null)
                {
                    usersDGV.ClearSelection();
                    usersDGV.Rows[row.Index].Selected = true;
                    usersDGV.Rows[row.Index].Cells[usersDGV.Columns.Cast<DataGridViewColumn>().First(x => x.Visible).Name].Selected = true;
                }
            }
            else if(_currentMdiForm == ActiveMdiForm.NewUserForm)
            {
                LoadGroups();
                LoadUsers(groupsDGV.SelectedRows[0].Cells["idGroupsDGVC"].Value, haveCheckBox.Checked);
                searchUserTextBox.Text = "";
                ClearSearch();
            }

            _currentMdiForm = ActiveMdiForm.mainForm;
        }

        private void usersDGV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
            {
                if (SearchText.Length > 0)
                {
                    SearchText = SearchText.Remove(SearchText.Length - 1);
                    SearchLabel.Text = SearchText;
                    //searchUserTextBox.Text = SearchText;
                }
                e.Handled = true;
            }
            else
            {
                SearchText += e.KeyChar.ToString();
                SearchLabel.Text = SearchText;
                //searchUserTextBox.Text = SearchText;
            }

            for (int i = 0; i < usersDGV.Rows.Count; i++)
            {
                if (usersDGV.Rows[i].Cells[userNameDGVC.Name].Value.ToString().ToLower().StartsWith(SearchText.ToLower()))
                {
                    usersDGV.ClearSelection();
                    usersDGV.Rows[i].Selected = true;

                    usersDGV.CurrentCell = usersDGV[userNameDGVC.Name, i];
                    usersDGV.FirstDisplayedScrollingRowIndex = i;
                    break;
                }
            }
        }

        private void usersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ClearSearch();
        }

        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
    }
}
