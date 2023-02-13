namespace Normy
{
    partial class Klucz
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbOK = new System.Windows.Forms.Button();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pagInfo = new System.Windows.Forms.TabPage();
            this.txNazwa = new System.Windows.Forms.TextBox();
            this.lNazwa = new System.Windows.Forms.Label();
            this.cbCancel = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.pagInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbOK
            // 
            this.cbOK.Image = global::Normy.Properties.Resources.Check2;
            this.cbOK.Location = new System.Drawing.Point(438, 53);
            this.cbOK.Name = "cbOK";
            this.cbOK.Size = new System.Drawing.Size(75, 23);
            this.cbOK.TabIndex = 1;
            this.cbOK.Text = "OK";
            this.cbOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbOK.UseVisualStyleBackColor = true;
            this.cbOK.Click += new System.EventHandler(this.cbOK_Click);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pagInfo);
            this.tabMain.ItemSize = new System.Drawing.Size(0, 1);
            this.tabMain.Location = new System.Drawing.Point(2, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(597, 46);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 0;
            // 
            // pagInfo
            // 
            this.pagInfo.Controls.Add(this.txNazwa);
            this.pagInfo.Controls.Add(this.lNazwa);
            this.pagInfo.Location = new System.Drawing.Point(4, 5);
            this.pagInfo.Name = "pagInfo";
            this.pagInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pagInfo.Size = new System.Drawing.Size(589, 37);
            this.pagInfo.TabIndex = 0;
            this.pagInfo.Text = "tabPage1";
            this.pagInfo.UseVisualStyleBackColor = true;
            // 
            // txNazwa
            // 
            this.txNazwa.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txNazwa.Location = new System.Drawing.Point(133, 8);
            this.txNazwa.Name = "txNazwa";
            this.txNazwa.Size = new System.Drawing.Size(448, 20);
            this.txNazwa.TabIndex = 0;
            // 
            // lNazwa
            // 
            this.lNazwa.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lNazwa.Location = new System.Drawing.Point(11, 8);
            this.lNazwa.Name = "lNazwa";
            this.lNazwa.Size = new System.Drawing.Size(117, 18);
            this.lNazwa.TabIndex = 7;
            this.lNazwa.Text = "Słowo kluczowe:";
            this.lNazwa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCancel
            // 
            this.cbCancel.Image = global::Normy.Properties.Resources.fileclose;
            this.cbCancel.Location = new System.Drawing.Point(520, 53);
            this.cbCancel.Name = "cbCancel";
            this.cbCancel.Size = new System.Drawing.Size(75, 23);
            this.cbCancel.TabIndex = 2;
            this.cbCancel.Text = "Anuluj";
            this.cbCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbCancel.UseVisualStyleBackColor = true;
            this.cbCancel.Click += new System.EventHandler(this.cbCancel_Click);
            // 
            // Klucz
            // 
            this.ClientSize = new System.Drawing.Size(603, 80);
            this.Controls.Add(this.cbCancel);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.cbOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Klucz";
            this.Text = "Słowo kluczowe";
            this.tabMain.ResumeLayout(false);
            this.pagInfo.ResumeLayout(false);
            this.pagInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cbOK;
        public System.Windows.Forms.TabControl tabMain;
        public System.Windows.Forms.TabPage pagInfo;
        private System.Windows.Forms.TextBox txNazwa;
        private System.Windows.Forms.Label lNazwa;
        private System.Windows.Forms.Button cbCancel;
    }
}