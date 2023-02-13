using System;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Settings
    {
        public static SqlConnection coliberConnection;
        public static string coliberConnectionString = "";
        public static string coliberConnectionStringSql = "";

        public static SqlConnection wypozyczalniaConnection;
        public static string wypozyczalniaConnectionStringSql = "";

        public static string Login = "";

        public static bool IsAdminLogged = false;

        public static bool coliberSetSettings()
        {
            IniFile Configs = new IniFile("coliber.ini", "coliber");

            if(string.IsNullOrEmpty(Configs.path))
                return false;

            Settings.coliberSetSettings(Configs.ReadIni("SqlServer", "ConnectionString"));

            return true;
        }
        public static void coliberSetSettings(string ConnectionString)
        {
            try
            {
                Settings.coliberConnectionString = ConnectionString;
                Settings.coliberConnectionStringSql = getSqlConnectionString(ConnectionString);
                coliberConnection = new SqlConnection(Settings.coliberConnectionStringSql);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }            
        }

        public static bool wypozyczalniaSetSettings()
        {
            IniFile Configs = new IniFile("wypozycz.ini", "wypozyczalnia");

            if (string.IsNullOrEmpty(Configs.path))
                return false;

            Settings.wypozyczalniaSetSettings(Configs.ReadIni("SqlServer", "ConnectionString"));

            return true;
        }
        public static void wypozyczalniaSetSettings(string ConnectionString)
        {
            try
            {                
                Settings.wypozyczalniaConnectionStringSql = getSqlConnectionString(ConnectionString);
                wypozyczalniaConnection = new SqlConnection(Settings.wypozyczalniaConnectionStringSql);
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        public static string getSqlConnectionString(string ConnectionString)
        {
            string connectionString = "";

            try
            {
                OdbcConnectionStringBuilder OdCB = new OdbcConnectionStringBuilder(ConnectionString);

                connectionString = "Server = " + OdCB["server"].ToString() + ";Database = " + OdCB["database"].ToString() + ";";

                if (OdCB.ContainsKey("Trusted_Connection"))
                    connectionString += "Trusted_Connection = " + OdCB["Trusted_Connection"].ToString();
                else if (OdCB.ContainsKey("Uid"))
                    connectionString += "Uid = " + OdCB["Uid"].ToString() + "; Pwd = " + OdCB["Pwd"].ToString();
                else if (OdCB.ContainsKey("User Id"))
                    connectionString += "User Id = " + OdCB["User Id"].ToString() + "; Password = " + OdCB["Password"].ToString();
                else
                    connectionString += "; persist security info = True; integrated security = SSPI";
            }
            catch
            { }

            return ConnectionString;
        }
    }
}
