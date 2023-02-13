namespace Wypozyczalnia
{
    partial class StatisticsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            this.exitButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.resourcesTabPage = new System.Windows.Forms.TabPage();
            this.dateOfOperationLabel = new System.Windows.Forms.Label();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.endDateDTP = new System.Windows.Forms.DateTimePicker();
            this.startDateDTP = new System.Windows.Forms.DateTimePicker();
            this.resourceStateComboBox = new System.Windows.Forms.ComboBox();
            this.resourceStateLabel = new System.Windows.Forms.Label();
            this.resourceGroupComboBox = new System.Windows.Forms.ComboBox();
            this.resourceGroupLabel = new System.Windows.Forms.Label();
            this.usersTabPage = new System.Windows.Forms.TabPage();
            this.onlyActiveUsersCheckBox = new System.Windows.Forms.CheckBox();
            this.userGroupComboBox = new System.Windows.Forms.ComboBox();
            this.groupLabel = new System.Windows.Forms.Label();
            this.userTypeComboBox = new System.Windows.Forms.ComboBox();
            this.userTypeLabel = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.readingEndDTP = new System.Windows.Forms.DateTimePicker();
            this.readingStartDTP = new System.Windows.Forms.DateTimePicker();
            this.operationTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.printButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.resourcesTabPage.SuspendLayout();
            this.usersTabPage.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.Location = new System.Drawing.Point(431, 226);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(77, 23);
            this.exitButton.TabIndex = 23;
            this.exitButton.Text = "Wyjście";
            this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.resourcesTabPage);
            this.tabControl1.Controls.Add(this.usersTabPage);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(496, 208);
            this.tabControl1.TabIndex = 24;
            // 
            // resourcesTabPage
            // 
            this.resourcesTabPage.Controls.Add(this.dateOfOperationLabel);
            this.resourcesTabPage.Controls.Add(this.toLabel);
            this.resourcesTabPage.Controls.Add(this.fromLabel);
            this.resourcesTabPage.Controls.Add(this.endDateDTP);
            this.resourcesTabPage.Controls.Add(this.startDateDTP);
            this.resourcesTabPage.Controls.Add(this.resourceStateComboBox);
            this.resourcesTabPage.Controls.Add(this.resourceStateLabel);
            this.resourcesTabPage.Controls.Add(this.resourceGroupComboBox);
            this.resourcesTabPage.Controls.Add(this.resourceGroupLabel);
            this.resourcesTabPage.Location = new System.Drawing.Point(4, 22);
            this.resourcesTabPage.Name = "resourcesTabPage";
            this.resourcesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.resourcesTabPage.Size = new System.Drawing.Size(488, 182);
            this.resourcesTabPage.TabIndex = 0;
            this.resourcesTabPage.Text = "Zasoby";
            this.resourcesTabPage.UseVisualStyleBackColor = true;
            // 
            // dateOfOperationLabel
            // 
            this.dateOfOperationLabel.Location = new System.Drawing.Point(3, 77);
            this.dateOfOperationLabel.Name = "dateOfOperationLabel";
            this.dateOfOperationLabel.Size = new System.Drawing.Size(79, 13);
            this.dateOfOperationLabel.TabIndex = 8;
            this.dateOfOperationLabel.Text = "Data operacji";
            this.dateOfOperationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toLabel
            // 
            this.toLabel.Location = new System.Drawing.Point(12, 124);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(70, 13);
            this.toLabel.TabIndex = 7;
            this.toLabel.Text = "Do";
            this.toLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fromLabel
            // 
            this.fromLabel.Location = new System.Drawing.Point(12, 99);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(70, 13);
            this.fromLabel.TabIndex = 6;
            this.fromLabel.Text = "Od";
            this.fromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // endDateDTP
            // 
            this.endDateDTP.Checked = false;
            this.endDateDTP.Location = new System.Drawing.Point(88, 121);
            this.endDateDTP.Name = "endDateDTP";
            this.endDateDTP.ShowCheckBox = true;
            this.endDateDTP.Size = new System.Drawing.Size(200, 20);
            this.endDateDTP.TabIndex = 5;
            // 
            // startDateDTP
            // 
            this.startDateDTP.Checked = false;
            this.startDateDTP.Location = new System.Drawing.Point(88, 95);
            this.startDateDTP.Name = "startDateDTP";
            this.startDateDTP.ShowCheckBox = true;
            this.startDateDTP.Size = new System.Drawing.Size(200, 20);
            this.startDateDTP.TabIndex = 4;
            // 
            // resourceStateComboBox
            // 
            this.resourceStateComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resourceStateComboBox.FormattingEnabled = true;
            this.resourceStateComboBox.Location = new System.Drawing.Point(88, 36);
            this.resourceStateComboBox.Name = "resourceStateComboBox";
            this.resourceStateComboBox.Size = new System.Drawing.Size(200, 21);
            this.resourceStateComboBox.TabIndex = 3;
            // 
            // resourceStateLabel
            // 
            this.resourceStateLabel.Location = new System.Drawing.Point(6, 39);
            this.resourceStateLabel.Name = "resourceStateLabel";
            this.resourceStateLabel.Size = new System.Drawing.Size(76, 13);
            this.resourceStateLabel.TabIndex = 2;
            this.resourceStateLabel.Text = "Stan zasobu";
            this.resourceStateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // resourceGroupComboBox
            // 
            this.resourceGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resourceGroupComboBox.FormattingEnabled = true;
            this.resourceGroupComboBox.Location = new System.Drawing.Point(88, 9);
            this.resourceGroupComboBox.Name = "resourceGroupComboBox";
            this.resourceGroupComboBox.Size = new System.Drawing.Size(200, 21);
            this.resourceGroupComboBox.TabIndex = 1;
            // 
            // resourceGroupLabel
            // 
            this.resourceGroupLabel.Location = new System.Drawing.Point(3, 12);
            this.resourceGroupLabel.Name = "resourceGroupLabel";
            this.resourceGroupLabel.Size = new System.Drawing.Size(79, 13);
            this.resourceGroupLabel.TabIndex = 0;
            this.resourceGroupLabel.Text = "Grupa zasobu";
            this.resourceGroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usersTabPage
            // 
            this.usersTabPage.Controls.Add(this.onlyActiveUsersCheckBox);
            this.usersTabPage.Controls.Add(this.userGroupComboBox);
            this.usersTabPage.Controls.Add(this.groupLabel);
            this.usersTabPage.Controls.Add(this.userTypeComboBox);
            this.usersTabPage.Controls.Add(this.userTypeLabel);
            this.usersTabPage.Location = new System.Drawing.Point(4, 22);
            this.usersTabPage.Name = "usersTabPage";
            this.usersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.usersTabPage.Size = new System.Drawing.Size(488, 182);
            this.usersTabPage.TabIndex = 1;
            this.usersTabPage.Text = "Osoby";
            this.usersTabPage.UseVisualStyleBackColor = true;
            // 
            // onlyActiveUsersCheckBox
            // 
            this.onlyActiveUsersCheckBox.Location = new System.Drawing.Point(102, 64);
            this.onlyActiveUsersCheckBox.Name = "onlyActiveUsersCheckBox";
            this.onlyActiveUsersCheckBox.Size = new System.Drawing.Size(152, 17);
            this.onlyActiveUsersCheckBox.TabIndex = 8;
            this.onlyActiveUsersCheckBox.Text = "Tylko aktywni użytkownicy";
            this.onlyActiveUsersCheckBox.UseVisualStyleBackColor = true;
            // 
            // userGroupComboBox
            // 
            this.userGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userGroupComboBox.FormattingEnabled = true;
            this.userGroupComboBox.Location = new System.Drawing.Point(102, 36);
            this.userGroupComboBox.Name = "userGroupComboBox";
            this.userGroupComboBox.Size = new System.Drawing.Size(200, 21);
            this.userGroupComboBox.TabIndex = 7;
            // 
            // groupLabel
            // 
            this.groupLabel.Location = new System.Drawing.Point(12, 39);
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(84, 13);
            this.groupLabel.TabIndex = 6;
            this.groupLabel.Text = "Grupa";
            this.groupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userTypeComboBox
            // 
            this.userTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.userTypeComboBox.FormattingEnabled = true;
            this.userTypeComboBox.Location = new System.Drawing.Point(102, 9);
            this.userTypeComboBox.Name = "userTypeComboBox";
            this.userTypeComboBox.Size = new System.Drawing.Size(200, 21);
            this.userTypeComboBox.TabIndex = 5;
            // 
            // userTypeLabel
            // 
            this.userTypeLabel.Location = new System.Drawing.Point(9, 12);
            this.userTypeLabel.Name = "userTypeLabel";
            this.userTypeLabel.Size = new System.Drawing.Size(87, 13);
            this.userTypeLabel.TabIndex = 4;
            this.userTypeLabel.Text = "Typ użytkownika";
            this.userTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.readingEndDTP);
            this.tabPage3.Controls.Add(this.readingStartDTP);
            this.tabPage3.Controls.Add(this.operationTypeComboBox);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(488, 182);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Czytelnia";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Data operacji";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 97);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Do";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "Od";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // readingEndDTP
            // 
            this.readingEndDTP.Checked = false;
            this.readingEndDTP.Location = new System.Drawing.Point(91, 94);
            this.readingEndDTP.Name = "readingEndDTP";
            this.readingEndDTP.ShowCheckBox = true;
            this.readingEndDTP.Size = new System.Drawing.Size(200, 20);
            this.readingEndDTP.TabIndex = 12;
            // 
            // readingStartDTP
            // 
            this.readingStartDTP.Checked = false;
            this.readingStartDTP.Location = new System.Drawing.Point(91, 68);
            this.readingStartDTP.Name = "readingStartDTP";
            this.readingStartDTP.ShowCheckBox = true;
            this.readingStartDTP.Size = new System.Drawing.Size(200, 20);
            this.readingStartDTP.TabIndex = 11;
            // 
            // operationTypeComboBox
            // 
            this.operationTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.operationTypeComboBox.FormattingEnabled = true;
            this.operationTypeComboBox.Location = new System.Drawing.Point(91, 9);
            this.operationTypeComboBox.Name = "operationTypeComboBox";
            this.operationTypeComboBox.Size = new System.Drawing.Size(200, 21);
            this.operationTypeComboBox.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(5, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Rodzaj operacji";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // printButton
            // 
            this.printButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
            this.printButton.Location = new System.Drawing.Point(350, 226);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(75, 23);
            this.printButton.TabIndex = 25;
            this.printButton.Text = "Drukuj";
            this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 261);
            this.Controls.Add(this.printButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.exitButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "StatisticsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statystyka wypożyczalni";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StatisticsForm_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.resourcesTabPage.ResumeLayout(false);
            this.usersTabPage.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage resourcesTabPage;
        private System.Windows.Forms.TabPage usersTabPage;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox resourceStateComboBox;
        private System.Windows.Forms.Label resourceStateLabel;
        private System.Windows.Forms.ComboBox resourceGroupComboBox;
        private System.Windows.Forms.Label resourceGroupLabel;
        private System.Windows.Forms.DateTimePicker endDateDTP;
        private System.Windows.Forms.DateTimePicker startDateDTP;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.Label dateOfOperationLabel;
        private System.Windows.Forms.ComboBox userGroupComboBox;
        private System.Windows.Forms.Label groupLabel;
        private System.Windows.Forms.ComboBox userTypeComboBox;
        private System.Windows.Forms.Label userTypeLabel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker readingEndDTP;
        private System.Windows.Forms.DateTimePicker readingStartDTP;
        private System.Windows.Forms.ComboBox operationTypeComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.CheckBox onlyActiveUsersCheckBox;
    }
}