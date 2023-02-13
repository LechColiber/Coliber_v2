using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;

namespace WindowsFormsApplication1
{
    public partial class AboutOwner : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        public AboutOwner()
        {
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "coliber_user_info");
            mapping.Add(CancelButton, "cancel");
            mapping.Add(SaveButton, "confirm");
            mapping.Add(label5, "phone");
            mapping.Add(label4, "zip_001");
            mapping.Add(label3, "city");
            mapping.Add(label2, "street");
            mapping.Add(label1, "file_name_cannot_be_empty");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutOwner_Load(object sender, EventArgs e)
        {
            IniFile ReadConfig = new IniFile("coliber.ini", "coliber");

            CityTextBox.Text = ReadConfig.ReadIni("Reports", "HeaderLine1");
            NameTextBox.Text = ReadConfig.ReadIni("Reports", "HeaderLine3");
            PostcodeTextBox.Text = ReadConfig.ReadIni("Reports", "HeaderLine4");
            AddressTextBox.Text = ReadConfig.ReadIni("Reports", "HeaderLine5");
            PhoneTextBox.Text = ReadConfig.ReadIni("Reports", "HeaderLine6");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            IniFile ReadConfig = new IniFile("coliber.ini", "coliber");
            string[] KeyList = { "HeaderLine1", "HeaderLine2", "HeaderLine3", "HeaderLine4", "HeaderLine5", "HeaderLine6" };
            string[] ValueList = { CityTextBox.Text, "", NameTextBox.Text, PostcodeTextBox.Text, AddressTextBox.Text, PhoneTextBox.Text };

            ReadConfig.WriteIni("Reports", KeyList, ValueList);

            MessageBox.Show(_T("saved"), _T("data_save"), MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void AboutOwner_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
