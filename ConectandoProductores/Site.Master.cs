using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores {
    public partial class Site : System.Web.UI.MasterPage {
        protected void Page_Load(object sender, EventArgs e) {
            int CantidadCarrito = 0;
            double MontoCarrito = 0;
            List<PedidosDetalle> carrito = new List<PedidosDetalle>();

            if (Session["Carrito"] == null) {
                Session["Carrito"] = carrito;
            } else {
                carrito = (List<PedidosDetalle>)Session["Carrito"];
            }

            CantidadCarrito = carrito.Count;

            foreach (PedidosDetalle item in carrito) {
                MontoCarrito = MontoCarrito + (item.Cantidad * item.Precio);
            }

            CarritoLabel.Text = "Carrito Compra: " + CantidadCarrito + " Item(s) - $RD " + MontoCarrito.ToString("N2");
        }
    }
}