using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Ksiazki
{
    public partial class KartaKatologowaPrintForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        private string BookID;
        private Form _parent;

        public KartaKatologowaPrintForm(string BookID, bool isTome, Form parent)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.BookID = BookID;
            this.MdiParent = parent.MdiParent;
            _parent = parent;
            _parent.Enabled = false;
            parent.BringToFront();

            tomesAllRadioButton.Enabled = !isTome;
            tomesChoosenRadioButton.Enabled = !isTome;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(this, "catalogue_card_print");
            mapping.Add(label2, "volume_card_print");
            mapping.Add(label1, "main_catalogue_card_print");
            mapping.Add(tomesChoosenRadioButton, "chosen_catalogue_card_print");
            mapping.Add(tomesAllRadioButton, "all_catalogue_card_print");
            mapping.Add(PrintButton, "print");
            mapping.Add(ExitButton, "exit");
            mapping.Add(mainChoosenRadioButton, "chosen_main_catalogue_card_print");
            mapping.Add(mainAllRadioButton, "all_main_catalogue_card_print");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KartaKatologowaPrintForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void KartaKatologowaPrintForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parent.Enabled = true;
            _parent.Focus();
        }

        private void OpenRaport(string RaportName, ReportParameter[] prms)
        {
            //WaitForm WF = new WaitForm();
            //this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });

            string csSQLCopy = Settings.ConnectionString;

            
            //RdlViewer.MainForm Report = null;

            RdlViewer.MainForm rpt = new RdlViewer.MainForm(RaportName, prms, "coliber", csSQLCopy);


            //Report = new RdlViewer.MainForm(RaportName, prms, "coliber", csSQLCopy);            

            //WF.Dispose();

            if (rpt != null)
                rpt.ShowDialog();
            
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            ReportParameter[] Parameters = new ReportParameter[2];

            if (mainAllRadioButton.Checked)
            {
                Parameters[0] = new ReportParameter("kod", BookID);
                Parameters[1] = new ReportParameter("id_sygnat", "");

                OpenRaport("Ksiazki_KartaKatalogowa.rdl", Parameters);
            } 
            else if (mainChoosenRadioButton.Checked)
            {
                SygsToChooseForm STCF = new SygsToChooseForm(BookID, false);

                if (STCF.ShowDialog() == DialogResult.OK)
                {
                    Parameters[0] = new ReportParameter("kod", BookID);
                    Parameters[1] = new ReportParameter("id_sygnat", STCF.id_sygnatValues);

                    OpenRaport("Ksiazki_KartaKatalogowa.rdl", Parameters);
                }
            }
            else if (tomesAllRadioButton.Checked)
            {
                Parameters[0] = new ReportParameter("kod", BookID);
                Parameters[1] = new ReportParameter("id_sygnat", "");

                OpenRaport("Ksiazki_KartaKatalogowaTomy.rdl", Parameters);
            }
            else if (tomesChoosenRadioButton.Checked)
            {
                SygsToChooseForm STCF = new SygsToChooseForm(BookID, true);

                if (STCF.ShowDialog() == DialogResult.OK)
                {
                    Parameters[0] = new ReportParameter("kod", BookID);
                    Parameters[1] = new ReportParameter("id_sygnat", STCF.id_sygnatValues);

                    OpenRaport("Ksiazki_KartaKatalogowaWybraneTomy.rdl", Parameters);
                }
            }
        }
    }
}
