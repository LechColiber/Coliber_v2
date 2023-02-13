namespace Normy
{
    partial class Normy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Normy));
            this.dgNormy = new System.Windows.Forms.DataGridView();
            this.nr_normy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tytul = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataPub = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SelectButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.buttonAll = new System.Windows.Forms.Button();
            this.buttonSzukaj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgNormy)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgNormy
            // 
            this.dgNormy.AllowUserToAddRows = false;
            this.dgNormy.AllowUserToDeleteRows = false;
            this.dgNormy.AllowUserToResizeRows = false;
            this.dgNormy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgNormy.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgNormy.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgNormy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nr_normy,
            this.Tytul,
            this.DataPub,
            this.Id});
            this.dgNormy.Location = new System.Drawing.Point(3, 1);
            this.dgNormy.MultiSelect = false;
            this.dgNormy.Name = "dgNormy";
            this.dgNormy.ReadOnly = true;
            this.dgNormy.RowHeadersWidth = 20;
            this.dgNormy.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgNormy.Size = new System.Drawing.Size(1051, 524);
            this.dgNormy.TabIndex = 0;
            this.dgNormy.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNormy_CellClick);
            this.dgNormy.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgNormy_CellDoubleClick);
            this.dgNormy.Sorted += new System.EventHandler(this.dgNormy_Sorted);
            this.dgNormy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgNormy_KeyPress);
            // 
            // nr_normy
            // 
            this.nr_normy.DataPropertyName = "nr_normy";
            this.nr_normy.FillWeight = 200F;
            this.nr_normy.HeaderText = "Numer normy";
            this.nr_normy.Name = "nr_normy";
            this.nr_normy.ReadOnly = true;
            // 
            // Tytul
            // 
            this.Tytul.DataPropertyName = "Tytul";
            this.Tytul.FillWeight = 500F;
            this.Tytul.HeaderText = "Tytuł";
            this.Tytul.Name = "Tytul";
            this.Tytul.ReadOnly = true;
            // 
            // DataPub
            // 
            this.DataPub.DataPropertyName = "data_pub";
            this.DataPub.FillWeight = 150F;
            this.DataPub.HeaderText = "Data publikacji";
            this.DataPub.Name = "DataPub";
            this.DataPub.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id_norma";
            this.Id.FillWeight = 50F;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(958, 3);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(86, 29);
            this.ExitButton.TabIndex = 9;
            this.ExitButton.Text = "Wyjście";
            this.ExitButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SelectButton
            // 
            this.SelectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.SelectButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.SelectButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SelectButton.Image = global::Normy.Properties.Resources.Check2;
            this.SelectButton.Location = new System.Drawing.Point(3, 3);
            this.SelectButton.Name = "SelectButton";
            this.SelectButton.Size = new System.Drawing.Size(85, 29);
            this.SelectButton.TabIndex = 1;
            this.SelectButton.Text = "Wybierz";
            this.SelectButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.SelectButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.SelectButton.UseVisualStyleBackColor = true;
            this.SelectButton.Click += new System.EventHandler(this.SelectButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.buttonAll);
            this.panel1.Controls.Add(this.buttonSzukaj);
            this.panel1.Controls.Add(this.DeleteButton);
            this.panel1.Controls.Add(this.ExitButton);
            this.panel1.Controls.Add(this.SearchLabel);
            this.panel1.Controls.Add(this.SelectButton);
            this.panel1.Location = new System.Drawing.Point(3, 531);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1047, 39);
            this.panel1.TabIndex = 3;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DeleteButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.DeleteButton.Image = global::Normy.Properties.Resources.fileclose;
            this.DeleteButton.Location = new System.Drawing.Point(94, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(85, 29);
            this.DeleteButton.TabIndex = 10;
            this.DeleteButton.Text = "Usuń";
            this.DeleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Visible = false;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Location = new System.Drawing.Point(98, 11);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(0, 13);
            this.SearchLabel.TabIndex = 2;
            // 
            // buttonAll
            // 
            this.buttonAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonAll.Image = ((System.Drawing.Image)(resources.GetObject("buttonAll.Image")));
            this.buttonAll.Location = new System.Drawing.Point(488, 3);
            this.buttonAll.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(32, 32);
            this.buttonAll.TabIndex = 204;
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // buttonSzukaj
            // 
            this.buttonSzukaj.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSzukaj.Image = ((System.Drawing.Image)(resources.GetObject("buttonSzukaj.Image")));
            this.buttonSzukaj.Location = new System.Drawing.Point(527, 3);
            this.buttonSzukaj.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSzukaj.Name = "buttonSzukaj";
            this.buttonSzukaj.Size = new System.Drawing.Size(32, 32);
            this.buttonSzukaj.TabIndex = 203;
            this.buttonSzukaj.UseVisualStyleBackColor = true;
            this.buttonSzukaj.Click += new System.EventHandler(this.buttonSzukaj_Click);
            // 
            // Normy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 571);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgNormy);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Normy";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Normy";
            ((System.ComponentModel.ISupportInitialize)(this.dgNormy)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgNormy;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button SelectButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn nr_normy;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tytul;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataPub;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonSzukaj;
    }
}

