<%@ Page Title="" Language="C#" MasterPageFile="~/PanelAdministrativo/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="rUsuario.aspx.cs" Inherits="ConectandoProductores.PanelAdministrativo.rUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- NOMBRE DEL REGISTRO --%>
    <div>
        <h3>
            <asp:Label ID="NombreRegistroLabel" runat="server" CssClass="page-header" Text="Registro de Usuarios"></asp:Label></h3>
    </div>
    <%-- NOMBRE DEL REGISTRO --%>

    <%-- CONTENIDO DEL REGISTRO --%>
    <div class="row">
        <div class="col-md-6">
            <div class="col-md-6">
                <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>

                <asp:TextBox ID="IdTextBox" runat="server" Enabled="False" CssClass="form-control"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Nombres"></asp:Label>

                <asp:TextBox ID="NombresTextBox" required="true" runat="server" CssClass="form-control"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label3" runat="server" Text="Apellidos"></asp:Label>

                <asp:TextBox ID="ApellidoTextBox" required="true" runat="server" CssClass="form-control"></asp:TextBox>

                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Cedula"></asp:Label>

                <asp:TextBox ID="cedulaTextBox" required="true" runat="server" CssClass="form-control"></asp:TextBox>


            </div>

            <div class="col-md-6">
                <asp:Label ID="Label5" runat="server" Text="Telefono"></asp:Label>

                <asp:TextBox ID="telefonoTextBox" required="true" MaxLength="10" runat="server" CssClass="form-control"></asp:TextBox>


                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Text="Celular"></asp:Label>

                <asp:TextBox ID="celularTextBox" required="true" runat="server" MaxLength="10"  CssClass="form-control"></asp:TextBox>

                <br />
                <br />
                <asp:Label ID="Label7" runat="server" Text="Direccion"></asp:Label>

                <asp:TextBox ID="DireccionTextBox" required="true" runat="server" CssClass="form-control"></asp:TextBox>


                <br />
                <br />
                <asp:Label ID="Label8" runat="server" Text="Email"></asp:Label>

                <asp:TextBox ID="EmailTextBox" required="true" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        
        <div class="col-md-4 col-sm-offset-1">
            <div class="well">
                <div class="panel-body">
                    <div class="text-center">
                        <h2>Información de Usuario</h2>
                    </div>

                    <span>Nombre de Usuario</span>
                    <asp:TextBox ID="NombreUsuarioTextBox" runat="server" required="true" CssClass="form-control"></asp:TextBox>

                    <span>Contraseña</span>
                    <asp:TextBox ID="ContrasenaTextBox" runat="server" TextMode="Password" required="true" CssClass="form-control"></asp:TextBox>

                    <span>Confirmación</span>
                    <asp:TextBox ID="ConfirmacionTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                     
                    <asp:CompareValidator 
                        ID="ContrasenaCompareValidator" 
                        ForeColor="Black"
                        ControlToValidate="ContrasenaTextBox"
                        ControlToCompare="ConfirmacionTextBox"
                        runat="server" 
                        ErrorMessage="La contraseña y la confirmación de contraseña no coinciden">
                    </asp:CompareValidator>

                </div>
            </div>
        </div>
    </div>




    <%-- CONTENIDO DEL REGISTRO --%>
    <br />
    <%-- BOTONES --%>
    <div>
        <a href="/PanelAdministrativo/rUsuario.aspx" class="btn btn-primary" style="width: 68px;">Nuevo</a>

        <asp:Button ID="guardarButton" runat="server" Text="Guardar" Width="70px" CssClass="btn btn-success" OnClick="guardarButton_Click" />

        <asp:Button ID="eliminarButton" runat="server" Text="Eliminar" Width="68px" CssClass="btn btn-danger" OnClick="eliminarButton_Click" />
        <br />
        <asp:Label ID="LabelMesaage" runat="server"></asp:Label>
    </div>
    <%-- BOTONES --%>
</asp:Content>
