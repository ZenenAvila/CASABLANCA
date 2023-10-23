using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.cls
{
    public class IngresoCls
    {
        int id;
        bool llavesDado;
        string fecha;
        int userAtiende;
        int idCliente;
        int idAuto;
        string fallas;
        string diagnostico;
        decimal descuento;
        decimal subtotal;
        decimal iva;
        decimal total;

        public int Id { get => id; set => id = value; }
        public bool LlavesDado { get => llavesDado; set => llavesDado = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int UserAtiende { get => userAtiende; set => userAtiende = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdAuto { get => idAuto; set => idAuto = value; }
        public string Fallas { get => fallas; set => fallas = value; }
        public string Diagnostico { get => diagnostico; set => diagnostico = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public decimal Iva { get => iva; set => iva = value; }
        public decimal Total { get => total; set => total = value; }
    }

    public class IngresoRegistrosCls
    {
        int id;
        int idIngreso;
        int idCatProdServ;
        int idProveedor;
        int idProdServ;
        string noParte;
        string marca;
        decimal precioUnitario;
        decimal iva;
        decimal descuento;
        decimal descuentoPorcentaje;
        decimal subtotal;
        int cantidad;
        decimal total;

        public int Id { get => id; set => id = value; }
        public int IdIngreso { get => idIngreso; set => idIngreso = value; }
        public int IdProdServ { get => idProdServ; set => idProdServ = value; }
        public string NoParte { get => noParte; set => noParte = value; }
        public string Marca { get => marca; set => marca = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public decimal Iva { get => iva; set => iva = value; }
        public decimal Descuento { get => descuento; set => descuento = value; }
        public decimal DescuentoPorcentaje { get => descuentoPorcentaje; set => descuentoPorcentaje = value; }
        public decimal Subtotal { get => subtotal; set => subtotal = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Total { get => total; set => total = value; }
        public int IdCatProdServ { get => idCatProdServ; set => idCatProdServ = value; }
        public int IdProveedor { get => idProveedor; set => idProveedor = value; }
    }

    public class IngresoCheckListeCls
    { 
        int id;
        int idIngreso;
        string tabla;
        int idChecklist;
        string noParte;
        string catProdServ;
        string proveedor;
        string productoServicio;
        decimal precioUnitario;
        int cantidad;
        decimal total;
        bool requerido;
        bool autorizado;

        public int Id { get => id; set => id = value; }
        public int IdIngreso { get => idIngreso; set => idIngreso = value; }
        public string Tabla { get => tabla; set => tabla = value; }
        public int IdChecklist { get => idChecklist; set => idChecklist = value; }
        public string NoParte { get => noParte; set => noParte = value; }
        public string CatProdServ { get => catProdServ; set => catProdServ = value; }
        public string Proveedor { get => proveedor; set => proveedor = value; }
        public string ProductoServicio { get => productoServicio; set => productoServicio = value; }
        public decimal PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public decimal Total { get => total; set => total = value; }
        public bool Requerido { get => requerido; set => requerido = value; }
        public bool Autorizado { get => autorizado; set => autorizado = value; }
    }
}
