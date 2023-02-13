
﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Smo.Wmi;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Configurator : Form
    {
        private Dictionary<string, string> _translationsDictionary;
        public string _T(string cKey)
        {
            return _translationsDictionary.ContainsKey(cKey) ? _translationsDictionary[cKey] : "_" + cKey + "_";
        }
        string Database, ConnectionString, Server;
        OdbcConnectionStringBuilder ConnectionStringBuilder;
        OdbcConnection NewConnection;

        DataTable Dt;
        bool lLoadSrvrs;
        string CurrentServer, CurrentDatabase;
        private bool LogInMode;
        private string _dbName;
        private string _iniFileName;

        public Configurator(string dbName, string iniFileName, bool LogInMode = false)
        {
            lLoadSrvrs = true;
            InitializeComponent();
            _translationsDictionary = new Dictionary<string, string>();
            setControlsText();

            this.LogInMode = LogInMode;
            _dbName = dbName;
            _iniFileName = iniFileName;

            ServerComboBox.Enabled = SQLcheckBox.Checked;
            DbUserNameTextBox.Enabled = SQLcheckBox.Checked;
            DbPasswordTextBox.Enabled = SQLcheckBox.Checked;
            DatabaseComboBox.Enabled = SQLcheckBox.Checked;

            if (LogInMode)
            {
                RememberCheckBox.Visible = true;
                TestButton.Visible = false;
                this.Text = _T("sign_in");
                UserTextBox.Select();                
            }

            ConnectionStringBuilder = new OdbcConnectionStringBuilder();

            if (Settings.coliberSetSettings())
            {

                IniFile Configs = new IniFile(_iniFileName, _dbName);

                if (string.IsNullOrWhiteSpace(Configs.path))
                    return;

                this.ConnectionString = Configs.ReadIni("SqlServer", "ConnectionString");
                this.UserTextBox.Text = Configs.ReadIni("PanelAdmina", "user");
                
                RememberCheckBox.Checked = UserTextBox.Text.Trim().Length > 0;

                if (UserTextBox.Text.Trim().Length > 0)
                    PasswordTextBox.Select();

                ConnectionStringBuilder.ConnectionString = this.ConnectionString;

                try
                {                    
                    if (ConnectionStringBuilder.ContainsKey("server"))
                        ServerComboBox.Text = ConnectionStringBuilder["server"].ToString();
                    if (ConnectionStringBuilder.ContainsKey("database"))
                        DatabaseComboBox.Text = ConnectionStringBuilder["database"].ToString();
                    if (ConnectionStringBuilder.ContainsKey("uid"))
                        DbUserNameTextBox.Text = ConnectionStringBuilder["uid"].ToString();
                    if (ConnectionStringBuilder.ContainsKey("pwd"))
                        DbPasswordTextBox.Text = ConnectionStringBuilder["pwd"].ToString();
                }
                catch (Exception)
                {

                }

                CurrentServer = ServerComboBox.Text.Trim();
                CurrentDatabase = DatabaseComboBox.Text.Trim();
                if (System.IO.File.Exists("Debug.SQL")) MessageBox.Show(Configs.path + "\n" + this.ConnectionString,"Configurator");
            }
        }

        private void setControlsText()
        {
            var mapping = new Dictionary<Object, string>(); 
            mapping.Add(this, "sign_in");
            mapping.Add(SQLcheckBox, "change_database");
            mapping.Add(groupBox2, "coliber_user_data");
            mapping.Add(UserLabel, "user");
            mapping.Add(PasswordLabel, "password");
            mapping.Add(RememberCheckBox, "remember_username");
            mapping.Add(groupBox1, "sql_server_data");
            mapping.Add(label3, "users_password");
            mapping.Add(label2, "database");
            mapping.Add(label1, "server_name");
            mapping.Add(label4, "database_user");
            mapping.Add(TestInfoLabel, "testing_connection");
            mapping.Add(SaveButton, "confirm");
            mapping.Add(TestButton, "do_test");
            mapping.Add(CancelButton, "cancel");
            _translationsDictionary = CommonFunctions.GetAndLoadTranslations(mapping, Thread.CurrentThread.CurrentUICulture.Name) ?? new Dictionary<string, string>();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Server = ServerComboBox.Text.Trim();
            Database = DatabaseComboBox.Text.Trim();
            bool lIngrated = false;
            IniFile ReadConfig = new IniFile(_iniFileName, _dbName);
            
            //string temp = "Driver=" + ConnectionStringBuilder.Driver + ";SERVER=" + ServerTextBox.Text + ";DATABASE=" + DatabaseTextBox.Text + ";Trusted_Connection=Yes";
            //string temp = "Driver=SQL SERVER;SERVER=" + ServerComboBox.Text + ";DATABASE=" + DatabaseComboBox.Text + ";Trusted_Connection=Yes";
            //string temp = "SERVER=" + ServerComboBox.Text + ";DATABASE=" + DatabaseComboBox.Text + ";Trusted_Connection=Yes";
            
//            ConnectionStringBuilder["Driver"] = "SQL SERVER";
            ConnectionStringBuilder["server"] = ServerComboBox.Text.Trim();
            ConnectionStringBuilder["database"] = DatabaseComboBox.Text.Trim();

            if(_iniFileName.Contains("coliber"))
                Settings.coliberSetSettings(ConnectionStringBuilder.ConnectionString);
            else
                Settings.wypozyczalniaSetSettings(ConnectionStringBuilder.ConnectionString);

            if (string.IsNullOrEmpty(ServerComboBox.Text.Trim()))
            {
                MessageBox.Show(_T("db_server_not_chosen"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            else if (string.IsNullOrEmpty(DatabaseComboBox.Text.Trim()))
            {
                MessageBox.Show(_T("database_not_chosen"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
            }
            if (string.IsNullOrEmpty(DbUserNameTextBox.Text.Trim()))
            {
                lIngrated = true;
                /*
                MessageBox.Show(_T("user_not_entered"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
                */
            }
            if (string.IsNullOrEmpty(DbPasswordTextBox.Text.Trim()))
            {
                lIngrated = true;
                /*
                MessageBox.Show(_T("password_not_entered"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
                return;
                */
            }
            if (lIngrated == false)
            {
                ConnectionStringBuilder["uid"] = DbUserNameTextBox.Text.Trim();
                ConnectionStringBuilder["pwd"] = DbPasswordTextBox.Text.Trim();
            }
            SqlConnection connection = new SqlConnection(Settings.getSqlConnectionString(ConnectionStringBuilder.ConnectionString));

            int Resultat = LogIn(UserTextBox.Text.Trim(), PasswordTextBox.Text.Trim(), ref connection);

            if (System.IO.File.Exists("Debug.SQL")) MessageBox.Show(connection.ConnectionString + "\n" + Resultat.ToString(),"saveClick");
            //MessageBox.Show(Resultat.ToString());

            if (Resultat == -2)
            {
                MessageBox.Show(_T("wrong_user_or_password"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.DialogResult = DialogResult.None;
            }
            else if (Resultat >= 0)
            {
                ReadConfig.WriteIni("SqlServer", "ConnectionString", ConnectionStringBuilder.ConnectionString);

                if (RememberCheckBox.Checked)
                    ReadConfig.WriteIni("PanelAdmina", "user", UserTextBox.Text.Trim());
                else
                    ReadConfig.WriteIni("PanelAdmina", "user", null);

                Settings.Login = UserTextBox.Text.Trim();

                if (UserTextBox.Text.Trim().ToLower() == "admin")
                    Settings.IsAdminLogged = true;

                Settings.coliberSetSettings();
                Settings.wypozyczalniaSetSettings();

                if(!LogInMode)
                    MessageBox.Show(_T("saved"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
            
        }

        private int LogIn(string UserName, string Password, ref SqlConnection connection)
        {
            //NewConnection = new OdbcConnection("Driver="/*SQL SERVER;*/+ ConnectionStringBuilder.Driver + ";SERVER=" + ServerComboBox.Text + ";DATABASE=" + DatabaseComboBox.Text + ";Trusted_Connection=Yes");
            NewConnection = new OdbcConnection(ConnectionStringBuilder.ConnectionString);
            Settings.coliberSetSettings(ConnectionStringBuilder.ConnectionString);

            SqlCommand Command = new SqlCommand();

            Command.CommandText = "SELECT dbo.LogInToDb (@nazwa, @haslo); ";
            Command.Parameters.AddWithValue("@nazwa", UserName);
            Command.Parameters.AddWithValue("@haslo", Password);
            Command.CommandTimeout = 1;

            DataTable Dt = CommonFunctions.ReadData(Command, ref connection);

            if (Dt.Rows.Count == 0)
                return -1;

            return (int)Dt.Rows[0][0];

            // -1 - błąd
            // -2 - błąd logowania
            //  >= 0 - zalogowano
        }

        private void TestButton_Click(object sender, EventArgs e)
        {
            TestInfoLabel.Visible = true;
            TestInfoLabel.Update();

            //ConnectionStringBuilder["Driver"] = "SQL SERVER";
            ConnectionStringBuilder["server"] = ServerComboBox.Text.Trim();
            ConnectionStringBuilder["database"] = DatabaseComboBox.Text.Trim();
            //ConnectionStringBuilder["uid"] = DbUserNameTextBox.Text.Trim();
            //ConnectionStringBuilder["pwd"] = DbPasswordTextBox.Text.Trim();

            //NewConnection = new OdbcConnection("Driver="/*SQL SERVER;*/+ ConnectionStringBuilder.Driver +";SERVER=" + ServerComboBox.Text + ";DATABASE=" + DatabaseComboBox.Text + ";Trusted_Connection=Yes");
            NewConnection = new OdbcConnection(ConnectionStringBuilder.ConnectionString);

            try
            {
                NewConnection.Open();

                if (NewConnection.State == ConnectionState.Open)
                    MessageBox.Show(_T("connection_ok"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            catch (OdbcException Ex)
            {
                foreach (OdbcError error in Ex.Errors)
                {
                    if (error.SQLState.ToString() == "28000")
                    {
                        MessageBox.Show(_T("wrong_user_or_password"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(Ex.Message); 
                }
            }
            catch (Exception Ex)
            {                
                MessageBox.Show(Ex.Message);
            }

            TestInfoLabel.Visible = false;
            NewConnection.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            //DialogResult Result = MessageBox.Show(_T("cancel_q"), "", MessageBoxButtons.YesNo);
            //if (Result == System.Windows.Forms.DialogResult.Yes)
            this.Close();

        }

        private void ServerComboBox_DropDown(object sender, EventArgs e)
        {
            string cSrvr;
            cSrvr = ServerComboBox.Text;

            
            this.Cursor = Cursors.WaitCursor;
            if (lLoadSrvrs)
            {
                Dt = new DataTable();
                WaitForm Wait = new WaitForm();
                this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });

                /*Thread DbThread = new Thread(() => { GetServers(ref Dt); });
                DbThread.Start();
                DbThread.Join();
                 */


                //foreach (DataRow row in Dt.Rows) MessageBox.Show(row[0].ToString());


                try
                {
                    Dt = SmoApplication.EnumAvailableSqlServers();
                    string cNapis = "";
                    if (Dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in Dt.Rows)
                        {
                            cNapis += dr["Name"].ToString() + "\\" + dr["Instance"] + "\n";
                        }
                    }
                    //MessageBox.Show(cNapis);
                    ServerComboBox.ValueMember = "Name";
                    ServerComboBox.DataSource = Dt;
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
                lLoadSrvrs = false;
                Wait.Close();
            }

            /*if (!string.IsNullOrEmpty(CurrentServer))
                ServerComboBox.SelectedValue = CurrentServer;*/

            /*if (!string.IsNullOrEmpty(cSrvr))
                ServerComboBox.SelectedValue = cSrvr;*/

            this.Cursor = Cursors.Default;


        }

        private void DatabaseComboBox_DropDown(object sender, EventArgs e)
        {
            //DatabaseComboBox.Items.Clear();            
            if (string.IsNullOrEmpty(ServerComboBox.Text.ToString().Trim()))
            {
                MessageBox.Show(_T("db_server_name_required"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(DbUserNameTextBox.Text.Trim()) || string.IsNullOrEmpty(DbPasswordTextBox.Text.Trim()))
            {
                MessageBox.Show(_T("name_and_password_required"), _T("information"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            WaitForm Wait = new WaitForm();

            this.Invoke((MethodInvoker)delegate { Wait.Show(this); Wait.Update(); });
            this.Cursor = Cursors.WaitCursor;

            List<string> DbList = new List<string>();

            Server ServerForConnect = new Server(ServerComboBox.Text);

            Thread DbThread = new Thread(() => { GetDatabases(ServerForConnect, ref DbList, DbUserNameTextBox.Text.Trim(), DbPasswordTextBox.Text.Trim()); });
            DbThread.Start();
            DbThread.Join();
            /*try
            {
                Server ServerForConnect = new Server(ServerComboBox.Text);

                foreach (Database Database in ServerForConnect.Databases)
                {
                    DatabaseComboBox.Items.Add(Database.Name);
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }*/
            DatabaseComboBox.DataSource = DbList;
            DatabaseComboBox.ValueMember = "";

            for (int i = 0; i < DatabaseComboBox.Items.Count; i++)
                if (DatabaseComboBox.Items[i].ToString() == CurrentDatabase)
                {
                    DatabaseComboBox.SelectedIndex = i;
                    break;
                }            

            this.Cursor = Cursors.Default;
            Wait.Close();
        }

        private void GetDatabases(Server ServerForConnect, ref List<string> DbList, string userName, string password)
        {            
            try
            {
                DbList = new List<string>();                

                ServerForConnect.ConnectionContext.LoginSecure = false;
                ServerForConnect.ConnectionContext.Login = userName;
                ServerForConnect.ConnectionContext.Password = password;

                foreach (Database Database in ServerForConnect.Databases)
                {
                    if (Database.Name.ToLower().Contains(_dbName.ToLower().Trim()))
                    {
                        DbList.Add(Database.Name);
                        //MessageBox.Show(Database.Name);
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.InnerException.Message);
            }
        }

        private void GetServers(ref DataTable Dt)
        {
            try
            {
                Dt = SmoApplication.EnumAvailableSqlServers();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.ToString());
            }
        }
        private const String defaultMsSqlInstanceName = "MSSQLSERVER";

        /*public String[] GetLocalSqlServerInstances()
        {
            return new
                ManagedComputer()
                .ServerInstances
                .Cast<ServerInstance>()
                .Select(instance => String.IsNullOrEmpty(instance.Name) || instance.Name == defaultMsSqlInstanceName ?
                    instance.Parent.Name : instance.Parent.Name + instance.Name)
                .ToArray();
        }
         */

        private void Configurator_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void SQLcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ServerComboBox.Enabled = SQLcheckBox.Checked;
            DbUserNameTextBox.Enabled = SQLcheckBox.Checked;
            DbPasswordTextBox.Enabled = SQLcheckBox.Checked;
            DatabaseComboBox.Enabled = SQLcheckBox.Checked;
        }
    }
}
