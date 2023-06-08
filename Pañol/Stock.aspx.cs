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
    public partial class Stock : Utilidades
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
                        LlenarddlGrupo();
                        Session["Stock"] = Logica.Articulo.Stock();
                        gvStock.DataSource = Session["Stock"];
                        gvStock.DataBind();
                    }
                }
        }
        public void FiltroNinja(string filtro)
        {
            DataTable dt = (DataTable)Session["Stock"];
            int validardt = dt.Rows.Count;
            if (validardt > 0)
            { 
            DataTable dt1 = (DataTable)Session["Stock"];
            DataView dv1 = dt1.DefaultView;
            string GRUPO = ddlGrupoArt.Text.Trim();
            string COLUMNA = ddlColumna.Text.Trim();
            
                if (filtro != "")
                {
              
                    if (ddlGrupoArt.Text.Trim() == "TODOS")
                    {
                        dv1.RowFilter = "" + COLUMNA + " LIKE '%" + txtFiltrar.Text.Trim() + "%'";
                        gvStock.DataSource = dv1;
                        gvStock.DataBind();
                    }
                    else
                    {
                        dv1.RowFilter = "" + COLUMNA + " LIKE '%" + txtFiltrar.Text.Trim() + "%'AND GRUPO = '" + GRUPO + "'";
                        gvStock.DataSource = dv1;
                        gvStock.DataBind();
                    }
                    
                   
                }
                else
                {
                    if (ddlGrupoArt.Text.Trim() == "TODOS")
                    {
                        dv1.RowFilter = " STOCK >= 0";
                        gvStock.DataSource = dv1;
                        gvStock.DataBind();
                    }
                    else
                    {
                        dv1.RowFilter = " GRUPO = '" + GRUPO + "' AND STOCK >= 0";
                        gvStock.DataSource = dv1;
                        gvStock.DataBind();
                    }


                }

            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (ddlColumna.Text.Trim() == "")
            {
                MsgBox("Seleccione una columna");
            }
            else
            {
                FiltroNinja(txtFiltrar.Text.Trim());
            }

        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            FiltroNinja("");
            ddlColumna.Text = "CODIGO";
            ddlGrupoArt.Text = "TODOS";
            txtFiltrar.Text = "";
        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
      
        }

        protected void ddlColumna_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltroNinja("");
            txtFiltrar.Text = "";
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

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel("STOCK_" + DateTime.Now.ToShortDateString()+".xls",gvStock) ;
        }
        public void LlenarddlGrupo()
        {
            DataTable dt = Logica.Articulo.ListaGrupoART();
            dt.Rows.Add("TODOS");
            ddlGrupoArt.DataSource = dt;
            ddlGrupoArt.DataTextField = "GRUPO";
            ddlGrupoArt.DataBind();
            ddlGrupoArt.SelectedValue = "TODOS";
        }

        protected void ddlGrupoArt_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltroNinja("");
        }
    }
}