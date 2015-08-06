﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores.PanelAdministrativo {
    public partial class _default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {

            if (!User.Identity.IsAuthenticated) {
                FormsAuthentication.RedirectToLoginPage();
            } 
        }
    }
}