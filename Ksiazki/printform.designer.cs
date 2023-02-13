namespace Ksiazki
{
    partial class PrintForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintForm));
            this.WithCommentsRB = new System.Windows.Forms.RadioButton();
            this.WithOutCommentsRB = new System.Windows.Forms.RadioButton();
            this.ExitButton = new System.Windows.Forms.Button();
            this.PrintButton = new System.Windows.Forms.Button();
            this.CardRB = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // WithCommentsRB
            // 
            this.WithCommentsRB.Location = new System.Drawing.Point(71, 38);
            this.WithCommentsRB.Name = "WithCommentsRB";
            this.WithCommentsRB.Size = new System.Drawing.Size(229, 17);
            this.WithCommentsRB.TabIndex = 0;
            this.WithCommentsRB.TabStop = true;
            this.WithCommentsRB.Text = "Opis katalogowy – z uwagami i ISBN";
            this.WithCommentsRB.UseVisualStyleBackColor = true;
            // 
            // WithOutCommentsRB
            // 
            this.WithOutCommentsRB.Location = new System.Drawing.Point(71, 61);
            this.WithOutCommentsRB.Name = "WithOutCommentsRB";
            this.WithOutCommentsRB.Size = new System.Drawing.Size(225, 17);
            this.WithOutCommentsRB.TabIndex = 1;
            this.WithOutCommentsRB.TabStop = true;
            this.WithOutCommentsRB.Text = "Opis katalogowy – bez uwag i ISBN";
            this.WithOutCommentsRB.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Image = global::Ksiazki.Properties.Resources.door_out;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(306, 141);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(79, 23);
            this.ExitButton.TabIndex = 6;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // PrintButton
            // 
            this.PrintButton.Image = global::Ksiazki.Properties.Resources.print_printer;
            this.PrintButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PrintButton.Location = new System.Drawing.Point(221, 141);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(79, 23);
            this.PrintButton.TabIndex = 7;
            this.PrintButton.Text = "Drukuj";
            this.PrintButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CardRB
            // 
            this.CardRB.Location = new System.Drawing.Point(71, 84);
            this.CardRB.Name = "CardRB";
            this.CardRB.Size = new System.Drawing.Size(140, 17);
            this.CardRB.TabIndex = 2;
            this.CardRB.TabStop = true;
            this.CardRB.Text = "Karta katalogowa";
            this.CardRB.UseVisualStyleBackColor = true;
            // 
            // PrintForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 176);
            this.Controls.Add(this.PrintButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.CardRB);
            this.Controls.Add(this.WithOutCommentsRB);
            this.Controls.Add(this.WithCommentsRB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "PrintForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drukowanie";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PrintForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton WithCommentsRB;
        private System.Windows.Forms.RadioButton WithOutCommentsRB;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.RadioButton CardRB;
    }
}