using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace Czasopisma
{
    class Settings
    {        
        public static string ConnectionString;
        public static string ConnectionStringSql;
        public static int ID_rodzaj = 0;
        public static int Search_ID_rodzaj = 0;
        public static SqlConnection Connection;
        public static bool ReadOnlyMode = false;
        public static string employeeID = "-1";

        public static void SetSettings(int ID_rodzaj)
        {
            IniFile Configs = new IniFile("coliber.ini", "Coliber");

            Settings.SetSettings(Configs.ReadIni("SqlServer", "ConnectionString"), ID_rodzaj);

            Connection = new SqlConnection(Settings.ConnectionString);

            Settings.ReadOnlyMode = false;
            employeeID = "-1";
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

            Settings.ReadOnlyMode = false;
            employeeID = "-1";
        }

        public static DataTable IsNumberBorrowed(string id, int type)
        {
            SqlCommand Command = new SqlCommand();
            Command.CommandText = "EXEC Akcesja_SprawdzNumerJestWypozyczony @id, @type;";
            Command.Parameters.AddWithValue("@id", id);
            Command.Parameters.AddWithValue("@type", type);

            return CommonFunctions.ReadData(Command, ref Settings.Connection);
        }
    }
}
