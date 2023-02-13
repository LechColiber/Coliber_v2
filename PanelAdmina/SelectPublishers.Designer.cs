namespace WindowsFormsApplication1
{
    partial class SelectPublishers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectPublishers));
            this.BooksRadioButton = new System.Windows.Forms.RadioButton();
            this.MagazinesRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BooksRadioButton
            // 
            this.BooksRadioButton.AutoSize = true;
            this.BooksRadioButton.Location = new System.Drawing.Point(56, 66);
            this.BooksRadioButton.Name = "BooksRadioButton";
            this.BooksRadioButton.Size = new System.Drawing.Size(58, 17);
            this.BooksRadioButton.TabIndex = 0;
            this.BooksRadioButton.Text = "Książki";
            this.BooksRadioButton.UseVisualStyleBackColor = true;
            // 
            // MagazinesRadioButton
            // 
            this.MagazinesRadioButton.AutoSize = true;
            this.MagazinesRadioButton.Checked = true;
            this.MagazinesRadioButton.Location = new System.Drawing.Point(56, 42);
            this.MagazinesRadioButton.Name = "MagazinesRadioButton";
            this.MagazinesRadioButton.Size = new System.Drawing.Size(81, 17);
            this.MagazinesRadioButton.TabIndex = 1;
            this.MagazinesRadioButton.TabStop = true;
            this.MagazinesRadioButton.Text = "Czasopisma";
            this.MagazinesRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(24, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Wydawcy dla bazy:";
            // 
            // OkButton
            // 
            this.OkButton.Image = global::WindowsFormsApplication1.Properties.Resources.Check2;
            this.OkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkButton.Location = new System.Drawing.Point(24, 107);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(106, 30);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "    Wybierz";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::WindowsFormsApplication1.Properties.Resources.fileclose1;
            this.ExitButton.Location = new System.Drawing.Point(136, 107);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(106, 30);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Anuluj";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SelectPublishers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(266, 151);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.MagazinesRadioButton);
            this.Controls.Add(this.BooksRadioButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "SelectPublishers";
            this.ShowInTaskbar = false;
            this.Text = "Wybór bazy";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectPublishers_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton BooksRadioButton;
        private System.Windows.Forms.RadioButton MagazinesRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button ExitButton;
    }
}