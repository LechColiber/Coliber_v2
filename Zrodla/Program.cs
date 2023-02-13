using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Zrodla
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
            string MUTEX_GUID = "zrodla_coliber";

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

            ProcessCloser.ProcessMonitor.Init("coliber");            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            if (args != null && args.Length == 3)
                Application.Run(new SourceForm(Int32.Parse(args[0]), Int32.Parse(args[1]), Int32.Parse(args[2])));
            else if (args != null && args.Length == 4)
                Application.Run(new SourceForm(Int32.Parse(args[0]), Int32.Parse(args[1]), Int32.Parse(args[2]), true));
        }
    }
}
