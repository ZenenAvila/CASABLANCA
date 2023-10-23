using CASABLANCA.app.cls;
using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    class IngresoBus:IIngreso
    {
        IngresoDao dao = new IngresoDao();
        ProductosProveedoresDao BalatasDao = new ProductosProveedoresDao();

        public DataTable GetIngreso(int id)
        {
            return dao.GetIngreso(id);
        }

        public DataTable GetIngresosCliente(int id)
        {
            return dao.GetIngresosCliente(id);
        }

        public DataTable InsertIngreso(IngresoCls obj)
        {
            return dao.InsertIngreso(obj);
        }

        public void UpdateIngreso(IngresoCls obj)
        {
            dao.UpdateIngreso(obj);
        }

        public void DeleteIngreso(int id)
        {
            dao.DeleteIngreso(id);
        }

        public DataTable GetIngresoRegistros(int id)
        {
            return dao.GetIngresoRegistros(id);
        }

        public void InsertIngresoRegistros(IngresoRegistrosCls obj)
        {
            dao.InsertIngresoRegistros(obj);
        }

        public void DeleteIngresoRegistros(int id)
        {
            dao.DeleteIngresoRegistros(id);
        }

        public DataTable GetIngresoChecklist(int id)
        {
            return dao.GetIngresoChecklist(id);
        }

        public void InsertIngresoChecklist(IngresoCheckListeCls obj)
        {
            dao.InsertIngresoChecklist(obj);
        }

        public void DeleteIngresoChecklist(int id)
        {
            dao.DeleteIngresoChecklist(id);
        }

        public void updateExistencia(int nuevo, int idProceso, string proceso,
            string tabla, int idProducto, string noParte,
             int idProveedor, string marca, decimal precioUni, int cantidad)
        {
            BalatasDao.updateExistencia(nuevo,idProceso,proceso,tabla.ToUpper(), 
                idProducto, noParte, idProveedor, marca, precioUni, cantidad);
        }
    }
}
