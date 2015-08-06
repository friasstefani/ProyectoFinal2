<%@ Page Title="" Language="C#" MasterPageFile="~/PanelAdministrativo/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="cPedidos.aspx.cs" Inherits="ConectandoProductores.PanelAdministrativo.cPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Label ID="Labelfiltro" runat="server" Text="Filtar"></asp:Label>
&nbsp;
    <asp:DropDownList ID="DropDownListTipoFiltro" runat="server" Height="23px" Width="159px">
        <asp:ListItem>Nombres</asp:ListItem>
    </asp:DropDownList>
&nbsp;
    <asp:TextBox ID="TextBoxFiltro" runat="server" Height="22px" Width="186px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="ButtonBuscar" runat="server" OnClick="ButtonBuscar_Click" Text="Buscar" />
    <br />
    <asp:GridView ID="ConsultaGridView" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" Width="100%">
        <AlternatingRowStyle BackColor="#DCDCDC" /> 
        <Columns>
            <asp:HyperLinkField DataNavigateUrlFields="IdPedidos" DataNavigateUrlFormatString="~/PanelAdministrativo/cPedidoDetalle.aspx?IdPedido={0}" HeaderText="Ver " Text="Ver pedido" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#0000A9" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#000065" />
    </asp:GridView>
&nbsp;
</asp:Content>
