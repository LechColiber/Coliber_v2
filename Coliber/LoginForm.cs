using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;
using System.Reflection;
using Translate_Manager;

namespace Coliber
{
    public partial class LoginForm : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public LoginForm()
        {
            InitializeComponent();

            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            IniFile Configs = new IniFile("coliber.ini", "coliber");

            this.UserTextBox.Text = Configs.ReadIni("PanelAdmina", "user");

            RememberCheckBox.Checked = UserTextBox.Text.Trim().Length > 0;

            UserTextBox.Select();

            if (RememberCheckBox.Checked)
                PasswordTextBox.Select();

            this.Text = String.Format("{0} {1}", _translationsDictionary.ContainsKey("app_name") ? _translationsDictionary["app_name"] : "", Assembly.GetExecutingAssembly().GetName().Version);
            //this.Text = String.Format("{0} {1}", _translationsDictionary.ContainsKey("app_name") ? _translationsDictionary["app_name"] : "Co-Liber", Assembly.GetExecutingAssembly().GetName().Version);
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>();
            mapping.Add(label1, "sign_in");
            mapping.Add(label2, "please_sign_in");
            mapping.Add(UserLabel, "username");
            mapping.Add(PasswordLabel, "password");
            mapping.Add(RememberCheckBox, "remember_username");
            mapping.Add(SaveButton, "ok");
            mapping.Add(EscapeButton, "cancel");            

            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            int loginResult = App.LogIn(UserTextBox.Text.Trim(), PasswordTextBox.Text.Trim(), ref Settings.Connection);

            if (loginResult == -2)
            {
                if (_translationsDictionary.ContainsKey("invalid_username_or_password") && _translationsDictionary.ContainsKey("invalid_sign_in"))
                    MessageBox.Show(_translationsDictionary["invalid_username_or_password"], _translationsDictionary["invalid_sign_in"], MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    MessageBox.Show("Nieprawidłowa nazwa użytkownika lub hasło!", "Błędne logowanie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    
                this.DialogResult = DialogResult.Cancel;
            }
            else if (loginResult >= 0)
            {
                LogInToWypozyczalnia(UserTextBox.Text.Trim(), PasswordTextBox.Text.Trim());

                Settings.UserName = UserTextBox.Text.Trim();

                //IniFile Configs = new IniFile("coliber.ini", true, "coliber", false);
                IniFile Configs = new IniFile("coliber.ini", "coliber");

                if (RememberCheckBox.Checked)
                    Configs.WriteIni("PanelAdmina", "user", UserTextBox.Text.Trim());
                else
                    Configs.WriteIni("PanelAdmina", "user", null);

                this.DialogResult = DialogResult.OK;
            }
//            this.Dispose();
        }

        private void LogInToWypozyczalnia(string UserName, string Password)
        {
            try
            {
                //IniFile wypozyczalniaConfigs = new IniFile("wypozycz.ini", true, "wypozyczalnia", false);
                IniFile wypozyczalniaConfigs = new IniFile("wypozycz.ini", "wypozyczalnia");

                if (string.IsNullOrEmpty(wypozyczalniaConfigs.path))
                {
                    return;
                }

                Settings.wypozyczalniaConnectionString = Settings.getConnectionString(wypozyczalniaConfigs.ReadIni("SqlServer", "ConnectionString"));
                SqlConnection Connection = new SqlConnection(Settings.wypozyczalniaConnectionString);

                int id = App.LogIn(UserName.Trim(), Password.Trim(), ref Connection);

                if (id >= 0)
                {
                    Settings.employeeID = id.ToString();
                }

                //MessageBox.Show(id.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Dispose();
        }

        private void Configurator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            { 
                this.DialogResult = DialogResult.Cancel; 
                this.Dispose(); 
            }
        }
    }
}
