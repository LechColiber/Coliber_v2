namespace Akcesja
{
    partial class AkcesjaDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AkcesjaDetailsForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.Numbers = new System.Windows.Forms.TabPage();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.SygnaturaTextBox = new System.Windows.Forms.TextBox();
            this.magazineSignatureLabel = new System.Windows.Forms.Label();
            this.FreqCommonUserControl = new Akcesja.CommonUserControl();
            this.Indexes = new System.Windows.Forms.TabPage();
            this.IndexCommonUserControl = new Akcesja.CommonUserControl();
            this.ForWho = new System.Windows.Forms.TabPage();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.NumberNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.amountOfCopiesLabel = new System.Windows.Forms.Label();
            this.SelectButton = new System.Windows.Forms.Button();
            this.DepartmentTextBox = new System.Windows.Forms.TextBox();
            this.departmentNameLabel = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.DepartmentDGV = new System.Windows.Forms.DataGridView();
            this.kod_departDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_dlakogoDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departamentDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iloscDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.ForWhoCommonUserControl = new Akcesja.CommonUserControl();
            this.ExitButton = new System.Windows.Forms.Button();
            this.separateNumbersButton = new System.Windows.Forms.Button();
            this.MainTabControl.SuspendLayout();
            this.Numbers.SuspendLayout();
            this.Indexes.SuspendLayout();
            this.ForWho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.Numbers);
            this.MainTabControl.Controls.Add(this.Indexes);
            this.MainTabControl.Controls.Add(this.ForWho);
            this.MainTabControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(622, 447);
            this.MainTabControl.TabIndex = 0;
            // 
            // Numbers
            // 
            this.Numbers.Controls.Add(this.TitleTextBox);
            this.Numbers.Controls.Add(this.titleLabel);
            this.Numbers.Controls.Add(this.SygnaturaTextBox);
            this.Numbers.Controls.Add(this.magazineSignatureLabel);
            this.Numbers.Controls.Add(this.FreqCommonUserControl);
            this.Numbers.Location = new System.Drawing.Point(4, 22);
            this.Numbers.Name = "Numbers";
            this.Numbers.Padding = new System.Windows.Forms.Padding(3);
            this.Numbers.Size = new System.Drawing.Size(614, 421);
            this.Numbers.TabIndex = 0;
            this.Numbers.Text = "tabPage1";
            this.Numbers.UseVisualStyleBackColor = true;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(56, 85);
            this.TitleTextBox.Multiline = true;
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.ReadOnly = true;
            this.TitleTextBox.Size = new System.Drawing.Size(545, 58);
            this.TitleTextBox.TabIndex = 15;
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(6, 87);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(43, 13);
            this.titleLabel.TabIndex = 14;
            this.titleLabel.Text = "Tytuł";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SygnaturaTextBox
            // 
            this.SygnaturaTextBox.Location = new System.Drawing.Point(437, 57);
            this.SygnaturaTextBox.Name = "SygnaturaTextBox";
            this.SygnaturaTextBox.ReadOnly = true;
            this.SygnaturaTextBox.Size = new System.Drawing.Size(164, 20);
            this.SygnaturaTextBox.TabIndex = 13;
            // 
            // magazineSignatureLabel
            // 
            this.magazineSignatureLabel.Location = new System.Drawing.Point(149, 60);
            this.magazineSignatureLabel.Name = "magazineSignatureLabel";
            this.magazineSignatureLabel.Size = new System.Drawing.Size(286, 13);
            this.magazineSignatureLabel.TabIndex = 12;
            this.magazineSignatureLabel.Text = "SYGNATURA CZASOPISMA";
            this.magazineSignatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FreqCommonUserControl
            // 
            this.FreqCommonUserControl.Location = new System.Drawing.Point(11, 3);
            this.FreqCommonUserControl.Name = "FreqCommonUserControl";
            this.FreqCommonUserControl.Size = new System.Drawing.Size(593, 153);
            this.FreqCommonUserControl.TabIndex = 0;
            // 
            // Indexes
            // 
            this.Indexes.Controls.Add(this.IndexCommonUserControl);
            this.Indexes.Location = new System.Drawing.Point(4, 22);
            this.Indexes.Name = "Indexes";
            this.Indexes.Padding = new System.Windows.Forms.Padding(3);
            this.Indexes.Size = new System.Drawing.Size(614, 421);
            this.Indexes.TabIndex = 1;
            this.Indexes.Text = "Indeksy i numery specjalne";
            this.Indexes.UseVisualStyleBackColor = true;
            // 
            // IndexCommonUserControl
            // 
            this.IndexCommonUserControl.Location = new System.Drawing.Point(11, 3);
            this.IndexCommonUserControl.Name = "IndexCommonUserControl";
            this.IndexCommonUserControl.Size = new System.Drawing.Size(597, 51);
            this.IndexCommonUserControl.TabIndex = 1;
            // 
            // ForWho
            // 
            this.ForWho.Controls.Add(this.CancelButton);
            this.ForWho.Controls.Add(this.OKButton);
            this.ForWho.Controls.Add(this.NumberNumericUpDown);
            this.ForWho.Controls.Add(this.amountOfCopiesLabel);
            this.ForWho.Controls.Add(this.SelectButton);
            this.ForWho.Controls.Add(this.DepartmentTextBox);
            this.ForWho.Controls.Add(this.departmentNameLabel);
            this.ForWho.Controls.Add(this.DeleteButton);
            this.ForWho.Controls.Add(this.EditButton);
            this.ForWho.Controls.Add(this.NewButton);
            this.ForWho.Controls.Add(this.DepartmentDGV);
            this.ForWho.Controls.Add(this.label1);
            this.ForWho.Controls.Add(this.ForWhoCommonUserControl);
            this.ForWho.Location = new System.Drawing.Point(4, 22);
            this.ForWho.Name = "ForWho";
            this.ForWho.Padding = new System.Windows.Forms.Padding(3);
            this.ForWho.Size = new System.Drawing.Size(614, 421);
            this.ForWho.TabIndex = 2;
            this.ForWho.Text = "Dla kogo";
            this.ForWho.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.Enabled = false;
            this.CancelButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelButton.Image")));
            this.CancelButton.Location = new System.Drawing.Point(528, 361);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(80, 23);
            this.CancelButton.TabIndex = 12;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Enabled = false;
            this.OKButton.Image = ((System.Drawing.Image)(resources.GetObject("OKButton.Image")));
            this.OKButton.Location = new System.Drawing.Point(442, 361);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(80, 23);
            this.OKButton.TabIndex = 11;
            this.OKButton.Text = "Zatwierdź";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // NumberNumericUpDown
            // 
            this.NumberNumericUpDown.Enabled = false;
            this.NumberNumericUpDown.Location = new System.Drawing.Point(307, 166);
            this.NumberNumericUpDown.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NumberNumericUpDown.Name = "NumberNumericUpDown";
            this.NumberNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.NumberNumericUpDown.TabIndex = 10;
            this.NumberNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumberNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // amountOfCopiesLabel
            // 
            this.amountOfCopiesLabel.AutoSize = true;
            this.amountOfCopiesLabel.Location = new System.Drawing.Point(304, 150);
            this.amountOfCopiesLabel.Name = "amountOfCopiesLabel";
            this.amountOfCopiesLabel.Size = new System.Drawing.Size(90, 13);
            this.amountOfCopiesLabel.TabIndex = 9;
            this.amountOfCopiesLabel.Text = "Ilość egzemplarzy";
            // 
            // SelectButton
            // 
            this.SelectButton.Enabled = false;
            this.SelectButton.Image = global::Akcesja.Properties.Resources.lista2;
            this.SelectButton.Location = new System.Drawing.Point(582, 92);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(26, 23);
            this.SelectButton.TabIndex = 8;
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // DepartmentTextBox
            // 
            this.DepartmentTextBox.Location = new System.Drawing.Point(307, 92);
            this.DepartmentTextBox.MaxLength = 80;
            this.DepartmentTextBox.Multiline = true;
            this.DepartmentTextBox.Name = "DepartmentTextBox";
            this.DepartmentTextBox.ReadOnly = true;
            this.DepartmentTextBox.Size = new System.Drawing.Size(269, 46);
            this.DepartmentTextBox.TabIndex = 7;
            this.DepartmentTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DepartmentTextBox_KeyDown);
            // 
            // departmentNameLabel
            // 
            this.departmentNameLabel.AutoSize = true;
            this.departmentNameLabel.Location = new System.Drawing.Point(304, 75);
            this.departmentNameLabel.Name = "departmentNameLabel";
            this.departmentNameLabel.Size = new System.Drawing.Size(108, 13);
            this.departmentNameLabel.TabIndex = 6;
            this.departmentNameLabel.Text = "Nazwa departamentu";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Location = new System.Drawing.Point(223, 361);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 5;
            this.DeleteButton.Text = "Usuń";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Image")));
            this.EditButton.Location = new System.Drawing.Point(142, 361);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 4;
            this.EditButton.Text = "Edytuj";
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Image = ((System.Drawing.Image)(resources.GetObject("NewButton.Image")));
            this.NewButton.Location = new System.Drawing.Point(61, 361);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 3;
            this.NewButton.Text = "Nowy";
            this.NewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // DepartmentDGV
            // 
            this.DepartmentDGV.AllowUserToAddRows = false;
            this.DepartmentDGV.AllowUserToDeleteRows = false;
            this.DepartmentDGV.AllowUserToResizeRows = false;
            this.DepartmentDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DepartmentDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.DepartmentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DepartmentDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.kod_departDGVC,
            this.id_dlakogoDGVC,
            this.departamentDGVC,
            this.iloscDGVC});
            this.DepartmentDGV.Location = new System.Drawing.Point(11, 66);
            this.DepartmentDGV.MultiSelect = false;
            this.DepartmentDGV.Name = "DepartmentDGV";
            this.DepartmentDGV.ReadOnly = true;
            this.DepartmentDGV.RowHeadersVisible = false;
            this.DepartmentDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DepartmentDGV.Size = new System.Drawing.Size(287, 275);
            this.DepartmentDGV.TabIndex = 2;
            this.DepartmentDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DepartmentDGV_CellClick);
            this.DepartmentDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DepartmentDGV_KeyDown);
            // 
            // kod_departDGVC
            // 
            this.kod_departDGVC.DataPropertyName = "kod_depart";
            this.kod_departDGVC.HeaderText = "kod_depart";
            this.kod_departDGVC.Name = "kod_departDGVC";
            this.kod_departDGVC.ReadOnly = true;
            this.kod_departDGVC.Visible = false;
            // 
            // id_dlakogoDGVC
            // 
            this.id_dlakogoDGVC.DataPropertyName = "id_dlakogo";
            this.id_dlakogoDGVC.HeaderText = "id_dlakogo";
            this.id_dlakogoDGVC.Name = "id_dlakogoDGVC";
            this.id_dlakogoDGVC.ReadOnly = true;
            this.id_dlakogoDGVC.Visible = false;
            // 
            // departamentDGVC
            // 
            this.departamentDGVC.DataPropertyName = "departament";
            this.departamentDGVC.HeaderText = "Departament";
            this.departamentDGVC.Name = "departamentDGVC";
            this.departamentDGVC.ReadOnly = true;
            this.departamentDGVC.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // iloscDGVC
            // 
            this.iloscDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.iloscDGVC.DataPropertyName = "ilosc";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.iloscDGVC.DefaultCellStyle = dataGridViewCellStyle4;
            this.iloscDGVC.HeaderText = "Ilość";
            this.iloscDGVC.Name = "iloscDGVC";
            this.iloscDGVC.ReadOnly = true;
            this.iloscDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.iloscDGVC.Width = 35;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(159, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(325, 23);
            this.label1.TabIndex = 1;
            // 
            // ForWhoCommonUserControl
            // 
            this.ForWhoCommonUserControl.Location = new System.Drawing.Point(11, 3);
            this.ForWhoCommonUserControl.Name = "ForWhoCommonUserControl";
            this.ForWhoCommonUserControl.Size = new System.Drawing.Size(597, 57);
            this.ForWhoCommonUserControl.TabIndex = 0;
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::Akcesja.Properties.Resources.door_out;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(537, 455);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // separateNumbersButton
            // 
            this.separateNumbersButton.Location = new System.Drawing.Point(4, 455);
            this.separateNumbersButton.Name = "separateNumbersButton";
            this.separateNumbersButton.Size = new System.Drawing.Size(271, 23);
            this.separateNumbersButton.TabIndex = 3;
            this.separateNumbersButton.Text = "Zbiorcze rozdzielenie numerów na woluminy";
            this.separateNumbersButton.UseVisualStyleBackColor = true;
            this.separateNumbersButton.Click += new System.EventHandler(this.separateNumbersButton_Click);
            // 
            // AkcesjaDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 490);
            this.Controls.Add(this.separateNumbersButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MainTabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "AkcesjaDetailsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AkcesjaDetailsForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AkcesjaDetailsForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Ctrl_KeyDown);
            this.MainTabControl.ResumeLayout(false);
            this.Numbers.ResumeLayout(false);
            this.Numbers.PerformLayout();
            this.Indexes.ResumeLayout(false);
            this.ForWho.ResumeLayout(false);
            this.ForWho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumberNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage Numbers;
        private System.Windows.Forms.TabPage Indexes;
        private System.Windows.Forms.TabPage ForWho;
        private CommonUserControl FreqCommonUserControl;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox SygnaturaTextBox;
        private System.Windows.Forms.Label magazineSignatureLabel;
        private CommonUserControl ForWhoCommonUserControl;
        private CommonUserControl IndexCommonUserControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView DepartmentDGV;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.NumericUpDown NumberNumericUpDown;
        private System.Windows.Forms.Label amountOfCopiesLabel;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.TextBox DepartmentTextBox;
        private System.Windows.Forms.Label departmentNameLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn kod_departDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_dlakogoDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn departamentDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn iloscDGVC;
        private System.Windows.Forms.Button separateNumbersButton;
    }
}