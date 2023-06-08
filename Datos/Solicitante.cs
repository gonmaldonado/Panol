using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Solicitante
    {
        public static Entidades.Solicitante TraerSolicitante(int pLegajo)
        {
            Entidades.Solicitante objEntidadSolicitante = new Entidades.Solicitante();
            string strproc = "SELECT * FROM T_SOLICITANTES WHERE LEGAJO= " + pLegajo + "";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand comTraerSolicitante = new SqlCommand(strproc, objConexion);
            comTraerSolicitante.CommandType = CommandType.Text;
            SqlDataReader drSolicitante; // no tiene constructor
            try
            {
                objConexion.Open();
                drSolicitante = comTraerSolicitante.ExecuteReader();

                if (drSolicitante.Read())
                {
                    objEntidadSolicitante.Legajo = Convert.ToInt32(drSolicitante["LEGAJO"].ToString().Trim());
                    objEntidadSolicitante.Apellido = drSolicitante["APELLIDO"].ToString().Trim();
                    objEntidadSolicitante.Nombre = drSolicitante["NOMBRE"].ToString().Trim();
                }


                objConexion.Close();
                return objEntidadSolicitante;

            }
            catch (SqlException)
            {
                throw new Exception("NO SE PUDO RECOLECTAR DATOS PARA EL SOLICITANTE");
            }
            finally
            {
                // se ejecuta siempre
                // cierro la conexion
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }
        public static void AltaSolicitante(Entidades.Solicitante pSolicitante)

        {
            string stProc = @"INSERT INTO T_SOLICITANTES VALUES (@LEGAJO,@APELLIDO,@NOMBRE)";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(stProc, objConexion);
            objComAgregar.Parameters.AddWithValue("@LEGAJO", pSolicitante.Legajo);
            objComAgregar.Parameters.AddWithValue("@NOMBRE", pSolicitante.Nombre.Trim().ToUpper());
            objComAgregar.Parameters.AddWithValue("@APELLIDO", pSolicitante.Apellido.Trim().ToUpper());
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            objComAgregar.ExecuteNonQuery();

        }
        public static void ModificarSolicitante(Entidades.Solicitante pSolicitante)

        {
            string stProc = @"UPDATE T_SOLICITANTES SET NOMBRE = @NOMBRE, APELLIDO = @APELLIDO WHERE LEGAJO = @LEGAJO ";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(stProc, objConexion);
            objComAgregar.Parameters.AddWithValue("@LEGAJO", pSolicitante.Legajo);
            objComAgregar.Parameters.AddWithValue("@NOMBRE", pSolicitante.Nombre.Trim().ToUpper());
            objComAgregar.Parameters.AddWithValue("@APELLIDO", pSolicitante.Apellido.Trim().ToUpper());


            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            objComAgregar.ExecuteNonQuery();

        }
        public static Boolean ValidarSolicitante(int c)
        {
            DataTable dt = new DataTable();
            Boolean b = false;
            string strProc = "Select * FROM T_SOLICITANTES WHERE LEGAJO = " + c + "";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }
        public static DataTable ListarSolicitantes()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT LEGAJO
                               ,NOMBRE +' '+ APELLIDO 'NOMBRE'
                               FROM T_SOLICITANTES";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }

    }
}
