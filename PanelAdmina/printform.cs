using System;
using System.Data.Odbc;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class PrintForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private Connection NewConnection;

        public PrintForm(Connection NewConnection)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.NewConnection = NewConnection;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "printing");
            mapping.Add(ExitButton, "exit");
            mapping.Add(PrintButton, "print");
            mapping.Add(authorsRadioButton, "authors_from_list");
            mapping.Add(allAuthorsRadioButton, "all_authors");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcCommand ReportCommand = new OdbcCommand();
                ReportCommand.Connection = NewConnection.AppConnection;

                ReportCommand.CommandText = "EXEC PA_RaportAutorow ?; ";
                ReportCommand.Parameters.AddWithValue("wszystko", allAuthorsRadioButton.Checked);

                ShowReport Report = new ShowReport(ReportCommand, "Ksiazki");

                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                Report.ShowDialog();

                Wait.Close();                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            this.Close();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintForm_KeyDown(object sender, KeyEventArgs e)
        {
            this.Close();
        }
    }
}
