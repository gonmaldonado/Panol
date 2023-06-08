<%@ Page Title="Modificar solicitante" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarSOL.aspx.cs" Inherits="Pañol.ModificarSOL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <br />
    <form action="">
 <div class="form-group">
     <div class="row">
        <div class="col-md-6">
         <h1><span class="label label-default">Modificar solicitante</span></h1>
    <table>
         <tr>
            <td style="height: 22px; width: 95px"><asp:Label ID="Label1" runat="server" Text="Legajo:"></asp:Label><br />
             <asp:TextBox ID="txtLegajo" runat="server" Height="27px" Width="352px" onkeypress="javascript:return solonumeros(event)" ></asp:TextBox>
                <ajaxToolkit:AutoCompleteExtender 
                ID="AutoCompleteExtender"
                runat="server"
                Enabled="true"
                TargetControlID="txtLegajo"
                MinimumPrefixLength="2"
                ServiceMethod="ObtenerLegajos"
                ServicePath="~/WSArticulos.asmx"
                EnableCaching="true"
                UseContextKey="true"
                FirstRowSelected="true"
                CompletionSetCount="10"
                CompletionInterval="0">
              </ajaxToolkit:AutoCompleteExtender>
         </td>
      </tr>
     <tr>
          <td>
              <br />
              <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" class="btn btn-warning btn-s" OnClick="btnSeleccionar_Click"/>
              <asp:Button ID="btnBorrar" runat="server" Text="Borrar seleccionar" class="btn btn-warning btn-s" OnClick="btnBorrar_Click"/>
         </td>    
      </tr>
    </table>
     </div>
   </div>
     <br />
  <asp:Panel ID="panelModificar" runat="server"> 
    <div class="row">
        <div class="col-md-4">
         <table style="width: 100%;">
                 <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label3" runat="server" Text="Nombre:"></asp:Label><br />
                        <asp:TextBox ID="txtNombre" runat="server" Height="27px" Width="352px" MaxLength="20" ></asp:TextBox>
                    </td>    
                </tr>
                   <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label5" runat="server" Text="Apellido:"></asp:Label><br />
                        <asp:TextBox ID="txtApellido" runat="server" Height="27px" Width="300px" MaxLength="20" ></asp:TextBox>
                    </td>    
                </tr>

            </table>
 
     </div>

 </div>
<div class="row">
     <div class="col-md-4">
      <br />   
         <asp:Panel ID="pMensaje" runat="server" ForeColor="Red">
             <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" Enabled="False" ReadOnly="True" Height="100px"  Width="352px" ForeColor="White" ></asp:TextBox>
         </asp:Panel>
         <asp:Button ID="btnEntrada" runat="server" Text="Modificar" class="btn btn-warning btn-lg" OnClick="btnEntrada_Click" />
         <a href="Default.aspx" class="btn btn-secondary btn-lg">Cancelar </a>
     </div>
   </div>
</asp:Panel>
</form>
<!-- Scrip para que solo el textbox solo acepte numeros lo llamo asi -> onkeypress="javascript:return solonumeros(event)"-->
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
