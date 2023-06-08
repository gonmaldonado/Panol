using System;
using System.Collections.Generic;
using System.Reflection;
using System.Security.Principal;
using System.Text;

namespace Entidades
{
    public class Tarjeta
    {
        public int Numero { get; set; }
        public string CodigoMov { get; set; }
        public bool Activo { get; set; }
    }
}
