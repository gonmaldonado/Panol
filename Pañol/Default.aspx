<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pañol._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="CSS/estilo.css" rel="stylesheet" />
        <div class="row">
        <div class="col-md-3">
          <h1 style="color:orange">
            <asp:Image ID="Image1" runat="server" Height="39px" ImageUrl="~/Imagenes/icono.png" Width="55px" />
            Pañol</h1>
        </div>
        <div class="col-md-6">
            <br />
           <div class="center-block">
            <asp:Button ID="btnEntrada" runat="server" Text="Entrada" CssClass="btn btn-success btn-lg" PostBackUrl="~/Entrada.aspx" />
            <asp:Button ID="btnSalida" runat="server" Text="Salida" CssClass="btn btn-danger btn-lg" PostBackUrl="~/Salida.aspx" />
            <asp:Button ID="btnRetiro" runat="server" Text="Retiro" CssClass="btn btn-info btn-lg" PostBackUrl="~/Retiro.aspx" />
            <asp:Button ID="btnDevolucion" runat="server" Text="Devolucion" CssClass="btn btn-primary btn-lg" PostBackUrl="~/Devolucion.aspx" />
           </div>
        </div>
         <div class="col-md-3">
             <br />
             <table>
                 <tr>
                     <td>
                        <b><asp:Label ID="Label1" runat="server" Text="Responsable: "></asp:Label></b>
                        <asp:Label ID="lblResponsable" runat="server" Text=""></asp:Label>
                     </td>
                     </tr>
                    <tr>
                     <td>
                         <b><asp:Label ID="Label2" runat="server" Text="Legajo: "></asp:Label></b>
                        <asp:Label ID="lblLegajo" runat="server" Text=""></asp:Label>
                     </td>
                 </tr>
                    <tr>
                     <td>
                      <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-secondary btn-xs" PostBackUrl="~/Contraseña.aspx" style="margin-left: 0px">Cambiar contraseña</asp:LinkButton>
                     </td>
                 </tr>
             </table> 
            
        </div>
    </div>
   <hr />
    <div class="row">
        <div class="col-md-4">
           <h1><span class="label label-default">Tarjetas en uso</span></h1> 
           <div class="scrolling-table-container">
            <asp:GridView ID="gvTarjetas" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin"  EmptyDataText="No hay datos registrados"></asp:GridView>
           </div>
        </div>
        <div class="col-md-8">
            <h1><span class="label label-default">Articulos retirados</span></h1>
              <div class="scrolling-table-container"style="overflow:scroll">
            <asp:GridView ID="gvRetiros" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin"  EmptyDataText="No hay datos registrados"></asp:GridView>
        </div>
    </div>
    </div>
        <div class="row">
        <div class="col-md-4">
           <h1><span class="label label-default">Punto de Pedido</span></h1> 
           <div class="scrolling-table-container">
            <asp:GridView ID="gvPedido" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin"  EmptyDataText="No hay datos registrados"></asp:GridView>
        </div>
        </div>
        <div class="col-md-4">
            <h1><span class="label label-default">Stock Min</span></h1>
            <div class="scrolling-table-container">
            <asp:GridView ID="gvMin" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin"  EmptyDataText="No hay datos registrados"></asp:GridView>
           </div>
        </div>
        <div class="col-md-4">
           <h1><span class="label label-default">Stock Max</span></h1> 
             <div class="scrolling-table-container">
            <asp:GridView ID="gvMax" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin"  EmptyDataText="No hay datos registrados"></asp:GridView>
            </div>
        </div>
    </div>
  <div class="row">
        <div class="col-md-12">
           <h1><span class="label label-default">Registros</span></h1> 
             <div class="scrolling-table-container" style="overflow:scroll">
            <asp:GridView ID="gvRegistros" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin"  EmptyDataText="No hay datos registrados"></asp:GridView>
             </div>
        </div>
    </div>
</asp:Content>
