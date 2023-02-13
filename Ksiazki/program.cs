using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using ProcessCloser;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using ProcessCloser;

namespace Ksiazki
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [System.Runtime.InteropServices.DllImport("user32", SetLastError = false)]
        private static extern bool SetForegroundWindow(Int32 hwnd);
        [STAThread]
        static void Main(string[] args)
        {
            // 1 - id rodzaj
            // 2 - tryb
            //      1 - dodawanie
            //      2 - modyfikacja
            //      3 - usuwanie

            /*string MUTEX_GUID = "ksiazki_coliber";

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

            ProcessMonitor.Init("coliber");*/

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new DeleteSygDialogForm());
            //Application.Run(new ChooseServerForm(1, "Driver=SQL SERVER;SERVER=LAPTOP\\SQLEXPRESS;DATABASE=coliber_1do_test;Trusted_Connection=Yes"));
            //Application.Run(new ChooseServerForm(1));//, ""));
            //Application.Run(new PublisherForm("234", "234"));
            //Application.Run(new ShowKeyListForm());
            //Application.Run(new StartForm());
            //Application.Run((new DetailsForm(1, "21")));
            //Application.Run((new DetailsForm(1, "1")));
            //Application.Run(new TomsForm());
            //Application.Run(new UbytkiForm("46"));
            //Application.Run(new SingleUbytkiForm("   222 ", "   555 "));

            if (args != null && args.Any())
            {
                MessageBox.Show(args[0]);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(args[0]);
            }
//            Application.Run(new DetailsForm(1, "20"));
            Application.Run(new BookListForm(1, BookListForm.ModeEnum.Edit, "1"));
            //Application.Run(new BookListForm(1, BookListForm.ModeEnum.Edit, "1"));
            /*ChooseServerForm CSF = new ChooseServerForm(Settings.ID_rodzaj);
            if(args.Length > 1)
            {
                if(args[1].Trim() == "1")
                    Application.Run(new DetailsForm(Int32.Parse(args[0])));
                else if (args[1].Trim() == "2")
                    Application.Run(new BookListForm(Int32.Parse(args[0]), BookListForm.ModeEnum.Edit));
                else if (args[1].Trim() == "3")
                    Application.Run(new BookListForm(Int32.Parse(args[0]), BookListForm.ModeEnum.Delete));
            }*/
        }      
   
                    // 1 - id rodzaj
            // 2 - tryb
            //      1 - dodawanie
            //      2 - modyfikacja
            //      3 - usuwanie

            /*string MUTEX_GUID = "ksiazki_coliber";

            Settings.oneMutex = null;

            try
            {
                Settings.oneMutex = Mutex.OpenExisting(MUTEX_GUID);
            }
            catch (WaitHandleCannotBeOpenedException Ex)
            {
                // Mutex nie istnieje, obsĹ‚uga wyjÄ…tku                
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

    }
}
