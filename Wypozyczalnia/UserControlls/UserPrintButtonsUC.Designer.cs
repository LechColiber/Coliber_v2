namespace Wypozyczalnia
{
    partial class UserPrintButtonsUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPrintButtonsUC));
            this.printHistoryButton = new System.Windows.Forms.Button();
            this.printBorrowsButton = new System.Windows.Forms.Button();
            this.printReminderButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // printHistoryButton
            // 
            this.printHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.printHistoryButton.Enabled = false;
            this.printHistoryButton.Image = ((System.Drawing.Image)(resources.GetObject("printHistoryButton.Image")));
            this.printHistoryButton.Location = new System.Drawing.Point(372, 0);
            this.printHistoryButton.Name = "printHistoryButton";
            this.printHistoryButton.Size = new System.Drawing.Size(180, 23);
            this.printHistoryButton.TabIndex = 2;
            this.printHistoryButton.Text = "Drukuj historię wypożyczeń";
            this.printHistoryButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printHistoryButton.UseVisualStyleBackColor = true;
            this.printHistoryButton.Click += new System.EventHandler(this.printHistoryButton_Click);
            // 
            // printBorrowsButton
            // 
            this.printBorrowsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.printBorrowsButton.Enabled = false;
            this.printBorrowsButton.Image = ((System.Drawing.Image)(resources.GetObject("printBorrowsButton.Image")));
            this.printBorrowsButton.Location = new System.Drawing.Point(186, 0);
            this.printBorrowsButton.Name = "printBorrowsButton";
            this.printBorrowsButton.Size = new System.Drawing.Size(180, 23);
            this.printBorrowsButton.TabIndex = 1;
            this.printBorrowsButton.Text = "Drukuj aktualne wypożyczenia";
            this.printBorrowsButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printBorrowsButton.UseVisualStyleBackColor = true;
            this.printBorrowsButton.Click += new System.EventHandler(this.printBorrowsButton_Click);
            // 
            // printReminderButton
            // 
            this.printReminderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.printReminderButton.Enabled = false;
            this.printReminderButton.Image = ((System.Drawing.Image)(resources.GetObject("printReminderButton.Image")));
            this.printReminderButton.Location = new System.Drawing.Point(0, 0);
            this.printReminderButton.Name = "printReminderButton";
            this.printReminderButton.Size = new System.Drawing.Size(180, 23);
            this.printReminderButton.TabIndex = 0;
            this.printReminderButton.Text = "Drukuj upomnienia zbiorcze";
            this.printReminderButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.printReminderButton.UseVisualStyleBackColor = true;
            this.printReminderButton.Click += new System.EventHandler(this.printReminderButton_Click);
            // 
            // UserPrintButtonsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.printHistoryButton);
            this.Controls.Add(this.printBorrowsButton);
            this.Controls.Add(this.printReminderButton);
            this.Name = "UserPrintButtonsUC";
            this.Size = new System.Drawing.Size(554, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button printHistoryButton;
        private System.Windows.Forms.Button printBorrowsButton;
        private System.Windows.Forms.Button printReminderButton;
    }
}
