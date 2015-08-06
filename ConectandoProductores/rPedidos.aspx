<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rPedidos.aspx.cs" Inherits="ConectandoProductores.rPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- CONTENIDO DEL REGISTRO --%>
    <div class="row">

        <div class="col-md-8">
            <h1>Carrito de Compra</h1>
            <table class="table table-hover">
                <thead>
                    <tr>
                        <th>Producto</th>
                        <th>Cantidad</th>
                        <th class="text-center">Precio</th>
                        <th class="text-center">Total</th>
                        <th></th>
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
                                    <asp:TextBox ID="IdProductoTextBox" class="form-control" Visible="false" ReadOnly="true" runat="server" Text='<%# Eval("IdProducto") %>'></asp:TextBox>
                                    <asp:TextBox ID="CantidadProductoText" class="form-control" runat="server" Text='<%# Eval("Cantidad") %>'></asp:TextBox>
                                </td>

                                <td class="col-sm-1 col-md-1 text-center"><strong>$<%# Convert.ToDouble(Eval("Precio")).ToString("N2") %></strong></td>
                                <td class="col-sm-1 col-md-1 text-center"><strong>$<%# (Convert.ToDouble(Eval("Precio")) * Convert.ToDouble(Eval("Cantidad"))).ToString("N2") %></strong></td>
                                <td class="col-sm-1 col-md-1">
                                    <asp:Button ID="QuitarItemCarritoButton" class="btn btn-warning" OnClick="QuitarItemCarritoButton_Click" CommandArgument='<%# Eval("IdProducto") %>' runat="server" Text="Quitar" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>


            <div class="pull-left">
                <a href="../default.aspx" class="btn btn-link">Continuar Seleccionando Productos >> </a>
            </div>
            <div class="pull-right">
                <asp:Button ID="ActualizarCarroButton" runat="server" Text="Actualizar Carrito" CssClass="btn btn-info" OnClick="ActualizarCarroButton_Click" Font-Size="Medium" />
            </div>
        </div>

        <div class="col-md-4">
            <br />
            <br />
            <div class="panel panel-default">
                <div class="panel-heading">Resumen de Pedido</div>
                <div class="panel panel-body">
                    <span style="font-size: 20px;" class="text-info">SubTotal</span>
                    <asp:Label ID="CantidadCarritoLabel" runat="server" Style="font-size: 20px;" CssClass="text-danger" Text="(0 Items): "></asp:Label>
                    <asp:Label ID="CarritoLabel" runat="server" Style="font-size: 20px;" Text="$RD 9,500.00"></asp:Label>
                    <div class="text-justify">
                        <h5>Al confirmar su pedido la orden sera solicitada y sus articulos enviados con la mayor brevedad posible.
                        </h5>
                    </div>

                    <br />
                    <asp:Button ID="guardarButton" runat="server" OnClick="guardarButton_Click" Text="Confirmar Pedido" CssClass="btn btn-success" />
                    <asp:Button ID="eliminarButton" runat="server" OnClick="eliminarButton_Click" Text="Cancelar" CssClass="btn btn-danger" />
                </div>
            </div>
        </div>
    </div>
    <br />

</asp:Content>
