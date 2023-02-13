namespace Normy
{
    partial class Szukaj
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
            this.OKButton = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pagInfo = new System.Windows.Forms.TabPage();
            this.txTytul = new System.Windows.Forms.TextBox();
            this.lbTytul = new System.Windows.Forms.Label();
            this.txNrNormy = new System.Windows.Forms.TextBox();
            this.lbNrNormy = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.pagInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKButton.Image = global::Normy.Properties.Resources.Check2;
            this.OKButton.Location = new System.Drawing.Point(298, 106);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(90, 29);
            this.OKButton.TabIndex = 1;
            this.OKButton.Text = "OK";
            this.OKButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OKButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // btCancel
            // 
            this.btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btCancel.Image = global::Normy.Properties.Resources.fileclose;
            this.btCancel.Location = new System.Drawing.Point(401, 106);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(90, 29);
            this.btCancel.TabIndex = 2;
            this.btCancel.Text = "Anuluj";
            this.btCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pagInfo);
            this.tabMain.ItemSize = new System.Drawing.Size(0, 1);
            this.tabMain.Location = new System.Drawing.Point(1, -1);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(800, 102);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 0;
            // 
            // pagInfo
            // 
            this.pagInfo.Controls.Add(this.txTytul);
            this.pagInfo.Controls.Add(this.lbTytul);
            this.pagInfo.Controls.Add(this.txNrNormy);
            this.pagInfo.Controls.Add(this.lbNrNormy);
            this.pagInfo.Location = new System.Drawing.Point(4, 5);
            this.pagInfo.Name = "pagInfo";
            this.pagInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pagInfo.Size = new System.Drawing.Size(792, 93);
            this.pagInfo.TabIndex = 0;
            this.pagInfo.Text = "tabPage1";
            this.pagInfo.UseVisualStyleBackColor = true;
            // 
            // txTytul
            // 
            this.txTytul.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txTytul.Location = new System.Drawing.Point(133, 32);
            this.txTytul.Multiline = true;
            this.txTytul.Name = "txTytul";
            this.txTytul.Size = new System.Drawing.Size(645, 49);
            this.txTytul.TabIndex = 1;
            // 
            // lbTytul
            // 
            this.lbTytul.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbTytul.Location = new System.Drawing.Point(11, 33);
            this.lbTytul.Name = "lbTytul";
            this.lbTytul.Size = new System.Drawing.Size(117, 18);
            this.lbTytul.TabIndex = 9;
            this.lbTytul.Text = "Tytuł:";
            this.lbTytul.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txNrNormy
            // 
            this.txNrNormy.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txNrNormy.Location = new System.Drawing.Point(133, 8);
            this.txNrNormy.Name = "txNrNormy";
            this.txNrNormy.Size = new System.Drawing.Size(645, 20);
            this.txNrNormy.TabIndex = 0;
            // 
            // lbNrNormy
            // 
            this.lbNrNormy.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbNrNormy.Location = new System.Drawing.Point(11, 8);
            this.lbNrNormy.Name = "lbNrNormy";
            this.lbNrNormy.Size = new System.Drawing.Size(117, 18);
            this.lbNrNormy.TabIndex = 7;
            this.lbNrNormy.Text = "Numer normy:";
            this.lbNrNormy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Szukaj
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 147);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.OKButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Szukaj";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Szukaj";
            this.tabMain.ResumeLayout(false);
            this.pagInfo.ResumeLayout(false);
            this.pagInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button btCancel;
        public System.Windows.Forms.TabControl tabMain;
        public System.Windows.Forms.TabPage pagInfo;
        private System.Windows.Forms.TextBox txTytul;
        private System.Windows.Forms.Label lbTytul;
        private System.Windows.Forms.TextBox txNrNormy;
        private System.Windows.Forms.Label lbNrNormy;
    }
}