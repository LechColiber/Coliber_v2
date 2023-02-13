using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Wypozyczalnia
{
    public partial class UserGroupUC : UserControl
    {
        int _currentMode;
        UserGroup _group;

        public GroupCollection Groups { get; set; }
        private Dictionary<string, string> _translationsDictionary;
        public UserGroupUC()
        {
            InitializeComponent();

            setControlsText();

            Groups = new GroupCollection();

            GroupState(0);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(nameDGVC, "name");
            mapping.Add(addUserGroupButton, "add_group");
            mapping.Add(editUserGroupButton, "edit_group");
            mapping.Add(deleteUserGroupButton, "delete_group");
            mapping.Add(saveUserGroupButton, "save");
            mapping.Add(cancelUserGroupButton, "cancel");
            mapping.Add(groupNameLabel, "name");
            mapping.Add(amountLimitLabel, "default_amount_limit");
            mapping.Add(timeLimitLabel, "default_time_limit");
            mapping.Add(defualtPermissionLabel, "default_resource_permissions");
            mapping.Add(rightNameDGVC, "name");
            mapping.Add(isActiveCheckBox, "active_group");
            mapping.Add(deletePermissionButton, "delete_permission");
            mapping.Add(addPermissionButton, "add_permission");
            mapping.Add(commentsLabel, "comments");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        #region public void LoadGroups(GroupCollection groups)
        public void LoadGroups(GroupCollection groups)
        {
            Groups = groups;

            foreach (UserGroup group in groups.Values)
                groupsDGV.Rows.Add(group.HashCode, group.GroupId, group.Name);
        }
        #endregion

        #region private void maxBorrowsTextBox_TextChanged(object sender, EventArgs e)
        private void maxBorrowsTextBox_TextChanged(object sender, EventArgs e)
        {
            maxBorrowsTextBox.Text = string.Join("", maxBorrowsTextBox.Text.Where(x => char.IsDigit(x)).ToArray());
            maxBorrowsTextBox.SelectionStart = maxBorrowsTextBox.TextLength;
        }
        #endregion

        #region private void maxTimeTextBox_TextChanged(object sender, EventArgs e)
        private void maxTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            maxTimeTextBox.Text = string.Join("", maxTimeTextBox.Text.Where(x => char.IsDigit(x)));
            maxTimeTextBox.SelectionStart = maxTimeTextBox.TextLength;
        }
        #endregion

        #region private void addUserGroupButton_Click(object sender, EventArgs e)
        private void addUserGroupButton_Click(object sender, EventArgs e)
        {
            GroupState(1);
            _group = new UserGroup();

            if (this.ParentForm is ConfigurationForm)
                (this.ParentForm as ConfigurationForm).DisableButtons(true);
        }
        #endregion

        #region private void editUserGroupButton_Click(object sender, EventArgs e)
        private void editUserGroupButton_Click(object sender, EventArgs e)
        {
            GroupState(2);

            if (this.ParentForm is ConfigurationForm)
                (this.ParentForm as ConfigurationForm).DisableButtons(true);
        }
        #endregion

        #region private void deleteUserGroupButton_Click(object sender, EventArgs e)
        private void deleteUserGroupButton_Click(object sender, EventArgs e)
        {
            if (groupsDGV.SelectedRows.Count > 0 && MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_this_group", "Czy chcesz usunąć grupę? Użytkownicy przypisani do tej grupy nie będą przypisani do żadnej grupy."), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie grupy"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Groups.Remove((int)groupsDGV.SelectedRows[0].Cells[syncIdGroupsDGVC.Name].Value);
                groupsDGV.Rows.RemoveAt(groupsDGV.SelectedRows[0].Index);
            }

            if (groupsDGV.Rows.Count == 0)
            {
                GroupState(1);
                GroupState(0);
            }
        }
        #endregion

        #region private void GroupState(int mode)
        private void GroupState(int mode)
        {
            // 0 - brak
            // 1 - nowy
            // 2 - edycja

            _currentMode = mode;

            bool locked = mode != 0;

            if (mode == 1)
            {
                groupNameTextBox.Text = "";
                maxBorrowsTextBox.Text = "";
                maxTimeTextBox.Text = "";

                permissionsDGV.Rows.Clear();
                isActiveCheckBox.Checked = true;

                commentsRTB.Text = "";
            }

            groupsDGV.Enabled = !locked;

            groupNameTextBox.ReadOnly = !locked;
            maxBorrowsTextBox.ReadOnly = !locked;
            maxTimeTextBox.ReadOnly = !locked;

            isActiveCheckBox.Enabled = locked;

            commentsRTB.ReadOnly = !locked;
            commentsRTB.BackColor = locked ? Color.White : Color.FromKnownColor(KnownColor.Control);

            addUserGroupButton.Enabled = !locked;
            editUserGroupButton.Enabled = !locked && groupsDGV.SelectedRows.Count > 0;
            deleteUserGroupButton.Enabled = !locked && groupsDGV.SelectedRows.Count > 0;

            saveUserGroupButton.Enabled = locked;
            cancelUserGroupButton.Enabled = locked;   
 
            addPermissionButton.Enabled = locked;
            deletePermissionButton.Enabled = locked && permissionsDGV.SelectedRows.Count > 0;
        }
        #endregion

        #region private void saveUserGroupButton_Click(object sender, EventArgs e)
        private void saveUserGroupButton_Click(object sender, EventArgs e)
        {
            if (!CheckForSave())
                return;

            if(_currentMode == 1)
            {
                UserGroup group = new UserGroup(groupNameTextBox.Text.Trim(), commentsRTB.Text.Trim(), isActiveCheckBox.Checked, short.Parse(maxTimeTextBox.Text), short.Parse(maxBorrowsTextBox.Text));

                foreach (var right in _group.Rights.Values)
                    group.Rights.Add(right);

                int idx = groupsDGV.Rows.Add(group.HashCode, group.GroupId, group.Name);

                Groups.Add(group);
                GroupState(0);

                groupsDGV.ClearSelection();
                groupsDGV.Rows[idx].Selected = true;
                groupsDGV.FirstDisplayedScrollingRowIndex = idx;
                groupsDGV.CurrentCell = groupsDGV.Rows[idx].Cells[nameDGVC.Name];
            
            }
            else if(_currentMode == 2)
            {
                if(groupsDGV.SelectedRows.Count > 0)
                {
                    int syncId = (int)groupsDGV.SelectedRows[0].Cells[syncIdGroupsDGVC.Name].Value;
                    Groups[syncId].Name = groupNameTextBox.Text.Trim();
                    Groups[syncId].Comments = commentsRTB.Text.Trim();
                    Groups[syncId].IsActive = isActiveCheckBox.Checked;
                    Groups[syncId].TimeLimit = short.Parse(maxTimeTextBox.Text);
                    (Groups[syncId] as UserGroup).CountLimit = short.Parse(maxBorrowsTextBox.Text);

                    GroupState(0);
                }
            }

            if (this.ParentForm is ConfigurationForm)
                (this.ParentForm as ConfigurationForm).DisableButtons(false);
        }
        #endregion

        #region private void cancelUserGroupButton_Click(object sender, EventArgs e)
        private void cancelUserGroupButton_Click(object sender, EventArgs e)
        {
            GroupState(0);
            LoadDataIntoControls();

            if (this.ParentForm is ConfigurationForm)
                (this.ParentForm as ConfigurationForm).DisableButtons(false);
        }
        #endregion

        #region private bool CheckForSave()
        private bool CheckForSave()
        {
            if (string.IsNullOrEmpty(groupNameTextBox.Text.Trim()))
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("enter_group_name", "Proszę wprowadzić nazwę grupy."), _translationsDictionary.getStringFromDictionary("to_correct_data", "Uzupełnienie danych"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (string.IsNullOrEmpty(maxBorrowsTextBox.Text.Trim()))
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("maximun_resources_amount_must_be_given", "Maksymalna ilość zasobów musi być uzupełniona!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Uzupełnienie danych"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrEmpty(maxTimeTextBox.Text.Trim()))
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("maximum_time_limit_must_be_given", "Maksymalny czas przetrzymywania zasobu musi być uzupełniony!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Uzupełnienie danych"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        #endregion

        #region private void deletePermissionButton_Click(object sender, EventArgs e)
        private void deletePermissionButton_Click(object sender, EventArgs e)
        {
            if (permissionsDGV.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_this_permission", "Czy chcesz usunąć to uprawnienie z listy uprawnień grupy?"), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie uprawnienia"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Groups[(int)groupsDGV.SelectedRows[0].Cells[syncIdGroupsDGVC.Name].Value].Rights.Remove((int)permissionsDGV.SelectedRows[0].Cells[syncIDDGVC.Name].Value);
                    permissionsDGV.Rows.RemoveAt(permissionsDGV.SelectedRows[0].Index);

                    deletePermissionButton.Enabled = permissionsDGV.SelectedRows.Count > 0;
                }
            }
        }
        #endregion

        #region private void permissionsDGV_SelectionChanged(object sender, EventArgs e)
        private void permissionsDGV_SelectionChanged(object sender, EventArgs e)
        {
            deletePermissionButton.Enabled = permissionsDGV.SelectedRows.Count > 0 && _currentMode != 0;            
        }
        #endregion

        #region private void groupsDGV_SelectionChanged(object sender, EventArgs e)
        private void groupsDGV_SelectionChanged(object sender, EventArgs e)
        {
            LoadDataIntoControls();
        }
        #endregion

        private void LoadDataIntoControls()
        {
            if (groupsDGV.SelectedRows.Count > 0 && _currentMode == 0)
            {
                int syncId = (int)groupsDGV.SelectedRows[0].Cells[syncIdGroupsDGVC.Name].Value;

                groupNameTextBox.Text = Groups[syncId].Name;
                maxBorrowsTextBox.Text = (Groups[syncId] as UserGroup).CountLimit.ToString();
                maxTimeTextBox.Text = Groups[syncId].TimeLimit.ToString();
                isActiveCheckBox.Checked = (bool)Groups[syncId].IsActive;
                commentsRTB.Text = Groups[syncId].Comments;

                permissionsDGV.Rows.Clear();

                foreach (var right in Groups[syncId].Rights)
                    permissionsDGV.Rows.Add(right.Value.HashCode, right.Value.Name);
            }

            editUserGroupButton.Enabled = groupsDGV.SelectedRows.Count > 0;
            deleteUserGroupButton.Enabled = groupsDGV.SelectedRows.Count > 0;
        }

        #region private void isActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        private void isActiveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(!isActiveCheckBox.Checked && _currentMode != 0)
            {
                if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("all_users_will_be_lock_continue", "Wszyscy użytkownicy tej grupy zostaną zablokowani. Czy kontynuować?"), _translationsDictionary.getStringFromDictionary("change_in_activity", "Zmiana stanu aktywności"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                    isActiveCheckBox.Checked = true;
            }
        }
        #endregion

        private void addPermissionButton_Click(object sender, EventArgs e)
        {
            List<string> permissions = new List<string>();

            if(_currentMode == 2)
                foreach (var right in Groups[(int)groupsDGV.SelectedRows[0].Cells[syncIdGroupsDGVC.Name].Value].Rights)
                    permissions.Add(right.Value.RightId.ToString());
            else
                foreach (var right in _group.Rights)
                    permissions.Add(right.Value.RightId.ToString());

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_lista_praw; ";

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].Name = "name";
            Columns[0].HeaderText = _translationsDictionary.getStringFromDictionary("name", "Nazwa");
            Columns[0].DataPropertyName = "nazwa";
            Columns[0].Visible = true;
            Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].Name = "id";
            Columns[1].DataPropertyName = "prawa_id";
            Columns[1].Visible = false;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].Name = "stan";
            Columns[2].DataPropertyName = "stan_domyslny";
            Columns[2].Visible = false;

            ShowForm SF = new ShowForm(Command, Columns, permissions, "name");

            if (SF.ShowDialog() == DialogResult.OK)
            {
                bool isActive = GeneralBase.ConvertToBool(SF.Dt.Cells["stan"].Value.ToString());
                
                Right right = new Right((int)SF.Dt.Cells["id"].Value, SF.Dt.Cells["name"].Value.ToString(), isActive);
                right.Name = right.Name;

                if (_currentMode == 2)
                    Groups[(int)groupsDGV.SelectedRows[0].Cells[syncIdGroupsDGVC.Name].Value].Rights.Add(right);
                else
                    _group.Rights.Add(right);

                permissionsDGV.Rows.Add(right.GetHashCode(), right.Name);
                deletePermissionButton.Enabled = permissionsDGV.SelectedRows.Count > 0;
            }
        }
    }
}
