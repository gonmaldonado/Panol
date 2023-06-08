using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace Pañol
{
    public partial class Devolucion : Utilidades
    {
        protected void Page_Load(object sender, EventArgs e)
        {   

                if (Session["Login"] == null)
                {
                     Response.Redirect("Login.aspx");

                }
                else
                {
                if (!IsPostBack)
                {
                    List<Entidades.Item> ListaDevolucion = new List<Entidades.Item>();
                    ListaDevolucion.Clear();
                    Session["ListaDevolucion"] = ListaDevolucion;
                    pObservacion.Visible = false;
                    pLista.Visible = false;
                }
                }

        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (txtTarjeta.Text.Trim() != "")
            {
                if (Logica.Tarjeta.ValidarTarjetaAct(Convert.ToInt32(txtTarjeta.Text)))
                {
                    string Movimiento = Logica.Tarjeta.TraerMovimiento(Convert.ToInt32(txtTarjeta.Text));
                    Session["Devolucion"] = Logica.Tarjeta.TraerPedido(Movimiento);
                    Session["NumMov"] = Movimiento;
                    gvPedido.DataSource = Session["Devolucion"];
                    gvPedido.DataBind();
                    pLista.Visible = true;
                    pObservacion.Visible = true;
                    txtTarjeta.Enabled = false;
                }
                else
                {
                    MsgBox("La tarjeta seleccionada no se encuentra asociada a un pedido.");
                }
            }
        }

        protected void gvPedido_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow filaSeleccionada = gvPedido.Rows[e.RowIndex];//Fila seleccionada
            List<Entidades.Item> ListaDevolucion = new List<Entidades.Item>();
            Entidades.Item art = new Entidades.Item();
            ListaDevolucion= (List<Entidades.Item>)Session["ListaDevolucion"];
            DataTable dt = (DataTable)Session["Devolucion"];
            art.Codigo= filaSeleccionada.Cells[1].Text.Trim();
            art.Descripcion = filaSeleccionada.Cells[2].Text.Trim();
            art.Cantidad = Convert.ToInt32(filaSeleccionada.Cells[3].Text)*-1;
            ListaDevolucion.Add(art);
            dt.Rows.RemoveAt(e.RowIndex);
            Session["ListaDevolucion"] = ListaDevolucion;
            Session["Devolucion"] = dt;
            gvPedido.DataSource = Session["Devolucion"];
            gvPedido.DataBind();
            gvDevolucion.DataSource = Session["ListaDevolucion"];
            gvDevolucion.DataBind();
        }

        protected void btnDevolucion_Click(object sender, EventArgs e)
        {
            List<Entidades.Item> ListaDevolucion = new List<Entidades.Item>();
            ListaDevolucion = (List<Entidades.Item>)Session["ListaDevolucion"];
            DataTable dt = (DataTable)Session["Devolucion"];
            Entidades.Item item = new Entidades.Item();
            if (ListaDevolucion.Count() == 0)
            {
                MsgBox("No se han agregado articulos a la lista de devolucion.");
            }
            else
            {
                if (txtObservacion.Text.Trim() != "")
                {
                    //Convetir
                    List<Entidades.Item> ListaPedido = new List<Entidades.Item>();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        item.Codigo = dt.Rows[i]["ARTICULO"].ToString();
                       // item.Descripcion = dt.Rows[i]["DESCRPICION"].ToString();
                        item.Cantidad = Convert.ToInt32(dt.Rows[i]["CANTIDAD"]);
                        ListaPedido.Add(item);
                    }
                    //
                    DateTime Hoy = DateTime.Now;
                    string fecha_actual = Hoy.ToString("dd-MM-yyyy");
                    string hora_actual = Hoy.ToLongTimeString();
                    string CodMov = Logica.Movimiento.GenerarCodigoMovDev((string)Session["NumMov"]);
                    string CodReg = Logica.Registro.GenerarCodigo();
                    //Doy de alta movimiento
                    Logica.Movimiento.AltaMovimiento(CodMov, 4, ListaDevolucion);
                    Entidades.Registro RegPedido = new Entidades.Registro();
                    RegPedido = Logica.Registro.TraerRegistro(Convert.ToInt32(txtTarjeta.Text));
                    Entidades.Registro Reg = new Entidades.Registro();
                    // TRAER REGISTRO POR NUMERO DE TARJETA
                    Reg.CodigoReg = CodReg;
                    Reg.CodigoMov = CodMov;
                    Reg.Documento = "";
                    Reg.Fecha = Convert.ToDateTime(fecha_actual);
                    Reg.Hora = Convert.ToDateTime(hora_actual);
                    Reg.Solicitante = 0;
                    Reg.Responsable = (int)Session["ID_Responsable"];
                    Reg.Tarjeta = Convert.ToInt32(txtTarjeta.Text);
                    Reg.Observacion = txtObservacion.Text.Trim();
                    Reg.Destino = "";
                    //Doy de alta registro
                    Logica.Registro.CrearRegistro(Reg);
                    MsgBox("Se genero el registro: " + CodReg + " Movimiento " + CodMov + ".");
                    Entidades.Tarjeta t = new Entidades.Tarjeta();
                    t.Activo = false;
                    t.CodigoMov = "";
                    t.Numero = Convert.ToInt32(txtTarjeta.Text);
                    //Limpio
                    ListaDevolucion.Clear();
                    Session["ListaDevolucion"] = ListaDevolucion;
                    gvDevolucion.DataSource = Session["ListaDevolucion"];
                    gvDevolucion.DataBind();
                    pLista.Visible = false;
                    txtObservacion.Text = "";
                    txtTarjeta.Text = "";
                    pObservacion.Visible = false;
                    txtTarjeta.Enabled = true;
                    Logica.Tarjeta.ModificarTarjeta(t);
                    if (ListaPedido.Count() != 0)
                    {
                        Thread.Sleep(1000);
                        Hoy = DateTime.Now;
                        fecha_actual = Hoy.ToString("dd-MM-yyyy");
                        hora_actual = Hoy.ToLongTimeString();
                        string CodMov2 = Logica.Movimiento.GenerarCodigoPed(CodMov);
                        string CodReg2 = Logica.Registro.GenerarCodigo();
                        //Genero nuevo pedido
                        Logica.Movimiento.AltaMovimiento(CodMov2,3,ListaPedido);
                        RegPedido.CodigoReg = CodReg2;
                        RegPedido.CodigoMov = CodMov2;
                        RegPedido.Documento = "";
                        RegPedido.Fecha = Convert.ToDateTime(fecha_actual);
                        RegPedido.Hora = Convert.ToDateTime(hora_actual);
                        RegPedido.Responsable = (int)Session["ID_Responsable"];
                        //Doy de alta registro
                        Logica.Registro.CrearRegistro(RegPedido);
                        //Asocio Tarjeta a Movimiento
                        t.Numero = RegPedido.Tarjeta;
                        t.Activo = true;
                        t.CodigoMov = CodMov2;
                        Logica.Tarjeta.ModificarTarjeta(t);
                    }
                }
                else
                {
                    MsgBox("No se puede registrar la devolcion sin una observacion.");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            List<Entidades.Item> ListaDevolucion = new List<Entidades.Item>();
            ListaDevolucion.Clear();
            Session["ListaDevolucion"] = ListaDevolucion;
            gvDevolucion.DataSource = Session["ListaDevolucion"];
            gvDevolucion.DataBind();
            pLista.Visible = false;
            txtObservacion.Text = "";
            txtTarjeta.Text = "";
            pObservacion.Visible = false;
            txtTarjeta.Enabled = true;
        }
    }
}