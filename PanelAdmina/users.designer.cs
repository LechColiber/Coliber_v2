namespace WindowsFormsApplication1
{
    partial class Users
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Users));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nazwa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDGVC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prawa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_rodzaj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ksiegozbiorStartowy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.UserNameTextBox = new System.Windows.Forms.TextBox();
            this.PassTextBox = new System.Windows.Forms.TextBox();
            this.Pass2TextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.RodzajeComboBox = new System.Windows.Forms.ComboBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.RightsTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nazwa,
            this.firstNameDGVC,
            this.nameDGVC,
            this.Prawa,
            this.id_rodzaj,
            this.ksiegozbiorStartowy});
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(687, 292);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView1_KeyPress);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            this.dataGridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDown);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "id";
            this.ID.HeaderText = "userID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // Nazwa
            // 
            this.Nazwa.DataPropertyName = "nazwa";
            this.Nazwa.FillWeight = 73.55392F;
            this.Nazwa.HeaderText = "Nazwa";
            this.Nazwa.Name = "Nazwa";
            this.Nazwa.ReadOnly = true;
            this.Nazwa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // firstNameDGVC
            // 
            this.firstNameDGVC.DataPropertyName = "imie";
            this.firstNameDGVC.HeaderText = "Imię";
            this.firstNameDGVC.Name = "firstNameDGVC";
            this.firstNameDGVC.ReadOnly = true;
            this.firstNameDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // nameDGVC
            // 
            this.nameDGVC.DataPropertyName = "nazwisko";
            this.nameDGVC.HeaderText = "Nazwisko";
            this.nameDGVC.Name = "nameDGVC";
            this.nameDGVC.ReadOnly = true;
            this.nameDGVC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Prawa
            // 
            this.Prawa.DataPropertyName = "prawa";
            this.Prawa.HeaderText = "Prawa";
            this.Prawa.Name = "Prawa";
            this.Prawa.ReadOnly = true;
            this.Prawa.Visible = false;
            // 
            // id_rodzaj
            // 
            this.id_rodzaj.DataPropertyName = "id_rodzaj";
            this.id_rodzaj.HeaderText = "id_rodzaj";
            this.id_rodzaj.Name = "id_rodzaj";
            this.id_rodzaj.ReadOnly = true;
            this.id_rodzaj.Visible = false;
            // 
            // ksiegozbiorStartowy
            // 
            this.ksiegozbiorStartowy.DataPropertyName = "ksiegozbiorStartowy";
            this.ksiegozbiorStartowy.FillWeight = 193.401F;
            this.ksiegozbiorStartowy.HeaderText = "Księgozbiór startowy";
            this.ksiegozbiorStartowy.Name = "ksiegozbiorStartowy";
            this.ksiegozbiorStartowy.ReadOnly = true;
            this.ksiegozbiorStartowy.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(3, 322);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Nazwa";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 374);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Hasło";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(222, 374);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ponów hasło";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserNameTextBox
            // 
            this.UserNameTextBox.Location = new System.Drawing.Point(104, 319);
            this.UserNameTextBox.MaxLength = 15;
            this.UserNameTextBox.Name = "UserNameTextBox";
            this.UserNameTextBox.Size = new System.Drawing.Size(115, 20);
            this.UserNameTextBox.TabIndex = 0;
            this.UserNameTextBox.Enter += new System.EventHandler(this.NameTextBox_Enter);
            // 
            // PassTextBox
            // 
            this.PassTextBox.Location = new System.Drawing.Point(104, 371);
            this.PassTextBox.MaxLength = 42;
            this.PassTextBox.Name = "PassTextBox";
            this.PassTextBox.Size = new System.Drawing.Size(115, 20);
            this.PassTextBox.TabIndex = 3;
            this.PassTextBox.UseSystemPasswordChar = true;
            this.PassTextBox.Enter += new System.EventHandler(this.PassTextBox_Enter);
            // 
            // Pass2TextBox
            // 
            this.Pass2TextBox.Location = new System.Drawing.Point(313, 371);
            this.Pass2TextBox.MaxLength = 42;
            this.Pass2TextBox.Name = "Pass2TextBox";
            this.Pass2TextBox.Size = new System.Drawing.Size(115, 20);
            this.Pass2TextBox.TabIndex = 4;
            this.Pass2TextBox.UseSystemPasswordChar = true;
            this.Pass2TextBox.Enter += new System.EventHandler(this.Pass2TextBox_Enter);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 428);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Prawa";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(3, 400);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Księgozbiór startowy";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Location = new System.Drawing.Point(104, 299);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.Size = new System.Drawing.Size(100, 20);
            this.IDTextBox.TabIndex = 16;
            this.IDTextBox.Visible = false;
            // 
            // RodzajeComboBox
            // 
            this.RodzajeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RodzajeComboBox.FormattingEnabled = true;
            this.RodzajeComboBox.Location = new System.Drawing.Point(104, 397);
            this.RodzajeComboBox.Name = "RodzajeComboBox";
            this.RodzajeComboBox.Size = new System.Drawing.Size(115, 21);
            this.RodzajeComboBox.TabIndex = 5;
            // 
            // CloseButton
            // 
            this.CloseButton.Image = global::WindowsFormsApplication1.Properties.Resources.door_out;
            this.CloseButton.Location = new System.Drawing.Point(575, 451);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(106, 30);
            this.CloseButton.TabIndex = 9;
            this.CloseButton.Text = "Wyjście";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.CloseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Image = global::WindowsFormsApplication1.Properties.Resources.contact_busy_overlay;
            this.DeleteButton.Location = new System.Drawing.Point(231, 451);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(106, 30);
            this.DeleteButton.TabIndex = 6;
            this.DeleteButton.Text = "Usuń";
            this.DeleteButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.DeleteButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Image = global::WindowsFormsApplication1.Properties.Resources.edycjam;
            this.EditButton.Location = new System.Drawing.Point(463, 451);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(106, 30);
            this.EditButton.TabIndex = 8;
            this.EditButton.Text = "Edytuj";
            this.EditButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EditButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Image = global::WindowsFormsApplication1.Properties.Resources.edit_add;
            this.AddButton.Location = new System.Drawing.Point(352, 451);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(106, 30);
            this.AddButton.TabIndex = 7;
            this.AddButton.Text = "Dodaj";
            this.AddButton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.AddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(431, 302);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(78, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Wyszukiwanie:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(515, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "ll";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(104, 345);
            this.firstNameTextBox.MaxLength = 15;
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(115, 20);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 348);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 34;
            this.label6.Text = "Imię";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(313, 345);
            this.nameTextBox.MaxLength = 15;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(115, 20);
            this.nameTextBox.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(222, 348);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Nazwisko";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RightsTextBox
            // 
            this.RightsTextBox.Location = new System.Drawing.Point(104, 425);
            this.RightsTextBox.MaxLength = 254;
            this.RightsTextBox.Name = "RightsTextBox";
            this.RightsTextBox.Size = new System.Drawing.Size(115, 20);
            this.RightsTextBox.TabIndex = 3;
            this.RightsTextBox.Visible = false;
            this.RightsTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.RightsTextBox_KeyPress);
            // 
            // Users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 489);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RodzajeComboBox);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.RightsTextBox);
            this.Controls.Add(this.Pass2TextBox);
            this.Controls.Add(this.PassTextBox);
            this.Controls.Add(this.UserNameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Users";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Użytkownicy systemu Co-Liber";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Users_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox UserNameTextBox;
        private System.Windows.Forms.TextBox PassTextBox;
        private System.Windows.Forms.TextBox Pass2TextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox IDTextBox;
        private System.Windows.Forms.ComboBox RodzajeComboBox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nazwa;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDGVC;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prawa;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_rodzaj;
        private System.Windows.Forms.DataGridViewTextBoxColumn ksiegozbiorStartowy;
        private System.Windows.Forms.TextBox RightsTextBox;


    }
}