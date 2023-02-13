namespace Akcesja
{
    partial class HalfYearlyUserControl
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
            this.comments2Label = new System.Windows.Forms.Label();
            this.no2Label = new System.Windows.Forms.Label();
            this.Half2Label = new System.Windows.Forms.Label();
            this.Half1Label = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.commentsLabel = new System.Windows.Forms.Label();
            this.noLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comments2Label
            // 
            this.comments2Label.Location = new System.Drawing.Point(312, 10);
            this.comments2Label.Name = "comments2Label";
            this.comments2Label.Size = new System.Drawing.Size(61, 13);
            this.comments2Label.TabIndex = 327;
            this.comments2Label.Text = "Uwagi";
            this.comments2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // no2Label
            // 
            this.no2Label.Location = new System.Drawing.Point(288, 10);
            this.no2Label.Name = "no2Label";
            this.no2Label.Size = new System.Drawing.Size(18, 13);
            this.no2Label.TabIndex = 326;
            this.no2Label.Text = "Nr";
            this.no2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Half2Label
            // 
            this.Half2Label.BackColor = System.Drawing.Color.Gainsboro;
            this.Half2Label.Location = new System.Drawing.Point(307, 29);
            this.Half2Label.Name = "Half2Label";
            this.Half2Label.Size = new System.Drawing.Size(66, 13);
            this.Half2Label.TabIndex = 324;
            this.Half2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Half2Label.Click += new System.EventHandler(this.LoadData);
            // 
            // Half1Label
            // 
            this.Half1Label.BackColor = System.Drawing.Color.Gainsboro;
            this.Half1Label.Location = new System.Drawing.Point(220, 29);
            this.Half1Label.Name = "Half1Label";
            this.Half1Label.Size = new System.Drawing.Size(66, 13);
            this.Half1Label.TabIndex = 323;
            this.Half1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Half1Label.Click += new System.EventHandler(this.LoadData);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(290, 29);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(16, 13);
            this.label14.TabIndex = 319;
            this.label14.Text = "2.";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(203, 29);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 13);
            this.label13.TabIndex = 318;
            this.label13.Text = "1.";
            // 
            // commentsLabel
            // 
            this.commentsLabel.Location = new System.Drawing.Point(225, 10);
            this.commentsLabel.Name = "commentsLabel";
            this.commentsLabel.Size = new System.Drawing.Size(57, 13);
            this.commentsLabel.TabIndex = 317;
            this.commentsLabel.Text = "Uwagi";
            this.commentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // noLabel
            // 
            this.noLabel.Location = new System.Drawing.Point(201, 10);
            this.noLabel.Name = "noLabel";
            this.noLabel.Size = new System.Drawing.Size(18, 13);
            this.noLabel.TabIndex = 316;
            this.noLabel.Text = "Nr";
            this.noLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HalfYearlyUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comments2Label);
            this.Controls.Add(this.no2Label);
            this.Controls.Add(this.Half2Label);
            this.Controls.Add(this.Half1Label);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.commentsLabel);
            this.Controls.Add(this.noLabel);
            this.Name = "HalfYearlyUserControl";
            this.Size = new System.Drawing.Size(573, 58);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label comments2Label;
        private System.Windows.Forms.Label no2Label;
        private System.Windows.Forms.Label Half2Label;
        private System.Windows.Forms.Label Half1Label;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label commentsLabel;
        private System.Windows.Forms.Label noLabel;
    }
}
