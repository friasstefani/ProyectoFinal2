using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores.PanelAdministrativo {
    public partial class cPedidoDetalle : System.Web.UI.Page {
        int id = 0;
        int CantidadCarrito = 0;
        double MontoCarrito = 0;

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                int.TryParse(Request.QueryString["IdPedido"], out id);

                if (id > 0) {
                    Pedidos pedido = new Pedidos();
                    Clientes cliente = new Clientes();

                    pedido.Buscar(id);

                    cliente.Buscar(pedido.IdCliente);
                    IdPedidoTextBox.Text = pedido.IdPedidos.ToString();
                    NombreTextBox.Text = cliente.Nombres + " " + cliente.Apellidos;
                    FechaTextBox.Text = pedido.Fecha.ToString("dd-MM-yyyy");
                    DireccionTextBox.Text = cliente.Direccion;
                    CedulaTextBox.Text = cliente.cedula;
                    CelularTextBox.Text = cliente.Celular;

                    foreach (PedidosDetalle item in pedido.PedidosDetalle) {
                        MontoCarrito = MontoCarrito + (item.Cantidad * item.Precio);
                    }


                    // Create the Table
                    DataTable CarritoDataTable = new DataTable("Carrito");

                    // Build the Orders schema
                    CarritoDataTable.Columns.Add("IdPedidos", Type.GetType("System.Int32"));
                    CarritoDataTable.Columns.Add("IdProducto", Type.GetType("System.Int32"));
                    CarritoDataTable.Columns.Add("IdProductor", Type.GetType("System.Int32"));
                    CarritoDataTable.Columns.Add("Precio", Type.GetType("System.Double"));
                    CarritoDataTable.Columns.Add("Cantidad", Type.GetType("System.Double"));
                    CarritoDataTable.Columns.Add("Foto", Type.GetType("System.String"));
                    CarritoDataTable.Columns.Add("Nombre", Type.GetType("System.String"));
                    CarritoDataTable.Columns.Add("Productor", Type.GetType("System.String")); 

                    foreach (var item in pedido.PedidosDetalle) {
                        Productos producto = new Productos();
                        Productores productor = new Productores();
                        producto.Buscar(item.IdProducto);
                        productor.Buscar(item.IdProductor);

                        CarritoDataTable.Rows.Add(item.IdPedidos, item.IdProducto, item.IdProductor, item.Precio, item.Cantidad, producto.Imagen, producto.Nombre, productor.Nombres);
                    }

                    ProductosRepeater.DataSource = CarritoDataTable;
                    ProductosRepeater.DataBind();
                }
            }
        }
    }
}