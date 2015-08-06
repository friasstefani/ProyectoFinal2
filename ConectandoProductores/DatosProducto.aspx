<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="DatosProducto.aspx.cs" Inherits="ConectandoProductores.DatosProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <!-- Left Starts -->
        <div class="col-sm-5 images-block">
            <p> 
                <asp:Image ID="FotoImage" class="img-responsive thumbnail" runat="server" />
            </p>
        </div>
        <!-- Left Ends -->
        <!-- Right Starts -->
        <div class="col-sm-7 product-details">
            <!-- Product Name Starts -->
            <h2>
                <asp:Label ID="NombreLabel" runat="server" Text="Producto no encontrado"></asp:Label>
            </h2>
            <!-- Product Name Ends -->
            <hr/>
            <!-- Manufacturer Starts -->
            <ul class="list-unstyled manufacturer">
                <li>
                    <span>Estado:</span> <strong class="label label-success">Disponible</strong>
                </li>
            </ul>
            <!-- Manufacturer Ends -->
            <hr/>
            <!-- Price Starts -->
            <div class="price">
                <span class="price-head">Price :</span>
                <span class="price-new">$<asp:Label ID="PrecioLabel" runat="server" Text="00.00"></asp:Label></span>
            </div>
            <!-- Price Ends -->
            <hr />
            <!-- Available Options Starts -->
            <div class="options">
                <div class="form-group">
                    <div class="row">
                        <div class="col-md-2">
                            <label for="input-quantity">Cantidad:</label>
                        </div>

                        <div class="col-md-4"> 
                            <asp:TextBox ID="CantidadTextBox" Text="1" type="number" class="form-control" runat="server"></asp:TextBox>
                        </div>

                        <div class="col-md-4">
                            <asp:Button ID="AgragarCaritoButton" OnClick="AgragarCaritoButton_Click" runat="server" CssClass="btn btn-default" Text="Agregar al Carrito" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Right Ends -->

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
                                <asp:Button ID="AgregarCarritoButton" runat="server" Text="Agregar al Carrito" OnClick="AgregarCarritoButton_Click" CommandArgument='<%# Eval("IdProducto") %>' CssClass="btn btn-primary" />
                            </p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
