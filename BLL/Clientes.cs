using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
namespace BLL
{
    public class Clientes
    {
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string cedula { get; set; }
        public string Email { get; set; }

        Conexion conectar = new Conexion();

        public Clientes(int IdCliente, int IdUsuario, string Nombres, string Apellidos, string Telefono, string Celular, string Direcion, string Cedula, string Email)
        {

            this.IdCliente = IdCliente;
            this.IdUsuario = IdUsuario;
            this.Nombres = Nombres;
            this.Apellidos = Apellidos;
            this.Telefono = Telefono;
            this.Celular = Celular;
            this.Direccion = Direcion;
            this.cedula = cedula;
            this.Email = Email;
        }

        public Clientes()
        {
            // TODO: Complete member initialization
            this.IdCliente = 0;
            this.IdUsuario = 0;
            this.Nombres = "";
            this.Apellidos = "";
            this.Telefono = "";
            this.Celular = "";
            this.Direccion = "";
            this.cedula = "";
            this.Email = "";
        }
        public static int getIdClientePorIdUsuario(int IdUsuario) {
            int valor = 0;
            Conexion conectar = new Conexion();

            valor = Convert.ToInt32(conectar.GetDbValue("Select IdCliente From Clientes Where IdUsuario = " + IdUsuario));
            return valor;
        }

        public bool Insertar()
        {
            this.IdCliente = Convert.ToInt32(conectar.GetDbValue("Insert Into Clientes(IdUsuario,Nombres,apellidos,Telefono,Celular,Direccion,cedula,Email) Values ('" + IdUsuario + "','" + Nombres + "','" + Apellidos + "','" + Telefono + "','" + Celular + "','" + Direccion + "','" + cedula + "','" + Email + "'); Select @@IDENTITY"));

            return this.IdCliente > 0; 
        }

        public bool Modificar(int IdCliente)
        {
            return conectar.EjecutarDB(" update Clientes set IdUsuario ='" + IdUsuario + "',Nombres ='" + Nombres + "',Apellidos ='" + Apellidos + "',Telefono ='" + Telefono + "',Celular ='" + Celular + "',Direccion ='" + Direccion + "',cedula ='" + cedula + "',Email ='" + Email + "' where IdCliente = '" + IdCliente + "' ");
        }

        public bool Eliminar(int IdCliente)
        {

            return conectar.EjecutarDB("Delete from Clientes where IdCliente ='" + IdCliente + "' ");
        }

        public bool Buscar(int IdCliente) {
            bool mensaje = false;


            DataTable dt;

            dt = conectar.BuscarDb("select * from Clientes where IdCliente  = " + IdCliente);
            if (dt.Rows.Count > 0) {
                mensaje = true;

                this.IdCliente = (int)dt.Rows[0]["IdCliente"];
                this.IdUsuario = (int)dt.Rows[0]["IdUsuario"];
                this.Nombres = (String)dt.Rows[0]["Nombres"];
                this.Apellidos = (String)dt.Rows[0]["Apellidos"];
                this.Telefono = (String)dt.Rows[0]["Telefono"];
                this.Celular = (String)dt.Rows[0]["Celular"];
                this.Direccion = (String)dt.Rows[0]["Direccion"];
                this.cedula = (String)dt.Rows[0]["cedula"];
                this.Email = (String)dt.Rows[0]["Email"];   

            }

            return mensaje;
        }

        public bool BuscarIdUsuario(int IdUsuario) {
            bool mensaje = false; 
            DataTable dt;

            dt = conectar.BuscarDb("select * from Clientes where IdUsuario  = " + IdUsuario);
            if (dt.Rows.Count > 0) {
                mensaje = true;

                this.IdCliente = (int)dt.Rows[0]["IdCliente"];
                this.IdUsuario = (int)dt.Rows[0]["IdUsuario"];
                this.Nombres = (String)dt.Rows[0]["Nombres"];
                this.Apellidos = (String)dt.Rows[0]["Apellidos"];
                this.Telefono = (String)dt.Rows[0]["Telefono"];
                this.Celular = (String)dt.Rows[0]["Celular"];
                this.Direccion = (String)dt.Rows[0]["Direccion"];
                this.cedula = (String)dt.Rows[0]["cedula"];
                this.Email = (String)dt.Rows[0]["Email"]; 
            }

            return mensaje;
        }

        public static DataTable Lista(String Campos, String FiltroWhere)
        {
            Conexion ConexionDB = new Conexion();
            return ConexionDB.BuscarDb("Select " + Campos + " From Clientes Where " + FiltroWhere);
        }


    }
}



