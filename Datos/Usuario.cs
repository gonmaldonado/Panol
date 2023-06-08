using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Datos
{
    public class Usuario
    {
        public static Boolean ValidarUsuario(int Legajo, string Contraseña)
        {
            DataTable dt = new DataTable();
            Boolean b = false;
            string strProc = @"Select * FROM T_USUARIOS WHERE LEGAJO = " + Legajo + " " +
                                 "and CONTRASEÑA ='"+GetSHA256(Contraseña.Trim())+"'";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }
        public static Boolean ValidarUsuario(int Legajo)
        {
            DataTable dt = new DataTable();
            Boolean b = false;
            string strProc = "Select * FROM T_USUARIOS WHERE LEGAJO = " + Legajo + "";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }
        public static Entidades.Usuario TraerUsuario(int pLegajo)
        {
            Entidades.Usuario objEntidadUsuario = new Entidades.Usuario();
            string strproc = @"SELECT * FROM T_USUARIOS WHERE LEGAJO= " + pLegajo + "";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand comTraerUsuario = new SqlCommand(strproc, objConexion);
            comTraerUsuario.CommandType = CommandType.Text;
            SqlDataReader drSolicitante; 
            try
            {
                objConexion.Open();
                drSolicitante = comTraerUsuario.ExecuteReader();

                if (drSolicitante.Read())
                {
                    objEntidadUsuario.Legajo = Convert.ToInt32(drSolicitante["LEGAJO"].ToString().Trim());
                    objEntidadUsuario.Apellido = drSolicitante["APELLIDO"].ToString().Trim();
                    objEntidadUsuario.Nombre = drSolicitante["NOMBRE"].ToString().Trim();
                    objEntidadUsuario.Contraseña = drSolicitante["CONTRASEÑA"].ToString().Trim();
                    objEntidadUsuario.Tipo = Convert.ToInt32(drSolicitante["TIPO_USER"].ToString().Trim());
                }


                objConexion.Close();
                return objEntidadUsuario;

            }
            catch (SqlException)
            {
                throw new Exception("NO SE PUDO RECOLECTAR DATOS PARA EL USUARIO");
            }
            finally
            {
                // se ejecuta siempre
                // cierro la conexion
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }
            public static void ModificarUsuario(Entidades.Usuario pUsuario)

            {
                string stProc = @"UPDATE T_USUARIOS SET NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, CONTRASEÑA = @CONTRASEÑA, TIPO_USER = @TIPO  WHERE LEGAJO = @LEGAJO ";
                SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
                SqlCommand objComAgregar = new SqlCommand(stProc, objConexion);
                objComAgregar.Parameters.AddWithValue("@LEGAJO", pUsuario.Legajo);
                objComAgregar.Parameters.AddWithValue("@NOMBRE", pUsuario.Nombre.Trim().ToUpper());
                objComAgregar.Parameters.AddWithValue("@APELLIDO", pUsuario.Apellido.Trim().ToUpper());
                objComAgregar.Parameters.AddWithValue("@CONTRASEÑA",pUsuario.Contraseña.Trim());
                objComAgregar.Parameters.AddWithValue("@TIPO", Convert.ToInt32(pUsuario.Tipo));


            objComAgregar.CommandType = CommandType.Text;
                objConexion.Open();
                objComAgregar.ExecuteNonQuery();

            }
        public static DataTable ListarTiposUser()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT TIPO
                               FROM T_TIPO_USER";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static void AltaUsuario(Entidades.Usuario pUsuario)

        {
            string stProc = @"INSERT INTO T_USUARIOS VALUES (@LEGAJO,@NOMBRE,@APELLIDO,@CONTRASEÑA,@TIPO)";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(stProc, objConexion);
            objComAgregar.Parameters.AddWithValue("@LEGAJO", pUsuario.Legajo);
            objComAgregar.Parameters.AddWithValue("@NOMBRE", pUsuario.Nombre);
            objComAgregar.Parameters.AddWithValue("@APELLIDO", pUsuario.Apellido);
            objComAgregar.Parameters.AddWithValue("@CONTRASEÑA",GetSHA256(pUsuario.Contraseña));
            objComAgregar.Parameters.AddWithValue("@TIPO", pUsuario.Tipo);
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            objComAgregar.ExecuteNonQuery();

        }
        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}
