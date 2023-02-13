using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Wypozyczalnia;

namespace Akcesja
{
    public partial class SingleNumberForm : Form
    {
        Dictionary<int, string> SposobNabyciaDictionary;
        private string Comments;
        private string KodyK;
        private string AkcesjaCode;
        private string CzasopCode;
        private int Year;
        private int Numer_z;
        private int VolumesMode;
        private bool NewNumber;
        private int Kol;
        private string Sygnatura;
        private int MaxKol;
        private string StartVolume;
        private string id_cza_syg;
        private string id_czasop_n;
        private string id_volumin;
        private string id_volumin_old;
        private Dictionary<string, string> _translationsDictionary;

        //public SingleNumberForm(string Title, int Year, string Kol, string AkcesjaCode, string CzasopCode, int VolumesMode, bool NewNumber, string Sygnatura, string id_cza_syg, int MaxKol)
        public SingleNumberForm(string Title, int Year, string Kol, string AkcesjaCode, string CzasopCode, int VolumesMode, bool NewNumber, string Sygnatura, string id_cza_syg, string id_czasop_n, int MaxKol)
        {
            InitializeComponent();

            setControlsText();

            this.TitleTextBox.Text = Title;
            this.TitleTextBox.Select(TitleTextBox.Text.Length, 0);
            this.WDateMaskedTextBox.Text = DateTime.Today.ToString("dd-MM-yyyy");
            this.NoteTextBox.Text = Kol;
            this.YearLabel.Text = Year.ToString();
            this.AkcesjaCode = AkcesjaCode;
            this.CzasopCode = CzasopCode;
            this.Year = Year;
            this.VolumesMode = VolumesMode;
            this.NewNumber = NewNumber;
            this.Comments = "";
            KodyK = "";
            this.Kol = Int32.Parse(Kol);
            this.Sygnatura = Sygnatura;
            this.MaxKol = MaxKol;
            this.id_cza_syg = id_cza_syg;
            this.id_czasop_n = id_czasop_n;
            this.id_volumin = "0";
            this.StartVolume = "";

            SposobNabyciaDictionary = new Dictionary<int, string>();
            Generate();
            SposobNabyciaComboBox.DataSource = new BindingSource(SposobNabyciaDictionary, null);
            SposobNabyciaComboBox.ValueMember = "Key";
            SposobNabyciaComboBox.DisplayMember = "Value";

            if (NewNumber)            
                DeleteButton.Enabled = false;
            else            
                GetData();            

            SetToolTips();

            if (NextTextBox.Text.Trim() == "")
                Next2TextBox.ReadOnly = true;
            
            Lock();
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(magazineTitleLabel, "magazine_title");
            mapping.Add(notebookTitleLabel, "notebook_title");

            mapping.Add(yearLlabel, "year");
            mapping.Add(volumeLabel, "volume");
            mapping.Add(notebookNumberLabel, "notebook_number");
            mapping.Add(absoluteNumberLabel, "absolute_number");
            mapping.Add(amountLabel, "amount");
            mapping.Add(methodOfAcquisitionLabel, "method_of_acquisition");
            mapping.Add(CommentsCheckBox, "comments");

            mapping.Add(amountToBorrowLabel, "amount_to_borrow");
            mapping.Add(dateOfReceiptLabel, "date_of_receipt");
            mapping.Add(dateOfComplaintLabel, "date_of_complaint");

            mapping.Add(DeleteButton, "delete");
            mapping.Add(OKButton, "confirm");
            mapping.Add(CancelButton, "cancel");

            mapping.Add(this, "single_magazine_number");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        #region SetToolTips() - OK
        private void SetToolTips()
        {
            ToolTip DeleteButtonToolTip = new ToolTip();
            DeleteButtonToolTip.SetToolTip(DeleteButton, _translationsDictionary.ContainsKey("single_number_deleting") ? _translationsDictionary["single_number_deleting"] : "Usuwanie pojedynczego numeru");

            ToolTip VolumeButtonToolTip = new ToolTip();
            VolumeButtonToolTip.SetToolTip(VolumeButton, _translationsDictionary.ContainsKey("list_of_available_volumes") ? _translationsDictionary["list_of_available_volumes"] : "Lista dostępnych woluminów");
        }
        #endregion

        #region GetData() - To TEST
        private void GetData()
        {
            try
            {
                SqlCommand Command = new SqlCommand();

                //Command.CommandText = "SELECT LTRIM(RTRIM(volumin)) AS volumin, spos_nab, ilosc, ile_wyp, data_wpl, data_rekl1, data_rekl2, data_rekl3, uwagi_n, numer_z, numer_z2, num_abs, num_abs2 FROM czasop_n WHERE kod = ? AND rok1 = ? AND kol = ?";
                Command.CommandText = "EXEC Akcesja_SzczegolyNumeru @id_czasop_n; ";
                Command.Parameters.AddWithValue("@id_czasop_n", id_czasop_n);
                //Command.Parameters.AddWithValue("@kod", Code);
                //Command.Parameters.AddWithValue("@rok1", Year);                
                //Command.Parameters.AddWithValue("@kol", Kol);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {                
                    this.VolumeTextBox.Text = Dt.Rows[0]["volumin"].ToString();
                    this.id_volumin = Dt.Rows[0]["id_volumes"].ToString();
                    this.id_volumin_old = id_volumin;
                    this.SposobNabyciaComboBox.SelectedValue = Int32.Parse(Dt.Rows[0]["spos_nab"].ToString());
                    this.NumberTextBox.Text = Dt.Rows[0]["ilosc"].ToString();
                    this.WNumberTextBox.Text = Dt.Rows[0]["ile_wyp"].ToString();

                    if (Dt.Rows[0]["data_wpl"].ToString().Length > 0 && Dt.Rows[0]["data_wpl"].ToString().Substring(0, 10) == "1900-01-01")
                        this.WDateMaskedTextBox.Text = "";
                    else if (Dt.Rows[0]["data_wpl"].ToString() != "")
                        this.WDateMaskedTextBox.Text = DateTime.Parse(Dt.Rows[0]["data_wpl"].ToString()).ToString("dd-MM-yyyy");

                    if (Dt.Rows[0]["data_rekl1"].ToString().Length > 0 && Dt.Rows[0]["data_rekl1"].ToString().Substring(0, 10) == "1900-01-01")
                        this.RDateMaskedTextBox.Text = "";
                    else if (Dt.Rows[0]["data_rekl1"].ToString() != "")
                        this.RDateMaskedTextBox.Text = DateTime.Parse(Dt.Rows[0]["data_rekl1"].ToString()).ToString("dd-MM-yyyy");

                    if (Dt.Rows[0]["data_rekl2"].ToString().Length > 0 && Dt.Rows[0]["data_rekl2"].ToString().Substring(0, 10) == "1900-01-01")
                        this.R2DateMaskedTextBox.Text = "";
                    else if (Dt.Rows[0]["data_rekl2"].ToString() != "")
                        this.R2DateMaskedTextBox.Text = DateTime.Parse(Dt.Rows[0]["data_rekl2"].ToString()).ToString("dd-MM-yyyy");

                    if (Dt.Rows[0]["data_rekl3"].ToString().Length > 0 && Dt.Rows[0]["data_rekl3"].ToString().Substring(0, 10) == "1900-01-01")
                        this.R3DateMaskedTextBox.Text = "";
                    else if (Dt.Rows[0]["data_rekl3"].ToString() != "")
                        this.R3DateMaskedTextBox.Text = DateTime.Parse(Dt.Rows[0]["data_rekl3"].ToString()).ToString("dd-MM-yyyy");

                    this.Comments = Dt.Rows[0]["uwagi_n"].ToString();

                    this.NoteTextBox.Text = Dt.Rows[0]["numer_z"].ToString();

                    if (Int32.Parse(Dt.Rows[0]["numer_z2"].ToString()) != 0)
                        this.Note2TextBox.Text = Dt.Rows[0]["numer_z2"].ToString();
                    else
                        this.Note2TextBox.Text = "";

                    if (Int32.Parse(Dt.Rows[0]["num_abs"].ToString()) != 0)
                        this.NextTextBox.Text = Dt.Rows[0]["num_abs"].ToString();
                    else
                        this.NextTextBox.Text = "";

                    if (Int32.Parse(Dt.Rows[0]["num_abs2"].ToString()) != 0)
                        this.Next2TextBox.Text = Dt.Rows[0]["num_abs2"].ToString();
                    else
                        this.Next2TextBox.Text = "";

                    NoTitleRTB.Text = Dt.Rows[0]["tytul_num"].ToString();
                    
                    this.CommentsCheckBox.Checked = !string.IsNullOrEmpty(Comments.Trim());

                    StartVolume = VolumeTextBox.Text;
                    KodyK = Coliber.App.NVL(Dt.Rows[0]["KodyK"].ToString());
                    if (KodyK != "")
                        chKodyK.Checked = true;
                }
            }
            catch (Exception Ex)
            {
                //MessageBox.Show(Ex.Message, CommonFunctions.getStringFromDictionary(_translationsDictionary, "error", "Błąd"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show(Ex.Message, _translationsDictionary.getStringFromDictionary("error", "Błąd"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region Generate() - OK
        private void Generate()
        {
            SposobNabyciaDictionary.Add(1, _translationsDictionary.getStringFromDictionary("purchase", "KUPNO").ToUpper());
            SposobNabyciaDictionary.Add(2, _translationsDictionary.getStringFromDictionary("gift","DAR").ToUpper());
            SposobNabyciaDictionary.Add(3, _translationsDictionary.getStringFromDictionary("replacement", "WYMIANA").ToUpper());
            SposobNabyciaDictionary.Add(4, _translationsDictionary.getStringFromDictionary("deposit", "DEPOZYT").ToUpper());
        }
        #endregion

        #region Calendars - OK
        private void WDateButton_Click(object sender, EventArgs e)
        {
            DateForm DF = new DateForm();
            
            if (DF.DialogResult == System.Windows.Forms.DialogResult.OK)
                WDateMaskedTextBox.Text = DF.monthCalendar1.SelectionRange.Start.ToString("dd-MM-yyyy");
        }

        private void RDateButton_Click(object sender, EventArgs e)
        {
            DateForm DF = new DateForm();

            if (DF.DialogResult == System.Windows.Forms.DialogResult.OK)
                RDateMaskedTextBox.Text = DF.monthCalendar1.SelectionRange.Start.ToString("dd-MM-yyyy");
        }

        private void R2DateButton_Click(object sender, EventArgs e)
        {
            DateForm DF = new DateForm();

            if (DF.DialogResult == System.Windows.Forms.DialogResult.OK)
                R2DateMaskedTextBox.Text = DF.monthCalendar1.SelectionRange.Start.ToString("dd-MM-yyyy");
        }

        private void R3DateButton_Click(object sender, EventArgs e)
        {
            DateForm DF = new DateForm();

            if (DF.DialogResult == System.Windows.Forms.DialogResult.OK)
                R3DateMaskedTextBox.Text = DF.monthCalendar1.SelectionRange.Start.ToString("dd-MM-yyyy");
        }
        #endregion

        #region CheckIsDigit(object sender, KeyPressEventArgs e) - OK
        private void CheckIsDigit(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        #endregion

        #region CancelButton_Click(object sender, EventArgs e) - OK
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
            /*if (Settings.ReadOnlyModeForCatalog)
                this.Close();
            else
                CloseForm();*/
        }
        #endregion

        #region CloseForm() - OK
        private void CloseForm()
        {
            if (MessageBox.Show("Czy zamknąć bez zapisywania zmian?", "Opuszczenie okna", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                this.Close();
        }
        #endregion

        #region OKButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        ///     Obsługuje przycisk OKButton.
        ///     Sprawdza, czy numer, ilość i ilość do wypożyczenia są puste i informuje o tym.
        ///     Wywołuje funkcję SendData().
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            string enter_the_data = _translationsDictionary.getStringFromDictionary("enter_the_data", "Wprowadź dane");

            if (NoteTextBox.Text.Trim() == "")
            {
                string number_cannot_be_blank = _translationsDictionary.getStringFromDictionary("number_cannot_be_blank", "Numer nie może być pusty!");

                MessageBox.Show(number_cannot_be_blank, enter_the_data, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (NumberTextBox.Text.Trim() == "")
            {
                string amount_cannot_be_blank = _translationsDictionary.getStringFromDictionary("amount_cannot_be_blank", "Ilość nie może być pusta!");

                MessageBox.Show(amount_cannot_be_blank, enter_the_data, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (WNumberTextBox.Text.Trim() == "")
            {
                string amount_to_borrow_cannot_be_blank = _translationsDictionary.getStringFromDictionary("amount_to_borrow_cannot_be_blank", "Ilość do wypożyczenia nie może być pusta!");

                MessageBox.Show(amount_to_borrow_cannot_be_blank, enter_the_data, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (Int32.Parse(NumberTextBox.Text.Trim()) < Int32.Parse(WNumberTextBox.Text.Trim()))
            {
                string amount_to_borrow_cannot_be_greater_than_amount_of_numbers = _translationsDictionary.getStringFromDictionary("amount_to_borrow_cannot_be_greater_than_amount_of_numbers", "Ilość do wypożyczenia nie może być większa niż ilość numerów!");

                MessageBox.Show(amount_to_borrow_cannot_be_greater_than_amount_of_numbers, _translationsDictionary.getStringFromDictionary("to_correct_data", "Popraw dane"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SendData();
        }
        #endregion

        #region SendData()
        /// <summary>
        ///     Dodaje nowy pojedynczy numer lub aktualizuje informacje o nim.
        /// </summary>
        private void SendData()
        {
            try
            {
                SqlCommand Command = new SqlCommand();
                Command.Parameters.AddWithValue("@AkcesjaKod", AkcesjaCode);

                SqlParameter volumesIdParameter = new SqlParameter();
                volumesIdParameter.DbType = DbType.Int32;
                volumesIdParameter.ParameterName = "@VolumesID";                
                volumesIdParameter.Direction = ParameterDirection.InputOutput;                

                Command.Parameters.Add(volumesIdParameter);

                if (this.VolumeTextBox.Text == "")
                {
                    string message = _translationsDictionary.getStringFromDictionary("add_wihout_volume", "Czy dodać numer bez woluminu?");
                    string caption = _translationsDictionary.getStringFromDictionary("adding_without_volume", "Dodawanie bez woluminu");

                    //if (MessageBox.Show("Czy dodać numer bez woluminu?", "Dodawanie bez woluminu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        if (!CheckVolumeExists())
                        {
                            //Query += " INSERT INTO volumes (kod, syg, rok1, rok2, volumin, czesci, uwagi_v, nr_akcesji, rocz_pren, wart_vol, numer_inw, nab, dodatki, data_biez) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); \n";
                            AddVolumin(ref Command);
                        }
                    }
                    else
                        return;
                }
                else if (!CheckVolumeExists())
                {
                    string message = _translationsDictionary.getStringFromDictionary("volume_does_not_exists_add_it", "Podany wolumin nie istnieje. Czy dopisać go do listy?");
                    string caption = _translationsDictionary.getStringFromDictionary("volume_adding", "Dodawanie woluminu");

                    //if (MessageBox.Show("Podany wolumin nie istnieje. Czy dopisać go do listy?", "Dodawanie woluminu", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        //Query += " INSERT INTO volumes (kod, syg, rok1, rok2, volumin, czesci, uwagi_v, nr_akcesji, rocz_pren, wart_vol, numer_inw, nab, dodatki, data_biez) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?); \n";
                        AddVolumin(ref Command);
                    }
                    else
                        return;
                }

                /*if (Note2TextBox.Text.Trim() != "")
                {
                    int Roznica = Int32.Parse(Note2TextBox.Text) - Int32.Parse(NoteTextBox.Text);
                    
                    for (int i = Kol + 1; i <= Kol + Roznica; i++)
                    {
                       Command.CommandText += "UPDATE czasop_n SET ile_wyp = 0 WHERE kod = @AkcesjaKod AND kol = @kol" + i + " AND rok1 = @rok1" + i + "; " + Environment.NewLine +
                                               "DELETE FROM czasop_n WHERE kod = @AkcesjaKod AND kol = @kol" + i + " AND rok1 = @rok1" + i + "; " + Environment.NewLine;
                        
                        Command.Parameters.AddWithValue("@kol" + i, i);
                        Command.Parameters.AddWithValue("@rok1" + i, Year);
                    }
                }*/

                volumesIdParameter.SqlValue = Int32.Parse(id_volumin);

                InsertRow(ref Command, NewNumber);

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

                if (VolumesMode != 1)
                {
                    if (VolumesMode == 2)
                    {
                        //Command.CommandText += "EXEC nr_zeszytu @volumin, @year, @maxKol, @code, @Akcesja_code; " + Environment.NewLine;
                        Command.CommandText += "EXEC nr_zeszytu @VolumesID, @maxKol, @code, @Akcesja_code; " + Environment.NewLine;
                    }
                    else if (VolumesMode == 3)
                    {
                        //Command.CommandText += "EXEC nr_kolejny @volumin, @year, @maxKol, @code, @Akcesja_code; " + Environment.NewLine;
                        Command.CommandText += "EXEC nr_kolejny @VolumesID, @maxKol, @code, @Akcesja_code; " + Environment.NewLine;
                    }

                    Command.Parameters.AddWithValue("@maxKol", MaxKol);
                    Command.Parameters.AddWithValue("@code", CzasopCode);
                    Command.Parameters.AddWithValue("@Akcesja_code", AkcesjaCode);
                }

                if (!NewNumber && StartVolume.Trim() != VolumeTextBox.Text.Trim())
                {
                    if (VolumesMode != 1)
                    {
                        if (VolumesMode == 2)
                        {
                            Command.CommandText += "EXEC nr_zeszytu @id_volumin_old, @maxKol_old, @code_old, @Akcesja_code_old; " + Environment.NewLine;
                        }
                        else if (VolumesMode == 3)
                        {
                            Command.CommandText += "EXEC nr_kolejny @id_volumin_old, @maxKol_old, @code_old, @Akcesja_code_old; " + Environment.NewLine;
                        }

                        Command.Parameters.AddWithValue("@id_volumin_old", id_volumin_old);
                        Command.Parameters.AddWithValue("@maxKol_old", MaxKol);
                        Command.Parameters.AddWithValue("@code_old", CzasopCode);
                        Command.Parameters.AddWithValue("@Akcesja_code_old", AkcesjaCode);
                    }
                }

                if(CommonFunctions.WriteData(Command, ref Settings.Connection))
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("saved", "Dane zostały zapisane."), _translationsDictionary.getStringFromDictionary("data_save", "Zapis do bazy"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }

                /*SqlDataReader Reader = Command.ExecuteReader();

                string InfoFromDb = "";

                while (Reader.Read())
                {
                    InfoFromDb += Reader.GetValue(0).ToString();
                    //InfoFromDb += Reader.GetValue(0).ToString();
                }

                if (InfoFromDb.Trim() != "")
                    MessageBox.Show(InfoFromDb, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    MessageBox.Show("Dane zostały zapisane.", "Zapis do bazy", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //MessageBox.Show(Query);
                    this.Close();
                }

                Reader.Close();*/
            }
            catch (SqlException Ex)
            {
                MessageBox.Show(Ex.Message, _translationsDictionary.getStringFromDictionary("error", "Błąd"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _translationsDictionary.getStringFromDictionary("error", "Błąd"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region AddVolumin(ref SqlCommand Command) - To TEST
        private void AddVolumin(ref SqlCommand Command)
        {
            Command.CommandText += "EXEC Czasop_VolumesAdd @CzasopKod_volumes, @syg_volumes, @rok1_volumes, @rok2_volumes, @volumin_volumes, @czesci_volumes, @uwagi_v_volumes, @rocz_pren_volumes, @wart_vol_volumes, @numer_inw_volumes, @nab_volumes, @dodatki_volumes, @data_biez_volumes, @id_cza_syg, @VolumesID OUTPUT; ";

            Command.Parameters.AddWithValue("@CzasopKod_volumes", CzasopCode);
            Command.Parameters.AddWithValue("@syg_volumes", Sygnatura);
            Command.Parameters.AddWithValue("@rok1_volumes", YearLabel.Text);
            Command.Parameters.AddWithValue("@rok2_volumes", 0);
            Command.Parameters.AddWithValue("@volumin_volumes", this.VolumeTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@czesci_volumes", "");
            Command.Parameters.AddWithValue("@uwagi_v_volumes", "");
            Command.Parameters.AddWithValue("@nr_akcesji_volumes", "");
            Command.Parameters.AddWithValue("@rocz_pren_volumes", 0);
            Command.Parameters.AddWithValue("@wart_vol_volumes", 0);
            Command.Parameters.AddWithValue("@numer_inw_volumes", "");
            Command.Parameters.AddWithValue("@nab_volumes", 0);
            Command.Parameters.AddWithValue("@dodatki_volumes", 0);
            Command.Parameters.AddWithValue("@data_biez_volumes", DateTime.Now);
            Command.Parameters.AddWithValue("@id_cza_syg", id_cza_syg);
        }
        #endregion

        #region InsertRow(ref SqlCommand Command, int Number) - To TEST
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Command">referencja do zmiennej Command typu SqlCommand</param>
        /// <param name="Number"></param>
        private void InsertRow(ref SqlCommand Command, bool NewNumber)
        {
            //Command.CommandText += "INSERT INTO czasop_n (kod, rok1, rok2, volumin, numer_z, numer_z2, num_abs, num_abs2, spos_nab, ilosc, stan_poz, stan_zam, data_wpl, data_rekl1, data_rekl2, data_rekl3, uwagi_n, data_biez, kol, tytul_num, ile_wyp, id_czasop) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, convert(datetime,?, 105), convert(datetime,?, 105), convert(datetime,?, 105), convert(datetime,?, 105), ?, ?, ?, ?, ?, ?) \n";
            if(NewNumber)
                Command.CommandText += "EXEC Akcesja_DodajNumer @AkcesjaKod, @p_rok1, @p_rok2, @p_volumin, @p_numer_z, @p_numer_z2, @p_num_abs, @p_num_abs2, @p_spos_nab, @p_ilosc, @p_stan_poz, @p_stan_zam, @p_data_wpl, @p_data_rekl1, @p_data_rekl2, @p_data_rekl3, @p_uwagi_n, @p_data_biez, @p_kol, @p_tytul_num, @p_ile_wyp, @p_id_czasop, @VolumesID, @KodyK; ";
            else
                Command.CommandText += "EXEC Akcesja_ModyfikujNumer @p_volumin, @p_numer_z, @p_numer_z2, @p_num_abs, @p_num_abs2, @p_spos_nab, @p_ilosc, @p_data_wpl, @p_data_rekl1, @p_data_rekl2, @p_data_rekl3, @p_uwagi_n, @p_data_biez, @p_ile_wyp, @VolumesID, @id_czasop_n, @p_tytul_num, @KodyK; ";
            
            Command.Parameters.AddWithValue("@p_rok1", YearLabel.Text);
            Command.Parameters.AddWithValue("@p_rok2", Year2Label.Text);
            Command.Parameters.AddWithValue("@p_volumin", VolumeTextBox.Text);

            if (NoteTextBox.Text.Trim() != "")
                Command.Parameters.AddWithValue("@p_numer_z", NoteTextBox.Text);
            else
                Command.Parameters.AddWithValue("@p_numer_z", 0);

            if (Note2TextBox.Text.Trim() != "")
                Command.Parameters.AddWithValue("@p_numer_z2", Note2TextBox.Text);
            else
                Command.Parameters.AddWithValue("@p_numer_z2", 0);

            if (NextTextBox.Text.Trim() != "")
                Command.Parameters.AddWithValue("@p_num_abs", NextTextBox.Text);
            else
                Command.Parameters.AddWithValue("@p_num_abs", 0);

            if (Next2TextBox.Text.Trim() != "")
                Command.Parameters.AddWithValue("@p_num_abs2", Next2TextBox.Text);
            else
                Command.Parameters.AddWithValue("@p_num_abs2", 0);

            Command.Parameters.AddWithValue("@p_spos_nab", SposobNabyciaComboBox.SelectedValue.ToString());
            Command.Parameters.AddWithValue("@p_ilosc", NumberTextBox.Text);
            Command.Parameters.AddWithValue("@p_stan_poz", 0);
            Command.Parameters.AddWithValue("@p_stan_zam", 0);

            if (WDateMaskedTextBox.Text.Trim() != "-  -")
                Command.Parameters.AddWithValue("@p_data_wpl", DateTime.ParseExact(WDateMaskedTextBox.Text.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd"));
            else
                Command.Parameters.AddWithValue("@p_data_wpl", DBNull.Value);

            if (RDateMaskedTextBox.Text.Trim() != "-  -")
                Command.Parameters.AddWithValue("@p_data_wpl", DateTime.ParseExact(RDateMaskedTextBox.Text.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd"));
            else
                Command.Parameters.AddWithValue("@p_data_rekl1", DBNull.Value);

            if (R2DateMaskedTextBox.Text.Trim() != "-  -")
                Command.Parameters.AddWithValue("@p_data_wpl", DateTime.ParseExact(R2DateMaskedTextBox.Text.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd"));
            else
                Command.Parameters.AddWithValue("@p_data_rekl2", DBNull.Value);

            if (R3DateMaskedTextBox.Text.Trim() != "-  -")
                Command.Parameters.AddWithValue("@p_data_wpl", DateTime.ParseExact(R3DateMaskedTextBox.Text.Trim(), "dd-MM-yyyy", CultureInfo.InvariantCulture).ToString("yyyyMMdd"));
            else
                Command.Parameters.AddWithValue("@p_data_rekl3", DBNull.Value);

            if (Comments.Trim() != "")
                Command.Parameters.AddWithValue("@p_uwagi_n", Comments.Trim());
            else
                Command.Parameters.AddWithValue("@p_uwagi_n", DBNull.Value);

            Command.Parameters.AddWithValue("@p_data_biez", DateTime.Now);
            Command.Parameters.AddWithValue("@p_kol", this.Kol);
            Command.Parameters.AddWithValue("@p_tytul_num", NoTitleRTB.Text.Trim());
            Command.Parameters.AddWithValue("@p_ile_wyp", WNumberTextBox.Text);
            Command.Parameters.AddWithValue("@p_id_czasop", CzasopCode);
            Command.Parameters.AddWithValue("@id_czasop_n", id_czasop_n);
            Command.Parameters.AddWithValue("@KodyK", KodyK);
        }
        #endregion

        #region CheckVolumeExists() - To TEST
        private bool CheckVolumeExists()
        {
            try
            {
                SqlCommand Command = new SqlCommand();

                //Command.CommandText = "SELECT COUNT(*) FROM volumes WHERE kod = ? AND rok1 = ? AND volumin = ?";
                Command.CommandText = "EXEC Akcesja_SprawdzWoluminIstnieje @id_cza_syg, @rok1, @volumin; ";
                Command.Parameters.AddWithValue("@id_cza_syg", id_cza_syg);
                Command.Parameters.AddWithValue("@rok1", YearLabel.Text);
                Command.Parameters.AddWithValue("@volumin", VolumeTextBox.Text.Trim());

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    id_volumin = Dt.Rows[0]["id_volumes"].ToString();
                    return true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }
        #endregion

        #region CommentsCheckBox_Click(object sender, EventArgs e) - OK
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommentsCheckBox_Click(object sender, EventArgs e)
        {
            CommentsForm Comm = new CommentsForm(Comments, this);

            if (Comm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Comments = Comm.textBox1.Text;
            }

            if (Comments != null && Comments.Trim() == "")
                CommentsCheckBox.Checked = false;
            else
                CommentsCheckBox.Checked = true;

            Comm.Dispose();
        }
        #endregion

        #region VolumeButton_Click(object sender, EventArgs e) - To TEST
        /// <summary>
        ///     Przycisk wywołujący okno z woluminami.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VolumeButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Akcesja_WoluminySygnaturyRoku @id_cza_syg, @rok; ";            
            Command.Parameters.AddWithValue("@id_cza_syg", id_cza_syg);
            Command.Parameters.AddWithValue("@rok", Year);

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id_volumes";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "volumin";
            Columns[1].Name = "volumin";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("available_volumes", "Dostępne woluminy");

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "numery";
            Columns[2].Name = "numery";
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("numbers", "Numery");

            ShowForm SF = new ShowForm(Command, Columns, "", "volumes", "volumes");
            
            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                VolumeTextBox.Text = SF.DGVRow.Cells["volumin"].Value.ToString();
                this.id_volumin = SF.DGVRow.Cells["id"].Value.ToString();
            }
        }
        #endregion

        #region NumberTextBox_TextChanged(object sender, EventArgs e) - OK
        /// <summary>
        ///     Przepisuje "Ilość" do "Ilość do wypożyczenia".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
            if (((TextBox)(sender)).Name == "NumberTextBox")
                WNumberTextBox.Text = NumberTextBox.Text;
        }
        #endregion

        #region DeleteButton_Click(object sender, EventArgs e) - OK
        /// <summary>
        ///     Przycisk wywołujący funkcję usuwającą pojedynczy numer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteButton_Click(object sender, EventArgs e)
        {            
            DeleteSingleNumber();
        }
        #endregion

        private DataTable IsNumberBorrowed()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Akcesja_SprawdzNumerJestWypozyczony @id_czasop_n, 1;";
            Command.Parameters.AddWithValue("@id_czasop_n", id_czasop_n);

            return CommonFunctions.ReadData(Command, ref Settings.Connection);
        }

        #region DeleteSingleNumber() - To TEST
        /// <summary>
        ///     Usuwanie pojedynczego
        /// </summary>
        private void DeleteSingleNumber()
        {
            DataTable Dt = IsNumberBorrowed();

            if (Dt.Rows.Count > 0)
            {
                string message = string.Format("{0} {1}. {2}", _translationsDictionary.getStringFromDictionary("there_are_borrowed_copies_in_quantities", "Istnieją wypożyczone egzemplarze w ilości:"), Dt.Rows.Count, _translationsDictionary.getStringFromDictionary("do_you_want_to_return_it", "Czy chcesz je zwrócić?"));
                
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
                        DeleteSingleNumber();
                }

                return;
            }

            //do_you_want_to_delete_single_magazine_number
            string do_you_want_to_delete_single_magazine_number = _translationsDictionary.getStringFromDictionary("do_you_want_to_delete_single_magazine_number", "Czy na pewno chcesz usunąć pojedynczy numer?");
            //if (MessageBox.Show("Czy na pewno chcesz usunąć pojedynczy numer?", "Usuwanie", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            if (MessageBox.Show(do_you_want_to_delete_single_magazine_number, _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                SqlCommand Command = new SqlCommand();

                Command.CommandText = "EXEC DeleteSingleNumber @p_akcesja_kod, @p_czasop_kod, @p_mode, @p_maxKol, @id_czasop_n; ";
                Command.Parameters.AddWithValue("@p_czasop_kod", this.CzasopCode);
                Command.Parameters.AddWithValue("@p_akcesja_kod", this.AkcesjaCode);
                Command.Parameters.AddWithValue("@p_mode", this.VolumesMode);
                Command.Parameters.AddWithValue("@p_maxKol", this.MaxKol);
                Command.Parameters.AddWithValue("@id_czasop_n", this.id_czasop_n);
                
                if(CommonFunctions.WriteData(Command, ref Settings.Connection))
                {//
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("removed", "Numer pomyślnie usunięto."), _translationsDictionary.getStringFromDictionary("single_number_deleting", "Usuwanie numeru"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }
        #endregion

        #region SingleNumberForm_KeyDown(object sender, KeyEventArgs e) - OK
        /// <summary>
        ///  Obsługa zamykania okienka poprzez wciśnięcie ESCAPE.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SingleNumberForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                this.Close();
           /* if (Settings.ReadOnlyModeForCatalog)
                this.Close();
            else if (e.KeyData == Keys.Escape)
                CloseForm();*/
        }
        #endregion

        #region Połamane Pola - OK
        /// <summary>
        ///     Obsługa zachowań pól połamanych numerów.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Next2TextBox_Enter(object sender, EventArgs e)
        {
            if (Settings.ReadOnlyModeForCatalog) return;

            Next2TextBox.ReadOnly = NextTextBox.Text.Trim() == "";
        }

        private void NextTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (Settings.ReadOnlyModeForCatalog) return;

            if (NextTextBox.Text.Trim() != "")
                Next2TextBox.ReadOnly = false;
            else
            {
                Next2TextBox.Text = "";
                Next2TextBox.ReadOnly = true;
            }
        }

        private void Note2TextBox_Enter(object sender, EventArgs e)
        {
            if (Settings.ReadOnlyModeForCatalog) return;

            Note2TextBox.ReadOnly = NoteTextBox.Text.Trim() == "";
        }

        private void NoteTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (Settings.ReadOnlyModeForCatalog) return;

            if (NoteTextBox.Text.Trim() != "")
                Note2TextBox.ReadOnly = false;
            else
            {
                Note2TextBox.Text = "";
                Note2TextBox.ReadOnly = true;
            }
        }
        #endregion

        #region Lock() - OK
        private void Lock()
        {
            if (Settings.ReadOnlyModeForCatalog)
            {
                SposobNabyciaComboBox.Enabled = false;
                OKButton.Visible = false;
                DeleteButton.Visible = false;
                WDateButton.Visible = false;
                RDateButton.Visible = false;
                R2DateButton.Visible = false;
                R3DateButton.Visible = false;
                VolumeTextBox.ReadOnly = true;
                NoteTextBox.ReadOnly = true;
                Note2TextBox.ReadOnly = true;
                NextTextBox.ReadOnly = true;
                Next2TextBox.ReadOnly = true;
                NumberTextBox.ReadOnly = true;
                WNumberTextBox.ReadOnly = true;
                WDateMaskedTextBox.ReadOnly = true;
                RDateMaskedTextBox.ReadOnly = true;
                R2DateMaskedTextBox.ReadOnly = true;
                R3DateMaskedTextBox.ReadOnly = true;
                chKodyK.Enabled = false;
            }
        }
        #endregion

        private void chKodyK_Click(object sender, EventArgs e)
        {
            CommentsForm Comm = new CommentsForm( this, KodyK);

            if (Comm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                KodyK = Comm.textBox1.Text.Trim();
                string[] Kody = KodyK.Split((char)10);
                foreach (string kod in Kody)
                {
                    if (kod.Trim() == "" || !IsDigitsOnly(kod))
                    {
                        KodyK = "";
                        MessageBox.Show("Nieprawidłowy kod kreskowy", kod, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                //bool isUnique = Kody.Distinct().Count() == Kody.Count();
                HashSet<string> s = new HashSet<string>(Kody);
                if (s.Count != Kody.Length)
                {
                    KodyK = "";
                    MessageBox.Show("Wpisano powtarzjące się kody kreskowe","Informacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (WNumberTextBox.Text.Trim() != Kody.Length.ToString())
                {
                    KodyK = "";
                    MessageBox.Show("Wpisano nieprawidłową ilość się kodów kreskowych", Kody.Length.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

            }


            if (KodyK != null && KodyK.Trim() == "")
                chKodyK.Checked = false;
            else
                chKodyK.Checked = true;

            Comm.Dispose();
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }
    }
}