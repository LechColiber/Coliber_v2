namespace Ksiazki
{
    partial class ShowListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowListForm));
            this.AvailableGroupBox = new System.Windows.Forms.GroupBox();
            this.AvailableDataGridView = new System.Windows.Forms.DataGridView();
            this.SelectedGroupBox = new System.Windows.Forms.GroupBox();
            this.SelectedDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.OdpowTextBox = new System.Windows.Forms.TextBox();
            this.RoleLabel = new System.Windows.Forms.Label();
            this.CleanRoleButton = new System.Windows.Forms.Button();
            this.AddRoleButton = new System.Windows.Forms.Button();
            this.Odpow1Button = new System.Windows.Forms.Button();
            this.AvailableGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AvailableDataGridView)).BeginInit();
            this.SelectedGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SelectedDataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvailableGroupBox
            // 
            this.AvailableGroupBox.Controls.Add(this.AvailableDataGridView);
            this.AvailableGroupBox.Location = new System.Drawing.Point(12, 12);
            this.AvailableGroupBox.Name = "AvailableGroupBox";
            this.AvailableGroupBox.Size = new System.Drawing.Size(544, 162);
            this.AvailableGroupBox.TabIndex = 0;
            this.AvailableGroupBox.TabStop = false;
            this.AvailableGroupBox.Text = "Lista dostępnych pozycji";
            // 
            // AvailableDataGridView
            // 
            this.AvailableDataGridView.AllowUserToAddRows = false;
            this.AvailableDataGridView.AllowUserToDeleteRows = false;
            this.AvailableDataGridView.AllowUserToResizeRows = false;
            this.AvailableDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AvailableDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AvailableDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.AvailableDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AvailableDataGridView.Location = new System.Drawing.Point(3, 16);
            this.AvailableDataGridView.MultiSelect = false;
            this.AvailableDataGridView.Name = "AvailableDataGridView";
            this.AvailableDataGridView.ReadOnly = true;
            this.AvailableDataGridView.RowHeadersVisible = false;
            this.AvailableDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AvailableDataGridView.Size = new System.Drawing.Size(538, 143);
            this.AvailableDataGridView.TabIndex = 6;
            this.AvailableDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvailabeDataGridView_CellClick);
            this.AvailableDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AvailabeDataGridView_CellDoubleClick);
            this.AvailableDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AvailabeDataGridView_KeyDown);
            this.AvailableDataGridView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AvailabeDataGridView_KeyPress);
            // 
            // SelectedGroupBox
            // 
            this.SelectedGroupBox.Controls.Add(this.SelectedDataGridView);
            this.SelectedGroupBox.Location = new System.Drawing.Point(15, 180);
            this.SelectedGroupBox.Name = "SelectedGroupBox";
            this.SelectedGroupBox.Size = new System.Drawing.Size(538, 168);
            this.SelectedGroupBox.TabIndex = 1;
            this.SelectedGroupBox.TabStop = false;
            this.SelectedGroupBox.Text = "Lista wybrach pozycji";
            // 
            // SelectedDataGridView
            // 
            this.SelectedDataGridView.AllowUserToAddRows = false;
            this.SelectedDataGridView.AllowUserToDeleteRows = false;
            this.SelectedDataGridView.AllowUserToResizeRows = false;
            this.SelectedDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SelectedDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.SelectedDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
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
            this.SelectedDataGridView.SelectionChanged += new System.EventHandler(this.SelectedDataGridView_SelectionChanged);
            this.SelectedDataGridView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectedDataGridView_KeyDown);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ExitButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Location = new System.Drawing.Point(21, 386);
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
            this.ExitButton.Location = new System.Drawing.Point(450, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(79, 29);
            this.ExitButton.TabIndex = 10;
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
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Image = global::Ksiazki.Properties.Resources.Check2;
            this.OKButton.Location = new System.Drawing.Point(3, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(90, 29);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "Zatwierdź";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(138, 429);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Wybór - [Enter] lub podwójne kliknięcie myszki";
            // 
            // OdpowTextBox
            // 
            this.OdpowTextBox.Enabled = false;
            this.OdpowTextBox.Location = new System.Drawing.Point(278, 353);
            this.OdpowTextBox.Name = "OdpowTextBox";
            this.OdpowTextBox.Size = new System.Drawing.Size(158, 20);
            this.OdpowTextBox.TabIndex = 42;
            this.OdpowTextBox.Visible = false;
            this.OdpowTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OdpowTextBox_KeyDown);
            // 
            // RoleLabel
            // 
            this.RoleLabel.AutoSize = true;
            this.RoleLabel.Location = new System.Drawing.Point(176, 356);
            this.RoleLabel.Name = "RoleLabel";
            this.RoleLabel.Size = new System.Drawing.Size(96, 13);
            this.RoleLabel.TabIndex = 44;
            this.RoleLabel.Text = "Odpowiedzialność:";
            this.RoleLabel.Visible = false;
            // 
            // CleanRoleButton
            // 
            this.CleanRoleButton.Image = ((System.Drawing.Image)(resources.GetObject("CleanRoleButton.Image")));
            this.CleanRoleButton.Location = new System.Drawing.Point(518, 351);
            this.CleanRoleButton.Name = "CleanRoleButton";
            this.CleanRoleButton.Size = new System.Drawing.Size(32, 23);
            this.CleanRoleButton.TabIndex = 47;
            this.CleanRoleButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CleanRoleButton.UseVisualStyleBackColor = true;
            this.CleanRoleButton.Click += new System.EventHandler(this.CleanRoleButton_Click);
            // 
            // AddRoleButton
            // 
            this.AddRoleButton.Enabled = false;
            this.AddRoleButton.Image = global::Ksiazki.Properties.Resources.edit_add;
            this.AddRoleButton.Location = new System.Drawing.Point(442, 351);
            this.AddRoleButton.Name = "AddRoleButton";
            this.AddRoleButton.Size = new System.Drawing.Size(32, 23);
            this.AddRoleButton.TabIndex = 46;
            this.AddRoleButton.UseVisualStyleBackColor = true;
            this.AddRoleButton.Click += new System.EventHandler(this.AddRoleButton_Click);
            // 
            // Odpow1Button
            // 
            this.Odpow1Button.Enabled = false;
            this.Odpow1Button.Image = ((System.Drawing.Image)(resources.GetObject("Odpow1Button.Image")));
            this.Odpow1Button.Location = new System.Drawing.Point(480, 351);
            this.Odpow1Button.Name = "Odpow1Button";
            this.Odpow1Button.Size = new System.Drawing.Size(32, 23);
            this.Odpow1Button.TabIndex = 43;
            this.Odpow1Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Odpow1Button.UseVisualStyleBackColor = true;
            this.Odpow1Button.Visible = false;
            this.Odpow1Button.Click += new System.EventHandler(this.Odpow1Button_Click);
            // 
            // ShowListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 455);
            this.Controls.Add(this.CleanRoleButton);
            this.Controls.Add(this.AddRoleButton);
            this.Controls.Add(this.RoleLabel);
            this.Controls.Add(this.Odpow1Button);
            this.Controls.Add(this.OdpowTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.SelectedGroupBox);
            this.Controls.Add(this.AvailableGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ShowListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wybór";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShowKeyListForm_KeyDown);
            this.AvailableGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AvailableDataGridView)).EndInit();
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
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DataGridView SelectedDataGridView;
        private System.Windows.Forms.DataGridView AvailableDataGridView;
        private System.Windows.Forms.Button Odpow1Button;
        private System.Windows.Forms.TextBox OdpowTextBox;
        private System.Windows.Forms.Label RoleLabel;
        private System.Windows.Forms.Button AddRoleButton;
        private System.Windows.Forms.Button CleanRoleButton;
        private System.Windows.Forms.Button ExitButton;
    }
}