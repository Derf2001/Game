using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Threading;

namespace Logica
{
    public class Conexion
    {
        string IP;
        string BD;
        string Cliente;
        string Password;

        public Conexion(string IP, string BD, string Cliente, string Password)
        {
            this.IP = IP;
            this.BD = BD;
            this.Cliente = Cliente;
            this.Password = Password;
        }

        SqlConnection con = new SqlConnection();

        public void Conectar()
        {
            try
            {
                //Data Source = MIPC\\Derf
                string comand = "Data Source=" + IP + "; Initial Catalog=" + BD + "; Integrated Security=True"; //Conexion local a la base de datos
                //string comand = "Data Source=" + IP + "; Initial Catalog=" + BD + ";User Id=" + Cliente + ";Password=" + Password; //Conexion remota a la base de datos
                con = new SqlConnection(comand);
                con.Open();//se abre la conexion
                Console.WriteLine("se Conecto " + IP);
            }
            catch (SqlException e)
            {
                MessageBox.Show("Ocurrio un Error :\n" + e.Message);
            }
        }

        public string Consulta()
        { //Leela accion que se va a realizar y lo retorna
            string mov = "";
            try
            {
                SqlCommand sql = new SqlCommand("select * from Movimiento", con);
                SqlDataReader read = sql.ExecuteReader();
                while (read.Read())
                {
                    mov = read.GetValue(0).ToString();
                }
                read.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Ocurrio un Error al Consultar:\n" + e.Message);
            }
            return mov;
        }

        public void Update(string Action)
        {// Metodo que actualiza el valor de la base de datos
            try
            {
                SqlCommand sql = new SqlCommand("Update Movimiento set Action='" + Action + "'", con);
                sql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Ocurrio un Error al Actualizar:\n" + e.Message);
            }
        }

        public void Insert(string Action)
        {
            try
            {// Inserta el movimiento que se hara
                SqlCommand sql = new SqlCommand("Insert Into Movimiento values ('" + Action + "')", con);
                sql.ExecuteNonQuery();
            }
            catch(SqlException e)
            {
                Console.WriteLine("Ocurrio un Error al Insertar:\n" + e.Message);
            }
        }

        public void Delete()
        {
            try// elimina el movimiento
            {
                SqlCommand sql = new SqlCommand("Delete Movimiento ", con);
                sql.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine("Ocurrio un Error al Insertar:\n" + e.Message);
            }
        }
    }


}
