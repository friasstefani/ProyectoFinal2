using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
namespace BLL {
    public class Usuarios {
        public int IdUsuario { get; set; }
        public String Nombres { get; set; }
        public String Clave { get; set; }
        public int estado { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Imagen { get; set; }

        Conexion conectar = new Conexion();

        public Usuarios(int IdUsuario, String Nombres, string Clave, int estado, TiposUsuarios.Tipos IdTipoUsuario) {
            this.IdUsuario = IdUsuario;
            this.Nombres = Nombres;
            this.Clave = Clave;
            this.estado = estado;
            this.IdTipoUsuario = (int)IdTipoUsuario;
            this.Imagen = "";
        }


        public Usuarios() {
            // TODO: Complete member initialization
        }

        public bool Insertar() {
            object retorno = conectar.GetDbValue("Insert Into Usuarios (Nombres,Clave, estado,IdTipoUsuario) Values ('" + Nombres + "','" + Clave + "','" + estado + "','" + IdTipoUsuario + "'); Select @@IDENTITY");
            int id = 0; 
            int.TryParse(retorno.ToString(), out id); 

            this.IdUsuario = id;
            this.Nombres = retorno.ToString();
            return this.IdUsuario > 0;
        }

        public bool Modificar(int IdUsuario) {
            return conectar.EjecutarDB(" update  Usuarios  set Nombres ='" + Nombres + "',Clave ='" + Clave + "',estado ='" + estado + "'where IdUsuario = '" + IdUsuario + "' ");
        }

        public bool Eliminar(int IdUsuario) {

            return conectar.EjecutarDB("Delete from  Usuarios  where IdUsuario  ='" + IdUsuario + "',Nombres ='" + Nombres + "',Clave ='" + Clave + "',estado ='" + estado + "' ");
        }

        public bool Buscar(int IdUsuario) {
            bool mensaje = false;


            DataTable dt;

            dt = conectar.BuscarDb("select * from Usuarios where IdUsuario  = " + IdUsuario);
            if (dt.Rows.Count > 0) {
                mensaje = true;

                this.IdUsuario = (int)dt.Rows[0]["IdUsuario"];
                this.Nombres = (String)dt.Rows[0]["Nombres"];
                this.Clave = (String)dt.Rows[0]["Clave"];
                this.estado = (int)dt.Rows[0]["estado"];
                this.IdTipoUsuario = (int)dt.Rows[0]["IdTipoUsuario"];
            }

            return mensaje;
        }

        public bool BuscarPorNombre(string Nombre) {
            bool mensaje = false;


            DataTable dt;

            dt = conectar.BuscarDb("select * from Usuarios where Nombres  = '" + Nombre + "'");
            if (dt.Rows.Count > 0) {
                mensaje = true;

                this.IdUsuario = (int)dt.Rows[0]["IdUsuario"];
                this.Nombres = (String)dt.Rows[0]["Nombres"];
                this.Clave = (String)dt.Rows[0]["Clave"];
                this.estado = (int)dt.Rows[0]["estado"];
                this.IdTipoUsuario = (int)dt.Rows[0]["IdTipoUsuario"];
            }

            return mensaje;
        }

        public static DataTable Lista(String Campos, String FiltroWhere) {
            Conexion ConexionDB = new Conexion();
            return ConexionDB.BuscarDb("Select " + Campos + " From Usuarios Where " + FiltroWhere);
        }

        public static bool Logon(string Nombres, string Clave) {
            Conexion ConexionDB = new Conexion();
            bool Msj = false;
            DataTable dt;
            dt = ConexionDB.BuscarDb("select * from Usuarios Where Nombres ='" + Nombres + "' and Clave  ='" + Clave + "'");
            if (dt.Rows.Count > 0)
                Msj = true;
            return Msj;
        } 
    }
}