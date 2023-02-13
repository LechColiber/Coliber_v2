using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Akcesja
{
    public partial class BaseFreqUserControl :  UserControl
    {
        private Dictionary<int, string> ValuesDictionary;
        private Dictionary<string, string> id_czasop_nDictionary;

        protected int Year;
        protected string AkcesjaCode;
        protected string CzasopCode;
        protected string Title;

        private string Freq;// = "Month";
        protected string ColumnName = "numer_z";
        private int VolumesMode;
        protected int MaxKol;
        private string Sygnatura;
        private string id_cza_syg;
        protected Dictionary<string, string> _translationsDictionary;

        public BaseFreqUserControl()
        {

        }

        protected void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            
            foreach (Label ctrl in this.Controls.Owner.Controls.OfType<Label>())
            {
                if (ctrl.Name.StartsWith("comments"))
                    mapping.Add(ctrl, "comments"); 
                else if (ctrl.Name.StartsWith("no"))
                    mapping.Add(ctrl, "number_short");
            }

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        public BaseFreqUserControl(string Title, int Year, string AkcesjaCode, string CzasopCode, int RadioMode, string Freq, int VolumesMode, int MaxKol, string Sygnatura, string id_cza_syg)
        {
            InitializeComponent();

            this.Year = Year;
            this.AkcesjaCode = AkcesjaCode;
            this.CzasopCode = CzasopCode;
            this.Title = Title;
            this.Freq = Freq;
            this.VolumesMode = VolumesMode;
            this.MaxKol = MaxKol;
            this.Sygnatura = Sygnatura;
            this.id_cza_syg = id_cza_syg;
            id_czasop_nDictionary = new Dictionary<string, string>();

            SetViewMode(RadioMode);
        }

        public void LoadNewData(int Year, int MaxKol, int RadioMode)
        {
            this.Year = Year;
            this.MaxKol = MaxKol;

            SetViewMode(RadioMode);

            GetData();
        }

        protected void SetViewMode(int RadioMode)
        {
            if (RadioMode == 1)
                ColumnName = "data_wpl";
            else if (RadioMode == 2)
                ColumnName = "numer_z";
            else if (RadioMode == 3)
                ColumnName = "num_abs";
        }

        public void Lock()
        {            
            if (Settings.ReadOnlyMode)
            {
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
                    if (Ctrl is Label && Ctrl.Name.Contains(Freq) && !Ctrl.Name.Contains("Order") && Ctrl.Text == "")
                    {
                        this.Controls[Ctrl.Name].Enabled = false;
                    }
                }
            }
        }

        protected void GetData()
        {
            int DebugIDCzasop = -1;
            int DebugKol = -1;

            try
            {
                foreach (Control Ctrl in this.Controls)
                {
                    if (Ctrl is Label && Ctrl.Name.Contains(Freq) && !Ctrl.Name.Contains("Order"))
                    {
                        this.Controls[Ctrl.Name].Text = "";
                        this.Controls[Ctrl.Name].Enabled = true;
                    }
                }  

                SqlCommand Command = new SqlCommand();

                //Command.CommandText = "SELECT numer_z, numer_z2, num_abs, num_abs2, data_wpl, kol, id_czasop_n FROM czasop_n WHERE kod = @kod AND rok1 = @rok1;-- AND kol <= @kol; ";
                Command.CommandText = "EXEC Akcesja_NumeryKarty @kod, @rok1, @id_cza_syg, @kol; ";
                Command.Parameters.AddWithValue("@kod", AkcesjaCode);
                Command.Parameters.AddWithValue("@rok1", Year);
                Command.Parameters.AddWithValue("@id_cza_syg", id_cza_syg);
                Command.Parameters.AddWithValue("@kol", MaxKol);

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

                foreach (Control Ctrl in this.Controls)
                {
                    if (Ctrl is Label && Ctrl.Name.Contains(Freq) && !Ctrl.Name.Contains("Order"))
                    {
                        if (ValuesDictionary.Keys.Contains(Int32.Parse(Ctrl.Name.Replace("Label", "").Replace(Freq, ""))))
                        {
                            this.Controls[Freq + Int32.Parse(Ctrl.Name.Replace("Label", "").Replace(Freq, "")) + "Label"].Text = ValuesDictionary[Int32.Parse(Ctrl.Name.Replace("Label", "").Replace(Freq, ""))];

                            if (ValuesDictionary[Int32.Parse(Ctrl.Name.Replace("Label", "").Replace(Freq, ""))] == "--//--")
                                this.Controls[Freq + Int32.Parse(Ctrl.Name.Replace("Label", "").Replace(Freq, "")) + "Label"].Enabled = false;
                        }
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

        protected void LoadData(object sender, EventArgs e)
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
