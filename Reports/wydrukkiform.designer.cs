namespace Reports
{
    partial class WydrukKIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WydrukKIForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DateCheckBox = new System.Windows.Forms.CheckBox();
            this.ToDTP = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.FromDTP = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.SortByComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.IdRodzajComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.AllDbCheckBox = new System.Windows.Forms.CheckBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.KindComboBox = new System.Windows.Forms.ComboBox();
            this.ForAllComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.cbStatWyp = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Statystyki";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Wydruk ksiąg inwentarzowych";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Reports.Properties.Resources.wykres;
            this.pictureBox1.Location = new System.Drawing.Point(357, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Rodzaj:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cbStatWyp);
            this.panel1.Controls.Add(this.DateCheckBox);
            this.panel1.Controls.Add(this.ToDTP);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.FromDTP);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.SortByComboBox);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.IdRodzajComboBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.AllDbCheckBox);
            this.panel1.Controls.Add(this.ValueTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.KindComboBox);
            this.panel1.Controls.Add(this.ForAllComboBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(383, 301);
            this.panel1.TabIndex = 4;
            // 
            // DateCheckBox
            // 
            this.DateCheckBox.AutoSize = true;
            this.DateCheckBox.Location = new System.Drawing.Point(3, 188);
            this.DateCheckBox.Name = "DateCheckBox";
            this.DateCheckBox.Size = new System.Drawing.Size(100, 17);
            this.DateCheckBox.TabIndex = 20;
            this.DateCheckBox.Text = "Uwzględnij daty";
            this.DateCheckBox.UseVisualStyleBackColor = true;
            this.DateCheckBox.CheckedChanged += new System.EventHandler(this.DateCheckBox_CheckedChanged);
            // 
            // ToDTP
            // 
            this.ToDTP.Enabled = false;
            this.ToDTP.Location = new System.Drawing.Point(88, 237);
            this.ToDTP.Name = "ToDTP";
            this.ToDTP.Size = new System.Drawing.Size(150, 20);
            this.ToDTP.TabIndex = 17;
            this.ToDTP.ValueChanged += new System.EventHandler(this.ToDTP_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(37, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Do dnia";
            // 
            // FromDTP
            // 
            this.FromDTP.Enabled = false;
            this.FromDTP.Location = new System.Drawing.Point(88, 211);
            this.FromDTP.Name = "FromDTP";
            this.FromDTP.Size = new System.Drawing.Size(150, 20);
            this.FromDTP.TabIndex = 15;
            this.FromDTP.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.FromDTP.ValueChanged += new System.EventHandler(this.FromDTP_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 214);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Od dnia";
            // 
            // SortByComboBox
            // 
            this.SortByComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SortByComboBox.FormattingEnabled = true;
            this.SortByComboBox.Location = new System.Drawing.Point(88, 143);
            this.SortByComboBox.Name = "SortByComboBox";
            this.SortByComboBox.Size = new System.Drawing.Size(150, 21);
            this.SortByComboBox.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1, 147);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Wyniki sortuj wg:";
            // 
            // IdRodzajComboBox
            // 
            this.IdRodzajComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IdRodzajComboBox.FormattingEnabled = true;
            this.IdRodzajComboBox.Location = new System.Drawing.Point(88, 116);
            this.IdRodzajComboBox.Name = "IdRodzajComboBox";
            this.IdRodzajComboBox.Size = new System.Drawing.Size(251, 21);
            this.IdRodzajComboBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "lub w inwentarzu";
            // 
            // AllDbCheckBox
            // 
            this.AllDbCheckBox.AutoSize = true;
            this.AllDbCheckBox.Location = new System.Drawing.Point(4, 98);
            this.AllDbCheckBox.Name = "AllDbCheckBox";
            this.AllDbCheckBox.Size = new System.Drawing.Size(222, 17);
            this.AllDbCheckBox.TabIndex = 9;
            this.AllDbCheckBox.Text = "We wszystkich księgach inwentarzowych";
            this.AllDbCheckBox.UseVisualStyleBackColor = true;
            this.AllDbCheckBox.CheckedChanged += new System.EventHandler(this.AllDbCheckBox_CheckedChanged);
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(88, 72);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(150, 20);
            this.ValueTextBox.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(246, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "rozpoczynających się od:";
            // 
            // KindComboBox
            // 
            this.KindComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KindComboBox.FormattingEnabled = true;
            this.KindComboBox.Location = new System.Drawing.Point(88, 10);
            this.KindComboBox.Name = "KindComboBox";
            this.KindComboBox.Size = new System.Drawing.Size(150, 21);
            this.KindComboBox.TabIndex = 6;
            this.KindComboBox.SelectedIndexChanged += new System.EventHandler(this.KindComboBox_SelectedIndexChanged);
            // 
            // ForAllComboBox
            // 
            this.ForAllComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ForAllComboBox.FormattingEnabled = true;
            this.ForAllComboBox.Location = new System.Drawing.Point(88, 44);
            this.ForAllComboBox.Name = "ForAllComboBox";
            this.ForAllComboBox.Size = new System.Drawing.Size(150, 21);
            this.ForAllComboBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Dla wszystkich";
            // 
            // SearchButton
            // 
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.Location = new System.Drawing.Point(127, 378);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 5;
            this.SearchButton.Text = "Szukaj";
            this.SearchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(208, 378);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // cbStatWyp
            // 
            this.cbStatWyp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatWyp.FormattingEnabled = true;
            this.cbStatWyp.Items.AddRange(new object[] {
            "Pokaż status wypozyczenia",
            "Pokaż tylko pozycje niewypożyczone"});
            this.cbStatWyp.Location = new System.Drawing.Point(88, 265);
            this.cbStatWyp.Name = "cbStatWyp";
            this.cbStatWyp.Size = new System.Drawing.Size(251, 21);
            this.cbStatWyp.TabIndex = 21;
            this.cbStatWyp.Visible = false;
            // 
            // WydrukKIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 414);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "WydrukKIForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wydruk księgi inwentarzowej";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WydrukKIForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker ToDTP;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker FromDTP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox SortByComboBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox IdRodzajComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox AllDbCheckBox;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox KindComboBox;
        private System.Windows.Forms.ComboBox ForAllComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.CheckBox DateCheckBox;
        private System.Windows.Forms.ComboBox cbStatWyp;
    }
}

