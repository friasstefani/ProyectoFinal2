<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="ListadoProductos.aspx.cs" Inherits="ConectandoProductores.ListadoProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <!-- Jumbotron Header -->
         
        <!-- Title -->
        <div class="row">
            <div class="col-lg-12">
                <h3>Listado de Productos</h3>
            </div>
        </div>
        <!-- /.row -->

        <!-- Page Features -->
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
        </div>
        <!-- /.row -->
    </div>
</asp:Content>
