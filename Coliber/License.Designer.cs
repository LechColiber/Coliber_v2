namespace Coliber
{
    partial class License
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
            this.cbOK = new System.Windows.Forms.Button();
            this.tLInfo = new System.Windows.Forms.TextBox();
            this.lLinfo = new System.Windows.Forms.Label();
            this.lLDate = new System.Windows.Forms.Label();
            this.tLDate = new System.Windows.Forms.TextBox();
            this.lLKey = new System.Windows.Forms.Label();
            this.tLKey = new System.Windows.Forms.MaskedTextBox();
            this.cbBuy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbOK
            // 
            this.cbOK.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbOK.Location = new System.Drawing.Point(581, 90);
            this.cbOK.Name = "cbOK";
            this.cbOK.Size = new System.Drawing.Size(75, 23);
            this.cbOK.TabIndex = 4;
            this.cbOK.Text = "OK";
            this.cbOK.UseVisualStyleBackColor = true;
            this.cbOK.Click += new System.EventHandler(this.cbOK_Click);
            // 
            // tLInfo
            // 
            this.tLInfo.BackColor = System.Drawing.SystemColors.Info;
            this.tLInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tLInfo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.tLInfo.Location = new System.Drawing.Point(172, 13);
            this.tLInfo.Name = "tLInfo";
            this.tLInfo.ReadOnly = true;
            this.tLInfo.Size = new System.Drawing.Size(483, 21);
            this.tLInfo.TabIndex = 0;
            // 
            // lLinfo
            // 
            this.lLinfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lLinfo.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lLinfo.Location = new System.Drawing.Point(12, 13);
            this.lLinfo.Name = "lLinfo";
            this.lLinfo.Size = new System.Drawing.Size(143, 20);
            this.lLinfo.TabIndex = 5;
            this.lLinfo.Text = "Licencja dla:";
            this.lLinfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lLDate
            // 
            this.lLDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lLDate.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lLDate.Location = new System.Drawing.Point(12, 63);
            this.lLDate.Name = "lLDate";
            this.lLDate.Size = new System.Drawing.Size(143, 20);
            this.lLDate.TabIndex = 6;
            this.lLDate.Text = "Uzyskana dnia:";
            this.lLDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tLDate
            // 
            this.tLDate.BackColor = System.Drawing.SystemColors.Info;
            this.tLDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tLDate.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.tLDate.Location = new System.Drawing.Point(172, 63);
            this.tLDate.Name = "tLDate";
            this.tLDate.ReadOnly = true;
            this.tLDate.Size = new System.Drawing.Size(483, 21);
            this.tLDate.TabIndex = 2;
            // 
            // lLKey
            // 
            this.lLKey.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lLKey.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.lLKey.Location = new System.Drawing.Point(12, 38);
            this.lLKey.Name = "lLKey";
            this.lLKey.Size = new System.Drawing.Size(143, 20);
            this.lLKey.TabIndex = 7;
            this.lLKey.Text = "Klucz licencji:";
            this.lLKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tLKey
            // 
            this.tLKey.BackColor = System.Drawing.SystemColors.Info;
            this.tLKey.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tLKey.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.tLKey.Location = new System.Drawing.Point(172, 38);
            this.tLKey.Name = "tLKey";
            this.tLKey.PromptChar = ' ';
            this.tLKey.ReadOnly = true;
            this.tLKey.Size = new System.Drawing.Size(483, 21);
            this.tLKey.TabIndex = 1;
            // 
            // cbBuy
            // 
            this.cbBuy.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbBuy.Location = new System.Drawing.Point(172, 90);
            this.cbBuy.Name = "cbBuy";
            this.cbBuy.Size = new System.Drawing.Size(335, 23);
            this.cbBuy.TabIndex = 3;
            this.cbBuy.Text = "Wprowadź dane licencji";
            this.cbBuy.UseVisualStyleBackColor = true;
            this.cbBuy.Click += new System.EventHandler(this.cbBuy_Click);
            // 
            // License
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(702, 123);
            this.Controls.Add(this.cbBuy);
            this.Controls.Add(this.lLKey);
            this.Controls.Add(this.tLKey);
            this.Controls.Add(this.lLDate);
            this.Controls.Add(this.tLDate);
            this.Controls.Add(this.lLinfo);
            this.Controls.Add(this.tLInfo);
            this.Controls.Add(this.cbOK);
            this.Name = "License";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Coliber - informacje o licencji";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cbOK;
        private System.Windows.Forms.TextBox tLInfo;
        private System.Windows.Forms.Label lLinfo;
        private System.Windows.Forms.Label lLDate;
        private System.Windows.Forms.TextBox tLDate;
        private System.Windows.Forms.Label lLKey;
        private System.Windows.Forms.MaskedTextBox tLKey;
        private System.Windows.Forms.Button cbBuy;
    }
}