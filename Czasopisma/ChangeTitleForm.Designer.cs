namespace Czasopisma
{
    partial class ChangeTitleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeTitleForm));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.NextInfoButton = new System.Windows.Forms.Button();
            this.DeleteNextButton = new System.Windows.Forms.Button();
            this.PreviousInfoButton = new System.Windows.Forms.Button();
            this.DeletePreviousButton = new System.Windows.Forms.Button();
            this.AddNextButton = new System.Windows.Forms.Button();
            this.AddPreviousButton = new System.Windows.Forms.Button();
            this.NextRTB = new System.Windows.Forms.RichTextBox();
            this.CurrentRTB = new System.Windows.Forms.RichTextBox();
            this.PreviousRTB = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TitleRTB = new System.Windows.Forms.RichTextBox();
            this.NextButton = new System.Windows.Forms.Button();
            this.PreviousButton = new System.Windows.Forms.Button();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tytuł modyfikowanego czasopisma:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.NextInfoButton);
            this.panel1.Controls.Add(this.DeleteNextButton);
            this.panel1.Controls.Add(this.PreviousInfoButton);
            this.panel1.Controls.Add(this.DeletePreviousButton);
            this.panel1.Controls.Add(this.AddNextButton);
            this.panel1.Controls.Add(this.AddPreviousButton);
            this.panel1.Controls.Add(this.NextRTB);
            this.panel1.Controls.Add(this.CurrentRTB);
            this.panel1.Controls.Add(this.PreviousRTB);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(660, 370);
            this.panel1.TabIndex = 2;
            // 
            // NextInfoButton
            // 
            this.NextInfoButton.BackColor = System.Drawing.Color.Transparent;
            this.NextInfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.NextInfoButton.Image = ((System.Drawing.Image)(resources.GetObject("NextInfoButton.Image")));
            this.NextInfoButton.Location = new System.Drawing.Point(623, 321);
            this.NextInfoButton.Name = "NextInfoButton";
            this.NextInfoButton.Size = new System.Drawing.Size(32, 23);
            this.NextInfoButton.TabIndex = 39;
            this.NextInfoButton.UseVisualStyleBackColor = false;
            this.NextInfoButton.Click += new System.EventHandler(this.NextInfoButton_Click);
            // 
            // DeleteNextButton
            // 
            this.DeleteNextButton.BackColor = System.Drawing.Color.Transparent;
            this.DeleteNextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeleteNextButton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteNextButton.Image")));
            this.DeleteNextButton.Location = new System.Drawing.Point(623, 292);
            this.DeleteNextButton.Name = "DeleteNextButton";
            this.DeleteNextButton.Size = new System.Drawing.Size(32, 23);
            this.DeleteNextButton.TabIndex = 38;
            this.DeleteNextButton.UseVisualStyleBackColor = false;
            this.DeleteNextButton.Click += new System.EventHandler(this.DeleteNextButton_Click);
            // 
            // PreviousInfoButton
            // 
            this.PreviousInfoButton.BackColor = System.Drawing.Color.Transparent;
            this.PreviousInfoButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PreviousInfoButton.Image = ((System.Drawing.Image)(resources.GetObject("PreviousInfoButton.Image")));
            this.PreviousInfoButton.Location = new System.Drawing.Point(623, 84);
            this.PreviousInfoButton.Name = "PreviousInfoButton";
            this.PreviousInfoButton.Size = new System.Drawing.Size(32, 23);
            this.PreviousInfoButton.TabIndex = 37;
            this.PreviousInfoButton.UseVisualStyleBackColor = false;
            this.PreviousInfoButton.Click += new System.EventHandler(this.PreviousInfoButton_Click);
            // 
            // DeletePreviousButton
            // 
            this.DeletePreviousButton.BackColor = System.Drawing.Color.Transparent;
            this.DeletePreviousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.DeletePreviousButton.Image = ((System.Drawing.Image)(resources.GetObject("DeletePreviousButton.Image")));
            this.DeletePreviousButton.Location = new System.Drawing.Point(623, 55);
            this.DeletePreviousButton.Name = "DeletePreviousButton";
            this.DeletePreviousButton.Size = new System.Drawing.Size(32, 23);
            this.DeletePreviousButton.TabIndex = 36;
            this.DeletePreviousButton.UseVisualStyleBackColor = false;
            this.DeletePreviousButton.Click += new System.EventHandler(this.DeletePreviousButton_Click);
            // 
            // AddNextButton
            // 
            this.AddNextButton.BackColor = System.Drawing.Color.Transparent;
            this.AddNextButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddNextButton.Image = ((System.Drawing.Image)(resources.GetObject("AddNextButton.Image")));
            this.AddNextButton.Location = new System.Drawing.Point(623, 263);
            this.AddNextButton.Name = "AddNextButton";
            this.AddNextButton.Size = new System.Drawing.Size(32, 23);
            this.AddNextButton.TabIndex = 35;
            this.AddNextButton.UseVisualStyleBackColor = false;
            this.AddNextButton.Click += new System.EventHandler(this.AddNextButton_Click);
            // 
            // AddPreviousButton
            // 
            this.AddPreviousButton.BackColor = System.Drawing.Color.Transparent;
            this.AddPreviousButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.AddPreviousButton.Image = ((System.Drawing.Image)(resources.GetObject("AddPreviousButton.Image")));
            this.AddPreviousButton.Location = new System.Drawing.Point(623, 26);
            this.AddPreviousButton.Name = "AddPreviousButton";
            this.AddPreviousButton.Size = new System.Drawing.Size(32, 23);
            this.AddPreviousButton.TabIndex = 34;
            this.AddPreviousButton.UseVisualStyleBackColor = false;
            this.AddPreviousButton.Click += new System.EventHandler(this.AddPreviousButton_Click);
            // 
            // NextRTB
            // 
            this.NextRTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NextRTB.Location = new System.Drawing.Point(32, 264);
            this.NextRTB.Name = "NextRTB";
            this.NextRTB.ReadOnly = true;
            this.NextRTB.Size = new System.Drawing.Size(585, 81);
            this.NextRTB.TabIndex = 7;
            this.NextRTB.Text = "";
            // 
            // CurrentRTB
            // 
            this.CurrentRTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CurrentRTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CurrentRTB.Location = new System.Drawing.Point(32, 145);
            this.CurrentRTB.Name = "CurrentRTB";
            this.CurrentRTB.ReadOnly = true;
            this.CurrentRTB.Size = new System.Drawing.Size(585, 80);
            this.CurrentRTB.TabIndex = 6;
            this.CurrentRTB.Text = "";
            // 
            // PreviousRTB
            // 
            this.PreviousRTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PreviousRTB.Location = new System.Drawing.Point(32, 29);
            this.PreviousRTB.Name = "PreviousRTB";
            this.PreviousRTB.ReadOnly = true;
            this.PreviousRTB.Size = new System.Drawing.Size(585, 79);
            this.PreviousRTB.TabIndex = 5;
            this.PreviousRTB.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(11, 248);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Następny tytuł czasopisma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(11, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Poprzedni tytuł czasopisma:";
            // 
            // TitleRTB
            // 
            this.TitleRTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TitleRTB.ForeColor = System.Drawing.Color.Red;
            this.TitleRTB.Location = new System.Drawing.Point(27, 25);
            this.TitleRTB.Name = "TitleRTB";
            this.TitleRTB.ReadOnly = true;
            this.TitleRTB.Size = new System.Drawing.Size(645, 83);
            this.TitleRTB.TabIndex = 6;
            this.TitleRTB.Text = "";
            // 
            // NextButton
            // 
            this.NextButton.Image = global::Czasopisma.Properties.Resources.rightarrow;
            this.NextButton.Location = new System.Drawing.Point(345, 498);
            this.NextButton.Name = "NextButton";
            this.NextButton.Size = new System.Drawing.Size(75, 23);
            this.NextButton.TabIndex = 5;
            this.NextButton.Text = "Następny";
            this.NextButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.NextButton.UseVisualStyleBackColor = true;
            this.NextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // PreviousButton
            // 
            this.PreviousButton.Image = global::Czasopisma.Properties.Resources.leftarrow;
            this.PreviousButton.Location = new System.Drawing.Point(264, 498);
            this.PreviousButton.Name = "PreviousButton";
            this.PreviousButton.Size = new System.Drawing.Size(75, 23);
            this.PreviousButton.TabIndex = 4;
            this.PreviousButton.Text = "Poprzedni";
            this.PreviousButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.PreviousButton.UseVisualStyleBackColor = true;
            this.PreviousButton.Click += new System.EventHandler(this.PrevoiusButton_Click);
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = global::Czasopisma.Properties.Resources.door_out;
            this.EscapeButton.Location = new System.Drawing.Point(597, 498);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(75, 23);
            this.EscapeButton.TabIndex = 3;
            this.EscapeButton.Text = "Wyjście";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // ChangeTitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(684, 533);
            this.Controls.Add(this.TitleRTB);
            this.Controls.Add(this.NextButton);
            this.Controls.Add(this.PreviousButton);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ChangeTitleForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zmiana tytułu czasopisma";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChangeTitleForm_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox PreviousRTB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox NextRTB;
        private System.Windows.Forms.RichTextBox CurrentRTB;
        private System.Windows.Forms.Button AddPreviousButton;
        private System.Windows.Forms.Button AddNextButton;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button PreviousInfoButton;
        private System.Windows.Forms.Button DeletePreviousButton;
        private System.Windows.Forms.Button PreviousButton;
        private System.Windows.Forms.Button NextButton;
        private System.Windows.Forms.Button NextInfoButton;
        private System.Windows.Forms.Button DeleteNextButton;
        private System.Windows.Forms.RichTextBox TitleRTB;
    }
}