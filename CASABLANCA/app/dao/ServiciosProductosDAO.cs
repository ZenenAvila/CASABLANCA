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

        public DataTable Get()
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_PRODUCTOS_SERVICIOS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable Insert(string codigo, string nombre, decimal precioUnitario)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_PRODUCTOS_SERVICIOS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CODIGO", codigo);
            cmd.Parameters.AddWithValue("@NOMBRE", nombre);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", precioUnitario);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable Update(int id, string codigo, string nombre, decimal precioUnitario)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_PRODUCTOS_SERVICIOS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@CODIGO", codigo);
            cmd.Parameters.AddWithValue("@NOMBRE", nombre);
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
