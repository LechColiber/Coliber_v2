using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using ProcessCloser;

namespace Artykuly
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// 
        /// [0] - id_rodzaj
        /// [1] - tryb działania
        ///         1 - nowy
        ///         2 - edycja
        ///         3 - usuwanie
        ///         4 - read only do katalogu
        /// [2] -  kod artykułu
        /// </summary>
        
        [System.Runtime.InteropServices.DllImport("user32", SetLastError=false)]
        private static extern bool SetForegroundWindow(Int32 hwnd);
        [STAThread]
        static void Main(string[] args)
        {
            /*string MUTEX_GUID = "artykuly_coliber";

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
                        
            ProcessMonitor.Init("coliber");*/
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ChooseType CT = new ChooseType(1, 3, new Form());
           /* if (args.Length == 2)
            {
                ChooseType CT = new ChooseType(Int32.Parse(args[0]), Int32.Parse(args[1]));
            }
            else if (args.Length == 3)
            {              
                ChooseType CT = new ChooseType(Int32.Parse(args[0]), Int32.Parse(args[1]), args[2]);
            }*/
        }
    }   
}
