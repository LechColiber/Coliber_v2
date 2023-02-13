namespace Wypozyczalnia
{
    partial class notReturnedResourcesDGVUC
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
            this.components = new System.ComponentModel.Container();
            this.notReturnedDGV = new System.Windows.Forms.DataGridView();
            this.notReturnedContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zawrotZasobuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drukujUpomnienieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.typesComboBox = new System.Windows.Forms.ComboBox();
            this.wypozIDNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorsNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sygNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoInvNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.borrowDateNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.limitNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateNotReturnedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiredDGVC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.notReturnedDGV)).BeginInit();
            this.notReturnedContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // notReturnedDGV
            // 
            this.notReturnedDGV.AllowUserToAddRows = false;
            this.notReturnedDGV.AllowUserToDeleteRows = false;
            this.notReturnedDGV.AllowUserToResizeRows = false;
            this.notReturnedDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.notReturnedDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.notReturnedDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wypozIDNotReturnedDGVC,
            this.descNotReturnedDGVC,
            this.authorsNotReturnedDGVC,
            this.sygNotReturnedDGVC,
            this.NoInvNotReturnedDGVC,
            this.barcodeNotReturnedDGVC,
            this.borrowDateNotReturnedDGVC,
            this.limitNotReturnedDGVC,
            this.dateNotReturnedDGVC,
            this.expiredDGVC});
            this.notReturnedDGV.ContextMenuStrip = this.notReturnedContextMenuStrip;
            this.notReturnedDGV.Location = new System.Drawing.Point(0, 30);
            this.notReturnedDGV.MultiSelect = false;
            this.notReturnedDGV.Name = "notReturnedDGV";
            this.notReturnedDGV.ReadOnly = true;
            this.notReturnedDGV.RowHeadersVisible = false;
            this.notReturnedDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.notReturnedDGV.Size = new System.Drawing.Size(827, 430);
            this.notReturnedDGV.StandardTab = true;
            this.notReturnedDGV.TabIndex = 1;
            this.notReturnedDGV.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.notReturnedDGV_CellMouseDown);
            // 
            // notReturnedContextMenuStrip
            // 
            this.notReturnedContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zawrotZasobuToolStripMenuItem,
            this.drukujUpomnienieToolStripMenuItem});
            this.notReturnedContextMenuStrip.Name = "notReturnedContextMenuStrip";
            this.notReturnedContextMenuStrip.Size = new System.Drawing.Size(177, 48);
            // 
            // zawrotZasobuToolStripMenuItem
            // 
            this.zawrotZasobuToolStripMenuItem.Name = "zawrotZasobuToolStripMenuItem";
            this.zawrotZasobuToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.zawrotZasobuToolStripMenuItem.Text = "Zwrot zasobu";
            this.zawrotZasobuToolStripMenuItem.Click += new System.EventHandler(this.zawrotZasobuToolStripMenuItem_Click);
            // 
            // drukujUpomnienieToolStripMenuItem
            // 
            this.drukujUpomnienieToolStripMenuItem.Name = "drukujUpomnienieToolStripMenuItem";
            this.drukujUpomnienieToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.drukujUpomnienieToolStripMenuItem.Text = "Drukuj upomnienie";
            this.drukujUpomnienieToolStripMenuItem.Click += new System.EventHandler(this.drukujUpomnienieToolStripMenuItem_Click);
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
            this.authorsNotReturnedDGVC.HeaderText = "Autorzy";
            this.authorsNotReturnedDGVC.Name = "authorsNotReturnedDGVC";
            this.authorsNotReturnedDGVC.ReadOnly = true;
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
            // borrowDateNotReturnedDGVC
            // 
            this.borrowDateNotReturnedDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.borrowDateNotReturnedDGVC.HeaderText = "Data wypożyczenia";
            this.borrowDateNotReturnedDGVC.Name = "borrowDateNotReturnedDGVC";
            this.borrowDateNotReturnedDGVC.ReadOnly = true;
            this.borrowDateNotReturnedDGVC.Width = 114;
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
            // dateNotReturnedDGVC
            // 
            this.dateNotReturnedDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dateNotReturnedDGVC.DataPropertyName = "data_przewidywana";
            this.dateNotReturnedDGVC.HeaderText = "Przewidywana data zwrotu";
            this.dateNotReturnedDGVC.Name = "dateNotReturnedDGVC";
            this.dateNotReturnedDGVC.ReadOnly = true;
            this.dateNotReturnedDGVC.Width = 116;
            // 
            // expiredDGVC
            // 
            this.expiredDGVC.HeaderText = "expired";
            this.expiredDGVC.Name = "expiredDGVC";
            this.expiredDGVC.ReadOnly = true;
            this.expiredDGVC.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.expiredDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.expiredDGVC.Visible = false;
            // 
            // notReturnedResourcesDGVUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.typesComboBox);
            this.Controls.Add(this.notReturnedDGV);
            this.Name = "notReturnedResourcesDGVUC";
            this.Size = new System.Drawing.Size(827, 460);
            ((System.ComponentModel.ISupportInitialize)(this.notReturnedDGV)).EndInit();
            this.notReturnedContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip notReturnedContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem zawrotZasobuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drukujUpomnienieToolStripMenuItem;
        private System.Windows.Forms.ComboBox typesComboBox;
        public System.Windows.Forms.DataGridView notReturnedDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn wypozIDNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn descNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorsNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn sygNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoInvNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowDateNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn limitNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateNotReturnedDGVC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn expiredDGVC;
    }
}
