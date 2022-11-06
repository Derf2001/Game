using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Logica;
using System.IO;

namespace Game
{
    public partial class Form1 : Form
    {
        
        Conexion c = new Conexion("MIPC", "Player2", "Player1", "1234");
        Conexion c2 = new Conexion("MIPC", "Player1", "Player2", "1234");
        Movimiento m = new Movimiento();
        Proyectil pro;
        Proyectil2 pro2;
        double Temp = 5.00;
        int PosY = 326;
        string mov = "";
        int alA = 0;
        int Cder = 2;
        int Cder2 = 11;
        bool s, s2= false;

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            c.Conectar();
            c2.Conectar();
            TimeMov.Start();
            TimeTime.Start();
            TimeSalto.Start();
            //Fondo.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\Fondo.gif"));

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (c2.Consulta())
            {
                case "Salta": s2 = true;
                    /*int salto = Player2.Location.Y - 10;
                    Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im15.png"));
                    this.Refresh();
                    while (salto > 10)
                    {
                        Player2.Location = new Point(Player2.Location.X, salto);
                        salto = Player2.Location.Y - 10;
                        Console.WriteLine("subiendo");
                        this.Refresh();
                    }

                    while (salto < posY)
                    {
                        Player2.Location = new Point(Player2.Location.X, salto);
                        salto = Player2.Location.Y + 10;
                        Console.WriteLine("bajando");
                        this.Refresh();
                    }*/
                    break;
                case "Izquierda":
                    int izq = Player2.Location.X + 10;
                    Player2.Location = new Point(izq, Player2.Location.Y);
                    if (Cder2 > 14)
                    {
                        Cder2 = 11;
                        Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im" + Cder + ".png"));
                        this.Refresh();
                    }
                    else
                    {
                        Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im" + Cder + ".png"));
                        this.Refresh();
                    }
                    Cder2++;
                    break;
                case "Derecha":
                    int der = Player2.Location.X - 10;
                    Player2.Location = new Point(der, Player2.Location.Y);
                    if (Cder2 > 14)
                    {
                        Cder2 = 11;
                        Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im" + Cder + ".png"));
                        this.Refresh();
                    }
                    else
                    {
                        Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im" + Cder + ".png"));
                        this.Refresh();
                    }
                    Cder2++;
                    break;
                case "Agacha":
                    alA = Player2.Size.Height;
                    Player2.Size = new Size(Player2.Size.Width, 60);
                    Player2.Location = new Point(Player2.Location.X, 386);
                    Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im13.png"));
                    this.Refresh();
                    break;
                case "Disparar":
                    pro2 = new Proyectil2(this, Player2.Location.X, Player2.Location.Y);
                    Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im16.png"));
                    this.Refresh();
                    break;
                default:
                    if (Player2.Size.Height == 60 || Player1.Size.Height == 60)
                    {
                        Player2.Size = new Size(69, 120);
                        Player2.Location = new Point(Player2.Location.X, 326);
                        Player1.Size = new Size(69, 120);
                        Player1.Location = new Point(Player1.Location.X, 326);
                        Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im11.png"));
                        this.Refresh();
                    }
                    break;
            }
            c2.Delete();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            mov = m.Player(sender, e);
            c.Insert(mov);
            switch (mov)
            {
                case "Salta": s = true;
                    /*int salto = Player1.Location.Y - 10;
                    Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg2.png"));
                    this.Refresh();
                    while (salto > 10)
                    {
                        Player1.Location = new Point(Player1.Location.X, salto);
                        salto = Player1.Location.Y - 10;
                        Console.WriteLine("subiendo");
                        this.Refresh();
                    }

                    while (salto < posY)
                    {
                        Player1.Location = new Point(Player1.Location.X, salto);
                        salto = Player1.Location.Y + 10;
                        Console.WriteLine("bajando");
                        this.Refresh();
                    }*/
                    break;
                case "Izquierda":
                    int izq = Player1.Location.X - 10;
                    Player1.Location = new Point(izq, Player1.Location.Y);
                    if (Cder > 9)
                    {
                        Cder = 2;
                        Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg" + Cder + ".png"));
                        this.Refresh();
                    }
                    else
                    {
                        Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg" + Cder + ".png"));
                        this.Refresh();
                    }
                    Cder++;
                    break;
                case "Derecha":
                    int der = Player1.Location.X + 10;
                    Player1.Location = new Point(der, Player1.Location.Y);
                    if (Cder > 9)
                    {
                        Cder = 2;
                        Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg"+ Cder + ".png"));
                        this.Refresh();
                    }
                    else
                    {
                        Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg" + Cder + ".png"));
                        this.Refresh();
                    }
                    Cder++;
                    break;
                case "Agacha":
                    alA = Player1.Size.Height;
                    Player1.Size = new Size(Player1.Size.Width, 60);
                    Player1.Location = new Point(Player1.Location.X, 386);
                    Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\ag2.png"));
                    this.Refresh();
                    break;
                case "Disparar":
                    Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg10.png"));
                    this.Refresh();
                    pro = new Proyectil(this, Player1.Location.X, Player1.Location.Y);
                    break;
                default:
                    if (Player1.Size.Height == 60)
                    {
                        Player1.Size = new Size(26, 120);
                        Player1.Location = new Point(Player1.Location.X, 326);
                        /*Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg1.png"));
                        this.Refresh();*/
                    }
                    break;
            }
        }

        private void TimeTime_Tick(object sender, EventArgs e)
        {
            // Temp -= 0.01;
            TimeL.Text = "Time: \n" + Temp;
            Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg1.png"));
            this.Refresh();
        }

        public Rectangle RecPlayer1()
        {
            return new Rectangle(Player1.Location.X, Player1.Location.Y, 26, 120);
        }

        public Rectangle RecPlayer2()
        {
            return new Rectangle(Player2.Location.X, Player2.Location.Y, 26, 120);
        }

        public void bajaVida1()
        {
            if (Vida1.Value > 1)
                Vida1.Value -= 10;
            if (Vida1.Value == 0)
                MessageBox.Show("Juego Terminado\n Ganador Player2");
        }

        public void bajaVida2()
        {
            if (Vida2.Value > 1)
                Vida2.Value -= 10;
            if(Vida2.Value == 0)
                MessageBox.Show("Juego Terminado\n Ganador Player1");
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg1.png"));
            this.Refresh();
        }

        private void TimeSalto_Tick(object sender, EventArgs e)
        {
            if(s)
            {
                Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg2.png"));
               // this.Refresh();
                int salto = Player1.Location.Y - 10;
                Player1.Location = new Point(Player1.Location.X, salto);
                if(salto <= 100) { s = false; }
            }
            else
            {
                if(Player1.Location.Y < 326)
                {
                    int salto = Player1.Location.Y + 10;
                    Player1.Location = new Point(Player1.Location.X, salto);
                }else
                {
                    //Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg1.png"));
                    //this.Refresh();
                }

            }

            if (s2)
            {
                Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im15.png"));
                // this.Refresh();
                int salto = Player2.Location.Y - 10;
                Player2.Location = new Point(Player2.Location.X, salto);
                if (salto <= 100) { s2 = false; }
            }
            else
            {
                if (Player2.Location.Y < 326)
                {
                    int salto = Player2.Location.Y + 10;
                    Player2.Location = new Point(Player2.Location.X, salto);
                }

            }
        }
    }
}
