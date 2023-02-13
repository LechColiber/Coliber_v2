using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Artykuly
{
    public partial class MagazineUC : UserControl
    {
        private string ID;
        public string IDValue
        {
            get { return ID; }
            set { ID = value; }
        }
        public string SourceTitleRichTextBoxValue
        {
            get { return SourceTitleRichTextBox.Text; }
            set { SourceTitleRichTextBox.Text = value; }
        }

        public string SygnaturaTextBoxValue
        {
            get { return SygnaturaTextBox.Text; }
            set { SygnaturaTextBox.Text = value; }
        }

        public string YearTextBoxValue
        {
            get { return YearTextBox.Text; }
            set { YearTextBox.Text = value; }
        }

        public string Year2TextBoxValue
        {
            get { return Year2TextBox.Text; }
            set { Year2TextBox.Text = value; }
        }
        public string WoluminTextBoxValue
        {
            get { return WoluminTextBox.Text; }
            set { WoluminTextBox.Text = value; }
        }
        public string NumberTextBoxValue
        {
            get { return NumberTextBox.Text; }
            set { NumberTextBox.Text = value; }
        }
        public string Number2TextBoxValue
        {
            get { return Number2TextBox.Text; }
            set { Number2TextBox.Text = value; }
        }
        public string LanguageTextBoxValue
        {
            get { return LanguageTextBox.Text; }
            set { LanguageTextBox.Text = value; }
        }
        public string PagesTextBoxValue
        {
            get { return PagesTextBox.Text; }
            set { PagesTextBox.Text = value; }
        }
        public string NrodcTextBoxValue
        {
            get { return NrodcTextBox.Text; }
            set { NrodcTextBox.Text = value; }
        }
        public bool TablesCheckBoxValue
        {
            get { return TablesCheckBox.Checked; }
            set { TablesCheckBox.Checked = value; }
        }
        public bool MapsCheckBoxValue
        {
            get { return MapsCheckBox.Checked; }
            set { MapsCheckBox.Checked = value; }
        }
        public bool ChartCheckBoxValue
        {
            get { return ChartCheckBox.Checked; }
            set { ChartCheckBox.Checked = value; }
        }
        public bool PolCheckBoxValue
        {
            get { return PolCheckBox.Checked; }
            set { PolCheckBox.Checked = value; }
        }
        public bool EngCheckBoxValue
        {
            get { return EngCheckBox.Checked; }
            set { EngCheckBox.Checked = value; }
        }
        public bool GerCheckBoxValue
        {
            get { return GerCheckBox.Checked; }
            set { GerCheckBox.Checked = value; }
        }
        public bool FraCheckBoxValue
        {
            get { return FraCheckBox.Checked; }
            set { FraCheckBox.Checked = value; }
        }
        public bool RusCheckBoxValue
        {
            get { return RusCheckBox.Checked; }
            set { RusCheckBox.Checked = value; }
        }
        public DateTime DateDTPValue
        {
            get { return DateDTP.Value; }
            set { DateDTP.Value = value; }
        }

        public string id_czasop_nValue
        {
            get { return id_czasop_n; }
            set { id_czasop_n = value; }
        }

        private string id_czasop_n;
        private Dictionary<string, string> _translationsDictionary;
        public MagazineUC()
        {
            InitializeComponent();

            setControlsText();

            ToolTip CleanToolTip = new ToolTip();
            CleanToolTip.SetToolTip(CleanCountryButton, _translationsDictionary.getStringFromDictionary("to_clean", "Wyczyść"));

            ToolTip SelectToolTip = new ToolTip();
            SelectToolTip.SetToolTip(ChooseLanguageButton, _translationsDictionary.getStringFromDictionary("choose_language", "Wybór języka z listy"));
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();

            mapping.Add(groupBox1, "magazine_data");

            mapping.Add(ChooseCzButton, "choose_magazine_and_magazine_number");
            mapping.Add(sourceTitleLabel, "title_of_publication_source");
            mapping.Add(signatureLabel, "signature");

            mapping.Add(yearLabel, "year");
            mapping.Add(volumeLabel, "volume");
            mapping.Add(numberLabel, "number");

            mapping.Add(pagesLabel, "pages");
            mapping.Add(episodeNumberLabel, "episode_number");
            mapping.Add(languageLabel, "language");

            mapping.Add(containsLabel, "contains");
            mapping.Add(TablesCheckBox, "tables_accusative");
            mapping.Add(MapsCheckBox, "maps_accusative");
            mapping.Add(ChartCheckBox, "charts_accusative");            

            mapping.Add(summariesLabel, "summaries");
            mapping.Add(PolCheckBox, "in_polish");
            mapping.Add(GerCheckBox, "in_german");
            mapping.Add(RusCheckBox, "in_russian");
            mapping.Add(EngCheckBox, "in_english");
            mapping.Add(FraCheckBox, "in_french");
            mapping.Add(entryDateLabel, "data_of_entry");

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void ChooseCzButton_Click(object sender, EventArgs e)
        {
            WaitForm WF = new WaitForm();

            try
            {
                
                this.Invoke((MethodInvoker) delegate
                {
                    WF.Show(this);
                    WF.Update();
                });

                ChooseMagazineAndNumber CMAN = new ChooseMagazineAndNumber();

                WF.Close();

                if (CMAN.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    id_czasop_n = "";
                    ID = "";
                    SourceTitleRichTextBox.Text = "";
                    SygnaturaTextBox.Text = "";

                    YearTextBox.Text = "";
                    Year2TextBox.Text = "";
                    WoluminTextBox.Text = "";
                    NumberTextBox.Text = "";
                    Number2TextBox.Text = "";

                    SourceTitleRichTextBox.ReadOnly = false;
                    SygnaturaTextBox.ReadOnly = false;

                    YearTextBox.ReadOnly = false;
                    Year2TextBox.ReadOnly = false;
                    WoluminTextBox.ReadOnly = false;
                    NumberTextBox.ReadOnly = false;
                    Number2TextBox.ReadOnly = false;

                    SourceTitleRichTextBox.BackColor = Color.FromArgb(LanguageTextBox.BackColor.ToArgb());

                    if (CMAN.MagazineRow != null)
                    {
                        if (CMAN.MagazineRow.Cells["id"].Value != null)
                            ID = CMAN.MagazineRow.Cells["id"].Value.ToString();

                        if (CMAN.MagazineRow.Cells["Magazine"].Value != null)
                            SourceTitleRichTextBox.Text = CMAN.MagazineRow.Cells["Magazine"].Value.ToString();

                        if (CMAN.MagazineRow.Cells["Sygnatura"].Value != null)
                            SygnaturaTextBox.Text = CMAN.MagazineRow.Cells["Sygnatura"].Value.ToString();

                        SourceTitleRichTextBox.ReadOnly = true;
                        SygnaturaTextBox.ReadOnly = true;
                    }

                    if (CMAN.NumberRow != null)
                    {
                        if (CMAN.NumberRow.Cells["IDNumber"].Value != null)
                            id_czasop_n = CMAN.NumberRow.Cells["IDNumber"].Value.ToString();
                        
                        if (CMAN.NumberRow.Cells["rok1"].Value != null)
                            YearTextBox.Text = CMAN.NumberRow.Cells["rok1"].Value.ToString();

                        if (CMAN.NumberRow.Cells["rok2"].Value != null)
                            Year2TextBox.Text = CMAN.NumberRow.Cells["rok2"].Value.ToString();

                        if (CMAN.NumberRow.Cells["volumin"].Value != null)
                            WoluminTextBox.Text = CMAN.NumberRow.Cells["volumin"].Value.ToString();

                        if (CMAN.NumberRow.Cells["numer1"].Value != null)
                            NumberTextBox.Text = CMAN.NumberRow.Cells["numer1"].Value.ToString();

                        if (CMAN.NumberRow.Cells["numer2"].Value != null)
                            Number2TextBox.Text = CMAN.NumberRow.Cells["numer2"].Value.ToString();

                        YearTextBox.ReadOnly = true;
                        Year2TextBox.ReadOnly = true;
                        WoluminTextBox.ReadOnly = true;
                        NumberTextBox.ReadOnly = true;
                        Number2TextBox.ReadOnly = true;
                    }
                }
            }
            finally 
            {
                if(WF != null)
                    WF.Close();
            }
        }

        private void ChooseLanguageButton_Click(object sender, EventArgs e)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC ZwrocJezyki;";

            DataGridViewColumn[] Columns = new DataGridViewColumn[2];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "kod";
            Columns[0].Name = "Kod";
            Columns[0].HeaderText = _translationsDictionary.getStringFromDictionary("code", "Kod");

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "jezyk";
            Columns[1].Name = "Język";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("language", "Język");

            ShowForm SF = new ShowForm(Command, Columns);            
            SF.Width = 400;

            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (SF.Dt != null)
                    LanguageTextBox.Text = SF.Dt.Cells["kod"].Value.ToString();
            }
        }

        private void Year2TextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Settings.ReadOnlyMode)
            {
                foreach (char c in Year2TextBox.Text)
                {
                    if (!Char.IsDigit(c) && !Char.IsControl(c))
                    {
                        Year2TextBox.Text = Year2TextBox.Text.Replace(c.ToString(), "");
                        Year2TextBox.SelectionStart = Year2TextBox.Text.Length;
                        return;
                    }
                }
            }
        }

        private void NrodcTextBox_TextChanged(object sender, EventArgs e)
        {
            foreach (char c in NrodcTextBox.Text)
            {
                if (!Char.IsDigit(c) && !Char.IsControl(c))
                {
                    NrodcTextBox.Text = NrodcTextBox.Text.Replace(c.ToString(), "");
                    NrodcTextBox.SelectionStart = NrodcTextBox.Text.Length;
                    return;
                }
            }
        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!Settings.ReadOnlyMode)
            {
                if (YearTextBox.Text.Trim().Length > 0)
                    Year2TextBox.ReadOnly = false;
                else
                {
                    Year2TextBox.ReadOnly = true;
                    Year2TextBox.Text = "";
                }

                foreach (char c in YearTextBox.Text)
                {
                    if (!Char.IsDigit(c) && !Char.IsControl(c))
                    {
                        YearTextBox.Text = YearTextBox.Text.Replace(c.ToString(), "");
                        YearTextBox.SelectionStart = YearTextBox.Text.Length;
                        return;
                    }
                }
            }
        }
        public void LockAll()
        {
            foreach (Control Ctrl in this.Controls)
                if (Ctrl is TextBox)
                    ((TextBox)Ctrl).ReadOnly = true;
                else if (Ctrl is CheckBox)
                    ((CheckBox)Ctrl).Enabled = false;
                else if (Ctrl is RichTextBox)
                    ((RichTextBox)Ctrl).ReadOnly = true;
                else if (Ctrl is CheckBox)
                    ((CheckBox)Ctrl).Enabled = false;
                else if (Ctrl is Button)
                    ((Button)Ctrl).Enabled = false;
                else if (Ctrl is DateTimePicker)
                    ((DateTimePicker)Ctrl).Enabled = false;

            foreach (Control Ctrl in this.groupBox1.Controls)
                if (Ctrl is TextBox)                
                    ((TextBox)Ctrl).ReadOnly = true;                                    
                else if (Ctrl is CheckBox)
                    ((CheckBox)Ctrl).Enabled = false;
                else if (Ctrl is RichTextBox)
                    ((RichTextBox)Ctrl).ReadOnly = true;
                else if (Ctrl is CheckBox)
                    ((CheckBox)Ctrl).Enabled = false;
                else if (Ctrl is Button)
                    ((Button)Ctrl).Enabled = false;
                else if (Ctrl is DateTimePicker)
                    ((DateTimePicker)Ctrl).Enabled = false;

            CleanCountryButton.Visible = false;            
        }

        public void Lock(bool IsMagazine, bool IsNumber)
        {
            if (Settings.ReadOnlyMode)
                return;

            SourceTitleRichTextBox.ReadOnly = IsMagazine;
            SygnaturaTextBox.ReadOnly = IsMagazine;
            YearTextBox.ReadOnly = IsNumber;
            Year2TextBox.ReadOnly = IsNumber;
            WoluminTextBox.ReadOnly = IsNumber;
            NumberTextBox.ReadOnly = IsNumber;
            Number2TextBox.ReadOnly = IsNumber;
        }

        private void CleanCountryButton_Click(object sender, EventArgs e)
        {
            LanguageTextBox.Text = "";
        }
    }
}
