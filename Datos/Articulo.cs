using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Datos
{
    public class Articulo
    {
        public static Entidades.Articulo TraerArticulo(string pCodigo)
        {
            Entidades.Articulo objEntidadArticulo = new Entidades.Articulo();
            string strproc = "SELECT * FROM T_ARTICULOS WHERE RTRIM(CODIGO) = '" + pCodigo.Trim() + "' or RTRIM(CODIGO_ALT) = '" + pCodigo.Trim() + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand comTraerArticulo = new SqlCommand(strproc, objConexion);
            comTraerArticulo.CommandType = CommandType.Text;
            SqlDataReader drArticulo; // no tiene constructor
            try
            {
                objConexion.Open();
                drArticulo = comTraerArticulo.ExecuteReader();

                if (drArticulo.Read())
                {
                    objEntidadArticulo.Codigo= drArticulo["CODIGO"].ToString().Trim();
                    objEntidadArticulo.CodigoAlt = drArticulo["CODIGO_ALT"].ToString().Trim();
                    objEntidadArticulo.Descripcion= drArticulo["DESCRIPCION"].ToString().Trim();
                    objEntidadArticulo.DescripcionAlt = drArticulo["DESCRIPCION_ALT"].ToString().Trim();
                    objEntidadArticulo.Sector = Convert.ToInt32(drArticulo["ID_GRUPO_ART"].ToString().Trim());
                    objEntidadArticulo.Ubicacion = drArticulo["UBICACION"].ToString().Trim();
                    objEntidadArticulo.Uso = drArticulo["USO"].ToString().Trim();
                    objEntidadArticulo.Critico = Convert.ToBoolean(drArticulo["CRITICO"].ToString().Trim());
                    objEntidadArticulo.CantDisponible = Convert.ToInt32(drArticulo["CANT_DISP"].ToString().Trim());
                    objEntidadArticulo.CantRetenida = Convert.ToInt32(drArticulo["CANT_RETE"].ToString().Trim());
                    objEntidadArticulo.Max= Convert.ToInt32(drArticulo["MAX"].ToString().Trim());
                    objEntidadArticulo.Min = Convert.ToInt32(drArticulo["MIN"].ToString().Trim());
                    objEntidadArticulo.Aviso = Convert.ToInt32(drArticulo["AVISO"].ToString().Trim());

                }


                objConexion.Close();
                return objEntidadArticulo;

            }

            catch (SqlException)
            {
                throw new Exception("NO SE PUDO RECOLECTAR DATOS PARA EL ARTICULO");
            }
            finally
            {
                // se ejecuta siempre
                // cierro la conexion
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }
        public static void AltaArticulo(Entidades.Articulo pArticulo)

        {
            string stProc = @"INSERT INTO T_ARTICULOS VALUES (@CODIGO,@CODIGO_ALT,@DESCRIPCION,@DESCRIPCION_ALT,@GRUPO_ART
                            ,@CANT_DISP,@CANT_RETE,@MAX,@MIN,@AVISO,@CRITICO,@UBICACION,@USO)";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(stProc, objConexion);
            objComAgregar.Parameters.AddWithValue("@CODIGO",pArticulo.Codigo.Trim());
            objComAgregar.Parameters.AddWithValue("@CODIGO_ALT", pArticulo.CodigoAlt.Trim());
            objComAgregar.Parameters.AddWithValue("@DESCRIPCION", pArticulo.Descripcion.Trim().ToUpper());
            objComAgregar.Parameters.AddWithValue("@DESCRIPCION_ALT", pArticulo.DescripcionAlt.Trim().ToUpper());
            objComAgregar.Parameters.AddWithValue("@GRUPO_ART", pArticulo.Sector);
            objComAgregar.Parameters.AddWithValue("@CRITICO", pArticulo.Critico);
            objComAgregar.Parameters.AddWithValue("@CANT_DISP", 0);
            objComAgregar.Parameters.AddWithValue("@CANT_RETE", 0);
            objComAgregar.Parameters.AddWithValue("@MAX", Convert.ToInt32(pArticulo.Max));
            objComAgregar.Parameters.AddWithValue("@MIN", Convert.ToInt32(pArticulo.Min));
            objComAgregar.Parameters.AddWithValue("@AVISO", Convert.ToInt32(pArticulo.Aviso));
            objComAgregar.Parameters.AddWithValue("@UBICACION", pArticulo.Ubicacion.Trim().ToUpper());
            objComAgregar.Parameters.AddWithValue("@USO", pArticulo.Uso.Trim().ToUpper());
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            objComAgregar.ExecuteNonQuery();

        }
        public static void ModificarArticulo(Entidades.Articulo pArticulo)

        {
            string stProc = @"UPDATE T_ARTICULOS SET CODIGO_ALT = @CODIGO_ALT,DESCRIPCION = @DESCRIPCION, DESCRIPCION_ALT = @DESCRIPCION_ALT,ID_GRUPO_ART = @GRUPO_ART,
                            UBICACION = @UBICACION,CRITICO = @CRITICO,MAX = @MAX,MIN = @MIN,AVISO = @AVISO, USO = @USO WHERE RTRIM(CODIGO) = @CODIGO";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(stProc, objConexion);
            objComAgregar.Parameters.AddWithValue("@CODIGO", pArticulo.Codigo.Trim());
            objComAgregar.Parameters.AddWithValue("@CODIGO_ALT", pArticulo.CodigoAlt.Trim());
            objComAgregar.Parameters.AddWithValue("@DESCRIPCION", pArticulo.Descripcion.Trim().ToUpper());
            objComAgregar.Parameters.AddWithValue("@DESCRIPCION_ALT", pArticulo.DescripcionAlt.Trim().ToUpper());
            objComAgregar.Parameters.AddWithValue("@GRUPO_ART", pArticulo.Sector);
            objComAgregar.Parameters.AddWithValue("@CRITICO", pArticulo.Critico);
            objComAgregar.Parameters.AddWithValue("@MAX", Convert.ToInt32(pArticulo.Max));
            objComAgregar.Parameters.AddWithValue("@MIN", Convert.ToInt32(pArticulo.Min));
            objComAgregar.Parameters.AddWithValue("@AVISO", Convert.ToInt32(pArticulo.Aviso));
            objComAgregar.Parameters.AddWithValue("@UBICACION", pArticulo.Ubicacion.Trim().ToUpper());
            objComAgregar.Parameters.AddWithValue("@USO", pArticulo.Uso.Trim().ToUpper());


            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            objComAgregar.ExecuteNonQuery();

        }
    
    public static DataTable ListarGruposART()

    {
        DataTable dt = new DataTable();
        string strProc = "SELECT GRUPO FROM T_GRUPO_ARTICULOS ";
        SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
        objDaTraer.SelectCommand.CommandType = CommandType.Text;
        objDaTraer.Fill(dt);
        return dt;
    }
    public static Boolean ValidarArticulo(string c)
    {
        DataTable dt = new DataTable();
        Boolean b = false;
        string strProc = "Select * FROM T_ARTICULOS WHERE RTRIM(CODIGO) = '" + c.Trim() + "' OR RTRIM(CODIGO_ALT) = '" + c.Trim() + "'";
        SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
        objDaTraer.SelectCommand.CommandType = CommandType.Text;
        objDaTraer.Fill(dt);
        if (dt.Rows.Count > 0)
        {
         b = true;
        }
         return b;
        }
        public static Boolean ValidarArticuloEsp(string c)
        {
            DataTable dt = new DataTable();
            Boolean b = false;
            string strProc = "Select * FROM T_ARTICULOS WHERE (RTRIM(CODIGO) = '" + c.Trim() + "' OR RTRIM(CODIGO_ALT) = '" + c.Trim() + "') AND CRITICO = 0 ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }
        public static Boolean ValidarArticuloRetiro(string c)
        {
            DataTable dt = new DataTable();
            Boolean b = false;
            string strProc = "Select * FROM T_ARTICULOS WHERE RTRIM(CODIGO) = '" + c.Trim() + "' OR RTRIM(CODIGO_ALT) = '" + c.Trim() + "' and (ID_GRUPO_ART = 1 OR ID_GRUPO_ART = 4 OR ID_GRUPO_ART = 5) ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }
        public static int TraerIDGrupo(string c)
        {
            int grupo;
            DataTable dt = new DataTable();
            Boolean b = false;
            string strProc = "Select ID FROM T_GRUPO_ARTICULOS WHERE RTRIM(GRUPO) = '" + c.Trim() + "'";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            grupo = Convert.ToInt32(CommandType.Text);
            return grupo;
        }
        public static string TraerGrupo(int c)
        {
             string strProc = "select GRUPO FROM T_GRUPO_ARTICULOS where id =" + c + "";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(strProc, objConexion);
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            string grupo = objComAgregar.ExecuteScalar().ToString();
            objConexion.Close();
            return grupo;
        }
        public static string TraerDescripcionArt(string c)
        {
            string strProc = "select DESCRIPCION FROM T_ARTICULOS where RTRIM(CODIGO)='" + c.Trim() + "' or RTRIM(CODIGO_ALT)='" + c.Trim() + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(strProc, objConexion);
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            string descripcion = objComAgregar.ExecuteScalar().ToString();
            objConexion.Close();
            return descripcion;
        }
        public static string TraerCodigoAltArt(string c)
        {
            string strProc = "select CODIGO_ALT FROM T_ARTICULOS where RTRIM(CODIGO)='" + c.Trim() + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(strProc, objConexion);
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            string descripcion = objComAgregar.ExecuteScalar().ToString();
            objConexion.Close();
            return descripcion;
        }
        public static DataTable TraerStock()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT a.[CODIGO]
                              ,a.[CODIGO_ALT]
                              ,a.[DESCRIPCION]
                              ,a.[DESCRIPCION_ALT]
                              ,g.[GRUPO]
                              ,a.[CANT_DISP]
                              ,a.[CANT_RETE]
	                          ,a.[CANT_DISP]+a.[CANT_RETE]'STOCK'
                              ,a.[UBICACION]
                          FROM [T_ARTICULOS] a inner join T_GRUPO_ARTICULOS g on a.ID_GRUPO_ART=g.ID";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable TraerArticulos()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT [CODIGO]
                              ,[DESCRIPCION]
                            FROM [T_ARTICULOS]";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable TraerArticulosEsp()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT [CODIGO]
                              ,[DESCRIPCION]
                            FROM [T_ARTICULOS] WHERE CRITICO = 0";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable TraerArticulosRetiro()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT [CODIGO]
                              ,[DESCRIPCION]
                            FROM [T_ARTICULOS] WHERE ID_GRUPO_ART = 1 OR ID_GRUPO_ART = 4 OR ID_GRUPO_ART = 5 ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarStockMax()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT CODIGO 'Articulo', DESCRIPCION 'Descripcion',MAX 'Cant Max', CANT_DISP 'Disponible'
                                FROM T_ARTICULOS Where CANT_DISP >= MAX  ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarArticulos()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT 
                              a.[CODIGO] 'Articulo'
                              ,a.[CODIGO_ALT] 'Cod_Alt'
                              ,a.[DESCRIPCION] 'Descripcion'
                              ,a.[DESCRIPCION_ALT] 'Descripcion_Alt'
                              ,g.[GRUPO] 'Grupo' 
                              ,a.[MAX] 'Max'
                              ,a.[MIN] 'Min'
                              ,a.[AVISO] 'Pto Aviso'
                              ,CAST(Case 
                                    When a.[CRITICO] =1 Then 'SI' 
                                    ELse 'NO' END 
                                AS Varchar(256))'Activable'
                              ,a.[UBICACION] 'Ubicacion'
                              ,a.[USO] 'Uso'
                              FROM [Pañol].[dbo].[T_ARTICULOS] a
                              inner join T_GRUPO_ARTICULOS g on a.ID_GRUPO_ART = g.ID";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarStockMin()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT CODIGO 'Articulo', DESCRIPCION 'Descripcion',MIN 'Cant Min', CANT_DISP 'Disponible' 
                               FROM T_ARTICULOS Where CANT_DISP <= MIN  ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarPuntoPedido()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT CODIGO 'Articulo', DESCRIPCION 'Descripcion',Aviso 'Pto Pedido', CANT_DISP 'Disponible' 
                                FROM T_ARTICULOS Where CANT_DISP <= AVISO  ";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarActivables()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT 
                               [CODIGO] 'Articulo'
                              ,[CODIGO_ALT] 'Cod_Alt'
                              ,[DESCRIPCION] 'Descripcion'
                              ,[DESCRIPCION_ALT] 'Descripcion_Alt'
                              ,[USO] 'Uso'
	                          ,CANT_DISP 'Cantidad'
                              FROM [Pañol].[dbo].[T_ARTICULOS] 
                              where [CRITICO] = 1";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }

    }
}
