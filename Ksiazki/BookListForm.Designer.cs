namespace Ksiazki
{
    partial class BookListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookListForm));
            this.label1 = new System.Windows.Forms.Label();
            this.BarCodeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NumInwTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SygTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.NumInwButton = new System.Windows.Forms.Button();
            this.SygButton = new System.Windows.Forms.Button();
            this.TitleButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(153, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Wybór opisu poprzez:";
            // 
            // BarCodeTextBox
            // 
            this.BarCodeTextBox.Location = new System.Drawing.Point(138, 52);
            this.BarCodeTextBox.MaxLength = 20;
            this.BarCodeTextBox.Name = "BarCodeTextBox";
            this.BarCodeTextBox.Size = new System.Drawing.Size(246, 20);
            this.BarCodeTextBox.TabIndex = 1;
            this.BarCodeTextBox.TextChanged += new System.EventHandler(this.BarCodeTextBox_TextChanged);
            this.BarCodeTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BarCodeTextBox_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kod kreskowy:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Numer inwentarzowy:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumInwTextBox
            // 
            this.NumInwTextBox.Location = new System.Drawing.Point(138, 93);
            this.NumInwTextBox.Name = "NumInwTextBox";
            this.NumInwTextBox.Size = new System.Drawing.Size(246, 20);
            this.NumInwTextBox.TabIndex = 3;
            this.NumInwTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NumInwTextBox_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sygnaturę:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // SygTextBox
            // 
            this.SygTextBox.Location = new System.Drawing.Point(138, 119);
            this.SygTextBox.Name = "SygTextBox";
            this.SygTextBox.Size = new System.Drawing.Size(246, 20);
            this.SygTextBox.TabIndex = 5;
            this.SygTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SygTextBox_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tytuł:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(138, 145);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(246, 20);
            this.TitleTextBox.TabIndex = 7;
            this.TitleTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TitleTextBox_KeyDown);
            // 
            // NumInwButton
            // 
            this.NumInwButton.Location = new System.Drawing.Point(396, 90);
            this.NumInwButton.Name = "NumInwButton";
            this.NumInwButton.Size = new System.Drawing.Size(251, 23);
            this.NumInwButton.TabIndex = 10;
            this.NumInwButton.Text = "Lista wprowadzonych numerów inwentarzowych";
            this.NumInwButton.UseVisualStyleBackColor = true;
            this.NumInwButton.Click += new System.EventHandler(this.NumInwButton_Click);
            // 
            // SygButton
            // 
            this.SygButton.Location = new System.Drawing.Point(396, 117);
            this.SygButton.Name = "SygButton";
            this.SygButton.Size = new System.Drawing.Size(251, 23);
            this.SygButton.TabIndex = 11;
            this.SygButton.Text = "Lista wprowadzonych sygnatur";
            this.SygButton.UseVisualStyleBackColor = true;
            this.SygButton.Click += new System.EventHandler(this.SygButton_Click);
            // 
            // TitleButton
            // 
            this.TitleButton.Location = new System.Drawing.Point(396, 143);
            this.TitleButton.Name = "TitleButton";
            this.TitleButton.Size = new System.Drawing.Size(251, 23);
            this.TitleButton.TabIndex = 12;
            this.TitleButton.Text = "Lista wprowadzonych tytułów";
            this.TitleButton.UseVisualStyleBackColor = true;
            this.TitleButton.Click += new System.EventHandler(this.TitleButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::Ksiazki.Properties.Resources.door_out;
            this.ExitButton.Location = new System.Drawing.Point(618, 197);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 13;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // BookListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 232);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.TitleButton);
            this.Controls.Add(this.SygButton);
            this.Controls.Add(this.NumInwButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SygTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NumInwTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BarCodeTextBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "BookListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Książki: modyfikacja danych";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BookListForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox BarCodeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox NumInwTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SygTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Button NumInwButton;
        private System.Windows.Forms.Button SygButton;
        private System.Windows.Forms.Button TitleButton;
        private System.Windows.Forms.Button ExitButton;
    }
}