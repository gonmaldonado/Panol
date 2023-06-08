using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Articulo
    {
        public string Codigo { get; set; }
        public string CodigoAlt { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionAlt { get; set; }
        public int Sector { get; set; }
        public int CantDisponible { get; set; }
        public int CantRetenida { get; set; }
        public int Max { get; set; }
        public int Min { get; set; }
        public int Aviso { get; set; }
        public bool Critico { get; set; }
        public string Ubicacion { get; set; }
        public string Uso { get; set; }

    }
}
