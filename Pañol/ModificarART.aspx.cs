using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;


namespace Pañol
{
    public partial class Modificar : Utilidades
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
                    if ((int)Session["Tipo_Responsable"] == 1) {
                        pAdm.Visible = true;
                    }
                    else
                    {
                        pAdm.Visible = false;
                    }
                        panelModificar.Visible = false;
                        txtMensaje.Text = "";
                        pMensaje.Visible = false;
                        LlenarddlGrupo();
                    }
                }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (Logica.Articulo.ValidarArticulo(txtCodigo.Text))
            {
                panelModificar.Visible = true;
                txtCodigo.Enabled = false;
                TraerArticulo(Logica.Articulo.TraerArticulo(txtCodigo.Text.Trim()));
            }
            else
            {
                MsgBox("El codigo de articulo no existe.");
            }

        }
        public void TraerArticulo(Entidades.Articulo art)
        {
            txtCodigoAlt.Text = art.CodigoAlt;
            txtDescripcion.Text = art.Descripcion;
            txtDescripcionAlt.Text = art.DescripcionAlt;
            txtUbicacion.Text = art.Ubicacion;
            txtAviso.Text = art.Aviso.ToString();
            txtUso.Text = art.Uso;
            txtMax.Text = art.Max.ToString();
            txtMin.Text = art.Min.ToString();
            ddlGrupoArt.Text = Logica.Articulo.TraerGrupo(art.Sector).Trim();
            if (art.Critico)
            {
                ckbCritico.Checked = true;
            }
            else
            {
                ckbCritico.Checked = false;
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

        protected void btnEntrada_Click(object sender, EventArgs e)
        {
            string msj = ValidarModificacion();
            if (msj != "")
            {
                txtMensaje.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                pMensaje.Visible = true;
                txtMensaje.Text = msj;
            }
            else
            {
                txtMensaje.ForeColor = System.Drawing.ColorTranslator.FromHtml("green");
                txtMensaje.Text = "Articulo modificado correctamente.";
                pMensaje.Visible = true;
                ModificarArticulo();
            }

        }
        public string ValidarModificacion()
        {
            string mensaje = "";
            //CODIGO
            if (txtCodigo.Text == "")
            {
                mensaje = mensaje + "El codigo del articulo es obligatorio.\n";
            }
            //CODIGO_ALT
            if (txtCodigoAlt.Text != "")
            {
                string Codigo_alt = Logica.Articulo.TraerCodigoAlt(txtCodigo.Text.Trim());
                if (Codigo_alt != txtCodigoAlt.Text.Trim())
                {
                    if (Logica.Articulo.ValidarArticulo(txtCodigoAlt.Text.Trim()))
                    {
                        mensaje = mensaje + "El codigo alternativo del articulo ya existe.\n";
                    }
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

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            panelModificar.Visible = false;
            pMensaje.Visible = false;
            txtMensaje.Text = "";
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";

        }
        public void ModificarArticulo()
        {
            Entidades.Articulo art = new Entidades.Articulo();
            art.Codigo = txtCodigo.Text.Trim();
            art.CodigoAlt = txtCodigoAlt.Text.Trim();
            art.Descripcion = txtDescripcion.Text.Trim();
            art.DescripcionAlt = txtDescripcionAlt.Text.Trim();
            art.Ubicacion = txtUbicacion.Text.Trim();
            art.Uso= txtUso.Text.Trim();
            art.Sector = Logica.Articulo.TraerIDGrupo(ddlGrupoArt.Text.Trim());
            if (ckbCritico.Checked)
            {
                art.Critico = true;
            }
            else
            {
                art.Critico = false;
            }
            art.Max = Convert.ToInt32(txtMax.Text.Trim());
            art.Min = Convert.ToInt32(txtMin.Text.Trim());
            art.Aviso = Convert.ToInt32(txtAviso.Text.Trim());
            Logica.Articulo.ModificarArticulo(art);
        }
    }
}