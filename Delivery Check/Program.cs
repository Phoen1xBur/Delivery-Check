using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delivery_Check
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Authorization loginForm = new Authorization();
            Application.Run(loginForm);

            if (loginForm.userAuth)
            {
                // MainForm is defined elsewhere
                Application.Run(new MainForm(loginForm.isAdmin));
            }
        }
    }
}
