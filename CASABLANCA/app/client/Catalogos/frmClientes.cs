using CASABLANCA.app.business;
using CASABLANCA.app.client.Genericos;
using CASABLANCA.app.client.Ingreso;
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

namespace CASABLANCA.app.client.Catalogos
{
    public partial class frmClientes : Form
    {
        ClientesBus business = new ClientesBus();
        DireccionesBus DireccionBus = new DireccionesBus();
        private mainWindows mainWindows;
        frmIngreso Ingreso;
        public frmClientes(mainWindows form)
        {
            InitializeComponent();
            mainWindows = form;
        }
        public frmClientes(mainWindows form,frmIngreso ingreso)
        {
            InitializeComponent();
            mainWindows = form;
            Ingreso = ingreso;
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Heigth: " + this.Height + " Width " + this.Width);
            cargarClientes();
        }

        private void cargarClientes()
        {
            dgvClientes.DataSource = business.GetClientes();
            dgvClientes.Refresh();
        }

        public void cargarDireccion()
        {
            cbxDireccion.Items.Clear();
            DataTable dtDirecciones = DireccionBus.GetDireciones(Convert.ToInt32(txtID.Text));
            if (dtDirecciones.Rows.Count > 0)
            {
                foreach (DataRow row in dtDirecciones.Rows)
                {
                    cbxDireccion.Items.Add("Col. " + row["COLONIA"] +
                        ", Calle " + row["CALLE"] +
                        ", No. Ext. " + row["NO_EXTERIOR"]);
                }
            }
        }

        private void pbxAgregarDireccion_Click(object sender, EventArgs e)
        {
            if(txtID.Text!="")
                {
                frmDireccion direccion = new frmDireccion(Convert.ToInt32(txtID.Text),this);
                mainWindows.abrirForm(direccion, Global.Ventana._1_2);
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Cliente.");
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            business.InsertCliente(txtNombre.Text,txtCorreo.Text,txtCFDI.Text,txtRfc.Text,txtCP.Text,
                txtCalle.Text,txtMunicipio.Text,txtEstado.Text);
            cargarClientes();
        }
        int row = 0;
        private void dgvClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            row = dgvClientes.CurrentCell.RowIndex;
            txtID.Text = dgvClientes.Rows[row].Cells[0].Value.ToString();
            txtNombre.Text = dgvClientes.Rows[row].Cells[1].Value.ToString();
            txtCorreo.Text = dgvClientes.Rows[row].Cells[2].Value.ToString();
            txtCFDI.Text = dgvClientes.Rows[row].Cells[3].Value.ToString();
            txtRfc.Text = dgvClientes.Rows[row].Cells[4].Value.ToString();
            txtCP.Text = dgvClientes.Rows[row].Cells[5].Value.ToString();
            txtCalle.Text = dgvClientes.Rows[row].Cells[6].Value.ToString();
            txtMunicipio.Text = dgvClientes.Rows[row].Cells[7].Value.ToString();
            txtEstado.Text = dgvClientes.Rows[row].Cells[8].Value.ToString();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            business.DeleteCliente(Convert.ToInt32(txtID.Text));
            cargarClientes();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            business.UpdateCliente(Convert.ToInt32( txtID.Text),txtNombre.Text,txtCorreo.Text,
                txtCFDI.Text,txtRfc.Text,txtCP.Text,txtCalle.Text,txtMunicipio.Text,txtEstado.Text);
            cargarClientes();
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            cargarDireccion();
        }

        private void frmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Ingreso != null)
            {
                Ingreso.cargarClientes();
            }
        }

        #region Traer Al Frente
        private void frmClientes_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
        }
        #endregion
    }
}
