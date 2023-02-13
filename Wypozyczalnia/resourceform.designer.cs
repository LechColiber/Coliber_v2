namespace Wypozyczalnia
{
    partial class ResourceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.CommentsRTB = new System.Windows.Forms.RichTextBox();
            this.daysLabel = new System.Windows.Forms.Label();
            this.timeTextBox = new System.Windows.Forms.TextBox();
            this.groupTextBox = new System.Windows.Forms.TextBox();
            this.isBorrowedCheckBox = new System.Windows.Forms.CheckBox();
            this.noIvnTextBox = new System.Windows.Forms.TextBox();
            this.barcodeTextBox = new System.Windows.Forms.TextBox();
            this.timeLimitLabel = new System.Windows.Forms.Label();
            this.groupIdLabel = new System.Windows.Forms.Label();
            this.invertoryNumberLabel = new System.Windows.Forms.Label();
            this.barcodeLabel = new System.Windows.Forms.Label();
            this.TitleRTB = new System.Windows.Forms.RichTextBox();
            this.PermissionstabPage = new System.Windows.Forms.TabPage();
            this.addPermissionButton = new System.Windows.Forms.Button();
            this.deletePermissionButton = new System.Windows.Forms.Button();
            this.permissionCheckBox = new System.Windows.Forms.CheckBox();
            this.endDatePermissionDTP = new System.Windows.Forms.DateTimePicker();
            this.startDatePermissionDTP = new System.Windows.Forms.DateTimePicker();
            this.validToLabel = new System.Windows.Forms.Label();
            this.validFromLabel = new System.Windows.Forms.Label();
            this.permissionsDGV = new System.Windows.Forms.DataGridView();
            this.syncIdPermissionsDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.namePermissionsDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.historyTabPage = new System.Windows.Forms.TabPage();
            this.historyDGV = new System.Windows.Forms.DataGridView();
            this.borrowDateDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnDateDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delayDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.returnEmployeeDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderHistoryTabPage = new System.Windows.Forms.TabPage();
            this.orderHistoryDGVC = new System.Windows.Forms.DataGridView();
            this.orderDateDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.PermissionstabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsDGV)).BeginInit();
            this.historyTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.historyDGV)).BeginInit();
            this.orderHistoryTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.orderHistoryDGVC)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.generalTabPage);
            this.tabControl1.Controls.Add(this.PermissionstabPage);
            this.tabControl1.Controls.Add(this.historyTabPage);
            this.tabControl1.Controls.Add(this.orderHistoryTabPage);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(660, 304);
            this.tabControl1.TabIndex = 0;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.commentsLabel);
            this.generalTabPage.Controls.Add(this.CommentsRTB);
            this.generalTabPage.Controls.Add(this.daysLabel);
            this.generalTabPage.Controls.Add(this.timeTextBox);
            this.generalTabPage.Controls.Add(this.groupTextBox);
            this.generalTabPage.Controls.Add(this.isBorrowedCheckBox);
            this.generalTabPage.Controls.Add(this.noIvnTextBox);
            this.generalTabPage.Controls.Add(this.barcodeTextBox);
            this.generalTabPage.Controls.Add(this.timeLimitLabel);
            this.generalTabPage.Controls.Add(this.groupIdLabel);
            this.generalTabPage.Controls.Add(this.invertoryNumberLabel);
            this.generalTabPage.Controls.Add(this.barcodeLabel);
            this.generalTabPage.Controls.Add(this.TitleRTB);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(652, 278);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "Ogólne";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // commentsLabel
            // 
            this.commentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commentsLabel.Location = new System.Drawing.Point(6, 206);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(56, 13);
            this.commentsLabel.TabIndex = 12;
            this.commentsLabel.Text = "Uwagi:";
            // 
            // CommentsRTB
            // 
            this.CommentsRTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentsRTB.Location = new System.Drawing.Point(6, 224);
            this.CommentsRTB.Name = "CommentsRTB";
            this.CommentsRTB.ReadOnly = true;
            this.CommentsRTB.Size = new System.Drawing.Size(640, 48);
            this.CommentsRTB.TabIndex = 11;
            this.CommentsRTB.Text = "";
            // 
            // daysLabel
            // 
            this.daysLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.daysLabel.AutoSize = true;
            this.daysLabel.Location = new System.Drawing.Point(174, 182);
            this.daysLabel.Name = "daysLabel";
            this.daysLabel.Size = new System.Drawing.Size(21, 13);
            this.daysLabel.TabIndex = 10;
            this.daysLabel.Text = "dni";
            // 
            // timeTextBox
            // 
            this.timeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeTextBox.Location = new System.Drawing.Point(127, 179);
            this.timeTextBox.Name = "timeTextBox";
            this.timeTextBox.Size = new System.Drawing.Size(41, 20);
            this.timeTextBox.TabIndex = 9;
            this.timeTextBox.TextChanged += new System.EventHandler(this.timeTextBox_TextChanged);
            // 
            // groupTextBox
            // 
            this.groupTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupTextBox.Location = new System.Drawing.Point(127, 153);
            this.groupTextBox.Name = "groupTextBox";
            this.groupTextBox.ReadOnly = true;
            this.groupTextBox.Size = new System.Drawing.Size(182, 20);
            this.groupTextBox.TabIndex = 8;
            // 
            // isBorrowedCheckBox
            // 
            this.isBorrowedCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.isBorrowedCheckBox.Enabled = false;
            this.isBorrowedCheckBox.Location = new System.Drawing.Point(315, 103);
            this.isBorrowedCheckBox.Name = "isBorrowedCheckBox";
            this.isBorrowedCheckBox.Size = new System.Drawing.Size(112, 17);
            this.isBorrowedCheckBox.TabIndex = 7;
            this.isBorrowedCheckBox.Text = "Wypożyczony";
            this.isBorrowedCheckBox.UseVisualStyleBackColor = true;
            // 
            // noIvnTextBox
            // 
            this.noIvnTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.noIvnTextBox.Location = new System.Drawing.Point(127, 127);
            this.noIvnTextBox.Name = "noIvnTextBox";
            this.noIvnTextBox.ReadOnly = true;
            this.noIvnTextBox.Size = new System.Drawing.Size(182, 20);
            this.noIvnTextBox.TabIndex = 6;
            // 
            // barcodeTextBox
            // 
            this.barcodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.barcodeTextBox.Location = new System.Drawing.Point(127, 101);
            this.barcodeTextBox.Name = "barcodeTextBox";
            this.barcodeTextBox.ReadOnly = true;
            this.barcodeTextBox.Size = new System.Drawing.Size(182, 20);
            this.barcodeTextBox.TabIndex = 5;
            // 
            // timeLimitLabel
            // 
            this.timeLimitLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.timeLimitLabel.Location = new System.Drawing.Point(6, 182);
            this.timeLimitLabel.Name = "timeLimitLabel";
            this.timeLimitLabel.Size = new System.Drawing.Size(134, 13);
            this.timeLimitLabel.TabIndex = 4;
            this.timeLimitLabel.Text = "Limit czasu na oddanie:";
            // 
            // groupIdLabel
            // 
            this.groupIdLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupIdLabel.Location = new System.Drawing.Point(6, 156);
            this.groupIdLabel.Name = "groupIdLabel";
            this.groupIdLabel.Size = new System.Drawing.Size(113, 13);
            this.groupIdLabel.TabIndex = 3;
            this.groupIdLabel.Text = "Identyfikator grupy:";
            // 
            // invertoryNumberLabel
            // 
            this.invertoryNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.invertoryNumberLabel.Location = new System.Drawing.Point(6, 130);
            this.invertoryNumberLabel.Name = "invertoryNumberLabel";
            this.invertoryNumberLabel.Size = new System.Drawing.Size(124, 13);
            this.invertoryNumberLabel.TabIndex = 2;
            this.invertoryNumberLabel.Text = "Numer inwentarzowy:";
            // 
            // barcodeLabel
            // 
            this.barcodeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.barcodeLabel.Location = new System.Drawing.Point(6, 104);
            this.barcodeLabel.Name = "barcodeLabel";
            this.barcodeLabel.Size = new System.Drawing.Size(93, 13);
            this.barcodeLabel.TabIndex = 1;
            this.barcodeLabel.Text = "Kod kreskowy:";
            // 
            // TitleRTB
            // 
            this.TitleRTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleRTB.Location = new System.Drawing.Point(6, 6);
            this.TitleRTB.Name = "TitleRTB";
            this.TitleRTB.ReadOnly = true;
            this.TitleRTB.Size = new System.Drawing.Size(640, 90);
            this.TitleRTB.TabIndex = 0;
            this.TitleRTB.Text = "";
            // 
            // PermissionstabPage
            // 
            this.PermissionstabPage.Controls.Add(this.addPermissionButton);
            this.PermissionstabPage.Controls.Add(this.deletePermissionButton);
            this.PermissionstabPage.Controls.Add(this.permissionCheckBox);
            this.PermissionstabPage.Controls.Add(this.endDatePermissionDTP);
            this.PermissionstabPage.Controls.Add(this.startDatePermissionDTP);
            this.PermissionstabPage.Controls.Add(this.validToLabel);
            this.PermissionstabPage.Controls.Add(this.validFromLabel);
            this.PermissionstabPage.Controls.Add(this.permissionsDGV);
            this.PermissionstabPage.Location = new System.Drawing.Point(4, 22);
            this.PermissionstabPage.Name = "PermissionstabPage";
            this.PermissionstabPage.Padding = new System.Windows.Forms.Padding(3);
            this.PermissionstabPage.Size = new System.Drawing.Size(652, 278);
            this.PermissionstabPage.TabIndex = 1;
            this.PermissionstabPage.Text = "Uprawnienia";
            this.PermissionstabPage.UseVisualStyleBackColor = true;
            // 
            // addPermissionButton
            // 
            this.addPermissionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addPermissionButton.Image = ((System.Drawing.Image)(resources.GetObject("addPermissionButton.Image")));
            this.addPermissionButton.Location = new System.Drawing.Point(518, 243);
            this.addPermissionButton.Name = "addPermissionButton";
            this.addPermissionButton.Size = new System.Drawing.Size(126, 23);
            this.addPermissionButton.TabIndex = 16;
            this.addPermissionButton.Text = "Dodaj uprawnienie";
            this.addPermissionButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addPermissionButton.UseVisualStyleBackColor = true;
            this.addPermissionButton.Click += new System.EventHandler(this.addPermissionButton_Click);
            // 
            // deletePermissionButton
            // 
            this.deletePermissionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.deletePermissionButton.Image = ((System.Drawing.Image)(resources.GetObject("deletePermissionButton.Image")));
            this.deletePermissionButton.Location = new System.Drawing.Point(394, 243);
            this.deletePermissionButton.Name = "deletePermissionButton";
            this.deletePermissionButton.Size = new System.Drawing.Size(118, 23);
            this.deletePermissionButton.TabIndex = 15;
            this.deletePermissionButton.Text = "Usuń uprawnienie";
            this.deletePermissionButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deletePermissionButton.UseVisualStyleBackColor = true;
            this.deletePermissionButton.Click += new System.EventHandler(this.deletePermissionButton_Click);
            // 
            // permissionCheckBox
            // 
            this.permissionCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.permissionCheckBox.Location = new System.Drawing.Point(553, 220);
            this.permissionCheckBox.Name = "permissionCheckBox";
            this.permissionCheckBox.Size = new System.Drawing.Size(91, 17);
            this.permissionCheckBox.TabIndex = 14;
            this.permissionCheckBox.Text = "Zablokowane";
            this.permissionCheckBox.UseVisualStyleBackColor = true;
            this.permissionCheckBox.Click += new System.EventHandler(this.permissionCheckBox_Click);
            // 
            // endDatePermissionDTP
            // 
            this.endDatePermissionDTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.endDatePermissionDTP.Location = new System.Drawing.Point(326, 218);
            this.endDatePermissionDTP.Name = "endDatePermissionDTP";
            this.endDatePermissionDTP.Size = new System.Drawing.Size(139, 20);
            this.endDatePermissionDTP.TabIndex = 13;
            this.endDatePermissionDTP.ValueChanged += new System.EventHandler(this.endDatePermissionDTP_ValueChanged);
            // 
            // startDatePermissionDTP
            // 
            this.startDatePermissionDTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startDatePermissionDTP.Location = new System.Drawing.Point(95, 218);
            this.startDatePermissionDTP.Name = "startDatePermissionDTP";
            this.startDatePermissionDTP.Size = new System.Drawing.Size(139, 20);
            this.startDatePermissionDTP.TabIndex = 12;
            this.startDatePermissionDTP.ValueChanged += new System.EventHandler(this.startDatePermissionDTP_ValueChanged);
            // 
            // validToLabel
            // 
            this.validToLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.validToLabel.Location = new System.Drawing.Point(240, 221);
            this.validToLabel.Name = "validToLabel";
            this.validToLabel.Size = new System.Drawing.Size(80, 13);
            this.validToLabel.TabIndex = 11;
            this.validToLabel.Text = "Obowiązuje do:";
            // 
            // validFromLabel
            // 
            this.validFromLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.validFromLabel.Location = new System.Drawing.Point(9, 221);
            this.validFromLabel.Name = "validFromLabel";
            this.validFromLabel.Size = new System.Drawing.Size(80, 13);
            this.validFromLabel.TabIndex = 10;
            this.validFromLabel.Text = "Obowiązuje od:";
            // 
            // permissionsDGV
            // 
            this.permissionsDGV.AllowUserToAddRows = false;
            this.permissionsDGV.AllowUserToDeleteRows = false;
            this.permissionsDGV.AllowUserToResizeRows = false;
            this.permissionsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.permissionsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.permissionsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.syncIdPermissionsDGVC,
            this.namePermissionsDGVC});
            this.permissionsDGV.Location = new System.Drawing.Point(6, 6);
            this.permissionsDGV.MultiSelect = false;
            this.permissionsDGV.Name = "permissionsDGV";
            this.permissionsDGV.ReadOnly = true;
            this.permissionsDGV.RowHeadersVisible = false;
            this.permissionsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.permissionsDGV.Size = new System.Drawing.Size(638, 206);
            this.permissionsDGV.TabIndex = 9;
            this.permissionsDGV.SelectionChanged += new System.EventHandler(this.permissionsDGV_SelectionChanged);
            // 
            // syncIdPermissionsDGVC
            // 
            this.syncIdPermissionsDGVC.HeaderText = "syncID";
            this.syncIdPermissionsDGVC.Name = "syncIdPermissionsDGVC";
            this.syncIdPermissionsDGVC.ReadOnly = true;
            this.syncIdPermissionsDGVC.Visible = false;
            // 
            // namePermissionsDGVC
            // 
            this.namePermissionsDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.namePermissionsDGVC.HeaderText = "Nazwa";
            this.namePermissionsDGVC.Name = "namePermissionsDGVC";
            this.namePermissionsDGVC.ReadOnly = true;
            this.namePermissionsDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // historyTabPage
            // 
            this.historyTabPage.Controls.Add(this.historyDGV);
            this.historyTabPage.Location = new System.Drawing.Point(4, 22);
            this.historyTabPage.Name = "historyTabPage";
            this.historyTabPage.Size = new System.Drawing.Size(652, 278);
            this.historyTabPage.TabIndex = 2;
            this.historyTabPage.Text = "Historia wypożyczeń";
            this.historyTabPage.UseVisualStyleBackColor = true;
            // 
            // historyDGV
            // 
            this.historyDGV.AllowUserToAddRows = false;
            this.historyDGV.AllowUserToDeleteRows = false;
            this.historyDGV.AllowUserToResizeRows = false;
            this.historyDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.historyDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.borrowDateDGVC,
            this.returnDateDGVC,
            this.delayDGVC,
            this.userDGVC,
            this.employeeDGVC,
            this.returnEmployeeDGVC});
            this.historyDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyDGV.Location = new System.Drawing.Point(0, 0);
            this.historyDGV.MultiSelect = false;
            this.historyDGV.Name = "historyDGV";
            this.historyDGV.ReadOnly = true;
            this.historyDGV.RowHeadersVisible = false;
            this.historyDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.historyDGV.Size = new System.Drawing.Size(652, 278);
            this.historyDGV.TabIndex = 0;
            // 
            // borrowDateDGVC
            // 
            this.borrowDateDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.borrowDateDGVC.DataPropertyName = "data_wypoz";
            this.borrowDateDGVC.HeaderText = "Wypożyczenie";
            this.borrowDateDGVC.Name = "borrowDateDGVC";
            this.borrowDateDGVC.ReadOnly = true;
            this.borrowDateDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.borrowDateDGVC.Width = 82;
            // 
            // returnDateDGVC
            // 
            this.returnDateDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.returnDateDGVC.DataPropertyName = "data_zwrot";
            this.returnDateDGVC.HeaderText = "Zwrot";
            this.returnDateDGVC.Name = "returnDateDGVC";
            this.returnDateDGVC.ReadOnly = true;
            this.returnDateDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.returnDateDGVC.Width = 40;
            // 
            // delayDGVC
            // 
            this.delayDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.delayDGVC.DataPropertyName = "opoznienie";
            this.delayDGVC.HeaderText = "Opóźnienie";
            this.delayDGVC.Name = "delayDGVC";
            this.delayDGVC.ReadOnly = true;
            this.delayDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.delayDGVC.Width = 66;
            // 
            // userDGVC
            // 
            this.userDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.userDGVC.DataPropertyName = "uzytkownik";
            this.userDGVC.HeaderText = "Użytkownik";
            this.userDGVC.Name = "userDGVC";
            this.userDGVC.ReadOnly = true;
            this.userDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.userDGVC.Width = 68;
            // 
            // employeeDGVC
            // 
            this.employeeDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.employeeDGVC.DataPropertyName = "pracownik_wypozyczajacy";
            this.employeeDGVC.HeaderText = "Pracownik";
            this.employeeDGVC.Name = "employeeDGVC";
            this.employeeDGVC.ReadOnly = true;
            this.employeeDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // returnEmployeeDGVC
            // 
            this.returnEmployeeDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.returnEmployeeDGVC.DataPropertyName = "pracownik_zwracajacy";
            this.returnEmployeeDGVC.HeaderText = "Pracownik zwracający";
            this.returnEmployeeDGVC.Name = "returnEmployeeDGVC";
            this.returnEmployeeDGVC.ReadOnly = true;
            this.returnEmployeeDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.returnEmployeeDGVC.Width = 107;
            // 
            // orderHistoryTabPage
            // 
            this.orderHistoryTabPage.Controls.Add(this.orderHistoryDGVC);
            this.orderHistoryTabPage.Location = new System.Drawing.Point(4, 22);
            this.orderHistoryTabPage.Name = "orderHistoryTabPage";
            this.orderHistoryTabPage.Size = new System.Drawing.Size(652, 278);
            this.orderHistoryTabPage.TabIndex = 3;
            this.orderHistoryTabPage.Text = "Historia zamówień";
            this.orderHistoryTabPage.UseVisualStyleBackColor = true;
            // 
            // orderHistoryDGVC
            // 
            this.orderHistoryDGVC.AllowUserToAddRows = false;
            this.orderHistoryDGVC.AllowUserToDeleteRows = false;
            this.orderHistoryDGVC.AllowUserToResizeRows = false;
            this.orderHistoryDGVC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.orderHistoryDGVC.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderDateDGVC,
            this.dataGridViewTextBoxColumn2,
            this.stateDGVC,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.orderHistoryDGVC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderHistoryDGVC.Location = new System.Drawing.Point(0, 0);
            this.orderHistoryDGVC.MultiSelect = false;
            this.orderHistoryDGVC.Name = "orderHistoryDGVC";
            this.orderHistoryDGVC.ReadOnly = true;
            this.orderHistoryDGVC.RowHeadersVisible = false;
            this.orderHistoryDGVC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.orderHistoryDGVC.Size = new System.Drawing.Size(652, 278);
            this.orderHistoryDGVC.TabIndex = 1;
            // 
            // orderDateDGVC
            // 
            this.orderDateDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.orderDateDGVC.DataPropertyName = "data_zamow";
            this.orderDateDGVC.HeaderText = "Zamówienie";
            this.orderDateDGVC.Name = "orderDateDGVC";
            this.orderDateDGVC.ReadOnly = true;
            this.orderDateDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.orderDateDGVC.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "data_realiz";
            this.dataGridViewTextBoxColumn2.HeaderText = "Realizacja";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 62;
            // 
            // stateDGVC
            // 
            this.stateDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.stateDGVC.DataPropertyName = "stan";
            this.stateDGVC.HeaderText = "Stan zamówienia";
            this.stateDGVC.Name = "stateDGVC";
            this.stateDGVC.ReadOnly = true;
            this.stateDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.stateDGVC.Width = 93;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "uzytkownik";
            this.dataGridViewTextBoxColumn4.HeaderText = "Użytkownik";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 68;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "pracownik";
            this.dataGridViewTextBoxColumn5.HeaderText = "Pracownik";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // EscapeButton
            // 
            this.EscapeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EscapeButton.Image = ((System.Drawing.Image)(resources.GetObject("EscapeButton.Image")));
            this.EscapeButton.Location = new System.Drawing.Point(597, 326);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(75, 23);
            this.EscapeButton.TabIndex = 2;
            this.EscapeButton.Text = "Wyjście";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SaveButton.Image = ((System.Drawing.Image)(resources.GetObject("SaveButton.Image")));
            this.SaveButton.Location = new System.Drawing.Point(12, 326);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Zapisz";
            this.SaveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ResourceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 366);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(700, 400);
            this.Name = "ResourceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dane zasobu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ResourceForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ResourceForm_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.PermissionstabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.permissionsDGV)).EndInit();
            this.historyTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.historyDGV)).EndInit();
            this.orderHistoryTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.orderHistoryDGVC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TabPage PermissionstabPage;
        private System.Windows.Forms.RichTextBox TitleRTB;
        private System.Windows.Forms.TabPage historyTabPage;
        private System.Windows.Forms.TabPage orderHistoryTabPage;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.TextBox noIvnTextBox;
        private System.Windows.Forms.TextBox barcodeTextBox;
        private System.Windows.Forms.Label timeLimitLabel;
        private System.Windows.Forms.Label groupIdLabel;
        private System.Windows.Forms.Label invertoryNumberLabel;
        private System.Windows.Forms.Label barcodeLabel;
        private System.Windows.Forms.CheckBox isBorrowedCheckBox;
        private System.Windows.Forms.TextBox groupTextBox;
        private System.Windows.Forms.TextBox timeTextBox;
        private System.Windows.Forms.Label daysLabel;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.RichTextBox CommentsRTB;
        private System.Windows.Forms.Button addPermissionButton;
        private System.Windows.Forms.Button deletePermissionButton;
        private System.Windows.Forms.CheckBox permissionCheckBox;
        private System.Windows.Forms.DateTimePicker endDatePermissionDTP;
        private System.Windows.Forms.DateTimePicker startDatePermissionDTP;
        private System.Windows.Forms.Label validToLabel;
        private System.Windows.Forms.Label validFromLabel;
        private System.Windows.Forms.DataGridView permissionsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn syncIdPermissionsDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn namePermissionsDGVC;
        private System.Windows.Forms.DataGridView historyDGV;
        private System.Windows.Forms.DataGridView orderHistoryDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn borrowDateDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnDateDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn delayDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn returnEmployeeDGVC;
    }
}