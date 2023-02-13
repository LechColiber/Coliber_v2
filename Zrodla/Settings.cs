using System;
using System.Data;
using System.Data.Odbc;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Forms;

namespace Zrodla
{
    class Settings
    {
        public static string ConnectionString;// = @"SERVER=dev2008\FSE21;DATABASE=coliber_b1;Trusted_Connection=Yes";
        public static string ConnectionStringSql;
        public static int ID_rodzaj = 0;
        public static int Code = -1;
        public static int KindOfResource = -1;
        public static bool ReadOnly;

        public static Mutex oneMutex;
        public static SqlConnection Connection;

        public static void SetSettings(string CString, int ID_rodzaj, int Code, int KindOfResource)
        {
            ConnectionString = CString;
            OdbcConnectionStringBuilder OdCB = new OdbcConnectionStringBuilder(ConnectionString);

            /*
            Settings.ConnectionStringSql = "Server = " + OdCB["server"].ToString() + ";Database = " + OdCB["database"].ToString() + ";";

            if (OdCB.ContainsKey("TrusteD_Connection"))
                Settings.ConnectionStringSql += "Trusted_Connection = " + OdCB["Trusted_Connection"].ToString();
            else if (OdCB.ContainsKey("Uid"))
                Settings.ConnectionStringSql += "Uid = " + OdCB["Uid"].ToString() + "; Pwd = " + OdCB["Pwd"].ToString();
            else if (OdCB.ContainsKey("User Id"))
                Settings.ConnectionStringSql += "User Id = " + OdCB["User Id"].ToString() + "; Password = " + OdCB["Password"].ToString();
            */
        
            Settings.ID_rodzaj = ID_rodzaj;
            Settings.Code = Code;
            Settings.KindOfResource = KindOfResource;

            try
            {
                Connection = new SqlConnection(Settings.ConnectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
