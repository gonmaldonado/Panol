﻿<%@ Page Title="Salida" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Salida.aspx.cs" Inherits="Pañol.Salida" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<form action="">
 <div class="form-group">
     <div class="row">
        <div class="col-md-6">
            <h1><span class="label label-default">Salida</span></h1>
            <table style="width: 100%;">
                <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label6" runat="server" Text="Articulo:"></asp:Label><br />
                        <asp:TextBox ID="txtCodigo" runat="server" Height="27px" Width="352px" ></asp:TextBox>
                          <ajaxToolkit:AutoCompleteExtender ID="txtCodigo_AutoCompleteExtender" 
                         runat="server"
                        Enabled="true"
                        TargetControlID="txtCodigo"
                        MinimumPrefixLength="2"
                        ServiceMethod="ObtenerArticulos"
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
                                  <td style="height: 22px; width: 100px"><asp:Label ID="Label2" runat="server" Text="Filtrar por:"></asp:Label><br />
                                    <asp:DropDownList ID="ddlColumna" runat="server" Height="27px">
                                        <asp:ListItem>DESCRIPCION</asp:ListItem>
                                        <asp:ListItem>CODIGO</asp:ListItem>
                                    </asp:DropDownList>
                                 </td>
                                 <td>
                                    <asp:Label ID="Label4" runat="server" Text=" "></asp:Label><br />
                                    <asp:TextBox ID="txtFiltrar" runat="server" Width="600px"></asp:TextBox>
                                    <asp:Button ID="Filtrar" class="btn btn-warning btn-s" runat="server" Text="Filtrar" OnClick="Filtrar_Click"  />
                                    <asp:Button ID="btnBorrar" class="btn btn-warning btn-s" runat="server" Text="Borrar" OnClick="btnBorrar_Click"  />
                                </td>
                                </tr>
                             <tr>
                                <td colspan="2">
                                    <div class="scrolling-table-container"style="overflow:scroll;Height:200px;">
                                    <asp:GridView ID="gvBuscar" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvBuscar_SelectedIndexChanged"></asp:GridView>
                                   </div>
                                </td>
                            </tr>
                       </table>
                    </asp:Panel>
            <table>
                <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label7" runat="server" Text="Cantidad:"></asp:Label><br />
                        <asp:TextBox ID="txtCantidad" runat="server" Height="27px"></asp:TextBox> 
                      
                        <ajaxToolkit:NumericUpDownExtender ID="txtCantidad_NumericUpDownExtender" runat="server" BehaviorID="txtCantidad_NumericUpDownExtender" RefValues="" ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtCantidad" Width="200" Maximum="9999" Minimum="1">
                        </ajaxToolkit:NumericUpDownExtender>
                      
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnagregar" runat="server" Text="Agregar"  cssclass="btn btn-danger btn-s" OnClick="btnagregar_Click" />

                    </td>
                </tr>
            </table>
            <br />
            <table style="width: 1377px">
                <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label8" runat="server" Text="Solicitante:"></asp:Label><br />
                        <asp:TextBox ID="txtSolicitante" runat="server" Height="27px" Width="352px" ></asp:TextBox>
                                        <ajaxToolkit:AutoCompleteExtender 
                                        ID="AutoCompleteExtender"
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
                     <asp:Button ID="btnBuscar2" class="btn btn-warning btn-s" runat="server" Text="Buscar" OnClick="btnBuscar2_Click" onkeypress="javascript:return solonumeros(event)" />
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
                                    <asp:Label ID="Label5" runat="server" Text=" "></asp:Label><br />
                                    <asp:TextBox ID="txtFiltrar2" runat="server" Width="600px"></asp:TextBox>
                                    <asp:Button ID="btnFiltrar2" class="btn btn-warning btn-s" runat="server" Text="Filtrar" OnClick="btnFiltrar2_Click"  />
                                    <asp:Button ID="btnBorrar2" class="btn btn-warning btn-s" runat="server" Text="Borrar" OnClick="btnBorrar2_Click"   />
                                </td>
                                </tr>
                             <tr>
                                <td colspan="2">
                                    <div class="scrolling-table-container"style="overflow:scroll;Height:200px;">
                                    <asp:GridView ID="gvBuscar2" runat="server" CssClass="table table-striped table-hover table-condensed small-top-margin" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvBuscar2_SelectedIndexChanged"></asp:GridView>
                                   </div>
                                </td>
                            </tr>
                       </table>
                    </asp:Panel>
                <table>
                 <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label1" runat="server" Text="Destino:"></asp:Label><br />
                        <asp:TextBox ID="txtDestino" runat="server" Height="27px" Width="352px" MaxLength="50" ></asp:TextBox>
                    </td>    
                </tr>
            </table>
            <br />
         <asp:Button ID="btnEntrada" runat="server" Text="Confirmar Salida " cssclass="btn btn-danger btn-lg" OnClick="btnEntrada_Click" />
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
