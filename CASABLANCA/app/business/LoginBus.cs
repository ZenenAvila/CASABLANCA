using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    class LoginBus:ILogin
    {
        userDao dao = new userDao();

        public DataTable GetUser(string user, string pass)
        {
            return dao.GetUser(user, pass);
        }

        public int ValidUser(string user, string pass)
        {
            return dao.ValidUser(user, pass);
        }

        public bool ChangePassword(string user)
        {
            return dao.ChangePassword(user);
        }
    }
}
