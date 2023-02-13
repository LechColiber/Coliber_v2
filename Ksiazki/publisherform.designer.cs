namespace Ksiazki
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.CleanPublisherCountryButton = new System.Windows.Forms.Button();
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Pełna nazwa wydawcy";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Skrót nazwy wydawcy";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Miejsce wydania";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Adres";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(2, 227);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Kontakt";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(2, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Kraj wydawcy";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Image = global::Ksiazki.Properties.Resources.Check2;
            this.OKButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OKButton.Location = new System.Drawing.Point(139, 342);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(90, 29);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "Zatwierdź";
            this.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::Ksiazki.Properties.Resources.fileclose;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(235, 342);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(90, 29);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "    Anuluj";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.BackColor = System.Drawing.Color.Transparent;
            this.SelectButton.BackgroundImage = global::Ksiazki.Properties.Resources.lista2;
            this.SelectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SelectButton.Location = new System.Drawing.Point(171, 298);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(29, 23);
            this.SelectButton.TabIndex = 5;
            this.SelectButton.UseVisualStyleBackColor = false;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // CleanPublisherCountryButton
            // 
            this.CleanPublisherCountryButton.Image = ((System.Drawing.Image)(resources.GetObject("CleanPublisherCountryButton.Image")));
            this.CleanPublisherCountryButton.Location = new System.Drawing.Point(206, 298);
            this.CleanPublisherCountryButton.Name = "CleanPublisherCountryButton";
            this.CleanPublisherCountryButton.Size = new System.Drawing.Size(32, 23);
            this.CleanPublisherCountryButton.TabIndex = 22;
            this.CleanPublisherCountryButton.UseVisualStyleBackColor = true;
            this.CleanPublisherCountryButton.Click += new System.EventHandler(this.CleanPublisherCountryButton_Click);
            // 
            // PublisherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 384);
            this.Controls.Add(this.CleanPublisherCountryButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Button CleanPublisherCountryButton;
    }
}