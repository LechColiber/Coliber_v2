namespace WindowsFormsApplication1
{
    partial class Languages
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Languages));
            this.LanguagesLabel = new System.Windows.Forms.Label();
            this.DigitalCodeLabel = new System.Windows.Forms.Label();
            this.EnglishNameLabel = new System.Windows.Forms.Label();
            this.PolishNameLabel = new System.Windows.Forms.Label();
            this.LanguageTextBox = new System.Windows.Forms.TextBox();
            this.DigitalCodeTextBox = new System.Windows.Forms.TextBox();
            this.EnglishNameTextBox = new System.Windows.Forms.TextBox();
            this.PolishNameTextBox = new System.Windows.Forms.TextBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // LanguagesLabel
            // 
            this.LanguagesLabel.AutoSize = true;
            this.LanguagesLabel.Location = new System.Drawing.Point(38, 53);
            this.LanguagesLabel.Name = "LanguagesLabel";
            this.LanguagesLabel.Size = new System.Drawing.Size(34, 13);
            this.LanguagesLabel.TabIndex = 0;
            this.LanguagesLabel.Text = "Język";
            // 
            // DigitalCodeLabel
            // 
            this.DigitalCodeLabel.AutoSize = true;
            this.DigitalCodeLabel.Location = new System.Drawing.Point(38, 85);
            this.DigitalCodeLabel.Name = "DigitalCodeLabel";
            this.DigitalCodeLabel.Size = new System.Drawing.Size(65, 13);
            this.DigitalCodeLabel.TabIndex = 1;
            this.DigitalCodeLabel.Text = "Kod cyfrowy";
            // 
            // EnglishNameLabel
            // 
            this.EnglishNameLabel.AutoSize = true;
            this.EnglishNameLabel.Location = new System.Drawing.Point(38, 117);
            this.EnglishNameLabel.Name = "EnglishNameLabel";
            this.EnglishNameLabel.Size = new System.Drawing.Size(88, 13);
            this.EnglishNameLabel.TabIndex = 2;
            this.EnglishNameLabel.Text = "Nazwa angielska";
            // 
            // PolishNameLabel
            // 
            this.PolishNameLabel.AutoSize = true;
            this.PolishNameLabel.Location = new System.Drawing.Point(38, 149);
            this.PolishNameLabel.Name = "PolishNameLabel";
            this.PolishNameLabel.Size = new System.Drawing.Size(74, 13);
            this.PolishNameLabel.TabIndex = 3;
            this.PolishNameLabel.Text = "Nazwa polska";
            // 
            // LanguageTextBox
            // 
            this.LanguageTextBox.Location = new System.Drawing.Point(135, 50);
            this.LanguageTextBox.MaxLength = 3;
            this.LanguageTextBox.Name = "LanguageTextBox";
            this.LanguageTextBox.Size = new System.Drawing.Size(111, 20);
            this.LanguageTextBox.TabIndex = 4;
            // 
            // DigitalCodeTextBox
            // 
            this.DigitalCodeTextBox.Location = new System.Drawing.Point(135, 82);
            this.DigitalCodeTextBox.MaxLength = 3;
            this.DigitalCodeTextBox.Name = "DigitalCodeTextBox";
            this.DigitalCodeTextBox.Size = new System.Drawing.Size(111, 20);
            this.DigitalCodeTextBox.TabIndex = 5;
            this.DigitalCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DigitalCodeTextBox_KeyPress);
            // 
            // EnglishNameTextBox
            // 
            this.EnglishNameTextBox.Location = new System.Drawing.Point(135, 114);
            this.EnglishNameTextBox.MaxLength = 25;
            this.EnglishNameTextBox.Name = "EnglishNameTextBox";
            this.EnglishNameTextBox.Size = new System.Drawing.Size(111, 20);
            this.EnglishNameTextBox.TabIndex = 6;
            // 
            // PolishNameTextBox
            // 
            this.PolishNameTextBox.Location = new System.Drawing.Point(135, 146);
            this.PolishNameTextBox.MaxLength = 30;
            this.PolishNameTextBox.Name = "PolishNameTextBox";
            this.PolishNameTextBox.Size = new System.Drawing.Size(111, 20);
            this.PolishNameTextBox.TabIndex = 7;
            // 
            // AddButton
            // 
            this.AddButton.Image = global::WindowsFormsApplication1.Properties.Resources.edit_add;
            this.AddButton.Location = new System.Drawing.Point(354, 31);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(106, 30);
            this.AddButton.TabIndex = 10;
            this.AddButton.Text = "Dodaj";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Image = global::WindowsFormsApplication1.Properties.Resources.edycjam;
            this.EditButton.Location = new System.Drawing.Point(354, 72);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(106, 30);
            this.EditButton.TabIndex = 11;
            this.EditButton.Text = "Edytuj";
            this.EditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = global::WindowsFormsApplication1.Properties.Resources.contact_busy_overlay;
            this.DeleteButton.Location = new System.Drawing.Point(354, 113);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(106, 30);
            this.DeleteButton.TabIndex = 12;
            this.DeleteButton.Text = "Usuń";
            this.DeleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Image = global::WindowsFormsApplication1.Properties.Resources.door_out;
            this.CloseButton.Location = new System.Drawing.Point(354, 154);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(106, 30);
            this.CloseButton.TabIndex = 13;
            this.CloseButton.Text = "Wyjście";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CloseButton);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.EditButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Controls.Add(this.PolishNameTextBox);
            this.panel1.Controls.Add(this.EnglishNameTextBox);
            this.panel1.Controls.Add(this.DigitalCodeTextBox);
            this.panel1.Controls.Add(this.LanguageTextBox);
            this.panel1.Controls.Add(this.PolishNameLabel);
            this.panel1.Controls.Add(this.EnglishNameLabel);
            this.panel1.Controls.Add(this.DigitalCodeLabel);
            this.panel1.Controls.Add(this.LanguagesLabel);
            this.panel1.Location = new System.Drawing.Point(12, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 185);
            this.panel1.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Wyszukiwanie:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "label1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-1, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(549, 269);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // Languages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 433);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Languages";
            this.ShowInTaskbar = false;
            this.Text = "Języki";
            this.Load += new System.EventHandler(this.Languages_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Languages_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LanguagesLabel;
        private System.Windows.Forms.Label DigitalCodeLabel;
        private System.Windows.Forms.Label EnglishNameLabel;
        private System.Windows.Forms.Label PolishNameLabel;
        private System.Windows.Forms.TextBox LanguageTextBox;
        private System.Windows.Forms.TextBox DigitalCodeTextBox;
        private System.Windows.Forms.TextBox EnglishNameTextBox;
        private System.Windows.Forms.TextBox PolishNameTextBox;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}