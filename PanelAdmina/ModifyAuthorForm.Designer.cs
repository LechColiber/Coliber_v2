namespace WindowsFormsApplication1
{
	partial class ModifyAuthorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyAuthorForm));
            this.label1 = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RodzajComboBox = new System.Windows.Forms.ComboBox();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Imię";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(68, 17);
            this.FirstNameTextBox.MaxLength = 50;
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(173, 20);
            this.FirstNameTextBox.TabIndex = 1;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(68, 43);
            this.NameTextBox.MaxLength = 100;
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(173, 20);
            this.NameTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nazwisko";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Księgozbiór";
            this.label3.Visible = false;
            // 
            // RodzajComboBox
            // 
            this.RodzajComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RodzajComboBox.FormattingEnabled = true;
            this.RodzajComboBox.Location = new System.Drawing.Point(68, 70);
            this.RodzajComboBox.Name = "RodzajComboBox";
            this.RodzajComboBox.Size = new System.Drawing.Size(173, 21);
            this.RodzajComboBox.TabIndex = 5;
            this.RodzajComboBox.Visible = false;
            // 
            // OkButton
            // 
            this.OkButton.Image = global::WindowsFormsApplication1.Properties.Resources.Check2;
            this.OkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OkButton.Location = new System.Drawing.Point(15, 92);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(106, 30);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "     Zatwierdź";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Image = global::WindowsFormsApplication1.Properties.Resources.fileclose1;
            this.CancelButton.Location = new System.Drawing.Point(138, 92);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(106, 30);
            this.CancelButton.TabIndex = 7;
            this.CancelButton.Text = "Anuluj";
            this.CancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ModifyAuthorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 131);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.RodzajComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ModifyAuthorForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ModifyAuthorForm";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ModifyAuthorForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox RodzajComboBox;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
	}
}