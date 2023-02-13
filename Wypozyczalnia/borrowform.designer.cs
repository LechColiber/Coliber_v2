namespace Wypozyczalnia
{
    partial class BorrowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorrowForm));
            this.userLabel = new System.Windows.Forms.Label();
            this.userGroupBox = new System.Windows.Forms.GroupBox();
            this.userLockedLabel = new System.Windows.Forms.Label();
            this.UDGVC = new System.Windows.Forms.DataGridView();
            this.nameUDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateUDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateUDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lockedUDGVC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.userCardButton = new System.Windows.Forms.Button();
            this.selectUserButton = new System.Windows.Forms.Button();
            this.searchUserTextBox = new System.Windows.Forms.TextBox();
            this.critLabel = new System.Windows.Forms.Label();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.resourceGroupBox = new System.Windows.Forms.GroupBox();
            this.printButton = new System.Windows.Forms.Button();
            this.orderButton = new System.Windows.Forms.Button();
            this.borrowButton = new System.Windows.Forms.Button();
            this.expectedReturnDateLabel = new System.Windows.Forms.Label();
            this.borrowDateLabel = new System.Windows.Forms.Label();
            this.returnDateDTP = new System.Windows.Forms.DateTimePicker();
            this.borrowDateDTP = new System.Windows.Forms.DateTimePicker();
            this.RDGVC = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chooseResourceButton = new System.Windows.Forms.Button();
            this.resourceCritTextBox = new System.Windows.Forms.TextBox();
            this.resourceCritLabel = new System.Windows.Forms.Label();
            this.resourceTitleRTB = new System.Windows.Forms.RichTextBox();
            this.resourceLabel = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.actualTabPage = new System.Windows.Forms.TabPage();
            this.returnResourceButton = new System.Windows.Forms.Button();
            this.userPrintButtonsUC1 = new Wypozyczalnia.UserPrintButtonsUC();
            this.notReturnedResourcesDGVUC1 = new Wypozyczalnia.notReturnedResourcesDGVUC();
            this.ordersTabPage = new System.Windows.Forms.TabPage();
            this.cancelOrderButton = new System.Windows.Forms.Button();
            this.checkoutOrderButton = new System.Windows.Forms.Button();
            this.ODGV = new System.Windows.Forms.DataGridView();
            this.orderIdODGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceIdODGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderDateODGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderStateODGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descODGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorsODGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noInvODGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sygODGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentsODGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyTabPage = new System.Windows.Forms.TabPage();
            this.returnedResourcesDGVUC1 = new Wypozyczalnia.returnedResourcesDGVUC();
            this.ExitButton = new System.Windows.Forms.Button();
            this.userGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UDGVC)).BeginInit();
            this.resourceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RDGVC)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.actualTabPage.SuspendLayout();
            this.ordersTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ODGV)).BeginInit();
            this.historyTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // userLabel
            // 
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userLabel.Location = new System.Drawing.Point(22, 19);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(88, 13);
            this.userLabel.TabIndex = 0;
            this.userLabel.Text = "Użytkownik";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userGroupBox
            // 
            this.userGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userGroupBox.Controls.Add(this.userLockedLabel);
            this.userGroupBox.Controls.Add(this.UDGVC);
            this.userGroupBox.Controls.Add(this.userCardButton);
            this.userGroupBox.Controls.Add(this.selectUserButton);
            this.userGroupBox.Controls.Add(this.searchUserTextBox);
            this.userGroupBox.Controls.Add(this.critLabel);
            this.userGroupBox.Controls.Add(this.userTextBox);
            this.userGroupBox.Controls.Add(this.userLabel);
            this.userGroupBox.Location = new System.Drawing.Point(12, 12);
            this.userGroupBox.Name = "userGroupBox";
            this.userGroupBox.Size = new System.Drawing.Size(960, 118);
            this.userGroupBox.TabIndex = 2;
            this.userGroupBox.TabStop = false;
            this.userGroupBox.Text = "Dane użytkownika ";
            // 
            // userLockedLabel
            // 
            this.userLockedLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userLockedLabel.AutoSize = true;
            this.userLockedLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userLockedLabel.ForeColor = System.Drawing.Color.Red;
            this.userLockedLabel.Location = new System.Drawing.Point(405, 19);
            this.userLockedLabel.Name = "userLockedLabel";
            this.userLockedLabel.Size = new System.Drawing.Size(15, 13);
            this.userLockedLabel.TabIndex = 12;
            this.userLockedLabel.Text = "Z";
            this.userLockedLabel.Visible = false;
            // 
            // UDGVC
            // 
            this.UDGVC.AllowUserToAddRows = false;
            this.UDGVC.AllowUserToDeleteRows = false;
            this.UDGVC.AllowUserToResizeRows = false;
            this.UDGVC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UDGVC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.UDGVC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameUDGVC,
            this.startDateUDGVC,
            this.endDateUDGVC,
            this.lockedUDGVC});
            this.UDGVC.Location = new System.Drawing.Point(516, 16);
            this.UDGVC.MultiSelect = false;
            this.UDGVC.Name = "UDGVC";
            this.UDGVC.ReadOnly = true;
            this.UDGVC.RowHeadersVisible = false;
            this.UDGVC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.UDGVC.Size = new System.Drawing.Size(438, 92);
            this.UDGVC.TabIndex = 11;
            this.UDGVC.TabStop = false;
            // 
            // nameUDGVC
            // 
            this.nameUDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameUDGVC.HeaderText = "Uprawnienie";
            this.nameUDGVC.Name = "nameUDGVC";
            this.nameUDGVC.ReadOnly = true;
            this.nameUDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // startDateUDGVC
            // 
            this.startDateUDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.startDateUDGVC.HeaderText = "Data od";
            this.startDateUDGVC.Name = "startDateUDGVC";
            this.startDateUDGVC.ReadOnly = true;
            this.startDateUDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.startDateUDGVC.Width = 51;
            // 
            // endDateUDGVC
            // 
            this.endDateUDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.endDateUDGVC.DataPropertyName = "data_od";
            this.endDateUDGVC.HeaderText = "Data do";
            this.endDateUDGVC.Name = "endDateUDGVC";
            this.endDateUDGVC.ReadOnly = true;
            this.endDateUDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.endDateUDGVC.Width = 51;
            // 
            // lockedUDGVC
            // 
            this.lockedUDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.lockedUDGVC.DataPropertyName = "zablokowane";
            this.lockedUDGVC.HeaderText = "Zablokowane";
            this.lockedUDGVC.Name = "lockedUDGVC";
            this.lockedUDGVC.ReadOnly = true;
            this.lockedUDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.lockedUDGVC.Width = 97;
            // 
            // userCardButton
            // 
            this.userCardButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userCardButton.Enabled = false;
            this.userCardButton.Image = ((System.Drawing.Image)(resources.GetObject("userCardButton.Image")));
            this.userCardButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userCardButton.Location = new System.Drawing.Point(434, 41);
            this.userCardButton.Name = "userCardButton";
            this.userCardButton.Size = new System.Drawing.Size(27, 23);
            this.userCardButton.TabIndex = 2;
            this.userCardButton.TabStop = false;
            this.userCardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.userCardButton.UseVisualStyleBackColor = true;
            this.userCardButton.Click += new System.EventHandler(this.userCardButton_Click);
            // 
            // selectUserButton
            // 
            this.selectUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.selectUserButton.Image = ((System.Drawing.Image)(resources.GetObject("selectUserButton.Image")));
            this.selectUserButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.selectUserButton.Location = new System.Drawing.Point(401, 41);
            this.selectUserButton.Name = "selectUserButton";
            this.selectUserButton.Size = new System.Drawing.Size(27, 23);
            this.selectUserButton.TabIndex = 1;
            this.selectUserButton.TabStop = false;
            this.selectUserButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectUserButton.UseVisualStyleBackColor = true;
            this.selectUserButton.Click += new System.EventHandler(this.selectUserButton_Click);
            // 
            // searchUserTextBox
            // 
            this.searchUserTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchUserTextBox.Location = new System.Drawing.Point(116, 42);
            this.searchUserTextBox.Name = "searchUserTextBox";
            this.searchUserTextBox.Size = new System.Drawing.Size(279, 20);
            this.searchUserTextBox.TabIndex = 0;
            this.searchUserTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchUserTextBox_KeyDown);
            // 
            // critLabel
            // 
            this.critLabel.Location = new System.Drawing.Point(6, 45);
            this.critLabel.Name = "critLabel";
            this.critLabel.Size = new System.Drawing.Size(104, 17);
            this.critLabel.TabIndex = 2;
            this.critLabel.Text = "Kod kreskowy";
            this.critLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userTextBox
            // 
            this.userTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.userTextBox.Location = new System.Drawing.Point(116, 16);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.ReadOnly = true;
            this.userTextBox.Size = new System.Drawing.Size(279, 20);
            this.userTextBox.TabIndex = 1;
            this.userTextBox.TabStop = false;
            // 
            // resourceGroupBox
            // 
            this.resourceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resourceGroupBox.Controls.Add(this.printButton);
            this.resourceGroupBox.Controls.Add(this.orderButton);
            this.resourceGroupBox.Controls.Add(this.borrowButton);
            this.resourceGroupBox.Controls.Add(this.expectedReturnDateLabel);
            this.resourceGroupBox.Controls.Add(this.borrowDateLabel);
            this.resourceGroupBox.Controls.Add(this.returnDateDTP);
            this.resourceGroupBox.Controls.Add(this.borrowDateDTP);
            this.resourceGroupBox.Controls.Add(this.RDGVC);
            this.resourceGroupBox.Controls.Add(this.chooseResourceButton);
            this.resourceGroupBox.Controls.Add(this.resourceCritTextBox);
            this.resourceGroupBox.Controls.Add(this.resourceCritLabel);
            this.resourceGroupBox.Controls.Add(this.resourceTitleRTB);
            this.resourceGroupBox.Controls.Add(this.resourceLabel);
            this.resourceGroupBox.Location = new System.Drawing.Point(12, 136);
            this.resourceGroupBox.Name = "resourceGroupBox";
            this.resourceGroupBox.Size = new System.Drawing.Size(960, 163);
            this.resourceGroupBox.TabIndex = 3;
            this.resourceGroupBox.TabStop = false;
            this.resourceGroupBox.Text = "Dane zasobu";
            // 
            // printButton
            // 
            this.printButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.printButton.Image = ((System.Drawing.Image)(resources.GetObject("printButton.Image")));
            this.printButton.Location = new System.Drawing.Point(768, 129);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(120, 23);
            this.printButton.TabIndex = 6;
            this.printButton.Text = "Drukuj rewers";
            this.printButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printButton.UseVisualStyleBackColor = true;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // orderButton
            // 
            this.orderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.orderButton.Location = new System.Drawing.Point(642, 130);
            this.orderButton.Name = "orderButton";
            this.orderButton.Size = new System.Drawing.Size(120, 23);
            this.orderButton.TabIndex = 5;
            this.orderButton.Text = "Zamów";
            this.orderButton.UseVisualStyleBackColor = true;
            this.orderButton.Click += new System.EventHandler(this.orderButton_Click);
            // 
            // borrowButton
            // 
            this.borrowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.borrowButton.Location = new System.Drawing.Point(516, 131);
            this.borrowButton.Name = "borrowButton";
            this.borrowButton.Size = new System.Drawing.Size(120, 23);
            this.borrowButton.TabIndex = 4;
            this.borrowButton.Text = "Wypożycz";
            this.borrowButton.UseVisualStyleBackColor = true;
            this.borrowButton.Click += new System.EventHandler(this.borrowButton_Click);
            // 
            // expectedReturnDateLabel
            // 
            this.expectedReturnDateLabel.Location = new System.Drawing.Point(4, 141);
            this.expectedReturnDateLabel.Name = "expectedReturnDateLabel";
            this.expectedReturnDateLabel.Size = new System.Drawing.Size(133, 13);
            this.expectedReturnDateLabel.TabIndex = 17;
            this.expectedReturnDateLabel.Text = "Przewidywana data zwrotu";
            this.expectedReturnDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // borrowDateLabel
            // 
            this.borrowDateLabel.Location = new System.Drawing.Point(38, 115);
            this.borrowDateLabel.Name = "borrowDateLabel";
            this.borrowDateLabel.Size = new System.Drawing.Size(99, 13);
            this.borrowDateLabel.TabIndex = 16;
            this.borrowDateLabel.Text = "Data wypożyczenia";
            this.borrowDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // returnDateDTP
            // 
            this.returnDateDTP.Location = new System.Drawing.Point(143, 137);
            this.returnDateDTP.Name = "returnDateDTP";
            this.returnDateDTP.Size = new System.Drawing.Size(200, 20);
            this.returnDateDTP.TabIndex = 3;
            this.returnDateDTP.ValueChanged += new System.EventHandler(this.returnDateDTP_ValueChanged);
            // 
            // borrowDateDTP
            // 
            this.borrowDateDTP.Location = new System.Drawing.Point(143, 111);
            this.borrowDateDTP.Name = "borrowDateDTP";
            this.borrowDateDTP.Size = new System.Drawing.Size(200, 20);
            this.borrowDateDTP.TabIndex = 2;
            this.borrowDateDTP.ValueChanged += new System.EventHandler(this.borrowDateDTP_ValueChanged);
            // 
            // RDGVC
            // 
            this.RDGVC.AllowUserToAddRows = false;
            this.RDGVC.AllowUserToDeleteRows = false;
            this.RDGVC.AllowUserToResizeRows = false;
            this.RDGVC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RDGVC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RDGVC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewCheckBoxColumn1});
            this.RDGVC.Location = new System.Drawing.Point(516, 13);
            this.RDGVC.MultiSelect = false;
            this.RDGVC.Name = "RDGVC";
            this.RDGVC.ReadOnly = true;
            this.RDGVC.RowHeadersVisible = false;
            this.RDGVC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.RDGVC.Size = new System.Drawing.Size(438, 92);
            this.RDGVC.TabIndex = 13;
            this.RDGVC.TabStop = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "Uprawnienie";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Data od";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 51;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "data_od";
            this.dataGridViewTextBoxColumn3.HeaderText = "Data do";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 51;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "zablokowane";
            this.dataGridViewCheckBoxColumn1.HeaderText = "Zablokowane";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.ReadOnly = true;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewCheckBoxColumn1.Width = 97;
            // 
            // chooseResourceButton
            // 
            this.chooseResourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chooseResourceButton.Image = ((System.Drawing.Image)(resources.GetObject("chooseResourceButton.Image")));
            this.chooseResourceButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.chooseResourceButton.Location = new System.Drawing.Point(434, 84);
            this.chooseResourceButton.Name = "chooseResourceButton";
            this.chooseResourceButton.Size = new System.Drawing.Size(27, 23);
            this.chooseResourceButton.TabIndex = 1;
            this.chooseResourceButton.TabStop = false;
            this.chooseResourceButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.chooseResourceButton.UseVisualStyleBackColor = true;
            this.chooseResourceButton.Click += new System.EventHandler(this.chooseResourceButton_Click);
            // 
            // resourceCritTextBox
            // 
            this.resourceCritTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resourceCritTextBox.Location = new System.Drawing.Point(121, 85);
            this.resourceCritTextBox.Name = "resourceCritTextBox";
            this.resourceCritTextBox.Size = new System.Drawing.Size(307, 20);
            this.resourceCritTextBox.TabIndex = 0;
            this.resourceCritTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resourceCritTextBox_KeyDown);
            // 
            // resourceCritLabel
            // 
            this.resourceCritLabel.Location = new System.Drawing.Point(6, 88);
            this.resourceCritLabel.Name = "resourceCritLabel";
            this.resourceCritLabel.Size = new System.Drawing.Size(109, 17);
            this.resourceCritLabel.TabIndex = 10;
            this.resourceCritLabel.Text = "[kryterium]";
            this.resourceCritLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // resourceTitleRTB
            // 
            this.resourceTitleRTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.resourceTitleRTB.Location = new System.Drawing.Point(121, 13);
            this.resourceTitleRTB.Name = "resourceTitleRTB";
            this.resourceTitleRTB.ReadOnly = true;
            this.resourceTitleRTB.Size = new System.Drawing.Size(340, 66);
            this.resourceTitleRTB.TabIndex = 2;
            this.resourceTitleRTB.TabStop = false;
            this.resourceTitleRTB.Text = "";
            // 
            // resourceLabel
            // 
            this.resourceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.resourceLabel.Location = new System.Drawing.Point(41, 16);
            this.resourceLabel.Name = "resourceLabel";
            this.resourceLabel.Size = new System.Drawing.Size(74, 13);
            this.resourceLabel.TabIndex = 1;
            this.resourceLabel.Text = "Zasób";
            this.resourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.actualTabPage);
            this.tabControl1.Controls.Add(this.ordersTabPage);
            this.tabControl1.Controls.Add(this.historyTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 305);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(960, 265);
            this.tabControl1.TabIndex = 5;
            // 
            // actualTabPage
            // 
            this.actualTabPage.Controls.Add(this.returnResourceButton);
            this.actualTabPage.Controls.Add(this.userPrintButtonsUC1);
            this.actualTabPage.Controls.Add(this.notReturnedResourcesDGVUC1);
            this.actualTabPage.Location = new System.Drawing.Point(4, 22);
            this.actualTabPage.Name = "actualTabPage";
            this.actualTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.actualTabPage.Size = new System.Drawing.Size(952, 239);
            this.actualTabPage.TabIndex = 1;
            this.actualTabPage.Text = "Wypożyczenia";
            this.actualTabPage.UseVisualStyleBackColor = true;
            // 
            // returnResourceButton
            // 
            this.returnResourceButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.returnResourceButton.Location = new System.Drawing.Point(3, 204);
            this.returnResourceButton.Name = "returnResourceButton";
            this.returnResourceButton.Size = new System.Drawing.Size(180, 23);
            this.returnResourceButton.TabIndex = 0;
            this.returnResourceButton.Text = "Zwrot zasobu";
            this.returnResourceButton.UseVisualStyleBackColor = true;
            this.returnResourceButton.Click += new System.EventHandler(this.returnResourceButton_Click);
            // 
            // userPrintButtonsUC1
            // 
            this.userPrintButtonsUC1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userPrintButtonsUC1.Location = new System.Drawing.Point(189, 204);
            this.userPrintButtonsUC1.Name = "userPrintButtonsUC1";
            this.userPrintButtonsUC1.Size = new System.Drawing.Size(588, 23);
            this.userPrintButtonsUC1.TabIndex = 1;
            this.userPrintButtonsUC1.UserId = 0;
            // 
            // notReturnedResourcesDGVUC1
            // 
            this.notReturnedResourcesDGVUC1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.notReturnedResourcesDGVUC1.Location = new System.Drawing.Point(3, 3);
            this.notReturnedResourcesDGVUC1.Name = "notReturnedResourcesDGVUC1";
            this.notReturnedResourcesDGVUC1.OnReturnBorrow = null;
            this.notReturnedResourcesDGVUC1.Size = new System.Drawing.Size(946, 195);
            this.notReturnedResourcesDGVUC1.TabIndex = 0;
            this.notReturnedResourcesDGVUC1.TabStop = false;
            // 
            // ordersTabPage
            // 
            this.ordersTabPage.Controls.Add(this.cancelOrderButton);
            this.ordersTabPage.Controls.Add(this.checkoutOrderButton);
            this.ordersTabPage.Controls.Add(this.ODGV);
            this.ordersTabPage.Location = new System.Drawing.Point(4, 22);
            this.ordersTabPage.Name = "ordersTabPage";
            this.ordersTabPage.Size = new System.Drawing.Size(952, 239);
            this.ordersTabPage.TabIndex = 2;
            this.ordersTabPage.Text = "Zamówienia";
            this.ordersTabPage.UseVisualStyleBackColor = true;
            // 
            // cancelOrderButton
            // 
            this.cancelOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelOrderButton.Enabled = false;
            this.cancelOrderButton.Location = new System.Drawing.Point(84, 213);
            this.cancelOrderButton.Name = "cancelOrderButton";
            this.cancelOrderButton.Size = new System.Drawing.Size(75, 23);
            this.cancelOrderButton.TabIndex = 4;
            this.cancelOrderButton.Text = "Zrezygnuj";
            this.cancelOrderButton.UseVisualStyleBackColor = true;
            this.cancelOrderButton.Click += new System.EventHandler(this.cancelOrderButton_Click);
            // 
            // checkoutOrderButton
            // 
            this.checkoutOrderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkoutOrderButton.Enabled = false;
            this.checkoutOrderButton.Location = new System.Drawing.Point(3, 213);
            this.checkoutOrderButton.Name = "checkoutOrderButton";
            this.checkoutOrderButton.Size = new System.Drawing.Size(75, 23);
            this.checkoutOrderButton.TabIndex = 3;
            this.checkoutOrderButton.Text = "Realizuj";
            this.checkoutOrderButton.UseVisualStyleBackColor = true;
            this.checkoutOrderButton.Click += new System.EventHandler(this.checkoutOrderButton_Click);
            // 
            // ODGV
            // 
            this.ODGV.AllowUserToAddRows = false;
            this.ODGV.AllowUserToDeleteRows = false;
            this.ODGV.AllowUserToResizeRows = false;
            this.ODGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ODGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ODGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIdODGVC,
            this.resourceIdODGVC,
            this.orderDateODGVC,
            this.orderStateODGVC,
            this.descODGVC,
            this.authorsODGVC,
            this.noInvODGVC,
            this.sygODGVC,
            this.CommentsODGVC});
            this.ODGV.Location = new System.Drawing.Point(3, 0);
            this.ODGV.MultiSelect = false;
            this.ODGV.Name = "ODGV";
            this.ODGV.ReadOnly = true;
            this.ODGV.RowHeadersVisible = false;
            this.ODGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ODGV.Size = new System.Drawing.Size(946, 207);
            this.ODGV.TabIndex = 2;
            // 
            // orderIdODGVC
            // 
            this.orderIdODGVC.DataPropertyName = "zamow_id";
            this.orderIdODGVC.HeaderText = "orderId";
            this.orderIdODGVC.Name = "orderIdODGVC";
            this.orderIdODGVC.ReadOnly = true;
            this.orderIdODGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orderIdODGVC.Visible = false;
            // 
            // resourceIdODGVC
            // 
            this.resourceIdODGVC.DataPropertyName = "zasob_id";
            this.resourceIdODGVC.HeaderText = "resourceId";
            this.resourceIdODGVC.Name = "resourceIdODGVC";
            this.resourceIdODGVC.ReadOnly = true;
            this.resourceIdODGVC.Visible = false;
            // 
            // orderDateODGVC
            // 
            this.orderDateODGVC.DataPropertyName = "data_zamow";
            this.orderDateODGVC.HeaderText = "Data zamówienia";
            this.orderDateODGVC.Name = "orderDateODGVC";
            this.orderDateODGVC.ReadOnly = true;
            this.orderDateODGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // orderStateODGVC
            // 
            this.orderStateODGVC.DataPropertyName = "stan";
            this.orderStateODGVC.HeaderText = "Stan zamówienia";
            this.orderStateODGVC.Name = "orderStateODGVC";
            this.orderStateODGVC.ReadOnly = true;
            this.orderStateODGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // descODGVC
            // 
            this.descODGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descODGVC.DataPropertyName = "opis";
            this.descODGVC.HeaderText = "Opis";
            this.descODGVC.Name = "descODGVC";
            this.descODGVC.ReadOnly = true;
            this.descODGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // authorsODGVC
            // 
            this.authorsODGVC.DataPropertyName = "autor";
            this.authorsODGVC.HeaderText = "Autorzy";
            this.authorsODGVC.Name = "authorsODGVC";
            this.authorsODGVC.ReadOnly = true;
            this.authorsODGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // noInvODGVC
            // 
            this.noInvODGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.noInvODGVC.DataPropertyName = "numer_inw";
            this.noInvODGVC.HeaderText = "Numer inwentarzowy";
            this.noInvODGVC.Name = "noInvODGVC";
            this.noInvODGVC.ReadOnly = true;
            this.noInvODGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sygODGVC
            // 
            this.sygODGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sygODGVC.DataPropertyName = "syg";
            this.sygODGVC.HeaderText = "Sygnatura";
            this.sygODGVC.Name = "sygODGVC";
            this.sygODGVC.ReadOnly = true;
            this.sygODGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sygODGVC.Width = 61;
            // 
            // CommentsODGVC
            // 
            this.CommentsODGVC.DataPropertyName = "uwagi";
            this.CommentsODGVC.HeaderText = "Uwagi";
            this.CommentsODGVC.Name = "CommentsODGVC";
            this.CommentsODGVC.ReadOnly = true;
            // 
            // historyTabPage
            // 
            this.historyTabPage.Controls.Add(this.returnedResourcesDGVUC1);
            this.historyTabPage.Location = new System.Drawing.Point(4, 22);
            this.historyTabPage.Name = "historyTabPage";
            this.historyTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.historyTabPage.Size = new System.Drawing.Size(952, 239);
            this.historyTabPage.TabIndex = 0;
            this.historyTabPage.Text = "Historia";
            this.historyTabPage.UseVisualStyleBackColor = true;
            // 
            // returnedResourcesDGVUC1
            // 
            this.returnedResourcesDGVUC1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.returnedResourcesDGVUC1.Location = new System.Drawing.Point(3, 3);
            this.returnedResourcesDGVUC1.Name = "returnedResourcesDGVUC1";
            this.returnedResourcesDGVUC1.Size = new System.Drawing.Size(946, 233);
            this.returnedResourcesDGVUC1.TabIndex = 4;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(897, 576);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // BorrowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 616);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.resourceGroupBox);
            this.Controls.Add(this.userGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "BorrowForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wypożyczanie i zwracanie zasobów";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BorrowForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BorrowForm_KeyDown);
            this.userGroupBox.ResumeLayout(false);
            this.userGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UDGVC)).EndInit();
            this.resourceGroupBox.ResumeLayout(false);
            this.resourceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RDGVC)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.actualTabPage.ResumeLayout(false);
            this.ordersTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ODGV)).EndInit();
            this.historyTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.GroupBox userGroupBox;
        private System.Windows.Forms.GroupBox resourceGroupBox;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox searchUserTextBox;
        private System.Windows.Forms.Label critLabel;
        private System.Windows.Forms.Button userCardButton;
        private System.Windows.Forms.Button selectUserButton;
        private System.Windows.Forms.DataGridView UDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameUDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateUDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateUDGVC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn lockedUDGVC;
        private System.Windows.Forms.Button chooseResourceButton;
        private System.Windows.Forms.TextBox resourceCritTextBox;
        private System.Windows.Forms.Label resourceCritLabel;
        private System.Windows.Forms.RichTextBox resourceTitleRTB;
        private System.Windows.Forms.Label resourceLabel;
        private System.Windows.Forms.DataGridView RDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.Label expectedReturnDateLabel;
        private System.Windows.Forms.Label borrowDateLabel;
        private System.Windows.Forms.DateTimePicker returnDateDTP;
        private System.Windows.Forms.DateTimePicker borrowDateDTP;
        private returnedResourcesDGVUC returnedResourcesDGVUC1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage historyTabPage;
        private System.Windows.Forms.TabPage actualTabPage;
        private System.Windows.Forms.TabPage ordersTabPage;
        private notReturnedResourcesDGVUC notReturnedResourcesDGVUC1;
        private System.Windows.Forms.Button cancelOrderButton;
        private System.Windows.Forms.Button checkoutOrderButton;
        public System.Windows.Forms.DataGridView ODGV;
        private UserPrintButtonsUC userPrintButtonsUC1;
        private System.Windows.Forms.Button printButton;
        private System.Windows.Forms.Button orderButton;
        private System.Windows.Forms.Button borrowButton;
        private System.Windows.Forms.Button returnResourceButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label userLockedLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdODGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceIdODGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateODGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderStateODGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn descODGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorsODGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn noInvODGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn sygODGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentsODGVC;
    }
}