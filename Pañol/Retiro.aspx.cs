using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pañol
{
    public partial class Retiro : Utilidades
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
                    List<Entidades.Item> ListaRetiro = new List<Entidades.Item>();
                    ListaRetiro.Clear();
                    Session["Retiro"] = ListaRetiro;
                    Session["Buscar"] = Logica.Articulo.TraerBuscarRetiro();
                    gvBuscar.DataSource = Session["Buscar"];
                    gvBuscar.DataBind();
                    Session["Buscar2"] = Logica.Solicitante.ListarSolicitantes();
                    gvBuscar2.DataSource = Session["Buscar2"];
                    gvBuscar2.DataBind();
                    Panel1.Visible = false;
                    pBuscar.Visible = false;
                    pBuscar2.Visible = false;
                }
            }

        }

        protected void btnagregar_Click(object sender, EventArgs e)
        {
            if (txtArticulo.Text != "")
            {
                List<Entidades.Item> ListaEntradas = new List<Entidades.Item>();
                ListaEntradas = (List<Entidades.Item>)Session["Retiro"];
                if (ListaEntradas.Count <= 9)
                {
                    if (Logica.Articulo.ValidarArticuloRetiro(txtArticulo.Text.Trim()))
                    {
                        Entidades.Articulo art = new Entidades.Articulo();
                        art = Logica.Articulo.TraerArticulo(txtArticulo.Text.Trim());
                        Entidades.Item item = new Entidades.Item();
                        item.Cantidad = -1;
                        item.Codigo = art.Codigo;
                        bool resultado = ListaEntradas.Any(s => s.Codigo == txtArticulo.Text.Trim());
                        if (!resultado)
                        {
                            item.Descripcion = Logica.Articulo.TraerDescripcion(txtArticulo.Text.Trim());
                            if (art.CantDisponible > 0)
                            {
                                ListaEntradas.Add(item);
                                Session["Retiro"] = ListaEntradas;
                                Panel1.Visible = true;
                                gvItems.DataSource = ListaEntradas;
                                gvItems.DataBind();
                                txtArticulo.Text = "";
                            }
                            else
                            {
                                MsgBox("El articulo no posee cantidad disponible.");
                            }
                        }
                        else
                        {
                            MsgBox("El articulo ya se encuentra en la lista de retiro.");
                        }
                    }
                    else
                    {
                        MsgBox("El articulo ingresado no es valido.");
                    }
                }

                else
                {
                    MsgBox("Se alcanzo el maximo de articulos permitos para un retiro.");

                }

            }
            else
            {
                MsgBox("No se ha ingresado un articulo.");

            }

        }



        protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Entidades.Item> ListaSalidas = new List<Entidades.Item>();
            ListaSalidas = (List<Entidades.Item>)Session["Retiro"];
            ListaSalidas.RemoveAt(e.RowIndex);
            Session["Retiro"] = ListaSalidas;
            gvItems.DataSource = ListaSalidas;
            gvItems.DataBind();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pBuscar.Visible = true;
            btnBuscar.Visible = false;
        }
        public void FiltroNinja(string filtro)
        {
            DataTable dt = (DataTable)Session["Buscar"];
            int validardt = dt.Rows.Count;
            if (validardt > 0)
            {
                DataTable dt1 = (DataTable)Session["Buscar"];
                DataView dv1 = dt1.DefaultView;
                string COLUMNA = ddlColumna.Text.Trim();

                if (filtro != "")
                {
                    dv1.RowFilter = "" + COLUMNA + " LIKE '%" + txtFiltrar.Text.Trim() + "%'";
                    gvBuscar.DataSource = dv1;
                    gvBuscar.DataBind();
                }
                else
                {
                    dv1.RowFilter = " CODIGO <> ''";
                    gvBuscar.DataSource = dv1;
                    gvBuscar.DataBind();
                }
            }
        }
        public void FiltroNinja2(string filtro)
        {
            DataTable dt = (DataTable)Session["Buscar2"];
            int validardt = dt.Rows.Count;
            if (validardt > 0)
            {
                DataTable dt1 = (DataTable)Session["Buscar2"];
                DataView dv1 = dt1.DefaultView;
                string COLUMNA = ddlColumna2.Text.Trim();

                if (filtro != "")
                {
                    dv1.RowFilter = "" + COLUMNA + " LIKE '%" + txtFiltrar2.Text.Trim() + "%'";
                    gvBuscar2.DataSource = dv1;
                    gvBuscar2.DataBind();

                }
                else
                {
                    dv1.RowFilter = " LEGAJO <> ''";
                    gvBuscar2.DataSource = dv1;
                    gvBuscar2.DataBind();


                }
            }
        }

        protected void Filtrar_Click(object sender, EventArgs e)
        {
            FiltroNinja(txtFiltrar.Text.Trim());
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            FiltroNinja("");
            ddlColumna.Text = "CODIGO";
            txtFiltrar.Text = "";

        }

        protected void btnBuscar2_Click(object sender, EventArgs e)
        {
            pBuscar2.Visible = true;
            btnBuscar2.Visible = false;
        }

        protected void btnFiltrar2_Click(object sender, EventArgs e)
        {
            FiltroNinja2(txtFiltrar2.Text.Trim());
        }

        protected void btnBorrar2_Click(object sender, EventArgs e)
        {
            FiltroNinja2("");
            ddlColumna2.Text = "CODIGO";
            txtFiltrar2.Text = "";
        }

        protected void gvBuscar2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaSeleccionada = gvBuscar2.SelectedRow;
            string strCodigo = filaSeleccionada.Cells[1].Text;
            txtSolicitante.Text = strCodigo;
            txtFiltrar2.Text = "";
            pBuscar2.Visible = false;
            btnBuscar2.Visible = true;
        }

        protected void gvBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaSeleccionada = gvBuscar.SelectedRow;
            string strCodigo = filaSeleccionada.Cells[1].Text;
            txtArticulo.Text = strCodigo;
            txtFiltrar.Text = "";
            pBuscar.Visible = false;
            btnBuscar.Visible = true;
        }

        protected void btnRetiro_Click(object sender, EventArgs e)
        {
            List<Entidades.Item> ListaRetiro= new List<Entidades.Item>();
            ListaRetiro = (List<Entidades.Item>)Session["Retiro"];
            if (ListaRetiro.Count() == 0)
            {
                MsgBox("No se han agregado articulos a la lista de retiro");
            }
            else
            {

                if (txtTarjeta.Text != "" && Logica.Tarjeta.ValidarTarjeta(Convert.ToInt32(txtTarjeta.Text)))
                {
                    if (txtSolicitante.Text != "" && Logica.Solicitante.ValidarSolicitante(Convert.ToInt32(txtSolicitante.Text)))
                    {
                        DateTime Hoy = DateTime.Now;
                        string fecha_actual = Hoy.ToString("dd-MM-yyyy");
                        string hora_actual = Hoy.ToLongTimeString();
                        string CodMov = Logica.Movimiento.GenerarCodigoMov(3);
                        string CodReg = Logica.Registro.GenerarCodigo();
                        //Doy de alta movimiento
                        Logica.Movimiento.AltaMovimiento(CodMov, 3, ListaRetiro);
                        Entidades.Registro Reg = new Entidades.Registro();
                        Reg.CodigoReg = CodReg;
                        Reg.CodigoMov = CodMov;
                        Reg.Documento = "";
                        Reg.Fecha = Convert.ToDateTime(fecha_actual);
                        Reg.Hora = Convert.ToDateTime(hora_actual);
                        Reg.Solicitante = Convert.ToInt32(txtSolicitante.Text);
                        Reg.Responsable = (int)Session["ID_Responsable"];
                        Reg.Tarjeta = Convert.ToInt32(txtTarjeta.Text);
                        Reg.Observacion = "";
                        Reg.Destino = "";
                        //Doy de alta registro
                        Logica.Registro.CrearRegistro(Reg);
                        //Asocio Tarjeta a Movimiento
                        Entidades.Tarjeta tja = new Entidades.Tarjeta();
                        tja.Numero = Reg.Tarjeta;
                        tja.Activo = true;
                        tja.CodigoMov = CodMov;
                        Logica.Tarjeta.ModificarTarjeta(tja);
                        //Limpio
                        txtArticulo.Text = "";
                        txtSolicitante.Text = "";
                        txtTarjeta.Text = "";
                        ListaRetiro.Clear();
                        pBuscar.Visible = false;
                        pBuscar2.Visible = false;
                        Panel1.Visible = false;
                        //****
                        MsgBox("Se genero el registro: " + CodReg + " Movimiento " + CodMov+".");
                    }
                    else
                    {
                        MsgBox("No se puede registrar el retiro de articulos si no hay un solicitante valido.");
                    }
                }
                else
                {
                    MsgBox("El retiro no tiene una tarjeta asociada valida.");

                }
            }
        }
    }
}
