<%@ Page Title="Anular movimiento" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Anular.aspx.cs" Inherits="Pañol.Anular" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <form action="">
 <div class="form-group">
     <div class="row">
        <div class="col-md-6">
         <h1><span class="label label-default">Anular movimiento</span></h1>
    <table>
         <tr>
            <td><asp:Label ID="Label1" runat="server" Text="Movimiento:"></asp:Label><br />
             <asp:TextBox ID="txtMovimiento" runat="server" Height="27px" Width="254px"  ></asp:TextBox>
             <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" class="btn btn-warning btn-s" OnClick="btnSeleccionar_Click" />
         </td>
      </tr>
    </table>
     </div>
   </div>
     <br />
  <asp:Panel ID="panelMovimiento" runat="server"> 
    <div class="row">
        <div class="col-md-6">
           
            <table>
 
                 <tr>
                    <td>
                        <asp:GridView ID="gvMovimiento" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin"></asp:GridView>
                        <asp:Button ID="btnCancelar" class="btn btn-warning btn-s" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </td>
   
                </tr>
               
            </table>
            <br />
            <div>
         <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar anulacion" class="btn btn-warning btn-lg" OnClick="btnConfirmar_Click"  />
         <a href="Default.aspx" class="btn btn-secondary btn-lg">Cancelar </a>
            </div>
    </div>
 </div>
</asp:Panel>
</form>
</asp:Content>
