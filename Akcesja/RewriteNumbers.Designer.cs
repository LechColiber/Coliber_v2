namespace Akcesja
{
    partial class RewriteNumbers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RewriteNumbers));
            this.DGV = new System.Windows.Forms.DataGridView();
            this.id_volumesDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sygDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wolumin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.CheckCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeRows = false;
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_volumesDGVC,
            this.Check,
            this.sygDGVC,
            this.Rok,
            this.Wolumin});
            this.DGV.Location = new System.Drawing.Point(12, 30);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersVisible = false;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(470, 325);
            this.DGV.TabIndex = 0;
            // 
            // id_volumesDGVC
            // 
            this.id_volumesDGVC.DataPropertyName = "id_volumes";
            this.id_volumesDGVC.HeaderText = "id_volumes";
            this.id_volumesDGVC.Name = "id_volumesDGVC";
            this.id_volumesDGVC.Visible = false;
            // 
            // Check
            // 
            this.Check.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Check.FalseValue = "False";
            this.Check.HeaderText = "";
            this.Check.IndeterminateValue = "False";
            this.Check.Name = "Check";
            this.Check.TrueValue = "True";
            this.Check.Width = 5;
            // 
            // sygDGVC
            // 
            this.sygDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sygDGVC.DataPropertyName = "syg";
            this.sygDGVC.HeaderText = "Sygnatura";
            this.sygDGVC.Name = "sygDGVC";
            this.sygDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sygDGVC.Width = 61;
            // 
            // Rok
            // 
            this.Rok.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Rok.DataPropertyName = "rok";
            this.Rok.HeaderText = "Rok";
            this.Rok.Name = "Rok";
            this.Rok.ReadOnly = true;
            this.Rok.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Rok.Width = 33;
            // 
            // Wolumin
            // 
            this.Wolumin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Wolumin.DataPropertyName = "volumin";
            this.Wolumin.HeaderText = "Wolumin";
            this.Wolumin.Name = "Wolumin";
            this.Wolumin.ReadOnly = true;
            this.Wolumin.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OKButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OKButton.Image = ((System.Drawing.Image)(resources.GetObject("OKButton.Image")));
            this.OKButton.Location = new System.Drawing.Point(160, 361);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(84, 23);
            this.OKButton.TabIndex = 20;
            this.OKButton.Text = "Aktualizuj";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelButton.Image")));
            this.CancelButton.Location = new System.Drawing.Point(250, 361);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(84, 23);
            this.CancelButton.TabIndex = 21;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // CheckCheckBox
            // 
            this.CheckCheckBox.AutoSize = true;
            this.CheckCheckBox.Location = new System.Drawing.Point(17, 7);
            this.CheckCheckBox.Name = "CheckCheckBox";
            this.CheckCheckBox.Size = new System.Drawing.Size(113, 17);
            this.CheckCheckBox.TabIndex = 22;
            this.CheckCheckBox.Text = "Zaznacz wszystko";
            this.CheckCheckBox.UseVisualStyleBackColor = true;
            this.CheckCheckBox.CheckedChanged += new System.EventHandler(this.CheckCheckBox_CheckedChanged);
            // 
            // RewriteNumbers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 391);
            this.Controls.Add(this.CheckCheckBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.DGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(510, 430);
            this.Name = "RewriteNumbers";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Aktualizacja numerów";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RewriteNumbers_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.CheckBox CheckCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_volumesDGVC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn sygDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wolumin;


    }
}