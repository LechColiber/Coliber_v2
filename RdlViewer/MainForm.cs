using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Xml;
using Microsoft.Reporting.WinForms;
using System.Threading;

namespace RdlViewer
{
    public partial class MainForm : Form
    {
        private ReportParameter[] Parameters;
        public enum TypeEnum {Archivarius, Coliber};        

        public MainForm()
        {
            InitializeComponent();
            this.reportViewer1.Drillthrough += new DrillthroughEventHandler(DrillthroughEventHandler);
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        }

        public MainForm(string ReportName, ReportParameter[] Parameters, string Mode, string ConnectionString) : this()
        {
            if (Mode.ToLower().Trim() == "coliber")
            {
                Settings.CurrentType = TypeEnum.Coliber;
                Settings.ConnectionString = ConnectionString;
            }
            else if (Mode.ToLower().Trim() == "archivarius")
                Settings.CurrentType = TypeEnum.Archivarius;

            this.Parameters = Parameters;
            OpenReport(ReportName);
        }

        public MainForm(string ReportName, ReportParameter[] Parameters, string Mode, string ConnectionString, bool auto) : this()
        {
            if (Mode.ToLower().Trim() == "coliber")
            {
                Settings.CurrentType = TypeEnum.Coliber;
                Settings.ConnectionString = ConnectionString;
            }
            else if (Mode.ToLower().Trim() == "archivarius")
                Settings.CurrentType = TypeEnum.Archivarius;

            this.Parameters = Parameters;
            OpenReport(ReportName);

            if (auto)
            {
                ReportPrintDocument a = new ReportPrintDocument(this.reportViewer1.LocalReport);
                a.Print();
            }
        }

        /*public MainForm(string ReportName, ReportParameter[] Parameters, string Mode, string ConnectionString) : this(ReportName, Parameters, Mode)
        {
            if (Mode.ToLower().Trim() == "coliber")
                Settings.ConnectionString = ConnectionString;
        }*/

        private void LoadReportData(string rdlPath, IList<string> dataSetNames, ReportParameterInfoCollection reportParams, ReportDataSourceCollection dataSources)
        {
            ReportInfo reportInfo = new ReportInfo(rdlPath);
            try
            {
                reportInfo.Initialize();

                foreach (string dataSetName in dataSetNames)
                {
                    DataTable dataTable = reportInfo.GetData(dataSetName, reportParams);
                    if (dataTable == null)
                        return;
                    dataSources.Add(new ReportDataSource(dataSetName, dataTable));
                }
            }
            finally
            {
                reportInfo.Cleanup();
            }
        }

        private void LoadDataIntoReport(LocalReport report)
        {
            if (System.IO.File.Exists("Debug.SQL")) MessageBox.Show(report.ReportPath + "\n" + Settings.ConnectionString);
            LoadReportData(report.ReportPath, report.GetDataSourceNames(), report.GetParameters(), report.DataSources);
        }
        
        private void LoadReport(string rdlFilename)
        {
            this.reportViewer1.Reset();
            this.reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.EnableHyperlinks = true;
            this.reportViewer1.LocalReport.ReportPath = rdlFilename;

            this.reportViewer1.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(SubreportEventHandler);

            // Note about subreports:
            //
            // If the report has subreports ReportViewer will automatically load them, but only if the subreport has
            // the .rdlc extension.
            //
            // You could use LoadSubreportDefinition() to workaround this problem but in this case you have to know the 
            // name of the subreport. You could scan the main report's rdl to collect names of all subreports, but this
            // sample does not do that.

            //ReportParameterInfoCollection parameters = this.reportViewer1.LocalReport.GetParameters();
            if (Parameters != null && Parameters.Length > 0)
            {
                /*using (ParameterDialog dialog = new ParameterDialog())
                {
                    dialog.ReportViewer = this.reportViewer1;
                    dialog.ShowDialog();
                }*/
                this.reportViewer1.LocalReport.SetParameters(Parameters);
            }

            this.reportViewer1.ServerReport.Timeout = 100000;
            //this.reportViewer1.LocalReport.MapTileServerConfiguration.Timeout = 100000;

            LoadDataIntoReport(this.reportViewer1.LocalReport);            

            this.reportViewer1.RefreshReport();
        }

        void SubreportEventHandler(object sender, SubreportProcessingEventArgs e)
        {
            /*LocalReport parentReport = (LocalReport)sender;
            string parentRdl = parentReport.ReportPath;
            string subreportPath = Path.Combine(Path.GetDirectoryName(parentRdl), e.ReportPath +".rdlc");
            LoadReportData(subreportPath, e.DataSourceNames, e.Parameters, e.DataSources);*/
        }

        void DrillthroughEventHandler(object sender, DrillthroughEventArgs e)
        {
            string parentRdl = this.reportViewer1.LocalReport.ReportPath;
            string drillthruReportPath = Path.Combine(Path.GetDirectoryName(parentRdl), e.ReportPath + ".rdl");
            if (!File.Exists(drillthruReportPath))
                drillthruReportPath = Path.Combine(Path.GetDirectoryName(parentRdl), e.ReportPath + ".rdlc");
            LocalReport report = (LocalReport)e.Report;
            report.SubreportProcessing += new SubreportProcessingEventHandler(SubreportEventHandler);
            report.ReportPath = drillthruReportPath;
            LoadDataIntoReport(report);
        }

        private string GetExceptionMessage(Exception ex)
        {
            string message = ex.Message;
            if (ex.InnerException != null)
                message += ": " + GetExceptionMessage(ex.InnerException);
            return message;
        }

        private void OpenReport(string ReportName)
        {
            try
            {
                LoadReport("Raporty/" + ReportName);
                //this.Text = ReportName + " - RDL Viewer";
            }
            catch (Exception ex)
            {
                string message = GetExceptionMessage(ex);

                if (ex.InnerException != null && ex.InnerException.GetType().ToString() ==
                             "Microsoft.Reporting.DefinitionInvalidException")
                {
                    message = "RDL version may not be compatible with ReportViewer version. "
                              + "To view 2008 RDLs you need Visual Studio 2010."
                              + "\r\n\r\n" + message;
                }

                MessageBox.Show(message, "RDL Viewer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
