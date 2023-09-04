using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    interface IClientes
    {
        DataTable GetClientes();
        DataTable GetClientesCombo();
        void InsertCliente(string nombre, string correo, string cfdi, string rfc,
            string codigoPostal, string calle, string municipio, string estado);
        void UpdateCliente(int id, string nombre, string correo, string cfdi, string rfc,
            string codigoPostal, string calle, string municipio, string estado);
        void DeleteCliente(int id);
    }
}
