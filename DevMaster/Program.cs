using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DevMaster
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //GUILogin guiLogin = new GUILogin();
            //if (guiLogin.ShowDialog() == DialogResult.OK)
            //{
                Application.Run(new GUIPrincipal());
            //}
            
        }
    }
}
