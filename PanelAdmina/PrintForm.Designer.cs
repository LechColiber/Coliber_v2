namespace WindowsFormsApplication1
{
    partial class PrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintForm));
            this.allAuthorsRadioButton = new System.Windows.Forms.RadioButton();
            this.authorsRadioButton = new System.Windows.Forms.RadioButton();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // allAuthorsRadioButton
            // 
            this.allAuthorsRadioButton.AutoSize = true;
            this.allAuthorsRadioButton.Location = new System.Drawing.Point(45, 39);
            this.allAuthorsRadioButton.Name = "allAuthorsRadioButton";
            this.allAuthorsRadioButton.Size = new System.Drawing.Size(164, 17);
            this.allAuthorsRadioButton.TabIndex = 0;
            this.allAuthorsRadioButton.Text = "Autorzy ze wszystkich opisów";
            this.allAuthorsRadioButton.UseVisualStyleBackColor = true;
            // 
            // authorsRadioButton
            // 
            this.authorsRadioButton.AutoSize = true;
            this.authorsRadioButton.Checked = true;
            this.authorsRadioButton.Location = new System.Drawing.Point(45, 16);
            this.authorsRadioButton.Name = "authorsRadioButton";
            this.authorsRadioButton.Size = new System.Drawing.Size(115, 17);
            this.authorsRadioButton.TabIndex = 1;
            this.authorsRadioButton.TabStop = true;
            this.authorsRadioButton.Text = "Autorzy z ewidencji";
            this.authorsRadioButton.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::WindowsFormsApplication1.Properties.Resources.door_out;
            this.ExitButton.Location = new System.Drawing.Point(166, 70);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(106, 30);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Image = global::WindowsFormsApplication1.Properties.Resources.print_printer;
            this.PrintButton.Location = new System.Drawing.Point(45, 70);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(106, 30);
            this.PrintButton.TabIndex = 7;
            this.PrintButton.Text = "Drukuj";
            this.PrintButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.PrintButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 114);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.authorsRadioButton);
            this.Controls.Add(this.allAuthorsRadioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drukowanie";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrintForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton allAuthorsRadioButton;
        private System.Windows.Forms.RadioButton authorsRadioButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button PrintButton;
    }
}