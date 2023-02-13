namespace Artykuly
{
    partial class BookUC
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookUC));
            this.ChooseBookButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SourceTitleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sourceTitleLabel = new System.Windows.Forms.Label();
            this.authorRedactorLabel = new System.Windows.Forms.Label();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.booksAuthorsLabel = new System.Windows.Forms.Label();
            this.BookAuhorsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.publisherLabel = new System.Windows.Forms.Label();
            this.PublisherTextBox = new System.Windows.Forms.TextBox();
            this.publishPlaceLabel = new System.Windows.Forms.Label();
            this.PlaceTextBox = new System.Windows.Forms.TextBox();
            this.publishYearLabel = new System.Windows.Forms.Label();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.signatureLabel = new System.Windows.Forms.Label();
            this.SygnaturaTextBox = new System.Windows.Forms.TextBox();
            this.CleanCountryButton = new System.Windows.Forms.Button();
            this.ChooseLanguageButton = new System.Windows.Forms.Button();
            this.pagesLabel = new System.Windows.Forms.Label();
            this.PagesTextBox = new System.Windows.Forms.TextBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.LanguageTextBox = new System.Windows.Forms.TextBox();
            this.entryDateLabel = new System.Windows.Forms.Label();
            this.DateDTP = new System.Windows.Forms.DateTimePicker();
            this.summariesLabel = new System.Windows.Forms.Label();
            this.RusCheckBox = new System.Windows.Forms.CheckBox();
            this.FraCheckBox = new System.Windows.Forms.CheckBox();
            this.GerCheckBox = new System.Windows.Forms.CheckBox();
            this.EngCheckBox = new System.Windows.Forms.CheckBox();
            this.PolCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChooseBookButton
            // 
            this.ChooseBookButton.Location = new System.Drawing.Point(6, 19);
            this.ChooseBookButton.Name = "ChooseBookButton";
            this.ChooseBookButton.Size = new System.Drawing.Size(363, 23);
            this.ChooseBookButton.TabIndex = 0;
            this.ChooseBookButton.Text = "Kopiuj sygnaturę i tytuł";
            this.ChooseBookButton.UseVisualStyleBackColor = true;
            this.ChooseBookButton.Click += new System.EventHandler(this.ChooseBookButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SourceTitleRichTextBox);
            this.groupBox1.Controls.Add(this.sourceTitleLabel);
            this.groupBox1.Controls.Add(this.authorRedactorLabel);
            this.groupBox1.Controls.Add(this.AuthorTextBox);
            this.groupBox1.Controls.Add(this.booksAuthorsLabel);
            this.groupBox1.Controls.Add(this.BookAuhorsRichTextBox);
            this.groupBox1.Controls.Add(this.publisherLabel);
            this.groupBox1.Controls.Add(this.PublisherTextBox);
            this.groupBox1.Controls.Add(this.publishPlaceLabel);
            this.groupBox1.Controls.Add(this.PlaceTextBox);
            this.groupBox1.Controls.Add(this.publishYearLabel);
            this.groupBox1.Controls.Add(this.YearTextBox);
            this.groupBox1.Controls.Add(this.signatureLabel);
            this.groupBox1.Controls.Add(this.SygnaturaTextBox);
            this.groupBox1.Controls.Add(this.ChooseBookButton);
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(380, 392);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dane książki";
            // 
            // SourceTitleRichTextBox
            // 
            this.SourceTitleRichTextBox.BackColor = System.Drawing.SystemColors.Window;
            this.SourceTitleRichTextBox.Location = new System.Drawing.Point(128, 48);
            this.SourceTitleRichTextBox.MaxLength = 80;
            this.SourceTitleRichTextBox.Name = "SourceTitleRichTextBox";
            this.SourceTitleRichTextBox.Size = new System.Drawing.Size(241, 125);
            this.SourceTitleRichTextBox.TabIndex = 1;
            this.SourceTitleRichTextBox.Text = "";
            // 
            // sourceTitleLabel
            // 
            this.sourceTitleLabel.Location = new System.Drawing.Point(7, 51);
            this.sourceTitleLabel.Name = "sourceTitleLabel";
            this.sourceTitleLabel.Size = new System.Drawing.Size(115, 13);
            this.sourceTitleLabel.TabIndex = 7;
            this.sourceTitleLabel.Text = "Tytuł źródła publikacji:";
            this.sourceTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // authorRedactorLabel
            // 
            this.authorRedactorLabel.Location = new System.Drawing.Point(7, 368);
            this.authorRedactorLabel.Name = "authorRedactorLabel";
            this.authorRedactorLabel.Size = new System.Drawing.Size(115, 13);
            this.authorRedactorLabel.TabIndex = 54;
            this.authorRedactorLabel.Text = "Autor / redaktor:";
            this.authorRedactorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Location = new System.Drawing.Point(128, 365);
            this.AuthorTextBox.MaxLength = 150;
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(241, 20);
            this.AuthorTextBox.TabIndex = 7;
            // 
            // booksAuthorsLabel
            // 
            this.booksAuthorsLabel.Location = new System.Drawing.Point(7, 205);
            this.booksAuthorsLabel.Name = "booksAuthorsLabel";
            this.booksAuthorsLabel.Size = new System.Drawing.Size(115, 13);
            this.booksAuthorsLabel.TabIndex = 22;
            this.booksAuthorsLabel.Text = "Autorzy książki:";
            this.booksAuthorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BookAuhorsRichTextBox
            // 
            this.BookAuhorsRichTextBox.Location = new System.Drawing.Point(128, 205);
            this.BookAuhorsRichTextBox.Name = "BookAuhorsRichTextBox";
            this.BookAuhorsRichTextBox.Size = new System.Drawing.Size(241, 76);
            this.BookAuhorsRichTextBox.TabIndex = 3;
            this.BookAuhorsRichTextBox.Text = "";
            // 
            // publisherLabel
            // 
            this.publisherLabel.Location = new System.Drawing.Point(7, 342);
            this.publisherLabel.Name = "publisherLabel";
            this.publisherLabel.Size = new System.Drawing.Size(115, 13);
            this.publisherLabel.TabIndex = 20;
            this.publisherLabel.Text = "Wydawnictwo:";
            this.publisherLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PublisherTextBox
            // 
            this.PublisherTextBox.Location = new System.Drawing.Point(128, 339);
            this.PublisherTextBox.MaxLength = 120;
            this.PublisherTextBox.Name = "PublisherTextBox";
            this.PublisherTextBox.Size = new System.Drawing.Size(241, 20);
            this.PublisherTextBox.TabIndex = 6;
            // 
            // publishPlaceLabel
            // 
            this.publishPlaceLabel.Location = new System.Drawing.Point(7, 316);
            this.publishPlaceLabel.Name = "publishPlaceLabel";
            this.publishPlaceLabel.Size = new System.Drawing.Size(115, 13);
            this.publishPlaceLabel.TabIndex = 18;
            this.publishPlaceLabel.Text = "Miejsce wydania książki:";
            this.publishPlaceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlaceTextBox
            // 
            this.PlaceTextBox.Location = new System.Drawing.Point(128, 313);
            this.PlaceTextBox.MaxLength = 30;
            this.PlaceTextBox.Name = "PlaceTextBox";
            this.PlaceTextBox.Size = new System.Drawing.Size(241, 20);
            this.PlaceTextBox.TabIndex = 5;
            // 
            // publishYearLabel
            // 
            this.publishYearLabel.Location = new System.Drawing.Point(7, 290);
            this.publishYearLabel.Name = "publishYearLabel";
            this.publishYearLabel.Size = new System.Drawing.Size(115, 13);
            this.publishYearLabel.TabIndex = 16;
            this.publishYearLabel.Text = "Rok wydania:";
            this.publishYearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // YearTextBox
            // 
            this.YearTextBox.Location = new System.Drawing.Point(128, 287);
            this.YearTextBox.MaxLength = 4;
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(37, 20);
            this.YearTextBox.TabIndex = 4;
            this.YearTextBox.TextChanged += new System.EventHandler(this.YearTextBox_TextChanged);
            // 
            // signatureLabel
            // 
            this.signatureLabel.Location = new System.Drawing.Point(7, 182);
            this.signatureLabel.Name = "signatureLabel";
            this.signatureLabel.Size = new System.Drawing.Size(115, 13);
            this.signatureLabel.TabIndex = 15;
            this.signatureLabel.Text = "Sygnatura:";
            this.signatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SygnaturaTextBox
            // 
            this.SygnaturaTextBox.Location = new System.Drawing.Point(128, 179);
            this.SygnaturaTextBox.MaxLength = 20;
            this.SygnaturaTextBox.Name = "SygnaturaTextBox";
            this.SygnaturaTextBox.Size = new System.Drawing.Size(241, 20);
            this.SygnaturaTextBox.TabIndex = 2;
            // 
            // CleanCountryButton
            // 
            this.CleanCountryButton.Image = ((System.Drawing.Image)(resources.GetObject("CleanCountryButton.Image")));
            this.CleanCountryButton.Location = new System.Drawing.Point(220, 422);
            this.CleanCountryButton.Name = "CleanCountryButton";
            this.CleanCountryButton.Size = new System.Drawing.Size(32, 23);
            this.CleanCountryButton.TabIndex = 69;
            this.CleanCountryButton.UseVisualStyleBackColor = true;
            this.CleanCountryButton.Click += new System.EventHandler(this.CleanCountryButton_Click);
            // 
            // ChooseLanguageButton
            // 
            this.ChooseLanguageButton.Image = global::Artykuly.Properties.Resources.lista2;
            this.ChooseLanguageButton.Location = new System.Drawing.Point(182, 422);
            this.ChooseLanguageButton.Name = "ChooseLanguageButton";
            this.ChooseLanguageButton.Size = new System.Drawing.Size(32, 23);
            this.ChooseLanguageButton.TabIndex = 58;
            this.ChooseLanguageButton.UseVisualStyleBackColor = true;
            this.ChooseLanguageButton.Click += new System.EventHandler(this.ChooseLanguageButton_Click);
            // 
            // pagesLabel
            // 
            this.pagesLabel.Location = new System.Drawing.Point(10, 401);
            this.pagesLabel.Name = "pagesLabel";
            this.pagesLabel.Size = new System.Drawing.Size(115, 13);
            this.pagesLabel.TabIndex = 68;
            this.pagesLabel.Text = "Strony:";
            this.pagesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PagesTextBox
            // 
            this.PagesTextBox.Location = new System.Drawing.Point(131, 398);
            this.PagesTextBox.MaxLength = 20;
            this.PagesTextBox.Name = "PagesTextBox";
            this.PagesTextBox.Size = new System.Drawing.Size(241, 20);
            this.PagesTextBox.TabIndex = 56;
            // 
            // languageLabel
            // 
            this.languageLabel.Location = new System.Drawing.Point(10, 427);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(115, 13);
            this.languageLabel.TabIndex = 67;
            this.languageLabel.Text = "Język:";
            this.languageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LanguageTextBox
            // 
            this.LanguageTextBox.Location = new System.Drawing.Point(131, 424);
            this.LanguageTextBox.MaxLength = 3;
            this.LanguageTextBox.Name = "LanguageTextBox";
            this.LanguageTextBox.ReadOnly = true;
            this.LanguageTextBox.Size = new System.Drawing.Size(45, 20);
            this.LanguageTextBox.TabIndex = 57;
            // 
            // entryDateLabel
            // 
            this.entryDateLabel.Location = new System.Drawing.Point(3, 543);
            this.entryDateLabel.Name = "entryDateLabel";
            this.entryDateLabel.Size = new System.Drawing.Size(122, 13);
            this.entryDateLabel.TabIndex = 66;
            this.entryDateLabel.Text = "Data wprowadzenia:";
            this.entryDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DateDTP
            // 
            this.DateDTP.Location = new System.Drawing.Point(131, 541);
            this.DateDTP.Name = "DateDTP";
            this.DateDTP.Size = new System.Drawing.Size(130, 20);
            this.DateDTP.TabIndex = 64;
            // 
            // summariesLabel
            // 
            this.summariesLabel.Location = new System.Drawing.Point(13, 460);
            this.summariesLabel.Name = "summariesLabel";
            this.summariesLabel.Size = new System.Drawing.Size(115, 13);
            this.summariesLabel.TabIndex = 65;
            this.summariesLabel.Text = "Streszczenia:";
            this.summariesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RusCheckBox
            // 
            this.RusCheckBox.Location = new System.Drawing.Point(283, 476);
            this.RusCheckBox.Name = "RusCheckBox";
            this.RusCheckBox.Size = new System.Drawing.Size(87, 17);
            this.RusCheckBox.TabIndex = 61;
            this.RusCheckBox.Text = "w j. rosyjskim";
            this.RusCheckBox.UseVisualStyleBackColor = true;
            // 
            // FraCheckBox
            // 
            this.FraCheckBox.Location = new System.Drawing.Point(181, 499);
            this.FraCheckBox.Name = "FraCheckBox";
            this.FraCheckBox.Size = new System.Drawing.Size(96, 17);
            this.FraCheckBox.TabIndex = 63;
            this.FraCheckBox.Text = "w j. francuskim";
            this.FraCheckBox.UseVisualStyleBackColor = true;
            // 
            // GerCheckBox
            // 
            this.GerCheckBox.Location = new System.Drawing.Point(180, 476);
            this.GerCheckBox.Name = "GerCheckBox";
            this.GerCheckBox.Size = new System.Drawing.Size(97, 17);
            this.GerCheckBox.TabIndex = 60;
            this.GerCheckBox.Text = "w j. niemieckim";
            this.GerCheckBox.UseVisualStyleBackColor = true;
            // 
            // EngCheckBox
            // 
            this.EngCheckBox.Location = new System.Drawing.Point(81, 499);
            this.EngCheckBox.Name = "EngCheckBox";
            this.EngCheckBox.Size = new System.Drawing.Size(94, 17);
            this.EngCheckBox.TabIndex = 62;
            this.EngCheckBox.Text = "w j. angielskim";
            this.EngCheckBox.UseVisualStyleBackColor = true;
            // 
            // PolCheckBox
            // 
            this.PolCheckBox.Location = new System.Drawing.Point(81, 476);
            this.PolCheckBox.Name = "PolCheckBox";
            this.PolCheckBox.Size = new System.Drawing.Size(93, 17);
            this.PolCheckBox.TabIndex = 59;
            this.PolCheckBox.Text = "w j. polskim";
            this.PolCheckBox.UseVisualStyleBackColor = true;
            // 
            // BookUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CleanCountryButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.LanguageTextBox);
            this.Controls.Add(this.ChooseLanguageButton);
            this.Controls.Add(this.PolCheckBox);
            this.Controls.Add(this.EngCheckBox);
            this.Controls.Add(this.pagesLabel);
            this.Controls.Add(this.GerCheckBox);
            this.Controls.Add(this.FraCheckBox);
            this.Controls.Add(this.PagesTextBox);
            this.Controls.Add(this.RusCheckBox);
            this.Controls.Add(this.summariesLabel);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.DateDTP);
            this.Controls.Add(this.entryDateLabel);
            this.Name = "BookUC";
            this.Size = new System.Drawing.Size(390, 565);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ChooseBookButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label booksAuthorsLabel;
        private System.Windows.Forms.RichTextBox BookAuhorsRichTextBox;
        private System.Windows.Forms.Label publisherLabel;
        private System.Windows.Forms.TextBox PublisherTextBox;
        private System.Windows.Forms.Label publishPlaceLabel;
        private System.Windows.Forms.TextBox PlaceTextBox;
        private System.Windows.Forms.Label publishYearLabel;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.Label signatureLabel;
        private System.Windows.Forms.TextBox SygnaturaTextBox;
        private System.Windows.Forms.Label authorRedactorLabel;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.RichTextBox SourceTitleRichTextBox;
        private System.Windows.Forms.Label sourceTitleLabel;
        private System.Windows.Forms.Button CleanCountryButton;
        private System.Windows.Forms.Button ChooseLanguageButton;
        private System.Windows.Forms.Label pagesLabel;
        private System.Windows.Forms.TextBox PagesTextBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.TextBox LanguageTextBox;
        private System.Windows.Forms.Label entryDateLabel;
        private System.Windows.Forms.DateTimePicker DateDTP;
        private System.Windows.Forms.Label summariesLabel;
        private System.Windows.Forms.CheckBox RusCheckBox;
        private System.Windows.Forms.CheckBox FraCheckBox;
        private System.Windows.Forms.CheckBox GerCheckBox;
        private System.Windows.Forms.CheckBox EngCheckBox;
        private System.Windows.Forms.CheckBox PolCheckBox;
    }
}
