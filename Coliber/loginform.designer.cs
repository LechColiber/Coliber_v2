namespace Coliber
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.RememberCheckBox = new System.Windows.Forms.CheckBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // RememberCheckBox
            // 
            this.RememberCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RememberCheckBox.Location = new System.Drawing.Point(80, 130);
            this.RememberCheckBox.Name = "RememberCheckBox";
            this.RememberCheckBox.Size = new System.Drawing.Size(161, 17);
            this.RememberCheckBox.TabIndex = 14;
            this.RememberCheckBox.Text = "Zapamiętaj użytkownika";
            this.RememberCheckBox.UseVisualStyleBackColor = true;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(80, 103);
            this.PasswordTextBox.MaxLength = 40;
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(260, 20);
            this.PasswordTextBox.TabIndex = 13;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.PasswordLabel.Location = new System.Drawing.Point(12, 106);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(62, 13);
            this.PasswordLabel.TabIndex = 18;
            this.PasswordLabel.Text = "Hasło:";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserTextBox
            // 
            this.UserTextBox.Location = new System.Drawing.Point(80, 77);
            this.UserTextBox.MaxLength = 15;
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.Size = new System.Drawing.Size(260, 20);
            this.UserTextBox.TabIndex = 12;
            // 
            // UserLabel
            // 
            this.UserLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.UserLabel.Location = new System.Drawing.Point(9, 80);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(65, 13);
            this.UserLabel.TabIndex = 17;
            this.UserLabel.Text = "Użytkownik:";
            this.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EscapeButton
            // 
            this.EscapeButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.EscapeButton.Location = new System.Drawing.Point(180, 160);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(67, 23);
            this.EscapeButton.TabIndex = 16;
            this.EscapeButton.Text = "Anuluj";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SaveButton.Location = new System.Drawing.Point(107, 160);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(67, 23);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "OK";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 62);
            this.panel1.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(299, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(32, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Proszę zalogować się do programu";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Logowanie";
            // 
            // LoginForm
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 190);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.RememberCheckBox);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserTextBox);
            this.Controls.Add(this.UserLabel);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.SaveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Logowanie";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Configurator_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox RememberCheckBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox UserTextBox;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}