namespace Czasopisma
{
    partial class DetailsChangeTitleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsChangeTitleForm));
            this.EscapeButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.toYearNumberLabel = new System.Windows.Forms.Label();
            this.YearTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NumberTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Number2TextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Year2TextBox = new System.Windows.Forms.TextBox();
            this.sinceYearNumberLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = ((System.Drawing.Image)(resources.GetObject("EscapeButton.Image")));
            this.EscapeButton.Location = new System.Drawing.Point(195, 279);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(88, 23);
            this.EscapeButton.TabIndex = 1;
            this.EscapeButton.Text = "Anuluj";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = ((System.Drawing.Image)(resources.GetObject("OkButton.Image")));
            this.OkButton.Location = new System.Drawing.Point(101, 279);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(88, 23);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Zatwierdź";
            this.OkButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // toYearNumberLabel
            // 
            this.toYearNumberLabel.AutoSize = true;
            this.toYearNumberLabel.Location = new System.Drawing.Point(12, 18);
            this.toYearNumberLabel.Name = "toYearNumberLabel";
            this.toYearNumberLabel.Size = new System.Drawing.Size(85, 13);
            this.toYearNumberLabel.TabIndex = 2;
            this.toYearNumberLabel.Text = "Do roku/numeru";
            // 
            // YearTextBox
            // 
            this.YearTextBox.Location = new System.Drawing.Point(103, 15);
            this.YearTextBox.MaxLength = 4;
            this.YearTextBox.Name = "YearTextBox";
            this.YearTextBox.Size = new System.Drawing.Size(53, 20);
            this.YearTextBox.TabIndex = 3;
            this.YearTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.YearTextBox.TextChanged += new System.EventHandler(this.YearTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(162, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "/";
            // 
            // NumberTextBox
            // 
            this.NumberTextBox.Location = new System.Drawing.Point(180, 15);
            this.NumberTextBox.MaxLength = 6;
            this.NumberTextBox.Name = "NumberTextBox";
            this.NumberTextBox.Size = new System.Drawing.Size(53, 20);
            this.NumberTextBox.TabIndex = 5;
            this.NumberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NumberTextBox.TextChanged += new System.EventHandler(this.NumberTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(239, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "pt.:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(239, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(22, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "pt.:";
            // 
            // Number2TextBox
            // 
            this.Number2TextBox.Location = new System.Drawing.Point(180, 150);
            this.Number2TextBox.MaxLength = 6;
            this.Number2TextBox.Name = "Number2TextBox";
            this.Number2TextBox.Size = new System.Drawing.Size(53, 20);
            this.Number2TextBox.TabIndex = 10;
            this.Number2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Number2TextBox.TextChanged += new System.EventHandler(this.Number2TextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(162, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "/";
            // 
            // Year2TextBox
            // 
            this.Year2TextBox.Location = new System.Drawing.Point(103, 150);
            this.Year2TextBox.MaxLength = 4;
            this.Year2TextBox.Name = "Year2TextBox";
            this.Year2TextBox.Size = new System.Drawing.Size(53, 20);
            this.Year2TextBox.TabIndex = 8;
            this.Year2TextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Year2TextBox.TextChanged += new System.EventHandler(this.Year2TextBox_TextChanged);
            // 
            // sinceYearNumberLabel
            // 
            this.sinceYearNumberLabel.AutoSize = true;
            this.sinceYearNumberLabel.Location = new System.Drawing.Point(12, 153);
            this.sinceYearNumberLabel.Name = "sinceYearNumberLabel";
            this.sinceYearNumberLabel.Size = new System.Drawing.Size(85, 13);
            this.sinceYearNumberLabel.TabIndex = 7;
            this.sinceYearNumberLabel.Text = "Od roku/numeru";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(15, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(357, 89);
            this.richTextBox1.TabIndex = 12;
            this.richTextBox1.Text = "";
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(12, 176);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(357, 89);
            this.richTextBox2.TabIndex = 13;
            this.richTextBox2.Text = "";
            // 
            // DetailsChangeTitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 314);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Number2TextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Year2TextBox);
            this.Controls.Add(this.sinceYearNumberLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumberTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.YearTextBox);
            this.Controls.Add(this.toYearNumberLabel);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.OkButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "DetailsChangeTitleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Szczegóły zmiany tytułu";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DetailsChangeTitleForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Label toYearNumberLabel;
        private System.Windows.Forms.TextBox YearTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NumberTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Number2TextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Year2TextBox;
        private System.Windows.Forms.Label sinceYearNumberLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RichTextBox richTextBox2;
    }
}