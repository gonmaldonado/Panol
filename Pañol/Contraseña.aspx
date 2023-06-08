<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contraseña.aspx.cs" Inherits="Pañol.Contraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
         <br />
    <form action="">
 <div class="form-group">
 <div class="row">
     <div class="col-md-6">
        <h1><span class="label label-default">Modificar contraseña</span></h1> 
    <table>
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
    </table>
     <br />   
         <asp:Button ID="btnEntrada" runat="server" Text="Confirmar" class="btn btn-warning btn-lg" OnClick="btnEntrada_Click"  />
         <a href="Default.aspx" class="btn btn-secondary btn-lg">Cancelar </a>
  </div>
 </div>
 </div>
</form>
</asp:Content>
