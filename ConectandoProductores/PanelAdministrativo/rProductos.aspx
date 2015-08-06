<%@ Page Title="" Language="C#" MasterPageFile="~/PanelAdministrativo/PaginaMaestra.Master" AutoEventWireup="true" CodeBehind="rProductos.aspx.cs" Inherits="ConectandoProductores.PanelAdministrativo.rProductos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   
        <%-- NOMBRE DEL REGISTRO --%>
        <div>
            <h3 class="page-header">Registro de Productos</h3>
        </div>
    
            <div id="alerta" style="display: none;" class="alert alert-danger alert-dismissible fade in" role="alert">
                <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">×</span></button>
                <h2>Oh ha ocurrido un error!</h2>
                <div id="mensaje">
                    <h3>
                        <asp:Label ID="MensajeLabel" runat="server" Text=""></asp:Label>
                    </h3>
                </div>
            </div>

        <%-- NOMBRE DEL REGISTRO --%>
        <%-- CONTENIDO DEL REGISTRO --%>
        <div class="row">
            <div class="col-md-3">
                <asp:Label ID="Label1" runat="server" Text="IdProducto"></asp:Label>
                <asp:TextBox ID="IdProductoTextBox" runat="server" Enabled="False" Width="138px" CssClass="form-control"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label6" runat="server" Text="Nombre"></asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                    runat="server"
                    ForeColor="Red"
                    ControlToValidate="NombreTextBox"
                    ErrorMessage=" - El nombre es obligatorio"> 
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="NombreTextBox" runat="server" Width="136px" MaxLength="35" CssClass="form-control"></asp:TextBox>

                <asp:Label ID="Label2" runat="server" Text="Descripcion"></asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                    runat="server"
                    ForeColor="Red"
                    ControlToValidate="NombreTextBox"
                    ErrorMessage=" - La descripcion es obligatoria"> 
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="DescripcionTextBox" TextMode="MultiLine" runat="server" Width="136px" MaxLength="250" CssClass="form-control"></asp:TextBox>
                <br />
                <asp:Label ID="Label4" runat="server" Text="Precio"></asp:Label>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                    runat="server"
                    ForeColor="Red"
                    ControlToValidate="NombreTextBox"
                    ErrorMessage=" - El precio es obligatorio"> 
                </asp:RequiredFieldValidator>
                <asp:TextBox ID="PrecioTextBox" type="number" MaxLength="5" runat="server" Width="136px" CssClass="form-control"></asp:TextBox>
                <br />

            </div>

            <div class="col-md-4">

                <asp:Label ID="Label5" runat="server" Text="Tipo de Medida"></asp:Label>
                <div class="row">
                    <div class="col-md-9">
                        <asp:DropDownList ID="TipoMedidaDropDownList" CssClass="form-control" runat="server">
                            <asp:ListItem Text="[Seleccione Una]" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <a class="btn btn-primary" data-toggle="modal" href="#myModal">Nuevo</a>
                    </div>
                </div>
                <br />

                <a href="#" class="thumbnail">
                    <img id="img" style="height: 170px; width: 100%;" src="https://cdn4.iconfinder.com/data/icons/miu/22/editor_image_picture_photo-128.png" alt="..." />
                </a>

                <asp:Label ID="Label3" runat="server" Text="Subir Imagen"></asp:Label>
                <asp:FileUpload ID="ImagenProductoFileUpload" onchange="showimagepreview(this)" runat="server" />
            </div>
        </div>
        <%-- CONTENIDO DEL REGISTRO --%>

        <%-- BOTONES --%>
        <div>
            <a href="/PanelAdministrativo/rProductos.aspx" class="btn btn-primary" style="width: 68px;">Nuevo</a>

            <asp:Button ID="guardarButton" runat="server" Text="Guardar" Width="70px" CssClass="btn btn-success" OnClick="guardarButton_Click" />

            <asp:Button ID="eliminarButton" runat="server" Text="Eliminar" Width="68px" CssClass="btn btn-danger" OnClick="eliminarButton_Click" />
            <br />
            <asp:Label ID="LabelMesaage" runat="server"></asp:Label>

        </div>
        <%-- BOTONES --%>


        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title">Nuevo Tipo de Medida</h4>
                    </div>
                    <div class="modal-body">
                        <div>
                            <asp:TextBox ID="tipoTextBox" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>

                    <div class="modal-footer">
                        <button data-dismiss="modal" class="btn btn-danger" type="button">Cerrar</button>
                        <asp:Button ID="NuevoTipoMedidaButton" CausesValidation="false" runat="server" OnClick="guardarTipoMedidaButton_Click" Text="Guardar" CssClass="btn btn-success" />
                    </div>
                </div>
            </div>
        </div>
        <!-- modal --> 
</asp:Content>
