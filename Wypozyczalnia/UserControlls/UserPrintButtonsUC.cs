using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Wypozyczalnia
{
    public partial class UserPrintButtonsUC : UserControl
    {
        public int UserId { get; set; }
        private Dictionary<string, string> _translationsDictionary;
        public UserPrintButtonsUC()
        {
            InitializeComponent();
            
            setControlsText();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(printReminderButton, "print_all_reminders");
            mapping.Add(printBorrowsButton, "print_current_borrows");
            mapping.Add(printHistoryButton, "print_history_borrows");

            CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name);
        }

        public void SetButtonsEnable(bool printReminder, bool printBorrows, bool printHistory)
        {
            printReminderButton.Enabled = printReminder;
            printBorrowsButton.Enabled = printBorrows;
            printHistoryButton.Enabled = printHistory;
        }

        private void printReminderButton_Click(object sender, EventArgs e)
        {
            ReportParameter[] parameters = new ReportParameter[2];
            parameters[0] = new ReportParameter("wypoz_id", "-1");
            parameters[1] = new ReportParameter("uzytk_id", UserId.ToString());
            RdlViewer.MainForm printForm = new RdlViewer.MainForm("Upomnienia.rdl", parameters, "coliber", Settings.ConnectionString);

            printForm.ShowDialog();
        }

        private void printBorrowsButton_Click(object sender, EventArgs e)
        {
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("uzytk_id", UserId.ToString());
            RdlViewer.MainForm printForm = new RdlViewer.MainForm("Wypozyczalnia_wypozyczone.rdl", parameters, "coliber", Settings.ConnectionString);

            printForm.ShowDialog();
        }

        private void printHistoryButton_Click(object sender, EventArgs e)
        {
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("uzytk_id", UserId.ToString());
            RdlViewer.MainForm printForm = new RdlViewer.MainForm("Wypozyczalnia_historia.rdl", parameters, "coliber", Settings.ConnectionString);

            printForm.ShowDialog();
        }
    }
}
