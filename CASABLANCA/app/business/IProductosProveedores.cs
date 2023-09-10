using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    interface IProductosProveedores
    {
        //Complementos
        DataTable GetCatPS();
        DataTable GetProveedores();
        void ValidServProdProv(int idProveedor, int idProductoServicio);

        //Clutch
        DataTable GetClutch(int idProveedor);
        void InsertClutch(string aplicacion, int idProveedor, string numParte, 
            string prodcuto, string eqvLuk, string eqvSachs, string eqv3L, string eqvExedy,
            string eqvValeo, string eqvAisin, decimal precioCompra, decimal precioPublico);
        void UpdateClutch(int id, string aplicacion, int idProveedor, string numParte, 
            string prodcuto, string eqvLuk, string eqvSachs, string eqv3L, string eqvExedy,
            string eqvValeo, string eqvAisin, decimal precioCompra, decimal precioPublico);
        void DeleteClutch(int id);

        //Balatas
        DataTable GetBalatas(int idProveedor);
        void InsertBalata(int idProveedor, string numParte, string marca, string posicion,
            bool abutment, string aplicacion, string modelo, string formula, decimal precioPublico,
            string observaciones, int existencia);
        void UpdateBalatas(int id, int idProveedor, string numParte, string marca, string posicion,
            bool abutment, string aplicacion, string modelo, string formula, decimal precioPublico,
            string observaciones);
        void DeleteBalatas(int id);
        void updateExistencia(int nuevo,string tabla, int id, string noParte,
            int idProv, string marca, decimal precioUni, int cantidad);
    }
}
