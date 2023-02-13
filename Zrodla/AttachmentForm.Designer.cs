namespace Zrodla
{
    partial class AttachmentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttachmentForm));
            this.FileNameLabel = new System.Windows.Forms.Label();
            this.AttachButton = new System.Windows.Forms.Button();
            this.FileNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.URLLabel = new System.Windows.Forms.Label();
            this.CommentsTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FileNameLabel
            // 
            this.FileNameLabel.Location = new System.Drawing.Point(12, 20);
            this.FileNameLabel.Name = "FileNameLabel";
            this.FileNameLabel.Size = new System.Drawing.Size(62, 13);
            this.FileNameLabel.TabIndex = 0;
            this.FileNameLabel.Text = "Plik";
            // 
            // AttachButton
            // 
            this.AttachButton.Location = new System.Drawing.Point(42, 15);
            this.AttachButton.Name = "AttachButton";
            this.AttachButton.Size = new System.Drawing.Size(32, 23);
            this.AttachButton.TabIndex = 5;
            this.AttachButton.Text = "...";
            this.AttachButton.UseVisualStyleBackColor = true;
            this.AttachButton.Click += new System.EventHandler(this.AttachButton_Click);
            // 
            // FileNameTextBox
            // 
            this.FileNameTextBox.Location = new System.Drawing.Point(80, 17);
            this.FileNameTextBox.Name = "FileNameTextBox";
            this.FileNameTextBox.ReadOnly = true;
            this.FileNameTextBox.Size = new System.Drawing.Size(342, 20);
            this.FileNameTextBox.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Uwagi";
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Image = ((System.Drawing.Image)(resources.GetObject("OKButton.Image")));
            this.OKButton.Location = new System.Drawing.Point(139, 251);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "Zapisz";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Image = ((System.Drawing.Image)(resources.GetObject("CancelButton.Image")));
            this.CancelButton.Location = new System.Drawing.Point(220, 251);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // URLTextBox
            // 
            this.URLTextBox.Location = new System.Drawing.Point(80, 43);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(342, 20);
            this.URLTextBox.TabIndex = 1;
            // 
            // URLLabel
            // 
            this.URLLabel.Location = new System.Drawing.Point(12, 46);
            this.URLLabel.Name = "URLLabel";
            this.URLLabel.Size = new System.Drawing.Size(62, 13);
            this.URLLabel.TabIndex = 7;
            this.URLLabel.Text = "Adres URL";
            // 
            // CommentsTextBox
            // 
            this.CommentsTextBox.Location = new System.Drawing.Point(80, 69);
            this.CommentsTextBox.MaxLength = 400;
            this.CommentsTextBox.Multiline = true;
            this.CommentsTextBox.Name = "CommentsTextBox";
            this.CommentsTextBox.Size = new System.Drawing.Size(342, 165);
            this.CommentsTextBox.TabIndex = 2;
            // 
            // AttachmentForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 286);
            this.Controls.Add(this.CommentsTextBox);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.URLLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FileNameTextBox);
            this.Controls.Add(this.AttachButton);
            this.Controls.Add(this.FileNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "AttachmentForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Załączanie pliku";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AttachmentForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label FileNameLabel;
        private System.Windows.Forms.Button AttachButton;
        private System.Windows.Forms.TextBox FileNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.Label URLLabel;
        private System.Windows.Forms.TextBox CommentsTextBox;
    }
}