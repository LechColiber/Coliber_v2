namespace Wypozyczalnia
{
    partial class UsersListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersListForm));
            this.groupsDGV = new System.Windows.Forms.DataGridView();
            this.idGroupsDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupNameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupsLabel = new System.Windows.Forms.Label();
            this.nameLabel = new System.Windows.Forms.Label();
            this.usersDGV = new System.Windows.Forms.DataGridView();
            this.idUsersDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userNameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.blockedUsersDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.haveCheckBox = new System.Windows.Forms.CheckBox();
            this.newUserButton = new System.Windows.Forms.Button();
            this.selectUserButton = new System.Windows.Forms.Button();
            this.escapeButton = new System.Windows.Forms.Button();
            this.searchUserTextBox = new System.Windows.Forms.TextBox();
            this.usersLabel = new System.Windows.Forms.Label();
            this.searchUserButton = new System.Windows.Forms.Button();
            this.SearchLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // groupsDGV
            // 
            this.groupsDGV.AllowUserToAddRows = false;
            this.groupsDGV.AllowUserToDeleteRows = false;
            this.groupsDGV.AllowUserToResizeRows = false;
            this.groupsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupsDGV.ColumnHeadersVisible = false;
            this.groupsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idGroupsDGVC,
            this.groupNameDGVC});
            this.groupsDGV.Location = new System.Drawing.Point(12, 25);
            this.groupsDGV.MultiSelect = false;
            this.groupsDGV.Name = "groupsDGV";
            this.groupsDGV.ReadOnly = true;
            this.groupsDGV.RowHeadersVisible = false;
            this.groupsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.groupsDGV.Size = new System.Drawing.Size(166, 536);
            this.groupsDGV.StandardTab = true;
            this.groupsDGV.TabIndex = 0;
            this.groupsDGV.SelectionChanged += new System.EventHandler(this.groupsDGV_SelectionChanged);
            this.groupsDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.groupsDGV_KeyDown);
            // 
            // idGroupsDGVC
            // 
            this.idGroupsDGVC.DataPropertyName = "grupa_id";
            this.idGroupsDGVC.HeaderText = "id";
            this.idGroupsDGVC.Name = "idGroupsDGVC";
            this.idGroupsDGVC.ReadOnly = true;
            this.idGroupsDGVC.Visible = false;
            // 
            // groupNameDGVC
            // 
            this.groupNameDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.groupNameDGVC.DataPropertyName = "nazwa";
            this.groupNameDGVC.HeaderText = "Grupa";
            this.groupNameDGVC.Name = "groupNameDGVC";
            this.groupNameDGVC.ReadOnly = true;
            // 
            // groupsLabel
            // 
            this.groupsLabel.Location = new System.Drawing.Point(12, 9);
            this.groupsLabel.Name = "groupsLabel";
            this.groupsLabel.Size = new System.Drawing.Size(38, 13);
            this.groupsLabel.TabIndex = 1;
            this.groupsLabel.Text = "Grupy:";
            // 
            // nameLabel
            // 
            this.nameLabel.Location = new System.Drawing.Point(192, 9);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(98, 13);
            this.nameLabel.TabIndex = 2;
            this.nameLabel.Text = "Nazwa / nazwisko:";
            // 
            // usersDGV
            // 
            this.usersDGV.AllowUserToAddRows = false;
            this.usersDGV.AllowUserToDeleteRows = false;
            this.usersDGV.AllowUserToResizeRows = false;
            this.usersDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.usersDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.usersDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDGV.ColumnHeadersVisible = false;
            this.usersDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idUsersDGVC,
            this.userNameDGVC,
            this.blockedUsersDGVC});
            this.usersDGV.Location = new System.Drawing.Point(195, 59);
            this.usersDGV.MultiSelect = false;
            this.usersDGV.Name = "usersDGV";
            this.usersDGV.ReadOnly = true;
            this.usersDGV.RowHeadersVisible = false;
            this.usersDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersDGV.Size = new System.Drawing.Size(397, 429);
            this.usersDGV.StandardTab = true;
            this.usersDGV.TabIndex = 1;
            this.usersDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.usersDGV_CellClick);
            this.usersDGV.DoubleClick += new System.EventHandler(this.usersDGV_DoubleClick);
            this.usersDGV.KeyDown += new System.Windows.Forms.KeyEventHandler(this.usersDGV_KeyDown);
            this.usersDGV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.usersDGV_KeyPress);
            // 
            // idUsersDGVC
            // 
            this.idUsersDGVC.DataPropertyName = "id";
            this.idUsersDGVC.HeaderText = "id";
            this.idUsersDGVC.Name = "idUsersDGVC";
            this.idUsersDGVC.ReadOnly = true;
            this.idUsersDGVC.Visible = false;
            // 
            // userNameDGVC
            // 
            this.userNameDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.userNameDGVC.DataPropertyName = "nazwa";
            this.userNameDGVC.HeaderText = "Użytkownik";
            this.userNameDGVC.Name = "userNameDGVC";
            this.userNameDGVC.ReadOnly = true;
            // 
            // blockedUsersDGVC
            // 
            this.blockedUsersDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Red;
            this.blockedUsersDGVC.DefaultCellStyle = dataGridViewCellStyle1;
            this.blockedUsersDGVC.HeaderText = "Zablokowany";
            this.blockedUsersDGVC.Name = "blockedUsersDGVC";
            this.blockedUsersDGVC.ReadOnly = true;
            this.blockedUsersDGVC.Width = 5;
            // 
            // haveCheckBox
            // 
            this.haveCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.haveCheckBox.Location = new System.Drawing.Point(195, 515);
            this.haveCheckBox.Name = "haveCheckBox";
            this.haveCheckBox.Size = new System.Drawing.Size(210, 17);
            this.haveCheckBox.TabIndex = 4;
            this.haveCheckBox.Text = "Tylko posiadający niezwrócone zasoby";
            this.haveCheckBox.UseVisualStyleBackColor = true;
            this.haveCheckBox.CheckedChanged += new System.EventHandler(this.haveCheckBox_CheckedChanged);
            // 
            // newUserButton
            // 
            this.newUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.newUserButton.Image = ((System.Drawing.Image)(resources.GetObject("newUserButton.Image")));
            this.newUserButton.Location = new System.Drawing.Point(195, 538);
            this.newUserButton.Name = "newUserButton";
            this.newUserButton.Size = new System.Drawing.Size(75, 23);
            this.newUserButton.TabIndex = 5;
            this.newUserButton.Text = "Nowy";
            this.newUserButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.newUserButton.UseVisualStyleBackColor = true;
            this.newUserButton.Click += new System.EventHandler(this.newUserButton_Click);
            // 
            // selectUserButton
            // 
            this.selectUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.selectUserButton.Image = ((System.Drawing.Image)(resources.GetObject("selectUserButton.Image")));
            this.selectUserButton.Location = new System.Drawing.Point(276, 538);
            this.selectUserButton.Name = "selectUserButton";
            this.selectUserButton.Size = new System.Drawing.Size(75, 23);
            this.selectUserButton.TabIndex = 6;
            this.selectUserButton.Text = "Wybierz";
            this.selectUserButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectUserButton.UseVisualStyleBackColor = true;
            this.selectUserButton.Click += new System.EventHandler(this.selectUserButton_Click);
            // 
            // escapeButton
            // 
            this.escapeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.escapeButton.Image = ((System.Drawing.Image)(resources.GetObject("escapeButton.Image")));
            this.escapeButton.Location = new System.Drawing.Point(517, 538);
            this.escapeButton.Name = "escapeButton";
            this.escapeButton.Size = new System.Drawing.Size(75, 23);
            this.escapeButton.TabIndex = 7;
            this.escapeButton.Text = "Wyjście";
            this.escapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.escapeButton.UseVisualStyleBackColor = true;
            this.escapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // searchUserTextBox
            // 
            this.searchUserTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.searchUserTextBox.Location = new System.Drawing.Point(297, 6);
            this.searchUserTextBox.Name = "searchUserTextBox";
            this.searchUserTextBox.Size = new System.Drawing.Size(255, 20);
            this.searchUserTextBox.TabIndex = 2;
            this.searchUserTextBox.TextChanged += new System.EventHandler(this.searchUserTextBox_TextChanged);
            // 
            // usersLabel
            // 
            this.usersLabel.Location = new System.Drawing.Point(192, 34);
            this.usersLabel.Name = "usersLabel";
            this.usersLabel.Size = new System.Drawing.Size(70, 13);
            this.usersLabel.TabIndex = 9;
            this.usersLabel.Text = "Użytkownicy:";
            // 
            // searchUserButton
            // 
            this.searchUserButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.searchUserButton.Image = ((System.Drawing.Image)(resources.GetObject("searchUserButton.Image")));
            this.searchUserButton.Location = new System.Drawing.Point(558, 4);
            this.searchUserButton.Name = "searchUserButton";
            this.searchUserButton.Size = new System.Drawing.Size(34, 23);
            this.searchUserButton.TabIndex = 3;
            this.searchUserButton.UseVisualStyleBackColor = true;
            this.searchUserButton.Click += new System.EventHandler(this.searchUserButton_Click);
            // 
            // SearchLabel
            // 
            this.SearchLabel.Location = new System.Drawing.Point(192, 495);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(35, 13);
            this.SearchLabel.TabIndex = 10;
            this.SearchLabel.Text = "label1";
            // 
            // UsersListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 573);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.searchUserButton);
            this.Controls.Add(this.usersLabel);
            this.Controls.Add(this.searchUserTextBox);
            this.Controls.Add(this.escapeButton);
            this.Controls.Add(this.selectUserButton);
            this.Controls.Add(this.newUserButton);
            this.Controls.Add(this.haveCheckBox);
            this.Controls.Add(this.usersDGV);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.groupsLabel);
            this.Controls.Add(this.groupsDGV);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(620, 600);
            this.Name = "UsersListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wybór użytkownika";
            this.Activated += new System.EventHandler(this.UsersListForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UsersListForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UsersListForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.usersDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView groupsDGV;
        private System.Windows.Forms.Label groupsLabel;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.DataGridView usersDGV;
        private System.Windows.Forms.CheckBox haveCheckBox;
        private System.Windows.Forms.Button newUserButton;
        private System.Windows.Forms.Button selectUserButton;
        private System.Windows.Forms.Button escapeButton;
        private System.Windows.Forms.TextBox searchUserTextBox;
        private System.Windows.Forms.Label usersLabel;
        private System.Windows.Forms.Button searchUserButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGroupsDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupNameDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn idUsersDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn blockedUsersDGVC;
        private System.Windows.Forms.Label SearchLabel;
    }
}