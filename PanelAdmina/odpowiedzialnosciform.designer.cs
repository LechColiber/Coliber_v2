namespace WindowsFormsApplication1
{
    partial class OdpowiedzialnosciForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OdpowiedzialnosciForm));
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CountTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OdpowiedzialnoscDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.label4.TabIndex = 29;
            this.label4.Text = "Wyszukiwanie:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(589, 490);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "ll";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 520);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 25;
            this.label2.Text = "książkach";
            // 
            // CountTextBox
            // 
            this.CountTextBox.Location = new System.Drawing.Point(169, 516);
            this.CountTextBox.Name = "CountTextBox";
            this.CountTextBox.ReadOnly = true;
            this.CountTextBox.Size = new System.Drawing.Size(100, 20);
            this.CountTextBox.TabIndex = 24;
            this.CountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(12, 519);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(154, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "Odpowiedzialność występuje w";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDGV,
            this.OdpowiedzialnoscDGV});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(970, 475);
            this.dataGridView1.TabIndex = 17;
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
            // 
            // OdpowiedzialnoscDGV
            // 
            this.OdpowiedzialnoscDGV.DataPropertyName = "Odpowiedzialność";
            this.OdpowiedzialnoscDGV.HeaderText = "Odpowiedzialność";
            this.OdpowiedzialnoscDGV.Name = "OdpowiedzialnoscDGV";
            this.OdpowiedzialnoscDGV.ReadOnly = true;
            // 
            // EditButton
            // 
            this.EditButton.Image = global::WindowsFormsApplication1.Properties.Resources.edycjam;
            this.EditButton.Location = new System.Drawing.Point(528, 565);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(106, 30);
            this.EditButton.TabIndex = 27;
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
            this.ShowBooksButton.Size = new System.Drawing.Size(106, 30);
            this.ShowBooksButton.TabIndex = 26;
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
            this.ExitButton.TabIndex = 22;
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
            this.MergeButton.TabIndex = 20;
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
            this.AddButton.TabIndex = 19;
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
            this.DelButton.TabIndex = 18;
            this.DelButton.Text = "Usuń";
            this.DelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // OdpowiedzialnosciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 631);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.ShowBooksButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CountTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MergeButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DelButton);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "OdpowiedzialnosciForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Odpowiedzialności";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OdpowiedzialnosciForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button ShowBooksButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CountTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button MergeButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn OdpowiedzialnoscDGV;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}