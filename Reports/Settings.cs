using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Reports
{
    class Settings
    {
        public static string ConnectionString;// = @"Server=LAPTOP\sqlexpress;Database=coliberdotk;Trusted_Connection = True;Connection Timeout = 200000;";
        public static SqlConnection Connection;

        public static void SetSettings(string CString)
        {
            ConnectionString = CString;
            /*
            OdbcConnectionStringBuilder OdCB = new OdbcConnectionStringBuilder(ConnectionString);

            Settings.ConnectionStringSql = "Server = " + OdCB["server"].ToString() + ";Database = " + OdCB["database"].ToString() + ";";

            if (OdCB.ContainsKey("TrusteD_Connection"))
                Settings.ConnectionStringSql += "Trusted_Connection = " + OdCB["Trusted_Connection"].ToString();
            else if (OdCB.ContainsKey("Uid"))
                Settings.ConnectionStringSql += "Uid = " + OdCB["Uid"].ToString() + "; Pwd = " + OdCB["Pwd"].ToString();
            else if (OdCB.ContainsKey("User Id"))
                Settings.ConnectionStringSql += "User Id = " + OdCB["User Id"].ToString() + "; Password = " + OdCB["Password"].ToString();
           */

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
