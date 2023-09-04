using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    public class UsuariosBus : IUsuarios
    {
        userDao dao = new userDao();
        cargoDao cargo = new cargoDao();

        public void CreateUser(string user, string nombre,
            string apPaterno, string apMaterno, int cargo,
            string email)
        {
            dao.CreateUser(user, nombre, apPaterno, apMaterno, cargo, email);
        }

        public void UpdateUser(int id, string user, string nombre,
            string apPaterno, string apMaterno, int cargo,
            string email, string pass)
        {
            dao.UpdateUser(id, user, nombre, apPaterno, apMaterno, cargo, email, pass);
        }

        public void ChangeStatusUser(int id, int status)
        {
            dao.ChangeStatusUser(id, status);
        }

        public DataTable GetAllUser()
        {
            return dao.GetAllUser();
        }

        public DataTable GetCargo()
        {
            return cargo.GetCargo();
        }
    }
}
