namespace Ksiazki
{
    partial class EditServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditServerForm));
            this.AddressLabel = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.NameLabel = new System.Windows.Forms.Label();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.PortLabel = new System.Windows.Forms.Label();
            this.DatabaseTextBox = new System.Windows.Forms.TextBox();
            this.DatabaseLabel = new System.Windows.Forms.Label();
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.CommentsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddressLabel
            // 
            this.AddressLabel.Location = new System.Drawing.Point(12, 67);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(88, 13);
            this.AddressLabel.TabIndex = 0;
            this.AddressLabel.Text = "Adres serwera";
            this.AddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(111, 63);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(256, 20);
            this.AddressTextBox.TabIndex = 1;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(111, 37);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(256, 20);
            this.NameTextBox.TabIndex = 0;
            // 
            // NameLabel
            // 
            this.NameLabel.Location = new System.Drawing.Point(12, 40);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(88, 13);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Nazwa serwera";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(111, 89);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(256, 20);
            this.PortTextBox.TabIndex = 2;
            this.PortTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PortTextBox_KeyPress);
            // 
            // PortLabel
            // 
            this.PortLabel.Location = new System.Drawing.Point(12, 92);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(88, 13);
            this.PortLabel.TabIndex = 4;
            this.PortLabel.Text = "Port";
            this.PortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DatabaseTextBox
            // 
            this.DatabaseTextBox.Location = new System.Drawing.Point(111, 115);
            this.DatabaseTextBox.Name = "DatabaseTextBox";
            this.DatabaseTextBox.Size = new System.Drawing.Size(256, 20);
            this.DatabaseTextBox.TabIndex = 3;
            // 
            // DatabaseLabel
            // 
            this.DatabaseLabel.Location = new System.Drawing.Point(12, 119);
            this.DatabaseLabel.Name = "DatabaseLabel";
            this.DatabaseLabel.Size = new System.Drawing.Size(88, 13);
            this.DatabaseLabel.TabIndex = 6;
            this.DatabaseLabel.Text = "Baza danych";
            this.DatabaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserTextBox
            // 
            this.UserTextBox.Location = new System.Drawing.Point(111, 141);
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.Size = new System.Drawing.Size(256, 20);
            this.UserTextBox.TabIndex = 4;
            // 
            // UserLabel
            // 
            this.UserLabel.Location = new System.Drawing.Point(12, 144);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(88, 13);
            this.UserLabel.TabIndex = 8;
            this.UserLabel.Text = "Użytkownik";
            this.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(111, 167);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.PasswordChar = '*';
            this.PasswordTextBox.Size = new System.Drawing.Size(256, 20);
            this.PasswordTextBox.TabIndex = 5;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(12, 170);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(88, 13);
            this.PasswordLabel.TabIndex = 10;
            this.PasswordLabel.Text = "Hasło";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CommentsTextBox
            // 
            this.CommentsTextBox.Location = new System.Drawing.Point(111, 193);
            this.CommentsTextBox.MaxLength = 100;
            this.CommentsTextBox.Multiline = true;
            this.CommentsTextBox.Name = "CommentsTextBox";
            this.CommentsTextBox.Size = new System.Drawing.Size(256, 78);
            this.CommentsTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 26);
            this.label1.TabIndex = 12;
            this.label1.Text = "Uwagi\r\n(do 100 znaków)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::Ksiazki.Properties.Resources.fileclose;
            this.CancelButton.Location = new System.Drawing.Point(196, 277);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(90, 29);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Image = global::Ksiazki.Properties.Resources.Check2;
            this.SaveButton.Location = new System.Drawing.Point(96, 277);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(90, 29);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Zatwierdź";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EditServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 314);
            this.Controls.Add(this.CommentsTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserTextBox);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.DatabaseTextBox);
            this.Controls.Add(this.DatabaseLabel);
            this.Controls.Add(this.PortTextBox);
            this.Controls.Add(this.PortLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.AddressLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "EditServerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditServerForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditServerForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox DatabaseTextBox;
        private System.Windows.Forms.Label DatabaseLabel;
        private System.Windows.Forms.TextBox UserTextBox;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox CommentsTextBox;
        private System.Windows.Forms.Label label1;
    }
}