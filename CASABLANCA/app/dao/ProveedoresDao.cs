using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.dao
{
    class ProveedoresDao
    {
        connectionBDD cn = new connectionBDD();

        public DataTable Get()
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_PROVEEDORES", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable GetByID(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_PROVEEDORES_ID", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable Insert(string nombre, string rfc, string direccion,string telefono,
            string correo)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_PROVEEDORES", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", nombre);
            cmd.Parameters.AddWithValue("@RFC", rfc);
            cmd.Parameters.AddWithValue("@DIRECCION", direccion);
            cmd.Parameters.AddWithValue("@TELEFONO", telefono);
            cmd.Parameters.AddWithValue("@CORREO", correo);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable Update(int id, string nombre, string rfc, string direccion, 
            string telefono, string correo)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_PROVEEDORES", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NOMBRE", nombre);
            cmd.Parameters.AddWithValue("@RFC", rfc);
            cmd.Parameters.AddWithValue("@DIRECCION", direccion);
            cmd.Parameters.AddWithValue("@TELEFONO", telefono);
            cmd.Parameters.AddWithValue("@CORREO", correo);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable Delete(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_PROVEEDORES", cn._connection);
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
