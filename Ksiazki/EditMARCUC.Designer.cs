namespace Ksiazki
{
    partial class EditMARCUC
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
            this.TagComboBox = new System.Windows.Forms.ComboBox();
            this.Ind1TextBox = new System.Windows.Forms.TextBox();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.Ind2TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TagComboBox
            // 
            this.TagComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TagComboBox.FormattingEnabled = true;
            this.TagComboBox.Location = new System.Drawing.Point(6, 6);
            this.TagComboBox.Name = "TagComboBox";
            this.TagComboBox.Size = new System.Drawing.Size(48, 21);
            this.TagComboBox.TabIndex = 8;
            // 
            // Ind1TextBox
            // 
            this.Ind1TextBox.Location = new System.Drawing.Point(69, 6);
            this.Ind1TextBox.Name = "Ind1TextBox";
            this.Ind1TextBox.Size = new System.Drawing.Size(20, 20);
            this.Ind1TextBox.TabIndex = 13;
            this.Ind1TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ValueTextBox.Location = new System.Drawing.Point(139, 6);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.Size = new System.Drawing.Size(182, 20);
            this.ValueTextBox.TabIndex = 15;
            // 
            // Ind2TextBox
            // 
            this.Ind2TextBox.Location = new System.Drawing.Point(104, 6);
            this.Ind2TextBox.Name = "Ind2TextBox";
            this.Ind2TextBox.Size = new System.Drawing.Size(20, 20);
            this.Ind2TextBox.TabIndex = 14;
            this.Ind2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EditMARCUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TagComboBox);
            this.Controls.Add(this.Ind1TextBox);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.Ind2TextBox);
            this.Name = "EditMARCUC";
            this.Size = new System.Drawing.Size(324, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox TagComboBox;
        private System.Windows.Forms.TextBox Ind1TextBox;
        private System.Windows.Forms.TextBox ValueTextBox;
        private System.Windows.Forms.TextBox Ind2TextBox;
    }
}
