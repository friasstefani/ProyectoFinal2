using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConectandoProductores.PanelAdministrativo
{
    public partial class rUsuario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["Tipo"] != null)
                {
                    switch (Request.QueryString["Tipo"])
                    {
                        case "1":
                            NombreRegistroLabel.Text = "Registro de Clientes";
                            break;
                        case "2":
                            NombreRegistroLabel.Text = "Registro de Productores";
                            break;
                        default:
                            break;
                    }
                }
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["Tipo"] != null)
                {
                    switch (Request.QueryString["Tipo"])
                    {
                      case "1":
                            if (Request.QueryString["IdCliente"] != null)
                            {
                                int codigo = 0;
                                int.TryParse(Request.QueryString["IdCliente"].ToString(), out codigo);
                                BuscarUsuario(codigo);

                            } if (IdTextBox.Text == string.Empty)
                            {
                                eliminarButton.Enabled = false;
                            }
                            else
                            {
                                eliminarButton.Enabled = true;
                            }

                            break;
                        case "2":
                            if (Request.QueryString["IdProductor"] != null)
                            {
                                int codigo = 0;
                                int.TryParse(Request.QueryString["IdProductor"].ToString(), out codigo);
                                BuscarUsuario(codigo);

                            } if (IdTextBox.Text == string.Empty)
                            {
                                eliminarButton.Enabled = false;
                            }
                            else
                            {
                                eliminarButton.Enabled = true;
                            }

                            break;
                        default:
                            break;
                    }


                }
            }
        }

        protected void guardarButton_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["Tipo"] != null)
            {
                Usuarios usuario = new Usuarios();
                usuario.Nombres = NombreUsuarioTextBox.Text;
                usuario.Clave = ContrasenaTextBox.Text;

                switch (Request.QueryString["Tipo"])
                {
                    case "1":
                        usuario.IdTipoUsuario = (int)TiposUsuarios.Tipos.Cliente;
                        usuario.Insertar();

                        Clientes c = new Clientes();
                        c.IdUsuario = usuario.IdUsuario;
                        c.Nombres = NombresTextBox.Text;
                        c.Apellidos = ApellidoTextBox.Text;
                        c.Direccion = DireccionTextBox.Text;
                        c.Celular = celularTextBox.Text;
                        c.Telefono = telefonoTextBox.Text;
                        c.cedula = cedulaTextBox.Text;
                        c.Email = EmailTextBox.Text; 

                        if (Session["Codigo"] == null)
                        {
                            if (c.Insertar())
                            {
                                LabelMesaage.Text = "Guardado correctamente";
                                IdTextBox.Text = "";
                                NombresTextBox.Text = "";
                                ApellidoTextBox.Text = "";
                                cedulaTextBox.Text = "";
                                telefonoTextBox.Text = "";
                                celularTextBox.Text = "";
                                DireccionTextBox.Text = "";
                                EmailTextBox.Text = "";
                                NombreUsuarioTextBox.Text = "";
                                ContrasenaTextBox.Text = "";

                            }
                        }
                        else
                        {
                            int id = Convert.ToInt32(Session["Codigo"]);
                            if (c.Modificar(id))
                            {
                                LabelMesaage.Text = "Modificado correctamente";
                            }
                        }

                        break;
                    case "2":
                        usuario.IdTipoUsuario = (int)TiposUsuarios.Tipos.Productor;
                        usuario.Insertar();

                        Productores p = new Productores();
                        p.IdUsuario = usuario.IdUsuario;
                        p.Nombres = NombresTextBox.Text;
                        p.Apellidos = ApellidoTextBox.Text;
                        p.Direccion = DireccionTextBox.Text;
                        p.Celular = celularTextBox.Text;
                        p.Telefono = telefonoTextBox.Text;
                        p.cedula = cedulaTextBox.Text;
                        p.Email = EmailTextBox.Text;

                        if (Session["Codigo"] == null)
                        {
                            if (p.Insertar())
                            {
                                LabelMesaage.Text = "Guardado correctamente";

                                IdTextBox.Text = "";
                                NombresTextBox.Text = "";
                                ApellidoTextBox.Text = "";
                                cedulaTextBox.Text = "";
                                telefonoTextBox.Text = "";
                                celularTextBox.Text = "";
                                DireccionTextBox.Text = "";
                                EmailTextBox.Text = "";
                                NombreUsuarioTextBox.Text = "";
                                ContrasenaTextBox.Text = "";
                            }
                        }
                        else
                        {
                            int id = Convert.ToInt32(Session["Codigo"]);
                            if (p.Modificar(id))
                            {
                                LabelMesaage.Text = "Modificado correctamente";
                            }
                        } break;
                    default:
                        break;
                }
            }
        }

        protected void eliminarButton_Click(object sender, EventArgs e)
        {

            if (Request.QueryString["Tipo"] != null)
            {
                switch (Request.QueryString["Tipo"])
                {
                    case "1":
                        Clientes c = new Clientes();
                        int codigo = 0;
                        int.TryParse(IdTextBox.Text, out codigo);
                        if (c.Eliminar(codigo))
                        {
                            LabelMesaage.Text = "Eliminado correctamente";
                        }

                        break;
                    case "2":

                        Productores p = new Productores();
                        int clave = 0;
                        int.TryParse(IdTextBox.Text, out clave);

                        if (p.Eliminar(clave))
                        {
                            LabelMesaage.Text = "Eliminado correctamente";
                        }
                        break;
                    default:
                        break;
                }
            }
        }
        public void BuscarUsuario(int codigo)
        {

            if (Request.QueryString["Tipo"] != null)
            {
                switch (Request.QueryString["Tipo"])
                {

                    case "1":
                        Clientes c = new Clientes();
                        Usuarios u = new Usuarios();
                        if (c.Buscar(codigo))
                        {
                            Session["Codigo"] = c.IdCliente;
                            IdTextBox.Text = c.IdCliente.ToString();
                            NombresTextBox.Text = c.Nombres;
                            ApellidoTextBox.Text = c.Apellidos;
                            cedulaTextBox.Text = c.cedula;
                            telefonoTextBox.Text = c.Telefono;
                            celularTextBox.Text = c.Celular;
                            DireccionTextBox.Text = c.Direccion;
                            EmailTextBox.Text = c.Email;
                            NombreUsuarioTextBox.Text = u.Nombres;
                            ContrasenaTextBox.Text = u.Clave;
                        }

                        break;
                    case "2":

                        Productores p = new Productores();
                        Usuarios s = new Usuarios();
                        if (p.Buscar(codigo))
                        {
                            Session["Codigo"] = p.IdProductor;
                            IdTextBox.Text = p.IdProductor.ToString();
                            NombresTextBox.Text = p.Nombres;
                            ApellidoTextBox.Text = p.Apellidos;
                            cedulaTextBox.Text = p.cedula;
                            telefonoTextBox.Text = p.Telefono;
                            celularTextBox.Text = p.Celular;
                            DireccionTextBox.Text = p.Direccion;
                            EmailTextBox.Text = p.Email;
                            NombreUsuarioTextBox.Text = s.Nombres;
                            ContrasenaTextBox.Text = s.Clave;
                        }

                        else
                        {
                            //Label.Text = ("Paiente no existe");
                        }
                        break;
                    default:
                        break;
                }


            }
        }

    }
}