using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    class HistServiciosProductosBus:IHistServiciosProductos
    {
        HistServiciosProductosDao dao = new HistServiciosProductosDao();

        public DataTable Get()
        {
            return dao.Get();
        }
    }
}
