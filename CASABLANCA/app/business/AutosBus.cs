using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    class AutosBus
    {
        AutosDao dao = new AutosDao();
        public DataTable GetAutos(int id)
        {
            return dao.GetAutos(id);
        }

        public void InsertAuto(string placa, string marca, string modelo, string numeroSerie,
            string color, int KMJ, int idCliente)
        {
            dao.InsertAuto(placa, marca, modelo, numeroSerie,
            color, KMJ, idCliente);
        }

        public void UpdateAuto(int id, string placa, string marca, string modelo, string numeroSerie,
            string color, int KMJ)
        {
            dao.UpdateAuto(id,placa, marca, modelo, numeroSerie,
            color, KMJ);
        }

        public void DeleteAuto(int id)
        {
            dao.DeleteAuto( id);
        }
    }
}
