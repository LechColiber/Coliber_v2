
﻿using System.Collections.Generic;
using System.Threading;
using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Wypozyczalnia
{
    public partial class BorrowForm : Form
    {
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private Manager _manager;
        private User _user;
        private Resource _resource;
        private int _timeDiff;
        private Form _parent;

        private Dictionary<string, string> _translationsDictionary;
        public BorrowForm(int EmployeeId, Form parent)
        {
            Settings.SetSettings();

            InitializeComponent();

            setControlsText();

            if (parent != null)
            {
                parent.Enabled = false;
                _parent = parent;
                this.MdiParent = parent.MdiParent;
                this.Size = new Size(parent.MdiParent.Size.Width - 300, parent.MdiParent.Size.Height - 200);
            }

            notReturnedResourcesDGVUC1.OnReturnBorrow = GetUserData;
            
            Settings.employeeID = EmployeeId;

            _manager = new Manager(EmployeeId, Settings.ConnectionString);
            Set();
            SetButtons();
            searchUserTextBox.Select();
            userLockedLabel.Text = _T("blocked");

        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(userGroupBox, "user_info");
            mapping.Add(userLabel, "username");
            mapping.Add(critLabel, "barcode");

            mapping.Add(nameUDGVC, "permission");
            mapping.Add(startDateUDGVC, "date_from");
            mapping.Add(endDateUDGVC, "date_to");
            mapping.Add(lockedUDGVC, "locked_permission");

            mapping.Add(resourceGroupBox, "resource_info");
            mapping.Add(resourceLabel, "resource");
            mapping.Add(borrowDateLabel, "borrow_date");
            mapping.Add(expectedReturnDateLabel, "expected_date_of_return");

            mapping.Add(dataGridViewTextBoxColumn1, "permission");
            mapping.Add(dataGridViewTextBoxColumn2, "date_from");
            mapping.Add(dataGridViewTextBoxColumn3, "date_to");
            mapping.Add(dataGridViewCheckBoxColumn1, "locked_permission");

            mapping.Add(borrowButton, "do_borrow");
            mapping.Add(orderButton, "do_order");
            mapping.Add(printButton, "print_reverse");

            mapping.Add(actualTabPage, "borrows");
            mapping.Add(ordersTabPage, "orders");
            mapping.Add(historyTabPage, "history");
            mapping.Add(returnResourceButton, "return_resource");

            mapping.Add(orderDateODGVC, "order_date");
            mapping.Add(orderStateODGVC, "order_state");
            mapping.Add(descODGVC, "description");
            mapping.Add(authorsODGVC, "authors");
            mapping.Add(noInvODGVC, "inventory_number");
            mapping.Add(sygODGVC, "signature");
            mapping.Add(CommentsODGVC, "comments");
            mapping.Add(checkoutOrderButton, "realize");
            mapping.Add(cancelOrderButton, "cancel_order");
            mapping.Add(ExitButton, "exit");

            mapping.Add(this, "borrowing_and_returning_resources");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void Set()
        {
            switch(_manager.WypozyczalniaConfiguration.AutoSearchField)
            {
                case Configuration.SearchFieldMode.Barcode: resourceCritLabel.Text = _translationsDictionary.getStringFromDictionary("barcode", "Kod kreskowy"); break;
                case Configuration.SearchFieldMode.InvertoryNo: resourceCritLabel.Text = _translationsDictionary.getStringFromDictionary("inventory_number", "Numer inwentarzowy"); break;
                case Configuration.SearchFieldMode.Signature: resourceCritLabel.Text = _translationsDictionary.getStringFromDictionary("signature", "Sygnatura"); break;
            }

            ToolTip userDetailsToolTip = new ToolTip();
            userDetailsToolTip.SetToolTip(userCardButton, _translationsDictionary.getStringFromDictionary("open_user_card", "Otwórz kartę użytkownika"));
            userDetailsToolTip.SetToolTip(chooseResourceButton, _translationsDictionary.getStringFromDictionary("search_resource", "Wyszukaj zasób"));

            borrowDateDTP.Value = DateTime.Now;
            _timeDiff = 0;
        }

        private void BorrowForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SetTime()
        {
            if (_user != null && _resource != null)
                returnDateDTP.Value = borrowDateDTP.Value.AddDays(_user.MaxBorrowTime <= _resource.TimeLimit ? _user.MaxBorrowTime : _resource.TimeLimit);
            else if(_user != null)
                returnDateDTP.Value = borrowDateDTP.Value.AddDays(_user.MaxBorrowTime);
            else if (_resource != null)
                returnDateDTP.Value = borrowDateDTP.Value.AddDays(_resource.TimeLimit);
        }

        private void SetButtons()
        {
            bool enabled = _user != null && _user.UserID > 0 && (!_user.IsLocked || _manager.WypozyczalniaConfiguration.RequiredNotLockedUserForBorrow == Configuration.RequiredNotLockedUserForBorrowMode.No) && _resource != null && _resource.ResourceId > 0; ;
            borrowButton.Enabled = enabled;
            orderButton.Enabled = enabled;
            printButton.Enabled = notReturnedResourcesDGVUC1.notReturnedDGV.SelectedRows.Count > 0;
            returnResourceButton.Enabled = notReturnedResourcesDGVUC1.notReturnedDGV.SelectedRows.Count > 0;
            checkoutOrderButton.Enabled = ODGV.Rows.Count > 0 && _user != null && (!_user.IsLocked || _manager.WypozyczalniaConfiguration.RequiredNotLockedUserForBorrow == Configuration.RequiredNotLockedUserForBorrowMode.No);
        }

        private void GetUserData(int id)
        {
            _user = _manager.GetUserById(id, true);
            userTextBox.Text = _user.UserName;
            DataTable dt1;

            UDGVC.Rows.Clear();

            foreach (var permission in _user.Permissions.Values)
                UDGVC.Rows.Add(permission.Right.Name, permission.StartDate.ToString("dd-MM-yyyy"), permission.EndDate.ToString("dd-MM-yyyy"), permission.IsLocked);
            
            userCardButton.Enabled = id != -1;

            returnedResourcesDGVUC1.LoadReturned(_user.UserID);
            notReturnedResourcesDGVUC1.LoadNotReturned(_user.UserID, false);
            dt1 = _manager.GetUserOrdersByUserId(_user.UserID);
            dt1.Columns["stan"].ReadOnly = false;
            dt1.Columns["stan"].MaxLength = 30;
            string cOrg, cNew;
            foreach (DataRow dr in dt1.Rows)
            {
                cOrg = (string)dr["stan"];
                cNew = _T("stat_"+cOrg);
                dr["stan"] = cNew;
            }

            ODGV.DataSource = dt1;

            //returnBorrowButton.Enabled = notReturnedResourcesDGVUC1.notReturnedDGV.Rows.Count > 0;

            userPrintButtonsUC1.SetButtonsEnable(notReturnedResourcesDGVUC1.notReturnedDGV.Rows.Count > 0, notReturnedResourcesDGVUC1.notReturnedDGV.Rows.Count > 0, returnedResourcesDGVUC1.returnedDGV.Rows.Count > 0);
            userPrintButtonsUC1.UserId = id;
            UpdateTabsNames();

            SetTime();
            SetButtons();

            userLockedLabel.Visible = _user.IsLocked && _user.UserID != -1;

            if (_user.IsLocked && _user.UserID != -1 && _manager.WypozyczalniaConfiguration.RequiredNotLockedUserForBorrow == Configuration.RequiredNotLockedUserForBorrowMode.Yes)
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("user_is_locked", "Użytkownik jest zablokowany. Odblokuj go na karcie użytkownika, żeby mógł wypożyczać zasoby."), _translationsDictionary.getStringFromDictionary("locked_user", "Zablokowany użytkownik"), MessageBoxButtons.OK, MessageBoxIcon.Warning);            
        }

        private void UpdateTabsNames()
        {
            historyTabPage.Text = _translationsDictionary.getStringFromDictionary("history", "Historia") + " (" + returnedResourcesDGVUC1.returnedDGV.Rows.Count + ")";
            actualTabPage.Text = _translationsDictionary.getStringFromDictionary("borrows", "Wypożyczenia") + " (" + notReturnedResourcesDGVUC1.notReturnedDGV.Rows.Count + ")";
            ordersTabPage.Text = _translationsDictionary.getStringFromDictionary("orders", "Zamówienia") + " (" + ODGV.Rows.Count + ")";

            cancelOrderButton.Enabled = ODGV.Rows.Count > 0;
            checkoutOrderButton.Enabled = ODGV.Rows.Count > 0;
        }

        private void GetResourceData(int id)
        {
            _resource = _manager.GetResourceById(id, true);
            resourceTitleRTB.Text = _resource.Title;

            RDGVC.Rows.Clear();

            foreach (var permission in _resource.Permissions.Values)
                RDGVC.Rows.Add(permission.Right.Name, permission.StartDate.ToString("dd-MM-yyyy"), permission.EndDate.ToString("dd-MM-yyyy"), permission.IsLocked);

            SetTime();
            SetButtons();
        }

        private int SearchUser(string barcode)
        {
            return _manager.GetUserIdByBarcode(barcode);
        }

        private int SearchResource(string value, Configuration.SearchFieldMode mode)
        {
            switch(mode)
            {
                case Configuration.SearchFieldMode.Barcode: return _manager.GetResourceIdByBarcode(value);
                case Configuration.SearchFieldMode.InvertoryNo: return _manager.GetResourceIdByNoInv(value);
                case Configuration.SearchFieldMode.Signature: return _manager.GetResourceIdBySignature(value);

                default: return -1;
            }            
        }

        private void selectUserButton_Click(object sender, EventArgs e)
        {
            UsersListForm userList = new UsersListForm(UsersListForm.Mode.SelectUser, null, Settings.employeeID);

            if(userList.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GetUserData(userList.CurrentUserId);
            }

            searchUserTextBox.Focus();
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

        private void searchUserTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(searchUserTextBox.Text))
            {
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

        private void chooseResourceButton_Click(object sender, EventArgs e)
        {
            ChooseResourceForm crf = new ChooseResourceForm(_manager.EmployeeId, ChooseResourceForm.WorkMode.SelectResource, null);
            
            if(crf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GetResourceData(crf.CurrentResourceId);
            }
        }

        private void resourceCritTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter && !string.IsNullOrWhiteSpace(resourceCritTextBox.Text))
            {
                GetResourceData(SearchResource(resourceCritTextBox.Text, _manager.WypozyczalniaConfiguration.AutoSearchField));
                resourceCritTextBox.Text = "";

                if(_resource.ResourceId == -1)
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
                else if (_manager.GetResourceById(_resource.ResourceId, true).IsBorrowed && _user != null && _user.UserID != -1 && _manager.GetUserHaveResourceBorrowed(_user.UserID, _resource.ResourceId) && MessageBox.Show(_T("return_resource_q"), _T("return_resource"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
                {
                    DataTable Dt = _manager.GetBorrowDetailsByResourceId(_resource.ResourceId);

                    int borrowId = Dt.Rows.Count > 0 ? (int)Dt.Rows[0]["wypoz_id"] : -1;

                    if (_manager.ReturnBorrow(borrowId, DateTime.Now))
                    {
                        MessageBox.Show(_translationsDictionary.getStringFromDictionary("resource_returned", "Zasób został zwrócony!"), _translationsDictionary.getStringFromDictionary("return_resource", "Zwrot zasobu"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                        GetUserData(_user.UserID);
                        GetResourceData(-1);
                    }
                }
            }
        }

        private void borrowDateDTP_ValueChanged(object sender, EventArgs e)
        {            
            //returnDateDTP.MinDate = borrowDateDTP.Value;
            returnDateDTP.Value = borrowDateDTP.Value.AddDays(_timeDiff);
        }

        private void returnDateDTP_ValueChanged(object sender, EventArgs e)
        {
            _timeDiff = returnDateDTP.Value.Subtract(borrowDateDTP.Value).Days;
        }

        private void cancelOrderButton_Click(object sender, EventArgs e)
        {
            if (ODGV.SelectedRows.Count > 0 && MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_cancel_order", "Czy na pewno zrezygnować z zamówienia?"), _translationsDictionary.getStringFromDictionary("resignation_order", "Rezygnacja z zamówienia"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                _manager.CancelOrder((int)ODGV.SelectedRows[0].Cells[orderIdODGVC.Name].Value);
                ODGV.DataSource = _manager.GetUserOrdersByUserId(_user.UserID);

                UpdateTabsNames();
            }
        }

        private void RealizeOrder()
        {
            if (_user.MaxBorrows <= notReturnedResourcesDGVUC1.notReturnedDGV.Rows.Count)
            {
                if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("user_exceed_limit_of_amount", "Użytkownik przekroczył limit ilości wypożyczonych zasobów. Czy wypożyczyć mimo to?"), _translationsDictionary.getStringFromDictionary("exceeded_amount_limit", "Przekroczony limit ilości"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("resource_has_not_been_borrowed", "Zasób NIE został wypożyczony!"), _translationsDictionary.getStringFromDictionary("information", "Informacja"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            int borrowId = -1;

            if (_manager.GetResourceById((int)ODGV.SelectedRows[0].Cells[resourceIdODGVC.Name].Value, true).IsBorrowed)
            {
                DataTable Dt = _manager.GetBorrowDetailsByResourceId((int)ODGV.SelectedRows[0].Cells[resourceIdODGVC.Name].Value);

                string user = Dt.Rows.Count > 0 ? Dt.Rows[0]["uzytkownik"].ToString() : "";
                borrowId = Dt.Rows.Count > 0 ? (int)Dt.Rows[0]["wypoz_id"] : -1;

                if (MessageBox.Show(string.Format(_T("return_resource_info_001"), user, _user.UserName), _translationsDictionary.getStringFromDictionary("return_resource", "Zwrot zasobu"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    /*ZwrotForm zwrot = new ZwrotForm(borrowId.ToString(), null, true);
                    zwrot.ShowDialog();*/

                    if (_manager.ReturnBorrow(borrowId, DateTime.Now))
                        RealizeOrder();

                    return;
                }
                else
                    return;                
            }

            borrowId = _manager.RealizeOrder((int)ODGV.SelectedRows[0].Cells[orderIdODGVC.Name].Value);
            GetUserData(_user.UserID);

            MessageBox.Show(_translationsDictionary.getStringFromDictionary("resource_has_been_borrowed", "Zasób został wypożyczony!"), _translationsDictionary.getStringFromDictionary("borrow", "Wypożyczenie"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (_manager.WypozyczalniaConfiguration.Reverse == Configuration.ReverseMode.Semiauto)
                PrintRevers(borrowId, false);
            else if (_manager.WypozyczalniaConfiguration.Reverse == Configuration.ReverseMode.Auto)
                PrintRevers(borrowId, true);
        }

        private void DoBorrow()
        {
            if(_user.MaxBorrows <= notReturnedResourcesDGVUC1.notReturnedDGV.Rows.Count)
            {
                if (MessageBox.Show(_T("user_exceed_limit_of_amount"), _T("exceeded_amount_limit"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("resource_has_not_been_borrowed", "Zasób NIE został wypożyczony!"), _translationsDictionary.getStringFromDictionary("information", "Informacja"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if(borrowDateDTP.Value > returnDateDTP.Value)
            {
                MessageBox.Show(_T("return_resource_info_002"), "Błędna data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (_manager.GetResourceById(_resource.ResourceId, true).IsBorrowed)
            {
                DataTable Dt = _manager.GetBorrowDetailsByResourceId(_resource.ResourceId);

                string user = Dt.Rows.Count > 0 ? Dt.Rows[0]["uzytkownik"].ToString() : "";
                int borrowId = Dt.Rows.Count > 0 ? (int)Dt.Rows[0]["wypoz_id"] : -1;

                if (MessageBox.Show(string.Format(_T("return_resource_info_003"), user, _user.UserName), _T("return_resource"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //ZwrotForm zwrot = new ZwrotForm(borrowId.ToString(), this, true);
                    
                    //if(zwrot.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if(_manager.ReturnBorrow(borrowId, DateTime.Now))
                        DoBorrow();
                    
                    return;
                }
                else
                    return;
            }

            int tempborrowId = _manager.DoBorrow(_resource.ResourceId, _user.UserID, returnDateDTP.Value.Subtract(borrowDateDTP.Value).Days, "", borrowDateDTP.Value);

            if (tempborrowId != -1)
            {                
                tabControl1.SelectedTab = actualTabPage;
                GetUserData(_user.UserID);
                GetResourceData(-1);

                resourceCritTextBox.Select();

                if(_manager.WypozyczalniaConfiguration.Reverse == Configuration.ReverseMode.Semiauto)
                    PrintRevers(tempborrowId, false);
                else if(_manager.WypozyczalniaConfiguration.Reverse == Configuration.ReverseMode.Auto)
                    PrintRevers(tempborrowId, true);
            }
        }

        private void checkoutOrderButton_Click(object sender, EventArgs e)
        {
            RealizeOrder();
        }

        private void borrowButton_Click(object sender, EventArgs e)
        {
            DoBorrow();
        }

        private void orderButton_Click(object sender, EventArgs e)
        {
            if (_manager.DoOrder(_resource.ResourceId, _user.UserID, ""))
            {
                try
                {
                    Coliber.MainForm MF = (Coliber.MainForm)this.MdiParent;
                    MF.UpdateOrdersButtonsText();
                }
                catch { }
                GetUserData(_user.UserID);
                GetResourceData(-1);
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("resource_ordered", "Zasób został zamówiony!"), _translationsDictionary.getStringFromDictionary("order", "Zamówienie"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show(_translationsDictionary.getStringFromDictionary("resource_is_in_user_orders", "Zasób został wcześniej zamówiony przez tego użytkownika."), _translationsDictionary.getStringFromDictionary("order", "Zamówienie"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BorrowForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_parent != null)
            {
                _parent.Enabled = true;
                _parent.Focus();
            }
        }

        private void returnResourceButton_Click(object sender, EventArgs e)
        {
            notReturnedResourcesDGVUC1.ReturnResource();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            PrintRevers((int)notReturnedResourcesDGVUC1.notReturnedDGV.SelectedRows[0].Cells["wypozIDNotReturnedDGVC"].Value, false);
        }

        private void PrintRevers(int borrowId, bool auto)
        {
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("wypoz_id", borrowId.ToString());
            RdlViewer.MainForm printForm = new RdlViewer.MainForm("Rewers.rdl", parameters, "coliber", Settings.ConnectionString, auto);
            
            if(!auto)
                printForm.ShowDialog();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
