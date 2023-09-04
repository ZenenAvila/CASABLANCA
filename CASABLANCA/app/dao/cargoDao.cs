using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.dao
{
    class cargoDao
    {
        connectionBDD cn = new connectionBDD();

        public DataTable GetCargo()
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_CARGO", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

    }
}
