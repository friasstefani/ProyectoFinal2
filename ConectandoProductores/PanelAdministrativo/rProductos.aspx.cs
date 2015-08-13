using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores.PanelAdministrativo {
    public partial class rProductos : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!this.Page.User.Identity.IsAuthenticated) {
                FormsAuthentication.RedirectToLoginPage();
            }

            TipoMedidaDropDownList.DataSource = Medidas.Lista("IdMedidas,Descripcion", "IdMedidas > 0 ");
            TipoMedidaDropDownList.DataValueField = "IdMedidas";
            TipoMedidaDropDownList.DataTextField = "Descripcion";
            TipoMedidaDropDownList.DataBind();
            if (!IsPostBack) {
                if (Request.QueryString["IdProducto"] != null) {
                    int codigo = 0;
                    int.TryParse(Request.QueryString["IdProducto"].ToString(), out codigo);
                    BuscarProducto(codigo);

                }

                if (IdProductoTextBox.Text == string.Empty) {
                    eliminarButton.Enabled = false;
                } else {
                    eliminarButton.Enabled = true;
                }
            }
        }

        protected void guardarButton_Click(object sender, EventArgs e) {
            Productos productos = new Productos();
            string imagen;
            int id = 0;

            productos.Nombre = NombreTextBox.Text;
            productos.Descripcion = DescripcionTextBox.Text;
            productos.Precio = float.Parse(PrecioTextBox.Text);
            imagen = "Producto-" + productos.Descripcion.Trim() + ".Png";

            productos.Imagen = "/ImagenesSubidas/" + imagen;
            productos.IdMedida = Convert.ToInt32(TipoMedidaDropDownList.SelectedValue);

            Usuarios usuario = new Usuarios();
            usuario.BuscarPorNombre(User.Identity.Name);
            productos.IdProductor = Productores.getIdProductorPorIdUsuario(usuario.IdUsuario);

            if (Request.QueryString["Id"] != null) {
                int.TryParse(Request.QueryString["Id"], out id);
            }

            if (id == 0) {
                productos.Insertar();
                NombreTextBox.Text = "";
                DescripcionTextBox.Text = "";
                PrecioTextBox.Text = "";
                IdProductoTextBox.Text = "";
            } else {
                productos.Modificar(id);
            }

            if (ImagenProductoFileUpload.HasFile) {
                string directory = Server.MapPath("~/ImagenesSubidas/"); //Convierte la ruta virtual a la ruta fisica del servidor..
                var fileName = Path.GetFileName(ImagenProductoFileUpload.FileName);
                ImagenProductoFileUpload.SaveAs(Path.Combine(directory, imagen));
               MensajeLabel.Text = "Información Guardada Correctamente";
              
            }
        }

        protected void eliminarButton_Click(object sender, EventArgs e) {
            Productos Producto = new Productos();
            int codigo = 0;
            int.TryParse(IdProductoTextBox.Text, out codigo);
            if (Producto.Eliminar(codigo)) {
                MensajeLabel.Text = "Eliminado correctamente";
                NombreTextBox.Text = "";
                DescripcionTextBox.Text = "";
                PrecioTextBox.Text = "";
                IdProductoTextBox.Text = "";
            }
        }

        protected void guardarTipoMedidaButton_Click(object sender, EventArgs e) {
            Medidas M = new Medidas();
            M.Descripcion = tipoTextBox.Text;
            M.InsertaYRetornaId();

            TipoMedidaDropDownList.DataSource = Medidas.Lista("IdMedidas,Descripcion", "IdMedidas > 0 ");
            TipoMedidaDropDownList.DataValueField = "IdMedidas";
            TipoMedidaDropDownList.DataTextField = "Descripcion";
            TipoMedidaDropDownList.DataBind();
            TipoMedidaDropDownList.SelectedValue = M.IdMedidas.ToString();
        }

        public void BuscarProducto(int codigo) {
            Productos p = new Productos();

            if (p.Buscar(codigo)) {
                Session["Codigo"] = p.IdProducto;
                IdProductoTextBox.Text = p.IdProducto.ToString();
                NombreTextBox.Text = p.Nombre;
                DescripcionTextBox.Text = p.Descripcion;
                PrecioTextBox.Text = p.Precio.ToString();
                TipoMedidaDropDownList.SelectedValue = p.IdMedida.ToString();

            } else {
                MensajeLabel.Text = "Producto no encontrado";
            }
        }


    }
}