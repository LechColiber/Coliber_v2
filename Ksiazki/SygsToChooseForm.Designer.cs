namespace Ksiazki
{
    partial class SygsToChooseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SygsToChooseForm));
            this.sygsDataGridView = new System.Windows.Forms.DataGridView();
            this.id_sygnatDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chooseDGVC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sygDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sygsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // sygsDataGridView
            // 
            this.sygsDataGridView.AllowUserToAddRows = false;
            this.sygsDataGridView.AllowUserToDeleteRows = false;
            this.sygsDataGridView.AllowUserToResizeRows = false;
            this.sygsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sygsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sygsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sygsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_sygnatDGVC,
            this.chooseDGVC,
            this.sygDGVC,
            this.descDGVC});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.sygsDataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.sygsDataGridView.Location = new System.Drawing.Point(12, 12);
            this.sygsDataGridView.MultiSelect = false;
            this.sygsDataGridView.Name = "sygsDataGridView";
            this.sygsDataGridView.RowHeadersVisible = false;
            this.sygsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sygsDataGridView.Size = new System.Drawing.Size(610, 308);
            this.sygsDataGridView.TabIndex = 6;
            // 
            // id_sygnatDGVC
            // 
            this.id_sygnatDGVC.DataPropertyName = "id_sygnat";
            this.id_sygnatDGVC.HeaderText = "id_sygnatDGVC";
            this.id_sygnatDGVC.Name = "id_sygnatDGVC";
            this.id_sygnatDGVC.Visible = false;
            // 
            // chooseDGVC
            // 
            this.chooseDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.chooseDGVC.FalseValue = "0";
            this.chooseDGVC.HeaderText = "Zaznacz";
            this.chooseDGVC.Name = "chooseDGVC";
            this.chooseDGVC.TrueValue = "1";
            this.chooseDGVC.Width = 54;
            // 
            // sygDGVC
            // 
            this.sygDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sygDGVC.DataPropertyName = "syg";
            this.sygDGVC.HeaderText = "Sygnatura";
            this.sygDGVC.Name = "sygDGVC";
            this.sygDGVC.ReadOnly = true;
            this.sygDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sygDGVC.Width = 61;
            // 
            // descDGVC
            // 
            this.descDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descDGVC.DataPropertyName = "opis";
            this.descDGVC.HeaderText = "Opis skrócony";
            this.descDGVC.Name = "descDGVC";
            this.descDGVC.ReadOnly = true;
            this.descDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(543, 326);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(79, 23);
            this.ExitButton.TabIndex = 11;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SelectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SelectButton.Image = ((System.Drawing.Image)(resources.GetObject("SelectButton.Image")));
            this.SelectButton.Location = new System.Drawing.Point(12, 326);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(79, 23);
            this.SelectButton.TabIndex = 10;
            this.SelectButton.Text = "Drukuj";
            this.SelectButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // SygsToChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 361);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SelectButton);
            this.Controls.Add(this.sygsDataGridView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(650, 400);
            this.Name = "SygsToChooseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sygnatury";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SygsToChooseForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.sygsDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView sygsDataGridView;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_sygnatDGVC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chooseDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn sygDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn descDGVC;
    }
}