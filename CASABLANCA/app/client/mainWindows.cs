using CASABLANCA.app.client.Catalogos;
using CASABLANCA.app.client.Compras;
using CASABLANCA.app.client.Historial;
using CASABLANCA.app.client.Ingreso;
using CASABLANCA.app.client.Users;
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

namespace CASABLANCA.app.client
{
    public partial class mainWindows : Form,IMainWindows
    {
        int x = 0, y = 0;
        int wSWidth = 0, wSHeigth = 0;
        public mainWindows()
        {
            InitializeComponent();
            iniciarMenu();
        }

        public void iniciarMenu()
        {
            ddlCatalogos.IsMainMenu = true;
            ddlIngreso.IsMainMenu = true;
            ddlHistoria.IsMainMenu = true;
            ddlSistema.IsMainMenu = true;
            ddlCompras.IsMainMenu = true;
            ddlCatalogos.MenuItemTextColor = Color.Black;
            ddlIngreso.MenuItemTextColor = Color.Black;
            ddlHistoria.MenuItemTextColor = Color.Black;
            ddlSistema.MenuItemTextColor = Color.Black;
            ddlCompras.MenuItemTextColor = Color.Black;
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            ddlIngreso.Show(btnIngreso,btnIngreso.Width,0);
        }

        private void pbxIngreso_Click(object sender, EventArgs e)
        {
            ddlIngreso.Show(btnIngreso, btnIngreso.Width, 0);
        }

        private void btnCatalogos_Click(object sender, EventArgs e)
        {
            ddlCatalogos.Show(btnCatalogos,btnCatalogos.Width,0);
        }

        private void pbxCatalogos_Click(object sender, EventArgs e)
        {
            ddlCatalogos.Show(btnCatalogos, btnCatalogos.Width, 0);
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            ddlHistoria.Show(btnHistorial, btnHistorial.Width, 0);
        }

        private void pbxHistorial_Click(object sender, EventArgs e)
        {
            ddlHistoria.Show(btnHistorial, btnHistorial.Width, 0);
        }

        private void btnSistema_Click(object sender, EventArgs e)
        {
            ddlSistema.Show(btnSistema, btnSistema.Width, 0);
        }

        private void pbxSistema_Click(object sender, EventArgs e)
        {
            ddlSistema.Show(btnSistema, btnSistema.Width, 0);
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            ddlCompras.Show(btnCompras, btnCompras.Width, 0);
        }

        private void pbxCompras_Click(object sender, EventArgs e)
        {
            ddlCompras.Show(btnCompras, btnCompras.Width, 0);
        }

        private void smiNuevo_Click(object sender, EventArgs e)
        {
            frmIngreso ingreso = new frmIngreso(this);
            abrirForm(ingreso,Global.Ventana._2_4);//larga
        }

        private void smiClientes_Click(object sender, EventArgs e)
        {
            app.client.Catalogos.frmClientes form = new Catalogos.frmClientes(this);
            abrirForm(form, Global.Ventana._3_3);
        }

        private void smiProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores form = new frmProveedores();
            abrirForm(form, Global.Ventana._2_4);
        }

        private void smiSyp_Click(object sender, EventArgs e)
        {
            app.client.Catalogos.frmServiciosProductos form = new Catalogos.frmServiciosProductos();
            abrirForm(form);
        }

        private void smiHistSyp_Click(object sender, EventArgs e)
        {

            frmHistServiciosProductos form = new frmHistServiciosProductos();
            abrirForm(form, Global.Ventana._2_4);
        }

        public void smiAutos_Click(object sender, EventArgs e)
        {
            app.client.Catalogos.frmAutos form = new Catalogos.frmAutos();
            abrirForm(form);
        }

        private void smiProductos_Click(object sender, EventArgs e)
        {
            frmProductosProveedores form = new frmProductosProveedores();
            abrirForm(form,Global.Ventana._3_3);
        }

        private void smiUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuarios form = new frmUsuarios();
            abrirForm(form);
        }

        private void smiComprasProveedores_Click(object sender, EventArgs e)
        {
            frmComprasProveedor form = new frmComprasProveedor(this);
            abrirForm(form,Global.Ventana._3_2);
        }

        private void smiComprasDia_Click(object sender, EventArgs e)
        {
            
        frmComprasDiaEncabezado form = new frmComprasDiaEncabezado(this);
            abrirForm(form,Global.Ventana._2_2);
        }

        private void mainWindows_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //smiAutos_Click(this,new EventArgs());
            MessageBoxButtons btnOpciones = MessageBoxButtons.YesNo;
            DialogResult dr = MessageBox.Show("¿Desea Cerrar Sesion?", "Cerrar Sesion",
                btnOpciones, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                login log = new login();
                log.LogOut();
                this.Hide();
            }
        }

        public void abrirForm(object form, Global.Ventana ventana= Global.Ventana._2_4)
        {
            Form f = form as Form;
            f.TopLevel = false;
            this.pnlWorkSpace.Controls.Add(f);
            this.pnlWorkSpace.Tag = f;
            int uWidth = (wSWidth-50) / 4,uHeigth=(wSHeigth-50)/4;

            //Tamaño ventana
            switch (ventana)
            {
                case Global.Ventana._1_1:
                    f.Width = uWidth;
                    f.Height = uHeigth;
                    break;
                case Global.Ventana._1_2:
                    f.Width = uWidth;
                    f.Height =uHeigth*2;
                    break;
                case Global.Ventana._2_1:
                    f.Width = uWidth*2;
                    f.Height = uHeigth;
                    break;
                case Global.Ventana._2_2:
                    f.Width = uWidth*2;
                    f.Height = uHeigth*2;
                    break;
                case Global.Ventana._3_2:
                    f.Width = uWidth*3;
                    f.Height = uHeigth*2;
                    break;
                case Global.Ventana._2_3:
                    f.Width = uWidth*2;
                    f.Height = uHeigth*3;
                    break;
                case Global.Ventana._4_2:
                    f.Width = uWidth*4;
                    f.Height = uHeigth*2;
                    break;
                case Global.Ventana._2_4:
                    f.Width = uWidth*2;
                    f.Height = uHeigth*4;
                    break;
                case Global.Ventana._4_3:
                    f.Width = uWidth*4;
                    f.Height = uHeigth*3;
                    break;
                case Global.Ventana._3_4:
                    f.Width = uWidth*3;
                    f.Height = uHeigth*4;
                    break;
                case Global.Ventana._4_4:
                    f.Width = uWidth*4;
                    f.Height = uHeigth*4;
                    break;
            }
            //MessageBox.Show("H: " + f.Height + " , W: " + f.Width);
            //MessageBox.Show("H: " + (this.pnlWorkSpace.Height / 4) * 3 + " , W: " + (this.pnlWorkSpace.Width / 4) * 3);
            //f.Height = 730;
            //f.Width = isLong? 945 : 630;

            f.MaximumSize = new Size(f.Width + 30, f.Height + 30);

            f.BringToFront();
            x += 15; y += 15;
            f.Location = new Point(x, y);
            f.Show();
            pbxLogoFondo.SendToBack();
        }

        private void mainWindows_Load(object sender, EventArgs e)
        {
            pnlMenu.Controls.SetChildIndex(pnlUsuario, 6);
            pnlMenu.Controls.SetChildIndex(pnlIngreso, 5);
            pnlMenu.Controls.SetChildIndex(pnlCompras, 4);
            pnlMenu.Controls.SetChildIndex(pnlCatalogos, 3);
            pnlMenu.Controls.SetChildIndex(pnlHistorial, 2);
            pnlMenu.Controls.SetChildIndex(pnlSistema, 1);

            cargarUsuario();
            if(userCls.cargo=="SECRETARIO")
            {
                pnlHistorial.Visible = false;
            }

            wSWidth = this.pnlWorkSpace.Width;
            wSHeigth = this.pnlWorkSpace.Height;
        }

        private void cargarUsuario()
        {
            string nombre = userCls.nombre;
            string apellido = userCls.apellidoPaterno;
            lblCargo.Text = string.IsNullOrEmpty(userCls.cargo)?"Desarrollador":userCls.cargo.Substring(0,1)+userCls.cargo.Substring(1,userCls.cargo.Length-1).ToLower();
            lblUsuario.Text = string.IsNullOrEmpty(userCls.nombre) ? "Zenen Avila"
                              : nombre.Substring(0, 1) + nombre.Substring(1, nombre.Length - 1).ToLower() + " " +
                              apellido.Substring(0, 1) + apellido.Substring(1, apellido.Length - 1).ToLower() ;
        }

        //private void smiSyp_MouseHover(object sender, EventArgs e)
        //{
        //    smiSyp.Image = Image.FromFile(@"../../Images/productosServiciosVerdePequeña.png");
        //}

        //private void smiSyp_MouseLeave(object sender, EventArgs e)
        //{
        //    smiSyp.Image = Image.FromFile(@"../../Images/productosServiciosAzulPequeña4.png");
        //}

        public void abrirCliente()
        {
            smiAutos_Click(this, new EventArgs());
        }

        private void pbxTamaño_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Size.Width!=60)
            {
                //Minimizado
                pnlMenu.Size = new Size(60, pnlMenu.Size.Height);
                pbxTamaño.Location = new Point(10, pbxTamaño.Location.Y);
                pbxCerrarSesion.Location = new Point(10, pbxTamaño.Location.Y);
                pbxLogoCompleto.Image = Image.FromFile(@"Images/iconoCasaBlanca.png");
                pbxTamaño.Image = Image.FromFile(@"Images/flechaMaximizar.png");
            }
            else
            {
                //Maximizado
                pnlMenu.Size = new Size(213, pnlMenu.Size.Height);
                pbxTamaño.Location = new Point(80, pbxTamaño.Location.Y);
                pbxCerrarSesion.Location = new Point(80, pbxTamaño.Location.Y);
                pbxLogoCompleto.Image = Image.FromFile(@"Images/Logo Completo.jpeg");
                pbxTamaño.Image = Image.FromFile(@"Images/flechaMinimizar.png");
            }
        }
        bool banCerrar = false;
        private void mainWindows_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!banCerrar)
            {
                MessageBoxButtons btnOpciones = MessageBoxButtons.YesNo;
                DialogResult dr = MessageBox.Show("¿Desea Cerrar La Aplicación?", "Cerrar Sesion",
                    btnOpciones, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    banCerrar = true;
                    Application.Exit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void pbxCerrarSesion_Click(object sender, EventArgs e)
        {

            //smiAutos_Click(this,new EventArgs());
            MessageBoxButtons btnOpciones = MessageBoxButtons.YesNo;
            DialogResult dr = MessageBox.Show("¿Desea Cerrar Sesion?", "Cerrar Sesion",
                btnOpciones, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                login log = new login();
                log.LogOut();
                this.Hide();
            }

        }

        public void abrirProveedor()
        {
            smiProveedores_Click(this, new EventArgs());
        }
    }
}
