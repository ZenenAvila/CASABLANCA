using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    interface IDirecciones
    {
        DataTable GetDireciones(int idCliente);

        void InsertDireccion(string pais, string estado, string municipio,
            string ciudad, string colonia, string codigoPostal, string calle,
            string noExterior, string noInterior, int idCliente);

        void UpdateDireccion(int id, string pais, string estado, string municipio,
            string ciudad, string colonia, string codigoPostal, string calle,
            string noExterior, string noInterior, int idCliente);

        void DeleteCliente(int id);
    }
}
