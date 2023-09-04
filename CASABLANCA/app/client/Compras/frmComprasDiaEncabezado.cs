using CASABLANCA.app.business;
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
    public partial class frmComprasDiaEncabezado : Form
    {
        ComprasDiaBus business = new ComprasDiaBus();
        public frmComprasDiaEncabezado()
        {
            InitializeComponent();
        }

        mainWindows mainWindows;
        public frmComprasDiaEncabezado(mainWindows form)
        {
            mainWindows = form;
            InitializeComponent();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.Close();
            frmComprasDia frm = new frmComprasDia(mainWindows);
            mainWindows.abrirForm(frm, Global.Ventana._2_4);
        }

        private void frmComprasDiaEncabezado_Load(object sender, EventArgs e)
        {
            dgvEncabezados.DataSource = business.GetComprasDia();
            DataGridViewImageColumn dgvImage = new DataGridViewImageColumn();
            dgvImage.HeaderText = "Eliminar"; 
            dgvImage.Name = "eliminar";
            dgvEncabezados.Columns.Add(dgvImage);

            lblRegistros.Text = "Total de Registros: " + dgvEncabezados.RowCount.ToString();
        }

        private void dgvEncabezados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string columna = dgvEncabezados.Columns[e.ColumnIndex].Name;
            if (columna != "eliminar")
            {
                frmComprasDia comprasDia = new frmComprasDia(mainWindows);
                int row = dgvEncabezados.CurrentCell.RowIndex;
                comprasDia.cargarEncabezado(dgvEncabezados.Rows[row]);
                mainWindows.abrirForm(comprasDia, Global.Ventana._2_4);
                this.Close();
            }

        }

        private void dgvEncabezados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columna = dgvEncabezados.Columns[e.ColumnIndex].Name;
            if (columna == "eliminar")
            {
                MessageBoxButtons btnOpciones = MessageBoxButtons.YesNo;
                DialogResult dr = MessageBox.Show("¿Está seguro que desea " +
                    "eliminar el registro?", "Eliminación",
                    btnOpciones, MessageBoxIcon.Warning);


                if (dr == DialogResult.Yes)
                {
                    int row = dgvEncabezados.CurrentCell.RowIndex;
                    business.deleteComprasDia(Convert.ToInt32(dgvEncabezados.Rows[row].Cells[1].Value.ToString()));
                    business.deleteRegistrComprasDia(dgvEncabezados.Rows[row].Cells[1].Value.ToString());
                    dgvEncabezados.Rows.Remove(dgvEncabezados.Rows[row]);
                }
            }
        }
        #region Traer Al Frente
        private void frmComprasDiaEncabezado_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
        }
        #endregion
    }
}
