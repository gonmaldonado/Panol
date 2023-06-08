<%@ Page Title="Modificar articulo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModificarART.aspx.cs" Inherits="Pañol.Modificar" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <form action="">
 <div class="form-group">
     <div class="row">
        <div class="col-md-6">
         <h1><span class="label label-default">Modificar articulo</span></h1>
    <table>
         <tr>
            <td style="height: 22px; width: 95px"><asp:Label ID="Label1" runat="server" Text="Codigo:"></asp:Label><br />
             <asp:TextBox ID="txtCodigo" runat="server" Height="27px" Width="352px"  ></asp:TextBox>
               <ajaxToolkit:AutoCompleteExtender 
                ID="AutoCompleteExtender1" 
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
         </td>
      </tr>
     <tr>
          <td>
              <br />
              <asp:Button ID="btnSeleccionar" runat="server" Text="Seleccionar" class="btn btn-warning btn-s" OnClick="btnSeleccionar_Click" />
              <asp:Button ID="btnBorrar" runat="server" Text="Borrar seleccionar" class="btn btn-warning btn-s" OnClick="btnBorrar_Click"  />
         </td>    
      </tr>
    </table>
     </div>
   </div>
     <br />
  <asp:Panel ID="panelModificar" runat="server"> 
    <div class="row">
        <div class="col-md-3">
           
            <table style="width: 100%;">
 
                 <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label2" runat="server" Text="Codigo alternativo:"></asp:Label><br />
                        <asp:TextBox ID="txtCodigoAlt" runat="server" Height="27px" Width="352px" ></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label3" runat="server" Text="Descripcion:"></asp:Label><br />
                        <asp:TextBox ID="txtDescripcion" runat="server" Height="27px" Width="352px" ></asp:TextBox>
                    </td>
                </tr>
                   <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label4" runat="server" Text="Descripcion alternativa:"></asp:Label><br />
                        <asp:TextBox ID="txtDescripcionAlt" runat="server" Height="27px" Width="352px" ></asp:TextBox>
                    </td>
             
                </tr>
                  <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label6" runat="server" Text="Grupo de articulo:"></asp:Label><br />
                        <asp:DropDownList ID="ddlGrupoArt" runat="server" Height="27px" Width="190px"></asp:DropDownList>
                    </td>
                </tr>
                   <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label5" runat="server" Text="Ubicacion:"></asp:Label><br />
                        <asp:TextBox ID="txtUbicacion" runat="server" Height="27px" Width="300px" ></asp:TextBox>
                    </td>    
                </tr>
                 <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label7" runat="server" Text="Uso:"></asp:Label><br />
                        <asp:TextBox ID="txtUso" runat="server" Height="27px" Width="300px" MaxLength="50" ></asp:TextBox>
                    </td>    
                </tr>

            </table>
     </div>
     <div class="col-md-8">
         <table>
        <tr>
           <td style="height: 22px; width: 171px"><asp:Label ID="Label8" runat="server" Text="Stock Max:"></asp:Label><br />
             <asp:TextBox ID="txtMax" runat="server" Height="25px" Width="352px" ></asp:TextBox>
             <ajaxToolkit:NumericUpDownExtender ID="txtMax_NumericUpDownExtender" runat="server" BehaviorID="txtMax_NumericUpDownExtender" RefValues="" ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtMax" Width="100" Maximum="99999" Minimum="0" />
          </td>
        </tr>
        <tr>
         <td style="height: 22px; width: 171px"><asp:Label ID="Label9" runat="server" Text="Stock Min:"></asp:Label><br />
            <asp:TextBox ID="txtMin" runat="server" Height="25px" Width="352px" ></asp:TextBox>
            <ajaxToolkit:NumericUpDownExtender ID="txtMin_NumericUpDownExtender" runat="server" BehaviorID="txtMin_NumericUpDownExtender" RefValues="" ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtMin" Width="100" Maximum="99999" Minimum="0" />
         </td> 
         </tr>
        <tr>
           <td style="height: 22px; width: 171px"><asp:Label ID="Label10" runat="server" Text="Punto de aviso:"></asp:Label><br />
             <asp:TextBox ID="txtAviso" runat="server" Height="25px" Width="352px" ></asp:TextBox>
             <ajaxToolkit:NumericUpDownExtender ID="txtAviso_NumericUpDownExtender" runat="server" BehaviorID="txtAviso_NumericUpDownExtender" RefValues="" ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtAviso" Width="100" Maximum="99999" Minimum="0" />
           </td> 
        </tr>
             <asp:Panel ID="pAdm" runat="server">
         <tr>
             <td style="height: 22px; width: 171px"><asp:Label ID="Label11" runat="server" Text="Articulo activable:"></asp:Label><br />
                <asp:CheckBox ID="ckbCritico" runat="server" Text="   Es un articulo activable" />   
                <ajaxToolkit:MutuallyExclusiveCheckBoxExtender ID="ckbCritico_MutuallyExclusiveCheckBoxExtender" runat="server" BehaviorID="ckbCritico_MutuallyExclusiveCheckBoxExtender" Key="" TargetControlID="ckbCritico" />     
            </td> 
        </tr>
            </asp:Panel>
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


</asp:Content>
