namespace Ksiazki
{
    partial class EditMARCForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMARCForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Ind2Label = new System.Windows.Forms.Label();
            this.MARCDetailsTextBox = new System.Windows.Forms.TextBox();
            this.TagLabel = new System.Windows.Forms.Label();
            this.Ind1Label = new System.Windows.Forms.Label();
            this.ValueLabel = new System.Windows.Forms.Label();
            this.ButtonsPanel = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.AddRowButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ButtonsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(546, 328);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edycja opisu MARC do importu";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ButtonsPanel, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(540, 309);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Ind2Label);
            this.panel1.Controls.Add(this.MARCDetailsTextBox);
            this.panel1.Controls.Add(this.TagLabel);
            this.panel1.Controls.Add(this.Ind1Label);
            this.panel1.Controls.Add(this.ValueLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 254);
            this.panel1.TabIndex = 0;
            // 
            // Ind2Label
            // 
            this.Ind2Label.AutoSize = true;
            this.Ind2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Ind2Label.Location = new System.Drawing.Point(56, 6);
            this.Ind2Label.Name = "Ind2Label";
            this.Ind2Label.Size = new System.Drawing.Size(30, 13);
            this.Ind2Label.TabIndex = 3;
            this.Ind2Label.Text = "Ws2";
            // 
            // MARCDetailsTextBox
            // 
            this.MARCDetailsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.MARCDetailsTextBox.Location = new System.Drawing.Point(7, 23);
            this.MARCDetailsTextBox.Multiline = true;
            this.MARCDetailsTextBox.Name = "MARCDetailsTextBox";
            this.MARCDetailsTextBox.Size = new System.Drawing.Size(519, 228);
            this.MARCDetailsTextBox.TabIndex = 5;
            this.MARCDetailsTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MARCDetailsTextBox_KeyDown);
            // 
            // TagLabel
            // 
            this.TagLabel.AutoSize = true;
            this.TagLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TagLabel.Location = new System.Drawing.Point(2, 6);
            this.TagLabel.Name = "TagLabel";
            this.TagLabel.Size = new System.Drawing.Size(32, 13);
            this.TagLabel.TabIndex = 1;
            this.TagLabel.Text = "Pole";
            // 
            // Ind1Label
            // 
            this.Ind1Label.AutoSize = true;
            this.Ind1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Ind1Label.Location = new System.Drawing.Point(31, 6);
            this.Ind1Label.Name = "Ind1Label";
            this.Ind1Label.Size = new System.Drawing.Size(30, 13);
            this.Ind1Label.TabIndex = 2;
            this.Ind1Label.Text = "Ws1";
            // 
            // ValueLabel
            // 
            this.ValueLabel.AutoSize = true;
            this.ValueLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ValueLabel.Location = new System.Drawing.Point(82, 6);
            this.ValueLabel.Name = "ValueLabel";
            this.ValueLabel.Size = new System.Drawing.Size(51, 13);
            this.ValueLabel.TabIndex = 4;
            this.ValueLabel.Text = "Wartość";
            // 
            // ButtonsPanel
            // 
            this.ButtonsPanel.Controls.Add(this.CancelButton);
            this.ButtonsPanel.Controls.Add(this.ImportButton);
            this.ButtonsPanel.Controls.Add(this.AddRowButton);
            this.ButtonsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonsPanel.Location = new System.Drawing.Point(3, 263);
            this.ButtonsPanel.Name = "ButtonsPanel";
            this.ButtonsPanel.Size = new System.Drawing.Size(534, 43);
            this.ButtonsPanel.TabIndex = 1;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Image = global::Ksiazki.Properties.Resources.door_out;
            this.CancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CancelButton.Location = new System.Drawing.Point(447, 5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(79, 29);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Wyjście";
            this.CancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(30, 10);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(79, 29);
            this.ImportButton.TabIndex = 2;
            this.ImportButton.Text = "Importuj";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Visible = false;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // AddRowButton
            // 
            this.AddRowButton.Location = new System.Drawing.Point(115, 9);
            this.AddRowButton.Name = "AddRowButton";
            this.AddRowButton.Size = new System.Drawing.Size(79, 29);
            this.AddRowButton.TabIndex = 1;
            this.AddRowButton.Text = "Dodaj wiersz";
            this.AddRowButton.UseVisualStyleBackColor = true;
            this.AddRowButton.Click += new System.EventHandler(this.AddRowButton_Click);
            // 
            // EditMARCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 328);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(554, 362);
            this.Name = "EditMARCForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "EdtMARCForm";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ButtonsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label TagLabel;
        private System.Windows.Forms.Label ValueLabel;
        private System.Windows.Forms.Label Ind2Label;
        private System.Windows.Forms.Label Ind1Label;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddRowButton;
        private System.Windows.Forms.Panel ButtonsPanel;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.TextBox MARCDetailsTextBox;
    }
}