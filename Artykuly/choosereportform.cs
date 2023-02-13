using System.Collections.Generic;
using System.Threading;
using Microsoft.Reporting.WinForms;
using System;
using System.Windows.Forms;

namespace Artykuly
{
    public partial class ChooseReportForm : Form
    {
        private ArtykulyForm.KindEnum Kind;
        private string ID;
        private Form _parent;
        public ChooseReportForm(ArtykulyForm.KindEnum Kind, string ID, Form parent)
        {
            InitializeComponent();

            setControlsText();

            this.MdiParent = parent.MdiParent;
            parent.Enabled = false;
            _parent = parent;

            this.Kind = Kind;
            this.ID = ID;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(Card, "catalog_card");
            mapping.Add(Description, "catalog_description");
            mapping.Add(EscapeButton, "exit");

            mapping.Add(this, "printing");

            CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name);
        }

        private void Card_Click(object sender, EventArgs e)
        {
            ReportParameter[] Parameters = new ReportParameter[1];
            Parameters[0] = new ReportParameter("kod", ID);

            if (Kind == ArtykulyForm.KindEnum.Book)
            {
                RdlViewer.MainForm Report = new RdlViewer.MainForm("Artykul_KsiazkiKartaKatalogowa.rdl", Parameters, "coliber", Settings.ConnectionString);
                Report.ShowDialog();
            }
            else if (Kind == ArtykulyForm.KindEnum.Magazine)
            {
                RdlViewer.MainForm Report = new RdlViewer.MainForm("Artykul_CzaKartaKatalogowa.rdl", Parameters, "coliber", Settings.ConnectionString);
                Report.ShowDialog();
            }
        }

        private void Description_Click(object sender, EventArgs e)
        {
            ReportParameter[] Parameters = new ReportParameter[1];
            Parameters[0] = new ReportParameter("kod", ID);

            if (Kind == ArtykulyForm.KindEnum.Book)
            {
                RdlViewer.MainForm Report = new RdlViewer.MainForm("Artykul_KsiazkiOpisKatalogowy.rdl", Parameters, "coliber", Settings.ConnectionString);
                Report.ShowDialog();
            }
            else if (Kind == ArtykulyForm.KindEnum.Magazine)
            {
                RdlViewer.MainForm Report = new RdlViewer.MainForm("Artykul_CzaOpisKatalogowy.rdl", Parameters, "coliber", Settings.ConnectionString);
                Report.ShowDialog();
            }
        }

        private void ChooseReportForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void EscapeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChooseReportForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parent.Enabled = true;
            _parent.Focus();
        }
    }
}
