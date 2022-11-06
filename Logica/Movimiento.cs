using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Logica
{
    public class Movimiento
    {
        public string Player(object sender, KeyEventArgs e)
        {
            string M = "";
            switch (e.KeyCode)
            {
                case Keys.Up: M = "Salta"; break;
                case Keys.Down: M = "Agacha"; break;
                case Keys.Left: M = "Izquierda"; break;
                case Keys.Right: M = "Derecha"; break;
                case Keys.Space: M = "Disparar"; break;
            }
            return M;
        }
    }
}
