using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    interface IComprasProveedores
    {
        DataTable GetProveedores();

        DataTable GetServProdProv(int idProveedor);

        DataTable GetBalatas(int idProveedor);
    }
}
