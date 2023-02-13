namespace WindowsFormsApplication1
{
    partial class EditPublisherForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPublisherForm));
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ShortTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.IDCountryTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PlaceTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ContactTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.KindComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ShowButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pełna nazwa wydawcy";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(143, 11);
            this.NameTextBox.MaxLength = 120;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(199, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // ShortTextBox
            // 
            this.ShortTextBox.Location = new System.Drawing.Point(143, 37);
            this.ShortTextBox.MaxLength = 120;
            this.ShortTextBox.Name = "ShortTextBox";
            this.ShortTextBox.Size = new System.Drawing.Size(199, 20);
            this.ShortTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Skrócona nazwa wydawcy";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IDCountryTextBox
            // 
            this.IDCountryTextBox.Location = new System.Drawing.Point(143, 203);
            this.IDCountryTextBox.MaxLength = 3;
            this.IDCountryTextBox.Name = "IDCountryTextBox";
            this.IDCountryTextBox.ReadOnly = true;
            this.IDCountryTextBox.Size = new System.Drawing.Size(40, 20);
            this.IDCountryTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Kraj wydawcy";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlaceTextBox
            // 
            this.PlaceTextBox.Location = new System.Drawing.Point(143, 63);
            this.PlaceTextBox.MaxLength = 30;
            this.PlaceTextBox.Name = "PlaceTextBox";
            this.PlaceTextBox.Size = new System.Drawing.Size(199, 20);
            this.PlaceTextBox.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Miasto";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ContactTextBox
            // 
            this.ContactTextBox.Location = new System.Drawing.Point(143, 146);
            this.ContactTextBox.MaxLength = 200;
            this.ContactTextBox.Multiline = true;
            this.ContactTextBox.Name = "ContactTextBox";
            this.ContactTextBox.Size = new System.Drawing.Size(199, 51);
            this.ContactTextBox.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 149);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Kontakt";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(143, 89);
            this.AddressTextBox.MaxLength = 120;
            this.AddressTextBox.Multiline = true;
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(199, 51);
            this.AddressTextBox.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(117, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Adres";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // KindComboBox
            // 
            this.KindComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KindComboBox.FormattingEnabled = true;
            this.KindComboBox.Location = new System.Drawing.Point(143, 229);
            this.KindComboBox.Name = "KindComboBox";
            this.KindComboBox.Size = new System.Drawing.Size(199, 21);
            this.KindComboBox.TabIndex = 6;
            this.KindComboBox.Visible = false;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 232);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Księgozbiór";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // ShowButton
            // 
            this.ShowButton.Image = global::WindowsFormsApplication1.Properties.Resources.lista2;
            this.ShowButton.Location = new System.Drawing.Point(189, 202);
            this.ShowButton.Name = "ShowButton";
            this.ShowButton.Size = new System.Drawing.Size(32, 23);
            this.ShowButton.TabIndex = 21;
            this.ShowButton.UseVisualStyleBackColor = true;
            this.ShowButton.Click += new System.EventHandler(this.ShowButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::WindowsFormsApplication1.Properties.Resources.fileclose1;
            this.CancelButton.Location = new System.Drawing.Point(180, 245);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(106, 30);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = global::WindowsFormsApplication1.Properties.Resources.Check2;
            this.OkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkButton.Location = new System.Drawing.Point(68, 245);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(106, 30);
            this.OkButton.TabIndex = 7;
            this.OkButton.Text = "     Zatwierdź";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // EditPublisherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 284);
            this.Controls.Add(this.ShowButton);
            this.Controls.Add(this.KindComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ContactTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.PlaceTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.IDCountryTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.ShortTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "EditPublisherForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditPublisherForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditPublisherForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox ShortTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TextBox IDCountryTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PlaceTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ContactTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox KindComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button ShowButton;
    }
}