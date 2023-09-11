using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    class ComprasDiaBus:IComprasDia
    {
        CatProductosServiciosDao productosDao = new CatProductosServiciosDao();
        UniProveedoresServiciosProductos proveedorDao = new UniProveedoresServiciosProductos();
        ProductosProveedoresDao BalatasDao = new ProductosProveedoresDao();
        ComprasDiaDao ComprasDao = new ComprasDiaDao();

        public DataTable GetProductos()
        {
            return productosDao.GetCatPS();
        }

        public DataTable GetProveedorById(int id)
        {
            return proveedorDao.GetProvByServProd(id);
        }

        public DataTable GetBalatas(int idProveedor)
        {
            return BalatasDao.GetBalatas(idProveedor);
        }

        public DataTable GetClutch(int idProveedor)
        {
            return BalatasDao.GetClutch(idProveedor);
        }

        public DataTable GetComprasDia()
        {
            return ComprasDao.GetComprasDia();
        }

        public string InsertComprasDia( string noFactura, int idProducto, int idProveedor, decimal subTotal, decimal IVA, decimal Total)
        {
            return ComprasDao.InsertComprasDia( noFactura, idProducto, idProveedor, subTotal, IVA, Total);
        }

        public void updateComprasDia(int id, string noFactura, int idProducto, int idProveedor, decimal subTotal, decimal IVA, decimal Total)
        {
            ComprasDao.updateComprasDia(id, noFactura, idProducto, idProveedor, subTotal, IVA, Total);
        }

        public void deleteComprasDia(int id)
        {
            ComprasDao.deleteComprasDia(id);
        }

        public DataTable GetRegistrosComprasDia(string noFactura)
        {
            return ComprasDao.GetRegistrosComprasDia(noFactura);
        }

        public void InsertRegistroComprasDia(string noFactura,int idCatProdServ, int idProveedor, int idProdServ, string noParte, string marca,
            decimal precioUnitario, decimal IVA, decimal descuento, decimal descuentoPorcentaje,
            decimal subtotal, int cantidad, decimal total)
        {
            ComprasDao.InsertRegistroComprasDia(noFactura,idCatProdServ,idProveedor, idProdServ, noParte, marca,
            precioUnitario, IVA, descuento, descuentoPorcentaje,
            subtotal, cantidad, total);
        }

        public void deleteRegistrComprasDia(string idnoFacRem)
        {
            ComprasDao.deleteRegistrComprasDia(idnoFacRem);
        }

        public void updateExistencia(int nuevo, int idProceso, string proceso,
            string tabla, int idProducto, string noParte,
             int idProveedor, string marca, decimal precioUni, int cantidad)
        {
            BalatasDao.updateExistencia(nuevo, idProceso, proceso, tabla.ToUpper(),
                idProducto, noParte, idProveedor, marca, precioUni, cantidad);
        }
    }
}
