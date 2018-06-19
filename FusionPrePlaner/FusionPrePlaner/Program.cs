using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FusionPrePlaner
{
    static class Program
    {

        public static FM_Main fmMainWindow = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            fmMainWindow = new FM_Main();
            Application.Run(fmMainWindow);
        }
    }
}
