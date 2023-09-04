using CASABLANCA.app.business;
using CASABLANCA.app.cls;
using CASABLANCA.app.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASABLANCA.app.client
{
    public partial class login : Form
    {
        LoginBus business = new LoginBus();

        public login()
        {
            InitializeComponent();
        }

        private void pbxMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbxCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.White;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.Gainsboro;
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.White;
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = Color.Gainsboro;
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            if (Global.prod)
            {
                if (txtUsuario.Text != "Usuario" && !string.IsNullOrEmpty(txtUsuario.Text)
                && txtContraseña.Text != "Contraseña" && !string.IsNullOrEmpty(txtContraseña.Text))
                {
                    switch (business.ValidUser(txtUsuario.Text, txtContraseña.Text))
                    {
                        case 0:
                            lblResultado.Visible = true;
                            lblResultado.Text = "Usuario Inexistente";
                            lblResultado.Location = new Point(433, 180);
                            txtContraseña.Clear();
                            break;
                        case 1:
                            lblResultado.Visible = true;
                            lblResultado.Text = "Contraseña Incorrecta";
                            lblResultado.Location = new Point(411, 180);
                            txtContraseña.Clear();
                            break;
                        case 2:
                            business.GetUser(txtUsuario.Text, txtContraseña.Text);
                            app.client.mainWindows main = new app.client.mainWindows();
                            main.Show();
                            this.Hide();
                            break;
                    }
                }
                else
                {
                    lblResultado.Visible = true;
                    lblResultado.Text = "Debe Ingresar un Usuario y Contraseña";
                    lblResultado.Location = new Point(358, 180);
                }
            }
            else
            {
                app.client.mainWindows main = new app.client.mainWindows();
                main.Show();
                this.Hide();
            }
        }
        public void LogOut()
        {
            txtUsuario.Text="Usuario";
            txtContraseña.Text="Contraseña";
            txtUsuario.UseSystemPasswordChar = false;
            lblResultado.Visible = false;
            this.Show();
        }

        private void login_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void lbkRecuperarContraseña_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            if (txtUsuario.Text != "Usuario" && !string.IsNullOrEmpty(txtUsuario.Text))
            {
                try
                {
                    MessageBoxButtons btnOpciones = MessageBoxButtons.YesNo;
                    DialogResult dr = MessageBox.Show("¿Desea recuperar su Contraseña?", "Recuperación de Contraseña",
                        btnOpciones, MessageBoxIcon.Exclamation);

                    if (dr == DialogResult.Yes)
                    {
                        if(business.ChangePassword(txtUsuario.Text))
                        {
                            MessageBox.Show("Contraseña enviada", "Recuperación de Contraseña",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontro este Usuario", "Recuperación de Contraseña",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al enviar contraseña: " + ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("Debe Ingresar un Usuario", "Datos Faltantes",
                         MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            acceder(e.KeyChar);
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            acceder(e.KeyChar);
        }

        private void acceder(char e)
        {
            if(e== '\r')
            {
                btnAcceder_Click(this, new EventArgs());
            }
        }
    }
}
