using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pañol
{
    public partial class ModificarADM : Utilidades
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
                        pUsuario.Visible = false;
                    }
                }
            }
           
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (txtLegajo.Text.Trim() != "")
            {
                Entidades.Usuario user = new Entidades.Usuario();
                int legajo = Convert.ToInt32(txtLegajo.Text.Trim());
                if (Logica.Usuario.ValidarUsuario(legajo))
                {

                    user = Logica.Usuario.TraerUsuario(legajo);
                    txtApellido.Text = user.Apellido;
                    txtNombre.Text = user.Nombre;
                    //txtContraseña.Attributes.Add("value", user.Contraseña);//para rellenar textbox con modo password
                    //txtConfContraseña.Attributes.Add("value", user.Contraseña);
                    txtContraseña.Text="";//para rellenar textbox con modo password
                    txtConfContraseña.Text="";
                    if (user.Tipo == 1)
                    {
                        
                        RadioButtonList1.SelectedValue = "Administrador";
                    }
                    else
                    {
                        RadioButtonList1.SelectedValue = "Estandar";
                    }
                    txtLegajo.Enabled = false;
                    pUsuario.Visible = true;
                }
                else
                {
                    MsgBox("Legajo incorrecto.");
                    txtLegajo.Text = "";
                }
            }
            
        }

        protected void btnBorrar_Click(object sender, EventArgs e)
        {
            pUsuario.Visible = false;
            txtLegajo.Text = "";
            txtLegajo.Enabled = true;
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


        protected void btnEntrada_Click(object sender, EventArgs e)
        {
            if (txtApellido.Text.Trim() != "" & txtLegajo.Text.Trim() != "" & txtNombre.Text.Trim() != "")
            {
                int Legajo = Convert.ToInt32(txtLegajo.Text.Trim());
                if (Logica.Usuario.ValidarUsuario(Legajo))
                {
                    Entidades.Usuario user = new Entidades.Usuario();
                    user = Logica.Usuario.TraerUsuario(Legajo);
                    user.Nombre = txtNombre.Text.Trim().ToUpper();
                    user.Apellido = txtApellido.Text.Trim().ToUpper();
                    if (txtConfContraseña.Text.Trim() != "" & txtContraseña.Text.Trim() != "")
                    {
                        string cont = txtContraseña.Text.Trim();
                        string cont2 = txtConfContraseña.Text.Trim();
                        if (ValidarContraseña(cont, cont2))
                        {
                           
                            user.Contraseña = Logica.Usuario.Encrypt.GetSHA256(cont);

                        }
                        else
                        {
                            MsgBox("Los datos ingresados para la contraseña no coinciden.");
                        }
                    }
                    if (RadioButtonList1.SelectedValue == "Administrador")
                    {
                        user.Tipo = 1;
                    }
                    else
                    {
                        user.Tipo = 2;
                    }
                    Logica.Usuario.ModificarUsuario(user);
                    MsgBox("Se modifico el responsable correctamente.");
                    txtApellido.Text = "";
                    txtLegajo.Text = "";
                    txtNombre.Text = "";
                    txtContraseña.Text = "";
                    txtConfContraseña.Text = "";
                    RadioButtonList1.SelectedValue = "Estandar";
                    pUsuario.Visible = false;
                    txtLegajo.Enabled = true;
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