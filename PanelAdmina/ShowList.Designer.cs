namespace WindowsFormsApplication1
{
    partial class ShowList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowList));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(1, 7);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(692, 303);
            this.listBox1.TabIndex = 0;
            // 
            // ExitButton
            // 
            this.ExitButton.Image = global::WindowsFormsApplication1.Properties.Resources.door_out;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(587, 316);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(106, 30);
            this.ExitButton.TabIndex = 1;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // ShowList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 351);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ShowList";
            this.ShowInTaskbar = false;
            this.Text = "Zasoby (ESC żeby zamknąć)";
            this.Load += new System.EventHandler(this.ShowList_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ShowList_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ShowList_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button ExitButton;
    }
}