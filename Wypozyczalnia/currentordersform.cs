using System.Threading;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Wypozyczalnia
{    
    public partial class CurrentOrdersForm : Form
    {
        private Form _parent;
        private Manager _manager;
        private int _currentSort;
        private Color _isReadyRowColor;
        private Dictionary<string, string> _translationsDictionary;
        public CurrentOrdersForm(int EmployeeId, Form Parent)
        {
            InitializeComponent();

            setControlsText();

            Settings.SetSettings();

            if (Parent != null)
            {
                this.MdiParent = Parent.MdiParent;
            }

            _manager = new Manager(EmployeeId, Settings.ConnectionString);

            _isReadyRowColor = Color.LightGreen;

            _currentSort = 7;
            GetData(_currentSort);
        }

        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(userNameDGVC, "user");
            mapping.Add(descriptionDGVC, "title");
            mapping.Add(authorDGVC, "author1");
            mapping.Add(sigDGVC, "signature");
            mapping.Add(noInvDGVC, "inventory_number");
            mapping.Add(resourceKindDGVC, "kind");
            mapping.Add(orderDateDGVC, "order_date");
            mapping.Add(commentsDGVC, "comments");
            mapping.Add(isReadyDGVC, "ready");
            mapping.Add(realizeOrderButton, "realize");
            mapping.Add(cancelOrderButton, "cancel_order");
            mapping.Add(refreshButton, "refresh");
            mapping.Add(ExitButton, "exit");

            mapping.Add(this, "current_orders");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void GetData(int sort)
        {
            ordersDGV.Rows.Clear();

            DataTable Dt = _manager.GetCurrentOrders(sort);

            this.Text = string.Format("{0} ({1})", _translationsDictionary.getStringFromDictionary("current_orders", "Aktualne zamówienia"), Dt.Rows.Count);

            string locked = "";

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Boolean.Parse(Dt.Rows[i]["zablokowany"].ToString()))
                    locked = _T("blocked");
                
                int idx = ordersDGV.Rows.Add(Dt.Rows[i]["zamow_id"], Dt.Rows[i]["uzytk_id"], Dt.Rows[i]["zasob_id"], locked, Dt.Rows[i]["uzytkownik"], Dt.Rows[i]["opis"], Dt.Rows[i]["autor"], Dt.Rows[i]["syg"], Dt.Rows[i]["numer_inw"], Dt.Rows[i]["rodzaj"], Dt.Rows[i]["data_zamow"], Dt.Rows[i]["uwagi"], GeneralBase.ConvertToBool(Dt.Rows[i]["stan"].ToString()));

                if (GeneralBase.ConvertToBool(Dt.Rows[i]["stan"].ToString()))
                    ordersDGV.Rows[idx].DefaultCellStyle.BackColor = _isReadyRowColor;

                locked = "";
            }

            cancelOrderButton.Enabled = ordersDGV.Rows.Count > 0;
            realizeOrderButton.Enabled = ordersDGV.Rows.Count > 0;
        }

        private void CurrentOrdersForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void borrowsDGV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            /* Sortowanie:
            * 1 opis
            * 2 autor
            * 3 stan
            * 4 numer inwentarzowy
            * 5 sygnatura             
            * 6 użytkownik
            * 7 data zamowienia
            * 8 rodzaj
            * */
            if (e.Button == MouseButtons.Left)
            {
                int previousSort = _currentSort;

                if (e.ColumnIndex == ordersDGV.Columns[descriptionDGVC.Name].Index)
                    _currentSort = 1;
                else if (e.ColumnIndex == ordersDGV.Columns[authorDGVC.Name].Index)
                    _currentSort = 2;
                else if (e.ColumnIndex == ordersDGV.Columns[isReadyDGVC.Name].Index)
                    _currentSort = 3;
                else if (e.ColumnIndex == ordersDGV.Columns[noInvDGVC.Name].Index)
                    _currentSort = 4;
                else if (e.ColumnIndex == ordersDGV.Columns[sigDGVC.Name].Index)
                    _currentSort = 5;
                else if (e.ColumnIndex == ordersDGV.Columns[userNameDGVC.Name].Index)
                    _currentSort = 6;
                else if (e.ColumnIndex == ordersDGV.Columns[orderDateDGVC.Name].Index)
                    _currentSort = 7;
                else if (e.ColumnIndex == ordersDGV.Columns[resourceKindDGVC.Name].Index)
                    _currentSort = 8;

                if (previousSort != _currentSort)
                    GetData(_currentSort);
            }  
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            GetData(_currentSort);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ChangeOrderState(int orderId, bool isReady)
        {
            return _manager.ChangeOrderState(orderId, isReady) && isReady;
        }

        private void ordersDGV_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (ordersDGV.IsCurrentCellDirty)
                ordersDGV.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void ordersDGV_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ordersDGV.Columns[isReadyDGVC.Name].Index && e.RowIndex >= 0 && e.RowIndex < ordersDGV.Rows.Count)
            {
                if (ChangeOrderState((int)ordersDGV[orderIdDGVC.Name, e.RowIndex].Value, (bool)ordersDGV[isReadyDGVC.Name, e.RowIndex].Value))
                    ordersDGV.Rows[e.RowIndex].DefaultCellStyle.BackColor = _isReadyRowColor;
                else
                    ordersDGV.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }

        private void cancelOrderButton_Click(object sender, EventArgs e)
        {
            if (ordersDGV.SelectedRows.Count > 0 && MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_cancel_order", "Czy na pewno zrezygnować z zamówienia?"), _translationsDictionary.getStringFromDictionary("resignation_order", "Rezygnacja z zamówienia"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                _manager.CancelOrder((int) ordersDGV.SelectedRows[0].Cells[orderIdDGVC.Name].Value);
                GetData(_currentSort);
            }
        }

        private void checkoutOrderButton_Click(object sender, EventArgs e)
        {
            RealizeOrder((int)ordersDGV.SelectedRows[0].Cells[userIdDGVC.Name].Value, (int)ordersDGV.SelectedRows[0].Cells[resourceIdDGVC.Name].Value, (int)ordersDGV.SelectedRows[0].Cells[orderIdDGVC.Name].Value);            
        }

        private void RealizeOrder(int userId, int resourceId, int orderId)
        {
            User userOrder = _manager.GetUserById(userId);

            if (userOrder.MaxBorrows <= _manager.GetUserBorrowsCount(userId))
            {
                if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("user_exceed_limit_of_amount", "Użytkownik przekroczył limit ilości wypożyczonych zasobów. Czy wypożyczyć mimo to?"), _translationsDictionary.getStringFromDictionary("exceeded_amount_limit", "Przekroczony limit ilości"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("resource_has_not_been_borrowed", "Zasób NIE został wypożyczony!"), _translationsDictionary.getStringFromDictionary("information", "Informacja"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            int borrowId = -1;

            if (_manager.GetResourceById(resourceId, true).IsBorrowed)
            {
                DataTable Dt = _manager.GetBorrowDetailsByResourceId(resourceId);

                string user = Dt.Rows.Count > 0 ? Dt.Rows[0]["uzytkownik"].ToString() : "";
                borrowId = Dt.Rows.Count > 0 ? (int)Dt.Rows[0]["wypoz_id"] : -1;

                if (MessageBox.Show(string.Format(_T("return_resource_info_001"), user, userOrder.UserName), _T("question"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    /*ZwrotForm zwrot = new ZwrotForm(borrowId.ToString(), null, true);
                    zwrot.ShowDialog();*/

                    if (_manager.ReturnBorrow(borrowId, DateTime.Now))
                        RealizeOrder(userId, resourceId, orderId);

                    return;
                }
                else
                    return;
            }

            borrowId = _manager.RealizeOrder(orderId);

            MessageBox.Show(_translationsDictionary.getStringFromDictionary("resource_has_been_borrowed", "Zasób został wypożyczony!"), _translationsDictionary.getStringFromDictionary("borrow", "Wypożyczenie"), MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (_manager.WypozyczalniaConfiguration.Reverse == Configuration.ReverseMode.Semiauto)
                PrintRevers(borrowId, false);
            else if (_manager.WypozyczalniaConfiguration.Reverse == Configuration.ReverseMode.Auto)
                PrintRevers(borrowId, true);
            else if (_manager.WypozyczalniaConfiguration.Reverse == Configuration.ReverseMode.Manual && MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_print_reverse", "Czy wydrukować rewers?"), _translationsDictionary.getStringFromDictionary("printing", "Drukowanie rewersu"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                PrintRevers(borrowId, false);

            GetData(_currentSort);
        }

        private void PrintRevers(int borrowId, bool auto)
        {
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("wypoz_id", borrowId.ToString());
            RdlViewer.MainForm printForm = new RdlViewer.MainForm("Rewers.rdl", parameters, "coliber", Settings.ConnectionString, auto);

            if (!auto)
                printForm.ShowDialog();
        }

        private void ordersDGV_SelectionChanged(object sender, EventArgs e)
        {
            if(ordersDGV.SelectedRows.Count > 0)
            {
                realizeOrderButton.Enabled = !(ordersDGV.SelectedRows[0].Cells[userLockedDGVC.Name].Value.ToString() == _T("blocked") && _manager.WypozyczalniaConfiguration.RequiredNotLockedUserForBorrow == Configuration.RequiredNotLockedUserForBorrowMode.Yes);
            }
        }
    }
}
