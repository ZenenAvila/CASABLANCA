
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
    public partial class frmComprasProveedor : Form
    {
        comprasProveedorBus bussProveedor = new comprasProveedorBus();
        DataTable dtbproveedores, dtProductos;

        public frmComprasProveedor()
        {
            InitializeComponent();
        }

        private void cargarDgv()
        {

            //columna.ColumnName = "NoParte";
            //dtbproveedores.Columns.Add(columna);
            //dgvProveedores.Columns["NoParte"].HeaderText = "NO. PARTE";
            //dgvProveedores.Columns["NoParte"].ReadOnly = true;

            //columna.ColumnName = "Marca";
            //dtbproveedores.Columns.Add(columna);
            //dgvProveedores.Columns["Marca"].HeaderText = "MARCA";
            //dgvProveedores.Columns["Marca"].ReadOnly = true;

            //dgvProductos.columnsco = 5;
            //DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
            //columna.HeaderText = "ID";
            //columna.Name = "Id";
            //columna.ReadOnly = true;
            //columna.Width = 200;
            //this.dtbproveedores.Columns.Add(columna);

        }

        private void frmComprasProveedor_Load(object sender, EventArgs e)
        {
            cargarProveedores();

            cbxProveedores.BackColor = Color.FromArgb(147, 190, 30);
            //txtDireccion.BackColor = Color.FromArgb(147, 190, 30);
            //txtDireccion.BorderStyle = BorderStyle.None;
            //txtCorreo.BackColor = Color.FromArgb(147, 190, 30);
            //txtCorreo.BorderStyle = BorderStyle.None;
            //txtTelefono.BackColor = Color.FromArgb(147, 190, 30);
            //txtTelefono.BorderStyle = BorderStyle.None;
            //txtRfc.BackColor = Color.FromArgb(147, 190, 30);
            //txtRfc.BorderStyle = BorderStyle.None;
            cbxProductos.BackColor = Color.FromArgb(147, 190, 30);

            cargarDgv();
        }

        public void cargarProveedores(int i=-1)
        {
            dtbproveedores = bussProveedor.GetProveedores();
            cbxProveedores.DataSource = dtbproveedores;
            cbxProveedores.ValueMember = "ID";
            cbxProveedores.DisplayMember = "NOMBRE";
            cbxProveedores.Refresh();
            if (i != -1)
            {
                cbxProveedores.SelectedValue = i;
            }
        }

        public void cargarProductos()
        {
            dtProductos = bussProveedor.GetServProdProv(Convert.ToInt32(cbxProveedores.SelectedValue));
            
            cbxProductos.Text = "";
            cbxProductos.DataSource = dtProductos;
            cbxProductos.ValueMember = "ID";
            cbxProductos.DisplayMember = "NOMBRE";
            cbxProductos.Refresh();

            if(dtProductos.Rows.Count>0)
            {
                cbxProductos.SelectedIndex = 0;
            }

        }
        DataRow datosProveedor;
        int i = 0;
        bool banInicio = false;

        private void cbxProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow proveedor in dtbproveedores.Rows)
            {
                if (proveedor["ID"].ToString() == cbxProveedores.SelectedValue.ToString())
                {
                    datosProveedor = proveedor;
                    cargarDatos();

                    if (banInicio)
                    {
                        cargarProductos();
                    }
                    banInicio = true;

                    //DataTable dt = new DataTable();
                    //dgvProductos.DataSource = dt;
                    //dgvProveedores.DataSource = dt;
                }
            }
            i++;
            if (i > 3)
            {
                cbxProveedores.Enabled = false;
                btnProveedores.Visible = false;
            }
        }

        private void cargarDatos()
        {

            //txtRfc.Text = datosProveedor[2].ToString();
            //txtDireccion.Text = datosProveedor[3].ToString();
            //txtTelefono.Text = datosProveedor[4].ToString();
            //txtCorreo.Text = datosProveedor[5].ToString();
        }

        private IMainWindows _mainWindows;
        private mainWindows mainWindows;

        public frmComprasProveedor(mainWindows form)
        {
            InitializeComponent();
            _mainWindows = form;
            mainWindows = form;
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            //main.smiAutos_Click(this,new EventArgs());
            //_mainWindows.abrirProveedor();
            frmProveedores formProveedores = new frmProveedores();
            mainWindows.abrirForm(formProveedores);
            formProveedores.definirHijo(this);

            formProveedores.Text = "Prueba";
            //cargarProveedores();

        }

        private void pbxProductos_Click(object sender, EventArgs e)
        {
            frmProductosProveedores formProvServ = new frmProductosProveedores();
            mainWindows.abrirForm(formProvServ, Global.Ventana._3_2);
            formProvServ.definirHijo(this);

            formProvServ.Text = "Prueba";


            formProvServ.cargarProveedores(Convert.ToInt32(cbxProveedores.SelectedValue));
            formProvServ.cbxProveedor.Enabled = false;

            if (cbxProductos.SelectedValue != null)
                formProvServ.cbxProducto.SelectedValue = cbxProductos.SelectedValue;
                formProvServ.cbxProveedor.Enabled = false;
        }

        private void cbxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            consultarProductos();
        }

        public void consultarProductos()
        {
            switch (cbxProductos.Text)
            {
                case "Balatas":
                    if (cbxProveedores.SelectedValue != null)
                    {
                        dgvProductos.DataSource = bussProveedor.GetBalatas(Convert.ToInt32(cbxProveedores.SelectedValue.ToString()));
                    }
                    break;
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            cargarDatos();
        }

        private void dgvProductos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvProductos.CurrentCell.RowIndex;
            string id = dgvProductos.Rows[row].Cells[0].Value.ToString(),
                   noParte= dgvProductos.Rows[row].Cells[2].Value.ToString(),
                   marca= dgvProductos.Rows[row].Cells[3].Value.ToString(),
                   pUnitario= dgvProductos.Rows[row].Cells[10].Value.ToString();

            bool banExist = false;
            
            foreach (DataGridViewRow fila in dgvElementos.Rows)
            {
                if (id == fila.Cells[0].Value.ToString() && noParte == fila.Cells[1].Value.ToString())
                {
                    banExist = true;
                }
            }
            if(!banExist)
            dgvElementos.Rows.Add(id, noParte, marca,pUnitario);

        }

        private void cbxProveedores_BindingContextChanged(object sender, EventArgs e)
        {
            //cargarProductos();
        }

        private void pcbBorrar_Click(object sender, EventArgs e)
        {
            cbxProveedores.Enabled = true;
            btnProveedores.Visible = true;
            cbxProductos.DataSource = null;
            cbxProductos.Items.Clear();
            dgvProductos.DataSource = null;
            dgvProductos.Columns.Clear();
            dgvElementos.DataSource = null;
            dgvElementos.Rows.Clear();

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
