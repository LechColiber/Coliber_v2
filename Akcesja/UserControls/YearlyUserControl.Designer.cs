namespace Akcesja
{
    partial class YearlyUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Year1Label = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.noLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Year1Label
            // 
            this.Year1Label.BackColor = System.Drawing.Color.Gainsboro;
            this.Year1Label.Location = new System.Drawing.Point(269, 25);
            this.Year1Label.Name = "Year1Label";
            this.Year1Label.Size = new System.Drawing.Size(66, 13);
            this.Year1Label.TabIndex = 327;
            this.Year1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Year1Label.Click += new System.EventHandler(this.LoadData);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(247, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 13);
            this.label13.TabIndex = 326;
            this.label13.Text = "1.";
            // 
            // commentsLabel
            // 
            this.commentsLabel.Location = new System.Drawing.Point(269, 6);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(66, 13);
            this.commentsLabel.TabIndex = 325;
            this.commentsLabel.Text = "Uwagi";
            this.commentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // noLabel
            // 
            this.noLabel.Location = new System.Drawing.Point(233, 6);
            this.noLabel.Name = "noLabel";
            this.noLabel.Size = new System.Drawing.Size(30, 13);
            this.noLabel.TabIndex = 324;
            this.noLabel.Text = "Nr";
            this.noLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // YearlyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Year1Label);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.noLabel);
            this.Name = "YearlyUserControl";
            this.Size = new System.Drawing.Size(573, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Year1Label;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.Label noLabel;
    }
}
