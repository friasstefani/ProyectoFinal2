using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL {
    public class Pedidos {

        public enum EstadosPedidos {
            Pendiente = 1,
            EnEspera = 2,
            Enviado = 3,
            Finalizado = 4
        }

        /// <summary>
        /// retorna la descripcion del estado en el que esta
        /// </summary>
        /// <param name="Estado">tipo de estado solicitado</param>
        /// <returns>descripcion del estado</returns>
        public virtual string getEstadoPedido(EstadosPedidos Estado) {
            string valor = "";

            switch (Estado) {
                case EstadosPedidos.Pendiente:
                    valor = "Pendiente";
                    break; 
                case EstadosPedidos.Finalizado:
                    valor = "Finalizado";
                    break;
                case EstadosPedidos.Enviado:
                    valor = "Enviado";
                    break;
                case EstadosPedidos.EnEspera :
                    valor = "En Espera";
                    break;
            }

            return valor;
        }

        public int IdPedidos { get; set; }
        public int IdCliente { get; set; }
        public DateTime Fecha { get; set; }
        public Double Total { get; set; }

        public List<PedidosDetalle> PedidosDetalle = new List<PedidosDetalle>();

        Conexion conectar = new Conexion();

        public Pedidos(int IdPedidos, int IdProductor, int IdCliente, DateTime Fecha, Double Total) {
            this.IdPedidos = IdPedidos;
            this.IdCliente = IdCliente;
            this.Fecha = Fecha;
            this.Total = Total;
            PedidosDetalle = new List<PedidosDetalle>();
        }

        public Pedidos() {
            // TODO: Complete member initialization
        }

        public bool Insertar() {
            string comando = " Select getdate() ";
            int IdPedidos = Convert.ToInt32(conectar.GetDbValue("Insert Into Pedidos(IdCliente,Fecha,Total ) Values (" + IdCliente + ",'" + Fecha.ToString("MM/dd/yyyy") + "'," + Total + "); Select @@IDENTITY"));

            if (IdPedidos > 0) {
                comando = "select getDate() ";
                foreach (PedidosDetalle item in PedidosDetalle) {
                    comando += " Insert into PedidosDetalles (IdPedidos,IdProducto,IdProductor,Precio,Cantidad) Values(" + IdPedidos + "," + item.IdProducto + "," + item.IdProductor + "," + item.Precio + "," + item.Cantidad + ");";
                }

                conectar.EjecutarDB(comando);
            }

            return IdPedidos > 0;
        }

        public bool Modificar(int IdPedidos) {
            string comando;
            comando = "Update Pedidos Set IdCliente=" + IdCliente + " Fecha = '" + Fecha.ToString("MM/dd/yyyy") + " Total = '" + Total + "' Where IdPedidos =" + IdPedidos + " ;";

            conectar.EjecutarDB("Delete From DetalleRecetas Where IdPedidos = " + IdPedidos);

            foreach (PedidosDetalle item in PedidosDetalle) {
                comando += " Insert into DetalleRecetas (IdPedidos,IdProducto,Precio,Cantidad) Values(" + IdPedidos + "," + item.IdProducto + "," + item.Precio + "," + item.Cantidad + ");";
            }

            return conectar.EjecutarDB(comando);
        }

        public bool Eliminar(int IdPedidos) {
            conectar.EjecutarDB("delete from PedidosDetalle where IdPedidos = '" + IdPedidos + "' ");
            return conectar.EjecutarDB("Delete from Pedidos where IdPedidos ='" + IdPedidos + "' ");
        }


        public bool Buscar(int IdPedidos) {
            bool mensaje = false;
            DataTable dt;

            dt = conectar.BuscarDb("select * from Pedidos where IdPedidos = " + IdPedidos);
            if (dt.Rows.Count > 0) {
                mensaje = true;

                this.IdPedidos = (int)dt.Rows[0]["IdPedidos"];
                this.IdCliente = (int)dt.Rows[0]["IdCliente"];
                this.Fecha = (DateTime)dt.Rows[0]["Fecha"];
                this.Total = (double)dt.Rows[0]["Total"];
            }

            dt = conectar.BuscarDb("Select * from PedidosDetalles where IdPedidos = " + IdPedidos);

            foreach (DataRow datos in dt.Rows) {
                AgregarPedidosDetalle(this.IdPedidos, int.Parse(datos["IdProductor"].ToString()), int.Parse(datos["IdPedidos"].ToString()), int.Parse(datos["IdProducto"].ToString()), float.Parse(datos["Precio"].ToString()), float.Parse(datos["Cantidad"].ToString()),"");
            }

            return mensaje;
        }

        public static DataTable Lista(String Campos, String FiltroWhere) {
            Conexion ConexionDB = new Conexion();
            return ConexionDB.BuscarDb("Select " + Campos + " From Pedidos Where " + FiltroWhere);
        }

        public static DataTable ListaPedidos(String Campos, String FiltroWhere) {
            Conexion ConexionDB = new Conexion();
            return ConexionDB.BuscarDb("Select " + Campos + " From Pedidos pedido Inner Join Clientes cliente " +
                "on pedido.IdCliente = cliente.IdCliente Where " + FiltroWhere);
        }

        public void AgregarPedidosDetalle(int IdDetalle, int IdProductor,int idPedidos, int IdProducto, double Precio, double Cantidad, string Foto) {
            PedidosDetalle.Add(new PedidosDetalle(IdDetalle, IdProductor, idPedidos, IdProducto, Precio, Cantidad, Foto));
        }

    }
}