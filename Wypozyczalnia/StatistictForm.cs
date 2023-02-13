using System.Threading;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Wypozyczalnia
{
    public partial class StatisticsForm : Form
    {
        private Manager _manager;
        private Dictionary<string, string> _translationsDictionary;

        public StatisticsForm()
        {
            InitializeComponent();
            setControlsText();

            Settings.SetSettings();

            _manager = new Manager(0, Settings.ConnectionString);

            SetUpResourceGroupComboBox();
            SetUpResourceStateComboBox();
            SetUpUserTypeComboBox();
            SetUpUserGroupComboBox();
            SetUpOperationTypeComboBox();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(resourcesTabPage, "resources");
            mapping.Add(resourceGroupLabel, "resource_group");
            mapping.Add(resourceStateLabel, "resource_state");
            mapping.Add(dateOfOperationLabel, "date_of_operation");
            mapping.Add(fromLabel, "from");
            mapping.Add(toLabel, "to");

            mapping.Add(usersTabPage, "persons");
            mapping.Add(userTypeLabel, "user_type");
            mapping.Add(groupLabel, "group");
            mapping.Add(onlyActiveUsersCheckBox, "only_active_users");

            mapping.Add(tabPage3, "reading_room");
            mapping.Add(label11, "kind_of_operation");
            mapping.Add(label8, "date_of_operation");
            mapping.Add(label10, "from");
            mapping.Add(label9, "to");

            mapping.Add(printButton, "print");
            mapping.Add(exitButton, "exit");

            mapping.Add(this, "borrows_stats");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void SetUpResourceGroupComboBox()
        {
            var items = _manager.GetResourceGroupsDictionary();
            items.Add(-1, _translationsDictionary.getStringFromDictionary("all", "Wszystkie"));

            resourceGroupComboBox.DisplayMember = "Value";
            resourceGroupComboBox.ValueMember = "Key";
            resourceGroupComboBox.DataSource = new BindingSource(items, null);

            resourceGroupComboBox.SelectedValue = -1;
        }

        private void SetUpResourceStateComboBox()
        {
            var items = new Dictionary<int, string>();
            items.Add(-1, _translationsDictionary.getStringFromDictionary("all", "Wszystkie"));
            items.Add(0, _translationsDictionary.getStringFromDictionary("not_borrowed", "Niewypożyczony"));
            items.Add(1, _translationsDictionary.getStringFromDictionary("borrowed_single", "Wypożyczony"));
            items.Add(2, _translationsDictionary.getStringFromDictionary("ordered", "Zamówiony"));

            resourceStateComboBox.DisplayMember = "Value";
            resourceStateComboBox.ValueMember = "Key";
            resourceStateComboBox.DataSource = new BindingSource(items, null);

            resourceStateComboBox.SelectedValue = -1;
        }

        private void StatisticsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SetUpUserTypeComboBox()
        {
            var items = _manager.GetUserTypesDictionary();
            items.Add(-1, _translationsDictionary.getStringFromDictionary("all", "Wszystkie"));

            userTypeComboBox.DisplayMember = "Value";
            userTypeComboBox.ValueMember = "Key";
            userTypeComboBox.DataSource = new BindingSource(items, null);

            userTypeComboBox.SelectedValue = -1;
        }

        private void SetUpUserGroupComboBox()
        {
            var items = _manager.GetUserGroupsDictionary();
            items[-1] = _translationsDictionary.getStringFromDictionary("all", "Wszystkie");

            userGroupComboBox.DisplayMember = "Value";
            userGroupComboBox.ValueMember = "Key";
            userGroupComboBox.DataSource = new BindingSource(items, null);

            userGroupComboBox.SelectedValue = -1;
        }

        private void SetUpOperationTypeComboBox()
        {
            var items = new Dictionary<int, string>();
            items.Add(1, _translationsDictionary.getStringFromDictionary("reminders", "Upomnienia"));
            items.Add(2, _translationsDictionary.getStringFromDictionary("borrows", "Wypożyczenia"));
            items.Add(3, _translationsDictionary.getStringFromDictionary("returns", "Zwroty"));
            items.Add(4, _translationsDictionary.getStringFromDictionary("orders", "Zamówienia"));

            operationTypeComboBox.DisplayMember = "Value";
            operationTypeComboBox.ValueMember = "Key";
            operationTypeComboBox.DataSource = new BindingSource(items, null);

            operationTypeComboBox.SelectedValue = 1;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();

            if(tabControl1.SelectedTab == tabPage3)
            {
                if(readingStartDTP.Checked && readingEndDTP.Checked && readingStartDTP.Value > readingEndDTP.Value)
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("start_date_cannot_be_later_than_end_date", "Data początkowa nie może być późniejsza niż data końcowa!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Błędne daty"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                command.Parameters.AddWithValue("@isStartDate", readingStartDTP.Checked);
                command.Parameters.AddWithValue("@startDate", readingStartDTP.Value.ToString("yyyyMMdd"));
                command.Parameters.AddWithValue("@isEndDate", readingEndDTP.Checked ? "1" : "0");
                command.Parameters.AddWithValue("@endDate", readingEndDTP.Value.ToString("yyyyMMdd"));

                ReportParameter[] parameters = new ReportParameter[4];
                parameters[0] = new ReportParameter("isStartDate", readingStartDTP.Checked ? "1" : "0");
                parameters[1] = new ReportParameter("startDate", readingStartDTP.Value.ToString("yyyyMMdd"));
                parameters[2] = new ReportParameter("isEndDate", readingEndDTP.Checked ? "1" : "0");
                parameters[3] = new ReportParameter("endDate", readingEndDTP.Value.ToString("yyyyMMdd"));

                if((int)operationTypeComboBox.SelectedValue == 1)
                {
                    command.CommandText = "EXEC w2_upomnienie_raport_wszyscy_liczba @isStartDate, @startDate, @isEndDate, @endDate; ";

                    if (!CheckCount(command))
                        return;

                    PrintReport("Upomnienia_wszyscy.rdl", parameters);
                }
                else if ((int)operationTypeComboBox.SelectedValue == 2)
                {
                    command.CommandText = "EXEC w2_uzytkownicy_wypozyczenia_raport_liczba @isStartDate, @startDate, @isEndDate, @endDate; ";

                    if (!CheckCount(command))
                        return;

                    PrintReport("Wypozyczalnia_wypozyczone_wszyscy.rdl", parameters);
                }
                else if ((int)operationTypeComboBox.SelectedValue == 3)
                {
                    command.CommandText = "EXEC w2_zwroty_raport_liczba @isStartDate, @startDate, @isEndDate, @endDate; ";

                    if (!CheckCount(command))
                        return;

                    PrintReport("Wypozyczalnia_zwroty.rdl", parameters);
                }
                else if ((int)operationTypeComboBox.SelectedValue == 4)
                {
                    command.CommandText = "EXEC w2_zamowienia_raport_liczba @isStartDate, @startDate, @isEndDate, @endDate; ";

                    if (!CheckCount(command))
                        return;

                    PrintReport("Wypozyczalnia_zamowienia.rdl", parameters);
                }
            }
            else if(tabControl1.SelectedTab == usersTabPage)
            {
                command.Parameters.AddWithValue("@grupa_id", userGroupComboBox.SelectedValue.ToString());
                command.Parameters.AddWithValue("@typ_uzytk", userTypeComboBox.SelectedValue.ToString());
                command.Parameters.AddWithValue("@tylko_aktywni", onlyActiveUsersCheckBox.Checked ? "1" : "0");

                command.CommandText = "EXEC w2_raport_uzytkownikow_liczba @grupa_id, @typ_uzytk, @tylko_aktywni; ";

                if (!CheckCount(command))
                    return;

                ReportParameter[] parameters = new ReportParameter[3];
                parameters[0] = new ReportParameter("grupa_id", userGroupComboBox.SelectedValue.ToString());
                parameters[1] = new ReportParameter("typ_uzytk", userTypeComboBox.SelectedValue.ToString());
                parameters[2] = new ReportParameter("tylko_aktywni", onlyActiveUsersCheckBox.Checked ? "1" : "0");

                PrintReport("Wypozyczalnia_uzytkownicy.rdl", parameters);
            }
            else if(tabControl1.SelectedTab == resourcesTabPage)
            {
                if (startDateDTP.Checked && endDateDTP.Checked && startDateDTP.Value > endDateDTP.Value)
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("start_date_cannot_be_later_than_end_date", "Data początkowa nie może być późniejsza niż data końcowa!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Błędne daty"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                command.Parameters.AddWithValue("@isStartDate", startDateDTP.Checked);
                command.Parameters.AddWithValue("@startDate", startDateDTP.Value.ToString("yyyyMMdd"));
                command.Parameters.AddWithValue("@isEndDate", endDateDTP.Checked);
                command.Parameters.AddWithValue("@endDate", endDateDTP.Value.ToString("yyyyMMdd"));
                command.Parameters.AddWithValue("@groupId", resourceGroupComboBox.SelectedValue.ToString());
                command.Parameters.AddWithValue("@state", resourceStateComboBox.SelectedValue.ToString());

                command.CommandText = "EXEC w2_zasoby_raport_liczba @isStartDate, @startDate, @isEndDate, @endDate, @groupId, @state; ";

                if (!CheckCount(command))
                    return;

                ReportParameter[] parameters = new ReportParameter[6];
                parameters[0] = new ReportParameter("isStartDate", startDateDTP.Checked ? "1" : "0");
                parameters[1] = new ReportParameter("startDate", startDateDTP.Value.ToString("yyyyMMdd"));
                parameters[2] = new ReportParameter("isEndDate", endDateDTP.Checked ? "1" : "0");
                parameters[3] = new ReportParameter("endDate", endDateDTP.Value.ToString("yyyyMMdd"));
                parameters[4] = new ReportParameter("groupId", resourceGroupComboBox.SelectedValue.ToString());
                parameters[5] = new ReportParameter("state", resourceStateComboBox.SelectedValue.ToString());

                PrintReport("Wypozyczalnia_zasoby.rdl", parameters);
            }
        }

        private void PrintReport(string reportName, ReportParameter[] parameters)
        {
            WaitForm WF = new WaitForm();

            this.Invoke((MethodInvoker)delegate
            {
                WF.Show(this);
                WF.Update();
            });

            if (System.IO.File.Exists("Debug.SQL")) MessageBox.Show(reportName + "\n" + Settings.ConnectionString);
            RdlViewer.MainForm printForm = new RdlViewer.MainForm(reportName, parameters, "coliber", Settings.ConnectionString);            

            WF.Close();

            printForm.ShowDialog();
        }

        private bool CheckCount(SqlCommand command)
        {            
            DataTable Dt = CommonFunctions.ReadData(command, ref Settings.Connection);


            if (Dt.Rows.Count > 0 && (int)Dt.Rows[0]["liczba"] == 0)
            {
                ShowMessage();
                return false;
            }

            return true;
        }
        private void ShowMessage()
        {
            MessageBox.Show(_translationsDictionary.getStringFromDictionary("no_results", "Brak wyników."), _translationsDictionary.getStringFromDictionary("statistics", "Statystyka"), MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
