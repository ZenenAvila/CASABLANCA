using CASABLANCA.app.business;
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
    public partial class frmAutos : Form
    {
        AutosBus business = new AutosBus();
        public frmAutos()
        {
            InitializeComponent();
        }

        int idCliente;
        public frmAutos(int _idCliente)
        {
            InitializeComponent();
            idCliente = _idCliente;
        }
        frmIngreso frmIngreso;
        public frmAutos(frmIngreso _frmIngreso)
        {
            InitializeComponent();
            frmIngreso = _frmIngreso;
        }

        private void frmAutos_Load(object sender, EventArgs e)
        {
            cargarAutos();
            //MessageBox.Show("Heigth: " + this.Height + " Width " + this.Width);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            business.InsertAuto(txtPlaca.Text,txtMarca.Text,txtModelo.Text,txtNumeroSerie.Text,
                txtColor.Text,Convert.ToInt32(txtKMJ.Text), Convert.ToInt32(frmIngreso.cbxCliente.SelectedValue));
            cargarAutos();
        }

        private void cargarAutos()
        {
            dgvAutos.DataSource = business.GetAutos(Convert.ToInt32(frmIngreso.cbxCliente.SelectedValue));
            dgvAutos.Refresh();
        }
        int row;
        private void dgvAutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = dgvAutos.CurrentCell.RowIndex;
            txtID.Text = dgvAutos.Rows[row].Cells[0].Value.ToString();
            txtPlaca.Text = dgvAutos.Rows[row].Cells[1].Value.ToString();
            txtMarca.Text = dgvAutos.Rows[row].Cells[2].Value.ToString();
            txtModelo.Text = dgvAutos.Rows[row].Cells[3].Value.ToString();
            txtNumeroSerie.Text = dgvAutos.Rows[row].Cells[4].Value.ToString();
            txtColor.Text = dgvAutos.Rows[row].Cells[5].Value.ToString();
            txtKMJ.Text = dgvAutos.Rows[row].Cells[6].Value.ToString();
            btnEliminar.Visible = true;
            btnModificar.Visible = true;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            business.UpdateAuto(Convert.ToInt32(txtID.Text), txtPlaca.Text, txtMarca.Text,txtModelo.Text,txtNumeroSerie.Text,
                txtColor.Text,Convert.ToInt32(txtKMJ.Text));
            cargarAutos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            business.DeleteAuto(Convert.ToInt32(txtID.Text));
            txtID.Text = "";
            txtPlaca.Text = "";
            txtMarca.Text = "";
            txtModelo.Text = "";
            txtNumeroSerie.Text = "";
            txtColor.Text = "";
            txtKMJ.Text = "";
            cargarAutos();
        }

        private void frmAutos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (frmIngreso != null)
            {
                frmIngreso.cargarAutos();
            }
        }
        #region Traer Al Frente
        private void frmAutos_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
        }
        #endregion
    }
}
