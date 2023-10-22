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

        bool banInicio = true;

        private mainWindows mainWindows;
        public frmIngreso(mainWindows form)
        {
            InitializeComponent();
            mainWindows = form;
            clutch();
            afinacion();
            suspencion();
            frenos();
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

                ProdServDgv = "Productos y Servicios";
                cargarProductos();
                banInicio = false;

                cargarProductosCheckList();
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
                switch (ProdServDgv)
                {
                    case "Productos y Servicios":
                        dtProdServ = ProductosProveedoresBus.GetProductoServicio(Convert.ToInt32(cbxProveedores.SelectedValue.ToString()));
                        break;
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
                    //switch (cbxServicios.Text)K
                    switch (ProdServDgv)
                    {
                        case "Productos y Servicios":
                            if (String.IsNullOrEmpty(cbxProductos.Text))
                            {
                                cbxProductos.Text = "Num. Parte: " + row["NUMERO_PARTE"] + ", Precio: " + row["PRECIO_PUBLICO"] + ", Producto: " + row["DESCRIPCION"];
                            }
                            cbxProductos.Items.Add("Num. Parte: " + row["NUMERO_PARTE"] + ", Precio: " + row["PRECIO_PUBLICO"] + ", Producto: " + row["DESCRIPCION"]);

                            break;
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
                //if (tablaDgv != "")
                //{
                //    agregarProducto(noProductoDgv);
                //    tablaDgv = "";
                //}
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
        }

        private void cbxProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!banInicio)
            {
                ProdServDgv = cbxServicios.Text;
                cargarProductos();
            }
        }

        private void cbxServicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!banInicio)
            {
                ProdServDgv = cbxServicios.Text;
                cargarProductos();
            }
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
            ProdServDgv = cbxServicios.Text;
            agregarProducto(cbxProductos.Text.Substring(12, cbxProductos.Text.IndexOf(',') - 12));
        }

        private void agregarProducto(string noParte)
        {
            cargarProductos();

            //if (!string.IsNullOrEmpty(cbxProductos.Text))
            {
                string numParte = noParte;
                string proveedor = cbxProveedores.Text;

                bool banExist = false;
                foreach (DataGridViewRow fila in dgvProductos.Rows)
                {
                    if (numParte == fila.Cells["noParte"].Value.ToString() &
                        proveedor == fila.Cells["proveedor"].Value.ToString())
                    {
                        banExist = true;
                    }
                }
                if (!banExist)
                {
                    foreach (DataRow fila in dtProdServ.Rows)
                    {
                        if (fila["NUMERO_PARTE"].ToString() == numParte)
                        {
                            string id = fila["id"].ToString();
                            string marca = fila[4].ToString();
                            decimal pUnitario = Convert.ToDecimal(fila["PRECIO_PUBLICO"]),
                                iva = Math.Round((pUnitario) * Convert.ToDecimal(0.16),
                                2, MidpointRounding.ToEven);

                            dgvProductos.Rows.Add(cbxServicios.SelectedValue, cbxServicios.Text, id, numParte, cbxProveedores.SelectedValue.ToString(), cbxProveedores.Text,
                                marca, pUnitario, iva, "0.00", "0.00 %", pUnitario, 1, pUnitario);

                            break;
                        }
                    }
                    calculoTotalGeneral();
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
                MessageBox.Show("El Ingreso Se Guardó Correctamente.", "Ingreso Guardado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                obj.Id = Convert.ToInt32(txtId.Text);
                business.UpdateIngreso(obj);
                MessageBox.Show("El Ingreso Se Actualizó Correctamente.", "Ingreso Actualizado",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //Registros
            business.DeleteIngresoRegistros(Convert.ToInt32(txtId.Text));
            foreach (DataGridViewRow row in dgvProductos.Rows)
            {
                IngresoRegistrosCls objRegistros = new IngresoRegistrosCls();
                objRegistros.IdIngreso = Convert.ToInt32(txtId.Text);
                objRegistros.IdCatProdServ = Convert.ToInt32(row.Cells["idProdServ"].Value.ToString());
                objRegistros.IdProveedor = Convert.ToInt32(row.Cells["idProveedor"].Value.ToString());
                objRegistros.IdProdServ = Convert.ToInt32(row.Cells["idProducto"].Value.ToString());
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
                    business.updateExistencia(0, Convert.ToInt32(txtId.Text),
                        "INGRESO", producto[0]["Nombre"].ToString(),
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
                        decimal precioIni = 0, precioAct = 0, precio = 0;
                        if (registro != null)
                        {
                            existenciaIni = Convert.ToInt32(registro["CANTIDAD"].ToString());
                            precioIni = Convert.ToDecimal(registro["PRECIO_UNITARIO"].ToString());
                            dtRegistrosIngresos.Rows.Remove(registro);
                        }
                        existenciaAct = Convert.ToInt32(rows.Cells["cantidad"].Value);
                        precioAct = Convert.ToDecimal(rows.Cells["precioUni"].Value);

                        existencia = existenciaAct - existenciaIni;
                        precio = precioAct - precioIni;

                        if (existencia != 0 | precio != 0)
                        {
                            DataRow[] producto = dtProductos.Select("ID = " + Convert.ToInt32(rows.Cells["IdProdServ"].Value));
                            business.updateExistencia(1, Convert.ToInt32(txtId.Text),
                                "INGRESO", producto[0]["Nombre"].ToString(),
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
                            business.updateExistencia(2, Convert.ToInt32(txtId.Text),
                                "INGRESO", producto[0]["Nombre"].ToString(),
                                Convert.ToInt32(row["ID_PROD_SERV"].ToString()),
                                row["NO_PARTE"].ToString(),
                                Convert.ToInt32(row["ID_PROVEEDOR"].ToString()),
                                row["MARCA"].ToString(),
                                Convert.ToDecimal(row["PRECIO_UNITARIO"].ToString()),
                                Convert.ToInt32(row["CANTIDAD"].ToString())
                                );
                        }
                    }
                }
                else
                {
                    foreach (DataGridViewRow rows in dgvProductos.Rows)
                    {
                        DataRow[] producto = dtProductos.Select("ID = " + Convert.ToInt32(rows.Cells["IdProdServ"].Value));
                        business.updateExistencia(0, Convert.ToInt32(txtId.Text),
                            "INGRESO", producto[0]["Nombre"].ToString(),
                            Convert.ToInt32(rows.Cells["IdProducto"].Value),
                            rows.Cells["noParte"].Value.ToString(),
                            Convert.ToInt32(rows.Cells["idProveedor"].Value),
                            rows.Cells["marca"].Value.ToString(),
                            Convert.ToDecimal(rows.Cells["precioUni"].Value),
                            Convert.ToInt32(rows.Cells["cantidad"].Value) * -1
                            );
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

        public void cargarIngreso(string id)
        {
            txtId.Text = id;
            limpiarControles();
            DataTable dtIngreso = business.GetIngreso(Convert.ToInt32(txtId.Text));
            DataRow row = dtIngreso.Rows[0];

            chkLlavesDado.Checked = Convert.ToBoolean(row["LLAVES"]);
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

            cbxCliente.Enabled = true;
            btnGuardar.Text = "Actualizar";

            dtRegistrosIngresos = business.GetIngresoRegistros(Convert.ToInt32(txtId.Text));
            dgvProductos.Rows.Clear();

            foreach (DataRow rowRegistros in dtRegistrosIngresos.Rows)
            {
                DataRow[] producto = dtProductos.Select("ID = " + rowRegistros["ID_CAT_PROD_SERV"]);

                DataRow[] proveedor = dtproveedores.Select("ID = " + rowRegistros["ID_PROVEEDOR"]);

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

                calculoTotalGeneral();
            }
        }

        private void calculoTotalGeneral()
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
                calculoTotalGeneral();
            }
        }

        #region Traer Al Frente
        private void frmIngreso_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
        }
        #endregion

        private void clutch()
        {
            dgvClutch.Rows.Add("", "", "Clutch Nuevo Valeo Kit (3) (2) (4) pzas.", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Volante Nuevo", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Collarín Nuevo", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Rectificado de Volante", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Bomba de Clutch", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Horquilla de Clutch", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Reten de Cigüeñal", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Candelero", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Aceite para Transmisión Standard", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Mano de Obra cambio de Clutch", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "OTROS");
            dgvClutch.Rows.Add("", "", "Banda de Accesorios", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Poleas", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "M.O. Banda de Acceorios", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Revisión Banda de Distribución", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "M.O. Banda de Distribución", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Revisión de banda de aire acondicionado", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "M.O. Banda de Aire Acondicionado", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Revisión de banda de cigüeñal", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "M.O. Banda de Cigüeñal", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Anticongelante Rosa", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "M.O. Banda cambio de Radiador", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Rectificado de Discos Externos", "0.00", "1", "0.00");
            dgvClutch.Rows.Add("", "", "Rectificado de Tambores Externos", "0.00", "1", "0.00");

            foreach (DataGridViewRow row in dgvClutch.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;
            }

            dgvClutch.Rows[10].DefaultCellStyle.Font = new Font(dgvClutch.Font, FontStyle.Bold);
            dgvClutch.Rows[10].DefaultCellStyle.BackColor = Color.FromArgb(147, 190, 30);
            dgvClutch.Rows[10].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 190, 30);
            dgvClutch.Rows[10].ReadOnly = true;
        }

        private void afinacion()
        {
            dgvAfinacion.Rows.Add("", "", "Afinación de Motor");
            dgvAfinacion.Rows.Add("", "", "Filtro de Aire", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Filtro de Gasolina", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Filtro de Aceite", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Bujías Platino", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Bujías Doble Platino", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Aceite Multigrado", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Lavado de Cuerpo de Aceleración", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Lavado de Inyectores con Boya", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Limpiador para Lavado de Inyectores", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Anticongelante", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Frenos Delanteros", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Frenos Traseros", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Suspensión", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Banda de Accesorios", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Banda de Distribución", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Banda de Aire Acondicionado", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Banda de Cigüeñal", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión  de Dirección", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Sistema Eléctrico", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Radiador", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Rellenado de Niveles", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Módulos Electrónicos con Scanner", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Lavado de Carrocería ", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Limpieza de motor", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Limpieza de motor", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "M.O. Afinación Completa", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Media Afinación");
            dgvAfinacion.Rows.Add("", "", "Filtro de aceite", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Aceite Multigrado", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Aceite Sintético", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Lavado de Cuerpo de Aceleración", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Limpiador para Cuerpo de Aceleración", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Lavado de Inyectores con Boya ", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Limpiador para Lavado de Inyectores", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Frenos Delanteros", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Frenos Traseros", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Suspensión", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Acumulador", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Alternador", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión Línea", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "Revisión de Sistema de Carga", "0.00", "1", "0.00");
            dgvAfinacion.Rows.Add("", "", "M.O. Media Afinación", "0.00", "1", "0.00");

            foreach (DataGridViewRow row in dgvAfinacion.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; 
                row.DefaultCellStyle.ForeColor = Color.Black; 
            }

            dgvAfinacion.Rows[0].DefaultCellStyle.Font = new Font(dgvAfinacion.Font, FontStyle.Bold);
            dgvAfinacion.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(147, 190, 30);
            dgvAfinacion.Rows[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 190, 30);
            dgvAfinacion.Rows[0].ReadOnly = true;

            dgvAfinacion.Rows[27].DefaultCellStyle.Font = new Font(dgvAfinacion.Font, FontStyle.Bold);
            dgvAfinacion.Rows[27].DefaultCellStyle.BackColor = Color.FromArgb(147, 190, 30);
            dgvAfinacion.Rows[27].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 190, 30);
            dgvAfinacion.Rows[27].ReadOnly = true;
        }

        private void suspencion()
        {
            dgvSuspencion.Rows.Add("", "", "Suspensión Delantera");
            dgvSuspencion.Rows.Add("", "", "Amortiguadores Delanteros", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O Amortiguadores Delanteros", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Bases de Amortiguador Delanteras", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O Bases de Amortiguadores Delanteros", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Gomas de Tope/Rebote Delanteras", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O Gomas Tope/Rebote Delanteras", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Resortes de Amortiguador Delantero", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O Resortes Amortiguadores Delantero", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Horquilla Completa Superior", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Horquillas Completas Inferior", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Horquilla Completa", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O Gomas Tope/Rebote Delanteras", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Bujes de Horquilla Superior Grande", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Bujes de Horquilla Superior Chico", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Bujes de Horquilla Superior Grande", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Bujes de Horquilla Superior Chica", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Bujes de Horquilla Inferior Grande", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Bujes de Horquilla Inferior Chica", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Bujes de Horquilla Inferior Grande", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Bujes de Horquilla Inferior Chica", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Buje de Horquilla Flotante", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Bujes de Horquilla Flotante", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Tornillo Estabilizador Delantero", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Tornillo Estabilizador Delantero", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Vieleta Delantera", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Terminal de Dirección Delantera", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Vieleta y Terminal", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Rótula Superior Delantera", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Rótulas Superior Delantera", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "DelanteraRótula Inferior", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Rótulas Inferior", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Brazo Auxiliar Pitman Delantera", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Brazo Pitman Delantera", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Barra Estabilizadora Delantera", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Gomas de Barra Estabilizadora Delantera", "0.00", "1", "0.00");

            dgvSuspencion.Rows.Add("", "", "Suspensión Trasera Independiente");
            dgvSuspencion.Rows.Add("", "", "Amortiguadores Traseros Independiente", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O Amortiguadores Traseros", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Brazo Suspensión Superior Independiente", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Brazo de Superior Independiente", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Rótula Suspensión Superior Independiente", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Rótula Suspensión Superior", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Rótula de Dirección Independiente", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Rótula de Dirección", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Brazo Suspensión Inferior Independiente", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Brazo de Suspensior Inferior", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Kit de Barra Estabilizadora Independiente", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Muelle Suspensión Casquillos Silentbloc del Brazo de Suspensión Izquierda", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Muelle de Suspensión Izquierda", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Muelle Susp. Casquillos Silentbloc Brazo de Susp Izq", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Muelle de Suspensión Derecha", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Barra Estabilizadora Independiente", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Barra Estabilizadora Independiente", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Silentbloc de Barra Estabilizadora ", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Silentbloc de Barra Estabilizadora", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Casquillos Silentbloc del Brazo de Suspensión ", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Casquillo Silentblock BSS", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Eje del Brazo de Suspensión Independiente", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Eje del Brazo de Suspensión", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Tornillo Estabilizador Trasero Independiente", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Tornillo Estabilizador Trasero", "0.00", "1", "0.00");

            dgvSuspencion.Rows.Add("", "", "Otros");
            dgvSuspencion.Rows.Add("", "", "Soporte Motor lado Distribucion", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O Soporte Motor lado Distribución", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Soporte Motor lado Radiador ", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O.Soporte de Motor lado Radiador ", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Soporte Motor Lateral ", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Soporte MotorPared Lateral", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Soporte motor Pared de Fuego", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O. Soporte MotorPared de Fuego", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Soporte Motor lado Caja", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O Soporte de Motor lado Caja", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Soporte Motor Tipo Hueso Superior", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O Soporte Motor Tipo Hueso Superior", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Soporte Motor Tipo Hueso Inferior", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "M.O Soporte Motor Tipo Hueso Inferior", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Tornillos para Soporte de Motor ", "0.00", "1", "0.00");
            dgvSuspencion.Rows.Add("", "", "Servicio de Prensa", "0.00", "1", "0.00");

            foreach (DataGridViewRow row in dgvSuspencion.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; // Puedes ajustar el color de fondo según tus preferencias
                row.DefaultCellStyle.ForeColor = Color.Black; // Color de texto para las celdas regulares
            }

            dgvSuspencion.Rows[0].DefaultCellStyle.Font = new Font(dgvSuspencion.Font, FontStyle.Bold);
            dgvSuspencion.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(147, 190, 30);
            dgvSuspencion.Rows[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 190, 30);
            dgvSuspencion.Rows[0].ReadOnly = true;

            dgvSuspencion.Rows[36].DefaultCellStyle.Font = new Font(dgvSuspencion.Font, FontStyle.Bold);
            dgvSuspencion.Rows[36].DefaultCellStyle.BackColor = Color.FromArgb(147, 190, 30);
            dgvSuspencion.Rows[36].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 190, 30);
            dgvSuspencion.Rows[36].ReadOnly = true;

            dgvSuspencion.Rows[62].DefaultCellStyle.Font = new Font(dgvSuspencion.Font, FontStyle.Bold);
            dgvSuspencion.Rows[62].DefaultCellStyle.BackColor = Color.FromArgb(147, 190, 30);
            dgvSuspencion.Rows[62].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 190, 30);
            dgvSuspencion.Rows[62].ReadOnly = true;

            //dgvSuspencion.AllowUserToOrderColumns = false;
        }
        
        private void frenos()
        {
            dgvFrenos.Rows.Add("", "", "Frenos Delanteros");
            dgvFrenos.Rows.Add("DelaBala", "", "Balatas  Delanteras", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DelaDiscRect", "", "Rectificado de Discos Delanteros", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("MoDelaBala", "", "M.O Balatas Delanteras", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DelaDiscNuev", "", "Disco Nuevo Delantero", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("", "", "OTROS");
            dgvFrenos.Rows.Add("DelaRoto", "", "Rotores Delanteros", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DelaRotoRete", "", "Retén para Rotor Delantero", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DelaMazaBale", "", "Maza con Balero Delantera", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("MoDelaMazaBale", "", "M.O. Maza Balero", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DelaMaza", "", "Maza Delantera", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DelaMangFren", "", "Manguera de Frenos Delanteros", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("MoDelaMang", "", "M.O. Manguera de Frenos", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DelaHerrKit", "", "Kit de Herrajes Delanteros", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DelaPist", "", "Pistones Delanteros", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DelaLigaCubr", "", "Ligas con Cubrepolvo Delanteros", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("MoDelaPistLiga", "", "M.O. Pistones con ligas y cubre polvo", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DelaCali", "", "Caliper Delanteros", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DelaBirl", "", "Birlos Delanteros", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("Abs", "", "ABS", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("", "", "Frenos Traseros");
            dgvFrenos.Rows.Add("TrasBalaDisc", "", "Balatas o Pastillas Traseras", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("TrasBalaTamb", "", "Balata de Tambor", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("TrasDiscRect", "", "Rectificado de Discos Traseros", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("TrasTambRect", "", "Rectificado de Tambores", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("MoTrasBala", "", "M.O Balatas Traseras", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("MoTrasBalaElec", "", "M.O Balatas Traseras Freno ", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("TrasDiscNuev", "", "Disco Nuevo Trasero", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("TrasTambNuev", "", "Tambor Nuevo Trasero", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("", "", "OTROS");
            dgvFrenos.Rows.Add("", "", "Líquido de Frenos (Purgado)", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("MoPurgDot4", "", "M.O. Purgado (incluye líquido Dot 4)", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("MoPurgDot45", "", "M.O. Purgado (incluye líquido Dot 5)", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("DepoLiquFren", "", "Depósito de Liquido de Frenos", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("BombFren", "", "Bomba de Frenos", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("ChicFrenMano", "", "Chicote de Freno de Mano", "0.00", "1", "0.00");
            dgvFrenos.Rows.Add("MoChicFrenMano", "", "M.O. Chicote de Freno de Mano", "0.00", "1", "0.00");


            foreach (DataGridViewRow row in dgvFrenos.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White; 
                row.DefaultCellStyle.ForeColor = Color.Black; 
            }

            dgvFrenos.Rows[0].DefaultCellStyle.Font = new Font(dgvFrenos.Font, FontStyle.Bold);
            dgvFrenos.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(147, 190, 30);
            dgvFrenos.Rows[0].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 190, 30);
            dgvFrenos.Rows[0].ReadOnly = true;

            dgvFrenos.Rows[5].DefaultCellStyle.Font = new Font(dgvFrenos.Font, FontStyle.Bold);
            dgvFrenos.Rows[5].DefaultCellStyle.BackColor = Color.FromArgb(147, 190, 30);
            dgvFrenos.Rows[5].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 190, 30);
            dgvFrenos.Rows[5].ReadOnly = true;

            dgvFrenos.Rows[20].DefaultCellStyle.Font = new Font(dgvFrenos.Font, FontStyle.Bold);
            dgvFrenos.Rows[20].DefaultCellStyle.BackColor = Color.FromArgb(147, 190, 30); ;
            dgvFrenos.Rows[20].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 190, 30);
            dgvFrenos.Rows[20].ReadOnly = true;

            dgvFrenos.Rows[29].DefaultCellStyle.Font = new Font(dgvFrenos.Font, FontStyle.Bold);
            dgvFrenos.Rows[29].DefaultCellStyle.BackColor = Color.FromArgb(147, 190, 30);
            dgvFrenos.Rows[29].DefaultCellStyle.SelectionBackColor = Color.FromArgb(147, 190, 30);
            dgvFrenos.Rows[29].ReadOnly = true;
        }

        private void dgvClutch_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvCheckList != null)
            //{
            //    ProdServDgv = "Productos y Servicios";
            //    int idRow = dgvCheckList.CurrentCell.RowIndex;
            //    int[] filasBalatas = new int[] { -1 };
            //    if (filasBalatas.Contains(idRow))
            //    {
            //        ProdServDgv = "";
            //    }
                totalCheckList();
                //dgvCheckList = null
            //}
        }

        private void dgvAfinacion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvCheckList != null)
            //{
            //    ProdServDgv = "Productos y Servicios";
            //    int idRow = dgvCheckList.CurrentCell.RowIndex;
            //    int[] filasBalatas = new int[] { -1 };
            //    if (filasBalatas.Contains(idRow))
            //    {
            //        ProdServDgv = "";
            //    }
            totalCheckList();
            //    dgvCheckList = null;
            //}
        }

        private void dgvSuspencion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvCheckList != null)
            //{
            //    ProdServDgv = "Productos y Servicios";
            //    int idRow = dgvCheckList.CurrentCell.RowIndex;
            //    int[] filasBalatas = new int[] { -1 };
            //    if (filasBalatas.Contains(idRow))
            //    {
            //        ProdServDgv = "";
            //    }
            totalCheckList();
            //    dgvCheckList = null;
            //}
        }

        private void dgvFrenosDelanteros_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (dgvCheckList != null)
            //{
            //    ProdServDgv = "Productos y Servicios";
            //    int idRow = dgvCheckList.CurrentCell.RowIndex;
            //    int[] filasBalatas = new int[] { 1 };
            //    if (filasBalatas.Contains(idRow))
            //    {
            //        ProdServDgv = "Balatas";
            //    }
            totalCheckList();
            //    dgvCheckList = null;
            //}
        }

        private void totalCheckList()
        {
            if (dgvCheckList != null)
            {
                seleccionarProductoServicio();
                int idRow = dgvCheckList.CurrentCell.RowIndex;
                string tabla = dgvCheckList.Name.Replace("dgv", "");
                decimal total =
                (Convert.ToDecimal(dgvCheckList.Rows[idRow].Cells["precioUni" + tabla].Value)
                * Convert.ToDecimal(dgvCheckList.Rows[idRow].Cells["cantidad" + tabla].Value));
                dgvCheckList.Rows[idRow].Cells["total" + tabla].Value =
                    Math.Round(total, 2, MidpointRounding.ToEven);

                if (Convert.ToBoolean(dgvCheckList.Rows[idRow].Cells["autorizado" + tabla].Value))
                {

                    agregarProducto(dgvCheckList.Rows[idRow].Cells["noParte" + tabla].Value.ToString());
                }
                else
                {
                    eliminarProducto(dgvCheckList);
                }
            }
        }

        private void dgvClutch_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            abrirProductos(dgvClutch,e);
        }

        private void dgvFrenos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            abrirProductos(dgvFrenos,e);
        }

        private void seleccionarProductoServicio()
        {

            int idRow = dgvCheckList.CurrentCell.RowIndex;
            string tablaDgv = dgvCheckList.Name.Replace("dgv", "");
            ProdServDgv = "Productos y Servicios";
            switch (tablaDgv)
            {
                case "Clutch":
                    int[] filasCLutch = new int[] { 0 };
                    if (filasCLutch.Contains(idRow))
                    {
                        ProdServDgv = "Clutch";
                    }
                    break;
                case "Frenos":
                    int[] filasBalatas = new int[] { 1 };
                    if (filasBalatas.Contains(idRow))
                    {
                        ProdServDgv = "Balatas";
                    }
                    break;
            }
        }

        private void abrirProductos(DataGridView dgvCheck, DataGridViewCellEventArgs e)
        {
            dgvCheckList = dgvCheck;
            seleccionarProductoServicio();
            if (dgvCheckList != null)
            {
                string tablaDgv = dgvCheckList.Name.Replace("dgv", "");
                string columna = dgvCheckList.Columns[e.ColumnIndex].Name;
                if (columna == "noParte" + tablaDgv || columna == "producto" + tablaDgv)
                {

                    frmProductosProveedores formProvServ = new frmProductosProveedores(this, true);
                    mainWindows.abrirForm(formProvServ, Global.Ventana._3_3);
                }
            }
        }

        private void eliminarProducto(DataGridView dataGridView)
        {
            for (int i = dgvProductos.Rows.Count - 1; i >= 0; i--)
            {
                DataGridViewRow row = dgvProductos.Rows[i];
                string valorCelda = row.Cells["noParte"].Value.ToString();

                int idRow = dataGridView.CurrentCell.RowIndex;

                // Compara el valor con el texto a eliminar
                if (valorCelda == dataGridView.Rows[idRow].Cells["noParte"+ dgvCheckList.Name.Replace("dgv", "")].Value.ToString())
                {
                    // Si coincide, elimina la fila
                    dgvProductos.Rows.RemoveAt(i);
                }
            }
            calculoTotalGeneral();
        }

        DataGridView dgvCheckList=null; public string ProdServDgv = "";
        
        public void cargarProducoServicio(string noProducto,string precioUni)
        {
            string tablaDgv = dgvCheckList.Name.Replace("dgv", "");
            int indexDgv=dgvCheckList.CurrentCell.RowIndex;
            dgvCheckList.Rows[indexDgv].Cells["noParte" + tablaDgv].Value = noProducto;
            dgvCheckList.Rows[indexDgv].Cells["precioUni" + tablaDgv].Value = precioUni;
            //SELECIONAREL SERVICIO
            int indice = cbxServicios.FindStringExact(ProdServDgv);

            cbxServicios.SelectedIndex = indice;
            ProdServDgv = cbxServicios.Text;
            cargarProductos();
            calculoTotalGeneral();
        }
    
        private void cargarProductosCheckList()        
        {
            dtProdServ = ProductosProveedoresBus.GetProductoServicio(Convert.ToInt32(cbxProveedores.SelectedValue.ToString()));

            foreach(DataGridViewRow filaDgv in dgvFrenos.Rows)
            {
                foreach(DataRow filaPS in dtProdServ.Rows)
                {
                    if(filaDgv.Cells["noParteFrenos"].Value.ToString()== filaPS["NUMERO_PARTE"].ToString())
                    {
                        filaDgv.Cells["precioUniFrenos"].Value = filaPS["PRECIO_PUBLICO"].ToString();
                        filaDgv.Cells["totalFrenos"].Value = filaPS["PRECIO_PUBLICO"].ToString();
                    }
                }
            }
        }
    }
}
