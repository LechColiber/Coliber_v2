namespace Akcesja
{
    partial class AkcesjaForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AkcesjaForm));
            this.titleLabel = new System.Windows.Forms.Label();
            this.instituteLabel = new System.Windows.Forms.Label();
            this.seatLabel = new System.Windows.Forms.Label();
            this.freqLabel = new System.Windows.Forms.Label();
            this.supplierLabel = new System.Windows.Forms.Label();
            this.mergedLabel = new System.Windows.Forms.Label();
            this.rewritingLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.InstTextBox = new System.Windows.Forms.TextBox();
            this.PlaceTextBox = new System.Windows.Forms.TextBox();
            this.SuppliersTextBox = new System.Windows.Forms.TextBox();
            this.FreqComboBox = new System.Windows.Forms.ComboBox();
            this.MergedMagazineTitleTextBox = new System.Windows.Forms.TextBox();
            this.RewritingNumbersComboBox = new System.Windows.Forms.ComboBox();
            this.CommentsCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SygsDGV = new System.Windows.Forms.DataGridView();
            this.id_akc_sygDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sygnaturaDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.AkcesjaButton = new System.Windows.Forms.Button();
            this.ShowListButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SygsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(12, 21);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(124, 13);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Tytuł";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // instituteLabel
            // 
            this.instituteLabel.Location = new System.Drawing.Point(12, 67);
            this.instituteLabel.Name = "instituteLabel";
            this.instituteLabel.Size = new System.Drawing.Size(124, 13);
            this.instituteLabel.TabIndex = 1;
            this.instituteLabel.Text = "Instytucja sprawcza";
            this.instituteLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // seatLabel
            // 
            this.seatLabel.Location = new System.Drawing.Point(12, 96);
            this.seatLabel.Name = "seatLabel";
            this.seatLabel.Size = new System.Drawing.Size(124, 13);
            this.seatLabel.TabIndex = 2;
            this.seatLabel.Text = "Siedziba";
            this.seatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // freqLabel
            // 
            this.freqLabel.Location = new System.Drawing.Point(12, 125);
            this.freqLabel.Name = "freqLabel";
            this.freqLabel.Size = new System.Drawing.Size(124, 13);
            this.freqLabel.TabIndex = 3;
            this.freqLabel.Text = "Częstotliwość";
            this.freqLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // supplierLabel
            // 
            this.supplierLabel.Location = new System.Drawing.Point(12, 155);
            this.supplierLabel.Name = "supplierLabel";
            this.supplierLabel.Size = new System.Drawing.Size(124, 13);
            this.supplierLabel.TabIndex = 4;
            this.supplierLabel.Text = "Dostawca";
            this.supplierLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // mergedLabel
            // 
            this.mergedLabel.Location = new System.Drawing.Point(12, 184);
            this.mergedLabel.Name = "mergedLabel";
            this.mergedLabel.Size = new System.Drawing.Size(124, 26);
            this.mergedLabel.TabIndex = 5;
            this.mergedLabel.Text = "Tytuł połączonego\r\nczasopisma";
            this.mergedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // rewritingLabel
            // 
            this.rewritingLabel.Location = new System.Drawing.Point(12, 225);
            this.rewritingLabel.Name = "rewritingLabel";
            this.rewritingLabel.Size = new System.Drawing.Size(124, 26);
            this.rewritingLabel.TabIndex = 6;
            this.rewritingLabel.Text = "Przepisywanie numerów\r\nakcesyjnych";
            this.rewritingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(142, 18);
            this.TitleTextBox.Multiline = true;
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(398, 37);
            this.TitleTextBox.TabIndex = 7;
            this.TitleTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TitleTextBox_KeyDown);
            // 
            // InstTextBox
            // 
            this.InstTextBox.Location = new System.Drawing.Point(142, 64);
            this.InstTextBox.Name = "InstTextBox";
            this.InstTextBox.ReadOnly = true;
            this.InstTextBox.Size = new System.Drawing.Size(398, 20);
            this.InstTextBox.TabIndex = 8;
            // 
            // PlaceTextBox
            // 
            this.PlaceTextBox.Location = new System.Drawing.Point(142, 93);
            this.PlaceTextBox.Name = "PlaceTextBox";
            this.PlaceTextBox.ReadOnly = true;
            this.PlaceTextBox.Size = new System.Drawing.Size(398, 20);
            this.PlaceTextBox.TabIndex = 9;
            // 
            // SuppliersTextBox
            // 
            this.SuppliersTextBox.Location = new System.Drawing.Point(142, 152);
            this.SuppliersTextBox.Name = "SuppliersTextBox";
            this.SuppliersTextBox.ReadOnly = true;
            this.SuppliersTextBox.Size = new System.Drawing.Size(398, 20);
            this.SuppliersTextBox.TabIndex = 10;
            // 
            // FreqComboBox
            // 
            this.FreqComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FreqComboBox.Enabled = false;
            this.FreqComboBox.FormattingEnabled = true;
            this.FreqComboBox.Location = new System.Drawing.Point(142, 122);
            this.FreqComboBox.Name = "FreqComboBox";
            this.FreqComboBox.Size = new System.Drawing.Size(199, 21);
            this.FreqComboBox.TabIndex = 11;
            // 
            // MergedMagazineTitleTextBox
            // 
            this.MergedMagazineTitleTextBox.Location = new System.Drawing.Point(142, 181);
            this.MergedMagazineTitleTextBox.Multiline = true;
            this.MergedMagazineTitleTextBox.Name = "MergedMagazineTitleTextBox";
            this.MergedMagazineTitleTextBox.ReadOnly = true;
            this.MergedMagazineTitleTextBox.Size = new System.Drawing.Size(398, 37);
            this.MergedMagazineTitleTextBox.TabIndex = 12;
            // 
            // RewritingNumbersComboBox
            // 
            this.RewritingNumbersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RewritingNumbersComboBox.FormattingEnabled = true;
            this.RewritingNumbersComboBox.Location = new System.Drawing.Point(142, 227);
            this.RewritingNumbersComboBox.Name = "RewritingNumbersComboBox";
            this.RewritingNumbersComboBox.Size = new System.Drawing.Size(199, 21);
            this.RewritingNumbersComboBox.TabIndex = 13;
            // 
            // CommentsCheckBox
            // 
            this.CommentsCheckBox.AutoSize = true;
            this.CommentsCheckBox.Location = new System.Drawing.Point(471, 230);
            this.CommentsCheckBox.Name = "CommentsCheckBox";
            this.CommentsCheckBox.Size = new System.Drawing.Size(65, 17);
            this.CommentsCheckBox.TabIndex = 19;
            this.CommentsCheckBox.Text = "Uwagi...";
            this.CommentsCheckBox.UseVisualStyleBackColor = true;
            this.CommentsCheckBox.Click += new System.EventHandler(this.CommentsCheckBox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SygsDGV);
            this.groupBox1.Location = new System.Drawing.Point(15, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(563, 155);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sygnatury";
            // 
            // SygsDGV
            // 
            this.SygsDGV.AllowUserToAddRows = false;
            this.SygsDGV.AllowUserToDeleteRows = false;
            this.SygsDGV.AllowUserToResizeRows = false;
            this.SygsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SygsDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.SygsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SygsDGV.ColumnHeadersVisible = false;
            this.SygsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_akc_sygDGVC,
            this.sygnaturaDGVC});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.SygsDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.SygsDGV.Location = new System.Drawing.Point(127, 19);
            this.SygsDGV.MultiSelect = false;
            this.SygsDGV.Name = "SygsDGV";
            this.SygsDGV.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SygsDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.SygsDGV.RowHeadersVisible = false;
            this.SygsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SygsDGV.Size = new System.Drawing.Size(398, 130);
            this.SygsDGV.TabIndex = 11;
            // 
            // id_akc_sygDGVC
            // 
            this.id_akc_sygDGVC.DataPropertyName = "id";
            this.id_akc_sygDGVC.HeaderText = "id";
            this.id_akc_sygDGVC.Name = "id_akc_sygDGVC";
            this.id_akc_sygDGVC.ReadOnly = true;
            this.id_akc_sygDGVC.Visible = false;
            // 
            // sygnaturaDGVC
            // 
            this.sygnaturaDGVC.DataPropertyName = "syg";
            this.sygnaturaDGVC.HeaderText = "Sygnatura";
            this.sygnaturaDGVC.Name = "sygnaturaDGVC";
            this.sygnaturaDGVC.ReadOnly = true;
            this.sygnaturaDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::Akcesja.Properties.Resources.door_out;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(506, 415);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 25;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Image = global::Akcesja.Properties.Resources.lupka;
            this.SearchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchButton.Location = new System.Drawing.Point(413, 415);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 24;
            this.SearchButton.Text = "Wyszukaj";
            this.SearchButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.ShowListButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Image = ((System.Drawing.Image)(resources.GetObject("OKButton.Image")));
            this.OKButton.Location = new System.Drawing.Point(247, 415);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(116, 23);
            this.OKButton.TabIndex = 22;
            this.OKButton.Text = "Zatwierdź";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AkcesjaButton
            // 
            this.AkcesjaButton.Image = global::Akcesja.Properties.Resources.refresh;
            this.AkcesjaButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AkcesjaButton.Location = new System.Drawing.Point(15, 415);
            this.AkcesjaButton.Name = "AkcesjaButton";
            this.AkcesjaButton.Size = new System.Drawing.Size(86, 23);
            this.AkcesjaButton.TabIndex = 21;
            this.AkcesjaButton.Text = "Akcesja";
            this.AkcesjaButton.UseVisualStyleBackColor = true;
            this.AkcesjaButton.Click += new System.EventHandler(this.AkcesjaButton_Click);
            // 
            // ShowListButton
            // 
            this.ShowListButton.BackColor = System.Drawing.SystemColors.Control;
            this.ShowListButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ShowListButton.Image = global::Akcesja.Properties.Resources.lista2;
            this.ShowListButton.Location = new System.Drawing.Point(546, 16);
            this.ShowListButton.Name = "ShowListButton";
            this.ShowListButton.Size = new System.Drawing.Size(32, 23);
            this.ShowListButton.TabIndex = 14;
            this.ShowListButton.UseVisualStyleBackColor = false;
            this.ShowListButton.Click += new System.EventHandler(this.ShowListButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Location = new System.Drawing.Point(155, 415);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(86, 23);
            this.DeleteButton.TabIndex = 26;
            this.DeleteButton.Text = "Usuń";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AkcesjaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 450);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.AkcesjaButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.CommentsCheckBox);
            this.Controls.Add(this.ShowListButton);
            this.Controls.Add(this.RewritingNumbersComboBox);
            this.Controls.Add(this.MergedMagazineTitleTextBox);
            this.Controls.Add(this.FreqComboBox);
            this.Controls.Add(this.SuppliersTextBox);
            this.Controls.Add(this.PlaceTextBox);
            this.Controls.Add(this.InstTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.rewritingLabel);
            this.Controls.Add(this.mergedLabel);
            this.Controls.Add(this.supplierLabel);
            this.Controls.Add(this.freqLabel);
            this.Controls.Add(this.seatLabel);
            this.Controls.Add(this.instituteLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "AkcesjaForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Akcesja";
            this.Activated += new System.EventHandler(this.AkcesjaForm_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AkcesjaForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SygsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label instituteLabel;
        private System.Windows.Forms.Label seatLabel;
        private System.Windows.Forms.Label freqLabel;
        private System.Windows.Forms.Label supplierLabel;
        private System.Windows.Forms.Label mergedLabel;
        private System.Windows.Forms.Label rewritingLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox InstTextBox;
        private System.Windows.Forms.TextBox PlaceTextBox;
        private System.Windows.Forms.TextBox SuppliersTextBox;
        private System.Windows.Forms.ComboBox FreqComboBox;
        private System.Windows.Forms.TextBox MergedMagazineTitleTextBox;
        private System.Windows.Forms.ComboBox RewritingNumbersComboBox;
        private System.Windows.Forms.Button ShowListButton;
        private System.Windows.Forms.CheckBox CommentsCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AkcesjaButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DataGridView SygsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_akc_sygDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn sygnaturaDGVC;
    }
}

