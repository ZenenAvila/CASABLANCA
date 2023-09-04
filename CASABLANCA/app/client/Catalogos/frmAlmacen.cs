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
    public partial class frmAlmacen : Form
    {
        public frmAlmacen()
        {
            InitializeComponent();
        }

        private void frmAlmacen_Click(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void frmAlmacen_Move(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
