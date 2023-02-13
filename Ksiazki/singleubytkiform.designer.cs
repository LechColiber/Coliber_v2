namespace Ksiazki
{
    partial class SingleUbytkiForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleUbytkiForm));
            this.label1 = new System.Windows.Forms.Label();
            this.SygTextBox = new System.Windows.Forms.TextBox();
            this.NumInwTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.NrDowoduUbytkuTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.DateDTP = new System.Windows.Forms.DateTimePicker();
            this.label38 = new System.Windows.Forms.Label();
            this.NrKsUbytkowTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CommentsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.WykrComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sygnatura";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SygTextBox
            // 
            this.SygTextBox.Location = new System.Drawing.Point(123, 6);
            this.SygTextBox.MaxLength = 20;
            this.SygTextBox.Name = "SygTextBox";
            this.SygTextBox.ReadOnly = true;
            this.SygTextBox.Size = new System.Drawing.Size(236, 20);
            this.SygTextBox.TabIndex = 0;
            // 
            // NumInwTextBox
            // 
            this.NumInwTextBox.Location = new System.Drawing.Point(123, 32);
            this.NumInwTextBox.MaxLength = 20;
            this.NumInwTextBox.Name = "NumInwTextBox";
            this.NumInwTextBox.ReadOnly = true;
            this.NumInwTextBox.Size = new System.Drawing.Size(236, 20);
            this.NumInwTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numer inwentarzowy";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NrDowoduUbytkuTextBox
            // 
            this.NrDowoduUbytkuTextBox.Location = new System.Drawing.Point(123, 137);
            this.NrDowoduUbytkuTextBox.MaxLength = 10;
            this.NrDowoduUbytkuTextBox.Name = "NrDowoduUbytkuTextBox";
            this.NrDowoduUbytkuTextBox.Size = new System.Drawing.Size(236, 20);
            this.NrDowoduUbytkuTextBox.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(12, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nr dowodu ubytku";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Uwagi";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DateDTP
            // 
            this.DateDTP.Location = new System.Drawing.Point(123, 84);
            this.DateDTP.Name = "DateDTP";
            this.DateDTP.Size = new System.Drawing.Size(236, 20);
            this.DateDTP.TabIndex = 3;
            // 
            // label38
            // 
            this.label38.Location = new System.Drawing.Point(12, 87);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(105, 13);
            this.label38.TabIndex = 22;
            this.label38.Text = "Data";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NrKsUbytkowTextBox
            // 
            this.NrKsUbytkowTextBox.Location = new System.Drawing.Point(123, 58);
            this.NrKsUbytkowTextBox.MaxLength = 7;
            this.NrKsUbytkowTextBox.Name = "NrKsUbytkowTextBox";
            this.NrKsUbytkowTextBox.Size = new System.Drawing.Size(236, 20);
            this.NrKsUbytkowTextBox.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Nr księgi ubytków";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CommentsRichTextBox
            // 
            this.CommentsRichTextBox.Location = new System.Drawing.Point(123, 163);
            this.CommentsRichTextBox.MaxLength = 35;
            this.CommentsRichTextBox.Name = "CommentsRichTextBox";
            this.CommentsRichTextBox.Size = new System.Drawing.Size(236, 95);
            this.CommentsRichTextBox.TabIndex = 6;
            this.CommentsRichTextBox.Text = "";
            // 
            // WykrComboBox
            // 
            this.WykrComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WykrComboBox.FormattingEnabled = true;
            this.WykrComboBox.Location = new System.Drawing.Point(123, 110);
            this.WykrComboBox.Name = "WykrComboBox";
            this.WykrComboBox.Size = new System.Drawing.Size(236, 21);
            this.WykrComboBox.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 113);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 28;
            this.label6.Text = "Przyczyna wykreślenia";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OkButton
            // 
            this.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkButton.Image = global::Ksiazki.Properties.Resources.Check2;
            this.OkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkButton.Location = new System.Drawing.Point(96, 271);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(88, 23);
            this.OkButton.TabIndex = 7;
            this.OkButton.Text = "    Zatwierdź ";
            this.OkButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancButton
            // 
            this.CancButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancButton.Image = global::Ksiazki.Properties.Resources.fileclose;
            this.CancButton.Location = new System.Drawing.Point(190, 271);
            this.CancButton.Name = "CancButton";
            this.CancButton.Size = new System.Drawing.Size(88, 23);
            this.CancButton.TabIndex = 8;
            this.CancButton.Text = "Anuluj";
            this.CancButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancButton.UseVisualStyleBackColor = true;
            this.CancButton.Click += new System.EventHandler(this.CancButton_Click);
            // 
            // SingleUbytkiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 306);
            this.Controls.Add(this.CancButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.WykrComboBox);
            this.Controls.Add(this.CommentsRichTextBox);
            this.Controls.Add(this.NrKsUbytkowTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.DateDTP);
            this.Controls.Add(this.label38);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.NrDowoduUbytkuTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.NumInwTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SygTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SingleUbytkiForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pojedyncza pozycja w księdze ubytków";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SingleUbytkiForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox SygTextBox;
        private System.Windows.Forms.TextBox NumInwTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NrDowoduUbytkuTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker DateDTP;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox NrKsUbytkowTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox CommentsRichTextBox;
        private System.Windows.Forms.ComboBox WykrComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancButton;
    }
}