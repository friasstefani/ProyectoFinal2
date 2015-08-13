<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmacionPedido.aspx.cs" Inherits="ConectandoProductores.ConfirmacionPedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- CONTENIDO DEL REGISTRO --%> 
    <div class="col-md-12">
        <div id="alerta" style="display: none;" class="alert alert-danger alert-dismissible fade in" role="alert">
            <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button>
            <h2>Oh, ha ocurrido un error!</h2>
            <div id="mensaje">
                <h3>
                    <asp:Label ID="MensajeLabel" runat="server" Text=""></asp:Label>
                </h3>
            </div>
        </div>
    </div>

    <div class="col-md-8">
        <h1>Carrito de Compra</h1>
        <table class="table table-hover">
            <thead>
                <tr>
                    <th style="width: 60%;">Producto</th>
                    <th style="width: 10%;">Cantidad</th>
                    <th style="width: 15%;" class="text-center">Precio</th>
                    <th style="width: 15%;" class="text-center">Total</th>
                </tr>
            </thead>
            <tbody>

                <asp:Repeater ID="ProductosRepeater" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="col-sm-8 col-md-6">
                                <div class="media">
                                    <a class="thumbnail pull-left" href="#">
                                        <img class="media-object" src="<%# Eval("Foto") %>" style="width: 72px; height: 72px;" alt="Alt Tag" />
                                    </a>

                                    <div class="media-body">
                                        <h4 class="media-heading"><a href="#"><%# Eval("Nombre") %></a></h4>
                                        <h5 class="media-heading">Productor: <a href="#"><%#Eval("Productor") %></a></h5>
                                        <span>Estado: </span>
                                        <span class="text-success"><strong>Disponible</strong></span>
                                    </div>
                                </div>
                            </td>

                            <td class="col-sm-1 col-md-1" style="text-align: center">
                                <strong><%# Eval("Cantidad") %></strong></td>
                            </td>

                                <td class="col-sm-1 col-md-1 text-center"><strong>$<%# Convert.ToDouble(Eval("Precio")).ToString("N2") %></strong></td>
                            <td class="col-sm-1 col-md-1 text-center"><strong>$<%# (Convert.ToDouble(Eval("Precio")) * Convert.ToDouble(Eval("Cantidad"))).ToString("N2") %></strong></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>


        <div class="pull-left">
            <a href="../default.aspx" class="btn btn-link">Continuar Seleccionando Productos >> </a>
        </div>
    </div>

    <div class="col-md-4">
        <div id="panelLogin" class="col-md-12">
            <div>
                <div class="form-group">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="icon_profile"></i></span>
                        <asp:TextBox ID="UsuarioTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group">
                    <div class="input-group">
                        <span class="input-group-addon"><i class="icon_key_alt"></i></span>
                        <asp:TextBox ID="ClaveTextBox" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>


                <div class="row">
                    <div class="col-md-6">
                        <asp:Button ID="RegistrarmeButton" CausesValidation="false"  runat="server" OnClick="RegistrarmeButton_Click" CssClass="btn btn-primary btn-lg btn-block" Text="Registrarme" />

                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="CancelarPButton" CausesValidation="false"  Width="100%" OnClick="cancelarButton_Click" runat="server" Text="Cancelar" CssClass="btn btn-danger btn-lg btn-block" />
                    </div>
                </div>
                <br />
            </div>
        </div>
     
            <div id="panelRegistro" class="col-md-12">
                <div class="text-center">
                    <h2>Datos de Personales</h2>
                </div>

                <asp:Label ID="Label2" runat="server" Text="Nombres"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server"
                    ControlToValidate="NombresTextBox"
                    ForeColor="Red"
                    ErrorMessage=" - El nombre es obligatorio"> 
                </asp:RequiredFieldValidator>

                <asp:TextBox ID="NombresTextBox" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="Label3" runat="server" Text="Apellidos"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server"
                    ForeColor="Red"
                    ControlToValidate="ApellidoTextBox"
                    ErrorMessage=" - El apellido es obligatorio"> 
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="ApellidoTextBox" runat="server" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="Label4" runat="server" Text="Cedula"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server"
                    ForeColor="Red"
                    ControlToValidate="cedulaTextBox"
                    ErrorMessage=" - La cedula es obligatoria"> 
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="cedulaTextBox" runat="server" CssClass="form-control"></asp:TextBox>


                <asp:Label ID="Label6" runat="server" Text="Celular"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                    runat="server"
                    ForeColor="Red"
                    ControlToValidate="celularTextBox"
                    ErrorMessage=" - El celular es obligatorio"> 
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="celularTextBox" type="tel" runat="server" MaxLength="10" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="Label7" runat="server" Text="Direccion"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                    runat="server"
                    ForeColor="Red"
                    ControlToValidate="DireccionTextBox"
                    ErrorMessage=" - La direccion es obligatoria"> 
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="DireccionTextBox" runat="server" CssClass="form-control"></asp:TextBox>


                <div class="text-center">
                    <h2>Información de Usuario</h2>
                </div>

                <span>Nombre de Usuario</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                    runat="server"
                    ForeColor="Red"
                    ControlToValidate="NombreUsuarioTextBox"
                    ErrorMessage=" - El nombre obligatorio"> 
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="NombreUsuarioTextBox" runat="server" CssClass="form-control"></asp:TextBox>

                <span>Contraseña</span>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                    runat="server"
                    ForeColor="Red"
                    ControlToValidate="ContrasenaTextBox"
                    ErrorMessage=" - La contraseña es obligatoria"> 
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="ContrasenaTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>

                <span>Confirmación</span>
                <asp:TextBox ID="ConfirmacionTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>

                <asp:CompareValidator
                    ID="ContrasenaCompareValidator"
                    ForeColor="Red"
                    ControlToValidate="ContrasenaTextBox"
                    ControlToCompare="ConfirmacionTextBox"
                    runat="server"
                    ErrorMessage="La contraseña y la confirmación de contraseña no coinciden">
                </asp:CompareValidator>

                <div class="row">
                    <div class="col-md-6">
                        <asp:Button ID="guardarButton" Width="100%" OnClick="guardarButton_Click" runat="server" Text="Confirmar Pedido" CssClass="btn btn-success" />
                    </div>
                    <div class="col-md-6">
                        <asp:Button ID="cancelarButton"  CausesValidation="false"  Width="100%" OnClick="cancelarButton_Click" runat="server" Text="Cancelar" CssClass="btn btn-danger" />
                    </div>
                </div>
            </div>
               
    </div>
    <br />
</asp:Content>

