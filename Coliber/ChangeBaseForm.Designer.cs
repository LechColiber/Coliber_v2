namespace Coliber
{
    partial class ChangeBaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeBaseForm));
            this.AllDbCheckBox = new System.Windows.Forms.CheckBox();
            this.DbsDGV = new System.Windows.Forms.DataGridView();
            this.id_rodzaj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inwentarz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescriptionDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.DescriptionRTB = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DbsDGV)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // AllDbCheckBox
            // 
            this.AllDbCheckBox.AutoSize = true;
            this.AllDbCheckBox.Location = new System.Drawing.Point(12, 69);
            this.AllDbCheckBox.Name = "AllDbCheckBox";
            this.AllDbCheckBox.Size = new System.Drawing.Size(172, 17);
            this.AllDbCheckBox.TabIndex = 0;
            this.AllDbCheckBox.Text = "Wszystkie księgi inwentarzowe";
            this.AllDbCheckBox.UseVisualStyleBackColor = true;
            this.AllDbCheckBox.CheckedChanged += new System.EventHandler(this.AllDbCheckBox_CheckedChanged);
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
            this.Inwentarz,
            this.DescriptionDGVC});
            this.DbsDGV.Location = new System.Drawing.Point(12, 92);
            this.DbsDGV.MultiSelect = false;
            this.DbsDGV.Name = "DbsDGV";
            this.DbsDGV.ReadOnly = true;
            this.DbsDGV.RowHeadersVisible = false;
            this.DbsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DbsDGV.Size = new System.Drawing.Size(287, 250);
            this.DbsDGV.TabIndex = 1;
            this.DbsDGV.SelectionChanged += new System.EventHandler(this.DbsDGV_SelectionChanged);
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
            // DescriptionDGVC
            // 
            this.DescriptionDGVC.DataPropertyName = "opis";
            this.DescriptionDGVC.HeaderText = "Opis";
            this.DescriptionDGVC.Name = "DescriptionDGVC";
            this.DescriptionDGVC.ReadOnly = true;
            this.DescriptionDGVC.Visible = false;
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = ((System.Drawing.Image)(resources.GetObject("EscapeButton.Image")));
            this.EscapeButton.Location = new System.Drawing.Point(420, 319);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(75, 23);
            this.EscapeButton.TabIndex = 3;
            this.EscapeButton.Text = "Anuluj";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = ((System.Drawing.Image)(resources.GetObject("OkButton.Image")));
            this.OkButton.Location = new System.Drawing.Point(339, 319);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 2;
            this.OkButton.Text = "Wybierz";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // DescriptionRTB
            // 
            this.DescriptionRTB.Location = new System.Drawing.Point(321, 92);
            this.DescriptionRTB.Name = "DescriptionRTB";
            this.DescriptionRTB.ReadOnly = true;
            this.DescriptionRTB.Size = new System.Drawing.Size(174, 221);
            this.DescriptionRTB.TabIndex = 4;
            this.DescriptionRTB.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(505, 62);
            this.panel1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(441, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 54);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Proszę wybrać księgę inwentarzową i kliknąć Wybierz";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(17, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Zmiana księgi inwentarzowej";
            // 
            // ChangeBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 354);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.DescriptionRTB);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.DbsDGV);
            this.Controls.Add(this.AllDbCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ChangeBaseForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zmiana księgi inwentarzowej";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeBaseForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.DbsDGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox AllDbCheckBox;
        private System.Windows.Forms.DataGridView DbsDGV;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.RichTextBox DescriptionRTB;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_rodzaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inwentarz;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescriptionDGVC;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}