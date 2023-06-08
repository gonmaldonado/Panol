using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Movimiento
    {
        public static void AltaMovimiento(string pMovimiento, int pTipo, List<Entidades.Item> pArt)
        {
            for (int i = 0; i < pArt.Count; i++)
            {
                Datos.Movimiento.AltaMovimiento(pMovimiento, pTipo, pArt[i].Codigo.ToString(), pArt[i].Cantidad);
            }    
        }
        public static string GenerarCodigoMov(int TipoMov)
        {
            DateTime Hoy = DateTime.Now;
            string dia = Hoy.ToString("yyMMdd");
            string hora = DateTime.Now.TimeOfDay.Hours.ToString("D2");
            string minutos = DateTime.Now.TimeOfDay.Minutes.ToString("D2");
            string Codigo = "X";
            if (TipoMov == 1)//si es 1 es ENTRADA
            {
                Codigo = "E";
            }
            if (TipoMov == 2)//si es 2 es SALIDA
            {
                Codigo = "S";
            }
            if (TipoMov == 3)//si es 3 es RETIRO
            {
                Codigo = "R";
            }   
            Codigo = Codigo + dia + hora + minutos ;
            return Codigo;
        }
        public static string GenerarCodigoMovDev(string Mov)
        {
            string Codigo;
            Codigo = Mov.Replace("R", "D");
            return Codigo;
        }
        public static string GenerarCodigoAnulacion(string Mov)
        {
            string Codigo;
            Codigo = Mov.Substring(1);
            Codigo = "A" + Codigo;
            return Codigo;
        }
        public static string GenerarCodigoPed(string Mov)
        {
            string Codigo;
            int Cantidad = Mov.Trim().Length;
            Codigo = Mov.Replace("D", "R");
            if (Cantidad == 11)
            {
               
                if (Datos.Movimiento.ValidarMovimiento(Codigo.Trim()))
                {
                    Codigo = Codigo + "_1";
                }
            }
            else
            {
                if (Cantidad == 50)
                {
                    DateTime Hoy = DateTime.Now;
                    string dia = Hoy.ToString("yyMMdd");
                    string hora = DateTime.Now.TimeOfDay.Hours.ToString("D2");
                    string minutos = DateTime.Now.TimeOfDay.Minutes.ToString("D2");
                    Codigo = "D" + dia + hora + minutos;

                }
                else
                {
                    int numero = Convert.ToInt32(Codigo.Trim().Substring(12));
                    numero = numero + 1;
                    Codigo = Codigo.Trim().Substring(0, 12) + numero.ToString();
                }
            }
            return Codigo;
        }
        public static Boolean ValidarAnulado(string Mov)
        {
            return Datos.Movimiento.ValidarAnulado(Mov);
        }
        public static Boolean ValidarMovimiento(string Mov)
        {
            return Datos.Movimiento.ValidarMovimiento(Mov);
        }
        public static void AltaAnulacion(string Mov)
        {
            Datos.Movimiento.AltaAnulado(Mov);
        }
        public static DataTable RegistrosPD(string fecha1, string fecha2)
        {
            return Datos.Movimiento.ReporteMovimientosPD(fecha1, fecha2);
        }
        public static DataTable RegistrosES(string fecha1, string fecha2)
        {
            return Datos.Movimiento.ReporteMovimientosES(fecha1,fecha2);
        }
        public static DataTable Registros(string fecha1, string fecha2)
        {
            return Datos.Movimiento.ReporteMovimientos(fecha1, fecha2);
        }
        public static DataTable ArticulosEnRetiro()
        {
            return Datos.Movimiento.ArticulosEnRetiro();
        }
        public static DataTable Consumos(string fecha1, string fecha2)
        {
            return Datos.Movimiento.ReporteConsumo(fecha1, fecha2);
        }
    }
}
