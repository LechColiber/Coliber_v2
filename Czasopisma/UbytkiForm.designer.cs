namespace Czasopisma
{
    partial class UbytkiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UbytkiForm));
            this.UbytkiDGV = new System.Windows.Forms.DataGridView();
            this.UbytkiSygIDDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UbytkiSygNameDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllDGV = new System.Windows.Forms.DataGridView();
            this.AllSygIDDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllSygNameDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.SygIDDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SygNameDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllToDeleteButton = new System.Windows.Forms.Button();
            this.ToDeleteButton = new System.Windows.Forms.Button();
            this.ToAllButton = new System.Windows.Forms.Button();
            this.AllToAllButton = new System.Windows.Forms.Button();
            this.AllToDGVButton = new System.Windows.Forms.Button();
            this.ToDGVButton = new System.Windows.Forms.Button();
            this.DGVToAllButton = new System.Windows.Forms.Button();
            this.AllDGVToAll = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UbytkiDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // UbytkiDGV
            // 
            this.UbytkiDGV.AllowUserToAddRows = false;
            this.UbytkiDGV.AllowUserToDeleteRows = false;
            this.UbytkiDGV.AllowUserToResizeRows = false;
            this.UbytkiDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UbytkiDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UbytkiDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UbytkiSygIDDGV,
            this.UbytkiSygNameDGV});
            this.UbytkiDGV.Location = new System.Drawing.Point(12, 29);
            this.UbytkiDGV.MultiSelect = false;
            this.UbytkiDGV.Name = "UbytkiDGV";
            this.UbytkiDGV.ReadOnly = true;
            this.UbytkiDGV.RowHeadersVisible = false;
            this.UbytkiDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UbytkiDGV.Size = new System.Drawing.Size(233, 280);
            this.UbytkiDGV.TabIndex = 0;
            // 
            // UbytkiSygIDDGV
            // 
            this.UbytkiSygIDDGV.DataPropertyName = "id_sygnat";
            this.UbytkiSygIDDGV.HeaderText = "id";
            this.UbytkiSygIDDGV.Name = "UbytkiSygIDDGV";
            this.UbytkiSygIDDGV.ReadOnly = true;
            this.UbytkiSygIDDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.UbytkiSygIDDGV.Visible = false;
            // 
            // UbytkiSygNameDGV
            // 
            this.UbytkiSygNameDGV.DataPropertyName = "syg";
            this.UbytkiSygNameDGV.HeaderText = "Sygnatura";
            this.UbytkiSygNameDGV.Name = "UbytkiSygNameDGV";
            this.UbytkiSygNameDGV.ReadOnly = true;
            this.UbytkiSygNameDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // AllDGV
            // 
            this.AllDGV.AllowUserToAddRows = false;
            this.AllDGV.AllowUserToDeleteRows = false;
            this.AllDGV.AllowUserToResizeRows = false;
            this.AllDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AllDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AllDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AllSygIDDGV,
            this.AllSygNameDGV});
            this.AllDGV.Location = new System.Drawing.Point(284, 29);
            this.AllDGV.MultiSelect = false;
            this.AllDGV.Name = "AllDGV";
            this.AllDGV.ReadOnly = true;
            this.AllDGV.RowHeadersVisible = false;
            this.AllDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AllDGV.Size = new System.Drawing.Size(243, 280);
            this.AllDGV.TabIndex = 1;
            // 
            // AllSygIDDGV
            // 
            this.AllSygIDDGV.DataPropertyName = "id_sygnat";
            this.AllSygIDDGV.HeaderText = "id";
            this.AllSygIDDGV.Name = "AllSygIDDGV";
            this.AllSygIDDGV.ReadOnly = true;
            this.AllSygIDDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.AllSygIDDGV.Visible = false;
            // 
            // AllSygNameDGV
            // 
            this.AllSygNameDGV.DataPropertyName = "syg";
            this.AllSygNameDGV.HeaderText = "Sygnatura";
            this.AllSygNameDGV.Name = "AllSygNameDGV";
            this.AllSygNameDGV.ReadOnly = true;
            this.AllSygNameDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SygIDDGV,
            this.SygNameDGV});
            this.DGV.Location = new System.Drawing.Point(566, 29);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersVisible = false;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(243, 280);
            this.DGV.TabIndex = 2;
            // 
            // SygIDDGV
            // 
            this.SygIDDGV.DataPropertyName = "id";
            this.SygIDDGV.HeaderText = "id";
            this.SygIDDGV.Name = "SygIDDGV";
            this.SygIDDGV.ReadOnly = true;
            this.SygIDDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.SygIDDGV.Visible = false;
            // 
            // SygNameDGV
            // 
            this.SygNameDGV.DataPropertyName = "syg";
            this.SygNameDGV.HeaderText = "Sygnatura";
            this.SygNameDGV.Name = "SygNameDGV";
            this.SygNameDGV.ReadOnly = true;
            this.SygNameDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // AllToDeleteButton
            // 
            this.AllToDeleteButton.Location = new System.Drawing.Point(251, 109);
            this.AllToDeleteButton.Name = "AllToDeleteButton";
            this.AllToDeleteButton.Size = new System.Drawing.Size(27, 23);
            this.AllToDeleteButton.TabIndex = 3;
            this.AllToDeleteButton.Text = "<<";
            this.AllToDeleteButton.UseVisualStyleBackColor = true;
            this.AllToDeleteButton.Click += new System.EventHandler(this.AllToDeleteButton_Click);
            // 
            // ToDeleteButton
            // 
            this.ToDeleteButton.Location = new System.Drawing.Point(251, 138);
            this.ToDeleteButton.Name = "ToDeleteButton";
            this.ToDeleteButton.Size = new System.Drawing.Size(27, 23);
            this.ToDeleteButton.TabIndex = 4;
            this.ToDeleteButton.Text = "<";
            this.ToDeleteButton.UseVisualStyleBackColor = true;
            this.ToDeleteButton.Click += new System.EventHandler(this.ToDelete_Click);
            // 
            // ToAllButton
            // 
            this.ToAllButton.Location = new System.Drawing.Point(251, 167);
            this.ToAllButton.Name = "ToAllButton";
            this.ToAllButton.Size = new System.Drawing.Size(27, 23);
            this.ToAllButton.TabIndex = 5;
            this.ToAllButton.Text = ">";
            this.ToAllButton.UseVisualStyleBackColor = true;
            this.ToAllButton.Click += new System.EventHandler(this.ToAllButton_Click);
            // 
            // AllToAllButton
            // 
            this.AllToAllButton.Location = new System.Drawing.Point(251, 196);
            this.AllToAllButton.Name = "AllToAllButton";
            this.AllToAllButton.Size = new System.Drawing.Size(27, 23);
            this.AllToAllButton.TabIndex = 6;
            this.AllToAllButton.Text = ">>";
            this.AllToAllButton.UseVisualStyleBackColor = true;
            this.AllToAllButton.Click += new System.EventHandler(this.AllToAll_Click);
            // 
            // AllToDGVButton
            // 
            this.AllToDGVButton.Location = new System.Drawing.Point(533, 109);
            this.AllToDGVButton.Name = "AllToDGVButton";
            this.AllToDGVButton.Size = new System.Drawing.Size(27, 23);
            this.AllToDGVButton.TabIndex = 10;
            this.AllToDGVButton.Text = ">>";
            this.AllToDGVButton.UseVisualStyleBackColor = true;
            this.AllToDGVButton.Click += new System.EventHandler(this.AllToDGVButton_Click);
            // 
            // ToDGVButton
            // 
            this.ToDGVButton.Location = new System.Drawing.Point(533, 138);
            this.ToDGVButton.Name = "ToDGVButton";
            this.ToDGVButton.Size = new System.Drawing.Size(27, 23);
            this.ToDGVButton.TabIndex = 9;
            this.ToDGVButton.Text = ">";
            this.ToDGVButton.UseVisualStyleBackColor = true;
            this.ToDGVButton.Click += new System.EventHandler(this.ToDGVButton_Click);
            // 
            // DGVToAllButton
            // 
            this.DGVToAllButton.Location = new System.Drawing.Point(533, 167);
            this.DGVToAllButton.Name = "DGVToAllButton";
            this.DGVToAllButton.Size = new System.Drawing.Size(27, 23);
            this.DGVToAllButton.TabIndex = 8;
            this.DGVToAllButton.Text = "<";
            this.DGVToAllButton.UseVisualStyleBackColor = true;
            this.DGVToAllButton.Click += new System.EventHandler(this.DGVToAllButton_Click);
            // 
            // AllDGVToAll
            // 
            this.AllDGVToAll.Location = new System.Drawing.Point(533, 196);
            this.AllDGVToAll.Name = "AllDGVToAll";
            this.AllDGVToAll.Size = new System.Drawing.Size(27, 23);
            this.AllDGVToAll.TabIndex = 7;
            this.AllDGVToAll.Text = "<<";
            this.AllDGVToAll.UseVisualStyleBackColor = true;
            this.AllDGVToAll.Click += new System.EventHandler(this.AllDGVToAll_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = ((System.Drawing.Image)(resources.GetObject("OkButton.Image")));
            this.OkButton.Location = new System.Drawing.Point(629, 326);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(87, 23);
            this.OkButton.TabIndex = 11;
            this.OkButton.Text = "Zatwierdź";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancButton
            // 
            this.CancButton.Image = ((System.Drawing.Image)(resources.GetObject("CancButton.Image")));
            this.CancButton.Location = new System.Drawing.Point(722, 326);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(87, 23);
            this.CancButton.TabIndex = 12;
            this.CancButton.Text = "Anuluj";
            this.CancButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancButton.UseVisualStyleBackColor = true;
            this.CancButton.Click += new System.EventHandler(this.CancButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Sygnatury do usunięcia z wpisem do księgi:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(291, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Istniejące sygnatury:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(573, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(215, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Sygnatury do usunięcia bez wpisu do księgi:";
            // 
            // UbytkiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 361);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.AllToDGVButton);
            this.Controls.Add(this.ToDGVButton);
            this.Controls.Add(this.DGVToAllButton);
            this.Controls.Add(this.AllDGVToAll);
            this.Controls.Add(this.AllToAllButton);
            this.Controls.Add(this.ToAllButton);
            this.Controls.Add(this.ToDeleteButton);
            this.Controls.Add(this.AllToDeleteButton);
            this.Controls.Add(this.DGV);
            this.Controls.Add(this.AllDGV);
            this.Controls.Add(this.UbytkiDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "UbytkiForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Usuwanie sygnatur czasopism";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UbytkiForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.UbytkiDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AllToDeleteButton;
        private System.Windows.Forms.Button ToDeleteButton;
        private System.Windows.Forms.Button ToAllButton;
        private System.Windows.Forms.Button AllToAllButton;
        private System.Windows.Forms.Button AllToDGVButton;
        private System.Windows.Forms.Button ToDGVButton;
        private System.Windows.Forms.Button DGVToAllButton;
        private System.Windows.Forms.Button AllDGVToAll;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView UbytkiDGV;
        public System.Windows.Forms.DataGridView AllDGV;
        public System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn UbytkiSygIDDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn UbytkiSygNameDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllSygIDDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn AllSygNameDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SygIDDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn SygNameDGV;
    }
}