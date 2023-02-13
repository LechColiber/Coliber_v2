using System.Data.Odbc;
using System.Data.SqlClient;
using System.Threading;

namespace Ubytki
{
    class Settings
    {
        public static string ConnectionString;// = @"Server=LAPTOP\sqlexpress;Database=coliberdotk;Trusted_Connection = True;Connection Timeout = 200000;";
        public static string ConnectionStringSql;
        public static int ID_rodzaj = 1;
        public static SqlConnection Connection;// = new SqlConnection(Settings.ConnectionString);
        public static bool ReadOnlyMode;
        public static Mutex oneMutex;

        public static void SetSettings(int ID_rodzaj)
        {
            IniFile Configs = new IniFile("coliber.ini", "coliber");

            Settings.SetSettings(Configs.ReadIni("SqlServer", "ConnectionString"), ID_rodzaj);

            Connection = new SqlConnection(Settings.ConnectionString);
        }
        public static void SetSettings(string CString, int ID_rodzaj)
        {
            ConnectionString = CString;
            try 
            { 
                OdbcConnectionStringBuilder OdCB = new OdbcConnectionStringBuilder(ConnectionString);

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
                Settings.ID_rodzaj = ID_rodzaj;
            }
            catch { }
        }        
    }
}
