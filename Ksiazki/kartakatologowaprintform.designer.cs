namespace Ksiazki
{
    partial class KartaKatologowaPrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KartaKatologowaPrintForm));
            this.mainChoosenRadioButton = new System.Windows.Forms.RadioButton();
            this.mainAllRadioButton = new System.Windows.Forms.RadioButton();
            this.PrintButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.tomesChoosenRadioButton = new System.Windows.Forms.RadioButton();
            this.tomesAllRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainChoosenRadioButton
            // 
            this.mainChoosenRadioButton.Location = new System.Drawing.Point(52, 52);
            this.mainChoosenRadioButton.Name = "mainChoosenRadioButton";
            this.mainChoosenRadioButton.Size = new System.Drawing.Size(263, 17);
            this.mainChoosenRadioButton.TabIndex = 4;
            this.mainChoosenRadioButton.Text = "Wydruk wybranych kart głównych";
            this.mainChoosenRadioButton.UseVisualStyleBackColor = true;
            // 
            // mainAllRadioButton
            // 
            this.mainAllRadioButton.Checked = true;
            this.mainAllRadioButton.Location = new System.Drawing.Point(52, 29);
            this.mainAllRadioButton.Name = "mainAllRadioButton";
            this.mainAllRadioButton.Size = new System.Drawing.Size(263, 17);
            this.mainAllRadioButton.TabIndex = 3;
            this.mainAllRadioButton.TabStop = true;
            this.mainAllRadioButton.Text = "Wydruk wszystkich kart głównych";
            this.mainAllRadioButton.UseVisualStyleBackColor = true;
            // 
            // PrintButton
            // 
            this.PrintButton.Image = global::Ksiazki.Properties.Resources.print_printer;
            this.PrintButton.Location = new System.Drawing.Point(148, 148);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(79, 23);
            this.PrintButton.TabIndex = 9;
            this.PrintButton.Text = "Drukuj";
            this.PrintButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.PrintButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(232, 148);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(79, 23);
            this.ExitButton.TabIndex = 8;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // tomesChoosenRadioButton
            // 
            this.tomesChoosenRadioButton.Location = new System.Drawing.Point(52, 121);
            this.tomesChoosenRadioButton.Name = "tomesChoosenRadioButton";
            this.tomesChoosenRadioButton.Size = new System.Drawing.Size(264, 17);
            this.tomesChoosenRadioButton.TabIndex = 12;
            this.tomesChoosenRadioButton.Text = "Wydruk wybranych kart tomowych";
            this.tomesChoosenRadioButton.UseVisualStyleBackColor = true;
            // 
            // tomesAllRadioButton
            // 
            this.tomesAllRadioButton.Location = new System.Drawing.Point(52, 98);
            this.tomesAllRadioButton.Name = "tomesAllRadioButton";
            this.tomesAllRadioButton.Size = new System.Drawing.Size(264, 17);
            this.tomesAllRadioButton.TabIndex = 11;
            this.tomesAllRadioButton.Text = "Wydruk wszystkich kart tomowych";
            this.tomesAllRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Wydruk głównych kart katalogowych:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(31, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(195, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Wydruk kart tomowych:";
            // 
            // KartaKatologowaPrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 178);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tomesChoosenRadioButton);
            this.Controls.Add(this.tomesAllRadioButton);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.mainChoosenRadioButton);
            this.Controls.Add(this.mainAllRadioButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "KartaKatologowaPrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Wydruk kart katalogowych";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KartaKatologowaPrintForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KartaKatologowaPrintForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton mainChoosenRadioButton;
        private System.Windows.Forms.RadioButton mainAllRadioButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.RadioButton tomesChoosenRadioButton;
        private System.Windows.Forms.RadioButton tomesAllRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}