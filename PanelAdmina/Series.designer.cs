namespace WindowsFormsApplication1
{
    partial class Series
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Series));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DelButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.MergeButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.CountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ShowBooksButton = new System.Windows.Forms.Button();
            this.IDRodzajComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.EditButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 36);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(970, 475);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_RowEnter);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            // 
            // DelButton
            // 
            this.DelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DelButton.Image = global::WindowsFormsApplication1.Properties.Resources.contact_busy_overlay;
            this.DelButton.Location = new System.Drawing.Point(12, 589);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(106, 30);
            this.DelButton.TabIndex = 1;
            this.DelButton.Text = "Usuń";
            this.DelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddButton.Image = global::WindowsFormsApplication1.Properties.Resources.edit_add;
            this.AddButton.Location = new System.Drawing.Point(427, 589);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(106, 30);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Dodaj";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // MergeButton
            // 
            this.MergeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MergeButton.Image = global::WindowsFormsApplication1.Properties.Resources.zastap;
            this.MergeButton.Location = new System.Drawing.Point(651, 589);
            this.MergeButton.Name = "MergeButton";
            this.MergeButton.Size = new System.Drawing.Size(106, 30);
            this.MergeButton.TabIndex = 3;
            this.MergeButton.Text = "Połącz";
            this.MergeButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MergeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.MergeButton.UseVisualStyleBackColor = true;
            this.MergeButton.Click += new System.EventHandler(this.MergeButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrintButton.Image = global::WindowsFormsApplication1.Properties.Resources.print_printer;
            this.PrintButton.Location = new System.Drawing.Point(764, 589);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(106, 30);
            this.PrintButton.TabIndex = 4;
            this.PrintButton.Text = "Drukuj";
            this.PrintButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PrintButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Image = global::WindowsFormsApplication1.Properties.Resources.door_out;
            this.ExitButton.Location = new System.Drawing.Point(876, 589);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(106, 30);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(64, 543);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Seria występuje w";
            // 
            // CountTextBox
            // 
            this.CountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CountTextBox.Location = new System.Drawing.Point(156, 540);
            this.CountTextBox.Name = "CountTextBox";
            this.CountTextBox.ReadOnly = true;
            this.CountTextBox.Size = new System.Drawing.Size(100, 20);
            this.CountTextBox.TabIndex = 8;
            this.CountTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 544);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "książkach";
            // 
            // ShowBooksButton
            // 
            this.ShowBooksButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ShowBooksButton.Image = global::WindowsFormsApplication1.Properties.Resources.preview;
            this.ShowBooksButton.Location = new System.Drawing.Point(351, 536);
            this.ShowBooksButton.Name = "ShowBooksButton";
            this.ShowBooksButton.Size = new System.Drawing.Size(106, 30);
            this.ShowBooksButton.TabIndex = 10;
            this.ShowBooksButton.Text = "Pokaż książki";
            this.ShowBooksButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ShowBooksButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ShowBooksButton.UseVisualStyleBackColor = true;
            this.ShowBooksButton.Click += new System.EventHandler(this.ShowBooksButton_Click);
            // 
            // IDRodzajComboBox
            // 
            this.IDRodzajComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IDRodzajComboBox.FormattingEnabled = true;
            this.IDRodzajComboBox.Location = new System.Drawing.Point(79, 8);
            this.IDRodzajComboBox.Name = "IDRodzajComboBox";
            this.IDRodzajComboBox.Size = new System.Drawing.Size(121, 21);
            this.IDRodzajComboBox.TabIndex = 11;
            this.IDRodzajComboBox.SelectedValueChanged += new System.EventHandler(this.IDRodzajComboBox_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Księgozbiór:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(478, 514);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Wyszukiwanie:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(562, 514);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "ll";
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EditButton.Image = global::WindowsFormsApplication1.Properties.Resources.edycjam;
            this.EditButton.Location = new System.Drawing.Point(539, 589);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(106, 30);
            this.EditButton.TabIndex = 19;
            this.EditButton.Text = "Edytuj";
            this.EditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // Series
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 631);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.IDRodzajComboBox);
            this.Controls.Add(this.ShowBooksButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CountTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.MergeButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.DelButton);
            this.Controls.Add(this.dataGridView1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1010, 670);
            this.Name = "Series";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Serie dla bazy książek";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Series_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button MergeButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox CountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ShowBooksButton;
        private System.Windows.Forms.ComboBox IDRodzajComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EditButton;

    }
}

