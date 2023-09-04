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
    class IngresoDao
    {
        connectionBDD cn = new connectionBDD();


        public DataTable GetIngreso(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_INGRESO", cn._connection);
            cmd.Parameters.AddWithValue("@ID_INGRESO", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable GetIngresosCliente(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_INGRESOS_CLIENTE", cn._connection);
            cmd.Parameters.AddWithValue("@ID_CLIENTE", id);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public DataTable InsertIngreso(IngresoCls obj)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_INGRESO", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@LLAVES_DADO", obj.LlavesDado);
            cmd.Parameters.AddWithValue("@FECHA", obj.Fecha);
            cmd.Parameters.AddWithValue("@USER_ATIENDE", obj.UserAtiende);
            cmd.Parameters.AddWithValue("@ID_CLIENTE", obj.IdCliente);
            cmd.Parameters.AddWithValue("@ID_AUTO", obj.IdAuto);
            cmd.Parameters.AddWithValue("@FALLAS", obj.Fallas);
            cmd.Parameters.AddWithValue("@DIAGNOSTICO", obj.Diagnostico);
            cmd.Parameters.AddWithValue("@DESCUENTO", obj.Descuento);
            cmd.Parameters.AddWithValue("@SUBTOTAL", obj.Subtotal);
            cmd.Parameters.AddWithValue("@IVA", obj.Iva);
            cmd.Parameters.AddWithValue("@TOTAL", obj.Total);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public void UpdateIngreso(IngresoCls obj)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_INGRESO", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", obj.Id);
            cmd.Parameters.AddWithValue("@LLAVES_DADO", obj.LlavesDado);
            cmd.Parameters.AddWithValue("@FECHA", obj.Fecha);
            cmd.Parameters.AddWithValue("@USER_ATIENDE", obj.UserAtiende);
            cmd.Parameters.AddWithValue("@ID_CLIENTE", obj.IdCliente);
            cmd.Parameters.AddWithValue("@ID_AUTO", obj.IdAuto);
            cmd.Parameters.AddWithValue("@FALLAS", obj.Fallas);
            cmd.Parameters.AddWithValue("@DIAGNOSTICO", obj.Diagnostico);
            cmd.Parameters.AddWithValue("@DESCUENTO", obj.Descuento);
            cmd.Parameters.AddWithValue("@SUBTOTAL", obj.Subtotal);
            cmd.Parameters.AddWithValue("@IVA", obj.Iva);
            cmd.Parameters.AddWithValue("@TOTAL", obj.Total);
            cmd.ExecuteReader();
            cn.close();
        }

        public void DeleteIngreso(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_INGLESO", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteReader();
            cn.close();
        }

        public DataTable GetIngresoRegistros(int idIngreso)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_INGRESO_REGISTROS", cn._connection);
            cmd.Parameters.AddWithValue("@ID_INGRESO", idIngreso);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public void InsertIngresoRegistros(IngresoRegistrosCls obj)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_INGRESO_REGISTROS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_INGRESO", obj.IdIngreso);
            cmd.Parameters.AddWithValue("@ID_CAT_PROD_SERV", obj.IdCatProdServ);
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", obj.IdProveedor);
            cmd.Parameters.AddWithValue("@ID_PROD_SERV", obj.IdProdServ);
            cmd.Parameters.AddWithValue("@NO_PARTE", obj.NoParte);
            cmd.Parameters.AddWithValue("@MARCA", obj.Marca);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", obj.PrecioUnitario);
            cmd.Parameters.AddWithValue("@IVA", obj.Iva);
            cmd.Parameters.AddWithValue("@DESCUETO", obj.Descuento);
            cmd.Parameters.AddWithValue("@DESCUENTO_PORCENTAJE", obj.DescuentoPorcentaje);
            cmd.Parameters.AddWithValue("@SUBTOTAL", obj.Subtotal);
            cmd.Parameters.AddWithValue("@CANTIDAD", obj.Cantidad);
            cmd.Parameters.AddWithValue("@TOTAL", obj.Total);
            cmd.ExecuteReader();
            cn.close();
        }

        public void DeleteIngresoRegistros(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_INGRESO_REGISTROS", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID_INGRESO", id);
            cmd.ExecuteReader();
            cn.close();
        }
    }
}
