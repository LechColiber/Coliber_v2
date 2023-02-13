namespace Wypozyczalnia
{
    partial class CurrentOrdersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrentOrdersForm));
            this.ordersDGV = new System.Windows.Forms.DataGridView();
            this.orderIdDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIdDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userLockedDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sigDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noInvDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceKindDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentsDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isReadyDGVC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.refreshButton = new System.Windows.Forms.Button();
            this.cancelOrderButton = new System.Windows.Forms.Button();
            this.realizeOrderButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ordersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // ordersDGV
            // 
            this.ordersDGV.AllowUserToAddRows = false;
            this.ordersDGV.AllowUserToDeleteRows = false;
            this.ordersDGV.AllowUserToResizeRows = false;
            this.ordersDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ordersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIdDGVC,
            this.userIdDGVC,
            this.resourceIdDGVC,
            this.userLockedDGVC,
            this.userNameDGVC,
            this.descriptionDGVC,
            this.authorDGVC,
            this.sigDGVC,
            this.noInvDGVC,
            this.resourceKindDGVC,
            this.orderDateDGVC,
            this.commentsDGVC,
            this.isReadyDGVC});
            this.ordersDGV.Location = new System.Drawing.Point(12, 41);
            this.ordersDGV.MultiSelect = false;
            this.ordersDGV.Name = "ordersDGV";
            this.ordersDGV.RowHeadersVisible = false;
            this.ordersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ordersDGV.Size = new System.Drawing.Size(960, 379);
            this.ordersDGV.StandardTab = true;
            this.ordersDGV.TabIndex = 2;
            this.ordersDGV.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ordersDGV_CellValueChanged);
            this.ordersDGV.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.borrowsDGV_ColumnHeaderMouseClick);
            this.ordersDGV.CurrentCellDirtyStateChanged += new System.EventHandler(this.ordersDGV_CurrentCellDirtyStateChanged);
            this.ordersDGV.SelectionChanged += new System.EventHandler(this.ordersDGV_SelectionChanged);
            // 
            // orderIdDGVC
            // 
            this.orderIdDGVC.DataPropertyName = "zamow_id";
            this.orderIdDGVC.FillWeight = 200F;
            this.orderIdDGVC.HeaderText = "zamow_id";
            this.orderIdDGVC.Name = "orderIdDGVC";
            this.orderIdDGVC.Visible = false;
            this.orderIdDGVC.Width = 200;
            // 
            // userIdDGVC
            // 
            this.userIdDGVC.HeaderText = "userId";
            this.userIdDGVC.Name = "userIdDGVC";
            this.userIdDGVC.Visible = false;
            // 
            // resourceIdDGVC
            // 
            this.resourceIdDGVC.HeaderText = "resourceId";
            this.resourceIdDGVC.Name = "resourceIdDGVC";
            this.resourceIdDGVC.Visible = false;
            // 
            // userLockedDGVC
            // 
            this.userLockedDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            this.userLockedDGVC.DefaultCellStyle = dataGridViewCellStyle1;
            this.userLockedDGVC.HeaderText = "";
            this.userLockedDGVC.Name = "userLockedDGVC";
            this.userLockedDGVC.ReadOnly = true;
            this.userLockedDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.userLockedDGVC.Width = 5;
            // 
            // userNameDGVC
            // 
            this.userNameDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.userNameDGVC.DataPropertyName = "uzytkownik";
            this.userNameDGVC.HeaderText = "Użytkownik";
            this.userNameDGVC.Name = "userNameDGVC";
            this.userNameDGVC.ReadOnly = true;
            this.userNameDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.userNameDGVC.Width = 150;
            // 
            // descriptionDGVC
            // 
            this.descriptionDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDGVC.DataPropertyName = "opis";
            this.descriptionDGVC.HeaderText = "Tytuł";
            this.descriptionDGVC.Name = "descriptionDGVC";
            this.descriptionDGVC.ReadOnly = true;
            this.descriptionDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // authorDGVC
            // 
            this.authorDGVC.DataPropertyName = "autor";
            this.authorDGVC.HeaderText = "Autor";
            this.authorDGVC.Name = "authorDGVC";
            this.authorDGVC.ReadOnly = true;
            this.authorDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // sigDGVC
            // 
            this.sigDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sigDGVC.DataPropertyName = "syg";
            this.sigDGVC.HeaderText = "Sygnatura";
            this.sigDGVC.Name = "sigDGVC";
            this.sigDGVC.ReadOnly = true;
            this.sigDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.sigDGVC.Width = 80;
            // 
            // noInvDGVC
            // 
            this.noInvDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.noInvDGVC.DataPropertyName = "numer_inw";
            this.noInvDGVC.HeaderText = "Numer inwentarzowy";
            this.noInvDGVC.Name = "noInvDGVC";
            this.noInvDGVC.ReadOnly = true;
            this.noInvDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.noInvDGVC.Width = 119;
            // 
            // resourceKindDGVC
            // 
            this.resourceKindDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.resourceKindDGVC.DataPropertyName = "rodzaj";
            this.resourceKindDGVC.HeaderText = "Rodzaj";
            this.resourceKindDGVC.Name = "resourceKindDGVC";
            this.resourceKindDGVC.ReadOnly = true;
            this.resourceKindDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.resourceKindDGVC.Width = 20;
            // 
            // orderDateDGVC
            // 
            this.orderDateDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.orderDateDGVC.DataPropertyName = "data_zamow";
            this.orderDateDGVC.HeaderText = "Data zamówienia";
            this.orderDateDGVC.Name = "orderDateDGVC";
            this.orderDateDGVC.ReadOnly = true;
            this.orderDateDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // commentsDGVC
            // 
            this.commentsDGVC.HeaderText = "Uwagi";
            this.commentsDGVC.Name = "commentsDGVC";
            this.commentsDGVC.ReadOnly = true;
            // 
            // isReadyDGVC
            // 
            this.isReadyDGVC.HeaderText = "Przygotowane";
            this.isReadyDGVC.Name = "isReadyDGVC";
            this.isReadyDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // refreshButton
            // 
            this.refreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.refreshButton.Location = new System.Drawing.Point(897, 12);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 3;
            this.refreshButton.Text = "Odśwież";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // cancelOrderButton
            // 
            this.cancelOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelOrderButton.Enabled = false;
            this.cancelOrderButton.Location = new System.Drawing.Point(93, 426);
            this.cancelOrderButton.Name = "cancelOrderButton";
            this.cancelOrderButton.Size = new System.Drawing.Size(75, 23);
            this.cancelOrderButton.TabIndex = 6;
            this.cancelOrderButton.Text = "Zrezygnuj";
            this.cancelOrderButton.UseVisualStyleBackColor = true;
            this.cancelOrderButton.Click += new System.EventHandler(this.cancelOrderButton_Click);
            // 
            // realizeOrderButton
            // 
            this.realizeOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.realizeOrderButton.Enabled = false;
            this.realizeOrderButton.Location = new System.Drawing.Point(12, 426);
            this.realizeOrderButton.Name = "realizeOrderButton";
            this.realizeOrderButton.Size = new System.Drawing.Size(75, 23);
            this.realizeOrderButton.TabIndex = 5;
            this.realizeOrderButton.Text = "Realizuj";
            this.realizeOrderButton.UseVisualStyleBackColor = true;
            this.realizeOrderButton.Click += new System.EventHandler(this.checkoutOrderButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(897, 426);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 7;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // CurrentOrdersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 461);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.cancelOrderButton);
            this.Controls.Add(this.realizeOrderButton);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.ordersDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1000, 500);
            this.Name = "CurrentOrdersForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aktualne zamówienia";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrentOrdersForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.ordersDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView ordersDGV;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Button cancelOrderButton;
        private System.Windows.Forms.Button realizeOrderButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIdDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn userLockedDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn sigDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn noInvDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceKindDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentsDGVC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReadyDGVC;
    }
}