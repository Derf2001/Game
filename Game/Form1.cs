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
        //En "MIPC", se pone la direccion IP del servidor(BD)
        //Para el jugador dos se invierte el Player1 y Player2, para que el Jugador 2 pueda mover su personaje
        Conexion c = new Conexion("MIPC", "Player1", "Player1", "1234"); //Conexion al Player1
        Conexion c2 = new Conexion("MIPC", "Player2", "Player2", "1234");//Conexion al Player2

        Movimiento m = new Movimiento(); //Declaracion de la clase Movimiento de Logica.dll
        Proyectil pro; //Declaracion del Proyectil del Player1
        Proyectil2 pro2; //Declaracion del Proyectil del Player2
        double Temp = 5.00; //Declaracion del temporizador de 5 min
        string mov = ""; //Declaracion de la variable mov que va recibir el movimiento
        int alA = 0; //Declaracion que va a recibir la Altura de los jugadores
        int Cder = 2; //Declarion que va a recibir los valores para cambiar la imagen del Player1, (Hacer la animacion de caminar)
        int Cder2 = 11; //Declarion que va a recibir los valores para cambiar la imagen del Player2, (Hacer la animacion de caminar)
        bool s, s2= false; //Declarion para verificar si se realiza algun salto en Player1 y Player2

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false; //verifica las llamadas a los hilos y deja que se ejecuten a la vez
            c.Conectar(); //Realizamos la conexion para Player1
            c2.Conectar(); //Realizamos la conexion para Player2
            TimeMov.Start(); //Se inicia el Timer que controla el Player2
            TimeTime.Start(); //Se inicia el Timer que cotrola el Tiempo
            TimeSalto.Start(); //Se incia el Timer que controla el Salto de los Jugadores
        }

        private void timer1_Tick(object sender, EventArgs e)//Evento Timer que Controla el Player2, cada segundo.
        {
            switch (c2.Consulta()) //Realiza la consulta a la Tabla del Player2 y retorna la accion que realiza
            {
                case "Salta": s2 = true; //Si SALTA, Cambia el valor del salto
                    break; //se rompe el ciclo
                case "Izquierda": //Si se mueve a la izquierda
                    int izq = Player2.Location.X + 10; //Se guarda el valor de X del Player2 y se suma 10 para su movimiento a la izquierda
                    Player2.Location = new Point(izq, Player2.Location.Y); //Se le agrega la nueva posicion al Player2
                    if (Cder2 > 14) //Si el valor de la imagen es mayor a 14
                    {
                        Cder2 = 11; //Se cambia el valor de la imagen a la principal
                        Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im" + Cder2 + ".png")); //Se actualiza la imagen del Player2
                        this.Refresh(); //Se realiza una actualizacion de la superficie
                    }
                    else //Si la condicion es falsa, entonces el valor de las imagenes es menor a 14
                    {
                        Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im" + Cder2 + ".png")); //Se actualiza la imagen del Player2
                        this.Refresh(); //Se realiza la actualizacion de la superficie
                    }
                    Cder2++; //Aumenta el valor de las imagenes (Para que camine)
                    break; //Se rompe el ciclo
                case "Derecha": //Si se mueve a la derecha
                    int der = Player2.Location.X - 10; //Se guarda el valor de X del Player2 y se resta 10 para su movimiento a la derecha
                    Player2.Location = new Point(der, Player2.Location.Y); //Se le agrega la nueva posicion al Player2
                    if (Cder2 > 14) //Si el valor de la imagen es mayor a 14
                    {
                        Cder2 = 11; //Se cambia el valor de la imagen a la principal
                        Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im" + Cder2 + ".png")); //Se actualiza la imagen del Player2
                        this.Refresh(); //Se realiza la actualizacion de la superficie
                    }
                    else
                    {
                        Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im" + Cder2 + ".png")); //Se actualiza la imagen del Player2
                        this.Refresh(); //Se realiza la actualizacion de la superficie
                    }
                    Cder2++; //Aumenta el valor de las imagenes (Para que camine)
                    break; //Se rompe el ciclo
                case "Agacha": //Si se agacha
                    alA = Player2.Size.Height; //Se Actualiza el valor de alA, con la altura actual del Player2
                    Player2.Size = new Size(Player2.Size.Width, 60); //Se actuliza el nevo tamaño del Player2
                    Player2.Location = new Point(Player2.Location.X, 386); //Se actualiza la posicion del Player para que se baje.
                    Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im13.png")); //Se actualiza la Imagen del Player2 (Imagen Agachar)
                    this.Refresh(); //Se realiza la actualizacion de la superficie
                    break; //Se rompe el ciclo
                case "Disparar": //Si se Dispara
                    pro2 = new Proyectil2(this, Player2.Location.X, Player2.Location.Y); //Se termmina de declara el Proyectil
                    Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im16.png")); //Se actualiza la Imagen del Player2 (Imagen Disparo)
                    this.Refresh(); //Se realiza la actualizacion de la superficie
                    break; //Se rompe el ciclo
                default: //Accion default
                    if (Player2.Size.Height == 60 || Player1.Size.Height == 60) //Si la altura del Player2 y Player1 == 60
                    {
                        Player2.Size = new Size(69, 120); //Se actualiza el tamaño por defecto de Player2
                        Player2.Location = new Point(Player2.Location.X, 326); //Se Actualiza la ubicacion del Player2
                        Player1.Size = new Size(69, 120); //Se actualiza el tamaña por defecto de Player1
                        Player1.Location = new Point(Player1.Location.X, 326); //Se actualiza la ubicacion del Player1
                        Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im11.png")); //Se actualiza la imagen del Player2 (Imagen default)
                        this.Refresh(); //Se realiza la actualizacion de la superficie
                    }
                    break; //Se rompe el ciclo
            }
            c2.Delete();// Borra la accion de la tabla despues de usarla
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) //Evento de Tecla que Controlar el Player1
        {
            mov = m.Player(sender, e);
            c.Insert(mov);
            switch (mov)
            {
                case "Salta": s = true;
                    break; //Se rompe el ciclo
                case "Izquierda":
                    int izq = Player1.Location.X - 10;
                    Player1.Location = new Point(izq, Player1.Location.Y);
                    if (Cder > 9)
                    {
                        Cder = 2;
                        Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg" + Cder + ".png"));
                        this.Refresh(); //Se realiza la actualizacion de la superficie
                    }
                    else
                    {
                        Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg" + Cder + ".png"));
                        this.Refresh(); //Se realiza la actualizacion de la superficie
                    }
                    Cder++;
                    break; //Se rompe el ciclo
                case "Derecha":
                    int der = Player1.Location.X + 10;
                    Player1.Location = new Point(der, Player1.Location.Y);
                    if (Cder > 9)
                    {
                        Cder = 2;
                        Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg"+ Cder + ".png"));
                        this.Refresh(); //Se realiza la actualizacion de la superficie
                    }
                    else
                    {
                        Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg" + Cder + ".png"));
                        this.Refresh(); //Se realiza la actualizacion de la superficie
                    }
                    Cder++;
                    break; //Se rompe el ciclo
                case "Agacha":
                    alA = Player1.Size.Height;
                    Player1.Size = new Size(Player1.Size.Width, 60);
                    Player1.Location = new Point(Player1.Location.X, 386);
                    Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\ag2.png"));
                    this.Refresh(); //Se realiza la actualizacion de la superficie
                    break; //Se rompe el ciclo
                case "Disparar":
                    Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg10.png"));
                    this.Refresh(); //Se realiza la actualizacion de la superficie
                    pro = new Proyectil(this, Player1.Location.X, Player1.Location.Y);
                    break; //Se rompe el ciclo
                default:
                    if (Player1.Size.Height == 60)
                    {
                        Player1.Size = new Size(26, 120);
                        Player1.Location = new Point(Player1.Location.X, 326);
                    }
                    break; //Se rompe el ciclo
            }
        }

        private void TimeTime_Tick(object sender, EventArgs e)//controla el tiempo
        {
            // Temp -= 0.01;
            TimeL.Text = "Time: \n" + Temp;
            Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg1.png"));
            this.Refresh(); //Se realiza la actualizacion de la superficie
        }

        public Rectangle RecPlayer1()//Rectangulo del jugador1
        {
            return new Rectangle(Player1.Location.X, Player1.Location.Y, 26, 120);
        }

        public Rectangle RecPlayer2()//Rectanguo del jugador2
        {
            return new Rectangle(Player2.Location.X, Player2.Location.Y, 26, 120);
        }

        public void bajaVida1()//Pregunta si el jugador1 aun tiene vida, si llega a 0 se declara al otro jugador ganador
        {
            if (Vida1.Value > 1)
                Vida1.Value -= 10;
            if (Vida1.Value == 0)
                MessageBox.Show("Juego Terminado\n Ganador Player2");
        }

        public void bajaVida2()//pregunta por la vida del jugador2
        {
            if (Vida2.Value > 1)
                Vida2.Value -= 10;
            if(Vida2.Value == 0)
                MessageBox.Show("Juego Terminado\n Ganador Player1");
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Player1.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\pg1.png"));
            this.Refresh(); //Se realiza la actualizacion de la superficie
        }

        private void TimeSalto_Tick(object sender, EventArgs e)//hace saltar
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
                }
            }

            if (s2)
            {
                Player2.Image = Image.FromFile(Path.GetFullPath(@"..\..\..\Game\Images\im15.png"));
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
