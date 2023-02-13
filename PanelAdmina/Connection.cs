using System.Data.Odbc;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApplication1
{
    public class Connection
    {
        public string ConnectionString;
        public OdbcConnection AppConnection;
        public string cODBCDriver = "SQL Server";

        public Connection(string File)
        {
            SetConnection(File);
        }

        public void SetConnection(string File)
        {
            Set(File);
            //AppConnection = new SqlConnection("Server=" + Server + ";Database=" + Database + ";Integrated Security = true");
            //ConnectionString = "Driver={SQL SERVER};" + ConnectionString.Replace("integrated security = SSPI", "Trusted_Connection=yes");
            ConnectionString = "Driver={"+ cODBCDriver + "};" + ConnectionString.Replace("integrated security = SSPI", "Trusted_Connection=yes");
            ConnectionString = ConnectionString.Replace("integrated security=SSPI", "Trusted_Connection=yes");
            //ConnectionString = @"Driver={SQL Server};server=DEV1\SQLEXPRESS;database=coliber_wzorzec_dentons;Trusted_Connection=yes";
            AppConnection = new OdbcConnection(ConnectionString);
            if (System.IO.File.Exists("Debug.SQL")) System.Windows.Forms.MessageBox.Show(ConnectionString,"SetConnection");
        }

        public void Set(string File)
        {
            IniFile Configs = new IniFile("coliber.ini", "coliber");

            this.ConnectionString = Configs.ReadIni("SqlServer", "ConnectionString");
            this.cODBCDriver = GetOdbcSqlDriverName(); //Configs.ReadIni("SqlServer", "ODBCDriver");
            if (System.IO.File.Exists("Debug.SQL")) System.Windows.Forms.MessageBox.Show(Configs.path + "\n" + Configs.Path,"Set");
        }

    public string[] GetOdbcDriverNames()
        {
            string[] odbcDriverNames = null;
            using (RegistryKey localMachineHive = Registry.LocalMachine)
            using (RegistryKey odbcDriversKey = localMachineHive.OpenSubKey(@"SOFTWARE\ODBC\ODBCINST.INI\ODBC Drivers"))
            {
                if (odbcDriversKey != null)
                {
                    odbcDriverNames = odbcDriversKey.GetValueNames();
                }
            }

            return odbcDriverNames;
        }

        public string GetOdbcSqlDriverName()
        {
            List<string> driverPrecedence = new List<string>() { "ODBC Driver 17 for SQL Server", "ODBC Driver 13 for SQL Server", "ODBC Driver 11 for SQL Server", "SQL Server Native Client 11.0", "SQL Server Native Client 10.0", "SQL Server Native Client 9.0", "SQL Server" };
            string[] availableOdbcDrivers = GetOdbcDriverNames();
            string driverName = null;

            if (availableOdbcDrivers != null)
            {
                driverName = driverPrecedence.Intersect(availableOdbcDrivers).FirstOrDefault();
            }

            return driverName;
        }

    }
}
