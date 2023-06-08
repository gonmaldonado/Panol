<%@ Page Title="Crear articulo" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearART.aspx.cs" Inherits="Pañol.Nuevo" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <form action="">
 <div class="form-group">
 <div class="row">
     <div class="col-md-4">
        <h1><span class="label label-default">Crear articulo</span></h1> 
     </div>
 </div>
     <div class="row">
     <div class="col-md-4">
            <table style="width: 100%;">
                <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label1" runat="server" Text="Codigo:"></asp:Label><br />
                        <asp:TextBox ID="txtCodigo" runat="server" Height="27px" Width="352px" ></asp:TextBox>
                    </td>    
                </tr>
                 <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label2" runat="server" Text="Codigo alternativo:"></asp:Label><br />
                        <asp:TextBox ID="txtCodigoAlt" runat="server" Height="27px" Width="352px" ></asp:TextBox>
                    </td>    
                </tr>
                 <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label3" runat="server" Text="Descripcion:"></asp:Label><br />
                        <asp:TextBox ID="txtDescripcion" runat="server" Height="50px" Width="352px" MaxLength="100" TextMode="MultiLine" ></asp:TextBox>
                    </td>    
                </tr>
                   <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label4" runat="server" Text="Descripcion alternativa:"></asp:Label><br />
                        <asp:TextBox ID="txtDescripcionAlt" runat="server" Height="50px" Width="352px" MaxLength="100" TextMode="MultiLine" ></asp:TextBox>
                    </td>    
                </tr>
                  <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label6" runat="server" Text="Grupo de articulo:"></asp:Label><br />
                        <asp:DropDownList ID="ddlGrupoArt" runat="server" Height="27px" Width="190px"></asp:DropDownList>
                    </td>    
                </tr>
                   <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label5" runat="server" Text="Ubicacion:"></asp:Label><br />
                        <asp:TextBox ID="txtUbicacion" runat="server" Height="27px" Width="300px" MaxLength="50" ></asp:TextBox>
                    </td>    
                </tr>

            </table>
          </div>
             <div class="col-md-4">
              <table style="width: 100%;">
                <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label8" runat="server" Text="Stock Max:"></asp:Label><br />
                        <asp:TextBox ID="txtMax" runat="server" Height="25px" Width="352px" MaxLength="5" ></asp:TextBox>
                        <ajaxToolkit:NumericUpDownExtender ID="NumericUpDownExtender1" runat="server" BehaviorID="TextBox1_NumericUpDownExtender"  RefValues="" ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtMax" Width="100" Maximum="99999" Minimum="0">
                        </ajaxToolkit:NumericUpDownExtender>
                    </td> 
               </tr>
                <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label9" runat="server" Text="Stock Min:"></asp:Label><br />
                        <asp:TextBox ID="txtMin" runat="server" Height="25px" Width="352px" MaxLength="5" ></asp:TextBox>
                        <ajaxToolkit:NumericUpDownExtender ID="NumericUpDownExtender2" runat="server" BehaviorID="TextBox1_NumericUpDownExtender"  RefValues="" ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtMin" Width="100" Maximum="99999" Minimum="0">
                        </ajaxToolkit:NumericUpDownExtender>
                    </td> 
               </tr>
                  <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label10" runat="server" Text="Punto de aviso:"></asp:Label><br />
                        <asp:TextBox ID="txtAviso" runat="server" Height="25px" Width="352px" MaxLength="5" ></asp:TextBox>
                        <ajaxToolkit:NumericUpDownExtender ID="NumericUpDownExtender3" runat="server" BehaviorID="TextBox1_NumericUpDownExtender"  RefValues="" ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" TargetButtonDownID="" TargetButtonUpID="" TargetControlID="txtAviso" Width="100" Maximum="99999" Minimum="0">
                        </ajaxToolkit:NumericUpDownExtender>
                    </td> 
               </tr>
                  <asp:Panel ID="pAdm" runat="server">
                  <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label11" runat="server" Text="Articulo activable:"></asp:Label><br />
                        <asp:CheckBox ID="ckbCritico" runat="server" Text="   Es un articulo activable" />
                        <ajaxToolkit:MutuallyExclusiveCheckBoxExtender ID="ckbCritico_MutuallyExclusiveCheckBoxExtender" runat="server" BehaviorID="ckbCritico_MutuallyExclusiveCheckBoxExtender" Key="" TargetControlID="ckbCritico" />
                    </td> 
               </tr>
                  </asp:Panel>
                <tr>
                    <td style="height: 22px; width: 95px"><asp:Label ID="Label7" runat="server" Text="Uso:"></asp:Label><br />
                        <asp:TextBox ID="txtUso" runat="server" Height="27px" Width="300px" MaxLength="50" ></asp:TextBox>
                    </td>    
                </tr>

                    </table>
        
         </div>
    </div>
<div class="row">
     <div class="col-md-4">
      <br />   
         <asp:Panel ID="pMensaje" runat="server" ForeColor="Red">
             <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" Enabled="False" ReadOnly="True" Height="100px"  Width="352px" ForeColor="White" ></asp:TextBox>
         </asp:Panel>
         <asp:Button ID="btnEntrada" runat="server" Text="Crear" class="btn btn-warning btn-lg" OnClick="btnEntrada_Click" />
         <a href="Default.aspx" class="btn btn-secondary btn-lg">Cancelar </a>
     </div>
   </div>
 </div>
</form>
</asp:Content>
