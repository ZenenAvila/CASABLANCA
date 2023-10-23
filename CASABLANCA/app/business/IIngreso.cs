using CASABLANCA.app.cls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    public interface IIngreso
    {
        DataTable GetIngreso(int id);
        DataTable GetIngresosCliente(int id);
        DataTable InsertIngreso(IngresoCls obj);
        void UpdateIngreso(IngresoCls obj);
        void DeleteIngreso(int id);
        DataTable GetIngresoRegistros(int idIngreso);
        void InsertIngresoRegistros(IngresoRegistrosCls obj);
        void DeleteIngresoRegistros(int id);
        DataTable GetIngresoChecklist(int idIngreso);
        void DeleteIngresoChecklist(int id);

        
    }
}
