namespace Wypozyczalnia
{
    partial class ResourceGroupUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResourceGroupUC));
            this.saveResourceGroupButton = new System.Windows.Forms.Button();
            this.permissionsDGV = new System.Windows.Forms.DataGridView();
            this.syncIDDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rightNameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupIdDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.syncIdGroupsDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancelResourceGroupButton = new System.Windows.Forms.Button();
            this.groupsDGV = new System.Windows.Forms.DataGridView();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.commentsRTB = new System.Windows.Forms.RichTextBox();
            this.deletePermissionButton = new System.Windows.Forms.Button();
            this.addPermissionButton = new System.Windows.Forms.Button();
            this.isActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.defualtPermissionLabel = new System.Windows.Forms.Label();
            this.timeLimitLabel = new System.Windows.Forms.Label();
            this.maxTimeTextBox = new System.Windows.Forms.TextBox();
            this.groupNameLabel = new System.Windows.Forms.Label();
            this.groupNameTextBox = new System.Windows.Forms.TextBox();
            this.deleteResourceGroupButton = new System.Windows.Forms.Button();
            this.editResourceGroupButton = new System.Windows.Forms.Button();
            this.addResourceGroupButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.permissionsDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // saveResourceGroupButton
            // 
            this.saveResourceGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("saveResourceGroupButton.Image")));
            this.saveResourceGroupButton.Location = new System.Drawing.Point(252, 29);
            this.saveResourceGroupButton.Name = "saveResourceGroupButton";
            this.saveResourceGroupButton.Size = new System.Drawing.Size(94, 23);
            this.saveResourceGroupButton.TabIndex = 4;
            this.saveResourceGroupButton.Text = "Zapisz";
            this.saveResourceGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveResourceGroupButton.UseVisualStyleBackColor = true;
            this.saveResourceGroupButton.Click += new System.EventHandler(this.saveResourceGroupButton_Click);
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
            this.permissionsDGV.Location = new System.Drawing.Point(252, 153);
            this.permissionsDGV.MultiSelect = false;
            this.permissionsDGV.Name = "permissionsDGV";
            this.permissionsDGV.ReadOnly = true;
            this.permissionsDGV.RowHeadersVisible = false;
            this.permissionsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.permissionsDGV.Size = new System.Drawing.Size(653, 149);
            this.permissionsDGV.StandardTab = true;
            this.permissionsDGV.TabIndex = 8;
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
            // nameDGVC
            // 
            this.nameDGVC.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDGVC.HeaderText = "Nazwa";
            this.nameDGVC.Name = "nameDGVC";
            this.nameDGVC.ReadOnly = true;
            this.nameDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupIdDGVC
            // 
            this.groupIdDGVC.HeaderText = "id";
            this.groupIdDGVC.Name = "groupIdDGVC";
            this.groupIdDGVC.ReadOnly = true;
            this.groupIdDGVC.Visible = false;
            // 
            // syncIdGroupsDGVC
            // 
            this.syncIdGroupsDGVC.HeaderText = "syncID";
            this.syncIdGroupsDGVC.Name = "syncIdGroupsDGVC";
            this.syncIdGroupsDGVC.ReadOnly = true;
            this.syncIdGroupsDGVC.Visible = false;
            // 
            // cancelResourceGroupButton
            // 
            this.cancelResourceGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("cancelResourceGroupButton.Image")));
            this.cancelResourceGroupButton.Location = new System.Drawing.Point(352, 29);
            this.cancelResourceGroupButton.Name = "cancelResourceGroupButton";
            this.cancelResourceGroupButton.Size = new System.Drawing.Size(94, 23);
            this.cancelResourceGroupButton.TabIndex = 5;
            this.cancelResourceGroupButton.Text = "Anuluj";
            this.cancelResourceGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cancelResourceGroupButton.UseVisualStyleBackColor = true;
            this.cancelResourceGroupButton.Click += new System.EventHandler(this.cancelResourceGroupButton_Click);
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
            // commentsLabel
            // 
            this.commentsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commentsLabel.AutoSize = true;
            this.commentsLabel.Location = new System.Drawing.Point(249, 341);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(40, 13);
            this.commentsLabel.TabIndex = 79;
            this.commentsLabel.Text = "Uwagi:";
            this.commentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // commentsRTB
            // 
            this.commentsRTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.commentsRTB.Location = new System.Drawing.Point(252, 357);
            this.commentsRTB.MaxLength = 1000;
            this.commentsRTB.Name = "commentsRTB";
            this.commentsRTB.Size = new System.Drawing.Size(653, 101);
            this.commentsRTB.TabIndex = 12;
            this.commentsRTB.Text = "";
            // 
            // deletePermissionButton
            // 
            this.deletePermissionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deletePermissionButton.Image = ((System.Drawing.Image)(resources.GetObject("deletePermissionButton.Image")));
            this.deletePermissionButton.Location = new System.Drawing.Point(388, 308);
            this.deletePermissionButton.Name = "deletePermissionButton";
            this.deletePermissionButton.Size = new System.Drawing.Size(121, 23);
            this.deletePermissionButton.TabIndex = 10;
            this.deletePermissionButton.Text = "Usuń uprawnienie";
            this.deletePermissionButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deletePermissionButton.UseVisualStyleBackColor = true;
            this.deletePermissionButton.Click += new System.EventHandler(this.deletePermissionButton_Click);
            // 
            // addPermissionButton
            // 
            this.addPermissionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.addPermissionButton.Image = ((System.Drawing.Image)(resources.GetObject("addPermissionButton.Image")));
            this.addPermissionButton.Location = new System.Drawing.Point(515, 308);
            this.addPermissionButton.Name = "addPermissionButton";
            this.addPermissionButton.Size = new System.Drawing.Size(121, 23);
            this.addPermissionButton.TabIndex = 11;
            this.addPermissionButton.Text = "Dodaj uprawnienie";
            this.addPermissionButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addPermissionButton.UseVisualStyleBackColor = true;
            this.addPermissionButton.Click += new System.EventHandler(this.addPermissionButton_Click);
            // 
            // isActiveCheckBox
            // 
            this.isActiveCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.isActiveCheckBox.Location = new System.Drawing.Point(252, 312);
            this.isActiveCheckBox.Name = "isActiveCheckBox";
            this.isActiveCheckBox.Size = new System.Drawing.Size(67, 17);
            this.isActiveCheckBox.TabIndex = 9;
            this.isActiveCheckBox.Text = "Aktywna";
            this.isActiveCheckBox.UseVisualStyleBackColor = true;
            this.isActiveCheckBox.Visible = false;
            this.isActiveCheckBox.CheckedChanged += new System.EventHandler(this.isActiveCheckBox_CheckedChanged);
            // 
            // defualtPermissionLabel
            // 
            this.defualtPermissionLabel.Location = new System.Drawing.Point(249, 137);
            this.defualtPermissionLabel.Name = "defualtPermissionLabel";
            this.defualtPermissionLabel.Size = new System.Drawing.Size(153, 13);
            this.defualtPermissionLabel.TabIndex = 74;
            this.defualtPermissionLabel.Text = "Domyślne uprawnienia zasobu:";
            this.defualtPermissionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timeLimitLabel
            // 
            this.timeLimitLabel.Location = new System.Drawing.Point(249, 113);
            this.timeLimitLabel.Name = "timeLimitLabel";
            this.timeLimitLabel.Size = new System.Drawing.Size(309, 13);
            this.timeLimitLabel.TabIndex = 73;
            this.timeLimitLabel.Text = "Domyślny maksymalny czas (w dniach) przetrzymywania zasobu:";
            this.timeLimitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // maxTimeTextBox
            // 
            this.maxTimeTextBox.Location = new System.Drawing.Point(582, 110);
            this.maxTimeTextBox.MaxLength = 5;
            this.maxTimeTextBox.Name = "maxTimeTextBox";
            this.maxTimeTextBox.Size = new System.Drawing.Size(36, 20);
            this.maxTimeTextBox.TabIndex = 7;
            this.maxTimeTextBox.TextChanged += new System.EventHandler(this.maxTimeTextBox_TextChanged);
            // 
            // groupNameLabel
            // 
            this.groupNameLabel.Location = new System.Drawing.Point(249, 84);
            this.groupNameLabel.Name = "groupNameLabel";
            this.groupNameLabel.Size = new System.Drawing.Size(43, 13);
            this.groupNameLabel.TabIndex = 69;
            this.groupNameLabel.Text = "Nazwa:";
            this.groupNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupNameTextBox
            // 
            this.groupNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupNameTextBox.Enabled = false;
            this.groupNameTextBox.Location = new System.Drawing.Point(295, 81);
            this.groupNameTextBox.Name = "groupNameTextBox";
            this.groupNameTextBox.Size = new System.Drawing.Size(610, 20);
            this.groupNameTextBox.TabIndex = 6;
            // 
            // deleteResourceGroupButton
            // 
            this.deleteResourceGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteResourceGroupButton.Image")));
            this.deleteResourceGroupButton.Location = new System.Drawing.Point(452, 0);
            this.deleteResourceGroupButton.Name = "deleteResourceGroupButton";
            this.deleteResourceGroupButton.Size = new System.Drawing.Size(94, 23);
            this.deleteResourceGroupButton.TabIndex = 3;
            this.deleteResourceGroupButton.Text = "Usuń grupę";
            this.deleteResourceGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.deleteResourceGroupButton.UseVisualStyleBackColor = true;
            this.deleteResourceGroupButton.Visible = false;
            this.deleteResourceGroupButton.Click += new System.EventHandler(this.deleteResourceGroupButton_Click);
            // 
            // editResourceGroupButton
            // 
            this.editResourceGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("editResourceGroupButton.Image")));
            this.editResourceGroupButton.Location = new System.Drawing.Point(352, 0);
            this.editResourceGroupButton.Name = "editResourceGroupButton";
            this.editResourceGroupButton.Size = new System.Drawing.Size(94, 23);
            this.editResourceGroupButton.TabIndex = 2;
            this.editResourceGroupButton.Text = "Edytuj grupę";
            this.editResourceGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.editResourceGroupButton.UseVisualStyleBackColor = true;
            this.editResourceGroupButton.Click += new System.EventHandler(this.editResourceGroupButton_Click);
            // 
            // addResourceGroupButton
            // 
            this.addResourceGroupButton.Image = ((System.Drawing.Image)(resources.GetObject("addResourceGroupButton.Image")));
            this.addResourceGroupButton.Location = new System.Drawing.Point(252, 0);
            this.addResourceGroupButton.Name = "addResourceGroupButton";
            this.addResourceGroupButton.Size = new System.Drawing.Size(94, 23);
            this.addResourceGroupButton.TabIndex = 1;
            this.addResourceGroupButton.Text = "Dodaj grupę";
            this.addResourceGroupButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.addResourceGroupButton.UseVisualStyleBackColor = true;
            this.addResourceGroupButton.Visible = false;
            this.addResourceGroupButton.Click += new System.EventHandler(this.addResourceGroupButton_Click);
            // 
            // ResourceGroupUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.saveResourceGroupButton);
            this.Controls.Add(this.permissionsDGV);
            this.Controls.Add(this.cancelResourceGroupButton);
            this.Controls.Add(this.groupsDGV);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.commentsRTB);
            this.Controls.Add(this.deletePermissionButton);
            this.Controls.Add(this.addPermissionButton);
            this.Controls.Add(this.isActiveCheckBox);
            this.Controls.Add(this.defualtPermissionLabel);
            this.Controls.Add(this.timeLimitLabel);
            this.Controls.Add(this.maxTimeTextBox);
            this.Controls.Add(this.groupNameLabel);
            this.Controls.Add(this.groupNameTextBox);
            this.Controls.Add(this.deleteResourceGroupButton);
            this.Controls.Add(this.editResourceGroupButton);
            this.Controls.Add(this.addResourceGroupButton);
            this.Name = "ResourceGroupUC";
            this.Size = new System.Drawing.Size(914, 463);
            ((System.ComponentModel.ISupportInitialize)(this.permissionsDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupsDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button saveResourceGroupButton;
        private System.Windows.Forms.DataGridView permissionsDGV;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupIdDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn syncIdGroupsDGVC;
        private System.Windows.Forms.Button cancelResourceGroupButton;
        private System.Windows.Forms.DataGridView groupsDGV;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.RichTextBox commentsRTB;
        private System.Windows.Forms.Button deletePermissionButton;
        private System.Windows.Forms.Button addPermissionButton;
        private System.Windows.Forms.CheckBox isActiveCheckBox;
        private System.Windows.Forms.Label defualtPermissionLabel;
        private System.Windows.Forms.Label timeLimitLabel;
        private System.Windows.Forms.TextBox maxTimeTextBox;
        private System.Windows.Forms.Label groupNameLabel;
        private System.Windows.Forms.TextBox groupNameTextBox;
        private System.Windows.Forms.Button deleteResourceGroupButton;
        private System.Windows.Forms.Button editResourceGroupButton;
        private System.Windows.Forms.Button addResourceGroupButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn syncIDDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn rightNameDGVC;
    }
}
