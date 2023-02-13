namespace WindowsFormsApplication1
{
    partial class ModifySortOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifySortOrderForm));
            this.OkButton = new System.Windows.Forms.Button();
            this.StringTextBox = new System.Windows.Forms.TextBox();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // OkButton
            // 
            this.OkButton.Image = global::WindowsFormsApplication1.Properties.Resources.Check2;
            this.OkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkButton.Location = new System.Drawing.Point(52, 59);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(87, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "Zatwierdź";
            this.OkButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // StringTextBox
            // 
            this.StringTextBox.Location = new System.Drawing.Point(12, 21);
            this.StringTextBox.MaxLength = 10;
            this.StringTextBox.Name = "StringTextBox";
            this.StringTextBox.Size = new System.Drawing.Size(260, 20);
            this.StringTextBox.TabIndex = 0;
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = global::WindowsFormsApplication1.Properties.Resources.fileclose1;
            this.EscapeButton.Location = new System.Drawing.Point(145, 59);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(87, 23);
            this.EscapeButton.TabIndex = 2;
            this.EscapeButton.Text = "Anuluj";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // ModifySortOrderForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 93);
            this.Controls.Add(this.StringTextBox);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModifySortOrderForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ModifySortOrderForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.TextBox StringTextBox;
    }
}