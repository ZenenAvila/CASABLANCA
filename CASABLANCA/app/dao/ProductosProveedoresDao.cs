using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.dao
{
    class ProductosProveedoresDao
    {
        connectionBDD cn = new connectionBDD();

        //Clutch
        public DataTable GetClutch(int idProveedor)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_CLUTCH", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable InsertClutch(string aplicacion, int idProveedor, string numParte,
            string prodcuto, string eqvLuk, string eqvSachs, string eqv3L, string eqvExedy,
            string eqvValeo, string eqvAisin, decimal precioCompra, decimal precioPublico)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_CLUTCH", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@APLICACION", aplicacion);
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            cmd.Parameters.AddWithValue("@NUMERO_PARTE", numParte);
            cmd.Parameters.AddWithValue("@PRODUCTO", prodcuto);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_LUK", eqvLuk);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_SACHS", eqvSachs);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_3L_ORIGINAL", eqv3L);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_EXEDY", eqvExedy);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_VALEO", eqvValeo);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_AISIN", eqvAisin);
            cmd.Parameters.AddWithValue("@PRECIO_COMPRA", precioCompra);
            cmd.Parameters.AddWithValue("@PRECIO_PUBLICO", precioPublico);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public void UpdateClutch(int id, string aplicacion, int idProveedor, string numParte,
            string prodcuto, string eqvLuk, string eqvSachs, string eqv3L, string eqvExedy,
            string eqvValeo, string eqvAisin, decimal precioCompra, decimal precioPublico)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_CLUTCH", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@APLICACION", aplicacion);
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            cmd.Parameters.AddWithValue("@NUMERO_PARTE", numParte);
            cmd.Parameters.AddWithValue("@PRODUCTO", prodcuto);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_LUK", eqvLuk);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_SACHS", eqvSachs);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_3L_ORIGINAL", eqv3L);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_EXEDY", eqvExedy);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_VALEO", eqvValeo);
            cmd.Parameters.AddWithValue("@EQUIVALENCIA_AISIN", eqvAisin);
            cmd.Parameters.AddWithValue("@PRECIO_COMPRA", precioCompra);
            cmd.Parameters.AddWithValue("@PRECIO_PUBLICO", precioPublico);
            cmd.ExecuteReader();

            cn.close();
        }

        public void DeleteClutch(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_CLUTCH", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteReader();

            cn.close();
        }

        //Balatas
        public DataTable GetBalatas(int idProveedor)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_BALATAS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable InsertBalatas(int idProveedor, string numParte, string marca, string posicion,
            bool abutment, string aplicacion, string modelo, string formula, decimal precioPublico,
            string observaciones, int existencia)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_BALATAS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            cmd.Parameters.AddWithValue("@NUMERO_PARTE", numParte);
            cmd.Parameters.AddWithValue("@MARCA", marca);
            cmd.Parameters.AddWithValue("@POSICION", posicion);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", observaciones);
            cmd.Parameters.AddWithValue("@ABUTMEN", abutment);
            cmd.Parameters.AddWithValue("@APLICACION", aplicacion);
            cmd.Parameters.AddWithValue("@MODELO", modelo);
            cmd.Parameters.AddWithValue("@FORMULA", formula);
            cmd.Parameters.AddWithValue("@PRECIO_PUBLICO", precioPublico);
            cmd.Parameters.AddWithValue("@EXISTENCIA", existencia);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public void UpdateBalatas(int id, int idProveedor, string numParte, string marca, string posicion,
            bool abutment, string aplicacion, string modelo, string formula, decimal precioPublico,
            string observaciones)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_BALATAS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            cmd.Parameters.AddWithValue("@NUMERO_PARTE", numParte);
            cmd.Parameters.AddWithValue("@MARCA", marca);
            cmd.Parameters.AddWithValue("@POSICION", posicion);
            cmd.Parameters.AddWithValue("@OBSERVACIONES", observaciones);
            cmd.Parameters.AddWithValue("@ABUTMEN", abutment);
            cmd.Parameters.AddWithValue("@APLICACION", aplicacion);
            cmd.Parameters.AddWithValue("@MODELO", modelo);
            cmd.Parameters.AddWithValue("@FORMULA", formula);
            cmd.Parameters.AddWithValue("@PRECIO_PUBLICO", precioPublico);
            cmd.Parameters.AddWithValue("@EXISTENCIA", 1);
            cmd.ExecuteReader();
            cn.close();
        }

        public void DeleteBalatas(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_BALATAS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteReader();
            cn.close();
        }

        public void updateExistencia(int nuevo,string tabla, int id, string noParte,
             int idProv,string marca, decimal precioUni, int cantidad)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_EXISTENCIA_PRECIO", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EXISTENCIA_NUEVA", nuevo);
            cmd.Parameters.AddWithValue("@TABLA", tabla);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NO_PARTE", noParte);
            cmd.Parameters.AddWithValue("@ID_PROV", idProv);
            cmd.Parameters.AddWithValue("@MARCA", marca); 
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", precioUni); 
            cmd.Parameters.AddWithValue("@CANTIDAD", cantidad); 
            cmd.ExecuteReader();
            cn.close();
        }
    }
}
