<%@ Page Title="Consumos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Consumos.aspx.cs" Inherits="Pañol.Consumos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <br />
    <h1><span class="label label-default">Consumos</span></h1>
 <div class="form-group">
 <div class="row">
   <div class="col-md-4">
       <table>
           <tr>
              <td style="width: 120px">
                 <asp:Label ID="Label1" runat="server" Text="Desde:"></asp:Label><br />
                   <asp:TextBox ID="txtDesde" runat="server" Height="27px" Width="100px" TextMode="DateTime"></asp:TextBox>
                   <ajaxToolkit:CalendarExtender ID="txtDesde_CalendarExtender" runat="server" BehaviorID="txtDesde_CalendarExtender" Format="dd/MM/yyyy" TargetControlID="txtDesde" />
               </td>
               <td style="width: 112px">
                <asp:Label ID="Label2" runat="server" Text="Hasta:"></asp:Label><br />
                   <asp:TextBox ID="txtHasta" runat="server" Height="27px" Width="100px" TextMode="DateTime"></asp:TextBox>
               
                   <ajaxToolkit:CalendarExtender ID="txtHasta_CalendarExtender" runat="server" BehaviorID="txtHasta_CalendarExtender" Format="dd/MM/yyyy" TargetControlID="txtHasta" />
               </td>
               <td>
                 <br />
                 <asp:Button ID="btnBuscar" runat="server" Text="Buscar" class="btn btn-warning btn-s " OnClick="btnBuscar_Click"/>
               </td>
           </tr>
       </table>
   </div>
  </div>
     <asp:Panel ID="pReistro" runat="server"> 
     <hr />  
     <div class="row">
     <div class="col-md-11">
     </div>
     <div class="col-md-1">
         <asp:Button ID="btnExcel" class="btn btn-success btn-s" runat="server" Text="Excel" OnClick="btnExcel_Click"/>
   </div>
</div>
 <div class="row">
 <div class="col-md-12">  
         <div class="scrolling-table-container"style="overflow:scroll; height: 674px;">
        <asp:GridView ID="gvRegistros" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin"  EmptyDataText="No hay datos registrados"></asp:GridView>
        </div> 
 </div>
</div>
  </asp:Panel>  
</div>
</asp:Content>
