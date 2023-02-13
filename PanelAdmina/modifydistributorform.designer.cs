namespace WindowsFormsApplication1
{
    partial class ModifyDistributorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyDistributorForm));
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ShortTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PlaceTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.ZipTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PhoneTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Phone2TextBox = new System.Windows.Forms.TextBox();
            this.FaxTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.CountryTextBox = new System.Windows.Forms.TextBox();
            this.CountryButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(94, 12);
            this.NameTextBox.MaxLength = 80;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(340, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // ShortTextBox
            // 
            this.ShortTextBox.Location = new System.Drawing.Point(94, 38);
            this.ShortTextBox.MaxLength = 30;
            this.ShortTextBox.Name = "ShortTextBox";
            this.ShortTextBox.Size = new System.Drawing.Size(340, 20);
            this.ShortTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Skrót nazwy";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = global::WindowsFormsApplication1.Properties.Resources.fileclose1;
            this.EscapeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EscapeButton.Location = new System.Drawing.Point(237, 275);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(90, 29);
            this.EscapeButton.TabIndex = 42;
            this.EscapeButton.Text = "    Anuluj";
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Image = global::WindowsFormsApplication1.Properties.Resources.Check2;
            this.OKButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OKButton.Location = new System.Drawing.Point(141, 275);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(90, 29);
            this.OKButton.TabIndex = 41;
            this.OKButton.Text = "Zatwierdź";
            this.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Adres";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(94, 64);
            this.AddressTextBox.MaxLength = 80;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(340, 20);
            this.AddressTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(7, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Miasto";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlaceTextBox
            // 
            this.PlaceTextBox.Location = new System.Drawing.Point(94, 90);
            this.PlaceTextBox.MaxLength = 30;
            this.PlaceTextBox.Name = "PlaceTextBox";
            this.PlaceTextBox.Size = new System.Drawing.Size(202, 20);
            this.PlaceTextBox.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(302, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Kod";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ZipTextBox
            // 
            this.ZipTextBox.Location = new System.Drawing.Point(353, 90);
            this.ZipTextBox.MaxLength = 10;
            this.ZipTextBox.Name = "ZipTextBox";
            this.ZipTextBox.Size = new System.Drawing.Size(81, 20);
            this.ZipTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(7, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Telefon";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PhoneTextBox
            // 
            this.PhoneTextBox.Location = new System.Drawing.Point(94, 178);
            this.PhoneTextBox.MaxLength = 50;
            this.PhoneTextBox.Name = "PhoneTextBox";
            this.PhoneTextBox.Size = new System.Drawing.Size(202, 20);
            this.PhoneTextBox.TabIndex = 11;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(7, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Fax";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Phone2TextBox
            // 
            this.Phone2TextBox.Location = new System.Drawing.Point(94, 204);
            this.Phone2TextBox.MaxLength = 50;
            this.Phone2TextBox.Name = "Phone2TextBox";
            this.Phone2TextBox.Size = new System.Drawing.Size(202, 20);
            this.Phone2TextBox.TabIndex = 13;
            // 
            // FaxTextBox
            // 
            this.FaxTextBox.Location = new System.Drawing.Point(94, 230);
            this.FaxTextBox.MaxLength = 50;
            this.FaxTextBox.Name = "FaxTextBox";
            this.FaxTextBox.Size = new System.Drawing.Size(202, 20);
            this.FaxTextBox.TabIndex = 15;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(7, 119);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 13);
            this.label12.TabIndex = 37;
            this.label12.Text = "Państwo";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CountryTextBox
            // 
            this.CountryTextBox.Location = new System.Drawing.Point(94, 116);
            this.CountryTextBox.MaxLength = 3;
            this.CountryTextBox.Name = "CountryTextBox";
            this.CountryTextBox.ReadOnly = true;
            this.CountryTextBox.Size = new System.Drawing.Size(43, 20);
            this.CountryTextBox.TabIndex = 38;
            // 
            // CountryButton
            // 
            this.CountryButton.BackColor = System.Drawing.Color.Transparent;
            this.CountryButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("CountryButton.BackgroundImage")));
            this.CountryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.CountryButton.Location = new System.Drawing.Point(143, 114);
            this.CountryButton.Name = "CountryButton";
            this.CountryButton.Size = new System.Drawing.Size(32, 23);
            this.CountryButton.TabIndex = 39;
            this.CountryButton.UseVisualStyleBackColor = false;
            this.CountryButton.Click += new System.EventHandler(this.CountryButton_Click);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(7, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(224, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "Dane teleadresowe";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ModifyDistributorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 316);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CountryButton);
            this.Controls.Add(this.CountryTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.FaxTextBox);
            this.Controls.Add(this.Phone2TextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PhoneTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ZipTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PlaceTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ShortTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ModifyDistributorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dostawca";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DistributorForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox ShortTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PlaceTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox ZipTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PhoneTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Phone2TextBox;
        private System.Windows.Forms.TextBox FaxTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox CountryTextBox;
        private System.Windows.Forms.Button CountryButton;
        private System.Windows.Forms.Label label7;
    }
}