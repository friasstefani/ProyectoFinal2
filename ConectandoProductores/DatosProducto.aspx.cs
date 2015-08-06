using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace ConectandoProductores {
    public partial class DatosProducto : System.Web.UI.Page {
        int id = 0;

        protected void Page_Load(object sender, EventArgs e) {
            ProductosRepeater.DataSource = Productos.Lista("Top(4) a.IdProducto,a.Nombre,a.Descripcion,a.Precio,a.Imagen,a.Estado,m.IdMedidas as IdMedida,m.Descripcion as Medida,p.IdProductor,p.Nombres as Productor ", "a.IdProducto > 0");
            ProductosRepeater.DataBind();

            Productos producto = new Productos();
            int.TryParse(Request.QueryString["Id"], out id);

            if (producto.Buscar(id)) {
                PrecioLabel.Text = producto.Precio.ToString("N2");
                FotoImage.ImageUrl = producto.Imagen;
                NombreLabel.Text = producto.Nombre;
            }
        }

        protected void AgregarCarritoButton_Click(object sender, EventArgs e) {

            List<PedidosDetalle> listado = new List<PedidosDetalle>();
            PedidosDetalle item = new PedidosDetalle();
            Productos producto = new Productos();
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

            producto.Buscar(Argumento);

            item.IdProducto = producto.IdProducto;
            item.Precio = producto.Precio;
            item.Foto = producto.Imagen;
            item.IdProductor = producto.IdProductor;

            try {
                if (listado.Where(dato => dato.IdProducto == item.IdProducto).FirstOrDefault().IdProducto > 0) {
                    PedidosDetalle ItemSeleccionado = (PedidosDetalle)listado.Find(dato => dato.IdProducto == item.IdProducto);
                    listado.RemoveAll(dato => dato.IdProducto == item.IdProducto);
                    item.Cantidad = ItemSeleccionado.Cantidad + 1;
                }
            } catch (NullReferenceException ex) {
                item.Cantidad = 1;
                Console.Write(ex.Message);
            }

            //agregamos el item al carrito
            listado.Add(item);

            //guardamos el carrito en la variable de session.
            Session["Carrito"] = listado;
            Response.Redirect("/DatosProducto.aspx?Id=" + id);
        }

        protected void AgragarCaritoButton_Click(object sender, EventArgs e) {

            List<PedidosDetalle> listado = new List<PedidosDetalle>();
            PedidosDetalle item = new PedidosDetalle();
            Productos producto = new Productos();
            int Codigo = 0;

            //verificamos si el carrito tiene contenido
            if (Session["Carrito"] != null) {
                listado = (List<PedidosDetalle>)Session["Carrito"];
            }

            if (Request.QueryString["Id"] != null) {
                Codigo = Convert.ToInt32(Request.QueryString["Id"]);
            }

            producto.Buscar(Codigo);

            item.IdProducto = producto.IdProducto;
            item.IdProductor = producto.IdProductor;
            item.Precio = producto.Precio;
            item.Foto = producto.Imagen;

            try {
                if (listado.Where(dato => dato.IdProducto == item.IdProducto).FirstOrDefault().IdProducto > 0) {
                    PedidosDetalle ItemSeleccionado = (PedidosDetalle)listado.Find(dato => dato.IdProducto == item.IdProducto);
                   
                    listado.RemoveAll(dato => dato.IdProducto == item.IdProducto);

                    if (Convert.ToDouble(CantidadTextBox.Text) > 0) {
                        item.Cantidad = ItemSeleccionado.Cantidad + Convert.ToDouble(CantidadTextBox.Text);
                    }

                }
            } catch (NullReferenceException ex) {

                if (Convert.ToDouble(CantidadTextBox.Text) > 0) {
                    item.Cantidad = Convert.ToDouble(CantidadTextBox.Text);
                }

                Console.Write(ex.Message);
            }
            

            //si la cantidad del producto a agregar es mayor k cero entonces lo agregamos al carrito
            //de lo contrario no porque etonces el total seria 0 ya que no agregaria nada.
            if (item.Cantidad > 0) {

                //agregamos el item al carrito
                listado.Add(item);

                //guardamos el carrito en la variable de session.
                Session["Carrito"] = listado;
            }

            Response.Redirect("/DatosProducto.aspx?Id=" + id);
        }
    }
}