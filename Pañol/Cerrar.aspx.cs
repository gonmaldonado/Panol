using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pañol
{
    public partial class Cerrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID_Responsable"]=null;
            Session["Nombre_Responsable"] = null;
            Session["Apellido_Responsable"] = null;
            Session["Tipo_Responsable"] = null;
            Session["Login"] = null;
            Response.Redirect("Login.aspx");
        }
    }
}