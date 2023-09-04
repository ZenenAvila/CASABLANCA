﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CASABLANCA.app.business
{
    interface IProveedores
    {
        DataTable Get();
        void Insert(string nombre, string rfc, string direccion, string telefono,string correo);
        void Update(int id, string nombre, string rfc, string direccion, string telefono, string correo);
        void Delete(int id);
    }
}
