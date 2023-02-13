namespace WindowsFormsApplication1
{
    partial class SelectTableForKeys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectTableForKeys));
            this.ExitButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.MagazinesRadioButton = new System.Windows.Forms.RadioButton();
            this.BooksRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ArticlesRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::WindowsFormsApplication1.Properties.Resources.fileclose1;
            this.ExitButton.Location = new System.Drawing.Point(145, 128);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(106, 30);
            this.ExitButton.TabIndex = 9;
            this.ExitButton.Text = "Anuluj";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = global::WindowsFormsApplication1.Properties.Resources.Check2;
            this.OkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkButton.Location = new System.Drawing.Point(33, 128);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(106, 30);
            this.OkButton.TabIndex = 8;
            this.OkButton.Text = "    Wybierz";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MagazinesRadioButton
            // 
            this.MagazinesRadioButton.AutoSize = true;
            this.MagazinesRadioButton.Location = new System.Drawing.Point(28, 47);
            this.MagazinesRadioButton.Name = "MagazinesRadioButton";
            this.MagazinesRadioButton.Size = new System.Drawing.Size(81, 17);
            this.MagazinesRadioButton.TabIndex = 6;
            this.MagazinesRadioButton.Text = "Czasopisma";
            this.MagazinesRadioButton.UseVisualStyleBackColor = true;
            // 
            // BooksRadioButton
            // 
            this.BooksRadioButton.AutoSize = true;
            this.BooksRadioButton.Location = new System.Drawing.Point(28, 70);
            this.BooksRadioButton.Name = "BooksRadioButton";
            this.BooksRadioButton.Size = new System.Drawing.Size(58, 17);
            this.BooksRadioButton.TabIndex = 5;
            this.BooksRadioButton.Text = "Książki";
            this.BooksRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ArticlesRadioButton);
            this.groupBox1.Controls.Add(this.BooksRadioButton);
            this.groupBox1.Controls.Add(this.MagazinesRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(33, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 99);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Klucze dla bazy:";
            // 
            // ArticlesRadioButton
            // 
            this.ArticlesRadioButton.AutoSize = true;
            this.ArticlesRadioButton.Checked = true;
            this.ArticlesRadioButton.Location = new System.Drawing.Point(28, 24);
            this.ArticlesRadioButton.Name = "ArticlesRadioButton";
            this.ArticlesRadioButton.Size = new System.Drawing.Size(64, 17);
            this.ArticlesRadioButton.TabIndex = 11;
            this.ArticlesRadioButton.TabStop = true;
            this.ArticlesRadioButton.Text = "Artykuły";
            this.ArticlesRadioButton.UseVisualStyleBackColor = true;
            // 
            // SelectTableForKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 170);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SelectTableForKeys";
            this.ShowInTaskbar = false;
            this.Text = "Wybór bazy";
            this.Load += new System.EventHandler(this.SelectTableForKeys_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectTableForKeys_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.RadioButton MagazinesRadioButton;
        private System.Windows.Forms.RadioButton BooksRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton ArticlesRadioButton;
    }
}