using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Wypozyczalnia
{
    public partial class ResourceForm : Form
    {
        private Manager _manager;
        private Resource _resource;
        private Form _parent;
        private Dictionary<string, string> _translationsDictionary;
        public ResourceForm(int resourceId, int employeeId, Form parent)
        {
            InitializeComponent();
            
            setControlsText();

            if (parent != null)
            {
                _parent = parent;
                parent.Enabled = false;
                this.MdiParent = parent.MdiParent;
            }

            _manager = new Manager(employeeId, Settings.ConnectionString);

            _resource = _manager.GetResourceById(resourceId);

            TitleRTB.Text = _resource.Title;
            barcodeTextBox.Text = _resource.Barcode;
            noIvnTextBox.Text = _resource.NoInv;
            groupTextBox.Text = _resource.GroupName;
            timeTextBox.Text = _resource.TimeLimit.ToString();
            isBorrowedCheckBox.Checked = _resource.IsBorrowed;
            CommentsRTB.Text = _resource.Comments;

            foreach (var permission in _resource.Permissions)
                permissionsDGV.Rows.Add(permission.Value.HashCode, permission.Value.Right.Name);

            deletePermissionButton.Enabled = permissionsDGV.SelectedRows.Count > 0;

            //startDatePermissionDTP.Value = DateTime.Now;

            historyDGV.DataSource = _manager.GetResourceHistoryById(resourceId);
            orderHistoryDGVC.DataSource = _manager.GetResourceOrderHistoryById(resourceId);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(generalTabPage, "general");
            mapping.Add(barcodeLabel, "barcode");
            mapping.Add(invertoryNumberLabel, "");
            mapping.Add(groupIdLabel, "inventory_number");
            mapping.Add(timeLimitLabel, "time_limit_to_return");
            mapping.Add(daysLabel, "days");
            mapping.Add(isBorrowedCheckBox, "borrowed_single");
            mapping.Add(commentsLabel, "comments");

            mapping.Add(PermissionstabPage, "permissions");
            mapping.Add(namePermissionsDGVC, "name");
            mapping.Add(validFromLabel, "valid_from");
            mapping.Add(validToLabel, "valid_to");
            mapping.Add(permissionCheckBox, "locked_permission");
            mapping.Add(deletePermissionButton, "delete_permission");
            mapping.Add(addPermissionButton, "add_permission");

            mapping.Add(historyTabPage, "borrow_history");
            mapping.Add(borrowDateDGVC, "borrow_date");
            mapping.Add(returnDateDGVC, "date_of_return");
            mapping.Add(delayDGVC, "delay");
            mapping.Add(userDGVC, "user");
            mapping.Add(employeeDGVC, "employee");
            mapping.Add(returnEmployeeDGVC, "person_returning_resource");

            mapping.Add(orderHistoryTabPage, "order_history");
            mapping.Add(orderDateDGVC, "order_date");
            mapping.Add(dataGridViewTextBoxColumn2, "date_of_realization");
            mapping.Add(stateDGVC, "order_state");
            mapping.Add(dataGridViewTextBoxColumn4, "user");
            mapping.Add(dataGridViewTextBoxColumn5, "employee");

            mapping.Add(SaveButton, "save");
            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "resource_info");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResourceForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void timeTextBox_TextChanged(object sender, EventArgs e)
        {
            timeTextBox.Text = string.Join("", timeTextBox.Text.Where(x => char.IsDigit(x)));
        }

        private void addPermissionButton_Click(object sender, EventArgs e)
        {
            List<string> permissions = new List<string>();

            for (int i = 0; i < permissionsDGV.Rows.Count; i++)
            {
                permissions.Add(_resource.Permissions[(int)permissionsDGV.Rows[i].Cells[syncIdPermissionsDGVC.Name].Value].Right.RightId.ToString());
            }

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

                ResourcePermission permission = new ResourcePermission(new Right((int)SF.Dt.Cells["id"].Value, SF.Dt.Cells["name"].Value.ToString(), isActive), DateTime.Now, DateTime.Now.AddYears(25), !isActive, _resource.ResourceId);

                endDatePermissionDTP.Value = DateTime.Now.AddYears(25);
                _resource.Permissions.Add(permission);
                int idx = permissionsDGV.Rows.Add(permission.GetHashCode(), permission.Right.Name);

                permissionsDGV.ClearSelection();
                permissionsDGV.Rows[idx].Selected = true;
                permissionsDGV.FirstDisplayedScrollingRowIndex = idx;
                permissionsDGV.CurrentCell = permissionsDGV.Rows[idx].Cells[namePermissionsDGVC.Name];

                permissionCheckBox.Checked = !isActive;
                deletePermissionButton.Enabled = permissionsDGV.SelectedRows.Count > 0;
            }
        }

        private void startDatePermissionDTP_ValueChanged(object sender, EventArgs e)
        {
            //endDatePermissionDTP.MinDate = startDatePermissionDTP.Value;

            if (permissionsDGV.SelectedRows.Count > 0)
            {
                _resource.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].StartDate = startDatePermissionDTP.Value;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (timeTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("time_limit_to_return_must_be_enter", "Limit czasu na oddanie zasobu musi być uzupełniony!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Uzupełnienie danych"), MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            _resource.TimeLimit = Int32.Parse(timeTextBox.Text.Trim());

            if (_manager.Save())
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("saved", "Zapisano!"), _translationsDictionary.getStringFromDictionary("data_save", "Zapis danych"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void permissionsDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (permissionsDGV.SelectedRows.Count > 0)
            {
                startDatePermissionDTP.Value = _resource.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].StartDate;
                endDatePermissionDTP.Value = _resource.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].EndDate;
                permissionCheckBox.Checked = _resource.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].IsLocked;
            }

            deletePermissionButton.Enabled = permissionsDGV.SelectedRows.Count > 0;
        }

        private void permissionCheckBox_Click(object sender, EventArgs e)
        {
            if (permissionsDGV.SelectedRows.Count > 0)
            {
                _resource.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].IsLocked = permissionCheckBox.Checked;
            }
        }

        private void endDatePermissionDTP_ValueChanged(object sender, EventArgs e)
        {
            if (permissionsDGV.SelectedRows.Count > 0)
            {
                if (startDatePermissionDTP.Value > endDatePermissionDTP.Value)
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("end_date_cannot_be_earlier_than_start_date", "Data \"Obowiązuje do\" nie może być wcześniejsza niż \"Obowiązuje od\"!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Złe dane"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    endDatePermissionDTP.Value = DateTime.Now;
                    endDatePermissionDTP.Focus();
                    return;
                }

                _resource.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].EndDate = endDatePermissionDTP.Value;
            }
        }

        private void deletePermissionButton_Click(object sender, EventArgs e)
        {
            if(permissionsDGV.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_this_permission", "Czy chcesz usunąć to uprawnienie z listy uprawnień zasobu?"), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie uprawnienia"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _resource.Permissions.Remove((int)permissionsDGV.SelectedRows[0].Cells[syncIdPermissionsDGVC.Name].Value);
                    permissionsDGV.Rows.RemoveAt(permissionsDGV.SelectedRows[0].Index);
                }
            }
        }

        private void ResourceForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(_parent != null)
            {
                _parent.Enabled = true;
                _parent.Focus();
            }
        }
    }
}
