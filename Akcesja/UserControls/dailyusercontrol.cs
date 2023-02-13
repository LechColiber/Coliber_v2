using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Akcesja
{
    public partial class DailyUserControl : BaseFreqUserControl//UserControl
    {
        Dictionary<int, string> MonthsDictionary;
        Dictionary<int, string> ValuesDictionary;
        private Dictionary<string, string> id_czasop_nDictionary;

        private int Year;
        private int Days = 31;
        private string Freq;
        private int FromNumber;
        private int ToNumber;
        private int PrevFromNumber;
        private int PrevToNumber;
        private int VolumesMode;
        private string Sygnatura;
        private string id_cza_syg;

        public DailyUserControl(string Title, int Year, string AkcesjaCode, string CzasopCode, int RadioMode, int VolumesMode, string Sygnatura, string id_cza_syg)
            : base(Title, Year, AkcesjaCode, CzasopCode, RadioMode, "Day", VolumesMode, 31, Sygnatura, id_cza_syg)
        {
            InitializeComponent();

            this.Year = Year;
            this.Freq = "Day";
            this.FromNumber = 1;
            this.ToNumber = 31;
            this.VolumesMode = VolumesMode;
            this.Sygnatura = Sygnatura;
            this.id_cza_syg = id_cza_syg;

            MonthsDictionary = new Dictionary<int, string>();
            ValuesDictionary = new Dictionary<int, string>();
            id_czasop_nDictionary = new Dictionary<string, string>();

            setControlsText();
            GenerateMonths();
            MonthComboBox.SelectedIndexChanged -= MonthComboBox_SelectedIndexChanged;
            MonthComboBox.DataSource = new BindingSource(MonthsDictionary, null);
            MonthComboBox.ValueMember = "Key";
            MonthComboBox.DisplayMember = "Value";
            MonthComboBox.SelectedIndexChanged += MonthComboBox_SelectedIndexChanged;
            MonthComboBox.SelectedValue = Settings.MonthNumber;            
        }

        public void LoadNewData(int Year, int RadioMode)
        {
            this.Year = Year;

            base.SetViewMode(RadioMode);

            MonthComboBox.SelectedValue = Settings.MonthNumber;

            GetData();
            Render();
        }

        public void Render()
        {
            if (Int32.Parse(MonthComboBox.SelectedValue.ToString()) == 2)
            {
                if (!(this.Year%4 == 0 && this.Year%100 != 0 || this.Year%400 == 0))
                {
                    OrderDay29Label.Visible = false;
                    Day29Label.Visible = false;
                    //base.MaxKol = 28;
                }
                else
                {
                    OrderDay29Label.Visible = true;
                    Day29Label.Visible = true;
                }
            }        
        }

        public void GenerateMonths()
        {
            MonthsDictionary.Add(1, _translationsDictionary.ContainsKey("january") ? _translationsDictionary["january"] : "Styczeń");
            MonthsDictionary.Add(2, _translationsDictionary.ContainsKey("february") ? _translationsDictionary["february"] : "Luty");
            MonthsDictionary.Add(3, _translationsDictionary.ContainsKey("march") ? _translationsDictionary["january"] : "Marzec");
            MonthsDictionary.Add(4, _translationsDictionary.ContainsKey("april") ? _translationsDictionary["april"] : "Kwiecień");
            MonthsDictionary.Add(5, _translationsDictionary.ContainsKey("may") ? _translationsDictionary["may"] : "Maj");
            MonthsDictionary.Add(6, _translationsDictionary.ContainsKey("june") ? _translationsDictionary["june"] : "Czerwiec");
            MonthsDictionary.Add(7, _translationsDictionary.ContainsKey("july") ? _translationsDictionary["july"] : "Lipiec");
            MonthsDictionary.Add(8, _translationsDictionary.ContainsKey("august") ? _translationsDictionary["august"] : "Sierpień");
            MonthsDictionary.Add(9, _translationsDictionary.ContainsKey("september") ? _translationsDictionary["september"] : "Wrzesień");
            MonthsDictionary.Add(10, _translationsDictionary.ContainsKey("october") ? _translationsDictionary["october"] : "Październik");
            MonthsDictionary.Add(11, _translationsDictionary.ContainsKey("november") ? _translationsDictionary["november"] : "Listopad");
            MonthsDictionary.Add(12, _translationsDictionary.ContainsKey("december") ? _translationsDictionary["december"] : "Grudzień");
        }

        private void MonthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrevFromNumber = FromNumber;
            PrevToNumber = ToNumber;

            switch (Int32.Parse(MonthComboBox.SelectedIndex.ToString())+1)
            {
                case 4:
                case 6:
                case 9:
                case 11: OrderDay31Label.Visible = false;
                         Day31Label.Visible = false;
                         //base.MaxKol = 30;
                         break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12: OrderDay29Label.Visible = true;
                         Day29Label.Visible = true;
                         OrderDay30Label.Visible = true;
                         Day30Label.Visible = true;
                         OrderDay31Label.Visible = true;
                         Day31Label.Visible = true;
                        // base.MaxKol = 31;
                         break;
                case 2:  //base.MaxKol = 29; 
                         if (!(this.Year % 4 == 0 && this.Year % 100 != 0 || this.Year % 400 == 0))
                         {
                             OrderDay29Label.Visible = false;
                             Day29Label.Visible = false;
                             //base.MaxKol = 28;
                         }

                         OrderDay30Label.Visible = false;
                         Day30Label.Visible = false;
                         OrderDay31Label.Visible = false;
                         Day31Label.Visible = false;                         
                         break;
            }

            CalculateNumber(Int32.Parse(MonthComboBox.SelectedIndex.ToString()) + 1);
            CleanRename();
            GetData();

            if (MonthComboBox.ValueMember != "")
                Settings.MonthNumber = Int32.Parse(MonthComboBox.SelectedIndex.ToString()) + 1;             

            base.Lock();
        }

        //Wylicza numery dni
        private void CalculateNumber(int MonthNumber)
        {
            for (int i = 1; i <= MonthNumber; i++)
            {
                switch (i)
                {
                    case 1: Days = 31;
                            FromNumber = 1;
                            ToNumber = FromNumber + Days - 1;
                            break;
                    case 2: FromNumber += Days;
                            if (!(this.Year % 4 == 0 && this.Year % 100 != 0 || this.Year % 400 == 0))
                                Days = 28;
                            else
                                Days = 29;

                            ToNumber = FromNumber + Days - 1;
                            break;
                    case 3:
                    case 5:
                    case 7:
                    case 8:
                    case 10:
                    case 12: 
                            FromNumber += Days;
                            Days = 31;
                            ToNumber = FromNumber + Days - 1;
                            break;
                    case 4:
                    case 6:
                    case 9:
                    case 11:   
                            FromNumber += Days;
                            Days = 30;                        
                            ToNumber = FromNumber + Days - 1;
                            break;
                }
            }
        }

        //Wyczyszczenie Labeli
        private void CleanRename()
        {
            this.SuspendLayout();
            for (int i = PrevFromNumber, j = FromNumber; i <= PrevFromNumber+30; i++, j++)
            {
                this.Controls[Freq + i + "Label"].Text = "";
                this.Controls[Freq + i + "Label"].Enabled = true;
                this.Controls[Freq + i + "Label"].Name = Freq + j + "Label";
            }
            this.ResumeLayout(true);
        }

        //Pobiera dane z bazy i wyświetla je
        private void GetData()
        {
            int DebugIDCzasop = -1;
            int DebugKol = -1;

            try
            {               
                //Czyści labele
                for (int i = FromNumber; i <= ToNumber; i++)
                {
                    this.Controls[Freq + i + "Label"].Text = "";
                    this.Controls[Freq + i + "Label"].Enabled = true;
                }

                SqlCommand Command = new SqlCommand();                
                
                //Command.CommandText = "SELECT numer_z, numer_z2, num_abs, num_abs2, data_wpl, kol, id_czasop_n FROM czasop_n WHERE kod = @kod AND rok1 = @rok1 AND id_volumes IN (SELECT id_volumes FROM volumes WHERE id_cza_syg = @id_cza_syg); ";
                Command.CommandText = "EXEC Akcesja_NumeryKarty @kod, @rok1, @id_cza_syg, @maxKol; ";
                
                Command.Parameters.AddWithValue("@kod", AkcesjaCode);
                Command.Parameters.AddWithValue("@rok1", Year);
                Command.Parameters.AddWithValue("@id_cza_syg", id_cza_syg);
                Command.Parameters.AddWithValue("@maxKol", ToNumber);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                ValuesDictionary = new Dictionary<int, string>();
                id_czasop_nDictionary.Clear();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    DebugIDCzasop = Int32.Parse(Dt.Rows[i]["id_czasop_n"].ToString());
                    DebugKol = Int32.Parse(Dt.Rows[i]["kol"].ToString());

                    id_czasop_nDictionary.Add(Dt.Rows[i]["kol"].ToString(), Dt.Rows[i]["id_czasop_n"].ToString());

                    if (ColumnName == "numer_z" || ColumnName == "num_abs")
                    {
                        if (Int32.Parse(Dt.Rows[i]["numer_z2"].ToString()) != 0 || Int32.Parse(Dt.Rows[i]["num_abs2"].ToString()) != 0)
                        {                            
                            if (Int32.Parse(Dt.Rows[i][ColumnName + "2"].ToString()) != 0)
                                ValuesDictionary.Add(Int32.Parse(Dt.Rows[i]["kol"].ToString()), Dt.Rows[i][ColumnName].ToString() + "/" + Dt.Rows[i][ColumnName + "2"].ToString());
                            else if (Int32.Parse(Dt.Rows[i][ColumnName].ToString()) != 0)
                                ValuesDictionary.Add(Int32.Parse(Dt.Rows[i]["kol"].ToString()), Dt.Rows[i][ColumnName].ToString());
                            else
                                ValuesDictionary.Add(Int32.Parse(Dt.Rows[i]["kol"].ToString()), "");

                            int Roznica = Int32.Parse(Dt.Rows[i]["numer_z2"].ToString()) - Int32.Parse(Dt.Rows[i]["numer_z"].ToString());
                            for (int j = Int32.Parse(Dt.Rows[i]["kol"].ToString()) + 1; j <= Int32.Parse(Dt.Rows[i]["kol"].ToString()) + Roznica; j++)
                            {
                                ValuesDictionary.Add(j, "--//--");
                            }
                        }
                        else if (Int32.Parse(Dt.Rows[i][ColumnName].ToString()) != 0)
                            ValuesDictionary.Add(Int32.Parse(Dt.Rows[i]["kol"].ToString()), Dt.Rows[i][ColumnName].ToString());
                        else
                            ValuesDictionary.Add(Int32.Parse(Dt.Rows[i]["kol"].ToString()), "");
                    }
                    else if (ColumnName == "data_wpl")
                    {
                        ValuesDictionary.Add(Int32.Parse(Dt.Rows[i]["kol"].ToString()), Dt.Rows[i][ColumnName].ToString());

                        int Roznica = Int32.Parse(Dt.Rows[i]["numer_z2"].ToString()) - Int32.Parse(Dt.Rows[i]["numer_z"].ToString());
                        for (int j = Int32.Parse(Dt.Rows[i]["kol"].ToString()) + 1; j <= Int32.Parse(Dt.Rows[i]["kol"].ToString()) + Roznica; j++)
                        {
                            ValuesDictionary.Add(j, "--//--");
                        }
                    }
                }

                //Wypełnia labele
                this.SuspendLayout();
                for (int i = FromNumber; i <= ToNumber; i++)
                {
                    if (ValuesDictionary.Keys.Contains(i))
                    {
                        this.Controls[Freq + i + "Label"].Text = ValuesDictionary[i];

                        if (ValuesDictionary[i] == "--//--")
                            this.Controls[Freq + i + "Label"].Enabled = false;
                    }
                }
                this.ResumeLayout(true);

                Lock();
            }
            catch (ArgumentException Ex)
            {
                string messageText = "ID rekordu: " + DebugIDCzasop.ToString() + "\nNumer, która się powtarza: " + DebugKol + "\n\nPrawdopodobnie zostały wprowadzone 2 numery w jedną komórkę. Proszę znaleźć ten numer i go usunąć. Jeśli akcja się nie powiedzie, proszę skontaktować się z producentem oprogramowania.";
                MessageBox.Show(messageText, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void LoadData(object sender, EventArgs e)
        {
            SingleNumberForm SNF;
            int MaxKol;

            if (this.Year % 4 == 0 && this.Year % 100 != 0 || this.Year % 400 == 0)
                MaxKol = 366;
            else
                MaxKol = 365;
            
            if (!ValuesDictionary.ContainsKey(Int32.Parse(((Label)(sender)).Name.Replace(Freq, "").Replace("Label", ""))))
                SNF = new SingleNumberForm(Title, Year, ((Label)(sender)).Name.Replace(Freq, "").Replace("Label", ""), AkcesjaCode, CzasopCode, VolumesMode, true, this.Sygnatura, this.id_cza_syg, "-1", MaxKol);
            else
                SNF = new SingleNumberForm(Title, Year, ((Label)(sender)).Name.Replace(Freq, "").Replace("Label", ""), AkcesjaCode, CzasopCode, VolumesMode, false, this.Sygnatura, this.id_cza_syg, id_czasop_nDictionary[((Label)(sender)).Name.Replace(Freq, "").Replace("Label", "")], MaxKol);

            SNF.ShowDialog();
            GetData();            
        }
    }
}
