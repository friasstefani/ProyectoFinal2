using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores {
    public partial class PedidoRealizado : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            ProductosRepeater.DataSource = Productos.Lista("Top(4) a.IdProducto,a.Nombre,a.Descripcion,a.Precio,a.Imagen,a.Estado,m.IdMedidas as IdMedida,m.Descripcion as Medida,p.IdProductor,p.Nombres as Productor ", "a.IdProducto > 0");
            ProductosRepeater.DataBind();
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
            Response.Redirect("/");
        }
    }
}