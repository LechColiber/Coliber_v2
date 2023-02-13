using Microsoft.Reporting.WinForms;
//using Report;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Reports
{
    public partial class WydrukKIForm : Form
    {
        public WydrukKIForm(int id_rodzaj)
        {
            InitializeComponent();

            IniFile Configs = new IniFile("coliber.ini", "coliber", false);
            
            Settings.SetSettings(Configs.ReadIni("SqlServer", "ConnectionString"));            

            GenerateKinds();
            GenerateForAll();
            GenerateIdRodzaj(id_rodzaj);
            GenerateSortBy();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void GenerateKinds()
        {
            Dictionary<int, string> KindsDictionary = new Dictionary<int, string>();
            KindsDictionary.Add(1, "Książki");
            KindsDictionary.Add(2, "Czasopisma");
            KindsDictionary.Add(3, "Wydawnictwa seryjne");

            KindComboBox.DataSource = new BindingSource(KindsDictionary, null);
            KindComboBox.DisplayMember = "Value";
            KindComboBox.ValueMember = "Key";
        }

        private void GenerateForAll()
        {
            Dictionary<int, string> ForAllDictionary = new Dictionary<int, string>();
            ForAllDictionary.Add(1, "Sygnatur");
            ForAllDictionary.Add(2, "Numerów inwentarzowych");

            ForAllComboBox.DataSource = new BindingSource(ForAllDictionary, null);
            ForAllComboBox.DisplayMember = "Value";
            ForAllComboBox.ValueMember = "Key";
        }

        private void GenerateIdRodzaj(int id_rodzaj)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "InventoryList;";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            IdRodzajComboBox.DataSource = new BindingSource(Dt, null);
            IdRodzajComboBox.DisplayMember = "inwentarz";
            IdRodzajComboBox.ValueMember = "id_rodzaj";

            IdRodzajComboBox.SelectedValue = id_rodzaj;
            
            AllDbCheckBox.Checked = id_rodzaj == 0;
        }

        private void GenerateSortBy()
        {
            Dictionary<int, string> SortByDictionary = new Dictionary<int, string>();
            SortByDictionary.Add(1, "Sygnatury");
            SortByDictionary.Add(2, "Numeru inwentarzowego");
            SortByDictionary.Add(3, "Daty wpisania");

            SortByComboBox.DataSource = new BindingSource(SortByDictionary, null);
            SortByComboBox.DisplayMember = "Value";
            SortByComboBox.ValueMember = "Key";
        }

        private void AllDbCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AllDbCheckBox.Checked)
                IdRodzajComboBox.Enabled = false;
            else
                IdRodzajComboBox.Enabled = true;
        }

        private void DateCheckBox_CheckedChanged(object sender, EventArgs e)
        {          
            FromDTP.Enabled = DateCheckBox.Checked;
            ToDTP.Enabled = DateCheckBox.Checked;
        }

        private void WydrukKIForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Dispose();
        }

        private void FromDTP_ValueChanged(object sender, EventArgs e)
        {
            if (FromDTP.Value > ToDTP.Value)
            {
                MessageBox.Show("Data początkowa nie może być późniejsza niż data końcowa!", "Zła data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FromDTP.Focus();
            }
        }

        private void ToDTP_ValueChanged(object sender, EventArgs e)
        {
            if (ToDTP.Value < FromDTP.Value)
            {
                MessageBox.Show("Data końcowa nie może być wcześniejsza niż data początkowa!", "Zła data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ToDTP.Focus();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            bool lStatWyp = false;
            int iStat = 10;
            lStatWyp = (cbStatWyp.Visible==true && cbStatWyp.SelectedIndex>-1);
            if (cbStatWyp.Visible == true && cbStatWyp.SelectedIndex == 1) iStat = 1;

            if (DateCheckBox.Checked)
            {
                if (FromDTP.Value > ToDTP.Value)
                {
                    MessageBox.Show("Data początkowa nie może być późniejsza niż data końcowa!", "Zła data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FromDTP.Focus();
                    return;
                }

                if (ToDTP.Value < FromDTP.Value)
                {
                    MessageBox.Show("Data końcowa nie może być wcześniejsza niż data początkowa!", "Zła data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ToDTP.Focus();
                    return;
                }
            }

            try
            {
                SqlCommand Command = new SqlCommand();

                if (Int32.Parse(KindComboBox.SelectedValue.ToString()) == 1)
                {
                    //Ksiazki();
                    if (lStatWyp )
                        Command.CommandText = "ZwrocIloscRekordowRaportuStatystykiKsiazki_2 @syg, @num_inw, @id_rodzaj, @data_poczatkowa, @data_koncowa, @p_stat;";
                    else
                        Command.CommandText = "ZwrocIloscRekordowRaportuStatystykiKsiazki @syg, @num_inw, @id_rodzaj, @data_poczatkowa, @data_koncowa;";
                }
                else if (Int32.Parse(KindComboBox.SelectedValue.ToString()) == 2)
                {
                    //Czasopisma();
                    Command.CommandText = "ZwrocIloscRekordowRaportuStatystykiCzasopism @syg, @num_inw, @id_rodzaj, @data_poczatkowa, @data_koncowa;";
                }
                else if (Int32.Parse(KindComboBox.SelectedValue.ToString()) == 3)
                {
                    //Czasopisma();
                    Command.CommandText = "ZwrocIloscRekordowRaportuStatystykiCzasopismaSeryjnego @syg, @num_inw, @id_rodzaj, @data_poczatkowa, @data_koncowa;";
                }

                if (Int32.Parse(ForAllComboBox.SelectedValue.ToString()) == 1)
                {
                    Command.Parameters.AddWithValue("@syg", ValueTextBox.Text.Trim());
                    Command.Parameters.AddWithValue("@num_inw", "");
                }
                else
                {
                    Command.Parameters.AddWithValue("@syg", "");
                    Command.Parameters.AddWithValue("@num_inw", ValueTextBox.Text.Trim());
                }

                if (AllDbCheckBox.Checked)
                    Command.Parameters.AddWithValue("@id_rodzaj", (0).ToString());
                else
                    Command.Parameters.AddWithValue("@id_rodzaj", IdRodzajComboBox.SelectedValue.ToString());

                if (DateCheckBox.Checked)
                {
                    /*
                    Command.Parameters.AddWithValue("@data_poczatkowa", FromDTP.Value.ToShortDateString());
                    Command.Parameters.AddWithValue("@data_koncowa", ToDTP.Value.ToShortDateString());
                    */

                    Command.Parameters.AddWithValue("@data_poczatkowa", FromDTP.Value.ToString("yyyyMMdd"));
                    Command.Parameters.AddWithValue("@data_koncowa", ToDTP.Value.ToString("yyyyMMdd"));

                }
                else
                {
                    Command.Parameters.AddWithValue("@data_poczatkowa", DBNull.Value);
                    Command.Parameters.AddWithValue("@data_koncowa", DBNull.Value);
                }
                if  (lStatWyp) Command.Parameters.AddWithValue("@p_stat", iStat.ToString());

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count != 0 && Dt.Rows[0]["ilosc"].ToString() == "0")
                {
                    MessageBox.Show("Nic nie znaleziono. ", "Brak rezulatatów", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (Dt.Rows.Count != 0 && MessageBox.Show("Ilość znalezionych pozycji: " + Dt.Rows[0]["ilosc"].ToString() + "\nCzy chcesz wydrukować?", "Wydruk", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    int Count = 6;
                    if (lStatWyp) Count = 7;

                    ReportParameter[] Parameters = new ReportParameter[Count];
                    
                    if (Int32.Parse(ForAllComboBox.SelectedValue.ToString()) == 1)
                    {
                        Parameters[0] = new ReportParameter("syg", ValueTextBox.Text.Trim());
                        Parameters[1] = new ReportParameter("num_inw", "");
                    }
                    else
                    {
                        Parameters[0] = new ReportParameter("syg", "");
                        Parameters[1] = new ReportParameter("num_inw", ValueTextBox.Text.Trim());
                    }

                    if (AllDbCheckBox.Checked)
                        Parameters[2] = new ReportParameter("id_rodzaj", (0).ToString());
                    else
                        Parameters[2] = new ReportParameter("id_rodzaj", IdRodzajComboBox.SelectedValue.ToString());

                    Parameters[3] = new ReportParameter("sort", SortByComboBox.SelectedValue.ToString());

                    if (DateCheckBox.Checked)
                    {
                        Parameters[4] = new ReportParameter("data_poczatkowa", FromDTP.Value.ToString("yyyy-MM-dd"));
                        Parameters[5] = new ReportParameter("data_koncowa", ToDTP.Value.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        Parameters[4] = new ReportParameter("data_poczatkowa", "1900-01-01");
                        Parameters[5] = new ReportParameter("data_koncowa", DateTime.Today.ToString("yyyy-MM-dd"));
                    }

                    WaitForm WF = new WaitForm();
                    this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });

                    RdlViewer.MainForm Report = null;// new RdlViewer.MainForm();

                    if (Int32.Parse(KindComboBox.SelectedValue.ToString()) == 1)
                    {
                        if (lStatWyp)
                        {
                            Parameters[6] = new ReportParameter("stat", iStat.ToString());
                            //Ksiazki
                            Report = new RdlViewer.MainForm("WydKsInw2.rdl", Parameters, "coliber", Settings.ConnectionString);
                        }
                        else
                            Report = new RdlViewer.MainForm("WydKsInw.rdl", Parameters, "coliber", Settings.ConnectionString);
                    }
                    else if (Int32.Parse(KindComboBox.SelectedValue.ToString()) == 2)
                    {
                        //Czasopisma
                        Report = new RdlViewer.MainForm("WydCzaInw.rdl", Parameters, "coliber", Settings.ConnectionString);
                    }
                    else if (Int32.Parse(KindComboBox.SelectedValue.ToString()) == 3)
                    {
                        //Wydawnictwa seryjne
                        Report = new RdlViewer.MainForm("WydSerInw.rdl", Parameters, "coliber", Settings.ConnectionString);
                    }

                    WF.Dispose();
                                        
                    if (Report != null)
                        Report.ShowDialog();                    
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                MessageBox.Show(Ex.Message);
            }
        }

        private void KindComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbStatWyp.Visible = (bool)(KindComboBox.SelectedIndex == 0);
            if (cbStatWyp.Visible == false) cbStatWyp.SelectedIndex = -1;
        }
    }
}