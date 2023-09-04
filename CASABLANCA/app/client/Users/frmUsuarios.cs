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

namespace CASABLANCA.app.client.Users
{
    public partial class frmUsuarios : Form
    {
        UsuariosBus business = new UsuariosBus();
        public frmUsuarios()
        {
            InitializeComponent();
        }

        private void frmUsuarios_Load(object sender, EventArgs e)
        {
            consultarCargo();
            if (userCls.cargo== "SECRETARIO" || userCls.cargo == "RECEPCIONISTA")
            {
                this.Height = 235;
                btnAgregar.Text = "Actualizar";

                lblPass.Visible = true;
                txtPass.Visible = true;
                lblConfPass.Visible = true;
                txtConfPas.Visible = true;
                cbxCargo.Enabled = false;

                txtId.Text = userCls.id.ToString();
                txtUsuario.Text = userCls.user;
                txtNombre.Text = userCls.nombre;
                txtPaterno.Text = userCls.apellidoPaterno;
                txtMaterno.Text = userCls.apellidoMaterno;
                txtCorreo.Text = userCls.email;
                switch (userCls.cargo)
                {
                    case "ADMINISTRADOR":
                        cbxCargo.SelectedIndex = 0;
                        break;
                    case "DESARROLLADOR":
                        cbxCargo.SelectedIndex = 1;
                        break;
                    case "RECEPCIONISTA":
                        cbxCargo.SelectedIndex = 2;
                        break;
                }
            }else
            {
                consultar();

            }

            txtId.Enabled = false;
        }

        private void actualizarDatos()
        {

            if (!string.IsNullOrEmpty(txtUsuario.Text) &&
                !string.IsNullOrEmpty(txtNombre.Text) &&
                !string.IsNullOrEmpty(txtPaterno.Text) &&
                !string.IsNullOrEmpty(txtMaterno.Text) &&
                !string.IsNullOrEmpty(txtCorreo.Text) &&
                !string.IsNullOrEmpty(cbxCargo.Text) &&
                !string.IsNullOrEmpty(txtPass.Text) &&
                !string.IsNullOrEmpty(txtConfPas.Text))
            {
                if (txtPass.Text == txtConfPas.Text)
                {
                    try
                    {
                        business.UpdateUser(Convert.ToInt32(txtId.Text), txtUsuario.Text, txtNombre.Text, txtPaterno.Text,
                            txtMaterno.Text, Convert.ToInt32(cbxCargo.SelectedIndex), txtCorreo.Text, txtPass.Text);
                        txtPass.Clear();
                        txtConfPas.Clear();

                        MessageBox.Show("Datos actualizados correctamente.",
                            "Datos actualizados", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al actualizar el registro: " + ex.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Pass y Conf. Pass no coinciden.",
                        "Pass no coincide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Debe Ingresar los siguientes datos: User, Nombre, Ap.Paterno," +
                    " Ap. Materno, Correo, Cargo, Pass, Conf. Pass",
                    "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (userCls.cargo == "SECRETARIO" || userCls.cargo == "RECEPCIONISTA")
            {
                actualizarDatos();
            }
            else
            {
                btnStatus.Visible = false;
                if (btnAgregar.Text == "Agregar")
                {
                    if (!string.IsNullOrEmpty(txtUsuario.Text) &&
                        !string.IsNullOrEmpty(txtNombre.Text) &&
                        !string.IsNullOrEmpty(txtPaterno.Text) &&
                        !string.IsNullOrEmpty(txtMaterno.Text) &&
                        !string.IsNullOrEmpty(txtCorreo.Text) &&
                        !string.IsNullOrEmpty(cbxCargo.Text))
                    {

                        try
                        {
                            business.CreateUser(txtUsuario.Text, txtNombre.Text,
                                txtPaterno.Text, txtMaterno.Text, Convert.ToInt32(cbxCargo.SelectedIndex),
                                txtCorreo.Text);
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
                        MessageBox.Show("Debe Ingresar los siguientes datos: Usuario, Contraseña, " +
                            "Comp. Contraseña, Nombre, Ap. Paterno, Ap. Materno, Correo, Cargo",
                            "Datos Faltantes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    actualizarDatos();
                    btnAgregar.Text = "Agregar";
                    limpiarDatos();
                }

                string texto = cbxCargo.Text;
                string valor = cbxCargo.SelectedValue.ToString();
            }
        }

        public void consultar()
        {
            try
            {
                dgvUsuarios.DataSource = business.GetAllUser();

                dgvUsuarios.Refresh();

                dgvUsuarios.Columns[1].HeaderText = "USER";
                dgvUsuarios.Columns[3].HeaderText = "PATERNO";
                dgvUsuarios.Columns[4].HeaderText = "MATERNO";
                dgvUsuarios.Columns[0].Frozen = true;
                dgvUsuarios.Columns[1].Frozen = true;
                dgvUsuarios.Columns[2].Frozen = true;

                lblRegistros.Text = "Total de Registros: " + dgvUsuarios.Rows.Count;

                limpiarDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar los datos: " + ex.ToString());
            }
        }

        public void consultarCargo()
        {
            cbxCargo.DataSource = business.GetCargo();
            cbxCargo.ValueMember = "ID";
            cbxCargo.DisplayMember = "CARGO";
            cbxCargo.Refresh();
        }

        public void limpiarDatos()
        {
            txtId.Clear();
            txtUsuario.Clear();
            txtNombre.Clear();
            txtPaterno.Clear();
            txtMaterno.Clear();
            txtCorreo.Clear();

            consultarCargo();
        }

        public void usuario()
        {
            string[] listNombre = txtNombre.Text.Split(' '),
            listPaterno = txtPaterno.Text.Split(' ');
            string nombre = "", paterno = "";
            if (txtNombre.Text.Length > 0)
            {
                nombre = string.IsNullOrEmpty(listNombre[0]) ? listNombre[1].Substring(1, 2) : listNombre[0].Substring(0, 1);
            }
            if (txtPaterno.Text.Length > 0)
            {
                paterno = string.IsNullOrEmpty(listPaterno[0]) ? listPaterno[1] : listPaterno[0];
            }

            txtUsuario.Text = nombre.ToUpper() + paterno.ToUpper();
        }

        private void txtPaterno_KeyUp(object sender, KeyEventArgs e)
        {
            usuario();
        }

        private void dgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int row = dgvUsuarios.CurrentCell.RowIndex;
            txtId.Text = dgvUsuarios.Rows[row].Cells[0].Value.ToString();
            txtUsuario.Text = dgvUsuarios.Rows[row].Cells[1].Value.ToString();
            txtNombre.Text = dgvUsuarios.Rows[row].Cells[2].Value.ToString();
            txtPaterno.Text = dgvUsuarios.Rows[row].Cells[3].Value.ToString();
            txtMaterno.Text = dgvUsuarios.Rows[row].Cells[4].Value.ToString();
            txtCorreo.Text = dgvUsuarios.Rows[row].Cells[6].Value.ToString();

            switch (dgvUsuarios.Rows[row].Cells[5].Value.ToString())
            {
                case "ADMINISTRADOR":
                    cbxCargo.SelectedIndex = 0;
                    break;
                case "DESARROLLADOR":
                    cbxCargo.SelectedIndex = 1;
                    break;
                case "RECEPCIONISTA":
                    cbxCargo.SelectedIndex = 2;
                    break;
            }

            btnStatus.Text = Convert.ToBoolean(dgvUsuarios.Rows[row].Cells[7].Value) ? "Desactivar" : "Activar";
            btnStatus.Visible = true;


            if (txtUsuario.Text==userCls.user)
            {

                btnStatus.Visible = false;
                btnAgregar.Text = "Actualizar";

                lblPass.Visible = true;
                txtPass.Visible = true;
                lblConfPass.Visible = true;
                txtConfPas.Visible = true;
                cbxCargo.Enabled = false;

            }
            else
            {
                btnStatus.Visible = true;
                btnAgregar.Text = "Agregar";

                lblPass.Visible = false;
                txtPass.Visible = false;
                lblConfPass.Visible = false;
                txtConfPas.Visible = false;
                cbxCargo.Enabled = false;
            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            btnStatus.Visible = false;
            business.ChangeStatusUser(Convert.ToInt32(txtId.Text),btnStatus.Text== "Activar"?1:0);
            limpiarDatos();
            consultar();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
