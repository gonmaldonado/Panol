<%@ Page Title="Stock" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="Pañol.Stock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <!--<div class="form-group" style="height: 800px">-->
     <h1><span class="label label-default">Stock de articulos</span></h1>
     <div class="row">
        <div class="col-md-11">
             <table>
                 <tr>
                    <td style="height: 22px; width: 100px"><asp:Label ID="Label2" runat="server" Text="Grupo de articulo:"></asp:Label><br />
                        <asp:DropDownList ID="ddlGrupoArt" runat="server" Height="27px" Width="150px" AutoPostBack="True"></asp:DropDownList>
                    </td>
                    <td style="height: 22px; width: 100px"><asp:Label ID="Label6" runat="server" Text="Filtrar por:"></asp:Label><br />
                        <asp:DropDownList ID="ddlColumna" runat="server" Height="27px" Width="180px" AutoPostBack="True" OnSelectedIndexChanged="ddlColumna_SelectedIndexChanged">
                            <asp:ListItem>CODIGO</asp:ListItem>
                            <asp:ListItem Value="CODIGO_ALT">CODIGO ALT</asp:ListItem>
                            <asp:ListItem>DESCRIPCION</asp:ListItem>
                            <asp:ListItem Value="DESCRIPCION_ALT">DESCRIPCION ALT</asp:ListItem>
                        </asp:DropDownList>
                    </td> 
                        <td style="height: 22px; width: 761px" ><asp:Label ID="Label1" runat="server" Text="Texto:"></asp:Label><br />
                            <asp:TextBox ID="txtFiltrar" runat="server" Width="428px" AutoPostBack="True" OnTextChanged="txtFiltrar_TextChanged" ></asp:TextBox>
                            <asp:Button ID="Button1" class="btn btn-warning btn-s" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click"/>
                            <asp:Button ID="Button2" class="btn btn-warning btn-s" runat="server" Text="Borrar" OnClick="btnBorrar_Click" />
                        </td>
  
                     </tr>
               </table>
          </div>
         <div class="col-md-1">
             <br />
              <asp:Button ID="btnExcel" class="btn btn-success btn-s" runat="server" Text="Excel" OnClick="btnExcel_Click" />
         </div>
    </div>
    <div class="row" style="height: 692px">
        <div class="col-md-12" style="left: 0px; top: 0px; height: 706px">
                  <section class="panel">
                <div class="scrolling-table-container"style="overflow:scroll; height: 674px;">
                <asp:GridView ID="gvStock" runat="server" ClientIDMode="Static" AutoGenerateColumns="False"  CssClass="table table-striped table-hover table-condensed small-top-margin"  EmptyDataText="No hay datos registrados" >
                    <Columns> 
                       <asp:BoundField DataField="CODIGO" HeaderText="Codigo" >
                           <HeaderStyle Width="10%" />
                       </asp:BoundField>
                           <asp:BoundField DataField="CODIGO_ALT" HeaderText="Codigo alt" >
                           <HeaderStyle Width="10%" />
                       </asp:BoundField>
                         <asp:BoundField DataField="DESCRIPCION" HeaderText="Descripcion" />
                         <asp:BoundField DataField="DESCRIPCION_ALT" HeaderText="Descripcion alt"/>
                         <asp:BoundField DataField="GRUPO" HeaderText="grupo de art" >
                          <HeaderStyle Width="10%" />
                       </asp:BoundField>
                       <asp:BoundField DataField="CANT_DISP" HeaderText="Disponible">
                             <HeaderStyle Width="5%" />
                       </asp:BoundField>
                       <asp:BoundField DataField="CANT_RETE" HeaderText="Retenido">
                             <HeaderStyle Width="5%" />
                       </asp:BoundField>
                       <asp:BoundField DataField="STOCK" HeaderText="Stock" >
                             <HeaderStyle Width="5%" />
                       </asp:BoundField>
                           <asp:BoundField DataField="UBICACION" HeaderText="Ubicacion" >
                           <HeaderStyle Width="10%" />
                       </asp:BoundField>
                    </Columns>
                </asp:GridView>
              </div>
           </section>
        </div>
     </div>
  <!-- </div>-->
</asp:Content>
