using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Pañol
{
    public partial class Login : Utilidades
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtContraseña.Text.Trim()!=""&& txtLegajo.Text.Trim() != "")
            {
                int legajo = Convert.ToInt32(txtLegajo.Text.Trim());
                if(Logica.Usuario.ValidarUsuario(legajo, txtContraseña.Text.Trim()))
                {
                    Entidades.Usuario user = Logica.Usuario.TraerUsuario(legajo);
                    Session["ID_Responsable"] = user.Legajo;
                    Session["Nombre_Responsable"] = user.Nombre;
                    Session["Apellido_Responsable"] = user.Apellido;
                    Session["Tipo_Responsable"] = user.Tipo;
                    Session["Login"] = true;
                    Server.Transfer("Default.aspx", true);
                }
                else
                {
                    MsgBox("Usuario o contraseña incorrecta.");
                }
            }
            else
            {
                MsgBox("Campos incompletos.");
            }

        }
    }
}