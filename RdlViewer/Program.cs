using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RdlViewer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] argc)
        {
            Application.EnableVisualStyles();
            Application.Run(new MainForm());
            //Application.Run(new MainForm(argc[0]));
        }
    }
}