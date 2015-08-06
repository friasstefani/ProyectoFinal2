<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ConectandoProductores.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Inicio de Sesion | Productores Dominicanos</title>
    <!-- Bootstrap CSS -->
    <link href="/css/bootstrap.min.css" rel="stylesheet" />

    <!-- bootstrap theme -->
    <link href="/css/bootstrap-theme.css" rel="stylesheet" />

    <!--external css-->
    <!-- font icon -->
    <link href="/css/elegant-icons-style.css" rel="stylesheet" />
    <link href="/css/font-awesome.css" rel="stylesheet" />

    <!-- Custom styles -->
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/style-responsive.css" rel="stylesheet" />

    <!-- HTML5 shim and Respond.js IE8 support of HTML5 -->
    <!--[if lt IE 9]>
    <script src="js/html5shiv.js"></script>
    <script src="js/respond.min.js"></script>
    <![endif]-->
</head>
<body class="login-img3-body">
    <div class="container">
        <form class="login-form" runat="server">
            <div class="login-wrap">
                <p class="login-img"><i class="icon_lock_alt"></i></p>
                <div class="input-group">
                    <span class="input-group-addon"><i class="icon_profile"></i></span>
                    <asp:TextBox ID="NombreUsuarioTextBox" class="form-control" runat="server" placeholder="Nombre de Usuario"></asp:TextBox>  
                </div>
                <div class="input-group">
                    <span class="input-group-addon"><i class="icon_key_alt"></i></span>
                    <asp:TextBox ID="ClaveTextBox" TextMode="Password" class="form-control" runat="server" placeholder="Clave"></asp:TextBox>  
                </div>

                <asp:Button ID="LoginButton" runat="server" class="btn btn-primary btn-lg btn-block" Text="Registrarme" OnClick="LoginButton_Click" />
                <div class="text-center">
                    <a href="/">Volver Atras</a>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
