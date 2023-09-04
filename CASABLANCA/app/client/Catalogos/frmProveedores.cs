using CASABLANCA.app.business;
using CASABLANCA.app.client.Compras;
using CASABLANCA.app.client.Ingreso;
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
    public partial class frmProveedores : Form
    {
        ProveedoresBus business = new ProveedoresBus();

        frmIngreso Ingreso;

        #region Controles
        public frmProveedores()
        {
            InitializeComponent();
        }

        public frmProveedores(frmIngreso _ingreso) 
        {
            InitializeComponent();
            Ingreso = _ingreso;
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {
            consultar();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void txtRfc_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtRfc.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text) &&
                !string.IsNullOrEmpty(txtCorreo.Text))
            {
                try
                {
                    business.Insert(txtNombre.Text, txtRfc.Text, txtDireccion.Text,
                        txtTelefono.Text, txtCorreo.Text);
                    consultar();
                    limpiarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar registro: " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe Ingresar los siguientes datos: Nombre, RFC, Direccion, Telefono, Correo",
                    "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtRfc.Text) &&
                !string.IsNullOrEmpty(txtDireccion.Text) &&
                !string.IsNullOrEmpty(txtTelefono.Text) &&
                !string.IsNullOrEmpty(txtCorreo.Text))
            {
                try
                {
                    business.Update(Convert.ToInt32(txtId.Text), txtNombre.Text, txtRfc.Text,
                        txtDireccion.Text, txtTelefono.Text, txtCorreo.Text);
                    consultar();

                    limpiarDatos();
                    btnModificar.Visible = false;
                    btnEliminar.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar el registro: " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe Ingresar los siguientes datos: Id, Nombre, RFC, Direccion, Telefono, Correo",
                    "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text))
            {
                try
                {
                    MessageBoxButtons btnOpciones = MessageBoxButtons.YesNo;
                    DialogResult dr = MessageBox.Show("¿Está seguro que desea " +
                        "eliminar el registro: " + txtNombre.Text + "?", "Eliminación",
                        btnOpciones, MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        business.Delete(Convert.ToInt32(txtId.Text));
                        consultar();

                        limpiarDatos();
                        btnModificar.Visible = false;
                        btnEliminar.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al eliminar el registro: " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe Ingresar los siguientes datos: Id", "Datos Faltantes",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblAnchoCeldas.Text = "Id: " + dgvProveedores.Columns[0].Width.ToString() +
                ", Nombre: " + dgvProveedores.Columns[1].Width.ToString() +
                ", RFC: " + dgvProveedores.Columns[2].Width.ToString() +
                ", Direccion: " + dgvProveedores.Columns[3].Width.ToString() +
                ", Telefono: " + dgvProveedores.Columns[4].Width.ToString() +
                ", Correo: " + dgvProveedores.Columns[4].Width.ToString();
        }

        private void dgvProveedores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvProveedores.CurrentCell.RowIndex;
            txtId.Text = dgvProveedores.Rows[row].Cells[0].Value.ToString();
            
            
                txtNombre.Text = dgvProveedores.Rows[row].Cells[1].Value.ToString();
                txtRfc.Text = dgvProveedores.Rows[row].Cells[2].Value.ToString();
                txtDireccion.Text = dgvProveedores.Rows[row].Cells[3].Value.ToString();
                txtTelefono.Text = dgvProveedores.Rows[row].Cells[4].Value.ToString();
                txtCorreo.Text = dgvProveedores.Rows[row].Cells[5].Value.ToString();
            

            btnModificar.Visible = true;
            btnEliminar.Visible = true;
        }
        #endregion

        #region Metodos Generales

        public void consultar()
        {
            try
            {
                dgvProveedores.DataSource = business.Get();
                dgvProveedores.Refresh();

                //dgvProveedores.Columns[0].Width = 35;
                //dgvProveedores.Columns[1].Width = 162;
                //dgvProveedores.Columns[2].Width = 270;
                //dgvProveedores.Columns[3].Width = 73;

                lblRegistros.Text = "Total de Registros: " + dgvProveedores.Rows.Count;

                limpiarDatos();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar los datos: " + ex.ToString());
            }
        }

        public void limpiarDatos()
        {
            txtId.Clear();
            txtRfc.Clear();
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }

        public void filtro()
        {
            int total = 0;
            if (txtNombre.Text != "" || txtRfc.Text != "")
            {
                dgvProveedores.CurrentCell = null;
                int i = 1;
                foreach (DataGridViewRow row in dgvProveedores.Rows)
                {
                    if (i <= dgvProveedores.Rows.Count)
                    {
                        row.Visible = false;
                    }
                    i++;
                }
                i = 1;
                foreach (DataGridViewRow row in dgvProveedores.Rows)
                {
                    if (i <= dgvProveedores.Rows.Count)
                    {
                        bool nombre = (row.Cells[1].Value.ToString().ToUpper()).Contains(txtNombre.Text.ToUpper())
                            && txtNombre.Text != "";
                        bool rfc = (row.Cells[2].Value.ToString().ToUpper()).Contains(txtRfc.Text.ToUpper())
                            && txtRfc.Text != "";

                        if (nombre || rfc)
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
        private frmComprasProveedor formComprasProveedor;
        public void definirHijo(frmComprasProveedor form)
        {
            formComprasProveedor = form;
        }
        private frmComprasDia formComprasDía;
        public void definirHijo(frmComprasDia form)
        {
            formComprasDía = form;
        }
        #endregion

        private void frmProveedores_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formComprasProveedor != null & !string.IsNullOrEmpty(txtId.Text))
            {
                formComprasProveedor.cargarProveedores(Convert.ToInt32(txtId.Text));
            }
            else if (formComprasDía != null & !string.IsNullOrEmpty(txtId.Text))
            {
                formComprasDía.cargarProveedores(Convert.ToInt32(txtId.Text));
            }

            if(Ingreso!=null)
            {
                Ingreso.cargarProveedores();
            }
        }

        #region Trae Al Frente
        private void frmProveedores_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
        }
        #endregion
    }
}
