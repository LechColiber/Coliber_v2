namespace Normy
{
    partial class Dokument
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.pagInfo = new System.Windows.Forms.TabPage();
            this.btAttach = new System.Windows.Forms.Button();
            this.txOpis = new System.Windows.Forms.TextBox();
            this.lbOpis = new System.Windows.Forms.Label();
            this.txNazwa = new System.Windows.Forms.TextBox();
            this.lbNazwa = new System.Windows.Forms.Label();
            this.cbCancel = new System.Windows.Forms.Button();
            this.cbOK = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.pagInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.pagInfo);
            this.tabMain.ItemSize = new System.Drawing.Size(0, 1);
            this.tabMain.Location = new System.Drawing.Point(2, 3);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(800, 154);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 0;
            // 
            // pagInfo
            // 
            this.pagInfo.Controls.Add(this.btAttach);
            this.pagInfo.Controls.Add(this.txOpis);
            this.pagInfo.Controls.Add(this.lbOpis);
            this.pagInfo.Controls.Add(this.txNazwa);
            this.pagInfo.Controls.Add(this.lbNazwa);
            this.pagInfo.Location = new System.Drawing.Point(4, 5);
            this.pagInfo.Name = "pagInfo";
            this.pagInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pagInfo.Size = new System.Drawing.Size(792, 145);
            this.pagInfo.TabIndex = 0;
            this.pagInfo.Text = "tabPage1";
            this.pagInfo.UseVisualStyleBackColor = true;
            // 
            // btAttach
            // 
            this.btAttach.Location = new System.Drawing.Point(133, 6);
            this.btAttach.Name = "btAttach";
            this.btAttach.Size = new System.Drawing.Size(32, 23);
            this.btAttach.TabIndex = 0;
            this.btAttach.Text = "...";
            this.btAttach.UseVisualStyleBackColor = true;
            this.btAttach.Click += new System.EventHandler(this.btAttach_Click);
            // 
            // txOpis
            // 
            this.txOpis.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txOpis.Location = new System.Drawing.Point(133, 32);
            this.txOpis.Multiline = true;
            this.txOpis.Name = "txOpis";
            this.txOpis.Size = new System.Drawing.Size(645, 107);
            this.txOpis.TabIndex = 2;
            // 
            // lbOpis
            // 
            this.lbOpis.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbOpis.Location = new System.Drawing.Point(11, 33);
            this.lbOpis.Name = "lbOpis";
            this.lbOpis.Size = new System.Drawing.Size(117, 18);
            this.lbOpis.TabIndex = 9;
            this.lbOpis.Text = "Opis:";
            this.lbOpis.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txNazwa
            // 
            this.txNazwa.Enabled = false;
            this.txNazwa.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txNazwa.Location = new System.Drawing.Point(171, 8);
            this.txNazwa.Name = "txNazwa";
            this.txNazwa.Size = new System.Drawing.Size(607, 20);
            this.txNazwa.TabIndex = 1;
            // 
            // lbNazwa
            // 
            this.lbNazwa.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbNazwa.Location = new System.Drawing.Point(11, 8);
            this.lbNazwa.Name = "lbNazwa";
            this.lbNazwa.Size = new System.Drawing.Size(117, 18);
            this.lbNazwa.TabIndex = 7;
            this.lbNazwa.Text = "Plik:";
            this.lbNazwa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCancel
            // 
            this.cbCancel.Image = global::Normy.Properties.Resources.fileclose;
            this.cbCancel.Location = new System.Drawing.Point(723, 162);
            this.cbCancel.Name = "cbCancel";
            this.cbCancel.Size = new System.Drawing.Size(75, 23);
            this.cbCancel.TabIndex = 4;
            this.cbCancel.Text = "Anuluj";
            this.cbCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbCancel.UseVisualStyleBackColor = true;
            this.cbCancel.Click += new System.EventHandler(this.cbCancel_Click);
            // 
            // cbOK
            // 
            this.cbOK.Image = global::Normy.Properties.Resources.Check2;
            this.cbOK.Location = new System.Drawing.Point(641, 162);
            this.cbOK.Name = "cbOK";
            this.cbOK.Size = new System.Drawing.Size(75, 23);
            this.cbOK.TabIndex = 3;
            this.cbOK.Text = "OK";
            this.cbOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbOK.UseVisualStyleBackColor = true;
            this.cbOK.Click += new System.EventHandler(this.cbOK_Click);
            // 
            // Dokument
            // 
            this.ClientSize = new System.Drawing.Size(804, 192);
            this.Controls.Add(this.cbCancel);
            this.Controls.Add(this.cbOK);
            this.Controls.Add(this.tabMain);
            this.Name = "Dokument";
            this.Text = "Załączony dokument";
            this.tabMain.ResumeLayout(false);
            this.pagInfo.ResumeLayout(false);
            this.pagInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TabControl tabMain;
        public System.Windows.Forms.TabPage pagInfo;
        private System.Windows.Forms.TextBox txOpis;
        private System.Windows.Forms.Label lbOpis;
        private System.Windows.Forms.TextBox txNazwa;
        private System.Windows.Forms.Label lbNazwa;
        private System.Windows.Forms.Button btAttach;
        private System.Windows.Forms.Button cbCancel;
        private System.Windows.Forms.Button cbOK;
    }
}