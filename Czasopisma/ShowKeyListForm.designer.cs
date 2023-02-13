namespace Czasopisma
{
    partial class ShowKeyListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowKeyListForm));
            this.AvailableGroupBox = new System.Windows.Forms.GroupBox();
            this.AvailabeDataGridView = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Keya = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectedGroupBox = new System.Windows.Forms.GroupBox();
            this.SelectedDataGridView = new System.Windows.Forms.DataGridView();
            this.OKButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.infoLabel = new System.Windows.Forms.Label();
            this.AvailableGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvailabeDataGridView)).BeginInit();
            this.SelectedGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvailableGroupBox
            // 
            this.AvailableGroupBox.Controls.Add(this.AvailabeDataGridView);
            this.AvailableGroupBox.Location = new System.Drawing.Point(12, 12);
            this.AvailableGroupBox.Name = "AvailableGroupBox";
            this.AvailableGroupBox.Size = new System.Drawing.Size(544, 162);
            this.AvailableGroupBox.TabIndex = 0;
            this.AvailableGroupBox.TabStop = false;
            this.AvailableGroupBox.Text = "Lista dostępnych słów kluczowych";
            // 
            // AvailabeDataGridView
            // 
            this.AvailabeDataGridView.AllowUserToAddRows = false;
            this.AvailabeDataGridView.AllowUserToDeleteRows = false;
            this.AvailabeDataGridView.AllowUserToResizeRows = false;
            this.AvailabeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AvailabeDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AvailabeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AvailabeDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Keya});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AvailabeDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.AvailabeDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AvailabeDataGridView.Location = new System.Drawing.Point(3, 16);
            this.AvailabeDataGridView.MultiSelect = false;
            this.AvailabeDataGridView.Name = "AvailabeDataGridView";
            this.AvailabeDataGridView.ReadOnly = true;
            this.AvailabeDataGridView.RowHeadersVisible = false;
            this.AvailabeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AvailabeDataGridView.Size = new System.Drawing.Size(538, 143);
            this.AvailabeDataGridView.TabIndex = 6;
            this.AvailabeDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvailabeDataGridView_CellClick);
            this.AvailabeDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvailabeDataGridView_CellDoubleClick);
            this.AvailabeDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AvailabeDataGridView_KeyDown);
            this.AvailabeDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AvailabeDataGridView_KeyPress);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Keya
            // 
            this.Keya.DataPropertyName = "klucze";
            this.Keya.HeaderText = "Klucz";
            this.Keya.Name = "Keya";
            this.Keya.ReadOnly = true;
            // 
            // SelectedGroupBox
            // 
            this.SelectedGroupBox.Controls.Add(this.SelectedDataGridView);
            this.SelectedGroupBox.Location = new System.Drawing.Point(15, 180);
            this.SelectedGroupBox.Name = "SelectedGroupBox";
            this.SelectedGroupBox.Size = new System.Drawing.Size(538, 168);
            this.SelectedGroupBox.TabIndex = 1;
            this.SelectedGroupBox.TabStop = false;
            this.SelectedGroupBox.Text = "Lista wybrach słów kluczowych";
            // 
            // SelectedDataGridView
            // 
            this.SelectedDataGridView.AllowUserToAddRows = false;
            this.SelectedDataGridView.AllowUserToDeleteRows = false;
            this.SelectedDataGridView.AllowUserToResizeRows = false;
            this.SelectedDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SelectedDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.SelectedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectedDataGridView.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.SelectedDataGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.SelectedDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SelectedDataGridView.Location = new System.Drawing.Point(3, 16);
            this.SelectedDataGridView.MultiSelect = false;
            this.SelectedDataGridView.Name = "SelectedDataGridView";
            this.SelectedDataGridView.ReadOnly = true;
            this.SelectedDataGridView.RowHeadersVisible = false;
            this.SelectedDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SelectedDataGridView.Size = new System.Drawing.Size(532, 149);
            this.SelectedDataGridView.TabIndex = 7;
            this.SelectedDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectedDataGridView_CellDoubleClick);
            this.SelectedDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedDataGridView_KeyDown);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Image = global::Czasopisma.Properties.Resources.Check2;
            this.OKButton.Location = new System.Drawing.Point(3, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(90, 29);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "Zatwierdź";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ExitButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Location = new System.Drawing.Point(18, 351);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 36);
            this.panel1.TabIndex = 3;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(450, 4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(79, 29);
            this.ExitButton.TabIndex = 12;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // infoLabel
            // 
            this.infoLabel.AutoSize = true;
            this.infoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel.Location = new System.Drawing.Point(135, 394);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(298, 17);
            this.infoLabel.TabIndex = 4;
            this.infoLabel.Text = "Wybór - [Enter] lub podwójne kliknięcie myszki";
            // 
            // ShowKeyListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 418);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SelectedGroupBox);
            this.Controls.Add(this.AvailableGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShowKeyListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Słowa kluczowe";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShowKeyListForm_KeyDown);
            this.AvailableGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AvailabeDataGridView)).EndInit();
            this.SelectedGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SelectedDataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox AvailableGroupBox;
        private System.Windows.Forms.GroupBox SelectedGroupBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label infoLabel;
        public System.Windows.Forms.DataGridView SelectedDataGridView;
        private System.Windows.Forms.DataGridView AvailabeDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Klucz;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Keya;
        private System.Windows.Forms.Button ExitButton;
    }
}