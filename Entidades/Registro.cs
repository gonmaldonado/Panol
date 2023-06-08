using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class Registro
    {
        public string CodigoReg { get; set; }
        public string CodigoMov { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int Responsable { get; set; }
        public int Solicitante { get; set; }
        public string Documento { get; set; }
        public int Tarjeta { get; set; }
        public string Destino { get; set; }
        public string Observacion { get; set; }


    }
}
