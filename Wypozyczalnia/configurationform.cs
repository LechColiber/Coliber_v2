
﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Wypozyczalnia
{
    public partial class ConfigurationForm : Form
    {
        Manager _manager;
        Dictionary<Configuration.SortFields, string> sortDictionary;
        Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }

        public ConfigurationForm(int EmployeeId)
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();

            Settings.SetSettings();
            Settings.employeeID = EmployeeId;

            setControlsText();
            SetSearchComboboxes();
            SetSortComboboxes();

            _manager = new Manager(Settings.employeeID, Settings.ConnectionString);
            userGroupUC.LoadGroups(_manager.UserGroups);

            resourceGroupUC.LoadGroups(_manager.ResourceGroups);

            Set(_manager.WypozyczalniaConfiguration);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "configuration");
            mapping.Add(escapeButton, "exit");
            mapping.Add(saveButton, "save");
            mapping.Add(usersGroupsTabPage, "users_group");
            mapping.Add(resourcesGroupsTabPage, "resources_group");
            mapping.Add(reverseTabPage, "verso");
            mapping.Add(manualPrintRadioButton, "manual_print");
            mapping.Add(semiautoPrintRadioButton, "semiauto_print");
            mapping.Add(autoPrintRadioButton, "auto_print");
            mapping.Add(label1, "print_verso");
            mapping.Add(searchTabPage, "searching");
            mapping.Add(manualSearchConfigGroupBox, "manual_search");
            mapping.Add(compareComboBox, "starts_with");
            mapping.Add(searchFieldComboBox, "title");
            mapping.Add(label3, "default_values_001");
            mapping.Add(autoSearchConfigGroupBox, "automatic_search");
            mapping.Add(noInvAutoSearchRadioButton, "inventory_number");
            mapping.Add(sigAutoSearchRadioButton, "signature");
            mapping.Add(barcodeAutoSearchRadioButton, "barcode");
            mapping.Add(label2, "dafault_criteria_001");
            mapping.Add(sortTabPage, "sort_001");
            mapping.Add(groupBox1, "sort_options_001");
            mapping.Add(sort2ComboBox, "signature");
            mapping.Add(sort1ComboBox, "title");
            mapping.Add(label4, "sort_criteria_order");
            mapping.Add(usersTabPage, "users");
            mapping.Add(onlyInformationUserIsLockedRadioButton, "user_blocked_info");
            mapping.Add(requiredNotLockedUserRadioButton, "user_blocked_info_001");
            mapping.Add(label9, "choose_blocked_user");
            mapping.Add(aboutUserTabPage, "coliber_user_info");
            mapping.Add(label10, "phone");
            mapping.Add(label11, "zip_001");
            mapping.Add(label12, "city");
            mapping.Add(label13, "street");
            mapping.Add(label14, "file_name_cannot_be_empty");
            mapping.Add(othersTabPage, "others");
            mapping.Add(showBarcodeColumnCheckBox, "show_barcode_on_form");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        public void DisableButtons(bool disabled)
        {
            saveButton.Enabled = !disabled;
        }

        private void Set(Configuration configuration)
        {
            // reverse
            if (configuration.Reverse == Configuration.ReverseMode.Auto)
                autoPrintRadioButton.Checked = true;
            else if (configuration.Reverse == Configuration.ReverseMode.Semiauto)
                semiautoPrintRadioButton.Checked = true;
            else if (configuration.Reverse == Configuration.ReverseMode.Manual)
                manualPrintRadioButton.Checked = true;

            // autosearch
            if (configuration.AutoSearchField == Configuration.SearchFieldMode.Barcode)
                barcodeAutoSearchRadioButton.Checked = true;
            else if (configuration.AutoSearchField == Configuration.SearchFieldMode.Signature)
                sigAutoSearchRadioButton.Checked = true;
            else if (configuration.AutoSearchField == Configuration.SearchFieldMode.InvertoryNo)
                 noInvAutoSearchRadioButton.Checked = true;

            // manual search
            searchFieldComboBox.SelectedValue = configuration.ManualSearchField;
            compareComboBox.SelectedValue = configuration.Compare;

            // sort
            sort1ComboBox.SelectedValue = configuration.Sort1;
            sort2ComboBox.SelectedValue = configuration.Sort2;
            sort3ComboBox.SelectedValue = configuration.Sort3;
            sort4ComboBox.SelectedValue = configuration.Sort4;

            if (configuration.RequiredNotLockedUserForBorrow == Configuration.RequiredNotLockedUserForBorrowMode.Yes)
                requiredNotLockedUserRadioButton.Checked = true;
            else
                onlyInformationUserIsLockedRadioButton.Checked = true;

            //ShowBarcodeColumn
            showBarcodeColumnCheckBox.Checked = _manager.WypozyczalniaConfiguration.ShowBarcodeColumn;

            // Name
            libraryNameTextBox.Text = _manager.WypozyczalniaConfiguration.InformationAboutUser.Name;
            // Street
            libraryStreetTextBox.Text = _manager.WypozyczalniaConfiguration.InformationAboutUser.Street;
            // City
            libraryCityTextBox.Text = _manager.WypozyczalniaConfiguration.InformationAboutUser.City;
            // Zip
            libraryZipTextBox.Text = _manager.WypozyczalniaConfiguration.InformationAboutUser.ZipCode;
            // PhoneNumber
            libraryPhoneTextBox.Text = _manager.WypozyczalniaConfiguration.InformationAboutUser.PhoneNumber;
        }

        private void SetSearchComboboxes()
        {
            Dictionary<Configuration.SearchFieldMode, string> searchFieldsDictionary = new Dictionary<Configuration.SearchFieldMode, string>();
            searchFieldsDictionary.Add(Configuration.SearchFieldMode.Title, _T("title"));
            searchFieldsDictionary.Add(Configuration.SearchFieldMode.Signature, _T("signature"));
            searchFieldsDictionary.Add(Configuration.SearchFieldMode.InvertoryNo, _T("inventory_number"));
            searchFieldsDictionary.Add(Configuration.SearchFieldMode.Barcode, _T("barcode"));

            searchFieldComboBox.DisplayMember = "Value";
            searchFieldComboBox.ValueMember = "Key";
            searchFieldComboBox.DataSource = new BindingSource(searchFieldsDictionary, null);

            Dictionary<Configuration.CompareMode, string> compareDictionary = new Dictionary<Configuration.CompareMode, string>();
            compareDictionary.Add(Configuration.CompareMode.Equals, _T("equals"));
            compareDictionary.Add(Configuration.CompareMode.StartsWith, _T("starts_with"));
            compareDictionary.Add(Configuration.CompareMode.Contains, _T("contains"));

            compareComboBox.DisplayMember = "Value";
            compareComboBox.ValueMember = "Key";
            compareComboBox.DataSource = new BindingSource(compareDictionary, null);
        }

        private void SetSortComboboxes()
        {
            sortDictionary = new Dictionary<Configuration.SortFields, string>();
            sortDictionary.Add(Configuration.SortFields.None, _T("-void-"));
            sortDictionary.Add(Configuration.SortFields.Signature, _T("signature"));
            sortDictionary.Add(Configuration.SortFields.InvertoryNo, _T("inventory_number"));
            sortDictionary.Add(Configuration.SortFields.Title, _T("title"));
            sortDictionary.Add(Configuration.SortFields.Author, _T("authors"));

            sort1ComboBox.DisplayMember = "Value";
            sort1ComboBox.ValueMember = "Key";
            sort1ComboBox.DataSource = new BindingSource(sortDictionary, null);

            sort2ComboBox.DisplayMember = "Value";
            sort2ComboBox.ValueMember = "Key";
            sort2ComboBox.DataSource = new BindingSource(sortDictionary, null);

            sort3ComboBox.DisplayMember = "Value";
            sort3ComboBox.ValueMember = "Key";
            sort3ComboBox.DataSource = new BindingSource(sortDictionary, null);

            sort4ComboBox.DisplayMember = "Value";
            sort4ComboBox.ValueMember = "Key";
            sort4ComboBox.DataSource = new BindingSource(sortDictionary, null);
        }

        private void ConfigurationForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void excapeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // groups
            _manager.UserGroups = userGroupUC.Groups;
            _manager.ResourceGroups = resourceGroupUC.Groups;

            // reverse
            if (autoPrintRadioButton.Checked)
                _manager.WypozyczalniaConfiguration.Reverse = Configuration.ReverseMode.Auto;
            else if(semiautoPrintRadioButton.Checked)
                _manager.WypozyczalniaConfiguration.Reverse = Configuration.ReverseMode.Semiauto;
            else if(manualPrintRadioButton.Checked)
                _manager.WypozyczalniaConfiguration.Reverse = Configuration.ReverseMode.Manual;

            // manual search field
            _manager.WypozyczalniaConfiguration.ManualSearchField = (Configuration.SearchFieldMode)searchFieldComboBox.SelectedValue;

            // auto search field
            if (barcodeAutoSearchRadioButton.Checked)
                _manager.WypozyczalniaConfiguration.AutoSearchField = Configuration.SearchFieldMode.Barcode;
            else if (sigAutoSearchRadioButton.Checked)
                _manager.WypozyczalniaConfiguration.AutoSearchField = Configuration.SearchFieldMode.Signature;
            else if (noInvAutoSearchRadioButton.Checked)
                _manager.WypozyczalniaConfiguration.AutoSearchField = Configuration.SearchFieldMode.InvertoryNo;

            // compare
            _manager.WypozyczalniaConfiguration.Compare = (Configuration.CompareMode)compareComboBox.SelectedValue;

            // sort
            _manager.WypozyczalniaConfiguration.Sort1 = (Configuration.SortFields)(sort1ComboBox.SelectedValue ?? 0);
            _manager.WypozyczalniaConfiguration.Sort2 = (Configuration.SortFields)(sort2ComboBox.SelectedValue ?? 0);
            _manager.WypozyczalniaConfiguration.Sort3 = (Configuration.SortFields)(sort3ComboBox.SelectedValue ?? 0);
            _manager.WypozyczalniaConfiguration.Sort4 = (Configuration.SortFields)(sort4ComboBox.SelectedValue ?? 0);

            _manager.WypozyczalniaConfiguration.RequiredNotLockedUserForBorrow = requiredNotLockedUserRadioButton.Checked ? Configuration.RequiredNotLockedUserForBorrowMode.Yes : Configuration.RequiredNotLockedUserForBorrowMode.No;

            // ShowBarcodeColumn
            _manager.WypozyczalniaConfiguration.ShowBarcodeColumn = showBarcodeColumnCheckBox.Checked;

            // Name
            _manager.WypozyczalniaConfiguration.InformationAboutUser.Name = libraryNameTextBox.Text.Trim();
            // Street
            _manager.WypozyczalniaConfiguration.InformationAboutUser.Street = libraryStreetTextBox.Text.Trim();
            // City
            _manager.WypozyczalniaConfiguration.InformationAboutUser.City = libraryCityTextBox.Text.Trim();
            // Zip
            _manager.WypozyczalniaConfiguration.InformationAboutUser.ZipCode = libraryZipTextBox.Text.Trim();
            // PhoneNumber
            _manager.WypozyczalniaConfiguration.InformationAboutUser.PhoneNumber = libraryPhoneTextBox.Text.Trim();
            
            if(_manager.Save())
            {
                MessageBox.Show("Zmiany pomyślnie zapisano!", "Zapis danych", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void sort1ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
           /* Dictionary<int, string> tempDict = sortDictionary.Where(x => (x.Key == 0 || x.Key != (int?)sort2ComboBox.SelectedValue) && (x.Key != (int?)sort1ComboBox.SelectedValue && x.Key != (int?)sort3ComboBox.SelectedValue && x.Key != (int?)sort4ComboBox.SelectedValue)).ToDictionary(x => x.Key, y => y.Value);

            int? sort2 = (int?)sort2ComboBox.SelectedValue;
            sort2ComboBox.DisplayMember = "Value";
            sort2ComboBox.ValueMember = "Key";
            sort2ComboBox.DataSource = new BindingSource(tempDict, null);
            sort2ComboBox.SelectedValue = sort2 ?? 0;

            int? sort3 = (int?)sort3ComboBox.SelectedValue;
            sort3ComboBox.DisplayMember = "Value";
            sort3ComboBox.ValueMember = "Key";
            sort3ComboBox.DataSource = new BindingSource(tempDict, null);
            sort3ComboBox.SelectedValue = sort3 ?? 0;

            int? sort4 = (int?)sort4ComboBox.SelectedValue;
            sort4ComboBox.DisplayMember = "Value";
            sort4ComboBox.ValueMember = "Key";
            sort4ComboBox.DataSource = new BindingSource(tempDict, null);
            sort4ComboBox.SelectedValue = sort4 ?? 0;*/
        }

        private void sort2ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*//Dictionary<int, string> tempDict = sortDictionary.Where(x => x.Key == 0 || x.Key != (int?)sort2ComboBox.SelectedValue).ToDictionary(x => x.Key, y => y.Value);
            Dictionary<int, string> tempDict = sortDictionary.Where(x => x.Key == 0 || (x.Key != (int?)sort1ComboBox.SelectedValue && x.Key != (int?)sort2ComboBox.SelectedValue && x.Key != (int?)sort3ComboBox.SelectedValue && x.Key != (int?)sort4ComboBox.SelectedValue)).ToDictionary(x => x.Key, y => y.Value);
            int? sort1 = (int?)sort1ComboBox.SelectedValue;
            sort1ComboBox.DisplayMember = "Value";
            sort1ComboBox.ValueMember = "Key";
            sort1ComboBox.DataSource = new BindingSource(tempDict, null);
            sort1ComboBox.SelectedValue = sort1 ?? 0;

            int? sort3 = (int?)sort3ComboBox.SelectedValue;
            sort3ComboBox.DisplayMember = "Value";
            sort3ComboBox.ValueMember = "Key";
            sort3ComboBox.DataSource = new BindingSource(tempDict, null);
            sort3ComboBox.SelectedValue = sort3 ?? 0;

            int? sort4 = (int?)sort4ComboBox.SelectedValue;
            sort4ComboBox.DisplayMember = "Value";
            sort4ComboBox.ValueMember = "Key";
            sort4ComboBox.DataSource = new BindingSource(tempDict, null);
            sort4ComboBox.SelectedValue = sort4 ?? 0;*/
        }

        private void sort3ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*//Dictionary<int, string> tempDict = sortDictionary.Where(x => x.Key == 0 || x.Key != (int?)sort3ComboBox.SelectedValue).ToDictionary(x => x.Key, y => y.Value);
            Dictionary<int, string> tempDict = sortDictionary.Where(x => x.Key == 0 ||( x.Key != (int?)sort1ComboBox.SelectedValue && x.Key != (int?)sort2ComboBox.SelectedValue && x.Key != (int?)sort3ComboBox.SelectedValue && x.Key != (int?)sort4ComboBox.SelectedValue)).ToDictionary(x => x.Key, y => y.Value);
            int? sort1 = (int?)sort1ComboBox.SelectedValue;
            sort1ComboBox.DisplayMember = "Value";
            sort1ComboBox.ValueMember = "Key";
            sort1ComboBox.DataSource = new BindingSource(tempDict, null);
            sort1ComboBox.SelectedValue = sort1 ?? 0;

            int? sort2 = (int?)sort2ComboBox.SelectedValue;
            sort2ComboBox.DisplayMember = "Value";
            sort2ComboBox.ValueMember = "Key";
            sort2ComboBox.DataSource = new BindingSource(tempDict, null);
            sort2ComboBox.SelectedValue = sort2 ?? 0;

            int? sort4 = (int?)sort4ComboBox.SelectedValue;
            sort4ComboBox.DisplayMember = "Value";
            sort4ComboBox.ValueMember = "Key";
            sort4ComboBox.DataSource = new BindingSource(tempDict, null);
            sort4ComboBox.SelectedValue = sort4 ?? 0;*/
        }

        private void sort4ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*//Dictionary<int, string> tempDict = sortDictionary.Where(x => x.Key == 0 || x.Key != (int?)sort4ComboBox.SelectedValue).ToDictionary(x => x.Key, y => y.Value);
            Dictionary<int, string> tempDict = sortDictionary.Where(x => x.Key == 0 || (x.Key != (int?)sort1ComboBox.SelectedValue && x.Key != (int?)sort2ComboBox.SelectedValue && x.Key != (int?)sort3ComboBox.SelectedValue && x.Key != (int?)sort4ComboBox.SelectedValue)).ToDictionary(x => x.Key, y => y.Value);
            int? sort1 = (int?)sort1ComboBox.SelectedValue;
            sort1ComboBox.DisplayMember = "Value";
            sort1ComboBox.ValueMember = "Key";
            sort1ComboBox.DataSource = new BindingSource(tempDict, null);
            sort1ComboBox.SelectedValue = sort1 ?? 0;

            int? sort2 = (int?)sort2ComboBox.SelectedValue;
            sort2ComboBox.DisplayMember = "Value";
            sort2ComboBox.ValueMember = "Key";
            sort2ComboBox.DataSource = new BindingSource(tempDict, null);
            sort2ComboBox.SelectedValue = sort2 ?? 0;

            int? sort3 = (int?)sort3ComboBox.SelectedValue;
            sort3ComboBox.DisplayMember = "Value";
            sort3ComboBox.ValueMember = "Key";
            sort3ComboBox.DataSource = new BindingSource(tempDict, null);
            sort3ComboBox.SelectedValue = sort3 ?? 0;*/
        }        
    }
}
