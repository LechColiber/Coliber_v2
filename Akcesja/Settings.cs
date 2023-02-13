using System.Data.Odbc;
using System.Data.SqlClient;
using System.Threading;

namespace Akcesja
{
    class Settings
    {
        public static string ConnectionString;// = "Driver=SQL SERVER;SERVER=LAPTOP\\SQLEXPRESS;DATABASE=coliber_b1;Trusted_Connection=Yes";
        public static string ConnectionStringSql;
        public static int ID_rodzaj;// = 1;
        public static string employeeID = "-1";

        public static SqlConnection Connection;

        public static int MonthNumber = 1;
        public static int Interval = 1;

        public static bool ReadOnlyMode = false;
        public static bool ReadOnlyModeForCatalog = false;

        public static Mutex oneMutex;

        public static void SetSettings(string ConnectionString, int ID_rodzaj)
        {
            Settings.ConnectionString = ConnectionString;
            Settings.ID_rodzaj = ID_rodzaj;

            ReadOnlyMode = false;
            ReadOnlyModeForCatalog = false;
            MonthNumber = 1;
            Interval = 1;

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
            }
            catch
            { }

            try
            {
                Settings.ID_rodzaj = ID_rodzaj;
            }
            catch { }

            Connection = new SqlConnection(Settings.ConnectionString);

            Settings.ReadOnlyMode = false;
        }  
    }
}
