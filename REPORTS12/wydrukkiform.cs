using System.Threading;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Reports
{
    public partial class WydrukKIForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        Dictionary<int, string> SortByDictionary1 = new Dictionary<int, string>();
        Dictionary<int, string> SortByDictionary2 = new Dictionary<int, string>();
        public WydrukKIForm(int id_rodzaj)
        {
            InitializeComponent();

            IniFile Configs = new IniFile("coliber.ini", "coliber");
            
            Settings.SetSettings(Configs.ReadIni("SqlServer", "ConnectionString"));

            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            GenerateKinds();
            GenerateForAll();
            GenerateIdRodzaj(id_rodzaj);
            GenerateSortBy();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(statsLabel, "stats");
            mapping.Add(label2, "printout_invertories");

            mapping.Add(kindLabel, "kind");
            mapping.Add(forAllLabel, "for_all");
            mapping.Add(startWithLabel, "start_with");
            mapping.Add(AllDbCheckBox, "in_all_invertories");
            mapping.Add(orInInvertoryLabel, "or_in_intertory");
            mapping.Add(sortByLabel, "sort_by");
            mapping.Add(DateCheckBox, "include_dates");
            mapping.Add(startDateLabel, "since_date");
            mapping.Add(endDateLabel, "to_date");

            mapping.Add(SearchButton, "search");
            mapping.Add(ExitButton, "exit");
            mapping.Add(this, "printout_invertories");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GenerateKinds()
        {
            Dictionary<int, string> KindsDictionary = new Dictionary<int, string>();
            KindsDictionary.Add(1, _translationsDictionary.ContainsKey("books") ? _translationsDictionary["books"] : "Książki");
            KindsDictionary.Add(2, _translationsDictionary.ContainsKey("magazines") ? _translationsDictionary["magazines"] : "Czasopisma");
            KindsDictionary.Add(3, _translationsDictionary.ContainsKey("serial_publications") ? _translationsDictionary["serial_publications"] : "Wydawnictwa seryjne");            

            KindComboBox.DataSource = new BindingSource(KindsDictionary, null);
            KindComboBox.DisplayMember = "Value";
            KindComboBox.ValueMember = "Key";
        }

        private void GenerateForAll()
        {
            Dictionary<int, string> ForAllDictionary = new Dictionary<int, string>();
            ForAllDictionary.Add(1, _translationsDictionary.ContainsKey("signatures_genitive") ? _translationsDictionary["signatures_genitive"] : "Sygnatur");
            ForAllDictionary.Add(2, _translationsDictionary.ContainsKey("inventory_numbers_genitive") ? _translationsDictionary["inventory_numbers_genitive"] : "Numerów inwentarzowych");

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
            SortByDictionary1.Add(1, _translationsDictionary.ContainsKey("signature_genitive") ? _translationsDictionary["signature_genitive"] : "Sygnatury");
            SortByDictionary1.Add(2, _translationsDictionary.ContainsKey("inventory_number_genitive") ? _translationsDictionary["inventory_number_genitive"] : "Numeru inwentarzowego");
            SortByDictionary1.Add(3, _translationsDictionary.ContainsKey("entry_date_genitive") ? _translationsDictionary["entry_date_genitive"] : "Daty wpisania");
            SortByDictionary1.Add(4, _translationsDictionary.ContainsKey("by_author") ? _translationsDictionary["by_author"] : "Autora");
            SortByDictionary1.Add(5, _translationsDictionary.ContainsKey("by_title") ? _translationsDictionary["by_title"] : "Tytułu");

            SortByDictionary2.Add(1, _translationsDictionary.ContainsKey("signature_genitive") ? _translationsDictionary["signature_genitive"] : "Sygnatury");
            SortByDictionary2.Add(2, _translationsDictionary.ContainsKey("inventory_number_genitive") ? _translationsDictionary["inventory_number_genitive"] : "Numeru inwentarzowego");
            SortByDictionary2.Add(3, _translationsDictionary.ContainsKey("entry_date_genitive") ? _translationsDictionary["entry_date_genitive"] : "Daty wpisania");
            SortByDictionary2.Add(4, _translationsDictionary.ContainsKey("by_title") ? _translationsDictionary["by_title"] : "Tytułu");

            SortByComboBox.DataSource = new BindingSource(SortByDictionary1, null);
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
                this.Close();
        }

        private void FromDTP_ValueChanged(object sender, EventArgs e)
        {
            if (FromDTP.Value > ToDTP.Value)
            {
                string message = _translationsDictionary.ContainsKey("start_date_cannot_be_later_than_end_date") ? _translationsDictionary["start_date_cannot_be_later_than_end_date"] : "Data początkowa nie może być późniejsza niż data końcowa!";
                string caption = _translationsDictionary.ContainsKey("invalid_date") ? _translationsDictionary["invalid_date"] : "Zła data";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                FromDTP.Focus();
            }
        }

        private void ToDTP_ValueChanged(object sender, EventArgs e)
        {
            if (ToDTP.Value < FromDTP.Value)
            {
                string message = _translationsDictionary.ContainsKey("end_date_cannot_be_earlier_than_start_date") ? _translationsDictionary["end_date_cannot_be_earlier_than_start_date"] : "Data końcowa nie może być wcześniejsza niż data początkowa!";
                string caption = _translationsDictionary.ContainsKey("invalid_date") ? _translationsDictionary["invalid_date"] : "Zła data";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                ToDTP.Focus();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (DateCheckBox.Checked)
            {
                if (FromDTP.Value > ToDTP.Value)
                {
                    string message = _translationsDictionary.ContainsKey("start_date_cannot_be_later_than_end_date") ? _translationsDictionary["start_date_cannot_be_later_than_end_date"] : "Data początkowa nie może być późniejsza niż data końcowa!";
                    string caption = _translationsDictionary.ContainsKey("invalid_date") ? _translationsDictionary["invalid_date"] : "Zła data";

                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    FromDTP.Focus();
                    return;
                }

                if (ToDTP.Value < FromDTP.Value)
                {
                    string message = _translationsDictionary.ContainsKey("end_date_cannot_be_earlier_than_start_date") ? _translationsDictionary["end_date_cannot_be_earlier_than_start_date"] : "Data końcowa nie może być wcześniejsza niż data początkowa!";
                    string caption = _translationsDictionary.ContainsKey("invalid_date") ? _translationsDictionary["invalid_date"] : "Zła data";

                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Command.Parameters.AddWithValue("@data_poczatkowa", FromDTP.Value.ToShortDateString());
                    Command.Parameters.AddWithValue("@data_koncowa", ToDTP.Value.ToShortDateString());
                }
                else
                {
                    Command.Parameters.AddWithValue("@data_poczatkowa", DBNull.Value);
                    Command.Parameters.AddWithValue("@data_koncowa", DBNull.Value);
                }

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count != 0 && Dt.Rows[0]["ilosc"].ToString() == "0")
                {
                    string message = _translationsDictionary.ContainsKey("not_found") ? _translationsDictionary["not_found"] : "Nic nie znaleziono.";
                    string caption = _translationsDictionary.ContainsKey("no_results") ? _translationsDictionary["no_results"] : "Zła data";

                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return;
                }

                string message2 = string.Format("{0} {1}\n{2}", _translationsDictionary.ContainsKey("number_of_items_found") ? _translationsDictionary["number_of_items_found"] : "Ilość znalezionych pozycji: ", Dt.Rows[0]["ilosc"].ToString(), _translationsDictionary.ContainsKey("do_you_want_to_print") ? _translationsDictionary["do_you_want_to_print"] : "Czy chcesz wydrukować?");
                string caption2 = _translationsDictionary.ContainsKey("printout") ? _translationsDictionary["printout"] : "Wydruk";

                //if (Dt.Rows.Count != 0 && MessageBox.Show("Ilość znalezionych pozycji: " + Dt.Rows[0]["ilosc"].ToString() + "\nCzy chcesz wydrukować?", "Wydruk", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                if (Dt.Rows.Count != 0 && MessageBox.Show(message2, caption2, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                {
                    int Count = 6;

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
                        Parameters[4] = new ReportParameter("data_poczatkowa", FromDTP.Value.ToShortDateString());
                        Parameters[5] = new ReportParameter("data_koncowa", ToDTP.Value.ToShortDateString());
                    }
                    else
                    {
                        Parameters[4] = new ReportParameter("data_poczatkowa", "1900-01-01");
                        Parameters[5] = new ReportParameter("data_koncowa", DateTime.Today.ToShortDateString());
                    }

                    WaitForm WF = new WaitForm();
                    this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });

                    RdlViewer.MainForm Report = null;// new RdlViewer.MainForm();

                    if (Int32.Parse(KindComboBox.SelectedValue.ToString()) == 1)
                    {
                        //Ksiazki
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

                    WF.Close();
                                        
                    if (Report != null)
                        Report.ShowDialog();                    
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void KindComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SortByComboBox.DataSource = null;
            if  (KindComboBox.SelectedIndex == 1) SortByComboBox.DataSource = new BindingSource(SortByDictionary2, null);
            else SortByComboBox.DataSource = new BindingSource(SortByDictionary1, null);
            SortByComboBox.DisplayMember = "Value";
            SortByComboBox.ValueMember = "Key";
        }
    }
}