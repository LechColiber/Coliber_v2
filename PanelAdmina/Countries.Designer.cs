namespace WindowsFormsApplication1
{
    partial class Countries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Countries));
            this.panel1 = new System.Windows.Forms.Panel();
            this.DigitalCodeTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Code2TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PolishNameTextBox = new System.Windows.Forms.TextBox();
            this.EnglishNameTextBox = new System.Windows.Forms.TextBox();
            this.ShortNameTextBox = new System.Windows.Forms.TextBox();
            this.CountryTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.EditButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DigitalCodeTextBox);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.Code2TextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.PolishNameTextBox);
            this.panel1.Controls.Add(this.EnglishNameTextBox);
            this.panel1.Controls.Add(this.ShortNameTextBox);
            this.panel1.Controls.Add(this.CountryTextBox);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Location = new System.Drawing.Point(-5, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 138);
            this.panel1.TabIndex = 0;
            // 
            // DigitalCodeTextBox
            // 
            this.DigitalCodeTextBox.Location = new System.Drawing.Point(405, 19);
            this.DigitalCodeTextBox.MaxLength = 3;
            this.DigitalCodeTextBox.Name = "DigitalCodeTextBox";
            this.DigitalCodeTextBox.Size = new System.Drawing.Size(34, 20);
            this.DigitalCodeTextBox.TabIndex = 3;
            this.DigitalCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox6_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(287, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Cyfrowy kod państwa";
            // 
            // Code2TextBox
            // 
            this.Code2TextBox.Location = new System.Drawing.Point(214, 19);
            this.Code2TextBox.MaxLength = 2;
            this.Code2TextBox.Name = "Code2TextBox";
            this.Code2TextBox.Size = new System.Drawing.Size(27, 20);
            this.Code2TextBox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(181, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Kod2";
            // 
            // PolishNameTextBox
            // 
            this.PolishNameTextBox.Location = new System.Drawing.Point(101, 103);
            this.PolishNameTextBox.MaxLength = 70;
            this.PolishNameTextBox.Name = "PolishNameTextBox";
            this.PolishNameTextBox.Size = new System.Drawing.Size(337, 20);
            this.PolishNameTextBox.TabIndex = 6;
            // 
            // EnglishNameTextBox
            // 
            this.EnglishNameTextBox.Location = new System.Drawing.Point(101, 75);
            this.EnglishNameTextBox.MaxLength = 60;
            this.EnglishNameTextBox.Name = "EnglishNameTextBox";
            this.EnglishNameTextBox.Size = new System.Drawing.Size(337, 20);
            this.EnglishNameTextBox.TabIndex = 5;
            // 
            // ShortNameTextBox
            // 
            this.ShortNameTextBox.Location = new System.Drawing.Point(101, 47);
            this.ShortNameTextBox.MaxLength = 25;
            this.ShortNameTextBox.Name = "ShortNameTextBox";
            this.ShortNameTextBox.Size = new System.Drawing.Size(337, 20);
            this.ShortNameTextBox.TabIndex = 4;
            // 
            // CountryTextBox
            // 
            this.CountryTextBox.Location = new System.Drawing.Point(101, 19);
            this.CountryTextBox.MaxLength = 3;
            this.CountryTextBox.Name = "CountryTextBox";
            this.CountryTextBox.Size = new System.Drawing.Size(32, 20);
            this.CountryTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nazwa polska";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nazwa angielska";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nazwa skrócona";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(12, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Państwo";
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = global::WindowsFormsApplication1.Properties.Resources.contact_busy_overlay;
            this.DeleteButton.Location = new System.Drawing.Point(342, 390);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(106, 30);
            this.DeleteButton.TabIndex = 8;
            this.DeleteButton.Text = "Usuń";
            this.DeleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(834, 242);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // EditButton
            // 
            this.EditButton.Image = global::WindowsFormsApplication1.Properties.Resources.edycjam;
            this.EditButton.Location = new System.Drawing.Point(611, 390);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(106, 30);
            this.EditButton.TabIndex = 10;
            this.EditButton.Text = "Edytuj";
            this.EditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Image = global::WindowsFormsApplication1.Properties.Resources.door_out;
            this.CloseButton.Location = new System.Drawing.Point(723, 390);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(106, 30);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Wyjście";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Image = global::WindowsFormsApplication1.Properties.Resources.edit_add;
            this.AddButton.Location = new System.Drawing.Point(499, 390);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(106, 30);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Dodaj";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(464, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Wyszukiwanie:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(558, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "label8";
            // 
            // Countries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 430);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Countries";
            this.ShowInTaskbar = false;
            this.Text = "Państwa";
            this.Load += new System.EventHandler(this.Countries_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Countries_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox DigitalCodeTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Code2TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PolishNameTextBox;
        private System.Windows.Forms.TextBox EnglishNameTextBox;
        private System.Windows.Forms.TextBox ShortNameTextBox;
        private System.Windows.Forms.TextBox CountryTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
    }
}