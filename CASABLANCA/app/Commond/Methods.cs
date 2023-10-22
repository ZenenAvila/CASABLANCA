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
        public List<Methods> busqueda { get; set; }
        public Methods()
        {
            busqueda = new List<Methods>();
        }
        public void parametros(string _texto, int _celda)
        {

            busqueda.Add(new Methods { texto = _texto, celda = _celda });

            //texto.Add(_texto);
            //celda.Add(_celda);
        }

        //public void filtrarDGV(DataGridView dgv, List<Methods> busqueda, Label total)
        public void filtrarDGV(DataGridView dgv, Label total)
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
