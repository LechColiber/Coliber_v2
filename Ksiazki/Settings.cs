using System.Data.Odbc;
using System.Data.SqlClient;
using System.Threading;

namespace Ksiazki
{
    class Settings
    {
        public static string ConnectionString;// = "Driver=SQL SERVER;SERVER=LAPTOP\\SQLEXPRESS;DATABASE=coliber_1do_test;Trusted_Connection=Yes";
        public static string ConnectionStringSql;
        public static int ID_rodzaj = 0;
        public static SqlConnection Connection;
        public static bool ReadOnlyMode = false;
        public static Mutex oneMutex;
        public static string employeeID = "-1";

        public static int MaxRecords = 200;

        public static void SetSettings(int ID_rodzaj)
        {
            IniFile Configs = new IniFile("coliber.ini", "coliber");

            Settings.SetSettings(Configs.ReadIni("SqlServer", "ConnectionString"), ID_rodzaj);

            Connection = new SqlConnection(Settings.ConnectionString);

            ReadOnlyMode = false;
            employeeID = "-1";
        }

        public static void SetSettings(string CS, int ID_rodzaj)
        {
            ConnectionString = CS;
            try
            {
                OdbcConnectionStringBuilder OdCB = new OdbcConnectionStringBuilder(CS);

                Settings.ConnectionStringSql = "Server = " + OdCB["server"].ToString() + ";Database = " + OdCB["database"].ToString() + ";";

                if (OdCB.ContainsKey("TrusteD_Connection"))
                    Settings.ConnectionStringSql += "Trusted_Connection = " + OdCB["Trusted_Connection"].ToString();
                else if (OdCB.ContainsKey("Uid"))
                    Settings.ConnectionStringSql += "Uid = " + OdCB["Uid"].ToString() + "; Pwd = " + OdCB["Pwd"].ToString();
                else if (OdCB.ContainsKey("User Id"))
                    Settings.ConnectionStringSql += "User Id = " + OdCB["User Id"].ToString() + "; Password = " + OdCB["Password"].ToString();
                else
                    Settings.ConnectionStringSql += "; persist security info = True; integrated security = SSPI";
            }
            catch
            { }

            try
            {
                Connection = new SqlConnection(Settings.ConnectionString);

                Settings.ID_rodzaj = ID_rodzaj;
            }
            catch { }

            ReadOnlyMode = false;
        }        
    }
}
