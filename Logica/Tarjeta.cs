using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace Logica
{
    public class Tarjeta
    {
        public static DataTable ListarTarjetas()
        {
            return Datos.Tarjeta.ListarTarjetas();
        }
        public static DataTable ListarTarjetasAct()
        {
            return Datos.Tarjeta.ListarTarjetasAct();
        }
        public static bool ValidarTarjeta(int numero)
        {
            return Datos.Tarjeta.ValidarTarjeta(numero);
        }
        public static bool ValidarTarjetaAct(int numero)
        {
            return Datos.Tarjeta.ValidarTarjetaAct(numero);
        }
        public static Entidades.Tarjeta TraerTarjeta(int Numero)
        {
            return Datos.Tarjeta.TraerTarjeta(Numero);
        }
        public static int TraerTarjeta(string mov)
        {
            return Datos.Tarjeta.TraerTarjeta(mov);
        }
        public static void ModificarTarjeta(Entidades.Tarjeta Tarjeta)
        {
            Datos.Tarjeta.ModificarTarjeta(Tarjeta);
        }
        public static DataTable TraerPedido(string Movimiento)
        {
            return Datos.Tarjeta.TraerPedido(Movimiento);
        }
        public static string TraerMovimiento(int Tarjeta)
        {
           return  Datos.Tarjeta.TraerMovimiento(Tarjeta);
        }
    }
}
