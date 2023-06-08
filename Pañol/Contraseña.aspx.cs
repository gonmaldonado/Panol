using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pañol
{
    public partial class Contraseña : Utilidades
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
                    Entidades.Usuario user = new Entidades.Usuario();
                    user = Logica.Usuario.TraerUsuario((int)Session["ID_Responsable"]);
                    //txtContraseña.Attributes.Add("value", user.Contraseña);//para rellenar textbox con modo password
                    //txtConfContraseña.Attributes.Add("value", user.Contraseña);
                    txtContraseña.Text="";
                    txtConfContraseña.Text="";
                }
            }

        }

        protected void btnEntrada_Click(object sender, EventArgs e)
        {
            if(txtConfContraseña.Text.Trim() != "" & txtContraseña.Text.Trim() != "")
            {
                string cont = txtContraseña.Text.Trim();
                string cont2 = txtConfContraseña.Text.Trim();
                if (ValidarContraseña(cont, cont2))
                {

                    Entidades.Usuario user = new Entidades.Usuario();
                    user = Logica.Usuario.TraerUsuario((int)Session["ID_Responsable"]);
                    user.Contraseña = Logica.Usuario.Encrypt.GetSHA256(cont);
                    Logica.Usuario.ModificarUsuario(user);
                    //Response.Redirect("Default.aspx");
                    MsgBox("Se modifico la contraseña correctamente correctamente.");
                }
                else
                {
                    MsgBox("Los datos ingresados para la contraseña no coinciden.");
                }
            }
            else
            {
                MsgBox("Complete los campos incompletos.");
            }
            
        }
        public bool ValidarContraseña(string a, string b)
        {
            bool resultado = false;
            if (a.Trim() == b.Trim())
            {
                resultado = true;
            }
            return resultado;
        }
    }
}