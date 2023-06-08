using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Registro
    {
        public static void AltaRegistro(Entidades.Registro pRegistro)

        {
            string stProc = @"INSERT INTO T_REGISTROS VALUES (@CODIGO,@CODIGO_MOV,@FECHA,@HORA,@RESPONSABLE
                            ,@SOLICITANTE,@DOC_ENTREGA,@TARJETA,@DESTINO,@OBSERVACION)";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(stProc, objConexion);
            objComAgregar.Parameters.AddWithValue("@CODIGO", pRegistro.CodigoReg.Trim());
            objComAgregar.Parameters.AddWithValue("@CODIGO_MOV", pRegistro.CodigoMov.Trim());
            objComAgregar.Parameters.AddWithValue("@FECHA", pRegistro.Fecha);
            objComAgregar.Parameters.AddWithValue("@HORA", pRegistro.Hora);
            objComAgregar.Parameters.AddWithValue("@RESPONSABLE", pRegistro.Responsable);
            objComAgregar.Parameters.AddWithValue("@SOLICITANTE", pRegistro.Solicitante);
            objComAgregar.Parameters.AddWithValue("@TARJETA", pRegistro.Tarjeta);
            objComAgregar.Parameters.AddWithValue("@DOC_ENTREGA", pRegistro.Documento.Trim().ToUpper());
            objComAgregar.Parameters.AddWithValue("@DESTINO", pRegistro.Destino.Trim().ToUpper());
            objComAgregar.Parameters.AddWithValue("@OBSERVACION", pRegistro.Observacion.Trim().ToUpper());
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            objComAgregar.ExecuteNonQuery();

        }
        public static Boolean ValidarDocEntrega(string c)
        {
            DataTable dt = new DataTable();
            Boolean b = false;
            string strProc = "Select * FROM T_REGISTROS WHERE RTRIM(DOC_ENTREGA) = '" + c.Trim() + "'";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }

        public static Entidades.Registro TraerRegistro(int Tarjeta)
        {
            Entidades.Registro objEntidadRegistro = new Entidades.Registro();
            string strproc = "SELECT TOP (1) * FROM T_REGISTROS WHERE TARJETA ="+Tarjeta+" ORDER BY FECHA DESC, HORA DESC";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand comTraerRegistro = new SqlCommand(strproc, objConexion);
            comTraerRegistro.CommandType = CommandType.Text;
            SqlDataReader drRegistro; // no tiene constructor
            try
            {
                objConexion.Open();
                drRegistro = comTraerRegistro.ExecuteReader();

                if (drRegistro.Read())
                {
                    objEntidadRegistro.CodigoReg = drRegistro["CODIGO"].ToString().Trim();
                    objEntidadRegistro.Fecha = Convert.ToDateTime( drRegistro["FECHA"].ToString().Trim());
                    objEntidadRegistro.Hora = Convert.ToDateTime(drRegistro["HORA"].ToString().Trim());
                    objEntidadRegistro.Responsable = Convert.ToInt32(drRegistro["RESPONSABLE"].ToString().Trim());
                    objEntidadRegistro.Solicitante = Convert.ToInt32(drRegistro["SOLICITANTE"].ToString().Trim());
                    objEntidadRegistro.Documento = drRegistro["DOC_ENTREGA"].ToString().Trim();
                    objEntidadRegistro.Tarjeta = Convert.ToInt32(drRegistro["TARJETA"].ToString().Trim());
                    objEntidadRegistro.Destino= drRegistro["DESTINO"].ToString().Trim();
                    objEntidadRegistro.Observacion= drRegistro["OBSERVACION"].ToString().Trim();

                }


                objConexion.Close();
                return objEntidadRegistro;

            }

            catch (SqlException)
            {
                throw new Exception("NO SE PUDO RECOLECTAR DATOS PARA EL REGISTRO");
            }
            finally
            {
                // se ejecuta siempre
                // cierro la conexion
                if (objConexion.State == ConnectionState.Open)
                    objConexion.Close();

            }
        }
        public static DataTable ListarRegistrosHoy()

        {
            string hoy = DateTime.Today.ToString();
            DateTime dia2 = Convert.ToDateTime(hoy);
            DateTime dia1 = Convert.ToDateTime(hoy).AddDays(-1);
            DataTable dt = new DataTable();
            string strProc = @"select CONVERT(VARCHAR , r.FECHA , 103) 'Fecha',CONVERT( VARCHAR , r.HORA , 108)  'Hora',
                                r.CODIGO 'N_Registro',r.CODIGO_MOV 'N_Movimiento',r.DOC_ENTREGA 'Referencia',r.TARJETA 'Tarjeta',
                                s.NOMBRE +' '+s.APELLIDO 'Solicitante',u.NOMBRE+' '+u.APELLIDO 'Responsable',r.DESTINO 'Destino',r.OBSERVACION 'Observacion'
                                from T_REGISTROS r full join T_SOLICITANTES s on r.SOLICITANTE=s.LEGAJO
                                inner join T_USUARIOS u on u.LEGAJO = r.RESPONSABLE
                                where r.Fecha between CONVERT(VARCHAR, '" + dia1.ToString("dd/MM/yyyy") + "', 103) and CONVERT(VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 )" +
                                "order by r.Fecha desc,r.Hora desc";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ListarRegistros(string fecha1, string fecha2)

        {
            DateTime dia2 = Convert.ToDateTime(fecha2);
            DateTime dia1 = Convert.ToDateTime(fecha1);
            DataTable dt = new DataTable();
            string strProc = @"select CONVERT(VARCHAR , r.FECHA , 103) 'Fecha',CONVERT( VARCHAR , r.HORA , 108)  'Hora',
                                r.CODIGO 'N_Registro',r.CODIGO_MOV 'N_Movimiento',r.DOC_ENTREGA 'Referencia',r.TARJETA 'Tarjeta',
                                s.NOMBRE +' '+s.APELLIDO 'Solicitante',u.NOMBRE+' '+u.APELLIDO 'Responsable',r.DESTINO 'Destino',r.OBSERVACION 'Observacion'
                                from T_REGISTROS r full join T_SOLICITANTES s on r.SOLICITANTE=s.LEGAJO
                                inner join T_USUARIOS u on u.LEGAJO = r.RESPONSABLE
                                where r.Fecha between CONVERT(VARCHAR, '" + dia1.ToString("dd/MM/yyyy") + "', 103) and CONVERT(VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 )" +
                                "order by r.Fecha desc,r.Hora desc";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
    }
}
