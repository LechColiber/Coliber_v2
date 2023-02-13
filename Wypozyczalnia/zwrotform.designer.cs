namespace Wypozyczalnia
{
    partial class ZwrotForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZwrotForm));
            this.resourceLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dateCal = new System.Windows.Forms.MonthCalendar();
            this.returnResourceButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.prolongationButton = new System.Windows.Forms.Button();
            this.reqiureDateLabel = new System.Windows.Forms.Label();
            this.borrowDateLabel = new System.Windows.Forms.Label();
            this.lenderLabel = new System.Windows.Forms.Label();
            this.groupLabel = new System.Windows.Forms.Label();
            this.barcodeLabel = new System.Windows.Forms.Label();
            this.dateFromCalendarLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.userTextLabel = new System.Windows.Forms.Label();
            this.descRTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // resourceLabel
            // 
            this.resourceLabel.Location = new System.Drawing.Point(16, 34);
            this.resourceLabel.Name = "resourceLabel";
            this.resourceLabel.Size = new System.Drawing.Size(65, 13);
            this.resourceLabel.TabIndex = 0;
            this.resourceLabel.Text = "Zasób:";
            this.resourceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(16, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kod kreskowy:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(16, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Pracownik wypożyczający:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Grupa:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(16, 207);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Data wymagana:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Data wypożyczenia:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(13, 241);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(182, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Data zwrotu / nowa data wymagana:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dateCal
            // 
            this.dateCal.Location = new System.Drawing.Point(416, 116);
            this.dateCal.MaxSelectionCount = 1;
            this.dateCal.Name = "dateCal";
            this.dateCal.ScrollChange = 1;
            this.dateCal.TabIndex = 1;
            this.dateCal.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.dateCal_DateChanged);
            // 
            // returnResourceButton
            // 
            this.returnResourceButton.Image = ((System.Drawing.Image)(resources.GetObject("returnResourceButton.Image")));
            this.returnResourceButton.Location = new System.Drawing.Point(100, 290);
            this.returnResourceButton.Name = "returnResourceButton";
            this.returnResourceButton.Size = new System.Drawing.Size(110, 23);
            this.returnResourceButton.TabIndex = 3;
            this.returnResourceButton.Text = "Zatwierdź zwrot";
            this.returnResourceButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.returnResourceButton.UseVisualStyleBackColor = true;
            this.returnResourceButton.Click += new System.EventHandler(this.returnResourceButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
            this.ExitButton.Location = new System.Drawing.Point(498, 290);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(75, 23);
            this.ExitButton.TabIndex = 4;
            this.ExitButton.Text = "Anuluj";
            this.ExitButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // prolongationButton
            // 
            this.prolongationButton.Image = ((System.Drawing.Image)(resources.GetObject("prolongationButton.Image")));
            this.prolongationButton.Location = new System.Drawing.Point(12, 290);
            this.prolongationButton.Name = "prolongationButton";
            this.prolongationButton.Size = new System.Drawing.Size(82, 23);
            this.prolongationButton.TabIndex = 2;
            this.prolongationButton.Text = "Prolonguj";
            this.prolongationButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.prolongationButton.UseVisualStyleBackColor = true;
            this.prolongationButton.Click += new System.EventHandler(this.prolongationButton_Click);
            // 
            // reqiureDateLabel
            // 
            this.reqiureDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reqiureDateLabel.Location = new System.Drawing.Point(153, 207);
            this.reqiureDateLabel.Name = "reqiureDateLabel";
            this.reqiureDateLabel.Size = new System.Drawing.Size(114, 13);
            this.reqiureDateLabel.TabIndex = 17;
            this.reqiureDateLabel.Text = "[data wymagana]";
            // 
            // borrowDateLabel
            // 
            this.borrowDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.borrowDateLabel.Location = new System.Drawing.Point(153, 186);
            this.borrowDateLabel.Name = "borrowDateLabel";
            this.borrowDateLabel.Size = new System.Drawing.Size(133, 13);
            this.borrowDateLabel.TabIndex = 16;
            this.borrowDateLabel.Text = "[data wypożyczenia]";
            // 
            // lenderLabel
            // 
            this.lenderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lenderLabel.Location = new System.Drawing.Point(153, 165);
            this.lenderLabel.Name = "lenderLabel";
            this.lenderLabel.Size = new System.Drawing.Size(110, 13);
            this.lenderLabel.TabIndex = 15;
            this.lenderLabel.Text = "[wypożyczający]";
            // 
            // groupLabel
            // 
            this.groupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupLabel.Location = new System.Drawing.Point(153, 144);
            this.groupLabel.Name = "groupLabel";
            this.groupLabel.Size = new System.Drawing.Size(58, 13);
            this.groupLabel.TabIndex = 14;
            this.groupLabel.Text = "[grupa]";
            // 
            // barcodeLabel
            // 
            this.barcodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.barcodeLabel.Location = new System.Drawing.Point(153, 123);
            this.barcodeLabel.Name = "barcodeLabel";
            this.barcodeLabel.Size = new System.Drawing.Size(104, 13);
            this.barcodeLabel.TabIndex = 13;
            this.barcodeLabel.Text = "[kod kreskowy]";
            // 
            // dateFromCalendarLabel
            // 
            this.dateFromCalendarLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateFromCalendarLabel.Location = new System.Drawing.Point(153, 265);
            this.dateFromCalendarLabel.Name = "dateFromCalendarLabel";
            this.dateFromCalendarLabel.Size = new System.Drawing.Size(146, 13);
            this.dateFromCalendarLabel.TabIndex = 18;
            this.dateFromCalendarLabel.Text = "[nowa/wymagana]";
            this.dateFromCalendarLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userLabel.Location = new System.Drawing.Point(84, 9);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(78, 13);
            this.userLabel.TabIndex = 20;
            this.userLabel.Text = "[użytkownik]";
            // 
            // userTextLabel
            // 
            this.userTextLabel.Location = new System.Drawing.Point(12, 9);
            this.userTextLabel.Name = "userTextLabel";
            this.userTextLabel.Size = new System.Drawing.Size(69, 13);
            this.userTextLabel.TabIndex = 19;
            this.userTextLabel.Text = "Użytkownik:";
            this.userTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // descRTB
            // 
            this.descRTB.Location = new System.Drawing.Point(88, 34);
            this.descRTB.Name = "descRTB";
            this.descRTB.ReadOnly = true;
            this.descRTB.Size = new System.Drawing.Size(485, 70);
            this.descRTB.TabIndex = 0;
            this.descRTB.Text = "";
            // 
            // ZwrotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 325);
            this.Controls.Add(this.descRTB);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.userTextLabel);
            this.Controls.Add(this.dateFromCalendarLabel);
            this.Controls.Add(this.reqiureDateLabel);
            this.Controls.Add(this.borrowDateLabel);
            this.Controls.Add(this.lenderLabel);
            this.Controls.Add(this.groupLabel);
            this.Controls.Add(this.barcodeLabel);
            this.Controls.Add(this.prolongationButton);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.returnResourceButton);
            this.Controls.Add(this.dateCal);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resourceLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "ZwrotForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zwrot zasobu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ZwrotForm_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ZwrotForm_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label resourceLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MonthCalendar dateCal;
        private System.Windows.Forms.Button returnResourceButton;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button prolongationButton;
        private System.Windows.Forms.Label reqiureDateLabel;
        private System.Windows.Forms.Label borrowDateLabel;
        private System.Windows.Forms.Label lenderLabel;
        private System.Windows.Forms.Label groupLabel;
        private System.Windows.Forms.Label barcodeLabel;
        private System.Windows.Forms.Label dateFromCalendarLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label userTextLabel;
        private System.Windows.Forms.RichTextBox descRTB;
    }
}