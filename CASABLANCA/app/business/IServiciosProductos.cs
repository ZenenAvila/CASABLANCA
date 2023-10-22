using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    public interface IServiciosProductos
    {
        DataTable Get(int idProveedor);
        DataTable Insert(string producto, bool esServicio, string numeroParte,
            string descripcion, int idProveedor, decimal precioCompra, decimal precioUnitario);
        DataTable Update(int id, string producto, bool esServicio, string numeroParte,
            string descripcion, int idProveedor, decimal precioCompra, decimal precioUnitario);
        DataTable Delete(int id);
    }
}
