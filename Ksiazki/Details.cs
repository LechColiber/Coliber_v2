﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.Globalization;
using Wypozyczalnia;
using System.Threading;
using WinformsDirtyTracking;

namespace Ksiazki
{
    public partial class DetailsForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        #region Variable declaration - GOOD
        private Object Array;

        private List<string[]> InstitutionsList;
        private List<string[]> PublishersList;
        private string[] PublishersID;
        //private List<string[]> KeyList;
        private Dictionary<int, string> ContentFormComboboxValues;
        private List<string> TextLanguagesList;
        private List<string> ShortLanguagesList;
        private string IDSerie;
        private string IDSubSerie;
        private XmlNode Record;
        private string Server;
        private string BookID;

        private string LangID;
        private string Lang2ID;
        private string Lang3ID;
        private string Lang4ID;
        private string Lang5ID;

        private string LangBookID;
        private string Lang2BookID;
        private string Lang3BookID;
        private string Lang4BookID;
        private string Lang5BookID;

        private string ParallelTitleID;
        private string AdditionalTitleID;
        private string ConfID;

        private List<string> KeysToDelete;

        private DataTable SygDataTable;
        private DataTable SygsToUbytkowanie;
        private int TempID;
        private List<string> SygsToDelete;

        private string MainBookID;
        private string SubSerieID;

        private int TomesCount;
        private int SourcesCount;

        private List<string> AuthorsToDelete;
        private List<string> CoAuthorsToDelete;
        private DataTable AuthorsDt;
        private DataTable CoAuthorsDt;

        private bool ReadOnly;

        private string TempSyg;
        private bool uniqueSignatures = false;
        private bool uniqueInvNo = false;
        private bool uniqueScope = false;

        private enum FormActivate
        {
            faMainForm, faAuthorsForm, faTomesForm
        };

        private FormActivate ActiveReason;

        private enum SygModeEnum
        {
            Add,
            Edit,
            None
        };

        private enum ModeEnum
        {
            Add,
            Edit,            
            None
        };       

        private SygModeEnum CurrentSygMode;
        private ModeEnum CurrentMode;
        AuthorsForm authorsForm;
        SlightlyMoreSophisticatedDirtyTracker _dirtyTracker;
        bool lEdit;
        #endregion

        #region DetailsForm(Object Array, XmlNode Record, string Server) : this() - Z39.50/REFACTORED
        public DetailsForm(Object Array, XmlNode Record, string Server) : this()
        {
            //InitializeComponent();

            if (CheckConnection())
            {
                //SetToolTip();

                CurrentMode = ModeEnum.Add;

                /*AuthorsList = new List<string[]>();
                SecondAuthorsList = new List<string[]>();
                InstitutionsList = new List<string[]>();
                PublishersList = new List<string[]>();
                PublishersID = new string[2];
                KeyList = new List<string[]>();
                TextLanguagesList = new List<string>();
                ShortLanguagesList = new List<string>();
                IDSerie = "";
                IDSubSerie = "";*/
                this.Record = Record;
                this.Server = Server;

                this.Array = Array;

                string[] TempPub;
                foreach (List<SubfieldClass> Datafield in (IList)Array)
                {
                    TempPub = new string[3];

                    foreach (SubfieldClass Subfield in Datafield)
                    {
                        if (Subfield.Tag == "245" && Subfield.Code == "a")
                            MainTitleTextBox.Text = Subfield.Value + " ";
                        else if (Subfield.Tag == "245" && Subfield.Code == "b")
                            MainTitleTextBox.Text += Subfield.Value;
                        else if (Subfield.Tag == "245" && Subfield.Code == "n")
                            MainTitleTextBox.Text += Subfield.Value;

                        else if (Subfield.Tag == "246" && Subfield.Ind2 == "1")
                            ParallelTitleTextBox.Text += Subfield.Value;
                        else if (Subfield.Tag == "246" && Subfield.Ind2 == "0" && Subfield.Code == "a")
                            AdditionalTitleTextBox.Text = Subfield.Value;

                        else if ((Subfield.Tag == "020" || Subfield.Tag == "920") && Subfield.Code == "a")
                        {
                            if (ISBNTextBox.Text.Trim() == "")
                                ISBNTextBox.Text = Subfield.Value;
                            else if (ISBN2TextBox.Text.Trim() == "")
                                ISBN2TextBox.Text = Subfield.Value;
                        }

                        else if (Subfield.Tag == "008")
                            PublishYearTextBox.Text = Subfield.Value.Substring(7, 4).Replace("||||", "").Trim();

                        else if (Subfield.Tag == "300" && Subfield.Code == "c")
                        {
                            if (!Subfield.Value.Contains('x'))
                                HeightTextBox.Text = Subfield.Value.Replace("cm.", "").Replace("cm", "").Replace("+", "").Trim();
                            else
                            {
                                string[] temp = Subfield.Value.Replace("cm.", "").Replace("cm", "").Replace("+", "").Split('x');
                                if (temp.Length > 0)
                                    HeightTextBox.Text = temp[0];
                                if (temp.Length > 1)
                                    WidthTextBox.Text = temp[1];
                            }
                        }
                        else if (Subfield.Tag == "300" && Subfield.Code == "a")
                            DescriptionTextBox.Text = Subfield.Value.Replace(";", "").Replace(":", "").Trim();

                        else if (Subfield.Tag == "250" && Subfield.Code == "a")
                            PublishVersionTextBox.Text = Subfield.Value;

                        else if (Subfield.Tag == "260" && Subfield.Code == "a")
                        {
                            TempPub[1] = Subfield.Value.Replace(":", "").Trim();
                        }
                        else if (Subfield.Tag == "260" && Subfield.Code == "b")
                        {
                            TempPub[0] = Subfield.Value.Replace(",", "").Trim();
                        }

                        else if (Subfield.Tag == "111" && Subfield.Code == "a")
                            ConfTitleTextBox.Text = Subfield.Value;
                        else if (Subfield.Tag == "111" && Subfield.Code == "c")
                            ConfCityTextBox.Text = Subfield.Value;
                        else if (Subfield.Tag == "111" && Subfield.Code == "n")
                            ConfNumberTextBox.Text = Subfield.Value;

                        else if (Subfield.Tag == "650" && Subfield.Code == "a")
                            KeysDataGridView.Rows.Add(new string[] { "-1", Subfield.Value.ToUpper() });

                        else if (Subfield.Tag == "041" && Subfield.Code == "a")
                        {
                            TextLanguagesList.Add(Subfield.Value.ToUpper());
                        }
                        else if (Subfield.Tag == "041" && Subfield.Code == "h")
                        {
                            ShortLanguagesList.Add(Subfield.Value.ToUpper());
                        }

                        else if (Subfield.Tag == "830" && Subfield.Code == "a")
                            SerieTitleTextBox.Text = Subfield.Value;
                        else if (Subfield.Tag == "830" && Subfield.Code == "x")
                            ISSNTextBox.Text = Subfield.Value;
                        else if (Subfield.Tag == "830" && Subfield.Code == "p")
                            PartNameTextBox.Text = Subfield.Value;
                        else if (Subfield.Tag == "830" && Subfield.Code == "v")
                            NumberNameTextBox.Text = Subfield.Value;
                    }

                    if (TempPub[1] != null)
                        PublishersList.Add(TempPub);
                }

                ClearChars();

                LoadAuthorsToTextBox(true);
                LoadPublishers();

                CheckKeys();

                KeysDataGridView.Sort(KeysDataGridView.Columns["Key"], ListSortDirection.Ascending);

                //ContentFormDictionary();
                CheckLanguages();
                LoadLanguagesIntoControls();

                keySuggest("");
                if (LangTextBox.Text == null || LangTextBox.Text.Trim() == "") { LangID = Coliber.App.LangID; LangTextBox.Text = "POL"; }
                this.ShowDialog();
            }
            else
                this.Close();
        }
        #endregion

        #region DetailsForm() - GOOD
        public DetailsForm()
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.ActiveReason = FormActivate.faMainForm;

            SetToolTip();

            //if(Settings.ID_rodzaj == -1)
                Settings.SetSettings(1);            
                        
            InstitutionsList = new List<string[]>();
            PublishersList = new List<string[]>();
            PublishersID = new string[2];
            //KeyList = new List<string[]>();
            TextLanguagesList = new List<string>();
            ShortLanguagesList = new List<string>();
            IDSerie = "";
            IDSubSerie = "";
            KeysToDelete = new List<string>();
            ConfID = "";

            SygDataTable = new DataTable();
            SygDataTable.Columns.Add("tempID");
            SygDataTable.Columns.Add("id_sygnat");
            SygDataTable.Columns.Add("syg");
            SygDataTable.Columns.Add("numer_inw");
            SygDataTable.Columns.Add("k_kreskowy");
            SygDataTable.Columns.Add("numer_akc");
            SygDataTable.Columns.Add("spos_nab");
            SygDataTable.Columns.Add("cena");
            SygDataTable.Columns.Add("wartosc");
            SygDataTable.Columns.Add("waluta");
            SygDataTable.Columns.Add("data_zap");
            SygDataTable.Columns.Add("uwagi");

            SygsToDelete = new List<string>();

            SygsToUbytkowanie = new DataTable();
            SygsToUbytkowanie.Columns.Add("syg");
            SygsToUbytkowanie.Columns.Add("numer_inw");
            SygsToUbytkowanie.Columns.Add("nr_ksiegi");
            SygsToUbytkowanie.Columns.Add("data");
            SygsToUbytkowanie.Columns.Add("przyczyna");
            SygsToUbytkowanie.Columns.Add("nr_dowodu");
            SygsToUbytkowanie.Columns.Add("uwagi");
            SygsToUbytkowanie.Columns.Add("id_sygnat");

            TempID = 1;            

            AuthorsDt = new DataTable();
            AuthorsDt.Columns.Add("id");
            AuthorsDt.Columns.Add("imie");
            AuthorsDt.Columns.Add("nazwisko");

            CoAuthorsDt = new DataTable();
            CoAuthorsDt.Columns.Add("id");            
            CoAuthorsDt.Columns.Add("imie");
            CoAuthorsDt.Columns.Add("nazwisko");
            CoAuthorsDt.Columns.Add("id_odpow");
            CoAuthorsDt.Columns.Add("odpow");

            AuthorsToDelete = new List<string>();
            CoAuthorsToDelete = new List<string>();

            LoadSposobNabycia();
            ContentFormDictionary();

            CommonFunctions.LoadConfig(this.Controls, ref Settings.Connection, 1);
            LoadConfiguration();

            ChangeSygState(SygModeEnum.None);
            if (LangTextBox.Text == null || LangTextBox.Text.Trim() == "") { LangID = Coliber.App.LangID; LangTextBox.Text = "POL"; }
        }
        #endregion

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); mapping.Add(label1, "edition");
            mapping.Add(UKDLabel, "udc");
            mapping.Add(label3, "isbn");
            mapping.Add(label8, "format");
            mapping.Add(label12, "comments");
            mapping.Add(label4, "publish_year");
            mapping.Add(label7, "ph_description");
            mapping.Add(label40, "volume_count");
            mapping.Add(label13, "main_title");
            mapping.Add(label14, "parallel_title");
            mapping.Add(label15, "additional_title");
            mapping.Add(label17, "conference_date");
            mapping.Add(label16, "event_promoter");
            mapping.Add(label10, "city");
            mapping.Add(label6, "country");
            mapping.Add(label5, "event_number");
            mapping.Add(label2, "conference_title");
            mapping.Add(Publisher2Label, "new");
            mapping.Add(PublisherLabel, "new");
            mapping.Add(Key, "key");
            mapping.Add(RusCheckBox, "russian");
            mapping.Add(FraCheckBox, "french");
            mapping.Add(GerCheckBox, "german");
            mapping.Add(EngCheckBox, "english");
            mapping.Add(PolCheckBox, "polish");
            mapping.Add(label19, "summaries");
            mapping.Add(LanguagesLabel, "languages_of_text");
            mapping.Add(label18, "form_of_document_content");
            mapping.Add(label24, "series_promoter");
            mapping.Add(label23, "part_number");
            mapping.Add(label22, "part_name");
            mapping.Add(label21, "series_issn");
            mapping.Add(label20, "series_title");
            mapping.Add(label28, "subseries_title");
            mapping.Add(label27, "subseries_issn");
            mapping.Add(label26, "part_name");
            mapping.Add(label25, "part_number");
            mapping.Add(label42, "f2_last_signatures");
            mapping.Add(label41, "positions_in_inventory");
            mapping.Add(CancelSygButton, "cancel");
            mapping.Add(SaveSygButton, "save");
            mapping.Add(DeleteSygButton, "delete");
            mapping.Add(EditSygButton, "edit");
            mapping.Add(NewSygButton, "new_signature");
            mapping.Add(label39, "comments");
            mapping.Add(label38, "date");
            mapping.Add(label34, "currency");
            mapping.Add(label35, "value");
            mapping.Add(label36, "price");
            mapping.Add(label37, "method_of_acquisition");
            mapping.Add(label32, "receipt_number");
            mapping.Add(label33, "barcode");
            mapping.Add(label31, "inventory_number");
            mapping.Add(label30, "signature");
            mapping.Add(Syg, "signature");
            mapping.Add(NumInwDGV, "inventory_number");
            mapping.Add(label29, "existing_signatures");
            mapping.Add(ImportButton, "import");
            mapping.Add(DeleteButton, "delete");
            mapping.Add(SourcesButton, "sources");
            mapping.Add(TomsButton, "volumes_1");
            mapping.Add(PrintButton, "print");
            mapping.Add(ExitButton, "exit");
            mapping.Add(SaveButton, "save");
            mapping.Add(this, "books_register");
            mapping.Add(tabPage1, "main_description");
            mapping.Add(AuthorsGroupBox, "authors");
            mapping.Add(TitleGroupBox, "title");
            mapping.Add(ConferenceGroupBox, "conference_materials");
            mapping.Add(PublishersGroupBox, "editors");
            mapping.Add(tabPage2, "factual_description");
            mapping.Add(ClassificationGroupBox, "factual_classification");
            mapping.Add(SerieGroupBox, "series");
            mapping.Add(SubserieGroupBox, "subseries");
            mapping.Add(tabPage3, "registration_data");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        #region DetailsForm(int id_rodzaj) : this() - GOOD
        public DetailsForm(int id_rodzaj, string employeeID)
            : this()
        {            
            Settings.SetSettings(id_rodzaj);

            Settings.employeeID = employeeID;

            CurrentMode = ModeEnum.Add;
            ImportButton.Visible = true;

            keySuggest("");
            if (LangTextBox.Text == null || LangTextBox.Text.Trim() == "") { LangID = Coliber.App.LangID; LangTextBox.Text = "POL"; }

            //LoadDataInControls();
        }
        #endregion

        #region DetailsForm(int id_rodzaj, string BookID, bool ReadOnly = false) : this() - GOOD
        public DetailsForm(int id_rodzaj, string BookID, string employeeID, bool ReadOnly = false) : this()
        {
            Settings.SetSettings(id_rodzaj);
            this.BookID = BookID;
            Settings.employeeID = employeeID;

            CurrentMode = ModeEnum.Edit;
            //this.BooksListButton.Visible = false;

            LoadDataInControls(BookID, true, false);
            if (LangTextBox.Text == null || LangTextBox.Text.Trim() == "") { LangID = Coliber.App.LangID; LangTextBox.Text = "POL"; }

            if (ReadOnly)
            { 
                Lock();
                Settings.ReadOnlyMode = true;
                this.ReadOnly = true;
                SaveButton.Visible = false;
                DeleteButton.Visible = true;
            }
            else
            {
                DeleteButton.Visible = false;
            }

            keySuggest("");
        }
        #endregion

        #region DetailsForm(string TomeID, string MainBookID, bool ReadOnly = false) : this() - GOOD //TOMY NOWY
        public DetailsForm(string TomeID, string MainBookID, string employeeID, bool ReadOnly = false) : this()
        {
            this.BookID = TomeID;
            this.MainBookID = MainBookID;

            Settings.employeeID = employeeID;

            if (string.IsNullOrEmpty(TomeID))
            {
                CurrentMode = ModeEnum.Add;
                LoadDataInControls(MainBookID, false, false);
            }
            else
            {
                CurrentMode = ModeEnum.Edit;
                //this.BooksListButton.Visible = false;
                LoadDataInControls(TomeID, true, false);
            }

            if (ReadOnly)
            {
                Lock();
                this.ReadOnly = true;
                SaveButton.Visible = false;
                DeleteButton.Visible = true;
            }
            else
            {
                DeleteButton.Visible = false;
            }

            TomsButton.Visible = false;
            keySuggest("");
            if (LangTextBox.Text == null || LangTextBox.Text.Trim() == "") { LangID = Coliber.App.LangID; LangTextBox.Text = "POL"; }
        }
        #endregion

        private void LoadConfiguration()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "SELECT LTRIM(RTRIM(nazwa)) AS nazwa, w_warunek FROM dbo.konfig WHERE nazwa = 'UnikalneSygnaturyKsiazki' OR nazwa = 'OstatnieSygnatury_NumeryInwentarzowe' OR nazwa = 'UnikalneNumeryInwKsiazki' OR nazwa = 'UnikatyWidRodzaj'; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if (Dt.Rows[i]["nazwa"].ToString().Trim().ToLower() == ("UnikalneSygnaturyKsiazki").ToLower())
                    uniqueSignatures = (Dt.Rows[i]["w_warunek"].ToString().Trim().ToLower() == "true" || Dt.Rows[i]["w_warunek"].ToString().Trim().ToLower() == "1");
                else if (Dt.Rows[i]["nazwa"].ToString().Trim().ToLower() == ("OstatnieSygnatury_NumeryInwentarzowe").ToLower() && (Dt.Rows[i]["w_warunek"].ToString().Trim().ToLower() == "true" || Dt.Rows[i]["w_warunek"].ToString().Trim().ToLower() == "1"))
                    label42.Text = _T("f2_last_invetories");
                else if (Dt.Rows[i]["nazwa"].ToString().Trim().ToLower() == ("UnikalneNumeryInwKsiazki").ToLower())
                    uniqueInvNo = (Dt.Rows[i]["w_warunek"].ToString().Trim().ToLower() == "true" || Dt.Rows[i]["w_warunek"].ToString().Trim().ToLower() == "1");
                else if (Dt.Rows[i]["nazwa"].ToString().Trim().ToLower() == ("UnikatyWidRodzaj").ToLower())
                    uniqueScope = (Dt.Rows[i]["w_warunek"].ToString().Trim().ToLower() == "true" || Dt.Rows[i]["w_warunek"].ToString().Trim().ToLower() == "1");
            }
        }

        #region void keySuggest(string text) - GOOD
        private void keySuggest(string text)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "EXEC SlowaKluczowePodpowiedz @text, @id_rodzaj, 1; ";
            command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
            command.Parameters.AddWithValue("@text", text);

            DataTable dt = CommonFunctions.ReadData(command, ref Settings.Connection);

            var source = new AutoCompleteStringCollection();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                source.Add(dt.Rows[i]["klucz"].ToString());
            }

            KeyTextBox.AutoCompleteCustomSource = source;
        }
        #endregion

        #region Lock() - GOOD
        private void Lock()
        {
            AddAuthorsButton.Enabled = false;

            MainTitleTextBox.ReadOnly = true;
            AdditionalTitleTextBox.ReadOnly = true;
            ParallelTitleTextBox.ReadOnly = true;
            TomsNumberTextBox.ReadOnly = true;
            BooksListButton.Enabled = false;

            //publisher
            AddPublisherButton.Enabled = false;
            CleanPublisherButton.Visible = false;
            SelectPublisherButton.Enabled = false;

            AddPublisher2Button.Enabled = false;
            CleanPublisher2Button.Visible = false;
            SelectPublisher2Button.Enabled = false;

            
            PublishVersionTextBox.ReadOnly = true;
            PublishYearTextBox.ReadOnly = true;
            LataWydTextBox.ReadOnly = true;
            ISBNTextBox.ReadOnly = true;
            ISBN2TextBox.ReadOnly = true;
            DescriptionTextBox.ReadOnly = true;
            WidthTextBox.ReadOnly = true;
            HeightTextBox.ReadOnly = true;
            UKDTextBox.ReadOnly = true;
            CommentsTextBox.ReadOnly = true;
            ChooseConferenceButton.Enabled = false;
            ConfCountryButton.Enabled = false;

            //konferencja
            CleanConferenceButton.Visible = false;
            CleanConfCountryButton.Visible = false;
            ConfTitleTextBox.ReadOnly = true;
            ConfNumberTextBox.ReadOnly = true;
            ConfCityTextBox.ReadOnly = true;
            ConfOrgTextBox.ReadOnly = true;
            ConferenceDateDTP.Enabled = false;
            ConferenceDateCheckBox.Enabled = false;

            //2 zakładka

            //klucze
            KeyListButton.Enabled = false;
            NewKeyButton.Enabled = false;
            DeleteKeyButton.Enabled = false;
            KeyTextBox.ReadOnly = true;

            //serie
            SerieShowButton.Enabled = false;
            SerieTitleTextBox.ReadOnly = true;
            ISSNTextBox.ReadOnly = true;
            NumberNameTextBox.ReadOnly = true;
            PartNameTextBox.ReadOnly = true;
            InsytTextBox.ReadOnly = true;

            //podserie
            SubSerieShowButton.Enabled = false;
            SubSerieTitleTextBox.ReadOnly = true;
            ISSNSubSerieTextBox.ReadOnly = true;
            PartNameSubSerieTextBox.ReadOnly = true;
            NumberNameSubSerieTextBox.ReadOnly = true;

            //forma zawartości
            FormAndContentComboBox.Enabled = false;

            //języki
            LangButton.Enabled = false;
            Lang2Button.Enabled = false;
            Lang3Button.Enabled = false;
            Lang4Button.Enabled = false;
            Lang5Button.Enabled = false;
            CleanLangButton.Visible = false;
            CleanLang2Button.Visible = false;
            CleanLang3Button.Visible = false;
            CleanLang4Button.Visible = false;
            CleanLang5Button.Visible = false;

            //streszczenia
            PolCheckBox.Enabled = false;
            EngCheckBox.Enabled = false;
            GerCheckBox.Enabled = false;
            FraCheckBox.Enabled = false;
            RusCheckBox.Enabled = false;

            //seria
            CleanSerieButton.Visible = false;

            //podseria
            CleanSubSerieButton.Visible = false;

            //3 zakładka
            NewSygButton.Enabled = false;
            EditSygButton.Enabled = false;
            DeleteSygButton.Enabled = false;
        }
        #endregion

        #region ChangeSygState(SygModeEnum State) - GOOD
        private void ChangeSygState(SygModeEnum State)
        {
            barCodeLabel.Text = SelectHighestBarcode();
            if (SposobNabyciaComboBox.Text == "" ) SposobNabyciaComboBox.Text = "KUPNO";

            bool EnabledCtrls;
            CurrentSygMode = State;
            SygRTB.ResetText();

            if (State == SygModeEnum.Add)
            {
                EnabledCtrls = true;
                Clear();
                SygnaturaTextBox.Select();
                SaveSygButton.Text = _T("add");                
            }
            else if (State == SygModeEnum.Edit)
            {
                EnabledCtrls = true;
                SygnaturaTextBox.Select();
                SaveSygButton.Text = _T("save");                
            }
            else
            {
                EnabledCtrls = false;
            }

            tabPage1.Enabled = !EnabledCtrls;
            tabPage2.Enabled = !EnabledCtrls;

            SaveButton.Enabled = !EnabledCtrls;
            TomsButton.Enabled = !EnabledCtrls;
            SourcesButton.Enabled = !EnabledCtrls;
            PrintButton.Enabled = !EnabledCtrls && CurrentMode == ModeEnum.Edit;
            ImportButton.Enabled = !EnabledCtrls;
            
            SygDGV.Enabled = !EnabledCtrls;
            CopySygToNumInwButton.Enabled = EnabledCtrls;
            
            SygnaturaTextBox.ReadOnly = !EnabledCtrls;
            NumerInwTextBox.ReadOnly = !EnabledCtrls;
            BarCodeTextBox.ReadOnly = !EnabledCtrls;
            NrDowoduTextBox.ReadOnly = !EnabledCtrls;
            SposobNabyciaComboBox.Enabled = EnabledCtrls;
            //PriceTextBox.ReadOnly = !EnabledCtrls;
            //ValueTextBox.ReadOnly = !EnabledCtrls;
            PriceNumericUpDown.ReadOnly = !EnabledCtrls;
            PriceNumericUpDown.Controls[0].Enabled = EnabledCtrls;
            ValueNumericUpDown.ReadOnly = !EnabledCtrls;
            ValueNumericUpDown.Controls[0].Enabled = EnabledCtrls;
            CurrencyTextBox.ReadOnly = !EnabledCtrls;
            //SygDateCheckBox.Enabled = EnabledCtrls;

            DateDTP.Enabled = EnabledCtrls;// && SygDateCheckBox.Checked;            

            SygCommentsRichTextBox.Enabled = EnabledCtrls;

            NewSygButton.Enabled = !EnabledCtrls;
            EditSygButton.Enabled = !EnabledCtrls;
            DeleteSygButton.Enabled = !EnabledCtrls;

            SaveSygButton.Visible = EnabledCtrls;
            CancelSygButton.Visible = EnabledCtrls;

            if (SygDGV.SelectedRows.Count == 0 || (SygDGV.SelectedRows.Count > 0 && SygDGV.SelectedRows[0].Index < 0))
            {
                EditSygButton.Enabled = false;
                DeleteSygButton.Enabled = false;
            }
        }
        #endregion

        #region string SelectHighestBarcode() - GOOD
        private string SelectHighestBarcode()
        {
            string tempBarcode = "";
            double tempMaxBarcodeInt = 0;
            double tempBarcodeInt = 0;

            for (int i = 0; i < SygDataTable.Rows.Count; i++)
            {
                double.TryParse(SygDataTable.Rows[i]["k_kreskowy"].ToString(), out tempBarcodeInt);

                if (tempBarcodeInt > tempMaxBarcodeInt)
                {
                    tempMaxBarcodeInt = tempBarcodeInt;
                    tempBarcode = SygDataTable.Rows[i]["k_kreskowy"].ToString();
                }
            }

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_NajwiekszyKodKreskowy; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {
                double.TryParse(Dt.Rows[0]["kod_kreskowy"].ToString(), out tempBarcodeInt);

                if (tempBarcodeInt > tempMaxBarcodeInt)
                    tempBarcode =  Dt.Rows[0]["kod_kreskowy"].ToString();
            }

            return "(" + tempBarcode + ")";
        }
        #endregion

        #region Clear() - GOOD
        private void Clear()
        {
            SygnaturaTextBox.Text = "";
            NumerInwTextBox.Text = "";
            BarCodeTextBox.Text = "";
            NrDowoduTextBox.Text = "";

            if (SposobNabyciaComboBox.Items.Count > 0)
                SposobNabyciaComboBox.SelectedValue = 1;

            //PriceTextBox.Text = "";
            //ValueTextBox.Text = "";

            PriceNumericUpDown.Value = 0;
            ValueNumericUpDown.Value = 0;

            CurrencyTextBox.Text = "PLN";
            DateDTP.Value = DateTime.Now;
            SygCommentsRichTextBox.Text = "";
        }
        #endregion

        #region CheckKeys() - Z39.50/REFACTORED
        private void CheckKeys()
        {           
            SqlCommand Command = new SqlCommand();                
            Command.CommandText = "EXEC Ksiazki_KeyExists @klucze, @id_rodzaj; ";                

            for (int i = 0; i < KeysDataGridView.Rows.Count; i++)
            {
                if (KeysDataGridView.Rows[i].Cells["id"].Value.ToString() == "-1")
                {
                    Command.Parameters.AddWithValue("@klucze", KeysDataGridView.Rows[i].Cells["Key"].Value.ToString());
                    Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

                    DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                    if (Dt.Rows.Count > 0)
                    {
                        KeysDataGridView.Rows[i].Cells["id"].Value = Dt.Rows[0]["kody"].ToString();
                        break;
                    }

                    Command.Parameters.Clear();
                }
            }
        }
        #endregion

        #region CheckConnection() - REFACTORED
        private bool CheckConnection()
        {
            return CommonFunctions.WriteData(new SqlCommand("SELECT 1;"), ref Settings.Connection);
        }
        #endregion

        private void SetToolTip()
        {
            // ZAKĹADKA 1
            ToolTip BooksListToolTip = new ToolTip();
            BooksListToolTip.SetToolTip(BooksListButton, _T("copy_book_description"));

            ToolTip AuthorsToolTip = new ToolTip();
            AuthorsToolTip.SetToolTip(AddAuthorsButton, _T("authorship_action"));

            // wydawca
            ToolTip PublisherToolTip = new ToolTip();
            PublisherToolTip.SetToolTip(AddPublisherButton, _T("add_editor"));
            PublisherToolTip.SetToolTip(AddPublisher2Button, _T("add_editor"));

            ToolTip CleanToolTip = new ToolTip();
            CleanToolTip.SetToolTip(CleanPublisherButton, _T("to_clean"));
            CleanToolTip.SetToolTip(CleanPublisher2Button, _T("to_clean"));
            CleanToolTip.SetToolTip(CleanConferenceButton, _T("to_clean"));
            CleanToolTip.SetToolTip(CleanLangButton, _T("to_clean"));
            CleanToolTip.SetToolTip(CleanLang2Button, _T("to_clean"));
            CleanToolTip.SetToolTip(CleanLang3Button, _T("to_clean"));
            CleanToolTip.SetToolTip(CleanLang4Button, _T("to_clean"));
            CleanToolTip.SetToolTip(CleanLang5Button, _T("to_clean"));
            CleanToolTip.SetToolTip(CleanConfCountryButton, _T("to_clean"));

            ToolTip SelectPublisherToolTip = new ToolTip();
            SelectPublisherToolTip.SetToolTip(SelectPublisherButton, _T("list_of_editors"));
            SelectPublisherToolTip.SetToolTip(SelectPublisher2Button, _T("list_of_editors"));

            // konferencja
            ToolTip ChooseConferenceButtonToolTip = new ToolTip();
            ChooseConferenceButtonToolTip.SetToolTip(ChooseConferenceButton, _T("copy_conference_title"));

            ToolTip ConfCountryToolTip = new ToolTip();
            ConfCountryToolTip.SetToolTip(ConfCountryButton, _T("choose_country"));

            ToolTip CalendarToolTip = new ToolTip();
            CalendarToolTip.SetToolTip(ConferenceDateDTP, _T("choose_date"));

            // drukuj
            ToolTip PrintToolTip = new ToolTip();
            PrintToolTip.SetToolTip(PrintButton, _T("print_001"));

            // tomy
            ToolTip TomesToolTip = new ToolTip();
            TomesToolTip.SetToolTip(TomsButton, _T("volume_action"));

            // ĹşrĂłdĹ‚a
            ToolTip SourcesToolTip = new ToolTip();
            SourcesToolTip.SetToolTip(SourcesButton, _T("add_attachments"));

            // ZAKĹADKA 2
            ToolTip KeyListToolTip = new ToolTip();
            KeyListToolTip.SetToolTip(KeyListButton, _T("list_of_keywords"));
            ToolTip NewKeyButtonToolTip = new ToolTip();
            NewKeyButtonToolTip.SetToolTip(NewKeyButton, _T("add_keyword"));
            ToolTip DeleteKeyButtonToolTip = new ToolTip();
            DeleteKeyButtonToolTip.SetToolTip(DeleteKeyButton, _T("delete_keyword"));

            ToolTip SerieShowButtonToolTip = new ToolTip();
            SerieShowButtonToolTip.SetToolTip(SerieShowButton, _T("copy_series_title"));

            ToolTip LangButtonToolTip = new ToolTip();
            LangButtonToolTip.SetToolTip(LangButton, _T("choose_language"));
            LangButtonToolTip.SetToolTip(Lang2Button, _T("choose_language"));
            LangButtonToolTip.SetToolTip(Lang3Button, _T("choose_language"));
            LangButtonToolTip.SetToolTip(Lang4Button, _T("choose_language"));
            LangButtonToolTip.SetToolTip(Lang5Button, _T("choose_language"));

            ToolTip SubSerieShowButtonToolTip = new ToolTip();
            SubSerieShowButtonToolTip.SetToolTip(SubSerieShowButton, _T("copy_subserias_title"));

            ToolTip CleanSubSerieShowButtonToolTip = new ToolTip();
            SubSerieShowButtonToolTip.SetToolTip(CleanSerieButton, _T("to_clean"));
            SubSerieShowButtonToolTip.SetToolTip(CleanSubSerieButton, _T("to_clean"));

            // ZAKĹADKA 3
            ToolTip NewSygButtonToolTip = new ToolTip();
            NewSygButtonToolTip.SetToolTip(NewSygButton, _T("add_signature"));

            ToolTip EditSygButtonToolTip = new ToolTip();
            EditSygButtonToolTip.SetToolTip(EditSygButton, _T("edit_signature"));

            ToolTip DeleteSygButtonToolTip = new ToolTip();
            DeleteSygButtonToolTip.SetToolTip(DeleteSygButton, _T("delete_signature"));

            ToolTip CopySygButtonToolTip = new ToolTip();
            CopySygButtonToolTip.SetToolTip(CopySygToNumInwButton, _T("copy_signature_and_title"));

            // kod kreskowy
            ToolTip BarCodeLabelToolTip = new ToolTip();
            BarCodeLabelToolTip.SetToolTip(barCodeLabel, _T("last_barcodelabel"));
        }

        #region ContentFormDictionary() - GOOD
        //Tworzy sĹ‚ownik do FormAndContentComboBox
        private void ContentFormDictionary()
        {
            ContentFormComboboxValues = new Dictionary<int, string>();

            ContentFormComboboxValues.Add(1, "");
            ContentFormComboboxValues.Add(2, _T("atlas"));
            ContentFormComboboxValues.Add(3, _T("bibliography"));
            ContentFormComboboxValues.Add(4, _T("biography"));
            ContentFormComboboxValues.Add(5, _T("chronology"));
            ContentFormComboboxValues.Add(6, _T("documents"));
            ContentFormComboboxValues.Add(7, _T("encyclopedia"));
            ContentFormComboboxValues.Add(8, _T("forms"));
            ContentFormComboboxValues.Add(9, _T("informer"));
            ContentFormComboboxValues.Add(10, _T("factual_classification"));
            ContentFormComboboxValues.Add(11, _T("codex"));
            ContentFormComboboxValues.Add(12, _T("comment"));
            ContentFormComboboxValues.Add(13, _T("lexicon"));
            ContentFormComboboxValues.Add(14, _T("map"));
            ContentFormComboboxValues.Add(15, _T("monography"));
            ContentFormComboboxValues.Add(16, _T("user_guide"));
            ContentFormComboboxValues.Add(17, _T("guide"));
            ContentFormComboboxValues.Add(18, _T("losses_report"));
            ContentFormComboboxValues.Add(19, _T("script"));

            FormAndContentComboBox.DataSource = new BindingSource(ContentFormComboboxValues, null);
            FormAndContentComboBox.DisplayMember = "Value";
            FormAndContentComboBox.ValueMember = "Key";
        }
        #endregion

        #region ClearChars() - Z39.50/GOOD
        //Czyści znaki ":" i "/"
        private void ClearChars()
        {
            MainTitleTextBox.Text = MainTitleTextBox.Text.Trim();

            switch(MainTitleTextBox.Text[MainTitleTextBox.Text.Length - 1].ToString())
            {
                case ":": 
                case "/": MainTitleTextBox.Text = MainTitleTextBox.Text.Remove(MainTitleTextBox.Text.Length - 1);
                          break;
            }
        }
        #endregion

        #region CheckLanguages() - Z39.50/REFACTORED
        //Sprawdza, czy język jest w bazie
        private void CheckLanguages()
        {
            List<string> TempTextLanguagesList = new List<string>();
            TempTextLanguagesList.AddRange(TextLanguagesList);

            List<string> TempShortLanguagesList = new List<string>();
            TempShortLanguagesList.AddRange(ShortLanguagesList);

            SqlCommand Command = new SqlCommand();
            //Command.CommandText = "SELECT COUNT(*) FROM jezyki WHERE jezyk = ?";
            Command.CommandText = "EXEC Ksiazki_LanguageExists @jezyk; ";

            Command.Parameters.AddWithValue("@jezyk", "");

            DataTable Dt;

            foreach (string Lang in TextLanguagesList)
            {
                Command.Parameters["@jezyk"].Value = Lang;

                Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if(Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0][0].ToString() == "-1")                    
                        TempTextLanguagesList.Remove(Lang); 
                    else
                    {
                        if (LangTextBox.Text.Trim() == "")
                        { 
                            LangTextBox.Text = Lang;
                            LangID = Dt.Rows[0][0].ToString();
                        }
                        else if (Lang2TextBox.Text.Trim() == "")
                        { 
                            LangTextBox.Text = Lang;
                            Lang2ID = Dt.Rows[0][0].ToString();
                        }
                        else if (Lang3TextBox.Text.Trim() == "")
                        { 
                            LangTextBox.Text = Lang;
                            Lang3ID = Dt.Rows[0][0].ToString();
                        }
                        else if (Lang4TextBox.Text.Trim() == "")
                        { 
                            LangTextBox.Text = Lang;
                            Lang4ID = Dt.Rows[0][0].ToString();
                        }
                        else if (Lang5TextBox.Text.Trim() == "")
                        { 
                            LangTextBox.Text = Lang;
                            Lang5ID = Dt.Rows[0][0].ToString();
                        }
                    }                    
                }
            }

            foreach (string Lang in ShortLanguagesList)
            {
                Command.Parameters["@jezyk"].Value = Lang;

                Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0][0].ToString() == "0")
                        TempShortLanguagesList.Remove(Lang);
                }
            }

            TextLanguagesList = TempTextLanguagesList;
            ShortLanguagesList = TempShortLanguagesList;
        }
        #endregion

        #region LoadLanguagesIntoControls() - Z39.50/GOOD
        //Ładuje informacje o językach do TextBoxów i CheckBoxów
        private void LoadLanguagesIntoControls()
        {
           /* foreach (string Lang in TextLanguagesList)
            {
                if (LangTextBox.Text.Trim() == "")
                    LangTextBox.Text = Lang;
                else if (Lang2TextBox.Text.Trim() == "")
                    LangTextBox.Text = Lang;
                else if (Lang3TextBox.Text.Trim() == "")
                    LangTextBox.Text = Lang;
                else if (Lang4TextBox.Text.Trim() == "")
                    LangTextBox.Text = Lang;
                else if (Lang5TextBox.Text.Trim() == "")
                    LangTextBox.Text = Lang;
            }*/

            foreach (string Lang in ShortLanguagesList)
            {
                if (Lang.ToLower() == "pol")
                    PolCheckBox.Checked = true;
                else if (Lang.ToLower() == "eng")
                    EngCheckBox.Checked = true;
                else if (Lang.ToLower() == "ger")
                    GerCheckBox.Checked = true;
                else if (Lang.ToLower() == "fre")
                    FraCheckBox.Checked = true;
                else if (Lang.ToLower() == "rus")
                    RusCheckBox.Checked = true;
            }
        }
        #endregion

        #region LoadAuthorsToTextBox(bool FirstLoad) - GOOD
        //Ładowanie informacji o autorach
        private void LoadAuthorsToTextBox(bool FirstLoad)
        {           
            //if (AuthorsDt.Rows.Count == 0 && CoAuthorsDt.Rows.Count == 0 && InstitutionsList.Count == 0)
            if (FirstLoad)
            {
                if (AuthorsDt.Rows.Count == 0 && CoAuthorsDt.Rows.Count == 0 && InstitutionsList.Count == 0)
                    authorsForm = new AuthorsForm(Array);
                else
                    authorsForm = new AuthorsForm(AuthorsDt, CoAuthorsDt, InstitutionsList);

                ProcessAuthors(authorsForm);
            }
            else
            {
                ActiveReason = FormActivate.faAuthorsForm;                
                authorsForm = new AuthorsForm(AuthorsDt, CoAuthorsDt, InstitutionsList, this);
                //authorsForm.Owner = this;
                authorsForm.Show();
            }

            /*if (Res == System.Windows.Forms.DialogResult.OK || FirstLoad)
            {
                this.AuthorsDt = authorsForm.AuthorsDt;
                this.CoAuthorsDt = authorsForm.CoAuthorsDt;
                this.AuthorsToDelete.AddRange(authorsForm.AuthorsToDelete);
                this.CoAuthorsToDelete.AddRange(authorsForm.CoAuthorsToDelete);
                this.InstitutionsList = authorsForm.InstitutionsList;

                AuthorsTextBox.Clear();

                AuthorsTextBox.AppendText("Autorzy:\r\n");
                for (int i = 0; i < authorsForm.AuthorsDt.Rows.Count; i++)
                {                                        
                    AuthorsTextBox.Text += "\t" + (i + 1).ToString() + ". " + authorsForm.AuthorsDt.Rows[i]["imie"].ToString() + " " + authorsForm.AuthorsDt.Rows[i]["nazwisko"].ToString() + "\r\n";
                }

                AuthorsTextBox.AppendText("Współtwórcy:\r\n");
                for (int i = 0; i < authorsForm.CoAuthorsDt.Rows.Count; i++)
                {
                    AuthorsTextBox.AppendText("\t" + (i + 1).ToString() + ". " + authorsForm.CoAuthorsDt.Rows[i]["imie"].ToString() + " " + authorsForm.CoAuthorsDt.Rows[i]["nazwisko"].ToString() + " - " + authorsForm.CoAuthorsDt.Rows[i]["odpow"].ToString() + "\r\n");
                }

                AuthorsTextBox.AppendText("Instytucje sprawcze:\r\n");
                for (int i = 0; i < authorsForm.InstitutionsList.Count; i++)
                {
                    string[] temp = authorsForm.InstitutionsList[i];
                    AuthorsTextBox.AppendText("\t" + (i + 1).ToString() + ". " + temp[0] + " " + temp[1] + "\r\n");
                }
            }*/
        }
        #endregion

        #region void ProcessAuthors(AuthorsForm authorsForm)
        private void ProcessAuthors(AuthorsForm authorsForm)
        {
            this.AuthorsDt = authorsForm.AuthorsDt;
            this.CoAuthorsDt = authorsForm.CoAuthorsDt;
            this.AuthorsToDelete.AddRange(authorsForm.AuthorsToDelete);
            this.CoAuthorsToDelete.AddRange(authorsForm.CoAuthorsToDelete);
            this.InstitutionsList = authorsForm.InstitutionsList;


            AuthorsTextBox.Clear();

            AuthorsTextBox.AppendText("Autorzy:\r\n");
            for (int i = 0; i < authorsForm.AuthorsDt.Rows.Count; i++)
            {
                AuthorsTextBox.Text += "\t" + (i + 1).ToString() + ". " + authorsForm.AuthorsDt.Rows[i]["imie"].ToString().ToUpper() + " " + authorsForm.AuthorsDt.Rows[i]["nazwisko"].ToString().ToUpper() + Environment.NewLine;
            }

            AuthorsTextBox.AppendText("Współtwórcy:\r\n");
            for (int i = 0; i < authorsForm.CoAuthorsDt.Rows.Count; i++)
            {
                AuthorsTextBox.AppendText("\t" + (i + 1).ToString() + ". " + authorsForm.CoAuthorsDt.Rows[i]["imie"].ToString().ToUpper() + " " + authorsForm.CoAuthorsDt.Rows[i]["nazwisko"].ToString().ToUpper() + " - " + authorsForm.CoAuthorsDt.Rows[i]["odpow"].ToString().ToUpper() + Environment.NewLine);
            }

            AuthorsTextBox.AppendText("Instytucje sprawcze:\r\n");
            for (int i = 0; i < authorsForm.InstitutionsList.Count; i++)
            {
                string[] temp = authorsForm.InstitutionsList[i];
                AuthorsTextBox.AppendText("\t" + (i + 1).ToString() + ". " + temp[0] + " " + temp[1] + Environment.NewLine);
            }
        }
        #endregion

        #region LoadPublishers() - Z39.50/REFACTORED
        private void LoadPublishers()
        {
            SqlCommand Command = new SqlCommand();            
            Command.CommandText = "EXEC Ksiazki_PublisherExists @Name, @City, @id_rodzaj; ";

            for (int i = 0; i < PublishersList.Count && i < 2; i++)
            {
                if (i == 0)
                {
                    if (PublishersList[i].ElementAt(0) != null)
                        PublisherTextBox.Text = PublishersList[i].ElementAt(0).Trim();
                    if (PublishersList[i].ElementAt(1) != null)
                        PlaceTextBox.Text = PublishersList[i].ElementAt(1).Trim();

                    if (!IsInDb(Command, PublisherTextBox.Text, PlaceTextBox.Text))
                        PublisherLabel.Visible = true;
                    else
                        SelectPublisherID(PublisherTextBox.Text, PlaceTextBox.Text, ref PublishersID[0]);
                }
                else
                {
                    if (PublishersList[i].ElementAt(0) != null)
                        Publisher2TextBox.Text = PublishersList[i].ElementAt(0).Trim();
                    if (PublishersList[i].ElementAt(1) != null)
                        Place2TextBox.Text = PublishersList[i].ElementAt(1).Trim();

                    if (!IsInDb(Command, Publisher2TextBox.Text, Place2TextBox.Text))
                        Publisher2Label.Visible = true;
                    else
                    {
                        SelectPublisherID(Publisher2TextBox.Text, Place2TextBox.Text, ref PublishersID[1]);
                    }
                }
            }
        }
        #endregion

        #region SelectPublisherID(string Name, string Place, ref string Value) - REFACTORED
        private void SelectPublisherID(string Name, string Place, ref string Value)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_PublisherExists @Name, @City, @id_rodzaj; ";
            Command.Parameters.AddWithValue("@Name", Name);
            Command.Parameters.AddWithValue("@City", Place);
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if(Dt.Rows.Count > 0)
            {
                Value = Dt.Rows[0][0].ToString();                
            }                     
        }
        #endregion

        #region ExitButton - GOOD
        //Obsługa przycisku wyjścia
        private void ExitButton_Click(object sender, EventArgs e)
        {    
            this.Close();            
        }
        #endregion

        #region AddAuthorsButton - GOOD
        //Obsługa przycisku dodawania autorów
        private void AddAuthorsButton_Click(object sender, EventArgs e)
        {
            LoadAuthorsToTextBox(false);
        }
        #endregion

        #region SelectPublisherButton i SelectPublisher2Button - GOOD
        //Obsługa przycisków wybierania autora z listy dostępnych w bazie danych
        private void SelectPublisherButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC PublishersList;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "nazwa_w";
            Columns[1].Name = "nazwa_w";
            Columns[1].HeaderText = _T("publisher_name");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "miasto_w";
            Columns[2].Name = "Miasto";
            Columns[2].HeaderText = _T("city");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns, false, "Nazwa_w", BookListForm.ModeEnum.Edit, "P");
            Formka.Text = _T("select_001");

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PublisherTextBox.Text = Formka.Dt.Cells["Nazwa_w"].Value.ToString();
                PlaceTextBox.Text = Formka.Dt.Cells["Miasto"].Value.ToString();
                PublishersID[0] = Formka.Dt.Cells["id"].Value.ToString();
                PublisherLabel.Visible = false;

                AddPublisherButton.Enabled = false;
            }
        }

        private void SelectPublisher2Button_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC PublishersList;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "nazwa_w";
            Columns[1].Name = "Nazwa w";
            Columns[1].HeaderText = _T("publisher_name");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "miasto_w";
            Columns[2].Name = "Miasto";
            Columns[2].HeaderText = _T("city");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns, false, "Nazwa_w");
            Formka.Text = _T("select_001");

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Publisher2TextBox.Text = Formka.Dt.Cells["Nazwa w"].Value.ToString();
                Place2TextBox.Text = Formka.Dt.Cells["Miasto"].Value.ToString();
                PublishersID[1] = Formka.Dt.Cells["id"].Value.ToString();
                Publisher2Label.Visible = false;

                AddPublisher2Button.Enabled = false;
            }
        }
        #endregion

        #region AddPublisherButton_Click(object sender, EventArgs e) - GOOD
        private void AddPublisherButton_Click(object sender, EventArgs e)
        {
            PublisherForm Publisher = new PublisherForm(PublisherTextBox.Text, PlaceTextBox.Text);

            if (Publisher.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (PublishersList.Count > 0)                
                    PublishersList[0] = Publisher.Publisher;                                    
                else
                    PublishersList.Add(Publisher.Publisher);

                if(PublishersID.Length > 0)
                    PublishersID[0] = null;

                PublisherTextBox.Text = Publisher.Publisher.ElementAt(0);
                PlaceTextBox.Text = Publisher.Publisher.ElementAt(2);
                PublisherLabel.Visible = true;
            }
        }
        #endregion

        #region AddPublisher2Button_Click(object sender, EventArgs e) - GOOD
        private void AddPublisher2Button_Click(object sender, EventArgs e)
        {
            PublisherForm Publisher = new PublisherForm(Publisher2TextBox.Text, Place2TextBox.Text);

            if (Publisher.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (PublishersList.Count > 1)
                    PublishersList[1] = Publisher.Publisher;
                else
                    PublishersList.Add(Publisher.Publisher);

                if (PublishersID.Length > 1)
                    PublishersID[1] = null;

                Publisher2TextBox.Text = Publisher.Publisher.ElementAt(0);
                Place2TextBox.Text = Publisher.Publisher.ElementAt(2);

                Publisher2Label.Visible = true;
            }
        }
        #endregion

        #region IsInDb(SqlCommand Command, string First, string Second) - REFACTORED
        //Sprawdzenie, czy coś jest w bazie
        private bool IsInDb(SqlCommand Command, string First, string Second)
        {            
            if (First == null)
                First = "";
            if (Second == null)
                Second = "";
            if (Command.Parameters.Count == 0)
            {
                Command.Parameters.AddWithValue("@Name", First);
                Command.Parameters.AddWithValue("@City", Second);
                Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
            }

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if(Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][0].ToString() != "-1")
                {
                    return true;
                }
            }
                        
            return false;
        }
        #endregion

        #region NewKeyButton_Click(object sender, EventArgs e) - REFACTORED
        private void NewKeyButton_Click(object sender, EventArgs e)
        {            
            if (KeyTextBox.Text.Trim() == "")
                return;

            try
            {
                SqlCommand Command = new SqlCommand();                
                Command.CommandText = "EXEC Ksiazki_KeyExists @klucze, @id_rodzaj; ";
                Command.Parameters.AddWithValue("@klucze", KeyTextBox.Text);
                Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);
                lEdit = true;
                if (Dt.Rows.Count > 0)
                {
                    bool NewRow = true;

                    foreach (DataGridViewRow Row in KeysDataGridView.Rows)
                    {
                        if (Row.Cells["id"].Value.ToString().ToLower() == Dt.Rows[0]["kody"].ToString().ToLower())
                        {
                            NewRow = false;
                            break;
                        }
                    }

                    if (NewRow)
                        KeysDataGridView.Rows.Add(Dt.Rows[0].ItemArray);
                }
                else
                {
                    if (MessageBox.Show(_T("key_not_found_add_it"), _T("adding_key"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Command.CommandText = "EXEC Ksiazki_AddKey @klucze, @id_rodzaj, @KeyID OUTPUT;";

                        Command.Parameters.Clear();
                        Command.Parameters.AddWithValue("@klucze", KeyTextBox.Text.Trim());
                        Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

                        SqlParameter KeyIDParameter = new SqlParameter();
                        KeyIDParameter.ParameterName = "@KeyID";
                        KeyIDParameter.SqlDbType = SqlDbType.Int;
                        KeyIDParameter.Direction = ParameterDirection.Output;
                        Command.Parameters.Add(KeyIDParameter);

                        if (CommonFunctions.WriteData(ref Command, ref Settings.Connection))
                            KeysDataGridView.Rows.Add(new string[] { KeyIDParameter.Value.ToString(), KeyTextBox.Text.Trim() });
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _T("error"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            KeysDataGridView.Sort(KeysDataGridView.Columns["Key"], ListSortDirection.Ascending);
        }
        #endregion

        #region KeyListButton_Click(object sender, EventArgs e) - GOOD
        private void KeyListButton_Click(object sender, EventArgs e)
        {
            ShowKeyListForm KeyListWindow = new ShowKeyListForm(KeysDataGridView);

            if (KeyListWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                bool NotExists = true;

                for (int i = 0; i < KeysDataGridView.Rows.Count; i++)
                {
                    NotExists = true;

                    for (int j = 0; j < KeyListWindow.SelectedDataGridView.Rows.Count; j++)
                    {
                        if (KeysDataGridView.Rows[i].Cells["id"].Value.ToString() == KeyListWindow.SelectedDataGridView.Rows[j].Cells["id"].Value.ToString())
                            NotExists = false;
                    }

                    if (NotExists)
                        KeysToDelete.Add(KeysDataGridView.Rows[i].Cells["id"].Value.ToString());
                }

                if (KeysDataGridView.Rows.Count > 0)
                    KeysDataGridView.Rows.Clear();

                foreach(DataGridViewRow Row in KeyListWindow.SelectedDataGridView.Rows)
                {
                    //KeyList.Add(new string[] { Row.Cells["id"].Value.ToString(), Row.Cells["Key"].Value.ToString() });
                    KeysDataGridView.Rows.Add(new string[] { Row.Cells["id"].Value.ToString(), Row.Cells["Key"].Value.ToString() });
                }
            }
        }
        #endregion

        #region KeysDataGridView_CellClick(object sender, DataGridViewCellEventArgs e) - GOOD
        private void KeysDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            KeyTextBox.Text = KeysDataGridView.CurrentCell.Value.ToString();
        }
        #endregion

        #region KeyTextBox_Enter(object sender, EventArgs e) - GOOD
        private void KeyTextBox_Enter(object sender, EventArgs e)
        {
            KeysDataGridView.ClearSelection();
            KeyTextBox.Text = "";
        }
        #endregion

        #region KeyTextBox_KeyDown(object sender, KeyEventArgs e) - GOOD
        private void KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                NewKeyButton_Click(sender, e);
        }
        #endregion

        #region DeleteKeyButton_Click(object sender, EventArgs e) - GOOD
        private void DeleteKeyButton_Click(object sender, EventArgs e)
        {
            if (KeysDataGridView.SelectedRows.Count > 0)
                KeysToDelete.Add(KeysDataGridView.SelectedRows[0].Cells["id"].Value.ToString());

            //foreach (DataGridViewCell Cell in KeysDataGridView.SelectedCells)
            //    KeysDataGridView.Rows.RemoveAt(Cell.RowIndex);     

            foreach (DataGridViewRow Row in KeysDataGridView.SelectedRows)
                KeysDataGridView.Rows.RemoveAt(Row.Index);  

            KeyTextBox.Text = "";
            lEdit = true;
        }
        #endregion

        #region Obsługa przycisów języków - REFACTORED
        private void LangButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC ListaJezykow;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "jezyk";
            Columns[2].Name = "Język";
            Columns[2].HeaderText = _T("language");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "kod";
            Columns[1].Name = "Kod";
            Columns[1].HeaderText = _T("code");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _T("choose_language");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LangTextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();
                LangID = Formka.Dt.Cells["id"].Value.ToString();
            }
        }

        private void Lang2Button_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC ListaJezykow;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "jezyk";
            Columns[2].Name = "Język";
            Columns[2].HeaderText = _T("language");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "kod";
            Columns[1].Name = "Kod";
            Columns[1].HeaderText = _T("code");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _T("choose_laguage");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Lang2TextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();
                Lang2ID = Formka.Dt.Cells["id"].Value.ToString();
            }
        }

        private void Lang3Button_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC ListaJezykow;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "jezyk";
            Columns[2].Name = "Język";
            Columns[2].HeaderText = _T("language");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "kod";
            Columns[1].Name = "Kod";
            Columns[1].HeaderText = _T("code");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _T("choose_laguage");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Lang3TextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();
                Lang3ID = Formka.Dt.Cells["id"].Value.ToString();
            }
        }

        private void Lang4Button_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC ListaJezykow;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "jezyk";
            Columns[2].Name = "Język";
            Columns[2].HeaderText = _T("language");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "kod";
            Columns[1].Name = "Kod";
            Columns[1].HeaderText = _T("code");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _T("choose_language");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Lang4TextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();
                Lang4ID = Formka.Dt.Cells["id"].Value.ToString();
            }
        }

        private void Lang5Button_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC ListaJezykow;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "jezyk";
            Columns[2].Name = "Język";
            Columns[2].HeaderText = _T("language");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "kod";
            Columns[1].Name = "Kod";
            Columns[1].HeaderText = _T("code");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _T("choose_language");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Lang5TextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();
                Lang5ID = Formka.Dt.Cells["id"].Value.ToString();
            }
        }
        #endregion

        #region SerieShowButton_Click(object sender, EventArgs e) - REFACTORED
        private void SerieShowButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_SerieList @id_rodzaj;";
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

            DataGridViewColumn[] Columns = new DataGridViewColumn[4];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "tyt_serii";
            Columns[1].Name = "Tytuł serii";
            Columns[1].HeaderText = _T("series_title");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "inst_serii";
            Columns[2].Name = "Instytucja serii";
            Columns[2].HeaderText = _T("series_promoter");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            Columns[3] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[3].DataPropertyName = "ISSN";
            Columns[3].Name = "ISSN";
            Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            ShowForm Formka = new ShowForm(Command, Columns);

            Formka.Text = _T("choose_institution_001");
            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SerieTitleTextBox.Text = Formka.Dt.Cells["Tytuł serii"].Value.ToString();
                InsytTextBox.Text = Formka.Dt.Cells["Instytucja serii"].Value.ToString();
                ISSNTextBox.Text = Formka.Dt.Cells["ISSN"].Value.ToString();
                IDSerie = Formka.Dt.Cells["id"].Value.ToString();

                SerieTitleTextBox.ReadOnly = true;
                InsytTextBox.ReadOnly = true;
                ISSNTextBox.ReadOnly = true;
                /*
                PartNameTextBox.Text = Formka.Dt.Cells["Nazwa czÄ™Ĺ›ci"].Value.ToString();
                NumberNameTextBox.Text = Formka.Dt.Cells["Numer czÄ™Ĺ›ci"].Value.ToString();*/
            }
        }
        #endregion

        #region SaveButton_Click(object sender, EventArgs e) - GOOD
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Import();            
        }
        #endregion

        #region bool CheckSave(bool NoMessage = false)
        private bool CheckSave(bool NoMessage = false)
        {

            HeightTextBox.Text = HeightTextBox.Text.Trim();
            PublishYearTextBox.Text = PublishYearTextBox.Text.Trim();
            WidthTextBox.Text = WidthTextBox.Text.Trim();

            foreach (char a in HeightTextBox.Text.AsQueryable())
            {
                if (!Char.IsDigit(a))
                {
                    MessageBox.Show(_T("heigth_only_digits"), _T("data_incorrect"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (HeightTextBox.Text.Length > 2)
            {
                MessageBox.Show(_T("heigth_only_two_digits"), _T("data_incorrect"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (WidthTextBox.Text.Length > 2)
            {
                MessageBox.Show(_T("width_only_two_digits"), _T("data_incorrect"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            foreach (char a in PublishYearTextBox.Text.AsQueryable())
            {
                if (!Char.IsDigit(a))
                {
                    MessageBox.Show(_T("year_only_digits"), _T("data_incorrect"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            foreach (char a in WidthTextBox.Text.AsQueryable())
            {
                if (!Char.IsDigit(a))
                {
                    MessageBox.Show(_T("width_only_digits"), _T("data_incorrect"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (MainTitleTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show(_T("enter_book_title"), _T("data_fillout"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
            //return Import();            
        }
        #endregion

        #region SubSerieShowButton_Click(object sender, EventArgs e) - GOOD
        private void SubSerieShowButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC SubseriesList; ");

            DataGridViewColumn[] Columns = new DataGridViewColumn[2];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "tyt_pserii";
            Columns[0].Name = "tyt_pserii";
            Columns[0].HeaderText = _T("subseries_title");
            Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "pissn";
            Columns[1].Name = "pissn";
            Columns[1].HeaderText = _T("subseries_issn");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _T("select_001");

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SubSerieTitleTextBox.Text = Formka.Dt.Cells["tyt_pserii"].Value.ToString();
                ISSNSubSerieTextBox.Text = Formka.Dt.Cells["pissn"].Value.ToString();
            }
        }
        #endregion

        #region Import()
        private bool Import(bool NoMessage = false)
        {

            if (!CheckSave())
                return false;

            lEdit = lEdit || CurrentMode == ModeEnum.Add || _dirtyTracker.IsDirty;
            if (!lEdit) return true;

            try
            {
                string[] temp;

                SqlCommand CommandSql = new SqlCommand();

                //Dodanie wydawców
                for (int i = 0; i < 2; i++)
                {
                    SqlParameter WydParam = new SqlParameter();
                    WydParam.ParameterName = "@id_wyd" + (i + 1);
                    WydParam.Direction = ParameterDirection.InputOutput;
                    WydParam.SqlDbType = SqlDbType.Int;
                    WydParam.SqlValue = DBNull.Value;

                    CommandSql.Parameters.Add(WydParam);
                }                                

                for (int i = 0; i < PublishersID.Length; i++)
                {
                    if (!string.IsNullOrEmpty(PublishersID[i]))
                    {
                        CommandSql.Parameters["@id_wyd" + (i + 1)].Value = PublishersID[i];
                    }
                }

                int TempPubCount = 0;

                if (string.IsNullOrEmpty(PublishersID[0]) && string.IsNullOrEmpty(PublishersID[1]))
                    TempPubCount = 0;
                else if (!string.IsNullOrEmpty(PublishersID[0]))
                    TempPubCount = 1;
                else                
                    TempPubCount = 0;
                
                for (int j = 0, i = TempPubCount; j < PublishersList.Count; j++, i++)
                {
                    temp = PublishersList[j];

                    if (temp.Length >= 6 && temp[6] == "new")
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_AddPublisher @nazwa_w" + (j + 1) + ", @sk_nazwa" + (j + 1) + ", @id_panst_w" + (j + 1) + ", @miasto_w" + (j + 1) + ", @kontakt_w" + (j + 1) + ", @adres_w" + (j + 1) + ", @id_rodzaj" + ", @id_wyd" + (i + 1) + " OUTPUT; ";

                        CommandSql.Parameters.AddWithValue("@nazwa_w" + (j + 1), temp[0]);
                        CommandSql.Parameters.AddWithValue("@sk_nazwa" + (j + 1), temp[1]);
                        CommandSql.Parameters.AddWithValue("@id_panst_w" + (j + 1), temp[5]);
                        CommandSql.Parameters.AddWithValue("@miasto_w" + (j + 1), temp[2]);
                        CommandSql.Parameters.AddWithValue("@kontakt_w" + (j + 1), temp[4]);
                        CommandSql.Parameters.AddWithValue("@adres_w" + (j + 1), temp[3]);
                        CommandSql.Parameters.AddWithValue("@p_rodz_wyd" + (j + 1), DBNull.Value);
                    }
                    else if (string.IsNullOrEmpty(PublishersID[0]) && !string.IsNullOrEmpty(PublisherTextBox.Text.Trim()) && !string.IsNullOrEmpty(PlaceTextBox.Text.Trim()))
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_AddPublisher @nazwa_w" + (j + 1) + ", @sk_nazwa" + (j + 1) + ", @id_panst_w" + (j + 1) + ", @miasto_w" + (j + 1) + ", @kontakt_w" + (j + 1) + ", @adres_w" + (j + 1) + ", @id_rodzaj" + ", @id_wyd" + (i + 1) + " OUTPUT; ";

                        CommandSql.Parameters.AddWithValue("@nazwa_w" + (j + 1), PublisherTextBox.Text);
                        CommandSql.Parameters.AddWithValue("@sk_nazwa" + (j + 1), PublisherTextBox.Text);
                        CommandSql.Parameters.AddWithValue("@id_panst_w" + (j + 1), "");
                        CommandSql.Parameters.AddWithValue("@miasto_w" + (j + 1), PlaceTextBox.Text);
                        CommandSql.Parameters.AddWithValue("@kontakt_w" + (j + 1), "");
                        CommandSql.Parameters.AddWithValue("@adres_w" + (j + 1), "");
                        CommandSql.Parameters.AddWithValue("@p_rodz_wyd" + (j + 1), DBNull.Value);
                    }
                    else if (string.IsNullOrEmpty(PublishersID[1]) && !string.IsNullOrEmpty(Publisher2TextBox.Text.Trim()) && !string.IsNullOrEmpty(Place2TextBox.Text.Trim()))
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_AddPublisher @nazwa_w" + (j + 1) + ", @sk_nazwa" + (j + 1) + ", @id_panst_w" + (j + 1) + ", @miasto_w" + (j + 1) + ", @kontakt_w" + (j + 1) + ", @adres_w" + (j + 1) + ", @id_rodzaj" + ", @id_wyd" + (i + 1) + " OUTPUT; ";

                        CommandSql.Parameters.AddWithValue("@nazwa_w" + (j + 1), Publisher2TextBox.Text);
                        CommandSql.Parameters.AddWithValue("@sk_nazwa" + (j + 1), Publisher2TextBox.Text);
                        CommandSql.Parameters.AddWithValue("@id_panst_w" + (j + 1), "");
                        CommandSql.Parameters.AddWithValue("@miasto_w" + (j + 1), Place2TextBox.Text);
                        CommandSql.Parameters.AddWithValue("@kontakt_w" + (j + 1), "");
                        CommandSql.Parameters.AddWithValue("@adres_w" + (j + 1), "");
                        CommandSql.Parameters.AddWithValue("@p_rodz_wyd" + (j + 1), DBNull.Value);
                    }  
                }                

                //Dodanie książki
                CommandSql.CommandText += "EXEC Ksiazki_ModifyKsiazka @p_tytul, @id_wyd1, @id_wyd2, @p_wydanie, @p_rok_wyd, @p_lata_wyd, @p_strony, @p_isbn, @p_isbn2, @p_il_tomow, @p_wysokosc, @p_dlugosc, @p_zawartosc, @p_s_pol, @p_s_ang, @p_s_niem, @p_s_fra, @p_s_ros, @p_ukd, @p_uwagi, @p_rodzajnik, @id_rodzaj, @mode, @BookID OUTPUT; ";
                CommandSql.Parameters.AddWithValue("@p_tytul", MainTitleTextBox.Text.Trim());

                CommandSql.Parameters.AddWithValue("@p_wydanie", PublishVersionTextBox.Text.Trim());

                if (PublishYearTextBox.Text.Trim() != "")
                    CommandSql.Parameters.AddWithValue("@p_rok_wyd", PublishYearTextBox.Text.Trim());
                else
                    CommandSql.Parameters.AddWithValue("@p_rok_wyd", DBNull.Value);

                CommandSql.Parameters.AddWithValue("@p_lata_wyd", LataWydTextBox.Text.Trim());
                CommandSql.Parameters.AddWithValue("@p_strony", DescriptionTextBox.Text);
                CommandSql.Parameters.AddWithValue("@p_isbn", ISBNTextBox.Text.Trim());
                CommandSql.Parameters.AddWithValue("@p_isbn2", ISBN2TextBox.Text.Trim());
                CommandSql.Parameters.AddWithValue("@p_il_tomow", TomsNumberTextBox.Text.Trim());

                if (HeightTextBox.Text != "")
                    CommandSql.Parameters.AddWithValue("@p_wysokosc", HeightTextBox.Text);                
                else
                    CommandSql.Parameters.AddWithValue("@p_wysokosc", DBNull.Value);
                
                if (WidthTextBox.Text != "")                
                    CommandSql.Parameters.AddWithValue("@p_dlugosc", WidthTextBox.Text);                
                else
                    CommandSql.Parameters.AddWithValue("@p_dlugosc", DBNull.Value);

                if (FormAndContentComboBox.SelectedValue != null)
                    CommandSql.Parameters.AddWithValue("@p_zawartosc", FormAndContentComboBox.SelectedValue.ToString());
                else
                    CommandSql.Parameters.AddWithValue("@p_zawartosc", 1);

                CommandSql.Parameters.AddWithValue("@p_s_pol", PolCheckBox.Checked.ToString());
                CommandSql.Parameters.AddWithValue("@p_s_ang", EngCheckBox.Checked.ToString());
                CommandSql.Parameters.AddWithValue("@p_s_niem", GerCheckBox.Checked.ToString());
                CommandSql.Parameters.AddWithValue("@p_s_fra", FraCheckBox.Checked.ToString());
                CommandSql.Parameters.AddWithValue("@p_s_ros", RusCheckBox.Checked.ToString());
                CommandSql.Parameters.AddWithValue("@p_ukd", UKDTextBox.Text.Trim());
                CommandSql.Parameters.AddWithValue("@p_uwagi", CommentsTextBox.Text.Trim());
                CommandSql.Parameters.AddWithValue("@p_rodzajnik", "");
                CommandSql.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

                //Dodanie parametru id książki.
                SqlParameter BookIDSqlParameter = new SqlParameter();
                BookIDSqlParameter.ParameterName = "@BookID";
                BookIDSqlParameter.SqlDbType = SqlDbType.Int;
                BookIDSqlParameter.Direction = ParameterDirection.InputOutput;
                CommandSql.Parameters.Add(BookIDSqlParameter);

                if (CurrentMode == ModeEnum.Add)
                {
                    CommandSql.Parameters.AddWithValue("@mode", 1);
                    BookIDSqlParameter.SqlValue = DBNull.Value;
                }
                else if (CurrentMode == ModeEnum.Edit)
                {
                    CommandSql.Parameters.AddWithValue("@mode", 2);
                    BookIDSqlParameter.Value = BookID;
                }
                
                //jezyk1, jezyk2, jezyk3, jezyk4, jezyk5
                if (LangTextBox.Text != "")
                {
                    if (string.IsNullOrEmpty(LangBookID) || !string.IsNullOrEmpty(MainBookID))
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook @id_jezyk, @BookID; ";
                        CommandSql.Parameters.AddWithValue("@id_jezyk", LangID);
                    }
                    else
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook @id_jezyk, @BookID, @modify, @id_ksiazki_jezyk; ";
                        CommandSql.Parameters.AddWithValue("@id_jezyk", LangID);
                        CommandSql.Parameters.AddWithValue("@modify", 1);
                        CommandSql.Parameters.AddWithValue("@id_ksiazki_jezyk", LangBookID);
                    }
                }
                else if (!string.IsNullOrEmpty(LangBookID))
                {
                    CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook 0, 0, 2, @id_ksiazki_jezyk; ";
                    CommandSql.Parameters.AddWithValue("@id_ksiazki_jezyk", LangBookID);
                }

                if (Lang2TextBox.Text != "")
                {
                    if (string.IsNullOrEmpty(Lang2BookID) || !string.IsNullOrEmpty(MainBookID))
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook @id_jezyk2, @BookID; ";
                        CommandSql.Parameters.AddWithValue("@id_jezyk2", Lang2ID);
                    }
                    else
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook @id_jezyk2, @BookID, @modify2, @id_ksiazki_jezyk2; ";
                        CommandSql.Parameters.AddWithValue("@id_jezyk2", Lang2ID);
                        CommandSql.Parameters.AddWithValue("@modify2", 1);
                        CommandSql.Parameters.AddWithValue("@id_ksiazki_jezyk2", Lang2BookID);
                    }
                }
                else if (!string.IsNullOrEmpty(Lang2BookID))
                {
                    CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook 0, 0, 2, @id_ksiazki_jezyk2; ";
                    CommandSql.Parameters.AddWithValue("@id_ksiazki_jezyk2", Lang2BookID);
                }

                if (Lang3TextBox.Text != "")
                {
                    if (string.IsNullOrEmpty(Lang3BookID) || !string.IsNullOrEmpty(MainBookID))
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook @id_jezyk3, @BookID; ";
                        CommandSql.Parameters.AddWithValue("@id_jezyk3", Lang3ID);
                    }
                    else
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook @id_jezyk3, @BookID, @modify3, @id_ksiazki_jezyk3; ";
                        CommandSql.Parameters.AddWithValue("@id_jezyk3", Lang3ID);
                        CommandSql.Parameters.AddWithValue("@modify3", 1);
                        CommandSql.Parameters.AddWithValue("@id_ksiazki_jezyk3", Lang3BookID);
                    }
                }
                else if (!string.IsNullOrEmpty(Lang3BookID))
                {
                    CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook 0, 0, 2, @id_ksiazki_jezyk3; ";
                    CommandSql.Parameters.AddWithValue("@id_ksiazki_jezyk3", Lang3BookID);
                }

                if (Lang4TextBox.Text != "")
                {
                    if (string.IsNullOrEmpty(Lang4BookID) || !string.IsNullOrEmpty(MainBookID))
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook @id_jezyk4, @BookID; ";
                        CommandSql.Parameters.AddWithValue("@id_jezyk4", Lang4ID);
                    }
                    else
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook @id_jezyk4, @BookID, @modify4, @id_ksiazki_jezyk4; ";
                        CommandSql.Parameters.AddWithValue("@id_jezyk4", Lang4ID);
                        CommandSql.Parameters.AddWithValue("@modify4", 1);
                        CommandSql.Parameters.AddWithValue("@id_ksiazki_jezyk4", Lang4BookID);
                    }
                }
                else if (!string.IsNullOrEmpty(Lang4BookID))
                {
                    CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook 0, 0, 2, @id_ksiazki_jezyk4; ";
                    CommandSql.Parameters.AddWithValue("@id_ksiazki_jezyk4", Lang4BookID);
                }

                if (Lang5TextBox.Text != "")
                {
                    if (string.IsNullOrEmpty(Lang5BookID) || !string.IsNullOrEmpty(MainBookID))
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook @id_jezyk5, @BookID; ";
                        CommandSql.Parameters.AddWithValue("@id_jezyk5", Lang5ID);
                    }
                    else
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook @id_jezyk5, @BookID, @modify5, @id_ksiazki_jezyk5; ";
                        CommandSql.Parameters.AddWithValue("@id_jezyk5", Lang5ID);
                        CommandSql.Parameters.AddWithValue("@modify5", 1);
                        CommandSql.Parameters.AddWithValue("@id_ksiazki_jezyk5", Lang5BookID);
                    }
                }
                else if (!string.IsNullOrEmpty(Lang5BookID))
                {
                    CommandSql.CommandText += "EXEC Ksiazki_ModifyLangBook 0, 0, 2, @id_ksiazki_jezyk5; ";
                    CommandSql.Parameters.AddWithValue("@id_ksiazki_jezyk5", Lang5BookID);
                }

                //tytuł równoległy
                if (ParallelTitleTextBox.Text.Trim() != "")
                {
                    CommandSql.CommandText += "EXEC Ksiazki_AddParallelTitleToBook @ParallelTitle, @BookID, @ParallelModify, @ParallelID; ";
                    CommandSql.Parameters.AddWithValue("@ParallelTitle", ParallelTitleTextBox.Text.Trim());

                    if (string.IsNullOrEmpty(ParallelTitleID))// || !string.IsNullOrEmpty(MainBookID))
                        CommandSql.Parameters.AddWithValue("@ParallelModify", 1);
                    else
                        CommandSql.Parameters.AddWithValue("@ParallelModify", 2);

                    CommandSql.Parameters.AddWithValue("@ParallelID", string.IsNullOrEmpty(ParallelTitleID) ? DBNull.Value.ToString() : ParallelTitleID);                    
                }
                else if (!string.IsNullOrEmpty(ParallelTitleID))
                {
                    CommandSql.CommandText += "EXEC Ksiazki_AddParallelTitleToBook @ParallelTitle, @BookID, @ParallelModify, @ParallelID; ";
                    CommandSql.Parameters.AddWithValue("@ParallelTitle", ParallelTitleTextBox.Text.Trim());
                    CommandSql.Parameters.AddWithValue("@ParallelModify", 3);
                    CommandSql.Parameters.AddWithValue("@ParallelID", ParallelTitleID);
                }

                //tytuł dodatkowy
                if (AdditionalTitleTextBox.Text.Trim() != "")
                {
                    CommandSql.CommandText += "EXEC Ksiazki_AddAdditionalTitleToBook @AdditionalTitle, @BookID, @AdditionalModify, @AdditionalID; ";
                    CommandSql.Parameters.AddWithValue("@AdditionalTitle", AdditionalTitleTextBox.Text.Trim());

                    if (string.IsNullOrEmpty(AdditionalTitleID))// || !string.IsNullOrEmpty(MainBookID))
                        CommandSql.Parameters.AddWithValue("@AdditionalModify", 1);
                    else
                        CommandSql.Parameters.AddWithValue("@AdditionalModify", 2);

                    CommandSql.Parameters.AddWithValue("@AdditionalID", string.IsNullOrEmpty(AdditionalTitleID) ? DBNull.Value.ToString() : AdditionalTitleID);
                }
                else if (!string.IsNullOrEmpty(AdditionalTitleID))
                {
                    CommandSql.CommandText += "EXEC Ksiazki_AddAdditionalTitleToBook @AdditionalTitle, @BookID, @AdditionalModify, @AdditionalID; ";
                    CommandSql.Parameters.AddWithValue("@AdditionalTitle", AdditionalTitleTextBox.Text.Trim());
                    CommandSql.Parameters.AddWithValue("@AdditionalModify", 3);
                    CommandSql.Parameters.AddWithValue("@AdditionalID", AdditionalTitleID);
                }

                // Usunięcie kluczy
                for (int i = 0; i < KeysToDelete.Count; i++)
                {
                    CommandSql.CommandText += "EXEC Ksiazki_DeleteKeyFromBook @BookID, @KeyIDDelete" + i + "; ";
                    CommandSql.Parameters.AddWithValue("@KeyIDDelete" + i, KeysToDelete[i]);
                }
                
                // Dodanie kluczy
                for (int i = 0; i < KeysDataGridView.Rows.Count; i++)
                {                    
                    if (KeysDataGridView.Rows[i].Cells["id"].Value.ToString() == "-1")
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_AddKeyToBook @BookID, @KeyID" + i + ", @KeyName" + i + ", @NewKey" + i + ", @id_rodzaj;";
                        CommandSql.Parameters.AddWithValue("@KeyID" + i, KeysDataGridView.Rows[i].Cells["id"].Value.ToString());
                        CommandSql.Parameters.AddWithValue("@KeyName" + i, KeysDataGridView.Rows[i].Cells["Key"].Value.ToString());
                        CommandSql.Parameters.AddWithValue("@NewKey" + i, 1);
                    }
                    else
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_AddKeyToBook @BookID, @KeyID" + i + ", @KeyName" + i + ", @NewKey" + i + ", @id_rodzaj;";
                        CommandSql.Parameters.AddWithValue("@KeyID" + i, KeysDataGridView.Rows[i].Cells["id"].Value.ToString());
                        CommandSql.Parameters.AddWithValue("@KeyName" + i, "");
                        CommandSql.Parameters.AddWithValue("@NewKey" + i, 0);
                    }
                }

                // Dodanie konferencji
                if (ConfTitleTextBox.Text.Trim() != "")
                {
                    SqlParameter ConfSqlParameter = new SqlParameter();
                    ConfSqlParameter.ParameterName = "@ConfID";
                    ConfSqlParameter.SqlDbType = SqlDbType.Int;
                    ConfSqlParameter.Direction = ParameterDirection.InputOutput;

                    if (!string.IsNullOrEmpty(ConfID))
                        ConfSqlParameter.Value = Int32.Parse(ConfID);
                    else
                        ConfSqlParameter.Value = -1;

                    CommandSql.Parameters.Add(ConfSqlParameter);

                    CommandSql.CommandText += "EXEC Ksiazki_AddConferenceToBook @ConfID OUTPUT, @BookID, @ConfName, @ConfNumber, @ConfCountry, @ConfCity, @ConfOrganizator, @ConfDate, @ConfType, @ConfModify; ";
                    //CommandSql.Parameters.AddWithValue("@ConfID", ConfID);
                    CommandSql.Parameters.AddWithValue("@ConfName", ConfTitleTextBox.Text.Trim());
                    CommandSql.Parameters.AddWithValue("@ConfNumber", ConfNumberTextBox.Text.Trim());
                    CommandSql.Parameters.AddWithValue("@ConfCountry", ConfCountryTextBox.Text.Trim());
                    CommandSql.Parameters.AddWithValue("@ConfCity", ConfCityTextBox.Text.Trim());
                    CommandSql.Parameters.AddWithValue("@ConfOrganizator", ConfOrgTextBox.Text.Trim());

                    if (!ConferenceDateCheckBox.Checked)
                        CommandSql.Parameters.AddWithValue("@ConfDate", DBNull.Value);
                    else
                        CommandSql.Parameters.AddWithValue("@ConfDate", ConferenceDateDTP.Value.ToString("yyyyMMdd"));

                    CommandSql.Parameters.AddWithValue("@ConfType", "0");

                    if (ConfID == "-1" || string.IsNullOrEmpty(ConfID) || string.IsNullOrEmpty(BookID))
                        CommandSql.Parameters.AddWithValue("@ConfModify", 0);
                    else
                        CommandSql.Parameters.AddWithValue("@ConfModify", 1);
                }
                    // usunięcie konferencji
                else
                {
                    CommandSql.CommandText += "EXEC Ksiazki_DeleteConferenceFromBook @BookID; ";
                }

                //Serie
                if (IDSerie == "")
                {
                    if (SerieTitleTextBox.Text.Trim() != "")
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_AddSerie @tyt_serii, @issn, @inst_serii, @siedziba, @id_rodzaj, @SerieID OUTPUT;";
                        
                        CommandSql.Parameters.AddWithValue("@tyt_serii", SerieTitleTextBox.Text);
                        CommandSql.Parameters.AddWithValue("@issn", ISSNTextBox.Text);
                        CommandSql.Parameters.AddWithValue("@inst_serii", InsytTextBox.Text);
                        CommandSql.Parameters.AddWithValue("@siedziba", "");
                        CommandSql.Parameters.AddWithValue("@SerieID", DBNull.Value);

                        CommandSql.CommandText += "EXEC Ksiazki_AddSerieToBook @BookID, @SerieID, @nazwa_cz, @numer_cz; ";

                        //CommandSql.Parameters.AddWithValue("@SerieID", IDSerie);
                        CommandSql.Parameters.AddWithValue("@nazwa_cz", PartNameTextBox.Text);
                        CommandSql.Parameters.AddWithValue("@numer_cz", NumberNameTextBox.Text);
                    }
                    else
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_DeleteSerie @BookID;";
                    }
                }
                else
                {                    
                    CommandSql.CommandText += "EXEC Ksiazki_AddSerieToBook @BookID, @SerieID, @nazwa_cz, @numer_cz; ";

                    CommandSql.Parameters.AddWithValue("@SerieID", IDSerie);
                    CommandSql.Parameters.AddWithValue("@nazwa_cz", PartNameTextBox.Text);
                    CommandSql.Parameters.AddWithValue("@numer_cz", NumberNameTextBox.Text);
                    
                }
                
                // Usunięcie autorów z książki
                if (AuthorsToDelete.Count > 0)
                {
                    for (int i = 0; i < AuthorsToDelete.Count; i++)
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_DeleteAuthorFromBook @BookID, @p_AuthorID" + i + ";";
                        CommandSql.Parameters.AddWithValue("@p_AuthorID" + i, AuthorsToDelete[i]);
                    }
                }

                //Dodanie autorów do książki
                for (int i = 0; i < AuthorsDt.Rows.Count; i++)
                {
                    if (AuthorsDt.Rows[i]["id"].ToString() == "-1")
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_AddAuthor @imie" + i + ", @nazwisko" + i + ", @id_rodzaj, @AddToBook" + i + ", @BookID, @rating" + i + "; ";
                        CommandSql.Parameters.AddWithValue("@imie" + i, AuthorsDt.Rows[i]["imie"]);
                        CommandSql.Parameters.AddWithValue("@nazwisko" + i, AuthorsDt.Rows[i]["nazwisko"]);
                        CommandSql.Parameters.AddWithValue("@AddToBook" + i, 1);
                        CommandSql.Parameters.AddWithValue("@rating" + i, i+1);
                    }
                    else
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_AddAuthorToBook @BookID, " + " @zautorID" + i + ", @rating" + i +"; ";
                        CommandSql.Parameters.AddWithValue("@zautorID" + i, AuthorsDt.Rows[i]["id"].ToString());
                        CommandSql.Parameters.AddWithValue("@rating" + i, i + 1);
                    }
                }

                // Usunięcie współautorów z książki
                if (CoAuthorsToDelete.Count > 0)
                {
                    for (int i = 0; i < CoAuthorsToDelete.Count; i++)
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_DeleteCoAuthorFromBook @BookID, @p_CoAuthorID" + i + ";";
                        CommandSql.Parameters.AddWithValue("@p_CoAuthorID" + i, CoAuthorsToDelete[i]);
                    }
                }

                //Dodanie współautorów
                for (int i = 0; i < CoAuthorsDt.Rows.Count; i++)
                {
                    if (CoAuthorsDt.Rows[i]["id"].ToString() == "-1")
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_AddAuthor @coimie" + i + ", @conazwisko" + i + ", @id_rodzaj, 'FALSE', @BookID, @CoRating" + i + ", @CoAuthorID" + i + " OUTPUT; ";
                        CommandSql.Parameters.AddWithValue("@coimie" + i, CoAuthorsDt.Rows[i]["imie"]);
                        CommandSql.Parameters.AddWithValue("@conazwisko" + i, CoAuthorsDt.Rows[i]["nazwisko"]);
                        CommandSql.Parameters.AddWithValue("@CoRating" + i, i + 1);
                        CommandSql.Parameters.AddWithValue("@CoAuthorID" + i, DBNull.Value);

                        if (CoAuthorsDt.Rows[i]["id_odpow"].ToString() == "-1")
                        {
                            CommandSql.CommandText += "EXEC Ksiazki_AddOdpowiedzialnosc @odpowName" + i + ", @odpowID" + i + " OUTPUT; ";
                            CommandSql.Parameters.AddWithValue("@odpowName" + i, CoAuthorsDt.Rows[i]["odpow"]);
                            CommandSql.Parameters.AddWithValue("@odpowID" + i, DBNull.Value);

                            CommandSql.CommandText += "EXEC Ksiazki_AddCoAuthorToBook @BookID, " + " @CoAuthorID" + i + ", @OdpowID" + i + ", @CoRating" + i + "; ";
                        }
                        else
                        {
                            CommandSql.CommandText += "EXEC Ksiazki_AddCoAuthorToBook @BookID, " + " @CoAuthorID" + i + ", @OdpowID" + i + ", @CoRating" + i + "; ";

                            if (CoAuthorsDt.Rows[i]["id_odpow"].ToString() == "")
                                CommandSql.Parameters.AddWithValue("@OdpowID" + i, DBNull.Value);
                            else
                                CommandSql.Parameters.AddWithValue("@OdpowID" + i, CoAuthorsDt.Rows[i]["id_odpow"]);                            
                        }
                    }
                    else
                    {
                        if (CoAuthorsDt.Rows[i]["id_odpow"].ToString() == "-1")
                        {
                            CommandSql.CommandText += "EXEC Ksiazki_AddOdpowiedzialnosc @odpowName" + i + ", @odpowID" + i + " OUTPUT; ";
                            CommandSql.Parameters.AddWithValue("@odpowName" + i, CoAuthorsDt.Rows[i]["odpow"]);
                            CommandSql.Parameters.AddWithValue("@odpowID" + i, DBNull.Value);

                            CommandSql.CommandText += "EXEC Ksiazki_AddCoAuthorToBook @BookID, " + " @CoAuthorID" + i + ", @OdpowID" + i + ", @CoRating" + i + "; ";
                            CommandSql.Parameters.AddWithValue("@CoAuthorID" + i, CoAuthorsDt.Rows[i]["id"]);
                            CommandSql.Parameters.AddWithValue("@CoRating" + i, i + 1);
                        }
                        else
                        {
                            CommandSql.CommandText += "EXEC Ksiazki_AddCoAuthorToBook @BookID, " + " @CoAuthorID" + i + ", @OdpowID" + i + ", @CoRating" + i + "; ";
                            CommandSql.Parameters.AddWithValue("@CoAuthorID" + i, CoAuthorsDt.Rows[i]["id"]);                            
                            CommandSql.Parameters.AddWithValue("@CoRating" + i, i + 1);

                            if (CoAuthorsDt.Rows[i]["id_odpow"].ToString() == "")
                                CommandSql.Parameters.AddWithValue("@OdpowID" + i, DBNull.Value);
                            else
                                CommandSql.Parameters.AddWithValue("@OdpowID" + i, CoAuthorsDt.Rows[i]["id_odpow"]);
                        }
                    }
                }

                // Usunięcie instytucji
                CommandSql.CommandText += "EXEC Ksiazki_DeleteInstitutionFromBook @BookID; ";
                
                // Dodanie instytucji
                for (int i = 0; i < InstitutionsList.Count; i++)
                {
                    temp = InstitutionsList[i];

                    CommandSql.CommandText += "EXEC Ksiazki_AddInstitutionToBook @BookID, @InstituteName" + i + ", @InstituteCity" + i + "; ";
                    CommandSql.Parameters.AddWithValue("@InstituteName" + i, temp[0]);
                    CommandSql.Parameters.AddWithValue("@InstituteCity" + i, temp[1]);
                }

                //Dodanie tomu
                if (!string.IsNullOrEmpty(MainBookID) && CurrentMode == ModeEnum.Add)
                {
                    CommandSql.CommandText += "EXEC Ksiazki_AddTomeToBook @MainBookID, @BookID; ";
                    CommandSql.Parameters.AddWithValue("@MainBookID", MainBookID);
                }
                
                CommandSql.CommandText += "EXEC Ksiazki_DeleteSubSerie @BookID; ";

                //Podserie
                if (SubSerieTitleTextBox.Text.Trim() != "")
                {
                    CommandSql.CommandText += "EXEC Ksiazki_AddSubSerie @BookID, @tyt_pserii, @pissn, @nazwa_pcz, @numer_pcz; ";                             
                    CommandSql.Parameters.AddWithValue("@tyt_pserii", SubSerieTitleTextBox.Text);
                    CommandSql.Parameters.AddWithValue("@pissn", ISSNSubSerieTextBox.Text);
                    CommandSql.Parameters.AddWithValue("@nazwa_pcz", PartNameSubSerieTextBox.Text);
                    CommandSql.Parameters.AddWithValue("@numer_pcz", NumberNameSubSerieTextBox.Text);
                }

                //Dodanie sygnatur
                for (int i = 0; i < SygDataTable.Rows.Count; i++)
                {
                    if (SygDataTable.Rows[i]["id_sygnat"].ToString() == "-1")
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_AddSignature @p_k_kreskowy" + i + ", @BookID, @p_syg" + i + ", @p_tytulsyg" + i + ", @p_autor" + i + ", @p_rok1" + i + ", @p_numer_inw" + i + ", @p_numer_akc" + i + ", @p_rodz_ksieg" + i + ", @p_sposob_nab" + i + ", @p_cena" + i + ", @p_wartosc" + i + ", @p_waluta" + i + ", @p_data_zap" + i + ", @p_uwagi" + i + "; ";
                        CommandSql.Parameters.AddWithValue("@p_k_kreskowy" + i, SygDataTable.Rows[i]["k_kreskowy"].ToString().Length > 0 ? SygDataTable.Rows[i]["k_kreskowy"] : "0");
                        CommandSql.Parameters.AddWithValue("@p_syg" + i, SygDataTable.Rows[i]["syg"]);
                        CommandSql.Parameters.AddWithValue("@p_tytulsyg" + i, MainTitleTextBox.Text.Trim());

                        if (AuthorsDt.Rows.Count > 0)
                        {
                            CommandSql.Parameters.AddWithValue("@p_autor" + i, AuthorsDt.Rows[0]["nazwisko"].ToString().Trim() + " " + AuthorsDt.Rows[0]["imie"].ToString().Trim());
                        }
                        else
                            CommandSql.Parameters.AddWithValue("@p_autor" + i, "");

                        CommandSql.Parameters.AddWithValue("@p_rok1" + i, PublishYearTextBox.Text.Trim().Length > 0 ? PublishYearTextBox.Text.Trim() : "0");

                        CommandSql.Parameters.AddWithValue("@p_numer_inw" + i, SygDataTable.Rows[i]["numer_inw"]);
                        CommandSql.Parameters.AddWithValue("@p_numer_akc" + i, SygDataTable.Rows[i]["numer_akc"]);

                        CommandSql.Parameters.AddWithValue("@p_rodz_ksieg" + i, Settings.ID_rodzaj);
                        CommandSql.Parameters.AddWithValue("@p_sposob_nab" + i, SygDataTable.Rows[i]["spos_nab"]);
                        CommandSql.Parameters.AddWithValue("@p_cena" + i, SygDataTable.Rows[i]["cena"]);
                        CommandSql.Parameters.AddWithValue("@p_wartosc" + i, SygDataTable.Rows[i]["wartosc"]);
                        CommandSql.Parameters.AddWithValue("@p_waluta" + i, SygDataTable.Rows[i]["waluta"]);                        

                        if (!string.IsNullOrEmpty(SygDataTable.Rows[i]["data_zap"].ToString()))
                            CommandSql.Parameters.AddWithValue("@p_data_zap" + i, DateTime.ParseExact(SygDataTable.Rows[i]["data_zap"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture));
                        else
                            CommandSql.Parameters.AddWithValue("@p_data_zap" + i, "19900101");

                        CommandSql.Parameters.AddWithValue("@p_uwagi" + i, SygDataTable.Rows[i]["uwagi"]);
                    }
                    else
                    {
                        CommandSql.CommandText += "EXEC Ksiazki_ModifySignature @p_k_kreskowy" + i + ", @BookID, @p_syg" + i + ", @p_numer_inw" + i + ", @p_numer_akc" + i + ", @p_rodz_ksieg" + i + ", @p_sposob_nab" + i + ", @p_cena" + i + ", @p_wartosc" + i + ", @p_waluta" + i + ", @p_data_zap" + i + ", @p_uwagi" + i + ", @id_sygnat" + i + ";";
                        CommandSql.Parameters.AddWithValue("@p_k_kreskowy" + i, SygDataTable.Rows[i]["k_kreskowy"].ToString().Length > 0 ? SygDataTable.Rows[i]["k_kreskowy"] : "0");
                        CommandSql.Parameters.AddWithValue("@p_syg" + i, SygDataTable.Rows[i]["syg"]);

                        CommandSql.Parameters.AddWithValue("@p_numer_inw" + i, SygDataTable.Rows[i]["numer_inw"]);
                        CommandSql.Parameters.AddWithValue("@p_numer_akc" + i, SygDataTable.Rows[i]["numer_akc"]);

                        CommandSql.Parameters.AddWithValue("@p_rodz_ksieg" + i, Settings.ID_rodzaj);
                        CommandSql.Parameters.AddWithValue("@p_sposob_nab" + i, SygDataTable.Rows[i]["spos_nab"]);
                        CommandSql.Parameters.AddWithValue("@p_cena" + i, SygDataTable.Rows[i]["cena"]);
                        CommandSql.Parameters.AddWithValue("@p_wartosc" + i, SygDataTable.Rows[i]["wartosc"]);
                        CommandSql.Parameters.AddWithValue("@p_waluta" + i, SygDataTable.Rows[i]["waluta"]);

                        if (!string.IsNullOrEmpty(SygDataTable.Rows[i]["data_zap"].ToString()))
                            CommandSql.Parameters.AddWithValue("@p_data_zap" + i, DateTime.ParseExact(SygDataTable.Rows[i]["data_zap"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture));
                        else
                            CommandSql.Parameters.AddWithValue("@p_data_zap" + i, "19900101");

                        CommandSql.Parameters.AddWithValue("@p_uwagi" + i, SygDataTable.Rows[i]["uwagi"]);

                        CommandSql.Parameters.AddWithValue("@id_sygnat" + i, SygDataTable.Rows[i]["id_sygnat"]);
                    }
                }

                CommandSql.CommandText += "EXEC Ksiazki_AddMarcXML @BookID; ";


                /*if (Record != null)
                {
                    CommandSql.CommandText += "  INSERT INTO opisy_xml (opis_xml, serwer) VALUES (?, ?) \n";
                    CommandSql.Parameters.AddWithValue("@xml", Record.OuterXml);
                    CommandSql.Parameters.AddWithValue("@serwer", Server);
                }     */

                string cSQL = CommandSql.CommandText.ToString();
                //File.WriteAllText("1Info.TXT", cSQL);

                if (CommonFunctions.WriteData(ref CommandSql, ref Settings.Connection))
                {
                    BookID = BookIDSqlParameter.Value.ToString();

                    CurrentMode = ModeEnum.Edit;

                    PublishersList = new List<string[]>();
                    AuthorsDt.Clear();
                    CoAuthorsDt.Clear();

                    LoadDataInControls(BookID, true, false);
                    PrintButton.Enabled = true;

                    SygsToDelete.Clear();
                    SygsToUbytkowanie.Clear();
                    lEdit = false;
                    _dirtyTracker.MarkAsClean();
                    

                    if (!NoMessage)
                        MessageBox.Show(_T("book_data_was_saved"), _T("saving_book_data"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (TempSyg != null)
                    {
                        for (int i = 0; i < SygDGV.Rows.Count; i++)
                        {
                            if (SygDGV.Rows[i].Cells["Syg"].Value.ToString() == TempSyg)
                            {
                                SygDGV.ClearSelection();
                                SygDGV.Rows[i].Selected = true;
                                SygDGV.CurrentCell = SygDGV["Syg", i];
                                SygDGV.FirstDisplayedScrollingRowIndex = i;

                                break;
                            }
                        }
                    }

                    return true;
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, _T("error"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return false;
        }
        #endregion

        #region HeightTextBox_KeyPress(object sender, KeyPressEventArgs e) - GOOD
        private void HeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        #endregion

        #region WidthTextBox_KeyPress(object sender, KeyPressEventArgs e) - GOOD
        private void WidthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }
        #endregion

        #region ConfCountryButton_Click(object sender, EventArgs e) - REFACTORED
        private void ConfCountryButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC CountryList;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[2];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "kod";
            Columns[0].Name = "Kod";
            Columns[0].HeaderText = _T("code");
            Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "p_sk_nazwa";
            Columns[1].Name = "Państwo";
            Columns[1].HeaderText = _T("country");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _T("select_001");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                 ConfCountryTextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();
        }
        #endregion

        #region DetailsForm_KeyDown(object sender, KeyEventArgs e) - GOOD
        private void DetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)                
                this.Close();
            else if(e.KeyCode == Keys.F2 && (CurrentSygMode == SygModeEnum.Add || CurrentSygMode == SygModeEnum.Edit))
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC ZwrocOstatniaSygnature 1, @str; ";
                Command.Parameters.AddWithValue("@str", SygnaturaTextBox.Text.Trim());

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);
                SygRTB.ResetText();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    SygRTB.Text += Dt.Rows[i]["syg"].ToString() + Environment.NewLine;
                }
            }
        }
        #endregion

        #region ExitImport() - GOOD
        private void ExitImport()
        {
            //if (Settings.ReadOnlyMode)
            if (this.ReadOnly)
            { 
                this.Dispose();
                return;
            }

            if (MessageBox.Show(_T("close_window_wo_saving"), _T("exit"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (CurrentMode == ModeEnum.Edit)
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                this.Dispose();
            }
        }
        #endregion

        #region NewSygButton_Click(object sender, EventArgs e) - GOOD
        private void NewSygButton_Click(object sender, EventArgs e)
        {
            ChangeSygState(SygModeEnum.Add);
        }
        #endregion

        #region CancelSygButton_Click(object sender, EventArgs e) - GOOD
        private void CancelSygButton_Click(object sender, EventArgs e)
        {
            ChangeSygState(SygModeEnum.None);

            FillSygControls(FetchFillSyg());
        }
        #endregion

        #region SaveSygButton_Click(object sender, EventArgs e) - GOOD
        private void SaveSygButton_Click(object sender, EventArgs e)
        {
            if(SaveSyg())
                ChangeSygState(SygModeEnum.None);
        }
        #endregion

        #region SaveSyg() - GOOD
        private bool SaveSyg()
        {
            string id_sygnat;
            string TempIDTemp;

            if (CurrentSygMode == SygModeEnum.Add)
            {
                id_sygnat = "-1";

                TempIDTemp = TempID.ToString();
            }
            else
            {
                id_sygnat = SygDGV.SelectedRows[0].Cells["id_sygnat"].Value.ToString();

                TempIDTemp = SygDGV.SelectedRows[0].Cells["TempIDDGV"].Value.ToString();
            }  

            if (BarCodeTextBox.TextLength > 0)
            {
                for (int i = 0; i < SygDataTable.Rows.Count; i++)
                {
                    if (SygDataTable.Rows[i]["k_kreskowy"].ToString() == BarCodeTextBox.Text.Trim() && SygDataTable.Rows[i]["tempID"].ToString() != TempIDTemp)
                    {
                        MessageBox.Show(_T("barcode_exists"), _T("to_correct_data"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Ksiazki_CheckBarCodeExists @BarCode, @id_sygnat;";
                Command.Parameters.AddWithValue("@BarCode", BarCodeTextBox.Text);
                Command.Parameters.AddWithValue("@id_sygnat", id_sygnat);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show(_T("barcode_exists"), _T("to_correct_data"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            if ( NumerInwTextBox.Text.Trim().Length == 0)
            {
                if (SygnaturaTextBox.Text.Trim().Length > 0)
                    NumerInwTextBox.Text = uniqueInvNo ? SygnaturaTextBox.Text : "0";
                else
                {
                    MessageBox.Show(_T("enter_inventory_number"), _T("data_fillout"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            if (SygnaturaTextBox.Text.Trim().Length == 0 || (SygnaturaTextBox.Text.Trim().Length == 0 && NumerInwTextBox.Text.Trim().Length > 0))
            {
                MessageBox.Show(_T("enter_signature"), _T("data_fillout"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if ( uniqueInvNo && NumerInwTextBox.TextLength > 0)
            {
                for (int i = 0; i < SygDataTable.Rows.Count; i++)
                {
                    if (SygDataTable.Rows[i]["numer_inw"].ToString() == NumerInwTextBox.Text.Trim() && SygDataTable.Rows[i]["tempID"].ToString() != TempIDTemp)
                    {
                        MessageBox.Show(_T("inventory_number_exists"), _T("to_correct_data"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Ksiazki_CheckNumerInwExists @NumInw, @id_sygnat, @id_rodzaj;";
                Command.Parameters.AddWithValue("@NumInw", NumerInwTextBox.Text.Trim());
                Command.Parameters.AddWithValue("@id_sygnat", id_sygnat);
                Command.Parameters.AddWithValue("@id_rodzaj", (uniqueScope) ? Settings.ID_rodzaj : 0);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show(_T("inventory_number_exists"), _T("to_correct_data"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            // check syg
            if (uniqueSignatures)
            {
                for (int i = 0; i < SygDataTable.Rows.Count; i++)
                {
                    if (SygDataTable.Rows[i]["syg"].ToString() == SygnaturaTextBox.Text.Trim() && SygDataTable.Rows[i]["tempID"].ToString() != TempIDTemp)
                    {
                        MessageBox.Show(_T("signature_exists"), _T("to_correct_data"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SygnaturaTextBox.Select();
                        return false;
                    }
                }

                SqlCommand sygCommand = new SqlCommand();
                sygCommand.CommandText = "EXEC Ksiazki_CheckSigExists @syg, @id_sygnat, @id_rodzaj;";
                sygCommand.Parameters.AddWithValue("@syg", SygnaturaTextBox.Text.Trim());
                sygCommand.Parameters.AddWithValue("@id_sygnat", id_sygnat);
                sygCommand.Parameters.AddWithValue("@id_rodzaj",(uniqueScope) ? Settings.ID_rodzaj : 0);

                DataTable sygDt = CommonFunctions.ReadData(sygCommand, ref Settings.Connection);

                if (sygDt.Rows.Count > 0)
                {
                    if (sygDt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show(_T("signature_exists"), _T("to_correct_data"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        SygnaturaTextBox.Select();
                        return false;
                    }
                }
            }
                        
            string Date = null;
            int RowNumber = -1;

            if (CurrentSygMode == SygModeEnum.Add)
            {
                //id_sygnat = "-1";

                //TempIDTemp = TempID.ToString();

                RowNumber = SygDGV.Rows.Add(TempIDTemp, -1, SygnaturaTextBox.Text.Trim(), NumerInwTextBox.Text.Trim());                
            }
            else
            {
                id_sygnat = SygDGV.SelectedRows[0].Cells["id_sygnat"].Value.ToString();
                SygDGV.SelectedRows[0].Cells["Syg"].Value = SygnaturaTextBox.Text.Trim();
                SygDGV.SelectedRows[0].Cells["NumInwDGV"].Value = NumerInwTextBox.Text.Trim();

                for (int i = 0; i < SygDataTable.Rows.Count; i++)
                {
                    if (SygDGV.SelectedRows[0].Cells["TempIDDGV"].Value.ToString() == SygDataTable.Rows[i]["tempID"].ToString())
                    {
                        SygDataTable.Rows.RemoveAt(i);
                        break;
                    }
                }

                //TempIDTemp = SygDGV.SelectedRows[0].Cells["TempIDDGV"].Value.ToString();
            }           

            //if (SygDateCheckBox.Checked)
            Date = DateDTP.Value.ToString("yyyyMMdd");

            if (SposobNabyciaComboBox.SelectedValue == null && SposobNabyciaComboBox.Items.Count > 0)
                SposobNabyciaComboBox.SelectedIndex = 0;

            string cPrice;
            cPrice = PriceNumericUpDown.Value.ToString().Replace(',', '.');
            //MessageBox.Show(cPrice);

            SygDataTable.Rows.Add(new object[] { TempIDTemp, id_sygnat, SygnaturaTextBox.Text.Trim(), NumerInwTextBox.Text.Trim(), BarCodeTextBox.Text.Trim(), NrDowoduTextBox.Text.Trim(), SposobNabyciaComboBox.SelectedValue.ToString(), /*PriceTextBox.Text.Trim(), ValueTextBox.Text.Trim(),*/ cPrice, ValueNumericUpDown.Value.ToString().Replace(',', '.'), CurrencyTextBox.Text.Trim(), Date, SygCommentsRichTextBox.Text.Trim() });            

            TempID++;

            if (RowNumber != -1)
            {
                SygDGV.ClearSelection();
                SygDGV.Rows[RowNumber].Selected = true;
                SygDGV.CurrentCell = SygDGV["Syg", RowNumber];
                SygDGV.FirstDisplayedScrollingRowIndex = RowNumber;
            }

            TempSyg = SygnaturaTextBox.Text.Trim();

            SetSygsCount(SygDGV.Rows.Count);
            lEdit = true;
            return true;
        }
        #endregion
        
        #region EditSygButton_Click(object sender, EventArgs e) - GOOD
        private void EditSygButton_Click(object sender, EventArgs e)
        {
            ChangeSygState(SygModeEnum.Edit);
        }
        #endregion

        #region SourcesButton_Click(object sender, EventArgs e) - GOOD
        private void SourcesButton_Click(object sender, EventArgs e)
        {
            //_dirtyTracker.Dump();

            if (string.IsNullOrEmpty(BookID))
            {
                if (MessageBox.Show(_T("save_data_to_add_source"), _T("saving"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    /*if (!Import(true))
                        return;*/

                    if (!Import(true))
                        return;
                }
                else
                    return;
            }

            //if (Settings.ReadOnlyMode)
            if (this.ReadOnly)
            {
                Zrodla.SourceForm SF = new Zrodla.SourceForm(Int32.Parse(BookID), 1, Settings.ID_rodzaj, true);
                SF.ShowDialog();
            }
            else
            {
                Zrodla.SourceForm SF = new Zrodla.SourceForm(Int32.Parse(BookID), 1, Settings.ID_rodzaj);
                SF.ShowDialog();
            }

            LoadSourcesCount();
        }
        #endregion

        #region SygDGV_SelectionChanged(object sender, EventArgs e) - GOOD
        private void SygDGV_SelectionChanged(object sender, EventArgs e)
        {

            if (SygDGV.SelectedRows.Count == 0 || (SygDGV.SelectedRows.Count > 0 && SygDGV.SelectedRows[0].Index < 0) || this.ReadOnly)// Settings.ReadOnlyMode)
            {
                EditSygButton.Enabled = false;
                DeleteSygButton.Enabled = false;
            }
            else
            {
                EditSygButton.Enabled = true;
                DeleteSygButton.Enabled = true;                
            }

            FillSygControls(FetchFillSyg());
        }
        #endregion

        #region FillSygControls(DataRow Dr) - GOOD
        private void FillSygControls(DataRow Dr)
        {
            if (Dr != null)
            {
                SygnaturaTextBox.Text = Dr["syg"].ToString();
                NumerInwTextBox.Text = Dr["numer_inw"].ToString();
                BarCodeTextBox.Text = Dr["k_kreskowy"].ToString();
                NrDowoduTextBox.Text = Dr["numer_akc"].ToString();
                SposobNabyciaComboBox.SelectedValue = Dr["spos_nab"].ToString();
                //PriceTextBox.Text = Dr["cena"].ToString();
                //ValueTextBox.Text = Dr["wartosc"].ToString();

                string s1, s2, s3, s4;
                s1 = Dr["cena"].ToString().Replace(',', '.');
                s2 = Dr["wartosc"].ToString().Replace(',', '.');
                decimal d1, d2;
                d1 = d2 = 0m;
                try
                {
                    d1 = decimal.Parse(s1,CultureInfo.InvariantCulture);
                    d2 = decimal.Parse(s2, CultureInfo.InvariantCulture);
                }
                catch {}

                s3 = d1.ToString();
                s4 = d2.ToString();

                PriceNumericUpDown.Value = d1;
                ValueNumericUpDown.Value = d2;

                CurrencyTextBox.Text = Dr["waluta"].ToString();

                string cDate = "";

                cDate = Dr["data_zap"].ToString();


//                MessageBox.Show("Ala" + "\n" + cDate + "\n" + CultureInfo.CurrentCulture.DisplayName + "\n" + CultureInfo.CurrentCulture.DateTimeFormat.FullDateTimePattern);

                if (!string.IsNullOrEmpty(cDate))
                {
                    //SygDateCheckBox.Checked = true;


                    if (cDate.Contains('-'))
                        DateDTP.Value = DateTime.Parse(cDate);
                    else
                        DateDTP.Value = DateTime.ParseExact(cDate, "yyyyMMdd", CultureInfo.InvariantCulture);
                    //DateDTP.Value = DateTime.Parse(Dr["data_zap"].ToString());
                     
                }
                else
                {
                    DateDTP.Value = new DateTime(1999, 1, 1);
                }


                //SygCommentsRichTextBox.Text = s1 + "\n" + s2 + "\n" + s3 + "\n" + s4;
                
                SygCommentsRichTextBox.Text = Dr["uwagi"].ToString();

            }
        }
        #endregion

        #region FetchFillSyg() - GOOD
        private DataRow FetchFillSyg()
        {
            DataTable Dt = new DataTable();
            DataRow Dr = null;

            try
            {
                int RowNumber = -1;

                for (int i = 0; i < SygDataTable.Rows.Count; i++)
                {
                    if (SygDGV.SelectedRows.Count > 0 && SygDGV.SelectedRows[0].Cells["TempIDDGV"].Value.ToString() == SygDataTable.Rows[i]["tempID"].ToString())
                    {
                        RowNumber = i;
                        break;
                    }
                }

                if (RowNumber != -1)
                {
                    Dr = SygDataTable.Rows[RowNumber];
                }
                else if (SygDGV.SelectedRows.Count > 0)
                //if (SygDGV.SelectedRows[0].Cells["id_sygnat"].Value.ToString() != "-1")
                {
                    SqlCommand Command = new SqlCommand();
                    Command.CommandText = "EXEC Ksiazki_SygSelectFill @id;";
                    Command.Parameters.AddWithValue("@id", SygDGV.SelectedRows[0].Cells["id_sygnat"].Value.ToString());

                    Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                    if (Dt.Rows.Count > 0)
                        Dr = Dt.Rows[0];
                }          
                else 
                    Clear();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }

            //return Dt.Rows.Count > 0 ? Dt.Rows[0] : null;
            return Dr;
        }
        #endregion

        #region ConferenceDateCheckBox_CheckedChanged(object sender, EventArgs e) - GOOD
        private void ConferenceDateCheckBox_CheckedChanged(object sender, EventArgs e)
        {            
            ConferenceDateDTP.Enabled = ConferenceDateCheckBox.Checked;
        }
        #endregion

        #region TomsButton_Click(object sender, EventArgs e) - GOOD
        private void TomsButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(BookID))
            {
                if (MessageBox.Show(_T("save_data_to_add_vol"), _T("saving"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!Import(true))
                        return;
                }
                else
                    return;
            }
            else
                if(!Import(true))
                    return;
            
            TomsForm Tomy = new TomsForm(BookID, this, this.ReadOnly);// Settings.ReadOnlyMode);            
            Tomy.Show();

            ActiveReason = FormActivate.faTomesForm;            
        }
        #endregion

        #region LoadSposobNabycia() - GOOD
        private void LoadSposobNabycia()
        {
            SqlCommand Command = new SqlCommand();

            //start - załadowanie sposobów nabycia
            Command.CommandText = "EXEC ListaSposobNabycia; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            SposobNabyciaComboBox.DataSource = new BindingSource(Dt, null);
            SposobNabyciaComboBox.DisplayMember = "sposob";
            SposobNabyciaComboBox.ValueMember = "id";

            if (SposobNabyciaComboBox.Items.Count == 0)
            {
                SposobNabyciaComboBox.DataSource = null;

                Dt.Clear();
                Dt.Rows.Add(-1, "");

                SposobNabyciaComboBox.DataSource = new BindingSource(Dt, null);
                SposobNabyciaComboBox.DisplayMember = "sposob";
                SposobNabyciaComboBox.ValueMember = "id";
            }

            if (SposobNabyciaComboBox.Items.Count > 0)
                SposobNabyciaComboBox.SelectedIndex = 0;
            //koniec - załadowanie sposobów nabycia
        }
        #endregion

        #region LoadTomesCount() - GOOD
        private void LoadTomesCount()
        {
            if (string.IsNullOrEmpty(MainBookID))
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Ksiazki_BookTomeCount @BookID; ";

                Command.Parameters.AddWithValue("@BookID", BookID);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    //Ilość tomów
                    if (Dt.Rows[0]["tomyCount"].ToString() != "0")
                        TomsButton.Text = "Tomy (" + Dt.Rows[0]["tomyCount"].ToString() + ")";
                    else
                        TomsButton.Text = "Tomy";

                    Int32.TryParse(Dt.Rows[0]["tomyCount"].ToString(), out TomesCount);
                }
            }
        }
        #endregion

        #region LoadSourcesCount() - GOOD
        private void LoadSourcesCount()
        {
            if (string.IsNullOrEmpty(MainBookID))
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Ksiazki_BookSourcesCount @BookID; ";

                Command.Parameters.AddWithValue("@BookID", BookID);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    //Ilość źródeł
                    if (Dt.Rows[0]["docsCount"].ToString() != "0")
                        SourcesButton.Text = _T("sources") + " (" + Dt.Rows[0]["docsCount"].ToString() + ")";
                    else
                        SourcesButton.Text = _T("sources");

                    Int32.TryParse(Dt.Rows[0]["docsCount"].ToString(), out SourcesCount);
                }                
            }
        }
        #endregion

        

        #region LoadDataInControls(string BookID = null) - GOOD
        private void LoadDataInControls(string BookID, bool LoadSygs, bool isCopy)
        {
            SqlCommand Command = new SqlCommand();

            Command.Parameters.AddWithValue("@BookID", BookID);

            DataTable Dt;

            if (CurrentMode == ModeEnum.Edit && LoadSygs)
            {
                //start - załadowanie sygnatur
                Command.CommandText = "Ksiazki_BookSygs @BookID; ";

                Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (SygDGV.Rows.Count > 0)
                    SygDGV.Rows.Clear();

                SygDataTable.Rows.Clear();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    SygDGV.Rows.Add(TempID, Dt.Rows[i]["id_sygnat"], Dt.Rows[i]["syg"], Dt.Rows[i]["numer_inw"]);

                    TempID++;
                }

                SetSygsCount(SygDGV.Rows.Count);
                //koniec - załadowanie sygnatur

                PrintButton.Enabled = true;
            }

            //start - załadowanie danych o książce
            Command.CommandText = "EXEC Ksiazki_AboutBook @BookID; ";

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {
                //Tytuł
                MainTitleTextBox.Text = Dt.Rows[0]["tytul_gl"].ToString();

                //Tytuł dodatkowy
                if (!isCopy)
                    AdditionalTitleID = Dt.Rows[0]["t_dodatkID"].ToString();

                AdditionalTitleTextBox.Text = Dt.Rows[0]["t_dodatk"].ToString();

                //Tytuł równoległy
                if (!isCopy)
                    ParallelTitleID = Dt.Rows[0]["t_rownolID"].ToString();

                ParallelTitleTextBox.Text = Dt.Rows[0]["t_rownol"].ToString();

                //Ilość tomów
                TomsNumberTextBox.Text = Dt.Rows[0]["il_tomow"].ToString();

                //Wydawcy
                PublishersID[0] = Dt.Rows[0]["id_wyd1"].ToString();
                PublishersID[1] = Dt.Rows[0]["id_wyd2"].ToString();

                
                AddPublisherButton.Enabled = string.IsNullOrEmpty(Dt.Rows[0]["id_wyd1"].ToString());
                AddPublisher2Button.Enabled = string.IsNullOrEmpty(Dt.Rows[0]["id_wyd2"].ToString());
                

                PublisherTextBox.Text = Dt.Rows[0]["nazwa_w1"].ToString();
                Publisher2TextBox.Text = Dt.Rows[0]["nazwa_w2"].ToString();
                PlaceTextBox.Text = Dt.Rows[0]["miasto_w1"].ToString();
                Place2TextBox.Text = Dt.Rows[0]["miasto_w2"].ToString();

                PublisherLabel.Visible = false;
                Publisher2Label.Visible = false;

                //Wydanie
                PublishVersionTextBox.Text = Dt.Rows[0]["wydanie"].ToString();

                //Rok wydania
                PublishYearTextBox.Text = Dt.Rows[0]["rok_wyd"].ToString();

                //Lata wydania
                LataWydTextBox.Text = Dt.Rows[0]["lata_wyd"].ToString();

                //Strony
                DescriptionTextBox.Text = Dt.Rows[0]["strony"].ToString();

                //ISBN-y
                ISBNTextBox.Text = Dt.Rows[0]["isbn"].ToString();
                ISBN2TextBox.Text = Dt.Rows[0]["isbn2"].ToString();

                //Wymiary
                HeightTextBox.Text = Dt.Rows[0]["wysokosc"].ToString();
                WidthTextBox.Text = Dt.Rows[0]["dlugosc"].ToString();

                //Zawartość
                if (!string.IsNullOrEmpty(Dt.Rows[0]["zawartosc"].ToString()))
                    FormAndContentComboBox.SelectedValue = Dt.Rows[0]["zawartosc"];
                    
                //Streszczenia
                PolCheckBox.Checked = Dt.Rows[0]["s_pol"].ToString().Trim().ToLower() == "true";
                EngCheckBox.Checked = Dt.Rows[0]["s_ang"].ToString().Trim().ToLower() == "true";
                GerCheckBox.Checked = Dt.Rows[0]["s_niem"].ToString().Trim().ToLower() == "true";
                FraCheckBox.Checked = Dt.Rows[0]["s_fran"].ToString().Trim().ToLower() == "true";
                RusCheckBox.Checked = Dt.Rows[0]["s_ros"].ToString().Trim().ToLower() == "true";

                //UKD
                UKDTextBox.Text = Dt.Rows[0]["ukd"].ToString();

                //Uwagi
                CommentsTextBox.Text = Dt.Rows[0]["uwagi"].ToString();                   

                //Konferencja
                if (!isCopy)
                    ConfID = Dt.Rows[0]["id_konfer"].ToString();

                ConfTitleTextBox.Text = Dt.Rows[0]["nazwa_imp"].ToString();
                ConfNumberTextBox.Text = Dt.Rows[0]["numer_imp"].ToString();
                ConfCountryTextBox.Text = Dt.Rows[0]["kraj_imp"].ToString();
                ConfCityTextBox.Text = Dt.Rows[0]["miasto_imp"].ToString();
                ConfOrgTextBox.Text = Dt.Rows[0]["org_imp"].ToString();

                if (!string.IsNullOrEmpty(Dt.Rows[0]["data_imp"].ToString()))
                {
                    ConferenceDateDTP.Value = DateTime.Parse(Dt.Rows[0]["data_imp"].ToString());
                    ConferenceDateCheckBox.Checked = true;
                }
                else
                {
                    ConferenceDateDTP.Value = DateTime.Now;
                    ConferenceDateCheckBox.Checked = false;
                }
                    
                //Serie
                IDSerie = Dt.Rows[0]["id_serie"].ToString();

                InsytTextBox.Text = Dt.Rows[0]["inst_serii"].ToString();
                ISSNTextBox.Text = Dt.Rows[0]["issn"].ToString();
                SerieTitleTextBox.Text = Dt.Rows[0]["tyt_serii"].ToString();
                PartNameTextBox.Text = Dt.Rows[0]["nazwa_cz"].ToString();
                NumberNameTextBox.Text = Dt.Rows[0]["numer_cz"].ToString();

                if (!string.IsNullOrEmpty(IDSerie))
                {
                    SerieTitleTextBox.ReadOnly = true;
                    InsytTextBox.ReadOnly = true;
                    ISSNTextBox.ReadOnly = true;
                }

                //Podserie
                if (!isCopy)
                    IDSubSerie = Dt.Rows[0]["id_podser"].ToString();

                SubSerieTitleTextBox.Text = Dt.Rows[0]["tyt_pserii"].ToString();
                ISSNSubSerieTextBox.Text = Dt.Rows[0]["pissn"].ToString();
                NumberNameSubSerieTextBox.Text = Dt.Rows[0]["numer_pcz"].ToString();
                PartNameSubSerieTextBox.Text = Dt.Rows[0]["nazwa_pcz"].ToString();
                    

                if (string.IsNullOrEmpty(MainBookID))                       
                {
                    //Ilość tomów
                    if (Dt.Rows[0]["tomyCount"].ToString() != "0")
                        TomsButton.Text = _T("volumes_1") + " (" + Dt.Rows[0]["tomyCount"].ToString() + ")";
                    else
                        TomsButton.Text = _T("volumes_1");

                    Int32.TryParse(Dt.Rows[0]["tomyCount"].ToString(), out TomesCount);

                    //Ilość źródeł
                    if (Dt.Rows[0]["docsCount"].ToString() != "0")
                        SourcesButton.Text = _T("sources") + " (" + Dt.Rows[0]["docsCount"].ToString() + ")";
                    else
                        SourcesButton.Text = _T("sources");

                    Int32.TryParse(Dt.Rows[0]["docsCount"].ToString(), out SourcesCount);
                }
            }
            //koniec - załadowanie danych o książce

            //start - załadowanie języków książki
            Command.CommandText = "EXEC Ksiazki_AboutBookLangs @BookID; ";

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows.Count > 0)
                {
                    LangID = Dt.Rows[0]["id_jezyk"].ToString();
                    LangTextBox.Text = Dt.Rows[0]["jezyk"].ToString();
                    LangBookID = Dt.Rows[0]["id"].ToString();
                }
                else
                {
                    LangID = "";
                    LangTextBox.Text = "";
                    LangBookID = "";
                }

                if (Dt.Rows.Count > 1)
                {
                    Lang2ID = Dt.Rows[1]["id_jezyk"].ToString();
                    Lang2TextBox.Text = Dt.Rows[1]["jezyk"].ToString();
                    Lang2BookID = Dt.Rows[1]["id"].ToString();
                }
                else
                {
                    Lang2ID = "";
                    Lang2TextBox.Text = "";
                    Lang2BookID = "";
                }

                if (Dt.Rows.Count > 2)
                {
                    Lang3ID = Dt.Rows[2]["id_jezyk"].ToString();
                    Lang3TextBox.Text = Dt.Rows[2]["jezyk"].ToString();
                    Lang3BookID = Dt.Rows[2]["id"].ToString();
                }
                else
                {
                    Lang3ID = "";
                    Lang3TextBox.Text = "";
                    Lang3BookID = "";
                }

                if (Dt.Rows.Count > 3)
                {
                    Lang4ID = Dt.Rows[3]["id_jezyk"].ToString();
                    Lang4TextBox.Text = Dt.Rows[3]["jezyk"].ToString();
                    Lang4BookID = Dt.Rows[3]["id"].ToString();
                }
                else
                {
                    Lang4ID = "";
                    Lang4TextBox.Text = "";
                    Lang4BookID = "";
                }

                if (Dt.Rows.Count > 4)
                {
                    Lang5ID = Dt.Rows[4]["id_jezyk"].ToString();
                    Lang5TextBox.Text = Dt.Rows[4]["jezyk"].ToString();
                    Lang5BookID = Dt.Rows[4]["id"].ToString();
                }
                else
                {
                    Lang5ID = "";
                    Lang5TextBox.Text = "";
                    Lang5BookID = "";
                }
            }
            //koniec - załadowanie języków książki

            //start - załadowanie kluczy książki
            Command.CommandText = "EXEC Ksiazki_AboutBookKeys @BookID; ";

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (KeysDataGridView.Rows.Count > 0)
            {
                KeysToDelete.AddRange(KeysDataGridView.Rows.Cast<DataGridViewRow>().Select(x => x.Cells["id"].Value.ToString()));
                KeysDataGridView.Rows.Clear();
            }

            foreach (DataRow Row in Dt.Rows)
            {
                KeysDataGridView.Rows.Add(new string[] { Row["id"].ToString(), Row["klucz"].ToString() });
            }
            //koniec - załadowanie kluczy książki

            //start - załadowanie autorów książki
            Command.CommandText = "EXEC Ksiazki_AboutBookAuthors @BookID; ";

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            string[] temp;            

            AuthorsToDelete.AddRange(AuthorsDt.Rows.AsParallel().Cast<DataRow>().Select(x => x["id"].ToString()));
            AuthorsDt.Clear();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                AuthorsDt.Rows.Add(Dt.Rows[i]["id_aut"].ToString(), Dt.Rows[i]["imie"].ToString(), Dt.Rows[i]["nazwisko"].ToString());
            }

            //współautorzy
            Command.CommandText = "EXEC Ksiazki_AboutBookCoAuthors @BookID; ";

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            CoAuthorsToDelete.AddRange(CoAuthorsDt.Rows.AsParallel().Cast<DataRow>().Select(x => x["id"].ToString()));
            CoAuthorsDt.Clear();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                CoAuthorsDt.Rows.Add(Dt.Rows[i]["id_aut"].ToString(), Dt.Rows[i]["imie"].ToString(), Dt.Rows[i]["nazwisko"].ToString(), Dt.Rows[i]["odpowID"].ToString(), Dt.Rows[i]["odpowiedzialnosc"].ToString());
            }

            //instutycje sprawcze
            Command.CommandText = "EXEC Ksiazki_AboutBookInstitution @BookID; ";

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);
            InstitutionsList.Clear();

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                temp = new string[2];

                temp[0] = Dt.Rows[i]["nazwa_inst"].ToString();
                temp[1] = Dt.Rows[i]["siedziba"].ToString();

                InstitutionsList.Add(temp);
            }

            LoadAuthorsToTextBox(true);

            _dirtyTracker = new SlightlyMoreSophisticatedDirtyTracker();
            _dirtyTracker.AddControls(tabPage1.Controls);
            _dirtyTracker.AddControls(tabPage2.Controls, "$KeyTextBox");
            _dirtyTracker.MarkAsClean();
            lEdit = false;

            //koniec - załadowanie autorów książki           
        }
        #endregion

        #region DeleteSygButton_Click(object sender, EventArgs e) - GOOD
        private void DeleteSygButton_Click(object sender, EventArgs e)
        {
            DialogResult Res = System.Windows.Forms.DialogResult.None;

            if (SygDGV.SelectedRows[0].Cells["id_sygnat"].Value.ToString() != "-1")
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = "EXEC Ksiazki_SprawdzSygnaturaJestWypozyczona @id; ";
                Cmd.Parameters.AddWithValue("@id", SygDGV.SelectedRows[0].Cells["id_sygnat"].Value.ToString());

                DataTable Dt = CommonFunctions.ReadData(Cmd, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    if (MessageBox.Show(string.Format(_T("book_was_borrowed_return_q"), Dt.Rows[0]["uzytkownik"]), _T("book_return"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ZwrotForm zwrot = new ZwrotForm(Dt.Rows[0]["wypoz_id"].ToString(), Settings.employeeID, null);

                        if (zwrot.ShowDialog() == DialogResult.Cancel)
                            return;
                    }
                    else
                        return;
                }

                //Res = MessageBox.Show(_T("delete_sig_with_notify"), _T("deleting_signature"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                Res = new DeleteSygDialogForm().ShowDialog();

                if (Res == System.Windows.Forms.DialogResult.Yes)
                {
                    SingleUbytkiForm SUF;

                    SUF = new SingleUbytkiForm(SygDGV.SelectedRows[0].Cells["Syg"].Value.ToString(), SygDGV.SelectedRows[0].Cells["NumInwDGV"].Value.ToString());

                    if (SUF.ShowDialog() == DialogResult.OK)
                    {
                        //SygsToUbytkowanie.Rows.Add(SUF.Dt.Rows[0]["syg"].ToString(), SUF.Dt.Rows[0]["numer_inw"].ToString(), SUF.Dt.Rows[0]["nr_ksiegi"].ToString(), SUF.Dt.Rows[0]["data"].ToString(), SUF.Dt.Rows[0]["przyczyna"].ToString(), SUF.Dt.Rows[0]["nr_dowodu"].ToString(), SUF.Dt.Rows[0]["uwagi"].ToString(), SygDGV.SelectedRows[0].Cells["id_sygnat"].Value.ToString());                        

                        //Ubytkownie
                        SqlCommand CommandSql = new SqlCommand();
                        CommandSql.CommandText += "EXEC Ubytki_Add @BookID, @p_id_sygnat, @syg, @tytul, '', @numer_inw, '', @nr_ksiegi, @nr_dow, @cena, @data_ubyt, @uwagi, @przyczyna, @id_rodzaj, 1; ";
                        CommandSql.Parameters.AddWithValue("@BookID", BookID);
                        CommandSql.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
                        CommandSql.Parameters.AddWithValue("@p_id_sygnat", SygDGV.SelectedRows[0].Cells["id_sygnat"].Value.ToString());
                        CommandSql.Parameters.AddWithValue("@syg", SUF.Dt.Rows[0]["syg"].ToString());
                        CommandSql.Parameters.AddWithValue("@tytul", "");
                        CommandSql.Parameters.AddWithValue("@numer_inw", SUF.Dt.Rows[0]["numer_inw"]);
                        CommandSql.Parameters.AddWithValue("@nr_ksiegi", SUF.Dt.Rows[0]["nr_ksiegi"].ToString() != "" ? SUF.Dt.Rows[0]["nr_ksiegi"].ToString() : "0");
                        CommandSql.Parameters.AddWithValue("@nr_dow", SUF.Dt.Rows[0]["nr_dowodu"]);
                        CommandSql.Parameters.AddWithValue("@cena", 0);
                        CommandSql.Parameters.AddWithValue("@data_ubyt", SUF.Dt.Rows[0]["data"]);
                        CommandSql.Parameters.AddWithValue("@uwagi", SUF.Dt.Rows[0]["uwagi"]);
                        CommandSql.Parameters.AddWithValue("@przyczyna", SUF.Dt.Rows[0]["przyczyna"]);

                        if (CommonFunctions.WriteData(CommandSql, ref Settings.Connection))
                            MessageBox.Show(_T("book_was_deleted") + ".", _T("deleting"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        return;
                }
                else if (Res == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }

            if (Res == System.Windows.Forms.DialogResult.No)
            { 
                //SygsToDelete.Add(SygDGV.SelectedRows[0].Cells["id_sygnat"].Value.ToString()); 

                //Usunięcie sygnatur
                SqlCommand CommandSql = new SqlCommand();
                CommandSql.CommandText += "EXEC Ksiazki_DeleteSignature @id_sygnatDel; ";
                CommandSql.Parameters.AddWithValue("@id_sygnatDel", SygDGV.SelectedRows[0].Cells["id_sygnat"].Value.ToString());

                if (CommonFunctions.WriteData(CommandSql, ref Settings.Connection))
                    MessageBox.Show(_T("book_was_deleted") + ".", _T("deleting"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    return;
            }

            for (int i = 0; i < SygDataTable.Rows.Count; i++)
            {
                if (SygDGV.SelectedRows[0].Cells["TempIDDGV"].Value.ToString() == SygDataTable.Rows[i]["tempID"].ToString())
                {
                    SygDataTable.Rows.RemoveAt(i);
                    break;
                }
            }

            SygDGV.Rows.RemoveAt(SygDGV.SelectedRows[0].Index);

            FillSygControls(FetchFillSyg());

            SetSygsCount(SygDGV.Rows.Count);
        }
        #endregion

        #region BooksListButton_Click(object sender, EventArgs e) - GOOD
        private void BooksListButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC Ksiazki_BookList @sort, @id_rodzaj; ");
            Command.Parameters.AddWithValue("@sort", 1);
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

            DataGridViewColumn[] Columns = new DataGridViewColumn[4];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "kod";
            Columns[0].HeaderText = _T("code");
            Columns[0].Name = "kod";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "tytul";
            Columns[1].Name = "tytul";
            Columns[1].HeaderText = _T("title");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "syg";
            Columns[2].Name = "syg";
            Columns[2].HeaderText = _T("signature");
            Columns[2].Width = 120;
            //Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            Columns[3] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[3].DataPropertyName = "numer_inw";
            Columns[3].Name = "numer_inw";
            Columns[3].HeaderText = _T("inventory_number");
            Columns[3].Width = 120;
            //Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            ShowForm Formka = new ShowForm(Command, Columns, true);
            Formka.Text = _T("select_001");

            if (Formka.ShowDialog() == DialogResult.OK)
                LoadDataInControls(Formka.Dt.Cells["Kod"].Value.ToString(), false, true);
        }
        #endregion

        #region ChooseConferenceButton_Click(object sender, EventArgs e) - GOOD
        private void ChooseConferenceButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC ConferenceList; ");

            DataGridViewColumn[] Columns = new DataGridViewColumn[6];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "nazwa_imp";
            Columns[0].Name = "nazwa_imp";
            Columns[0].HeaderText = _T("file_name_cannot_be_empty");
            //Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            Columns[0].Width = 300;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "numer_imp";
            Columns[1].Name = "numer_imp";
            Columns[1].HeaderText = _T("inventory_numbers_genitive");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "kraj_imp";
            Columns[2].Name = "kraj_imp";
            Columns[2].HeaderText = _T("publish_country");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            Columns[3] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[3].DataPropertyName = "miasto_imp";
            Columns[3].Name = "miasto_imp";
            Columns[3].HeaderText = _T("city");
            Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            Columns[4] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[4].DataPropertyName = "org_imp";
            Columns[4].Name = "org_imp";
            Columns[4].HeaderText = _T("event_promoter");
            Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            Columns[5] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[5].DataPropertyName = "data_imp";
            Columns[5].Name = "data_imp";
            Columns[5].HeaderText = _T("date_of_add");
            Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _T("select_001");

            if (Formka.ShowDialog() == DialogResult.OK)
            {
                ConfTitleTextBox.Text = Formka.Dt.Cells["nazwa_imp"].Value.ToString();
                ConfNumberTextBox.Text = Formka.Dt.Cells["numer_imp"].Value.ToString();
                ConfCountryTextBox.Text = Formka.Dt.Cells["kraj_imp"].Value.ToString();
                ConfCityTextBox.Text = Formka.Dt.Cells["miasto_imp"].Value.ToString();
                ConfOrgTextBox.Text = Formka.Dt.Cells["org_imp"].Value.ToString();

                if (!string.IsNullOrEmpty(Formka.Dt.Cells["data_imp"].Value.ToString()))
                {
                    ConferenceDateDTP.Value = DateTime.ParseExact(Formka.Dt.Cells["data_imp"].Value.ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    ConferenceDateCheckBox.Checked = true;
                }
                else
                {
                    ConferenceDateDTP.Value = DateTime.Now;
                    ConferenceDateCheckBox.Checked = false;
                }
            }
        }
        #endregion

        #region SetSygsCount(int Count) - GOOD
        private void SetSygsCount(int Count)
        {
            SygsCountLabel.Text = Count.ToString();
        }
        #endregion

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (TomesCount > 0)
            {
                MessageBox.Show(_T("delete_volumes_first"), _T("deleting"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SygDGV.Rows.Count > 0)
            {
                if (MessageBox.Show(_T("delete_signatures_first_q"), _T("deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UbytkiForm UF = new UbytkiForm(BookID);
                    
                    if(UF.ShowDialog() == DialogResult.OK)
                        if(UF.AllSygsCount == 0)
                            DeleteBook();
                        else
                            LoadDataInControls(BookID, true, false);
                }
            }
            else 
            {
                if (!string.IsNullOrEmpty(MainBookID))
                {
                    if (MessageBox.Show(_T("delete_volume_q"), _T("vol_deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DeleteBook();
                    }
                }
                else
                {
                    if (MessageBox.Show(_T("delete_main_data_q"), _T("main_data_deleting"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DeleteBook();
                    }
                }
            }
        }

        #region DeleteBook() - GOOD
        private void DeleteBook()
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Ksiazki_DeleteBook @BookID; ";
            
            Command.Parameters.AddWithValue("@BookID", BookID);

            if (!string.IsNullOrEmpty(MainBookID))
            {
                Command.CommandText += "EXEC Ksiazki_DeleteTomeFromBook @MainBookID, @TomeID; ";

                Command.Parameters.AddWithValue("@MainBookID", MainBookID); 
                Command.Parameters.AddWithValue("@TomeID", BookID);
            }

            if (CommonFunctions.WriteData(Command, ref Settings.Connection))
            {
                if (!string.IsNullOrEmpty(MainBookID))
                    MessageBox.Show(_T("volume_was_deleted"), _T("url_deleting"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(_T("main_data_was_deleted"), _T("url_deleting"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Dispose();
            }            
        }
        #endregion

        #region PriceNumericUpDown_ValueChanged(object sender, EventArgs e) - GOOD
        private void PriceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ValueNumericUpDown.Value = PriceNumericUpDown.Value;
        }
        #endregion

        #region BarCodeTextBox_TextChanged(object sender, EventArgs e) - GOOD
        private void BarCodeTextBox_TextChanged(object sender, EventArgs e)
        {                            
            for(int i = 0; i < BarCodeTextBox.Text.Length; i++)
            {
                if (!char.IsDigit(BarCodeTextBox.Text[i]))
                {
                    BarCodeTextBox.Text = BarCodeTextBox.Text.Remove(i, 1);
                    i++;
                    BarCodeTextBox.SelectionStart = BarCodeTextBox.Text.Length;
                }
            }
        }
        #endregion

        private void ImportButton_Click(object sender, EventArgs e)
        {
            //this.Hide();

            ChooseServerForm CSF = new ChooseServerForm(Settings.ID_rodzaj, Settings.employeeID);
            
            this.Dispose();
        }

        private void CopySygToNumInwButton_Click(object sender, EventArgs e)
        {
            NumerInwTextBox.Text = SygnaturaTextBox.Text;
        }

        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {
            /*KeyTextBox.Text = KeyTextBox.Text.ToUpper();
            KeyTextBox.SelectionStart = KeyTextBox.Text.Length;*/
        }

        private void CleanPublisherButton_Click(object sender, EventArgs e)
        {
            if(PublishersID.Length > 0)
                PublishersID[0] = null;

            AddPublisherButton.Enabled = true;
            PublisherTextBox.Text = "";
            PlaceTextBox.Text = "";
            PublisherLabel.Visible = false;
        }

        private void CleanPublisher2Button_Click(object sender, EventArgs e)
        {
            if (PublishersID.Length > 1)
                PublishersID[1] = null;

            AddPublisher2Button.Enabled = true;
            Publisher2TextBox.Text = "";
            Place2TextBox.Text = "";
            Publisher2Label.Visible = false;
        }

        private void CleanSerieButton_Click(object sender, EventArgs e)
        {
            IDSerie = "";
            SerieTitleTextBox.ResetText();
            ISSNTextBox.ResetText();
            PartNameTextBox.ResetText();
            NumberNameTextBox.ResetText();
            InsytTextBox.ResetText();

            SerieTitleTextBox.ReadOnly = false;
            ISSNTextBox.ReadOnly = false;
            InsytTextBox.ReadOnly = false;
        }

        private void CleanSubSerieButton_Click(object sender, EventArgs e)
        {
            SubSerieID = "";
            SubSerieTitleTextBox.ResetText();
            ISSNSubSerieTextBox.ResetText();
            PartNameSubSerieTextBox.ResetText();
            NumberNameSubSerieTextBox.ResetText();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            KartaKatologowaPrintForm KKPF = new KartaKatologowaPrintForm(BookID, !string.IsNullOrEmpty(MainBookID), this);
            KKPF.Show();
        }

        private void CleanConferenceButton_Click(object sender, EventArgs e)
        {
            ConfID = "";

            ConfTitleTextBox.Text = "";
            ConfNumberTextBox.Text = "";
            ConfCountryButton.Text = "";
            ConfCityTextBox.Text = "";
            ConfCountryTextBox.Text = "";
            ConfOrgTextBox.Text = "";
            ConferenceDateCheckBox.Checked = false;
            ConferenceDateDTP.Value = DateTime.Now;
        }

        private void CleanLangButton_Click(object sender, EventArgs e)
        {
            LangID = "";
            LangTextBox.Text = "";
        }

        private void CleanLang2Button_Click(object sender, EventArgs e)
        {
            Lang2ID = "";
            Lang2TextBox.Text = "";
        }

        private void CleanLang3Button_Click(object sender, EventArgs e)
        {
            Lang3ID = "";
            Lang3TextBox.Text = "";
        }

        private void CleanLang4Button_Click(object sender, EventArgs e)
        {
            Lang4ID = "";
            Lang4TextBox.Text = "";
        }

        private void CleanLang5Button_Click(object sender, EventArgs e)
        {
            Lang5ID = "";
            Lang5TextBox.Text = "";
        }

        private void CleanConfCountryButton_Click(object sender, EventArgs e)
        {
            ConfCountryTextBox.Text = "";
        }

        private void DetailsForm_Activated(object sender, EventArgs e)
        {            
            if (this.ActiveReason == FormActivate.faAuthorsForm)
            {
                if(authorsForm.DialogResult == DialogResult.OK)
                    ProcessAuthors(authorsForm);
            }
            else if (this.ActiveReason == FormActivate.faTomesForm)
                LoadTomesCount();
            
            this.ActiveReason = FormActivate.faMainForm;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            e.Cancel = !e.TabPage.Enabled;
        }

        private void DetailsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ReadOnly)
            {
//                this.Dispose();
                return;
            }

            lEdit = lEdit || CurrentMode == ModeEnum.Add || _dirtyTracker.IsDirty;
            if (!lEdit) return;

            if (MessageBox.Show(_T("close_window_wo_saving"), _T("exit"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                if (CurrentMode == ModeEnum.Edit)
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;

                return;
                //this.Dispose();
            }

            e.Cancel = true;
        }

    }
}
