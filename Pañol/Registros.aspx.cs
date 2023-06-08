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
    public partial class Registros1 : Utilidades
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
                    pReistro.Visible = false;
                }
            }
          
        }

        public bool validarFecha(string fecha1, string fecha2)
        {

            DateTime Desde = Convert.ToDateTime(fecha1);
            DateTime Hasta = Convert.ToDateTime(fecha2);
            if (Desde > Hasta)
            {
                return false;
            }
            else
            {
                return true;
            }


        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtHasta.Text.Trim() != "" & txtDesde.Text.Trim() != "")
            {
                if (IsDate(txtDesde.Text.Trim()) && IsDate(txtHasta.Text.Trim()))
                {
                    if (validarFecha(txtDesde.Text.Trim(), txtHasta.Text.Trim()))
                    {
 
                       gvRegistros.DataSource = Logica.Registro.Registros(txtDesde.Text.Trim(), txtHasta.Text.Trim());
                       gvRegistros.DataBind();
                       pReistro.Visible = true;

                    }
                    else
                    {
                        MsgBox("Revise fechas ingresadas.");
                    }
                }
                else
                {
                    MsgBox("Revisar datos ingresados.");
                }
            }
            else
            {
                MsgBox("Complete campos incompletos.");
            }

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
        public bool IsDate(object inValue)
        {
            bool bValid;
            try
            {
                DateTime myDT = DateTime.Parse(inValue.ToString());
                bValid = true;
            }
            catch (Exception e)
            {
                bValid = false;
            }

            return bValid;
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel("REG_" + DateTime.Now.ToShortDateString() + ".xls", gvRegistros);
        }
    }
}