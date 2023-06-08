using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Datos
{
    public class Conexion
    {
        public static string strConexion = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    }
}
