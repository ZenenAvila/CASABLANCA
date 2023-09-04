using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.dao
{
    class DireccionesDao
    {
        connectionBDD cn = new connectionBDD();

        public DataTable GetDireciones(int idCliente)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_DIRECCIONES", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_CLIENTE", idCliente);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public void InsertDireccion(string pais, string estado, string municipio, 
            string ciudad, string colonia, string codigoPostal, string calle, 
            string noExterior, string noInterior,int idCliente)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_DIRECCIONES", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PAIS", pais);
            cmd.Parameters.AddWithValue("@ESTADO", estado);
            cmd.Parameters.AddWithValue("@MUNICIPIO", municipio);
            cmd.Parameters.AddWithValue("@CIUDAD", ciudad);
            cmd.Parameters.AddWithValue("@COLONIA", colonia);
            cmd.Parameters.AddWithValue("@CODIGO_POSTAL", codigoPostal);
            cmd.Parameters.AddWithValue("@CALLE", calle);
            cmd.Parameters.AddWithValue("@NO_EXTERIOR", noExterior);
            cmd.Parameters.AddWithValue("@NO_INTERIOR", noInterior);
            cmd.Parameters.AddWithValue("@ID_CLIENTE", idCliente);
            SqlDataReader reader = cmd.ExecuteReader();
            cn.close();
        }

        public void UpdateDireccion(int id,string pais, string estado, string municipio,
            string ciudad, string colonia, string codigoPostal, string calle,
            string noExterior, string noInterior, int idCliente)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_DIRECCIONES", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@PAIS", pais);
            cmd.Parameters.AddWithValue("@ESTADO", estado);
            cmd.Parameters.AddWithValue("@MUNICIPIO", municipio);
            cmd.Parameters.AddWithValue("@CIUDAD", ciudad);
            cmd.Parameters.AddWithValue("@COLONIA", colonia);
            cmd.Parameters.AddWithValue("@CODIGO_POSTAL", codigoPostal);
            cmd.Parameters.AddWithValue("@CALLE", calle);
            cmd.Parameters.AddWithValue("@NO_EXTERIOR", noExterior);
            cmd.Parameters.AddWithValue("@NO_INTERIOR", noInterior);
            cmd.ExecuteReader();

            cn.close();
        }

        public void DeleteCliente(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_DIRECCION", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteReader();

            cn.close();
        }
    }
}
