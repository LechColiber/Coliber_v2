namespace WindowsFormsApplication1
{
    partial class Rights
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rights));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AddOneButton = new System.Windows.Forms.Button();
            this.AddAllButton = new System.Windows.Forms.Button();
            this.DeleteAllButton = new System.Windows.Forms.Button();
            this.DeleteOneBbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(22, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(228, 277);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(304, 12);
            this.listBox2.Name = "listBox2";
            this.listBox2.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox2.Size = new System.Drawing.Size(228, 277);
            this.listBox2.TabIndex = 1;
            this.listBox2.DoubleClick += new System.EventHandler(this.listBox2_DoubleClick);
            // 
            // AddButton
            // 
            this.AddButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AddButton.Location = new System.Drawing.Point(168, 312);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(106, 30);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Zapisz";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 312);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Anuluj";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AddOneButton
            // 
            this.AddOneButton.Location = new System.Drawing.Point(257, 62);
            this.AddOneButton.Name = "AddOneButton";
            this.AddOneButton.Size = new System.Drawing.Size(41, 23);
            this.AddOneButton.TabIndex = 9;
            this.AddOneButton.Text = ">";
            this.AddOneButton.UseVisualStyleBackColor = true;
            this.AddOneButton.Click += new System.EventHandler(this.AddOneButton_Click);
            // 
            // AddAllButton
            // 
            this.AddAllButton.Location = new System.Drawing.Point(257, 91);
            this.AddAllButton.Name = "AddAllButton";
            this.AddAllButton.Size = new System.Drawing.Size(41, 23);
            this.AddAllButton.TabIndex = 10;
            this.AddAllButton.Text = ">>";
            this.AddAllButton.UseVisualStyleBackColor = true;
            this.AddAllButton.Click += new System.EventHandler(this.AddAllButton_Click);
            // 
            // DeleteAllButton
            // 
            this.DeleteAllButton.Location = new System.Drawing.Point(256, 209);
            this.DeleteAllButton.Name = "DeleteAllButton";
            this.DeleteAllButton.Size = new System.Drawing.Size(41, 23);
            this.DeleteAllButton.TabIndex = 11;
            this.DeleteAllButton.Text = "<<";
            this.DeleteAllButton.UseVisualStyleBackColor = true;
            this.DeleteAllButton.Click += new System.EventHandler(this.DeleteAllButton_Click);
            // 
            // DeleteOneBbutton
            // 
            this.DeleteOneBbutton.Location = new System.Drawing.Point(256, 180);
            this.DeleteOneBbutton.Name = "DeleteOneBbutton";
            this.DeleteOneBbutton.Size = new System.Drawing.Size(41, 23);
            this.DeleteOneBbutton.TabIndex = 12;
            this.DeleteOneBbutton.Text = "<";
            this.DeleteOneBbutton.UseVisualStyleBackColor = true;
            this.DeleteOneBbutton.Click += new System.EventHandler(this.DeleteOneBbutton_Click);
            // 
            // Rights
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 354);
            this.Controls.Add(this.DeleteOneBbutton);
            this.Controls.Add(this.DeleteAllButton);
            this.Controls.Add(this.AddAllButton);
            this.Controls.Add(this.AddOneButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.listBox2);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Rights";
            this.ShowInTaskbar = false;
            this.Text = "Prawa";
            this.Load += new System.EventHandler(this.Rights_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Rights_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button AddOneButton;
        private System.Windows.Forms.Button AddAllButton;
        private System.Windows.Forms.Button DeleteAllButton;
        private System.Windows.Forms.Button DeleteOneBbutton;
    }
}