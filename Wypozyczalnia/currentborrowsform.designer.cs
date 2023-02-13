namespace Wypozyczalnia
{
    partial class CurrentBorrowsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrentBorrowsForm));
            this.borrowsDGV = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.zwrotZasobuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.informacjeOUżytkownikuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.drukujUpomnienieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitButton = new System.Windows.Forms.Button();
            this.typesComboBox = new System.Windows.Forms.ComboBox();
            this.toLabel = new System.Windows.Forms.Label();
            this.fromLabel = new System.Windows.Forms.Label();
            this.endDateSearchDTP = new System.Windows.Forms.DateTimePicker();
            this.dateSearchCheckBox = new System.Windows.Forms.CheckBox();
            this.TitleSearchTextBox = new System.Windows.Forms.TextBox();
            this.startDateSearchDTP = new System.Windows.Forms.DateTimePicker();
            this.noInvSearchTextBox = new System.Windows.Forms.TextBox();
            this.invertoryNumberLabel = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.sigSearchTextBox = new System.Windows.Forms.TextBox();
            this.signatureLabel = new System.Windows.Forms.Label();
            this.authorSearchTextBox = new System.Windows.Forms.TextBox();
            this.authorLabel = new System.Windows.Forms.Label();
            this.userNameSearchTextBox = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.CleanSearchButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.selectUserButton = new System.Windows.Forms.Button();
            this.onlyExpiredCheckBox = new System.Windows.Forms.CheckBox();
            this.wypozIdDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.authorDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcodeDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noInvDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sigDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resourceKindDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userIdDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataWypDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataPrzewDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expiredDGVC = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.borrowsDGV)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // borrowsDGV
            // 
            this.borrowsDGV.AllowUserToAddRows = false;
            this.borrowsDGV.AllowUserToDeleteRows = false;
            this.borrowsDGV.AllowUserToResizeRows = false;
            this.borrowsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.borrowsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.borrowsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.wypozIdDGVC,
            this.descriptionDGVC,
            this.authorDGVC,
            this.barcodeDGVC,
            this.noInvDGVC,
            this.sigDGVC,
            this.resourceKindDGVC,
            this.userIdDGVC,
            this.userNameDGVC,
            this.dataWypDGVC,
            this.dataPrzewDGVC,
            this.expiredDGVC});
            this.borrowsDGV.ContextMenuStrip = this.contextMenuStrip1;
            this.borrowsDGV.Location = new System.Drawing.Point(12, 39);
            this.borrowsDGV.MultiSelect = false;
            this.borrowsDGV.Name = "borrowsDGV";
            this.borrowsDGV.ReadOnly = true;
            this.borrowsDGV.RowHeadersVisible = false;
            this.borrowsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.borrowsDGV.Size = new System.Drawing.Size(960, 434);
            this.borrowsDGV.StandardTab = true;
            this.borrowsDGV.TabIndex = 1;
            this.borrowsDGV.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.borrowsDGV_CellMouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zwrotZasobuToolStripMenuItem,
            this.toolStripMenuItem1,
            this.informacjeOUżytkownikuToolStripMenuItem,
            this.drukujUpomnienieToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 76);
            // 
            // zwrotZasobuToolStripMenuItem
            // 
            this.zwrotZasobuToolStripMenuItem.Name = "zwrotZasobuToolStripMenuItem";
            this.zwrotZasobuToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.zwrotZasobuToolStripMenuItem.Text = "Zwrot zasobu";
            this.zwrotZasobuToolStripMenuItem.Click += new System.EventHandler(this.zwrotZasobuToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(208, 6);
            // 
            // informacjeOUżytkownikuToolStripMenuItem
            // 
            this.informacjeOUżytkownikuToolStripMenuItem.Name = "informacjeOUżytkownikuToolStripMenuItem";
            this.informacjeOUżytkownikuToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.informacjeOUżytkownikuToolStripMenuItem.Text = "Informacje o użytkowniku";
            this.informacjeOUżytkownikuToolStripMenuItem.Click += new System.EventHandler(this.informacjeOUżytkownikuToolStripMenuItem_Click);
            // 
            // drukujUpomnienieToolStripMenuItem
            // 
            this.drukujUpomnienieToolStripMenuItem.Name = "drukujUpomnienieToolStripMenuItem";
            this.drukujUpomnienieToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            this.drukujUpomnienieToolStripMenuItem.Text = "Drukuj upomnienie";
            this.drukujUpomnienieToolStripMenuItem.Click += new System.EventHandler(this.drukujUpomnienieToolStripMenuItem_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.Location = new System.Drawing.Point(897, 576);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 14;
            this.exitButton.Text = "Wyjście";
            this.exitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // typesComboBox
            // 
            this.typesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.typesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typesComboBox.FormattingEnabled = true;
            this.typesComboBox.Location = new System.Drawing.Point(791, 12);
            this.typesComboBox.Name = "typesComboBox";
            this.typesComboBox.Size = new System.Drawing.Size(181, 21);
            this.typesComboBox.TabIndex = 0;
            this.typesComboBox.SelectionChangeCommitted += new System.EventHandler(this.typesComboBox_SelectionChangeCommitted);
            // 
            // toLabel
            // 
            this.toLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.toLabel.Location = new System.Drawing.Point(349, 583);
            this.toLabel.Name = "toLabel";
            this.toLabel.Size = new System.Drawing.Size(131, 13);
            this.toLabel.TabIndex = 53;
            this.toLabel.Text = "Do:";
            this.toLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // fromLabel
            // 
            this.fromLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.fromLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.fromLabel.Location = new System.Drawing.Point(349, 557);
            this.fromLabel.Name = "fromLabel";
            this.fromLabel.Size = new System.Drawing.Size(131, 13);
            this.fromLabel.TabIndex = 52;
            this.fromLabel.Text = "Od:";
            this.fromLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // endDateSearchDTP
            // 
            this.endDateSearchDTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.endDateSearchDTP.Enabled = false;
            this.endDateSearchDTP.Location = new System.Drawing.Point(486, 579);
            this.endDateSearchDTP.Name = "endDateSearchDTP";
            this.endDateSearchDTP.Size = new System.Drawing.Size(207, 20);
            this.endDateSearchDTP.TabIndex = 11;
            // 
            // dateSearchCheckBox
            // 
            this.dateSearchCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dateSearchCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateSearchCheckBox.Location = new System.Drawing.Point(375, 530);
            this.dateSearchCheckBox.Name = "dateSearchCheckBox";
            this.dateSearchCheckBox.Size = new System.Drawing.Size(121, 17);
            this.dateSearchCheckBox.TabIndex = 9;
            this.dateSearchCheckBox.TabStop = false;
            this.dateSearchCheckBox.Text = "Data wypożyczenia:";
            this.dateSearchCheckBox.UseVisualStyleBackColor = true;
            this.dateSearchCheckBox.CheckedChanged += new System.EventHandler(this.SearchCheckBox_CheckedChanged);
            // 
            // TitleSearchTextBox
            // 
            this.TitleSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.TitleSearchTextBox.Location = new System.Drawing.Point(136, 502);
            this.TitleSearchTextBox.Name = "TitleSearchTextBox";
            this.TitleSearchTextBox.Size = new System.Drawing.Size(207, 20);
            this.TitleSearchTextBox.TabIndex = 3;
            // 
            // startDateSearchDTP
            // 
            this.startDateSearchDTP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.startDateSearchDTP.Enabled = false;
            this.startDateSearchDTP.Location = new System.Drawing.Point(486, 553);
            this.startDateSearchDTP.Name = "startDateSearchDTP";
            this.startDateSearchDTP.Size = new System.Drawing.Size(207, 20);
            this.startDateSearchDTP.TabIndex = 10;
            this.startDateSearchDTP.ValueChanged += new System.EventHandler(this.startDateSearchDTP_ValueChanged);
            // 
            // noInvSearchTextBox
            // 
            this.noInvSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.noInvSearchTextBox.Location = new System.Drawing.Point(136, 583);
            this.noInvSearchTextBox.MaxLength = 20;
            this.noInvSearchTextBox.Name = "noInvSearchTextBox";
            this.noInvSearchTextBox.Size = new System.Drawing.Size(207, 20);
            this.noInvSearchTextBox.TabIndex = 6;
            // 
            // invertoryNumberLabel
            // 
            this.invertoryNumberLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.invertoryNumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.invertoryNumberLabel.Location = new System.Drawing.Point(22, 586);
            this.invertoryNumberLabel.Name = "invertoryNumberLabel";
            this.invertoryNumberLabel.Size = new System.Drawing.Size(108, 13);
            this.invertoryNumberLabel.TabIndex = 50;
            this.invertoryNumberLabel.Text = "Numer inwentarzowy:";
            this.invertoryNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // titleLabel
            // 
            this.titleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.titleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.titleLabel.Location = new System.Drawing.Point(25, 505);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(105, 13);
            this.titleLabel.TabIndex = 49;
            this.titleLabel.Text = "Tytuł:";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // sigSearchTextBox
            // 
            this.sigSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sigSearchTextBox.Location = new System.Drawing.Point(136, 554);
            this.sigSearchTextBox.Name = "sigSearchTextBox";
            this.sigSearchTextBox.Size = new System.Drawing.Size(207, 20);
            this.sigSearchTextBox.TabIndex = 5;
            // 
            // signatureLabel
            // 
            this.signatureLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.signatureLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.signatureLabel.Location = new System.Drawing.Point(25, 557);
            this.signatureLabel.Name = "signatureLabel";
            this.signatureLabel.Size = new System.Drawing.Size(105, 13);
            this.signatureLabel.TabIndex = 48;
            this.signatureLabel.Text = "Sygnatura:";
            this.signatureLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // authorSearchTextBox
            // 
            this.authorSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.authorSearchTextBox.Location = new System.Drawing.Point(136, 528);
            this.authorSearchTextBox.Name = "authorSearchTextBox";
            this.authorSearchTextBox.Size = new System.Drawing.Size(207, 20);
            this.authorSearchTextBox.TabIndex = 4;
            // 
            // authorLabel
            // 
            this.authorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.authorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.authorLabel.Location = new System.Drawing.Point(25, 531);
            this.authorLabel.Name = "authorLabel";
            this.authorLabel.Size = new System.Drawing.Size(105, 13);
            this.authorLabel.TabIndex = 55;
            this.authorLabel.Text = "Autor:";
            this.authorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // userNameSearchTextBox
            // 
            this.userNameSearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userNameSearchTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.userNameSearchTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.userNameSearchTextBox.Location = new System.Drawing.Point(486, 502);
            this.userNameSearchTextBox.Name = "userNameSearchTextBox";
            this.userNameSearchTextBox.Size = new System.Drawing.Size(207, 20);
            this.userNameSearchTextBox.TabIndex = 7;
            // 
            // userLabel
            // 
            this.userLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.userLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userLabel.Location = new System.Drawing.Point(361, 505);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(119, 13);
            this.userLabel.TabIndex = 57;
            this.userLabel.Text = "Użytkownik:";
            this.userLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CleanSearchButton
            // 
            this.CleanSearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CleanSearchButton.Image = ((System.Drawing.Image)(resources.GetObject("CleanSearchButton.Image")));
            this.CleanSearchButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.CleanSearchButton.Location = new System.Drawing.Point(717, 580);
            this.CleanSearchButton.Name = "CleanSearchButton";
            this.CleanSearchButton.Size = new System.Drawing.Size(85, 23);
            this.CleanSearchButton.TabIndex = 13;
            this.CleanSearchButton.TabStop = false;
            this.CleanSearchButton.Text = "Wyczyść";
            this.CleanSearchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CleanSearchButton.UseVisualStyleBackColor = true;
            this.CleanSearchButton.Click += new System.EventHandler(this.CleanSearchButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SearchButton.Image = ((System.Drawing.Image)(resources.GetObject("SearchButton.Image")));
            this.SearchButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.SearchButton.Location = new System.Drawing.Point(717, 551);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(85, 23);
            this.SearchButton.TabIndex = 12;
            this.SearchButton.TabStop = false;
            this.SearchButton.Text = "Filtruj";
            this.SearchButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // selectUserButton
            // 
            this.selectUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectUserButton.Image = ((System.Drawing.Image)(resources.GetObject("selectUserButton.Image")));
            this.selectUserButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.selectUserButton.Location = new System.Drawing.Point(699, 500);
            this.selectUserButton.Name = "selectUserButton";
            this.selectUserButton.Size = new System.Drawing.Size(27, 23);
            this.selectUserButton.TabIndex = 8;
            this.selectUserButton.TabStop = false;
            this.selectUserButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectUserButton.UseVisualStyleBackColor = true;
            this.selectUserButton.Click += new System.EventHandler(this.selectUserButton_Click);
            // 
            // onlyExpiredCheckBox
            // 
            this.onlyExpiredCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.onlyExpiredCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.onlyExpiredCheckBox.Location = new System.Drawing.Point(34, 479);
            this.onlyExpiredCheckBox.Name = "onlyExpiredCheckBox";
            this.onlyExpiredCheckBox.Size = new System.Drawing.Size(135, 17);
            this.onlyExpiredCheckBox.TabIndex = 2;
            this.onlyExpiredCheckBox.TabStop = false;
            this.onlyExpiredCheckBox.Text = "Tylko przeterminowane";
            this.onlyExpiredCheckBox.UseVisualStyleBackColor = true;
            this.onlyExpiredCheckBox.CheckedChanged += new System.EventHandler(this.onlyExpiredCheckBox_CheckedChanged);
            // 
            // wypozIdDGVC
            // 
            this.wypozIdDGVC.DataPropertyName = "wypoz_id";
            this.wypozIdDGVC.FillWeight = 200F;
            this.wypozIdDGVC.HeaderText = "wypozId";
            this.wypozIdDGVC.Name = "wypozIdDGVC";
            this.wypozIdDGVC.ReadOnly = true;
            this.wypozIdDGVC.Visible = false;
            this.wypozIdDGVC.Width = 200;
            // 
            // descriptionDGVC
            // 
            this.descriptionDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDGVC.DataPropertyName = "opis";
            this.descriptionDGVC.HeaderText = "Opis";
            this.descriptionDGVC.Name = "descriptionDGVC";
            this.descriptionDGVC.ReadOnly = true;
            // 
            // authorDGVC
            // 
            this.authorDGVC.DataPropertyName = "autor";
            this.authorDGVC.HeaderText = "Autor";
            this.authorDGVC.Name = "authorDGVC";
            this.authorDGVC.ReadOnly = true;
            // 
            // barcodeDGVC
            // 
            this.barcodeDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.barcodeDGVC.DataPropertyName = "k_kreskowy";
            this.barcodeDGVC.HeaderText = "Kod kreskowy";
            this.barcodeDGVC.Name = "barcodeDGVC";
            this.barcodeDGVC.ReadOnly = true;
            this.barcodeDGVC.Width = 99;
            // 
            // noInvDGVC
            // 
            this.noInvDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.noInvDGVC.DataPropertyName = "numer_inw";
            this.noInvDGVC.HeaderText = "Numer inwentarzowy";
            this.noInvDGVC.Name = "noInvDGVC";
            this.noInvDGVC.ReadOnly = true;
            this.noInvDGVC.Width = 119;
            // 
            // sigDGVC
            // 
            this.sigDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.sigDGVC.DataPropertyName = "syg";
            this.sigDGVC.HeaderText = "Sygnatura";
            this.sigDGVC.Name = "sigDGVC";
            this.sigDGVC.ReadOnly = true;
            this.sigDGVC.Width = 80;
            // 
            // resourceKindDGVC
            // 
            this.resourceKindDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.resourceKindDGVC.DataPropertyName = "rodzaj";
            this.resourceKindDGVC.HeaderText = "Rodzaj";
            this.resourceKindDGVC.Name = "resourceKindDGVC";
            this.resourceKindDGVC.ReadOnly = true;
            this.resourceKindDGVC.Width = 20;
            // 
            // userIdDGVC
            // 
            this.userIdDGVC.DataPropertyName = "uzytk_id";
            this.userIdDGVC.HeaderText = "userID";
            this.userIdDGVC.Name = "userIdDGVC";
            this.userIdDGVC.ReadOnly = true;
            this.userIdDGVC.Visible = false;
            // 
            // userNameDGVC
            // 
            this.userNameDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.userNameDGVC.DataPropertyName = "uzytkownik";
            this.userNameDGVC.HeaderText = "Użytkownik";
            this.userNameDGVC.Name = "userNameDGVC";
            this.userNameDGVC.ReadOnly = true;
            this.userNameDGVC.Width = 150;
            // 
            // dataWypDGVC
            // 
            this.dataWypDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataWypDGVC.DataPropertyName = "data_wypoz";
            this.dataWypDGVC.HeaderText = "Data wypożyczenia";
            this.dataWypDGVC.Name = "dataWypDGVC";
            this.dataWypDGVC.ReadOnly = true;
            this.dataWypDGVC.Width = 80;
            // 
            // dataPrzewDGVC
            // 
            this.dataPrzewDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataPrzewDGVC.DataPropertyName = "data_przewidywana";
            this.dataPrzewDGVC.HeaderText = "Przewidywana data zwrotu";
            this.dataPrzewDGVC.Name = "dataPrzewDGVC";
            this.dataPrzewDGVC.ReadOnly = true;
            this.dataPrzewDGVC.Width = 80;
            // 
            // expiredDGVC
            // 
            this.expiredDGVC.HeaderText = "expired";
            this.expiredDGVC.Name = "expiredDGVC";
            this.expiredDGVC.ReadOnly = true;
            this.expiredDGVC.Visible = false;
            // 
            // CurrentBorrowsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 611);
            this.Controls.Add(this.onlyExpiredCheckBox);
            this.Controls.Add(this.selectUserButton);
            this.Controls.Add(this.CleanSearchButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.userNameSearchTextBox);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.authorSearchTextBox);
            this.Controls.Add(this.authorLabel);
            this.Controls.Add(this.toLabel);
            this.Controls.Add(this.fromLabel);
            this.Controls.Add(this.endDateSearchDTP);
            this.Controls.Add(this.dateSearchCheckBox);
            this.Controls.Add(this.TitleSearchTextBox);
            this.Controls.Add(this.startDateSearchDTP);
            this.Controls.Add(this.noInvSearchTextBox);
            this.Controls.Add(this.invertoryNumberLabel);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.sigSearchTextBox);
            this.Controls.Add(this.signatureLabel);
            this.Controls.Add(this.typesComboBox);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.borrowsDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1000, 450);
            this.Name = "CurrentBorrowsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pozycje wypożyczone";
            this.Activated += new System.EventHandler(this.CurrentBorrowsForm_Activated);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CurrentBorrowsForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.borrowsDGV)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView borrowsDGV;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.ComboBox typesComboBox;
        private System.Windows.Forms.Label toLabel;
        private System.Windows.Forms.Label fromLabel;
        private System.Windows.Forms.DateTimePicker endDateSearchDTP;
        private System.Windows.Forms.CheckBox dateSearchCheckBox;
        private System.Windows.Forms.TextBox TitleSearchTextBox;
        private System.Windows.Forms.DateTimePicker startDateSearchDTP;
        private System.Windows.Forms.TextBox noInvSearchTextBox;
        private System.Windows.Forms.Label invertoryNumberLabel;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox sigSearchTextBox;
        private System.Windows.Forms.Label signatureLabel;
        private System.Windows.Forms.TextBox authorSearchTextBox;
        private System.Windows.Forms.Label authorLabel;
        private System.Windows.Forms.TextBox userNameSearchTextBox;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button CleanSearchButton;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button selectUserButton;
        private System.Windows.Forms.CheckBox onlyExpiredCheckBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zwrotZasobuToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem informacjeOUżytkownikuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drukujUpomnienieToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn wypozIdDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn barcodeDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn noInvDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn sigDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn resourceKindDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIdDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataWypDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataPrzewDGVC;
        private System.Windows.Forms.DataGridViewCheckBoxColumn expiredDGVC;
    }
}