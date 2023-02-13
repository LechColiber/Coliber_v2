namespace Akcesja
{
    partial class SeparateNumbersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeparateNumbersForm));
            this.label1 = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.gridsGroupBox = new System.Windows.Forms.GroupBox();
            this.gridsPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.infoPictureBox = new System.Windows.Forms.PictureBox();
            this.withoutVoluminSNGUC = new Akcesja.UserControls.SeparateNumbersGridUC();
            this.gridsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.infoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Lista numerów:";
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.Image = global::Akcesja.Properties.Resources.door_out;
            this.ExitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ExitButton.Location = new System.Drawing.Point(826, 500);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 16;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OKButton.Image = ((System.Drawing.Image)(resources.GetObject("OKButton.Image")));
            this.OKButton.Location = new System.Drawing.Point(15, 500);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(84, 23);
            this.OKButton.TabIndex = 21;
            this.OKButton.Text = "Zatwierdź";
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // gridsGroupBox
            // 
            this.gridsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridsGroupBox.Controls.Add(this.gridsPanel);
            this.gridsGroupBox.Location = new System.Drawing.Point(248, 13);
            this.gridsGroupBox.Name = "gridsGroupBox";
            this.gridsGroupBox.Size = new System.Drawing.Size(653, 481);
            this.gridsGroupBox.TabIndex = 22;
            this.gridsGroupBox.TabStop = false;
            this.gridsGroupBox.Text = "Dostępne woluminy";
            // 
            // gridsPanel
            // 
            this.gridsPanel.AutoScroll = true;
            this.gridsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridsPanel.Location = new System.Drawing.Point(3, 16);
            this.gridsPanel.Name = "gridsPanel";
            this.gridsPanel.Size = new System.Drawing.Size(647, 462);
            this.gridsPanel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Zaznacz numery i przeciągnij go woluminu.";
            // 
            // infoPictureBox
            // 
            this.infoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("infoPictureBox.Image")));
            this.infoPictureBox.Location = new System.Drawing.Point(226, 13);
            this.infoPictureBox.Name = "infoPictureBox";
            this.infoPictureBox.Size = new System.Drawing.Size(16, 16);
            this.infoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.infoPictureBox.TabIndex = 24;
            this.infoPictureBox.TabStop = false;
            this.infoPictureBox.Click += new System.EventHandler(this.infoPictureBox_Click);
            // 
            // withoutVoluminSNGUC
            // 
            this.withoutVoluminSNGUC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.withoutVoluminSNGUC.Location = new System.Drawing.Point(12, 45);
            this.withoutVoluminSNGUC.Name = "withoutVoluminSNGUC";
            this.withoutVoluminSNGUC.Size = new System.Drawing.Size(230, 449);
            this.withoutVoluminSNGUC.TabIndex = 14;
            // 
            // SeparateNumbersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 535);
            this.Controls.Add(this.infoPictureBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gridsGroupBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.withoutVoluminSNGUC);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "SeparateNumbersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rozdzielenie numerów na woluminy";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SeparateNumbersForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SeparateNumbersForm_KeyDown);
            this.gridsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.infoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private UserControls.SeparateNumbersGridUC withoutVoluminSNGUC;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.GroupBox gridsGroupBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel gridsPanel;
        private System.Windows.Forms.PictureBox infoPictureBox;
    }
}