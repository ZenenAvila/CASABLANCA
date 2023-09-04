using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.dao
{
    class ComprasDiaDao
    {
        connectionBDD cn = new connectionBDD();

        public DataTable GetComprasDia()
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_COMPRA_DIA", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }

        public void InsertComprasDia(string noFactura, int idProducto, int idProveedor,  decimal subTotal, decimal IVA, decimal Total)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_COMPRA_DIA", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NO_FACTURA_REMISION", noFactura);
            cmd.Parameters.AddWithValue("@ID_PRODUCTO", idProducto);
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            cmd.Parameters.AddWithValue("@SUBTOTAL", subTotal);
            cmd.Parameters.AddWithValue("@IVA", IVA);
            cmd.Parameters.AddWithValue("@TOTAL", Total);
            cmd.ExecuteReader();
            cn.close();
        }

        public void updateComprasDia(int id, string noFactura, int idProducto, int idProveedor, decimal subTotal, decimal IVA, decimal Total)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_UPDATE_COMPRA_DIA", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@NO_FACTURA_REMISION", noFactura);
            cmd.Parameters.AddWithValue("@ID_PRODUCTO", idProducto);
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            cmd.Parameters.AddWithValue("@SUBTOTAL", subTotal);
            cmd.Parameters.AddWithValue("@IVA", IVA);
            cmd.Parameters.AddWithValue("@TOTAL", Total);
            cmd.ExecuteReader();
            cn.close();
        }

        public void deleteComprasDia(int id)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_COMPRA_DIA", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.ExecuteReader();
            cn.close();
        }

        public DataTable GetRegistrosComprasDia(string noFactura)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_GET_REGISTRO_COMPRA_DIA", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NO_FACTURA_REMISION", noFactura);
            SqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);
            cn.close();
            return dt;
        }


        public void InsertRegistroComprasDia(string noFactura, int idCatProdServ,int idProveedor, 
            int idProdServ, string noParte,string marca, decimal precioUnitario, decimal IVA, 
            decimal descuento, decimal descuentoPorcentaje, decimal subtotal, int cantidad, 
            decimal total)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_INSERT_REGISTRO_COMPRA_DIA", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NO_FACTURA_REMISION", noFactura);
            cmd.Parameters.AddWithValue("@ID_CAT_PROD_SERV", idCatProdServ);
            cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
            cmd.Parameters.AddWithValue("@ID_PROD_SERV", idProdServ);
            cmd.Parameters.AddWithValue("@NO_PARTE", noParte);
            cmd.Parameters.AddWithValue("@MARCA", marca);
            cmd.Parameters.AddWithValue("@PRECIO_UNITARIO", precioUnitario);
            cmd.Parameters.AddWithValue("@IVA", IVA);
            cmd.Parameters.AddWithValue("@DESCUETO", descuento);
            cmd.Parameters.AddWithValue("@DESCUENTO_PORCENTAJE", descuentoPorcentaje);
            cmd.Parameters.AddWithValue("@SUBTOTAL", subtotal);
            cmd.Parameters.AddWithValue("@CANTIDAD", cantidad);
            cmd.Parameters.AddWithValue("@TOTAL", total);
            cmd.ExecuteReader();
            cn.close();
        }

        public void deleteRegistrComprasDia(string idnoFacRem)
        {
            cn.open();
            SqlCommand cmd = new SqlCommand("SP_DELETE_REGISTRO_COMPRA_DIA", cn._connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NO_FACTURA_REMISION", idnoFacRem);
            cmd.ExecuteReader();
            cn.close();
        }

    }
}
