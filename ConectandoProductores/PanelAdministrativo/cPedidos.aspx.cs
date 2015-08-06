using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores.PanelAdministrativo {
    public partial class cPedidos : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!this.Page.User.Identity.IsAuthenticated) {
                FormsAuthentication.RedirectToLoginPage();
            }


        }

        protected void ButtonBuscar_Click(object sender, EventArgs e) {
            string filtro = TextBoxFiltro.Text;
            Usuarios usuario = new Usuarios();
            usuario.BuscarPorNombre(User.Identity.Name);

            if (usuario.IdTipoUsuario == (int)TiposUsuarios.Tipos.Cliente) {
                if (filtro.Length > 0) {
                    ConsultaGridView.DataSource = Pedidos.ListaPedidos("pedido.IdPedidos,pedido.Fecha,pedido.IdCliente,cliente.Nombres,pedido.Total", DropDownListTipoFiltro.SelectedValue + "  like '%" + filtro + "%' And pedido.IdCliente = '" + Clientes.getIdClientePorIdUsuario(usuario.IdUsuario) + "'");
                    ConsultaGridView.DataBind();
                } else {
                    ConsultaGridView.DataSource = Pedidos.ListaPedidos("pedido.IdPedidos,pedido.Fecha,pedido.IdCliente,cliente.Nombres,pedido.Total", DropDownListTipoFiltro.SelectedValue + " != '" + filtro + "' And pedido.IdCliente = '" + Clientes.getIdClientePorIdUsuario(usuario.IdUsuario) + "'");
                    ConsultaGridView.DataBind();
                }
            } else {
                if (filtro.Length > 0) {
                    ConsultaGridView.DataSource = Pedidos.ListaPedidos("pedido.IdPedidos,pedido.Fecha,pedido.IdCliente,cliente.Nombres,pedido.Total", DropDownListTipoFiltro.SelectedValue + "  like '%" + filtro + "%'");
                    ConsultaGridView.DataBind();
                } else {
                    ConsultaGridView.DataSource = Pedidos.ListaPedidos("pedido.IdPedidos,pedido.Fecha,pedido.IdCliente,cliente.Nombres,pedido.Total", DropDownListTipoFiltro.SelectedValue + " != '" + filtro + "'");
                    ConsultaGridView.DataBind();
                }
            }
        }
    }
}