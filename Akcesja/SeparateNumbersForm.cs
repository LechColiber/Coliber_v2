using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Akcesja.UserControls;

namespace Akcesja
{
    public partial class SeparateNumbersForm : Form
    {
        private Form _parent;
        private string kod_akcesja;
        private string czasop_kod;
        private int MaxKol;
        private int VolumesMode;
        private infoAboutSeparateNumbersForm infoForm;
        private Dictionary<string, string> _translationsDictionary;
        public SeparateNumbersForm(string id_cza_syg, int year, string kod_akcesja, string czasop_kod, int MaxKol, int VolumesMode, Form parent)
        {
            InitializeComponent();

            setControlsText();

            this.MdiParent = parent.MdiParent;
            _parent = parent;
            parent.Enabled = false;

            this.kod_akcesja = kod_akcesja;
            this.czasop_kod = czasop_kod;
            this.MaxKol = MaxKol;
            this.VolumesMode = VolumesMode;

            SetGrids(GetData(id_cza_syg, year), year, kod_akcesja);

            ToolTip a = new ToolTip();
            a.IsBalloon = true;//
            a.UseAnimation = true;
            a.SetToolTip(infoPictureBox, _translationsDictionary.ContainsKey("instruction") ? _translationsDictionary["instruction"] : "Instrukcja przenoszenia");
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(OKButton, "confirm");
            mapping.Add(ExitButton, "exit");
            mapping.Add(gridsGroupBox, "available_volumes");
            mapping.Add(label1, "list_of_magazine_numbers");
            mapping.Add(label2, "select_magazine_numbers_and_move_to_volume");

            mapping.Add(this, "numbers_separation");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private DataTable GetData(string id_cza_syg, int year)
        {
            SqlCommand Command = new SqlCommand();            
            Command.CommandText = "EXEC Akcesja_WoluminySygnaturyRoku @id_cza_syg, @rok; ";
            
            Command.Parameters.AddWithValue("@id_cza_syg", id_cza_syg);
            Command.Parameters.AddWithValue("@rok", year);

            return CommonFunctions.ReadData(Command, ref Settings.Connection);
        }

        private void SetGrids(DataTable Dt, int year, string kod_akcesja)
        {
            int startX = 4;
            int startY = 16;
            int lastX = startX;
            int lastY = startY;

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (string.IsNullOrEmpty(Dt.Rows[i]["volumin"].ToString()))
                {
                    withoutVoluminSNGUC.SetUC(Dt.Rows[i]["id_volumes"].ToString(), year, Dt.Rows[i]["volumin"].ToString(), kod_akcesja);
                }
                else
                {
                    Control ctrl = new SeparateNumbersGridUC(Dt.Rows[i]["id_volumes"].ToString(), year, Dt.Rows[i]["volumin"].ToString(), kod_akcesja);
                    ctrl.Location = new Point(lastX, lastY);
                    //gridsGroupBox.Controls.Add(ctrl);
                    gridsPanel.Controls.Add(ctrl);
                                        
                   // if (gridsGroupBox.Width - lastX > ctrl.Width*2)
                    if (gridsPanel.Width - lastX > ctrl.Width * 2)
                    {
                        lastX += ctrl.Width;
                    }
                    else
                    {
                        lastX = startX; 
                        lastY += ctrl.Height;
                    }
                }
            }
        }

        private void SeparateNumbersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _parent.Enabled = true;
            _parent.Focus();
        }

        private void SeparateNumbersForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void ExitButton_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void OKButton_Click(object sender, System.EventArgs e)
        {
            UpdateNumbers();
        }

        private void UpdateNumbers()
        {
            SqlCommand Command = new SqlCommand("");
            StringBuilder commandText = new StringBuilder();
            int i = 0;
            List<string> volumesToRewriteList = new List<string>();

            Command.Parameters.AddWithValue("@czasop_code", czasop_kod);
            Command.Parameters.AddWithValue("@Akcesja_code", kod_akcesja);
            Command.Parameters.AddWithValue("@maxKol", MaxKol);

            foreach (SeparateNumbersGridUC ctrl in GetAll(this, typeof(SeparateNumbersGridUC)))
            {
                for (int j = 0; j < ctrl.NumbersDGV.Rows.Count; j++)
                {
                    if (ctrl.NumbersDGV.Rows[j].Cells["originalId_volumesDGVC"].Value.ToString() != ctrl.ID_volumes)
                    {                        
                        commandText.Append("EXEC Akcesja_ZmienWoluminNumeru @id_czasop_n" + i + ", @id_volumes" + i + "; " + Environment.NewLine);
                        Command.Parameters.AddWithValue("@id_czasop_n" + i, ctrl.NumbersDGV.Rows[j].Cells["id_czasop_nDGVC"].Value.ToString());
                        Command.Parameters.AddWithValue("@id_volumes" + i, ctrl.ID_volumes);                        

                        volumesToRewriteList.Add(ctrl.NumbersDGV.Rows[j].Cells["originalId_volumesDGVC"].Value.ToString());
                        volumesToRewriteList.Add(ctrl.ID_volumes);

                        i++;
                    }                    
                }                
            }

            volumesToRewriteList = volumesToRewriteList.Distinct().ToList();

            foreach (string id_volumes in volumesToRewriteList)
            {
                if (VolumesMode == 2)
                    commandText.Append("EXEC nr_zeszytu @id_volumes" + i + ", @maxKol, @czasop_code, @Akcesja_code; " + Environment.NewLine);
                else if (VolumesMode == 3)
                    commandText.Append("EXEC nr_kolejny @id_volumes" + i + ", @maxKol, @czasop_code, @Akcesja_code; " + Environment.NewLine);

                Command.Parameters.AddWithValue("@id_volumes" + i, id_volumes);

                i++;
            }

            Command.CommandText = commandText.ToString();

            WaitForm Wait = new WaitForm();
            this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

            if (string.IsNullOrEmpty(Command.CommandText.Trim()) || CommonFunctions.WriteData(Command, ref Settings.Connection))
            {
                Wait.Close();

                string message = _translationsDictionary.ContainsKey("rewriting_accession_numbers_success") ? _translationsDictionary["rewriting_accession_numbers_success"] : "Numery pomyślnie przepisano!";
                string caption = _translationsDictionary.ContainsKey("rewriting_accession_numbers") ? _translationsDictionary["rewriting_accession_numbers"] : "Przepisywanie numerów";

                //MessageBox.Show("Numery pomyślnie przepisano!", "Przepisywanie numerów", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

            Wait.Close();
        }

        public IEnumerable<Control> GetAll(Control control, Type type)
        {
            var controls = control.Controls.Cast<Control>();

            return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        private void infoPictureBox_Click(object sender, EventArgs e)
        {
            if (infoForm == null || infoForm.IsDisposed)
            {
                infoForm = new infoAboutSeparateNumbersForm(this);
                infoForm.Show();
            }
            else
                infoForm.BringToFront();
        }
    }
}
