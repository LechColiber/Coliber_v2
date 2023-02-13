using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Threading;

namespace Ksiazki
{
    public partial class PrintForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        public PrintForm()
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            //mapping.Add(OkButton, "ok");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
            //this.Text = _T("authors_coauthors_institutions");
        }

        private void PrintForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
           /* int Count = 6;
            WaitForm WF = new WaitForm();
            this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });
            ReportParameter[] Parameters = new ReportParameter[Count];

            RdlViewer.MainForm Report = null;
            Report = new RdlViewer.MainForm("WydKsInw.rdl", Parameters, "coliber", Settings.ConnectionStringSql);

            WF.Dispose();

            if (Report != null)
                Report.ShowDialog(); */
        }
    }
}
