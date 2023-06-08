using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Tarjeta
    {
        public static Boolean ValidarTarjeta(int c)
        {
            DataTable dt = new DataTable();
            Boolean b = false;
            string strProc = "Select * FROM T_TARJETAS WHERE TARJETA = " + c + " AND ACTIVA = 0";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }
        public static Boolean ValidarTarjetaAct(int c)
        {
            DataTable dt = new DataTable();
            Boolean b = false;
            string strProc = "Select * FROM T_TARJETAS WHERE TARJETA = " + c + " AND ACTIVA = 1";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }
        public static DataTable ListarTarjetas()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT *
                               FROM T_TARJETAS";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarTarjetasAct()

        {
            DataTable dt = new DataTable();
            string strProc = @"SELECT TARJETA 'Tarjeta', CODIGO_MOV 'N_Movimiento'
                               FROM T_TARJETAS WHERE ACTIVA = 1";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static Entidades.Tarjeta TraerTarjeta(int pNumero)
        {
            Entidades.Tarjeta objEntidadTarjeta = new Entidades.Tarjeta();
            string strproc = "SELECT * FROM T_TARJETAS WHERE TARJETA = " + pNumero + "";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand comTraerTarjeta = new SqlCommand(strproc, objConexion);
            comTraerTarjeta.CommandType = CommandType.Text;
            SqlDataReader drTarjeta; // no tiene constructor
            try
            {
                objConexion.Open();
                drTarjeta = comTraerTarjeta.ExecuteReader();

                if (drTarjeta.Read())
                {
                    objEntidadTarjeta.Numero = Convert.ToInt32(drTarjeta["TARJETA"].ToString().Trim());
                    objEntidadTarjeta.CodigoMov = drTarjeta["CODIGO_MOV"].ToString().Trim();
                    objEntidadTarjeta.Activo = Convert.ToBoolean(drTarjeta["ACTIVA"].ToString().Trim());
                }


                objConexion.Close();
                return objEntidadTarjeta;

            }
            catch (SqlException)
            {
                throw new Exception("NO SE PUDO RECOLECTAR DATOS PARA LA TARJETA");
            }
            finally
            {
                // se ejecuta siempre
                // cierro la conexion
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }
        public static void ModificarTarjeta(Entidades.Tarjeta pTajeta)

        {
            string stProc = @"UPDATE T_TARJETAS SET CODIGO_MOV = @CODIGO_MOV, ACTIVA = @ACTIVA WHERE TARJETA = @TARJETA ";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(stProc, objConexion);
            objComAgregar.Parameters.AddWithValue("@CODIGO_MOV", pTajeta.CodigoMov);
            objComAgregar.Parameters.AddWithValue("@ACTIVA", pTajeta.Activo);
            objComAgregar.Parameters.AddWithValue("@TARJETA", pTajeta.Numero);


            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            objComAgregar.ExecuteNonQuery();

        }
        public static DataTable TraerPedido(string Movimiento)
        {

            DataTable dt = new DataTable();
            string strProc = @"select m.CODIGO_ART 'Articulo',a.DESCRIPCION 'Descripcion',m.CANTIDAD 'Cantidad' 
                                from T_MOVIMIENTOS m inner join T_ARTICULOS a on m.CODIGO_ART=a.CODIGO 
                                where RTRIM(m.CODIGO)= '"+Movimiento.Trim()+"'";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static string TraerMovimiento(int Tarjeta)
        {
            string strProc = "select TOP(1)  CODIGO_MOV from T_REGISTROS WHERE TARJETA = "+Tarjeta+" order by fecha desc , hora desc";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(strProc, objConexion);
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            string grupo = objComAgregar.ExecuteScalar().ToString();
            objConexion.Close();
            return grupo;
        }
        public static int TraerTarjeta(string Movimiento)
        {
            string strProc = "select TARJETA from T_REGISTROS WHERE CODIGO_MOV = '" + Movimiento.Trim() + "'";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(strProc, objConexion);
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            int grupo = Convert.ToInt32(objComAgregar.ExecuteScalar().ToString());
            objConexion.Close();
            return grupo;
        }

    }
}
