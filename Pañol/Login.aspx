<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Pañol.Login" %>

<!DOCTYPE html>

<html lang="es">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login - Pañol</title>
 <link href="~/icono.ico" rel="shortcut icon" type="image/x-icon" />
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>
    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="~/icono.ico" rel="shortcut icon" type="image/x-icon" />
    <style type="text/css">
        .auto-style1 {
            height: 36px;
        }
    </style>
</head>
<body>
<div class="navbar navbar-inverse navbar-fixed-top" style="left: 0; right: 0; top: 0; height: 64px">
            <div class="container">
                <div class="navbar-header">
                     <h2 style="color:orange" class="auto-style1">
                    <asp:Image ID="Image1" runat="server" Height="35px" ImageUrl="~/Imagenes/icono.png" Width="52px" />
                     Pañol</h2>
                 </div>
            </div>
     </div>
<form runat="server">
 <div class="form-group">
     <div class="container body-content">
 <br />
 <div class="row">
 <div class="col-md-4">
     <div class="container">
        <h1><span class="label label-default">Iniciar sesion</span></h1> 
            <table style="width: 100%;">
                <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label1" runat="server" Text="Legajo:" ></asp:Label><br />
                        <asp:TextBox ID="txtLegajo" runat="server" Height="27px" Width="352px" MaxLength="4" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
                    </td>    
                </tr>
                 <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label2" runat="server" Text="Contraseña:"></asp:Label><br />
                        <asp:TextBox ID="txtContraseña" runat="server" Height="27px" Width="352px" MaxLength="10" TextMode="Password" ></asp:TextBox>
                    </td>    
                </tr>
            </table>
      <br />   
         <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" class="btn btn-warning btn-lg" OnClick="btnIngresar_Click"/>
    </div>
</div>
</div>
        <div >
            <hr />
            <footer>
                <p>&copy; <%: DateTime.Now.Year %> - Sewtech Argentina SRL</p>
            </footer>
        </div>
</div>
</div>
</form>
<script>
    function solonumeros(e) {

            var key;

            if (window.event) // IE
            {
        key = e.keyCode;
            }
            else if (e.which) // Netscape/Firefox/Opera
            {
        key = e.which;
            }

            if (key < 48 || key > 57) {
                return false;
            }

            return true;
        }

</script>
</body>
</html>
