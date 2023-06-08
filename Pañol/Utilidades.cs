using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Pañol
{
    public class Utilidades : Page
    {
        public void MsgBox(string pMensaje)
        {
            string msj = "<script language='Javascript'> alert('" + pMensaje + "');</script>";
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "mensaje", msj);

        }

    }
}