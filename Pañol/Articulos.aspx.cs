using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Pañol
{
    public partial class Articulos : Utilidades
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
                    gvArticulos.DataSource = Logica.Articulo.ListarArticulos();
                    gvArticulos.DataBind();
                    Session["Buscar"] = Logica.Articulo.ListarArticulos();
                }
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel("ART_" + DateTime.Now.ToShortDateString() + ".xls", gvArticulos);
        }
        private void ExportToExcel(string nameReport, GridView wControl)
        {
            HttpResponse response = Response;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pageToRender = new Page();
            HtmlForm form = new HtmlForm();
            form.Controls.Add(wControl);
            pageToRender.Controls.Add(form);
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=" + nameReport);
            response.Charset = "UTF-8";
            response.ContentEncoding = Encoding.Default;
            pageToRender.RenderControl(htw);
            response.Write(sw.ToString());
            response.End();
        }
        public void FiltroNinja(string filtro)
        {
            DataTable dt = (DataTable)Session["Buscar"];
            int validardt = dt.Rows.Count;
            if (validardt > 0)
            {
                DataTable dt1 = (DataTable)Session["Buscar"];
                DataView dv1 = dt1.DefaultView;
                string COLUMNA = ddlColumna2.Text.Trim();

                if (filtro != "")
                {
                    dv1.RowFilter = "" + COLUMNA + " LIKE '%" + txtFiltrar.Text.Trim() + "%'";
                    gvArticulos.DataSource = dv1;
                    gvArticulos.DataBind();

                }
                else
                {
                    dv1.RowFilter = " Articulo <> ''";
                    gvArticulos.DataSource = dv1;
                    gvArticulos.DataBind();


                }
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            FiltroNinja(txtFiltrar.Text.Trim());
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            FiltroNinja("");
            ddlColumna2.Text = "ARTICULO";
            txtFiltrar.Text = "";
        }
    }
}
