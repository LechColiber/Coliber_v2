using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Reports
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string MUTEX_GUID = "e1ffff8f-c91d-4188-9e82-c92ca5b1d057";

            Mutex oneMutex = null;

            try
            {
                oneMutex = Mutex.OpenExisting(MUTEX_GUID);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                // Mutex nie istnieje, obsługa wyjątku
            }

            if (oneMutex == null)
            {
                oneMutex = new Mutex(true, MUTEX_GUID);
            }
            else
            {
                oneMutex.Close();
                return;
            }

            ProcessCloser.ProcessMonitor.Init("coliber");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 2)
            {
                if (Int32.Parse(args[0]) == 1)
                    Application.Run(new WydrukKIForm(Int32.Parse(args[1])));
            }
        }
    }
}
