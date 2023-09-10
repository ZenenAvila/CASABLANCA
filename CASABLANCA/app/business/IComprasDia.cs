using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    interface IComprasDia
    {
        DataTable GetProductos();
        DataTable GetProveedorById(int id);
        DataTable GetBalatas(int idProveedor);
        DataTable GetClutch(int idProveedor);

        DataTable GetComprasDia();
        void InsertComprasDia(string noFactura, int idProducto, int idProveedor, decimal subTotal, decimal IVA, decimal Total);
        void updateComprasDia(int id, string noFactura, int idProducto, int idProveedor, decimal subTotal, decimal IVA, decimal Total);
        void deleteComprasDia(int id);

        DataTable GetRegistrosComprasDia(string noFactura);
        void InsertRegistroComprasDia(string noFactura,int idCatProdServ, int idProveedor, int idProdServ, string noParte, string marca,
            decimal precioUnitario, decimal IVA, decimal descuento, decimal descuentoPorcentaje,
            decimal subtotal, int cantidad, decimal total);
        void deleteRegistrComprasDia(string idnoFacRem);

        void updateExistencia(int nuevo, string producto, int id, string noParte, int idProv,
            string marca, decimal precioUni, int cantidad);

    }

}
