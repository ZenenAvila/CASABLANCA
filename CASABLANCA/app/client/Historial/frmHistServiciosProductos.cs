using CASABLANCA.app.business;
using CASABLANCA.app.Commond;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASABLANCA.app.client.Historial
{
    public partial class frmHistServiciosProductos : Form
    {
        HistServiciosProductosBus business = new HistServiciosProductosBus();

        #region Controles
        public frmHistServiciosProductos()
        {
            InitializeComponent();
        }

        private void frmHistServiciosProductos_Load(object sender, EventArgs e)
        {
            consultar();
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            filtro();


        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            filtro();
        }
        private void pbxActualizar_Click(object sender, EventArgs e)
        {
            consultar();
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
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar los datos: " + ex.ToString());
            }
        }
        //public void filtro()
        //{
        //    int total = 0;
        //    if (txtId.Text != "" || txtNombre.Text != "" || txtCodigo.Text != "")
        //    {
        //        dgvPys.CurrentCell = null;
        //        int i = 1;
        //        foreach (DataGridViewRow row in dgvPys.Rows)
        //        {
        //            if (i < dgvPys.Rows.Count)
        //            {
        //                row.Visible = false;
        //            }
        //            i++;
        //        }
        //        i = 1;
        //        foreach (DataGridViewRow row in dgvPys.Rows)
        //        {
        //            if (i <= dgvPys.Rows.Count)
        //            {
        //                bool id = (row.Cells[0].Value.ToString().ToUpper()).Contains(txtId.Text.ToUpper())
        //                    && txtId.Text != "";
        //                bool nombre = (row.Cells[2].Value.ToString().ToUpper()).Contains(txtNombre.Text.ToUpper())
        //                    && txtNombre.Text != "";
        //                bool codigo = (row.Cells[1].Value.ToString().ToUpper()).Contains(txtCodigo.Text.ToUpper())
        //                    && txtCodigo.Text != "";

        //                if (id || nombre || codigo)
        //                {
        //                    row.Visible = true;
        //                    total++;
        //                }
        //            }
        //            i++;
        //        }
        //        lblRegistros.Text = "Total de Registros: " + total;
        //    }
        //    else
        //    {
        //        consultar();
        //    }
        //}
        public void filtro()
        {
            if (txtId.Text != "" || txtNombre.Text != "" || txtCodigo.Text != "")
            {
                List<Methods> busqueda = new List<Methods>();
                busqueda.Add(new Methods { texto = txtCodigo.Text, celda = 2 });
                busqueda.Add(new Methods { texto = txtId.Text, celda = 0 });
                Methods metodo = new Methods();
                metodo.filtrarDGV(dgvPys, busqueda,lblRegistros);
                
            }
            else
            {
                consultar();
            }
        }
        #endregion

        #region Traer Al Frente
        private void frmHistServiciosProductos_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
        }
        #endregion
    }
}
