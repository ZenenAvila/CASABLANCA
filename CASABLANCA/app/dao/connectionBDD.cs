using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Configuration.ConfigurationManager;
namespace CASABLANCA.app.dao
{
    class connectionBDD
    {
        //string cadena = "Data Source=DESKTOP-F3EHM0T\\SQLEXPRESS;Initial Catalog=CASABLANCA; Integrated Security=True";
        //CADENA GAMER
        //public static string cadena = "Data Source=LAPTOP-QDP5DH58\\SQLEXPRESS;Initial Catalog=CASABLANCA_DEV; Integrated Security=True";
        //CADENA CASABLANCA
        //public static string cadena = "Data Source=DESKTOP-3A0EPT1\\OPUSDB;Initial Catalog=master; Integrated Security=True";
        //CADENA PRO
        public static string cadena = "Data Source=DESKTOP-F3EHM0T\\SQLEXPRESS;Initial Catalog=master; Integrated Security=True";
        //public static string _cadena = ConnectionStrings["CASABLANCA"].ConnectionString;
        public SqlConnection _connection = new SqlConnection(cadena);

        public connectionBDD()
        {
            //string _cadena = ConnectionStrings["CASABLANCA"].ConnectionString;
             //_connection = new SqlConnection(_cadena);
        //_connection.ConnectionString = cadena;---------
            //_connection = new SqlConnection(ConnectionStrings["CASABLANCA"].ConnectionString);
        }

        public string open()
        {
            try
            {
                //_connection.ConnectionString = _cadena;
                _connection.Open();
                return "Conexxion correcta";
            }
            catch (Exception ex)
            {
                return "Erro:" + ex.Message;
            }
        }

        public string close()
        {
            try
            {
                _connection.Close();
                return "Conexxion correcta";
            }
            catch (Exception ex)
            {
                return "Erro:" + ex.Message;
            }
        }
    }
}
