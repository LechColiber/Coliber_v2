namespace WindowsFormsApplication1
{
    partial class Configurator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configurator));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DbPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DbUserNameTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.RememberCheckBox = new System.Windows.Forms.CheckBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UserTextBox = new System.Windows.Forms.TextBox();
            this.UserLabel = new System.Windows.Forms.Label();
            this.DatabaseComboBox = new System.Windows.Forms.ComboBox();
            this.ServerComboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.TestButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.TestInfoLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SQLcheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(2, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa serwera:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(2, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baza danych:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DbPasswordTextBox
            // 
            this.DbPasswordTextBox.Location = new System.Drawing.Point(115, 72);
            this.DbPasswordTextBox.Name = "DbPasswordTextBox";
            this.DbPasswordTextBox.Size = new System.Drawing.Size(254, 20);
            this.DbPasswordTextBox.TabIndex = 2;
            this.DbPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Hasło użytkownika:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DbUserNameTextBox
            // 
            this.DbUserNameTextBox.Location = new System.Drawing.Point(115, 46);
            this.DbUserNameTextBox.Name = "DbUserNameTextBox";
            this.DbUserNameTextBox.Size = new System.Drawing.Size(254, 20);
            this.DbUserNameTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(2, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Użytkownik bazy:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RememberCheckBox
            // 
            this.RememberCheckBox.Location = new System.Drawing.Point(116, 71);
            this.RememberCheckBox.Name = "RememberCheckBox";
            this.RememberCheckBox.Size = new System.Drawing.Size(170, 17);
            this.RememberCheckBox.TabIndex = 2;
            this.RememberCheckBox.Text = "Zapamiętaj";
            this.RememberCheckBox.UseVisualStyleBackColor = true;
            this.RememberCheckBox.Visible = false;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(115, 45);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(254, 20);
            this.PasswordTextBox.TabIndex = 1;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Location = new System.Drawing.Point(2, 48);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(106, 13);
            this.PasswordLabel.TabIndex = 11;
            this.PasswordLabel.Text = "Hasło:";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserTextBox
            // 
            this.UserTextBox.Location = new System.Drawing.Point(115, 19);
            this.UserTextBox.Name = "UserTextBox";
            this.UserTextBox.Size = new System.Drawing.Size(254, 20);
            this.UserTextBox.TabIndex = 0;
            // 
            // UserLabel
            // 
            this.UserLabel.Location = new System.Drawing.Point(2, 22);
            this.UserLabel.Name = "UserLabel";
            this.UserLabel.Size = new System.Drawing.Size(106, 13);
            this.UserLabel.TabIndex = 9;
            this.UserLabel.Text = "Użytkownik:";
            this.UserLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DatabaseComboBox
            // 
            this.DatabaseComboBox.FormattingEnabled = true;
            this.DatabaseComboBox.Location = new System.Drawing.Point(115, 98);
            this.DatabaseComboBox.Name = "DatabaseComboBox";
            this.DatabaseComboBox.Size = new System.Drawing.Size(254, 21);
            this.DatabaseComboBox.TabIndex = 3;
            this.DatabaseComboBox.DropDown += new System.EventHandler(this.DatabaseComboBox_DropDown);
            // 
            // ServerComboBox
            // 
            this.ServerComboBox.FormattingEnabled = true;
            this.ServerComboBox.Location = new System.Drawing.Point(115, 19);
            this.ServerComboBox.Name = "ServerComboBox";
            this.ServerComboBox.Size = new System.Drawing.Size(254, 21);
            this.ServerComboBox.TabIndex = 0;
            this.ServerComboBox.DropDown += new System.EventHandler(this.ServerComboBox_DropDown);
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::WindowsFormsApplication1.Properties.Resources.fileclose1;
            this.CancelButton.Location = new System.Drawing.Point(156, 274);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(106, 30);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // TestButton
            // 
            this.TestButton.Image = global::WindowsFormsApplication1.Properties.Resources.test;
            this.TestButton.Location = new System.Drawing.Point(268, 274);
            this.TestButton.Name = "TestButton";
            this.TestButton.Size = new System.Drawing.Size(106, 30);
            this.TestButton.TabIndex = 2;
            this.TestButton.Text = "Testuj";
            this.TestButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.TestButton.UseVisualStyleBackColor = true;
            this.TestButton.Click += new System.EventHandler(this.TestButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.SaveButton.Image = global::WindowsFormsApplication1.Properties.Resources.Check2;
            this.SaveButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SaveButton.Location = new System.Drawing.Point(41, 274);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(106, 30);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "   Zatwierdź";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // TestInfoLabel
            // 
            this.TestInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TestInfoLabel.ForeColor = System.Drawing.Color.Red;
            this.TestInfoLabel.Location = new System.Drawing.Point(45, 307);
            this.TestInfoLabel.Name = "TestInfoLabel";
            this.TestInfoLabel.Size = new System.Drawing.Size(330, 29);
            this.TestInfoLabel.TabIndex = 5;
            this.TestInfoLabel.Text = "Testuję połączenie...";
            this.TestInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TestInfoLabel.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DbPasswordTextBox);
            this.groupBox1.Controls.Add(this.ServerComboBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.DbUserNameTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.DatabaseComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 132);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dane serwera SQL";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.UserTextBox);
            this.groupBox2.Controls.Add(this.UserLabel);
            this.groupBox2.Controls.Add(this.PasswordLabel);
            this.groupBox2.Controls.Add(this.PasswordTextBox);
            this.groupBox2.Controls.Add(this.RememberCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 168);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 100);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dane użytkownika systemu Co-Liber";
            // 
            // SQLcheckBox
            // 
            this.SQLcheckBox.Location = new System.Drawing.Point(12, 7);
            this.SQLcheckBox.Name = "SQLcheckBox";
            this.SQLcheckBox.Size = new System.Drawing.Size(369, 17);
            this.SQLcheckBox.TabIndex = 14;
            this.SQLcheckBox.Text = "Zmień bazę danych lub poświadczenia do serwera SQL";
            this.SQLcheckBox.UseVisualStyleBackColor = true;
            this.SQLcheckBox.CheckedChanged += new System.EventHandler(this.SQLcheckBox_CheckedChanged);
            // 
            // Configurator
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 348);
            this.Controls.Add(this.SQLcheckBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TestInfoLabel);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.TestButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Configurator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konfiguracja połączenia";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Configurator_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button TestButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Label TestInfoLabel;
        private System.Windows.Forms.ComboBox ServerComboBox;
        private System.Windows.Forms.ComboBox DatabaseComboBox;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.TextBox UserTextBox;
        private System.Windows.Forms.Label UserLabel;
        private System.Windows.Forms.CheckBox RememberCheckBox;
        private System.Windows.Forms.TextBox DbPasswordTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DbUserNameTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox SQLcheckBox;
    }
}