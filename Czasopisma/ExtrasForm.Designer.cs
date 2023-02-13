namespace Czasopisma
{
    partial class ExtrasForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtrasForm));
            this.extrasLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.authorsLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.Author2TextBox = new System.Windows.Forms.TextBox();
            this.Author3TextBox = new System.Windows.Forms.TextBox();
            this.ExtrasDGV = new System.Windows.Forms.DataGridView();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.tKodK = new System.Windows.Forms.TextBox();
            this.lKodK = new System.Windows.Forms.Label();
            this.tempid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TitleDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autor1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autor2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.autor3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.k_kreskowy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ExtrasDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // extrasLabel
            // 
            this.extrasLabel.AutoSize = true;
            this.extrasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.extrasLabel.Location = new System.Drawing.Point(12, 9);
            this.extrasLabel.Name = "extrasLabel";
            this.extrasLabel.Size = new System.Drawing.Size(93, 13);
            this.extrasLabel.TabIndex = 0;
            this.extrasLabel.Text = "Lista dodatków";
            // 
            // titleLabel
            // 
            this.titleLabel.Location = new System.Drawing.Point(6, 208);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(47, 13);
            this.titleLabel.TabIndex = 5;
            this.titleLabel.Text = "Tytuł";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // authorsLabel
            // 
            this.authorsLabel.Location = new System.Drawing.Point(3, 262);
            this.authorsLabel.Name = "authorsLabel";
            this.authorsLabel.Size = new System.Drawing.Size(49, 13);
            this.authorsLabel.TabIndex = 6;
            this.authorsLabel.Text = "Autorzy";
            this.authorsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(59, 208);
            this.TitleTextBox.MaxLength = 201;
            this.TitleTextBox.Multiline = true;
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(310, 40);
            this.TitleTextBox.TabIndex = 7;
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Location = new System.Drawing.Point(58, 259);
            this.AuthorTextBox.MaxLength = 40;
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(311, 20);
            this.AuthorTextBox.TabIndex = 8;
            // 
            // Author2TextBox
            // 
            this.Author2TextBox.Location = new System.Drawing.Point(58, 285);
            this.Author2TextBox.MaxLength = 40;
            this.Author2TextBox.Name = "Author2TextBox";
            this.Author2TextBox.Size = new System.Drawing.Size(311, 20);
            this.Author2TextBox.TabIndex = 9;
            // 
            // Author3TextBox
            // 
            this.Author3TextBox.Location = new System.Drawing.Point(59, 311);
            this.Author3TextBox.MaxLength = 40;
            this.Author3TextBox.Name = "Author3TextBox";
            this.Author3TextBox.Size = new System.Drawing.Size(311, 20);
            this.Author3TextBox.TabIndex = 10;
            // 
            // ExtrasDGV
            // 
            this.ExtrasDGV.AllowUserToAddRows = false;
            this.ExtrasDGV.AllowUserToDeleteRows = false;
            this.ExtrasDGV.AllowUserToResizeRows = false;
            this.ExtrasDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExtrasDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ExtrasDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExtrasDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.tempid,
            this.id,
            this.TitleDGVC,
            this.autor1,
            this.autor2,
            this.autor3,
            this.k_kreskowy});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ExtrasDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.ExtrasDGV.Location = new System.Drawing.Point(12, 25);
            this.ExtrasDGV.MultiSelect = false;
            this.ExtrasDGV.Name = "ExtrasDGV";
            this.ExtrasDGV.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExtrasDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ExtrasDGV.RowHeadersVisible = false;
            this.ExtrasDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ExtrasDGV.Size = new System.Drawing.Size(357, 166);
            this.ExtrasDGV.TabIndex = 11;
            this.ExtrasDGV.SelectionChanged += new System.EventHandler(this.ExtrasDGV_SelectionChanged);
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = global::Czasopisma.Properties.Resources.door_out;
            this.EscapeButton.Location = new System.Drawing.Point(456, 345);
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
            this.NewButton.Text = "Nowy";
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
            // tKodK
            // 
            this.tKodK.Location = new System.Drawing.Point(58, 337);
            this.tKodK.MaxLength = 40;
            this.tKodK.Name = "tKodK";
            this.tKodK.Size = new System.Drawing.Size(97, 20);
            this.tKodK.TabIndex = 16;
            // 
            // lKodK
            // 
            this.lKodK.Location = new System.Drawing.Point(-4, 340);
            this.lKodK.Name = "lKodK";
            this.lKodK.Size = new System.Drawing.Size(55, 31);
            this.lKodK.TabIndex = 15;
            this.lKodK.Text = "Kod kreskowy";
            this.lKodK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // TitleDGVC
            // 
            this.TitleDGVC.DataPropertyName = "syg";
            this.TitleDGVC.HeaderText = "Tytuł";
            this.TitleDGVC.Name = "TitleDGVC";
            this.TitleDGVC.ReadOnly = true;
            this.TitleDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // autor1
            // 
            this.autor1.HeaderText = "autor1";
            this.autor1.Name = "autor1";
            this.autor1.ReadOnly = true;
            this.autor1.Visible = false;
            // 
            // autor2
            // 
            this.autor2.HeaderText = "autor2";
            this.autor2.Name = "autor2";
            this.autor2.ReadOnly = true;
            this.autor2.Visible = false;
            // 
            // autor3
            // 
            this.autor3.HeaderText = "autor3";
            this.autor3.Name = "autor3";
            this.autor3.ReadOnly = true;
            this.autor3.Visible = false;
            // 
            // k_kreskowy
            // 
            this.k_kreskowy.HeaderText = "k_kreskowy";
            this.k_kreskowy.Name = "k_kreskowy";
            this.k_kreskowy.ReadOnly = true;
            this.k_kreskowy.Visible = false;
            // 
            // ExtrasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 380);
            this.Controls.Add(this.tKodK);
            this.Controls.Add(this.lKodK);
            this.Controls.Add(this.CancButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.ExtrasDGV);
            this.Controls.Add(this.Author3TextBox);
            this.Controls.Add(this.Author2TextBox);
            this.Controls.Add(this.AuthorTextBox);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.authorsLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.extrasLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ExtrasForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dodatki";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ExtrasForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ExtrasDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label extrasLabel;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Label authorsLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.TextBox Author2TextBox;
        private System.Windows.Forms.TextBox Author3TextBox;
        private System.Windows.Forms.DataGridView ExtrasDGV;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button CancButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TextBox tKodK;
        private System.Windows.Forms.Label lKodK;
        private System.Windows.Forms.DataGridViewTextBoxColumn tempid;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn TitleDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn autor1;
        private System.Windows.Forms.DataGridViewTextBoxColumn autor2;
        private System.Windows.Forms.DataGridViewTextBoxColumn autor3;
        private System.Windows.Forms.DataGridViewTextBoxColumn k_kreskowy;
    }
}