<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="PedidoRealizado.aspx.cs" Inherits="ConectandoProductores.PedidoRealizado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="well text-center">

        <h1>Pedido guardado correctamente</h1>
        <h2>Los proveedores de sus productos estaran en contacto para confirmar su pedido</h2>
        <h3>Gracias por preferirnos!</h3>

        <div>
            <a href="/" style="font-size: medium;" title="Volver al inicio" class="label label-primary">Volver al inicio</a>
        </div>
    </div>

    <hr />
    <div class="row text-center">
        <asp:Repeater ID="ProductosRepeater" runat="server">
            <ItemTemplate>
                <div class="col-md-3 col-sm-6 hero-feature" style="margin-bottom: 10px;">
                    <div class="well">
                        <a href="/DatosProducto.aspx?Id=<%#Eval("IdProducto") %>">
                            <img src="<%# Eval("Imagen") %>" height="150" width="200" />
                        </a>

                        <div class="caption">
                            <h3 class="text-center">
                                <a href="/DatosProducto.aspx?Id=<%#Eval("IdProducto") %>"><%#Eval("Nombre") %></a>
                            </h3>

                            <p>
                                <asp:Button ID="AgregarCarritoButton" runat="server" Text="Agregar al Carrito" OnClick="AgregarCarritoButton_Click" CommandArgument = '<%# Eval("IdProducto") %>' CssClass="btn btn-primary" />
                            </p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
