using CASABLANCA.app.cls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASABLANCA
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new app.client.Compras.frmComprasProveedor());

            if (Global.prod)
            {
                Application.Run(new app.client.login());
            }
            else
            {
                Application.Run(new app.client.mainWindows());
            }
        }
    }
}
