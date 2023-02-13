using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Wypozyczalnia
{
    public partial class UserForm : Form
    {
        public enum ModeEnum
        {
            Add, Edit
        }

        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private ModeEnum _currentMode;
        private int _currentAddressMode;
        private int _currentTeleaddressMode;

        private string userID;

        Dictionary<int, string> _addressTypes;
        Dictionary<int, string> _teleaddressTypes;
        private User _newUser;
        private Manager _manager;
        private Form _parent;
        private Dictionary<string, string> _translationsDictionary;

        public UserForm(Form Parent, int GroupId = -1)
        {
            InitializeComponent();

            setControlsText();

            if (Parent != null)
            {
                Parent.Enabled = false;
                _parent = Parent;
                this.MdiParent = Parent.MdiParent;
            }

            _addressTypes = new Dictionary<int, string>();
            _teleaddressTypes = new Dictionary<int, string>();

            this._currentMode = ModeEnum.Add;

            _newUser = new User();
            _manager = new Manager(Settings.employeeID, Settings.ConnectionString);            

            LoadGroups(ref _manager);
            LoadUserTypes(ref _manager);
            LoadAddressTypes(ref _manager);
            LoadTeleaddressTypes(ref _manager);
            AddressesState(0);
            TeleaddressesState(0);

            deletePermissionButton.Enabled = permissionsDGV.Rows.Count > 0;

            if (GroupId > 0)
            {
                userGroupComboBox.SelectedValue = GroupId;
                userGroupComboboxSelection();
            }

            userPrintButtonsUC1.SetButtonsEnable(false, false, false);
        }

        public UserForm(string userID, Form Parent) : this(Parent)
        {
            this._currentMode = ModeEnum.Edit;

            this.userID = userID;

            _newUser = _manager.GetUserById(Int32.Parse(userID));

            deleteButton.Enabled = true;

            LoadUserData(ref _newUser);

            notReturnedResourcesDGVUC.LoadNotReturned(_newUser.UserID, true);
            returnedResourcesDGVUC1.LoadReturned(_newUser.UserID);
            LoadPermissions(ref _newUser);
            LoadAddresses(ref _newUser);
            LoadTeleaddresses(ref _newUser);

            userPrintButtonsUC1.SetButtonsEnable(notReturnedResourcesDGVUC.notReturnedDGV.Rows.Count > 0, notReturnedResourcesDGVUC.notReturnedDGV.Rows.Count > 0, returnedResourcesDGVUC1.returnedDGV.Rows.Count > 0);
            userPrintButtonsUC1.UserId = _newUser.UserID;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(nameFirstNameLabel, "name_last_name_first_name");
            mapping.Add(departmentLabel, "department");
            mapping.Add(sexLabel, "sex");
            mapping.Add(femaleRadioButton, "female");
            mapping.Add(maleRadioButton, "male");
            mapping.Add(barcodeLabel, "barcode");
            mapping.Add(cardIdLabel, "card_no");
            mapping.Add(usertypeLabel, "user_type");
            mapping.Add(domainNameLabel, "user_domain_name");
            mapping.Add(groupLabel, "group");
            mapping.Add(birthdateLabel, "date_of_birth");
            mapping.Add(CountLimitLabel, "amount_limit");
            mapping.Add(lockedCheckBox, "locked_user");
            mapping.Add(timeLimitLabel, "time_limit");
            mapping.Add(commentsLabel, "comments");

            mapping.Add(notReturnedTabPage, "unreturned");

            mapping.Add(permissionsTabPage, "permissions");
            mapping.Add(namePermissionsDGVC, "name");
            mapping.Add(label13, "valid_from");
            mapping.Add(label14, "valid_to");
            mapping.Add(permissionCheckBox, "locked_permission");
            mapping.Add(deletePermissionButton, "delete_permission");
            mapping.Add(addPermissionButton, "add_permission");

            mapping.Add(addressesTabPage, "addresses");
            mapping.Add(typSlownieAdressesDGVC, "type");
            mapping.Add(placeAdressesDGVC, "place");
            mapping.Add(streetAdressesDGVC, "street");
            mapping.Add(houseNoAdressesDGVC, "house_no");
            mapping.Add(localNoAdressesDGVC, "local_no");
            mapping.Add(label15, "type");
            mapping.Add(label16, "street");
            mapping.Add(label18, "zip");
            mapping.Add(label19, "place");
            mapping.Add(label20, "post_office");
            mapping.Add(activeAddressCheckBox, "active_address");
            mapping.Add(addressCommentsLabel, "comments");
            mapping.Add(addAddressButton, "add");
            mapping.Add(editAddressButton, "edit");
            mapping.Add(deleteAddressButton, "delete");
            mapping.Add(saveAddressButton, "save");
            mapping.Add(cancelAdressButton, "cancel");

            mapping.Add(teleAddressesTabPage, "teleaddresses");
            mapping.Add(TypeTeleAddressesDGVC, "type");
            mapping.Add(valueTeleAddressesDGVC, "value");
            mapping.Add(label22, "type");
            mapping.Add(label23, "value");
            mapping.Add(label24, "comments");
            mapping.Add(activeTeleaddressCheckBox, "active_address");
            mapping.Add(addTeleaddressButton, "add");
            mapping.Add(editTeleaddressButton, "edit");
            mapping.Add(deleteTeleaddressButton, "delete");
            mapping.Add(saveTeleaddressButton, "save");
            mapping.Add(cancelTeleaddressButton, "cancel");

            mapping.Add(historyTabPage, "history");

            mapping.Add(deleteButton, "delete_user");
            mapping.Add(saveButton, "save");
            mapping.Add(exitButton, "exit");

            mapping.Add(this, "user_info");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        #region void LoadUserData(ref User user)
        private void LoadUserData(ref User user)
        {
            // nazwa / nazwisko
            userNameTextBox.Text = user.UserName;

            // dział
            departmentTextBox.Text = user.Department;

            // płeć
            maleRadioButton.Checked = user.IsMale;

            // kod kreskowy
            barcodeTextBox.Text = user.Barcode;

            // typ użytkownika
            userTypeComboBox.SelectedValue = user.UserType ?? -1;

            // grupa użytkownika
            userGroupComboBox.SelectedValue = user.UserGroup ?? -1;

            // nr legitymacji
            cardIdTextBox.Text = user.CardId;

            // nazwa domenowa
            domainNameTextBox.Text = user.DomainName;

            // data urodzenia
            birthDateCheckBox.Checked = user.BirthDate.HasValue;

            if (user.BirthDate.HasValue)
                birthDTP.Value = user.BirthDate.Value >= birthDTP.MinDate && user.BirthDate.Value <= birthDTP.MaxDate ? user.BirthDate.Value : DateTime.Now;

            // limit ilości
            maxBorrowsTextBox.Text = user.MaxBorrows.ToString();

            // limit czasu
            maxTimeTextBox.Text = user.MaxBorrowTime.ToString();

            // uwagi
            CommentsRTB.Text = user.Comments;

            // zablokowany
            lockedCheckBox.Checked = user.IsLocked;
        }
        #endregion

        #region void LoadGroups(ref Manager manager)
        private void LoadGroups(ref Manager manager)
        {
            userGroupComboBox.DisplayMember = "Value";
            userGroupComboBox.ValueMember = "Key";
            userGroupComboBox.DataSource = new BindingSource(manager.GetUserGroupsDictionary(), null);

            userGroupComboBox.SelectedValue = -1;
        }
        #endregion        

        #region void LoadUserTypes()
        private void LoadUserTypes(ref Manager manager)
        {
            userTypeComboBox.DisplayMember = "Value";
            userTypeComboBox.ValueMember = "Key";
            userTypeComboBox.DataSource = new BindingSource(manager.GetUserTypesDictionary(), null);            
        }
        #endregion

        #region void LoadPermissions(ref User user)
        private void LoadPermissions(ref User user)
        {
            if (permissionsDGV.Rows.Count > 0)
                permissionsDGV.Rows.Clear();

            foreach(KeyValuePair<int, Permission> keyValuePair in user.Permissions)
            {
                permissionsDGV.Rows.Add(keyValuePair.Key, keyValuePair.Value.Right.Name);
            }

            deletePermissionButton.Enabled = permissionsDGV.Rows.Count > 0;

            UpdateTabsNames();
        }
        #endregion

        #region void LoadAddresses(ref User user)
        private void LoadAddresses(ref User user)
        {
            if (addressesDGV.Rows.Count > 0)
                addressesDGV.Rows.Clear();

            foreach (KeyValuePair<int, Address> keyValuePair in user.Addresses)
            {
                string address_string = "";

                if (_addressTypes.ContainsKey(keyValuePair.Value.AddressType))
                    address_string = _addressTypes[keyValuePair.Value.AddressType];

                addressesDGV.Rows.Add(keyValuePair.Key, keyValuePair.Value.AddressId, keyValuePair.Value.AddressType, keyValuePair.Value.IsActive, keyValuePair.Value.Zip, keyValuePair.Value.Comments, keyValuePair.Value.PostOffice, address_string, keyValuePair.Value.Place, keyValuePair.Value.Street, keyValuePair.Value.HouseNo, keyValuePair.Value.LocalNo);
            }

            AddressesState(0);
            UpdateTabsNames();
        }
        #endregion

        #region void UpdateTabsNames()
        public void UpdateTabsNames(bool run = false)
        {
            teleAddressesTabPage.Text = string.Format("{0} {1}", _translationsDictionary.getStringFromDictionary("teleaddresses", "Teleadresy"), teleaddressesDGV.Rows.Count);
            
            if (run)
                returnedResourcesDGVUC1.LoadReturned(_newUser.UserID);

            historyTabPage.Text = _translationsDictionary.getStringFromDictionary("history", "Historia") + " (" + returnedResourcesDGVUC1.returnedDGV.Rows.Count +")";
            permissionsTabPage.Text = _translationsDictionary.getStringFromDictionary("permissions", "Uprawnienia") + " (" +  permissionsDGV.Rows.Count +")";
            notReturnedTabPage.Text = _translationsDictionary.getStringFromDictionary("unreturned", "Niezwrócone zasoby") + " (" +  notReturnedResourcesDGVUC.notReturnedDGV.Rows.Count +")";
            teleAddressesTabPage.Text = _translationsDictionary.getStringFromDictionary("teleaddresses", "Teledresy") + " (" + teleaddressesDGV.Rows.Count + ")";
            addressesTabPage.Text = _translationsDictionary.getStringFromDictionary("addresses", "Adresy") + " (" +  addressesDGV.Rows.Count +")";


        }
        #endregion

        #region void LoadTeleaddresses(ref User user)
        private void LoadTeleaddresses(ref User user)
        {
            if (teleaddressesDGV.Rows.Count > 0)
                teleaddressesDGV.Rows.Clear();

            foreach (KeyValuePair<int, Teleaddress> keyValuePair in user.Teleaddresses)
            {
                string address_string = "";

                if (_teleaddressTypes.ContainsKey(keyValuePair.Value.TeleaddressType))
                    address_string = _teleaddressTypes[keyValuePair.Value.TeleaddressType];

                teleaddressesDGV.Rows.Add(keyValuePair.Key, keyValuePair.Value.TeleaddressId, address_string, keyValuePair.Value.Value);
            }

            TeleaddressesState(0);

            UpdateTabsNames();
        }
        #endregion

        #region void LoadTeleaddressTypes()
        private void LoadTeleaddressTypes(ref Manager manager)
        {
            _teleaddressTypes = manager.GetTeleaddressTypesDictionary();

            teleaddressTypeComboBox.DisplayMember = "Value";
            teleaddressTypeComboBox.ValueMember = "Key";
            teleaddressTypeComboBox.DataSource = new BindingSource(_teleaddressTypes, null);
                
            teleaddressTypeComboBox.SelectedIndex = 0;
        }
        #endregion

        #region void LoadAddressTypes()
        private void LoadAddressTypes(ref Manager manager)
        {
            _addressTypes = manager.GetAddressesTypesDictionary();

            addressTypeComboBox.DisplayMember = "Value";
            addressTypeComboBox.ValueMember = "Key";
            addressTypeComboBox.DataSource = new BindingSource(_addressTypes, null);

            addressTypeComboBox.SelectedIndex = 0;            
        }
        #endregion

        #region void maxBorrowsTextBox_TextChanged(object sender, EventArgs e)
        private void maxBorrowsTextBox_TextChanged(object sender, EventArgs e)
        {            
            maxBorrowsTextBox.Text = string.Join("", maxBorrowsTextBox.Text.Where(x => char.IsDigit(x)).ToArray());
            maxBorrowsTextBox.SelectionStart = maxBorrowsTextBox.TextLength;
        }
        #endregion

        #region void maxTimeTextBox_TextChanged(object sender, EventArgs e)
        private void maxTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            maxTimeTextBox.Text = string.Join("", maxTimeTextBox.Text.Where(x => char.IsDigit(x)));
            maxTimeTextBox.SelectionStart = maxTimeTextBox.TextLength;
        }
        #endregion

        #region void selectDomainNameButton_Click(object sender, EventArgs e)
        private void selectDomainNameButton_Click(object sender, EventArgs e)
        {
            if (IsComputerInDomain())
                Run();                        
        }
        #endregion

        #region bool IsComputerInDomain()
        private bool IsComputerInDomain()
        {
            try
            {
                System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain();
                return true;
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _translationsDictionary.getStringFromDictionary("error", "Błąd"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;                
            }
        }
        #endregion

        #region private void Run()
        private void Run()
        {
            string domain = "";

            try
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC w2_wartosc_konfiguracyjna 'nazwa_domeny'; ";

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    domain = Dt.Rows[0][0].ToString();
                }
                else
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("domain_name_in_configuration_is_blank", "Brak wpisanej nazwy domeny w konfiguracji."), _translationsDictionary.getStringFromDictionary("no_data", "Brak danych"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Dictionary<string, string> usersDictionary = new Dictionary<string, string>();

                using (var root = new DirectoryEntry("LDAP://" + domain))
                {
                    using (var searcher = new DirectorySearcher(root) {Filter = "(&(objectClass=user)(objectCategory=person)(!(userAccountControl:1.2.840.113556.1.4.803:=2)))", SearchScope = SearchScope.Subtree})
                    {
                        searcher.Sort.PropertyName = "sn";
                        searcher.Sort.Direction = SortDirection.Ascending;

                        searcher.PropertiesToLoad.AddRange(new[] {"sn", "givenname", "samAccountName"});

                        using (SearchResultCollection searchResult = searcher.FindAll())
                        {
                            foreach (SearchResult user in searchResult)
                            {
                                var displayName = user.Properties["sn"].Count > 0 ? user.Properties["sn"][0].ToString() + " " : "";
                                displayName += user.Properties["givenname"].Count > 0 ? user.Properties["givenname"][0].ToString() : "";

                                var samAccountName = user.Properties["samAccountName"].Count > 0 ? user.Properties["samAccountName"][0].ToString() : "";

                                usersDictionary.Add(domain + "\\" + samAccountName, displayName);
                            }
                        }
                    }
                }

                usersDictionary = usersDictionary.OrderBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);

                DataGridViewColumn[] Columns = new DataGridViewColumn[2];
                Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
                Columns[0].Name = "value";
                Columns[0].HeaderText = _translationsDictionary.getStringFromDictionary("last_name_and_first_name", "Nazwisko i imię");
                Columns[0].Visible = true;
                Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
                Columns[1].Name = "key";
                Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("name", "Nazwa");
                Columns[1].Visible = true;
                Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                ShowForm SF = new ShowForm(usersDictionary, Columns, "value");

                if (SF.ShowDialog() == DialogResult.OK)
                    domainNameTextBox.Text = SF.Dt.Cells["key"].Value.ToString();
            }
            catch (Exception Ex)
            {
                string cMsg = "";
                cMsg = Ex.Message;
                if (cMsg == "Serwer nie działa") cMsg = _T("server_not_working");
                MessageBox.Show(_T("server_not_working") + "\n" + _T("user_domain_name") + ": " + domain, _translationsDictionary.getStringFromDictionary("error", "Błąd"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region bool CheckForSave()
        private bool CheckForSave()
        {
            if (string.IsNullOrEmpty(userNameTextBox.Text.Trim()))
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("enter_user_name", "Proszę wprowadzić nazwę użytkownika!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Uzupełnienie danych"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            if (!string.IsNullOrWhiteSpace(domainNameTextBox.Text))
            {
                DataTable Dt = _manager.GetUserNameWithDomainName(domainNameTextBox.Text);

                if (Dt.Rows.Count > 0 && (int)Dt.Rows[0]["uzytk_id"] != _newUser.UserID)
                {
//                    MessageBox.Show(string.Format("Wprowadzona nazwa domenowa została już wprowadzona użytkownikowi {0}. Nazwa domenowa nie może się powtarzać.", Dt.Rows[0]["uzytkownik"]), _translationsDictionary.getStringFromDictionary("to_correct_data", "Uzupełnienie danych"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show(NamedFormat.Format(_translationsDictionary.getStringFromDictionary("invalid_user_domain_name", "Wprowadzona nazwa domenowa została już wprowadzona użytkownikowi {user}. Nazwa domenowa nie może się powtarzać."), Dt.Rows[0]["uzytkownik"]), _translationsDictionary.getStringFromDictionary("to_correct_data", "Uzupełnienie danych"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region void Save()
        private void Save()
        {
            if (_currentMode == ModeEnum.Edit)
                _manager.Users[_newUser.HashCode] = _newUser;
            else
                _manager.Users.Add(_newUser);

            if (_manager.Save())
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("saved", "Zapisano!"), "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.Yes;
                this.Close();
            }
        }
        #endregion

        #region void saveButton_Click(object sender, EventArgs e)
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!CheckForSave())
                return;

            // typ użytkownika
            _newUser.UserType = (int?)userTypeComboBox.SelectedValue;
            
            // grupa użytkownika
            _newUser.UserGroup = (int?)userGroupComboBox.SelectedValue != -1 ? (int?)userGroupComboBox.SelectedValue : null;

            // kod kreskowy
            _newUser.Barcode = barcodeTextBox.Text.Trim();       

            // nazwa
            _newUser.UserName = userNameTextBox.Text.Trim();

            // data urodzenia
            if(birthDateCheckBox.Checked)
                _newUser.BirthDate = birthDTP.Value;
            else
                _newUser.BirthDate = null;

            // płeć            
            _newUser.IsMale = maleRadioButton.Checked;

            // uwagi
            _newUser.Comments = CommentsRTB.Text.Trim();

            // limit czasu
            int MaxBorrowTime;
            Int32.TryParse(maxTimeTextBox.Text.Trim(), out MaxBorrowTime);            
            _newUser.MaxBorrowTime = MaxBorrowTime;

            // limit ilości
            int tempMaxBorrows;
            Int32.TryParse(maxBorrowsTextBox.Text.Trim(), out tempMaxBorrows);                          
            _newUser.MaxBorrows = tempMaxBorrows;

            // zablokowany
            _newUser.IsLocked = lockedCheckBox.Checked;

            // numer legitymacji
            _newUser.CardId = cardIdTextBox.Text.Trim();

            // domena_nazwa
            _newUser.DomainName = domainNameTextBox.Text.Trim();

            // dział
            _newUser.Department = departmentTextBox.Text.Trim();
            
            Save();
        }
        #endregion

        #region void birthDateCheckBox_CheckedChanged(object sender, EventArgs e)
        private void birthDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            birthDTP.Enabled = birthDateCheckBox.Checked;
        }
        #endregion

        #region void userGroupComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        private void userGroupComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            userGroupComboboxSelection();
        }
        #endregion

        private void userGroupComboboxSelection()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC w2_lista_grup 0, @grupa_id; ";
            Command.Parameters.AddWithValue("@grupa_id", userGroupComboBox.SelectedValue);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            int[] table = _newUser.Permissions.Values.Select(x => x.HashCode).ToArray();

            foreach (int key in table)
            {
                _newUser.Permissions.Remove(key);
            }            

            if (Dt.Rows.Count > 0)
            {
                maxBorrowsTextBox.Text = Dt.Rows[0]["limit_ilosci"].ToString();
                maxTimeTextBox.Text = Dt.Rows[0]["limit_czasu"].ToString();

                UserGroup uGroup = _manager.GetUserGroupById((int)userGroupComboBox.SelectedValue);

                foreach (var right in uGroup.Rights)
                    _newUser.Permissions.Add(new UserPermission(right.Value, DateTime.Now, DateTime.Now.AddYears(25), !right.Value.IsActive, _newUser.UserID));                
            }
            else
            {
                maxBorrowsTextBox.Text = maxTimeTextBox.Text = "";
            }

            LoadPermissions(ref _newUser);
        }

        #region void lockedCheckBox_CheckedChanged(object sender, EventArgs e)
        private void lockedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            lockedPictureBox.Visible = lockedCheckBox.Checked;
        }
        #endregion

        #region void exitButton_Click(object sender, EventArgs e)
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region void UserForm_KeyDown(object sender, KeyEventArgs e)
        private void UserForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }
        #endregion

        #region void permissionsDGV_SelectionChanged(object sender, EventArgs e)
        private void permissionsDGV_SelectionChanged(object sender, EventArgs e)
        {
            if (permissionsDGV.SelectedRows.Count > 0)
            {
                startDatePermissionDTP.Value = _newUser.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].StartDate;
                endDatePermissionDTP.Value = _newUser.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].EndDate;
                permissionCheckBox.Checked = _newUser.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].IsLocked;
            }

            deletePermissionButton.Enabled = permissionsDGV.SelectedRows.Count > 0;
        }
        #endregion

        #region void deletePermissionButton_Click(object sender, EventArgs e)
        private void deletePermissionButton_Click(object sender, EventArgs e)
        {
            if (permissionsDGV.SelectedRows.Count > 0)
            {
                if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_this_permission_from_user", "Czy chcesz usunąć to uprawnienie z listy uprawnień użytkownika?"), _translationsDictionary.getStringFromDictionary("permission_deleting", "Usuwanie uprawnienia"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _newUser.Permissions.Remove((int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value);
                    permissionsDGV.Rows.RemoveAt(permissionsDGV.SelectedRows[0].Index);
                    
                    UpdateTabsNames();
                }
            }
        }
        #endregion

        #region void addPermissionButton_Click(object sender, EventArgs e)
        private void addPermissionButton_Click(object sender, EventArgs e)
        {
            List<string> permissions = new List<string>();

            for (int i = 0; i < permissionsDGV.Rows.Count; i++)
            {                
                permissions.Add(_newUser.Permissions[(int)permissionsDGV.Rows[i].Cells[syncIdPermissionsDGVC.Name].Value].Right.RightId.ToString());                
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
                bool isActive = ConvertToBool(SF.Dt.Cells["stan"].Value.ToString());

                UserPermission permission = new UserPermission(new Right((int)SF.Dt.Cells["id"].Value, SF.Dt.Cells["name"].Value.ToString(), isActive), DateTime.Now, DateTime.Now.AddYears(25), !isActive, _newUser.UserID);

                endDatePermissionDTP.Value = DateTime.Now.AddYears(25);
                _newUser.Permissions.Add(permission);
                int idx = permissionsDGV.Rows.Add(permission.GetHashCode(), permission.Right.Name);

                permissionsDGV.ClearSelection();
                permissionsDGV.Rows[idx].Selected = true;
                permissionsDGV.FirstDisplayedScrollingRowIndex = idx;
                permissionsDGV.CurrentCell = permissionsDGV.Rows[idx].Cells[namePermissionsDGVC.Name];

                permissionCheckBox.Checked = !isActive;
                deletePermissionButton.Enabled = permissionsDGV.SelectedRows.Count > 0;

                UpdateTabsNames();
            }
        }
        #endregion

        #region bool ConvertToBool(string value)
        private bool ConvertToBool(string value)
        {
            return value.Trim().ToLower() == bool.TrueString.ToLower() || value.Trim() == "1";
        }
        #endregion

        #region void startDatePermissionDTP_ValueChanged(object sender, EventArgs e)
        private void startDatePermissionDTP_ValueChanged(object sender, EventArgs e)
        {
            //endDatePermissionDTP.MinDate = startDatePermissionDTP.Value;
            if (permissionsDGV.SelectedRows.Count > 0)
            {
                _newUser.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].StartDate = startDatePermissionDTP.Value;
            }
        }
        #endregion

        #region void endDatePermissionDTP_ValueChanged(object sender, EventArgs e)
        private void endDatePermissionDTP_ValueChanged(object sender, EventArgs e)
        {
            if (permissionsDGV.SelectedRows.Count > 0)
            {
                if(startDatePermissionDTP.Value > endDatePermissionDTP.Value)
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("end_date_cannot_be_earlier_than_start_date", "Data \"Obowiązuje do\" nie może być wcześniejsza niż \"Obowiązuje od\"!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Złe dane"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    endDatePermissionDTP.Value = DateTime.Now;
                    endDatePermissionDTP.Focus();
                    return;
                }

                _newUser.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].EndDate = endDatePermissionDTP.Value;
            }
        }
        #endregion

        #region void authCheckBox_Click(object sender, EventArgs e)
        private void authCheckBox_Click(object sender, EventArgs e)
        {
            if (permissionsDGV.SelectedRows.Count > 0)
            {
                _newUser.Permissions[(int)permissionsDGV.SelectedRows[0].Cells["syncIdPermissionsDGVC"].Value].IsLocked = permissionCheckBox.Checked;
            }
        }
        #endregion

        #region addressesDGV_SelectionChanged(object sender, EventArgs e)
        private void addressesDGV_SelectionChanged(object sender, EventArgs e)
        {
            LoadAddressIntoControls();
        }
        #endregion

        #region void LoadAddressIntoControls()
        private void LoadAddressIntoControls()
        {
            if (addressesDGV.SelectedRows.Count > 0)
            {
                UserAddress address = _newUser.Addresses[(int)addressesDGV.SelectedRows[0].Cells[syncIDDGVC.Name].Value] as UserAddress;

                addressTypeComboBox.SelectedValue = address.AddressType;
                streetAddressTextBox.Text = address.Street;
                houseNoAddressTextBox.Text = address.HouseNo;
                localNoAddressTextBox.Text = address.LocalNo;
                zipMaskedTextBox.Text = address.Zip;
                placeAddressTextBox.Text = address.Place;
                postofficeTextBox.Text = address.PostOffice;
                activeAddressCheckBox.Checked = address.IsActive;
                commentsAddressRTB.Text = address.Comments;
            }

            editAddressButton.Enabled = addressesDGV.SelectedRows.Count > 0;
            deleteAddressButton.Enabled = addressesDGV.SelectedRows.Count > 0;
        }
        #endregion

        #region AddressesState(int mode)
        private void AddressesState(int mode)
        {
            // 0 - brak
            // 1 - nowy
            // 2 - edycja

            _currentAddressMode = mode;
            
            bool locked = mode != 0;

            if (mode == 1)
            {
                streetAddressTextBox.Text = "";
                houseNoAddressTextBox.Text = "";
                houseNoAddressTextBox.Text = "";
                localNoAddressTextBox.Text = "";
                zipMaskedTextBox.Text = "";
                placeAddressTextBox.Text = "";
                postofficeTextBox.Text = "";
                activeAddressCheckBox.Checked = true;
                commentsAddressRTB.Text = "";

                if (addressTypeComboBox.Items.Count > 0)
                    addressTypeComboBox.SelectedIndex = 0;
            }

            addressesDGV.Enabled = !locked;

            addressTypeComboBox.Enabled = locked;
            streetAddressTextBox.ReadOnly = !locked;
            houseNoAddressTextBox.ReadOnly = !locked;
            houseNoAddressTextBox.ReadOnly = !locked;
            localNoAddressTextBox.ReadOnly = !locked;
            zipMaskedTextBox.ReadOnly = !locked;
            placeAddressTextBox.ReadOnly = !locked;
            postofficeTextBox.ReadOnly = !locked;
            activeAddressCheckBox.Enabled = locked;

            commentsAddressRTB.ReadOnly = !locked;
            commentsAddressRTB.BackColor = locked ? Color.White : Color.FromKnownColor(KnownColor.Control);

            addAddressButton.Enabled = !locked;
            editAddressButton.Enabled = !locked && addressesDGV.Rows.Count > 0;
            deleteAddressButton.Enabled = !locked && addressesDGV.Rows.Count > 0;

            saveAddressButton.Enabled = locked;
            cancelAdressButton.Enabled = locked;            
        }
        #endregion

        #region TeleaddressesState(int mode)
        private void TeleaddressesState(int mode)
        {
            // 0 - brak
            // 1 - nowy
            // 2 - edycja

            _currentTeleaddressMode = mode;

            bool locked = mode != 0;

            if (mode == 1)
            {
                valueTeleaddressTextBox.Text = "";
                activeTeleaddressCheckBox.Checked = true;
                commentsTeleaddressRTB.Text = "";

                if (teleaddressTypeComboBox.Items.Count > 0)
                    teleaddressTypeComboBox.SelectedIndex = 0;
            }

            teleaddressesDGV.Enabled = !locked;

            teleaddressTypeComboBox.Enabled = locked;
            valueTeleaddressTextBox.ReadOnly = !locked;
            commentsTeleaddressRTB.ReadOnly = !locked;
            activeTeleaddressCheckBox.Enabled = locked;

            commentsTeleaddressRTB.ReadOnly = !locked;
            commentsTeleaddressRTB.BackColor = locked ? Color.White : Color.FromKnownColor(KnownColor.Control);

            addTeleaddressButton.Enabled = !locked;
            editTeleaddressButton.Enabled = !locked && teleaddressesDGV.Rows.Count > 0;
            deleteTeleaddressButton.Enabled = !locked && teleaddressesDGV.Rows.Count > 0;

            saveTeleaddressButton.Enabled = locked;
            cancelTeleaddressButton.Enabled = locked;
        }
        #endregion

        #region addAddressButton_Click(object sender, EventArgs e)
        private void addAddressButton_Click(object sender, EventArgs e)
        {
            AddressesState(1);
        }
        #endregion

        #region editAddressButton_Click(object sender, EventArgs e)
        private void editAddressButton_Click(object sender, EventArgs e)
        {
            AddressesState(2);
        }
        #endregion

        #region deleteAddressButton_Click(object sender, EventArgs e)
        private void deleteAddressButton_Click(object sender, EventArgs e)
        {
            if (addressesDGV.SelectedRows.Count > 0 && MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_address", "Czy chcesz usunąć ten adres?"), _translationsDictionary.getStringFromDictionary("address_deleting", "Usuwanie adresu"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                _newUser.Addresses.Remove((int)addressesDGV.SelectedRows[0].Cells[syncIDDGVC.Name].Value);                
                addressesDGV.Rows.RemoveAt(addressesDGV.SelectedRows[0].Index);

                UpdateTabsNames();
            }
        }
        #endregion

        #region saveAddressButton_Click(object sender, EventArgs e)
        private void saveAddressButton_Click(object sender, EventArgs e)
        {
            if (!CheckIsAddressEmpty())
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("address_cannot_be_blank", "Adres nie może być pusty."), _translationsDictionary.getStringFromDictionary("address_adding", "Dodawanie adresu"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            if (_currentAddressMode == 1)
            {
                int addressType = Convert.ToInt32(addressTypeComboBox.SelectedValue);
                string address_string = "";

                if (_addressTypes.ContainsKey(addressType))
                    address_string = _addressTypes[addressType];

                UserAddress address = new UserAddress(addressType, placeAddressTextBox.Text.Trim(), streetAddressTextBox.Text.Trim(), houseNoAddressTextBox.Text.Trim(), localNoAddressTextBox.Text.Trim(), zipMaskedTextBox.Text.Trim().Replace("-", ""), postofficeTextBox.Text.Trim(), activeAddressCheckBox.Checked,  commentsAddressRTB.Text.Trim(), _newUser.UserID);
                int collectionId = _newUser.Addresses.Add(address);

                int idx = addressesDGV.Rows.Add(collectionId, address.AddressId, address.AddressType, address.IsActive, address.Zip, address.Comments, address.PostOffice, address_string, address.Place, address.Street, address.HouseNo, address.LocalNo);

                addressesDGV.ClearSelection();
                addressesDGV.Rows[idx].Selected = true;
                addressesDGV.FirstDisplayedScrollingRowIndex = idx;
                addressesDGV.CurrentCell = addressesDGV.Rows[idx].Cells[typSlownieAdressesDGVC.Name];
            }
            else
            {
                int idx = addressesDGV.SelectedRows[0].Index;
                
                UserAddress address = _newUser.Addresses[(int)addressesDGV.Rows[idx].Cells[syncIDDGVC.Name].Value] as UserAddress;

                int addressType = Convert.ToInt32(addressTypeComboBox.SelectedValue);

                address.AddressType = addressType;
                address.Street = streetAddressTextBox.Text.Trim();
                address.HouseNo = houseNoAddressTextBox.Text.Trim();
                address.LocalNo = localNoAddressTextBox.Text.Trim();
                address.Zip = zipMaskedTextBox.Text.Trim().Replace("-", "");
                address.Place = placeAddressTextBox.Text.Trim();
                address.PostOffice = postofficeTextBox.Text.Trim();
                address.IsActive = activeAddressCheckBox.Checked;
                address.Comments = commentsAddressRTB.Text.Trim();

                addressesDGV.Rows[idx].Cells[typadrIDAdressesDGVC.Name].Value = address.AddressType;
                addressesDGV.Rows[idx].Cells[typSlownieAdressesDGVC.Name].Value = addressTypeComboBox.Text;
                addressesDGV.Rows[idx].Cells[streetAdressesDGVC.Name].Value = address.Street;
                addressesDGV.Rows[idx].Cells[houseNoAdressesDGVC.Name].Value = address.HouseNo;
                addressesDGV.Rows[idx].Cells[localNoAdressesDGVC.Name].Value = address.LocalNo;
                addressesDGV.Rows[idx].Cells[zipAdressesDGVC.Name].Value = address.Zip;
                addressesDGV.Rows[idx].Cells[placeAdressesDGVC.Name].Value = address.Place;
                addressesDGV.Rows[idx].Cells[postofficeAddressDGVC.Name].Value = address.PostOffice;
                addressesDGV.Rows[idx].Cells[addressStateAdressesDGVC.Name].Value = address.IsActive;
                addressesDGV.Rows[idx].Cells[commentsAdressesDGVC.Name].Value = address.Comments;             
            }

            AddressesState(0);
            UpdateTabsNames();
        }
        #endregion

        private bool CheckIsAddressEmpty()
        {
            return !(string.IsNullOrWhiteSpace(streetAddressTextBox.Text))
                || !(string.IsNullOrWhiteSpace(houseNoAddressTextBox.Text))
                || !(string.IsNullOrWhiteSpace(localNoAddressTextBox.Text))
                || !(string.IsNullOrWhiteSpace(placeAddressTextBox.Text))
                || !(string.IsNullOrWhiteSpace(zipMaskedTextBox.Text.Replace("-","")))
                || !(string.IsNullOrWhiteSpace(postofficeTextBox.Text))
                || !(string.IsNullOrWhiteSpace(commentsAddressRTB.Text.Trim()));
        }

        private bool CheckIsTeleAddressEmpty()
        {
            return !(string.IsNullOrWhiteSpace(valueTeleaddressTextBox.Text))
                || !(string.IsNullOrWhiteSpace(commentsTeleaddressRTB.Text));
        }

        #region cancelAdressButton_Click(object sender, EventArgs e)
        private void cancelAdressButton_Click(object sender, EventArgs e)
        {
            AddressesState(0);
            LoadAddressIntoControls();
        }
        #endregion        

        #region private void deleteButton_Click(object sender, EventArgs e)
        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_user", "Czy na pewno usunąć użytkownika?"), _translationsDictionary.getStringFromDictionary("user_deleting", "Usuwanie użytkownika"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != System.Windows.Forms.DialogResult.Yes)
                    return;

                int userBorrowsCount = _manager.GetUserBorrowsCount(_newUser.UserID);

                if (userBorrowsCount > 0)
                {

                    string c1 = _T("user_has_borrowed_resources");
                    string c2 = c1.Replace(@"\n", "\n");

                    //MessageBox.Show(, "Operacja przerwana", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    MessageBox.Show(string.Format(c2, userBorrowsCount), _T("user_deleting"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                _manager.Users.Remove(_newUser.HashCode);

                if (_manager.Save())
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("user_has_been_deleted", "Użytkownik został usunięty."), _translationsDictionary.getStringFromDictionary("", "Operacja zakończona"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = System.Windows.Forms.DialogResult.No;
                    this.Close();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _translationsDictionary.getStringFromDictionary("error", "Błąd"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region void addTeleaddressButton_Click(object sender, EventArgs e)
        private void addTeleaddressButton_Click(object sender, EventArgs e)
        {
            TeleaddressesState(1);
        }
        #endregion

        #region void editTeleaddressButton_Click(object sender, EventArgs e)
        private void editTeleaddressButton_Click(object sender, EventArgs e)
        {
            TeleaddressesState(2);
        }
        #endregion

        #region deleteTeleaddressButton_Click(object sender, EventArgs e)
        private void deleteTeleaddressButton_Click(object sender, EventArgs e)
        {
            if (teleaddressesDGV.SelectedRows.Count > 0 && MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_this_teleaddress", "Czy chcesz usunąć ten teleadres?"), _translationsDictionary.getStringFromDictionary("teleaddress_deleting", "Usuwanie teleadresu"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _newUser.Teleaddresses.Remove((int)teleaddressesDGV.SelectedRows[0].Cells[syncIDteleAddressesDGVC.Name].Value);
                teleaddressesDGV.Rows.RemoveAt(teleaddressesDGV.SelectedRows[0].Index);

                UpdateTabsNames();
            }            
        }
        #endregion

        #region void saveTeleaddressButton_Click(object sender, EventArgs e)
        private void saveTeleaddressButton_Click(object sender, EventArgs e)
        {
            if (!CheckIsTeleAddressEmpty())
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("teleaddress_cannot_be_blank", "Teleadres nie może być pusty."), _translationsDictionary.getStringFromDictionary("teleaddress_adding", "Dodawanie teleadresu"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int teleaddressType = Convert.ToInt32(teleaddressTypeComboBox.SelectedValue);

            string teleaddress_string = "";

            if (_teleaddressTypes.ContainsKey(teleaddressType))
                teleaddress_string = _teleaddressTypes[teleaddressType];

            if (_currentTeleaddressMode == 1)
            {
                UserTeleaddress teleaddress = new UserTeleaddress(teleaddressType, valueTeleaddressTextBox.Text.Trim(), activeTeleaddressCheckBox.Checked, commentsTeleaddressRTB.Text.Trim(), _newUser.UserID);
                int collectionId = _newUser.Teleaddresses.Add(teleaddress);

                int idx = teleaddressesDGV.Rows.Add(collectionId, teleaddress.TeleaddressId, teleaddress_string, teleaddress.Value);

                teleaddressesDGV.ClearSelection();
                teleaddressesDGV.Rows[idx].Selected = true;
                teleaddressesDGV.FirstDisplayedScrollingRowIndex = idx;
                teleaddressesDGV.CurrentCell = teleaddressesDGV.Rows[idx].Cells[valueTeleAddressesDGVC.Name];
            }
            else
            {
                int idx = teleaddressesDGV.SelectedRows[0].Index;

                UserTeleaddress teleaddress = _newUser.Teleaddresses[(int)teleaddressesDGV.Rows[idx].Cells[syncIDteleAddressesDGVC.Name].Value] as UserTeleaddress;                
                
                teleaddress.TeleaddressType = teleaddressType;
                teleaddress.Value = valueTeleaddressTextBox.Text.Trim();
                teleaddress.IsActive = activeTeleaddressCheckBox.Checked;
                teleaddress.Comments = commentsTeleaddressRTB.Text.Trim();

                teleaddressesDGV.Rows[idx].Cells[TypeTeleAddressesDGVC.Name].Value = teleaddress_string;
                teleaddressesDGV.Rows[idx].Cells[valueTeleAddressesDGVC.Name].Value = teleaddress.Value;
            }

            TeleaddressesState(0);
            UpdateTabsNames();
        }
        #endregion

        #region void cancelTeleaddressButton_Click(object sender, EventArgs e)
        private void cancelTeleaddressButton_Click(object sender, EventArgs e)
        {
            TeleaddressesState(0);
            LoadTeleaddressIntoControls();
        }
        #endregion

        #region void teleaddressesDGV_SelectionChanged(object sender, EventArgs e)
        private void teleaddressesDGV_SelectionChanged(object sender, EventArgs e)
        {
            LoadTeleaddressIntoControls();
        }
        #endregion

        #region void LoadTeleaddressIntoControls()
        private void LoadTeleaddressIntoControls()
        {
            if (teleaddressesDGV.SelectedRows.Count > 0)
            {
                teleaddressTypeComboBox.SelectedValue = _newUser.Teleaddresses[(int)teleaddressesDGV.SelectedRows[0].Cells[syncIDteleAddressesDGVC.Name].Value].TeleaddressType;
                valueTeleaddressTextBox.Text = _newUser.Teleaddresses[(int)teleaddressesDGV.SelectedRows[0].Cells[syncIDteleAddressesDGVC.Name].Value].Value;
                commentsTeleaddressRTB.Text = _newUser.Teleaddresses[(int)teleaddressesDGV.SelectedRows[0].Cells[syncIDteleAddressesDGVC.Name].Value].Comments;
                activeTeleaddressCheckBox.Checked = _newUser.Teleaddresses[(int)teleaddressesDGV.SelectedRows[0].Cells[syncIDteleAddressesDGVC.Name].Value].IsActive;
            }

            editTeleaddressButton.Enabled = teleaddressesDGV.SelectedRows.Count > 0;
            deleteTeleaddressButton.Enabled = teleaddressesDGV.SelectedRows.Count > 0;
        }
        #endregion        

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_parent != null)
            {
                _parent.Enabled = true;
                _parent.Focus();
            }
        }

        private void UserForm_Load(object sender, EventArgs e)
        {

        }
    }
}
