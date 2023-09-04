using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    interface IUsuarios
    {
        void CreateUser(string user, string nombre,
            string apPaterno, string apMaterno, int cargo,
            string email);
        void UpdateUser(int id, string user, string nombre,
            string apPaterno, string apMaterno, int cargo,
            string email,string pass);
        void ChangeStatusUser(int id, int status);
        DataTable GetAllUser();
        DataTable GetCargo();
    }
}
