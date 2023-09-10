using CASABLANCA.app.business;
using CASABLANCA.app.client.Catalogos;
using CASABLANCA.app.client.Genericos;
using CASABLANCA.app.cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASABLANCA.app.client.Ingreso
{
    public partial class frmIngreso : Form
    {
        IngresoBus business = new IngresoBus();
        ClientesBus ClientesBus = new ClientesBus();
        AutosBus AutosBus = new AutosBus();
        ProductosProveedoresBus ProductosProveedoresBus = new ProductosProveedoresBus();

        DataTable dtProductos;
        DataTable dtproveedores;

        DataTable dtRegistrosIngresos;

        bool banInsertar = true;

        private mainWindows mainWindows;
        public frmIngreso(mainWindows form)
        {
            InitializeComponent();
            mainWindows = form;
        }
        public frmIngreso(mainWindows form, int id)
        {
            InitializeComponent();
            mainWindows = form;
        }
        public frmIngreso()
        {
            InitializeComponent();
        }

        private void frmIngreso_Load(object sender, EventArgs e)
        {
            try
            {
                txtDescuento.Text = "0.00";
                cargarClientes();
                cargarServicios();
                cargarProveedores();
                cargarProductos();
                inicio = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar Formulario Ingreso: " + ex.ToString());
            }
        }

        public void cargarClientes()
        {
            try
            {
                DataTable DT = ClientesBus.GetClientesCombo();
                //idCliente = Convert.ToInt32(DT.Rows[0][0].ToString());
                cbxCliente.DataSource = DT;
                cbxCliente.ValueMember = "ID";
                cbxCliente.DisplayMember = "NOMBRE";
                cargarAutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Clientes: " + ex.ToString());
            }
        }

        public void cargarAutos()
        {
            try
            {
                if (cbxCliente.SelectedValue.ToString().Length<=5)
                {
                    //idCliente = Convert.ToInt32(cbxCliente.SelectedValue);
                    cbxAutos.DataSource = null;
                    cbxAutos.Items.Clear();
                    cbxAutos.DataSource = AutosBus.GetAutos(Convert.ToInt32(cbxCliente.SelectedValue));
                    cbxAutos.ValueMember = "ID";
                    cbxAutos.DisplayMember = "PLACA";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Autos: " + ex.ToString());
            }
        }

        private void cargarServicios(int i = -1)
        {
            try
            { 
            dtProductos = ProductosProveedoresBus.GetCatPS();
            cbxServicios.DataSource = dtProductos;
            cbxServicios.ValueMember = "ID";
            cbxServicios.DisplayMember = "NOMBRE";
            cbxServicios.Refresh();

            if (i != -1)
            {
                cbxServicios.SelectedValue = i;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Servicios: " + ex.ToString());
            }

        }

        public void cargarProveedores(int i = -1)
        {
            try
            { 
            dtproveedores = ProductosProveedoresBus.GetProveedores();
            cbxProveedores.DataSource = dtproveedores;
            cbxProveedores.ValueMember = "ID";
            cbxProveedores.DisplayMember = "NOMBRE";
            cbxProveedores.Refresh();
            if (i != -1)
            {
                cbxProveedores.SelectedValue = i;
            }
            else
            {
                    //cbxProveedor.SelectedIndex = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Proveedores: " + ex.ToString());
            }
        }

        DataTable dtProdServ;
        public void cargarProductos()
        { 
            try
            { 
            dtProdServ = new DataTable();
            switch (cbxServicios.Text)
            {
                case "Clutch":
                    dtProdServ = ProductosProveedoresBus.GetClutch(Convert.ToInt32(cbxProveedores.SelectedValue.ToString()));
                    break;
                case "Balatas":
                    dtProdServ = ProductosProveedoresBus.GetBalatas(Convert.ToInt32(cbxProveedores.SelectedValue.ToString()));
                    break;
            }
            cbxProductos.Text = "";
            cbxProductos.Items.Clear();
            foreach (DataRow row in dtProdServ.Rows)
            {
                switch (cbxServicios.Text)
                {
                    case "Clutch":
                        if (String.IsNullOrEmpty(cbxProductos.Text))
                        {
                            cbxProductos.Text = "Num. Parte: " + row["NUMERO_PARTE"] + ", Precio: " + row["PRECIO_PUBLICO"] + ", Producto: " + row["PRODUCTO"];
                        }
                        cbxProductos.Items.Add("Num. Parte: " + row["NUMERO_PARTE"] + ", Precio: " + row["PRECIO_PUBLICO"] + ", Producto: " + row["PRODUCTO"]);

                        break;
                    case "Balatas":
                        if (String.IsNullOrEmpty(cbxProductos.Text))
                        {
                            cbxProductos.Text = "Num. Parte: " + row["NUMERO_PARTE"] + ", Marca: " + row["MARCA"] + ", Posición: " + row["POSICION"] + ", Precio: " + row["PRECIO_PUBLICO"];
                        }
                        cbxProductos.Items.Add("Num. Parte: " + row["NUMERO_PARTE"] + ", Marca: " + row["MARCA"] + ", Posición: " + row["POSICION"] + ", Precio: " + row["PRECIO_PUBLICO"]);
                        break;
                }
            }
            cbxProductos.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Productos: " + ex.ToString());
            }
        }

        private void pbxNuevoCliente_Click(object sender, EventArgs e)
        {
            frmClientes cliente = new frmClientes(mainWindows, this);
            mainWindows.abrirForm(cliente, Global.Ventana._2_4);
        }
        private void pbxNuevoAuto_Click(object sender, EventArgs e)
        {
            if (cbxCliente.Text != null)
            {
                //idCliente = Convert.ToInt32(cbxCliente.SelectedValue);
                //frmAutos autos = new frmAutos(idCliente);
                frmAutos autos = new frmAutos(this);
                mainWindows.abrirForm(autos, Global.Ventana._2_4);
            }
        }

        private void cbxCliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //idCliente = Convert.ToInt32(cbxCliente.SelectedValue);
                cargarAutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Productos: " + ex.ToString());
            }
        }

        private void pbxServicios_Click(object sender, EventArgs e)
        {
            frmProductosProveedores formProvServ = new frmProductosProveedores();
            mainWindows.abrirForm(formProvServ, Global.Ventana._3_2);
            //formProvServ.definirHijo(this);

        }
        bool inicio = true;

        private void cbxProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!inicio)
            {
                cargarProductos();

            }
        }

        private void cbxServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!inicio)
            {
                cargarProductos();

            }
        }

        private void cbxServicios_RightToLeftChanged(object sender, EventArgs e)
        {

        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pbxProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores formProv = new frmProveedores(this);
            mainWindows.abrirForm(formProv, Global.Ventana._2_4);

        }

        private void pbxProductos_Click(object sender, EventArgs e)
        {
            frmProductosProveedores formProvServ = new frmProductosProveedores(this);
            mainWindows.abrirForm(formProvServ, Global.Ventana._3_3);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(cbxProductos.Text))
            {
                string numParte = cbxProductos.Text.Substring(12, cbxProductos.Text.IndexOf(',') - 12);
                string proveedor = cbxProveedores.Text;
                //DataRow[] found= dtProdServ.Select("NUMERO_PARTE = '" + numParte + "'");
                //if(found.Count() != 0)
                //{


                bool banExist = false;
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    if (numParte == fila.Cells["noParte"].Value.ToString() & 
                        proveedor== fila.Cells["proveedor"].Value.ToString())
                    {
                        banExist = true;
                    }
                }
                if (!banExist)
                {
                    //dgvProductos.Rows.Add(numParte);

                    foreach (DataRow fila in dtProdServ.Rows)
                    {
                        if (fila["NUMERO_PARTE"].ToString() == numParte)
                        {
                            string id = fila["id"].ToString();
                            string marca = fila[4].ToString();
                            decimal pUnitario = Convert.ToDecimal(fila["PRECIO_PUBLICO"]),
                                iva = Math.Round((pUnitario) * Convert.ToDecimal(0.16),
                                2, MidpointRounding.ToEven);

                            dgvProductos.Rows.Add(cbxServicios.SelectedValue,cbxServicios.Text,id, numParte, cbxProveedores.SelectedValue.ToString(), cbxProveedores.Text,
                                marca, pUnitario, iva, "0.00", "0.00 %", pUnitario, 1, pUnitario);
                            //calculoGeneral();
                            //lblRegistros.Text = "Total de Registros: " + dgvProductos.RowCount.ToString();

                            break;
                        }
                    }
                    calculoGeneral();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardar.Text = "Actualizar";

            IngresoCls obj = new IngresoCls();
            obj.LlavesDado = chkLlavesDado.Checked;
            obj.Fecha = DateTime.Now.ToString("dd MMMM yyyy HH:mm:ss", CultureInfo.GetCultureInfo("es-ES"));
            obj.UserAtiende = Convert.ToInt32(cbxCliente.SelectedValue);
            obj.IdCliente = Convert.ToInt32(cbxCliente.SelectedValue);
            obj.IdAuto = Convert.ToInt32(cbxAutos.SelectedValue);
            obj.Fallas = txtFallas.Text;
            obj.Diagnostico = txtDiagnostico.Text;
            obj.Descuento = Convert.ToDecimal(txtDescuento.Text);
            obj.Subtotal = Convert.ToDecimal(txtSubtotal.Text);
            obj.Iva = Convert.ToDecimal(txtIva.Text);
            obj.Total = Convert.ToDecimal(txtTotal.Text);

            if (string.IsNullOrEmpty(txtId.Text))
            {
                txtId.Text = business.InsertIngreso(obj).Rows[0][0].ToString();
                //MessageBox.Show(, "Ingreso Guardado Correctamente.",MessageBoxIcon., MessageBoxButtons.OK);
            }
            else
            {
                obj.Id = Convert.ToInt32(txtId.Text);
                business.UpdateIngreso(obj);
            }

            //Registros
            business.DeleteIngresoRegistros(Convert.ToInt32(txtId.Text));
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                IngresoRegistrosCls objRegistros = new IngresoRegistrosCls();
                objRegistros.IdIngreso = Convert.ToInt32(txtId.Text);
                objRegistros.IdCatProdServ = Convert.ToInt32(row.Cells["idProdServ"].Value.ToString());
                objRegistros.IdProveedor = Convert.ToInt32(row.Cells["idProveedor"].Value.ToString());
                objRegistros.IdProdServ = Convert.ToInt32(row.Cells["idProdServ"].Value.ToString());
                objRegistros.NoParte = row.Cells["noParte"].Value.ToString();
                objRegistros.Marca = row.Cells["marca"].Value.ToString();
                objRegistros.PrecioUnitario = Convert.ToDecimal(row.Cells["precioUni"].Value.ToString());
                objRegistros.Iva = Convert.ToDecimal(row.Cells["iva"].Value.ToString());
                objRegistros.Descuento = Convert.ToDecimal(row.Cells["descuento"].Value.ToString());
                objRegistros.DescuentoPorcentaje = Convert.ToDecimal(row.Cells["descuentoPor"].Value.ToString().Replace(" %", ""));
                objRegistros.Subtotal = Convert.ToDecimal(row.Cells["subTotal"].Value.ToString());
                objRegistros.Cantidad = Convert.ToInt32(row.Cells["cantidad"].Value.ToString());
                objRegistros.Total = Convert.ToDecimal(row.Cells["total"].Value.ToString());

                business.InsertIngresoRegistros(objRegistros);
            }
            actualizarExistencias();
        }

        public void actualizarExistencias()
        {
            if (dtRegistrosIngresos == null)
            {
                foreach (DataGridViewRow rows in dgvProductos.Rows)
                {
                    DataRow[] producto = dtProductos.Select("ID = " + Convert.ToInt32(rows.Cells["IdProdServ"].Value));
                    business.updateExistencia(0,
                        producto[0]["Nombre"].ToString(),
                        Convert.ToInt32(rows.Cells["IdProducto"].Value),
                        rows.Cells["noParte"].Value.ToString(),
                        Convert.ToInt32(rows.Cells["idProveedor"].Value),
                        rows.Cells["marca"].Value.ToString(),
                        Convert.ToDecimal(rows.Cells["precioUni"].Value),
                        Convert.ToInt32(rows.Cells["cantidad"].Value) * -1
                        );
                }
            }
            else
            {
                if (dtRegistrosIngresos.Rows.Count > 0)
                {
                    foreach (DataGridViewRow rows in dgvProductos.Rows)
                    {
                        var registro = dtRegistrosIngresos.Select("NO_PARTE = '" + rows.Cells["noParte"].Value + "'").FirstOrDefault();

                        int existenciaIni = 0, existenciaAct = 0, existencia = 0;
                        if (registro != null)
                        {
                            existenciaIni = Convert.ToInt32(registro["CANTIDAD"].ToString());
                            dtRegistrosIngresos.Rows.Remove(registro);
                        }
                        existenciaAct = Convert.ToInt32(rows.Cells["cantidad"].Value);

                        existencia = existenciaAct - existenciaIni;

                        if (existencia != 0)
                        {
                            //existencia = existencia * -1;//ACTUALIZAR EXISTENCIA

                            DataRow[] producto = dtProductos.Select("ID = " + Convert.ToInt32(rows.Cells["IdProdServ"].Value));
                            business.updateExistencia(1,
                                producto[0]["Nombre"].ToString(),
                                        Convert.ToInt32(rows.Cells["IdProducto"].Value),
                                rows.Cells["noParte"].Value.ToString(),
                                Convert.ToInt32(rows.Cells["idProveedor"].Value),
                                rows.Cells["marca"].Value.ToString(),
                                Convert.ToDecimal(rows.Cells["precioUni"].Value),
                                existencia * -1
                                );
                        }
                    }

                    if (dtRegistrosIngresos.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtRegistrosIngresos.Rows)
                        {
                            DataRow[] producto = dtProductos.Select("ID = " + Convert.ToInt32(row["ID_CAT_PROD_SERV"]));
                            business.updateExistencia(0,producto[0]["Nombre"].ToString(),
                                        Convert.ToInt32(row["ID_PROD_SERV"].ToString()),
                                row["NO_PARTE"].ToString(),
                                1,//CAMIAR POR EL ID PROVEEDOR CORRECTO, SE DEBE GUARDAR EN A TABLA DE INGRESO Y LA DE COMPRAS
                                row["MARCA"].ToString(),
                                Convert.ToDecimal(row["PRECIO_UNITARIO"].ToString()),
                                Convert.ToInt32(row["CANTIDAD"].ToString())
                                );
                        }
                    }
                }
                else
                {
                    foreach (DataRow row in dtRegistrosIngresos.Rows)
                    {
                        var a = Convert.ToInt32(row["CANTIDAD"].ToString()) * -1;//ACTUALIZAR EXISTENCIA
                                                                                 //business.updateExistencia()
                    }
                }
            }
            dtRegistrosIngresos = business.GetIngresoRegistros(Convert.ToInt32(txtId.Text));
        }

        private void pbxEncabezados_Click(object sender, EventArgs e)
        {
            cbxCliente.Enabled = false;
            frmIngresoEncabezado frm = new frmIngresoEncabezado(Convert.ToInt32(cbxCliente.SelectedValue), this);
            mainWindows.abrirForm(frm, Global.Ventana._2_2);
        }

        private void limpiarControles()
        {
            chkLlavesDado.Checked = false;
            txtAtiende.Clear();
            txtDescuento.Clear();
            txtFallas.Clear();
            txtDiagnostico.Clear();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
        }

        public void cargarIngreso(string id)
        {
            txtId.Text = id;
            limpiarControles();
            DataTable dtIngreso = business.GetIngreso(Convert.ToInt32(txtId.Text));
            DataRow row = dtIngreso.Rows[0];

            //Limpiar controles antes de mostrar la información

            chkLlavesDado.Checked = Convert.ToBoolean(row["LLAVES"]);
            //lblFechaHora.Text = row[2].ToString();
            txtAtiende.Text = row["ATIENDE"].ToString();
            foreach (var elemento in cbxAutos.Items)
            {
                string value = ((System.Data.DataRowView)elemento).Row[cbxAutos.ValueMember].ToString();
                if (value == row["ID_AUTO"].ToString())
                {
                    cbxAutos.SelectedItem = elemento;
                }
            }

            txtDescuento.Text = row["DESCUENTO"].ToString();
            txtFallas.Text = row["FALLAS"].ToString();
            txtDiagnostico.Text = row["DIAGNOSTICO"].ToString();
            txtSubtotal.Text = row["SUBTOTAL"].ToString();
            txtIva.Text = row["IVA"].ToString();
            txtTotal.Text = row["TOTAL"].ToString();
            //terminar de poner los controles asociados y realizar la busquedas de los elementos para cada combo

            banInsertar = false;
            cbxCliente.Enabled = true;

            btnGuardar.Text = "Actualizar";

            dtRegistrosIngresos = business.GetIngresoRegistros(Convert.ToInt32(txtId.Text));
            dgvProductos.Rows.Clear();
            //dgvProductos.DataSource = null;

            foreach (DataRow rowRegistros in dtRegistrosIngresos.Rows)
            {
                DataRow[] producto = dtProductos.Select("ID = " + rowRegistros["ID_CAT_PROD_SERV"]);

                DataRow[] proveedor = dtproveedores.Select("ID = " + rowRegistros["ID_PROVEEDOR"]);

                //string a = rowRegistros[1];
                dgvProductos.Rows.Add(
                    producto[0]["ID"],
                    producto[0]["NOMBRE"],
                    rowRegistros["ID_PROD_SERV"],
                    rowRegistros["NO_PARTE"],
                    proveedor[0]["ID"],
                    proveedor[0]["NOMBRE"],
                    rowRegistros["MARCA"],
                    rowRegistros["PRECIO_UNITARIO"],
                    rowRegistros["IVA"],
                    rowRegistros["DESCUETO"],
                    rowRegistros["DESCUENTO_PORCENTAJE"],
                    rowRegistros["SUBTOTAL"],
                    rowRegistros["CANTIDAD"],
                    rowRegistros["TOTAL"]);
            }
        }

        private void dgvProductos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvProductos.CurrentCell != null)
            {
                int idRow = dgvProductos.CurrentCell.RowIndex;
                //IVA
                decimal iva = Convert.ToDecimal(dgvProductos.Rows[idRow].Cells["precioUni"].Value) * Convert.ToDecimal(0.16);
                dgvProductos.Rows[idRow].Cells["iva"].Value = Math.Round(iva, 2, MidpointRounding.ToEven);
                //DESCUENTO
                dgvProductos.Rows[idRow].Cells["descuento"].Value = string.IsNullOrEmpty(dgvProductos.Rows[idRow].Cells["descuento"].Value.ToString()) ?
                    "0.00" : Math.Round(Convert.ToDecimal(dgvProductos.Rows[idRow].Cells["descuento"].Value), 2, MidpointRounding.ToEven).ToString();
                //SUBTOTAL
                dgvProductos.Rows[idRow].Cells["subtotal"].Value = Math.Round((Convert.ToDecimal(dgvProductos.Rows[idRow].Cells["precioUni"].Value) -
                    Convert.ToDecimal(dgvProductos.Rows[idRow].Cells["descuento"].Value)), 2, MidpointRounding.ToEven);
                //DESCUENTO PORCENTAJE
                dgvProductos.Rows[idRow].Cells["descuentoPor"].Value = ((Convert.ToDecimal(dgvProductos.Rows[idRow].Cells["descuento"].Value) * 100) /
                    Convert.ToDecimal(dgvProductos.Rows[idRow].Cells["precioUni"].Value)).ToString() + " %";
                //CANTIDAD
                dgvProductos.Rows[idRow].Cells["cantidad"].Value = string.IsNullOrEmpty(dgvProductos.Rows[idRow].Cells["cantidad"].Value.ToString()) ||
                    Convert.ToInt32(dgvProductos.Rows[idRow].Cells["cantidad"].Value) < 1 ?
                    1 : Math.Round(Convert.ToDecimal(dgvProductos.Rows[idRow].Cells["cantidad"].Value), 0, MidpointRounding.ToEven);
                //TOTAL
                decimal total =
                    (Convert.ToDecimal(dgvProductos.Rows[idRow].Cells["subtotal"].Value)
                    * Convert.ToDecimal(dgvProductos.Rows[idRow].Cells["cantidad"].Value));
                dgvProductos.Rows[idRow].Cells["total"].Value =
                    Math.Round(total, 2, MidpointRounding.ToEven);

                calculoGeneral();
            }
        }

        private void calculoGeneral()
        {
            decimal totalGeneral = 0, ivaGeneral = 0;
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                totalGeneral += Convert.ToDecimal(row.Cells["total"].Value);
            }

            ivaGeneral = (totalGeneral * Convert.ToDecimal(0.16));
            txtSubtotal.Text = Math.Round(totalGeneral - ivaGeneral, 2, MidpointRounding.ToEven).ToString();
            txtIva.Text = Math.Round(ivaGeneral, 2, MidpointRounding.ToEven).ToString();
            txtTotal.Text = Math.Round(totalGeneral, 2, MidpointRounding.ToEven).ToString();
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columna = dgvProductos.Columns[e.ColumnIndex].Name;
            if (columna == "eliminar")
            {
                int row = dgvProductos.CurrentCell.RowIndex;
                dgvProductos.Rows.Remove(dgvProductos.Rows[row]);
                calculoGeneral();
            }
        }

        #region Traer Al Frente
        private void frmIngreso_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
        }
        #endregion

    }
}
