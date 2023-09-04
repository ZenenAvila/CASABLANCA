using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.dao
{
    class UniProveedoresServiciosProductos
    {
        connectionBDD cn = new connectionBDD();
        public void ValidServProdProv(int idProveedor, int idProductoServicio)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_VALID_PROVEEDORES_SERVICIOS_PRODUCTOS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            cmd.Parameters.AddWithValue("@ID_SERVICIOS_PRODUCTOS", idProductoServicio);
            cmd.ExecuteReader();
            cn.close();
        }

        public DataTable GetServProdProv(int idProveedor)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_SERV_PROD_PROV", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable GetProvByServProd(int idServProd)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_PROV_BY_SERV_PROD", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_SERVICIOS_PRODUCTOS", idServProd);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }
    }
}
