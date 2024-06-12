using RestaurAdminApp.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurAdminApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string codice;
            var exists = LetturaOperations.ExistsCode(out codice);
            if (exists)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new frmRegForm());
            }
            
        }
    }
}
