using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.dao
{
    class CatProductosServiciosDao
    {
        connectionBDD cn = new connectionBDD();

        public DataTable GetCatPS()
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_CAT_PRODUCTO_SERVICIO", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }
    }
}
