using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pañol
{
    public partial class Nuevo : Utilidades
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Session["Login"]== null)
                {
                    Response.Redirect("Login.aspx");    
                }
                else
                {
                    if (!this.IsPostBack)
                {
                        if ((int)Session["Tipo_Responsable"] == 1)
                        {
                            pAdm.Visible = true;
                        }
                        else
                        {
                            pAdm.Visible = false;
                        }
                        txtMensaje.Text = "";
                        pMensaje.Visible = false;
                        LlenarddlGrupo();
                    }
                }
        }
        public void LlenarddlGrupo()
        {
            DataTable dt = Logica.Articulo.ListaGrupoART();
            dt.Rows.Add(" ");
            ddlGrupoArt.DataSource = dt;
            ddlGrupoArt.DataTextField = "GRUPO";
            ddlGrupoArt.DataBind();
            ddlGrupoArt.SelectedValue = " ";
        }
        public string ValidarCreacion()
        {
            string mensaje = "";
        //CODIGO
            if (txtCodigo.Text == "")
            {
                mensaje = mensaje + "El codigo del articulo es obligatorio.\n";
            }
            else
            {
                if (Logica.Articulo.ValidarArticulo(txtCodigo.Text.Trim()))
                {
                    mensaje = mensaje + "El codigo del articulo ya existe.\n";
                }
            }
            //CODIGO_ALT
            if (txtCodigoAlt.Text != "")
            {
                if (Logica.Articulo.ValidarArticulo(txtCodigoAlt.Text.Trim()))
                {
                    mensaje = mensaje + "El codigo alternativo del articulo ya existe.\n";
                }
            }
           
      //DESCRIPCION
            if (txtDescripcion.Text == "")
            {
                mensaje = mensaje + "La descripcion del articulo es obligatorio.\n";
            }
      //GRUPO
            if (ddlGrupoArt.Text == " ")
            {
                mensaje = mensaje + "El grupo de articulo es obligatorio.";
            }

            return mensaje;

        }

        protected void btnEntrada_Click(object sender, EventArgs e)
        {
            string msj = ValidarCreacion();
            if (msj != "")
            {
             txtMensaje.ForeColor= System.Drawing.ColorTranslator.FromHtml("red");
                pMensaje.Visible = true;
                txtMensaje.Text = msj;
            }
            else
            {
                txtMensaje.ForeColor = System.Drawing.ColorTranslator.FromHtml("green");
                txtMensaje.Text = "Articulo creado correctamente.";
                pMensaje.Visible = true;
                AltaArticulo();
            }
        }
        public void AltaArticulo()
        {
            Entidades.Articulo art = new Entidades.Articulo();
            art.Codigo = txtCodigo.Text.Trim();
            art.CodigoAlt = txtCodigoAlt.Text.Trim();
            art.Descripcion = txtDescripcion.Text.Trim();
            art.DescripcionAlt = txtDescripcionAlt.Text.Trim();
            art.Ubicacion = txtUbicacion.Text.Trim();
            art.Sector = Logica.Articulo.TraerIDGrupo(ddlGrupoArt.Text.Trim());
            if (ckbCritico.Checked)
            {
                art.Critico = true;
            }else
            {
                art.Critico = false;
            }
            art.Max = Convert.ToInt32(txtMax.Text.Trim());
            art.Min = Convert.ToInt32(txtMin.Text.Trim());
            art.Aviso = Convert.ToInt32(txtAviso.Text.Trim());
            art.Uso = txtUso.Text.Trim();
            Logica.Articulo.AltaArticulo(art);
        }
    }
}