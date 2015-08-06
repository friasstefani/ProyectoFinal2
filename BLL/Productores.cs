using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
namespace BLL {
    public class Productores {
        public int IdProductor { get; set; }
        public int IdUsuario { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public string Direccion { get; set; }
        public string cedula { get; set; }
        public string Email { get; set; }

        Conexion conectar = new Conexion();

        public Productores(int IdProductor, int IdUsuario, string Nombres, string Apellidos, string Telefono, string Celular, string Direcion, string Cedula, string Email) {

            this.IdProductor = IdProductor;
            this.IdUsuario = IdUsuario;
            this.Nombres = Nombres;
            this.Apellidos = Apellidos;
            this.Telefono = Telefono;
            this.Celular = Celular;
            this.Direccion = Direcion;
            this.cedula = cedula;
            this.Email = Email;
        }

        public Productores() {
            // TODO: Complete member initialization
        }

        public static int getIdProductorPorIdUsuario(int IdUsuario) {
            int valor = 0;
            Conexion conectar = new Conexion();

            valor = Convert.ToInt32(conectar.GetDbValue("Select IdProductor From Productores Where IdUsuario = " + IdUsuario));
            return valor;
        }

        public bool Insertar() {
            return conectar.EjecutarDB("Insert Into Productores(IdUsuario,Nombres,apellidos,Telefono,Celular,Direccion,cedula,Email) Values ('" + IdUsuario + "','" + Nombres + "','" + Apellidos + "','" + Telefono + "','" + Celular + "','" + Direccion + "','" + cedula + "','" + Email + "')");
        }

        public bool Modificar(int IdProductor) {
            return conectar.EjecutarDB(" update Productores set IdUsuario ='" + IdUsuario + "',Nombres ='" + Nombres + "',Apellidos ='" + Apellidos + "',Telefono ='" + Telefono + "',Celular ='" + Celular + "',Direccion ='" + Direccion + "',cedula ='" + cedula + "',Email ='" + Email + "' where IdProductor = '" + IdProductor + "' ");
        }

        public bool Eliminar(int IdProductor) {

            return conectar.EjecutarDB("Delete from Productores where IdProductor ='" + IdProductor + "' ");
        }

        public bool Buscar(int IdProductor) {
            bool mensaje = false;


            DataTable dt;

            dt = conectar.BuscarDb("select * from Productores where IdProductor  = " + IdProductor);
            if (dt.Rows.Count > 0) {
                mensaje = true;

                this.IdProductor = (int)dt.Rows[0]["IdProductor"];
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
        public static DataTable Lista(String Campos, String FiltroWhere) {
            Conexion ConexionDB = new Conexion();
            return ConexionDB.BuscarDb("Select " + Campos + " From Productores Where " + FiltroWhere);
        }


    }
}