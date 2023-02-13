namespace WindowsFormsApplication1
{
    partial class SortOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortOrderForm));
            this.ContentDGV = new System.Windows.Forms.DataGridView();
            this.idDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciagDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OldOrderDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UpButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ContentDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ContentDGV
            // 
            this.ContentDGV.AllowUserToAddRows = false;
            this.ContentDGV.AllowUserToDeleteRows = false;
            this.ContentDGV.AllowUserToResizeRows = false;
            this.ContentDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ContentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ContentDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDGVC,
            this.ciagDGVC,
            this.OldOrderDGVC});
            this.ContentDGV.Location = new System.Drawing.Point(12, 23);
            this.ContentDGV.MultiSelect = false;
            this.ContentDGV.Name = "ContentDGV";
            this.ContentDGV.ReadOnly = true;
            this.ContentDGV.RowHeadersVisible = false;
            this.ContentDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ContentDGV.Size = new System.Drawing.Size(426, 290);
            this.ContentDGV.TabIndex = 0;
            this.ContentDGV.SelectionChanged += new System.EventHandler(this.ContentDGV_SelectionChanged);
            // 
            // idDGVC
            // 
            this.idDGVC.DataPropertyName = "id";
            this.idDGVC.HeaderText = "id";
            this.idDGVC.Name = "idDGVC";
            this.idDGVC.ReadOnly = true;
            this.idDGVC.Visible = false;
            // 
            // ciagDGVC
            // 
            this.ciagDGVC.DataPropertyName = "ciag";
            this.ciagDGVC.HeaderText = "Ciąg";
            this.ciagDGVC.Name = "ciagDGVC";
            this.ciagDGVC.ReadOnly = true;
            this.ciagDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OldOrderDGVC
            // 
            this.OldOrderDGVC.HeaderText = "OldOrder";
            this.OldOrderDGVC.Name = "OldOrderDGVC";
            this.OldOrderDGVC.ReadOnly = true;
            this.OldOrderDGVC.Visible = false;
            // 
            // UpButton
            // 
            this.UpButton.Enabled = false;
            this.UpButton.Image = ((System.Drawing.Image)(resources.GetObject("UpButton.Image")));
            this.UpButton.Location = new System.Drawing.Point(444, 46);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(75, 23);
            this.UpButton.TabIndex = 1;
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Enabled = false;
            this.DownButton.Image = ((System.Drawing.Image)(resources.GetObject("DownButton.Image")));
            this.DownButton.Location = new System.Drawing.Point(444, 75);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(75, 23);
            this.DownButton.TabIndex = 2;
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Image")));
            this.EditButton.Location = new System.Drawing.Point(444, 191);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 23;
            this.EditButton.Text = "Edytuj";
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
            this.AddButton.Location = new System.Drawing.Point(444, 162);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 22;
            this.AddButton.Text = "Dodaj";
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Location = new System.Drawing.Point(444, 220);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 24;
            this.DeleteButton.Text = "Usuń";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = ((System.Drawing.Image)(resources.GetObject("EscapeButton.Image")));
            this.EscapeButton.Location = new System.Drawing.Point(267, 331);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(84, 23);
            this.EscapeButton.TabIndex = 21;
            this.EscapeButton.Text = "Wyjście";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = ((System.Drawing.Image)(resources.GetObject("OkButton.Image")));
            this.OkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkButton.Location = new System.Drawing.Point(177, 331);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(84, 23);
            this.OkButton.TabIndex = 20;
            this.OkButton.Text = "Zatwierdź";
            this.OkButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // SortOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(529, 365);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.DownButton);
            this.Controls.Add(this.UpButton);
            this.Controls.Add(this.ContentDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SortOrderForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kolejność sortowania";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SortOrderForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ContentDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ContentDGV;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciagDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn OldOrderDGVC;
    }
}