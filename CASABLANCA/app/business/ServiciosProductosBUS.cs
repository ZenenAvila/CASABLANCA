using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    class ServiciosProductosBUS:IServiciosProductos
    {
        ServiciosProductosDao dao = new ServiciosProductosDao();

        public DataTable Get(int idProveedor)
        {
            return dao.Get(idProveedor);
        }
        public DataTable Insert(string producto, bool esServicio, string numeroParte,
            string descripcion, int idProveedor, decimal precioCompra, decimal precioUnitario)
        {
            return dao.Insert(producto, esServicio, numeroParte,
            descripcion, idProveedor, precioCompra, precioUnitario);
        }
        public DataTable Update(int id, string producto, bool esServicio, string numeroParte,
            string descripcion, int idProveedor, decimal precioCompra, decimal precioUnitario)
        {
            return dao.Update(id, producto,  esServicio, numeroParte,
            descripcion, idProveedor, precioCompra, precioUnitario);
        }
        public DataTable Delete(int id)
        {
            return dao.Delete(id);
        }
    }
}
