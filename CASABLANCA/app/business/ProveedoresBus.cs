using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    class ProveedoresBus:IProveedores
    {
        ProveedoresDao dao = new ProveedoresDao();

        public DataTable Get()
        {
            return dao.Get();
        }
        public void Insert(string nombre, string rfc, string direccion, string telefono,
            string correo)
        {
            dao.Insert(nombre, rfc, direccion,telefono,correo);
        }
        public void Update(int id, string nombre, string rfc, string direccion,
            string telefono, string correo)
        {
            dao.Update(id, nombre, rfc,direccion,telefono,correo);
        }
        public void Delete(int id)
        {
            dao.Delete(id);
        }
    }
}
