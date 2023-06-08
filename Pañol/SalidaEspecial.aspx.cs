using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pañol
{
    public partial class SalidaEspecial : Utilidades
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

                        List<Entidades.Item> ListaSalidas = new List<Entidades.Item>();
                        ListaSalidas.Clear();
                        Session["Salida"] = ListaSalidas;
                        Session["Buscar"] = Logica.Articulo.TraerBuscarEsp();
                        gvBuscar.DataSource = Session["Buscar"];
                        gvBuscar.DataBind();
                        Session["Buscar2"] = Logica.Solicitante.ListarSolicitantes();
                        Panel1.Visible = false;
                        pBuscar.Visible = false;
                    }
                }

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            pBuscar.Visible = true;
            btnBuscar.Visible = false;
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

        protected void gvBuscar_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow filaSeleccionada = gvBuscar.SelectedRow;
            string strCodigo = filaSeleccionada.Cells[1].Text;
            txtCodigo.Text = strCodigo;
            txtFiltrar.Text = "";
            pBuscar.Visible = false;
            btnBuscar.Visible = true;
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

        protected void btnagregar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "" && txtCantidad.Text != "")
            {
                string codigo = txtCodigo.Text.Trim();
                if (Logica.Articulo.ValidarArticuloEsp(codigo))
                {
                    List<Entidades.Item> ListaEntradas = new List<Entidades.Item>();
                    Entidades.Item item = new Entidades.Item();
                    Entidades.Articulo art = new Entidades.Articulo();
                    art = Logica.Articulo.TraerArticulo(codigo);
                    item.Cantidad = Convert.ToInt32(txtCantidad.Text) * -1;
                    item.Codigo = art.Codigo;
                    item.Descripcion = "";
                    if (Convert.ToInt32(txtCantidad.Text) > art.CantDisponible)
                    {
                        MsgBox("Cantidad insuficiente del articulo " + art.Codigo + " para la salida de mercaderia");
                    }
                    else
                    {
                        EntradaIntem(item);
                        ListaEntradas = (List<Entidades.Item>)Session["Salida"];
                        Panel1.Visible = true;
                        gvItems.DataSource = ListaEntradas;
                        gvItems.DataBind();
                        txtCantidad.Text = "";
                        txtCodigo.Text = "";
                    }
                }
                else
                {
                    MsgBox("El articulo ingresado no es valido");
                }
            }
            else
            {
                MsgBox("Datos incompletos");
            }
        }

        protected void btnEntrada_Click(object sender, EventArgs e)
        {
            List<Entidades.Item> ListaSalidas = new List<Entidades.Item>();
            ListaSalidas = (List<Entidades.Item>)Session["Salida"];
            if (ListaSalidas.Count() == 0)
            {
                MsgBox("No se han agregado articulos a la salida de mercaderia");
            }
            else
            {
                DateTime Hoy = DateTime.Now;
                string fecha_actual = Hoy.ToString("dd-MM-yyyy");
                string hora_actual = Hoy.ToLongTimeString();
                string CodMov = Logica.Movimiento.GenerarCodigoMov(2);
                string CodReg = Logica.Registro.GenerarCodigo();
                //Doy de alta movimiento
                Logica.Movimiento.AltaMovimiento(CodMov, 2, ListaSalidas);
                Entidades.Registro Reg = new Entidades.Registro();
                Reg.CodigoReg = CodReg;
                Reg.CodigoMov = CodMov;
                Reg.Documento = "";
                Reg.Fecha = Convert.ToDateTime(fecha_actual);
                Reg.Hora = Convert.ToDateTime(hora_actual);
                Reg.Solicitante = (int)Session["ID_Responsable"];
                Reg.Responsable = (int)Session["ID_Responsable"];
                Reg.Tarjeta = 0;
                Reg.Observacion = "SE";
                Reg.Destino = "";
                //Doy de alta registro
                Logica.Registro.CrearRegistro(Reg);
                //Limpio
                txtCantidad.Text = "1";
                txtCodigo.Text = "";
                ListaSalidas.Clear();
                pBuscar.Visible = false;
                Panel1.Visible = false;
                //****
                MsgBox("Se genero el registro: " + CodReg + " Movimiento " + CodMov);



            }

        }
        public void EntradaIntem(Entidades.Item Elemento)
        {
            //Traigo la lista de session
            List<Entidades.Item> ListaEntradas = new List<Entidades.Item>();
            ListaEntradas = (List<Entidades.Item>)Session["Salida"];
            //Agrego el nuevo item a la lista
            ListaEntradas.Add(Elemento);
            //Con linq agrupo los elementos de la lista para no tener elemento repetidos
            var result = from item in ListaEntradas
                         group item by item.Codigo into g
                         select new Entidades.Item()
                         {
                             Codigo = g.Key,
                             Cantidad = g.Sum(x => x.Cantidad),
                             Descripcion = Logica.Articulo.TraerDescripcion(g.Key)
                         };
            //recorro el resultado y cre una nueva lista para actualizar la de session
            List<Entidades.Item> ListaEntradas2 = new List<Entidades.Item>();
            foreach (var item in result)
            {
                ListaEntradas2.Add(item);
            }


            Session["Salida"] = ListaEntradas2;

        }

        protected void gvItems_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            List<Entidades.Item> ListaSalidas = new List<Entidades.Item>();
            ListaSalidas = (List<Entidades.Item>)Session["Salida"];
            ListaSalidas.RemoveAt(e.RowIndex);
            Session["Salida"] = ListaSalidas;
            gvItems.DataSource = ListaSalidas;
            gvItems.DataBind();
        }
    }
}