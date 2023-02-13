namespace Czasopisma
{
    partial class InstitutionForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstitutionForm));
            this.listLabel = new System.Windows.Forms.Label();
            this.instNameLabel = new System.Windows.Forms.Label();
            this.seatLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.PlaceTextBox = new System.Windows.Forms.TextBox();
            this.ExtrasDGV = new System.Windows.Forms.DataGridView();
            this.tempid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SelectInstitutionButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ExtrasDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // listLabel
            // 
            this.listLabel.AutoSize = true;
            this.listLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.listLabel.Location = new System.Drawing.Point(12, 9);
            this.listLabel.Name = "listLabel";
            this.listLabel.Size = new System.Drawing.Size(158, 13);
            this.listLabel.TabIndex = 0;
            this.listLabel.Text = "Lista instytucji sprawczych";
            // 
            // instNameLabel
            // 
            this.instNameLabel.Location = new System.Drawing.Point(6, 211);
            this.instNameLabel.Name = "instNameLabel";
            this.instNameLabel.Size = new System.Drawing.Size(90, 13);
            this.instNameLabel.TabIndex = 5;
            this.instNameLabel.Text = "Nazwa instytucji";
            this.instNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // seatLabel
            // 
            this.seatLabel.Location = new System.Drawing.Point(3, 262);
            this.seatLabel.Name = "seatLabel";
            this.seatLabel.Size = new System.Drawing.Size(93, 13);
            this.seatLabel.TabIndex = 6;
            this.seatLabel.Text = "Siedziba instytucji";
            this.seatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(102, 208);
            this.NameTextBox.MaxLength = 80;
            this.NameTextBox.Multiline = true;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(267, 40);
            this.NameTextBox.TabIndex = 7;
            // 
            // PlaceTextBox
            // 
            this.PlaceTextBox.Location = new System.Drawing.Point(101, 259);
            this.PlaceTextBox.MaxLength = 20;
            this.PlaceTextBox.Name = "PlaceTextBox";
            this.PlaceTextBox.Size = new System.Drawing.Size(268, 20);
            this.PlaceTextBox.TabIndex = 8;
            // 
            // ExtrasDGV
            // 
            this.ExtrasDGV.AllowUserToAddRows = false;
            this.ExtrasDGV.AllowUserToDeleteRows = false;
            this.ExtrasDGV.AllowUserToResizeRows = false;
            this.ExtrasDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExtrasDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ExtrasDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExtrasDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tempid,
            this.id,
            this.NameDGVC,
            this.PlaceDGVC});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExtrasDGV.DefaultCellStyle = dataGridViewCellStyle5;
            this.ExtrasDGV.Location = new System.Drawing.Point(12, 25);
            this.ExtrasDGV.MultiSelect = false;
            this.ExtrasDGV.Name = "ExtrasDGV";
            this.ExtrasDGV.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExtrasDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.ExtrasDGV.RowHeadersVisible = false;
            this.ExtrasDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ExtrasDGV.Size = new System.Drawing.Size(357, 166);
            this.ExtrasDGV.TabIndex = 11;
            this.ExtrasDGV.SelectionChanged += new System.EventHandler(this.ExtrasDGV_SelectionChanged);
            // 
            // tempid
            // 
            this.tempid.HeaderText = "temp";
            this.tempid.Name = "tempid";
            this.tempid.ReadOnly = true;
            this.tempid.Visible = false;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // NameDGVC
            // 
            this.NameDGVC.HeaderText = "Nazwa instytucji";
            this.NameDGVC.Name = "NameDGVC";
            this.NameDGVC.ReadOnly = true;
            this.NameDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PlaceDGVC
            // 
            this.PlaceDGVC.HeaderText = "autor1";
            this.PlaceDGVC.Name = "PlaceDGVC";
            this.PlaceDGVC.ReadOnly = true;
            this.PlaceDGVC.Visible = false;
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = global::Czasopisma.Properties.Resources.door_out;
            this.EscapeButton.Location = new System.Drawing.Point(456, 288);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(75, 23);
            this.EscapeButton.TabIndex = 12;
            this.EscapeButton.Text = "Wyjście";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButton.Image")));
            this.DeleteButton.Location = new System.Drawing.Point(375, 83);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 4;
            this.DeleteButton.Text = "Usuń";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Image = ((System.Drawing.Image)(resources.GetObject("EditButton.Image")));
            this.EditButton.Location = new System.Drawing.Point(375, 54);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(75, 23);
            this.EditButton.TabIndex = 3;
            this.EditButton.Text = "Edytuj";
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Image = ((System.Drawing.Image)(resources.GetObject("NewButton.Image")));
            this.NewButton.Location = new System.Drawing.Point(375, 25);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(75, 23);
            this.NewButton.TabIndex = 2;
            this.NewButton.Text = "Nowa";
            this.NewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // CancButton
            // 
            this.CancButton.Image = ((System.Drawing.Image)(resources.GetObject("CancButton.Image")));
            this.CancButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CancButton.Location = new System.Drawing.Point(456, 54);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(75, 23);
            this.CancButton.TabIndex = 14;
            this.CancButton.Text = "Anuluj";
            this.CancButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancButton.UseVisualStyleBackColor = true;
            this.CancButton.Click += new System.EventHandler(this.CancButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SaveButton.Location = new System.Drawing.Point(456, 25);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // SelectInstitutionButton
            // 
            this.SelectInstitutionButton.BackColor = System.Drawing.Color.Transparent;
            this.SelectInstitutionButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("SelectInstitutionButton.BackgroundImage")));
            this.SelectInstitutionButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SelectInstitutionButton.Location = new System.Drawing.Point(375, 208);
            this.SelectInstitutionButton.Name = "SelectInstitutionButton";
            this.SelectInstitutionButton.Size = new System.Drawing.Size(32, 23);
            this.SelectInstitutionButton.TabIndex = 34;
            this.SelectInstitutionButton.UseVisualStyleBackColor = false;
            this.SelectInstitutionButton.Click += new System.EventHandler(this.SelectInstitutionButton_Click);
            // 
            // InstitutionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 326);
            this.Controls.Add(this.SelectInstitutionButton);
            this.Controls.Add(this.CancButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.ExtrasDGV);
            this.Controls.Add(this.PlaceTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.seatLabel);
            this.Controls.Add(this.instNameLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.listLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "InstitutionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Instytucje sprawcze";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExtrasForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ExtrasDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label listLabel;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label instNameLabel;
        private System.Windows.Forms.Label seatLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox PlaceTextBox;
        private System.Windows.Forms.DataGridView ExtrasDGV;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button CancButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn tempid;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceDGVC;
        private System.Windows.Forms.Button SelectInstitutionButton;
    }
}