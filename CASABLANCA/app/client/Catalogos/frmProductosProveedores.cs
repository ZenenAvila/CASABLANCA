using CASABLANCA.app.business;
using CASABLANCA.app.client.Compras;
using CASABLANCA.app.client.Ingreso;
using CASABLANCA.app.Commond;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASABLANCA.app.client.Catalogos
{
    public partial class frmProductosProveedores : Form
    {
        ProductosProveedoresBus business=new ProductosProveedoresBus();
        DataTable dtProductos;
        frmIngreso Ingreso;
        bool selecProducto = false;
        int idControles = 0;
        public frmProductosProveedores()
        {
            InitializeComponent();
        }

        public frmProductosProveedores(frmIngreso ingreso,bool _selecProducto=false)
        {
            InitializeComponent();
            Ingreso = ingreso;
            selecProducto=_selecProducto;
        }

        private void frmProductosProveedores_Load(object sender, EventArgs e)
        {
            cargarProductos();
            cargarProveedores();
            consultar();

            if (Ingreso != null)
            {
                int indice = cbxProducto.FindStringExact(Ingreso.ProdServDgv);

                if (indice != -1)
                {
                    cbxProducto.SelectedIndex = indice; // Selecciona el elemento encontrado
                }
                cbxProducto.Enabled = false;
            }
            //if(File.Exists(ofdExploradorArchivos.FileName))
            //    {

            //}

            //using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            //{
            //    System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        MessageBox.Show(dialog.SelectedPath);
            //    }
            //}
            inicio = false;
        }
        DataTable dtbproveedores;

        public void cargarProveedores(int i = -1)
        {
            dtbproveedores = business.GetProveedores();
            cbxProveedor.DataSource = dtbproveedores;
            cbxProveedor.ValueMember = "ID";
            cbxProveedor.DisplayMember = "NOMBRE";
            cbxProveedor.Refresh();
            if (i != -1)
            {
                cbxProveedor.SelectedValue = i;
            }
            else
            {
                //cbxProveedor.SelectedIndex = 1;
            }
        }

        private void cbxProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxProducto.Text)
            {
                case "Productos y Servicios":
                    idControles = 0;
                    break;
                case "Clutch":
                    idControles = 2;
                    break;
                case "Balatas":
                    idControles = 1;
                    break;
            }
            tcDatos.SelectedTab = tcDatos.TabPages[idControles];

            consultar();
        }

        public void cargarProductos(int i=-1)
        {
            dtProductos = business.GetCatPS();
            cbxProducto.DataSource = dtProductos;
            cbxProducto.ValueMember = "ID";
            cbxProducto.DisplayMember = "NOMBRE";
            cbxProducto.Refresh();

            if (i != -1)
            {
                cbxProducto.SelectedValue = i;
            }
        }

        private void descongelarDGV()
        {
            foreach (DataGridViewColumn column in dgvProductosProveedores.Columns)
            {
                column.Frozen = false;
            }
        }

        public void consultar()
        {

            if (cbxProveedor.SelectedValue != null)
            {
                descongelarDGV();
                switch (cbxProducto.Text)
                {
                    case "Clutch":
                        dgvProductosProveedores.DataSource = business.GetClutch(Convert.ToInt32(cbxProveedor.SelectedValue.ToString()));
                        dgvProductosProveedores.Columns[0].Frozen = true;
                        dgvProductosProveedores.Columns[1].Frozen = true;
                        dgvProductosProveedores.Columns[2].Frozen = true;
                        dgvProductosProveedores.Columns[3].Frozen = true;
                        //dgvProductosProveedores.Columns[4].Frozen = true;
                        break;
                    case "Balatas":
                        dgvProductosProveedores.DataSource = business.GetBalatas(Convert.ToInt32(cbxProveedor.SelectedValue.ToString()));
                        dgvProductosProveedores.Columns[0].Frozen = true;
                        dgvProductosProveedores.Columns[1].Frozen = true;
                        dgvProductosProveedores.Columns[2].Frozen = true;
                        //dgvProductosProveedores.Columns[3].Frozen = true;

                        break;
                    case "Productos y Servicios":
                        dgvProductosProveedores.DataSource = business.GetProductoServicio(Convert.ToInt32(cbxProveedor.SelectedValue.ToString()));
                        break;
                }
            }
            dgvProductosProveedores.Refresh();
            lblRegistros.Text = "Total de Registros: " + dgvProductosProveedores.RowCount;
            limpiar();
        }

        private void pbxImportar_Click(object sender, EventArgs e)
        {
            try
            {
                //frmMessage message = new frmMessage();
                
                   //await message._Show("Formato Excel " + cbxProducto.Text, "¿Qué desea realizar?", message.Advertencia, "Cancel", "Exportar", "Importar");
                
                MessageBoxButtons btnOpciones = MessageBoxButtons.YesNo;
                DialogResult dr = MessageBox.Show("¿Desea Importar un Formato de "+cbxProducto.Text+"?", "Formato Excel " + cbxProducto.Text,
                    btnOpciones, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    ofdExploradorArchivos.Title = "Formato " + cbxProducto.Text;
                    ofdExploradorArchivos.ShowDialog();
                    string ruta = ofdExploradorArchivos.FileName.Replace(@"\", @"/");
                    lecturaFormato(ruta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Importar: " + ex.ToString());
            }
        }

        private void pcbExportar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBoxButtons btnOpciones = MessageBoxButtons.YesNo;
                DialogResult dr = MessageBox.Show("¿Desea Exportar un Formato de " + cbxProducto.Text + "?", "Formato Excel " + cbxProducto.Text,
                    btnOpciones, MessageBoxIcon.Question);

                if (dr == DialogResult.Yes)
                {
                    //sfdExportar.Title = "Formato " + cbxProducto.Text;
                    //sfdExportar.ShowDialog();


                    using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
                    {
                        System.Windows.Forms.DialogResult result = dialog.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            //MessageBox.Show();


                            string ruta = dialog.SelectedPath +"\\"+cbxProducto.Text + ".xlsx";
                            bool banFile = true;
                            int conFile = 1;
                            while(banFile){
                                if (System.IO.File.Exists(ruta))
                                {
                                    conFile++;
                                    ruta = dialog.SelectedPath + "\\" + cbxProducto.Text + " - "+(conFile).ToString()+".xlsx";
                                }
                                else
                                {
                                    banFile = false;
                                }
                            }
                                //string ruta = dialog.SelectedPath + "\\prueba.txt";
                                string formatos = @"../../Exportacion/" + cbxProducto.Text + ".xlsx";
                                //string formatos = @"../../Exportacion/prueba.txt";
                                if (!string.IsNullOrEmpty(ruta))
                                {
                                    File.Copy(formatos.Replace(@"\", @"/"), ruta.Replace(@"\", @"/"));
                                }
                            
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Exportar: " + ex.ToString());
            }
        }

        public void lecturaFormato(string ruta)
        {
            if (!string.IsNullOrEmpty(ruta))
            {
                int fila=1;
                SLDocument s1;
                s1 = new SLDocument(ruta);
                switch (cbxProducto.Text)
                {
                    case "Clutch":

                        if (s1.GetCellValueAsString(fila, 1) == "APLICACION"
                        && s1.GetCellValueAsString(fila, 2) == "PROVEEDOR"
                        && s1.GetCellValueAsString(fila, 3) == "NUMERO DE PARTE"
                        && s1.GetCellValueAsString(fila, 4) == "PRECIO"
                        && s1.GetCellValueAsString(fila, 5) == "PRODUCTO"
                        && s1.GetCellValueAsString(fila, 6) == "EQUIVALENCIA LUK"
                        && s1.GetCellValueAsString(fila, 7) == "EQUIVALENCIA SACHS"
                        && s1.GetCellValueAsString(fila, 8) == "EQUIVALENCIA 3L ORIGINAL"
                        && s1.GetCellValueAsString(fila, 9) == "EQUIVALENCIA EXEDY"
                        && s1.GetCellValueAsString(fila, 10) == "EQUIVALENCIA VALEO"
                        && s1.GetCellValueAsString(fila, 11) == "EQUIVALENCIA AISIN")
                        {

                            fila++;
                            
                            while (!string.IsNullOrEmpty(s1.GetCellValueAsString(fila, 1)))
                            {
                                string aplicacion = s1.GetCellValueAsString(fila, 1);
                                string proveedor = s1.GetCellValueAsString(fila, 2);
                                string numeroParte = s1.GetCellValueAsString(fila, 3);
                                decimal precio = s1.GetCellValueAsDecimal(fila, 4);
                                string producto = s1.GetCellValueAsString(fila, 5);
                                string eqvLuk = s1.GetCellValueAsString(fila, 6);
                                string eqvSachs = s1.GetCellValueAsString(fila, 7);
                                string eqv3L = s1.GetCellValueAsString(fila, 8);
                                string eqvExedy = s1.GetCellValueAsString(fila, 9);
                                string eqvValeo = s1.GetCellValueAsString(fila, 10);
                                string eqvAisin = s1.GetCellValueAsString(fila, 11);

                                //business.InsertClutch(aplicacion, proveedor, numeroParte, precio, producto, eqvLuk, eqvSachs, eqv3L, eqvExedy, eqvValeo, eqvAisin);
                                fila++;
                            }
                            MessageBox.Show((fila-2).ToString()+" Insertados correctamente", "Formato Excel " + cbxProducto.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        }
                        else
                        {
                            MessageBox.Show("Este no es un formato de " + cbxProducto.Text, "Formato Excel " + cbxProducto.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                    case "Balatas":

                        if (s1.GetCellValueAsString(fila, 1) == "PROVEEDOR"
                        && s1.GetCellValueAsString(fila, 2) == "No. PARTE"
                        && s1.GetCellValueAsString(fila, 3) == "MARCA"
                        && s1.GetCellValueAsString(fila, 4) == "POSICION"
                        && s1.GetCellValueAsString(fila, 5) == "ABUTMENT"
                        && s1.GetCellValueAsString(fila, 6) == "APLICACION"
                        && s1.GetCellValueAsString(fila, 7) == "MODELO"
                        && s1.GetCellValueAsString(fila, 8) == "FORMULA"
                        && s1.GetCellValueAsString(fila, 9) == "PRECIO PUBLICO"
                        && s1.GetCellValueAsString(fila, 10) == "OBSERVACIONES")
                        {

                            fila++;
                            while (!string.IsNullOrEmpty(s1.GetCellValueAsString(fila, 1)))
                            {
                                string proveedor = s1.GetCellValueAsString(fila, 1);
                                string numeroParte = s1.GetCellValueAsString(fila, 2);
                                string marca = s1.GetCellValueAsString(fila, 3);
                                string posicion = s1.GetCellValueAsString(fila, 4);
                                bool abutment = Convert.ToBoolean(s1.GetCellValueAsString(fila, 5));
                                string aplicacion = s1.GetCellValueAsString(fila, 6);
                                string modelo = s1.GetCellValueAsString(fila, 7);
                                string formula = s1.GetCellValueAsString(fila, 8);
                                decimal precioPublico = s1.GetCellValueAsDecimal(fila, 9);
                                string observaciones = s1.GetCellValueAsString(fila, 10);

                                business.InsertBalata(1, numeroParte, marca, posicion, abutment, aplicacion, modelo,
                                    formula, precioPublico, observaciones,1);
                                fila++;
                            }
                            MessageBox.Show((fila - 2).ToString() + " Insertados correctamente", "Formato Excel " + cbxProducto.Text, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        }
                        else
                        {
                            MessageBox.Show("Este no es un formato de " + cbxProducto.Text, "Formato Excel " + cbxProducto.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        break;
                }
                consultar();
                s1.Dispose();
            }
        }

        public void limpiar()
        {
            switch (cbxProducto.Text.ToUpper())
            {
                case "BALATAS":
                    txtId.Clear();
                    txtNoParte.Clear();
                    txtBalatasMarca.Clear();
                    chkBalatasAbutmen.Checked=false;
                    txtBalatasAplicacion.Clear();
                    txtBalatasObservacion.Clear();
                    txtBalatasModelo.Clear();
                    txtBalatasFormula.Clear();
                    txtPrecioPublico.Clear();
                    txtBalatasPosicion.Clear();
                    btnModificar.Visible = false;
                    btnEliminar.Visible = false;
                    break;
                case "CLUTCH":
                    txtClutchAplicacion.Clear();
                    txtClutchProducto.Clear();
                    txtClutchLuk.Clear();
                    txtClutchSach.Clear();
                    txtClutch3L.Clear();
                    txtClutchExedy.Clear();
                    txtClutchValeo.Clear();
                    txtClutchAisin.Clear();
                    txtClutchAisin.Clear();
                    txtClutchPrecioCompra.Clear();
                    txtClutchPrecioPublico.Clear();
                    break;
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if(dgvProductosProveedores.RowCount==0)
                {
                    business.ValidServProdProv(Convert.ToInt32(cbxProveedor.SelectedValue),Convert.ToInt32(cbxProducto.SelectedValue));
                }
                business = new ProductosProveedoresBus();
                switch (cbxProducto.Text)
                {
                    case "Balatas":
                        if (!string.IsNullOrEmpty(cbxProveedor.Text) &&
                            !string.IsNullOrEmpty(txtNoParte.Text) &&
                            !string.IsNullOrEmpty(txtBalatasMarca.Text) &&
                            !string.IsNullOrEmpty(txtBalatasPosicion.Text))
                        {
                            business.InsertBalata(Convert.ToInt32(cbxProveedor.SelectedValue), txtNoParte.Text, 
                                txtBalatasMarca.Text, txtBalatasPosicion.Text, chkBalatasAbutmen.Checked,
                            txtBalatasAplicacion.Text, txtBalatasModelo.Text, txtBalatasFormula.Text, Convert.ToDecimal(txtPrecioPublico.Text), txtBalatasObservacion.Text, 1);
                        }
                        else
                        {
                            MessageBox.Show("Debe Ingresar los siguientes datos: Producto, Proveedor, No. Parte, Aplicación",
                                "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;

                    case "Clutch":
                        if (true)
                        {
                            business.InsertClutch(txtClutchAplicacion.Text, Convert.ToInt32(cbxProveedor.SelectedValue),txtNoParte.Text,
                                txtClutchProducto.Text,txtClutchLuk.Text,txtClutchSach.Text, txtClutch3L.Text, txtClutchExedy.Text, 
                                txtClutchValeo.Text, txtClutchAisin.Text,Convert.ToDecimal(txtClutchPrecioCompra.Text),
                                Convert.ToDecimal(txtClutchPrecioPublico.Text));
                        }
                        else
                        {
                            MessageBox.Show("Debe Ingresar los siguientes datos: Producto, Proveedor, No. Parte, Aplicación, Proveedor",
                                "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "Productos y Servicios":
                        business.InsertProductoServicio(txtPSProducto.Text, chkEsServicio.Checked, txtNoParte.Text, txtPSDescripcion.Text,
                            Convert.ToInt32(cbxProveedor.SelectedValue), Convert.ToDecimal(txtPSPrecioCompra.Text), Convert.ToDecimal(txtPSPrecioPublico.Text));
                        break;
                }
                consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar registro: " + ex.ToString());
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    MessageBoxButtons btnOpciones = MessageBoxButtons.YesNo;
                    DialogResult dr = MessageBox.Show("¿Está seguro que desea " +
                        "eliminar el registro?", "Eliminación",
                        btnOpciones, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        business = new ProductosProveedoresBus();
                        switch (cbxProducto.Text)
                        {
                            case "Productos y Servicios":
                                business.DeleteProductoServicio(Convert.ToInt32(txtId.Text));
                                break;
                            case "Clutch":
                                business.DeleteClutch(Convert.ToInt32(txtId.Text));
                                break;
                            case "Balatas":
                                business.DeleteBalatas(Convert.ToInt32(txtId.Text));
                                break;
                        }
                        consultar();
                    }
                }
                else
                {
                    MessageBox.Show("Debe Ingresar los siguientes datos: Id",
                        "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar registro: " + ex.ToString());
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                business = new ProductosProveedoresBus();
                switch (cbxProducto.Text)
                {
                    case "Productos y Servicios":
                        if (true)
                        {
                            business.UpdateProductoServicio(Convert.ToInt32(txtId.Text),txtPSProducto.Text,chkEsServicio.Checked,txtNoParte.Text,txtPSDescripcion.Text, 
                                Convert.ToInt32(cbxProveedor.SelectedValue),Convert.ToDecimal(txtPSPrecioCompra.Text),Convert.ToDecimal( txtPSPrecioPublico.Text) );
                        }
                        else
                        {
                            MessageBox.Show("Debe Ingresar los siguientes datos: Id, Producto, Proveedor, No. Parte, Aplicación",
                                "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;

                    case "Clutch":
                        if (true)
                        {
                            business.UpdateClutch(Convert.ToInt32(txtId.Text), txtClutchAplicacion.Text, Convert.ToInt32(cbxProveedor.SelectedValue), txtNoParte.Text,
                                txtClutchProducto.Text, txtClutchLuk.Text, txtClutchSach.Text, txtClutch3L.Text, txtClutchExedy.Text,
                                txtClutchValeo.Text, txtClutchAisin.Text, Convert.ToDecimal(txtClutchPrecioCompra.Text),
                                Convert.ToDecimal(txtClutchPrecioPublico.Text));
                        }
                        else
                        {
                            MessageBox.Show("Debe Ingresar los siguientes datos: Id, Producto, Proveedor, No. Parte, Aplicación, Proveedor",
                                "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;

                    case "Balatas":
                        if (!string.IsNullOrEmpty(txtId.Text) &&
                            !string.IsNullOrEmpty(cbxProveedor.Text) &&
                            !string.IsNullOrEmpty(txtNoParte.Text) &&
                            !string.IsNullOrEmpty(txtBalatasMarca.Text) &&
                            !string.IsNullOrEmpty(txtBalatasPosicion.Text))
                        {
                            business.UpdateBalatas(Convert.ToInt32(txtId.Text), Convert.ToInt32(cbxProveedor.SelectedValue), txtNoParte.Text, txtBalatasMarca.Text, txtBalatasPosicion.Text, chkBalatasAbutmen.Checked,
                            txtBalatasAplicacion.Text, txtBalatasModelo.Text, txtBalatasFormula.Text, Convert.ToDecimal(txtPrecioPublico.Text), txtBalatasObservacion.Text);
                        }
                        else
                        {
                            MessageBox.Show("Debe Ingresar los siguientes datos: Id, Producto, Proveedor, No. Parte, Aplicación",
                                "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                }
                consultar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar registro: " + ex.ToString());
            }
        }

        private void dgvProductosProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvProductosProveedores.CurrentCell.RowIndex;
            txtId.Text = dgvProductosProveedores.Rows[row].Cells["ID"].Value.ToString();
            //cbxProveedor.SelectedValue = dgvProductosProveedores.Rows[row].Cells["ID_PROVEEDOR"].Value.ToString();
            //cbxProveedor.SelectedValue = cbxProveedor.SelectedValue;
            txtNoParte.Text = dgvProductosProveedores.Rows[row].Cells["NUMERO_PARTE"].Value.ToString();

            switch (cbxProducto.Text.ToUpper())
            {

                case "PRODUCTOS Y SERVICIOS":
                    chkEsServicio.Checked = Convert.ToBoolean(dgvProductosProveedores.Rows[row].Cells["ES_SERVICIO"].Value.ToString());
                    txtPSProducto.Text = dgvProductosProveedores.Rows[row].Cells["PRODUCTO"].Value.ToString();
                    txtPSDescripcion.Text = dgvProductosProveedores.Rows[row].Cells["DESCRIPCION"].Value.ToString();
                    txtPSPrecioCompra.Text = dgvProductosProveedores.Rows[row].Cells["PRECIO_COMPRA"].Value.ToString();
                    txtPSPrecioPublico.Text = dgvProductosProveedores.Rows[row].Cells["PRECIO_PUBLICO"].Value.ToString();
                    break;

                case "CLUTCH":
                    txtClutchAplicacion.Text = dgvProductosProveedores.Rows[row].Cells["APLICACION"].Value.ToString();
                    txtClutchProducto.Text = dgvProductosProveedores.Rows[row].Cells["PRODUCTO"].Value.ToString();
                    txtClutchLuk.Text = dgvProductosProveedores.Rows[row].Cells["EQUIVALENCIA_LUK"].Value.ToString();
                    txtClutchSach.Text = dgvProductosProveedores.Rows[row].Cells["EQUIVALENCIA_SACHS"].Value.ToString();
                    txtClutch3L.Text = dgvProductosProveedores.Rows[row].Cells["EQUIVALENCIA_3L_ORIGINAL"].Value.ToString();
                    txtClutchExedy.Text = dgvProductosProveedores.Rows[row].Cells["EQUIVALENCIA_EXEDY"].Value.ToString();
                    txtClutchValeo.Text = dgvProductosProveedores.Rows[row].Cells["EQUIVALENCIA_VALEO"].Value.ToString();
                    txtClutchAisin.Text = dgvProductosProveedores.Rows[row].Cells["EQUIVALENCIA_AISIN"].Value.ToString();
                    txtClutchPrecioCompra.Text = dgvProductosProveedores.Rows[row].Cells["PRECIO_COMPRA"].Value.ToString();
                    txtClutchPrecioPublico.Text = dgvProductosProveedores.Rows[row].Cells["PRECIO_PUBLICO"].Value.ToString();
                    break;
                case "BALATAS":
                    txtBalatasMarca.Text = dgvProductosProveedores.Rows[row].Cells["MARCA"].Value.ToString();
                    txtBalatasPosicion.Text = dgvProductosProveedores.Rows[row].Cells["POSICION"].Value.ToString();
                    txtBalatasObservacion.Text = dgvProductosProveedores.Rows[row].Cells["OBSERVACIONES"].Value.ToString();
                    chkBalatasAbutmen.Checked = Convert.ToBoolean(dgvProductosProveedores.Rows[row].Cells["ABUTMEN"].Value.ToString());
                    txtBalatasAplicacion.Text = dgvProductosProveedores.Rows[row].Cells["APLICACION"].Value.ToString();
                    txtBalatasModelo.Text = dgvProductosProveedores.Rows[row].Cells["MODELO"].Value.ToString();
                    txtBalatasFormula.Text = dgvProductosProveedores.Rows[row].Cells["FORMULA"].Value.ToString();
                    txtPrecioPublico.Text = dgvProductosProveedores.Rows[row].Cells["PRECIO_PUBLICO"].Value.ToString();
                    break;
            }
            btnModificar.Visible = true;
            btnEliminar.Visible = true;
        }


        public void filtro()
        {

            string param1="", param2="";

            switch (cbxProducto.Text)
            {
                case "Balatas":
                    param1 = txtBalatasMarca.Text;
                    param2 = txtBalatasPosicion.Text;
                    break;
            }


                    int total = 0;
            if (txtNoParte.Text != "" || param1 != "" || param2 != "")
            {
                dgvProductosProveedores.CurrentCell = null;
                int i = 1;
                DataGridView dgv = dgvProductosProveedores;
                foreach (DataGridViewRow row in dgvProductosProveedores.Rows)
                {
                    if (i <= dgvProductosProveedores.Rows.Count)
                    {
                        row.Visible = false;
                    }
                    i++;
                }
                i = 1;
                foreach (DataGridViewRow row in dgvProductosProveedores.Rows)
                {
                    if (i <= dgvProductosProveedores.Rows.Count)
                    {
                        bool noParte = (row.Cells[2].Value.ToString().ToUpper()).Contains(txtNoParte.Text.ToUpper())
                            && txtNoParte.Text != "";
                        bool nombre = (row.Cells[3].Value.ToString().ToUpper()).Contains(param1.ToUpper())
                            && param1 != "";
                        bool rfc = (row.Cells[4].Value.ToString().ToUpper()).Contains(param2.ToUpper())
                            && param2 != "";

                        if (noParte||nombre || rfc)
                        {
                            row.Visible = true;
                            total++;
                        }
                    }
                    i++;
                }
                lblRegistros.Text = "Total de Registros: " + total;
            }
            else
            {
                consultar();
            }
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
        }

        private void txt8_TextChanged(object sender, EventArgs e)
        {
            if(cbxProducto.Text== "Balatas")
            {
                filtro();
            }
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

            if (cbxProducto.Text == "Balatas")
            {
                filtro();
            }
        }

        private void txtNoParte_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }
        bool inicio = true;
        private void cbxProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!inicio)
            {
                consultar();
            }
        }
        private frmComprasProveedor formComprasProveedor;
        public void definirHijo(frmComprasProveedor form)
        {
            formComprasProveedor = form;
        }
        private frmComprasDia formComprasDia;
        public void definirHijo(frmComprasDia form)
        {
            formComprasDia = form;
        }

        private void frmProductosProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formComprasProveedor != null)
            {
                formComprasProveedor.cargarProductos();
            }
            else if (formComprasDia != null)
            {
                formComprasDia.cargarProveedores();
                formComprasDia.cargarProductos();

            }

            //if(Ingreso!=null)
            //{
            //    Ingreso.cargarProductos();
            //}
        }

        private void tcDatos_SelectedIndexChanged(object sender, EventArgs e)
        {
            tcDatos.SelectedTab = tcDatos.TabPages[idControles];
        }

        private void pbxActualizar_Click(object sender, EventArgs e)
        {
            consultar();
        }

        #region Traer Al rente

        private void frmProductosProveedores_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
        }
        #endregion

        private void dgvProductosProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selecProducto)
            {
                string columna = dgvProductosProveedores.Columns[e.ColumnIndex].Name;
                if (columna == "NUMERO_PARTE")
                {
                    int idRow = dgvProductosProveedores.CurrentCell.RowIndex;
                    string noParte = dgvProductosProveedores.Rows[idRow].Cells["NUMERO_PARTE"].Value.ToString();
                    string precioUni = dgvProductosProveedores.Rows[idRow].Cells["PRECIO_PUBLICO"].Value.ToString();
                    Ingreso.cargarProducoServicio(noParte, precioUni);
                    this.Close();

                }
            }
        }

        private void chkEsServicio_CheckedChanged(object sender, EventArgs e)
        {
            txtPSPrecioCompra.Enabled = chkEsServicio.Checked;
        }
    }
}
