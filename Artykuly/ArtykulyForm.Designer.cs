namespace Artykuly
{
    partial class ArtykulyForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArtykulyForm));
            this.articleTitleLabel = new System.Windows.Forms.Label();
            this.authorsLabel = new System.Windows.Forms.Label();
            this.AuthorsDGV = new System.Windows.Forms.DataGridView();
            this.IDAuthorsDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameAuthorsDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FNameAuthorsDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeysDGV = new System.Windows.Forms.DataGridView();
            this.IDKeysDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KeyNameKeysDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.classificationLabel = new System.Windows.Forms.Label();
            this.AuthorNameTextBox = new System.Windows.Forms.TextBox();
            this.AuthorFNameTextBox = new System.Windows.Forms.TextBox();
            this.KeyTextBox = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CommentsTabPage = new System.Windows.Forms.TabPage();
            this.CommentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.StreszczenieTabPage = new System.Windows.Forms.TabPage();
            this.StreszczenieRichTextBox = new System.Windows.Forms.RichTextBox();
            this.FullTabPage = new System.Windows.Forms.TabPage();
            this.FullArtRichTextBox = new System.Windows.Forms.RichTextBox();
            this.TitleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SourcesButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.AddKeyButton = new System.Windows.Forms.Button();
            this.AddAuthorButton = new System.Windows.Forms.Button();
            this.ChooseKeyButton = new System.Windows.Forms.Button();
            this.ChooseAuthorsButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeleteAuthorButton = new System.Windows.Forms.Button();
            this.DeleteKeyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AuthorsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeysDGV)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.CommentsTabPage.SuspendLayout();
            this.StreszczenieTabPage.SuspendLayout();
            this.FullTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // articleTitleLabel
            // 
            this.articleTitleLabel.AutoSize = true;
            this.articleTitleLabel.Location = new System.Drawing.Point(12, 9);
            this.articleTitleLabel.Name = "articleTitleLabel";
            this.articleTitleLabel.Size = new System.Drawing.Size(74, 13);
            this.articleTitleLabel.TabIndex = 1;
            this.articleTitleLabel.Text = "Tytuł artykułu";
            // 
            // authorsLabel
            // 
            this.authorsLabel.AutoSize = true;
            this.authorsLabel.Location = new System.Drawing.Point(12, 114);
            this.authorsLabel.Name = "authorsLabel";
            this.authorsLabel.Size = new System.Drawing.Size(42, 13);
            this.authorsLabel.TabIndex = 2;
            this.authorsLabel.Text = "Autorzy";
            // 
            // AuthorsDGV
            // 
            this.AuthorsDGV.AllowUserToAddRows = false;
            this.AuthorsDGV.AllowUserToDeleteRows = false;
            this.AuthorsDGV.AllowUserToResizeRows = false;
            this.AuthorsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuthorsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDAuthorsDGV,
            this.NameAuthorsDGV,
            this.FNameAuthorsDGV});
            this.AuthorsDGV.Location = new System.Drawing.Point(12, 130);
            this.AuthorsDGV.MultiSelect = false;
            this.AuthorsDGV.Name = "AuthorsDGV";
            this.AuthorsDGV.ReadOnly = true;
            this.AuthorsDGV.RowHeadersVisible = false;
            this.AuthorsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AuthorsDGV.Size = new System.Drawing.Size(398, 102);
            this.AuthorsDGV.TabIndex = 3;
            this.AuthorsDGV.SelectionChanged += new System.EventHandler(this.AuthorsDGV_SelectionChanged);
            // 
            // IDAuthorsDGV
            // 
            this.IDAuthorsDGV.DataPropertyName = "id_aut";
            this.IDAuthorsDGV.HeaderText = "id";
            this.IDAuthorsDGV.Name = "IDAuthorsDGV";
            this.IDAuthorsDGV.ReadOnly = true;
            this.IDAuthorsDGV.Visible = false;
            // 
            // NameAuthorsDGV
            // 
            this.NameAuthorsDGV.DataPropertyName = "nazwisko";
            this.NameAuthorsDGV.HeaderText = "Nazwisko";
            this.NameAuthorsDGV.Name = "NameAuthorsDGV";
            this.NameAuthorsDGV.ReadOnly = true;
            // 
            // FNameAuthorsDGV
            // 
            this.FNameAuthorsDGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FNameAuthorsDGV.DataPropertyName = "imie";
            this.FNameAuthorsDGV.HeaderText = "Imię";
            this.FNameAuthorsDGV.Name = "FNameAuthorsDGV";
            this.FNameAuthorsDGV.ReadOnly = true;
            // 
            // KeysDGV
            // 
            this.KeysDGV.AllowUserToAddRows = false;
            this.KeysDGV.AllowUserToDeleteRows = false;
            this.KeysDGV.AllowUserToResizeRows = false;
            this.KeysDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.KeysDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KeysDGV.ColumnHeadersVisible = false;
            this.KeysDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDKeysDGV,
            this.KeyNameKeysDGV});
            this.KeysDGV.Location = new System.Drawing.Point(12, 279);
            this.KeysDGV.MultiSelect = false;
            this.KeysDGV.Name = "KeysDGV";
            this.KeysDGV.ReadOnly = true;
            this.KeysDGV.RowHeadersVisible = false;
            this.KeysDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.KeysDGV.Size = new System.Drawing.Size(398, 121);
            this.KeysDGV.TabIndex = 6;
            this.KeysDGV.SelectionChanged += new System.EventHandler(this.KeysDGV_SelectionChanged);
            // 
            // IDKeysDGV
            // 
            this.IDKeysDGV.DataPropertyName = "kody";
            this.IDKeysDGV.HeaderText = "id";
            this.IDKeysDGV.Name = "IDKeysDGV";
            this.IDKeysDGV.ReadOnly = true;
            this.IDKeysDGV.Visible = false;
            // 
            // KeyNameKeysDGV
            // 
            this.KeyNameKeysDGV.DataPropertyName = "klucze";
            this.KeyNameKeysDGV.HeaderText = "Column1";
            this.KeyNameKeysDGV.Name = "KeyNameKeysDGV";
            this.KeyNameKeysDGV.ReadOnly = true;
            // 
            // classificationLabel
            // 
            this.classificationLabel.AutoSize = true;
            this.classificationLabel.Location = new System.Drawing.Point(12, 263);
            this.classificationLabel.Name = "classificationLabel";
            this.classificationLabel.Size = new System.Drawing.Size(111, 13);
            this.classificationLabel.TabIndex = 5;
            this.classificationLabel.Text = "Klasyfikacja rzeczowa";
            // 
            // AuthorNameTextBox
            // 
            this.AuthorNameTextBox.Location = new System.Drawing.Point(12, 238);
            this.AuthorNameTextBox.MaxLength = 100;
            this.AuthorNameTextBox.Name = "AuthorNameTextBox";
            this.AuthorNameTextBox.Size = new System.Drawing.Size(206, 20);
            this.AuthorNameTextBox.TabIndex = 2;
            this.AuthorNameTextBox.TextChanged += new System.EventHandler(this.CheckNameOrFNameIsNotEmpty);
            this.AuthorNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameTextBox_KeyDown);
            // 
            // AuthorFNameTextBox
            // 
            this.AuthorFNameTextBox.Location = new System.Drawing.Point(224, 238);
            this.AuthorFNameTextBox.MaxLength = 50;
            this.AuthorFNameTextBox.Name = "AuthorFNameTextBox";
            this.AuthorFNameTextBox.Size = new System.Drawing.Size(186, 20);
            this.AuthorFNameTextBox.TabIndex = 3;
            this.AuthorFNameTextBox.TextChanged += new System.EventHandler(this.CheckNameOrFNameIsNotEmpty);
            this.AuthorFNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FNameTextBox_KeyDown);
            // 
            // KeyTextBox
            // 
            this.KeyTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.KeyTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.KeyTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.KeyTextBox.Location = new System.Drawing.Point(12, 406);
            this.KeyTextBox.MaxLength = 120;
            this.KeyTextBox.Name = "KeyTextBox";
            this.KeyTextBox.Size = new System.Drawing.Size(398, 20);
            this.KeyTextBox.TabIndex = 6;
            this.KeyTextBox.TextChanged += new System.EventHandler(this.KeyTextBox_TextChanged);
            this.KeyTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyTextBox_KeyDown);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.CommentsTabPage);
            this.tabControl1.Controls.Add(this.StreszczenieTabPage);
            this.tabControl1.Controls.Add(this.FullTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 436);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(398, 144);
            this.tabControl1.TabIndex = 8;
            // 
            // CommentsTabPage
            // 
            this.CommentsTabPage.Controls.Add(this.CommentsRichTextBox);
            this.CommentsTabPage.Location = new System.Drawing.Point(4, 22);
            this.CommentsTabPage.Name = "CommentsTabPage";
            this.CommentsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.CommentsTabPage.Size = new System.Drawing.Size(390, 118);
            this.CommentsTabPage.TabIndex = 0;
            this.CommentsTabPage.Text = "Uwagi";
            this.CommentsTabPage.UseVisualStyleBackColor = true;
            // 
            // CommentsRichTextBox
            // 
            this.CommentsRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CommentsRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.CommentsRichTextBox.MaxLength = 4000;
            this.CommentsRichTextBox.Name = "CommentsRichTextBox";
            this.CommentsRichTextBox.Size = new System.Drawing.Size(384, 112);
            this.CommentsRichTextBox.TabIndex = 0;
            this.CommentsRichTextBox.Text = "";
            // 
            // StreszczenieTabPage
            // 
            this.StreszczenieTabPage.Controls.Add(this.StreszczenieRichTextBox);
            this.StreszczenieTabPage.Location = new System.Drawing.Point(4, 22);
            this.StreszczenieTabPage.Name = "StreszczenieTabPage";
            this.StreszczenieTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.StreszczenieTabPage.Size = new System.Drawing.Size(390, 118);
            this.StreszczenieTabPage.TabIndex = 1;
            this.StreszczenieTabPage.Text = "Streszczenie";
            this.StreszczenieTabPage.UseVisualStyleBackColor = true;
            // 
            // StreszczenieRichTextBox
            // 
            this.StreszczenieRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.StreszczenieRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.StreszczenieRichTextBox.MaxLength = 4000;
            this.StreszczenieRichTextBox.Name = "StreszczenieRichTextBox";
            this.StreszczenieRichTextBox.Size = new System.Drawing.Size(384, 112);
            this.StreszczenieRichTextBox.TabIndex = 1;
            this.StreszczenieRichTextBox.Text = "";
            // 
            // FullTabPage
            // 
            this.FullTabPage.Controls.Add(this.FullArtRichTextBox);
            this.FullTabPage.Location = new System.Drawing.Point(4, 22);
            this.FullTabPage.Name = "FullTabPage";
            this.FullTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.FullTabPage.Size = new System.Drawing.Size(390, 118);
            this.FullTabPage.TabIndex = 2;
            this.FullTabPage.Text = "Pełny artykuł";
            this.FullTabPage.UseVisualStyleBackColor = true;
            // 
            // FullArtRichTextBox
            // 
            this.FullArtRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FullArtRichTextBox.Location = new System.Drawing.Point(3, 3);
            this.FullArtRichTextBox.MaxLength = 10000;
            this.FullArtRichTextBox.Name = "FullArtRichTextBox";
            this.FullArtRichTextBox.Size = new System.Drawing.Size(384, 112);
            this.FullArtRichTextBox.TabIndex = 2;
            this.FullArtRichTextBox.Text = "";
            // 
            // TitleRichTextBox
            // 
            this.TitleRichTextBox.Location = new System.Drawing.Point(12, 25);
            this.TitleRichTextBox.MaxLength = 201;
            this.TitleRichTextBox.Name = "TitleRichTextBox";
            this.TitleRichTextBox.Size = new System.Drawing.Size(398, 77);
            this.TitleRichTextBox.TabIndex = 0;
            this.TitleRichTextBox.Text = "";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Location = new System.Drawing.Point(726, 593);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 14;
            this.DeleteButton.Text = "Usuń";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = global::Artykuly.Properties.Resources.door_out;
            this.EscapeButton.Location = new System.Drawing.Point(807, 593);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(75, 23);
            this.EscapeButton.TabIndex = 15;
            this.EscapeButton.Text = "Wyjście";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Image = global::Artykuly.Properties.Resources.lupka;
            this.SearchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchButton.Location = new System.Drawing.Point(645, 593);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 13;
            this.SearchButton.Text = "Wyszukaj";
            this.SearchButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Visible = false;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Image = global::Artykuly.Properties.Resources.save;
            this.SaveButton.Location = new System.Drawing.Point(564, 593);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 12;
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SourcesButton
            // 
            this.SourcesButton.Image = global::Artykuly.Properties.Resources.attachsmall1;
            this.SourcesButton.Location = new System.Drawing.Point(107, 593);
            this.SourcesButton.Name = "SourcesButton";
            this.SourcesButton.Size = new System.Drawing.Size(75, 23);
            this.SourcesButton.TabIndex = 11;
            this.SourcesButton.Text = "Źródła";
            this.SourcesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SourcesButton.UseVisualStyleBackColor = true;
            this.SourcesButton.Click += new System.EventHandler(this.SourcesButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Image = global::Artykuly.Properties.Resources.print_printer;
            this.PrintButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrintButton.Location = new System.Drawing.Point(12, 593);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(89, 23);
            this.PrintButton.TabIndex = 10;
            this.PrintButton.Text = "Drukowanie";
            this.PrintButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Visible = false;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // AddKeyButton
            // 
            this.AddKeyButton.Enabled = false;
            this.AddKeyButton.Image = global::Artykuly.Properties.Resources.edit_add;
            this.AddKeyButton.Location = new System.Drawing.Point(416, 404);
            this.AddKeyButton.Name = "AddKeyButton";
            this.AddKeyButton.Size = new System.Drawing.Size(32, 23);
            this.AddKeyButton.TabIndex = 7;
            this.AddKeyButton.UseVisualStyleBackColor = true;
            this.AddKeyButton.Click += new System.EventHandler(this.AddKeyButton_Click);
            // 
            // AddAuthorButton
            // 
            this.AddAuthorButton.Enabled = false;
            this.AddAuthorButton.Image = global::Artykuly.Properties.Resources.edit_add;
            this.AddAuthorButton.Location = new System.Drawing.Point(416, 238);
            this.AddAuthorButton.Name = "AddAuthorButton";
            this.AddAuthorButton.Size = new System.Drawing.Size(32, 23);
            this.AddAuthorButton.TabIndex = 4;
            this.AddAuthorButton.UseVisualStyleBackColor = true;
            this.AddAuthorButton.Click += new System.EventHandler(this.AddAuthorButton_Click);
            // 
            // ChooseKeyButton
            // 
            this.ChooseKeyButton.Image = global::Artykuly.Properties.Resources.lista2;
            this.ChooseKeyButton.Location = new System.Drawing.Point(416, 279);
            this.ChooseKeyButton.Name = "ChooseKeyButton";
            this.ChooseKeyButton.Size = new System.Drawing.Size(32, 23);
            this.ChooseKeyButton.TabIndex = 5;
            this.ChooseKeyButton.UseVisualStyleBackColor = true;
            this.ChooseKeyButton.Click += new System.EventHandler(this.ChooseKeyButton_Click);
            // 
            // ChooseAuthorsButton
            // 
            this.ChooseAuthorsButton.Image = global::Artykuly.Properties.Resources.lista2;
            this.ChooseAuthorsButton.Location = new System.Drawing.Point(416, 130);
            this.ChooseAuthorsButton.Name = "ChooseAuthorsButton";
            this.ChooseAuthorsButton.Size = new System.Drawing.Size(32, 23);
            this.ChooseAuthorsButton.TabIndex = 1;
            this.ChooseAuthorsButton.UseVisualStyleBackColor = true;
            this.ChooseAuthorsButton.Click += new System.EventHandler(this.ChooseAuthorsButton_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(492, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 565);
            this.panel1.TabIndex = 9;
            // 
            // DeleteAuthorButton
            // 
            this.DeleteAuthorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeleteAuthorButton.Enabled = false;
            this.DeleteAuthorButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteAuthorButton.Image")));
            this.DeleteAuthorButton.Location = new System.Drawing.Point(454, 238);
            this.DeleteAuthorButton.Name = "DeleteAuthorButton";
            this.DeleteAuthorButton.Size = new System.Drawing.Size(32, 23);
            this.DeleteAuthorButton.TabIndex = 16;
            this.DeleteAuthorButton.UseVisualStyleBackColor = true;
            this.DeleteAuthorButton.Click += new System.EventHandler(this.DeleteAuthorButton_Click);
            // 
            // DeleteKeyButton
            // 
            this.DeleteKeyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeleteKeyButton.Enabled = false;
            this.DeleteKeyButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteKeyButton.Image")));
            this.DeleteKeyButton.Location = new System.Drawing.Point(454, 404);
            this.DeleteKeyButton.Name = "DeleteKeyButton";
            this.DeleteKeyButton.Size = new System.Drawing.Size(32, 23);
            this.DeleteKeyButton.TabIndex = 17;
            this.DeleteKeyButton.UseVisualStyleBackColor = true;
            this.DeleteKeyButton.Click += new System.EventHandler(this.DeleteKeyButton_Click);
            // 
            // ArtykulyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 620);
            this.Controls.Add(this.DeleteKeyButton);
            this.Controls.Add(this.DeleteAuthorButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SourcesButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.TitleRichTextBox);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.AddKeyButton);
            this.Controls.Add(this.AddAuthorButton);
            this.Controls.Add(this.KeyTextBox);
            this.Controls.Add(this.AuthorFNameTextBox);
            this.Controls.Add(this.AuthorNameTextBox);
            this.Controls.Add(this.ChooseKeyButton);
            this.Controls.Add(this.KeysDGV);
            this.Controls.Add(this.classificationLabel);
            this.Controls.Add(this.ChooseAuthorsButton);
            this.Controls.Add(this.AuthorsDGV);
            this.Controls.Add(this.authorsLabel);
            this.Controls.Add(this.articleTitleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ArtykulyForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Artykuły";
            this.Activated += new System.EventHandler(this.ArtykulyForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ArtykulyForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ArtykulyForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.AuthorsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.KeysDGV)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.CommentsTabPage.ResumeLayout(false);
            this.StreszczenieTabPage.ResumeLayout(false);
            this.FullTabPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label articleTitleLabel;
        private System.Windows.Forms.Label authorsLabel;
        private System.Windows.Forms.DataGridView AuthorsDGV;
        private System.Windows.Forms.Button ChooseAuthorsButton;
        private System.Windows.Forms.Button ChooseKeyButton;
        private System.Windows.Forms.DataGridView KeysDGV;
        private System.Windows.Forms.Label classificationLabel;
        private System.Windows.Forms.TextBox AuthorNameTextBox;
        private System.Windows.Forms.TextBox AuthorFNameTextBox;
        private System.Windows.Forms.TextBox KeyTextBox;
        private System.Windows.Forms.Button AddAuthorButton;
        private System.Windows.Forms.Button AddKeyButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CommentsTabPage;
        private System.Windows.Forms.TabPage StreszczenieTabPage;
        private System.Windows.Forms.RichTextBox CommentsRichTextBox;
        private System.Windows.Forms.RichTextBox StreszczenieRichTextBox;
        private System.Windows.Forms.RichTextBox TitleRichTextBox;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button SourcesButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TabPage FullTabPage;
        private System.Windows.Forms.RichTextBox FullArtRichTextBox;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDAuthorsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameAuthorsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNameAuthorsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDKeysDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn KeyNameKeysDGV;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DeleteAuthorButton;
        private System.Windows.Forms.Button DeleteKeyButton;
    }
}

