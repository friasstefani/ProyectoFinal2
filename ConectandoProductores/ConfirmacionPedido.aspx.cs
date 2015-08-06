using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores {
    public partial class ConfirmacionPedido : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                int CantidadCarrito = 0;
                double MontoCarrito = 0;
                List<PedidosDetalle> carrito = new List<PedidosDetalle>();

                if (Session["Carrito"] == null) {
                    Session["Carrito"] = carrito;
                } else {
                    carrito = (List<PedidosDetalle>)Session["Carrito"];
                }

                CantidadCarrito = carrito.Count;

                foreach (PedidosDetalle item in carrito) {
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

                foreach (var item in carrito) {
                    Productos producto = new Productos();
                    Productores productor = new Productores();
                    producto.Buscar(item.IdProducto);
                    productor.Buscar(item.IdProductor);

                    CarritoDataTable.Rows.Add(item.IdPedidos, item.IdProducto, item.IdProductor, item.Precio, item.Cantidad, item.Foto, producto.Nombre, productor.Nombres);
                }

                ProductosRepeater.DataSource = CarritoDataTable;
                ProductosRepeater.DataBind();
            }
        }

        protected void guardarButton_Click(object sender, EventArgs e) {
            Pedidos pedido = new Pedidos();
            Clientes cliente = new Clientes();
            double monto = 0;
            List<PedidosDetalle> detalle = new List<PedidosDetalle>();

            if (Session["Carrito"] != null) {

                Usuarios usuario = new Usuarios();
                usuario.Nombres = NombreUsuarioTextBox.Text;
                usuario.IdTipoUsuario = (int)TiposUsuarios.Tipos.Cliente;
                usuario.Clave = ContrasenaTextBox.Text;
                if (usuario.Insertar()) {

                    cliente.IdUsuario = usuario.IdUsuario;

                    cliente.Nombres = NombresTextBox.Text.Trim();
                    cliente.Apellidos = ApellidoTextBox.Text;
                    cliente.Direccion = DireccionTextBox.Text;
                    cliente.cedula = cedulaTextBox.Text;
                    cliente.Celular = celularTextBox.Text;

                    if (cliente.Insertar()) {

                        detalle = (List<PedidosDetalle>)Session["Carrito"];

                        detalle.ForEach(delegate(PedidosDetalle item) {
                            monto = monto + (item.Precio * item.Cantidad);
                            pedido.AgregarPedidosDetalle(0, item.IdProductor, 0, item.IdProducto, item.Precio, item.Cantidad, item.Foto);
                        });

                        pedido.Fecha = DateTime.Today;
                        pedido.Total = monto;
                        pedido.IdCliente = cliente.IdCliente;

                        if (pedido.Insertar()) {
                            Session["Carrito"] = null;

                            Response.Redirect("/PedidoRealizado.aspx");
                        }

                    }
                } else {
                    MensajeLabel.Text = usuario.Nombres;
                    MensajeLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        protected void cancelarButton_Click(object sender, EventArgs e) {
            Session["Carrito"] = null;
            Response.Redirect("/");
        }

        protected void RegistrarmeButton_Click(object sender, EventArgs e) {
            if (Usuarios.Logon(UsuarioTextBox.Text, ClaveTextBox.Text)) { 
                if (Session["Carrito"] != null) {
                    Usuarios usuario = new Usuarios();
                    Pedidos pedido = new Pedidos();
                    Clientes cliente = new Clientes();
                    double monto = 0;
                    List<PedidosDetalle> detalle = new List<PedidosDetalle>();

                    usuario.BuscarPorNombre(UsuarioTextBox.Text);
                    if (cliente.BuscarIdUsuario(usuario.IdUsuario)) {
                        FormsAuthentication.RedirectFromLoginPage(UsuarioTextBox.Text, true);

                        detalle = (List<PedidosDetalle>)Session["Carrito"];

                        detalle.ForEach(delegate(PedidosDetalle item) {
                            monto = monto + (item.Precio * item.Cantidad);
                            pedido.AgregarPedidosDetalle(0, item.IdProductor, 0, item.IdProducto, item.Precio, item.Cantidad, item.Foto);
                        });


                        pedido.Fecha = DateTime.Today;
                        pedido.Total = monto;
                        pedido.IdCliente = cliente.IdCliente;

                        if (pedido.Insertar()) {
                            Session["Carrito"] = null;
                            Response.Redirect("/PedidoRealizado.aspx");
                        }
                    } else {
                        MensajeLabel.Text = "Usuario no encontrado";
                        MensajeLabel.ForeColor = System.Drawing.Color.Red;
                    }
                } else {
                    MensajeLabel.Text = "No posee articulos en el carrito";
                    MensajeLabel.ForeColor = System.Drawing.Color.Red;
                }
            } else {
                MensajeLabel.Text = "Usuario no encontrado";
                MensajeLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
   
}