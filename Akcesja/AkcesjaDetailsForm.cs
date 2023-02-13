using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Akcesja
{
    public partial class AkcesjaDetailsForm : Form
    {
        private string FreqName;
        private string WindowText;
        private int Freq;
        private string AkcesjaCode;
        private string CzasopCode;
        private string Title;
        private int RadioMode;
        private int VolumesMode;
        private int DepartmentID;
        private string id_cza_syg;
        private int MaxKol;
        private enum DepartModeEnum {NONE, ADD, EDIT};
        private int CurrentDepartMode;

        BaseFreqUserControl FreqUC;

        IndexUserControl IndexUC;
        private Form _parent;
        protected Dictionary<string, string> _translationsDictionary;

        #region AkcesjaDetailsForm(int Freq, string AkcesjaCode, string CzasopCode, string Sygnatura, string Title, int id_rodzaj, bool ReadOnlyModeForCatalog, string id_cza_syg, Form Parent) - OK
        public AkcesjaDetailsForm(int Freq, string AkcesjaCode, string CzasopCode, string Sygnatura, string Title, int id_rodzaj, bool ReadOnlyModeForCatalog, string id_cza_syg, Form Parent)
            : this(Freq, AkcesjaCode, CzasopCode, Sygnatura, Title, 1, id_rodzaj, ReadOnlyModeForCatalog, id_cza_syg, Parent)
        {


        }
        #endregion

        #region AkcesjaDetailsForm(int Freq, string AkcesjaCode, string CzasopCode, string Sygnatura, string Title, int VolumesMode, int id_rodzaj, bool ReadOnlyModeForCatalog, string id_cza_syg, Form Parent) - OK
        public AkcesjaDetailsForm(int Freq, string AkcesjaCode, string CzasopCode, string Sygnatura, string Title, int VolumesMode, int id_rodzaj, bool ReadOnlyModeForCatalog, string id_cza_syg, Form Parent)
        {
            InitializeComponent();

            setControlsText();
            
            SetSetting(ReadOnlyModeForCatalog);

            this.MdiParent = Parent.MdiParent;
            
            this._parent = Parent;
            this._parent.Enabled = false;

            this.Freq = Freq;
            this.AkcesjaCode = AkcesjaCode;
            this.CzasopCode = CzasopCode;
            this.SygnaturaTextBox.Text = Sygnatura;
            this.Title = Title;
            this.TitleTextBox.Text = Title;
            this.VolumesMode = VolumesMode;
            this.id_cza_syg = id_cza_syg;

            RadioMode = 2;

            separateNumbersButton.Enabled = !Settings.ReadOnlyMode;

            this.FreqCommonUserControl.YearNumericUpDown.ValueChanged += YearNumericUpDown_ValueChanged;
            this.FreqCommonUserControl.DateRadioButton.CheckedChanged += DateRadioButton_CheckedChanged;
            this.FreqCommonUserControl.NextNumberRadioButton.CheckedChanged += NextNumberRadioButton_CheckedChanged;
            this.FreqCommonUserControl.NumberRadioButton.CheckedChanged += NumberRadioButton_CheckedChanged;

            this.IndexCommonUserControl.YearNumericUpDown.ValueChanged += YearNumericUpDown_ValueChanged;
            this.IndexCommonUserControl.DateRadioButton.CheckedChanged += DateRadioButton_CheckedChanged;
            this.IndexCommonUserControl.NextNumberRadioButton.CheckedChanged += NextNumberRadioButton_CheckedChanged;
            this.IndexCommonUserControl.NumberRadioButton.CheckedChanged += NumberRadioButton_CheckedChanged;

            this.ForWhoCommonUserControl.YearNumericUpDown.ValueChanged += YearNumericUpDown_ValueChanged;

            InitializeUC(1);

            this.Text = WindowText;

            this.MainTabControl.TabPages["Numbers"].Text = FreqName;

            GetDepartments();

            SetHints();    
        
            this.FreqCommonUserControl.loadConfig();
        }
        #endregion

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(magazineSignatureLabel, "magazines_signature");
            mapping.Add(titleLabel, "title");
            mapping.Add(ExitButton, "exit");
            mapping.Add(separateNumbersButton, "numbers_separation");
            mapping.Add(amountOfCopiesLabel, "amount_of_copies");
            mapping.Add(departmentNameLabel, "department_name");

            mapping.Add(Indexes, "indexes_and_special_magazine_numbers");
            mapping.Add(ForWho, "for_who");

            mapping.Add(NewButton, "new");
            mapping.Add(EditButton, "edit");
            mapping.Add(DeleteButton, "delete");
            mapping.Add(OKButton, "confirm");
            mapping.Add(CancelButton, "cancel");

            mapping.Add(departamentDGVC, "department");
            mapping.Add(iloscDGVC, "amount");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        #region SetSetting(bool ReadOnlyModeForCatalog) - OK
        private void SetSetting(bool ReadOnlyModeForCatalog)
        {
            Settings.ReadOnlyModeForCatalog = ReadOnlyModeForCatalog;

            Settings.Interval = 1;
            Settings.MonthNumber = DateTime.Now.Month;
        }
        #endregion

        #region SetHints() - OK
        private void SetHints()
        {
            ToolTip SelectButtonToolTip = new ToolTip();
            SelectButtonToolTip.SetToolTip(SelectButton, _translationsDictionary.ContainsKey("list_of_departments") ? _translationsDictionary["list_of_departments"] : "Lista departamentów");
        }
        #endregion

        #region NumberRadioButton_CheckedChanged(object sender, EventArgs e) - OK
        /// <summary>
        /// Obsługuje radiobutton zmieniający wyświetlanie na numer zeszytu.
        /// Synchronizuje radiobuttony na wszystkich trzech zakładkach.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NumberRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                this.FreqCommonUserControl.NumberRadioButton.Checked = true;
                this.IndexCommonUserControl.NumberRadioButton.Checked = true;

                RadioMode = 2;
                InitializeUC(RadioMode);
            }
        }
        #endregion

        #region NextNumberRadioButton_CheckedChanged(object sender, EventArgs e) - OK
        /// <summary>
        /// Obsługuje radiobutton zmieniający wyświetlanie na numer kolejny.
        /// Synchronizuje radiobuttony na wszystkich trzech zakładkach.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void NextNumberRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                this.FreqCommonUserControl.NextNumberRadioButton.Checked = true;
                this.IndexCommonUserControl.NextNumberRadioButton.Checked = true;

                RadioMode = 3;
                InitializeUC(RadioMode);
            }
        }
        #endregion

        #region DateRadioButton_CheckedChanged(object sender, EventArgs e) - OK
        /// <summary>
        /// Obsługuje radiobutton zmieniający wyświetlanie na datę.
        /// Synchronizuje radiobuttony na wszystkich trzech zakładkach.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void DateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                this.FreqCommonUserControl.DateRadioButton.Checked = true;
                this.IndexCommonUserControl.DateRadioButton.Checked = true;

                RadioMode = 1;
                InitializeUC(RadioMode);
            }
        }
        #endregion

        #region Ctrl_KeyDown(object sender, KeyEventArgs e) - OK
        /// <summary>
        /// Obsługuje zamykanie okna poprzez naciśnięcie przycisku ESCAPE.
        /// Ustawione jest "KeyPreview" na tym oknie.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Ctrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
        }
        #endregion

        #region YearNumericUpDown_ValueChanged(object sender, EventArgs e) - OK
        /// <summary>
        /// Obsługuje zmianę roku.
        /// Ustawia ten sam rok na wszystkich trzech zakładkach.
        /// Wywołuje funkcję "InitializeUC(int Mode)".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void YearNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            this.FreqCommonUserControl.YearNumericUpDown.ValueChanged -= YearNumericUpDown_ValueChanged;
            this.IndexCommonUserControl.YearNumericUpDown.ValueChanged -= YearNumericUpDown_ValueChanged;
            this.ForWhoCommonUserControl.YearNumericUpDown.ValueChanged -= YearNumericUpDown_ValueChanged;

            this.FreqCommonUserControl.YearNumericUpDown.Value = ((NumericUpDown)sender).Value;
            this.IndexCommonUserControl.YearNumericUpDown.Value = ((NumericUpDown)sender).Value;
            this.ForWhoCommonUserControl.YearNumericUpDown.Value = ((NumericUpDown)sender).Value;

            this.FreqCommonUserControl.YearNumericUpDown.ValueChanged += YearNumericUpDown_ValueChanged;
            this.IndexCommonUserControl.YearNumericUpDown.ValueChanged += YearNumericUpDown_ValueChanged;
            this.ForWhoCommonUserControl.YearNumericUpDown.ValueChanged += YearNumericUpDown_ValueChanged;

            //MessageBox.Show("Value changed to " + this.FreqCommonUserControl.YearNumericUpDown.Value.ToString());
            InitializeUC(RadioMode);
            GetDepartments();
        }
        #endregion

        #region InitializeUC(int Mode) - OK
        /// <summary>
        /// Inicjalizuje obiekt UserControl dla konkretnej częstoliwości czasopisma. Przyjmuje parametr "int Mode"
        /// </summary>
        /// <param name="Mode">
        /// Sposób wyświetlania danych:
        ///     1 - Pokazuje datę
        ///     2 - Pokazuje numer zeszytu
        ///     3 - Pokazuje numer kolejny
        /// </param>
        private void InitializeUC(int Mode)
        {
            if (this.Freq == 1)
            {
                this.MaxKol = DateTime.IsLeapYear((int) this.FreqCommonUserControl.YearNumericUpDown.Value) ? 366 : 365;
                this.FreqName = _translationsDictionary.ContainsKey("daily") ? _translationsDictionary["daily"] : "DZIENNIK";
                this.WindowText = _translationsDictionary.ContainsKey("daily_accession") ? _translationsDictionary["daily_accession"] : "Akcesja dziennika";

                if (FreqUC == null || !(FreqUC is DailyUserControl))
                    this.FreqUC = new DailyUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    ((DailyUserControl)this.FreqUC).LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.RadioMode);

                if (((int)this.FreqCommonUserControl.YearNumericUpDown.Value % 4 == 0 && (int)this.FreqCommonUserControl.YearNumericUpDown.Value % 100 != 0 || (int)this.FreqCommonUserControl.YearNumericUpDown.Value % 400 == 0))
                {
                    if (this.IndexUC == null)
                        this.IndexUC = new IndexUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, 366, this.SygnaturaTextBox.Text, this.id_cza_syg);
                    else
                        this.IndexUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 366, this.RadioMode);
                }
                else
                {
                    if (this.IndexUC == null)
                        this.IndexUC = new IndexUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, 365, this.SygnaturaTextBox.Text, this.id_cza_syg);
                    else
                        this.IndexUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 365, this.RadioMode);
                }
            }
            else if (this.Freq == 2)
            {
                this.MaxKol = 53;
                this.FreqName = _translationsDictionary.ContainsKey("weekly") ? _translationsDictionary["weekly"] : "TYGODNIK";
                this.WindowText = _translationsDictionary.ContainsKey("weekly_accession") ? _translationsDictionary["weekly_accession"] : "Akcesja tygodnika";

                if (FreqUC == null || !(FreqUC is WeeklyUserControl))
                    this.FreqUC = new WeeklyUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                {
                    this.FreqUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 53, this.RadioMode);

                    ((WeeklyUserControl)this.FreqUC).Render();
                }

                if (this.IndexUC == null)
                    this.IndexUC = new IndexUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, 53, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.IndexUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 53, this.RadioMode);
            }
            else if (this.Freq == 3)
            {
                this.MaxKol = 27;
                this.FreqName = _translationsDictionary.ContainsKey("biweekly") ? _translationsDictionary["weekly"] : "DWUTYGODNIK";
                this.WindowText = _translationsDictionary.ContainsKey("biweekly_accesion") ? _translationsDictionary["biweekly_accesion"] : "Akcesja dwutygodnika";

                if (FreqUC == null || !(FreqUC is BiWeeklyUserControl))
                    this.FreqUC = new BiWeeklyUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.FreqUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 27, this.RadioMode);
                
                if (this.IndexUC == null)
                    this.IndexUC = new IndexUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, 27, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.IndexUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 27, this.RadioMode);
            }
            else if (this.Freq == 4)
            {
                this.MaxKol = 12;
                this.FreqName = _translationsDictionary.ContainsKey("monthly") ? _translationsDictionary["monthly"] : "MIESIĘCZNIK";
                this.WindowText = _translationsDictionary.ContainsKey("monthly_accession") ? _translationsDictionary["monthly_accession"] : "Akcesja miesięcznika";

                if (FreqUC == null || !(FreqUC is MonthlyUserControl))
                    this.FreqUC = new MonthlyUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.FreqUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 12, this.RadioMode);

                if (this.IndexUC == null)
                    this.IndexUC = new IndexUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, 12, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.IndexUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 12, this.RadioMode);
            }
            else if (this.Freq == 5)
            {
                this.MaxKol = 6;
                this.FreqName = _translationsDictionary.ContainsKey("bimonthly") ? _translationsDictionary["bimonthly"] : "DWUMIESIĘCZNIK";
                this.WindowText = _translationsDictionary.ContainsKey("bimonthly_accession") ? _translationsDictionary["bimonthly_accession"] : "Akcesja dwumiesięcznika";

                if (FreqUC == null || !(FreqUC is BiMonthlyUserControl))
                    this.FreqUC = new BiMonthlyUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.FreqUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 6, this.RadioMode); 

                if (this.IndexUC == null)
                    this.IndexUC = new IndexUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, 6, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.IndexUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 6, this.RadioMode);
            }
            else if (this.Freq == 6)
            {
                this.MaxKol = 4;
                this.FreqName = _translationsDictionary.ContainsKey("quarterly") ? _translationsDictionary["quarterly"] : "KWARTALNIK";
                this.WindowText = _translationsDictionary.ContainsKey("quartely_accession") ? _translationsDictionary["quartely_accession"] : "Akcesja kwartalnika";

                if (FreqUC == null || !(FreqUC is QuartelyUserControl))
                    this.FreqUC = new QuartelyUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.FreqUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 4, this.RadioMode); 

                if (this.IndexUC == null)
                    this.IndexUC = new IndexUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, 4, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.IndexUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 4, this.RadioMode);
            }
            else if (this.Freq == 7)
            {
                this.MaxKol = 2;
                this.FreqName = _translationsDictionary.ContainsKey("half_yearly") ? _translationsDictionary["half_yearly"] : "PÓŁROCZNIK";
                this.WindowText = _translationsDictionary.ContainsKey("hal_yearly_accession") ? _translationsDictionary["hal_yearly_accession"] : "Akcesja półrocznika";

                if (FreqUC == null || !(FreqUC is HalfYearlyUserControl))
                    this.FreqUC = new HalfYearlyUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.FreqUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 2, this.RadioMode); 

                if (this.IndexUC == null)
                    this.IndexUC = new IndexUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, 2, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.IndexUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 2, this.RadioMode);
            }
            else if (this.Freq == 8)
            {
                this.MaxKol = 1;
                this.FreqName = _translationsDictionary.ContainsKey("yearly") ? _translationsDictionary["yearly"] : "ROCZNIK";
                this.WindowText = _translationsDictionary.ContainsKey("yearly_accession") ? _translationsDictionary["yearly_accession"] : "Akcesja rocznika";

                if (FreqUC == null || !(FreqUC is YearlyUserControl))
                    this.FreqUC = new YearlyUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.FreqUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 1, this.RadioMode); 

                if (this.IndexUC == null)
                    this.IndexUC = new IndexUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, 1, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    this.IndexUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 1, this.RadioMode);
            }
            else if (this.Freq == 9)
            {
                this.MaxKol = 9000;
                this.FreqName = _translationsDictionary.ContainsKey("irregular") ? _translationsDictionary["irregular"] : "NIEREGULARNE";
                this.WindowText = _translationsDictionary.ContainsKey("irregular_accession") ? _translationsDictionary["irregular_accession"] : "Akcesja czasopisma nieregularnego";

                if (FreqUC == null || !(FreqUC is IrregularUserControl))
                    this.FreqUC = new IrregularUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, this.SygnaturaTextBox.Text, this.id_cza_syg);
                else
                    ((IrregularUserControl)this.FreqUC).LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.RadioMode);

                if (this.IndexUC == null)
                    this.IndexUC = new IndexUserControl(this.Title, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, this.AkcesjaCode, this.CzasopCode, this.RadioMode, VolumesMode, 9000, this.SygnaturaTextBox.Text, this.id_cza_syg);                
                else
                    this.IndexUC.LoadNewData((int)this.FreqCommonUserControl.YearNumericUpDown.Value, 9000, this.RadioMode);
            }

            this.FreqUC.Location = new Point(8, 162);
            this.FreqUC.Show();
           
            this.IndexUC.Location = new Point(8, 60);
            this.IndexUC.Show();

            if (!this.MainTabControl.TabPages[0].Controls.Contains(FreqUC))
                this.MainTabControl.TabPages[0].Controls.Add(FreqUC);
            
            if (!this.MainTabControl.TabPages[0].Controls.Contains(IndexUC))
                this.MainTabControl.TabPages["Indexes"].Controls.Add(IndexUC);

            this.FreqUC.Lock();
            this.IndexUC.Lock();
            
            this.LockDlaKogo();
        }
        #endregion

        #region GetDepartments() - To TEST
        /// <summary>
        /// Pobiera departamenty i wyświetla je.
        /// </summary>
        private void GetDepartments()
        {           
            SqlCommand Command = new SqlCommand();                
            //Command.CommandText = "SELECT departam.kod_depart, id_dlakogo, LTRIM(RTRIM(departam.departam)) AS departament, dla_kogo.ilosc_egz AS ilosc FROM dla_kogo INNER JOIN departam ON dla_kogo.kod_depart = departam.kod_depart WHERE kod = ? AND rok_dep = ? ORDER BY departam.departam";
            Command.CommandText = "EXEC Akcesja_DepartamentyKarty @kod, @rok_dep; ";
                
            Command.Parameters.AddWithValue("@kod", AkcesjaCode);
            Command.Parameters.AddWithValue("@rok_dep", ForWhoCommonUserControl.YearNumericUpDown.Value);

            DepartmentDGV.DataSource = CommonFunctions.ReadData(Command, ref Settings.Connection);           

            if (DepartmentDGV.Rows.Count > 0 && CurrentDepartMode != (int)DepartModeEnum.EDIT)
            {
                DepartmentDGV.Rows[0].Cells[iloscDGVC.Name].Selected = true;
                FillDepartmentTextBox(DepartmentDGV.Rows[0].Cells[departamentDGVC.Name].Value.ToString());
            }
            else
            {
                DepartmentTextBox.Text = "";
                NumberNumericUpDown.Value = 0;
                DeleteButton.Enabled = false;
            }
        }
        #endregion

        #region ExitButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        /// Zamyka okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region DeleteButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        ///     Obsługuje przycisk usuwania departamentu. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            string message = _translationsDictionary.ContainsKey("do_you_want_to_delete_department") ? _translationsDictionary["do_you_want_to_delete_department"] : "Czy usunąć departament?";
            string caption = _translationsDictionary.ContainsKey("department_deleting") ? _translationsDictionary["department_deleting"] : "Usuwanie departamentu";

            //if (MessageBox.Show("Czy usunąć departament?", "Usuwanie departamentu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                DeleteDepartment();

                FillDepartmentTextBox("");
            }
        }
        #endregion

        #region DeleteDepartment() - To TEST
        /// <summary>
        ///     Usuwa departament.
        /// </summary>
        private void DeleteDepartment()
        {
            SqlCommand Command = new SqlCommand();
            //Command.CommandText = "DELETE FROM dla_kogo WHERE kod = ? AND rok_dep = ? AND kod_depart = ?";
            Command.CommandText = "EXEC Akcesja_UsunDepartamentKarty @kod, @rok_dep, @kod_depart; ";

            Command.Parameters.AddWithValue("@kod", AkcesjaCode);
            Command.Parameters.AddWithValue("@rok_dep", ForWhoCommonUserControl.YearNumericUpDown.Value);
            Command.Parameters.AddWithValue("@kod_depart", DepartmentDGV.SelectedRows[0].Cells[0].Value);

            if (CommonFunctions.WriteData(Command, ref Settings.Connection))
            {
                GetDepartments();
                string message = _translationsDictionary.ContainsKey("department_has_been_deleted") ? _translationsDictionary["department_has_been_deleted"] : "Departament został usunięty.";
                string caption = _translationsDictionary.ContainsKey("deleting") ? _translationsDictionary["deleting"] : "Usuwanie";

                //MessageBox.Show("Departament został usunięty.", "Usuwanie departamentu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }            
        }
        #endregion

        #region NewButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        ///     Obsługuje dodanie nowego departamentu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewButton_Click(object sender, EventArgs e)
        {
            CurrentDepartMode = (int)DepartModeEnum.ADD;
            DepartmentDGV.Enabled = false;

            DepartmentTextBox.ReadOnly = false;
            SelectButton.Enabled = true;
            NumberNumericUpDown.Enabled = true;
            OKButton.Enabled = true;
            CancelButton.Enabled = true;
            DeleteButton.Enabled = false;
            NewButton.Enabled = false;
            EditButton.Enabled = false;

            DepartmentTextBox.Text = "";
            NumberNumericUpDown.Value = 1;
        }
        #endregion

        #region CancelButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        ///     Obsługuje przycisk anulowania.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DepartmentTextBox.ReadOnly = true;
            SelectButton.Enabled = false;
            NumberNumericUpDown.Enabled = false;
            OKButton.Enabled = false;
            CancelButton.Enabled = false;
            DeleteButton.Enabled = true;
            NewButton.Enabled = true;

            CurrentDepartMode = (int)DepartModeEnum.NONE;
            DepartmentDGV.Enabled = true;

            FillDepartmentTextBox("");
        }
        #endregion

        #region FillDepartmentTextBox(string Crit) - OK
        /// <summary>
        ///     Wypełnia textboxy z departamentem.
        /// </summary>
        private void FillDepartmentTextBox(string Crit)
        {
            if (DepartmentDGV.SelectedRows.Count > 0)
            {
                for (int i = 0; i < DepartmentDGV.Rows.Count; i++)
                {
                    if (DepartmentDGV.Rows[i].Cells[departamentDGVC.Name].Value.ToString() == Crit)
                    {
                        DepartmentDGV.ClearSelection();
                        DepartmentDGV.Rows[i].Cells[departamentDGVC.Name].Selected = true;
                    }
                }

                if (CurrentDepartMode != (int)DepartModeEnum.EDIT)
                {
                    DeleteButton.Enabled = true;
                    EditButton.Enabled = true;

                    DepartmentTextBox.Text = DepartmentDGV.SelectedRows[0].Cells[departamentDGVC.Name].Value.ToString();
                    NumberNumericUpDown.Value = Decimal.Parse(DepartmentDGV.SelectedRows[0].Cells[iloscDGVC.Name].Value.ToString());
                }
            }
            else
            {
                if (CurrentDepartMode != (int)DepartModeEnum.EDIT)
                {
                    DeleteButton.Enabled = false;
                    EditButton.Enabled = false;
                }

                DepartmentTextBox.Text = "";
                NumberNumericUpDown.Value = 1;
            }
        }
        #endregion

        #region SelectButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        ///     Obsługuje przycisk SelectButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectButton_Click(object sender, EventArgs e)
        {
            InitShowForm("");   
        }
        #endregion

        #region DepartmentTextBox_KeyDown(object sender, KeyEventArgs e) - OK
        /// <summary>
        ///     Obsługuje wejście do listy z departamentami poprzez naciśnięcie Entera w TextBoxie z nazwą departamentu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DepartmentTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                InitShowForm(DepartmentTextBox.Text);
            }
        }
        #endregion

        #region InitShowForm(string Crit) - To TEST
        /// <summary>
        /// Inicjuje i otwiera okno z wyborem departementu.
        /// </summary>
        /// <param name="Crit">Ciąg znaków, wg których ma wyszukiwać w DataGridView.</param>
        private void InitShowForm(string Crit)
        {
            //string Query = "SELECT kod_depart as [id], LTRIM(RTRIM(departam)) AS [Departament] FROM departam ORDER BY departam;";

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Akcesja_ListaDepartamentow; ";

            DataGridViewColumn[] Columns = new DataGridViewColumn[2];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "departament";
            Columns[1].Name = "departament";
            Columns[1].HeaderText = _translationsDictionary.ContainsKey("department") ? _translationsDictionary["department"] : "Departament";
            
            ShowForm SF = new ShowForm(Command, Columns, Crit,  "departament", "departament");            

            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DepartmentID = Int32.Parse(SF.DGVRow.Cells["id"].Value.ToString());
                DepartmentTextBox.Text = SF.DGVRow.Cells["departament"].Value.ToString();
            }
            else
            {
                DepartmentID = -1;
            }

            DepartmentTextBox.Text = DepartmentTextBox.Text.Trim();
            DepartmentTextBox.Focus();
            DepartmentTextBox.Select(DepartmentTextBox.Text.Length, 0);
        }
        #endregion

        #region OKButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        /// Osbługuje przycisk zatwierdzenia edycji lub dodania
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DepartmentTextBox.Text))
            {
                string message = _translationsDictionary.ContainsKey("name_of_the_department_is_required") ? _translationsDictionary["name_of_the_department_is_required"] : "Nazwa departamentu jest wymagana!";
                string caption = _translationsDictionary.ContainsKey("to_correct_data") ? _translationsDictionary["to_correct_data"] : "Popraw dane";

               // MessageBox.Show("Nazwa departamentu jest wymagana!", "Popraw dane", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string TempName = DepartmentTextBox.Text;

            if (CurrentDepartMode == (int)DepartModeEnum.ADD)
            {
                if (!IsDepartmentInDb())
                {
                    string message = _translationsDictionary.ContainsKey("department_not_found_add_it") ? _translationsDictionary["department_not_found_add_it"] : "Nie znaleziono takiego departamentu na liście. Czy go dopisać?";
                    string caption = _translationsDictionary.ContainsKey("department_not_found") ? _translationsDictionary["department_not_found"] : "Brak departamentu";

                    //if (MessageBox.Show("Nie znaleziono takiego departamentu na liście. Czy go dopisać?", "Brak departamentu.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        SetDepartment();
                }
                else if (IsDepartmentForCodeYear())
                {
                    string message = _translationsDictionary.ContainsKey("deparment_for_the_magazine_and_year_already_exists") ? _translationsDictionary["deparment_for_the_magazine_and_year_already_exists"] : "Departament dla tego czasopisma i roku już istnieje.";
                    string caption = _translationsDictionary.ContainsKey("to_correct_data") ? _translationsDictionary["to_correct_data"] : "Popraw dane";

                    //MessageBox.Show("Departament dla tego czasopisma i roku już istnieje.", "Popraw dane", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    SetDepartment();
            }
            else if (CurrentDepartMode == (int)DepartModeEnum.EDIT)
            {
                UpdateDepartment();
            }

            CurrentDepartMode = (int)DepartModeEnum.NONE;

            GetDepartments();

            DepartmentTextBox.ReadOnly = true;
            SelectButton.Enabled = false;
            NumberNumericUpDown.Enabled = false;
            OKButton.Enabled = false;
            CancelButton.Enabled = false;
            DeleteButton.Enabled = true;
            NewButton.Enabled = true;

            DepartmentDGV.Enabled = true;

            FillDepartmentTextBox(TempName);
        }
        #endregion

        #region IsDepartmentForCodeYear() - To TEST
        /// <summary>
        ///     Sprawdza, czy departament istnieje już dla danego kodu czasopisma i roku.
        /// </summary>
        /// <returns>
        ///     true - jeśli istnieje
        ///     false - jeśli nie istnieje
        /// </returns>
        private bool IsDepartmentForCodeYear()
        {
            SqlCommand Command = new SqlCommand();

            /*Command.CommandText = "DECLARE @kod_depart varchar(80); \n" +
                                    "SELECT @kod_depart = departam.kod_depart FROM departam WHERE departam = @departam; \n" +
                                    "SELECT id_dlakogo FROM dla_kogo WHERE kod = @kod AND rok_dep = @rok_dep AND kod_depart = @kod_depart; \n";*/
            Command.CommandText = "EXEC Akcesja_SprawdzDepartamentIstniejeDlaKarty @kod, @rok_dep, @DepartmentID; ";            

            //Command.Parameters.AddWithValue("@departam", DepartmentTextBox.Text);
            Command.Parameters.AddWithValue("@DepartmentID", this.DepartmentID);
            Command.Parameters.AddWithValue("@kod", this.AkcesjaCode);
            Command.Parameters.AddWithValue("@rok_dep", this.ForWhoCommonUserControl.YearNumericUpDown.Value);

            return CommonFunctions.ReadData(Command, ref Settings.Connection).Rows.Count > 0;
        }
        #endregion

        #region IsDepartmentInDb() - To TEST
        /// <summary>
        /// Sprawdza, czy istnieje departament w bazie.
        /// </summary>
        /// <returns>
        /// true - jeśli istnieje
        /// false - jeśli nie istnieje
        /// </returns>
        private bool IsDepartmentInDb()
        {
            SqlCommand Command = new SqlCommand();

            //Command.CommandText = "SELECT kod_depart FROM departam WHERE departam.departam = @departam; ";
            Command.CommandText = "EXEC Akcesja_SprawdzDepartamentIstnieje @departam; ";

            Command.Parameters.AddWithValue("@departam", DepartmentTextBox.Text.Trim());

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {
                DepartmentID = Int32.Parse(Dt.Rows[0][0].ToString());
                return true;
            }

            return false;
        }
        #endregion

        #region SetDepartment() - To TEST
        /// <summary>
        /// Dodaje departament.
        /// </summary>
        private void SetDepartment()
        {
            SqlCommand Command = new SqlCommand();
            /*
                * 1. @p_DepartmentName - nazwa departamentu
                * 2. @p_Code - kod czasopima
                * 3. @p_rok - rok
                * 4. @p_ilosc_egz - ilość egzemplarzy
                * 5. @p_user - nazwa użytkownika
                * 
                */

            Command.CommandText = "EXEC SetDepartment @p_DepartmentName, @p_Code, @p_rok, @p_ilosc_egz, @p_DepartmentID; ";

            Command.Parameters.AddWithValue("@p_DepartmentName", DepartmentTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@p_Code", this.AkcesjaCode);
            Command.Parameters.AddWithValue("@p_rok", this.ForWhoCommonUserControl.YearNumericUpDown.Value);
            Command.Parameters.AddWithValue("@p_ilosc_egz", NumberNumericUpDown.Value);
            Command.Parameters.AddWithValue("@p_DepartmentID", this.DepartmentID);

            if(CommonFunctions.WriteData(Command, ref Settings.Connection))
            {
                string message = _translationsDictionary.ContainsKey("department_added") ? _translationsDictionary["department_added"] : "Departament został pomyślnie dodany.";

                //MessageBox.Show("Departament został pomyślnie dodany.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OKButton.Enabled = false;
                CancelButton.Enabled = false;
                NewButton.Enabled = true;
                DeleteButton.Enabled = true;
            }             
        }
        #endregion

        #region UpdateDepartment() - To TEST
        /// <summary>
        ///     Aktualizuje ilość egzemplarzy dla danego id_dlakogo.
        /// </summary>
        private void UpdateDepartment()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Akcesja_ModyfikacjaDepartamentuKarty @ilosc_egz, @id_dlakogo; ";

            Command.Parameters.AddWithValue("@ilosc_egz", NumberNumericUpDown.Value);
            Command.Parameters.AddWithValue("@id_dlakogo", DepartmentDGV.SelectedRows[0].Cells[id_dlakogoDGVC.Name].Value);

            if(CommonFunctions.WriteData(Command, ref Settings.Connection))
            {
                string message = _translationsDictionary.ContainsKey("updated") ? _translationsDictionary["updated"] : "Dane zostały pomyślnie zaktualizowane.";

                //MessageBox.Show("Dane zostały pomyślnie zaktualizowane.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                OKButton.Enabled = false;
                CancelButton.Enabled = false;
                NewButton.Enabled = true;
                DeleteButton.Enabled = true;
            }
        }
        #endregion

        #region EditButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        /// Obsługuje przycisk edycji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, EventArgs e)
        {
            CurrentDepartMode = (int)DepartModeEnum.EDIT;

            NumberNumericUpDown.Enabled = true;
            OKButton.Enabled = true;
            CancelButton.Enabled = true;
            DeleteButton.Enabled = false;
            NewButton.Enabled = false;
            EditButton.Enabled = false;

            DepartmentDGV.Enabled = false;
        }
        #endregion

        #region LockDlaKogo() - OK
        private void LockDlaKogo()
        {
            if (Settings.ReadOnlyMode)
            {
                foreach (Control Ctrl in this.MainTabControl.TabPages["ForWho"].Controls)
                {
                    if (!(Ctrl is DataGridView) && !(Ctrl is CommonUserControl))
                        Ctrl.Enabled = false;

                }
            }
            else if (Settings.ReadOnlyModeForCatalog)
            {
                NewButton.Visible = false;
                EditButton.Visible = false;
                DeleteButton.Visible = false;
                OKButton.Visible = false;
                CancelButton.Visible = false;

                SelectButton.Visible = false;
            }
        }
        #endregion

        #region DepartmentDGV_CellClick(object sender, DataGridViewCellEventArgs e) - OK
        private void DepartmentDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DepartmentDGV.CurrentRow != null)
                FillDepartmentTextBox(DepartmentDGV.CurrentRow.Cells[departamentDGVC.Name].Value.ToString());

            this.LockDlaKogo();
        }
        #endregion

        #region DepartmentDGV_KeyDown(object sender, KeyEventArgs e) - OK
        private void DepartmentDGV_KeyDown(object sender, KeyEventArgs e)
        {
            if (DepartmentDGV.CurrentRow != null)
                FillDepartmentTextBox(DepartmentDGV.CurrentRow.Cells[departamentDGVC.Name].Value.ToString());

            this.LockDlaKogo();
        }
        #endregion

        #region AkcesjaDetailsForm_FormClosing(object sender, FormClosingEventArgs e) - OK
        private void AkcesjaDetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this._parent.Enabled = true;
            this._parent.Focus();
        }
        #endregion

        private void separateNumbersButton_Click(object sender, EventArgs e)
        {            
            SeparateNumbersForm SNF = new SeparateNumbersForm(id_cza_syg, (int)this.FreqCommonUserControl.YearNumericUpDown.Value, AkcesjaCode, CzasopCode, MaxKol, VolumesMode, this);
            SNF.Show();
        }
    }
}
