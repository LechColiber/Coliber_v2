namespace Wypozyczalnia
{
    partial class UserGroupUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserGroupUC));
            this.commentsLabel = new System.Windows.Forms.Label();
            this.commentsRTB = new System.Windows.Forms.RichTextBox();
            this.deletePermissionButton = new System.Windows.Forms.Button();
            this.addPermissionButton = new System.Windows.Forms.Button();
            this.isActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.defualtPermissionLabel = new System.Windows.Forms.Label();
            this.timeLimitLabel = new System.Windows.Forms.Label();
            this.maxTimeTextBox = new System.Windows.Forms.TextBox();
            this.amountLimitLabel = new System.Windows.Forms.Label();
            this.maxBorrowsTextBox = new System.Windows.Forms.TextBox();
            this.groupNameLabel = new System.Windows.Forms.Label();
            this.groupNameTextBox = new System.Windows.Forms.TextBox();
            this.deleteUserGroupButton = new System.Windows.Forms.Button();
            this.editUserGroupButton = new System.Windows.Forms.Button();
            this.addUserGroupButton = new System.Windows.Forms.Button();
            this.groupsDGV = new System.Windows.Forms.DataGridView();
            this.syncIdGroupsDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupIdDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.permissionsDGV = new System.Windows.Forms.DataGridView();
            this.syncIDDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightNameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelUserGroupButton = new System.Windows.Forms.Button();
            this.saveUserGroupButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.groupsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // commentsLabel
            // 
            this.commentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commentsLabel.Location = new System.Drawing.Point(256, 368);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(63, 13);
            this.commentsLabel.TabIndex = 60;
            this.commentsLabel.Text = "Uwagi:";
            this.commentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // commentsRTB
            // 
            this.commentsRTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsRTB.Location = new System.Drawing.Point(252, 384);
            this.commentsRTB.MaxLength = 1000;
            this.commentsRTB.Name = "commentsRTB";
            this.commentsRTB.Size = new System.Drawing.Size(653, 74);
            this.commentsRTB.TabIndex = 13;
            this.commentsRTB.Text = "";
            // 
            // deletePermissionButton
            // 
            this.deletePermissionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deletePermissionButton.Image = ((System.Drawing.Image)(resources.GetObject("deletePermissionButton.Image")));
            this.deletePermissionButton.Location = new System.Drawing.Point(346, 331);
            this.deletePermissionButton.Name = "deletePermissionButton";
            this.deletePermissionButton.Size = new System.Drawing.Size(121, 23);
            this.deletePermissionButton.TabIndex = 11;
            this.deletePermissionButton.Text = "Usuń uprawnienie";
            this.deletePermissionButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deletePermissionButton.UseVisualStyleBackColor = true;
            this.deletePermissionButton.Click += new System.EventHandler(this.deletePermissionButton_Click);
            // 
            // addPermissionButton
            // 
            this.addPermissionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addPermissionButton.Image = ((System.Drawing.Image)(resources.GetObject("addPermissionButton.Image")));
            this.addPermissionButton.Location = new System.Drawing.Point(473, 331);
            this.addPermissionButton.Name = "addPermissionButton";
            this.addPermissionButton.Size = new System.Drawing.Size(121, 23);
            this.addPermissionButton.TabIndex = 12;
            this.addPermissionButton.Text = "Dodaj uprawnienie";
            this.addPermissionButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addPermissionButton.UseVisualStyleBackColor = true;
            this.addPermissionButton.Click += new System.EventHandler(this.addPermissionButton_Click);
            // 
            // isActiveCheckBox
            // 
            this.isActiveCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.isActiveCheckBox.Location = new System.Drawing.Point(252, 335);
            this.isActiveCheckBox.Name = "isActiveCheckBox";
            this.isActiveCheckBox.Size = new System.Drawing.Size(75, 17);
            this.isActiveCheckBox.TabIndex = 10;
            this.isActiveCheckBox.Text = "Aktywna";
            this.isActiveCheckBox.UseVisualStyleBackColor = true;
            this.isActiveCheckBox.CheckedChanged += new System.EventHandler(this.isActiveCheckBox_CheckedChanged);
            // 
            // defualtPermissionLabel
            // 
            this.defualtPermissionLabel.Location = new System.Drawing.Point(249, 160);
            this.defualtPermissionLabel.Name = "defualtPermissionLabel";
            this.defualtPermissionLabel.Size = new System.Drawing.Size(178, 13);
            this.defualtPermissionLabel.TabIndex = 54;
            this.defualtPermissionLabel.Text = "Domyślne uprawnienia użytkownika:";
            this.defualtPermissionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeLimitLabel
            // 
            this.timeLimitLabel.Location = new System.Drawing.Point(249, 136);
            this.timeLimitLabel.Name = "timeLimitLabel";
            this.timeLimitLabel.Size = new System.Drawing.Size(309, 13);
            this.timeLimitLabel.TabIndex = 53;
            this.timeLimitLabel.Text = "Domyślny maksymalny czas (w dniach) przetrzymywania zasobu:";
            this.timeLimitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maxTimeTextBox
            // 
            this.maxTimeTextBox.Location = new System.Drawing.Point(582, 133);
            this.maxTimeTextBox.MaxLength = 5;
            this.maxTimeTextBox.Name = "maxTimeTextBox";
            this.maxTimeTextBox.Size = new System.Drawing.Size(36, 20);
            this.maxTimeTextBox.TabIndex = 8;
            this.maxTimeTextBox.TextChanged += new System.EventHandler(this.maxTimeTextBox_TextChanged);
            // 
            // amountLimitLabel
            // 
            this.amountLimitLabel.Location = new System.Drawing.Point(249, 110);
            this.amountLimitLabel.Name = "amountLimitLabel";
            this.amountLimitLabel.Size = new System.Drawing.Size(327, 13);
            this.amountLimitLabel.TabIndex = 51;
            this.amountLimitLabel.Text = "Domyślna maksymalna liczba możliwych do wypożyczenia zasobów:";
            this.amountLimitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maxBorrowsTextBox
            // 
            this.maxBorrowsTextBox.Location = new System.Drawing.Point(582, 107);
            this.maxBorrowsTextBox.MaxLength = 5;
            this.maxBorrowsTextBox.Name = "maxBorrowsTextBox";
            this.maxBorrowsTextBox.Size = new System.Drawing.Size(36, 20);
            this.maxBorrowsTextBox.TabIndex = 7;
            this.maxBorrowsTextBox.TextChanged += new System.EventHandler(this.maxBorrowsTextBox_TextChanged);
            // 
            // groupNameLabel
            // 
            this.groupNameLabel.Location = new System.Drawing.Point(249, 84);
            this.groupNameLabel.Name = "groupNameLabel";
            this.groupNameLabel.Size = new System.Drawing.Size(43, 13);
            this.groupNameLabel.TabIndex = 49;
            this.groupNameLabel.Text = "Nazwa:";
            this.groupNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupNameTextBox
            // 
            this.groupNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupNameTextBox.Location = new System.Drawing.Point(295, 81);
            this.groupNameTextBox.Name = "groupNameTextBox";
            this.groupNameTextBox.Size = new System.Drawing.Size(610, 20);
            this.groupNameTextBox.TabIndex = 6;
            // 
            // deleteUserGroupButton
            // 
            this.deleteUserGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteUserGroupButton.Image")));
            this.deleteUserGroupButton.Location = new System.Drawing.Point(452, 0);
            this.deleteUserGroupButton.Name = "deleteUserGroupButton";
            this.deleteUserGroupButton.Size = new System.Drawing.Size(94, 23);
            this.deleteUserGroupButton.TabIndex = 3;
            this.deleteUserGroupButton.Text = "Usuń grupę";
            this.deleteUserGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteUserGroupButton.UseVisualStyleBackColor = true;
            this.deleteUserGroupButton.Click += new System.EventHandler(this.deleteUserGroupButton_Click);
            // 
            // editUserGroupButton
            // 
            this.editUserGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("editUserGroupButton.Image")));
            this.editUserGroupButton.Location = new System.Drawing.Point(352, 0);
            this.editUserGroupButton.Name = "editUserGroupButton";
            this.editUserGroupButton.Size = new System.Drawing.Size(94, 23);
            this.editUserGroupButton.TabIndex = 2;
            this.editUserGroupButton.Text = "Edytuj grupę";
            this.editUserGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editUserGroupButton.UseVisualStyleBackColor = true;
            this.editUserGroupButton.Click += new System.EventHandler(this.editUserGroupButton_Click);
            // 
            // addUserGroupButton
            // 
            this.addUserGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("addUserGroupButton.Image")));
            this.addUserGroupButton.Location = new System.Drawing.Point(252, 0);
            this.addUserGroupButton.Name = "addUserGroupButton";
            this.addUserGroupButton.Size = new System.Drawing.Size(94, 23);
            this.addUserGroupButton.TabIndex = 1;
            this.addUserGroupButton.Text = "Dodaj grupę";
            this.addUserGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addUserGroupButton.UseVisualStyleBackColor = true;
            this.addUserGroupButton.Click += new System.EventHandler(this.addUserGroupButton_Click);
            // 
            // groupsDGV
            // 
            this.groupsDGV.AllowUserToAddRows = false;
            this.groupsDGV.AllowUserToDeleteRows = false;
            this.groupsDGV.AllowUserToResizeRows = false;
            this.groupsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.groupsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.syncIdGroupsDGVC,
            this.groupIdDGVC,
            this.nameDGVC});
            this.groupsDGV.Location = new System.Drawing.Point(0, 0);
            this.groupsDGV.MultiSelect = false;
            this.groupsDGV.Name = "groupsDGV";
            this.groupsDGV.ReadOnly = true;
            this.groupsDGV.RowHeadersVisible = false;
            this.groupsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.groupsDGV.Size = new System.Drawing.Size(243, 458);
            this.groupsDGV.StandardTab = true;
            this.groupsDGV.TabIndex = 0;
            this.groupsDGV.SelectionChanged += new System.EventHandler(this.groupsDGV_SelectionChanged);
            // 
            // syncIdGroupsDGVC
            // 
            this.syncIdGroupsDGVC.HeaderText = "syncID";
            this.syncIdGroupsDGVC.Name = "syncIdGroupsDGVC";
            this.syncIdGroupsDGVC.ReadOnly = true;
            this.syncIdGroupsDGVC.Visible = false;
            // 
            // groupIdDGVC
            // 
            this.groupIdDGVC.HeaderText = "id";
            this.groupIdDGVC.Name = "groupIdDGVC";
            this.groupIdDGVC.ReadOnly = true;
            this.groupIdDGVC.Visible = false;
            // 
            // nameDGVC
            // 
            this.nameDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDGVC.HeaderText = "Nazwa";
            this.nameDGVC.Name = "nameDGVC";
            this.nameDGVC.ReadOnly = true;
            this.nameDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
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
            this.syncIDDGVC,
            this.rightNameDGVC});
            this.permissionsDGV.Location = new System.Drawing.Point(252, 176);
            this.permissionsDGV.MultiSelect = false;
            this.permissionsDGV.Name = "permissionsDGV";
            this.permissionsDGV.ReadOnly = true;
            this.permissionsDGV.RowHeadersVisible = false;
            this.permissionsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.permissionsDGV.Size = new System.Drawing.Size(653, 149);
            this.permissionsDGV.StandardTab = true;
            this.permissionsDGV.TabIndex = 9;
            this.permissionsDGV.SelectionChanged += new System.EventHandler(this.permissionsDGV_SelectionChanged);
            // 
            // syncIDDGVC
            // 
            this.syncIDDGVC.HeaderText = "syncID";
            this.syncIDDGVC.Name = "syncIDDGVC";
            this.syncIDDGVC.ReadOnly = true;
            this.syncIDDGVC.Visible = false;
            // 
            // rightNameDGVC
            // 
            this.rightNameDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rightNameDGVC.DataPropertyName = "nazwa";
            this.rightNameDGVC.HeaderText = "Nazwa";
            this.rightNameDGVC.Name = "rightNameDGVC";
            this.rightNameDGVC.ReadOnly = true;
            this.rightNameDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cancelUserGroupButton
            // 
            this.cancelUserGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelUserGroupButton.Image")));
            this.cancelUserGroupButton.Location = new System.Drawing.Point(352, 29);
            this.cancelUserGroupButton.Name = "cancelUserGroupButton";
            this.cancelUserGroupButton.Size = new System.Drawing.Size(94, 23);
            this.cancelUserGroupButton.TabIndex = 5;
            this.cancelUserGroupButton.Text = "Anuluj";
            this.cancelUserGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelUserGroupButton.UseVisualStyleBackColor = true;
            this.cancelUserGroupButton.Click += new System.EventHandler(this.cancelUserGroupButton_Click);
            // 
            // saveUserGroupButton
            // 
            this.saveUserGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("saveUserGroupButton.Image")));
            this.saveUserGroupButton.Location = new System.Drawing.Point(252, 29);
            this.saveUserGroupButton.Name = "saveUserGroupButton";
            this.saveUserGroupButton.Size = new System.Drawing.Size(94, 23);
            this.saveUserGroupButton.TabIndex = 4;
            this.saveUserGroupButton.Text = "Zapisz";
            this.saveUserGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveUserGroupButton.UseVisualStyleBackColor = true;
            this.saveUserGroupButton.Click += new System.EventHandler(this.saveUserGroupButton_Click);
            // 
            // UserGroupUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cancelUserGroupButton);
            this.Controls.Add(this.saveUserGroupButton);
            this.Controls.Add(this.permissionsDGV);
            this.Controls.Add(this.groupsDGV);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.commentsRTB);
            this.Controls.Add(this.deletePermissionButton);
            this.Controls.Add(this.addPermissionButton);
            this.Controls.Add(this.isActiveCheckBox);
            this.Controls.Add(this.defualtPermissionLabel);
            this.Controls.Add(this.timeLimitLabel);
            this.Controls.Add(this.maxTimeTextBox);
            this.Controls.Add(this.amountLimitLabel);
            this.Controls.Add(this.maxBorrowsTextBox);
            this.Controls.Add(this.groupNameLabel);
            this.Controls.Add(this.groupNameTextBox);
            this.Controls.Add(this.deleteUserGroupButton);
            this.Controls.Add(this.editUserGroupButton);
            this.Controls.Add(this.addUserGroupButton);
            this.Name = "UserGroupUC";
            this.Size = new System.Drawing.Size(914, 463);
            ((System.ComponentModel.ISupportInitialize)(this.groupsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.RichTextBox commentsRTB;
        private System.Windows.Forms.Button deletePermissionButton;
        private System.Windows.Forms.Button addPermissionButton;
        private System.Windows.Forms.CheckBox isActiveCheckBox;
        private System.Windows.Forms.Label defualtPermissionLabel;
        private System.Windows.Forms.Label timeLimitLabel;
        private System.Windows.Forms.TextBox maxTimeTextBox;
        private System.Windows.Forms.Label amountLimitLabel;
        private System.Windows.Forms.TextBox maxBorrowsTextBox;
        private System.Windows.Forms.Label groupNameLabel;
        private System.Windows.Forms.TextBox groupNameTextBox;
        private System.Windows.Forms.Button deleteUserGroupButton;
        private System.Windows.Forms.Button editUserGroupButton;
        private System.Windows.Forms.Button addUserGroupButton;
        private System.Windows.Forms.DataGridView groupsDGV;
        private System.Windows.Forms.DataGridView permissionsDGV;
        private System.Windows.Forms.Button cancelUserGroupButton;
        private System.Windows.Forms.Button saveUserGroupButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn syncIdGroupsDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupIdDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn syncIDDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightNameDGVC;
    }
}
