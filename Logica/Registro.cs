using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Registro
    {
        public static void CrearRegistro(Entidades.Registro pReg)
        {
            Datos.Registro.AltaRegistro(pReg);
        }
        public static string GenerarCodigo()
        {
            DateTime Hoy = DateTime.Now;
            string dia = Hoy.ToString("yyMMdd");
            string hora = DateTime.Now.TimeOfDay.Hours.ToString("D2");
            string minutos = DateTime.Now.TimeOfDay.Minutes.ToString("D2");
            string segundos = DateTime.Now.TimeOfDay.Seconds.ToString("D2");
            string Codigo = "R";
            Codigo = Codigo + dia + hora + minutos + segundos;
            return Codigo;

        }
        public static bool ValidarDocEntrega(string doc)
        {
            return Datos.Registro.ValidarDocEntrega(doc);
        }
        public static Entidades.Registro TraerRegistro(int Tarjeta)
        {
            return Datos.Registro.TraerRegistro(Tarjeta);
        }
        public static DataTable RegistrosHoy()
        {
            return Datos.Registro.ListarRegistrosHoy();
        }
        public static DataTable Registros(string fecha1,string fecha2)
        {
            return Datos.Registro.ListarRegistros(fecha1,fecha2);
        }
    }
}
