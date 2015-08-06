using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores.PanelAdministrativo {
    public partial class cProductos : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!this.Page.User.Identity.IsAuthenticated) {
                FormsAuthentication.RedirectToLoginPage();
            }


        }
        protected void ButtonBuscar_Click(object sender, EventArgs e) {
            string filtro = TextBoxFiltro.Text;
            Usuarios usuario = new Usuarios();
            usuario.BuscarPorNombre(User.Identity.Name);
             
            if (usuario.IdTipoUsuario == (int)TiposUsuarios.Tipos.Administrador) {
                if (filtro.Length > 0) {
                    ConsultaGridView.DataSource = Productos.Lista("a.IdProducto,a.Nombre,a.Descripcion,a.Precio,m.IdMedidas as IdMedida,m.Descripcion as Medida,p.IdProductor,p.Nombres as Productor ", DropDownListTipoFiltro.Text + "  like '%" + filtro + "%'");
                    ConsultaGridView.DataBind();
                } else {
                    ConsultaGridView.DataSource = Productos.Lista("a.IdProducto,a.Nombre,a.Descripcion,a.Precio,m.IdMedidas as IdMedida,m.Descripcion as Medida,p.IdProductor,p.Nombres as Productor ", DropDownListTipoFiltro.Text + " != '" + filtro + "'");
                    ConsultaGridView.DataBind();
                }  
            } else {
                if (filtro.Length > 0) {
                    ConsultaGridView.DataSource = Productos.Lista("a.IdProducto,a.Nombre,a.Descripcion,a.Precio,m.IdMedidas as IdMedida,m.Descripcion as Medida,p.IdProductor", DropDownListTipoFiltro.Text + "  like '%" + filtro + "%' And p.IdProductor = '" + Productores.getIdProductorPorIdUsuario(usuario.IdUsuario) + "'");
                    ConsultaGridView.DataBind();
                } else {
                    ConsultaGridView.DataSource = Productos.Lista("a.IdProducto,a.Nombre,a.Descripcion,a.Precio,m.IdMedidas as IdMedida,m.Descripcion as Medida ", DropDownListTipoFiltro.Text + " != '" + filtro + "' And p.IdProductor = '" + Productores.getIdProductorPorIdUsuario(usuario.IdUsuario) + "'");
                    ConsultaGridView.DataBind();
                }
            }

            //if (filtro.Length > 0) {
            //    ConsultaGridView.DataSource = Productos.Lista("a.IdProducto,a.Nombre,a.Descripcion,a.Precio,m.IdMedidas as IdMedida,m.Descripcion as Medida,p.IdProductor,p.Nombres as Productor ", DropDownListTipoFiltro.Text + "  like '%" + filtro + "%' And p.IdProductor = '" + Productores.getIdProductorPorIdUsuario(usuario.IdUsuario) + "'");
            //    ConsultaGridView.DataBind();
            //} else {
            //    ConsultaGridView.DataSource = Productos.Lista("a.IdProducto,a.Nombre,a.Descripcion,a.Precio,m.IdMedidas as IdMedida,m.Descripcion as Medida,p.IdProductor,p.Nombres as Productor ", DropDownListTipoFiltro.Text + " != '" + filtro + "' And p.IdProductor = '" + Productores.getIdProductorPorIdUsuario(usuario.IdUsuario) + "'");
            //    ConsultaGridView.DataBind();
            //}
        }
    }
}