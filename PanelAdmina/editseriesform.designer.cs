namespace WindowsFormsApplication1
{
    partial class EditSeriesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditSeriesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.ISSNTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.InstTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.PlaceTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.KindComboBox = new System.Windows.Forms.ComboBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tytuł serii";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(122, 11);
            this.TitleTextBox.MaxLength = 201;
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(354, 20);
            this.TitleTextBox.TabIndex = 1;
            // 
            // ISSNTextBox
            // 
            this.ISSNTextBox.Location = new System.Drawing.Point(122, 37);
            this.ISSNTextBox.MaxLength = 16;
            this.ISSNTextBox.Name = "ISSNTextBox";
            this.ISSNTextBox.Size = new System.Drawing.Size(354, 20);
            this.ISSNTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "ISSN";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InstTextBox
            // 
            this.InstTextBox.Location = new System.Drawing.Point(122, 63);
            this.InstTextBox.MaxLength = 120;
            this.InstTextBox.Name = "InstTextBox";
            this.InstTextBox.Size = new System.Drawing.Size(354, 20);
            this.InstTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Instytucja serii";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PlaceTextBox
            // 
            this.PlaceTextBox.Location = new System.Drawing.Point(122, 89);
            this.PlaceTextBox.MaxLength = 20;
            this.PlaceTextBox.Name = "PlaceTextBox";
            this.PlaceTextBox.Size = new System.Drawing.Size(354, 20);
            this.PlaceTextBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(10, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Siedziba serii";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(10, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Księgozbiór";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // KindComboBox
            // 
            this.KindComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KindComboBox.FormattingEnabled = true;
            this.KindComboBox.Location = new System.Drawing.Point(122, 115);
            this.KindComboBox.Name = "KindComboBox";
            this.KindComboBox.Size = new System.Drawing.Size(354, 21);
            this.KindComboBox.TabIndex = 13;
            this.KindComboBox.Visible = false;
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::WindowsFormsApplication1.Properties.Resources.fileclose1;
            this.CancelButton.Location = new System.Drawing.Point(253, 135);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(106, 30);
            this.CancelButton.TabIndex = 15;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Image = global::WindowsFormsApplication1.Properties.Resources.Check2;
            this.OkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkButton.Location = new System.Drawing.Point(130, 135);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(106, 30);
            this.OkButton.TabIndex = 14;
            this.OkButton.Text = "    Zatwierdź";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // EditSeriesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 173);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.KindComboBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.PlaceTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.InstTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ISSNTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "EditSeriesForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditSeriesForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditSeriesForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.TextBox ISSNTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox InstTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PlaceTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox KindComboBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
    }
}