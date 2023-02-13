using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Wypozyczalnia
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Settings.SetSettings();
            /*MessageBox.Show(System.Reflection.Assembly.GetExecutingAssembly()
                                           .GetName()
                                           .Version
                                           .ToString());*/
            Settings.employeeID = 20;

            //MessageBox.Show(short.Parse("").ToString());
            //MessageBox.Show(Environment.UserDomainName + "\\" + Environment.UserName);

            if (args != null && args.Any())
            {
                MessageBox.Show(args[0]);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(args[0]);
            }

            Application.Run(new BorrowForm(20, null));

            //Application.Run(new UsersListForm(UsersListForm.Mode.ManageUser, new Form(), 20));
            //Application.Run(new UserForm(new Form()));
            //Application.Run(new UserForm("409",));
            //Application.Run(new CurrentBorrowsForm(20, null));
            //Application.Run(new UserForm("247"));
            //Application.Run(new ZwrotForm("231776"));
            //Application.Run(new ConfigurationForm(0));
            //Application.Run(new UserForm("1"));
            //Application.Run(new StatisticsForm());
            //Application.Run(new CurrentOrdersForm(20, new Form()));
            //Application.Run(new ChooseResourceForm(Settings.employeeID, ChooseResourceForm.WorkMode.ManageResource, null));
            //Application.Run(new ResourceForm(11083, null));
        }
    }
}

