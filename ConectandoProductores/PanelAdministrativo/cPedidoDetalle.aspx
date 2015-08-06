<%@ Page Title="" Language="C#" MasterPageFile="~/PanelAdministrativo/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="cPedidoDetalle.aspx.cs" Inherits="ConectandoProductores.PanelAdministrativo.cPedidoDetalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="well">
        <div class="row">
            <div class="col-md-4 col-md-offset-2">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="IdPedido"></asp:Label>
                    <asp:TextBox ID="IdPedidoTextBox" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Nombres"></asp:Label>
                    <asp:TextBox ID="NombreTextBox" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Cedula"></asp:Label>
                    <asp:TextBox ID="CedulaTextBox" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-md-4">

                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Fecha"></asp:Label>
                    <asp:TextBox ID="FechaTextBox" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Dirección"></asp:Label>
                    <asp:TextBox ID="DireccionTextBox" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Cedula"></asp:Label>
                    <asp:TextBox ID="CelularTextBox" CssClass="form-control" Enabled="false" runat="server"></asp:TextBox>
                </div>
            </div> 


            <div class="col-md-8 col-md-offset-2">
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

                                <td class="col-sm-1 col-md-1 text-center"><strong>$<%# Convert.ToDouble(Eval("Precio")).ToString("N2") %></strong></td>
                            <td class="col-sm-1 col-md-1 text-center"><strong>$<%# (Convert.ToDouble(Eval("Precio")) * Convert.ToDouble(Eval("Cantidad"))).ToString("N2") %></strong></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>  
    </div>
        </div>  
    </div>
</asp:Content>
