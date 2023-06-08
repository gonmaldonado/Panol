using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pañol
{
    public partial class Anular :Utilidades
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
                    Session["ListaAnulacion"] = null;
                    panelMovimiento.Visible = false;
                }
                }
     
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (txtMovimiento.Text.Trim() != "")
            {               
                string Mov = txtMovimiento.Text.Trim();
                string letra = Mov.Substring(0,1);
                bool MovVal = Logica.Movimiento.ValidarMovimiento(Mov);
                if (letra != "A" && letra != "D" && MovVal)
                {
                    if (!Logica.Movimiento.ValidarAnulado(Mov))
                    {
                        DataTable dt = Logica.Tarjeta.TraerPedido(Mov);
                        gvMovimiento.DataSource = dt;
                        gvMovimiento.DataBind();
                        panelMovimiento.Visible = true;
                        //Convetir
                        Entidades.Item item = new Entidades.Item();
                        List<Entidades.Item> ListaAnulacion = new List<Entidades.Item>();
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            item.Codigo = dt.Rows[i]["ARTICULO"].ToString();
                            item.Descripcion = dt.Rows[i]["DESCRIPCION"].ToString();
                            item.Cantidad = Convert.ToInt32(dt.Rows[i]["CANTIDAD"])*-1;
                            ListaAnulacion.Add(item);
                        }
                        Session["ListaAnulacion"] = ListaAnulacion;
                        //
                        txtMovimiento.Enabled = false;
                    }
                    else
                    {
                        MsgBox("El movimiento ingresado ya ha sido anulado.");
                        
                    }
                }
                else
                {
                    MsgBox("El movimiento ingresado no es valido para la anulacion.");
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (txtMovimiento.Text.Trim() != "")
            {
                DateTime Hoy = DateTime.Now;
                string fecha_actual = Hoy.ToString("dd-MM-yyyy");
                string hora_actual = Hoy.ToLongTimeString();
                List<Entidades.Item> ListaAnulacion = new List<Entidades.Item>();
                ListaAnulacion = (List<Entidades.Item>)Session["ListaAnulacion"];
                string movimiento = txtMovimiento.Text.Trim();
                string tipo = movimiento.Substring(0,1);
                string CodMov = Logica.Movimiento.GenerarCodigoAnulacion(movimiento);
                string CodReg = Logica.Registro.GenerarCodigo();
                Entidades.Registro Reg = new Entidades.Registro();
                Reg.CodigoReg = CodReg;
                Reg.CodigoMov = CodMov;
                Reg.Documento = "";
                Reg.Fecha = Convert.ToDateTime(fecha_actual);
                Reg.Hora = Convert.ToDateTime(hora_actual);
                Reg.Solicitante = 0;
                Reg.Responsable = (int)Session["ID_Responsable"];
                Reg.Tarjeta = 0;
                Reg.Observacion = "";
                Reg.Destino = "";
                switch (tipo)
                {
                    case "E":
                        Logica.Movimiento.AltaMovimiento(CodMov, 2, ListaAnulacion);
                        Logica.Registro.CrearRegistro(Reg);
                        MsgBox("Se genero el registro: " + CodReg + " Movimiento " + CodMov + ".");
                        Limpiar();
                        break;
                    case "S":
                        Logica.Movimiento.AltaMovimiento(CodMov, 1, ListaAnulacion);
                        Logica.Registro.CrearRegistro(Reg);
                        Logica.Movimiento.AltaAnulacion(movimiento);
                        MsgBox("Se genero el registro: " + CodReg + " Movimiento " + CodMov + ".");
                        Limpiar();
                        break;
                    case "R":
                        int TarjetaAct =Logica.Tarjeta.TraerTarjeta(movimiento);
                        string TraerMov = Logica.Tarjeta.TraerMovimiento(TarjetaAct);
                        if (movimiento.Trim() == TraerMov.Trim())
                        {
                            Logica.Movimiento.AltaMovimiento(CodMov, 4, ListaAnulacion);
                            Entidades.Tarjeta t = new Entidades.Tarjeta();
                            t = Logica.Tarjeta.TraerTarjeta(TarjetaAct);
                            t.CodigoMov = "";
                            t.Activo = false;
                            Logica.Tarjeta.ModificarTarjeta(t);

                            Logica.Registro.CrearRegistro(Reg);
                            Logica.Movimiento.AltaAnulacion(movimiento);
                            MsgBox("Se genero el registro: " + CodReg + " Movimiento " + CodMov + ".");
                            Limpiar();
                        }
                        else
                        {
                            MsgBox("No se puede anular el movimiento de retiro porque ya tiene una devolucion asociada.");
                            Limpiar();
                        }
                        break;
                    case "D":
                        MsgBox("No se puede anular un movimiento de devolucion.");
                        Limpiar();
                        break;
                    case "A":
                        MsgBox("No se puede anular un movimiento de anulacion.");
                        Limpiar();
                        break;
                    default:
                        MsgBox("No se puede anular el movimiento.");
                        Limpiar();
                        break;
                }

            }
            else
            {
                MsgBox("Datos incompletos.");
            }
        }
        public void Limpiar()
        {
            txtMovimiento.Enabled = true;
            txtMovimiento.Text = "";
            panelMovimiento.Visible = false;
            Session["ListaAnulacion"] = null;
            gvMovimiento.DataSource = Session["ListaAnulacion"];
            gvMovimiento.DataBind();

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}