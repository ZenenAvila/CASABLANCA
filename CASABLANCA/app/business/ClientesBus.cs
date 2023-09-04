using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    class ClientesBus:IClientes
    {
        ClientesDao dao = new ClientesDao();

        public DataTable GetClientes()
        {
            return dao.GetClientes();
        }

        public DataTable GetClientesCombo()
        {
            return dao.GetClientesCombo();
        }

        public void InsertCliente(string nombre, string correo, string cfdi, string rfc,
            string codigoPostal, string calle, string municipio, string estado)
        {
            dao.InsertCliente(nombre, correo, cfdi, rfc,
            codigoPostal, calle, municipio, estado);
        }

        public void UpdateCliente(int id, string nombre, string correo, string cfdi, string rfc,
            string codigoPostal, string calle, string municipio, string estado)
        {
            dao.UpdateCliente(id, nombre, correo, cfdi, rfc,
            codigoPostal, calle, municipio, estado);
        }

        public void DeleteCliente(int id)
        {
            dao.DeleteCliente(id);
        }
    }
}
