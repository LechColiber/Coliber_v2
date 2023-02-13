using System;
using System.Diagnostics;
using System.Threading;

namespace ProcessCloser
{
    public class ProcessMonitor
    {
        public static Process[] process;

        public static void Init(string ProcessName)
        {
            process = Process.GetProcessesByName(ProcessName);

            if (process.Length > 0)
            {
                ProcessMonitor.MonitorForExit(process[0]);
            }
        }
        private static void MonitorForExit(Process process)
        {
            Thread thread = new Thread(() =>
            {
                process.WaitForExit();
                OnProcessClosed(EventArgs.Empty);
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private static void OnProcessClosed(EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
