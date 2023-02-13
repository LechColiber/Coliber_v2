//dodawanie karty akcesji - "nowa karta"
//Akcesja modyfikacja - "dopisz..."
//Usuwanie karty akcesji - "usuń..."
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using Wypozyczalnia;

namespace Akcesja
{
    public partial class AkcesjaForm : Form
    {
        Dictionary<int, string> FreqComboBoxValuesDictionary;
        Dictionary<int, string> RewritingValuesDictionary;
        private string Comments;
        private string czasop_kod;
        private string AkcesjaCode;
        private string ID_Kolport;
        private string Mode;
        private CommentsForm Comm;
        private enum FormActivate
        {
            faMainForm, faCommentsForm
        };

        private FormActivate ActiveReason;
        private Dictionary<string, string> _translationsDictionary;

        /// <summary>
        /// Konstruktor Akcesji.
        /// </summary>
        /// <param name="id_rodzaj">
        ///     id_rodzaj inwentarza.
        /// </param>
        /// <param name="Mode">
        ///     Tryb działania programu:
        ///         1. "nowa_karta" - można dodać tylko nową kartę akcesji
        ///         2. "dopisz" - można dopisywać numery akcesyjne
        ///         3. "usun" - można tylko usunąć akcesję
        /// </param>
        public AkcesjaForm(int id_rodzaj, string Mode, string employeeID, Form mdiParent)
        {
            InitializeComponent();

            setControlsText();

            ActiveReason = FormActivate.faMainForm;

            this.MdiParent = mdiParent;
            
            //Pobiera ConnectionString
            IniFile Configs = new IniFile("coliber.ini", "coliber", false);

            Settings.SetSettings(Configs.ReadIni("SqlServer", "ConnectionString"), id_rodzaj);

            Settings.employeeID = employeeID;

            //Generuje słownik częstotliwości            
            FreqComboBoxValuesDictionary = new Dictionary<int, string>();
            GenerateFreqComboBoxValues();
            FreqComboBox.DataSource = new BindingSource(FreqComboBoxValuesDictionary, null);
            FreqComboBox.ValueMember = "Key";
            FreqComboBox.DisplayMember = "Value";

            //Generuje słownik z wartościami dla przepisywania numerów akcesyjnych
            RewritingValuesDictionary = new Dictionary<int, string>();
            GenerateNumbers();
            RewritingNumbersComboBox.DataSource = new BindingSource(RewritingValuesDictionary, null);
            RewritingNumbersComboBox.ValueMember = "Key";
            RewritingNumbersComboBox.DisplayMember = "Value";

            Comments = "";

            this.Mode = Mode;

            InitModule(true);

            SetToolTips();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(titleLabel, "title");
            mapping.Add(instituteLabel, "institute");
            mapping.Add(seatLabel, "seat");
            mapping.Add(freqLabel, "frequency");
            mapping.Add(supplierLabel, "supplier");
            mapping.Add(mergedLabel, "title_of_accession_magazine");

            mapping.Add(CommentsCheckBox, "comments");
            mapping.Add(groupBox1, "signatures");
            mapping.Add(rewritingLabel, "rewriting_accession_numbers");

            mapping.Add(AkcesjaButton, "accession");

            mapping.Add(DeleteButton, "delete");
            mapping.Add(OKButton, "confirm");
            mapping.Add(SearchButton, "search");
            mapping.Add(ExitButton, "exit");

            mapping.Add(this, "accession");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void InitModule(bool first)
        {
            if (Mode.ToLower().Trim() == "nowa_karta")
            {
                Settings.ReadOnlyMode = false;

                AkcesjaButton.Enabled = false;

                this.Text = _translationsDictionary.ContainsKey("adding_accession") ? _translationsDictionary["adding_accession"] : "Dodawanie karty akcesji";

                this.Show();
            }
            else if (Mode.ToLower().Trim() == "dopisz")
            {
                this.Text = _translationsDictionary.ContainsKey("accession_modify") ? _translationsDictionary["accession_modify"] : "Akcesja - modyfikacja";
                OKButton.Text = _translationsDictionary.ContainsKey("update_numbers") ? _translationsDictionary["update_numbers"] : "Aktualizuj numery";

                Settings.ReadOnlyMode = false;
                AkcesjaButton.Enabled = true;

                //ShowList(Query, "", "dopisz", true, mdiParent);
                if(first)
                    ShowListWithAkcesja(true);
            }
            else if (Mode.ToLower().Trim() == "usun")
            {
                Settings.ReadOnlyMode = true;
                AkcesjaButton.Enabled = true;
                RewritingNumbersComboBox.Enabled = false;

                OKButton.Visible = false;
                DeleteButton.Visible = true;
                DeleteButton.Location = OKButton.Location;

                this.Text = _translationsDictionary.ContainsKey("deleting_accession") ? _translationsDictionary["deleting_accession"] : "Usuwanie karty akcesji";

                //ShowList(Query, "", "dopisz", true, mdiParent);
                if (first)
                    ShowListWithAkcesja(true);
            }
        }

        public AkcesjaForm(int id_rodzaj, string Mode, DataGridViewRow DGVRow, string employeeID, Form mdiParent) : this(id_rodzaj, Mode, employeeID, mdiParent)
        {
            LoadDataIntoControls(DGVRow);
        }

        #region SetToolTips() - OK
        /// <summary>
        ///     Ustawia ToolTip na ShowListButton
        /// </summary>
        private void SetToolTips()
        {
            ToolTip ShowListButtonToolTip = new ToolTip();
            ShowListButtonToolTip.SetToolTip(ShowListButton, _translationsDictionary.ContainsKey("list_of_magazines") ? _translationsDictionary["list_of_magazines"] : "Lista tytułów czasopism");
        }
        #endregion

        #region GenerateFreqComboBoxValues() - OK
        /// <summary>
        ///     Częstotliwość - generowanie wartości
        /// </summary>
        private void GenerateFreqComboBoxValues()
        {
            FreqComboBoxValuesDictionary.Add(1, _translationsDictionary.ContainsKey("daily") ? _translationsDictionary["daily"] : "DZIENNIK");
            FreqComboBoxValuesDictionary.Add(2, _translationsDictionary.ContainsKey("weekly") ? _translationsDictionary["weekly"] : "TYGODNIK");
            FreqComboBoxValuesDictionary.Add(3, _translationsDictionary.ContainsKey("biweekly") ? _translationsDictionary["biweekly"] : "DWUTYGODNIK");
            FreqComboBoxValuesDictionary.Add(4, _translationsDictionary.ContainsKey("monthly") ? _translationsDictionary["monthly"] : "MIESIĘCZNIK");
            FreqComboBoxValuesDictionary.Add(5, _translationsDictionary.ContainsKey("bimonthly") ? _translationsDictionary["bimonthly"] : "DWUMIESIĘCZNIK");
            FreqComboBoxValuesDictionary.Add(6, _translationsDictionary.ContainsKey("quartely") ? _translationsDictionary["quartely"] : "KWARTALNIK");
            FreqComboBoxValuesDictionary.Add(7, _translationsDictionary.ContainsKey("half_yearly") ? _translationsDictionary["half_yearly"] : "PÓŁROCZNIK");
            FreqComboBoxValuesDictionary.Add(8, _translationsDictionary.ContainsKey("yearly") ? _translationsDictionary["yearly"] : "ROCZNIK");
            FreqComboBoxValuesDictionary.Add(9, _translationsDictionary.ContainsKey("irregular") ? _translationsDictionary["irregular"] : "NIEREGULARNE");
        }
        #endregion

        #region GenerateNumbers() - OK
        /// <summary>
        ///     Przypisywanie numerów akcesyjnych - generowanie wartości
        /// </summary>
        private void GenerateNumbers()
        {
            RewritingValuesDictionary.Add(1, _translationsDictionary.ContainsKey("not_to_prescribe") ? _translationsDictionary["not_to_prescribe"] : "NIE PRZEPISYWAĆ");
            RewritingValuesDictionary.Add(2, _translationsDictionary.ContainsKey("notebook_number") ? _translationsDictionary["notebook_number"].ToUpper() : "NUMER ZESZYTU");
            RewritingValuesDictionary.Add(3, _translationsDictionary.ContainsKey("absolute_number") ? _translationsDictionary["absolute_number"].ToUpper() : "NUMER KOLEJNY");
        }
        #endregion

        #region ShowListButton_Click(object sender, EventArgs e) - To TEST
        /// <summary>
        ///     Pobieranie danych akcesji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowListButton_Click(object sender, EventArgs e)
        {
            if (Mode.ToLower().Trim() == "dopisz" || Mode.ToLower().Trim() == "usun")
            {
                /*string Query = " SELECT akcesja.kod AS [id], czasop.kod as [id2], LTRIM(RTRIM(akcesja.tytul)) AS [Tytuł akcesji], LTRIM(RTRIM(akc_syg.syg)) AS [Sygnatura], LTRIM(RTRIM(akcesja.nazwa_inst)) AS [Instytucja sprawcza], LTRIM(RTRIM(akcesja.siedziba)) AS [Siedziba], akcesja.id_kolport, akcesja.id_czest, akcesja.id_akces, akcesja.uwagi, LTRIM(RTRIM(kolport.nazwa_k)) AS [Dostawca] FROM akcesja " +                               
                               " LEFT JOIN czasop ON czasop.kod = akcesja.nr_czasop " +
                               " LEFT JOIN kolport ON kolport.id_kolport = akcesja.id_kolport " +
                               " LEFT JOIN akc_syg ON akc_syg.kod = akcesja.kod ORDER BY [Tytuł akcesji], [Sygnatura]";*/

                ShowListWithAkcesja(false);
            }
            else
            {
                /*string Query = " SELECT czasop.kod AS [id2], LTRIM(RTRIM(czasop.tytul)) AS [Tytuł czasopisma], LTRIM(RTRIM(cza_syg.syg)) AS [Sygnatura], LTRIM(RTRIM(nazwa_inst)) AS [Instytucja sprawcza], LTRIM(RTRIM(siedziba)) AS [Siedziba], " +
                               " id_czest, LTRIM(RTRIM(kolport.nazwa_k)) AS [Dostawca], '' AS uwagi, czasop.id_kolport FROM czasop " +
                               " LEFT JOIN cza_syg ON czasop.kod = cza_syg.kod " +
                               " LEFT JOIN kolport ON kolport.id_kolport = czasop.id_kolport " +                               
                               " WHERE (czasop.kod NOT IN (SELECT nr_czasop FROM akcesja) AND id_rodzaj = ?) ORDER BY [Tytuł czasopisma], [Sygnatura]; ";*/

                ShowMagazinesList(false);
            }
        }
        #endregion

        #region ShowListWithAkcesja(bool First) - To TEST
        private void ShowListWithAkcesja(bool First)
        {
            SqlCommand Query = new SqlCommand();
            Query.CommandText = "EXEC Akcesja_ListaAkcesji @id_rodzaj, '', @sort; ";
            Query.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
            Query.Parameters.AddWithValue("@sort", 1);

            ShowList(Query, "", "dopisz", First, this.MdiParent);
        }
        #endregion

        #region ShowMagazinesList(bool First) - to TEST
        private void ShowMagazinesList(bool First)
        {
            SqlCommand Query = new SqlCommand();
            Query.CommandText = "EXEC Akcesja_ListaCzasopismBezAkcesji @id_rodzaj, '', @sort; ";
            Query.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
            Query.Parameters.AddWithValue("@sort", 1);

            ShowList(Query, "", "nowa_karta", First, this.MdiParent);
        }
        #endregion

        #region ShowList(string Query, string Crit, string Mode, bool First) - To TEST
        /// <summary>
        ///     Wyświetla okno wyboru czasopisma.
        /// </summary>
        /// <param name="Query">Całe zapytanie</param>
        /// <param name="Crit">Kryterium do podświetlenia rekordu</param>
        /// <param name="Mode">Tryb (this.Mode)</param>
        /// <param name="First">Czy jest uruchomione z poziomu okna akcesji, czy przed wyświetleniem okna (dla dopisywania i usuwania)</param>
        private void ShowList(SqlCommand Query, string Crit, string Mode, bool First, Form mdiParent)
        {
            DataGridViewColumn[] Columns = new DataGridViewColumn[11];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "czasop_kod";
            Columns[0].Name = "czasop_kod";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "id";
            Columns[1].Name = "id";
            Columns[1].Visible = false;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "id_kolport";
            Columns[2].Name = "id_kolport";
            Columns[2].Visible = false;

            Columns[3] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[3].DataPropertyName = "tytul";
            Columns[3].Name = "tytul";
            Columns[3].HeaderText = _translationsDictionary.ContainsKey("title") ? _translationsDictionary["title"] : "Tytuł";
            Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[4] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[4].DataPropertyName = "id_czest";
            Columns[4].Name = "id_czest";
            Columns[4].Visible = false;

            Columns[5] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[5].DataPropertyName = "id_akces";
            Columns[5].Name = "id_akces";
            Columns[5].Visible = false;

            Columns[6] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[6].DataPropertyName = "dostawca";
            Columns[6].Name = "dostawca";
            Columns[6].Visible = false;

            Columns[7] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[7].DataPropertyName = "uwagi";
            Columns[7].Name = "uwagi";
            Columns[7].Visible = false;

            Columns[8] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[8].DataPropertyName = "nazwa_inst";
            Columns[8].Name = "nazwa_inst";
            Columns[8].Visible = false;

            Columns[9] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[9].DataPropertyName = "siedziba";
            Columns[9].Name = "siedziba";
            Columns[9].Visible = false;

            Columns[10] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[10].DataPropertyName = "sygnatury";
            Columns[10].Name = "sygnatury";
            Columns[10].HeaderText = _translationsDictionary.ContainsKey("signatures") ? _translationsDictionary["signatures"] : "Sygnatury";

            ShowForm Magazines = new ShowForm(Query, Columns, Crit, "", Mode);

            DialogResult DResult = Magazines.ShowDialog();

            if (DResult == System.Windows.Forms.DialogResult.OK)
            {
                LoadDataIntoControls(Magazines.DGVRow);

                if ((Mode == "dopisz" || Mode == "usun") && First)
                {
                    TitleTextBox.Select(TitleTextBox.Text.Length, 0);                    

                    this.MdiParent = mdiParent;
                    this.Show();
                }
            }

            Magazines.Close();            
        }
        #endregion

        #region LoadDataIntoControls(DataGridViewRow DGVRow) - OK
        /// <summary>
        ///     Ładuje dane do kontrolek.
        /// </summary>
        /// <param name="DGVRow">DataGridViewRow z danymi</param>
        private void LoadDataIntoControls(DataGridViewRow DGVRow)
        {
            czasop_kod = DGVRow.Cells["czasop_kod"].Value.ToString();

            ID_Kolport = DGVRow.Cells["id_kolport"].Value.ToString();

            TitleTextBox.Text = DGVRow.Cells["tytul"].Value.ToString();
            MergedMagazineTitleTextBox.Text = DGVRow.Cells["tytul"].Value.ToString();

            if (DGVRow.DataGridView.Columns.Contains("id") && DGVRow.Cells["id"].Value != null)
                AkcesjaCode = DGVRow.Cells["id"].Value.ToString();

            InstTextBox.Text = DGVRow.Cells["nazwa_inst"].Value.ToString();
            PlaceTextBox.Text = DGVRow.Cells["siedziba"].Value.ToString();
            FreqComboBox.SelectedValue = Int32.Parse(DGVRow.Cells["id_czest"].Value.ToString());

            if (DGVRow.DataGridView.Columns.Contains("id_akces") && DGVRow.Cells["id_akces"].Value != null)
                RewritingNumbersComboBox.SelectedValue = Int32.Parse(DGVRow.Cells["id_akces"].Value.ToString());

            SuppliersTextBox.Text = DGVRow.Cells["dostawca"].Value.ToString();            
            
            Comments = DGVRow.Cells["uwagi"].Value.ToString();

            CommentsCheckBox.Checked = !string.IsNullOrEmpty(Comments.Trim());

            GetSygs(czasop_kod);
        }
        #endregion

        #region GetSygs(string czasop_kod) - OK
        private void GetSygs(string czasop_kod)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_MagazineSygs @MagazineID; ";
            Command.Parameters.AddWithValue("@MagazineID", czasop_kod);

            SygsDGV.DataSource = CommonFunctions.ReadData(Command, ref Settings.Connection);
        }
        #endregion

        #region ExitButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        ///     Obsługuje przycisk wyłączania okna.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            if (TitleTextBox.Text.Trim() == "")
                this.Close();
            else if(Mode != "nowa_karta")
                this.Close();
            //else if (MessageBox.Show("Czy zamknąć okno bez zapisywania zmian?", "Zamykanie okna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            else if (MessageBox.Show(_translationsDictionary.ContainsKey("do_you_want_to_exit_without_save") ? _translationsDictionary["do_you_want_to_exit_without_save"] : "Czy zamknąć okno bez zapisywania zmian?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();            
        }
        #endregion

        #region OKButton_Click(object sender, EventArgs e) - To TEST
        /// <summary>
        ///     Obsługuje przycisk zakładania lub dopisywania akcesji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {            
            if (this.Mode == "dopisz")
            {
                ModifyAkcesja();
                return;
            }

            if (TitleTextBox.Text.Trim() == "")
            {
                string message = _translationsDictionary.ContainsKey("enter_the_title_of_the_magazine") ? _translationsDictionary["enter_the_title_of_the_magazine"] : "Wprowadź tytuł czasopisma.";
                //string caption = _translationsDictionary.ContainsKey("saved") ? _translationsDictionary["saved"] : "Wprowadzanie tytułu czasopisma";

                MessageBox.Show(message, message, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show("Wprowadź tytuł czasopisma.", "Wprowadzanie tytułu czasopisma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MergedMagazineTitleTextBox.Text.Trim() == "" || (TitleTextBox.Text.Trim() != MergedMagazineTitleTextBox.Text.Trim()))
            {
                try
                {
                    SqlCommand SearchCommand = new SqlCommand();

                    string Query = "";

                    if (Mode.ToLower().Trim() == "dopisz")
                    {
                        /*Query = " SELECT akcesja.kod AS [id], akcesja.nr_czasop AS [id2], LTRIM(RTRIM(akcesja.tytul)) AS [Tytuł akcesji], LTRIM(RTRIM(akc_syg.syg)) AS [Sygnatura], LTRIM(RTRIM(akcesja.nazwa_inst)) AS [Instytucja sprawcza], LTRIM(RTRIM(akcesja.siedziba)) AS [Siedziba], akcesja.id_kolport, akcesja.id_czest, akcesja.id_akces, akcesja.uwagi, LTRIM(RTRIM(kolport.nazwa_k)) AS [Dostawca] FROM akcesja " +                                       
                                " LEFT JOIN czasop ON czasop.kod = akcesja.nr_czasop " +
                                " LEFT JOIN kolport ON kolport.id_kolport = akcesja.id_kolport " +
                                " LEFT JOIN akc_syg ON akc_syg.kod = akcesja.kod WHERE LTRIM(RTRIM(akcesja.tytul)) = ? AND akcesja.nr_czasop != 0 ORDER BY [Tytuł akcesji], [Sygnatura]";*/
                        Query = "EXEC Akcesja_ListaAkcesji @id_rodzaj, @tytul; ";
                    }
                    else
                    {
                       /* Query = " SELECT czasop.kod AS [id2], LTRIM(RTRIM(czasop.tytul)) AS [Tytuł czasopisma], LTRIM(RTRIM(cza_syg.syg)) AS [Sygnatura], LTRIM(RTRIM(nazwa_inst)) AS [Instytucja sprawcza], LTRIM(RTRIM(siedziba)) AS [Siedziba], " +
                                " id_czest, LTRIM(RTRIM(kolport.nazwa_k)) AS [Dostawca], uwagi, czasop.id_kolport FROM czasop " +
                                " LEFT JOIN cza_syg ON czasop.kod = cza_syg.kod " +
                                " LEFT JOIN kolport ON kolport.id_kolport = czasop.id_kolport " +
                                " WHERE (czasop.kod NOT IN (SELECT kod FROM akcesja) AND id_rodzaj = ? AND LTRIM(RTRIM(czasop.tytul)) = ?) ORDER BY [Tytuł czasopisma], [Sygnatura]";   */
                        Query = "EXEC Akcesja_ListaCzasopismBezAkcesji @id_rodzaj, @tytul; ";
                    }

                    SearchCommand.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
                    SearchCommand.Parameters.AddWithValue("@tytul", TitleTextBox.Text.Trim());

                    SearchCommand.CommandText = Query;

                    DataTable SearchDt = CommonFunctions.ReadData(SearchCommand, ref Settings.Connection);

                    if (SearchDt.Rows.Count > 0)
                    {
                        czasop_kod = SearchDt.Rows[0]["czasop_kod"].ToString();
                        TitleTextBox.Text = SearchDt.Rows[0]["tytul"].ToString();
                        MergedMagazineTitleTextBox.Text = SearchDt.Rows[0]["tytul"].ToString();
                        InstTextBox.Text = SearchDt.Rows[0]["nazwa_inst"].ToString();
                        PlaceTextBox.Text = SearchDt.Rows[0]["siedziba"].ToString();
                        FreqComboBox.SelectedValue = Int32.Parse(SearchDt.Rows[0]["id_czest"].ToString());
                        SuppliersTextBox.Text = SearchDt.Rows[0]["dostawca"].ToString();
                        Comments = SearchDt.Rows[0]["uwagi"].ToString();
                        ID_Kolport = SearchDt.Rows[0]["id_kolport"].ToString();
                        CommentsCheckBox.Checked = !string.IsNullOrEmpty(Comments.Trim());

                        GetSygs(czasop_kod);
                    }
                    else
                    {
                        MessageBox.Show("Wprowadzony tytuł nie istnieje w bazie. Wprowadź poprawny tytuł.", "Popraw dane", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (this.Mode == "nowa_karta" && MergedMagazineTitleTextBox.Text.Trim() != "")
                    AddNewAkcesja();
                else if (this.Mode == "nowa_karta" && MergedMagazineTitleTextBox.Text.Trim() == "")
                    MessageBox.Show("Wprowadzony tytuł nie istnieje w bazie. Wprowadź poprawny tytuł.", "Tytuł nie istnieje", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            else if (this.Mode == "nowa_karta" && MergedMagazineTitleTextBox.Text.Trim() != "")
                AddNewAkcesja();
        }
        #endregion

        #region AddNewAkcesja() - To TEST
        /// <summary>
        ///     Funkcja zakładająca nową kartę akcesji.
        /// </summary>
        private void AddNewAkcesja()
        {
            SqlCommand Command = new SqlCommand();

            Command.CommandText = "EXEC Akcesja_DodajAkcesje @tytul, @id_czest, @uwagi, @nr_czasop, @id_akces, @id_rodzaj, @akcesja_id OUTPUT; ";

            Command.Parameters.AddWithValue("@tytul", MergedMagazineTitleTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@id_czest", FreqComboBox.SelectedValue);
            Command.Parameters.AddWithValue("@uwagi", Comments.Trim());
            Command.Parameters.AddWithValue("@nr_czasop", czasop_kod);
            Command.Parameters.AddWithValue("@id_akces", RewritingNumbersComboBox.SelectedValue);
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

            SqlParameter IdParameter = new SqlParameter();
            IdParameter.ParameterName = "@akcesja_id";
            IdParameter.SqlDbType = SqlDbType.Int;
            IdParameter.SqlValue = DBNull.Value;
            IdParameter.Direction = ParameterDirection.InputOutput;

            Command.Parameters.Add(IdParameter);
                            
            if(CommonFunctions.WriteData(ref Command, ref Settings.Connection))
            {
                string message = _translationsDictionary.ContainsKey("saved") ? _translationsDictionary["saved"] : "Dane zostały zapisane";
                string caption = _translationsDictionary.ContainsKey("data_save") ? _translationsDictionary["data_save"] : "Zapis danych";

                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessageBox.Show("Dane zostały zapisane.", "Zapis danych", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Mode = "dopisz";

                this.AkcesjaCode = Command.Parameters["@akcesja_id"].SqlValue.ToString();

                InitModule(false);
                //this.Close();
            }
        }
        #endregion

        #region ModifyAkcesja() - To TEST
        /// <summary>
        ///     Funkcja obsługująca zmianę danych akcesji.
        /// </summary>
        private void ModifyAkcesja()
        {
            WaitForm Wait = new WaitForm();

            try
            {
                SqlCommand Command = new SqlCommand();

                Command.CommandText = "EXEC Akcesja_Modyfikacja @id_akces, @kod_akcesja; " + Environment.NewLine;
                
                Command.Parameters.AddWithValue("@id_akces", RewritingNumbersComboBox.SelectedValue);
                Command.Parameters.AddWithValue("@kod_akcesja", this.AkcesjaCode);

                //Przepisywanie numerów akcesyjnych:
                // 2 - po numerze zeszytu
                // 3 - po numerze kolejnym
                // 
                // Korzysta z procedur w bazie.
                // Przyjmuje parametry:
                //     1. id woluminu
                //     2. MaxKol - ilość pól standardowych, tj. 
                //         a) dla: rocznika = 1, półrocznika = 2, kwartalnika = 4, dwumiesięcznika = 6, miesięcznika = 12, dwutygodnika = 27, tygodnika = (52 lub 53
                // ), dziennika = (365 lub 366), nieregularnego = 9000 (lub inna w zależności od ilości)
                //         b) pobierana jest ze zmiennej MaxKol
                //     3. Kod czasopisma
                //     4. Kod akcesji

                if (Int32.Parse(RewritingNumbersComboBox.SelectedValue.ToString()) != 1)
                {                    
                    RewriteNumbers t = new RewriteNumbers(czasop_kod);

                    int Freq = Int32.Parse(FreqComboBox.SelectedValue.ToString());
                    int MaxKol = 0;

                    if (Freq == 2)
                        MaxKol = 53;
                    else if (Freq == 3)
                        MaxKol = 27;
                    else if (Freq == 4)
                        MaxKol = 12;
                    else if (Freq == 5)
                        MaxKol = 6;
                    else if (Freq == 6)
                        MaxKol = 4;
                    else if (Freq == 7)
                        MaxKol = 2;
                    else if (Freq == 8)
                        MaxKol = 1;
                    else if (Freq == 9)
                        MaxKol = 9000;

                    if (t.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        if (t.DtV.Rows.Count > 0)
                        {
                            /*if (Int32.Parse(RewritingNumbersComboBox.SelectedValue.ToString()) == 2)
                            {
                                for (int i = 0; i < t.DtV.Rows.Count; i++)
                                {
                                    if (Freq == 1)
                                    {
                                        if (Int32.Parse(t.DtV.Rows[i]["Rok"].ToString()) % 4 == 0 && Int32.Parse(t.DtV.Rows[i]["Rok"].ToString()) % 100 != 0 || Int32.Parse(t.DtV.Rows[i]["Rok"].ToString()) % 400 == 0)
                                            MaxKol = 366;
                                        else
                                            MaxKol = 365;
                                    }

                                    Command.CommandText += "EXEC nr_zeszytu @volumin" + i + ", @rok" + i + ", @maxKol" + i + ", @code" + i + ", @Akcesja_code" + i + "; " + Environment.NewLine;

                                    Command.Parameters.AddWithValue("@volumin" + i, t.DtV.Rows[i]["Wolumin"].ToString());
                                    Command.Parameters.AddWithValue("@rok" + i, t.DtV.Rows[i]["Rok"].ToString());
                                    Command.Parameters.AddWithValue("@maxKol" + i, MaxKol);
                                    Command.Parameters.AddWithValue("@code" + i, czasop_kod);
                                    Command.Parameters.AddWithValue("@Akcesja_code" + i, AkcesjaCode);
                                }
                            }
                            else if (Int32.Parse(RewritingNumbersComboBox.SelectedValue.ToString()) == 3)
                            {
                                for (int i = 0; i < t.DtV.Rows.Count; i++)
                                {
                                    if (Freq == 1)
                                    {
                                        if (Int32.Parse(t.DtV.Rows[i]["Rok"].ToString()) % 4 == 0 && Int32.Parse(t.DtV.Rows[i]["Rok"].ToString()) % 100 != 0 || Int32.Parse(t.DtV.Rows[i]["Rok"].ToString()) % 400 == 0)
                                            MaxKol = 366;
                                        else
                                            MaxKol = 365;
                                    }

                                    Command.CommandText += "EXEC nr_kolejny @volumin" + i + ", @rok" + i + ", @maxKol" + i + ", @code" + i + ", @Akcesja_code" + i + "; " + Environment.NewLine;

                                    Command.Parameters.AddWithValue("@volumin" + i, t.DtV.Rows[i]["Wolumin"].ToString());
                                    Command.Parameters.AddWithValue("@rok" + i, t.DtV.Rows[i]["Rok"].ToString());
                                    Command.Parameters.AddWithValue("@maxKol" + i, MaxKol);
                                    Command.Parameters.AddWithValue("@code" + i, czasop_kod);
                                    Command.Parameters.AddWithValue("@Akcesja_code" + i, AkcesjaCode);
                                }
                            }*/

                            for (int i = 0; i < t.DtV.Rows.Count; i++)
                            {
                                if (Freq == 1)
                                {                                    
                                    if (Int32.Parse(t.DtV.Rows[i]["Rok"].ToString()) % 4 == 0 && Int32.Parse(t.DtV.Rows[i]["Rok"].ToString()) % 100 != 0 || Int32.Parse(t.DtV.Rows[i]["Rok"].ToString()) % 400 == 0)
                                        MaxKol = 366;
                                    else
                                        MaxKol = 365;
                                }

                                if (Int32.Parse(RewritingNumbersComboBox.SelectedValue.ToString()) == 2)
                                    Command.CommandText += "EXEC nr_zeszytu @id_volumes" + i + ", @maxKol" + i + ", @code" + i + ", @Akcesja_code" + i + "; " + Environment.NewLine;
                                else if (Int32.Parse(RewritingNumbersComboBox.SelectedValue.ToString()) == 3)
                                    Command.CommandText += "EXEC nr_kolejny @id_volumes" + i + ", @maxKol" + i + ", @code" + i + ", @Akcesja_code" + i + "; " + Environment.NewLine;

                                Command.Parameters.AddWithValue("@id_volumes" + i, t.DtV.Rows[i]["id_volumes"].ToString());
                                Command.Parameters.AddWithValue("@maxKol" + i, MaxKol);
                                Command.Parameters.AddWithValue("@code" + i, czasop_kod);
                                Command.Parameters.AddWithValue("@Akcesja_code" + i, AkcesjaCode);
                            }
                        }
                    }
                    else
                        return;

                    this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });
                }

                if(CommonFunctions.WriteData(Command, ref Settings.Connection))
                {
                    string message = _translationsDictionary.ContainsKey("saved") ? _translationsDictionary["saved"] : "Dane zostały zapisane";
                    string caption = _translationsDictionary.ContainsKey("data_save") ? _translationsDictionary["data_save"] : "Zapis danych";

                    MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                }            
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _translationsDictionary.ContainsKey("error") ? _translationsDictionary["error"] : "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Wait.Close();
        }
        #endregion

        #region CommentsCheckBox_Click(object sender, EventArgs e) - OK
        /// <summary>
        ///     Funkcja obsługująca CheckBox z uwagami.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentsCheckBox_Click(object sender, EventArgs e)
        {            
            ActiveReason = FormActivate.faCommentsForm;

            Comm = new CommentsForm(Comments, this, Mode == "usun");
            Comm.Show();
        }
        #endregion

        #region TitleTextBox_KeyDown(object sender, KeyEventArgs e) - To TEST
        /// <summary>
        ///     Obsługuje naciśnięcie klawisza na TitleTextBoxie. Po wciśnięciu ENTER otwiera okno wyboru:
        ///         1. dla dopisywania i usuwania wyświetla czasopisma z kartami akcesji
        ///         2. dla zakładania karty wyświetla czasopisma bez kartami akcesji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (Mode.ToLower().Trim() == "dopisz" || Mode.ToLower().Trim() == "usun")
                {
                    /*string Query = " SELECT akcesja.kod AS [id],czasop.kod AS [id2], LTRIM(RTRIM(akcesja.tytul)) AS [Tytuł akcesji], LTRIM(RTRIM(akc_syg.syg)) AS [Sygnatura], LTRIM(RTRIM(akcesja.nazwa_inst)) AS [Instytucja sprawcza], LTRIM(RTRIM(akcesja.siedziba)) AS [Siedziba], akcesja.id_kolport, akcesja.id_czest, akcesja.id_akces, akcesja.uwagi, LTRIM(RTRIM(kolport.nazwa_k)) AS [Dostawca] FROM akcesja " +                                   
                                   " LEFT JOIN czasop ON czasop.kod = akcesja.nr_czasop " +
                                   " LEFT JOIN kolport ON kolport.id_kolport = akcesja.id_kolport " +
                                   " LEFT JOIN akc_syg ON akc_syg.kod = akcesja.kod ORDER BY [Tytuł akcesji], [Sygnatura]";

                    ShowList(Query, TitleTextBox.Text.Trim(), "dopisz", false, this.MdiParent);*/

                    ShowListWithAkcesja(false);
                }
                else
                {
                    /*string Query = " SELECT czasop.kod AS [id2], LTRIM(RTRIM(czasop.tytul)) AS [Tytuł czasopisma], LTRIM(RTRIM(cza_syg.syg)) AS [Sygnatura], LTRIM(RTRIM(nazwa_inst)) AS [Instytucja sprawcza], LTRIM(RTRIM(siedziba)) AS [Siedziba], " +
                                   " id_czest, LTRIM(RTRIM(kolport.nazwa_k)) AS [Dostawca], '' AS uwagi, czasop.id_kolport FROM czasop " +
                                   " LEFT JOIN cza_syg ON czasop.kod = cza_syg.kod " +
                                   " LEFT JOIN kolport ON kolport.id_kolport = czasop.id_kolport " +
                                   " WHERE (czasop.kod NOT IN (SELECT nr_czasop FROM akcesja) AND id_rodzaj = ?) ORDER BY [Tytuł czasopisma], [Sygnatura]";


                    ShowList(Query, TitleTextBox.Text.Trim(), "nowa_karta", false, this.MdiParent);*/

                    ShowMagazinesList(false);
                }

                TitleTextBox.Text = TitleTextBox.Text.Trim();
                TitleTextBox.Focus();
                TitleTextBox.Select(TitleTextBox.Text.Length, 0);
            }
        }
        #endregion

        #region AkcesjaButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        ///  Wywołanie okienka akcesji
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>        
        private void AkcesjaButton_Click(object sender, EventArgs e)
        {
            if (SygsDGV.Rows.Count == 0)
            {
                string message = _translationsDictionary.ContainsKey("magazine_does_not_have_signature_enter_new_one") ? _translationsDictionary["magazine_does_not_have_signature_enter_new_one"] : "Czasopismo nie posiada sygnatury. Proszę najpierw wprowadzić sygnaturę na karcie głównej czasopisma, żeby prowadzić jego akcesję.";
                string caption = _translationsDictionary.ContainsKey("information") ? _translationsDictionary["information"] : "Informacja";

                //MessageBox.Show("Czasopismo nie posiada sygnatury. Proszę najpierw wprowadzić sygnaturę na karcie głównej czasopisma, żeby prowadzić jego akcesję.", "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (SygsDGV.SelectedRows.Count == 0 && SygsDGV.Rows.Count > 0)
                SygsDGV.Rows[0].Selected = true;

            AkcesjaDetailsForm Akc = new AkcesjaDetailsForm(Int32.Parse(FreqComboBox.SelectedValue.ToString()), AkcesjaCode, czasop_kod, SygsDGV.SelectedRows[0].Cells[sygnaturaDGVC.Name].Value.ToString(), this.MergedMagazineTitleTextBox.Text.Trim(), Int32.Parse(RewritingNumbersComboBox.SelectedValue.ToString()), Settings.ID_rodzaj, false, SygsDGV.SelectedRows[0].Cells[id_akc_sygDGVC.Name].Value.ToString(), this); 
            Akc.Show();
        }
        #endregion

        #region AkcesjaForm_KeyDown(object sender, KeyEventArgs e) - OK
        /// <summary>
        ///     Obsługuje naciśnięcie klawisza na całym formie. Po wciśnięciu ESCAPE zamyka okno.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AkcesjaForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ExitButton_Click(sender, e);
            }
        }
        #endregion

        #region DeleteButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        ///     Obsługuje przycisk DeleteButton, który wywołuje funkcję usuwającą kartę akcesji.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteAkcesja();
        }
        #endregion

        private DataTable IsNumberBorrowed()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Akcesja_SprawdzNumerJestWypozyczony @akcesja_kod, 3;";
            Command.Parameters.AddWithValue("@akcesja_kod", AkcesjaCode);

            return CommonFunctions.ReadData(Command, ref Settings.Connection);
        }

        #region DeleteAkcesja() - To TEST
        /// <summary>
        ///     Usuwanie akcesji.
        ///     Wykorzystuje procedurę składowaną "UsunAkcesje", która przyjmuje parametry:
        ///         1. kod czasopisma
        ///         2. nazwę użytkownika
        /// </summary>
        private void DeleteAkcesja()
        {
            DataTable Dt = IsNumberBorrowed();

            if (Dt.Rows.Count > 0)
            {
                string message = string.Format("{0} {1} {2}", _translationsDictionary.ContainsKey("there_are_borrowed_copies_in_quantities") ? _translationsDictionary["there_are_borrowed_copies_in_quantities"] : "Istnieją wypożyczone egzemplarze w ilości:", Dt.Rows.Count, _translationsDictionary.ContainsKey("do_you_want_to_return_it") ? _translationsDictionary["do_you_want_to_return_it"] : "Czy chcesz je zwrócić?");
                
                //if (MessageBox.Show(string.Format("Istnieją wypożyczone egzemplarze w ilości: {0}. Czy chcesz je zwrócić?", Dt.Rows.Count), "Zwracanie numerów", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int i = 1;
                    bool check = true;

                    foreach (DataRow row in Dt.Rows)
                    {
                        ZwrotForm zwrot = new ZwrotForm(row["wypoz_id"].ToString(), Settings.employeeID, this);
                        zwrot.Text += string.Format(" {0} z {1}", i, Dt.Rows.Count);

                        if (zwrot.ShowDialog() == DialogResult.Cancel)
                            check = false;

                        i++;
                    }

                    if(check)
                        DeleteAkcesja();
                }

                return;
            }

            string message2 = _translationsDictionary.ContainsKey("do_you_want_to_delete_accession") ? _translationsDictionary["do_you_want_to_delete_accession"] : "Czy usunąć kartę akcesji tego czasopisma? Jeśli istnieją numery w tej karcie akcesji, to zostaną usunięte!";
            string caption = _translationsDictionary.ContainsKey("deleting_accession") ? _translationsDictionary["deleting_accession"] : "Usuwanie karty akcesji";

            //if (MessageBox.Show("Czy usunąć kartę akcesji tego czasopisma? Jeśli istnieją numery w tej karcie akcesji, to zostaną usunięte!", "Usuwanie karty akcesji", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            if (MessageBox.Show(message2, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
            {                
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC UsunAkcesje @kod, @user; ";

                Command.Parameters.AddWithValue("@kod", this.AkcesjaCode);
                Command.Parameters.AddWithValue("@user", Environment.UserDomainName + "\\" + Environment.UserName);

                if (CommonFunctions.WriteData(Command, ref Settings.Connection))
                {
                    message2 = _translationsDictionary.ContainsKey("accession_has_been_deleted") ? _translationsDictionary["accession_has_been_deleted"] : "Karta akcesji została pomyślnie usunięta.";
                    caption = _translationsDictionary.ContainsKey("deleting_accession") ? _translationsDictionary["deleting_accession"] : "Usuwanie karty akcesji";

                    //MessageBox.Show("Karta akcesji została pomyślnie usunięta.", "Usuwanie karty akcesji", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show(message2, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        #endregion

        #region AkcesjaForm_Activated(object sender, EventArgs e) - OK
        private void AkcesjaForm_Activated(object sender, EventArgs e)
        {
            if (ActiveReason == FormActivate.faCommentsForm)
            {
                CommentsCheckBox.Checked = !string.IsNullOrEmpty(Comments.Trim()); //Comments.Trim() != ""; 

                if(Comm.DialogResult != DialogResult.OK)
                    return;

                Comments = Comm.textBox1.Text.Trim();

                CommentsCheckBox.Checked = !string.IsNullOrEmpty(Comments.Trim());//Comments.Trim() != ""; 

                if (Mode != "dopisz")
                    return;
                
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Akcesja_UpdateComments @kod, @uwagi; ";
                    
                Command.Parameters.AddWithValue("@kod", this.AkcesjaCode);
                Command.Parameters.AddWithValue("@uwagi", Comments);

                CommonFunctions.WriteData(Command, ref Settings.Connection);               
            }

            ActiveReason = FormActivate.faMainForm;
        }

        #endregion
    }
}
