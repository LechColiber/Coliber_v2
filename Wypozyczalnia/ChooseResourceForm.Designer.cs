namespace Wypozyczalnia
{
    partial class ChooseResourceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseResourceForm));
            this.searchFieldComboBox = new System.Windows.Forms.ComboBox();
            this.compareComboBox = new System.Windows.Forms.ComboBox();
            this.resourceTypeComboBox = new System.Windows.Forms.ComboBox();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.borrowedCheckBox = new System.Windows.Forms.CheckBox();
            this.notBorrowedCheckBox = new System.Windows.Forms.CheckBox();
            this.resultDGV = new System.Windows.Forms.DataGridView();
            this.selectButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.resourceIdDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noInvDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.signatureDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.resultDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // searchFieldComboBox
            // 
            this.searchFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchFieldComboBox.FormattingEnabled = true;
            this.searchFieldComboBox.Location = new System.Drawing.Point(13, 13);
            this.searchFieldComboBox.Name = "searchFieldComboBox";
            this.searchFieldComboBox.Size = new System.Drawing.Size(121, 21);
            this.searchFieldComboBox.TabIndex = 0;
            // 
            // compareComboBox
            // 
            this.compareComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compareComboBox.FormattingEnabled = true;
            this.compareComboBox.Location = new System.Drawing.Point(140, 12);
            this.compareComboBox.Name = "compareComboBox";
            this.compareComboBox.Size = new System.Drawing.Size(121, 21);
            this.compareComboBox.TabIndex = 1;
            // 
            // resourceTypeComboBox
            // 
            this.resourceTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resourceTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resourceTypeComboBox.FormattingEnabled = true;
            this.resourceTypeComboBox.Location = new System.Drawing.Point(821, 12);
            this.resourceTypeComboBox.Name = "resourceTypeComboBox";
            this.resourceTypeComboBox.Size = new System.Drawing.Size(151, 21);
            this.resourceTypeComboBox.TabIndex = 6;
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(267, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(279, 20);
            this.searchTextBox.TabIndex = 2;
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // borrowedCheckBox
            // 
            this.borrowedCheckBox.AutoSize = true;
            this.borrowedCheckBox.Location = new System.Drawing.Point(595, 7);
            this.borrowedCheckBox.Name = "borrowedCheckBox";
            this.borrowedCheckBox.Size = new System.Drawing.Size(93, 17);
            this.borrowedCheckBox.TabIndex = 4;
            this.borrowedCheckBox.Text = "Wypożyczone";
            this.borrowedCheckBox.UseVisualStyleBackColor = true;
            // 
            // notBorrowedCheckBox
            // 
            this.notBorrowedCheckBox.AutoSize = true;
            this.notBorrowedCheckBox.Checked = true;
            this.notBorrowedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.notBorrowedCheckBox.Location = new System.Drawing.Point(595, 25);
            this.notBorrowedCheckBox.Name = "notBorrowedCheckBox";
            this.notBorrowedCheckBox.Size = new System.Drawing.Size(106, 17);
            this.notBorrowedCheckBox.TabIndex = 5;
            this.notBorrowedCheckBox.Text = "Niewypożyczone";
            this.notBorrowedCheckBox.UseVisualStyleBackColor = true;
            // 
            // resultDGV
            // 
            this.resultDGV.AllowUserToAddRows = false;
            this.resultDGV.AllowUserToDeleteRows = false;
            this.resultDGV.AllowUserToResizeRows = false;
            this.resultDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.resourceIdDGVC,
            this.descriptionDGVC,
            this.authorDGVC,
            this.barcodeDGVC,
            this.noInvDGVC,
            this.signatureDGVC});
            this.resultDGV.Location = new System.Drawing.Point(12, 48);
            this.resultDGV.MultiSelect = false;
            this.resultDGV.Name = "resultDGV";
            this.resultDGV.ReadOnly = true;
            this.resultDGV.RowHeadersVisible = false;
            this.resultDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.resultDGV.Size = new System.Drawing.Size(960, 522);
            this.resultDGV.StandardTab = true;
            this.resultDGV.TabIndex = 7;
            this.resultDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.resultDGV_CellDoubleClick);
            this.resultDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resultDGV_KeyDown);
            // 
            // selectButton
            // 
            this.selectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectButton.Image = ((System.Drawing.Image)(resources.GetObject("selectButton.Image")));
            this.selectButton.Location = new System.Drawing.Point(12, 576);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 23);
            this.selectButton.TabIndex = 8;
            this.selectButton.Text = "Wybierz";
            this.selectButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.Location = new System.Drawing.Point(897, 576);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "Wyjście";
            this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
            this.searchButton.Location = new System.Drawing.Point(552, 10);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(37, 25);
            this.searchButton.TabIndex = 3;
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // resourceIdDGVC
            // 
            this.resourceIdDGVC.HeaderText = "id";
            this.resourceIdDGVC.Name = "resourceIdDGVC";
            this.resourceIdDGVC.ReadOnly = true;
            this.resourceIdDGVC.Visible = false;
            // 
            // descriptionDGVC
            // 
            this.descriptionDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDGVC.HeaderText = "Tytuł";
            this.descriptionDGVC.Name = "descriptionDGVC";
            this.descriptionDGVC.ReadOnly = true;
            // 
            // authorDGVC
            // 
            this.authorDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.authorDGVC.HeaderText = "Autor";
            this.authorDGVC.Name = "authorDGVC";
            this.authorDGVC.ReadOnly = true;
            this.authorDGVC.Width = 200;
            // 
            // barcodeDGVC
            // 
            this.barcodeDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.barcodeDGVC.HeaderText = "Kod kreskowy";
            this.barcodeDGVC.Name = "barcodeDGVC";
            this.barcodeDGVC.ReadOnly = true;
            // 
            // noInvDGVC
            // 
            this.noInvDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.noInvDGVC.HeaderText = "Numer inwentarzowy";
            this.noInvDGVC.Name = "noInvDGVC";
            this.noInvDGVC.ReadOnly = true;
            // 
            // signatureDGVC
            // 
            this.signatureDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.signatureDGVC.HeaderText = "Sygnatura";
            this.signatureDGVC.Name = "signatureDGVC";
            this.signatureDGVC.ReadOnly = true;
            // 
            // ChooseResourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.resultDGV);
            this.Controls.Add(this.selectButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.notBorrowedCheckBox);
            this.Controls.Add(this.borrowedCheckBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.resourceTypeComboBox);
            this.Controls.Add(this.compareComboBox);
            this.Controls.Add(this.searchFieldComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "ChooseResourceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wybór zasobu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseResourceForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.resultDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox searchFieldComboBox;
        private System.Windows.Forms.ComboBox compareComboBox;
        private System.Windows.Forms.ComboBox resourceTypeComboBox;
        private System.Windows.Forms.TextBox searchTextBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.CheckBox borrowedCheckBox;
        private System.Windows.Forms.CheckBox notBorrowedCheckBox;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.DataGridView resultDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn noInvDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn signatureDGVC;
    }
}