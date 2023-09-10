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

namespace CASABLANCA.app.client.Ingreso
{
    public partial class frmIngresoEncabezado : Form
    {
        IngresoBus business = new IngresoBus();
        int IdCliente;
        frmIngreso Padre;
        public frmIngresoEncabezado(int idCliente, frmIngreso padre)
        {
            InitializeComponent();
            IdCliente = idCliente;
            Padre = padre;
        }

        private void frmIngresoEncabezado_Load(object sender, EventArgs e)
        {
            dgvEncabezados.DataSource = business.GetIngresosCliente(IdCliente);
            DataGridViewImageColumn dgvImage = new DataGridViewImageColumn();
            dgvImage.HeaderText = "Eliminar";
            dgvImage.Name = "eliminar";
            dgvEncabezados.Columns.Add(dgvImage);
            lblRegistros.Text = "Total de Registros: " + dgvEncabezados.RowCount;
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
                    business.DeleteIngreso(Convert.ToInt32(dgvEncabezados.Rows[row].Cells[1].Value.ToString()));
                    business.DeleteIngresoRegistros(Convert.ToInt32(dgvEncabezados.Rows[row].Cells[1].Value.ToString()));
                    dgvEncabezados.Rows.Remove(dgvEncabezados.Rows[row]);
                    lblRegistros.Text = "Total de Registros: " + dgvEncabezados.RowCount;
                }
            }
        }

        private void dgvEncabezados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string columna = dgvEncabezados.Columns[e.ColumnIndex].Name;
            if (columna != "eliminar")
            {
                int row = dgvEncabezados.CurrentCell.RowIndex;
                Padre.cargarIngreso(dgvEncabezados.Rows[row].Cells[1].Value.ToString());
                this.Close();
            }
        }

        private void frmIngresoEncabezado_FormClosing(object sender, FormClosingEventArgs e)
        {
            Padre.cbxCliente.Enabled = true;
        }

        #region Traer Al Frente
        private void frmIngresoEncabezado_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
        }
        #endregion
    }
}
