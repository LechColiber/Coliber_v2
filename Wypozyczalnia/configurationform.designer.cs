namespace Wypozyczalnia
{
    partial class ConfigurationForm
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
            Wypozyczalnia.GroupCollection groupCollection1 = new Wypozyczalnia.GroupCollection();
            Wypozyczalnia.GroupCollection groupCollection2 = new Wypozyczalnia.GroupCollection();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.othersTabControl = new System.Windows.Forms.TabControl();
            this.usersGroupsTabPage = new System.Windows.Forms.TabPage();
            this.userGroupUC = new Wypozyczalnia.UserGroupUC();
            this.resourcesGroupsTabPage = new System.Windows.Forms.TabPage();
            this.resourceGroupUC = new Wypozyczalnia.ResourceGroupUC();
            this.reverseTabPage = new System.Windows.Forms.TabPage();
            this.manualPrintRadioButton = new System.Windows.Forms.RadioButton();
            this.semiautoPrintRadioButton = new System.Windows.Forms.RadioButton();
            this.autoPrintRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.searchTabPage = new System.Windows.Forms.TabPage();
            this.manualSearchConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.compareComboBox = new System.Windows.Forms.ComboBox();
            this.searchFieldComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.autoSearchConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.noInvAutoSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.sigAutoSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.barcodeAutoSearchRadioButton = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.sortTabPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sort4ComboBox = new System.Windows.Forms.ComboBox();
            this.sort3ComboBox = new System.Windows.Forms.ComboBox();
            this.sort2ComboBox = new System.Windows.Forms.ComboBox();
            this.sort1ComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.usersTabPage = new System.Windows.Forms.TabPage();
            this.onlyInformationUserIsLockedRadioButton = new System.Windows.Forms.RadioButton();
            this.requiredNotLockedUserRadioButton = new System.Windows.Forms.RadioButton();
            this.label9 = new System.Windows.Forms.Label();
            this.aboutUserTabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.libraryPhoneTextBox = new System.Windows.Forms.TextBox();
            this.libraryZipTextBox = new System.Windows.Forms.TextBox();
            this.libraryCityTextBox = new System.Windows.Forms.TextBox();
            this.libraryStreetTextBox = new System.Windows.Forms.TextBox();
            this.libraryNameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.othersTabPage = new System.Windows.Forms.TabPage();
            this.showBarcodeColumnCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.escapeButton = new System.Windows.Forms.Button();
            this.othersTabControl.SuspendLayout();
            this.usersGroupsTabPage.SuspendLayout();
            this.resourcesGroupsTabPage.SuspendLayout();
            this.reverseTabPage.SuspendLayout();
            this.searchTabPage.SuspendLayout();
            this.manualSearchConfigGroupBox.SuspendLayout();
            this.autoSearchConfigGroupBox.SuspendLayout();
            this.sortTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.usersTabPage.SuspendLayout();
            this.aboutUserTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            this.othersTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // othersTabControl
            // 
            this.othersTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.othersTabControl.Controls.Add(this.usersGroupsTabPage);
            this.othersTabControl.Controls.Add(this.resourcesGroupsTabPage);
            this.othersTabControl.Controls.Add(this.reverseTabPage);
            this.othersTabControl.Controls.Add(this.searchTabPage);
            this.othersTabControl.Controls.Add(this.sortTabPage);
            this.othersTabControl.Controls.Add(this.usersTabPage);
            this.othersTabControl.Controls.Add(this.aboutUserTabPage);
            this.othersTabControl.Controls.Add(this.othersTabPage);
            this.othersTabControl.Location = new System.Drawing.Point(0, 0);
            this.othersTabControl.Name = "othersTabControl";
            this.othersTabControl.SelectedIndex = 0;
            this.othersTabControl.Size = new System.Drawing.Size(784, 528);
            this.othersTabControl.TabIndex = 0;
            // 
            // usersGroupsTabPage
            // 
            this.usersGroupsTabPage.Controls.Add(this.userGroupUC);
            this.usersGroupsTabPage.Location = new System.Drawing.Point(4, 22);
            this.usersGroupsTabPage.Name = "usersGroupsTabPage";
            this.usersGroupsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.usersGroupsTabPage.Size = new System.Drawing.Size(776, 502);
            this.usersGroupsTabPage.TabIndex = 0;
            this.usersGroupsTabPage.Text = "Grupa użytkowników";
            this.usersGroupsTabPage.UseVisualStyleBackColor = true;
            // 
            // userGroupUC
            // 
            this.userGroupUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userGroupUC.Groups = groupCollection1;
            this.userGroupUC.Location = new System.Drawing.Point(3, 3);
            this.userGroupUC.Name = "userGroupUC";
            this.userGroupUC.Size = new System.Drawing.Size(770, 496);
            this.userGroupUC.TabIndex = 0;
            // 
            // resourcesGroupsTabPage
            // 
            this.resourcesGroupsTabPage.Controls.Add(this.resourceGroupUC);
            this.resourcesGroupsTabPage.Location = new System.Drawing.Point(4, 22);
            this.resourcesGroupsTabPage.Name = "resourcesGroupsTabPage";
            this.resourcesGroupsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.resourcesGroupsTabPage.Size = new System.Drawing.Size(776, 502);
            this.resourcesGroupsTabPage.TabIndex = 1;
            this.resourcesGroupsTabPage.Text = "Grupa zasobów";
            this.resourcesGroupsTabPage.UseVisualStyleBackColor = true;
            // 
            // resourceGroupUC
            // 
            this.resourceGroupUC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourceGroupUC.Groups = groupCollection2;
            this.resourceGroupUC.Location = new System.Drawing.Point(3, 3);
            this.resourceGroupUC.Name = "resourceGroupUC";
            this.resourceGroupUC.Size = new System.Drawing.Size(770, 496);
            this.resourceGroupUC.TabIndex = 0;
            // 
            // reverseTabPage
            // 
            this.reverseTabPage.Controls.Add(this.manualPrintRadioButton);
            this.reverseTabPage.Controls.Add(this.semiautoPrintRadioButton);
            this.reverseTabPage.Controls.Add(this.autoPrintRadioButton);
            this.reverseTabPage.Controls.Add(this.label1);
            this.reverseTabPage.Location = new System.Drawing.Point(4, 22);
            this.reverseTabPage.Name = "reverseTabPage";
            this.reverseTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.reverseTabPage.Size = new System.Drawing.Size(776, 502);
            this.reverseTabPage.TabIndex = 2;
            this.reverseTabPage.Text = "Rewers";
            this.reverseTabPage.UseVisualStyleBackColor = true;
            // 
            // manualPrintRadioButton
            // 
            this.manualPrintRadioButton.Location = new System.Drawing.Point(26, 79);
            this.manualPrintRadioButton.Name = "manualPrintRadioButton";
            this.manualPrintRadioButton.Size = new System.Drawing.Size(372, 17);
            this.manualPrintRadioButton.TabIndex = 3;
            this.manualPrintRadioButton.Text = "Ręcznie (podgląd wydruku po kliknięciu w przycisk „Drukuj rewers”)";
            this.manualPrintRadioButton.UseVisualStyleBackColor = true;
            // 
            // semiautoPrintRadioButton
            // 
            this.semiautoPrintRadioButton.Location = new System.Drawing.Point(26, 56);
            this.semiautoPrintRadioButton.Name = "semiautoPrintRadioButton";
            this.semiautoPrintRadioButton.Size = new System.Drawing.Size(332, 17);
            this.semiautoPrintRadioButton.TabIndex = 2;
            this.semiautoPrintRadioButton.Text = "Półautomatycznie (na ekranie pojawia się podgląd rewersu)";
            this.semiautoPrintRadioButton.UseVisualStyleBackColor = true;
            // 
            // autoPrintRadioButton
            // 
            this.autoPrintRadioButton.Checked = true;
            this.autoPrintRadioButton.Location = new System.Drawing.Point(25, 33);
            this.autoPrintRadioButton.Name = "autoPrintRadioButton";
            this.autoPrintRadioButton.Size = new System.Drawing.Size(461, 17);
            this.autoPrintRadioButton.TabIndex = 1;
            this.autoPrintRadioButton.TabStop = true;
            this.autoPrintRadioButton.Text = "Automatycznie (wydruk od razu wysyłany jest do drukarki domyślnej systemu Windows" +
                ")";
            this.autoPrintRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drukowanie rewersu po wypożyczeniu:";
            // 
            // searchTabPage
            // 
            this.searchTabPage.Controls.Add(this.manualSearchConfigGroupBox);
            this.searchTabPage.Controls.Add(this.autoSearchConfigGroupBox);
            this.searchTabPage.Location = new System.Drawing.Point(4, 22);
            this.searchTabPage.Name = "searchTabPage";
            this.searchTabPage.Size = new System.Drawing.Size(776, 502);
            this.searchTabPage.TabIndex = 3;
            this.searchTabPage.Text = "Wyszukiwanie";
            this.searchTabPage.UseVisualStyleBackColor = true;
            // 
            // manualSearchConfigGroupBox
            // 
            this.manualSearchConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.manualSearchConfigGroupBox.Controls.Add(this.compareComboBox);
            this.manualSearchConfigGroupBox.Controls.Add(this.searchFieldComboBox);
            this.manualSearchConfigGroupBox.Controls.Add(this.label3);
            this.manualSearchConfigGroupBox.Location = new System.Drawing.Point(8, 138);
            this.manualSearchConfigGroupBox.Name = "manualSearchConfigGroupBox";
            this.manualSearchConfigGroupBox.Size = new System.Drawing.Size(760, 110);
            this.manualSearchConfigGroupBox.TabIndex = 1;
            this.manualSearchConfigGroupBox.TabStop = false;
            this.manualSearchConfigGroupBox.Text = "Wyszukiwanie ręczne";
            // 
            // compareComboBox
            // 
            this.compareComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.compareComboBox.FormattingEnabled = true;
            this.compareComboBox.Location = new System.Drawing.Point(37, 77);
            this.compareComboBox.Name = "compareComboBox";
            this.compareComboBox.Size = new System.Drawing.Size(190, 21);
            this.compareComboBox.TabIndex = 1;
            // 
            // searchFieldComboBox
            // 
            this.searchFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchFieldComboBox.FormattingEnabled = true;
            this.searchFieldComboBox.Location = new System.Drawing.Point(37, 50);
            this.searchFieldComboBox.Name = "searchFieldComboBox";
            this.searchFieldComboBox.Size = new System.Drawing.Size(190, 21);
            this.searchFieldComboBox.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(15, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(443, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Domyślne ustawienie wartości rozwijanych list w oknie wyszukiwania zasobów:";
            // 
            // autoSearchConfigGroupBox
            // 
            this.autoSearchConfigGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.autoSearchConfigGroupBox.Controls.Add(this.noInvAutoSearchRadioButton);
            this.autoSearchConfigGroupBox.Controls.Add(this.sigAutoSearchRadioButton);
            this.autoSearchConfigGroupBox.Controls.Add(this.barcodeAutoSearchRadioButton);
            this.autoSearchConfigGroupBox.Controls.Add(this.label2);
            this.autoSearchConfigGroupBox.Location = new System.Drawing.Point(8, 9);
            this.autoSearchConfigGroupBox.Name = "autoSearchConfigGroupBox";
            this.autoSearchConfigGroupBox.Size = new System.Drawing.Size(760, 123);
            this.autoSearchConfigGroupBox.TabIndex = 0;
            this.autoSearchConfigGroupBox.TabStop = false;
            this.autoSearchConfigGroupBox.Text = "Wyszukiwanie automatyczne";
            // 
            // noInvAutoSearchRadioButton
            // 
            this.noInvAutoSearchRadioButton.Location = new System.Drawing.Point(37, 93);
            this.noInvAutoSearchRadioButton.Name = "noInvAutoSearchRadioButton";
            this.noInvAutoSearchRadioButton.Size = new System.Drawing.Size(210, 17);
            this.noInvAutoSearchRadioButton.TabIndex = 2;
            this.noInvAutoSearchRadioButton.Text = "Numer inwentarzowy";
            this.noInvAutoSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // sigAutoSearchRadioButton
            // 
            this.sigAutoSearchRadioButton.Location = new System.Drawing.Point(37, 70);
            this.sigAutoSearchRadioButton.Name = "sigAutoSearchRadioButton";
            this.sigAutoSearchRadioButton.Size = new System.Drawing.Size(190, 17);
            this.sigAutoSearchRadioButton.TabIndex = 1;
            this.sigAutoSearchRadioButton.Text = "Sygnatura";
            this.sigAutoSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // barcodeAutoSearchRadioButton
            // 
            this.barcodeAutoSearchRadioButton.Checked = true;
            this.barcodeAutoSearchRadioButton.Location = new System.Drawing.Point(37, 47);
            this.barcodeAutoSearchRadioButton.Name = "barcodeAutoSearchRadioButton";
            this.barcodeAutoSearchRadioButton.Size = new System.Drawing.Size(166, 17);
            this.barcodeAutoSearchRadioButton.TabIndex = 0;
            this.barcodeAutoSearchRadioButton.TabStop = true;
            this.barcodeAutoSearchRadioButton.Text = "Kod kreskowy";
            this.barcodeAutoSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(15, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(292, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Domyślne kryterium wyszukiwania automatycznego:";
            // 
            // sortTabPage
            // 
            this.sortTabPage.Controls.Add(this.groupBox1);
            this.sortTabPage.Location = new System.Drawing.Point(4, 22);
            this.sortTabPage.Name = "sortTabPage";
            this.sortTabPage.Size = new System.Drawing.Size(776, 502);
            this.sortTabPage.TabIndex = 4;
            this.sortTabPage.Text = "Sortowanie";
            this.sortTabPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.sort4ComboBox);
            this.groupBox1.Controls.Add(this.sort3ComboBox);
            this.groupBox1.Controls.Add(this.sort2ComboBox);
            this.groupBox1.Controls.Add(this.sort1ComboBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(8, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 194);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ustawienie sortowania";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 140);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "4.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "3.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "2.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "1.";
            // 
            // sort4ComboBox
            // 
            this.sort4ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sort4ComboBox.FormattingEnabled = true;
            this.sort4ComboBox.Location = new System.Drawing.Point(54, 137);
            this.sort4ComboBox.Name = "sort4ComboBox";
            this.sort4ComboBox.Size = new System.Drawing.Size(141, 21);
            this.sort4ComboBox.TabIndex = 3;
            this.sort4ComboBox.SelectionChangeCommitted += new System.EventHandler(this.sort4ComboBox_SelectionChangeCommitted);
            // 
            // sort3ComboBox
            // 
            this.sort3ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sort3ComboBox.FormattingEnabled = true;
            this.sort3ComboBox.Location = new System.Drawing.Point(54, 110);
            this.sort3ComboBox.Name = "sort3ComboBox";
            this.sort3ComboBox.Size = new System.Drawing.Size(141, 21);
            this.sort3ComboBox.TabIndex = 2;
            this.sort3ComboBox.SelectionChangeCommitted += new System.EventHandler(this.sort3ComboBox_SelectionChangeCommitted);
            // 
            // sort2ComboBox
            // 
            this.sort2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sort2ComboBox.FormattingEnabled = true;
            this.sort2ComboBox.Location = new System.Drawing.Point(54, 83);
            this.sort2ComboBox.Name = "sort2ComboBox";
            this.sort2ComboBox.Size = new System.Drawing.Size(141, 21);
            this.sort2ComboBox.TabIndex = 1;
            this.sort2ComboBox.SelectionChangeCommitted += new System.EventHandler(this.sort2ComboBox_SelectionChangeCommitted);
            // 
            // sort1ComboBox
            // 
            this.sort1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sort1ComboBox.FormattingEnabled = true;
            this.sort1ComboBox.Location = new System.Drawing.Point(54, 56);
            this.sort1ComboBox.Name = "sort1ComboBox";
            this.sort1ComboBox.Size = new System.Drawing.Size(141, 21);
            this.sort1ComboBox.TabIndex = 0;
            this.sort1ComboBox.SelectionChangeCommitted += new System.EventHandler(this.sort1ComboBox_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(17, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(472, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Kolejność kryteriów sortowania wyników wyszukiwania zasobów w oknie \"Wybór zasobu" +
                "\":";
            // 
            // usersTabPage
            // 
            this.usersTabPage.Controls.Add(this.onlyInformationUserIsLockedRadioButton);
            this.usersTabPage.Controls.Add(this.requiredNotLockedUserRadioButton);
            this.usersTabPage.Controls.Add(this.label9);
            this.usersTabPage.Location = new System.Drawing.Point(4, 22);
            this.usersTabPage.Name = "usersTabPage";
            this.usersTabPage.Size = new System.Drawing.Size(776, 502);
            this.usersTabPage.TabIndex = 5;
            this.usersTabPage.Text = "Użytkownicy";
            this.usersTabPage.UseVisualStyleBackColor = true;
            // 
            // onlyInformationUserIsLockedRadioButton
            // 
            this.onlyInformationUserIsLockedRadioButton.Location = new System.Drawing.Point(25, 56);
            this.onlyInformationUserIsLockedRadioButton.Name = "onlyInformationUserIsLockedRadioButton";
            this.onlyInformationUserIsLockedRadioButton.Size = new System.Drawing.Size(435, 17);
            this.onlyInformationUserIsLockedRadioButton.TabIndex = 1;
            this.onlyInformationUserIsLockedRadioButton.Text = "Informacja o tym, że użytkownik jest zablokowany (nie ma wpływu na wypożyczenie)";
            this.onlyInformationUserIsLockedRadioButton.UseVisualStyleBackColor = true;
            // 
            // requiredNotLockedUserRadioButton
            // 
            this.requiredNotLockedUserRadioButton.Checked = true;
            this.requiredNotLockedUserRadioButton.Location = new System.Drawing.Point(25, 33);
            this.requiredNotLockedUserRadioButton.Name = "requiredNotLockedUserRadioButton";
            this.requiredNotLockedUserRadioButton.Size = new System.Drawing.Size(731, 17);
            this.requiredNotLockedUserRadioButton.TabIndex = 0;
            this.requiredNotLockedUserRadioButton.TabStop = true;
            this.requiredNotLockedUserRadioButton.Text = "Komunikat z informacją o potrzebie odblokowania użytkownika (dopóki użytkownik ni" +
                "e zostanie odblokowany, nie można mu wypożyczać zasobów)";
            this.requiredNotLockedUserRadioButton.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(8, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(298, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Wybranie użytkownika zablokowanego przy wypożyczaniu:";
            // 
            // aboutUserTabPage
            // 
            this.aboutUserTabPage.Controls.Add(this.panel1);
            this.aboutUserTabPage.Location = new System.Drawing.Point(4, 22);
            this.aboutUserTabPage.Name = "aboutUserTabPage";
            this.aboutUserTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.aboutUserTabPage.Size = new System.Drawing.Size(776, 502);
            this.aboutUserTabPage.TabIndex = 7;
            this.aboutUserTabPage.Text = "Informacja o użytkowniku systemu Co-Liber";
            this.aboutUserTabPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.libraryPhoneTextBox);
            this.panel1.Controls.Add(this.libraryZipTextBox);
            this.panel1.Controls.Add(this.libraryCityTextBox);
            this.panel1.Controls.Add(this.libraryStreetTextBox);
            this.panel1.Controls.Add(this.libraryNameTextBox);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Location = new System.Drawing.Point(8, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(762, 170);
            this.panel1.TabIndex = 11;
            // 
            // libraryPhoneTextBox
            // 
            this.libraryPhoneTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.libraryPhoneTextBox.Location = new System.Drawing.Point(84, 126);
            this.libraryPhoneTextBox.MaxLength = 255;
            this.libraryPhoneTextBox.Name = "libraryPhoneTextBox";
            this.libraryPhoneTextBox.Size = new System.Drawing.Size(669, 20);
            this.libraryPhoneTextBox.TabIndex = 9;
            // 
            // libraryZipTextBox
            // 
            this.libraryZipTextBox.Location = new System.Drawing.Point(84, 96);
            this.libraryZipTextBox.MaxLength = 255;
            this.libraryZipTextBox.Name = "libraryZipTextBox";
            this.libraryZipTextBox.Size = new System.Drawing.Size(141, 20);
            this.libraryZipTextBox.TabIndex = 8;
            // 
            // libraryCityTextBox
            // 
            this.libraryCityTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.libraryCityTextBox.Location = new System.Drawing.Point(84, 69);
            this.libraryCityTextBox.MaxLength = 255;
            this.libraryCityTextBox.Name = "libraryCityTextBox";
            this.libraryCityTextBox.Size = new System.Drawing.Size(669, 20);
            this.libraryCityTextBox.TabIndex = 7;
            // 
            // libraryStreetTextBox
            // 
            this.libraryStreetTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.libraryStreetTextBox.Location = new System.Drawing.Point(84, 42);
            this.libraryStreetTextBox.MaxLength = 255;
            this.libraryStreetTextBox.Name = "libraryStreetTextBox";
            this.libraryStreetTextBox.Size = new System.Drawing.Size(669, 20);
            this.libraryStreetTextBox.TabIndex = 6;
            // 
            // libraryNameTextBox
            // 
            this.libraryNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.libraryNameTextBox.Location = new System.Drawing.Point(84, 16);
            this.libraryNameTextBox.MaxLength = 255;
            this.libraryNameTextBox.Name = "libraryNameTextBox";
            this.libraryNameTextBox.Size = new System.Drawing.Size(669, 20);
            this.libraryNameTextBox.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(9, 128);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "Telefon";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(9, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(88, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Kod pocztowy";
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(9, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Miasto";
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(9, 45);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(45, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Ulica";
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(9, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Nazwa";
            // 
            // othersTabPage
            // 
            this.othersTabPage.Controls.Add(this.showBarcodeColumnCheckBox);
            this.othersTabPage.Location = new System.Drawing.Point(4, 22);
            this.othersTabPage.Name = "othersTabPage";
            this.othersTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.othersTabPage.Size = new System.Drawing.Size(776, 502);
            this.othersTabPage.TabIndex = 6;
            this.othersTabPage.Text = "Inne";
            this.othersTabPage.UseVisualStyleBackColor = true;
            // 
            // showBarcodeColumnCheckBox
            // 
            this.showBarcodeColumnCheckBox.Location = new System.Drawing.Point(19, 16);
            this.showBarcodeColumnCheckBox.Name = "showBarcodeColumnCheckBox";
            this.showBarcodeColumnCheckBox.Size = new System.Drawing.Size(241, 17);
            this.showBarcodeColumnCheckBox.TabIndex = 0;
            this.showBarcodeColumnCheckBox.Text = "Pokaż kod kreskowy na fomularzach";
            this.showBarcodeColumnCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.Location = new System.Drawing.Point(314, 534);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Zapisz";
            this.saveButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // escapeButton
            // 
            this.escapeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.escapeButton.Image = ((System.Drawing.Image)(resources.GetObject("escapeButton.Image")));
            this.escapeButton.Location = new System.Drawing.Point(395, 534);
            this.escapeButton.Name = "escapeButton";
            this.escapeButton.Size = new System.Drawing.Size(75, 23);
            this.escapeButton.TabIndex = 2;
            this.escapeButton.Text = "Wyjście";
            this.escapeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.escapeButton.UseVisualStyleBackColor = true;
            this.escapeButton.Click += new System.EventHandler(this.excapeButton_Click);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 569);
            this.Controls.Add(this.escapeButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.othersTabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "ConfigurationForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Konfiguracja";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ConfigurationForm_KeyDown);
            this.othersTabControl.ResumeLayout(false);
            this.usersGroupsTabPage.ResumeLayout(false);
            this.resourcesGroupsTabPage.ResumeLayout(false);
            this.reverseTabPage.ResumeLayout(false);
            this.searchTabPage.ResumeLayout(false);
            this.manualSearchConfigGroupBox.ResumeLayout(false);
            this.autoSearchConfigGroupBox.ResumeLayout(false);
            this.sortTabPage.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.usersTabPage.ResumeLayout(false);
            this.aboutUserTabPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.othersTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl othersTabControl;
        private System.Windows.Forms.TabPage usersGroupsTabPage;
        private System.Windows.Forms.TabPage resourcesGroupsTabPage;
        private System.Windows.Forms.TabPage reverseTabPage;
        private System.Windows.Forms.TabPage searchTabPage;
        private System.Windows.Forms.TabPage sortTabPage;
        private System.Windows.Forms.TabPage usersTabPage;
        private UserGroupUC userGroupUC;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button escapeButton;
        private ResourceGroupUC resourceGroupUC;
        private System.Windows.Forms.RadioButton manualPrintRadioButton;
        private System.Windows.Forms.RadioButton semiautoPrintRadioButton;
        private System.Windows.Forms.RadioButton autoPrintRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox autoSearchConfigGroupBox;
        private System.Windows.Forms.RadioButton noInvAutoSearchRadioButton;
        private System.Windows.Forms.RadioButton sigAutoSearchRadioButton;
        private System.Windows.Forms.RadioButton barcodeAutoSearchRadioButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox manualSearchConfigGroupBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox compareComboBox;
        private System.Windows.Forms.ComboBox searchFieldComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox sort4ComboBox;
        private System.Windows.Forms.ComboBox sort3ComboBox;
        private System.Windows.Forms.ComboBox sort2ComboBox;
        private System.Windows.Forms.ComboBox sort1ComboBox;
        private System.Windows.Forms.RadioButton onlyInformationUserIsLockedRadioButton;
        private System.Windows.Forms.RadioButton requiredNotLockedUserRadioButton;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage othersTabPage;
        private System.Windows.Forms.CheckBox showBarcodeColumnCheckBox;
        private System.Windows.Forms.TabPage aboutUserTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox libraryPhoneTextBox;
        private System.Windows.Forms.TextBox libraryZipTextBox;
        private System.Windows.Forms.TextBox libraryCityTextBox;
        private System.Windows.Forms.TextBox libraryStreetTextBox;
        private System.Windows.Forms.TextBox libraryNameTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;              
    }
}