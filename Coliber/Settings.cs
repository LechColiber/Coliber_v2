using System;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace Coliber
{
    class Settings
    {
        public static string coliberConnectionString;
        public static string wypozyczalniaConnectionString;
        public static int ID_rodzaj = 0;
        public static SqlConnection Connection;
        public static string UserName = "";
        public static string InvertoryName = "";
        public static string employeeID = "0";


        public static void SetSettings(int ID_rodzaj = 1)
        {
            IniFile coliberConfigs = new IniFile("coliber.ini", "Coliber");

            if (string.IsNullOrEmpty(coliberConfigs.path))
            {
                Environment.Exit(0);
            }

            Settings.coliberConnectionString = Settings.getConnectionString(coliberConfigs.ReadIni("SqlServer", "ConnectionString"));

            Connection = new SqlConnection(Settings.coliberConnectionString);
        }

        public static string getConnectionString(string ConnectionString)
        {
            string connectionString = "";

            try
            {
                OdbcConnectionStringBuilder OdCB = new OdbcConnectionStringBuilder(ConnectionString);

                connectionString = "Server = " + OdCB["server"].ToString() + ";Database = " + OdCB["database"].ToString() + ";";

                if (OdCB.ContainsKey("TrusteD_Connection"))
                    connectionString += "Trusted_Connection = " + OdCB["Trusted_Connection"].ToString();
                else if (OdCB.ContainsKey("Uid"))
                    connectionString += "Uid = " + OdCB["Uid"].ToString() + "; Pwd = " + OdCB["Pwd"].ToString();
                else if (OdCB.ContainsKey("User Id"))
                    connectionString += "User Id = " + OdCB["User Id"].ToString() + "; Password = " + OdCB["Password"].ToString();
                else
                    connectionString += "; persist security info = True; integrated security = SSPI";
            }
            catch
            {
                connectionString = ConnectionString;
            }


            return connectionString;
        }
    }
}
