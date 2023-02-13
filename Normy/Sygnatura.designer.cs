namespace Normy
{
    partial class Sygnatura
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
            this.dpData = new Coliber.NullableDTP();
            this.lbData = new System.Windows.Forms.Label();
            this.txSygnatura = new System.Windows.Forms.TextBox();
            this.lbSygnatura = new System.Windows.Forms.Label();
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
            this.tabMain.Size = new System.Drawing.Size(339, 73);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 0;
            // 
            // pagInfo
            // 
            this.pagInfo.Controls.Add(this.dpData);
            this.pagInfo.Controls.Add(this.lbData);
            this.pagInfo.Controls.Add(this.txSygnatura);
            this.pagInfo.Controls.Add(this.lbSygnatura);
            this.pagInfo.Location = new System.Drawing.Point(4, 5);
            this.pagInfo.Name = "pagInfo";
            this.pagInfo.Padding = new System.Windows.Forms.Padding(3);
            this.pagInfo.Size = new System.Drawing.Size(331, 64);
            this.pagInfo.TabIndex = 0;
            this.pagInfo.Text = "tabPage1";
            this.pagInfo.UseVisualStyleBackColor = true;
            // 
            // dpData
            // 
            this.dpData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpData.Location = new System.Drawing.Point(134, 32);
            this.dpData.Name = "dpData";
            this.dpData.Size = new System.Drawing.Size(173, 20);
            this.dpData.TabIndex = 16;
            this.dpData.Value = new System.DateTime(2019, 9, 13, 0, 0, 0, 0);
            // 
            // lbData
            // 
            this.lbData.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbData.Location = new System.Drawing.Point(11, 33);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(117, 18);
            this.lbData.TabIndex = 9;
            this.lbData.Text = "Data przyjęcia:";
            this.lbData.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txSygnatura
            // 
            this.txSygnatura.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txSygnatura.Location = new System.Drawing.Point(133, 8);
            this.txSygnatura.Name = "txSygnatura";
            this.txSygnatura.Size = new System.Drawing.Size(174, 20);
            this.txSygnatura.TabIndex = 0;
            // 
            // lbSygnatura
            // 
            this.lbSygnatura.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbSygnatura.Location = new System.Drawing.Point(11, 8);
            this.lbSygnatura.Name = "lbSygnatura";
            this.lbSygnatura.Size = new System.Drawing.Size(117, 18);
            this.lbSygnatura.TabIndex = 7;
            this.lbSygnatura.Text = "Sygnatura:";
            this.lbSygnatura.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCancel
            // 
            this.cbCancel.Image = global::Normy.Properties.Resources.fileclose;
            this.cbCancel.Location = new System.Drawing.Point(261, 80);
            this.cbCancel.Name = "cbCancel";
            this.cbCancel.Size = new System.Drawing.Size(75, 23);
            this.cbCancel.TabIndex = 6;
            this.cbCancel.Text = "Anuluj";
            this.cbCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbCancel.UseVisualStyleBackColor = true;
            this.cbCancel.Click += new System.EventHandler(this.cbCancel_Click);
            // 
            // cbOK
            // 
            this.cbOK.Image = global::Normy.Properties.Resources.Check2;
            this.cbOK.Location = new System.Drawing.Point(179, 80);
            this.cbOK.Name = "cbOK";
            this.cbOK.Size = new System.Drawing.Size(75, 23);
            this.cbOK.TabIndex = 5;
            this.cbOK.Text = "OK";
            this.cbOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.cbOK.UseVisualStyleBackColor = true;
            this.cbOK.Click += new System.EventHandler(this.cbOK_Click);
            // 
            // Sygnatura
            // 
            this.ClientSize = new System.Drawing.Size(344, 108);
            this.Controls.Add(this.cbCancel);
            this.Controls.Add(this.cbOK);
            this.Controls.Add(this.tabMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Sygnatura";
            this.Text = "Sygnatura";
            this.tabMain.ResumeLayout(false);
            this.pagInfo.ResumeLayout(false);
            this.pagInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.TabControl tabMain;
        public System.Windows.Forms.TabPage pagInfo;
        private System.Windows.Forms.Label lbData;
        private System.Windows.Forms.TextBox txSygnatura;
        private System.Windows.Forms.Label lbSygnatura;
        private Coliber.NullableDTP dpData;
        private System.Windows.Forms.Button cbCancel;
        private System.Windows.Forms.Button cbOK;
    }
}