<%@ Page Title="" Language="C#" MasterPageFile="~/PanelAdministrativo/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="rMedidas.aspx.cs" Inherits="ConectandoProductores.PanelAdministrativo.rMedidas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%-- NOMBRE DEL REGISTRO --%>
    <div>
        <h3 class="page-header">Registro de Medidas</h3>
    </div>
    <%-- NOMBRE DEL REGISTRO --%>

    <%-- CONTENIDO DEL REGISTRO --%>
    <div>
        <asp:Label ID="Label1" runat="server" Text="IdMedida"></asp:Label>

        <asp:TextBox ID="MedidaTextBox" runat="server" Enabled="False" OnTextChanged="MedidaTextBox_TextChanged" Width="138px" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="Tipo de Medida"></asp:Label>

        <asp:TextBox ID="tipoTextBox" required="true" runat="server" Width="136px" CssClass="form-control"></asp:TextBox>
        <br />
        <br />
    </div>
    <%-- CONTENIDO DEL REGISTRO --%>

    <%-- BOTONES --%>
    <div> 
        <a href="/Registros/RMedidas.aspx" class="btn btn-primary" style="width:68px;">Nuevo</a> 

        <asp:Button ID="guardarButton" runat="server" OnClick="guardarButton_Click" Text="Guardar" Width="70px" CssClass="btn btn-success" />

        <asp:Button ID="eliminarButton" runat="server" OnClick="eliminarButton_Click" Text="Eliminar" Width="68px" CssClass="btn btn-danger" />
        <br />
        <asp:Label ID="LabelMesaage" runat="server"></asp:Label>
    </div>
    <%-- BOTONES --%>
</asp:Content>
