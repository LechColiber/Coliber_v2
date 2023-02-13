namespace Ksiazki
{
    partial class AuthorsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthorsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DeleteAuthorButton = new System.Windows.Forms.Button();
            this.DownButton = new System.Windows.Forms.Button();
            this.UpButton = new System.Windows.Forms.Button();
            this.AddAuthorButton = new System.Windows.Forms.Button();
            this.AuthorFNameTextBox = new System.Windows.Forms.TextBox();
            this.AuthorNameTextBox = new System.Windows.Forms.TextBox();
            this.ChooseAuthorsButton = new System.Windows.Forms.Button();
            this.AuthorsDGV = new System.Windows.Forms.DataGridView();
            this.IDAuthorsDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameAuthorsDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FNameAuthorsDGV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DeleteCoAuthorButton = new System.Windows.Forms.Button();
            this.AddCoAuthorButton = new System.Windows.Forms.Button();
            this.CoDownButton = new System.Windows.Forms.Button();
            this.CoUpButton = new System.Windows.Forms.Button();
            this.ChooseCoAuthorsButton = new System.Windows.Forms.Button();
            this.CoAuthorsDGV = new System.Windows.Forms.DataGridView();
            this.CoIDDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoNameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoFNameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CoRoleIDDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OdpowiedzialnoscDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Odpow1Button = new System.Windows.Forms.Button();
            this.RoleTextBox = new System.Windows.Forms.TextBox();
            this.CoAuthorFNameTextBox = new System.Windows.Forms.TextBox();
            this.CoAuthorNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CleanInstyt2Button = new System.Windows.Forms.Button();
            this.Insyt2Button = new System.Windows.Forms.Button();
            this.Place2TextBox = new System.Windows.Forms.TextBox();
            this.Instyt2TextBox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.CleanInstytButton = new System.Windows.Forms.Button();
            this.InstytButton = new System.Windows.Forms.Button();
            this.PlaceTextBox = new System.Windows.Forms.TextBox();
            this.Instyt1TextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbSiedziba = new System.Windows.Forms.Label();
            this.lbNazwaI = new System.Windows.Forms.Label();
            this.btCancel = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AuthorsDGV)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoAuthorsDGV)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DeleteAuthorButton);
            this.groupBox1.Controls.Add(this.DownButton);
            this.groupBox1.Controls.Add(this.UpButton);
            this.groupBox1.Controls.Add(this.AddAuthorButton);
            this.groupBox1.Controls.Add(this.AuthorFNameTextBox);
            this.groupBox1.Controls.Add(this.AuthorNameTextBox);
            this.groupBox1.Controls.Add(this.ChooseAuthorsButton);
            this.groupBox1.Controls.Add(this.AuthorsDGV);
            this.groupBox1.Location = new System.Drawing.Point(4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(673, 215);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Autorzy";
            // 
            // DeleteAuthorButton
            // 
            this.DeleteAuthorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteAuthorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeleteAuthorButton.Enabled = false;
            this.DeleteAuthorButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteAuthorButton.Image")));
            this.DeleteAuthorButton.Location = new System.Drawing.Point(594, 170);
            this.DeleteAuthorButton.Name = "DeleteAuthorButton";
            this.DeleteAuthorButton.Size = new System.Drawing.Size(32, 23);
            this.DeleteAuthorButton.TabIndex = 13;
            this.DeleteAuthorButton.UseVisualStyleBackColor = true;
            this.DeleteAuthorButton.Click += new System.EventHandler(this.DeleteAuthorButton_Click);
            // 
            // DownButton
            // 
            this.DownButton.Enabled = false;
            this.DownButton.Image = ((System.Drawing.Image)(resources.GetObject("DownButton.Image")));
            this.DownButton.Location = new System.Drawing.Point(556, 101);
            this.DownButton.Name = "DownButton";
            this.DownButton.Size = new System.Drawing.Size(49, 23);
            this.DownButton.TabIndex = 12;
            this.DownButton.UseVisualStyleBackColor = true;
            this.DownButton.Click += new System.EventHandler(this.DownButton_Click);
            // 
            // UpButton
            // 
            this.UpButton.Enabled = false;
            this.UpButton.Image = ((System.Drawing.Image)(resources.GetObject("UpButton.Image")));
            this.UpButton.Location = new System.Drawing.Point(556, 72);
            this.UpButton.Name = "UpButton";
            this.UpButton.Size = new System.Drawing.Size(49, 23);
            this.UpButton.TabIndex = 11;
            this.UpButton.UseVisualStyleBackColor = true;
            this.UpButton.Click += new System.EventHandler(this.UpButton_Click);
            // 
            // AddAuthorButton
            // 
            this.AddAuthorButton.Enabled = false;
            this.AddAuthorButton.Image = global::Ksiazki.Properties.Resources.edit_add;
            this.AddAuthorButton.Location = new System.Drawing.Point(556, 170);
            this.AddAuthorButton.Name = "AddAuthorButton";
            this.AddAuthorButton.Size = new System.Drawing.Size(32, 23);
            this.AddAuthorButton.TabIndex = 10;
            this.AddAuthorButton.UseVisualStyleBackColor = true;
            this.AddAuthorButton.Click += new System.EventHandler(this.AddAuthorButton_Click);
            // 
            // AuthorFNameTextBox
            // 
            this.AuthorFNameTextBox.Location = new System.Drawing.Point(364, 170);
            this.AuthorFNameTextBox.MaxLength = 50;
            this.AuthorFNameTextBox.Name = "AuthorFNameTextBox";
            this.AuthorFNameTextBox.Size = new System.Drawing.Size(186, 20);
            this.AuthorFNameTextBox.TabIndex = 8;
            this.AuthorFNameTextBox.TextChanged += new System.EventHandler(this.CheckNameOrFNameIsNotEmpty);
            this.AuthorFNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameTextBox_KeyDown);
            // 
            // AuthorNameTextBox
            // 
            this.AuthorNameTextBox.Location = new System.Drawing.Point(18, 170);
            this.AuthorNameTextBox.MaxLength = 100;
            this.AuthorNameTextBox.Name = "AuthorNameTextBox";
            this.AuthorNameTextBox.Size = new System.Drawing.Size(340, 20);
            this.AuthorNameTextBox.TabIndex = 6;
            this.AuthorNameTextBox.TextChanged += new System.EventHandler(this.CheckNameOrFNameIsNotEmpty);
            this.AuthorNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NameTextBox_KeyDown);
            // 
            // ChooseAuthorsButton
            // 
            this.ChooseAuthorsButton.Image = global::Ksiazki.Properties.Resources.lista2;
            this.ChooseAuthorsButton.Location = new System.Drawing.Point(556, 19);
            this.ChooseAuthorsButton.Name = "ChooseAuthorsButton";
            this.ChooseAuthorsButton.Size = new System.Drawing.Size(32, 23);
            this.ChooseAuthorsButton.TabIndex = 5;
            this.ChooseAuthorsButton.UseVisualStyleBackColor = true;
            this.ChooseAuthorsButton.Click += new System.EventHandler(this.ChooseAuthorsButton_Click);
            // 
            // AuthorsDGV
            // 
            this.AuthorsDGV.AllowUserToAddRows = false;
            this.AuthorsDGV.AllowUserToDeleteRows = false;
            this.AuthorsDGV.AllowUserToResizeRows = false;
            this.AuthorsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AuthorsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDAuthorsDGV,
            this.NameAuthorsDGV,
            this.FNameAuthorsDGV});
            this.AuthorsDGV.Location = new System.Drawing.Point(18, 19);
            this.AuthorsDGV.MultiSelect = false;
            this.AuthorsDGV.Name = "AuthorsDGV";
            this.AuthorsDGV.ReadOnly = true;
            this.AuthorsDGV.RowHeadersVisible = false;
            this.AuthorsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AuthorsDGV.Size = new System.Drawing.Size(532, 145);
            this.AuthorsDGV.TabIndex = 9;
            this.AuthorsDGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.AuthorsDGV_RowsAdded);
            this.AuthorsDGV.SelectionChanged += new System.EventHandler(this.AuthorsDGV_SelectionChanged);
            // 
            // IDAuthorsDGV
            // 
            this.IDAuthorsDGV.DataPropertyName = "id_aut";
            this.IDAuthorsDGV.HeaderText = "id";
            this.IDAuthorsDGV.Name = "IDAuthorsDGV";
            this.IDAuthorsDGV.ReadOnly = true;
            this.IDAuthorsDGV.Visible = false;
            // 
            // NameAuthorsDGV
            // 
            this.NameAuthorsDGV.DataPropertyName = "nazwisko";
            this.NameAuthorsDGV.HeaderText = "Nazwisko";
            this.NameAuthorsDGV.Name = "NameAuthorsDGV";
            this.NameAuthorsDGV.ReadOnly = true;
            this.NameAuthorsDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NameAuthorsDGV.Width = 340;
            // 
            // FNameAuthorsDGV
            // 
            this.FNameAuthorsDGV.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FNameAuthorsDGV.DataPropertyName = "imie";
            this.FNameAuthorsDGV.HeaderText = "Imię";
            this.FNameAuthorsDGV.Name = "FNameAuthorsDGV";
            this.FNameAuthorsDGV.ReadOnly = true;
            this.FNameAuthorsDGV.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DeleteCoAuthorButton);
            this.groupBox2.Controls.Add(this.AddCoAuthorButton);
            this.groupBox2.Controls.Add(this.CoDownButton);
            this.groupBox2.Controls.Add(this.CoUpButton);
            this.groupBox2.Controls.Add(this.ChooseCoAuthorsButton);
            this.groupBox2.Controls.Add(this.CoAuthorsDGV);
            this.groupBox2.Controls.Add(this.Odpow1Button);
            this.groupBox2.Controls.Add(this.RoleTextBox);
            this.groupBox2.Controls.Add(this.CoAuthorFNameTextBox);
            this.groupBox2.Controls.Add(this.CoAuthorNameTextBox);
            this.groupBox2.Location = new System.Drawing.Point(4, 226);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(673, 214);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Współtwórcy";
            // 
            // DeleteCoAuthorButton
            // 
            this.DeleteCoAuthorButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteCoAuthorButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeleteCoAuthorButton.Enabled = false;
            this.DeleteCoAuthorButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteCoAuthorButton.Image")));
            this.DeleteCoAuthorButton.Location = new System.Drawing.Point(632, 168);
            this.DeleteCoAuthorButton.Name = "DeleteCoAuthorButton";
            this.DeleteCoAuthorButton.Size = new System.Drawing.Size(32, 23);
            this.DeleteCoAuthorButton.TabIndex = 46;
            this.DeleteCoAuthorButton.UseVisualStyleBackColor = true;
            this.DeleteCoAuthorButton.Click += new System.EventHandler(this.DeleteCoAuthorButton_Click);
            // 
            // AddCoAuthorButton
            // 
            this.AddCoAuthorButton.Enabled = false;
            this.AddCoAuthorButton.Image = global::Ksiazki.Properties.Resources.edit_add;
            this.AddCoAuthorButton.Location = new System.Drawing.Point(594, 168);
            this.AddCoAuthorButton.Name = "AddCoAuthorButton";
            this.AddCoAuthorButton.Size = new System.Drawing.Size(32, 23);
            this.AddCoAuthorButton.TabIndex = 45;
            this.AddCoAuthorButton.UseVisualStyleBackColor = true;
            this.AddCoAuthorButton.Click += new System.EventHandler(this.AddCoAuthorButton_Click);
            // 
            // CoDownButton
            // 
            this.CoDownButton.Enabled = false;
            this.CoDownButton.Image = ((System.Drawing.Image)(resources.GetObject("CoDownButton.Image")));
            this.CoDownButton.Location = new System.Drawing.Point(556, 98);
            this.CoDownButton.Name = "CoDownButton";
            this.CoDownButton.Size = new System.Drawing.Size(49, 23);
            this.CoDownButton.TabIndex = 44;
            this.CoDownButton.UseVisualStyleBackColor = true;
            this.CoDownButton.Click += new System.EventHandler(this.CoDownButton_Click);
            // 
            // CoUpButton
            // 
            this.CoUpButton.Enabled = false;
            this.CoUpButton.Image = ((System.Drawing.Image)(resources.GetObject("CoUpButton.Image")));
            this.CoUpButton.Location = new System.Drawing.Point(556, 69);
            this.CoUpButton.Name = "CoUpButton";
            this.CoUpButton.Size = new System.Drawing.Size(49, 23);
            this.CoUpButton.TabIndex = 43;
            this.CoUpButton.UseVisualStyleBackColor = true;
            this.CoUpButton.Click += new System.EventHandler(this.CoUpButton_Click);
            // 
            // ChooseCoAuthorsButton
            // 
            this.ChooseCoAuthorsButton.Image = global::Ksiazki.Properties.Resources.lista2;
            this.ChooseCoAuthorsButton.Location = new System.Drawing.Point(556, 19);
            this.ChooseCoAuthorsButton.Name = "ChooseCoAuthorsButton";
            this.ChooseCoAuthorsButton.Size = new System.Drawing.Size(32, 23);
            this.ChooseCoAuthorsButton.TabIndex = 41;
            this.ChooseCoAuthorsButton.UseVisualStyleBackColor = true;
            this.ChooseCoAuthorsButton.Click += new System.EventHandler(this.ChooseCoAuthorsButton_Click);
            // 
            // CoAuthorsDGV
            // 
            this.CoAuthorsDGV.AllowUserToAddRows = false;
            this.CoAuthorsDGV.AllowUserToDeleteRows = false;
            this.CoAuthorsDGV.AllowUserToResizeRows = false;
            this.CoAuthorsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CoAuthorsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CoIDDGVC,
            this.CoNameDGVC,
            this.CoFNameDGVC,
            this.CoRoleIDDGVC,
            this.OdpowiedzialnoscDGVC});
            this.CoAuthorsDGV.Location = new System.Drawing.Point(18, 19);
            this.CoAuthorsDGV.MultiSelect = false;
            this.CoAuthorsDGV.Name = "CoAuthorsDGV";
            this.CoAuthorsDGV.ReadOnly = true;
            this.CoAuthorsDGV.RowHeadersVisible = false;
            this.CoAuthorsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CoAuthorsDGV.Size = new System.Drawing.Size(532, 145);
            this.CoAuthorsDGV.TabIndex = 42;
            this.CoAuthorsDGV.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.CoAuthorsDGV_RowsAdded);
            this.CoAuthorsDGV.SelectionChanged += new System.EventHandler(this.CoAuthorsDGV_SelectionChanged);
            // 
            // CoIDDGVC
            // 
            this.CoIDDGVC.DataPropertyName = "id_aut";
            this.CoIDDGVC.HeaderText = "id";
            this.CoIDDGVC.Name = "CoIDDGVC";
            this.CoIDDGVC.ReadOnly = true;
            this.CoIDDGVC.Visible = false;
            // 
            // CoNameDGVC
            // 
            this.CoNameDGVC.DataPropertyName = "nazwisko";
            this.CoNameDGVC.HeaderText = "Nazwisko";
            this.CoNameDGVC.Name = "CoNameDGVC";
            this.CoNameDGVC.ReadOnly = true;
            this.CoNameDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CoNameDGVC.Width = 259;
            // 
            // CoFNameDGVC
            // 
            this.CoFNameDGVC.DataPropertyName = "imie";
            this.CoFNameDGVC.HeaderText = "Imię";
            this.CoFNameDGVC.Name = "CoFNameDGVC";
            this.CoFNameDGVC.ReadOnly = true;
            this.CoFNameDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CoFNameDGVC.Width = 149;
            // 
            // CoRoleIDDGVC
            // 
            this.CoRoleIDDGVC.HeaderText = "idRole";
            this.CoRoleIDDGVC.Name = "CoRoleIDDGVC";
            this.CoRoleIDDGVC.ReadOnly = true;
            this.CoRoleIDDGVC.Visible = false;
            // 
            // OdpowiedzialnoscDGVC
            // 
            this.OdpowiedzialnoscDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OdpowiedzialnoscDGVC.HeaderText = "Odpowiedzialność";
            this.OdpowiedzialnoscDGVC.Name = "OdpowiedzialnoscDGVC";
            this.OdpowiedzialnoscDGVC.ReadOnly = true;
            this.OdpowiedzialnoscDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Odpow1Button
            // 
            this.Odpow1Button.Enabled = false;
            this.Odpow1Button.Image = ((System.Drawing.Image)(resources.GetObject("Odpow1Button.Image")));
            this.Odpow1Button.Location = new System.Drawing.Point(556, 168);
            this.Odpow1Button.Name = "Odpow1Button";
            this.Odpow1Button.Size = new System.Drawing.Size(32, 23);
            this.Odpow1Button.TabIndex = 40;
            this.Odpow1Button.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Odpow1Button.UseVisualStyleBackColor = true;
            this.Odpow1Button.Click += new System.EventHandler(this.Odpow1Button_Click);
            // 
            // RoleTextBox
            // 
            this.RoleTextBox.Location = new System.Drawing.Point(428, 170);
            this.RoleTextBox.MaxLength = 25;
            this.RoleTextBox.Name = "RoleTextBox";
            this.RoleTextBox.Size = new System.Drawing.Size(122, 20);
            this.RoleTextBox.TabIndex = 3;
            this.RoleTextBox.TextChanged += new System.EventHandler(this.RoleTextBox_TextChanged);
            this.RoleTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoNameTextBox_KeyDown);
            // 
            // CoAuthorFNameTextBox
            // 
            this.CoAuthorFNameTextBox.Location = new System.Drawing.Point(283, 170);
            this.CoAuthorFNameTextBox.MaxLength = 100;
            this.CoAuthorFNameTextBox.Name = "CoAuthorFNameTextBox";
            this.CoAuthorFNameTextBox.Size = new System.Drawing.Size(139, 20);
            this.CoAuthorFNameTextBox.TabIndex = 1;
            this.CoAuthorFNameTextBox.TextChanged += new System.EventHandler(this.CoFNameTextBox_TextChanged);
            this.CoAuthorFNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoNameTextBox_KeyDown);
            // 
            // CoAuthorNameTextBox
            // 
            this.CoAuthorNameTextBox.Location = new System.Drawing.Point(18, 170);
            this.CoAuthorNameTextBox.MaxLength = 50;
            this.CoAuthorNameTextBox.Name = "CoAuthorNameTextBox";
            this.CoAuthorNameTextBox.Size = new System.Drawing.Size(259, 20);
            this.CoAuthorNameTextBox.TabIndex = 0;
            this.CoAuthorNameTextBox.TextChanged += new System.EventHandler(this.CoNameTextBox_TextChanged);
            this.CoAuthorNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CoNameTextBox_KeyDown);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CleanInstyt2Button);
            this.groupBox3.Controls.Add(this.Insyt2Button);
            this.groupBox3.Controls.Add(this.Place2TextBox);
            this.groupBox3.Controls.Add(this.Instyt2TextBox);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.CleanInstytButton);
            this.groupBox3.Controls.Add(this.InstytButton);
            this.groupBox3.Controls.Add(this.PlaceTextBox);
            this.groupBox3.Controls.Add(this.Instyt1TextBox);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.lbSiedziba);
            this.groupBox3.Controls.Add(this.lbNazwaI);
            this.groupBox3.Location = new System.Drawing.Point(4, 446);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(673, 88);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Instytucje sprawcze";
            // 
            // CleanInstyt2Button
            // 
            this.CleanInstyt2Button.Image = ((System.Drawing.Image)(resources.GetObject("CleanInstyt2Button.Image")));
            this.CleanInstyt2Button.Location = new System.Drawing.Point(594, 56);
            this.CleanInstyt2Button.Name = "CleanInstyt2Button";
            this.CleanInstyt2Button.Size = new System.Drawing.Size(32, 23);
            this.CleanInstyt2Button.TabIndex = 7;
            this.CleanInstyt2Button.UseVisualStyleBackColor = true;
            this.CleanInstyt2Button.Click += new System.EventHandler(this.CleanInstyt2Button_Click);
            // 
            // Insyt2Button
            // 
            this.Insyt2Button.Image = ((System.Drawing.Image)(resources.GetObject("Insyt2Button.Image")));
            this.Insyt2Button.Location = new System.Drawing.Point(556, 56);
            this.Insyt2Button.Name = "Insyt2Button";
            this.Insyt2Button.Size = new System.Drawing.Size(32, 23);
            this.Insyt2Button.TabIndex = 6;
            this.Insyt2Button.UseVisualStyleBackColor = true;
            this.Insyt2Button.Click += new System.EventHandler(this.Insyt2Button_Click);
            // 
            // Place2TextBox
            // 
            this.Place2TextBox.Location = new System.Drawing.Point(387, 58);
            this.Place2TextBox.MaxLength = 30;
            this.Place2TextBox.Name = "Place2TextBox";
            this.Place2TextBox.Size = new System.Drawing.Size(163, 20);
            this.Place2TextBox.TabIndex = 5;
            // 
            // Instyt2TextBox
            // 
            this.Instyt2TextBox.Location = new System.Drawing.Point(18, 58);
            this.Instyt2TextBox.MaxLength = 120;
            this.Instyt2TextBox.Name = "Instyt2TextBox";
            this.Instyt2TextBox.Size = new System.Drawing.Size(363, 20);
            this.Instyt2TextBox.TabIndex = 4;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(3, 61);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "2";
            // 
            // CleanInstytButton
            // 
            this.CleanInstytButton.Image = ((System.Drawing.Image)(resources.GetObject("CleanInstytButton.Image")));
            this.CleanInstytButton.Location = new System.Drawing.Point(594, 30);
            this.CleanInstytButton.Name = "CleanInstytButton";
            this.CleanInstytButton.Size = new System.Drawing.Size(32, 23);
            this.CleanInstytButton.TabIndex = 3;
            this.CleanInstytButton.UseVisualStyleBackColor = true;
            this.CleanInstytButton.Click += new System.EventHandler(this.CleanInstytButton_Click);
            // 
            // InstytButton
            // 
            this.InstytButton.Image = ((System.Drawing.Image)(resources.GetObject("InstytButton.Image")));
            this.InstytButton.Location = new System.Drawing.Point(556, 30);
            this.InstytButton.Name = "InstytButton";
            this.InstytButton.Size = new System.Drawing.Size(32, 23);
            this.InstytButton.TabIndex = 2;
            this.InstytButton.UseVisualStyleBackColor = true;
            this.InstytButton.Click += new System.EventHandler(this.InstytButton_Click);
            // 
            // PlaceTextBox
            // 
            this.PlaceTextBox.Location = new System.Drawing.Point(387, 32);
            this.PlaceTextBox.MaxLength = 30;
            this.PlaceTextBox.Name = "PlaceTextBox";
            this.PlaceTextBox.Size = new System.Drawing.Size(163, 20);
            this.PlaceTextBox.TabIndex = 1;
            // 
            // Instyt1TextBox
            // 
            this.Instyt1TextBox.Location = new System.Drawing.Point(18, 32);
            this.Instyt1TextBox.MaxLength = 120;
            this.Instyt1TextBox.Name = "Instyt1TextBox";
            this.Instyt1TextBox.Size = new System.Drawing.Size(363, 20);
            this.Instyt1TextBox.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 35);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 17;
            this.label12.Text = "1";
            // 
            // lbSiedziba
            // 
            this.lbSiedziba.Location = new System.Drawing.Point(384, 16);
            this.lbSiedziba.Name = "lbSiedziba";
            this.lbSiedziba.Size = new System.Drawing.Size(235, 13);
            this.lbSiedziba.TabIndex = 16;
            this.lbSiedziba.Text = "Siedziba";
            // 
            // lbNazwaI
            // 
            this.lbNazwaI.Location = new System.Drawing.Point(15, 16);
            this.lbNazwaI.Name = "lbNazwaI";
            this.lbNazwaI.Size = new System.Drawing.Size(236, 13);
            this.lbNazwaI.TabIndex = 15;
            this.lbNazwaI.Text = "Nazwa instytucji";
            // 
            // btCancel
            // 
            this.btCancel.Image = global::Ksiazki.Properties.Resources.fileclose;
            this.btCancel.Location = new System.Drawing.Point(336, 542);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(87, 29);
            this.btCancel.TabIndex = 4;
            this.btCancel.Text = "Anuluj";
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Image = global::Ksiazki.Properties.Resources.Check2;
            this.OkButton.Location = new System.Drawing.Point(219, 542);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(87, 29);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "Zatwierdź";
            this.OkButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // AuthorsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 584);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "AuthorsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Autorzy, współautorzy i instytucje sprawcze";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AuthorsForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AuthorsForm_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AuthorsDGV)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoAuthorsDGV)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox CoAuthorFNameTextBox;
        private System.Windows.Forms.TextBox CoAuthorNameTextBox;
        private System.Windows.Forms.TextBox RoleTextBox;
        private System.Windows.Forms.Button CleanInstytButton;
        private System.Windows.Forms.Button InstytButton;
        private System.Windows.Forms.TextBox PlaceTextBox;
        private System.Windows.Forms.TextBox Instyt1TextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbSiedziba;
        private System.Windows.Forms.Label lbNazwaI;
        private System.Windows.Forms.Button CleanInstyt2Button;
        private System.Windows.Forms.Button Insyt2Button;
        private System.Windows.Forms.TextBox Place2TextBox;
        private System.Windows.Forms.TextBox Instyt2TextBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Button Odpow1Button;
        private System.Windows.Forms.Button AddAuthorButton;
        private System.Windows.Forms.TextBox AuthorFNameTextBox;
        private System.Windows.Forms.TextBox AuthorNameTextBox;
        private System.Windows.Forms.Button ChooseAuthorsButton;
        private System.Windows.Forms.DataGridView AuthorsDGV;
        private System.Windows.Forms.Button DownButton;
        private System.Windows.Forms.Button UpButton;
        private System.Windows.Forms.Button CoDownButton;
        private System.Windows.Forms.Button CoUpButton;
        private System.Windows.Forms.Button ChooseCoAuthorsButton;
        private System.Windows.Forms.DataGridView CoAuthorsDGV;
        private System.Windows.Forms.Button AddCoAuthorButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDAuthorsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameAuthorsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn FNameAuthorsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoIDDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoNameDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoFNameDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn CoRoleIDDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn OdpowiedzialnoscDGVC;
        private System.Windows.Forms.Button DeleteAuthorButton;
        private System.Windows.Forms.Button DeleteCoAuthorButton;
    }
}