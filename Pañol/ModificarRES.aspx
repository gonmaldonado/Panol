<%@ Page Title="Modificar responsable" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarRES.aspx.cs" Inherits="Pañol.ModificarADM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <br />
    <form action="">
 <div class="form-group">
 <div class="row">
     <div class="col-md-4">
        <h1><span class="label label-default">Modificar responsable</span></h1> 
            <table style="width: 100%;">
                <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label1" runat="server" Text="Legajo:" ></asp:Label><br />
                        <asp:TextBox ID="txtLegajo" runat="server" Height="27px" Width="352px" MaxLength="4" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
                    </td>    
                </tr>
             <tr>
              <td>
                <br />
                  <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" class="btn btn-warning btn-s" OnClick="btnSeleccionar_Click" />
                  <asp:Button ID="btnBorrar" runat="server" Text="Borrar seleccionar" class="btn btn-warning btn-s" OnClick="btnBorrar_Click"  />
              </td>
           </tr>
            </table>
         <asp:Panel ID="pUsuario" runat="server">
            <table>
                 <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label><br />
                        <asp:TextBox ID="txtNombre" runat="server" Height="27px" Width="352px" MaxLength="20" ></asp:TextBox>
                    </td>    
                </tr>
                   <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label5" runat="server" Text="Apellido:"></asp:Label><br />
                        <asp:TextBox ID="txtApellido" runat="server" Height="27px" Width="300px" MaxLength="20" ></asp:TextBox>
                    </td>    
                </tr>
                     <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label3" runat="server" Text="Contraseña:"></asp:Label><br />
                        <asp:TextBox ID="txtContraseña" runat="server" Height="27px" Width="300px" MaxLength="20" TextMode="Password" ></asp:TextBox>
                       
                    </td>    
                </tr>
                     <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label4" runat="server" Text="Repetir contraseña:"></asp:Label><br />
                        <asp:TextBox ID="txtConfContraseña" runat="server" Height="27px" Width="300px" MaxLength="20" TextMode="Password" ></asp:TextBox>
                        
                    </td>    
                </tr>
                     <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label6" runat="server" Text="Rol:"></asp:Label><br />
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Width="152px">
                            <asp:ListItem>Administrador</asp:ListItem>
                            <asp:ListItem>Estandar</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>    
                </tr>

            </table>

      <br />   
         <asp:Button ID="btnEntrada" runat="server" Text="Modificar" class="btn btn-warning btn-lg" OnClick="btnEntrada_Click"  />
         <a href="Default.aspx" class="btn btn-secondary btn-lg">Cancelar </a>
      </asp:Panel>
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
</asp:Content>
