using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.Odbc;

namespace WindowsFormsApplication1
{
    public partial class ShowReport : Form
    {
        DataSet Ds;
        string ReportName;
        OdbcCommand Command;

        public ShowReport(OdbcCommand Command, string ReportName)
        {
            InitializeComponent();

            this.Command = Command;
            this.ReportName = ReportName;            
        }

        private void ShowReport_Load(object sender, EventArgs e)
        {
            Command.CommandTimeout = 600;

            Ds = new DataSet();
            OdbcDataAdapter ReportAdapter = new OdbcDataAdapter();
            ReportAdapter.SelectCommand = Command;

            ReportAdapter.Fill(Ds);

            ReportDataSource reportDataSource = new ReportDataSource();
            reportDataSource.Value = Ds.Tables[0];

            bindingSource1.DataMember = Ds.Tables[0].ToString();
            bindingSource1.DataSource = Ds;

            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApplication1." + ReportName + ".rdlc";

            this.reportViewer1.RefreshReport();
        }

        private void ShowReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
