namespace Czasopisma
{
    partial class PublisherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PublisherForm));
            this.FullNameTextBox = new System.Windows.Forms.TextBox();
            this.ShortTextBox = new System.Windows.Forms.TextBox();
            this.PlaceTextBox = new System.Windows.Forms.TextBox();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.CountryTextBox = new System.Windows.Forms.TextBox();
            this.ContactTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.shortNameLabel = new System.Windows.Forms.Label();
            this.placeLabel = new System.Windows.Forms.Label();
            this.addressLabel = new System.Windows.Forms.Label();
            this.contactLabel = new System.Windows.Forms.Label();
            this.countryLabel = new System.Windows.Forms.Label();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FullNameTextBox
            // 
            this.FullNameTextBox.Location = new System.Drawing.Point(122, 12);
            this.FullNameTextBox.MaxLength = 120;
            this.FullNameTextBox.Multiline = true;
            this.FullNameTextBox.Name = "FullNameTextBox";
            this.FullNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FullNameTextBox.Size = new System.Drawing.Size(332, 79);
            this.FullNameTextBox.TabIndex = 0;
            // 
            // ShortTextBox
            // 
            this.ShortTextBox.Location = new System.Drawing.Point(122, 97);
            this.ShortTextBox.MaxLength = 120;
            this.ShortTextBox.Name = "ShortTextBox";
            this.ShortTextBox.Size = new System.Drawing.Size(332, 20);
            this.ShortTextBox.TabIndex = 1;
            // 
            // PlaceTextBox
            // 
            this.PlaceTextBox.Location = new System.Drawing.Point(122, 123);
            this.PlaceTextBox.MaxLength = 30;
            this.PlaceTextBox.Name = "PlaceTextBox";
            this.PlaceTextBox.Size = new System.Drawing.Size(332, 20);
            this.PlaceTextBox.TabIndex = 2;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(122, 149);
            this.AddressTextBox.MaxLength = 120;
            this.AddressTextBox.Multiline = true;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AddressTextBox.Size = new System.Drawing.Size(332, 69);
            this.AddressTextBox.TabIndex = 3;
            // 
            // CountryTextBox
            // 
            this.CountryTextBox.Location = new System.Drawing.Point(122, 299);
            this.CountryTextBox.MaxLength = 3;
            this.CountryTextBox.Name = "CountryTextBox";
            this.CountryTextBox.ReadOnly = true;
            this.CountryTextBox.Size = new System.Drawing.Size(43, 20);
            this.CountryTextBox.TabIndex = 5;
            this.CountryTextBox.TabStop = false;
            // 
            // ContactTextBox
            // 
            this.ContactTextBox.Location = new System.Drawing.Point(122, 224);
            this.ContactTextBox.MaxLength = 200;
            this.ContactTextBox.Multiline = true;
            this.ContactTextBox.Name = "ContactTextBox";
            this.ContactTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ContactTextBox.Size = new System.Drawing.Size(332, 69);
            this.ContactTextBox.TabIndex = 4;
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(2, 15);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(117, 13);
            this.nameLabel.TabIndex = 7;
            this.nameLabel.Text = "Pełna nazwa wydawcy";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // shortNameLabel
            // 
            this.shortNameLabel.Location = new System.Drawing.Point(2, 100);
            this.shortNameLabel.Name = "shortNameLabel";
            this.shortNameLabel.Size = new System.Drawing.Size(117, 13);
            this.shortNameLabel.TabIndex = 8;
            this.shortNameLabel.Text = "Skrót nazwy wydawcy";
            this.shortNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // placeLabel
            // 
            this.placeLabel.Location = new System.Drawing.Point(2, 127);
            this.placeLabel.Name = "placeLabel";
            this.placeLabel.Size = new System.Drawing.Size(117, 13);
            this.placeLabel.TabIndex = 9;
            this.placeLabel.Text = "Miejsce wydania";
            this.placeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // addressLabel
            // 
            this.addressLabel.Location = new System.Drawing.Point(2, 152);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(117, 13);
            this.addressLabel.TabIndex = 10;
            this.addressLabel.Text = "Adres";
            this.addressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // contactLabel
            // 
            this.contactLabel.Location = new System.Drawing.Point(2, 227);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(117, 13);
            this.contactLabel.TabIndex = 11;
            this.contactLabel.Text = "Kontakt";
            this.contactLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // countryLabel
            // 
            this.countryLabel.Location = new System.Drawing.Point(2, 302);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(117, 13);
            this.countryLabel.TabIndex = 12;
            this.countryLabel.Text = "Kraj wydawcy";
            this.countryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = ((System.Drawing.Image)(resources.GetObject("EscapeButton.Image")));
            this.EscapeButton.Location = new System.Drawing.Point(235, 342);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(90, 29);
            this.EscapeButton.TabIndex = 7;
            this.EscapeButton.Text = "Anuluj";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.BackColor = System.Drawing.Color.Transparent;
            this.SelectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SelectButton.Image = global::Czasopisma.Properties.Resources.lista2;
            this.SelectButton.Location = new System.Drawing.Point(171, 298);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(29, 23);
            this.SelectButton.TabIndex = 5;
            this.SelectButton.UseVisualStyleBackColor = false;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Image = ((System.Drawing.Image)(resources.GetObject("OKButton.Image")));
            this.OKButton.Location = new System.Drawing.Point(139, 342);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(90, 29);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "Zatwierdź";
            this.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // PublisherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 384);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.contactLabel);
            this.Controls.Add(this.addressLabel);
            this.Controls.Add(this.placeLabel);
            this.Controls.Add(this.shortNameLabel);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.ContactTextBox);
            this.Controls.Add(this.CountryTextBox);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.PlaceTextBox);
            this.Controls.Add(this.ShortTextBox);
            this.Controls.Add(this.FullNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PublisherForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wydawca";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PublisherForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FullNameTextBox;
        private System.Windows.Forms.TextBox ShortTextBox;
        private System.Windows.Forms.TextBox PlaceTextBox;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.TextBox CountryTextBox;
        private System.Windows.Forms.TextBox ContactTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Label shortNameLabel;
        private System.Windows.Forms.Label placeLabel;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button SelectButton;
    }
}