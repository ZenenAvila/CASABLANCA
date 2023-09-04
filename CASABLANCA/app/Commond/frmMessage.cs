using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASABLANCA.app.Commond
{
    public partial class frmMessage : Form
    {
        public string Correcto = @"../../Images/correcto.png";
        public string Error = @"../../Images/error.png";
        public string Advertencia = @"../../Images/advertencia.png";
        public frmMessage()
        {
            InitializeComponent();
        }

        private void frmMessage_Load(object sender, EventArgs e)
        {
            
        }

        public async Task<string> _Show(string title, string pregunta,string imagen, string opc1, string opc2="", string opc3="")
        {
            await Task.Run(() =>
            {
                this.Show();
            lblTitulo.Text = title;
            txtPregunta.Text = pregunta;
            pbxImage.Image = Image.FromFile(imagen);
            btn1.Text = opc1;
            btn2.Visible = opc2=="" ? false:true;
            btn2.Text = opc2;
            btn3.Visible = opc3 == "" ? false : true;
            btn3.Text = opc3;
            });
            return "";
        }
    }
}
