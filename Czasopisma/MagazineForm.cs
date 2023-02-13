using System.Threading;
using Akcesja;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using Wypozyczalnia;
using WinformsDirtyTracking;


namespace Czasopisma
{
    public partial class MagazineForm : Form
    {
        #region variables
        public enum ModeEnum { Add, Edit, Delete };
        private enum SygModeEnum { Add, Edit, None };
        private enum VolumesModeEnum { Add, Edit, None, NoActive };

        private ModeEnum CurrentModeEnum;
        private SygModeEnum CurrentSygMode;
        private VolumesModeEnum CurrentVolumesMode;

        private string MagazineID;

        private string PublisherID;
        private string[] Publisher;

        private string KolporterID;
        private string[] Kolporter;
        private string TempSyg;
        private string TempVol;

        private List<string> KeysToDelete;
        
        private int FreqInAkcesja;

        private int id_rodzaj;
        private bool Seryjne;

        private Dictionary<int, string> FreqComboBoxValuesDictionary;
        private int TempID;
        private DataTable SygDataTable;
        private DataTable VolumesDataTable;
        private DataTable InstitutionsDataTable;

        private DataTable TempDodatki;
        private int FreqIndex;
        private Dictionary<string, string> _translationsDictionary;
        SlightlyMoreSophisticatedDirtyTracker _dirtyTracker;
        bool lEdit;
        #endregion

        #region MagazineForm(string employeeID)
        public MagazineForm(string employeeID)
        {
            InitializeComponent();

            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            Settings.employeeID = employeeID;

            ToolTip CopyToolTip = new ToolTip();            
            CopyToolTip.SetToolTip(SelectMagazineButton, _translationsDictionary.getStringFromDictionary("copy_description", "Kopiuj opis"));

            string clean = _translationsDictionary.getStringFromDictionary("to_clean", "Wyczyść");

            ToolTip CleanToolTip = new ToolTip();
            CleanToolTip.SetToolTip(CleanCountryButton, clean);
            CleanToolTip.SetToolTip(CleanLangButton, clean);
            CleanToolTip.SetToolTip(CleanLang2Button, clean);
            CleanToolTip.SetToolTip(CleanLang3Button, clean);

            ToolTip AttachmentToolTip = new ToolTip();
            AttachmentToolTip.SetToolTip(SourcesButton, _translationsDictionary.getStringFromDictionary("add_attachments", "Dodaj załączniki"));

            ToolTip SygtToolTip = new ToolTip();
            SygtToolTip.SetToolTip(DeleteSygButton, _translationsDictionary.getStringFromDictionary("delete_signature",  "Usuń sygnaturę"));

            ToolTip WolToolTip = new ToolTip();
            WolToolTip.SetToolTip(DeleteVoluminButton, _translationsDictionary.getStringFromDictionary("delete_volume", "Usuń wolumin"));

            ContentFormDictionary();
            if (LangTextBox.Text == null || LangTextBox.Text == "") LangTextBox.Text = "POL";

            FreqInAkcesja = -1;
        }
        #endregion

        #region MagazineForm(int id_rodzaj, string employeeID, bool Seryjne = false) : this() - dodawanie
        //dodawanie
        public MagazineForm(int id_rodzaj, string employeeID, bool Seryjne = false) : this(employeeID)
        {
            CurrentModeEnum = ModeEnum.Add;

            Settings.SetSettings(id_rodzaj);
            Settings.employeeID = employeeID;

            CommonFunctions.LoadConfig(this.Controls, ref Settings.Connection, 2);
            this.id_rodzaj = id_rodzaj;

            this.Seryjne = Seryjne;

            FreqComboBoxValuesDictionary = new Dictionary<int, string>();

            GenerateFreqComboBoxValues();

            PublisherID = "";
            KolporterID = "";

            KeysToDelete = new List<string>();                        

            TempID = 1;

            if (!Seryjne)
            {
                EwidencjaTabControl.TabPages.RemoveByKey("SeryjnaTabPage");
            }
            else
            {
                EwidencjaTabControl.TabPages.RemoveByKey("EwidencjaTabPage");
                ExtrasButton.Visible = false;
                ExtrasLabel.Visible = false;
            }

            LoadSposobNabycia();

            SygDataTable = new DataTable();
            SygDataTable.Columns.Add("tempID");
            SygDataTable.Columns.Add("id_cza_syg");
            SygDataTable.Columns.Add("syg");
            SygDataTable.Columns.Add("old_syg");            

            VolumesDataTable = new DataTable();

            if (!Seryjne)
            {                
                VolumesDataTable.Columns.Add("TempID");
                VolumesDataTable.Columns.Add("id");
                VolumesDataTable.Columns.Add("rok1");
                VolumesDataTable.Columns.Add("rok2");
                VolumesDataTable.Columns.Add("volumin");
                VolumesDataTable.Columns.Add("czesci");
                VolumesDataTable.Columns.Add("uwagi_v");
                VolumesDataTable.Columns.Add("nab");
                VolumesDataTable.Columns.Add("numer_inw");
                VolumesDataTable.Columns.Add("rocz_pren");
                VolumesDataTable.Columns.Add("wart_vol");
                VolumesDataTable.Columns.Add("data_biez");
                VolumesDataTable.Columns.Add("ilosc_dodatki");
                VolumesDataTable.Columns.Add("dodatki", typeof(DataTable));
                VolumesDataTable.Columns.Add("syg");
                VolumesDataTable.Columns.Add("id_cza_syg");
            }
            else
            {                
                VolumesDataTable.Columns.Add("TempID");
                VolumesDataTable.Columns.Add("id");
                VolumesDataTable.Columns.Add("syg");
                VolumesDataTable.Columns.Add("numer_ser");
                VolumesDataTable.Columns.Add("tytul_ser");
                VolumesDataTable.Columns.Add("rok_ser");
                VolumesDataTable.Columns.Add("strony_ser");
                VolumesDataTable.Columns.Add("autor1_ser");
                VolumesDataTable.Columns.Add("autor2_ser");
                VolumesDataTable.Columns.Add("autor3_ser");
                VolumesDataTable.Columns.Add("nr_kol_ser");
                VolumesDataTable.Columns.Add("wart_ser");
                VolumesDataTable.Columns.Add("numer_inw");
                VolumesDataTable.Columns.Add("nab");
                VolumesDataTable.Columns.Add("uwagi_s");
                VolumesDataTable.Columns.Add("dodatki", typeof(DataTable));
                VolumesDataTable.Columns.Add("id_cza_syg");
            }

            TempDodatki = new DataTable();

            SearchButton.Visible = false;

            InstitutionsDataTable = new DataTable();
            InstitutionsDataTable.Columns.Add("idTemp");
            InstitutionsDataTable.Columns.Add("id");
            InstitutionsDataTable.Columns.Add("nazwa");
            InstitutionsDataTable.Columns.Add("siedziba");

            ChangeSygState(SygModeEnum.None);
            ChangeVolumesMode(VolumesModeEnum.NoActive);

            keySuggest("");
            if (LangTextBox.Text == "") LangTextBox.Text = "POL";
        }
        #endregion

        #region MagazineForm(int id_rodzaj, string MagazineID, string employeeID,bool Seryjne = false) : this(id_rodzaj, Seryjne) - edycja
        // edycja
        public MagazineForm(int id_rodzaj, string MagazineID, string employeeID, bool Seryjne = false) : this(id_rodzaj, employeeID, Seryjne)
        {           
            CurrentModeEnum = ModeEnum.Edit;

            this.MagazineID = MagazineID;

            TempDodatki = new DataTable();

            LoadData(MagazineID, true);
            if (LangTextBox.Text == null || LangTextBox.Text.Trim() == "") LangTextBox.Text = "POL";

            ChangeSygState(SygModeEnum.None);
            //ChangeVolumesMode(VolumesModeEnum.None);

            if (!Seryjne)
            {
                VolumesDataTable = new DataTable();
                VolumesDataTable.Columns.Add("TempID");
                VolumesDataTable.Columns.Add("id");
                VolumesDataTable.Columns.Add("rok1");
                VolumesDataTable.Columns.Add("rok2");
                VolumesDataTable.Columns.Add("volumin");
                VolumesDataTable.Columns.Add("czesci");
                VolumesDataTable.Columns.Add("uwagi_v");
                VolumesDataTable.Columns.Add("nab");
                VolumesDataTable.Columns.Add("numer_inw");
                VolumesDataTable.Columns.Add("rocz_pren");
                VolumesDataTable.Columns.Add("wart_vol");
                VolumesDataTable.Columns.Add("data_biez");
                VolumesDataTable.Columns.Add("ilosc_dodatki");
                VolumesDataTable.Columns.Add("dodatki", typeof(DataTable));
                VolumesDataTable.Columns.Add("syg");
                VolumesDataTable.Columns.Add("id_cza_syg");
            }
            else
            {
                VolumesDataTable = new DataTable();
                VolumesDataTable.Columns.Add("TempID");
                VolumesDataTable.Columns.Add("id");
                VolumesDataTable.Columns.Add("syg");
                VolumesDataTable.Columns.Add("numer_ser");
                VolumesDataTable.Columns.Add("tytul_ser");
                VolumesDataTable.Columns.Add("rok_ser");
                VolumesDataTable.Columns.Add("strony_ser");                
                VolumesDataTable.Columns.Add("autor1_ser");
                VolumesDataTable.Columns.Add("autor2_ser");
                VolumesDataTable.Columns.Add("autor3_ser");
                VolumesDataTable.Columns.Add("nr_kol_ser");
                VolumesDataTable.Columns.Add("wart_ser");
                VolumesDataTable.Columns.Add("numer_inw");
                VolumesDataTable.Columns.Add("nab");
                VolumesDataTable.Columns.Add("uwagi_s");
                VolumesDataTable.Columns.Add("dodatki", typeof(DataTable));
                VolumesDataTable.Columns.Add("id_cza_syg");
            }
        }
        #endregion

        #region MagazineForm(string MagazineID, string employeeID, bool Seryjne = false) : this() - usuwanie
        // usuwanie
        public MagazineForm(string MagazineID, string employeeID, bool Seryjne = false)
            : this(employeeID)
        {
            CommonFunctions.LoadConfig(this.Controls, ref Settings.Connection, 2);
            CurrentModeEnum = ModeEnum.Delete;

            this.MagazineID = MagazineID;

            Settings.ReadOnlyMode = true;

            FreqComboBoxValuesDictionary = new Dictionary<int, string>();

            SaveButton.Visible = false;
            DeleteButton.Visible = true;

            GenerateFreqComboBoxValues();

            VolumesDataTable = new DataTable();
            TempDodatki = new DataTable();

            TempID = 1;

            if (!Seryjne)
            {
                EwidencjaTabControl.TabPages.RemoveByKey("SeryjnaTabPage");
            }
            else
            {
                EwidencjaTabControl.TabPages.RemoveByKey("EwidencjaTabPage");
                ExtrasButton.Visible = false;
                ExtrasLabel.Visible = false;
            }

            LoadSposobNabycia();

            LoadData(MagazineID, true);
            ChangeSygState(SygModeEnum.None);
            //ChangeVolumesMode(VolumesModeEnum.None);

           Lock();           
        }
        #endregion

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            // main
            mapping.Add(tabPage1, "main_card");
            mapping.Add(tabPage3, "registration_data");
            mapping.Add(tabPage2, "factual_description");

            mapping.Add(groupBox3, "title");
            mapping.Add(TitleChangesCheckBox, "title_changes");
            mapping.Add(mainTitleLabel, "main_title");
            mapping.Add(subtitleLabel, "subtitle");
            mapping.Add(parallelLabel, "parallel_title");
            mapping.Add(additionalLabel, "additional_title");

            mapping.Add(groupBox1, "suppliers_publishers");
            mapping.Add(InstitutionsChangesCheckBox, "institutions_change_history");
            mapping.Add(institutiuonLabel, "institution");
            mapping.Add(seatLabel, "seat");
            mapping.Add(redactorLabel, "redactor");
            mapping.Add(publisherLabel, "publisher_001");
            mapping.Add(supplierLabel, "supplier");

            mapping.Add(publishCountryLabel, "publish_country");
            mapping.Add(formatLabel, "format");
            mapping.Add(unitOfLengthLabel, "unit_of_length");
            mapping.Add(frequencyLabel, "frequency");
            mapping.Add(issnLabel, "ISSN");
            mapping.Add(commentsLabel, "comments");

            // evidence
            mapping.Add(groupBox5, "existing_signatures");
            mapping.Add(Sygnatura, "signature");
            mapping.Add(groupBox6, "chosen_signature");
            mapping.Add(NewSygButton, "new_signature");
            mapping.Add(EditSygButton, "edit");
            mapping.Add(DeleteSygButton, "delete");
            mapping.Add(SaveSygButton, "save");
            mapping.Add(CancelSygButton, "cancel");
            mapping.Add(lastSygsLabel, "f2_last_signatures");
            mapping.Add(Volumes, "volumes");
            mapping.Add(NewVoluminButton, "new_volume");
            mapping.Add(EditVoluminButton, "edit");
            mapping.Add(DeleteVoluminButton, "delete");
            mapping.Add(SaveVoluminButton, "save");
            mapping.Add(CancelVoluminButton, "cancel");
            mapping.Add(ExtrasLabel, "supplements");
            // tab evidence
            mapping.Add(EwidencjaTabPage, "registration");
            mapping.Add(SeryjnaTabPage, "serial_registration");
            mapping.Add(yearEvidenceLabel, "year");
            mapping.Add(volumeEvidenceLabel, "volume");
            mapping.Add(numbersEvidenceLabel, "numbers");
            mapping.Add(commentsEvidenceLabel, "comments");
            mapping.Add(acquisitionEvidenceLabel, "method_of_acquisition");
            mapping.Add(invertoryNumberEvidenceLabel, "inventory_number");
            mapping.Add(PriceLabel, "price_of_annual_subscription");
            mapping.Add(PriceValueLabel, "volume_value");
            mapping.Add(entryDateEvidenceLabel, "data_of_entry");
            // tab serial
            mapping.Add(numberSerialLabel, "number");
            mapping.Add(titleSerialLabel, "title");
            mapping.Add(authorsSerialLabel, "authors");
            mapping.Add(invertoryNumberSerialLabel, "inventory_number");
            mapping.Add(acquisitionSerialLabel, "method_of_acquisition");
            mapping.Add(pagesSerialLabel, "pages");
            mapping.Add(SerPriceValueLabel, "volume_value");
            mapping.Add(absoluteNumberSerialLabel, "absolute_number");
            mapping.Add(commentsSerialLabel, "comments");

            // factual description
            mapping.Add(groupBox7, "factual_classification");
            mapping.Add(formOfDocumentcontentLabel, "form_of_document_content");
            mapping.Add(LanguagesLabel, "languages_of_text");

            // bottom buttons
            mapping.Add(PrintButton, "print");
            mapping.Add(SaveButton, "save");
            mapping.Add(SearchButton, "search");
            mapping.Add(DeleteButton, "delete_magazine");
            mapping.Add(SourcesButton, "sources");
            mapping.Add(ExitButton, "exit");

            mapping.Add(this, "magazine_registration");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        #region ContentFormDictionary()
        //Tworzy słownik do FormAndContentComboBox
        private void ContentFormDictionary()
        {
            Dictionary<int, string> ContentFormComboboxValues = new Dictionary<int, string>();

            ContentFormComboboxValues.Add(0, "");
            ContentFormComboboxValues.Add(1, _translationsDictionary.getStringFromDictionary("articles", "Artykuły"));
            ContentFormComboboxValues.Add(2, _translationsDictionary.getStringFromDictionary("bibliography", "Bibliografia"));
            ContentFormComboboxValues.Add(3, _translationsDictionary.getStringFromDictionary("biographies", "Biografie"));
            ContentFormComboboxValues.Add(4, _translationsDictionary.getStringFromDictionary("chronologies", "Chronologie"));
            ContentFormComboboxValues.Add(5, _translationsDictionary.getStringFromDictionary("documents", "Dokumenty"));
            ContentFormComboboxValues.Add(6, _translationsDictionary.getStringFromDictionary("statistics", "Statystyka"));
            ContentFormComboboxValues.Add(7, _translationsDictionary.getStringFromDictionary("analysis_and_elaboration", "Analizy i opracowania"));
            ContentFormComboboxValues.Add(8, _translationsDictionary.getStringFromDictionary("laws", "Przepisy prawne"));

            FormAndContentComboBox.DataSource = new BindingSource(ContentFormComboboxValues, null);
            FormAndContentComboBox.DisplayMember = "Value";
            FormAndContentComboBox.ValueMember = "Key";
        }
        #endregion

        #region Lock()
        private void Lock()
        {
            // ZAKŁADKA "Karta główna"
            SelectMagazineButton.Enabled = false;

            // tytuły
            TitleTextBox.ReadOnly = true;
            SubtitleTextBox.ReadOnly = true;
            ParallelTitleTextBox.ReadOnly = true;
            AdditionTitleTextBox.ReadOnly = true;

            // instytucja
            SelectInstitutionButton.Enabled = false;
            InstitutionTextBox.ReadOnly = true;
            PlaceTextBox.ReadOnly = true;
            RedaktorTextBox.ReadOnly = true;

            // wydawcy
            AddPublisherButton.Enabled = false;
            CleanPublisherButton.Visible = false;
            SelectPublisherButton.Enabled = false;

            // dostawcy
            AddKolporterButton.Enabled = false;
            CleanKolporterButton.Visible = false;
            SelectKolporterButton.Enabled = false;

            // kraj
            CountryButton.Enabled = false;
            HeightTextBox.ReadOnly = true;
            FreqComboBox.Enabled = false;
            ISSNTextBox.ReadOnly = true;
            CommentsRichTextBox.ReadOnly = true;
            CleanCountryButton.Visible = false;

            // ZAKŁADKA "Dane ewidencyjne"


            // ZAKŁADKA "Opis rzeczowy"
            KeyListButton.Enabled = false;
            NewKeyButton.Enabled = false;
            DeleteKeyButton.Enabled = false;
            KeyTextBox.ReadOnly = true;

            // języki
            CleanLangButton.Visible = false;
            CleanLang2Button.Visible = false;
            CleanLang3Button.Visible = false;

            LangButton.Enabled = false;
            Lang2Button.Enabled = false;
            Lang3Button.Enabled = false;

            // zawartość
            FormAndContentComboBox.Enabled = false;
        }
        #endregion

        #region GenerateFreqComboBoxValues()
        private void GenerateFreqComboBoxValues()
        {            
            // wygenerowanie częstotliwości            
            FreqComboBoxValuesDictionary.Add(1, _translationsDictionary.getStringFromDictionary("daily","DZIENNIK"));
            FreqComboBoxValuesDictionary.Add(2, _translationsDictionary.getStringFromDictionary("weekly","TYGODNIK"));
            FreqComboBoxValuesDictionary.Add(3, _translationsDictionary.getStringFromDictionary("biweekly","DWUTYGODNIK"));
            FreqComboBoxValuesDictionary.Add(4, _translationsDictionary.getStringFromDictionary("monthly","MIESIĘCZNIK"));
            FreqComboBoxValuesDictionary.Add(5, _translationsDictionary.getStringFromDictionary("bimonthly","DWUMIESIĘCZNIK"));
            FreqComboBoxValuesDictionary.Add(6, _translationsDictionary.getStringFromDictionary("quarterly", "KWARTALNIK"));
            FreqComboBoxValuesDictionary.Add(7, _translationsDictionary.getStringFromDictionary("half_yearly", "PÓŁROCZNIK"));
            FreqComboBoxValuesDictionary.Add(8, _translationsDictionary.getStringFromDictionary("yearly", "ROCZNIK"));
            FreqComboBoxValuesDictionary.Add(9, _translationsDictionary.getStringFromDictionary("irregular", "NIEREGULARNE"));

            // zaimportowanie częstotliwości do ComboBoxa
            FreqComboBox.DataSource = new BindingSource(FreqComboBoxValuesDictionary, null);
            FreqComboBox.ValueMember = "Key";
            FreqComboBox.DisplayMember = "Value";
        }
        #endregion

        #region CleanPublisherButton_Click(object sender, EventArgs e)
        private void CleanPublisherButton_Click(object sender, EventArgs e)
        {
            // wyczyszczenie ID wydawcy
            PublisherID = "";

            // wyczyszczenie textboxa wydawcy
            PublisherTextBox.ResetText();

            Publisher = null;

            AddPublisherButton.Enabled = true;
        }
        #endregion

        #region CleanKolporterButton_Click(object sender, EventArgs e)
        private void CleanKolporterButton_Click(object sender, EventArgs e)
        {
            // wyczyszczenie ID kolportera
            KolporterID = "";

            // wyczyszczenie textboxa kolportera
            KolporterTextBox.ResetText();

            AddKolporterButton.Enabled = true;
        }
        #endregion

        #region SelectPublisherButton_Click(object sender, EventArgs e)
        private void SelectPublisherButton_Click(object sender, EventArgs e)
        {
            // inicjalizacja 
            SqlCommand Command = new SqlCommand("EXEC PublishersList 2;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "nazwa_w";
            Columns[1].Name = "nazwa_w";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("publisher_name", "Nazwa wydawcy");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "miasto_w";
            Columns[2].Name = "miasto_w";
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("city", "Miasto");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybierz wydawcę");

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // przypisanie ID i nazwy wydawcy
                PublisherTextBox.Text = Formka.Dt.Cells["miasto_w"].Value.ToString().Trim() + (Formka.Dt.Cells["miasto_w"].Value.ToString().Trim().Length > 0 ? ": " : "") + Formka.Dt.Cells["nazwa_w"].Value.ToString();                
                PublisherID = Formka.Dt.Cells["id"].Value.ToString();

                Publisher = null;

                AddPublisherButton.Enabled = false;
            }
        }
        #endregion

        #region AddPublisherButton_Click(object sender, EventArgs e)
        private void AddPublisherButton_Click(object sender, EventArgs e)
        {
            PublisherForm PF = new PublisherForm();

            if(Publisher != null)
                PF = new PublisherForm(Publisher);
            
            if(PF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Publisher = PF.Publisher;

                PublisherTextBox.Text = PF.Publisher[2].Trim() + (PF.Publisher[2].Trim().Length > 0 ? ": " : "") + PF.Publisher[0];
                //AddPublisherButton.Enabled = false;
            }
        }
        #endregion 

        #region SelectKolporterButton_Click(object sender, EventArgs e)
        private void SelectKolporterButton_Click(object sender, EventArgs e)
        {
            // inicjalizacja 
            SqlCommand Command = new SqlCommand("EXEC DistributorsList;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "nazwa_k";
            Columns[1].Name = "nazwa_k";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("supplier_name", "Nazwa dostawcy");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "miasto_k";
            Columns[2].Name = "miasto_k";
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("city", "Miasto");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybierz dostawcę");

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // przypisanie ID i nazwy kolportera
                KolporterTextBox.Text = Formka.Dt.Cells["miasto_k"].Value.ToString().Trim() + (Formka.Dt.Cells["miasto_k"].Value.ToString().Trim().Length > 0 ? ": " : "") + Formka.Dt.Cells["nazwa_k"].Value.ToString();
                KolporterID = Formka.Dt.Cells["id"].Value.ToString();

                AddKolporterButton.Enabled = false;
            }
        }
        #endregion

        #region SelectInstitutionButton_Click(object sender, EventArgs e)
        private void SelectInstitutionButton_Click(object sender, EventArgs e)
        {
            // inicjalizacja 
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_InstitutionsList; ";

            DataGridViewColumn[] Columns = new DataGridViewColumn[2];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "nazwa_inst";
            Columns[0].Name = "nazwa_inst";
            Columns[0].HeaderText = _translationsDictionary.getStringFromDictionary("name_of_institution", "Nazwa instytucji");
            Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "siedziba";
            Columns[1].Name = "siedziba";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("city", "Miasto");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);

            if (Formka.ShowDialog() == DialogResult.OK)
            {
                // przypisanie siedziby i nazwy instytucji
                InstitutionTextBox.Text = Formka.Dt.Cells["nazwa_inst"].Value.ToString();
                PlaceTextBox.Text = Formka.Dt.Cells["siedziba"].Value.ToString();
            }
        }
        #endregion

        #region CountryButton_Click(object sender, EventArgs e)
        private void CountryButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC CountryList;");

            DataGridViewColumn[] Columns = new DataGridViewColumn[2];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "kod";
            Columns[0].Name = "Kod";
            Columns[0].HeaderText = _translationsDictionary.getStringFromDictionary("code", "Kod");
            Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "p_sk_nazwa";
            Columns[1].Name = "Państwo";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("country", "Państwo");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns, "Państwo");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                CountryTextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();
        }
        #endregion

        #region AddKolporterButton_Click(object sender, EventArgs e)
        private void AddKolporterButton_Click(object sender, EventArgs e)
        {
            DistributorForm DF = new DistributorForm();

            if(Kolporter != null)
                DF = new DistributorForm(Kolporter);
            
            if(DF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.Kolporter = DF.Kolporter;

                KolporterTextBox.Text = DF.Kolporter[3].Trim() + (DF.Kolporter[3].Trim().Length > 0 ? ": " : "") + DF.Kolporter[0];
                //AddKolporterButton.Enabled = false;
            }
        }
        #endregion

        #region KeyListButton_Click(object sender, EventArgs e)
        private void KeyListButton_Click(object sender, EventArgs e)
        {
            ShowKeyListForm KeyListWindow = new ShowKeyListForm(KeysDataGridView);

            DialogResult result = KeyListWindow.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
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

                foreach (DataGridViewRow Row in KeyListWindow.SelectedDataGridView.Rows)
                {                    
                    KeysDataGridView.Rows.Add(new string[] { Row.Cells["id"].Value.ToString(), Row.Cells["Key"].Value.ToString() });
                }
            }
        }
        #endregion

        #region DeleteKeyButton_Click(object sender, EventArgs e)
        private void DeleteKeyButton_Click(object sender, EventArgs e)
        {
            if (KeysDataGridView.SelectedRows.Count > 0)
                KeysToDelete.Add(KeysDataGridView.SelectedRows[0].Cells["id"].Value.ToString());    

            foreach (DataGridViewRow Row in KeysDataGridView.SelectedRows)
                KeysDataGridView.Rows.RemoveAt(Row.Index);

            KeyTextBox.Text = "";
        }
        #endregion

        #region AddKeyToGrid()
        private void AddKeyToGrid()
        {
            if (KeyTextBox.Text.Trim() == "")
                return;

            try
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Czasop_KeyExists @klucze, @id_rodzaj; ";
                Command.Parameters.AddWithValue("@klucze", KeyTextBox.Text);
                Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

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
                    if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("key_not_found_add_it", "Brak słowa kluczowego w bazie. Dodać nowe słowo kluczowe?"), _translationsDictionary.getStringFromDictionary("adding_key", "Dodawanie słowa kluczowego"), MessageBoxButtons.YesNo, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Command.CommandText = "EXEC Czasop_AddKey @klucze, @id_rodzaj, @KeyID OUTPUT;";

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
                MessageBox.Show(Ex.Message, _translationsDictionary.getStringFromDictionary("error", "Błąd"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            KeysDataGridView.Sort(KeysDataGridView.Columns["Key"], ListSortDirection.Ascending);
        }
        #endregion

        #region NewKeyButton_Click(object sender, EventArgs e)
        private void NewKeyButton_Click(object sender, EventArgs e)
        {
            AddKeyToGrid();
        }
        #endregion

        #region SelectMagazineButton_Click(object sender, EventArgs e)
        private void SelectMagazineButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand("EXEC Czasop_MagazinesList @id_rodzaj, @seryjne; ");
            Command.Parameters.AddWithValue("@id_rodzaj", id_rodzaj);
            Command.Parameters.AddWithValue("@seryjne", (CurrentModeEnum == ModeEnum.Delete) ? 2 : !Seryjne ? 0 : 1);

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "id";
            Columns[0].Name = "id";
            Columns[0].Visible = false;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "tytul";
            Columns[1].Name = "tytul";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("magazine_title",  "Tytuł czasopisma");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "syg";
            Columns[2].Name = "syg";
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("signature", "Sygnatura");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybieranie");

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LoadData(Formka.Dt.Cells["id"].Value.ToString());
            }
        }
        #endregion

        #region FreqComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        private void FreqComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (CurrentModeEnum == ModeEnum.Edit)
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Czasop_FreqInAkcesja @MagazineID; ";
                Command.Parameters.AddWithValue("@MagazineID", MagazineID);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0][0].ToString() != "-1")
                    {
                        FreqInAkcesja = Int32.Parse(Dt.Rows[0][0].ToString());                        

                        if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("info_about_magazine_freq_changing", "Zmiana częstotliwości czasopisma spowoduje utratę informacji o dotychczas wprowadzonych numerach w akcesji. Jeśli czasopismo zmieniło częstotliwość załóż drugą kartę główną czasopisma ze zmienioną częstotliwością oraz nową kartę akcesji. Czy mimo to zmienić częstotliwość w akcesji tego czasopisma?"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.No)
                        {                            
                            FreqComboBox.SelectedIndex = FreqIndex;
                        }

                        this.FreqIndex = FreqComboBox.SelectedIndex;
                    }
                }
            }
        }
        #endregion

        #region GetFreqInAkcesja(string MagazineID)
        private void GetFreqInAkcesja(string MagazineID)
        {
            // sprawdzenie częstotliwości w akcesji
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_FreqInAkcesja @MagazineID; ";
            Command.Parameters.AddWithValue("@MagazineID", MagazineID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][0].ToString() != "-1")
                {
                    FreqInAkcesja = Int32.Parse(Dt.Rows[0][0].ToString());
                }
                else
                    FreqInAkcesja = -1;
            }
        }
        #endregion

        #region LoadData(string MagazineID, bool First = false)
        private void LoadData(string MagazineID, bool First = false)
        {
            GetFreqInAkcesja(MagazineID);

            // ZAKŁADKA "karta główna"
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_AboutMagazine @MagazineID; ";
            Command.Parameters.AddWithValue("@MagazineID", MagazineID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if(Dt.Rows.Count > 0)
            {
                // zmiany tytułu
                TitleChangesCheckBox.Checked = !string.IsNullOrEmpty(Dt.Rows[0]["z_kodu"].ToString()) || !string.IsNullOrEmpty(Dt.Rows[0]["na_kod"].ToString());

                // tytuły
                TitleTextBox.Text = Dt.Rows[0]["tytul"].ToString();
                SubtitleTextBox.Text = Dt.Rows[0]["podtytul"].ToString();
                ParallelTitleTextBox.Text = Dt.Rows[0]["t_rownol"].ToString();
                AdditionTitleTextBox.Text = Dt.Rows[0]["t_dodatk"].ToString();

                // zmiany instytucji
                InstitutionsChangesCheckBox.Checked = !string.IsNullOrEmpty(Dt.Rows[0]["ilosc"].ToString()) && Dt.Rows[0]["ilosc"].ToString() != "0";

                // instytucja
                InstitutionTextBox.Text = Dt.Rows[0]["nazwa_inst"].ToString();
                PlaceTextBox.Text = Dt.Rows[0]["siedziba"].ToString();

                // wydawca
                PublisherID = Dt.Rows[0]["id_wydawcy"].ToString();
                PublisherTextBox.Text = Dt.Rows[0]["miasto_w"].ToString().Trim() + (Dt.Rows[0]["miasto_w"].ToString().Trim().Length > 0 ? ": " : "") + Dt.Rows[0]["nazwa_w"].ToString();

                // redaktor
                RedaktorTextBox.Text = Dt.Rows[0]["redaktor"].ToString();

                if(!string.IsNullOrEmpty(PublisherID))
                {
                    AddPublisherButton.Enabled = false;
                }

                // dostawca
                KolporterID = Dt.Rows[0]["id_kolport"].ToString();
                KolporterTextBox.Text = Dt.Rows[0]["miasto_k"].ToString().Trim() + (Dt.Rows[0]["miasto_k"].ToString().Trim().Length > 0 ? ": " : "") +  Dt.Rows[0]["nazwa_k"].ToString();

                if (!string.IsNullOrEmpty(KolporterID))
                {
                    AddKolporterButton.Enabled = false;
                }

                // kraj wydania
                CountryTextBox.Text = Dt.Rows[0]["kraj_w"].ToString();

                // wysokość (format)
                HeightTextBox.Text = Dt.Rows[0]["wysokosc"].ToString();

                // ISSN
                ISSNTextBox.Text = Dt.Rows[0]["ISSN"].ToString();

                // uwagi
                CommentsRichTextBox.Text = Dt.Rows[0]["uwagi"].ToString();

                // częstotliwość
                if (!string.IsNullOrEmpty(Dt.Rows[0]["id_czest"].ToString()) && FreqComboBoxValuesDictionary.Keys.Contains(Int32.Parse(Dt.Rows[0]["id_czest"].ToString())))
                    FreqComboBox.SelectedValue = Int32.Parse(Dt.Rows[0]["id_czest"].ToString());

                // ZAKŁADKA "Opis rzeczowy"
                // forma zawartości
                if (!string.IsNullOrEmpty(Dt.Rows[0]["zawartosc"].ToString()))
                    FormAndContentComboBox.SelectedValue = Int32.Parse(Dt.Rows[0]["zawartosc"].ToString());                

                // języki
                LangTextBox.Text = Dt.Rows[0]["jezyk1"].ToString();
                Lang2TextBox.Text = Dt.Rows[0]["jezyk2"].ToString();
                Lang3TextBox.Text = Dt.Rows[0]["jezyk3"].ToString();

            }

            //start - załadowanie kluczy książki
            Command.CommandText = "EXEC Czasop_AboutMagazineKeys @MagazineID; ";

            Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (KeysDataGridView.Rows.Count > 0)
                KeysDataGridView.Rows.Clear();

            foreach (DataRow Row in Dt.Rows)
            {
                KeysDataGridView.Rows.Add(new string[] { Row["id"].ToString(), Row["klucz"].ToString() });
            }
            //koniec - załadowanie kluczy książki

            // ZAKŁADKA "Dane ewidencyjne"
            if(First)
                LoadSygs(MagazineID);

            _dirtyTracker = new SlightlyMoreSophisticatedDirtyTracker();
            _dirtyTracker.AddControls(tabPage1.Controls);
            _dirtyTracker.AddControls(tabPage2.Controls, "$KeyTextBox");
            _dirtyTracker.MarkAsClean();
            lEdit = false;

        }
        #endregion

        #region LoadSygs(string MagazineID)
        private void LoadSygs(string MagazineID)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Czasop_MagazineSygs @MagazineID; ";
            Command.Parameters.AddWithValue("@MagazineID", MagazineID);

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            CurrentSygTextBox.ResetText();

            if(SygsDGV.Rows.Count > 0)
                SygsDGV.Rows.Clear();

            if (Dt.Rows.Count > 0)
            {
                for(int i = 0; i < Dt.Rows.Count; i++)
                {
                    SygsDGV.Rows.Add(TempID, Dt.Rows[i]["id"].ToString(), Dt.Rows[i]["syg"].ToString(), Dt.Rows[i]["syg"].ToString());

                    TempID++;
                }
                
                ChangeVolumesMode(VolumesModeEnum.None);
            }
            else
                ChangeVolumesMode(VolumesModeEnum.NoActive);

            ChangeSygState(SygModeEnum.None);

            if (TempSyg != null)
            {
                for (int i = 0; i < SygsDGV.Rows.Count; i++)
                {
                    if (SygsDGV.Rows[i].Cells["Sygnatura"].Value.ToString() == TempSyg)
                    {
                        SygsDGV.ClearSelection();
                        SygsDGV.Rows[i].Selected = true;

                        SygsDGV.CurrentCell = SygsDGV["Sygnatura", i];

                        SygsDGV.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
        }
        #endregion

        #region LoadVolumes(string MagazineID, string id_cza_Syg, string syg)
        private void LoadVolumes(string MagazineID, string id_cza_Syg, string syg)
        {
            if (VolumesDGV.Rows.Count > 0)
                VolumesDGV.Rows.Clear();

            DataTable Dt = new DataTable();            
            Dt.Columns.Add("id");
            Dt.Columns.Add("volumin");
            Dt.Columns.Add("rok1");

            if (CurrentModeEnum != ModeEnum.Add)
            {
                SqlCommand Command = new SqlCommand();

                if (!Seryjne)
                    Command.CommandText = "EXEC Czasop_VolumesList @MagazineID, @id_cza_Syg; ";
                else
                    Command.CommandText = "EXEC Czasop_SeryjneList @MagazineID, @id_cza_Syg; ";

                Command.Parameters.AddWithValue("@MagazineID", MagazineID);
                Command.Parameters.AddWithValue("@id_cza_Syg", id_cza_Syg);

                DataTable tempDt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                for (int i = 0; i < tempDt.Rows.Count; i++)
                {
                    Dt.Rows.Add(tempDt.Rows[i]["id"], tempDt.Rows[i]["volumin"], tempDt.Rows[i]["rok1"]);
                }
            }

            Dt.Columns.Add("TempID");
            Dt.Columns["TempID"].SetOrdinal(0);

            for (int i = 0; i < Dt.Rows.Count; i++)
            {
                if(VolumesDataTable.Rows.Cast<DataRow>().Where(x => x["id"].ToString() == Dt.Rows[i]["id"].ToString()).Count() > 0)
                {
                    Dt.Rows.RemoveAt(i);
                    i--;
                }                
            }

            for (int i = 0; i < VolumesDataTable.Rows.Count; i++)
            {
                if (VolumesDataTable.Rows[i]["syg"].ToString() == syg)
                {
                    if(!Seryjne)
                        Dt.Rows.Add(VolumesDataTable.Rows[i]["TempID"], VolumesDataTable.Rows[i]["id"], VolumesDataTable.Rows[i]["volumin"].ToString() + (!string.IsNullOrEmpty(VolumesDataTable.Rows[i]["rok1"].ToString()) ? " / " + VolumesDataTable.Rows[i]["rok1"].ToString() : "") + (!string.IsNullOrEmpty(VolumesDataTable.Rows[i]["rok2"].ToString()) ? " / " + VolumesDataTable.Rows[i]["rok2"].ToString() : ""), VolumesDataTable.Rows[i]["rok1"].ToString());
                    else
                    {
                        //string Ser = SerNumerTextBox.Text.Trim() + (SerYearTextBox.Text.Trim().Length > 0 && SerYearTextBox.Text.Trim() != "0" ? " / " + SerYearTextBox.Text.Trim() : "");
                        string Ser = VolumesDataTable.Rows[i]["numer_ser"].ToString() + ((VolumesDataTable.Rows[i]["rok_ser"].ToString().Trim().Length > 0 && VolumesDataTable.Rows[i]["rok_ser"].ToString().Trim() != "0") ? " / " + VolumesDataTable.Rows[i]["rok_ser"].ToString().Trim() : "");
                        Dt.Rows.Add(VolumesDataTable.Rows[i]["TempID"], VolumesDataTable.Rows[i]["id"], Ser, VolumesDataTable.Rows[i]["rok_ser"].ToString());
                    }
                }
            }            

            if (Dt.Rows.Count > 0)
            {
                AlphanumComparator<string> Comparer = new AlphanumComparator<string>();

                //if(!Seryjne)
                    Dt = Dt.Rows.Cast<DataRow>().OrderBy(x => x["rok1"].ToString(), Comparer).ThenBy(y => y["volumin"].ToString(), Comparer).CopyToDataTable();


                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    if (Dt.Rows[i]["TempID"] == null)
                    {
                        VolumesDGV.Rows.Add(TempID, Dt.Rows[i]["id"].ToString(), Dt.Rows[i]["volumin"].ToString(), id_cza_Syg);
                        TempID++;
                    }
                    else
                        VolumesDGV.Rows.Add(Dt.Rows[i]["TempID"].ToString(), Dt.Rows[i]["id"].ToString(), Dt.Rows[i]["volumin"].ToString(), id_cza_Syg);
                    
                }

                VolumesDGV.Rows[0].Selected = true;

                ChangeVolumesMode(VolumesModeEnum.None);
            }
            else
                ChangeVolumesMode(VolumesModeEnum.NoActive);

            if (TempVol != null)
            {
                for (int i = 0; i < VolumesDGV.Rows.Count; i++)
                {
                    if (VolumesDGV.Rows[i].Cells["Volumes"].Value.ToString() == TempVol)
                    {
                        VolumesDGV.ClearSelection();
                        VolumesDGV.Rows[i].Selected = true;

                        VolumesDGV.CurrentCell = VolumesDGV["Volumes", i];

                        VolumesDGV.FirstDisplayedScrollingRowIndex = i;
                        break;
                    }
                }
            }
        }
        #endregion

        #region LoadSposobNabycia() - GOOD
        private void LoadSposobNabycia()
        {
            SqlCommand Command = new SqlCommand();

            //start - załadowanie sposobów nabycia
            Command.CommandText = "EXEC ListaSposobNabycia; ";

            DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

            if (!Seryjne)
            {
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
            }
            else
            {
                //seryjne
                SerSposbNabyciaComboBox.DataSource = new BindingSource(Dt, null);
                SerSposbNabyciaComboBox.DisplayMember = "sposob";
                SerSposbNabyciaComboBox.ValueMember = "id";

                if (SerSposbNabyciaComboBox.Items.Count == 0)
                {
                    //seryjne
                    SerSposbNabyciaComboBox.DataSource = null;

                    SerSposbNabyciaComboBox.DataSource = new BindingSource(Dt, null);
                    SerSposbNabyciaComboBox.DisplayMember = "sposob";
                    SerSposbNabyciaComboBox.ValueMember = "id";
                }

                if (SerSposbNabyciaComboBox.Items.Count > 0)
                    SerSposbNabyciaComboBox.SelectedIndex = 0; 
            }                                                           
            //koniec - załadowanie sposobów nabycia
        }
        #endregion

        #region HeightTextBox_TextChanged(object sender, EventArgs e)
        private void HeightTextBox_TextChanged(object sender, EventArgs e)
        {
            // usunięcie znaków innych niż cyfry
            HeightTextBox.Text = string.Join("", HeightTextBox.Text.Where(x => Char.IsDigit(x)).ToArray());
        }
        #endregion

        #region PriceNumericUpDown_ValueChanged(object sender, EventArgs e)
        private void PriceNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            ValueNumericUpDown.Value = PriceNumericUpDown.Value;
        }
        #endregion

        #region ChangeSygState(SygModeEnum Mode)
        private void ChangeSygState(SygModeEnum Mode)
        {
            bool EnabledCtrls;
            CurrentSygMode = Mode;
            SygRTB.ResetText();

            if(Mode == SygModeEnum.Add)
            {
                EnabledCtrls = true;
                CurrentSygTextBox.Clear();
                CurrentSygTextBox.Focus();
            }
            else if (Mode == SygModeEnum.Edit)
            {
                EnabledCtrls = true;
                CurrentSygTextBox.Focus();
            }
            else
            {
                EnabledCtrls = false;

                if (SygsDGV.SelectedRows.Count > 0)
                    CurrentSygTextBox.Text = SygsDGV.SelectedRows[0].Cells["Sygnatura"].Value.ToString();
            }

            NewSygButton.Enabled = !EnabledCtrls && !Settings.ReadOnlyMode;            

            EditSygButton.Enabled = !EnabledCtrls && !Settings.ReadOnlyMode;
            DeleteSygButton.Enabled = !EnabledCtrls;

            SaveSygButton.Visible = EnabledCtrls;
            CancelSygButton.Visible = EnabledCtrls;

            CurrentSygTextBox.ReadOnly = !EnabledCtrls;

            if ((SygsDGV.SelectedRows.Count == 0 || (SygsDGV.SelectedRows.Count > 0 && SygsDGV.SelectedRows[0].Index < 0)))
            {
                EditSygButton.Enabled = false;
                DeleteSygButton.Enabled = false;
            }

            if (Mode != SygModeEnum.None)
            {
                NewVoluminButton.Enabled = false;
                EditVoluminButton.Enabled = false;
                DeleteVoluminButton.Enabled = false;
            }
            else
            {
                ChangeVolumesMode(VolumesModeEnum.None);
            }
        }
        #endregion

        #region KeyTextBox_TextChanged(object sender, EventArgs e)
        private void KeyTextBox_TextChanged(object sender, EventArgs e)
        {
            /*if (KeyTextBox.Text.Trim().Length > 0)
                keySuggest(KeyTextBox.Text);*/
        }
        #endregion

        private void keySuggest(string text)
        {
            SqlCommand command = new SqlCommand();
            command.CommandText = "EXEC SlowaKluczowePodpowiedz @text, @id_rodzaj, 2; ";
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

        #region NewSygButton_Click(object sender, EventArgs e)
        private void NewSygButton_Click(object sender, EventArgs e)
        {            
            ChangeSygState(SygModeEnum.Add);
        }
        #endregion

        #region EditSygButton_Click(object sender, EventArgs e)
        private void EditSygButton_Click(object sender, EventArgs e)
        {
            ChangeSygState(SygModeEnum.Edit);
        }
        #endregion

        #region SaveSygButton_Click(object sender, EventArgs e)
        private void SaveSygButton_Click(object sender, EventArgs e)
        {
            if (CurrentSygTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("signature_cannot_be_blank", "Sygnatura nie może być pusta!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Popraw dane"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CurrentSygTextBox.Select();
                return;
            }

            if(SaveSyg())
                ChangeSygState(SygModeEnum.None);            
        }
        #endregion

        #region CancelSygButton_Click(object sender, EventArgs e)
        private void CancelSygButton_Click(object sender, EventArgs e)
        {
            CurrentSygTextBox.Text = "";
            ChangeSygState(SygModeEnum.None);
        }
        #endregion

        #region SaveSyg()
        private bool SaveSyg()
        {
            string id_cza_syg;
            string TempIDTemp;

            if (CurrentSygMode == SygModeEnum.Add)
            {
                id_cza_syg = "-1";

                TempIDTemp = TempID.ToString();
            }
            else
            {
                id_cza_syg = SygsDGV.SelectedRows[0].Cells["id_cza_syg"].Value.ToString();

                TempIDTemp = SygsDGV.SelectedRows[0].Cells["TempIDDGV"].Value.ToString();
            }

            if (CurrentSygTextBox.TextLength > 0)
            {
                for (int i = 0; i < SygDataTable.Rows.Count; i++)
                {
                    if (SygDataTable.Rows[i]["syg"].ToString() == CurrentSygTextBox.Text.Trim() && SygDataTable.Rows[i]["tempID"].ToString() != TempIDTemp)
                    {
                        MessageBox.Show(_translationsDictionary.getStringFromDictionary("signature_exists", "Podana sygnatura już istnieje!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Popraw dane"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CurrentSygTextBox.Select();
                        return false;
                    }
                }

                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Czasop_CheckSigExists @syg, @id_cza_syg;";
                Command.Parameters.AddWithValue("@syg", CurrentSygTextBox.Text.Trim());
                Command.Parameters.AddWithValue("@id_cza_syg", id_cza_syg);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0][0].ToString() == "1")
                    {
                        MessageBox.Show(_translationsDictionary.getStringFromDictionary("signature_exists", "Podana sygnatura już istnieje!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Popraw dane"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        CurrentSygTextBox.Select();
                        return false;
                    }
                }
            }
            
            int RowNumber = -1;
            string OldSygnatura = "";
            string syg = CurrentSygTextBox.Text.Trim();

            if (CurrentSygMode == SygModeEnum.Add)
            {
                //id_sygnat = "-1";

                //TempIDTemp = TempID.ToString();

                RowNumber = SygsDGV.Rows.Add(TempIDTemp, -1, CurrentSygTextBox.Text.Trim(), OldSygnatura);                
            }
            else
            {
                OldSygnatura = SygsDGV.SelectedRows[0].Cells["Sygnatura"].Value.ToString();
                id_cza_syg = SygsDGV.SelectedRows[0].Cells["id_cza_syg"].Value.ToString();
                SygsDGV.SelectedRows[0].Cells["Sygnatura"].Value = CurrentSygTextBox.Text.Trim();
                SygsDGV.SelectedRows[0].Cells["oldSyg"].Value = OldSygnatura;

                for (int i = 0; i < SygDataTable.Rows.Count; i++)
                {
                    if (SygsDGV.SelectedRows[0].Cells["TempIDDGV"].Value.ToString() == SygDataTable.Rows[i]["tempID"].ToString())
                    {
                        SygDataTable.Rows.RemoveAt(i);
                        break;
                    }
                }

                //TempIDTemp = SygDGV.SelectedRows[0].Cells["TempIDDGV"].Value.ToString();
            }

            SygDataTable.Rows.Add(new object[] { TempIDTemp, id_cza_syg, syg, OldSygnatura});            

            TempID++;

            if (RowNumber != -1)
            {
                SygsDGV.ClearSelection();
                SygsDGV.Rows[RowNumber].Selected = true;
                SygsDGV.CurrentCell = SygsDGV["Sygnatura", RowNumber];
                SygsDGV.FirstDisplayedScrollingRowIndex = RowNumber;
            }
            lEdit = true;
            return true;
        }
        #endregion

        #region TitleChangesCheckBox_Click(object sender, EventArgs e)
        private void TitleChangesCheckBox_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MagazineID))
            {
                if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("to_use_this_feature_you_must_save_magazine", "Aby użyć tej funkcji, należy zapisać czasopismo. Chcesz zapisać?"), _translationsDictionary.getStringFromDictionary("data_save", "Zapisywanie"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!Save(true))
                    {
                        TitleChangesCheckBox.Checked = !TitleChangesCheckBox.Checked;
                        return;
                    }
                }
                else
                {
                    TitleChangesCheckBox.Checked = !TitleChangesCheckBox.Checked;
                    return;
                }
            }            

            ChangeTitleForm CTF = new ChangeTitleForm(MagazineID, Settings.ID_rodzaj, this.Seryjne, Settings.ReadOnlyMode);
            CTF.ShowDialog();

            LoadData(this.MagazineID);
        }
        #endregion

        #region ChangeVolumesMode(VolumesModeEnum Mode)
        private void ChangeVolumesMode(VolumesModeEnum Mode)
        {
            //TempDodatki = new DataTable();

            bool EnabledCtrls;
            CurrentVolumesMode = Mode;

            //if (Mode == VolumesModeEnum.Add) SposobNabyciaComboBox.Text = "KUPNO";

            if (Mode == VolumesModeEnum.Add)
            {
                EnabledCtrls = true;
                
                ClearVolumesControls();                
            }
            else if (Mode == VolumesModeEnum.Edit)
            {
                EnabledCtrls = true;                
            }
            else if (Mode == VolumesModeEnum.NoActive)
            {
                EnabledCtrls = false;

                NewVoluminButton.Visible = EnabledCtrls;
                EditVoluminButton.Visible = EnabledCtrls;
                DeleteVoluminButton.Visible = EnabledCtrls;
                ExtrasButton.Visible = EnabledCtrls;
                ExtrasLabel.Visible = EnabledCtrls;
            }
            else
            {
                EnabledCtrls = false;

                NewVoluminButton.Visible = !EnabledCtrls;
                EditVoluminButton.Visible = !EnabledCtrls;
                DeleteVoluminButton.Visible = !EnabledCtrls;
                ExtrasButton.Visible = !EnabledCtrls;
                ExtrasLabel.Visible = !EnabledCtrls;
            }

            NewVoluminButton.Enabled = !EnabledCtrls && !Settings.ReadOnlyMode && SygsDGV.SelectedRows.Count > 0;
            EditVoluminButton.Enabled = !EnabledCtrls && !Settings.ReadOnlyMode;
            DeleteVoluminButton.Enabled = !EnabledCtrls;            

            SaveVoluminButton.Visible = EnabledCtrls;
            CancelVoluminButton.Visible = EnabledCtrls;
            VolumesDGV.Enabled = !EnabledCtrls;

            //ExtrasButton.Enabled = EnabledCtrls;

            NewSygButton.Enabled = !EnabledCtrls && !Settings.ReadOnlyMode;
            EditSygButton.Enabled = !EnabledCtrls && !Settings.ReadOnlyMode && SygsDGV.SelectedRows.Count > 0;
            DeleteSygButton.Enabled = !EnabledCtrls && SygsDGV.SelectedRows.Count > 0;
            SygsDGV.Enabled = !EnabledCtrls;

            PrintButton.Enabled = !EnabledCtrls;
            SaveButton.Enabled = !EnabledCtrls;
            SearchButton.Enabled = !EnabledCtrls;
            SourcesButton.Enabled = !EnabledCtrls;
            ExitButton.Enabled = !EnabledCtrls;

            if ((VolumesDGV.SelectedRows.Count == 0 || (VolumesDGV.SelectedRows.Count > 0 && VolumesDGV.SelectedRows[0].Index < 0)))
            {
                EditVoluminButton.Enabled = false;
                DeleteVoluminButton.Enabled = false;                
            }

            ExtrasButton.Enabled = VolumesDGV.SelectedRows.Count > 0;

            LockVolumes(EnabledCtrls);            
        }
        #endregion

        #region ClearVolumesControls()
        private void ClearVolumesControls()
        {
            if (Seryjne)
            {
                // ewidencja seryjna
                SerNumerTextBox.Text = "";
                SerYearTextBox.Text = DateTime.Now.Year.ToString();
                SerNextNumerTextBox.Text = "";

                SerTitleTextBox.Text = "";
                SerAutorTextBox.Text = "";
                SerAutor2TextBox.Text = "";
                SerAutor3TextBox.Text = "";

                SerNumInwTextBox.Text = "";
                SerSposbNabyciaComboBox.SelectedValue = 2;
                SerValueNumericUpDown.Value = 0;
                StronyTextBox.Text = "";
                SerCommentsTextBox.Text = "";
            }
            else
            {
                // ewidencja
                YearTextBox.Text = DateTime.Now.Year.ToString();
                Year2TextBox.Text = "";
                WoluminTextBox.Text = "";
                NumbersTextBox.Text = "";
                CommentsVolumesTextBox.Text = "";
                SposobNabyciaComboBox.SelectedValue = 1;

                NumInwTextBox.Text = "";
                PriceNumericUpDown.Value = 0;
                ValueNumericUpDown.Value = 0;
                DateDTP.Value = DateTime.Now;
            }
        }
        #endregion

        #region LockVolumes(bool EnabledCtrl)
        private void LockVolumes(bool EnabledCtrl)
        {
            if (Seryjne)
            {
                // ewidencja seryjna
                SerNumerTextBox.ReadOnly = !EnabledCtrl;
                SerYearTextBox.ReadOnly = !EnabledCtrl;
                SerNextNumerTextBox.ReadOnly = !EnabledCtrl;

                SerTitleTextBox.ReadOnly = !EnabledCtrl;
                SerAutorTextBox.ReadOnly = !EnabledCtrl;
                SerAutor2TextBox.ReadOnly = !EnabledCtrl;
                SerAutor3TextBox.ReadOnly = !EnabledCtrl;

                SerNumInwTextBox.ReadOnly = !EnabledCtrl;
                SerSposbNabyciaComboBox.Enabled = EnabledCtrl;
                SerValueNumericUpDown.ReadOnly = !EnabledCtrl;
                SerValueNumericUpDown.Enabled = EnabledCtrl;
                StronyTextBox.ReadOnly = !EnabledCtrl;
                SerCommentsTextBox.ReadOnly = !EnabledCtrl;
            }
            else
            {
                // ewidencja
                YearTextBox.ReadOnly = !EnabledCtrl;
                Year2TextBox.ReadOnly = !EnabledCtrl;
                WoluminTextBox.ReadOnly = !EnabledCtrl;

                if(FreqInAkcesja != -1)
                    NumbersTextBox.ReadOnly = true;
                else
                    NumbersTextBox.ReadOnly = !EnabledCtrl;

                CommentsVolumesTextBox.ReadOnly = !EnabledCtrl;
                SposobNabyciaComboBox.Enabled = EnabledCtrl;

                NumInwTextBox.ReadOnly = !EnabledCtrl;
                PriceNumericUpDown.ReadOnly = !EnabledCtrl;
                PriceNumericUpDown.Enabled = EnabledCtrl;
                ValueNumericUpDown.ReadOnly = !EnabledCtrl;
                ValueNumericUpDown.Enabled = EnabledCtrl;
                DateDTP.Enabled = EnabledCtrl;
            }
        }
        #endregion

        #region NewVoluminButton_Click(object sender, EventArgs e)
        private void NewVoluminButton_Click(object sender, EventArgs e)
        {
            ChangeVolumesMode(VolumesModeEnum.Add);
        }
        #endregion

        #region EditVoluminButton_Click(object sender, EventArgs e)
        private void EditVoluminButton_Click(object sender, EventArgs e)
        {
            ChangeVolumesMode(VolumesModeEnum.Edit);
        }
        #endregion

        #region DeleteVoluminButton_Click(object sender, EventArgs e)
        private void DeleteVoluminButton_Click(object sender, EventArgs e)
        {
            if (VolumesDGV.SelectedRows[0].Cells["idVolumesDGV"].Value.ToString() == "-1")
            {
                for (int i = 0; i < VolumesDataTable.Rows.Count; i++)
                {
                    if (VolumesDataTable.Rows[i]["TempID"].ToString() == VolumesDGV.SelectedRows[0].Cells["tempIDVolumes"].Value.ToString())
                    {
                        VolumesDataTable.Rows.RemoveAt(i);
                        break;
                    }
                }

                VolumesDGV.Rows.RemoveAt(VolumesDGV.SelectedRows[0].Index);
            }
            else if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_volume", "Czy chcesz usunąć ten wolumin?"), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (FreqInAkcesja != -1)
                {
                    DataTable Dt = Settings.IsNumberBorrowed(VolumesDGV.SelectedRows[0].Cells["idVolumesDGV"].Value.ToString(), 2);

                    if (Dt.Rows.Count > 0)
                    {
                        string message = string.Format("{0} {1} {2}", _translationsDictionary.ContainsKey("there_are_borrowed_copies_in_quantities") ? _translationsDictionary["there_are_borrowed_copies_in_quantities"] : "Istnieją wypożyczone egzemplarze w ilości:", Dt.Rows.Count, _translationsDictionary.ContainsKey("do_you_want_to_return_it") ? _translationsDictionary["do_you_want_to_return_it"] : "Czy chcesz je zwrócić?");

//                        if (MessageBox.Show(string.Format("Istnieją wypożyczone egzemplarze w ilości: {0}. Czy chcesz je zwrócić?", Dt.Rows.Count), "Zwracanie numerów", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        if (MessageBox.Show(message, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int i = 1;
                            bool check = true;

                            foreach (DataRow row in Dt.Rows)
                            {
                                ZwrotForm zwrot = new ZwrotForm(row["wypoz_id"].ToString(), Settings.employeeID, null);
                                zwrot.Text += string.Format(" {0} z {1}", i, Dt.Rows.Count);

                                if (zwrot.ShowDialog() == DialogResult.Cancel)
                                    check = false;

                                i++;
                            }

                            if (!check)
                               return;
                        }
                        else
                            return;
                    }
                }

                DialogResult Dr = MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_volume_with_entry_to_lossess", "Czy usunąć wolumin z wpisem do księgi ubytków?"), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (Dr == DialogResult.Yes)
                {
                    if (!Seryjne)
                    {                        
                        SingleUbytkowanieForm SUF = new SingleUbytkowanieForm(VolumesDGV.SelectedRows[0].Cells["idVolumesDGV"].Value.ToString(), this.MagazineID, CurrentSygTextBox.Text.Trim(), TitleTextBox.Text.Trim(), Seryjne);
                        
                        if(SUF.ShowDialog() == DialogResult.OK)
                            VolumesDGV.Rows.RemoveAt(VolumesDGV.SelectedRows[0].Index);
                    }
                    else
                    {
                        SingleUbytkowanieForm SUF = new SingleUbytkowanieForm(VolumesDGV.SelectedRows[0].Cells["idVolumesDGV"].Value.ToString(), this.MagazineID, CurrentSygTextBox.Text.Trim(), TitleTextBox.Text.Trim(), Seryjne);

                        if (SUF.ShowDialog() == DialogResult.OK)
                            VolumesDGV.Rows.RemoveAt(VolumesDGV.SelectedRows[0].Index);
                    }
                }
                else if (Dr == DialogResult.No)
                {
                    DeleteVolumin(VolumesDGV.SelectedRows[0].Cells["idVolumesDGV"].Value.ToString(), Seryjne);
                }
            }

            ChangeVolumesMode(VolumesModeEnum.None);
        }
        #endregion       

        #region DeleteVolumin(string id_volumes, bool Seryjne = false)
        private void DeleteVolumin(string id_volumes, bool Seryjne = false)
        {                          
            SqlCommand Command = new SqlCommand();

            if(!Seryjne)
                Command.CommandText = "Czasop_DeleteVolumin @id_volumes; ";
            else
                Command.CommandText = "Czasop_SeryjneDelete @id_volumes; ";                
            
            Command.Parameters.AddWithValue("@id_volumes", id_volumes);

            if (CommonFunctions.WriteData(Command, ref Settings.Connection))
            {
                VolumesDGV.Rows.RemoveAt(VolumesDGV.SelectedRows[0].Index);
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("volume_removed", "Wolumin pomyślnie usunięto!"), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region SaveVoluminButton_Click(object sender, EventArgs e)
        private void SaveVoluminButton_Click(object sender, EventArgs e)
        {
            if (!Seryjne && YearTextBox.TextLength == 0)
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("year_cannot_be_blank", "Rok nie może być pusty!"), _translationsDictionary.getStringFromDictionary("to_correct_data", "Popraw dane"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(SaveVolumes())
                ChangeVolumesMode(VolumesModeEnum.None);
        }
        #endregion

        #region CancelVoluminButton_Click(object sender, EventArgs e)
        private void CancelVoluminButton_Click(object sender, EventArgs e)
        {
            if (VolumesDGV.SelectedRows.Count > 0)
            {
                int idx = VolumesDGV.SelectedRows[0].Index;
                VolumesDGV.ClearSelection();
                VolumesDGV.Rows[idx].Selected = true;
            }
            else
                ClearVolumesControls();

            ChangeVolumesMode(VolumesModeEnum.None);
        }
        #endregion

        #region SygsDGV_SelectionChanged(object sender, EventArgs e)
        private void SygsDGV_SelectionChanged(object sender, EventArgs e)
        {
            /*if (SygsDGV.SelectedRows.Count == 0 || (SygsDGV.SelectedRows.Count > 0 && SygsDGV.SelectedRows[0].Index < 0) || Settings.ReadOnlyMode)
            {
                EditSygButton.Enabled = false;
                DeleteSygButton.Enabled = false;
            }
            else
            {
                EditSygButton.Enabled = true;
                DeleteSygButton.Enabled = true;                
            }*/
//            ExtrasLabel.Text = "Dodatki (0)";
            ExtrasLabel.Text = string.Format("{0} ({1})", _translationsDictionary.getStringFromDictionary("supplements", "Dodatki"), 0);

            ChangeSygState(CurrentSygMode);

            if (SygsDGV.SelectedRows.Count > 0)// &&  CurrentModeEnum != ModeEnum.Add)
            {
                CurrentSygTextBox.Text = SygsDGV.SelectedRows[0].Cells["Sygnatura"].Value.ToString();

                //if (CurrentModeEnum != ModeEnum.Add)
                LoadVolumes(MagazineID, SygsDGV.SelectedRows[0].Cells[id_cza_syg.Name].Value.ToString(), SygsDGV.SelectedRows[0].Cells["Sygnatura"].Value.ToString());                
            }

            if (SygsDGV.Rows.Count > 0)
                ChangeVolumesMode(VolumesModeEnum.None);
            else
                ChangeVolumesMode(VolumesModeEnum.NoActive);            
        }
        #endregion

        #region FillVolumesControls(DataRow Dr)
        private void FillVolumesControls(DataRow Dr)
        {
            if (Dr != null)
            {
                if (Seryjne)
                {
                    // ewidencja seryjna
                    SerNumerTextBox.Text = Dr["numer_ser"].ToString();
                    SerYearTextBox.Text = Dr["rok_ser"].ToString();
                    SerNextNumerTextBox.Text = Dr["nr_kol_ser"].ToString();

                    SerTitleTextBox.Text = Dr["tytul_ser"].ToString();
                    SerAutorTextBox.Text = Dr["autor1_ser"].ToString();
                    SerAutor2TextBox.Text = Dr["autor2_ser"].ToString();
                    SerAutor3TextBox.Text = Dr["autor3_ser"].ToString();

                    SerNumInwTextBox.Text = Dr["numer_inw"].ToString();
                    SerSposbNabyciaComboBox.SelectedValue = Dr["nab"];
                    SerValueNumericUpDown.Value = decimal.Parse(Dr["wart_ser"].ToString());
                    StronyTextBox.Text = Dr["strony_ser"].ToString();
                    SerCommentsTextBox.Text = Dr["uwagi_s"].ToString();
                }
                else
                {
                    // ewidencja
//                    ExtrasLabel.Text = "Dodatki (" + Dr["ilosc_dodatki"].ToString() + ")";
                    ExtrasLabel.Text = string.Format("{0} ({1})", _translationsDictionary.getStringFromDictionary("supplements", "Dodatki"), Dr["ilosc_dodatki"]);
                    YearTextBox.Text = Dr["rok1"].ToString();
                    Year2TextBox.Text = Dr["rok2"].ToString();
                    WoluminTextBox.Text = Dr["volumin"].ToString();
                    NumbersTextBox.Text = Dr["czesci"].ToString();
                    CommentsVolumesTextBox.Text = Dr["uwagi_v"].ToString();
                    SposobNabyciaComboBox.SelectedValue = Dr["nab"].ToString();

                    NumInwTextBox.Text = Dr["numer_inw"].ToString();
                    PriceNumericUpDown.Value = decimal.Parse(Dr["rocz_pren"].ToString());
                    ValueNumericUpDown.Value = decimal.Parse(Dr["wart_vol"].ToString());

                    DateDTP.Value = DBDateT2(Dr["data_biez"]);
                    /*
                    if (!string.IsNullOrEmpty(Dr["data_biez"].ToString()) && Dr["data_biez"].ToString().Contains('-'))
                        DateDTP.Value = DateTime.Parse(Dr["data_biez"].ToString());
                    else
                        DateDTP.Value = DateTime.ParseExact(Dr["data_biez"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                    */
                }
            }
        }
        #endregion

        #region DeleteSygButton_Click(object sender, EventArgs e)
        private void DeleteSygButton_Click(object sender, EventArgs e)
        {
            if (VolumesDGV.Rows.Count > 0)
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("first_delete_all_volumes", "Proszę najpierw usunąć wszystkie woluminy!"), _translationsDictionary.getStringFromDictionary("", "Usuwanie sygnatury"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (SygsDGV.SelectedRows.Count > 0)
            {
                if(SygsDGV.SelectedRows[0].Cells["id_cza_syg"].Value.ToString() == "-1")
                {
                    for (int i = 0; i < SygDataTable.Rows.Count; i++)
                    {
                        if (SygDataTable.Rows[i]["TempID"].ToString() == SygsDGV.SelectedRows[0].Cells["tempIDDGV"].Value.ToString())
                        {
                            SygDataTable.Rows.RemoveAt(i);
                            break;
                        }
                    }

                    SygsDGV.Rows.RemoveAt(SygsDGV.SelectedRows[0].Index);
                    CurrentSygTextBox.ResetText();
                }
                else if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_signature", "Usunąć sygnaturę z listy?"), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {                    
                    SqlCommand Command = new SqlCommand();
                    Command.CommandText += "EXEC Czasop_DeleteSygs @deleteSyg; ";
                    Command.Parameters.AddWithValue("@deleteSyg", SygsDGV.SelectedRows[0].Cells["id_cza_syg"].Value.ToString());

                    if (CommonFunctions.WriteData(Command, ref Settings.Connection))
                    {
                        MessageBox.Show(_translationsDictionary.getStringFromDictionary("signature_removed", "Sygnatura została usunięta!"), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SygsDGV.Rows.RemoveAt(SygsDGV.SelectedRows[0].Index);
                        CurrentSygTextBox.ResetText();
                        //SygsToDelete.Add(SygsDGV.SelectedRows[0].Cells["id_cza_syg"].Value.ToString());
                    }
                }                
            }

            ChangeSygState(SygModeEnum.None);
        }
        #endregion

        #region VolumesDGV_SelectionChanged(object sender, EventArgs e)
        private void VolumesDGV_SelectionChanged(object sender, EventArgs e)
        {            
            //if(CurrentModeEnum != ModeEnum.Add)
                FillVolumesControls(FetchFillVolumes());
            
            //ExtrasButton.Enabled = VolumesDGV.SelectedRows.Count > 0;
        }
        #endregion

        #region FetchFillVolumes()
        private DataRow FetchFillVolumes()
        {
            DataTable Dt = new DataTable();
            DataRow Dr = null;

            try
            {
                int RowNumber = -1;

                for (int i = 0; i < VolumesDataTable.Rows.Count; i++)
                {
                    if (VolumesDGV.SelectedRows.Count > 0 && VolumesDGV.SelectedRows[0].Cells["tempIDVolumes"].Value.ToString() == VolumesDataTable.Rows[i]["tempID"].ToString())
                    {
                        RowNumber = i;
                        break;
                    }
                }

                if (RowNumber != -1)
                {
                    Dr = VolumesDataTable.Rows[RowNumber];
                    TempDodatki = VolumesDataTable.Rows[RowNumber]["dodatki"] as DataTable;
                }
                else if (VolumesDGV.SelectedRows.Count > 0 && CurrentModeEnum != ModeEnum.Add)
                //if (SygDGV.SelectedRows[0].Cells["id_sygnat"].Value.ToString() != "-1")
                {
                    SqlCommand Command = new SqlCommand();
                    if (!Seryjne)
                    {
                        Command.CommandText = "EXEC Czasop_VolumesSelectFill @id;";
                        Command.Parameters.AddWithValue("@id", VolumesDGV.SelectedRows[0].Cells["idVolumesDGV"].Value.ToString());                    
                    }
                    else
                    { 
                        Command.CommandText = "EXEC Czasop_SeryjneSelectFill @id;";
                        Command.Parameters.AddWithValue("@id", VolumesDGV.SelectedRows[0].Cells["idVolumesDGV"].Value.ToString());     
                    }                   

                    Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                    if (Dt.Rows.Count > 0)
                        Dr = Dt.Rows[0];

                    TempDodatki.Clear();
                }
                else
                    ClearVolumesControls();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            
            return Dr;
        }
        #endregion

        #region ExitButton_Click(object sender, EventArgs e)
        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        
        #region SourcesButton_Click(object sender, EventArgs e)
        private void SourcesButton_Click(object sender, EventArgs e)
        {
            //_dirtyTracker.Dump();
            if (string.IsNullOrEmpty(MagazineID))
            {
                if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("if_you_want_to_add_sources_save_article", "Aby dodać źródła należy zapisać artykuł. Chcesz zapisać?"), _translationsDictionary.getStringFromDictionary("data_save", "Zapisywanie"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (!Save(true))
                        return;
                }
                else
                    return;
            }

            //if (Settings.ReadOnlyMode)
            if (Settings.ReadOnlyMode)
            {
                Zrodla.SourceForm SF = new Zrodla.SourceForm(Int32.Parse(MagazineID), 2, Settings.ID_rodzaj, true);
                SF.ShowDialog();
            }
            else
            {
                Zrodla.SourceForm SF = new Zrodla.SourceForm(Int32.Parse(MagazineID), 2, Settings.ID_rodzaj);
                SF.ShowDialog();
            }
        }
        #endregion

        private bool Save(bool NoMessage = false)
        {
            if (TitleTextBox.Text.Trim().Length == 0)
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("enter_magazine_title", "Proszę podać tytuł czasopisma."), _translationsDictionary.getStringFromDictionary("to_correct_data", "Uzupełnienie danych"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            lEdit = lEdit || CurrentModeEnum == ModeEnum.Add || _dirtyTracker.IsDirty;
            if (!lEdit) return true;


            SqlCommand Command = new SqlCommand();

            SqlParameter PublisherParameter = new SqlParameter();
            PublisherParameter.ParameterName = "@PublisherID";
            PublisherParameter.Value = DBNull.Value;
            PublisherParameter.SqlDbType = SqlDbType.Int;
            PublisherParameter.Direction = ParameterDirection.InputOutput;

            // dodanie wydawcy
            if (string.IsNullOrEmpty(PublisherID) && Publisher != null)
            {
                //{FullNameTextBox.Text, ShortTextBox.Text, PlaceTextBox.Text, AddressTextBox.Text, ContactTextBox.Text, CountryTextBox.Text };

                Command.CommandText = "EXEC Czasop_AddPublisher @p_nazwa_w, @p_sk_nazwa_w, @p_id_panst_w, @p_miasto_w, @p_kontakt_w, @p_adres_w, @p_id_rodzaj, @PublisherID OUTPUT; ";
                Command.Parameters.AddWithValue("@p_nazwa_w", Publisher[0]);
                Command.Parameters.AddWithValue("@p_sk_nazwa_w", Publisher[1]);
                Command.Parameters.AddWithValue("@p_id_panst_w", Publisher[5]);
                Command.Parameters.AddWithValue("@p_miasto_w", Publisher[2]);
                Command.Parameters.AddWithValue("@p_kontakt_w", Publisher[4]);
                Command.Parameters.AddWithValue("@p_adres_w", Publisher[3]);
                Command.Parameters.Add(PublisherParameter);
                //Command.Parameters.AddWithValue("@p_id_rodzaj", Settings.ID_rodzaj);
            }

            SqlParameter KolporterParameter = new SqlParameter();
            KolporterParameter.ParameterName = "@KolporterID";
            KolporterParameter.Value = DBNull.Value;
            KolporterParameter.SqlDbType = SqlDbType.Int;
            KolporterParameter.Direction = ParameterDirection.InputOutput;

            // dodanie dostawcy
            if(string.IsNullOrEmpty(KolporterID) && Kolporter != null)
            {
                //{ NameTextBox.Text.Trim(), ShortTextBox.Text.Trim(), AddressTextBox.Text.Trim(), PlaceTextBox.Text.Trim(), ZipTextBox.Text.Trim(), CountryTextBox.Text.Trim(), PhoneTextBox.Text.Trim(), Phone2TextBox.Text.Trim(), FaxTextBox.Text.Trim() };

                Command.CommandText += "EXEC Czasop_AddDistributor @p_nazwa_k, @p_sk_nazwa_k, @p_id_panst_k, @p_kod_k, @p_miasto_k, @p_adres_k, @p_telefon_k, @p_telefon2_k, @p_fax_k, @KolporterID OUTPUT; ";
                Command.Parameters.AddWithValue("@p_nazwa_k", Kolporter[0]);
                Command.Parameters.AddWithValue("@p_sk_nazwa_k", Kolporter[1]);
                Command.Parameters.AddWithValue("@p_id_panst_k", Kolporter[5]);
                Command.Parameters.AddWithValue("@p_kod_k", Kolporter[4]);
                Command.Parameters.AddWithValue("@p_miasto_k", Kolporter[3]);
                Command.Parameters.AddWithValue("@p_adres_k", Kolporter[2]);
                Command.Parameters.AddWithValue("@p_telefon_k", Kolporter[6]);
                Command.Parameters.AddWithValue("@p_telefon2_k", Kolporter[7]);
                Command.Parameters.AddWithValue("@p_fax_k", Kolporter[8]);
                Command.Parameters.Add(KolporterParameter);
            }

            SqlParameter MagazineIDParameter = new SqlParameter();
            MagazineIDParameter.ParameterName = "@MagazineID";
            MagazineIDParameter.SqlDbType = SqlDbType.Int;
            MagazineIDParameter.Direction = ParameterDirection.InputOutput;

            Command.Parameters.Add(MagazineIDParameter);

            // dodanie czasopisma
            Command.CommandText += "EXEC Czasop_ModifyMagazine @p_seryjne, @p_tytul, @p_podtytul, @p_nazwa_inst, @p_siedziba, @p_issn, @PublisherID, @KolporterID, @p_id_czest, @p_uwagi, @p_redaktor, @p_wysokosc, @p_t_rownol, @p_t_dodatk, @p_kraj_w, @p_zawartosc, @jezyk1, @jezyk2, @jezyk3, @p_id_rodzaj, @p_mode, @MagazineID OUTPUT; ";
            Command.Parameters.AddWithValue("@p_seryjne", Seryjne);
            Command.Parameters.AddWithValue("@p_tytul", TitleTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@p_podtytul", SubtitleTextBox.Text.Trim());            
            Command.Parameters.AddWithValue("@p_nazwa_inst", InstitutionTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@p_siedziba", PlaceTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@p_issn", ISSNTextBox.Text.Trim());

            if (!string.IsNullOrEmpty(PublisherID))
                Command.Parameters.AddWithValue("@PublisherID", PublisherID);
            else if (Publisher == null)
                Command.Parameters.AddWithValue("@PublisherID", DBNull.Value);

            if (!string.IsNullOrEmpty(KolporterID))
                Command.Parameters.AddWithValue("@KolporterID", KolporterID);
            else if (Kolporter == null)
                Command.Parameters.AddWithValue("@KolporterID", DBNull.Value);

            Command.Parameters.AddWithValue("@p_id_czest", FreqComboBox.SelectedValue);
            Command.Parameters.AddWithValue("@p_uwagi", CommentsRichTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@p_redaktor", RedaktorTextBox.Text.Trim());            

            Command.Parameters.AddWithValue("@p_wysokosc", HeightTextBox.Text.Trim().Length > 0 ? HeightTextBox.Text.Trim() : "0");

            Command.Parameters.AddWithValue("@p_t_rownol", ParallelTitleTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@p_t_dodatk", AdditionTitleTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@p_kraj_w", CountryTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@p_zawartosc", FormAndContentComboBox.SelectedValue);
            Command.Parameters.AddWithValue("@jezyk1", LangTextBox.Text.Trim());
            Command.Parameters.AddWithValue("@jezyk2", Lang2TextBox.Text.Trim());
            Command.Parameters.AddWithValue("@jezyk3", Lang3TextBox.Text.Trim());
            Command.Parameters.AddWithValue("@p_id_rodzaj", Settings.ID_rodzaj);
           
            if(CurrentModeEnum == ModeEnum.Add)
            {
                MagazineIDParameter.SqlValue = DBNull.Value;
                Command.Parameters.AddWithValue("@p_mode", 1);
            }
            else
            { 
                MagazineIDParameter.SqlValue = MagazineID;                
                Command.Parameters.AddWithValue("@p_mode", 2);
            }

            Command.CommandText += "EXEC Czasop_UpdateAkcesja @MagazineID, @p_id_czest; ";

            // usunięcie kluczy
            for (int i = 0; i < KeysToDelete.Count; i++)
            {
                Command.CommandText += "EXEC Czasop_DeleteKeyFromMagazine @MagazineID, @DeleteKeyID" + i + "; ";
                Command.Parameters.AddWithValue("@DeleteKeyID" + i, KeysToDelete[i]);
            }

            // dodanie kluczy
            for (int i = 0; i < KeysDataGridView.Rows.Count; i++)
            {
                if (KeysDataGridView.Rows[i].Cells["id"].Value.ToString() == "-1")
                {
                    Command.CommandText += "EXEC Czasop_AddKeyToMagazine @MagazineID, @KeyID" + i + ", @KeyName" + i + ", @NewKey" + i + ", @p_id_rodzaj;";
                    Command.Parameters.AddWithValue("@KeyID" + i, KeysDataGridView.Rows[i].Cells["id"].Value.ToString());
                    Command.Parameters.AddWithValue("@KeyName" + i, KeysDataGridView.Rows[i].Cells["Key"].Value.ToString());
                    Command.Parameters.AddWithValue("@NewKey" + i, 1);
                }
                else
                {
                    Command.CommandText += "EXEC Czasop_AddKeyToMagazine @MagazineID, @KeyID" + i + ", @KeyName" + i + ", @NewKey" + i + ", @p_id_rodzaj;";
                    Command.Parameters.AddWithValue("@KeyID" + i, KeysDataGridView.Rows[i].Cells["id"].Value.ToString());
                    Command.Parameters.AddWithValue("@KeyName" + i, "");
                    Command.Parameters.AddWithValue("@NewKey" + i, 0);
                }
            }

            SqlParameter[] SygParameters = new SqlParameter[SygDataTable.Rows.Count];

            // zapis sygnatur
            for (int i = 0; i < SygDataTable.Rows.Count; i++)
            {
                //SygDataTable.Rows.Add(new object[] { TempIDTemp, id_cza_syg, CurrentSygTextBox.Text.Trim(), OldSygnatura});
                
                SygParameters[i] = new SqlParameter();
                SygParameters[i].ParameterName = "@id_cza_syg_" + i;
                SygParameters[i].Value = DBNull.Value;
                SygParameters[i].SqlDbType = SqlDbType.Int;
                SygParameters[i].Direction = ParameterDirection.InputOutput;                

                // dodaniej nowe sygnatury
                if (SygDataTable.Rows[i]["id_cza_syg"].ToString() == "-1")
                {
                    Command.CommandText += "EXEC Czasop_AddSignature @MagazineID, @NewSyg" + i + ", @p_seryjne, @id_cza_syg_" + i + " OUTPUT; ";
                    Command.Parameters.AddWithValue("@NewSyg" + i, SygDataTable.Rows[i]["syg"].ToString());
                    Command.Parameters.Add(SygParameters[i]);
                }
                // edycja sygnatury
                else
                {
                    Command.CommandText += "EXEC Czasop_EditSygnature @edit_id_cza_syg" + i + ", @OldEditSyg" + i + ", @EditSyg" + i + ", @MagazineID; ";
                    Command.Parameters.AddWithValue("@EditSyg" + i, SygDataTable.Rows[i]["syg"].ToString());
                    Command.Parameters.AddWithValue("@OldEditSyg" + i, SygDataTable.Rows[i]["old_syg"].ToString());
                    Command.Parameters.AddWithValue("@edit_id_cza_syg" + i, SygDataTable.Rows[i]["id_cza_syg"].ToString());
                }
            }

            // usunięcie woluminów

            // dodanie/edycja woluminów
            for (int i = 0; i < VolumesDataTable.Rows.Count; i++)
            {
                if (!Seryjne)
                {
                    // dodanie
                    if (VolumesDataTable.Rows[i]["id"].ToString() == "-1")
                    {
                        Command.CommandText += "EXEC Czasop_VolumesAdd @MagazineID, @p_SygVolumes" + i + ", @p_rok1Volumes" + i + ", @p_rok2Volumes" + i + ", @p_voluminVolumes" + i + ", @p_czesciVolumes" + i + ", @p_uwagi_vVolumes" + i + ", @p_rocz_prenVolumes" + i + ", @p_wart_vol" + i + ", @p_numer_inw" + i + ", @p_nab" + i + ", @p_dodatki" + i + ", @p_data_biez" + i + ", @p_id_cza_sygVolumes" + i + "_, @IDVolumes" + i + " OUTPUT; ";

                        Command.Parameters.AddWithValue("@p_SygVolumes" + i, VolumesDataTable.Rows[i]["syg"].ToString());
                        Command.Parameters.AddWithValue("@p_rok1Volumes" + i, VolumesDataTable.Rows[i]["rok1"].ToString());

                        if (!String.IsNullOrEmpty(VolumesDataTable.Rows[i]["rok2"].ToString()))
                            Command.Parameters.AddWithValue("@p_rok2Volumes" + i, VolumesDataTable.Rows[i]["rok2"].ToString());
                        else
                            Command.Parameters.AddWithValue("@p_rok2Volumes" + i, DBNull.Value);

                        Command.Parameters.AddWithValue("@p_voluminVolumes" + i, VolumesDataTable.Rows[i]["volumin"].ToString());
                        Command.Parameters.AddWithValue("@p_czesciVolumes" + i, VolumesDataTable.Rows[i]["czesci"].ToString());
                        Command.Parameters.AddWithValue("@p_uwagi_vVolumes" + i, VolumesDataTable.Rows[i]["uwagi_v"].ToString());
                        Command.Parameters.AddWithValue("@p_rocz_prenVolumes" + i, ToNumber(VolumesDataTable.Rows[i]["rocz_pren"]));
                        Command.Parameters.AddWithValue("@p_wart_vol" + i, ToNumber(VolumesDataTable.Rows[i]["wart_vol"]));
                        Command.Parameters.AddWithValue("@p_numer_inw" + i, VolumesDataTable.Rows[i]["numer_inw"].ToString());
                        Command.Parameters.AddWithValue("@p_nab" + i, VolumesDataTable.Rows[i]["nab"].ToString());
                        Command.Parameters.AddWithValue("@p_dodatki" + i, VolumesDataTable.Rows[i]["ilosc_dodatki"].ToString() != "0");
                        Command.Parameters.AddWithValue("@p_data_biez" + i, DTOC(VolumesDataTable.Rows[i]["data_biez"]));

                        if (VolumesDataTable.Rows[i]["id_cza_syg"].ToString() != "-1")
                            Command.Parameters.AddWithValue("@p_id_cza_sygVolumes" + i + "_", VolumesDataTable.Rows[i]["id_cza_syg"].ToString());                            
                        else
                        {
                            for (int k = 0; k < SygDataTable.Rows.Count; k++)
                            {
                                if (SygDataTable.Rows[k]["syg"].ToString() == VolumesDataTable.Rows[i]["syg"].ToString())
                                {
                                    Command.CommandText = Command.CommandText.Replace("p_id_cza_sygVolumes" + i + "_", "id_cza_syg_" + k);
                                    break;
                                }
                            }
                        }

                        SqlParameter Param = new SqlParameter();
                        Param.ParameterName = "@IDVolumes" + i;
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.InputOutput;
                        Param.Value = DBNull.Value;

                        Command.Parameters.Add(Param);

                        if (((DataTable) VolumesDataTable.Rows[i]["dodatki"]).Rows.Count > 0)
                        {
                            DataTable Dodatk = ((DataTable) VolumesDataTable.Rows[i]["dodatki"]);

                            for (int j = 0; j < Dodatk.Rows.Count; j++)
                            {
                                if (Dodatk.Rows[j]["id"].ToString() == "-1")
                                {
                                    Command.CommandText += "EXEC Czasop_ExtrasAdd @MagazineID, @p_SygExtras" + j + ", @p_rok1Extras" + j + ", @p_rok2Extras" + j + ", @p_voluminExtras" + j + ", @p_autor1Extras" + j + ", @p_autor2Extras" + j + ", @p_autor3Extras" + j + ", @p_tytul_dodExtras" + j + ", @p_k_kreskowy" + j + "; ";

                                    Command.Parameters.AddWithValue("@p_SygExtras" + j, VolumesDataTable.Rows[i]["syg"].ToString());
                                    Command.Parameters.AddWithValue("@p_rok1Extras" + j, VolumesDataTable.Rows[i]["rok1"].ToString());

                                    if (!String.IsNullOrEmpty(VolumesDataTable.Rows[i]["rok2"].ToString()))
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + j, VolumesDataTable.Rows[i]["rok2"].ToString());
                                    else
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + j, DBNull.Value);

                                    Command.Parameters.AddWithValue("@p_voluminExtras" + j, VolumesDataTable.Rows[i]["volumin"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor1Extras" + j, Dodatk.Rows[j]["autor1"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor2Extras" + j, Dodatk.Rows[j]["autor2"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor3Extras" + j, Dodatk.Rows[j]["autor3"].ToString());
                                    Command.Parameters.AddWithValue("@p_tytul_dodExtras" + j, Dodatk.Rows[j]["tytul_dod"].ToString());
                                    Command.Parameters.AddWithValue("@p_k_kreskowy" + j, Dodatk.Rows[j]["k_kreskowy"].ToString());
                                }
                            }
                        }
                    }

                        // edycja
                    else
                    {
                        Command.CommandText += "EXEC Czasop_VolumesEdit @p_SygVolumes" + i + ", @p_rok1Volumes" + i + ", @p_rok2Volumes" + i + ", @p_voluminVolumes" + i + ", @p_czesciVolumes" + i + ", @p_uwagi_vVolumes" + i + ", @p_rocz_prenVolumes" + i + ", @p_wart_vol" + i + ", @p_numer_inw" + i + ", @p_nab" + i + ", @p_dodatki" + i + ", @p_data_biez" + i + ", @IDVolumes" + i + " OUTPUT; ";

                        Command.Parameters.AddWithValue("@p_SygVolumes" + i, VolumesDataTable.Rows[i]["syg"].ToString());
                        Command.Parameters.AddWithValue("@p_rok1Volumes" + i, VolumesDataTable.Rows[i]["rok1"].ToString());

                        if (!String.IsNullOrEmpty(VolumesDataTable.Rows[i]["rok2"].ToString()))
                            Command.Parameters.AddWithValue("@p_rok2Volumes" + i, VolumesDataTable.Rows[i]["rok2"].ToString());
                        else
                            Command.Parameters.AddWithValue("@p_rok2Volumes" + i, DBNull.Value);

                        Command.Parameters.AddWithValue("@p_voluminVolumes" + i, VolumesDataTable.Rows[i]["volumin"].ToString());
                        Command.Parameters.AddWithValue("@p_czesciVolumes" + i, VolumesDataTable.Rows[i]["czesci"].ToString());
                        Command.Parameters.AddWithValue("@p_uwagi_vVolumes" + i, VolumesDataTable.Rows[i]["uwagi_v"].ToString());
                        Command.Parameters.AddWithValue("@p_rocz_prenVolumes" + i, ToNumber(VolumesDataTable.Rows[i]["rocz_pren"]));
                        Command.Parameters.AddWithValue("@p_wart_vol" + i, ToNumber(VolumesDataTable.Rows[i]["wart_vol"]));
                        Command.Parameters.AddWithValue("@p_numer_inw" + i, VolumesDataTable.Rows[i]["numer_inw"].ToString());
                        Command.Parameters.AddWithValue("@p_nab" + i, VolumesDataTable.Rows[i]["nab"].ToString());
                        Command.Parameters.AddWithValue("@p_dodatki" + i, VolumesDataTable.Rows[i]["ilosc_dodatki"].ToString() != "0");
                        Command.Parameters.AddWithValue("@p_data_biez" + i, DTOC(VolumesDataTable.Rows[i]["data_biez"]));
                        Command.Parameters.AddWithValue("@p_id_cza_sygVolumes" + i, VolumesDataTable.Rows[i]["id_cza_syg"].ToString());



                        SqlParameter Param = new SqlParameter();
                        Param.ParameterName = "@IDVolumes" + i;
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.InputOutput;
                        Param.Value = VolumesDataTable.Rows[i]["id"].ToString();

                        Command.Parameters.Add(Param);

                        if (((DataTable) VolumesDataTable.Rows[i]["dodatki"]).Rows.Count > 0)
                        {
                            DataTable Dodatk = ((DataTable) VolumesDataTable.Rows[i]["dodatki"]);

                            for (int j = 0; j < Dodatk.Rows.Count; j++)
                            {
                                // usuwanie dodatków
                                if (Dodatk.Rows[j]["idTemp"].ToString() == "-1")
                                {
                                    Command.CommandText += "EXEC Czasop_ExtrasDelete @id_dodatki" + j + "; ";

                                    Command.Parameters.AddWithValue("@id_dodatki" + j, Dodatk.Rows[j]["id"].ToString());
                                }
                                    // dodawanie dodatków
                                else if (Dodatk.Rows[j]["id"].ToString() == "-1")
                                {
                                    Command.CommandText += "EXEC Czasop_ExtrasAdd @MagazineID, @p_SygExtras" + j + ", @p_rok1Extras" + j + ", @p_rok2Extras" + j + ", @p_voluminExtras" + j + ", @p_autor1Extras" + j + ", @p_autor2Extras" + j + ", @p_autor3Extras" + j + ", @p_tytul_dodExtras" + j + ", @p_k_kreskowy" + j + "; ";

                                    Command.Parameters.AddWithValue("@p_SygExtras" + j, VolumesDataTable.Rows[i]["syg"].ToString());
                                    Command.Parameters.AddWithValue("@p_rok1Extras" + j, VolumesDataTable.Rows[i]["rok1"].ToString());

                                    if (!String.IsNullOrEmpty(VolumesDataTable.Rows[i]["rok2"].ToString()))
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + j, VolumesDataTable.Rows[i]["rok2"].ToString());
                                    else
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + j, DBNull.Value);

                                    Command.Parameters.AddWithValue("@p_voluminExtras" + j, VolumesDataTable.Rows[i]["volumin"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor1Extras" + j, Dodatk.Rows[j]["autor1"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor2Extras" + j, Dodatk.Rows[j]["autor2"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor3Extras" + j, Dodatk.Rows[j]["autor3"].ToString());
                                    Command.Parameters.AddWithValue("@p_tytul_dodExtras" + j, Dodatk.Rows[j]["tytul_dod"].ToString());
                                    Command.Parameters.AddWithValue("@p_k_kreskowy" + j, Dodatk.Rows[j]["k_kreskowy"].ToString());
                                }
                                // edycja dodatków
                                else
                                {
                                    Command.CommandText += "EXEC Czasop_ExtrasEdit @p_SygExtras" + j + ", @p_rok1Extras" + j + ", @p_rok2Extras" + j + ", @p_voluminExtras" + j + ", @p_autor1Extras" + j + ", @p_autor2Extras" + j + ", @p_autor3Extras" + j + ", @p_tytul_dodExtras" + j + ", @p_k_kreskowy" + j + ", @id_dodatki" + j + "; ";

                                    Command.Parameters.AddWithValue("@p_SygExtras" + j, VolumesDataTable.Rows[i]["syg"].ToString());
                                    Command.Parameters.AddWithValue("@p_rok1Extras" + j, VolumesDataTable.Rows[i]["rok1"].ToString());

                                    if (!String.IsNullOrEmpty(VolumesDataTable.Rows[i]["rok2"].ToString()))
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + j, VolumesDataTable.Rows[i]["rok2"].ToString());
                                    else
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + j, DBNull.Value);

                                    Command.Parameters.AddWithValue("@p_voluminExtras" + j, VolumesDataTable.Rows[i]["volumin"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor1Extras" + j, Dodatk.Rows[j]["autor1"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor2Extras" + j, Dodatk.Rows[j]["autor2"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor3Extras" + j, Dodatk.Rows[j]["autor3"].ToString());
                                    Command.Parameters.AddWithValue("@p_tytul_dodExtras" + j, Dodatk.Rows[j]["tytul_dod"].ToString());
                                    Command.Parameters.AddWithValue("@p_k_kreskowy" + j, Dodatk.Rows[j]["k_kreskowy"].ToString());
                                    Command.Parameters.AddWithValue("@id_dodatki" + j, Dodatk.Rows[j]["id"].ToString());
                                }
                            }
                        }
                    }
                }
                //seryjne
                else
                {
                    // dodanie
                    if (VolumesDataTable.Rows[i]["id"].ToString() == "-1")
                    {
                        Command.CommandText += "EXEC Czasop_SeryjneAdd @MagazineID, @p_Sygseryjne" + i + ", @p_rok_serseryjne" + i + ", @p_numer_serseryjne" + i + ", @p_tytul_serseryjne" + i + ", @p_autor1_ser" + i + ", @p_autor2_ser" + i + ", @p_autor3_ser" + i + ", @p_nr_kol_ser" + i + ", @p_wart_ser" + i + ", @p_numer_inw" + i + ", @p_nab" + i + ", @p_uwagi_s" + i + ", @strony_ser" + i + ", @p_id_cza_sygSeryjne" + i + "; ";

                        Command.Parameters.AddWithValue("@p_Sygseryjne" + i, VolumesDataTable.Rows[i]["syg"].ToString());
                        Command.Parameters.AddWithValue("@p_rok_serseryjne" + i, VolumesDataTable.Rows[i]["rok_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_numer_serseryjne" + i, VolumesDataTable.Rows[i]["numer_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_tytul_serseryjne" + i, VolumesDataTable.Rows[i]["tytul_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_autor1_ser" + i, VolumesDataTable.Rows[i]["autor1_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_autor2_ser" + i, VolumesDataTable.Rows[i]["autor2_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_autor3_ser" + i, VolumesDataTable.Rows[i]["autor3_ser"].ToString());

                        Command.Parameters.AddWithValue("@p_nr_kol_ser" + i, VolumesDataTable.Rows[i]["nr_kol_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_wart_ser" + i, VolumesDataTable.Rows[i]["wart_ser"].ToString());

                        Command.Parameters.AddWithValue("@p_nab" + i, VolumesDataTable.Rows[i]["nab"].ToString());
                        Command.Parameters.AddWithValue("@p_numer_inw" + i, VolumesDataTable.Rows[i]["numer_inw"].ToString());
                        Command.Parameters.AddWithValue("@p_uwagi_s" + i, VolumesDataTable.Rows[i]["uwagi_s"].ToString());
                        Command.Parameters.AddWithValue("@strony_ser" + i, VolumesDataTable.Rows[i]["strony_ser"].ToString());
                        //Command.Parameters.AddWithValue("@p_id_cza_sygSeryjne" + i, VolumesDataTable.Rows[i]["id_cza_syg"].ToString());

                        if (VolumesDataTable.Rows[i]["id_cza_syg"].ToString() != "-1")
                            Command.Parameters.AddWithValue("@p_id_cza_sygSeryjne" + i, VolumesDataTable.Rows[i]["id_cza_syg"].ToString());
                        else
                        {
                            for (int k = 0; k < SygDataTable.Rows.Count; k++)
                            {
                                if (SygDataTable.Rows[k]["syg"].ToString() == VolumesDataTable.Rows[i]["syg"].ToString())
                                {
                                    Command.CommandText = Command.CommandText.Replace("p_id_cza_sygSeryjne" + i, "id_cza_syg_" + k);
                                    break;
                                }
                            }
                        }

                        SqlParameter Param = new SqlParameter();
                        Param.ParameterName = "@IDVolumes" + i;
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.InputOutput;
                        Param.Value = DBNull.Value;

                        Command.Parameters.Add(Param);

                        if (VolumesDataTable.Rows[i]["dodatki"] != null && ((DataTable)VolumesDataTable.Rows[i]["dodatki"]).Rows.Count > 0)
                        {
                            DataTable Dodatk = ((DataTable)VolumesDataTable.Rows[i]["dodatki"]);

                            for (int j = 0; j < Dodatk.Rows.Count; j++)
                            {
                                if (Dodatk.Rows[j]["id"].ToString() == "-1")
                                {
                                    Command.CommandText += "EXEC Czasop_ExtrasAdd @MagazineID, @p_SygExtras" + j + ", @p_rok1Extras" + j + ", @p_rok2Extras" + j + ", @p_voluminExtras" + j + ", @p_autor1Extras" + j + ", @p_autor2Extras" + j + ", @p_autor3Extras" + j + ", @p_tytul_dodExtras" + j + ", @p_k_kreskowy" + j + "; ";

                                    Command.Parameters.AddWithValue("@p_SygExtras" + j, VolumesDataTable.Rows[i]["syg"].ToString());
                                    Command.Parameters.AddWithValue("@p_rok1Extras" + j, VolumesDataTable.Rows[i]["rok1"].ToString());

                                    if (!String.IsNullOrEmpty(VolumesDataTable.Rows[i]["rok2"].ToString()))
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + i, VolumesDataTable.Rows[i]["rok2"].ToString());
                                    else
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + i, DBNull.Value);

                                    Command.Parameters.AddWithValue("@p_voluminExtras" + j, VolumesDataTable.Rows[i]["volumin"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor1Extras" + j, Dodatk.Rows[j]["autor1"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor2Extras" + j, Dodatk.Rows[j]["autor2"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor3Extras" + j, Dodatk.Rows[j]["autor3"].ToString());
                                    Command.Parameters.AddWithValue("@p_tytul_dodExtras" + j, Dodatk.Rows[j]["tytul_dod"].ToString());
                                    Command.Parameters.AddWithValue("@p_k_kreskowy" + j, Dodatk.Rows[j]["k_kreskowy"].ToString());
                                }
                            }
                        }
                    }
                        // edycja
                    else
                    {
                        Command.CommandText += "EXEC Czasop_SeryjneEdit @p_Sygseryjne" + i + ", @p_rok_ser" + i + ", @p_numer_ser" + i + ", @p_tytul_ser" + i + ", @p_autor1_ser" + i + ", @p_autor2_ser" + i + ", @p_autor3_ser" + i + ", @p_nr_kol_ser" + i + ", @p_wart_ser" + i + ", @p_numer_inw" + i + ", @p_nab" + i + ", @p_uwagi_s" + i + ", @strony_ser" + i + ", @p_ID" + i + "; ";

                        Command.Parameters.AddWithValue("@p_Sygseryjne" + i, VolumesDataTable.Rows[i]["syg"].ToString());
                        Command.Parameters.AddWithValue("@p_rok_ser" + i, VolumesDataTable.Rows[i]["rok_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_numer_ser" + i, VolumesDataTable.Rows[i]["numer_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_tytul_ser" + i, VolumesDataTable.Rows[i]["tytul_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_autor1_ser" + i, VolumesDataTable.Rows[i]["autor1_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_autor2_ser" + i, VolumesDataTable.Rows[i]["autor2_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_autor3_ser" + i, VolumesDataTable.Rows[i]["autor3_ser"].ToString());

                        Command.Parameters.AddWithValue("@p_nr_kol_ser" + i, VolumesDataTable.Rows[i]["nr_kol_ser"].ToString());
                        Command.Parameters.AddWithValue("@p_wart_ser" + i, VolumesDataTable.Rows[i]["wart_ser"].ToString());

                        Command.Parameters.AddWithValue("@p_nab" + i, VolumesDataTable.Rows[i]["nab"].ToString());
                        Command.Parameters.AddWithValue("@p_numer_inw" + i, VolumesDataTable.Rows[i]["numer_inw"].ToString());
                        Command.Parameters.AddWithValue("@p_uwagi_s" + i, VolumesDataTable.Rows[i]["uwagi_s"].ToString());
                        Command.Parameters.AddWithValue("@strony_ser" + i, VolumesDataTable.Rows[i]["strony_ser"].ToString());                        

                        SqlParameter Param = new SqlParameter();
                        Param.ParameterName = "@p_ID" + i;
                        Param.SqlDbType = SqlDbType.Int;
                        Param.Direction = ParameterDirection.InputOutput;
                        Param.Value = VolumesDataTable.Rows[i]["id"].ToString();

                        Command.Parameters.Add(Param);

                        if (((DataTable)VolumesDataTable.Rows[i]["dodatki"]).Rows.Count > 0)
                        {
                            DataTable Dodatk = ((DataTable)VolumesDataTable.Rows[i]["dodatki"]);

                            for (int j = 0; j < Dodatk.Rows.Count; j++)
                            {
                                // usuwanie dodatków
                                if (Dodatk.Rows[j]["idTemp"].ToString() == "-1")
                                {
                                    Command.CommandText += "EXEC Czasop_ExtrasDelete @id_dodatki" + j + "; ";

                                    Command.Parameters.AddWithValue("@id_dodatki" + j, Dodatk.Rows[j]["id"].ToString());
                                }
                                // dodawanie dodatków
                                else if (Dodatk.Rows[j]["id"].ToString() == "-1")
                                {
                                    Command.CommandText += "EXEC Czasop_ExtrasAdd @MagazineID, @p_SygExtras" + j + ", @p_rok1Extras" + j + ", @p_rok2Extras" + j + ", @p_voluminExtras" + j + ", @p_autor1Extras" + j + ", @p_autor2Extras" + j + ", @p_autor3Extras" + j + ", @p_tytul_dodExtras" + j + ", @p_k_kreskowy" + j + "; ";

                                    Command.Parameters.AddWithValue("@p_SygExtras" + j, VolumesDataTable.Rows[i]["syg"].ToString());
                                    Command.Parameters.AddWithValue("@p_rok1Extras" + j, VolumesDataTable.Rows[i]["rok1"].ToString());

                                    if (!String.IsNullOrEmpty(VolumesDataTable.Rows[i]["rok2"].ToString()))
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + i, VolumesDataTable.Rows[i]["rok2"].ToString());
                                    else
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + i, DBNull.Value);

                                    Command.Parameters.AddWithValue("@p_voluminExtras" + j, VolumesDataTable.Rows[i]["volumin"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor1Extras" + j, Dodatk.Rows[j]["autor1"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor2Extras" + j, Dodatk.Rows[j]["autor2"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor3Extras" + j, Dodatk.Rows[j]["autor3"].ToString());
                                    Command.Parameters.AddWithValue("@p_tytul_dodExtras" + j, Dodatk.Rows[j]["tytul_dod"].ToString());
                                    Command.Parameters.AddWithValue("@p_k_kreskowy" + j, Dodatk.Rows[j]["k_kreskowy"].ToString());
                                }
                                // edycja dodatków
                                else
                                {
                                    Command.CommandText += "EXEC Czasop_ExtrasEdit @p_SygExtras" + j + ", @p_rok1Extras" + j + ", @p_rok2Extras" + j + ", @p_voluminExtras" + j + ", @p_autor1Extras" + j + ", @p_autor2Extras" + j + ", @p_autor3Extras" + j + ", @p_tytul_dodExtras" + j + ", @p_k_kreskowy" + j + ", @id_dodatki" + j + "; ";

                                    Command.Parameters.AddWithValue("@p_SygExtras" + j, VolumesDataTable.Rows[i]["syg"].ToString());
                                    Command.Parameters.AddWithValue("@p_rok1Extras" + j, VolumesDataTable.Rows[i]["rok1"].ToString());

                                    if (!String.IsNullOrEmpty(VolumesDataTable.Rows[i]["rok2"].ToString()))
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + i, VolumesDataTable.Rows[i]["rok2"].ToString());
                                    else
                                        Command.Parameters.AddWithValue("@p_rok2Extras" + i, DBNull.Value);

                                    Command.Parameters.AddWithValue("@p_voluminExtras" + j, VolumesDataTable.Rows[i]["volumin"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor1Extras" + j, Dodatk.Rows[j]["autor1"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor2Extras" + j, Dodatk.Rows[j]["autor2"].ToString());
                                    Command.Parameters.AddWithValue("@p_autor3Extras" + j, Dodatk.Rows[j]["autor3"].ToString());
                                    Command.Parameters.AddWithValue("@p_tytul_dodExtras" + j, Dodatk.Rows[j]["tytul_dod"].ToString());
                                    Command.Parameters.AddWithValue("@p_k_kreskowy" + j, Dodatk.Rows[j]["k_kreskowy"].ToString());
                                    Command.Parameters.AddWithValue("@id_dodatki" + j, Dodatk.Rows[j]["id"].ToString());
                                }
                            }
                        }
                    }
                }                
            }

            for (int i = 0; i < InstitutionsDataTable.Rows.Count; i++)
            {
                // usuwanie instytucji
                if (InstitutionsDataTable.Rows[i]["idTemp"].ToString() == "-1")
                {
                    Command.CommandText += "EXEC Czasop_DeleteMagazineInstitution @id_inst" + i + "; ";

                    Command.Parameters.AddWithValue("@id_inst" + i, InstitutionsDataTable.Rows[i]["id"].ToString());
                }
                // dodawanie instytucji
                else if (InstitutionsDataTable.Rows[i]["id"].ToString() == "-1")
                {
                    Command.CommandText += "EXEC Czasop_AddMagazineInstitution @MagazineID, @inst_name" + i + ", @inst_place" + i + "; ";

                    Command.Parameters.AddWithValue("@inst_name" + i, InstitutionsDataTable.Rows[i]["nazwa"].ToString());
                    Command.Parameters.AddWithValue("@inst_place" + i, InstitutionsDataTable.Rows[i]["siedziba"].ToString());
                }
                // edycja instytucji
                else
                {
                    Command.CommandText += "EXEC Czasop_EditMagazineInstitution @inst_name" + i + ", @inst_place" + i + ", @inst_id" + i + ";";

                    Command.Parameters.AddWithValue("@inst_name" + i, InstitutionsDataTable.Rows[i]["nazwa"].ToString());
                    Command.Parameters.AddWithValue("@inst_place" + i, InstitutionsDataTable.Rows[i]["siedziba"].ToString());
                    Command.Parameters.AddWithValue("@inst_id" + i, InstitutionsDataTable.Rows[i]["id"].ToString());
                }
            }


            if (CommonFunctions.WriteData(ref Command, ref Settings.Connection))
            {
                MessageBox.Show(_translationsDictionary.getStringFromDictionary("saved", "Dane zostały zapisane"), _translationsDictionary.getStringFromDictionary("data_save", "Zapis czasopisma"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.MagazineID = MagazineIDParameter.Value.ToString();
                this.CurrentModeEnum = ModeEnum.Edit;

                if (SygsDGV.SelectedRows.Count > 0)
                    TempSyg = SygsDGV.SelectedRows[0].Cells["Sygnatura"].Value.ToString();

                if(VolumesDGV.SelectedRows.Count >0)
                    TempVol = VolumesDGV.SelectedRows[0].Cells["Volumes"].Value.ToString();

                VolumesDataTable.Clear();
                SygDataTable.Clear();
                InstitutionsDataTable.Clear();

                LoadData(MagazineID, true);
                return true;
            }

            return false;
        }

        #region SaveButton_Click(object sender, EventArgs e)
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion

        #region ExtrasButton_Click(object sender, EventArgs e)
        private void ExtrasButton_Click(object sender, EventArgs e)
        {            
            if (CurrentVolumesMode == VolumesModeEnum.None)
            {
                if (VolumesDGV.SelectedRows[0].Cells["idVolumesDGV"].Value.ToString() == "-1")
                {
                    ExtrasForm EF = new ExtrasForm(TempDodatki, true);
                    EF.ShowDialog();
                }
                else
                {
                    ExtrasForm EF = new ExtrasForm(MagazineID, CurrentSygTextBox.Text.Trim(), WoluminTextBox.Text.Trim(), YearTextBox.Text.Trim(), true);
                    EF.ShowDialog();                    
                }
                
            }
            else
            {
                if (VolumesDGV.SelectedRows[0].Cells["idVolumesDGV"].Value.ToString() == "-1")
                {
                    ExtrasForm EF = new ExtrasForm(TempDodatki, false);
                    EF.ShowDialog();

                    TempDodatki = EF.Dt;
                }
                else
                {
                    ExtrasForm EF = new ExtrasForm(MagazineID, CurrentSygTextBox.Text.Trim(), WoluminTextBox.Text.Trim(), YearTextBox.Text.Trim(), Settings.ReadOnlyMode);
                    EF.ShowDialog();

                    TempDodatki = EF.Dt;
                }
            }            
        }
        #endregion

        #region SearchButton_Click(object sender, EventArgs e)
        private void SearchButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region MagazineForm_KeyDown(object sender, KeyEventArgs e)
        private void MagazineForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();

            else if(e.KeyCode == Keys.F2 && (CurrentSygMode == SygModeEnum.Add || CurrentSygMode == SygModeEnum.Edit))
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC ZwrocOstatniaSygnature 2, @str; ";
                Command.Parameters.AddWithValue("@str", CurrentSygTextBox.Text.Trim());

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);
                SygRTB.ResetText();

                for (int i = 0; i < Dt.Rows.Count; i++)
                {
                    SygRTB.Text += Dt.Rows[i]["syg"].ToString() + Environment.NewLine;
                }
            }
        }
        #endregion

        #region DeleteButton_Click(object sender, EventArgs e)
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if(Delete())
                this.Close();
        }
        #endregion
         
        #region SaveVolumes()
        private bool SaveVolumes()
        {
            if (!Seryjne)
            {
                string Wol = WoluminTextBox.Text.Trim() + (YearTextBox.Text.Trim().Length > 0 && YearTextBox.Text.Trim() != "0" ? " / " + YearTextBox.Text.Trim() : "") + (Year2TextBox.Text.Trim().Length > 0 && Year2TextBox.Text.Trim() != "0" ? " / " + Year2TextBox.Text.Trim() : "");

                if (CurrentVolumesMode == VolumesModeEnum.Add)
                {
                    VolumesDataTable.Rows.Add(TempID, "-1", YearTextBox.Text, Year2TextBox.Text, WoluminTextBox.Text.Trim(), NumbersTextBox.Text, CommentsVolumesTextBox.Text.Trim(), SposobNabyciaComboBox.SelectedValue ?? 1, NumInwTextBox.Text, PriceNumericUpDown.Value, ValueNumericUpDown.Value, DateDTP.Value.ToString(), TempDodatki.Rows.Count, TempDodatki, CurrentSygTextBox.Text.Trim(), SygsDGV.SelectedRows[0].Cells[id_cza_syg.Name].Value.ToString());
                    
                    //VolumesDGV.Rows.Add(TempID, "-1", WoluminTextBox.Text);
                    VolumesDGV.Rows.Add(TempID, "-1", Wol, SygsDGV.SelectedRows[0].Cells[id_cza_syg.Name].Value.ToString());
                }
                else if (CurrentVolumesMode == VolumesModeEnum.Edit)
                {
                    for (int i = 0; i < VolumesDataTable.Rows.Count; i++)
                    {
                        if (VolumesDataTable.Rows[i]["TempID"].ToString() == VolumesDGV.SelectedRows[0].Cells["tempIDVolumes"].Value.ToString())
                        {
                            VolumesDataTable.Rows.RemoveAt(i);
                            break;
                        }
                    }

                    if (string.IsNullOrEmpty(VolumesDGV.SelectedRows[0].Cells["tempIDVolumes"].Value.ToString()))
                        VolumesDGV.SelectedRows[0].Cells["tempIDVolumes"].Value = TempID.ToString();

                    VolumesDataTable.Rows.Add(VolumesDGV.SelectedRows[0].Cells["tempIDVolumes"].Value.ToString(), VolumesDGV.SelectedRows[0].Cells["idVolumesDGV"].Value.ToString(), YearTextBox.Text, Year2TextBox.Text, WoluminTextBox.Text.Trim(), NumbersTextBox.Text, CommentsVolumesTextBox.Text.Trim(), SposobNabyciaComboBox.SelectedValue ?? 1, NumInwTextBox.Text, PriceNumericUpDown.Value, ValueNumericUpDown.Value, DateDTP.Value.ToString(), TempDodatki.Rows.Count, TempDodatki, CurrentSygTextBox.Text.Trim(), VolumesDGV.SelectedRows[0].Cells["id_cza_sygVolumesDGVC"].Value.ToString());

                    VolumesDGV.SelectedRows[0].Cells["Volumes"].Value = Wol;// WoluminTextBox.Text;
                }

//                ExtrasLabel.Text = "Dodatki (" + TempDodatki.Rows.Count + ")";
                ExtrasLabel.Text = string.Format("{0} ({1})", _translationsDictionary.getStringFromDictionary("supplements", "Dodatki"), TempDodatki.Rows.Count);
            }
            else
            {
                string Ser = SerNumerTextBox.Text.Trim() + (SerYearTextBox.Text.Trim().Length > 0 && SerYearTextBox.Text.Trim() != "0" ? " / " + SerYearTextBox.Text.Trim() : "");

                if (CurrentVolumesMode == VolumesModeEnum.Add)
                {
                    VolumesDataTable.Rows.Add(TempID, "-1", CurrentSygTextBox.Text.Trim(), SerNumerTextBox.Text.Trim(), SerTitleTextBox.Text.Trim(), SerYearTextBox.Text.Trim(), StronyTextBox.Text.Trim(), SerAutorTextBox.Text.Trim(), SerAutor3TextBox.Text.Trim(), SerAutor3TextBox.Text.Trim(), SerNextNumerTextBox.Text.Trim(), SerValueNumericUpDown.Value.ToString(), SerNumInwTextBox.Text.Trim(), SerSposbNabyciaComboBox.SelectedValue, SerCommentsTextBox.Text.Trim(), TempDodatki, SygsDGV.SelectedRows[0].Cells[id_cza_syg.Name].Value.ToString());
                    //VolumesDGV.Rows.Add(TempID, "-1", SerNumerTextBox.Text + SerYearTextBox.Text);
                    VolumesDGV.Rows.Add(TempID, "-1", Ser, SygsDGV.SelectedRows[0].Cells[id_cza_syg.Name].Value.ToString());
                }
                else if (CurrentVolumesMode == VolumesModeEnum.Edit)
                {
                    for (int i = 0; i < VolumesDataTable.Rows.Count; i++)
                    {
                        if (VolumesDataTable.Rows[i]["TempID"].ToString() == VolumesDGV.SelectedRows[0].Cells["tempIDVolumes"].Value.ToString())
                        {
                            VolumesDataTable.Rows.RemoveAt(i);
                            break;
                        }
                    }

                    VolumesDataTable.Rows.Add(VolumesDGV.SelectedRows[0].Cells["tempIDVolumes"].Value.ToString(), VolumesDGV.SelectedRows[0].Cells["idVolumesDGV"].Value.ToString(), CurrentSygTextBox.Text.Trim(), SerNumerTextBox.Text.Trim(), SerTitleTextBox.Text.Trim(), SerYearTextBox.Text.Trim(), StronyTextBox.Text.Trim(), SerAutorTextBox.Text.Trim(), SerAutor2TextBox.Text.Trim(), SerAutor3TextBox.Text.Trim(), SerNextNumerTextBox.Text.Trim(), SerValueNumericUpDown.Value.ToString(), SerNumInwTextBox.Text.Trim(), SerSposbNabyciaComboBox.SelectedValue, SerCommentsTextBox.Text.Trim(), TempDodatki, VolumesDGV.SelectedRows[0].Cells["id_cza_sygVolumesDGVC"].Value.ToString());

                    VolumesDGV.SelectedRows[0].Cells["Volumes"].Value = Ser;//SerNumerTextBox.Text + SerYearTextBox.Text;
                }

                ExtrasLabel.Text = string.Format("{0} ({1})", _translationsDictionary.getStringFromDictionary("supplements", "Dodatki"), TempDodatki.Rows.Count);
            }

            for (int i = 0; i < VolumesDGV.Rows.Count; i++)
            {
                if (VolumesDGV.Rows[i].Cells["tempIDVolumes"].Value.ToString() == TempID.ToString())
                {
                    VolumesDGV.ClearSelection();
                    VolumesDGV.Rows[i].Selected = true;
                    VolumesDGV.CurrentCell = VolumesDGV["Volumes", i];
                    VolumesDGV.FirstDisplayedScrollingRowIndex = i;
                }
            }

            TempID++;
            lEdit = true;
            return true;
        }
        #endregion

        #region Delete()
        private bool Delete()
        {
            if (SygsDGV.Rows.Count == 0)
            {
                return DeleteMagazine();
            }

            UbytkiForm UF = new UbytkiForm(this.MagazineID, TitleTextBox.Text.Trim(), Seryjne);

            if (UF.ShowDialog() == DialogResult.OK)
            {
                if(VolumesDGV.Rows.Count > 0)
                    VolumesDGV.Rows.Clear();

                LoadSygs(MagazineID);

                if (SygsDGV.Rows.Count == 0)
                {
                    return DeleteMagazine();
                }
            }

            LoadSygs(MagazineID);

            return false;
        }
        #endregion

        private bool DeleteMagazine()
        {
            if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_delete_magazine", "Czy usunąć kartę główną tego czasopisma?"), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie karty głównej czasopisma"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GetFreqInAkcesja(MagazineID);

                if (FreqInAkcesja != -1)
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("delete_accession_first", "Proszę najpierw usunąć kartę akcesji tego czasopisma."), _translationsDictionary.getStringFromDictionary("app_name", "Co-Liber"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC Czasop_MagazineDelete @MagazineID; ";
                Command.Parameters.AddWithValue("@MagazineID", this.MagazineID);

                if (CommonFunctions.WriteData(Command, ref Settings.Connection))
                {
                    MessageBox.Show(_translationsDictionary.getStringFromDictionary("magazine_deleted", "Karta główna czasopisma została pomyślnie usunięta!"), _translationsDictionary.getStringFromDictionary("deleting", "Usuwanie"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                    return true;
                }
            }

            return false;
        }
         
        #region InstitutionsChangesCheckBox_Click(object sender, EventArgs e)
        private void InstitutionsChangesCheckBox_Click(object sender, EventArgs e)
        {

            int iRowCount;
            if (InstitutionsDataTable == null) iRowCount = 0; else iRowCount = InstitutionsDataTable.Rows.Count;
            InstitutionForm IF;

            if (CurrentModeEnum == ModeEnum.Add || iRowCount > 0)
            {
                IF = new InstitutionForm(InstitutionsDataTable, Settings.ReadOnlyMode);                
            }
            else
            {
                IF = new InstitutionForm(this.MagazineID, Settings.ReadOnlyMode);
            }

            IF.ShowDialog();

            InstitutionsDataTable = IF.Dt;

            InstitutionsChangesCheckBox.Checked = IF.Count > 0;
        }
        #endregion

        #region MagazineForm_FormClosing(object sender, FormClosingEventArgs e)
        private void MagazineForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Settings.ReadOnlyMode)
                return;

            lEdit = lEdit || CurrentModeEnum == ModeEnum.Add || _dirtyTracker.IsDirty;
            if (!lEdit) return;

            if (MessageBox.Show(_translationsDictionary.getStringFromDictionary("do_you_want_to_exit_without_save", "Czy zamknąć okno bez zapisywania zmian?"), _translationsDictionary.getStringFromDictionary("exit", "Wyjście"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
        }
        #endregion

        #region CleanCountryButton_Click(object sender, EventArgs e)
        private void CleanCountryButton_Click(object sender, EventArgs e)
        {
            CountryTextBox.Text = "";
        }
        #endregion

        #region LangButton_Click(object sender, EventArgs e)
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
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("language", "Język");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "kod";
            Columns[1].Name = "Kod";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("code", "Kod");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybierz język");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LangTextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();                
            }
        }
        #endregion

        #region Lang2Button_Click(object sender, EventArgs e)
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
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("language", "Język");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "kod";
            Columns[1].Name = "Kod";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("code", "Kod");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybierz język");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Lang2TextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();
            }
        }
        #endregion


        #region Lang3Button_Click(object sender, EventArgs e)
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
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("language", "Język");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "kod";
            Columns[1].Name = "Kod";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("code", "Kod");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybierz język");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Lang3TextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();                
            }
        }
        #endregion

        #region CleanLangButton_Click(object sender, EventArgs e)
        private void CleanLangButton_Click(object sender, EventArgs e)
        {
            LangTextBox.Text = "";
        }
        #endregion

        #region CleanLang2Button_Click(object sender, EventArgs e)
        private void CleanLang2Button_Click(object sender, EventArgs e)
        {
            Lang2TextBox.Text = "";
        }
        #endregion

        #region CleanLang3Button_Click(object sender, EventArgs e)
        private void CleanLang3Button_Click(object sender, EventArgs e)
        {
            Lang3TextBox.Text = "";
        }
        #endregion

        #region LangTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        private void LangTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
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
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("language", "Język");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "kod";
            Columns[1].Name = "Kod";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("code", "Kod");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybierz język");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                LangTextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();
            }
        }
        #endregion

        #region Lang2TextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        private void Lang2TextBox_MouseDoubleClick(object sender, MouseEventArgs e)
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
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("language", "Język");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "kod";
            Columns[1].Name = "Kod";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("code", "Kod");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybierz język");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Lang2TextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();
            }
        }
        #endregion

        #region Lang3TextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        private void Lang3TextBox_MouseDoubleClick(object sender, MouseEventArgs e)
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
            Columns[2].HeaderText = _translationsDictionary.getStringFromDictionary("language", "Język");
            Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "kod";
            Columns[1].Name = "Kod";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("code", "Kod");
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ShowForm Formka = new ShowForm(Command, Columns);
            Formka.Text = _translationsDictionary.getStringFromDictionary("select", "Wybierz język");
            Formka.Width = 400;

            if (Formka.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Lang3TextBox.Text = Formka.Dt.Cells["Kod"].Value.ToString();
            }
        }
        #endregion

        #region KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        private void KeyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
                AddKeyToGrid();
        }
        #endregion

        private void FreqComboBox_Enter(object sender, EventArgs e)
        {
            this.FreqIndex = FreqComboBox.SelectedIndex;
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            WaitForm WF = new WaitForm();
            this.Invoke((MethodInvoker)delegate { WF.Show(this); WF.Update(); });

            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("kod", this.MagazineID);

            RdlViewer.MainForm Report = new RdlViewer.MainForm("Czasopisma_KartaWyszczegolniajaca.rdl", parameters, "coliber", Settings.ConnectionString);

            WF.Close();

            if (Report != null)
                Report.ShowDialog();
        }

        private string ToNumber(object val)
        {
            string cRet = val.ToString();
            cRet = cRet.Replace(" ", "");
            cRet = cRet.Replace(",", ".");
            if (cRet == null || cRet == "" || cRet == ".") cRet = "0";
            return cRet;
        }

        private string DTOC(Object oVal)
        {
            DateTime dt;
            if (oVal == DBNull.Value)
                return "00010101";
            else
            {
                if (oVal is System.DateTime)
                {
                    dt = (DateTime)oVal;
                }
                else
                {
                    dt = Convert.ToDateTime((string)oVal);
                }
                return dt.ToString("yyyyMMdd");
            }
        }

        public static DateTime DBDateT2(Object oVal)
        {
            if (oVal == DBNull.Value)
                return new DateTime(1901, 1, 1);
            else
            {
                if (oVal is System.DateTime) return (DateTime)oVal;
                else return Convert.ToDateTime((string)oVal);
            }

        }

    }
}