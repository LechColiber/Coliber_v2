namespace Ubytki
{
    partial class UbytkiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UbytkiForm));
            this.UbytkiDGV = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SygDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumInwDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signatureLabel = new System.Windows.Forms.Label();
            this.SygnaturaTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.NumerInwTextBox = new System.Windows.Forms.TextBox();
            this.invertoryNumberLabel = new System.Windows.Forms.Label();
            this.NumbersTextBox = new System.Windows.Forms.TextBox();
            this.NumbersLabel = new System.Windows.Forms.Label();
            this.NrKsiegiTextBox = new System.Windows.Forms.TextBox();
            this.lossesBookNumberLabel = new System.Windows.Forms.Label();
            this.DateDTP = new System.Windows.Forms.DateTimePicker();
            this.entryDateLabel = new System.Windows.Forms.Label();
            this.TitleRichTextBox = new System.Windows.Forms.RichTextBox();
            this.CommentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.NumerDowoduTextBox = new System.Windows.Forms.TextBox();
            this.lossDocumentNumberLabel = new System.Windows.Forms.Label();
            this.WykrComboBox = new System.Windows.Forms.ComboBox();
            this.reasonLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.WoluminTextBox = new System.Windows.Forms.TextBox();
            this.WoluminLabel = new System.Windows.Forms.Label();
            this.PriceTextBox = new System.Windows.Forms.TextBox();
            this.startDateSearchDTP = new System.Windows.Forms.DateTimePicker();
            this.NumerInwSearchTextBox = new System.Windows.Forms.TextBox();
            this.invertoryNumberSearchLabel = new System.Windows.Forms.Label();
            this.titleSearchLabel = new System.Windows.Forms.Label();
            this.SygSearchTextBox = new System.Windows.Forms.TextBox();
            this.signatureSearchLabel = new System.Windows.Forms.Label();
            this.TitleSearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchCheckBox = new System.Windows.Forms.CheckBox();
            this.CleanSearchButton = new System.Windows.Forms.Button();
            this.PreviousSearchButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.NextSearchButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.YearLabel = new System.Windows.Forms.Label();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.endDateSearchDTP = new System.Windows.Forms.DateTimePicker();
            this.sinceDateLabel = new System.Windows.Forms.Label();
            this.toDateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UbytkiDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // UbytkiDGV
            // 
            this.UbytkiDGV.AllowUserToAddRows = false;
            this.UbytkiDGV.AllowUserToDeleteRows = false;
            this.UbytkiDGV.AllowUserToResizeRows = false;
            this.UbytkiDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.UbytkiDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UbytkiDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.TitleDGV,
            this.SygDGV,
            this.NumInwDGV,
            this.DateDGV});
            resources.ApplyResources(this.UbytkiDGV, "UbytkiDGV");
            this.UbytkiDGV.MultiSelect = false;
            this.UbytkiDGV.Name = "UbytkiDGV";
            this.UbytkiDGV.ReadOnly = true;
            this.UbytkiDGV.RowHeadersVisible = false;
            this.UbytkiDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UbytkiDGV.TabStop = false;
            this.UbytkiDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.UbytkiDGV_ColumnHeaderMouseClick);
            this.UbytkiDGV.SelectionChanged += new System.EventHandler(this.UbytkiDGV_SelectionChanged);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            resources.ApplyResources(this.id, "id");
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // TitleDGV
            // 
            this.TitleDGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TitleDGV.DataPropertyName = "tytul";
            resources.ApplyResources(this.TitleDGV, "TitleDGV");
            this.TitleDGV.Name = "TitleDGV";
            this.TitleDGV.ReadOnly = true;
            this.TitleDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // SygDGV
            // 
            this.SygDGV.DataPropertyName = "syg";
            resources.ApplyResources(this.SygDGV, "SygDGV");
            this.SygDGV.Name = "SygDGV";
            this.SygDGV.ReadOnly = true;
            this.SygDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // NumInwDGV
            // 
            this.NumInwDGV.DataPropertyName = "numer_inw";
            resources.ApplyResources(this.NumInwDGV, "NumInwDGV");
            this.NumInwDGV.Name = "NumInwDGV";
            this.NumInwDGV.ReadOnly = true;
            this.NumInwDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // DateDGV
            // 
            this.DateDGV.DataPropertyName = "data_ubyt";
            resources.ApplyResources(this.DateDGV, "DateDGV");
            this.DateDGV.Name = "DateDGV";
            this.DateDGV.ReadOnly = true;
            // 
            // signatureLabel
            // 
            resources.ApplyResources(this.signatureLabel, "signatureLabel");
            this.signatureLabel.Name = "signatureLabel";
            // 
            // SygnaturaTextBox
            // 
            resources.ApplyResources(this.SygnaturaTextBox, "SygnaturaTextBox");
            this.SygnaturaTextBox.Name = "SygnaturaTextBox";
            // 
            // titleLabel
            // 
            resources.ApplyResources(this.titleLabel, "titleLabel");
            this.titleLabel.Name = "titleLabel";
            // 
            // NumerInwTextBox
            // 
            resources.ApplyResources(this.NumerInwTextBox, "NumerInwTextBox");
            this.NumerInwTextBox.Name = "NumerInwTextBox";
            // 
            // invertoryNumberLabel
            // 
            resources.ApplyResources(this.invertoryNumberLabel, "invertoryNumberLabel");
            this.invertoryNumberLabel.Name = "invertoryNumberLabel";
            // 
            // NumbersTextBox
            // 
            resources.ApplyResources(this.NumbersTextBox, "NumbersTextBox");
            this.NumbersTextBox.Name = "NumbersTextBox";
            // 
            // NumbersLabel
            // 
            resources.ApplyResources(this.NumbersLabel, "NumbersLabel");
            this.NumbersLabel.Name = "NumbersLabel";
            // 
            // NrKsiegiTextBox
            // 
            resources.ApplyResources(this.NrKsiegiTextBox, "NrKsiegiTextBox");
            this.NrKsiegiTextBox.Name = "NrKsiegiTextBox";
            // 
            // lossesBookNumberLabel
            // 
            resources.ApplyResources(this.lossesBookNumberLabel, "lossesBookNumberLabel");
            this.lossesBookNumberLabel.Name = "lossesBookNumberLabel";
            // 
            // DateDTP
            // 
            resources.ApplyResources(this.DateDTP, "DateDTP");
            this.DateDTP.Name = "DateDTP";
            // 
            // entryDateLabel
            // 
            resources.ApplyResources(this.entryDateLabel, "entryDateLabel");
            this.entryDateLabel.Name = "entryDateLabel";
            // 
            // TitleRichTextBox
            // 
            resources.ApplyResources(this.TitleRichTextBox, "TitleRichTextBox");
            this.TitleRichTextBox.Name = "TitleRichTextBox";
            // 
            // CommentsRichTextBox
            // 
            resources.ApplyResources(this.CommentsRichTextBox, "CommentsRichTextBox");
            this.CommentsRichTextBox.Name = "CommentsRichTextBox";
            // 
            // commentsLabel
            // 
            resources.ApplyResources(this.commentsLabel, "commentsLabel");
            this.commentsLabel.Name = "commentsLabel";
            // 
            // NumerDowoduTextBox
            // 
            resources.ApplyResources(this.NumerDowoduTextBox, "NumerDowoduTextBox");
            this.NumerDowoduTextBox.Name = "NumerDowoduTextBox";
            // 
            // lossDocumentNumberLabel
            // 
            resources.ApplyResources(this.lossDocumentNumberLabel, "lossDocumentNumberLabel");
            this.lossDocumentNumberLabel.Name = "lossDocumentNumberLabel";
            // 
            // WykrComboBox
            // 
            this.WykrComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WykrComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.WykrComboBox, "WykrComboBox");
            this.WykrComboBox.Name = "WykrComboBox";
            // 
            // reasonLabel
            // 
            resources.ApplyResources(this.reasonLabel, "reasonLabel");
            this.reasonLabel.Name = "reasonLabel";
            // 
            // priceLabel
            // 
            resources.ApplyResources(this.priceLabel, "priceLabel");
            this.priceLabel.Name = "priceLabel";
            // 
            // WoluminTextBox
            // 
            resources.ApplyResources(this.WoluminTextBox, "WoluminTextBox");
            this.WoluminTextBox.Name = "WoluminTextBox";
            // 
            // WoluminLabel
            // 
            resources.ApplyResources(this.WoluminLabel, "WoluminLabel");
            this.WoluminLabel.Name = "WoluminLabel";
            // 
            // PriceTextBox
            // 
            resources.ApplyResources(this.PriceTextBox, "PriceTextBox");
            this.PriceTextBox.Name = "PriceTextBox";
            this.PriceTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PriceTextBox_KeyPress);
            // 
            // startDateSearchDTP
            // 
            resources.ApplyResources(this.startDateSearchDTP, "startDateSearchDTP");
            this.startDateSearchDTP.Name = "startDateSearchDTP";
            // 
            // NumerInwSearchTextBox
            // 
            resources.ApplyResources(this.NumerInwSearchTextBox, "NumerInwSearchTextBox");
            this.NumerInwSearchTextBox.Name = "NumerInwSearchTextBox";
            this.NumerInwSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumerInwSearchTextBox_KeyDown);
            // 
            // invertoryNumberSearchLabel
            // 
            resources.ApplyResources(this.invertoryNumberSearchLabel, "invertoryNumberSearchLabel");
            this.invertoryNumberSearchLabel.Name = "invertoryNumberSearchLabel";
            // 
            // titleSearchLabel
            // 
            resources.ApplyResources(this.titleSearchLabel, "titleSearchLabel");
            this.titleSearchLabel.Name = "titleSearchLabel";
            // 
            // SygSearchTextBox
            // 
            resources.ApplyResources(this.SygSearchTextBox, "SygSearchTextBox");
            this.SygSearchTextBox.Name = "SygSearchTextBox";
            this.SygSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SygSearchTextBox_KeyDown);
            // 
            // signatureSearchLabel
            // 
            resources.ApplyResources(this.signatureSearchLabel, "signatureSearchLabel");
            this.signatureSearchLabel.Name = "signatureSearchLabel";
            // 
            // TitleSearchTextBox
            // 
            resources.ApplyResources(this.TitleSearchTextBox, "TitleSearchTextBox");
            this.TitleSearchTextBox.Name = "TitleSearchTextBox";
            this.TitleSearchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TitleSearchTextBox_KeyDown);
            // 
            // SearchCheckBox
            // 
            resources.ApplyResources(this.SearchCheckBox, "SearchCheckBox");
            this.SearchCheckBox.Name = "SearchCheckBox";
            this.SearchCheckBox.TabStop = false;
            this.SearchCheckBox.UseVisualStyleBackColor = true;
            this.SearchCheckBox.CheckedChanged += new System.EventHandler(this.SearchCheckBox_CheckedChanged);
            // 
            // CleanSearchButton
            // 
            this.CleanSearchButton.Image = global::Ubytki.Properties.Resources.Clear_64;
            resources.ApplyResources(this.CleanSearchButton, "CleanSearchButton");
            this.CleanSearchButton.Name = "CleanSearchButton";
            this.CleanSearchButton.TabStop = false;
            this.CleanSearchButton.UseVisualStyleBackColor = true;
            this.CleanSearchButton.Click += new System.EventHandler(this.CleanSearchButton_Click);
            // 
            // PreviousSearchButton
            // 
            this.PreviousSearchButton.Image = global::Ubytki.Properties.Resources.leftarrow;
            resources.ApplyResources(this.PreviousSearchButton, "PreviousSearchButton");
            this.PreviousSearchButton.Name = "PreviousSearchButton";
            this.PreviousSearchButton.TabStop = false;
            this.PreviousSearchButton.UseVisualStyleBackColor = true;
            this.PreviousSearchButton.Click += new System.EventHandler(this.PreviousSearchButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Image = global::Ubytki.Properties.Resources.lupka;
            resources.ApplyResources(this.SearchButton, "SearchButton");
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.TabStop = false;
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // NextSearchButton
            // 
            this.NextSearchButton.Image = global::Ubytki.Properties.Resources.rightarrow;
            resources.ApplyResources(this.NextSearchButton, "NextSearchButton");
            this.NextSearchButton.Name = "NextSearchButton";
            this.NextSearchButton.TabStop = false;
            this.NextSearchButton.UseVisualStyleBackColor = true;
            this.NextSearchButton.Click += new System.EventHandler(this.NextSearchButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::Ubytki.Properties.Resources.door_out;
            resources.ApplyResources(this.ExitButton, "ExitButton");
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.TabStop = false;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // CancButton
            // 
            resources.ApplyResources(this.CancButton, "CancButton");
            this.CancButton.Name = "CancButton";
            this.CancButton.TabStop = false;
            this.CancButton.UseVisualStyleBackColor = true;
            this.CancButton.Click += new System.EventHandler(this.CancButton_Click);
            // 
            // SaveButton
            // 
            resources.ApplyResources(this.SaveButton, "SaveButton");
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.TabStop = false;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Image = global::Ubytki.Properties.Resources.print_printer;
            resources.ApplyResources(this.PrintButton, "PrintButton");
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.TabStop = false;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // EditButton
            // 
            resources.ApplyResources(this.EditButton, "EditButton");
            this.EditButton.Name = "EditButton";
            this.EditButton.TabStop = false;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            resources.ApplyResources(this.DeleteButton, "DeleteButton");
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.TabStop = false;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // YearLabel
            // 
            resources.ApplyResources(this.YearLabel, "YearLabel");
            this.YearLabel.Name = "YearLabel";
            // 
            // YearTextBox
            // 
            resources.ApplyResources(this.YearTextBox, "YearTextBox");
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.TextChanged += new System.EventHandler(this.YearTextBox_TextChanged);
            // 
            // endDateSearchDTP
            // 
            resources.ApplyResources(this.endDateSearchDTP, "endDateSearchDTP");
            this.endDateSearchDTP.Name = "endDateSearchDTP";
            // 
            // sinceDateLabel
            // 
            resources.ApplyResources(this.sinceDateLabel, "sinceDateLabel");
            this.sinceDateLabel.Name = "sinceDateLabel";
            // 
            // toDateLabel
            // 
            resources.ApplyResources(this.toDateLabel, "toDateLabel");
            this.toDateLabel.Name = "toDateLabel";
            // 
            // UbytkiForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toDateLabel);
            this.Controls.Add(this.sinceDateLabel);
            this.Controls.Add(this.endDateSearchDTP);
            this.Controls.Add(this.YearTextBox);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.SearchCheckBox);
            this.Controls.Add(this.CleanSearchButton);
            this.Controls.Add(this.PreviousSearchButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.NextSearchButton);
            this.Controls.Add(this.TitleSearchTextBox);
            this.Controls.Add(this.startDateSearchDTP);
            this.Controls.Add(this.NumerInwSearchTextBox);
            this.Controls.Add(this.invertoryNumberSearchLabel);
            this.Controls.Add(this.titleSearchLabel);
            this.Controls.Add(this.SygSearchTextBox);
            this.Controls.Add(this.signatureSearchLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CancButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PriceTextBox);
            this.Controls.Add(this.WoluminTextBox);
            this.Controls.Add(this.WoluminLabel);
            this.Controls.Add(this.priceLabel);
            this.Controls.Add(this.reasonLabel);
            this.Controls.Add(this.WykrComboBox);
            this.Controls.Add(this.CommentsRichTextBox);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.NumerDowoduTextBox);
            this.Controls.Add(this.lossDocumentNumberLabel);
            this.Controls.Add(this.TitleRichTextBox);
            this.Controls.Add(this.entryDateLabel);
            this.Controls.Add(this.DateDTP);
            this.Controls.Add(this.NrKsiegiTextBox);
            this.Controls.Add(this.lossesBookNumberLabel);
            this.Controls.Add(this.NumbersTextBox);
            this.Controls.Add(this.NumbersLabel);
            this.Controls.Add(this.NumerInwTextBox);
            this.Controls.Add(this.invertoryNumberLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.SygnaturaTextBox);
            this.Controls.Add(this.signatureLabel);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.UbytkiDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "UbytkiForm";
            this.ShowInTaskbar = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UbytkiForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UbytkiForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.UbytkiDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UbytkiDGV;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Label signatureLabel;
        private System.Windows.Forms.TextBox SygnaturaTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox NumerInwTextBox;
        private System.Windows.Forms.Label invertoryNumberLabel;
        private System.Windows.Forms.TextBox NumbersTextBox;
        private System.Windows.Forms.Label NumbersLabel;
        private System.Windows.Forms.TextBox NrKsiegiTextBox;
        private System.Windows.Forms.Label lossesBookNumberLabel;
        private System.Windows.Forms.DateTimePicker DateDTP;
        private System.Windows.Forms.Label entryDateLabel;
        private System.Windows.Forms.RichTextBox TitleRichTextBox;
        private System.Windows.Forms.RichTextBox CommentsRichTextBox;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.TextBox NumerDowoduTextBox;
        private System.Windows.Forms.Label lossDocumentNumberLabel;
        private System.Windows.Forms.ComboBox WykrComboBox;
        private System.Windows.Forms.Label reasonLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.TextBox WoluminTextBox;
        private System.Windows.Forms.Label WoluminLabel;
        private System.Windows.Forms.TextBox PriceTextBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.DateTimePicker startDateSearchDTP;
        private System.Windows.Forms.TextBox NumerInwSearchTextBox;
        private System.Windows.Forms.Label invertoryNumberSearchLabel;
        private System.Windows.Forms.Label titleSearchLabel;
        private System.Windows.Forms.TextBox SygSearchTextBox;
        private System.Windows.Forms.Label signatureSearchLabel;
        private System.Windows.Forms.TextBox TitleSearchTextBox;
        private System.Windows.Forms.Button PreviousSearchButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button NextSearchButton;
        private System.Windows.Forms.Button CleanSearchButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SygDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumInwDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateDGV;
        private System.Windows.Forms.CheckBox SearchCheckBox;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.DateTimePicker endDateSearchDTP;
        private System.Windows.Forms.Label sinceDateLabel;
        private System.Windows.Forms.Label toDateLabel;
    }
}

