using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    class comprasProveedorBus : IComprasProveedores
    {
        ProveedoresDao daoProveedores = new ProveedoresDao();
        ProductosProveedoresDao daoProductos = new ProductosProveedoresDao();
        UniProveedoresServiciosProductos daoUniPSP = new UniProveedoresServiciosProductos();
        public DataTable GetProveedores()
        {
            return daoProveedores.Get();
        }

        public DataTable GetServProdProv(int idProveedor)
        {
             return daoUniPSP.GetServProdProv(idProveedor);
        }


        public DataTable GetBalatas(int idProveedor)
        {
            return daoProductos.GetBalatas(idProveedor);
        }
    }
}
