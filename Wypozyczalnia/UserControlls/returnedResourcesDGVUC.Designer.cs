namespace Wypozyczalnia
{
    partial class returnedResourcesDGVUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.returnedDGV = new System.Windows.Forms.DataGridView();
            this.typesComboBox = new System.Windows.Forms.ComboBox();
            this.wypozIDNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowDateNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorsNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limitNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sygNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoInvNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.returnedDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // returnedDGV
            // 
            this.returnedDGV.AllowUserToAddRows = false;
            this.returnedDGV.AllowUserToDeleteRows = false;
            this.returnedDGV.AllowUserToResizeRows = false;
            this.returnedDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.returnedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.returnedDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wypozIDNotReturnedDGVC,
            this.borrowDateNotReturnedDGVC,
            this.dateNotReturnedDGVC,
            this.descNotReturnedDGVC,
            this.authorsNotReturnedDGVC,
            this.limitNotReturnedDGVC,
            this.sygNotReturnedDGVC,
            this.NoInvNotReturnedDGVC,
            this.barcodeNotReturnedDGVC});
            this.returnedDGV.Location = new System.Drawing.Point(0, 30);
            this.returnedDGV.MultiSelect = false;
            this.returnedDGV.Name = "returnedDGV";
            this.returnedDGV.ReadOnly = true;
            this.returnedDGV.RowHeadersVisible = false;
            this.returnedDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.returnedDGV.Size = new System.Drawing.Size(827, 430);
            this.returnedDGV.TabIndex = 1;
            this.returnedDGV.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.returnedDGV_CellMouseDown);
            // 
            // typesComboBox
            // 
            this.typesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.typesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typesComboBox.FormattingEnabled = true;
            this.typesComboBox.Location = new System.Drawing.Point(646, 3);
            this.typesComboBox.Name = "typesComboBox";
            this.typesComboBox.Size = new System.Drawing.Size(181, 21);
            this.typesComboBox.TabIndex = 3;
            this.typesComboBox.SelectionChangeCommitted += new System.EventHandler(this.typesComboBox_SelectionChangeCommitted);
            // 
            // wypozIDNotReturnedDGVC
            // 
            this.wypozIDNotReturnedDGVC.HeaderText = "wypozID";
            this.wypozIDNotReturnedDGVC.Name = "wypozIDNotReturnedDGVC";
            this.wypozIDNotReturnedDGVC.ReadOnly = true;
            this.wypozIDNotReturnedDGVC.Visible = false;
            // 
            // borrowDateNotReturnedDGVC
            // 
            this.borrowDateNotReturnedDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.borrowDateNotReturnedDGVC.HeaderText = "Data wypożyczenia";
            this.borrowDateNotReturnedDGVC.Name = "borrowDateNotReturnedDGVC";
            this.borrowDateNotReturnedDGVC.ReadOnly = true;
            this.borrowDateNotReturnedDGVC.Width = 114;
            // 
            // dateNotReturnedDGVC
            // 
            this.dateNotReturnedDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateNotReturnedDGVC.DataPropertyName = "data_zwrot";
            this.dateNotReturnedDGVC.HeaderText = "Data zwrotu";
            this.dateNotReturnedDGVC.Name = "dateNotReturnedDGVC";
            this.dateNotReturnedDGVC.ReadOnly = true;
            this.dateNotReturnedDGVC.Width = 82;
            // 
            // descNotReturnedDGVC
            // 
            this.descNotReturnedDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descNotReturnedDGVC.DataPropertyName = "opis";
            this.descNotReturnedDGVC.HeaderText = "Opis";
            this.descNotReturnedDGVC.Name = "descNotReturnedDGVC";
            this.descNotReturnedDGVC.ReadOnly = true;
            // 
            // authorsNotReturnedDGVC
            // 
            this.authorsNotReturnedDGVC.DataPropertyName = "autor";
            this.authorsNotReturnedDGVC.HeaderText = "Autorzy";
            this.authorsNotReturnedDGVC.Name = "authorsNotReturnedDGVC";
            this.authorsNotReturnedDGVC.ReadOnly = true;
            // 
            // limitNotReturnedDGVC
            // 
            this.limitNotReturnedDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.limitNotReturnedDGVC.DataPropertyName = "limit_czasu";
            this.limitNotReturnedDGVC.HeaderText = "Limit";
            this.limitNotReturnedDGVC.Name = "limitNotReturnedDGVC";
            this.limitNotReturnedDGVC.ReadOnly = true;
            this.limitNotReturnedDGVC.Width = 53;
            // 
            // sygNotReturnedDGVC
            // 
            this.sygNotReturnedDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sygNotReturnedDGVC.DataPropertyName = "syg";
            this.sygNotReturnedDGVC.HeaderText = "Sygnatura";
            this.sygNotReturnedDGVC.Name = "sygNotReturnedDGVC";
            this.sygNotReturnedDGVC.ReadOnly = true;
            this.sygNotReturnedDGVC.Width = 80;
            // 
            // NoInvNotReturnedDGVC
            // 
            this.NoInvNotReturnedDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NoInvNotReturnedDGVC.HeaderText = "Numer inwentarzowy";
            this.NoInvNotReturnedDGVC.Name = "NoInvNotReturnedDGVC";
            this.NoInvNotReturnedDGVC.ReadOnly = true;
            this.NoInvNotReturnedDGVC.Width = 119;
            // 
            // barcodeNotReturnedDGVC
            // 
            this.barcodeNotReturnedDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.barcodeNotReturnedDGVC.DataPropertyName = "kod_kresk";
            this.barcodeNotReturnedDGVC.HeaderText = "Kod kreskowy";
            this.barcodeNotReturnedDGVC.Name = "barcodeNotReturnedDGVC";
            this.barcodeNotReturnedDGVC.ReadOnly = true;
            this.barcodeNotReturnedDGVC.Width = 91;
            // 
            // returnedResourcesDGVUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.typesComboBox);
            this.Controls.Add(this.returnedDGV);
            this.Name = "returnedResourcesDGVUC";
            this.Size = new System.Drawing.Size(827, 460);
            ((System.ComponentModel.ISupportInitialize)(this.returnedDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox typesComboBox;
        public System.Windows.Forms.DataGridView returnedDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn wypozIDNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowDateNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn descNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorsNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn limitNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn sygNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoInvNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeNotReturnedDGVC;
    }
}
