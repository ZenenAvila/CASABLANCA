using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.dao
{
    class AutosDao
    {
        connectionBDD cn = new connectionBDD();


        public DataTable GetAutos(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_AUTOS", cn._connection);
            cmd.Parameters.AddWithValue("@ID_CLIENTE", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public void InsertAuto(string placa, string marca, string modelo, string numeroSerie,
            string color, int KMJ, int idCliente)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_AUTOS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PLACA", placa);
            cmd.Parameters.AddWithValue("@MARCA", marca);
            cmd.Parameters.AddWithValue("@MODELO", modelo);
            cmd.Parameters.AddWithValue("@NUMERO_SERIE", numeroSerie);
            cmd.Parameters.AddWithValue("@COLOR", color);
            cmd.Parameters.AddWithValue("@KMJ", KMJ);
            cmd.Parameters.AddWithValue("@ID_CLIENTE", idCliente);
            cmd.ExecuteReader();
            cn.close();
        }

        public void UpdateAuto(int id, string placa, string marca, string modelo, string numeroSerie,
            string color, int KMJ)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_AUTOS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@PLACA", placa);
            cmd.Parameters.AddWithValue("@MARCA", marca);
            cmd.Parameters.AddWithValue("@MODELO", modelo);
            cmd.Parameters.AddWithValue("@NUMERO_SERIE", numeroSerie);
            cmd.Parameters.AddWithValue("@COLOR", color);
            cmd.Parameters.AddWithValue("@KMJ", KMJ);
            cmd.ExecuteReader();
            cn.close();
        }

        public void DeleteAuto(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_AUTOS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteReader();
            cn.close();
        }

    }
}
