﻿using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    class ProductosProveedoresBus : IProductosProveedores
    {
        ServiciosProductosDao daoPS = new ServiciosProductosDao();
        ProductosProveedoresDao dao = new ProductosProveedoresDao();
        ProveedoresDao daoProveedores = new ProveedoresDao();
        UniProveedoresServiciosProductos daoUniPSP=new UniProveedoresServiciosProductos();
        CatProductosServiciosDao daoCatProdServ = new CatProductosServiciosDao();

        public DataTable GetProductoServicio(int idProveedor)
        {
            return daoPS.Get(idProveedor);
        }
        public DataTable InsertProductoServicio(string producto, bool esServicio, string numeroParte,
            string descripcion, int idProveedor, decimal precioCompra, decimal precioUnitario)
        {
            return daoPS.Insert(producto, esServicio, numeroParte,
            descripcion, idProveedor, precioCompra, precioUnitario);
        }
        public DataTable UpdateProductoServicio(int id, string producto, bool esServicio, string numeroParte,
            string descripcion, int idProveedor, decimal precioCompra, decimal precioUnitario)
        {
            return daoPS.Update(id, producto, esServicio, numeroParte,
            descripcion, idProveedor, precioCompra, precioUnitario);
        }
        public DataTable DeleteProductoServicio(int id)
        {
            return daoPS.Delete(id);
        }

        public DataTable GetCatPS()
        {
            return daoCatProdServ.GetCatPS();
        }

        public DataTable GetProveedores()
        {
            return daoProveedores.Get();
        }

        public void ValidServProdProv(int idProveedor, int idProductoServicio)
        {
            daoUniPSP.ValidServProdProv(idProveedor,idProductoServicio);
        }

        //Clutch
        public DataTable GetClutch(int idProveedor)
        {
            return dao.GetClutch(idProveedor);
        }

        public void InsertClutch(string aplicacion, int idProveedor, string numParte,
            string prodcuto, string eqvLuk, string eqvSachs, string eqv3L, string eqvExedy,
            string eqvValeo, string eqvAisin, decimal precioCompra, decimal precioPublico)
        {
            dao.InsertClutch(aplicacion, idProveedor, numParte,
            prodcuto, eqvLuk, eqvSachs, eqv3L, eqvExedy, eqvValeo, 
            eqvAisin, precioCompra, precioPublico);
        }

        public void UpdateClutch(int id, string aplicacion, int idProveedor, string numParte, 
            string prodcuto, string eqvLuk, string eqvSachs, string eqv3L, string eqvExedy,
            string eqvValeo, string eqvAisin, decimal precioCompra, decimal precioPublico)
        {
            dao.UpdateClutch(id, aplicacion, idProveedor, numParte, 
            prodcuto, eqvLuk, eqvSachs, eqv3L, eqvExedy,
            eqvValeo, eqvAisin, precioCompra,  precioPublico);
        }

        public void DeleteClutch(int id)
        {
            dao.DeleteClutch(id);
        }

        //Balatas
        public DataTable GetBalatas(int idProveedor)
        {
            return dao.GetBalatas(idProveedor);
        }

        public void InsertBalata(int idProveedor, string numParte, string marca, string posicion,
            bool abutment, string aplicacion, string modelo, string formula, decimal precioPublico,
            string observaciones, int existencia)
        {
            dao.InsertBalatas(idProveedor, numParte, marca, posicion,
            abutment, aplicacion, modelo, formula, precioPublico,
            observaciones, existencia);
        }

        public void UpdateBalatas(int id, int idProveedor, string numParte, string marca, string posicion,
            bool abutment, string aplicacion, string modelo, string formula, decimal precioPublico,
            string observaciones)
        {
            dao.UpdateBalatas(id, idProveedor, numParte, marca, posicion,
               abutment, aplicacion, modelo, formula, precioPublico,
               observaciones);
        }

        public void DeleteBalatas(int id)
        {
            dao.DeleteBalatas(id);
        }

        public void updateExistencia(int nuevo, int idProceso, string proceso,
            string tabla, int idProducto, string noParte,
             int idProveedor, string marca, decimal precioUni, int cantidad)
        {
            dao.updateExistencia(nuevo,idProceso,proceso,tabla, idProducto, 
                noParte, idProveedor , marca, precioUni, cantidad);
        }
    }
}
