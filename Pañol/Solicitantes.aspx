<%@ Page Title="Solicitantes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Solicitantes.aspx.cs" Inherits="Pañol.Solicitantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <link href="CSS/estilo.css" rel="stylesheet" />
    <h1><span class="label label-default">Solicitantes</span></h1>
    <div class="form-group">
        <div class="row">
            <div class="col-md-5">
                 <asp:DropDownList ID="ddlColumna2" runat="server" Height="27px">
                 <asp:ListItem>LEGAJO</asp:ListItem>
                 <asp:ListItem>NOMBRE</asp:ListItem>
                 </asp:DropDownList>
                 <asp:TextBox ID="txtFiltrar" runat="server" Width="200px"></asp:TextBox>
                 <asp:Button ID="btnFiltrar" class="btn btn-warning btn-s" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click"/>
                 <asp:Button ID="btnBorrar" class="btn btn-warning btn-s" runat="server" Text="Borrar" OnClick="btnBorrar_Click" />
            </div>
            <div class="col-md-1">
                <asp:Button ID="btnExcel" class="btn btn-success btn-s" runat="server" Text="Excel" OnClick="btnExcel_Click"/>
            </div>
            </div>
         <div class="row">
            <div class="col-md-6">
                <div class="scrolling-table-container">
                    <asp:GridView ID="gvSolicitantes" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin"  EmptyDataText="No hay datos registrados"></asp:GridView>
                </div>
            </div>
        </div>
   </div>
</asp:Content>
