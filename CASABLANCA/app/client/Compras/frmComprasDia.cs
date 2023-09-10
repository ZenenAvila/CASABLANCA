using CASABLANCA.app.business;
using CASABLANCA.app.client.Catalogos;
using CASABLANCA.app.cls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASABLANCA.app.client.Compras
{
    public partial class frmComprasDia : Form
    {
        ComprasDiaBus business = new ComprasDiaBus();
        ProductosProveedoresBus ProductosProveedoresBus = new ProductosProveedoresBus();

        DataTable dtproveedores, dtProductos, dtProductosServicios;
        public frmComprasDia()
        {
            InitializeComponent();
        }

        private IMainWindows _mainWindows;
        private mainWindows mainWindows;

        public frmComprasDia(mainWindows form)
        {
            InitializeComponent();
            _mainWindows = form;
            mainWindows = form;
        }

        private void frmComprasDia_Load(object sender, EventArgs e)
        {
            cargarProductos();
            //frmComprasDiaEncabezado formEncabezado = new frmComprasDiaEncabezado(this);
            //formEncabezado.Show();
        }

        private void cbxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarProveedores();
        }

        public void cargarProductos(int id = 0)
        {
            dtProductos = business.GetProductos();

            cbxProductos.Text = "";
            cbxProductos.DataSource = dtProductos;
            cbxProductos.ValueMember = "ID";
            cbxProductos.DisplayMember = "NOMBRE";
            cbxProductos.Refresh();

            if (dtProductos.Rows.Count > 0)
            {
                cbxProductos.SelectedIndex = id;

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string noParte = cbxNoParte.Text;

            bool banExist = false;
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (noParte == fila.Cells["noParte"].Value.ToString())
                {
                    banExist = true;
                }
            }
            if (!banExist)
            {
                foreach (DataRow fila in dtProductosServicios.Rows)
                {
                    if (fila["NUMERO_PARTE"].ToString() == noParte)
                    {
                        string id = fila["id"].ToString();
                        string marca = fila[3].ToString();
                        decimal pUnitario = Convert.ToDecimal(fila["PRECIO_PUBLICO"]),
                            iva = Math.Round((pUnitario) * Convert.ToDecimal(0.16),
                            2, MidpointRounding.ToEven);
                                                
                        dgvProductos.Rows.Add(
                            Convert.ToInt32(cbxProductos.SelectedValue),
                            cbxProductos.Text, 
                            id, 
                            noParte,
                            cbxProveedores.SelectedValue, 
                            cbxProveedores.Text
                            , marca, pUnitario, iva, 
                            "0.00", "0.00 %",
                            pUnitario, 1, pUnitario);
                        calculoGeneral();
                        lblRegistros.Text = "Total de Registros: " + dgvProductos.RowCount.ToString();

                        break;
                    }
                }
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
                    Convert.ToDecimal(dgvProductos.Rows[idRow].Cells["precioUni"].Value)).ToString() + '%';
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

        private void btnProveedores_Click(object sender, EventArgs e)
        {

            frmProveedores formProveedores = new frmProveedores();
            mainWindows.abrirForm(formProveedores);
            formProveedores.definirHijo(this);
        }

        private void pbxProductos_Click(object sender, EventArgs e)
        {
            frmProductosProveedores formProvServ = new frmProductosProveedores();
            mainWindows.abrirForm(formProvServ, Global.Ventana._3_3);
            formProvServ.definirHijo(this);

        }

        private void btnGuardarCompra_Click(object sender, EventArgs e)
        {

            if (banActualizar)
            {
                updateExistencia(false);

                business.updateComprasDia(idEncabezado,
                    txtNoRFacRem.Text,
                    Convert.ToInt32(cbxProductos.SelectedValue),
                    Convert.ToInt32(cbxProveedores.SelectedValue),
                    Convert.ToDecimal(txtSubtotal.Text),
                    Convert.ToDecimal(txtIva.Text),
                    Convert.ToDecimal(txtTotal.Text));
                //Eliminar registros
                business.deleteRegistrComprasDia(txtNoRFacRem.Text);


                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    int idCatProdServ = Convert.ToInt32(row.Cells["idProducto"].Value);
                    int idProdServ = Convert.ToInt32(row.Cells["id"].Value);
                    int idProveedor = Convert.ToInt32(row.Cells["idProveedor"].Value);
                    string noFacRem = txtNoRFacRem.Text,
                        noParte = row.Cells["noParte"].Value.ToString(),
                        marca = row.Cells["marca"].Value.ToString();
                    decimal precioUni = Convert.ToDecimal(row.Cells["precioUni"].Value),
                        iva = Convert.ToDecimal(row.Cells["iva"].Value),
                        descuento = Convert.ToDecimal(row.Cells["descuento"].Value),
                        descuentoPor = Convert.ToDecimal(row.Cells["descuentoPor"].Value
                        .ToString().Replace('%', ' ')),
                        subtotal = Convert.ToDecimal(row.Cells["subtotal"].Value),
                        total = Convert.ToDecimal(row.Cells["total"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                    business.InsertRegistroComprasDia(noFacRem, idCatProdServ,idProveedor, idProdServ, noParte, marca, precioUni,
                        iva, descuento, descuentoPor, subtotal, cantidad, total);
                }
                banActualizar = true;
                MessageBox.Show("La Compra Se Actualizó Correctamente.", "Compra Actualizada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                updateExistencia();
                business.InsertComprasDia(txtNoRFacRem.Text,
                    Convert.ToInt32(cbxProductos.SelectedValue),
                    Convert.ToInt32(cbxProveedores.SelectedValue),
                    Convert.ToDecimal(txtSubtotal.Text),
                    Convert.ToDecimal(txtIva.Text),
                    Convert.ToDecimal(txtTotal.Text));

                foreach (DataGridViewRow row in dgvProductos.Rows)
                {
                    int idCatProdServ = Convert.ToInt32(row.Cells["idProducto"].Value);
                    int idProdServ = Convert.ToInt32(row.Cells["id"].Value);
                    int idProveedor = Convert.ToInt32(row.Cells["idProveedor"].Value);
                    string noFacRem = txtNoRFacRem.Text,
                        noParte = row.Cells["noParte"].Value.ToString(),
                        marca = row.Cells["marca"].Value.ToString();
                    decimal precioUni = Convert.ToDecimal(row.Cells["precioUni"].Value),
                        iva = Convert.ToDecimal(row.Cells["iva"].Value),
                        descuento = Convert.ToDecimal(row.Cells["descuento"].Value),
                        descuentoPor = Convert.ToDecimal(row.Cells["descuentoPor"].Value
                        .ToString().Replace('%', ' ')),
                        subtotal = Convert.ToDecimal(row.Cells["subtotal"].Value),
                        total = Convert.ToDecimal(row.Cells["total"].Value);
                    int cantidad = Convert.ToInt32(row.Cells["cantidad"].Value);
                    business.InsertRegistroComprasDia(noFacRem, idCatProdServ, idProveedor,idProdServ, noParte, marca, precioUni,
                        iva, descuento, descuentoPor, subtotal, cantidad, total);
                }
                banActualizar = true;
                btnGuardarCompra.Text = "Actualizar Compra";
                MessageBox.Show("La Compra Se Guardó Correctamente.", "Compra Guardada",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            dtRegistrosCompraDia = business.GetRegistrosComprasDia(txtNoRFacRem.Text);
        }

        private void cbxProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbxProveedores.SelectedValue != null)
                {
                    switch (cbxProductos.Text)
                    {
                        case "Balatas":
                            dtProductosServicios = business.GetBalatas(Convert.ToInt32(cbxProveedores.SelectedValue.ToString()));
                            break;
                        case "Clutch":
                            dtProductosServicios = business.GetClutch(Convert.ToInt32(cbxProveedores.SelectedValue.ToString()));
                            break;
                    }
                    cbxNoParte.Text = "";
                    cbxNoParte.DataSource = dtProductosServicios;
                    cbxNoParte.ValueMember = "ID";
                    cbxNoParte.DisplayMember = "NUMERO_PARTE";
                    cbxNoParte.Refresh();

                    if (dtProductosServicios != null)
                    {
                        cbxNoParte.SelectedIndex = 0;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void cargarProveedores(int i = 0)
        {
            try
            {
                //dtproveedores = business.GetProveedorById(Convert.ToInt32(cbxProductos.SelectedValue));
                dtproveedores = ProductosProveedoresBus.GetProveedores();

                cbxProveedores.Text = "";
                cbxProveedores.DataSource = dtproveedores;
                cbxProveedores.ValueMember = "ID";
                cbxProveedores.DisplayMember = "NOMBRE";
                cbxProveedores.Refresh();

                if (i > 0)
                {
                    //foreach(DataRow row in dtproveedores.Rows)}
                    bool banProveedor = true;

                    for (int j = 0; banProveedor; j++)
                    {
                        if (dtproveedores.Rows[j][0].ToString() == i.ToString())
                        {
                            banProveedor = false;
                            cbxProveedores.SelectedIndex = j;
                        }
                    }
                }
                else
                {
                    cbxProveedores.SelectedIndex = i;
                }
            }
            catch (Exception ex)
            {

            }
        }
        bool banActualizar = false;

        int idEncabezado;
        DataGridViewRow Encabezado;
        DataTable dtRegistrosCompraDia = null;
        public void cargarEncabezado(DataGridViewRow row)
        {
            banActualizar = true;
            btnGuardarCompra.Text = "Actualizar Compra";
            Encabezado = row;
            idEncabezado = Convert.ToInt32(Encabezado.Cells[1].Value);

            txtNoRFacRem.Text = Encabezado.Cells[2].Value.ToString();
            cargarProductos(Convert.ToInt32(Encabezado.Cells[3].Value) - 1);
            cargarProveedores(Convert.ToInt32(Encabezado.Cells[4].Value));
            txtSubtotal.Text = Encabezado.Cells[5].Value.ToString();
            txtIva.Text = Encabezado.Cells[6].Value.ToString();
            txtTotal.Text = Encabezado.Cells[7].Value.ToString();

            cargarRegistros();
        }

        private void cargarRegistros()
        {
            dtRegistrosCompraDia = business.GetRegistrosComprasDia(txtNoRFacRem.Text);

            dgvProductos.Rows.Clear();

            foreach (DataRow registro in dtRegistrosCompraDia.Rows)
            {
                DataRow[] producto = dtProductos.Select("ID = " + registro["ID_CAT_PROD_SERV"]);

                DataRow[] proveedor = dtproveedores.Select("ID = " + registro["ID_PROVEEDOR"]);


                dgvProductos.Rows.Add(
                    producto[0]["ID"],
                    producto[0]["NOMBRE"],
                    registro["ID_PROD_SERV"],
                    registro["NO_PARTE"],
                    proveedor[0]["ID"],
                    proveedor[0]["NOMBRE"],
                    registro["MARCA"],
                    registro["PRECIO_UNITARIO"],
                    registro["IVA"],
                    registro["DESCUETO"],
                    registro["DESCUENTO_PORCENTAJE"],
                    registro["SUBTOTAL"],
                    registro["CANTIDAD"],
                    registro["TOTAL"]) ;
            }
        }

        private void updateExistencia(bool insert = true)
        {
            if (insert)
            {
                foreach (DataGridViewRow registroAct in dgvProductos.Rows)
                {
                    DataRow[] producto = dtProductos.Select("ID = " + Convert.ToInt32(registroAct.Cells["idProducto"].Value));
                    business.updateExistencia(0,producto[0]["Nombre"].ToString(),
                        Convert.ToInt32(registroAct.Cells["id"].Value),
                       registroAct.Cells["noParte"].Value.ToString(),
                       Convert.ToInt32(cbxProveedores.SelectedValue),
                       registroAct.Cells["marca"].Value.ToString(),
                       Convert.ToDecimal(registroAct.Cells["precioUni"].Value),
                       Convert.ToInt32(registroAct.Cells["cantidad"].Value));
                }
            }
            else
            {
                if (dtRegistrosCompraDia != null)
                {
                    if (dtRegistrosCompraDia.Rows.Count > dgvProductos.Rows.Count)
                    {
                        foreach (DataRow registro in dtRegistrosCompraDia.Rows)
                        {
                            bool banEliminado = true;
                            foreach (DataGridViewRow registroAct in dgvProductos.Rows)
                            {
                                if (registro["NO_PARTE"].ToString() == registroAct.Cells["noParte"].Value.ToString())
                                {
                                    banEliminado = false;
                                    if (registro["CANTIDAD"].ToString() != registroAct.Cells["cantidad"].Value.ToString()||
                                        Convert.ToDecimal(registro["PRECIO_UNITARIO"]) != Convert.ToDecimal(registroAct.Cells["precioUni"].Value))
                                    {
                                        banEliminado = false;
                                        int cantidad = Convert.ToInt32(registro["CANTIDAD"]),
                                            cantidadAct = Convert.ToInt32(registroAct.Cells["cantidad"].Value);

                                        DataRow[] producto = dtProductos.Select("ID = " + Convert.ToInt32(registroAct.Cells["idProducto"].Value));
                                        business.updateExistencia(1,
                                            producto[0]["Nombre"].ToString(),
                                            Convert.ToInt32(registroAct.Cells["id"].Value),
                                            registroAct.Cells["noParte"].Value.ToString(),
                                            Convert.ToInt32(cbxProveedores.SelectedValue),
                                            registroAct.Cells["marca"].Value.ToString(),
                                            Convert.ToDecimal(registroAct.Cells["precioUni"].Value),
                                            (cantidad - cantidadAct) * -1);
                                    }
                                }
                            }

                            if (banEliminado)
                            {
                                DataRow[] producto = dtProductos.Select("ID = " + Convert.ToInt32(registro["ID_CAT_PROD_SERV"]));
                                business.updateExistencia(2,
                                    producto[0]["Nombre"].ToString(),
                                            Convert.ToInt32(registro["ID_PROD_SERV"]),
                                            Convert.ToString(registro["NO_PARTE"]),
                                            Convert.ToInt32(cbxProveedores.SelectedValue),
                                            Convert.ToString(registro["MARCA"]),
                                            Convert.ToDecimal(registro["PRECIO_UNITARIO"]),
                                            Convert.ToInt32(registro["CANTIDAD"]) * -1);

                            }
                        }
                    }
                    else
                    {
                        foreach (DataGridViewRow registroAct in dgvProductos.Rows)
                        {
                            bool banAgregado = true;
                            foreach (DataRow registro in dtRegistrosCompraDia.Rows)
                            {
                                if (registro["NO_PARTE"].ToString() == registroAct.Cells["noParte"].Value.ToString())
                                {
                                    banAgregado = false;
                                    if (registro["CANTIDAD"].ToString() != registroAct.Cells["cantidad"].Value.ToString() || 
                                        Convert.ToDecimal(registro["PRECIO_UNITARIO"]) != Convert.ToDecimal(registroAct.Cells["precioUni"].Value))
                                    {
                                        banAgregado = false;
                                        int cantidad = Convert.ToInt32(registro["CANTIDAD"]),
                                            cantidadAct = Convert.ToInt32(registroAct.Cells["cantidad"].Value);

                                        //             business.updateExistencia("BALATAS", Convert.ToInt32(registroAct.Cells["id"].Value),
                                        //Convert.ToDecimal(registroAct.Cells["precioUni"].Value),
                                        //                (cantidad - cantidadAct) * -1);

                                        DataRow[] producto = dtProductos.Select("ID = " + Convert.ToInt32(registroAct.Cells["idProducto"].Value));
                                        business.updateExistencia(1,
                                            producto[0]["Nombre"].ToString(),
                                                    Convert.ToInt32(registro["ID_PROD_SERV"]),
                                            Convert.ToString(registro["NO_PARTE"]),
                                            Convert.ToInt32(cbxProveedores.SelectedValue),
                                            Convert.ToString(registro["MARCA"]),
                                            Convert.ToDecimal(registroAct.Cells["precioUni"].Value),
                                            (cantidad - cantidadAct) * -1);
                                    }
                                }
                            }

                            if (banAgregado)
                            {
                                DataRow[] producto = dtProductos.Select("ID = " + Convert.ToInt32(registroAct.Cells["idProducto"].Value));
                                business.updateExistencia(0,producto[0]["Nombre"].ToString(), 
                                    Convert.ToInt32(registroAct.Cells["id"].Value),
                                    registroAct.Cells["noParte"].Value.ToString(),
                                    Convert.ToInt32(cbxProveedores.SelectedValue),
                                    registroAct.Cells["marca"].Value.ToString(),
                                    Convert.ToDecimal(registroAct.Cells["precioUni"].Value),
                                    Convert.ToInt32(registroAct.Cells["cantidad"].Value));
                            }
                        }
                    }
                }
            }
        }
        #region Traer Al Frente
        private void frmComprasDia_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
        }
        #endregion
    }
}
