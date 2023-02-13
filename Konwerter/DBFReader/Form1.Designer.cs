namespace DBFReader
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.listDGV = new System.Windows.Forms.DataGridView();
            this.keyDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkDGVC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tableDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.rowsCountLabel = new System.Windows.Forms.Label();
            this.importedCountLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.exportButton = new System.Windows.Forms.Button();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pathTextBox = new System.Windows.Forms.TextBox();
            this.containsResourceIdCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(1288, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Wczytaj z DBF";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(221, 86);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1168, 536);
            this.dataGridView1.TabIndex = 4;
            // 
            // listDGV
            // 
            this.listDGV.AllowUserToAddRows = false;
            this.listDGV.AllowUserToDeleteRows = false;
            this.listDGV.AllowUserToResizeRows = false;
            this.listDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.keyDGVC,
            this.checkDGVC,
            this.tableDGVC});
            this.listDGV.Location = new System.Drawing.Point(12, 86);
            this.listDGV.MultiSelect = false;
            this.listDGV.Name = "listDGV";
            this.listDGV.RowHeadersVisible = false;
            this.listDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.listDGV.Size = new System.Drawing.Size(203, 536);
            this.listDGV.TabIndex = 6;
            this.listDGV.SelectionChanged += new System.EventHandler(this.listDGV_SelectionChanged_1);
            // 
            // keyDGVC
            // 
            this.keyDGVC.HeaderText = "Column1";
            this.keyDGVC.Name = "keyDGVC";
            this.keyDGVC.Visible = false;
            // 
            // checkDGVC
            // 
            this.checkDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.checkDGVC.HeaderText = "";
            this.checkDGVC.Name = "checkDGVC";
            this.checkDGVC.Width = 5;
            // 
            // tableDGVC
            // 
            this.tableDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.tableDGVC.HeaderText = "Tabela";
            this.tableDGVC.Name = "tableDGVC";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(221, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Liczba wierszy:";
            // 
            // rowsCountLabel
            // 
            this.rowsCountLabel.AutoSize = true;
            this.rowsCountLabel.Location = new System.Drawing.Point(306, 67);
            this.rowsCountLabel.Name = "rowsCountLabel";
            this.rowsCountLabel.Size = new System.Drawing.Size(13, 13);
            this.rowsCountLabel.TabIndex = 8;
            this.rowsCountLabel.Text = "0";
            // 
            // importedCountLabel
            // 
            this.importedCountLabel.AutoSize = true;
            this.importedCountLabel.Location = new System.Drawing.Point(306, 50);
            this.importedCountLabel.Name = "importedCountLabel";
            this.importedCountLabel.Size = new System.Drawing.Size(13, 13);
            this.importedCountLabel.TabIndex = 10;
            this.importedCountLabel.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(221, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Wczytano:";
            // 
            // exportButton
            // 
            this.exportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exportButton.Enabled = false;
            this.exportButton.Location = new System.Drawing.Point(1288, 40);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(101, 23);
            this.exportButton.TabIndex = 11;
            this.exportButton.Text = "Eksport do SQL";
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(283, 9);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(125, 23);
            this.selectFolderButton.TabIndex = 13;
            this.selectFolderButton.Text = "Wskaż folder z bazą";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.SelectedPath = "D:\\Exell\\TK\\BAZY";
            // 
            // pathTextBox
            // 
            this.pathTextBox.Location = new System.Drawing.Point(13, 11);
            this.pathTextBox.Name = "pathTextBox";
            this.pathTextBox.ReadOnly = true;
            this.pathTextBox.Size = new System.Drawing.Size(264, 20);
            this.pathTextBox.TabIndex = 14;
            // 
            // containsResourceIdCheckBox
            // 
            this.containsResourceIdCheckBox.AutoSize = true;
            this.containsResourceIdCheckBox.Location = new System.Drawing.Point(1137, 15);
            this.containsResourceIdCheckBox.Name = "containsResourceIdCheckBox";
            this.containsResourceIdCheckBox.Size = new System.Drawing.Size(145, 17);
            this.containsResourceIdCheckBox.TabIndex = 15;
            this.containsResourceIdCheckBox.Text = "\"wypozycz\" z \"id_zasob\"";
            this.containsResourceIdCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1401, 634);
            this.Controls.Add(this.containsResourceIdCheckBox);
            this.Controls.Add(this.pathTextBox);
            this.Controls.Add(this.selectFolderButton);
            this.Controls.Add(this.exportButton);
            this.Controls.Add(this.importedCountLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rowsCountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listDGV);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView listDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDGVC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn tableDGVC;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rowsCountLabel;
        private System.Windows.Forms.Label importedCountLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button selectFolderButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox pathTextBox;
        private System.Windows.Forms.CheckBox containsResourceIdCheckBox;
    }
}

