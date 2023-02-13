using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Akcesja
{
    public partial class IndexUserControl : UserControl //BaseFreqUserControl
    {
        private Dictionary<int, string> ValuesDictionary;
        private Dictionary<string, string> id_czasop_nDictionary;

        private int Year;
        private string AkcesjaCode;
        private string CzasopCode;
        private string Title;
        private string Freq;
        private string ColumnName = "numer_z";
        private int VolumesMode;
        private int MaxKol;
        private string Sygnatura;
        private bool IndexExists;
        private int IndexNumer;
        private string id_cza_syg;
        private Dictionary<string, string> _translationsDictionary;

        public IndexUserControl(string Title, int Year, string AkcesjaCode, string CzasopCode, int RadioMode, int VolumesMode, int MaxKol, string Sygnatura, string id_cza_syg)// : base(Title, Year, AkcesjaCode, RadioMode, "", VolumesMode, MaxKol, Sygnatura)
        { 
            this.Year = Year;
            this.AkcesjaCode = AkcesjaCode;
            this.CzasopCode = CzasopCode;
            this.Title = Title;
            this.VolumesMode = VolumesMode;
            this.MaxKol = MaxKol;
            this.Sygnatura = Sygnatura;
            this.IndexNumer = MaxKol + 1;
            this.id_cza_syg = id_cza_syg;

            id_czasop_nDictionary = new Dictionary<string, string>();

            //LoadNewData(Year, MaxKol, RadioMode);

            if (RadioMode == 1)
                ColumnName = "data_wpl";
            else if (RadioMode == 2)
                ColumnName = "numer_z";
            else if (RadioMode == 3)
                ColumnName = "num_abs";

            InitializeComponent();

            LoadDataSpec(MaxKol);

            GetData("Indeks");
            GetData("Spec");

            setControlsText();
        }

        protected void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(indeksLabel, "index");
            mapping.Add(specialNumbersLabel, "special_numbers");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        public void LoadNewData(int Year, int MaxKol, int RadioMode)
        {
            this.Year = Year;

            if (RadioMode == 1)
                ColumnName = "data_wpl";
            else if (RadioMode == 2)
                ColumnName = "numer_z";
            else if (RadioMode == 3)
                ColumnName = "num_abs";

            LoadDataSpec(MaxKol);

            GetData("Indeks");
            GetData("Spec");
        }

        void LoadDataSpec(int MaxKol)
        {
            if (this.Controls.ContainsKey("Indeks1Label"))
                this.Controls["Indeks1Label"].Name = "Indeks" + (MaxKol + 1).ToString() + "Label";
            else
                this.Controls["Indeks" + this.IndexNumer.ToString() + "Label"].Name = "Indeks" + (MaxKol + 1).ToString() + "Label";

            if (!this.Controls.ContainsKey("Spec1Label"))
            {
                for (int i = IndexNumer + 1, j = 1; i <= IndexNumer + 20; i++, j++)
                {
                    this.Controls["Spec" + i + "Label"].Name = "Spec" + j.ToString() + "Label";
                }
            }

            for (int i = 1, j = MaxKol + 2; i <= 20; i++, j++)
            {
                this.Controls["Spec" + i + "Label"].Name = "Spec" + j.ToString() + "Label";
            }

            this.IndexNumer = MaxKol + 1;
        }

        private void GetData(string Freq)
        {
            int DebugIDCzasop = -1;
            int DebugKol = -1;

            try
            {              
                SqlCommand Command = new SqlCommand();
                Command.Parameters.AddWithValue("@kod", AkcesjaCode);
                Command.Parameters.AddWithValue("@rok1", Year);
                Command.Parameters.AddWithValue("@id_cza_syg", id_cza_syg);

                if (Freq.ToLower().Trim() == "indeks")
                {
                    //Command.CommandText = "SELECT numer_z, numer_z2, num_abs, num_abs2, data_wpl, kol FROM czasop_n WHERE kod = ? AND rok1 = ? AND kol = ?";
                    Command.CommandText = "EXEC Akcesja_NumeryKarty @kod, @rok1, @id_cza_syg, @maxKol, 2;";
                    Command.Parameters.AddWithValue("@maxKol", MaxKol + 1);                    
                }
                else if (Freq.ToLower().Trim() == "spec")
                {
                    //Command.CommandText = "SELECT numer_z, numer_z2, num_abs, num_abs2, data_wpl, kol FROM czasop_n WHERE kod = ? AND rok1 = ? AND kol >= ?";
                    Command.CommandText = "EXEC Akcesja_NumeryKarty @kod, @rok1, @id_cza_syg, @maxKol, 3;";
                    Command.Parameters.AddWithValue("@maxKol", MaxKol + 2);
                }

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                ValuesDictionary = new Dictionary<int, string>();

                if(Freq.ToLower().Trim() == "indeks")
                    id_czasop_nDictionary.Clear();

                if (Freq == "Indeks")
                {
                    if (Dt.Rows.Count > 0)
                        IndexExists = true;
                    else
                        IndexExists = false;
                }

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
                
                foreach (Control Ctrl in this.Controls)
                {
                    if (Ctrl is Label && Ctrl.Name.Contains(Freq) && !Ctrl.Name.Contains("Order"))
                    {
                        this.Controls[Ctrl.Name].Text = "";
                        this.Controls[Ctrl.Name].Enabled = true;

                        if (ValuesDictionary.Keys.Contains(Int32.Parse(Ctrl.Name.Replace("Label", "").Replace(Freq, ""))))
                        {
                            this.Controls[Freq + Int32.Parse(Ctrl.Name.Replace("Label", "").Replace(Freq, "")) + "Label"].Text = ValuesDictionary[Int32.Parse(Ctrl.Name.Replace("Label", "").Replace(Freq, ""))];

                            if (ValuesDictionary[Int32.Parse(Ctrl.Name.Replace("Label", "").Replace(Freq, ""))] == "--//--")
                                this.Controls[Freq + Int32.Parse(Ctrl.Name.Replace("Label", "").Replace(Freq, "")) + "Label"].Enabled = false;
                        }
                        else
                            this.Controls[Ctrl.Name].Text = "";
                    }
                }                

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
            if (((Label)(sender)).Name.Contains("Indeks"))
                this.Freq = "Indeks";
            if (((Label)(sender)).Name.Contains("Spec"))
                this.Freq = "Spec";

            SingleNumberForm SNF;

            if (this.Freq == "Indeks")
            {
                if (!IndexExists)
                    SNF = new SingleNumberForm(Title, Year, ((Label)(sender)).Name.Replace(Freq, "").Replace("Label", ""), AkcesjaCode, CzasopCode, VolumesMode, true, this.Sygnatura, this.id_cza_syg, "-1", MaxKol);
                else
                    SNF = new SingleNumberForm(Title, Year, ((Label)(sender)).Name.Replace(Freq, "").Replace("Label", ""), AkcesjaCode, CzasopCode, VolumesMode, false, this.Sygnatura, this.id_cza_syg, id_czasop_nDictionary[((Label)(sender)).Name.Replace(Freq, "").Replace("Label", "")], MaxKol);
            }
            else
            {
                if (!ValuesDictionary.ContainsKey(Int32.Parse(((Label)(sender)).Name.Replace(Freq, "").Replace("Label", ""))))
                    SNF = new SingleNumberForm(Title, Year, ((Label)(sender)).Name.Replace(Freq, "").Replace("Label", ""), AkcesjaCode, CzasopCode, VolumesMode, true, this.Sygnatura, this.id_cza_syg, "-1", MaxKol);
                else
                    SNF = new SingleNumberForm(Title, Year, ((Label)(sender)).Name.Replace(Freq, "").Replace("Label", ""), AkcesjaCode, CzasopCode, VolumesMode, false, this.Sygnatura, this.id_cza_syg, id_czasop_nDictionary[((Label)(sender)).Name.Replace(Freq, "").Replace("Label", "")], MaxKol);
            }

            SNF.ShowDialog();

            GetData("Indeks");
            GetData("Spec");
        }

        public void Lock()
        {
            if (Settings.ReadOnlyMode)
            {
                string Freq = "Indeks";

                foreach (Control Ctrl in this.Controls)
                {
                    if (Ctrl.Name.Contains(Freq) && !Ctrl.Name.Contains("Order"))
                        Ctrl.Enabled = false;
                }

                Freq = "Spec";

                foreach (Control Ctrl in this.Controls)
                {
                    if (Ctrl.Name.Contains(Freq) && !Ctrl.Name.Contains("Order"))
                        Ctrl.Enabled = false;
                }
            }
            else if (Settings.ReadOnlyModeForCatalog)
            {
                foreach (Control Ctrl in this.Controls)
                {
                    if (Ctrl is Label && !Ctrl.Name.Contains("Order") && Ctrl.Text == "")
                    {
                        this.Controls[Ctrl.Name].Enabled = false;
                    }
                }
            }
        }
    }
}
