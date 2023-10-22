using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CASABLANCA.app.dao
{
    public class ServiciosProductosDao
    {
        connectionBDD cn = new connectionBDD();

        public DataTable Get(int idProveedor)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_PRODUCTOS_SERVICIOS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable Insert(string producto, bool esServicio,string numeroParte, 
            string descripcion, int idProveedor, decimal precioCompra, decimal precioUnitario)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_PRODUCTOS_SERVICIOS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PRODUCTO", producto);
            cmd.Parameters.AddWithValue("@ES_SERVICIO", esServicio);
            cmd.Parameters.AddWithValue("@NUMERO_PARTE", numeroParte);
            cmd.Parameters.AddWithValue("@DESCRIPCION", descripcion);
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            cmd.Parameters.AddWithValue("@PRECIO_COMPRA", precioCompra);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", precioUnitario);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable Update(int id, string producto, bool esServicio, string numeroParte,
            string descripcion, int idProveedor, decimal precioCompra, decimal precioUnitario)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_PRODUCTOS_SERVICIOS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@PRODUCTO", producto);
            cmd.Parameters.AddWithValue("@ES_SERVICIO", esServicio);
            cmd.Parameters.AddWithValue("@NUMERO_PARTE", numeroParte);
            cmd.Parameters.AddWithValue("@DESCRIPCION", descripcion);
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            cmd.Parameters.AddWithValue("@PRECIO_COMPRA", precioCompra);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", precioUnitario);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable Delete(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_PRODUCTOS_SERVICIOS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }
    }
}
