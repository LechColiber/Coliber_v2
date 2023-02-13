namespace Coliber
{
    partial class ChooseInvertoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseInvertoryForm));
            this.label1 = new System.Windows.Forms.Label();
            this.DbsDGV = new System.Windows.Forms.DataGridView();
            this.id_rodzaj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inwentarz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DbsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(382, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybierz inwentarz, w którym chcesz dodać pozycję.";
            // 
            // DbsDGV
            // 
            this.DbsDGV.AllowUserToAddRows = false;
            this.DbsDGV.AllowUserToDeleteRows = false;
            this.DbsDGV.AllowUserToResizeRows = false;
            this.DbsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DbsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DbsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_rodzaj,
            this.Inwentarz});
            this.DbsDGV.Location = new System.Drawing.Point(12, 36);
            this.DbsDGV.MultiSelect = false;
            this.DbsDGV.Name = "DbsDGV";
            this.DbsDGV.ReadOnly = true;
            this.DbsDGV.RowHeadersVisible = false;
            this.DbsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DbsDGV.Size = new System.Drawing.Size(382, 201);
            this.DbsDGV.TabIndex = 2;
            // 
            // id_rodzaj
            // 
            this.id_rodzaj.DataPropertyName = "id_rodzaj";
            this.id_rodzaj.HeaderText = "id_rodzaj";
            this.id_rodzaj.Name = "id_rodzaj";
            this.id_rodzaj.ReadOnly = true;
            this.id_rodzaj.Visible = false;
            // 
            // Inwentarz
            // 
            this.Inwentarz.DataPropertyName = "inwentarz";
            this.Inwentarz.HeaderText = "Inwentarz";
            this.Inwentarz.Name = "Inwentarz";
            this.Inwentarz.ReadOnly = true;
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = ((System.Drawing.Image)(resources.GetObject("EscapeButton.Image")));
            this.EscapeButton.Location = new System.Drawing.Point(210, 259);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(75, 23);
            this.EscapeButton.TabIndex = 5;
            this.EscapeButton.Text = "Anuluj";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = ((System.Drawing.Image)(resources.GetObject("OkButton.Image")));
            this.OkButton.Location = new System.Drawing.Point(129, 259);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "Wybierz";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ChooseInvertoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 293);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.DbsDGV);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ChooseInvertoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wybór inwentarza";
            ((System.ComponentModel.ISupportInitialize)(this.DbsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DbsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_rodzaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inwentarz;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button OkButton;
    }
}