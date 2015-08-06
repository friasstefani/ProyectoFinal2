using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores.PanelAdministrativo {
    public partial class rMedidas : System.Web.UI.Page {

        protected void Page_Load(object sender, EventArgs e) {

            if (!this.Page.User.Identity.IsAuthenticated) {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack) {
                if (Request.QueryString["IdMedidas"] != null) {
                    int codigo = 0;
                    int.TryParse(Request.QueryString["IdMedidas"].ToString(), out codigo);
                    BuscarMedida(codigo);

                }
            }
        }

        protected void MedidaTextBox_TextChanged(object sender, EventArgs e) {

        }

        protected void guardarButton_Click(object sender, EventArgs e) {
            Medidas M = new Medidas();
            M.Descripcion = tipoTextBox.Text;
            if (Session["Codigo"] == null) {
                if (M.Insertar()) {
                    LabelMesaage.Text = "Guardado correctamente";
                }
            } else {
                int id = Convert.ToInt32(Session["Codigo"]);
                if (M.Modificar(id)) {
                    LabelMesaage.Text = "Modificado correctamente";
                }
            }
        }

        protected void eliminarButton_Click(object sender, EventArgs e) {
            Medidas M = new Medidas();
            int codigo = 0;
            int.TryParse(MedidaTextBox.Text, out codigo);

            if (M.Eliminar(codigo)) {
                LabelMesaage.Text = "Eliminado correctamente";
            }
        }

        public void BuscarMedida(int codigo) {
            Medidas M = new Medidas();

            if (M.Buscar(codigo)) {
                Session["Codigo"] = M.IdMedidas;
                MedidaTextBox.Text = M.IdMedidas.ToString();
            } else {
                LabelMesaage.Text = ("No Existe Tal Medida");
            }
        }

        protected void nuevoButton_Click(object sender, EventArgs e) {
            Response.Redirect("/Registros/RMedidas.aspx");
        }
    }
}