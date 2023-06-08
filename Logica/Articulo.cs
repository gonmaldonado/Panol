using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Logica
{
    public class Articulo
    {
        public static DataTable ListaGrupoART()
        {
            return Datos.Articulo.ListarGruposART();
        }
        public static DataTable Stock()
        {
            return Datos.Articulo.TraerStock();
        }
        public static DataTable TraerBuscar()
        {
            return Datos.Articulo.TraerArticulos();
        }
        public static DataTable TraerBuscarEsp()
        {
            return Datos.Articulo.TraerArticulosEsp();
        }
        public static DataTable TraerBuscarRetiro()
        {
            return Datos.Articulo.TraerArticulosRetiro();
        }
        public static DataTable ListarStockMax()
        {
            return Datos.Articulo.ListarStockMax();
        }
        public static DataTable ListarStockMin()
        {
            return Datos.Articulo.ListarStockMin();
        }
        public static DataTable LinstarPuntoPedido()
        {
            return Datos.Articulo.ListarPuntoPedido();
        }
        public static DataTable ListarArticulos()
        {
            return Datos.Articulo.ListarArticulos();
        }
        public static DataTable ListarActivables()
        {
            return Datos.Articulo.ListarActivables();
        }
        public static bool ValidarArticulo(string Codigo)
        {
            return Datos.Articulo.ValidarArticulo(Codigo);
        }
        public static bool ValidarArticuloEsp(string Codigo)
        {
            return Datos.Articulo.ValidarArticuloEsp(Codigo);
        }
        public static bool ValidarArticuloRetiro(string Codigo)
        {
            return Datos.Articulo.ValidarArticuloRetiro(Codigo);
        }
        public static void AltaArticulo(Entidades.Articulo art)
        {
            Datos.Articulo.AltaArticulo(art);
        }
        public static void ModificarArticulo(Entidades.Articulo art)
        {
            Datos.Articulo.ModificarArticulo(art);
        }
        public static int TraerIDGrupo(string Codigo)
        {
            return Datos.Articulo.TraerIDGrupo(Codigo);
        }
        public static Entidades.Articulo TraerArticulo(string Codigo)
        {
            return Datos.Articulo.TraerArticulo(Codigo);
        }
        public static string TraerGrupo(int ID)
        {
            return Datos.Articulo.TraerGrupo(ID);
        }
        public static string TraerDescripcion(string CODIGO)
        {
            return Datos.Articulo.TraerDescripcionArt(CODIGO);
        }
        public static string TraerCodigoAlt(string CODIGO)
        {
            return Datos.Articulo.TraerCodigoAltArt(CODIGO);
        }
    }
}
