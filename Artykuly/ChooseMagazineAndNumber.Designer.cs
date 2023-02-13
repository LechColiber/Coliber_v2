namespace Artykuly
{
    partial class ChooseMagazineAndNumber
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseMagazineAndNumber));
            this.MagazinesDGV = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Magazine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sygnatura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_cza_sygDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumbersDGV = new System.Windows.Forms.DataGridView();
            this.IDNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Year = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numer1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numer2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rok1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rok2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.volumin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ChooseButton = new System.Windows.Forms.Button();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SortLabel = new System.Windows.Forms.Label();
            this.SygRadioButton = new System.Windows.Forms.RadioButton();
            this.TitleRadioButton = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.MagazinesDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumbersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // MagazinesDGV
            // 
            this.MagazinesDGV.AllowUserToAddRows = false;
            this.MagazinesDGV.AllowUserToDeleteRows = false;
            this.MagazinesDGV.AllowUserToResizeRows = false;
            this.MagazinesDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MagazinesDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MagazinesDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Magazine,
            this.Sygnatura,
            this.id_cza_sygDGVC});
            this.MagazinesDGV.Location = new System.Drawing.Point(12, 12);
            this.MagazinesDGV.MultiSelect = false;
            this.MagazinesDGV.Name = "MagazinesDGV";
            this.MagazinesDGV.ReadOnly = true;
            this.MagazinesDGV.RowHeadersVisible = false;
            this.MagazinesDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MagazinesDGV.Size = new System.Drawing.Size(387, 293);
            this.MagazinesDGV.TabIndex = 7;
            this.MagazinesDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MagazinesDGV_CellClick);
            this.MagazinesDGV.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.MagazinesDGV_CellEnter);
            this.MagazinesDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MagazinesDGV_KeyDown);
            this.MagazinesDGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.MagazinesDGV_KeyPress);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Magazine
            // 
            this.Magazine.DataPropertyName = "tytul";
            this.Magazine.HeaderText = "Tytuł czasopisma";
            this.Magazine.Name = "Magazine";
            this.Magazine.ReadOnly = true;
            this.Magazine.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Sygnatura
            // 
            this.Sygnatura.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sygnatura.DataPropertyName = "syg";
            this.Sygnatura.HeaderText = "Sygnatura";
            this.Sygnatura.Name = "Sygnatura";
            this.Sygnatura.ReadOnly = true;
            this.Sygnatura.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Sygnatura.Width = 61;
            // 
            // id_cza_sygDGVC
            // 
            this.id_cza_sygDGVC.DataPropertyName = "id_cza_syg";
            this.id_cza_sygDGVC.HeaderText = "id_volumes";
            this.id_cza_sygDGVC.Name = "id_cza_sygDGVC";
            this.id_cza_sygDGVC.ReadOnly = true;
            this.id_cza_sygDGVC.Visible = false;
            // 
            // NumbersDGV
            // 
            this.NumbersDGV.AllowUserToAddRows = false;
            this.NumbersDGV.AllowUserToDeleteRows = false;
            this.NumbersDGV.AllowUserToResizeRows = false;
            this.NumbersDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.NumbersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.NumbersDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDNumber,
            this.Year,
            this.Number,
            this.numer1,
            this.numer2,
            this.rok1,
            this.rok2,
            this.volumin});
            this.NumbersDGV.Location = new System.Drawing.Point(405, 12);
            this.NumbersDGV.MultiSelect = false;
            this.NumbersDGV.Name = "NumbersDGV";
            this.NumbersDGV.ReadOnly = true;
            this.NumbersDGV.RowHeadersVisible = false;
            this.NumbersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.NumbersDGV.Size = new System.Drawing.Size(267, 293);
            this.NumbersDGV.TabIndex = 8;
            // 
            // IDNumber
            // 
            this.IDNumber.DataPropertyName = "id";
            this.IDNumber.HeaderText = "id";
            this.IDNumber.Name = "IDNumber";
            this.IDNumber.ReadOnly = true;
            this.IDNumber.Visible = false;
            // 
            // Year
            // 
            this.Year.DataPropertyName = "Rok";
            this.Year.HeaderText = "Rok";
            this.Year.Name = "Year";
            this.Year.ReadOnly = true;
            this.Year.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "numer";
            this.Number.HeaderText = "Numer";
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            this.Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // numer1
            // 
            this.numer1.DataPropertyName = "numer1";
            this.numer1.HeaderText = "numer1";
            this.numer1.Name = "numer1";
            this.numer1.ReadOnly = true;
            this.numer1.Visible = false;
            // 
            // numer2
            // 
            this.numer2.DataPropertyName = "numer2";
            this.numer2.HeaderText = "numer2";
            this.numer2.Name = "numer2";
            this.numer2.ReadOnly = true;
            this.numer2.Visible = false;
            // 
            // rok1
            // 
            this.rok1.DataPropertyName = "rok1";
            this.rok1.HeaderText = "rok1";
            this.rok1.Name = "rok1";
            this.rok1.ReadOnly = true;
            this.rok1.Visible = false;
            // 
            // rok2
            // 
            this.rok2.DataPropertyName = "rok2";
            this.rok2.HeaderText = "rok2";
            this.rok2.Name = "rok2";
            this.rok2.ReadOnly = true;
            this.rok2.Visible = false;
            // 
            // volumin
            // 
            this.volumin.DataPropertyName = "volumin";
            this.volumin.HeaderText = "volumin";
            this.volumin.Name = "volumin";
            this.volumin.ReadOnly = true;
            this.volumin.Visible = false;
            // 
            // ChooseButton
            // 
            this.ChooseButton.Image = ((System.Drawing.Image)(resources.GetObject("ChooseButton.Image")));
            this.ChooseButton.Location = new System.Drawing.Point(12, 341);
            this.ChooseButton.Name = "ChooseButton";
            this.ChooseButton.Size = new System.Drawing.Size(75, 23);
            this.ChooseButton.TabIndex = 9;
            this.ChooseButton.Text = "Wybierz";
            this.ChooseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ChooseButton.UseVisualStyleBackColor = true;
            this.ChooseButton.Click += new System.EventHandler(this.ChooseButon_Click);
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = global::Artykuly.Properties.Resources.door_out;
            this.EscapeButton.Location = new System.Drawing.Point(597, 341);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(75, 23);
            this.EscapeButton.TabIndex = 10;
            this.EscapeButton.Text = "Wyjście";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(237, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "label1";
            // 
            // SortLabel
            // 
            this.SortLabel.Location = new System.Drawing.Point(184, 311);
            this.SortLabel.Name = "SortLabel";
            this.SortLabel.Size = new System.Drawing.Size(141, 13);
            this.SortLabel.TabIndex = 14;
            this.SortLabel.Text = "Sortowanie wg";
            this.SortLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SygRadioButton
            // 
            this.SygRadioButton.Location = new System.Drawing.Point(327, 327);
            this.SygRadioButton.Name = "SygRadioButton";
            this.SygRadioButton.Size = new System.Drawing.Size(106, 17);
            this.SygRadioButton.TabIndex = 13;
            this.SygRadioButton.Text = "Sygnatury";
            this.SygRadioButton.UseVisualStyleBackColor = true;
            // 
            // TitleRadioButton
            // 
            this.TitleRadioButton.Checked = true;
            this.TitleRadioButton.Location = new System.Drawing.Point(327, 310);
            this.TitleRadioButton.Name = "TitleRadioButton";
            this.TitleRadioButton.Size = new System.Drawing.Size(106, 17);
            this.TitleRadioButton.TabIndex = 12;
            this.TitleRadioButton.TabStop = true;
            this.TitleRadioButton.Text = "Tytułu";
            this.TitleRadioButton.UseVisualStyleBackColor = true;
            this.TitleRadioButton.CheckedChanged += new System.EventHandler(this.TitleRadioButton_CheckedChanged);
            // 
            // ChooseMagazineAndNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 376);
            this.Controls.Add(this.SortLabel);
            this.Controls.Add(this.SygRadioButton);
            this.Controls.Add(this.TitleRadioButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.ChooseButton);
            this.Controls.Add(this.NumbersDGV);
            this.Controls.Add(this.MagazinesDGV);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ChooseMagazineAndNumber";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wybór czasopisma i numeru";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseMagazineAndNumber_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.MagazinesDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumbersDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView MagazinesDGV;
        private System.Windows.Forms.DataGridView NumbersDGV;
        private System.Windows.Forms.Button ChooseButton;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SortLabel;
        private System.Windows.Forms.RadioButton SygRadioButton;
        private System.Windows.Forms.RadioButton TitleRadioButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn Year;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn numer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numer2;
        private System.Windows.Forms.DataGridViewTextBoxColumn rok1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rok2;
        private System.Windows.Forms.DataGridViewTextBoxColumn volumin;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Magazine;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sygnatura;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cza_sygDGVC;
    }
}