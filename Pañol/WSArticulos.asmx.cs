using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Protocols;


namespace Pañol
{
    /// <summary>
    /// Descripción breve de WSArticulos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    [System.Web.Script.Services.ScriptService]
    public class WSArticulos : System.Web.Services.WebService
    {
        [WebMethod]
        public string[] ObtenerArticulos(string prefixText, int count)
        {
            string strSQL = "SELECT CODIGO FROM T_ARTICULOS where CODIGO  LIKE '%' + @letras + '%' OR CODIGO_ALT  LIKE '%' + @letras + '%'";
            SqlConnection objConexion = new SqlConnection(Logica.Conexion.TraerConexion());
            SqlCommand comBuscar = new SqlCommand(strSQL, objConexion);
            comBuscar.Parameters.AddWithValue("@letras", prefixText);
            SqlDataReader dr;
            List<string> lista = new List<string>();
            objConexion.Open();
            dr = comBuscar.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(dr["CODIGO"].ToString());

            }
            objConexion.Close();
            return lista.ToArray();

        }
        [WebMethod]
        public string[] ObtenerArticulosRetiro(string prefixText, int count)
        {
            string strSQL = "SELECT CODIGO FROM T_ARTICULOS where (ID_GRUPO_ART = 1 OR ID_GRUPO_ART = 4 OR ID_GRUPO_ART = 5) AND CODIGO  LIKE '%' + @letras + '%' OR CODIGO_ALT  LIKE '%' + @letras + '%'";
            SqlConnection objConexion = new SqlConnection(Logica.Conexion.TraerConexion());
            SqlCommand comBuscar = new SqlCommand(strSQL, objConexion);
            comBuscar.Parameters.AddWithValue("@letras", prefixText);
            SqlDataReader dr;
            List<string> lista = new List<string>();
            objConexion.Open();
            dr = comBuscar.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(dr["CODIGO"].ToString());

            }
            objConexion.Close();
            return lista.ToArray();

        }
        [WebMethod]
        public string[] ObtenerArticulos2(string prefixText, int count)
        {
            string strSQL = @"SELECT CODIGO FROM T_ARTICULOS where CODIGO  LIKE '%' + @letras + '%' OR CODIGO_ALT  LIKE '%' + @letras + '%'
                              OR DESCRIPCION  LIKE '%' + @letras + '%'OR DESCRIPCION_ALT  LIKE '%' + @letras + '%'";
            SqlConnection objConexion = new SqlConnection(Logica.Conexion.TraerConexion());
            SqlCommand comBuscar = new SqlCommand(strSQL, objConexion);
            comBuscar.Parameters.AddWithValue("@letras", prefixText);
            SqlDataReader dr;
            List<string> lista = new List<string>();
            objConexion.Open();
            dr = comBuscar.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(dr["CODIGO"].ToString());

            }
            objConexion.Close();
            return lista.ToArray();

        }
        [WebMethod]
        public string[] ObtenerLegajos(string prefixText, int count)
        {
            string strSQL = @"SELECT LEGAJO FROM T_SOLICITANTES where LEGAJO  LIKE '%' + @letras + '%'";
            SqlConnection objConexion = new SqlConnection(Logica.Conexion.TraerConexion());
            SqlCommand comBuscar = new SqlCommand(strSQL, objConexion);
            comBuscar.Parameters.AddWithValue("@letras", prefixText);
            SqlDataReader dr;
            List<string> lista = new List<string>();
            objConexion.Open();
            dr = comBuscar.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(dr["LEGAJO"].ToString());

            }
            objConexion.Close();
            return lista.ToArray();

        }
        [WebMethod]
        public string[] ObtenerTarjetas(string prefixText, int count)
        {
            string strSQL = @"SELECT TARJETA FROM T_TARJETAS where TARJETA  LIKE '%' + @letras + '%' AND ACTIVA = 0";
            SqlConnection objConexion = new SqlConnection(Logica.Conexion.TraerConexion());
            SqlCommand comBuscar = new SqlCommand(strSQL, objConexion);
            comBuscar.Parameters.AddWithValue("@letras", prefixText);
            SqlDataReader dr;
            List<string> lista = new List<string>();
            objConexion.Open();
            dr = comBuscar.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(dr["TARJETA"].ToString());

            }
            objConexion.Close();
            return lista.ToArray();

        }
        [WebMethod]
        public string[] ObtenerTarjetasAct(string prefixText, int count)
        {
            string strSQL = @"SELECT TARJETA FROM T_TARJETAS where TARJETA  LIKE '%' + @letras + '%' AND ACTIVA = 1";
            SqlConnection objConexion = new SqlConnection(Logica.Conexion.TraerConexion());
            SqlCommand comBuscar = new SqlCommand(strSQL, objConexion);
            comBuscar.Parameters.AddWithValue("@letras", prefixText);
            SqlDataReader dr;
            List<string> lista = new List<string>();
            objConexion.Open();
            dr = comBuscar.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(dr["TARJETA"].ToString());

            }
            objConexion.Close();
            return lista.ToArray();

        }
        [WebMethod]
        public string[] ObtenerArticulosEsp(string prefixText, int count)
        {
            string strSQL = "SELECT CODIGO FROM T_ARTICULOS where (CRITICO = 0) AND (CODIGO  LIKE '%' + @letras + '%' OR CODIGO_ALT  LIKE '%' + @letras + '%')";
            SqlConnection objConexion = new SqlConnection(Logica.Conexion.TraerConexion());
            SqlCommand comBuscar = new SqlCommand(strSQL, objConexion);
            comBuscar.Parameters.AddWithValue("@letras", prefixText);
            SqlDataReader dr;
            List<string> lista = new List<string>();
            objConexion.Open();
            dr = comBuscar.ExecuteReader();
            while (dr.Read())
            {
                lista.Add(dr["CODIGO"].ToString());

            }
            objConexion.Close();
            return lista.ToArray();

        }
    }
}
