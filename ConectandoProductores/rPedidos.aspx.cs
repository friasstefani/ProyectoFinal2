using BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores {
    public partial class rPedidos : System.Web.UI.Page {
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

                CarritoLabel.Text = "$RD " + MontoCarrito.ToString("N2");
                CantidadCarritoLabel.Text = "(" + CantidadCarrito + " Items):";

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

        protected void QuitarItemCarritoButton_Click(object sender, EventArgs e) {
            List<PedidosDetalle> listado = new List<PedidosDetalle>();
            Button button;
            int Argumento;

            //Asignamos al boton el objecto boton al que se ha hecho click
            button = (sender as Button);

            //optenemos el dato que esta en el CommandArgument del boton
            Argumento = Convert.ToInt32(button.CommandArgument);

            //verificamos si el carrito tiene contenido
            if (Session["Carrito"] != null) {
                listado = (List<PedidosDetalle>)Session["Carrito"];
            }

            //obtenemos el item seleccionado haciendo un find o buscar dentro del listado donde el id del producto sea igual al que se selecciono 
            //para luego borrarlo
            PedidosDetalle ItemSeleccionado = (PedidosDetalle)listado.Find(dato => dato.IdProducto == Argumento);
            listado.RemoveAll(dato => dato.IdProducto == Argumento);

            //guardamos el carrito en la variable de session.
            Session["Carrito"] = listado;
            Response.Redirect("/rPedidos.aspx");
        }

        protected void ActualizarCarroButton_Click(object sender, EventArgs e) {
            List<PedidosDetalle> listado = new List<PedidosDetalle>();
            Productos producto = new Productos();

            //verificamos si el carrito tiene contenido
            if (Session["Carrito"] != null) {
                listado = (List<PedidosDetalle>)Session["Carrito"];
            }

            foreach (RepeaterItem item in ProductosRepeater.Items) {
                TextBox IdProductoTextBox = (TextBox)item.FindControl("IdProductoTextBox");
                TextBox CantidadTextBox = (TextBox)item.FindControl("CantidadProductoText");
                int idProducto = Convert.ToInt32(IdProductoTextBox.Text);
                int cantidad = 0;
                int.TryParse(CantidadTextBox.Text, out cantidad);
                PedidosDetalle detalle = new PedidosDetalle();

                if (cantidad > 0) {
                     
                    PedidosDetalle ItemSeleccionado = (PedidosDetalle)listado.Find(dato => dato.IdProducto == idProducto);
                    listado.RemoveAll(dato => dato.IdProducto == idProducto);

                    producto = new Productos();
                    producto.Buscar(idProducto);

                    detalle.IdProducto = producto.IdProducto;
                    detalle.IdProductor = 1; //Todo: revisar bien lo que necesitamos con los productores
                    detalle.Precio = producto.Precio;
                    detalle.Foto = producto.Imagen;
                    detalle.Cantidad = cantidad;

                    //agregamos el item al carrito...
                    listado.Add(detalle);
                }
            }

            //guardamos el carrito en la variable de session.
            Session["Carrito"] = listado;
            Response.Redirect("/rPedidos.aspx");
        }

        protected void guardarButton_Click(object sender, EventArgs e) {
            Response.Redirect("/ConfirmacionPedido.aspx");
        }

        protected void eliminarButton_Click(object sender, EventArgs e) {
            Session["Carrito"] = null;
            Response.Redirect("/");
        }
    }
}