using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pañol
{
    public partial class _Default : Page
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
                    lblResponsable.Text = Session["Nombre_Responsable"].ToString() + " " + Session["Apellido_Responsable"].ToString();
                    lblLegajo.Text = Session["ID_Responsable"].ToString();
                    gvTarjetas.DataSource = Logica.Tarjeta.ListarTarjetasAct();
                    gvTarjetas.DataBind();
                    gvRetiros.DataSource = Logica.Movimiento.ArticulosEnRetiro();
                    gvRetiros.DataBind();
                    gvMax.DataSource = Logica.Articulo.ListarStockMax();
                    gvMax.DataBind();
                    gvMin.DataSource = Logica.Articulo.ListarStockMin();
                    gvMin.DataBind();
                    gvPedido.DataSource = Logica.Articulo.LinstarPuntoPedido();
                    gvPedido.DataBind();
                    gvRegistros.DataSource = Logica.Registro.RegistrosHoy();
                    gvRegistros.DataBind();
                }
            }
        }

    }
}