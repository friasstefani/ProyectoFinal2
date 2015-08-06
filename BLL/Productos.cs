using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public string Imagen { get; set; }
        public int IdMedida { get; set; } 
        public bool Estado { get; set; }
        public int IdProductor { get; set; } 
        public Productores Productor { get; set; }
        public Medidas Medida { get; set; }

        Conexion conectar = new Conexion();

        public Productos(int IdProducto, string Nombre, string Descripcion, int Precio, int IdMedida, string Imagen, bool Estado)
        { 
            this.IdProducto = IdProducto;
            this.Nombre = Nombre;
            this.Descripcion = Descripcion;
            this.Precio = Precio;
            this.Imagen = Imagen;
            this.IdMedida = IdMedida;
            this.Estado = Estado;
            this.Productor = new Productores();
            this.Medida = new Medidas();
        }


        public Productos()
        {
            // TODO: Complete member initialization
            this.Productor = new Productores();
            this.Medida = new Medidas();
        }

        public bool Insertar()
        {
            return conectar.EjecutarDB("Insert Into Productos (Nombre,Descripcion,Precio,IdMedida, Imagen,Estado,IdProductor) Values ('" + Nombre + "','" + Descripcion + "','" + Precio + "','" + IdMedida + "','" + Imagen + "','" + Estado + "','" + IdProductor + "')");
        }

        public bool Modificar(int IdProducto)
        {
            return conectar.EjecutarDB(" update  Productos  set Nombre ='" + Nombre + "' Descripcion ='" + Descripcion + "',Precio ='" + Precio + "',Imagen ='" + Imagen + "',IdMedida ='" + IdMedida + "',Estado ='" + Estado + "'where IdProducto = '" + IdProducto + "' ");
        }

        public bool Eliminar(int IdProducto)
        { 
            return conectar.EjecutarDB("Delete from  Productos  where IdProducto  =" + IdProducto);
        }

        public bool Buscar(int IdProducto)
        {
            bool mensaje = false;


            DataTable dt;

            dt = conectar.BuscarDb("Select a.IdProducto,a.Nombre,a.Descripcion,a.Precio,a.Imagen,a.Estado,a.IdMedida,a.IdProductor From Productos a  where a.IdProducto  = " + IdProducto);
            if (dt.Rows.Count > 0)
            {
                mensaje = true;

                this.IdProducto = (int)dt.Rows[0]["IdProducto"];
                this.Nombre = (String)dt.Rows[0]["Nombre"];
                this.Descripcion = (String)dt.Rows[0]["Descripcion"];
                this.IdMedida = (int)dt.Rows[0]["IdMedida"];
                this.IdProductor = (int)dt.Rows[0]["IdProductor"];
                this.Precio = float.Parse(dt.Rows[0]["Precio"].ToString());
                this.Imagen = (string)dt.Rows[0]["Imagen"];
                this.Estado = (bool)dt.Rows[0]["Estado"];

                this.Productor.Buscar(this.IdProductor);
                this.Medida.Buscar(this.IdMedida);
            }

            return mensaje;
        }

        public static DataTable Lista(String Campos, String FiltroWhere)
        {
            Conexion ConexionDB = new Conexion();
            return ConexionDB.BuscarDb("Select " + Campos + " From Productos a Inner Join Medidas m on a.IdMedida  = m.IdMedidas Inner Join Productores p on a.IdProductor = p.IdProductor Where " + FiltroWhere);
        }  
    }
}