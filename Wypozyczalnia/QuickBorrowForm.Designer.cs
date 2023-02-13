namespace Wypozyczalnia
{
    partial class QuickBorrowForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickBorrowForm));
            this.resourceCritLabel = new System.Windows.Forms.Label();
            this.resourceCritTextBox = new System.Windows.Forms.TextBox();
            this.resourceRTB = new System.Windows.Forms.RichTextBox();
            this.searchUserTextBox = new System.Windows.Forms.TextBox();
            this.userBarcodeLabel = new System.Windows.Forms.Label();
            this.selectResourceButton = new System.Windows.Forms.Button();
            this.cleanResourceButton = new System.Windows.Forms.Button();
            this.cleanUserButton = new System.Windows.Forms.Button();
            this.selectUserButton = new System.Windows.Forms.Button();
            this.borrowButton = new System.Windows.Forms.Button();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.userCardButton = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // resourceCritLabel
            // 
            this.resourceCritLabel.Location = new System.Drawing.Point(2, 7);
            this.resourceCritLabel.Name = "resourceCritLabel";
            this.resourceCritLabel.Size = new System.Drawing.Size(143, 23);
            this.resourceCritLabel.TabIndex = 0;
            this.resourceCritLabel.Text = "Kod kreskowy zasobu:";
            this.resourceCritLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // resourceCritTextBox
            // 
            this.resourceCritTextBox.Location = new System.Drawing.Point(151, 9);
            this.resourceCritTextBox.Name = "resourceCritTextBox";
            this.resourceCritTextBox.Size = new System.Drawing.Size(333, 20);
            this.resourceCritTextBox.TabIndex = 1;
            this.resourceCritTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.resourceBarcodeTextBox_KeyDown);
            // 
            // resourceRTB
            // 
            this.resourceRTB.Location = new System.Drawing.Point(151, 36);
            this.resourceRTB.Name = "resourceRTB";
            this.resourceRTB.ReadOnly = true;
            this.resourceRTB.Size = new System.Drawing.Size(333, 96);
            this.resourceRTB.TabIndex = 2;
            this.resourceRTB.Text = "";
            // 
            // searchUserTextBox
            // 
            this.searchUserTextBox.Location = new System.Drawing.Point(151, 138);
            this.searchUserTextBox.Name = "searchUserTextBox";
            this.searchUserTextBox.Size = new System.Drawing.Size(333, 20);
            this.searchUserTextBox.TabIndex = 4;
            this.searchUserTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.userBarcodeTextBox_KeyDown);
            // 
            // userBarcodeLabel
            // 
            this.userBarcodeLabel.Location = new System.Drawing.Point(5, 141);
            this.userBarcodeLabel.Name = "userBarcodeLabel";
            this.userBarcodeLabel.Size = new System.Drawing.Size(146, 13);
            this.userBarcodeLabel.TabIndex = 3;
            this.userBarcodeLabel.Text = "Kod kreskowy użytkownika:";
            this.userBarcodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // selectResourceButton
            // 
            this.selectResourceButton.Image = ((System.Drawing.Image)(resources.GetObject("selectResourceButton.Image")));
            this.selectResourceButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.selectResourceButton.Location = new System.Drawing.Point(490, 7);
            this.selectResourceButton.Name = "selectResourceButton";
            this.selectResourceButton.Size = new System.Drawing.Size(27, 23);
            this.selectResourceButton.TabIndex = 5;
            this.selectResourceButton.TabStop = false;
            this.selectResourceButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectResourceButton.UseVisualStyleBackColor = true;
            this.selectResourceButton.Click += new System.EventHandler(this.selectResourceButton_Click);
            // 
            // cleanResourceButton
            // 
            this.cleanResourceButton.Image = ((System.Drawing.Image)(resources.GetObject("cleanResourceButton.Image")));
            this.cleanResourceButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cleanResourceButton.Location = new System.Drawing.Point(523, 7);
            this.cleanResourceButton.Name = "cleanResourceButton";
            this.cleanResourceButton.Size = new System.Drawing.Size(27, 23);
            this.cleanResourceButton.TabIndex = 6;
            this.cleanResourceButton.TabStop = false;
            this.cleanResourceButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cleanResourceButton.UseVisualStyleBackColor = true;
            this.cleanResourceButton.Click += new System.EventHandler(this.cleanResourceButton_Click);
            // 
            // cleanUserButton
            // 
            this.cleanUserButton.Image = ((System.Drawing.Image)(resources.GetObject("cleanUserButton.Image")));
            this.cleanUserButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cleanUserButton.Location = new System.Drawing.Point(556, 137);
            this.cleanUserButton.Name = "cleanUserButton";
            this.cleanUserButton.Size = new System.Drawing.Size(27, 23);
            this.cleanUserButton.TabIndex = 8;
            this.cleanUserButton.TabStop = false;
            this.cleanUserButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cleanUserButton.UseVisualStyleBackColor = true;
            this.cleanUserButton.Click += new System.EventHandler(this.cleanUserButton_Click);
            // 
            // selectUserButton
            // 
            this.selectUserButton.Image = ((System.Drawing.Image)(resources.GetObject("selectUserButton.Image")));
            this.selectUserButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.selectUserButton.Location = new System.Drawing.Point(490, 137);
            this.selectUserButton.Name = "selectUserButton";
            this.selectUserButton.Size = new System.Drawing.Size(27, 23);
            this.selectUserButton.TabIndex = 7;
            this.selectUserButton.TabStop = false;
            this.selectUserButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.selectUserButton.UseVisualStyleBackColor = true;
            this.selectUserButton.Click += new System.EventHandler(this.selectUserButton_Click);
            // 
            // borrowButton
            // 
            this.borrowButton.Enabled = false;
            this.borrowButton.Location = new System.Drawing.Point(235, 208);
            this.borrowButton.Name = "borrowButton";
            this.borrowButton.Size = new System.Drawing.Size(75, 23);
            this.borrowButton.TabIndex = 9;
            this.borrowButton.Text = "Wypożycz";
            this.borrowButton.UseVisualStyleBackColor = true;
            this.borrowButton.Click += new System.EventHandler(this.borrowButton_Click);
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(151, 164);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.ReadOnly = true;
            this.userTextBox.Size = new System.Drawing.Size(333, 20);
            this.userTextBox.TabIndex = 10;
            this.userTextBox.TabStop = false;
            // 
            // userCardButton
            // 
            this.userCardButton.Enabled = false;
            this.userCardButton.Image = ((System.Drawing.Image)(resources.GetObject("userCardButton.Image")));
            this.userCardButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.userCardButton.Location = new System.Drawing.Point(523, 137);
            this.userCardButton.Name = "userCardButton";
            this.userCardButton.Size = new System.Drawing.Size(27, 23);
            this.userCardButton.TabIndex = 11;
            this.userCardButton.TabStop = false;
            this.userCardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.userCardButton.UseVisualStyleBackColor = true;
            this.userCardButton.Click += new System.EventHandler(this.userCardButton_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.Location = new System.Drawing.Point(18, 40);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(118, 90);
            this.lbInfo.TabIndex = 12;
            // 
            // QuickBorrowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 242);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.userCardButton);
            this.Controls.Add(this.userTextBox);
            this.Controls.Add(this.borrowButton);
            this.Controls.Add(this.cleanUserButton);
            this.Controls.Add(this.selectUserButton);
            this.Controls.Add(this.cleanResourceButton);
            this.Controls.Add(this.selectResourceButton);
            this.Controls.Add(this.searchUserTextBox);
            this.Controls.Add(this.userBarcodeLabel);
            this.Controls.Add(this.resourceRTB);
            this.Controls.Add(this.resourceCritTextBox);
            this.Controls.Add(this.resourceCritLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "QuickBorrowForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Szybkie wypożyczenie";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.QuickBorrowForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resourceCritLabel;
        private System.Windows.Forms.TextBox resourceCritTextBox;
        private System.Windows.Forms.RichTextBox resourceRTB;
        private System.Windows.Forms.TextBox searchUserTextBox;
        private System.Windows.Forms.Label userBarcodeLabel;
        private System.Windows.Forms.Button selectResourceButton;
        private System.Windows.Forms.Button cleanResourceButton;
        private System.Windows.Forms.Button cleanUserButton;
        private System.Windows.Forms.Button selectUserButton;
        private System.Windows.Forms.Button borrowButton;
        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.Button userCardButton;
        private System.Windows.Forms.Label lbInfo;
    }
}