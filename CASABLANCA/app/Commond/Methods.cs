using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASABLANCA.app.Commond
{
    public class Methods
    {
        public string texto { get; set; }
        public int celda { get; set; }

        public void filtrarDGV(DataGridView dgv, List<Methods> busqueda, Label total)
        {
            dgv.CurrentCell = null;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                {
                    foreach (Methods bus in busqueda)
                    {
                        try
                        {
                            if (!(row.Cells[bus.celda].Value.ToString().ToUpper()).Contains(bus.texto.ToUpper())
                            || string.IsNullOrEmpty(bus.texto))
                            {
                                row.Visible = false;
                            }
                            else
                            {
                                row.Visible = true;
                                break;
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }

            total.Text = "Total de Registros: " + dgv.Rows.Count;
        }
    }
}
