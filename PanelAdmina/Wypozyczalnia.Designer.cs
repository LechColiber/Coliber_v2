namespace WindowsFormsApplication1
{
    partial class Wypozyczalnia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wypozyczalnia));
            this.LoginTextBox = new System.Windows.Forms.TextBox();
            this.PassTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SurnameTextBox = new System.Windows.Forms.TextBox();
            this.TimeExpiredTextBox = new System.Windows.Forms.TextBox();
            this.EmergencyTextBox = new System.Windows.Forms.TextBox();
            this.CommentsTextBox = new System.Windows.Forms.TextBox();
            this.SettingsTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.Pass2TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LoginTextBox
            // 
            this.LoginTextBox.Location = new System.Drawing.Point(101, 18);
            this.LoginTextBox.MaxLength = 20;
            this.LoginTextBox.Name = "LoginTextBox";
            this.LoginTextBox.Size = new System.Drawing.Size(307, 20);
            this.LoginTextBox.TabIndex = 0;
            this.LoginTextBox.Enter += new System.EventHandler(this.LoginTextBox_Enter);
            // 
            // PassTextBox
            // 
            this.PassTextBox.Location = new System.Drawing.Point(101, 44);
            this.PassTextBox.MaxLength = 40;
            this.PassTextBox.Name = "PassTextBox";
            this.PassTextBox.Size = new System.Drawing.Size(105, 20);
            this.PassTextBox.TabIndex = 1;
            this.PassTextBox.UseSystemPasswordChar = true;
            this.PassTextBox.Enter += new System.EventHandler(this.PassTextBox_Enter);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(101, 72);
            this.NameTextBox.MaxLength = 20;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(307, 20);
            this.NameTextBox.TabIndex = 3;
            this.NameTextBox.Enter += new System.EventHandler(this.NameTextBox_Enter);
            // 
            // SurnameTextBox
            // 
            this.SurnameTextBox.Location = new System.Drawing.Point(101, 98);
            this.SurnameTextBox.MaxLength = 30;
            this.SurnameTextBox.Name = "SurnameTextBox";
            this.SurnameTextBox.Size = new System.Drawing.Size(307, 20);
            this.SurnameTextBox.TabIndex = 4;
            this.SurnameTextBox.Enter += new System.EventHandler(this.SurnameTextBox_Enter);
            // 
            // TimeExpiredTextBox
            // 
            this.TimeExpiredTextBox.Location = new System.Drawing.Point(101, 124);
            this.TimeExpiredTextBox.MaxLength = 5;
            this.TimeExpiredTextBox.Name = "TimeExpiredTextBox";
            this.TimeExpiredTextBox.Size = new System.Drawing.Size(40, 20);
            this.TimeExpiredTextBox.TabIndex = 5;
            this.TimeExpiredTextBox.Enter += new System.EventHandler(this.TimeExpiredTextBox_Enter);
            this.TimeExpiredTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TimeExpiredTextBox_KeyPress);
            this.TimeExpiredTextBox.Leave += new System.EventHandler(this.TimeExpiredTextBox_Leave);
            // 
            // EmergencyTextBox
            // 
            this.EmergencyTextBox.Location = new System.Drawing.Point(280, 124);
            this.EmergencyTextBox.MaxLength = 3;
            this.EmergencyTextBox.Name = "EmergencyTextBox";
            this.EmergencyTextBox.Size = new System.Drawing.Size(32, 20);
            this.EmergencyTextBox.TabIndex = 6;
            this.EmergencyTextBox.Enter += new System.EventHandler(this.EmergencyTextBox_Enter);
            this.EmergencyTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EmergencyTextBox_KeyPress);
            this.EmergencyTextBox.Leave += new System.EventHandler(this.EmergencyTextBox_Leave);
            // 
            // CommentsTextBox
            // 
            this.CommentsTextBox.Location = new System.Drawing.Point(101, 150);
            this.CommentsTextBox.Name = "CommentsTextBox";
            this.CommentsTextBox.Size = new System.Drawing.Size(307, 20);
            this.CommentsTextBox.TabIndex = 7;
            this.CommentsTextBox.Enter += new System.EventHandler(this.CommentsTextBox_Enter);
            // 
            // SettingsTextBox
            // 
            this.SettingsTextBox.Location = new System.Drawing.Point(101, 176);
            this.SettingsTextBox.Name = "SettingsTextBox";
            this.SettingsTextBox.Size = new System.Drawing.Size(307, 20);
            this.SettingsTextBox.TabIndex = 8;
            this.SettingsTextBox.Enter += new System.EventHandler(this.SettingsTextBox_Enter);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Hasło";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Imię";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Nazwisko";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Ważność hasła";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(150, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Max logowań awaryjnych";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(55, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "Uwagi";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(33, 179);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Ustawienia";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(100, 215);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(106, 30);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // EscapeButton
            // 
            this.EscapeButton.Location = new System.Drawing.Point(212, 215);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(106, 30);
            this.EscapeButton.TabIndex = 10;
            this.EscapeButton.Text = "Anuluj";
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(223, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Ponów hasło";
            // 
            // Pass2TextBox
            // 
            this.Pass2TextBox.Location = new System.Drawing.Point(303, 44);
            this.Pass2TextBox.MaxLength = 40;
            this.Pass2TextBox.Name = "Pass2TextBox";
            this.Pass2TextBox.Size = new System.Drawing.Size(105, 20);
            this.Pass2TextBox.TabIndex = 2;
            this.Pass2TextBox.UseSystemPasswordChar = true;
            this.Pass2TextBox.Enter += new System.EventHandler(this.Pass2TextBox_Enter);
            // 
            // Wypozyczalnia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 250);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.Pass2TextBox);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.SurnameTextBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SettingsTextBox);
            this.Controls.Add(this.CommentsTextBox);
            this.Controls.Add(this.EmergencyTextBox);
            this.Controls.Add(this.TimeExpiredTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.PassTextBox);
            this.Controls.Add(this.LoginTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Wypozyczalnia";
            this.ShowInTaskbar = false;
            this.Text = "Wypożyczalnia";
            this.Load += new System.EventHandler(this.Wypozyczalnia_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Wypozyczalnia_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoginTextBox;
        private System.Windows.Forms.TextBox PassTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox SurnameTextBox;
        private System.Windows.Forms.TextBox TimeExpiredTextBox;
        private System.Windows.Forms.TextBox EmergencyTextBox;
        private System.Windows.Forms.TextBox CommentsTextBox;
        private System.Windows.Forms.TextBox SettingsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Pass2TextBox;
    }
}