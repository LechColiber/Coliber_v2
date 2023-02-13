namespace Czasopisma
{
    partial class ChooseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseForm));
            this.SygButton = new System.Windows.Forms.Button();
            this.TitleButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EscapeButton = new System.Windows.Forms.Button();
            this.NewWydSerButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SygButton
            // 
            this.SygButton.Location = new System.Drawing.Point(26, 80);
            this.SygButton.Name = "SygButton";
            this.SygButton.Size = new System.Drawing.Size(255, 23);
            this.SygButton.TabIndex = 0;
            this.SygButton.Text = "listę wprowadzonych sygnatur";
            this.SygButton.UseVisualStyleBackColor = true;
            this.SygButton.Click += new System.EventHandler(this.SygButton_Click);
            // 
            // TitleButton
            // 
            this.TitleButton.Location = new System.Drawing.Point(26, 109);
            this.TitleButton.Name = "TitleButton";
            this.TitleButton.Size = new System.Drawing.Size(255, 23);
            this.TitleButton.TabIndex = 1;
            this.TitleButton.Text = "listę wprowadzonych tytułów";
            this.TitleButton.UseVisualStyleBackColor = true;
            this.TitleButton.Click += new System.EventHandler(this.TitleButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(23, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Wybór istniejącego opisu poprzez:";
            // 
            // EscapeButton
            // 
            this.EscapeButton.Image = global::Czasopisma.Properties.Resources.door_out;
            this.EscapeButton.Location = new System.Drawing.Point(206, 166);
            this.EscapeButton.Name = "EscapeButton";
            this.EscapeButton.Size = new System.Drawing.Size(75, 23);
            this.EscapeButton.TabIndex = 3;
            this.EscapeButton.Text = "Wyjście";
            this.EscapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EscapeButton.UseVisualStyleBackColor = true;
            this.EscapeButton.Click += new System.EventHandler(this.EscapeButton_Click);
            // 
            // NewWydSerButton
            // 
            this.NewWydSerButton.Location = new System.Drawing.Point(26, 12);
            this.NewWydSerButton.Name = "NewWydSerButton";
            this.NewWydSerButton.Size = new System.Drawing.Size(255, 23);
            this.NewWydSerButton.TabIndex = 4;
            this.NewWydSerButton.Text = "Nowe wydawnictwo seryjne";
            this.NewWydSerButton.UseVisualStyleBackColor = true;
            this.NewWydSerButton.Visible = false;
            this.NewWydSerButton.Click += new System.EventHandler(this.NewWydSerButton_Click);
            // 
            // ChooseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 205);
            this.Controls.Add(this.NewWydSerButton);
            this.Controls.Add(this.EscapeButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitleButton);
            this.Controls.Add(this.SygButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modyfikacja danych";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChooseForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SygButton;
        private System.Windows.Forms.Button TitleButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EscapeButton;
        private System.Windows.Forms.Button NewWydSerButton;
    }
}