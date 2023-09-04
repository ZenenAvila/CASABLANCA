using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    interface IAutos
    {
        DataTable GetAutos(int id);
        void InsertAuto(string placa, string marca, string modelo, string numeroSerie,
            string color, int KMJ, int idCliente);
        void UpdateAuto(int id, string placa, string marca, string modelo, string numeroSerie,
            string color, int KMJ);
        void DeleteAuto(int id);
    }
}
