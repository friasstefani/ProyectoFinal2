﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores.PanelAdministrativo {
    public partial class cMedidas : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!this.Page.User.Identity.IsAuthenticated) {
                FormsAuthentication.RedirectToLoginPage();
            }


        }

        protected void ButtonBuscar_Click(object sender, EventArgs e) {
            string filtro = TextBoxFiltro.Text;

            if (filtro.Length > 0) {
                ConsultaGridView.DataSource = Medidas.Lista("IdMedidas,Descripcion", DropDownListTipoFiltro.Text + "  like '%" + filtro + "%'");
                ConsultaGridView.DataBind();
            } else {
                ConsultaGridView.DataSource = Medidas.Lista("IdMedidas,Descripcion", DropDownListTipoFiltro.Text + " != '" + filtro + "'");
                ConsultaGridView.DataBind();
            }
        }
    }
}