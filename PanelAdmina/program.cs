using System;
using System.Threading;
using System.Diagnostics;
using System.Globalization;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

namespace WindowsFormsApplication1
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

            //CommonFunctions.CheckIsOpen("panel_admina", "");
            //Settings.coliberSetSettings();
            //Application.Run(new DistributorForm());
            //return;
            if (args != null && args.Any())
            {
                //MessageBox.Show(args[0]);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(args[0]);
            }
            else Thread.CurrentThread.CurrentUICulture = new CultureInfo("pl-PL");

            Configurator Conf = new Configurator("coliber", "coliber.ini", true);
            if (Conf.ShowDialog() == DialogResult.OK)
                Application.Run(new Main());
        }
    }
}
