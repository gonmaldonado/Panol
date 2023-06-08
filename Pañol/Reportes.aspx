<%@ Page Title="Reporte" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Pañol.Reportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br />
    <link href="CSS/estilo.css" rel="stylesheet" />
 <h1><span class="label label-default">Reporte articulos activables</span></h1>
 <div class="form-group">
        <div class="row">
            <div class="col-md-11">
            </div>
            <div class="col-md-1">
                <asp:Button ID="btnExcel" class="btn btn-success btn-s" runat="server" Text="Excel" OnClick="btnExcel_Click" />
            </div>
            </div>
 <div class="row">
   <div class="col-md-12">
      <div class="scrolling-table-container" style="overflow:scroll; height: 674px;" >
           <asp:GridView ID="gvReporte" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin"  EmptyDataText="No hay datos registrados"></asp:GridView>
      </div>
   
   </div>
  </div>
</div>
</asp:Content>
