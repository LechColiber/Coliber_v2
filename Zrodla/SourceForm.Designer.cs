namespace Zrodla
{
    partial class SourceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SourceForm));
            this.FilesDGV = new System.Windows.Forms.DataGridView();
            this.URLsDGV = new System.Windows.Forms.DataGridView();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.DeleteFilesButton = new System.Windows.Forms.Button();
            this.EditFilesButton = new System.Windows.Forms.Button();
            this.AddFilesButton = new System.Windows.Forms.Button();
            this.DownloadFileButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.OrdinalFilesDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrdinalURLsDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameURLsDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URLURLsDGV = new System.Windows.Forms.DataGridViewLinkColumn();
            this.DateURLsDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentsURLsDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.FilesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.URLsDGV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // FilesDGV
            // 
            this.FilesDGV.AllowUserToAddRows = false;
            this.FilesDGV.AllowUserToDeleteRows = false;
            this.FilesDGV.AllowUserToResizeRows = false;
            this.FilesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FilesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrdinalFilesDGV,
            this.FileName,
            this.Date,
            this.Comments});
            this.FilesDGV.Location = new System.Drawing.Point(10, 19);
            this.FilesDGV.MultiSelect = false;
            this.FilesDGV.Name = "FilesDGV";
            this.FilesDGV.ReadOnly = true;
            this.FilesDGV.RowHeadersVisible = false;
            this.FilesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FilesDGV.Size = new System.Drawing.Size(660, 150);
            this.FilesDGV.TabIndex = 0;
            this.FilesDGV.DataSourceChanged += new System.EventHandler(this.FilesDGV_DataSourceChanged);
            this.FilesDGV.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.FilesDGV_CellDoubleClick);
            this.FilesDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FilesDGV_KeyDown);
            // 
            // URLsDGV
            // 
            this.URLsDGV.AllowUserToAddRows = false;
            this.URLsDGV.AllowUserToDeleteRows = false;
            this.URLsDGV.AllowUserToResizeRows = false;
            this.URLsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.URLsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.URLsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrdinalURLsDGV,
            this.NameURLsDGV,
            this.URLURLsDGV,
            this.DateURLsDGV,
            this.CommentsURLsDGV});
            this.URLsDGV.Location = new System.Drawing.Point(10, 19);
            this.URLsDGV.MultiSelect = false;
            this.URLsDGV.Name = "URLsDGV";
            this.URLsDGV.ReadOnly = true;
            this.URLsDGV.RowHeadersVisible = false;
            this.URLsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.URLsDGV.Size = new System.Drawing.Size(660, 150);
            this.URLsDGV.TabIndex = 2;
            this.URLsDGV.DataSourceChanged += new System.EventHandler(this.URLsDGV_DataSourceChanged);
            this.URLsDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.URLsDGV_CellContentClick);
            // 
            // AddButton
            // 
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.Location = new System.Drawing.Point(10, 175);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(90, 23);
            this.AddButton.TabIndex = 5;
            this.AddButton.Text = "Załącz";
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Image")));
            this.EditButton.Location = new System.Drawing.Point(106, 175);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(90, 23);
            this.EditButton.TabIndex = 6;
            this.EditButton.Text = "Edytuj";
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Location = new System.Drawing.Point(202, 175);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(90, 23);
            this.DeleteButton.TabIndex = 7;
            this.DeleteButton.Text = "Usuń";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(601, 434);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(90, 23);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // DeleteFilesButton
            // 
            this.DeleteFilesButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteFilesButton.Image")));
            this.DeleteFilesButton.Location = new System.Drawing.Point(202, 175);
            this.DeleteFilesButton.Name = "DeleteFilesButton";
            this.DeleteFilesButton.Size = new System.Drawing.Size(90, 23);
            this.DeleteFilesButton.TabIndex = 11;
            this.DeleteFilesButton.Text = "Usuń";
            this.DeleteFilesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteFilesButton.UseVisualStyleBackColor = true;
            this.DeleteFilesButton.Click += new System.EventHandler(this.DeleteFilesButton_Click);
            // 
            // EditFilesButton
            // 
            this.EditFilesButton.Image = ((System.Drawing.Image)(resources.GetObject("EditFilesButton.Image")));
            this.EditFilesButton.Location = new System.Drawing.Point(106, 175);
            this.EditFilesButton.Name = "EditFilesButton";
            this.EditFilesButton.Size = new System.Drawing.Size(90, 23);
            this.EditFilesButton.TabIndex = 10;
            this.EditFilesButton.Text = "Edytuj";
            this.EditFilesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditFilesButton.UseVisualStyleBackColor = true;
            this.EditFilesButton.Click += new System.EventHandler(this.EditFilesButton_Click);
            // 
            // AddFilesButton
            // 
            this.AddFilesButton.Image = ((System.Drawing.Image)(resources.GetObject("AddFilesButton.Image")));
            this.AddFilesButton.Location = new System.Drawing.Point(10, 175);
            this.AddFilesButton.Name = "AddFilesButton";
            this.AddFilesButton.Size = new System.Drawing.Size(90, 23);
            this.AddFilesButton.TabIndex = 9;
            this.AddFilesButton.Text = "Załącz";
            this.AddFilesButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddFilesButton.UseVisualStyleBackColor = true;
            this.AddFilesButton.Click += new System.EventHandler(this.AddFilesButton_Click);
            // 
            // DownloadFileButton
            // 
            this.DownloadFileButton.Image = ((System.Drawing.Image)(resources.GetObject("DownloadFileButton.Image")));
            this.DownloadFileButton.Location = new System.Drawing.Point(580, 175);
            this.DownloadFileButton.Name = "DownloadFileButton";
            this.DownloadFileButton.Size = new System.Drawing.Size(90, 23);
            this.DownloadFileButton.TabIndex = 12;
            this.DownloadFileButton.Text = "Pobierz";
            this.DownloadFileButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DownloadFileButton.UseVisualStyleBackColor = true;
            this.DownloadFileButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.FilesDGV);
            this.groupBox1.Controls.Add(this.DownloadFileButton);
            this.groupBox1.Controls.Add(this.AddFilesButton);
            this.groupBox1.Controls.Add(this.DeleteFilesButton);
            this.groupBox1.Controls.Add(this.EditFilesButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 206);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pliki do pobrania";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.URLsDGV);
            this.groupBox2.Controls.Add(this.AddButton);
            this.groupBox2.Controls.Add(this.DeleteButton);
            this.groupBox2.Controls.Add(this.EditButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(679, 204);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Adresy URL";
            // 
            // OrdinalFilesDGV
            // 
            this.OrdinalFilesDGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OrdinalFilesDGV.DataPropertyName = "L.p.";
            this.OrdinalFilesDGV.HeaderText = "L.p.";
            this.OrdinalFilesDGV.Name = "OrdinalFilesDGV";
            this.OrdinalFilesDGV.ReadOnly = true;
            this.OrdinalFilesDGV.Width = 50;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "nazwa";
            this.FileName.HeaderText = "Nazwa pliku";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Date.DataPropertyName = "data_dodania";
            this.Date.HeaderText = "Data dodania";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Width = 96;
            // 
            // Comments
            // 
            this.Comments.DataPropertyName = "uwagi";
            this.Comments.HeaderText = "Uwagi";
            this.Comments.Name = "Comments";
            this.Comments.ReadOnly = true;
            // 
            // OrdinalURLsDGV
            // 
            this.OrdinalURLsDGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OrdinalURLsDGV.DataPropertyName = "L.p.";
            this.OrdinalURLsDGV.HeaderText = "L.p.";
            this.OrdinalURLsDGV.Name = "OrdinalURLsDGV";
            this.OrdinalURLsDGV.ReadOnly = true;
            this.OrdinalURLsDGV.Width = 50;
            // 
            // NameURLsDGV
            // 
            this.NameURLsDGV.DataPropertyName = "nazwa";
            this.NameURLsDGV.HeaderText = "Nazwa";
            this.NameURLsDGV.Name = "NameURLsDGV";
            this.NameURLsDGV.ReadOnly = true;
            // 
            // URLURLsDGV
            // 
            this.URLURLsDGV.DataPropertyName = "URL";
            this.URLURLsDGV.HeaderText = "Adres";
            this.URLURLsDGV.Name = "URLURLsDGV";
            this.URLURLsDGV.ReadOnly = true;
            // 
            // DateURLsDGV
            // 
            this.DateURLsDGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateURLsDGV.DataPropertyName = "data_dodania";
            this.DateURLsDGV.HeaderText = "Data dodania";
            this.DateURLsDGV.Name = "DateURLsDGV";
            this.DateURLsDGV.ReadOnly = true;
            this.DateURLsDGV.Width = 96;
            // 
            // CommentsURLsDGV
            // 
            this.CommentsURLsDGV.DataPropertyName = "uwagi";
            this.CommentsURLsDGV.HeaderText = "Uwagi";
            this.CommentsURLsDGV.Name = "CommentsURLsDGV";
            this.CommentsURLsDGV.ReadOnly = true;
            // 
            // SourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 463);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SourceForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zestawienie źródeł";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SourceForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FilesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.URLsDGV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FilesDGV;
        private System.Windows.Forms.DataGridView URLsDGV;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button DeleteFilesButton;
        private System.Windows.Forms.Button EditFilesButton;
        private System.Windows.Forms.Button AddFilesButton;
        private System.Windows.Forms.Button DownloadFileButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdinalFilesDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdinalURLsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameURLsDGV;
        private System.Windows.Forms.DataGridViewLinkColumn URLURLsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateURLsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentsURLsDGV;
    }
}

