namespace Coliber
{
    partial class Browser
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
            this.oBrowser = new System.Windows.Forms.WebBrowser();
            this.oSplit = new System.Windows.Forms.SplitContainer();
            this.cbOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.oSplit)).BeginInit();
            this.oSplit.Panel1.SuspendLayout();
            this.oSplit.Panel2.SuspendLayout();
            this.oSplit.SuspendLayout();
            this.SuspendLayout();
            // 
            // oBrowser
            // 
            this.oBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oBrowser.Location = new System.Drawing.Point(0, 0);
            this.oBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.oBrowser.Name = "oBrowser";
            this.oBrowser.Size = new System.Drawing.Size(731, 453);
            this.oBrowser.TabIndex = 0;
            // 
            // oSplit
            // 
            this.oSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oSplit.Location = new System.Drawing.Point(0, 0);
            this.oSplit.Name = "oSplit";
            this.oSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // oSplit.Panel1
            // 
            this.oSplit.Panel1.Controls.Add(this.cbOK);
            // 
            // oSplit.Panel2
            // 
            this.oSplit.Panel2.Controls.Add(this.oBrowser);
            this.oSplit.Size = new System.Drawing.Size(731, 496);
            this.oSplit.SplitterDistance = 39;
            this.oSplit.TabIndex = 1;
            // 
            // cbOK
            // 
            this.cbOK.Location = new System.Drawing.Point(25, 7);
            this.cbOK.Name = "cbOK";
            this.cbOK.Size = new System.Drawing.Size(75, 23);
            this.cbOK.TabIndex = 0;
            this.cbOK.Text = "Gotowe";
            this.cbOK.UseVisualStyleBackColor = true;
            this.cbOK.Click += new System.EventHandler(this.cbOK_Click);
            // 
            // Browser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 496);
            this.Controls.Add(this.oSplit);
            this.Name = "Browser";
            this.Text = "Browser";
            this.Load += new System.EventHandler(this.Browser_Load);
            this.oSplit.Panel1.ResumeLayout(false);
            this.oSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.oSplit)).EndInit();
            this.oSplit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser oBrowser;
        private System.Windows.Forms.SplitContainer oSplit;
        private System.Windows.Forms.Button cbOK;
    }
}