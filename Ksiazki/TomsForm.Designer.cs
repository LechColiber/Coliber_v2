namespace Ksiazki
{
    partial class TomsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TomsForm));
            this.TomsListView = new System.Windows.Forms.ListView();
            this.TitleLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.kodLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EscapeButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TomsListView
            // 
            this.TomsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TomsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TitleLV,
            this.kodLV});
            this.TomsListView.FullRowSelect = true;
            this.TomsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.TomsListView.HideSelection = false;
            this.TomsListView.Location = new System.Drawing.Point(12, 12);
            this.TomsListView.MultiSelect = false;
            this.TomsListView.Name = "TomsListView";
            this.TomsListView.Size = new System.Drawing.Size(460, 211);
            this.TomsListView.TabIndex = 5;
            this.TomsListView.UseCompatibleStateImageBehavior = false;
            this.TomsListView.View = System.Windows.Forms.View.Details;
            this.TomsListView.SelectedIndexChanged += new System.EventHandler(this.TomsListView_SelectedIndexChanged);
            this.TomsListView.Resize += new System.EventHandler(this.TomsListView_Resize);
            // 
            // TitleLV
            // 
            this.TitleLV.Tag = "Title";
            this.TitleLV.Text = "Tytuł";
            this.TitleLV.Width = 25;
            // 
            // kodLV
            // 
            this.kodLV.Tag = "kod";
            this.kodLV.Text = "kod";
            this.kodLV.Width = 0;
            // 
            // EscapeButton
            // 
            this.EscapeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.EscapeButton.Image = ((System.Drawing.Image)(resources.GetObject("EscapeButton.Image")));
            this.EscapeButton.Location = new System.Drawing.Point(397, 326);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(75, 23);
            this.EscapeButton.TabIndex = 4;
            this.EscapeButton.Text = "Wyjście";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.Enabled = false;
            this.DeleteButton.Image = global::Ksiazki.Properties.Resources.contact_busy_overlay;
            this.DeleteButton.Location = new System.Drawing.Point(12, 298);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(155, 23);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Usuń";
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditButton.Enabled = false;
            this.EditButton.Image = global::Ksiazki.Properties.Resources.edycjam;
            this.EditButton.Location = new System.Drawing.Point(12, 269);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(155, 23);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Modyfikuj";
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // NewButton
            // 
            this.NewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewButton.Image = ((System.Drawing.Image)(resources.GetObject("NewButton.Image")));
            this.NewButton.Location = new System.Drawing.Point(12, 240);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(155, 23);
            this.NewButton.TabIndex = 1;
            this.NewButton.Text = "Nowy opis bibliograficzny";
            this.NewButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.NewButton.UseVisualStyleBackColor = true;
            this.NewButton.Click += new System.EventHandler(this.NewButton_Click);
            // 
            // TomsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.TomsListView);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.NewButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "TomsForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista tomów";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TomsForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TomsForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.ListView TomsListView;
        private System.Windows.Forms.ColumnHeader TitleLV;
        private System.Windows.Forms.ColumnHeader kodLV;
    }
}