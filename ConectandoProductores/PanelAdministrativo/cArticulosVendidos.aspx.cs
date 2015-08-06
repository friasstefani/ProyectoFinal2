using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores.PanelAdministrativo {
    public partial class cArticulosVendidos : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!this.Page.User.Identity.IsAuthenticated) {
                FormsAuthentication.RedirectToLoginPage();
            } 
        }

        protected void ButtonBuscar_Click(object sender, EventArgs e) {
            string filtro = TextBoxFiltro.Text;
            Usuarios usuario = new Usuarios();
            usuario.BuscarPorNombre(User.Identity.Name);

            if (filtro.Length > 0) {
                ConsultaGridView.DataSource = PedidosDetalle.ListaPedidos(" a.IdDetalle,a.IdPedidos,a.IdProducto,b.Nombre,b.Descripcion,c.Nombres as Productor ,a.Cantidad,a.Precio,a.Cantidad * a.Precio as Importe", DropDownListTipoFiltro.SelectedValue + "  like '%" + filtro + "%' And c.idProductor = '" + Productores.getIdProductorPorIdUsuario(usuario.IdUsuario) + "'");
                ConsultaGridView.DataBind();
            } else {
                ConsultaGridView.DataSource = PedidosDetalle.ListaPedidos(" a.IdDetalle,a.IdPedidos,a.IdProducto,b.Nombre,b.Descripcion,c.Nombres as Productor ,a.Cantidad,a.Precio,a.Cantidad * a.Precio as Importe", DropDownListTipoFiltro.SelectedValue + " != '" + filtro + "' And c.idProductor = '" + Productores.getIdProductorPorIdUsuario(usuario.IdUsuario) + "'");
                ConsultaGridView.DataBind();
            }
        }
    }
}