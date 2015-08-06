using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class Medidas{
        public int IdMedidas { get; set; }
        public String Descripcion { get; set; }
      

        Conexion conectar = new Conexion();

        public Medidas(int IdMedidas, String Descripcion)
        {

            this.IdMedidas = IdMedidas;
            this.Descripcion = Descripcion;
           
    }


        public Medidas()
        {
            // TODO: Complete member initialization
        }
        public bool Insertar()
        {
            return conectar.EjecutarDB("Insert Into Medidas (Descripcion ) Values ('" + Descripcion + "')");
        }

        public bool InsertaYRetornaId() {
            IdMedidas = Convert.ToInt32(conectar.GetDbValue("Insert Into Medidas (Descripcion ) Values ('" + Descripcion + "'); Select @@Identity"));

            return IdMedidas > 0;
        }

        public bool Modificar(int IdMedidas)
        {
            return conectar.EjecutarDB(" update Medidas set Descripcion ='" + Descripcion + "' where IdMedidas = '" + IdMedidas + "' ");
        }

        public bool Eliminar(int IdMedidas)
        {

            return conectar.EjecutarDB("Delete from Medidas where IdMedidas =" + IdMedidas + " ");
        }

        public bool Buscar(int IdMedidas)
        {
            bool mensaje = false;


            DataTable dt;

            dt = conectar.BuscarDb("select * from Medidas where IdMedidas = " + IdMedidas);
            if (dt.Rows.Count > 0)
            {
                mensaje = true;

                this.IdMedidas = (int)dt.Rows[0]["IdMedidas"];
                this.Descripcion = (String)dt.Rows[0]["Descripcion"];
              
                }

            return mensaje;
        }
        
        //public bool Buscarhijo(int IdSistema)
       // {
            //bool Msj = true;
           // DataTable dt = new DataTable();
           // dt = conectar.BuscarDb("select * from DetalleEstadoPaciente where IdSistema="+IdSistema);
            //if (dt.Rows.Count > 0)
               // Msj = false;
           // return Msj;
        //}

        public static DataTable Lista(String Campos, String FiltroWhere)
        {
            Conexion ConexionDB = new Conexion();
            return ConexionDB.BuscarDb("Select " + Campos + " From Medidas Where " + FiltroWhere);
        }
        

    }
}



   

