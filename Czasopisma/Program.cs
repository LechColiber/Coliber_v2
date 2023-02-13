using System;
using System.Runtime.Hosting;
using System.Windows.Forms;

namespace Czasopisma
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 

        [STAThread]
        static void Main(string[] args)
        {
            CommonFunctions.CheckIsOpen("czasopisma_coliber", "coliber");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MagazineForm(1, "430", true));
            //Application.Run(new MagazineForm(1));
            //Application.Run(new MagazineForm(1, "430", true));
            //Settings.SetSettings(1);
            //Application.Run(new UbytkiForm("424"));
            //Application.Run(new UbytkowanieForm("424", "KW1", "aaa", true));
            //Application.Run(new UbytkiForm("424", true));
            //Application.Run(new InstitutionForm("419", false));
            Application.Run(new ChooseForm(1, ChooseForm.ModeEnum.Edit, "1", false));            
            //Application.Run(new MagazineForm(Int32.Parse(args[0]), args[1]));
            //Application.Run(new ChooseForm(1, false));
        }
    }
}
