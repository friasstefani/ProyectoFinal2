using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
namespace BLL
{
   public  class PedidosDetalle
    {
        public int IdDetalle;
        public int IdPedidos;
        public int IdProducto;
        public int IdProductor;
        public double Precio;
        public double Cantidad;
        public string Foto;

        public PedidosDetalle(int idDetalle, int IdProductor, int IdPedidos, int IdProducto, double Precio, double Cantidad, string Foto)
        {
            this.IdDetalle = idDetalle;
            this.IdPedidos = IdPedidos;
            this.IdProducto = IdProducto;
            this.Precio = Precio;
            this.Cantidad = Cantidad;
            this.IdProductor = IdProductor;
            this.Foto = Foto;
        }

        public PedidosDetalle() {
            // TODO: Complete member initialization
        }


        public static DataTable ListaPedidos(String Campos, String FiltroWhere) {
            Conexion ConexionDB = new Conexion();
            return ConexionDB.BuscarDb("Select " + Campos + " From PedidosDetalles a Inner Join Productos b on a.IdProducto = b.IdProducto Inner Join Productores c on b.IdProductor = c.IdProductor Where " + FiltroWhere);
        }
    }
}
