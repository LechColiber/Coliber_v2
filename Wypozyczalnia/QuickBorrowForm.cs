using System.Threading;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Wypozyczalnia
{
    public partial class QuickBorrowForm : Form
    {
        private Manager _manager;
        private User _user;
        private Resource _resource;
        private int _timeDiff;
        private Dictionary<string, string> _translationsDictionary;

        public QuickBorrowForm(int EmployeeId)
        {
            InitializeComponent();
            setControlsText();

            Settings.SetSettings();

            Settings.employeeID = EmployeeId;

            _manager = new Manager(EmployeeId, Settings.ConnectionString);

            Set();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(userBarcodeLabel, "user_barcode");
            mapping.Add(borrowButton, "do_borrow");

            mapping.Add(this, "quick_borrow");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void Set()
        {
            switch (_manager.WypozyczalniaConfiguration.AutoSearchField)
            {
                case Configuration.SearchFieldMode.Barcode: resourceCritLabel.Text = _translationsDictionary.getStringFromDictionary("barcode", "Kod kreskowy"); break;
                case Configuration.SearchFieldMode.InvertoryNo: resourceCritLabel.Text = _translationsDictionary.getStringFromDictionary("inventory_number", "Numer inwentarzowy"); break;
                case Configuration.SearchFieldMode.Signature: resourceCritLabel.Text = _translationsDictionary.getStringFromDictionary("signature", "Sygnatura"); break;
            }

            ToolTip userDetailsToolTip = new ToolTip();
            //userDetailsToolTip.SetToolTip(userCardButton, "Otwórz kartę użytkownika");
            //userDetailsToolTip.SetToolTip(chooseResourceButton, "Wyszukaj zasób");
        }

        private void QuickBorrowForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void resourceBarcodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(resourceCritTextBox.Text))
            {
                GetResourceData(SearchResource(resourceCritTextBox.Text, _manager.WypozyczalniaConfiguration.AutoSearchField));
                resourceCritTextBox.Text = "";

                if (_resource.ResourceId == -1)
                {
                    string tekst = "";

                    if (_manager.WypozyczalniaConfiguration.AutoSearchField == Configuration.SearchFieldMode.Barcode)
                        tekst = _translationsDictionary.getStringFromDictionary("there_is_no_resource_with_given_barcode", "Brak zasobu o podanym kodzie kreskowym!");
                    else if (_manager.WypozyczalniaConfiguration.AutoSearchField == Configuration.SearchFieldMode.InvertoryNo)
                        tekst = _translationsDictionary.getStringFromDictionary("there_is_no_resource_with_given_invertory_number", "Brak zasobu o podanym numerze inwentarzowym!");
                    else if (_manager.WypozyczalniaConfiguration.AutoSearchField == Configuration.SearchFieldMode.Signature)
                        tekst = _translationsDictionary.getStringFromDictionary("there_is_no_resource_with_given_signature", "Brak zasobu o podanej sygnaturze!");

                    MessageBox.Show(tekst, _translationsDictionary.getStringFromDictionary("there_is_no_resource", "Brak zasobu"), MessageBoxButtons.OK, MessageBoxIcon.Information);                    
                }
            }
        }

        private int SearchResource(string value, Configuration.SearchFieldMode mode)
        {
            switch (mode)
            {
                case Configuration.SearchFieldMode.Barcode: return _manager.GetResourceIdByBarcode(value);
                case Configuration.SearchFieldMode.InvertoryNo: return _manager.GetResourceIdByNoInv(value);
                case Configuration.SearchFieldMode.Signature: return _manager.GetResourceIdBySignature(value);

                default: return -1;
            }
        }

        private void GetResourceData(int id)
        {
            _resource = _manager.GetResourceById(id, true);
            resourceRTB.Text = _resource.Title;

            SetButtons();
        }

        private void selectResourceButton_Click(object sender, EventArgs e)
        {
            ChooseResourceForm crf = new ChooseResourceForm(_manager.EmployeeId, ChooseResourceForm.WorkMode.SelectResource, null);

            if (crf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GetResourceData(crf.CurrentResourceId);
            }
        }

        private void borrowButton_Click(object sender, EventArgs e)
        {
            DoBorrow();

            GetUserData(-1);
            GetResourceData(-1);
        }

        private void DoBorrow()
        {
            if (_user.MaxBorrows <= _manager.GetUserBorrowsCount(_user.UserID))
            {
                if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("user_exceed_limit_of_amount", "Użytkownik przekroczył limit ilości wypożyczonych zasobów. Czy wypożyczyć mimo to?"), _translationsDictionary.getStringFromDictionary("exceeded_amount_limit", "Przekroczony limit ilości"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("resource_has_not_been_borrowed", "Zasób NIE został wypożyczony!"), _translationsDictionary.getStringFromDictionary("information", "Informacja"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (_manager.GetResourceById(_resource.ResourceId, true).IsBorrowed)
            {
                DataTable Dt = _manager.GetBorrowDetailsByResourceId(_resource.ResourceId);

                string user = Dt.Rows.Count > 0 ? Dt.Rows[0]["uzytkownik"].ToString() : "";
                int borrowId = Dt.Rows.Count > 0 ? (int)Dt.Rows[0]["wypoz_id"] : -1;

                if (MessageBox.Show(string.Format("Zasób nie może zostać wypożyczony, ponieważ obecnie jest wypożyczony przez użytkownika {0}. Czy zwrócić zasób i wypożyczyć użytkownikowi {1}?", user, _user.UserName), "Zwrot zasobu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (_manager.ReturnBorrow(borrowId, DateTime.Now))
                        DoBorrow();

                    return;
                }
                else
                    return;
            }

            int timeLimit = 0;

            if (_user != null && _resource != null)
                timeLimit = _user.MaxBorrowTime <= _resource.TimeLimit ? _user.MaxBorrowTime : _resource.TimeLimit;

            int tempborrowId = _manager.DoBorrow(_resource.ResourceId, _user.UserID, timeLimit, "", DateTime.Now);

            if (tempborrowId != -1)
            {
                GetUserData(_user.UserID);
                GetResourceData(-1);

                MessageBox.Show(_translationsDictionary.getStringFromDictionary("resource_has_been_borrowed", "Zasób został wypożyczony!"), _translationsDictionary.getStringFromDictionary("borrow", "Wypożyczenie"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (_manager.WypozyczalniaConfiguration.Reverse == Configuration.ReverseMode.Semiauto)
                    PrintRevers(tempborrowId, false);
                else if (_manager.WypozyczalniaConfiguration.Reverse == Configuration.ReverseMode.Auto)
                    PrintRevers(tempborrowId, true);
            }
        }

        private void GetUserData(int id)
        {
            _user = _manager.GetUserById(id, true);
            userTextBox.Text = _user.UserName;

            userCardButton.Enabled = id != -1;

            SetButtons();

            //userLockedLabel.Visible = _user.IsLocked && _user.UserID != -1;

            if (_user.IsLocked && _user.UserID != -1 && _manager.WypozyczalniaConfiguration.RequiredNotLockedUserForBorrow == Configuration.RequiredNotLockedUserForBorrowMode.Yes)
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("user_is_locked", "Użytkownik jest zablokowany. Odblokuj go na karcie użytkownika, żeby mógł wypożyczać zasoby."), _translationsDictionary.getStringFromDictionary("locked_user", "Zablokowany użytkownik"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void PrintRevers(int borrowId, bool auto)
        {
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("wypoz_id", borrowId.ToString());
            RdlViewer.MainForm printForm = new RdlViewer.MainForm("Rewers.rdl", parameters, "coliber", Settings.ConnectionString, auto);

            if (!auto)
                printForm.ShowDialog();
        }

        private void SetButtons()
        {
            string cInfo = "";
            bool enabled = _user != null && _user.UserID > 0 && (!_user.IsLocked || _manager.WypozyczalniaConfiguration.RequiredNotLockedUserForBorrow == Configuration.RequiredNotLockedUserForBorrowMode.No) && _resource != null && _resource.ResourceId > 0; ;
            if (_user == null) cInfo = "null";
            else cInfo = _user.UserID.ToString() + "\n" + _user.UserName + "\n" + _user.IsLocked.ToString();
            if (_resource == null) cInfo = cInfo + "\n null";
            else cInfo = cInfo + "\n" + _resource.ResourceId.ToString() + "\n" + _resource.Title;

            if (System.IO.File.Exists("Debug.SQL")) MessageBox.Show(cInfo);
            
            borrowButton.Enabled = enabled;                        
        }

        private void userCardButton_Click(object sender, EventArgs e)
        {
            UserForm uf = new UserForm(_user.UserID.ToString(), null);
            DialogResult result = uf.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.Yes || result == System.Windows.Forms.DialogResult.Cancel)
                GetUserData(_user.UserID);
            else
                GetUserData(-1);

            searchUserTextBox.Focus();
        }

        private void cleanResourceButton_Click(object sender, EventArgs e)
        {
            GetResourceData(-1);
        }

        private void cleanUserButton_Click(object sender, EventArgs e)
        {
            GetUserData(-1);
        }

        private void selectUserButton_Click(object sender, EventArgs e)
        {
            UsersListForm userList = new UsersListForm(UsersListForm.Mode.SelectUser, null, Settings.employeeID);

            if (userList.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GetUserData(userList.CurrentUserId);
            }

            searchUserTextBox.Focus();
        }

        private void userBarcodeTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrWhiteSpace(searchUserTextBox.Text))
                    return;

                GetUserData(SearchUser(searchUserTextBox.Text));
                searchUserTextBox.Text = "";

                if (_user.UserID == -1)
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("barcode_not_assigned_to_user", "Podany kod kreskowy nie został przypisany do żadnego użytkownika!"), _translationsDictionary.getStringFromDictionary("invalid_barcode", "Błędny kod kreskowy"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetUserData(-1);
                }
                else if (_user.IsDeleted)
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("user_has_been_checked_out", "Użytkownik został wyrejestrowany z biblioteki."), _translationsDictionary.getStringFromDictionary("user_checked_out", "Użytkownik wyrejestrowany"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    GetUserData(-1);
                }
            }
        }
        private int SearchUser(string barcode)
        {
            return _manager.GetUserIdByBarcode(barcode);
        }
    }
}
