using System.Data.Odbc;
using System.Data.SqlClient;

namespace Wypozyczalnia
{
    class Settings
    {        
        public static string ConnectionString;
        public static string ConnectionStringSql;
        public static int ID_rodzaj = 0;
        public static SqlConnection Connection;
        public static string UserName = "";
        public static int employeeID = -1;

        public static void SetSettings()
        {
            IniFile Configs = new IniFile("wypozycz.ini", "Wypozyczalnia", false);

            Settings.SetSettings(Configs.ReadIni("SqlServer", "ConnectionString"));

            Connection = new SqlConnection(Settings.ConnectionString);
        }

        public static void SetSettings(int ID_rodzaj)
        {
            try
            {
                Settings.ID_rodzaj = ID_rodzaj;
            }
            catch { }
        }

        public static void SetSettings(string CString)
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
        }        
    }
}
