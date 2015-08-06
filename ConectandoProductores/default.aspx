<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="default.aspx.cs" Inherits="ConectandoProductores._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="col-md-12">

            <div id="alerta" style="display: none;" class="alert alert-danger alert-dismissible fade in" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button>
                <h2>Oh ha ocurrido un error!</h2>
                <div id="mensaje">
                    <h3>
                        <asp:Label ID="MensajeLabel" runat="server" Text=""></asp:Label>
                    </h3>
                </div>
            </div>

            <div class="row carousel-holder hidden-phone hidden-print">

                <div class="col-md-12">
                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                        <ol class="carousel-indicators">
                            <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                            <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                            <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                        </ol>
                        <div class="carousel-inner">
                            <div class="item active">
                                <img class="slide-image" src="img/Sin%20título.png" alt="">
                            </div>
                            <div class="item">
                                <img class="slide-image" src="img/Sin%20título.png" alt="">
                            </div>
                            <div class="item">
                                <img class="slide-image" src="img/Sin%20título.png" alt="">
                            </div>
                        </div>
                        <a style="margin-top: 250px;" class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
                            <span class="fa fa-chevron-left"></span>
                        </a>
                        <a style="margin-top: 250px;" class="right carousel-control" href="#carousel-example-generic" data-slide="next">
                            <span class="fa fa-chevron-right"></span>
                        </a>
                    </div>
                </div>

            </div>

            <div class="well">
                <h2>Selección de Productos</h2>
            </div>

            <div class="row">

                <asp:Repeater ID="ProductosRepeater" runat="server"> 
                    <ItemTemplate>
                        <div class="col-sm-4 col-lg-4 col-md-4" style="margin-bottom: 10px;">
                            <div class="well">
                                <img src="<%#Eval("Imagen") %>" height="255" width="310" />

                                <div class="caption">
                                    <h4 class="pull-right">$<%#Eval("Precio") %></h4>
                                    <h4><a href="/DatosProducto.aspx?Id=<%#Eval("IdProducto") %>"><%#Eval("Nombre") %></a></h4>

                                    <div>
                                        Productor: <%#Eval("Productor") %>
                                    </div>
                                    <div>
                                        <%#Eval("Descripcion") %>
                                    </div>
                                </div>

                                <asp:Button ID="AgregarCarritoButton" runat="server" Text="Agregar al Carrito" OnClick="AgregarCarritoButton_Click" CommandArgument='<%# Eval("IdProducto") %>' CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

                <div class="col-sm-4 col-lg-4 col-md-4">
                    <div class="well">
                        <h4><strong>Gustaria ofrecer sus productos en nuestra web?</strong></h4>
                        <p>Esta página le permitirá ofrecer sus productos a una variedad de consumidores con la facilidad desde su hogar.</p>

                        <div class="form-group">

                            <span>Nombre de Usuario</span>
                            <asp:TextBox ID="NombreUsuarioTextBox" runat="server" CssClass="form-control"></asp:TextBox>

                            <span>Contraseña</span>

                            <asp:TextBox ID="ContrasenaTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>

                            <span>Confirmación</span>
                            <asp:TextBox ID="ConfirmacionTextBox" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>

                        </div>
                        <div>
                            <asp:CompareValidator
                                ID="ContrasenaCompareValidator"
                                ForeColor="Red"
                                ControlToValidate="ContrasenaTextBox"
                                ControlToCompare="ConfirmacionTextBox"
                                runat="server"
                                ErrorMessage="La contraseña y la confirmación de contraseña no coinciden">  
                            </asp:CompareValidator>
                        </div>
                        <asp:Button ID="NuevoProductorButton" runat="server" Text="Convertirme en Productor" OnClick="NuevoProductorButton_Click" CssClass="btn btn-primary" />
                    </div>
                </div>
            </div>

            <br />
            <div class="alert alert-info text-center">
                <a href="/ListadoProductos.aspx" title="Ver Todos los Productos">Ver Todos los Productos</a>
            </div>
        </div>
    </div>
</asp:Content>
