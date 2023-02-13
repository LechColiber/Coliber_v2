
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Coliber
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            //CommonFunctions.CheckIsOpen("coliber", "coliber");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new TestForm());

            if (args != null && args.Any())
            {
                //MessageBox.Show(args[0]);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(args[0]);
            }
            else Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl-PL");

            Settings.SetSettings();
            DialogResult dr = DialogResult.Abort;

            int[] aGroup = { 80, 76, 45, 83, 71, 32, 84, 65, 88, 32, 67, 111, 108, 105, 98, 101, 114, 32, 65, 114, 99, 104, 105, 119, 117, 109 };
            string cName = Environment.UserDomainName + @"\" + Environment.UserName;
            //cName = string.Join("", aGroup);
            cName = aGroup.Aggregate(string.Empty, (s, i) => s + (char)i);
            if  (System.IO.File.Exists("Debug.SQL") || false) MessageBox.Show(cName);
            
            //MessageBox.Show(cName);
            int id = App.LogIn(cName, "", ref Settings.Connection);

            if (System.IO.File.Exists("Debug.SQL")) MessageBox.Show(id.ToString(),"log");

            if (id >= 0)
            {
                IniFile wypozyczalniaConfigs = new IniFile("wypozycz.ini", "wypozyczalnia");
                if (!string.IsNullOrEmpty(wypozyczalniaConfigs.path))
                {
                    Settings.wypozyczalniaConnectionString = Settings.getConnectionString(wypozyczalniaConfigs.ReadIni("SqlServer", "ConnectionString"));
                }
                var connWyp = new SqlConnection(Settings.wypozyczalniaConnectionString);
                id = App.LogIn(cName, "", ref connWyp);
                if (System.IO.File.Exists("Debug.SQL")) MessageBox.Show(id.ToString(),"wypozycz");
                Settings.employeeID = id.ToString();
            }
            else
            {
                if (System.IO.File.Exists("Debug.SQL")) MessageBox.Show(id.ToString(),"form");
                LoginForm LF = new LoginForm();
                dr = LF.ShowDialog();
            }

            if (Settings.employeeID != "0")
            {
                SqlCommand Command = new SqlCommand();
                Command.CommandText = "EXEC UserDb @uzytkownik; ";
                Command.Parameters.AddWithValue("@uzytkownik", Settings.UserName);

                DataTable Dt = CommonFunctions.ReadData(Command, ref Settings.Connection);

                if (Dt.Rows.Count > 0)
                {
                    Int32.TryParse(Dt.Rows[0]["baza_start"].ToString(), out Settings.ID_rodzaj);

                    if (Settings.ID_rodzaj == 0)
                        Settings.InvertoryName = "wszystkie";
                    else
                        Settings.InvertoryName = Dt.Rows[0]["inwentarz"].ToString();                    
                }
                App.Init();
                MainForm MF = new MainForm();
                MF.ShowDialog();
            }
        }
    }
}
