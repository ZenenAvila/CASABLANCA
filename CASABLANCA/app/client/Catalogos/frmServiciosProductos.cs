using CASABLANCA.app.business;
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
    public partial class frmServiciosProductos : Form
    {
        ServiciosProductosBUS business = new ServiciosProductosBUS();

        #region Controles
        public frmServiciosProductos()
        {
            InitializeComponent();
        }

        private void frmServiciosProductos_Load(object sender, EventArgs e)
        {
            consultar();
        }

        private void frmServiciosProductos_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void frmServiciosProductos_Move(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtPU.Text))
            {
                try
                {
                    business.Insert(txtCodigo.Text, txtNombre.Text, Convert.ToDecimal(txtPU.Text));
                    consultar();
                    limpiarDatos();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error al guardar registro: "+ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe Ingresar los siguientes datos: Codigo, Nombre, Precio", "Datos Faltantes",
                         MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtId.Text) && !string.IsNullOrEmpty(txtCodigo.Text) && !string.IsNullOrEmpty(txtNombre.Text) && !string.IsNullOrEmpty(txtPU.Text))
            {
                try
                {
                    business.Update(Convert.ToInt32(txtId.Text), txtCodigo.Text, txtNombre.Text, Convert.ToDecimal(txtPU.Text));
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
                MessageBox.Show("Debe Ingresar los siguientes datos: Id, Codigo, Nombre, Precio", "Datos Faltantes",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        btnOpciones, MessageBoxIcon.Question);

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

        private void dgvPys_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblAnchoCeldas.Text = "Id: " + dgvPys.Columns[0].Width.ToString() +
                ", Codigo: " + dgvPys.Columns[1].Width.ToString() +
                ", Nombre: " + dgvPys.Columns[2].Width.ToString() +
                ", Precio: " + dgvPys.Columns[3].Width.ToString();
        }

        private void dgvPys_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = dgvPys.CurrentCell.RowIndex;
            txtId.Text = dgvPys.Rows[row].Cells[0].Value.ToString();
            txtCodigo.Text = dgvPys.Rows[row].Cells[1].Value.ToString();
            txtNombre.Text = dgvPys.Rows[row].Cells[2].Value.ToString();
            txtPU.Text = dgvPys.Rows[row].Cells[3].Value.ToString();


            btnModificar.Visible = true;
            btnEliminar.Visible = true;
        }
        #endregion

        #region Metodos Generales
        public void consultar()
        {
            try
            {
                dgvPys.DataSource = business.Get();
                dgvPys.Refresh();

                dgvPys.Columns[0].Width = 35;
                dgvPys.Columns[1].Width = 162;
                dgvPys.Columns[2].Width = 270;
                dgvPys.Columns[3].Width = 73;

                lblRegistros.Text = "Total de Registros: " + dgvPys.Rows.Count;
                
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
            txtCodigo.Clear();
            txtNombre.Clear();
            txtPU.Clear();
        }

        public void filtro()
        {
            int total = 0;
            if (txtNombre.Text != "" || txtCodigo.Text != "")
            {
                dgvPys.CurrentCell = null;
                int i = 1;
                foreach (DataGridViewRow row in dgvPys.Rows)
                {
                    if (i <= dgvPys.Rows.Count)
                    {
                        row.Visible = false;
                    }
                    i++;
                }
                i = 1;
                foreach (DataGridViewRow row in dgvPys.Rows)
                {
                    if (i <= dgvPys.Rows.Count)
                    {
                        bool nombre = (row.Cells[2].Value.ToString().ToUpper()).Contains(txtNombre.Text.ToUpper())
                            && txtNombre.Text != "";
                        bool codigo = (row.Cells[1].Value.ToString().ToUpper()).Contains(txtCodigo.Text.ToUpper())
                            && txtCodigo.Text != "";

                        if (nombre || codigo)
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
        #endregion
    }
}
