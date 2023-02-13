using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Artykuly
{
    public partial class BookUC : UserControl
    {
        private string ID;
        public string IDValue
        {
            get
            {
                return ID;
            }
            set
            {
                ID = value;
            }
        }
        public string SourceTitleRichTextBoxValue
        {
            get
            {
                return SourceTitleRichTextBox.Text;
            }
            set
            {
                SourceTitleRichTextBox.Text = value;
            }
        }
        public string BookAuhorsRichTextBoxValue
        {
            get
            {
                return BookAuhorsRichTextBox.Text;
            }
            set
            {
                BookAuhorsRichTextBox.Text = value;
            }
        }
        public bool BookAuhorsRichTextBoxReadOnly
        {
            get
            {
                return BookAuhorsRichTextBox.ReadOnly;
            }
            set
            {
                BookAuhorsRichTextBox.ReadOnly = value;
                
                if (value)
                    BookAuhorsRichTextBox.BackColor = Color.FromArgb(SystemColors.Control.ToArgb());
            }
        }
        public string SygnaturaTextBoxValue
        {
            get
            {
                return SygnaturaTextBox.Text;
            }
            set
            {
                SygnaturaTextBox.Text = value;
            }
        }
        public string YearTextBoxValue
        {
            get
            {
                return YearTextBox.Text;
            }
            set
            {
                YearTextBox.Text = value;
            }
        }
        public string PlaceTextBoxValue
        {
            get
            {
                return PlaceTextBox.Text;
            }
            set
            {
                PlaceTextBox.Text = value;
            }
        }
        public string AuthorTextBoxValue
        {
            get
            {
                return AuthorTextBox.Text;
            }
            set
            {
                AuthorTextBox.Text = value;
            }
        }
        public string PagesTextBoxValue
        {
            get
            {
                return PagesTextBox.Text;
            }
            set
            {
                PagesTextBox.Text = value;
            }
        }
        public string LanguageTextBoxValue
        {
            get
            {
                return LanguageTextBox.Text;
            }
            set
            {
                LanguageTextBox.Text = value;
            }
        }
        public string PublisherTextBoxValue
        {
            get
            {
                return PublisherTextBox.Text;
            }
            set
            {
                PublisherTextBox.Text = value;
            }
        }
        public bool PolCheckBoxValue
        {
            get
            {
                return PolCheckBox.Checked;
            }
            set
            {
                PolCheckBox.Checked = value;
            }
        }
        public bool EngCheckBoxValue
        {
            get
            {
                return EngCheckBox.Checked;
            }
            set
            {
                EngCheckBox.Checked = value;
            }
        }
        public bool GerCheckBoxValue
        {
            get
            {
                return GerCheckBox.Checked;
            }
            set
            {
                GerCheckBox.Checked = value;
            }
        }
        public bool FraCheckBoxValue
        {
            get
            {
                return FraCheckBox.Checked;
            }
            set
            {
                FraCheckBox.Checked = value;
            }
        }
        public bool RusCheckBoxValue
        {
            get
            {
                return RusCheckBox.Checked;
            }
            set
            {
                RusCheckBox.Checked = value;
            }
        }
        public DateTime DateDTPValue
        {
            get
            {
                return DateDTP.Value;
            }
            set
            {
                DateDTP.Value = value;
            }
        }

        private Dictionary<string, string> _translationsDictionary;
        public BookUC()
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

            mapping.Add(groupBox1, "book_data");

            mapping.Add(ChooseBookButton, "copy_signature_and_title");
            mapping.Add(sourceTitleLabel, "title_of_publication_source");
            mapping.Add(signatureLabel, "signature");
            mapping.Add(booksAuthorsLabel, "book_authors");
            mapping.Add(publishYearLabel, "publish_year");
            mapping.Add(publishPlaceLabel, "place_of_publication");
            mapping.Add(publisherLabel, "publisher");
            mapping.Add(authorRedactorLabel, "author_redactor");
            mapping.Add(pagesLabel, "pages");
            mapping.Add(languageLabel, "language");

            mapping.Add(summariesLabel, "summaries");
            mapping.Add(PolCheckBox, "in_polish");
            mapping.Add(GerCheckBox, "in_german");
            mapping.Add(RusCheckBox, "in_russian");
            mapping.Add(EngCheckBox, "in_english");
            mapping.Add(FraCheckBox, "in_french");
            mapping.Add(entryDateLabel, "data_of_entry");            

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
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

        public void Lock(bool IsSource)
        {
            if (Settings.ReadOnlyMode)
                return;

            if (IsSource)
            {
                SourceTitleRichTextBox.ReadOnly = true;

                PublisherTextBox.ReadOnly = true;
                SygnaturaTextBox.ReadOnly = true;
                YearTextBox.ReadOnly = true;
                PlaceTextBox.ReadOnly = true;
                SourceTitleRichTextBox.BackColor = Color.FromArgb(BookAuhorsRichTextBox.BackColor.ToArgb());
            }
        }

        //WYCZYSZCZENIE PÓL
        public void Clear()
        {
            this.SourceTitleRichTextBoxValue = "";
            this.SygnaturaTextBoxValue = "";
            this.BookAuhorsRichTextBoxValue = "";
            this.YearTextBoxValue = "";
            this.AuthorTextBoxValue = "";
            this.PlaceTextBoxValue = "";
            this.PublisherTextBoxValue = "";
            this.PagesTextBoxValue = "";
            this.LanguageTextBoxValue = "";
            this.PublisherTextBoxValue = "";
            this.PolCheckBoxValue = false;
            this.EngCheckBoxValue = false;
            this.FraCheckBoxValue = false;
            this.GerCheckBoxValue = false;
            this.RusCheckBoxValue = false;
            this.DateDTPValue = DateTime.Now;
        }

        private void ChooseBookButton_Click(object sender, EventArgs e)
        {
            WaitForm WF = new WaitForm();

            this.Invoke((MethodInvoker)delegate
            {
                WF.Show(this);
                WF.Update();
            });

            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC ZwrocListeKsiazek @id_rodzaj, @sort;";
            Command.Parameters.AddWithValue("@id_rodzaj", Settings.ID_rodzaj);
            Command.Parameters.AddWithValue("@sort", 1);

            DataGridViewColumn[] Columns = new DataGridViewColumn[3];
            Columns[0] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[0].DataPropertyName = "tytul_gl";
            Columns[0].Name = "tytul_gl";
            Columns[0].HeaderText = _translationsDictionary.getStringFromDictionary("book_title", "Tytuł książki");
            Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Columns[1] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[1].DataPropertyName = "syg";
            Columns[1].Name = "syg";
            Columns[1].HeaderText = _translationsDictionary.getStringFromDictionary("signature", "Sygnatura");
            Columns[1].Width = 150;
            Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            Columns[2] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[2].DataPropertyName = "kod";
            Columns[2].Name = "kod";
            Columns[2].Visible = false;
            Columns[2].Width = 0;

            /*Columns[3] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[3].DataPropertyName = "wydawca";
            Columns[3].Name = "wydawca";
            Columns[3].Visible = false;
            Columns[3].Width = 0;

            Columns[4] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[4].DataPropertyName = "miasto_w";
            Columns[4].Name = "miasto_w";
            Columns[4].Visible = false;
            Columns[4].Width = 0;

            Columns[5] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[5].DataPropertyName = "rok_wyd";
            Columns[5].Name = "rok_wyd";
            Columns[5].Visible = false;
            Columns[5].Width = 0;

            Columns[6] = new DataGridViewColumn(new DataGridViewTextBoxCell());
            Columns[6].DataPropertyName = "autorzy";
            Columns[6].Name = "autorzy";
            Columns[6].Visible = false;
            Columns[6].Width = 0;*/

            ShowForm SF = new ShowForm(Command, Columns);
            SF.ShowRadioButtons();

            WF.Close();

            if (SF.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (SF.Dt != null)
                {
                    Clear();

                    ID = SF.Dt.Cells["kod"].Value.ToString();  

                    Command = new SqlCommand();
                    Command.Parameters.Clear();
                    Command.CommandText = "EXEC Artykuly_InformacjeOKsiazce @kod; ";
                    Command.Parameters.AddWithValue("@kod", ID);

                    DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                    if (Dt.Rows.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(Dt.Rows[0]["wydawca"].ToString()))
                            PublisherTextBoxValue = Dt.Rows[0]["wydawca"].ToString();

                        if (!string.IsNullOrEmpty(Dt.Rows[0]["miasto_w"].ToString()))
                            PlaceTextBoxValue = Dt.Rows[0]["miasto_w"].ToString();

                        if (!string.IsNullOrEmpty(Dt.Rows[0]["rok_wyd"].ToString()))
                            YearTextBoxValue = Dt.Rows[0]["rok_wyd"].ToString();

                        if (!string.IsNullOrEmpty(Dt.Rows[0]["tytul_gl"].ToString()))
                            SourceTitleRichTextBoxValue = Dt.Rows[0]["tytul_gl"].ToString();

                        if (!string.IsNullOrEmpty(Dt.Rows[0]["syg"].ToString()))
                            SygnaturaTextBoxValue = Dt.Rows[0]["syg"].ToString();

                        if (!string.IsNullOrEmpty(Dt.Rows[0]["autorzy"].ToString()))
                            BookAuhorsRichTextBoxValue = Dt.Rows[0]["autorzy"].ToString();

                        BookAuhorsRichTextBoxReadOnly = true;  
                    }

                    SourceTitleRichTextBox.ReadOnly = true;
                    
                    SygnaturaTextBox.ReadOnly = true;
                    YearTextBox.ReadOnly = true;
                    PlaceTextBox.ReadOnly = true;
                    SourceTitleRichTextBox.BackColor = Color.FromArgb(BookAuhorsRichTextBox.BackColor.ToArgb());
                    PublisherTextBox.ReadOnly = true;
                }
            }
        }

        private void YearTextBox_TextChanged(object sender, EventArgs e)
        {            
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

        private void CleanCountryButton_Click(object sender, EventArgs e)
        {
            LanguageTextBox.Text = "";
        }
    }
}
