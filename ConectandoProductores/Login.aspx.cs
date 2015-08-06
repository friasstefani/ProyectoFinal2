using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Security;

namespace ConectandoProductores {
    public partial class Login : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void LoginButton_Click(object sender, EventArgs e) {
            if (Usuarios.Logon(NombreUsuarioTextBox.Text, ClaveTextBox.Text)) {
                FormsAuthentication.RedirectFromLoginPage(NombreUsuarioTextBox.Text, true);

                Usuarios usuario = new Usuarios();
                usuario.BuscarPorNombre(NombreUsuarioTextBox.Text); 
                Session["IdTipoUsuario"] = usuario.IdTipoUsuario; 
                Response.Redirect("/PanelAdministrativo/");
            }
        }
    }
}