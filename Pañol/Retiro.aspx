<%@ Page Title="Retiro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Retiro.aspx.cs" Inherits="Pañol.Retiro" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <br />
<form action="">
<div class="form-group">
     <div class="row">
        <div class="col-md-6">
             <h1><span class="label label-default">Retiro de articulos</span></h1>
            <table style="width: 100%;">
                <tr>
                     <td style="height: 22px; width: 176px"><asp:Label ID="Label2" runat="server" Text="Articulo:"></asp:Label><br />
                         <asp:TextBox ID="txtArticulo" runat="server" Height="27px" Width="352px"></asp:TextBox>
                        <ajaxToolkit:AutoCompleteExtender 
                    ID="AutoCompleteExtender"       
                    runat="server"
                    Enabled="true"
                    TargetControlID="txtArticulo"
                    MinimumPrefixLength="2"
                    ServiceMethod="ObtenerArticulosRetiro"
                    ServicePath="~/WSArticulos.asmx"
                    EnableCaching="true"
                    UseContextKey="true"
                    FirstRowSelected="true"
                    CompletionSetCount="10"
                    CompletionInterval="0">
                         </ajaxToolkit:AutoCompleteExtender>
                      <asp:Button ID="btnBuscar" class="btn btn-warning btn-s" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
                     </td>    
                 </tr>
                </table>
                    <asp:Panel ID="pBuscar" runat="server">
                      <table>
                            <tr>
                                  <td style="height: 22px; width: 100px"><asp:Label ID="Label6" runat="server" Text="Filtrar por:"></asp:Label><br />
                                    <asp:DropDownList ID="ddlColumna" runat="server" Height="27px">
                                        <asp:ListItem>DESCRIPCION</asp:ListItem>
                                        <asp:ListItem>CODIGO</asp:ListItem>
                                    </asp:DropDownList>
                                 </td>
                                 <td>
                                    <asp:Label ID="Label5" runat="server" Text=" "></asp:Label><br />
                                    <asp:TextBox ID="txtFiltrar" runat="server" Width="600px"></asp:TextBox>
                                    <asp:Button ID="Filtrar" class="btn btn-warning btn-s" runat="server" Text="Filtrar" OnClick="Filtrar_Click" />
                                    <asp:Button ID="btnBorrar" class="btn btn-warning btn-s" runat="server" Text="Borrar" OnClick="btnBorrar_Click" />
                                </td>
                                </tr>
                             <tr>
                                <td colspan="2">
                                    <div class="scrolling-table-container"style="overflow:scroll;Height:200px;">
                                    <asp:GridView ID="gvBuscar" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvBuscar_SelectedIndexChanged"  ></asp:GridView>
                                   </div>
                                </td>
                            </tr>
                       </table>
                    </asp:Panel>
            <table>
                <tr>
                    <td>
                        <asp:Button ID="btnagregar" runat="server" Text="Agregar"  cssclass="btn btn-info btn-s" OnClick="btnagregar_Click" />

                    </td>
                </tr>
            </table>
            <br />
            <table>
                <tr>
                        <td style="height: 22px; width: 894px"><asp:Label ID="Label8" runat="server" Text="Solicitante:"></asp:Label><br />
                        <asp:TextBox ID="txtSolicitante" runat="server" Height="27px" Width="352px" ></asp:TextBox>
                             <ajaxToolkit:AutoCompleteExtender 
                                 ID="txtSolicitante_AutoCompleteExtender" 
                                 runat="server"
                                 Enabled="true"
                                 TargetControlID="txtSolicitante"
                                 MinimumPrefixLength="2"
                                 ServiceMethod="ObtenerLegajos" 
                                 ServicePath="~/WSArticulos.asmx"
                                 EnableCaching="true"
                                UseContextKey="true"
                                FirstRowSelected="true"
                                CompletionSetCount="10"
                                CompletionInterval="0">
                              </ajaxToolkit:AutoCompleteExtender>                                
                     <asp:Button ID="btnBuscar2" class="btn btn-warning btn-s" runat="server" Text="Buscar"  onkeypress="javascript:return solonumeros(event)" OnClick="btnBuscar2_Click" />
                    </td>    
                </tr>
                </table>
                    <asp:Panel ID="pBuscar2" runat="server">
                      <table>
                            <tr>
                                  <td style="height: 22px; width: 100px"><asp:Label ID="Label3" runat="server" Text="Filtrar por:"></asp:Label><br />
                                    <asp:DropDownList ID="ddlColumna2" runat="server" Height="27px">
                                        <asp:ListItem>NOMBRE</asp:ListItem>
                                        <asp:ListItem>LEGAJO</asp:ListItem>
                                    </asp:DropDownList>
                                 </td>
                                 <td>
                                    <asp:Label ID="Label4" runat="server" Text=" "></asp:Label><br />
                                    <asp:TextBox ID="txtFiltrar2" runat="server" Width="600px"></asp:TextBox>
                                    <asp:Button ID="btnFiltrar2" class="btn btn-warning btn-s" runat="server" Text="Filtrar" OnClick="btnFiltrar2_Click" />
                                    <asp:Button ID="btnBorrar2" class="btn btn-warning btn-s" runat="server" Text="Borrar" OnClick="btnBorrar2_Click"  />
                                </td>
                                </tr>
                             <tr>
                                <td colspan="2">
                                    <div class="scrolling-table-container"style="overflow:scroll;Height:200px;">
                                    <asp:GridView ID="gvBuscar2" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvBuscar2_SelectedIndexChanged" ></asp:GridView>
                                   </div>
                                </td>
                            </tr>
                       </table>
                    </asp:Panel>
                <table>
                    <tr>
            <td style="height: 22px; width: 176px"><asp:Label ID="Label1" runat="server" Text="Tarjeta:"></asp:Label><asp:TextBox ID="txtTarjeta" runat="server" Height="27px" Width="352px" onkeypress="javascript:return solonumeros(event)"></asp:TextBox>
                <ajaxToolkit:AutoCompleteExtender 
                    ID="txtTarjeta_AutoCompleteExtender"
                        runat="server"
                        Enabled="true"
                       TargetControlID="txtTarjeta"
                       MinimumPrefixLength="2"
                       ServiceMethod="ObtenerTarjetas" 
                      ServicePath="~/WSArticulos.asmx"
                      EnableCaching="true"
                     UseContextKey="true"
                     FirstRowSelected="true"
                     CompletionSetCount="10"
                    CompletionInterval="0">
                </ajaxToolkit:AutoCompleteExtender>
                        </td>
             <td style="height: 22px">&nbsp;</td>
            
        </tr>
            </table>
                <br />
                 <asp:Button ID="btnRetiro" runat="server" Text="Confimar Retiro" Cssclass="btn btn-info btn-lg" OnClick="btnRetiro_Click" />
                 <a href="Default.aspx" class="btn btn-secondary btn-lg">Cancelar </a>
      
  </div>
  <div class="col-md-6">
       <asp:Panel ID="Panel1" runat="server">
                     <asp:GridView ID="gvItems" runat="server" Caption="Lista de articulos ingresados:"  CssClass="table table-striped table-hover table-condensed small-top-margin" AutoGenerateDeleteButton="True" OnRowDeleting="gvItems_RowDeleting"></asp:GridView>
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
