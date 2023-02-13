namespace Akcesja
{
    partial class CommonUserControl
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
            this.yearLabel = new System.Windows.Forms.Label();
            this.YearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.DateRadioButton = new System.Windows.Forms.RadioButton();
            this.NumberRadioButton = new System.Windows.Forms.RadioButton();
            this.NextNumberRadioButton = new System.Windows.Forms.RadioButton();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            ((System.ComponentModel.ISupportInitialize)(this.YearNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // yearLabel
            // 
            this.yearLabel.Location = new System.Drawing.Point(3, 10);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(51, 13);
            this.yearLabel.TabIndex = 0;
            this.yearLabel.Text = "ROK";
            this.yearLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // YearNumericUpDown
            // 
            this.YearNumericUpDown.Location = new System.Drawing.Point(57, 7);
            this.YearNumericUpDown.Maximum = new decimal(new int[] {
            2100,
            0,
            0,
            0});
            this.YearNumericUpDown.Minimum = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.YearNumericUpDown.Name = "YearNumericUpDown";
            this.YearNumericUpDown.Size = new System.Drawing.Size(57, 20);
            this.YearNumericUpDown.TabIndex = 2;
            this.YearNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.YearNumericUpDown.Value = new decimal(new int[] {
            1900,
            0,
            0,
            0});
            this.YearNumericUpDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YearNumericUpDown_KeyPress);
            // 
            // DateRadioButton
            // 
            this.DateRadioButton.AutoSize = true;
            this.DateRadioButton.Location = new System.Drawing.Point(163, 7);
            this.DateRadioButton.Name = "DateRadioButton";
            this.DateRadioButton.Size = new System.Drawing.Size(79, 17);
            this.DateRadioButton.TabIndex = 3;
            this.DateRadioButton.Text = "Pokaż datę";
            this.DateRadioButton.UseVisualStyleBackColor = true;
            // 
            // NumberRadioButton
            // 
            this.NumberRadioButton.AutoSize = true;
            this.NumberRadioButton.Checked = true;
            this.NumberRadioButton.Location = new System.Drawing.Point(250, 7);
            this.NumberRadioButton.Name = "NumberRadioButton";
            this.NumberRadioButton.Size = new System.Drawing.Size(87, 17);
            this.NumberRadioButton.TabIndex = 4;
            this.NumberRadioButton.TabStop = true;
            this.NumberRadioButton.Text = "Pokaż numer";
            this.NumberRadioButton.UseVisualStyleBackColor = true;
            // 
            // NextNumberRadioButton
            // 
            this.NextNumberRadioButton.AutoSize = true;
            this.NextNumberRadioButton.Location = new System.Drawing.Point(345, 7);
            this.NextNumberRadioButton.Name = "NextNumberRadioButton";
            this.NextNumberRadioButton.Size = new System.Drawing.Size(123, 17);
            this.NextNumberRadioButton.TabIndex = 5;
            this.NextNumberRadioButton.Text = "Pokaż numer kolejny";
            this.NextNumberRadioButton.UseVisualStyleBackColor = true;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(597, 54);
            this.shapeContainer1.TabIndex = 7;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 7;
            this.lineShape1.X2 = 586;
            this.lineShape1.Y1 = 45;
            this.lineShape1.Y2 = 45;
            // 
            // CommonUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NextNumberRadioButton);
            this.Controls.Add(this.NumberRadioButton);
            this.Controls.Add(this.DateRadioButton);
            this.Controls.Add(this.YearNumericUpDown);
            this.Controls.Add(this.yearLabel);
            this.Controls.Add(this.shapeContainer1);
            this.Name = "CommonUserControl";
            this.Size = new System.Drawing.Size(597, 54);
            ((System.ComponentModel.ISupportInitialize)(this.YearNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label yearLabel;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        public System.Windows.Forms.NumericUpDown YearNumericUpDown;
        public System.Windows.Forms.RadioButton DateRadioButton;
        public System.Windows.Forms.RadioButton NumberRadioButton;
        public System.Windows.Forms.RadioButton NextNumberRadioButton;
    }
}
