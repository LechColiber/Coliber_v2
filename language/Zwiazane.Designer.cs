namespace Normy
{
    partial class Zwiazane
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
            this.txTytul = new System.Windows.Forms.TextBox();
            this.lTytul = new System.Windows.Forms.Label();
            this.txSygnatura = new System.Windows.Forms.TextBox();
            this.lSygnatura = new System.Windows.Forms.Label();
            this.cbCancel = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.pagInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbOK
            // 
            this.cbOK.Location = new System.Drawing.Point(622, 109);
            this.cbOK.Name = "cbOK";
            this.cbOK.Size = new System.Drawing.Size(75, 23);
            this.cbOK.TabIndex = 1;
            this.cbOK.Text = "Zapisz";
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
            this.tabMain.Size = new System.Drawing.Size(800, 100);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 0;
            // 
            // pagInfo
            // 
            this.pagInfo.Controls.Add(this.txTytul);
            this.pagInfo.Controls.Add(this.lTytul);
            this.pagInfo.Controls.Add(this.txSygnatura);
            this.pagInfo.Controls.Add(this.lSygnatura);
            this.pagInfo.Location = new System.Drawing.Point(4, 5);
            this.pagInfo.Name = "pagInfo";
            this.pagInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pagInfo.Size = new System.Drawing.Size(792, 91);
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
            // lTytul
            // 
            this.lTytul.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lTytul.Location = new System.Drawing.Point(11, 33);
            this.lTytul.Name = "lTytul";
            this.lTytul.Size = new System.Drawing.Size(117, 18);
            this.lTytul.TabIndex = 9;
            this.lTytul.Text = "Tytuł:";
            this.lTytul.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txSygnatura
            // 
            this.txSygnatura.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txSygnatura.Location = new System.Drawing.Point(133, 8);
            this.txSygnatura.Name = "txSygnatura";
            this.txSygnatura.Size = new System.Drawing.Size(645, 20);
            this.txSygnatura.TabIndex = 0;
            // 
            // lSygnatura
            // 
            this.lSygnatura.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lSygnatura.Location = new System.Drawing.Point(11, 8);
            this.lSygnatura.Name = "lSygnatura";
            this.lSygnatura.Size = new System.Drawing.Size(117, 18);
            this.lSygnatura.TabIndex = 7;
            this.lSygnatura.Text = "Numer normy:";
            this.lSygnatura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCancel
            // 
            this.cbCancel.Location = new System.Drawing.Point(704, 109);
            this.cbCancel.Name = "cbCancel";
            this.cbCancel.Size = new System.Drawing.Size(75, 23);
            this.cbCancel.TabIndex = 2;
            this.cbCancel.Text = "Anuluj";
            this.cbCancel.UseVisualStyleBackColor = true;
            this.cbCancel.Click += new System.EventHandler(this.cbCancel_Click);
            // 
            // Zwiazane
            // 
            this.ClientSize = new System.Drawing.Size(804, 136);
            this.Controls.Add(this.cbCancel);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.cbOK);
            this.Name = "Zwiazane";
            this.Text = "Norma związana";
            this.tabMain.ResumeLayout(false);
            this.pagInfo.ResumeLayout(false);
            this.pagInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cbOK;
        public System.Windows.Forms.TabControl tabMain;
        public System.Windows.Forms.TabPage pagInfo;
        private System.Windows.Forms.TextBox txTytul;
        private System.Windows.Forms.Label lTytul;
        private System.Windows.Forms.TextBox txSygnatura;
        private System.Windows.Forms.Label lSygnatura;
        private System.Windows.Forms.Button cbCancel;
    }
}