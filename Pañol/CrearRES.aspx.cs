using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pañol
{
    public partial class CrarADM : Utilidades
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Login"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if ((int)Session["Tipo_Responsable"] != 1)
                {
                    Response.Redirect("Default.aspx");
                }
                else 
                {
                    if (!IsPostBack)
                    {
                        RadioButtonList1.SelectedValue = "Estandar";
                    }
                }
            }


     
        }
        public bool ValidarContraseña(string a , string b)
        {
            bool resultado = false;
            if (a.Trim() == b.Trim())
            {
                resultado = true;
            }
            return resultado;
        }

        protected void btnEntrada_Click(object sender, EventArgs e)
        {
            if(txtApellido.Text.Trim()!="" & txtLegajo.Text.Trim()!="" & txtNombre.Text.Trim()!="" & txtConfContraseña.Text.Trim()!="" & txtContraseña.Text.Trim() != "")
            {
                int Legajo = Convert.ToInt32(txtLegajo.Text.Trim());
                string cont = txtContraseña.Text.Trim();
                string cont2 = txtConfContraseña.Text.Trim();
                if (!Logica.Usuario.ValidarUsuario(Legajo))
                {
                    if (ValidarContraseña(cont, cont2))
                    {
                        Entidades.Usuario user = new Entidades.Usuario();
                        user.Legajo = Legajo;
                        user.Nombre = txtNombre.Text.Trim().ToUpper();
                        user.Apellido = txtApellido.Text.Trim().ToUpper();
                        user.Contraseña = cont;

                        if (RadioButtonList1.SelectedValue == "Administrador")
                        {
                            user.Tipo = 1;
                        }
                        else
                        {
                            user.Tipo = 2;
                        }
                        Logica.Usuario.AltaUsuario(user);
                        MsgBox("Se dio de alta el responsable correctamente.");
                        txtApellido.Text = "";
                        txtLegajo.Text = "";
                        txtNombre.Text = "";
                        txtContraseña.Text = "";
                        txtConfContraseña.Text = "";
                        RadioButtonList1.SelectedValue = "Estandar";
                    }
                    else
                    {
                        MsgBox("Los datos ingresados para la contraseña no coinciden.");
                    }
                }
                else
                {
                    MsgBox("Legajo no valido.");
                    txtLegajo.Text = "";
                }
                

            }
            else
            {
                MsgBox("Complete los campos incompletos.");
            }
        }
    }
}