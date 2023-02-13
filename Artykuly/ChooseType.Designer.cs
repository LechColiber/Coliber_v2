namespace Artykuly
{
    partial class ChooseType
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseType));
            this.MagazineButton = new System.Windows.Forms.Button();
            this.BookButton = new System.Windows.Forms.Button();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MagazineButton
            // 
            this.MagazineButton.Location = new System.Drawing.Point(65, 12);
            this.MagazineButton.Name = "MagazineButton";
            this.MagazineButton.Size = new System.Drawing.Size(135, 23);
            this.MagazineButton.TabIndex = 0;
            this.MagazineButton.Text = "Z czasopisma";
            this.MagazineButton.UseVisualStyleBackColor = true;
            this.MagazineButton.Click += new System.EventHandler(this.MagazineButton_Click);
            // 
            // BookButton
            // 
            this.BookButton.Location = new System.Drawing.Point(65, 41);
            this.BookButton.Name = "BookButton";
            this.BookButton.Size = new System.Drawing.Size(135, 23);
            this.BookButton.TabIndex = 1;
            this.BookButton.Text = "Z książki";
            this.BookButton.UseVisualStyleBackColor = true;
            this.BookButton.Click += new System.EventHandler(this.BookButton_Click);
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = global::Artykuly.Properties.Resources.door_out;
            this.EscapeButton.Location = new System.Drawing.Point(167, 73);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(85, 23);
            this.EscapeButton.TabIndex = 2;
            this.EscapeButton.Text = "Wyjście";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // ChooseType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 108);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.BookButton);
            this.Controls.Add(this.MagazineButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseType";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dodawanie artykułu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseType_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MagazineButton;
        private System.Windows.Forms.Button BookButton;
        private System.Windows.Forms.Button EscapeButton;
    }
}