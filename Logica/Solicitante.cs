using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Solicitante
    {
        public static DataTable ListarSolicitantes()
        {
            return Datos.Solicitante.ListarSolicitantes();
        }
        public static bool ValidarSolicitante(int Legajo)
        {
            return Datos.Solicitante.ValidarSolicitante(Legajo);
        }
        public static void AltaSolicitante(Entidades.Solicitante Solicitante)
        {
            Datos.Solicitante.AltaSolicitante(Solicitante);
        }
        public static void ModificarSolicitante(Entidades.Solicitante Solicitante)
        {
            Datos.Solicitante.ModificarSolicitante(Solicitante);
        }
        public static Entidades.Solicitante TraerSolicitante(int Legajo)
        {
            return Datos.Solicitante.TraerSolicitante(Legajo);
        }

    }
}
