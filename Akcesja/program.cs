using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace Akcesja
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [System.Runtime.InteropServices.DllImport("user32", SetLastError = false)]
        private static extern bool SetForegroundWindow(Int32 hwnd);
        [STAThread]
        static void Main(string[] args)        
        {
            /*string MUTEX_GUID = "akcesja_coliber";

            Settings.oneMutex = null;

            try
            {
                Settings.oneMutex = Mutex.OpenExisting(MUTEX_GUID);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                // Mutex nie istnieje, obsługa wyjątku
            }

            if (Settings.oneMutex == null)
            {
                Settings.oneMutex = new Mutex(true, MUTEX_GUID);
            }
            else
            {
                Process currentProcess = Process.GetCurrentProcess();

                String processName = currentProcess.ProcessName;
                Int32 currentProcessId = currentProcess.Id;

                Process[] processes = Process.GetProcessesByName(processName);

                foreach (Process p in processes)
                {
                    // Bring the existing instance to the front

                    if (p.Id != currentProcessId)
                    {
                        IntPtr windowHandle = p.MainWindowHandle;
                        SetForegroundWindow(windowHandle.ToInt32());
                    }
                }

                Settings.oneMutex.Close();
                return;
            }

            ProcessCloser.ProcessMonitor.Init("coliber");*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

          /*  if (args != null && args.Any())
            {
                MessageBox.Show(args[0]);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(args[0]);
            }*/
            
            Application.Run(new AkcesjaForm(1, "dopisz", "1", null));
            //Application.Run(new ShowForm(1, "dopisz", null));
            //Application.Run(new StartForm());
            //Application.Run(new AkcesjaDetailsForm(9, "", "",""));
            //Application.Run(new SingleNumberForm());
            //Application.Run(new test(412));

            /*if (args != null && args.Length == 2)
            {
                string Mode = args[1];
                new AkcesjaForm(Int32.Parse(args[0]), Mode);
                //Application.Run(new AkcesjaForm(Int32.Parse(args[0]), Mode));               
            }
            else if (args != null && args.Length > 2)
            {
                new AkcesjaDetailsForm(Int32.Parse(args[0]), args[1], args[2], args[3], args[4], Int32.Parse(args[5]), true);
            }*/
        }
    }
}
