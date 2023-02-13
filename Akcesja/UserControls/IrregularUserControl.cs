using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Akcesja
{
    public partial class IrregularUserControl : BaseFreqUserControl
    {
        Dictionary<int, string> NumbersDictionary;
        Dictionary<int, string> ValuesDictionary;
        private Dictionary<string, string> id_czasop_nDictionary;

        private string Freq = "Day";
        private int FromNumber;
        private int ToNumber;
        private int PrevFromNumber;
        private int PrevToNumber;
        private int VolumesMode;
        private int MaxNumber = 9000;
        private string Sygnatura;
        private string id_cza_syg;

        public IrregularUserControl(string Title, int Year, string AkcesjaCode, string CzasopCode, int RadioMode, int VolumesMode, string Sygnatura, string id_cza_syg)
            : base(Title, Year, AkcesjaCode, CzasopCode, RadioMode, "Day", VolumesMode, 9000, Sygnatura, id_cza_syg)
        {
            InitializeComponent();

            setControlsText();

            this.FromNumber = 1;
            this.ToNumber = 30;
            this.VolumesMode = VolumesMode;
            base.MaxKol = MaxNumber;
            this.Sygnatura = Sygnatura;
            this.id_cza_syg = id_cza_syg;

            ValuesDictionary = new Dictionary<int, string>();
            NumbersDictionary = new Dictionary<int, string>();
            id_czasop_nDictionary = new Dictionary<string, string>();

            GenerateNumbers();
            NumbersComboBox.DataSource = new BindingSource(NumbersDictionary, null);
            NumbersComboBox.ValueMember = "Key";
            NumbersComboBox.DisplayMember = "Value";
            NumbersComboBox.SelectedValue = Settings.Interval;

            //GetData();
        }

        public void LoadNewData(int Year, int RadioMode)
        {
            this.Year = Year;

            base.SetViewMode(RadioMode);

            NumbersComboBox.SelectedValue = Settings.Interval;

            GetData();
        }

        private void GenerateNumbers()
        {
            string numbers = _translationsDictionary.ContainsKey("numbers") ? _translationsDictionary["numbers"] : "Numery";

            for (int i = 1, n = 1; i <= MaxNumber; i += 30, n++)
            {
                //NumbersDictionary.Add(n, "Numery " + i + "-" + (i + 29));
                NumbersDictionary.Add(n, string.Format("{0} {1}-{2}", numbers, i, (i + 29)));

                if (i % 30 == 0)
                    i++;                
            }
        }

        private void NumbersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.PrevFromNumber = this.FromNumber;
            this.PrevToNumber = this.ToNumber;

            this.FromNumber = NumbersComboBox.SelectedIndex * 30 + 1;
            this.ToNumber = NumbersComboBox.SelectedIndex * 30 + 30;

            for (int i = 1; i <= 30; i++)
            {
                this.Controls["label" + i.ToString()].Text = (NumbersComboBox.SelectedIndex * 30 + i).ToString() + ".";
            }

            for (int i = PrevFromNumber, j = FromNumber; i < PrevFromNumber + 30; i++, j++)
            {
                this.Controls[Freq + i + "Label"].Text = "";
                this.Controls[Freq + i + "Label"].Enabled = true;
                this.Controls[Freq + i + "Label"].Name = Freq + j + "Label";
            }

            if (NumbersComboBox.ValueMember != "")
                Settings.Interval = Int32.Parse(NumbersComboBox.SelectedIndex.ToString()) + 1;

            GetData();

            base.Lock();
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
                for (int i = FromNumber; i <= ToNumber; i++)
                {
                    if (ValuesDictionary.Keys.Contains(i))
                    {
                        this.Controls[Freq + i + "Label"].Text = ValuesDictionary[i];

                        if (ValuesDictionary[i] == "--//--")
                            this.Controls[Freq + i + "Label"].Enabled = false;
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
            SingleNumberForm SNF;
            
            if (!ValuesDictionary.ContainsKey(Int32.Parse(((Label)(sender)).Name.Replace(Freq, "").Replace("Label", ""))))
                SNF = new SingleNumberForm(Title, Year, ((Label)(sender)).Name.Replace(Freq, "").Replace("Label", ""), AkcesjaCode, CzasopCode, VolumesMode, true, this.Sygnatura, this.id_cza_syg, "-1", MaxKol);
            else
                SNF = new SingleNumberForm(Title, Year, ((Label)(sender)).Name.Replace(Freq, "").Replace("Label", ""), AkcesjaCode, CzasopCode, VolumesMode, false, this.Sygnatura, this.id_cza_syg, id_czasop_nDictionary[((Label)(sender)).Name.Replace(Freq, "").Replace("Label", "")], MaxKol);

            SNF.ShowDialog();
            GetData();            
        }
    }
}
