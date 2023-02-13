namespace Normy
{
    partial class Slownik
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
            this.AvailableGroupBox = new System.Windows.Forms.GroupBox();
            this.dgSlownik = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbSzukaj = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.OdpowTextBox = new System.Windows.Forms.TextBox();
            this.lbNazwa = new System.Windows.Forms.Label();
            this.DelButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvailableGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSlownik)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // AvailableGroupBox
            // 
            this.AvailableGroupBox.Controls.Add(this.dgSlownik);
            this.AvailableGroupBox.Location = new System.Drawing.Point(12, 12);
            this.AvailableGroupBox.Name = "AvailableGroupBox";
            this.AvailableGroupBox.Size = new System.Drawing.Size(544, 360);
            this.AvailableGroupBox.TabIndex = 0;
            this.AvailableGroupBox.TabStop = false;
            this.AvailableGroupBox.Text = "Lista dostępnych pozycji";
            // 
            // dgSlownik
            // 
            this.dgSlownik.AllowUserToAddRows = false;
            this.dgSlownik.AllowUserToDeleteRows = false;
            this.dgSlownik.AllowUserToResizeRows = false;
            this.dgSlownik.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSlownik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSlownik.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nazwa,
            this.Id});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgSlownik.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgSlownik.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgSlownik.Location = new System.Drawing.Point(3, 16);
            this.dgSlownik.MultiSelect = false;
            this.dgSlownik.Name = "dgSlownik";
            this.dgSlownik.ReadOnly = true;
            this.dgSlownik.RowHeadersVisible = false;
            this.dgSlownik.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgSlownik.Size = new System.Drawing.Size(538, 341);
            this.dgSlownik.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.lbSzukaj);
            this.panel1.Controls.Add(this.ExitButton);
            this.panel1.Controls.Add(this.OKButton);
            this.panel1.Location = new System.Drawing.Point(21, 413);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 36);
            this.panel1.TabIndex = 3;
            // 
            // lbSzukaj
            // 
            this.lbSzukaj.Location = new System.Drawing.Point(104, 9);
            this.lbSzukaj.Name = "lbSzukaj";
            this.lbSzukaj.Size = new System.Drawing.Size(136, 16);
            this.lbSzukaj.TabIndex = 11;
            this.lbSzukaj.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Image = global::Normy.Properties.Resources.door_out;
            this.ExitButton.Location = new System.Drawing.Point(450, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(79, 29);
            this.ExitButton.TabIndex = 10;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Image = global::Normy.Properties.Resources.Check2;
            this.OKButton.Location = new System.Drawing.Point(3, 3);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(90, 29);
            this.OKButton.TabIndex = 2;
            this.OKButton.Text = "Zatwierdź";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // OdpowTextBox
            // 
            this.OdpowTextBox.Enabled = false;
            this.OdpowTextBox.Location = new System.Drawing.Point(135, 383);
            this.OdpowTextBox.Name = "OdpowTextBox";
            this.OdpowTextBox.Size = new System.Drawing.Size(300, 20);
            this.OdpowTextBox.TabIndex = 42;
            // 
            // lbNazwa
            // 
            this.lbNazwa.Location = new System.Drawing.Point(27, 386);
            this.lbNazwa.Name = "lbNazwa";
            this.lbNazwa.Size = new System.Drawing.Size(96, 13);
            this.lbNazwa.TabIndex = 44;
            this.lbNazwa.Visible = false;
            // 
            // DelButton
            // 
            this.DelButton.Enabled = false;
            this.DelButton.Image = global::Normy.Properties.Resources.contact_busy_overlay;
            this.DelButton.Location = new System.Drawing.Point(518, 381);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(32, 23);
            this.DelButton.TabIndex = 47;
            this.DelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DelButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Image = global::Normy.Properties.Resources.edycjam;
            this.EditButton.Location = new System.Drawing.Point(480, 381);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(32, 23);
            this.EditButton.TabIndex = 43;
            this.EditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Enabled = false;
            this.AddButton.Image = global::Normy.Properties.Resources.edit_add;
            this.AddButton.Location = new System.Drawing.Point(442, 381);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(32, 23);
            this.AddButton.TabIndex = 46;
            this.AddButton.UseVisualStyleBackColor = true;
            // 
            // Nazwa
            // 
            this.Nazwa.DataPropertyName = "Nazwa";
            this.Nazwa.HeaderText = "Nazwa";
            this.Nazwa.Name = "Nazwa";
            this.Nazwa.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.FillWeight = 10F;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // Slownik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 455);
            this.Controls.Add(this.DelButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.lbNazwa);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.OdpowTextBox);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AvailableGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Slownik";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wybór";
            this.AvailableGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgSlownik)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox AvailableGroupBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgSlownik;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.TextBox OdpowTextBox;
        private System.Windows.Forms.Label lbNazwa;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label lbSzukaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
    }
}