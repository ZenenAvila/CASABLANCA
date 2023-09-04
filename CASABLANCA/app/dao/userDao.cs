using CASABLANCA.app.client;
using CASABLANCA.app.cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.dao
{
    class userDao
    {
        connectionBDD cn = new connectionBDD();

        public int ValidUser(string user, string pass)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_VALID_USER", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USER_NAME", user);
            cmd.Parameters.AddWithValue("@PASSWORD", pass);
            //SqlDataReader reader = cmd.ExecuteReader();

            int result = Convert.ToInt32(cmd.ExecuteScalar());

            //DataTable dt = new DataTable();
            //dt.Load(reader);
            cn.close();
            return result;
        }

        public void CreateUser(string user, string nombre,
            string apPaterno, string apMaterno, int cargo,
            string email)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_USER", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USER_NAME", user);
            cmd.Parameters.AddWithValue("@NOMBRE", nombre);
            cmd.Parameters.AddWithValue("@APELLIDO_PATERNO", apPaterno);
            cmd.Parameters.AddWithValue("@APELLIDO_MATERNO", apMaterno);
            cmd.Parameters.AddWithValue("@ID_CARGO", cargo);
            cmd.Parameters.AddWithValue("@EMAIL", email);

            cmd.ExecuteScalar();
            cn.close();
        }

        public void UpdateUser(int id, string user, string nombre,
            string apPaterno, string apMaterno, int cargo,
            string email, string pass)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_USER", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@USER_NAME", user);
            cmd.Parameters.AddWithValue("@PASSWORD", pass);
            cmd.Parameters.AddWithValue("@NOMBRE", nombre);
            cmd.Parameters.AddWithValue("@APELLIDO_PATERNO", apPaterno);
            cmd.Parameters.AddWithValue("@APELLIDO_MATERNO", apMaterno);
            cmd.Parameters.AddWithValue("@ID_CARGO", cargo);
            cmd.Parameters.AddWithValue("@EMAIL", email);

            cmd.ExecuteScalar();
            cn.close();
        }

        public void ChangeStatusUser(int id, int status)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_STATUS_USER", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@STATUS", status);

            cmd.ExecuteScalar();
            cn.close();
        }


        public DataTable GetUser(string user, string pass)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_USER", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USER_NAME", user);
            cmd.Parameters.AddWithValue("@PASSWORD", pass);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    userCls.id = reader.GetInt32(0);
                    userCls.user = reader.GetString(1);
                    userCls.nombre = reader.GetString(3);
                    userCls.apellidoPaterno = reader.GetString(4);
                    userCls.apellidoMaterno = reader.GetString(5);
                    userCls.cargo = reader.GetString(6);
                    userCls.email = reader.GetString(7);
                }
            }
            //int result = Convert.ToInt32(cmd.ExecuteScalar());

            DataTable dt = new DataTable();
            //dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable GetAllUser()
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_ALL_USER", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public bool ChangePassword(string user)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_CHANGE_PASSWORD_USER", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@USER_NAME", user);
            SqlDataReader reader = cmd.ExecuteReader();
            bool result=false;
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string nombre = reader.GetString(3) + reader.GetString(4) + reader.GetString(5);
                    string mail = reader.GetString(7);
                    string pass = reader.GetString(2);

                    var mailService = new Commond.SystemSupportMail();
                    mailService.sendMail(
                        subject: "CASABLANCA: Solicitud de recuperación de contraseña",
                        body: "Hola, " + nombre + "" +
                        "\nEsta es tu solicitud de recuperación de contraseña," +
                        "\nTu contraseña es: " + pass+"  " +
                        "\n" +
                        "\nATENCION" +
                        "\nSi tu no realizaste esta solicitud haz caso omiso a este correo y contactate" +
                        "con la gerencia de CASABLANCA Clutch and Frenos.",
                        recipientMail: new List<string> { mail.ToLower() }
                        );
                    result = true;
                }
            }
            else
            {
                result = false;
            }
            
            cn.close();
            return result;
        }
    }
}
