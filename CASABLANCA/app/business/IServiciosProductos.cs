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
        DataTable Get();
        DataTable Insert(string codigo, string nombre, decimal precioUnitario);
        DataTable Update(int id, string codigo, string nombre, decimal precioUnitario);
        DataTable Delete(int id);
    }
}
