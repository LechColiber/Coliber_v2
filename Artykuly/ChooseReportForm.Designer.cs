namespace Artykuly
{
    partial class ChooseReportForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseReportForm));
            this.Description = new System.Windows.Forms.Button();
            this.Card = new System.Windows.Forms.Button();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Description
            // 
            this.Description.Location = new System.Drawing.Point(47, 55);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(123, 23);
            this.Description.TabIndex = 3;
            this.Description.Text = "Opis katalogowy";
            this.Description.UseVisualStyleBackColor = true;
            this.Description.Click += new System.EventHandler(this.Description_Click);
            // 
            // Card
            // 
            this.Card.Location = new System.Drawing.Point(47, 26);
            this.Card.Name = "Card";
            this.Card.Size = new System.Drawing.Size(123, 23);
            this.Card.TabIndex = 2;
            this.Card.Text = "Karta katalogowa";
            this.Card.UseVisualStyleBackColor = true;
            this.Card.Click += new System.EventHandler(this.Card_Click);
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = global::Artykuly.Properties.Resources.door_out;
            this.EscapeButton.Location = new System.Drawing.Point(127, 98);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(85, 23);
            this.EscapeButton.TabIndex = 4;
            this.EscapeButton.Text = "Wyjście";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // ChooseReportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 134);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.Card);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseReportForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Drukowanie";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseReportForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseReportForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Description;
        private System.Windows.Forms.Button Card;
        private System.Windows.Forms.Button EscapeButton;
    }
}