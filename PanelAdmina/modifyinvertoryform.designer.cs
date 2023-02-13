namespace WindowsFormsApplication1
{
    partial class ModifyInvertoryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyInvertoryForm));
            this.label1 = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.descTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(100, 12);
            this.NameTextBox.MaxLength = 50;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(360, 20);
            this.NameTextBox.TabIndex = 1;
            // 
            // descTextBox
            // 
            this.descTextBox.Location = new System.Drawing.Point(100, 38);
            this.descTextBox.MaxLength = 150;
            this.descTextBox.Name = "descTextBox";
            this.descTextBox.Size = new System.Drawing.Size(360, 20);
            this.descTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Opis";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = global::WindowsFormsApplication1.Properties.Resources.fileclose1;
            this.EscapeButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EscapeButton.Location = new System.Drawing.Point(237, 64);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(90, 29);
            this.EscapeButton.TabIndex = 42;
            this.EscapeButton.Text = "    Anuluj";
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Image = global::WindowsFormsApplication1.Properties.Resources.Check2;
            this.OKButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OKButton.Location = new System.Drawing.Point(141, 64);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(90, 29);
            this.OKButton.TabIndex = 41;
            this.OKButton.Text = "Zatwierdź";
            this.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // ModifyInvertoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 101);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.descTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ModifyInvertoryForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Księga inwentarzowa";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DistributorForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox descTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button OKButton;
    }
}