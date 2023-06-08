using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pañol
{
    public partial class CrearSOL : Utilidades
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                if (Session["Login"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    if (!this.IsPostBack)
                    {
                        txtMensaje.Text = "";
                        pMensaje.Visible = false;
                    }  
                }

        }
        public string ValidarCreacion()
        {
            string Mensaje = "";
            if (txtLegajo.Text.Trim() == "")
            {
                Mensaje = Mensaje + "El numero de legajo es obiligatorio.\n";
            }
            else
            {
                if (Logica.Solicitante.ValidarSolicitante(Convert.ToInt32(txtLegajo.Text)))
                {
                    Mensaje = Mensaje + "El numero de legajo ya existe.\n";
                }
            }
            if (txtNombre.Text.Trim() == "")
            {
                Mensaje = Mensaje + "El nombre es obiligatorio.\n";
            }
            if (txtApellido.Text.Trim() == "")
            {
                Mensaje = Mensaje + "El apellido es obiligatorio.\n";
            }
            return Mensaje;
        }

        protected void btnEntrada_Click(object sender, EventArgs e)
        {
            string msj = ValidarCreacion();
            if (msj == "")
            {
                Entidades.Solicitante Sol = new Entidades.Solicitante();
                Sol.Apellido = txtApellido.Text.Trim().ToUpper();
                Sol.Nombre = txtNombre.Text.Trim().ToUpper();
                Sol.Legajo = Convert.ToInt32(txtLegajo.Text);
                Logica.Solicitante.AltaSolicitante(Sol);
                MsgBox("Se ha creado el solicitante con legajo: " + txtLegajo.Text + ".");
                txtLegajo.Text = "";
                txtApellido.Text = "";
                txtNombre.Text = "";
                txtMensaje.Text = "";
                pMensaje.Visible = false;
            }
            else
            {
                txtMensaje.ForeColor = System.Drawing.ColorTranslator.FromHtml("red");
                txtMensaje.Text = msj;
                pMensaje.Visible = true;

            }

        }
    }
}