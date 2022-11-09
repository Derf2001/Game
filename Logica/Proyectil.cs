using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Threading;


namespace Logica
{
    public class Proyectil:PictureBox
    {
        Game.Form1 vista;
        int X, Y;
        Thread Tra;

        public Proyectil(Game.Form1 vista, int X, int Y)
        {
            this.vista = vista;
            this.X = X;
            this.Y = Y;

            this.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Logica\Image\Ball.png"));
            this.Location = new Point(X, Y);
            this.Size = new Size(10, 10);
            this.SizeMode = PictureBoxSizeMode.StretchImage;

            Tra = new Thread(Trayectoria);
            Tra.Start();
            this.vista.Controls.Add(this);
            this.BringToFront();
        }
        
        public void Trayectoria()
        {
            while(true)
            {
                X += 15;
                if (bandera() == true)
                {
                    Console.WriteLine("Chocaron");
                    vista.bajaVida2();
                    this.Location = new Point(1000, 1000);
                    Tra.Abort();
                    break;
                }
                this.Location = new Point(X, Y);
                Thread.Sleep(100);
                this.Refresh();
            }
        }

        public Rectangle RecObs()
        {
            return new Rectangle(X, Y, 10, 10);
        }
        public Boolean bandera()
        {
            return vista.RecPlayer2().IntersectsWith(RecObs());

        }

    }
}
