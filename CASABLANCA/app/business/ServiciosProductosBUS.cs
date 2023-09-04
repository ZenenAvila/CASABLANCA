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

        public DataTable Get()
        {
            return dao.Get();
        }
        public DataTable Insert(string codigo, string nombre, decimal precioUnitario)
        {
            return dao.Insert(codigo, nombre, precioUnitario);
        }
        public DataTable Update(int id, string codigo, string nombre, decimal precioUnitario)
        {
            return dao.Update(id,codigo,nombre,precioUnitario);
        }
        public DataTable Delete(int id)
        {
            return dao.Delete(id);
        }
    }
}
