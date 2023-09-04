using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.dao
{
    class ClientesDao
    {
        connectionBDD cn;


        public DataTable GetClientes()
        {
            cn = new connectionBDD();
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_CLIENTES", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable GetClientesCombo()
        {
            cn = new connectionBDD();
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_CLIENTES_COMBO", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public void InsertCliente(string nombre, string correo, string cfdi, string rfc,
            string codigoPostal, string calle, string municipio, string estado)
        {
            cn = new connectionBDD();
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_CLIENTES", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", nombre);
            cmd.Parameters.AddWithValue("@CORREO", correo);
            cmd.Parameters.AddWithValue("@CFDI", cfdi);
            cmd.Parameters.AddWithValue("@RFC", rfc);
            cmd.Parameters.AddWithValue("@CODIGO_POSTAL", codigoPostal);
            cmd.Parameters.AddWithValue("@CALLE", calle);
            cmd.Parameters.AddWithValue("@MUNICIPIO", municipio);
            cmd.Parameters.AddWithValue("@ESTADO", estado);
            SqlDataReader reader = cmd.ExecuteReader();
            cn.close();
        }

        public void UpdateCliente(int id, string nombre, string correo, string cfdi, string rfc,
            string codigoPostal, string calle, string municipio, string estado)
        {
            cn = new connectionBDD();
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_CLIENTES", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NOMBRE", nombre);
            cmd.Parameters.AddWithValue("@CORREO", correo);
            cmd.Parameters.AddWithValue("@CFDI", cfdi);
            cmd.Parameters.AddWithValue("@RFC", rfc);
            cmd.Parameters.AddWithValue("@CODIGO_POSTAL", codigoPostal);
            cmd.Parameters.AddWithValue("@CALLE", calle);
            cmd.Parameters.AddWithValue("@MUNICIPIO", municipio);
            cmd.Parameters.AddWithValue("@ESTADO", estado);
            cmd.ExecuteReader();

            cn.close();
        }

        public void DeleteCliente(int id)
        {
            cn = new connectionBDD();
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_CLIENTE", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteReader();

            cn.close();
        }


    }
}
