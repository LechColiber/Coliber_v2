namespace WindowsFormsApplication1
{
    partial class MagazinesPublishers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagazinesPublishers));
            this.ShowBooksButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.CountTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.MergeButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.DelButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.IDRodzajComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PrintButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ShowBooksButton
            // 
            this.ShowBooksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowBooksButton.Image = global::WindowsFormsApplication1.Properties.Resources.preview;
            this.ShowBooksButton.Location = new System.Drawing.Point(351, 536);
            this.ShowBooksButton.Name = "ShowBooksButton";
            this.ShowBooksButton.Size = new System.Drawing.Size(121, 30);
            this.ShowBooksButton.TabIndex = 21;
            this.ShowBooksButton.Text = "Pokaż czasopisma";
            this.ShowBooksButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ShowBooksButton.UseVisualStyleBackColor = true;
            this.ShowBooksButton.Click += new System.EventHandler(this.ShowBooksButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 544);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "czasopismach";
            // 
            // CountTextBox
            // 
            this.CountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CountTextBox.Location = new System.Drawing.Point(156, 540);
            this.CountTextBox.Name = "CountTextBox";
            this.CountTextBox.ReadOnly = true;
            this.CountTextBox.Size = new System.Drawing.Size(100, 20);
            this.CountTextBox.TabIndex = 19;
            this.CountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 543);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(116, 13);
            this.label12.TabIndex = 18;
            this.label12.Text = "Wydawca występuje w";
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Image = global::WindowsFormsApplication1.Properties.Resources.door_out;
            this.ExitButton.Location = new System.Drawing.Point(876, 589);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(106, 30);
            this.ExitButton.TabIndex = 17;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MergeButton
            // 
            this.MergeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MergeButton.Image = global::WindowsFormsApplication1.Properties.Resources.zastap;
            this.MergeButton.Location = new System.Drawing.Point(652, 589);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(106, 30);
            this.MergeButton.TabIndex = 14;
            this.MergeButton.Text = "Połącz";
            this.MergeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MergeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Image = global::WindowsFormsApplication1.Properties.Resources.edit_add;
            this.AddButton.Location = new System.Drawing.Point(428, 589);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(106, 30);
            this.AddButton.TabIndex = 13;
            this.AddButton.Text = "Dodaj";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // DelButton
            // 
            this.DelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DelButton.Image = global::WindowsFormsApplication1.Properties.Resources.contact_busy_overlay;
            this.DelButton.Location = new System.Drawing.Point(12, 589);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(106, 30);
            this.DelButton.TabIndex = 12;
            this.DelButton.Text = "Usuń";
            this.DelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 36);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(970, 475);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // IDRodzajComboBox
            // 
            this.IDRodzajComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDRodzajComboBox.FormattingEnabled = true;
            this.IDRodzajComboBox.Location = new System.Drawing.Point(125, 8);
            this.IDRodzajComboBox.Name = "IDRodzajComboBox";
            this.IDRodzajComboBox.Size = new System.Drawing.Size(155, 21);
            this.IDRodzajComboBox.TabIndex = 23;
            this.IDRodzajComboBox.SelectedValueChanged += new System.EventHandler(this.IDRodzajComboBox_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Księgozbiór:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.Image = global::WindowsFormsApplication1.Properties.Resources.edycjam;
            this.EditButton.Location = new System.Drawing.Point(540, 589);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(106, 30);
            this.EditButton.TabIndex = 25;
            this.EditButton.Text = "Edytuj";
            this.EditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(505, 514);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Wyszukiwanie:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(589, 514);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "ll";
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintButton.Image = global::WindowsFormsApplication1.Properties.Resources.print_printer;
            this.PrintButton.Location = new System.Drawing.Point(764, 589);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(106, 30);
            this.PrintButton.TabIndex = 33;
            this.PrintButton.Text = "Drukuj";
            this.PrintButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PrintButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // MagazinesPublishers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 636);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IDRodzajComboBox);
            this.Controls.Add(this.ShowBooksButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CountTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.MergeButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DelButton);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1010, 670);
            this.Name = "MagazinesPublishers";
            this.ShowInTaskbar = false;
            this.Text = "Wydawcy";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MagazinesPublishers_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ShowBooksButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CountTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button MergeButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox IDRodzajComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PrintButton;
    }
}