namespace Ksiazki
{
    partial class ChooseServerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseServerForm));
            this.ImportTabControl = new System.Windows.Forms.TabControl();
            this.ImportTabPage = new System.Windows.Forms.TabPage();
            this.MainGroupBox = new System.Windows.Forms.GroupBox();
            this.HeadLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SetDefaultButton = new System.Windows.Forms.Button();
            this.ServersComboBox = new System.Windows.Forms.ComboBox();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.SubLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.SearchingGroupBox = new System.Windows.Forms.GroupBox();
            this.ChooseSortLabel = new System.Windows.Forms.Label();
            this.YearRadioButton = new System.Windows.Forms.RadioButton();
            this.PublisherRadioButton = new System.Windows.Forms.RadioButton();
            this.AuthorRadioButton = new System.Windows.Forms.RadioButton();
            this.TitleRadioButton = new System.Windows.Forms.RadioButton();
            this.ISBNRadioButton = new System.Windows.Forms.RadioButton();
            this.FoldButton = new System.Windows.Forms.Button();
            this.SearchButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.PublisherTextBox = new System.Windows.Forms.TextBox();
            this.ISBNTextBox = new System.Windows.Forms.TextBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.YearLabel = new System.Windows.Forms.Label();
            this.PublisherLabel = new System.Windows.Forms.Label();
            this.ISBNLabel = new System.Windows.Forms.Label();
            this.TitleLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.ResultsGroupBox = new System.Windows.Forms.GroupBox();
            this.ResultsDGV = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ImportButton = new System.Windows.Forms.Button();
            this.EditMARCButton = new System.Windows.Forms.Button();
            this.PreviewButton = new System.Windows.Forms.Button();
            this.NumberOfDescriptonsLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.ServersTabPage = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.ServersDGV = new System.Windows.Forms.DataGridView();
            this.OrdinalS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServerID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.DeleteServerButton = new System.Windows.Forms.Button();
            this.EditServerButton = new System.Windows.Forms.Button();
            this.AddServerButton = new System.Windows.Forms.Button();
            this.MainLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ordinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AutorCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tytuł = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wydawca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rok = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wydanie = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportTabControl.SuspendLayout();
            this.ImportTabPage.SuspendLayout();
            this.MainGroupBox.SuspendLayout();
            this.HeadLayoutPanel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SubLayoutPanel.SuspendLayout();
            this.SearchingGroupBox.SuspendLayout();
            this.ResultsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDGV)).BeginInit();
            this.panel1.SuspendLayout();
            this.ServersTabPage.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServersDGV)).BeginInit();
            this.ButtonsPanel.SuspendLayout();
            this.MainLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImportTabControl
            // 
            this.ImportTabControl.Controls.Add(this.ImportTabPage);
            this.ImportTabControl.Controls.Add(this.ServersTabPage);
            this.ImportTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImportTabControl.Location = new System.Drawing.Point(3, 3);
            this.ImportTabControl.Name = "ImportTabControl";
            this.ImportTabControl.SelectedIndex = 0;
            this.ImportTabControl.Size = new System.Drawing.Size(738, 507);
            this.ImportTabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.ImportTabControl.TabIndex = 0;
            this.ImportTabControl.SelectedIndexChanged += new System.EventHandler(this.ImportTabControl_SelectedIndexChanged);
            // 
            // ImportTabPage
            // 
            this.ImportTabPage.Controls.Add(this.MainGroupBox);
            this.ImportTabPage.Location = new System.Drawing.Point(4, 22);
            this.ImportTabPage.Name = "ImportTabPage";
            this.ImportTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ImportTabPage.Size = new System.Drawing.Size(730, 481);
            this.ImportTabPage.TabIndex = 0;
            this.ImportTabPage.Text = "IMPORT";
            this.ImportTabPage.UseVisualStyleBackColor = true;
            // 
            // MainGroupBox
            // 
            this.MainGroupBox.Controls.Add(this.HeadLayoutPanel);
            this.MainGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainGroupBox.Location = new System.Drawing.Point(3, 3);
            this.MainGroupBox.Name = "MainGroupBox";
            this.MainGroupBox.Size = new System.Drawing.Size(724, 475);
            this.MainGroupBox.TabIndex = 0;
            this.MainGroupBox.TabStop = false;
            this.MainGroupBox.Text = "Import opisu MARC via Z39.50";
            // 
            // HeadLayoutPanel
            // 
            this.HeadLayoutPanel.ColumnCount = 1;
            this.HeadLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.HeadLayoutPanel.Controls.Add(this.panel2, 0, 0);
            this.HeadLayoutPanel.Controls.Add(this.SubLayoutPanel, 0, 1);
            this.HeadLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HeadLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.HeadLayoutPanel.Name = "HeadLayoutPanel";
            this.HeadLayoutPanel.RowCount = 2;
            this.HeadLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.HeadLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.HeadLayoutPanel.Size = new System.Drawing.Size(718, 456);
            this.HeadLayoutPanel.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SetDefaultButton);
            this.panel2.Controls.Add(this.ServersComboBox);
            this.panel2.Controls.Add(this.ServerLabel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(712, 44);
            this.panel2.TabIndex = 2;
            // 
            // SetDefaultButton
            // 
            this.SetDefaultButton.Location = new System.Drawing.Point(455, 7);
            this.SetDefaultButton.Name = "SetDefaultButton";
            this.SetDefaultButton.Size = new System.Drawing.Size(122, 29);
            this.SetDefaultButton.TabIndex = 1;
            this.SetDefaultButton.Text = "Ustaw jako domyślny";
            this.SetDefaultButton.UseVisualStyleBackColor = true;
            this.SetDefaultButton.Click += new System.EventHandler(this.SetDefaultButton_Click);
            // 
            // ServersComboBox
            // 
            this.ServersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ServersComboBox.FormattingEnabled = true;
            this.ServersComboBox.Location = new System.Drawing.Point(68, 13);
            this.ServersComboBox.Name = "ServersComboBox";
            this.ServersComboBox.Size = new System.Drawing.Size(367, 21);
            this.ServersComboBox.TabIndex = 0;
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ServerLabel.Location = new System.Drawing.Point(16, 17);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(46, 13);
            this.ServerLabel.TabIndex = 0;
            this.ServerLabel.Text = "Serwer: ";
            // 
            // SubLayoutPanel
            // 
            this.SubLayoutPanel.ColumnCount = 1;
            this.SubLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SubLayoutPanel.Controls.Add(this.SearchingGroupBox, 0, 0);
            this.SubLayoutPanel.Controls.Add(this.ResultsGroupBox, 0, 2);
            this.SubLayoutPanel.Controls.Add(this.panel1, 0, 1);
            this.SubLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubLayoutPanel.Location = new System.Drawing.Point(3, 53);
            this.SubLayoutPanel.Name = "SubLayoutPanel";
            this.SubLayoutPanel.RowCount = 3;
            this.SubLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 189F));
            this.SubLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 36F));
            this.SubLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.SubLayoutPanel.Size = new System.Drawing.Size(712, 400);
            this.SubLayoutPanel.TabIndex = 0;
            // 
            // SearchingGroupBox
            // 
            this.SearchingGroupBox.Controls.Add(this.ChooseSortLabel);
            this.SearchingGroupBox.Controls.Add(this.YearRadioButton);
            this.SearchingGroupBox.Controls.Add(this.PublisherRadioButton);
            this.SearchingGroupBox.Controls.Add(this.AuthorRadioButton);
            this.SearchingGroupBox.Controls.Add(this.TitleRadioButton);
            this.SearchingGroupBox.Controls.Add(this.ISBNRadioButton);
            this.SearchingGroupBox.Controls.Add(this.FoldButton);
            this.SearchingGroupBox.Controls.Add(this.SearchButton);
            this.SearchingGroupBox.Controls.Add(this.ClearButton);
            this.SearchingGroupBox.Controls.Add(this.YearTextBox);
            this.SearchingGroupBox.Controls.Add(this.PublisherTextBox);
            this.SearchingGroupBox.Controls.Add(this.ISBNTextBox);
            this.SearchingGroupBox.Controls.Add(this.TitleTextBox);
            this.SearchingGroupBox.Controls.Add(this.AuthorTextBox);
            this.SearchingGroupBox.Controls.Add(this.YearLabel);
            this.SearchingGroupBox.Controls.Add(this.PublisherLabel);
            this.SearchingGroupBox.Controls.Add(this.ISBNLabel);
            this.SearchingGroupBox.Controls.Add(this.TitleLabel);
            this.SearchingGroupBox.Controls.Add(this.AuthorLabel);
            this.SearchingGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchingGroupBox.Location = new System.Drawing.Point(3, 3);
            this.SearchingGroupBox.Name = "SearchingGroupBox";
            this.SearchingGroupBox.Size = new System.Drawing.Size(706, 183);
            this.SearchingGroupBox.TabIndex = 0;
            this.SearchingGroupBox.TabStop = false;
            // 
            // ChooseSortLabel
            // 
            this.ChooseSortLabel.AutoSize = true;
            this.ChooseSortLabel.Location = new System.Drawing.Point(437, 8);
            this.ChooseSortLabel.Name = "ChooseSortLabel";
            this.ChooseSortLabel.Size = new System.Drawing.Size(51, 13);
            this.ChooseSortLabel.TabIndex = 24;
            this.ChooseSortLabel.Text = "Sortuj wg";
            // 
            // YearRadioButton
            // 
            this.YearRadioButton.AutoSize = true;
            this.YearRadioButton.Location = new System.Drawing.Point(452, 130);
            this.YearRadioButton.Name = "YearRadioButton";
            this.YearRadioButton.Size = new System.Drawing.Size(14, 13);
            this.YearRadioButton.TabIndex = 23;
            this.YearRadioButton.TabStop = true;
            this.YearRadioButton.UseVisualStyleBackColor = true;
            // 
            // PublisherRadioButton
            // 
            this.PublisherRadioButton.AutoSize = true;
            this.PublisherRadioButton.Location = new System.Drawing.Point(452, 103);
            this.PublisherRadioButton.Name = "PublisherRadioButton";
            this.PublisherRadioButton.Size = new System.Drawing.Size(14, 13);
            this.PublisherRadioButton.TabIndex = 22;
            this.PublisherRadioButton.TabStop = true;
            this.PublisherRadioButton.UseVisualStyleBackColor = true;
            // 
            // AuthorRadioButton
            // 
            this.AuthorRadioButton.AutoSize = true;
            this.AuthorRadioButton.Location = new System.Drawing.Point(452, 77);
            this.AuthorRadioButton.Name = "AuthorRadioButton";
            this.AuthorRadioButton.Size = new System.Drawing.Size(14, 13);
            this.AuthorRadioButton.TabIndex = 21;
            this.AuthorRadioButton.TabStop = true;
            this.AuthorRadioButton.UseVisualStyleBackColor = true;
            // 
            // TitleRadioButton
            // 
            this.TitleRadioButton.AutoSize = true;
            this.TitleRadioButton.Checked = true;
            this.TitleRadioButton.Location = new System.Drawing.Point(452, 49);
            this.TitleRadioButton.Name = "TitleRadioButton";
            this.TitleRadioButton.Size = new System.Drawing.Size(14, 13);
            this.TitleRadioButton.TabIndex = 20;
            this.TitleRadioButton.TabStop = true;
            this.TitleRadioButton.UseVisualStyleBackColor = true;
            // 
            // ISBNRadioButton
            // 
            this.ISBNRadioButton.AutoSize = true;
            this.ISBNRadioButton.Location = new System.Drawing.Point(452, 23);
            this.ISBNRadioButton.Name = "ISBNRadioButton";
            this.ISBNRadioButton.Size = new System.Drawing.Size(14, 13);
            this.ISBNRadioButton.TabIndex = 19;
            this.ISBNRadioButton.TabStop = true;
            this.ISBNRadioButton.UseVisualStyleBackColor = true;
            // 
            // FoldButton
            // 
            this.FoldButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FoldButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FoldButton.Image = global::Ksiazki.Properties.Resources.wgore;
            this.FoldButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FoldButton.Location = new System.Drawing.Point(619, 11);
            this.FoldButton.Name = "FoldButton";
            this.FoldButton.Size = new System.Drawing.Size(79, 29);
            this.FoldButton.TabIndex = 18;
            this.FoldButton.Text = "Zwiń";
            this.FoldButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.FoldButton.UseVisualStyleBackColor = true;
            this.FoldButton.Click += new System.EventHandler(this.FoldButton_Click);
            // 
            // SearchButton
            // 
            this.SearchButton.Image = global::Ksiazki.Properties.Resources.lupka;
            this.SearchButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SearchButton.Location = new System.Drawing.Point(353, 150);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(79, 29);
            this.SearchButton.TabIndex = 6;
            this.SearchButton.Text = "SZUKAJ";
            this.SearchButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearButton.Image")));
            this.ClearButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ClearButton.Location = new System.Drawing.Point(268, 150);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(79, 29);
            this.ClearButton.TabIndex = 5;
            this.ClearButton.Text = "Wyczyść";
            this.ClearButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // YearTextBox
            // 
            this.YearTextBox.Location = new System.Drawing.Point(64, 126);
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(368, 20);
            this.YearTextBox.TabIndex = 4;
            this.YearTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ISBNTextBox_KeyDown);
            // 
            // PublisherTextBox
            // 
            this.PublisherTextBox.Location = new System.Drawing.Point(64, 100);
            this.PublisherTextBox.Name = "PublisherTextBox";
            this.PublisherTextBox.Size = new System.Drawing.Size(368, 20);
            this.PublisherTextBox.TabIndex = 3;
            this.PublisherTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ISBNTextBox_KeyDown);
            // 
            // ISBNTextBox
            // 
            this.ISBNTextBox.Location = new System.Drawing.Point(64, 20);
            this.ISBNTextBox.Name = "ISBNTextBox";
            this.ISBNTextBox.Size = new System.Drawing.Size(368, 20);
            this.ISBNTextBox.TabIndex = 0;
            this.ISBNTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ISBNTextBox_KeyDown);
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(64, 46);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(368, 20);
            this.TitleTextBox.TabIndex = 1;
            this.TitleTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ISBNTextBox_KeyDown);
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Location = new System.Drawing.Point(64, 74);
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(368, 20);
            this.AuthorTextBox.TabIndex = 2;
            this.AuthorTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ISBNTextBox_KeyDown);
            // 
            // YearLabel
            // 
            this.YearLabel.AutoSize = true;
            this.YearLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.YearLabel.Location = new System.Drawing.Point(6, 130);
            this.YearLabel.Name = "YearLabel";
            this.YearLabel.Size = new System.Drawing.Size(55, 13);
            this.YearLabel.TabIndex = 10;
            this.YearLabel.Text = "Rok wyd.:";
            // 
            // PublisherLabel
            // 
            this.PublisherLabel.AutoSize = true;
            this.PublisherLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PublisherLabel.Location = new System.Drawing.Point(6, 104);
            this.PublisherLabel.Name = "PublisherLabel";
            this.PublisherLabel.Size = new System.Drawing.Size(58, 13);
            this.PublisherLabel.TabIndex = 8;
            this.PublisherLabel.Text = "Wydawca:";
            // 
            // ISBNLabel
            // 
            this.ISBNLabel.AutoSize = true;
            this.ISBNLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ISBNLabel.Location = new System.Drawing.Point(6, 23);
            this.ISBNLabel.Name = "ISBNLabel";
            this.ISBNLabel.Size = new System.Drawing.Size(38, 13);
            this.ISBNLabel.TabIndex = 6;
            this.ISBNLabel.Text = "ISBN: ";
            // 
            // TitleLabel
            // 
            this.TitleLabel.AutoSize = true;
            this.TitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TitleLabel.Location = new System.Drawing.Point(6, 49);
            this.TitleLabel.Name = "TitleLabel";
            this.TitleLabel.Size = new System.Drawing.Size(38, 13);
            this.TitleLabel.TabIndex = 4;
            this.TitleLabel.Text = "Tytuł: ";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AuthorLabel.Location = new System.Drawing.Point(6, 77);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(38, 13);
            this.AuthorLabel.TabIndex = 2;
            this.AuthorLabel.Text = "Autor: ";
            // 
            // ResultsGroupBox
            // 
            this.ResultsGroupBox.Controls.Add(this.ResultsDGV);
            this.ResultsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsGroupBox.Location = new System.Drawing.Point(3, 228);
            this.ResultsGroupBox.Name = "ResultsGroupBox";
            this.ResultsGroupBox.Size = new System.Drawing.Size(706, 169);
            this.ResultsGroupBox.TabIndex = 1;
            this.ResultsGroupBox.TabStop = false;
            this.ResultsGroupBox.Text = "Wyniki wyszukiwania";
            // 
            // ResultsDGV
            // 
            this.ResultsDGV.AllowUserToAddRows = false;
            this.ResultsDGV.AllowUserToDeleteRows = false;
            this.ResultsDGV.AllowUserToResizeRows = false;
            this.ResultsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ResultsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ResultsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Ordinal,
            this.AutorCol,
            this.Tytuł,
            this.ISBN,
            this.Wydawca,
            this.Rok,
            this.Wydanie});
            this.ResultsDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsDGV.Location = new System.Drawing.Point(3, 16);
            this.ResultsDGV.MultiSelect = false;
            this.ResultsDGV.Name = "ResultsDGV";
            this.ResultsDGV.ReadOnly = true;
            this.ResultsDGV.RowHeadersVisible = false;
            this.ResultsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ResultsDGV.Size = new System.Drawing.Size(700, 150);
            this.ResultsDGV.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ImportButton);
            this.panel1.Controls.Add(this.EditMARCButton);
            this.panel1.Controls.Add(this.PreviewButton);
            this.panel1.Controls.Add(this.NumberOfDescriptonsLabel);
            this.panel1.Controls.Add(this.NameLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 192);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(706, 30);
            this.panel1.TabIndex = 3;
            // 
            // ImportButton
            // 
            this.ImportButton.Image = global::Ksiazki.Properties.Resources.save;
            this.ImportButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ImportButton.Location = new System.Drawing.Point(446, 1);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(112, 29);
            this.ImportButton.TabIndex = 4;
            this.ImportButton.Text = "IMPORTUJ";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // EditMARCButton
            // 
            this.EditMARCButton.Location = new System.Drawing.Point(619, 1);
            this.EditMARCButton.Name = "EditMARCButton";
            this.EditMARCButton.Size = new System.Drawing.Size(87, 29);
            this.EditMARCButton.TabIndex = 1;
            this.EditMARCButton.Text = "Edytuj opis MARC do importu";
            this.EditMARCButton.UseVisualStyleBackColor = true;
            this.EditMARCButton.Visible = false;
            this.EditMARCButton.Click += new System.EventHandler(this.EditMARCButton_Click);
            // 
            // PreviewButton
            // 
            this.PreviewButton.Image = global::Ksiazki.Properties.Resources.preview;
            this.PreviewButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PreviewButton.Location = new System.Drawing.Point(268, 0);
            this.PreviewButton.Name = "PreviewButton";
            this.PreviewButton.Size = new System.Drawing.Size(164, 29);
            this.PreviewButton.TabIndex = 0;
            this.PreviewButton.Text = "Podgląd opisu MARC";
            this.PreviewButton.UseVisualStyleBackColor = true;
            this.PreviewButton.Click += new System.EventHandler(this.PreviewButton_Click);
            // 
            // NumberOfDescriptonsLabel
            // 
            this.NumberOfDescriptonsLabel.AutoSize = true;
            this.NumberOfDescriptonsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NumberOfDescriptonsLabel.Location = new System.Drawing.Point(92, 6);
            this.NumberOfDescriptonsLabel.Name = "NumberOfDescriptonsLabel";
            this.NumberOfDescriptonsLabel.Size = new System.Drawing.Size(48, 17);
            this.NumberOfDescriptonsLabel.TabIndex = 3;
            this.NumberOfDescriptonsLabel.Text = "31231";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NameLabel.Location = new System.Drawing.Point(4, 6);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(86, 17);
            this.NameLabel.TabIndex = 2;
            this.NameLabel.Text = "Znaleziono: ";
            // 
            // ServersTabPage
            // 
            this.ServersTabPage.Controls.Add(this.tableLayoutPanel1);
            this.ServersTabPage.Location = new System.Drawing.Point(4, 22);
            this.ServersTabPage.Name = "ServersTabPage";
            this.ServersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ServersTabPage.Size = new System.Drawing.Size(730, 481);
            this.ServersTabPage.TabIndex = 1;
            this.ServersTabPage.Text = "SERWERY";
            this.ServersTabPage.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ServersDGV, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.ButtonsPanel, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(724, 475);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Używane serwery:";
            // 
            // ServersDGV
            // 
            this.ServersDGV.AllowUserToAddRows = false;
            this.ServersDGV.AllowUserToDeleteRows = false;
            this.ServersDGV.AllowUserToResizeRows = false;
            this.ServersDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ServersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServersDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.OrdinalS,
            this.ServerName,
            this.ServerAddress,
            this.ServerID,
            this.Comments});
            this.ServersDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServersDGV.Location = new System.Drawing.Point(3, 23);
            this.ServersDGV.MultiSelect = false;
            this.ServersDGV.Name = "ServersDGV";
            this.ServersDGV.ReadOnly = true;
            this.ServersDGV.RowHeadersVisible = false;
            this.ServersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServersDGV.Size = new System.Drawing.Size(718, 408);
            this.ServersDGV.TabIndex = 1;
            this.ServersDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ServersDGV_KeyDown);
            this.ServersDGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ServersDGV_KeyPress);
            // 
            // OrdinalS
            // 
            this.OrdinalS.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.OrdinalS.HeaderText = "L.p.";
            this.OrdinalS.Name = "OrdinalS";
            this.OrdinalS.ReadOnly = true;
            this.OrdinalS.Width = 50;
            // 
            // ServerName
            // 
            this.ServerName.HeaderText = "Nazwa serwera";
            this.ServerName.Name = "ServerName";
            this.ServerName.ReadOnly = true;
            // 
            // ServerAddress
            // 
            this.ServerAddress.HeaderText = "Adres serwera";
            this.ServerAddress.Name = "ServerAddress";
            this.ServerAddress.ReadOnly = true;
            // 
            // ServerID
            // 
            this.ServerID.HeaderText = "ServerID";
            this.ServerID.Name = "ServerID";
            this.ServerID.ReadOnly = true;
            this.ServerID.Visible = false;
            // 
            // Comments
            // 
            this.Comments.HeaderText = "Uwagi";
            this.Comments.Name = "Comments";
            this.Comments.ReadOnly = true;
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.SearchLabel);
            this.ButtonsPanel.Controls.Add(this.DeleteServerButton);
            this.ButtonsPanel.Controls.Add(this.EditServerButton);
            this.ButtonsPanel.Controls.Add(this.AddServerButton);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPanel.Location = new System.Drawing.Point(3, 437);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(718, 35);
            this.ButtonsPanel.TabIndex = 2;
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(283, 10);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(35, 13);
            this.SearchLabel.TabIndex = 3;
            this.SearchLabel.Text = "label2";
            // 
            // DeleteServerButton
            // 
            this.DeleteServerButton.Image = global::Ksiazki.Properties.Resources.contact_busy_overlay;
            this.DeleteServerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DeleteServerButton.Location = new System.Drawing.Point(189, 3);
            this.DeleteServerButton.Name = "DeleteServerButton";
            this.DeleteServerButton.Size = new System.Drawing.Size(87, 29);
            this.DeleteServerButton.TabIndex = 2;
            this.DeleteServerButton.Text = "Usuń";
            this.DeleteServerButton.UseVisualStyleBackColor = true;
            this.DeleteServerButton.Click += new System.EventHandler(this.DeleteServerButton_Click);
            // 
            // EditServerButton
            // 
            this.EditServerButton.Image = global::Ksiazki.Properties.Resources.edycjam;
            this.EditServerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EditServerButton.Location = new System.Drawing.Point(96, 3);
            this.EditServerButton.Name = "EditServerButton";
            this.EditServerButton.Size = new System.Drawing.Size(87, 29);
            this.EditServerButton.TabIndex = 1;
            this.EditServerButton.Text = "Edytuj";
            this.EditServerButton.UseVisualStyleBackColor = true;
            this.EditServerButton.Click += new System.EventHandler(this.EditServerButton_Click);
            // 
            // AddServerButton
            // 
            this.AddServerButton.Image = global::Ksiazki.Properties.Resources.edit_add;
            this.AddServerButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AddServerButton.Location = new System.Drawing.Point(3, 3);
            this.AddServerButton.Name = "AddServerButton";
            this.AddServerButton.Size = new System.Drawing.Size(87, 29);
            this.AddServerButton.TabIndex = 0;
            this.AddServerButton.Text = "Dodaj nowy";
            this.AddServerButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddServerButton.UseVisualStyleBackColor = true;
            this.AddServerButton.Click += new System.EventHandler(this.AddServerButton_Click);
            // 
            // MainLayoutPanel
            // 
            this.MainLayoutPanel.ColumnCount = 1;
            this.MainLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayoutPanel.Controls.Add(this.ImportTabControl, 0, 0);
            this.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.MainLayoutPanel.Name = "MainLayoutPanel";
            this.MainLayoutPanel.RowCount = 1;
            this.MainLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainLayoutPanel.Size = new System.Drawing.Size(744, 513);
            this.MainLayoutPanel.TabIndex = 1;
            // 
            // id
            // 
            this.id.FillWeight = 12F;
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // Ordinal
            // 
            this.Ordinal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.Ordinal.HeaderText = "L.p.";
            this.Ordinal.MinimumWidth = 30;
            this.Ordinal.Name = "Ordinal";
            this.Ordinal.ReadOnly = true;
            this.Ordinal.Width = 30;
            // 
            // AutorCol
            // 
            this.AutorCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.AutorCol.HeaderText = "Autor";
            this.AutorCol.MinimumWidth = 120;
            this.AutorCol.Name = "AutorCol";
            this.AutorCol.ReadOnly = true;
            this.AutorCol.Width = 120;
            // 
            // Tytuł
            // 
            this.Tytuł.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Tytuł.HeaderText = "Tytuł";
            this.Tytuł.MinimumWidth = 200;
            this.Tytuł.Name = "Tytuł";
            this.Tytuł.ReadOnly = true;
            // 
            // ISBN
            // 
            this.ISBN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.Name = "ISBN";
            this.ISBN.ReadOnly = true;
            this.ISBN.Width = 57;
            // 
            // Wydawca
            // 
            this.Wydawca.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Wydawca.HeaderText = "Wydawca";
            this.Wydawca.Name = "Wydawca";
            this.Wydawca.ReadOnly = true;
            // 
            // Rok
            // 
            this.Rok.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Rok.HeaderText = "Rok wyd.";
            this.Rok.MinimumWidth = 77;
            this.Rok.Name = "Rok";
            this.Rok.ReadOnly = true;
            this.Rok.Width = 77;
            // 
            // Wydanie
            // 
            this.Wydanie.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Wydanie.HeaderText = "Wydanie";
            this.Wydanie.Name = "Wydanie";
            this.Wydanie.ReadOnly = true;
            this.Wydanie.Width = 74;
            // 
            // ChooseServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 513);
            this.Controls.Add(this.MainLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(607, 445);
            this.Name = "ChooseServerForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Co-Liber Z39.50";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseServerForm_KeyDown);
            this.ImportTabControl.ResumeLayout(false);
            this.ImportTabPage.ResumeLayout(false);
            this.MainGroupBox.ResumeLayout(false);
            this.HeadLayoutPanel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.SubLayoutPanel.ResumeLayout(false);
            this.SearchingGroupBox.ResumeLayout(false);
            this.SearchingGroupBox.PerformLayout();
            this.ResultsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ResultsDGV)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ServersTabPage.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServersDGV)).EndInit();
            this.ButtonsPanel.ResumeLayout(false);
            this.ButtonsPanel.PerformLayout();
            this.MainLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl ImportTabControl;
        private System.Windows.Forms.TabPage ImportTabPage;
        private System.Windows.Forms.TabPage ServersTabPage;
        private System.Windows.Forms.GroupBox MainGroupBox;
        private System.Windows.Forms.ComboBox ServersComboBox;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.GroupBox SearchingGroupBox;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label YearLabel;
        private System.Windows.Forms.Label PublisherLabel;
        private System.Windows.Forms.Label ISBNLabel;
        private System.Windows.Forms.Label TitleLabel;
        private System.Windows.Forms.TableLayoutPanel MainLayoutPanel;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.TextBox PublisherTextBox;
        private System.Windows.Forms.TextBox ISBNTextBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.GroupBox ResultsGroupBox;
        private System.Windows.Forms.DataGridView ResultsDGV;
        private System.Windows.Forms.Button FoldButton;
        private System.Windows.Forms.TableLayoutPanel SubLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NumberOfDescriptonsLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TableLayoutPanel HeadLayoutPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button PreviewButton;
        private System.Windows.Forms.Button EditMARCButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView ServersDGV;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button DeleteServerButton;
        private System.Windows.Forms.Button EditServerButton;
        private System.Windows.Forms.Button AddServerButton;
        private System.Windows.Forms.Button SetDefaultButton;
        private System.Windows.Forms.RadioButton TitleRadioButton;
        private System.Windows.Forms.RadioButton ISBNRadioButton;
        private System.Windows.Forms.RadioButton YearRadioButton;
        private System.Windows.Forms.RadioButton PublisherRadioButton;
        private System.Windows.Forms.RadioButton AuthorRadioButton;
        private System.Windows.Forms.Label ChooseSortLabel;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn OrdinalS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServerID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ordinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn AutorCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tytuł;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wydawca;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rok;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wydanie;
    }
}