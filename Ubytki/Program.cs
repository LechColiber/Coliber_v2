using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using ProcessCloser;

namespace Ubytki
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
            string MUTEX_GUID = "ubytki_coliber";

            Settings.oneMutex = null;

            try
            {
                Settings.oneMutex = Mutex.OpenExisting(MUTEX_GUID);
            }
            catch (WaitHandleCannotBeOpenedException Ex)
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

            ProcessMonitor.Init("coliber");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 1)
            { 
                if(args[1] == "1")
                    Application.Run(new UbytkiForm(Int32.Parse(args[0]), UbytkiForm.KindEnum.Book));
                else if (args[1] == "2")
                    Application.Run(new UbytkiForm(Int32.Parse(args[0]), UbytkiForm.KindEnum.Magazine)); 
            }
        }
    }
}
