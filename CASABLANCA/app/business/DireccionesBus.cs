using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    class DireccionesBus:IDirecciones
    {
        DireccionesDao dao = new DireccionesDao();

        public DataTable GetDireciones(int idCliente)
        {
            return dao.GetDireciones(idCliente);
        }

        public void InsertDireccion(string pais, string estado, string municipio,
            string ciudad, string colonia, string codigoPostal, string calle,
            string noExterior, string noInterior, int idCliente)
        {
            dao.InsertDireccion(pais, estado, municipio, ciudad, colonia, 
                codigoPostal, calle, noExterior, noInterior, idCliente);
        }

        public void UpdateDireccion(int id ,string pais, string estado, string municipio,
            string ciudad, string colonia, string codigoPostal, string calle,
            string noExterior, string noInterior, int idCliente)
        {
            dao.UpdateDireccion(id,pais, estado, municipio,
            ciudad, colonia, codigoPostal, calle,
            noExterior, noInterior, idCliente);
        }

        public void DeleteCliente(int id)
        {
            dao.DeleteCliente(id);
        }
    }
}
