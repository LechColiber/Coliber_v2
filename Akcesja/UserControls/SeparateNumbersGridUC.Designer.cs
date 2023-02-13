namespace Akcesja.UserControls
{
    partial class SeparateNumbersGridUC
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.numbersDGV = new System.Windows.Forms.DataGridView();
            this.id_czasop_nDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numerDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.originalId_volumesDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberToSortDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.numbersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // numbersDGV
            // 
            this.numbersDGV.AllowDrop = true;
            this.numbersDGV.AllowUserToAddRows = false;
            this.numbersDGV.AllowUserToDeleteRows = false;
            this.numbersDGV.AllowUserToResizeRows = false;
            this.numbersDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numbersDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.numbersDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.numbersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.numbersDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_czasop_nDGVC,
            this.numerDGVC,
            this.originalId_volumesDGVC,
            this.numberToSortDGVC});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.numbersDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.numbersDGV.Location = new System.Drawing.Point(3, 3);
            this.numbersDGV.Name = "numbersDGV";
            this.numbersDGV.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.numbersDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.numbersDGV.RowHeadersVisible = false;
            this.numbersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.numbersDGV.Size = new System.Drawing.Size(119, 296);
            this.numbersDGV.TabIndex = 13;
            this.numbersDGV.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.numbersDGV_CellMouseDown);
            this.numbersDGV.CellMouseMove += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.numbersDGV_CellMouseMove);
            this.numbersDGV.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.numbersDGV_CellMouseUp);
            this.numbersDGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.numbersDGV_RowsAdded);
            this.numbersDGV.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.numbersDGV_SortCompare);
            this.numbersDGV.DragDrop += new System.Windows.Forms.DragEventHandler(this.numbersDGV_DragDrop);
            this.numbersDGV.DragEnter += new System.Windows.Forms.DragEventHandler(this.numbersDGV_DragEnter);
            // 
            // id_czasop_nDGVC
            // 
            this.id_czasop_nDGVC.DataPropertyName = "id";
            this.id_czasop_nDGVC.HeaderText = "id";
            this.id_czasop_nDGVC.Name = "id_czasop_nDGVC";
            this.id_czasop_nDGVC.ReadOnly = true;
            this.id_czasop_nDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id_czasop_nDGVC.Visible = false;
            // 
            // numerDGVC
            // 
            this.numerDGVC.DataPropertyName = "numer";
            this.numerDGVC.HeaderText = "Numery";
            this.numerDGVC.Name = "numerDGVC";
            this.numerDGVC.ReadOnly = true;
            this.numerDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // originalId_volumesDGVC
            // 
            this.originalId_volumesDGVC.HeaderText = "originalId_volumesDGVC";
            this.originalId_volumesDGVC.Name = "originalId_volumesDGVC";
            this.originalId_volumesDGVC.ReadOnly = true;
            this.originalId_volumesDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.originalId_volumesDGVC.Visible = false;
            // 
            // numberToSortDGVC
            // 
            this.numberToSortDGVC.DataPropertyName = "number_to_sort";
            this.numberToSortDGVC.HeaderText = "numberToSort";
            this.numberToSortDGVC.Name = "numberToSortDGVC";
            this.numberToSortDGVC.ReadOnly = true;
            this.numberToSortDGVC.Visible = false;
            // 
            // SeparateNumbersGridUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numbersDGV);
            this.Name = "SeparateNumbersGridUC";
            this.Size = new System.Drawing.Size(125, 302);
            ((System.ComponentModel.ISupportInitialize)(this.numbersDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView numbersDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_czasop_nDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn numerDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn originalId_volumesDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberToSortDGVC;
    }
}
