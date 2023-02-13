namespace Czasopisma
{
    partial class UbytkowanieForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UbytkowanieForm));
            this.UbytkiDGV = new System.Windows.Forms.DataGridView();
            this.id_volumesDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CheckBoxDGVC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WoluminDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumbersDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumbersLabel = new System.Windows.Forms.Label();
            this.VoluminLabel = new System.Windows.Forms.Label();
            this.YearLabel = new System.Windows.Forms.Label();
            this.SygLabel = new System.Windows.Forms.Label();
            this.numberTextLabel = new System.Windows.Forms.Label();
            this.voluminTextLabel = new System.Windows.Forms.Label();
            this.yearTextLabel = new System.Windows.Forms.Label();
            this.signatureLabel = new System.Windows.Forms.Label();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.NextNumberLabel = new System.Windows.Forms.Label();
            this.NumInwLabel = new System.Windows.Forms.Label();
            this.absNoLabel = new System.Windows.Forms.Label();
            this.invNoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UbytkiDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // UbytkiDGV
            // 
            this.UbytkiDGV.AllowUserToAddRows = false;
            this.UbytkiDGV.AllowUserToDeleteRows = false;
            this.UbytkiDGV.AllowUserToResizeRows = false;
            this.UbytkiDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.UbytkiDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.UbytkiDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UbytkiDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_volumesDGVC,
            this.CheckBoxDGVC,
            this.WoluminDGVC,
            this.NumbersDGVC});
            this.UbytkiDGV.Location = new System.Drawing.Point(12, 134);
            this.UbytkiDGV.MultiSelect = false;
            this.UbytkiDGV.Name = "UbytkiDGV";
            this.UbytkiDGV.RowHeadersVisible = false;
            this.UbytkiDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UbytkiDGV.Size = new System.Drawing.Size(510, 178);
            this.UbytkiDGV.TabIndex = 0;
            this.UbytkiDGV.SelectionChanged += new System.EventHandler(this.UbytkiDGV_SelectionChanged);
            // 
            // id_volumesDGVC
            // 
            this.id_volumesDGVC.HeaderText = "Column1";
            this.id_volumesDGVC.Name = "id_volumesDGVC";
            this.id_volumesDGVC.Visible = false;
            // 
            // CheckBoxDGVC
            // 
            this.CheckBoxDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.CheckBoxDGVC.HeaderText = "Usuń";
            this.CheckBoxDGVC.Name = "CheckBoxDGVC";
            this.CheckBoxDGVC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CheckBoxDGVC.Width = 38;
            // 
            // WoluminDGVC
            // 
            this.WoluminDGVC.HeaderText = "Wolumin";
            this.WoluminDGVC.Name = "WoluminDGVC";
            this.WoluminDGVC.ReadOnly = true;
            this.WoluminDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // NumbersDGVC
            // 
            this.NumbersDGVC.HeaderText = "Numery";
            this.NumbersDGVC.Name = "NumbersDGVC";
            this.NumbersDGVC.ReadOnly = true;
            this.NumbersDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumbersDGVC.Visible = false;
            // 
            // NumbersLabel
            // 
            this.NumbersLabel.AutoSize = true;
            this.NumbersLabel.Location = new System.Drawing.Point(82, 79);
            this.NumbersLabel.Name = "NumbersLabel";
            this.NumbersLabel.Size = new System.Drawing.Size(35, 13);
            this.NumbersLabel.TabIndex = 15;
            this.NumbersLabel.Text = "label8";
            // 
            // VoluminLabel
            // 
            this.VoluminLabel.AutoSize = true;
            this.VoluminLabel.Location = new System.Drawing.Point(82, 56);
            this.VoluminLabel.Name = "VoluminLabel";
            this.VoluminLabel.Size = new System.Drawing.Size(35, 13);
            this.VoluminLabel.TabIndex = 14;
            this.VoluminLabel.Text = "label7";
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Location = new System.Drawing.Point(82, 33);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(35, 13);
            this.YearLabel.TabIndex = 13;
            this.YearLabel.Text = "label6";
            // 
            // SygLabel
            // 
            this.SygLabel.AutoSize = true;
            this.SygLabel.Location = new System.Drawing.Point(82, 9);
            this.SygLabel.Name = "SygLabel";
            this.SygLabel.Size = new System.Drawing.Size(35, 13);
            this.SygLabel.TabIndex = 12;
            this.SygLabel.Text = "label5";
            // 
            // numberTextLabel
            // 
            this.numberTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numberTextLabel.Location = new System.Drawing.Point(15, 79);
            this.numberTextLabel.Name = "numberTextLabel";
            this.numberTextLabel.Size = new System.Drawing.Size(61, 13);
            this.numberTextLabel.TabIndex = 11;
            this.numberTextLabel.Text = "Numery";
            this.numberTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // voluminTextLabel
            // 
            this.voluminTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.voluminTextLabel.Location = new System.Drawing.Point(15, 56);
            this.voluminTextLabel.Name = "voluminTextLabel";
            this.voluminTextLabel.Size = new System.Drawing.Size(61, 13);
            this.voluminTextLabel.TabIndex = 10;
            this.voluminTextLabel.Text = "Wolumin";
            this.voluminTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // yearTextLabel
            // 
            this.yearTextLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.yearTextLabel.Location = new System.Drawing.Point(15, 33);
            this.yearTextLabel.Name = "yearTextLabel";
            this.yearTextLabel.Size = new System.Drawing.Size(61, 13);
            this.yearTextLabel.TabIndex = 9;
            this.yearTextLabel.Text = "Rok";
            this.yearTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // signatureLabel
            // 
            this.signatureLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.signatureLabel.Location = new System.Drawing.Point(12, 9);
            this.signatureLabel.Name = "signatureLabel";
            this.signatureLabel.Size = new System.Drawing.Size(64, 13);
            this.signatureLabel.TabIndex = 8;
            this.signatureLabel.Text = "Sygnatura";
            this.signatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EscapeButton
            // 
            this.EscapeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EscapeButton.Image = ((System.Drawing.Image)(resources.GetObject("EscapeButton.Image")));
            this.EscapeButton.Location = new System.Drawing.Point(434, 326);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(88, 23);
            this.EscapeButton.TabIndex = 17;
            this.EscapeButton.Text = "Anuluj";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Image = ((System.Drawing.Image)(resources.GetObject("OkButton.Image")));
            this.OkButton.Location = new System.Drawing.Point(340, 326);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(88, 23);
            this.OkButton.TabIndex = 16;
            this.OkButton.Text = "Zatwierdź";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // NextNumberLabel
            // 
            this.NextNumberLabel.AutoSize = true;
            this.NextNumberLabel.Location = new System.Drawing.Point(379, 32);
            this.NextNumberLabel.Name = "NextNumberLabel";
            this.NextNumberLabel.Size = new System.Drawing.Size(35, 13);
            this.NextNumberLabel.TabIndex = 27;
            this.NextNumberLabel.Text = "label8";
            // 
            // NumInwLabel
            // 
            this.NumInwLabel.AutoSize = true;
            this.NumInwLabel.Location = new System.Drawing.Point(379, 9);
            this.NumInwLabel.Name = "NumInwLabel";
            this.NumInwLabel.Size = new System.Drawing.Size(35, 13);
            this.NumInwLabel.TabIndex = 26;
            this.NumInwLabel.Text = "label7";
            // 
            // absNoLabel
            // 
            this.absNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.absNoLabel.Location = new System.Drawing.Point(241, 32);
            this.absNoLabel.Name = "absNoLabel";
            this.absNoLabel.Size = new System.Drawing.Size(132, 13);
            this.absNoLabel.TabIndex = 25;
            this.absNoLabel.Text = "Numer kolejny";
            this.absNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // invNoLabel
            // 
            this.invNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.invNoLabel.Location = new System.Drawing.Point(238, 9);
            this.invNoLabel.Name = "invNoLabel";
            this.invNoLabel.Size = new System.Drawing.Size(135, 13);
            this.invNoLabel.TabIndex = 24;
            this.invNoLabel.Text = "Numer inwentarzowy";
            this.invNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UbytkowanieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.NextNumberLabel);
            this.Controls.Add(this.NumInwLabel);
            this.Controls.Add(this.absNoLabel);
            this.Controls.Add(this.invNoLabel);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.NumbersLabel);
            this.Controls.Add(this.VoluminLabel);
            this.Controls.Add(this.YearLabel);
            this.Controls.Add(this.SygLabel);
            this.Controls.Add(this.numberTextLabel);
            this.Controls.Add(this.voluminTextLabel);
            this.Controls.Add(this.yearTextLabel);
            this.Controls.Add(this.signatureLabel);
            this.Controls.Add(this.UbytkiDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 400);
            this.Name = "UbytkowanieForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.UbytkiDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView UbytkiDGV;
        private System.Windows.Forms.Label NumbersLabel;
        private System.Windows.Forms.Label VoluminLabel;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Label SygLabel;
        private System.Windows.Forms.Label numberTextLabel;
        private System.Windows.Forms.Label voluminTextLabel;
        private System.Windows.Forms.Label yearTextLabel;
        private System.Windows.Forms.Label signatureLabel;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_volumesDGVC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBoxDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn WoluminDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumbersDGVC;
        private System.Windows.Forms.Label NextNumberLabel;
        private System.Windows.Forms.Label NumInwLabel;
        private System.Windows.Forms.Label absNoLabel;
        private System.Windows.Forms.Label invNoLabel;
    }
}