namespace WindowsFormsApplication1
{
    partial class DistributorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DistributorForm));
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CountTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NazwaDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiastoDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShortDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountryDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodeDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddressDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PhoneDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone2DGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FaxDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EditButton = new System.Windows.Forms.Button();
            this.ShowBooksButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MergeButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.DelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(505, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Wyszukiwanie:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(589, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 40;
            this.label1.Text = "ll";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "książkach";
            // 
            // CountTextBox
            // 
            this.CountTextBox.Location = new System.Drawing.Point(169, 516);
            this.CountTextBox.Name = "CountTextBox";
            this.CountTextBox.ReadOnly = true;
            this.CountTextBox.Size = new System.Drawing.Size(100, 20);
            this.CountTextBox.TabIndex = 36;
            this.CountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(47, 520);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Dostawca występuje w";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDGV,
            this.NazwaDGVC,
            this.MiastoDGVC,
            this.ShortDGVC,
            this.CountryDGVC,
            this.CodeDGVC,
            this.AddressDGVC,
            this.PhoneDGVC,
            this.Phone2DGVC,
            this.FaxDGVC});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(970, 475);
            this.dataGridView1.TabIndex = 30;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // idDGV
            // 
            this.idDGV.DataPropertyName = "id";
            this.idDGV.HeaderText = "id";
            this.idDGV.Name = "idDGV";
            this.idDGV.ReadOnly = true;
            this.idDGV.Visible = false;
            this.idDGV.Width = 21;
            // 
            // NazwaDGVC
            // 
            this.NazwaDGVC.DataPropertyName = "nazwa_k";
            this.NazwaDGVC.HeaderText = "Nazwa";
            this.NazwaDGVC.Name = "NazwaDGVC";
            this.NazwaDGVC.ReadOnly = true;
            this.NazwaDGVC.Width = 65;
            // 
            // MiastoDGVC
            // 
            this.MiastoDGVC.DataPropertyName = "miasto_k";
            this.MiastoDGVC.HeaderText = "Miasto";
            this.MiastoDGVC.Name = "MiastoDGVC";
            this.MiastoDGVC.ReadOnly = true;
            this.MiastoDGVC.Width = 63;
            // 
            // ShortDGVC
            // 
            this.ShortDGVC.DataPropertyName = "sk_nazwa_k";
            this.ShortDGVC.HeaderText = "Skr. nazwa";
            this.ShortDGVC.Name = "ShortDGVC";
            this.ShortDGVC.ReadOnly = true;
            this.ShortDGVC.Width = 85;
            // 
            // CountryDGVC
            // 
            this.CountryDGVC.DataPropertyName = "id_panst_k";
            this.CountryDGVC.HeaderText = "Państwo";
            this.CountryDGVC.Name = "CountryDGVC";
            this.CountryDGVC.ReadOnly = true;
            this.CountryDGVC.Width = 73;
            // 
            // CodeDGVC
            // 
            this.CodeDGVC.DataPropertyName = "kod_k";
            this.CodeDGVC.HeaderText = "Kod";
            this.CodeDGVC.Name = "CodeDGVC";
            this.CodeDGVC.ReadOnly = true;
            this.CodeDGVC.Width = 51;
            // 
            // AddressDGVC
            // 
            this.AddressDGVC.DataPropertyName = "adres_k";
            this.AddressDGVC.HeaderText = "Adres";
            this.AddressDGVC.Name = "AddressDGVC";
            this.AddressDGVC.ReadOnly = true;
            this.AddressDGVC.Width = 59;
            // 
            // PhoneDGVC
            // 
            this.PhoneDGVC.DataPropertyName = "telefon_k";
            this.PhoneDGVC.HeaderText = "Telefon";
            this.PhoneDGVC.Name = "PhoneDGVC";
            this.PhoneDGVC.ReadOnly = true;
            this.PhoneDGVC.Width = 68;
            // 
            // Phone2DGVC
            // 
            this.Phone2DGVC.DataPropertyName = "telefon2_k";
            this.Phone2DGVC.HeaderText = "Telefon 2";
            this.Phone2DGVC.Name = "Phone2DGVC";
            this.Phone2DGVC.ReadOnly = true;
            this.Phone2DGVC.Width = 77;
            // 
            // FaxDGVC
            // 
            this.FaxDGVC.DataPropertyName = "fax_k";
            this.FaxDGVC.HeaderText = "Fax";
            this.FaxDGVC.Name = "FaxDGVC";
            this.FaxDGVC.ReadOnly = true;
            this.FaxDGVC.Width = 49;
            // 
            // EditButton
            // 
            this.EditButton.Image = global::WindowsFormsApplication1.Properties.Resources.edycjam;
            this.EditButton.Location = new System.Drawing.Point(528, 565);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(106, 30);
            this.EditButton.TabIndex = 39;
            this.EditButton.Text = "Edytuj";
            this.EditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // ShowBooksButton
            // 
            this.ShowBooksButton.Image = global::WindowsFormsApplication1.Properties.Resources.preview;
            this.ShowBooksButton.Location = new System.Drawing.Point(361, 511);
            this.ShowBooksButton.Name = "ShowBooksButton";
            this.ShowBooksButton.Size = new System.Drawing.Size(143, 30);
            this.ShowBooksButton.TabIndex = 38;
            this.ShowBooksButton.Text = "Pokaż książki";
            this.ShowBooksButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ShowBooksButton.UseVisualStyleBackColor = true;
            this.ShowBooksButton.Click += new System.EventHandler(this.ShowBooksButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::WindowsFormsApplication1.Properties.Resources.door_out;
            this.ExitButton.Location = new System.Drawing.Point(864, 565);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(106, 30);
            this.ExitButton.TabIndex = 34;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MergeButton
            // 
            this.MergeButton.Image = global::WindowsFormsApplication1.Properties.Resources.zastap;
            this.MergeButton.Location = new System.Drawing.Point(640, 565);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(106, 30);
            this.MergeButton.TabIndex = 33;
            this.MergeButton.Text = "Połącz";
            this.MergeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MergeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Image = global::WindowsFormsApplication1.Properties.Resources.edit_add;
            this.AddButton.Location = new System.Drawing.Point(416, 565);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(106, 30);
            this.AddButton.TabIndex = 32;
            this.AddButton.Text = "Dodaj";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.Image = global::WindowsFormsApplication1.Properties.Resources.contact_busy_overlay;
            this.DelButton.Location = new System.Drawing.Point(25, 565);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(106, 30);
            this.DelButton.TabIndex = 31;
            this.DelButton.Text = "Usuń";
            this.DelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // DistributorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 636);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CountTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.ShowBooksButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MergeButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DelButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1010, 670);
            this.Name = "DistributorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dostawcy czasopism";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DistributorForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CountTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button ShowBooksButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button MergeButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NazwaDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn MiastoDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShortDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountryDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodeDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddressDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn PhoneDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone2DGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn FaxDGVC;
    }
}