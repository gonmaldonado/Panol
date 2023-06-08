using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pañol
{
    public partial class ModificarSOL : Utilidades
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
                        panelModificar.Visible = false;
                        txtMensaje.Text = "";
                        pMensaje.Visible = false;
                    }
                }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (txtLegajo.Text.Trim() != "")
            {
                int Legajo = Convert.ToInt32(txtLegajo.Text);
                if (Logica.Solicitante.ValidarSolicitante(Legajo))
                {
                    Entidades.Solicitante Solicitante = new Entidades.Solicitante();
                    txtLegajo.Enabled = false;
                    Solicitante = Logica.Solicitante.TraerSolicitante(Legajo);
                    txtApellido.Text = Solicitante.Apellido;
                    txtNombre.Text = Solicitante.Nombre;
                    txtLegajo.Enabled = false;
                    panelModificar.Visible = true;

                }
                else
                {
                    MsgBox("El numero de legajo no existe.");
                }
            }
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
           
            txtLegajo.Text ="";
            txtApellido.Text = "";
            txtNombre.Text = "";
            txtLegajo.Enabled = true;
            panelModificar.Visible = false;
        }
        public string ValidarCreacion()
        {
            string Mensaje = "";
            if (txtLegajo.Text.Trim() == "")
            {
                Mensaje = Mensaje + "El numero de legajo es obiligatorio\n";
            }
            if (txtNombre.Text.Trim() == "")
            {
                Mensaje = Mensaje + "El nombre es obiligatorio\n";
            }
            if (txtApellido.Text.Trim() == "")
            {
                Mensaje = Mensaje + "El apellido es obiligatorio\n";
            }
            return Mensaje;
        }

        protected void btnEntrada_Click(object sender, EventArgs e)
        {
            if(txtLegajo.Text!="" && txtApellido.Text!="" && txtNombre.Text != "")
            {
                Entidades.Solicitante Sol = new Entidades.Solicitante();
                Sol.Apellido = txtApellido.Text.Trim().ToUpper();
                Sol.Nombre = txtNombre.Text.Trim().ToUpper();
                Sol.Legajo = Convert.ToInt32(txtLegajo.Text);
                Logica.Solicitante.ModificarSolicitante(Sol);
                MsgBox("Se ha realizado la modificacion del legajo: "+ txtLegajo.Text+".");
                txtLegajo.Text = "";
                txtApellido.Text = "";
                txtNombre.Text = "";
                txtLegajo.Enabled = true;
                panelModificar.Visible = false;
            }
            else
            {
                MsgBox("Hay datos incompletos.");
            }
        }
    }
}