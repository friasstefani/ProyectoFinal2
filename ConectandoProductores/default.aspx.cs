using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ConectandoProductores {
    public partial class _default : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {

            //selecciona los ultimos 5 productos que se han insertando
            //haciendo un top(5) ordenandolo de forma descendente por idproducto...
            ProductosRepeater.DataSource = Productos.Lista("Top(5) a.IdProducto,a.Nombre,a.Descripcion,a.Precio,a.Imagen,a.Estado,m.IdMedidas as IdMedida,m.Descripcion as Medida,p.IdProductor,p.Nombres as Productor ", "a.IdProducto > 0  order by a.IdProducto desc");
            ProductosRepeater.DataBind();

            //identifica si el carrito de compras esta vacio, si lo esta pues lo crea...
            if (Session["Carrito"] == null) {
                Session["Carrito"] = new List<PedidosDetalle>();
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
                //esta condicion identifica si existe un item dentro del carrito para entonces agregar mas cantidades o agregar un nuevo item.
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

        protected void NuevoProductorButton_Click(object sender, EventArgs e) {

            //crea un nuevo productor
            if (NombreUsuarioTextBox.Text.Length > 0 && ContrasenaTextBox.Text.Length > 0) {
                Usuarios usuario = new Usuarios();
                usuario.Nombres = NombreUsuarioTextBox.Text;
                usuario.IdTipoUsuario = (int)TiposUsuarios.Tipos.Productor;
                usuario.Clave = ContrasenaTextBox.Text;
                if (usuario.Insertar()) {
                    Productores productor = new Productores();
                    productor.IdUsuario = usuario.IdUsuario;
                    productor.Nombres = NombreUsuarioTextBox.Text;
                    productor.Apellidos = "";
                    productor.Telefono = "";
                    productor.Celular = "";
                    productor.cedula = "";
                    productor.Direccion = "";
                    productor.Email = "";
                    productor.Insertar();
                  Response.Redirect("/Login.aspx");
                } else {
                    
                    MensajeLabel.Text = usuario.Nombres;
                    MensajeLabel.ForeColor = System.Drawing.Color.Red;

                }
            } else {
                MensajeLabel.Text = "Debe completar los datos del registro para confirmar su información";
                MensajeLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}