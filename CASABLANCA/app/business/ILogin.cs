using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    interface ILogin
    {
        DataTable GetUser(string user, string pass);
        int ValidUser(string user, string pass);
        bool ChangePassword(string user);
    }
}
