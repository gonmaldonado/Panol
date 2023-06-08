<%@ Page Title="Crear solicitante" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearSOL.aspx.cs" Inherits="Pañol.CrearSOL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <br />
    <form action="">
 <div class="form-group">
 <div class="row">
     <div class="col-md-4">
        <h1><span class="label label-default">Crear solicitante</span></h1> 
            <table style="width: 100%;">
                <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label1" runat="server" Text="Legajo:" ></asp:Label><br />
                        <asp:TextBox ID="txtLegajo" runat="server" Height="27px" Width="352px" MaxLength="4" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
                    </td>    
                </tr>
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

            </table>
      <br />   
         <asp:Panel ID="pMensaje" runat="server" ForeColor="Red">
             <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" Enabled="False" ReadOnly="True" Height="100px"  Width="352px" ForeColor="White" ></asp:TextBox>
         </asp:Panel>
         <asp:Button ID="btnEntrada" runat="server" Text="Crear" class="btn btn-warning btn-lg" OnClick="btnEntrada_Click" />
         <a href="Default.aspx" class="btn btn-secondary btn-lg">Cancelar </a>
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
