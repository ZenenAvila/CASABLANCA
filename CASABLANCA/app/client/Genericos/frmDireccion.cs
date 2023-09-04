using CASABLANCA.app.business;
using CASABLANCA.app.client.Catalogos;
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

namespace CASABLANCA.app.client.Genericos
{
    public partial class frmDireccion : Form
    {
        DireccionesBus business = new DireccionesBus();
        int idCliente,
            idDireccion=0;

        frmClientes Clientes;

        public frmDireccion()
        {
            InitializeComponent();
        }
        public frmDireccion(int _idCliente)
        {
            InitializeComponent();
            idCliente = _idCliente;
        }
        public frmDireccion(int _idCliente, frmClientes clientes)
        {

            InitializeComponent();
            idCliente = _idCliente;
            Clientes = clientes;
        }

        private void frmDireccion_Load(object sender, EventArgs e)
        {

            //MessageBox.Show("Heigth: " + this.Height + " Width " + this.Width);
            cargarDireccion();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (idDireccion == 0)
            {
                business.InsertDireccion(cbxPais.Text, cbxEstado.Text, cbxMunicipio.Text,
                    txtCiudad.Text, txtColonia.Text, txtCP.Text, txtCalle.Text,
                    txtNoExterior.Text, txtNoInterior.Text, idCliente);
            }
            else
            {

                business.UpdateDireccion(idDireccion,cbxPais.Text, cbxEstado.Text, cbxMunicipio.Text,
                    txtCiudad.Text, txtColonia.Text, txtCP.Text, txtCalle.Text,
                    txtNoExterior.Text, txtNoInterior.Text, idCliente);
            }
            cargarDireccion();
        }

        private void frmDireccion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(Clientes!=null)
            {
                Clientes.cargarDireccion();
            }
        }

        private void cargarDireccion()
        {
            DataTable dtDireccion = business.GetDireciones(idCliente);

            if (dtDireccion.Rows.Count > 0)
            {
                btnAgregar.Text = "Modificar";
                idDireccion = Convert.ToInt32(dtDireccion.Rows[0]["ID"].ToString());
                cbxPais.Text = dtDireccion.Rows[0]["PAIS"].ToString();
                cbxEstado.Text = dtDireccion.Rows[0]["ESTADO"].ToString();
                cbxMunicipio.Text = dtDireccion.Rows[0]["MUNICIPIO"].ToString();
                txtCiudad.Text = dtDireccion.Rows[0]["CIUDAD"].ToString();
                txtColonia.Text = dtDireccion.Rows[0]["COLONIA"].ToString();
                txtCP.Text = dtDireccion.Rows[0]["CODIGO_POSTAL"].ToString();
                txtCalle.Text = dtDireccion.Rows[0]["CALLE"].ToString();
                txtNoExterior.Text = dtDireccion.Rows[0]["NO_EXTERIOR"].ToString();
                txtNoInterior.Text = dtDireccion.Rows[0]["NO_INTERIOR"].ToString();
            }
        }

        #region Traer Al Frente
        private void frmDireccion_Enter(object sender, EventArgs e)
        {
            this.BringToFront();
        }
        #endregion
    }
}
