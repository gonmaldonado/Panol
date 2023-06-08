using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
    public class Movimiento
    {
        public static void AltaMovimiento(string Query)

        {
            string stProc = Query;
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(stProc, objConexion);
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            objComAgregar.ExecuteNonQuery();

        }
        public static void AltaMovimiento(string Movimiento, int Tipo, string CodigoART, int Cantidad)

        {
            string stProc = @"EXEC MovStock @MOVIMIENTO,@TIPO,@CODIGO,@CANTIDAD";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(stProc, objConexion);
            objComAgregar.Parameters.AddWithValue("@CODIGO", CodigoART.Trim());
            objComAgregar.Parameters.AddWithValue("@MOVIMIENTO", Movimiento.Trim());
            objComAgregar.Parameters.AddWithValue("@TIPO", Tipo);
            objComAgregar.Parameters.AddWithValue("@CANTIDAD", Cantidad);
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            objComAgregar.ExecuteNonQuery();

        }
        public static DataTable ReporteMovimientosES(string fecha1, string fecha2)
        {
            DateTime dia1 = Convert.ToDateTime(fecha1);
            DateTime dia2 = Convert.ToDateTime(fecha2);
            DataTable dt = new DataTable();
            string strProc = @"  select CONVERT(VARCHAR , r.FECHA , 103) 'Fecha',CONVERT( VARCHAR , r.HORA , 108)  'Hora', m.CODIGO 'N_Movimiento',tm.Movimiento 'Tipo_Mov',r.DOC_ENTREGA 'Referencia',m.CODIGO_ART 'Cod_Articulo',a.DESCRIPCION 'Descripcion', 
                                  m.CANTIDAD 'Cantidad',r.RESPONSABLE 'Responsable',r.SOLICITANTE 'Solicitante'  
                                  from t_movimientos m inner join T_TIPO_MOVIMIENTO tm on tm.ID=m.TIPO_MOV
                                  inner join T_REGISTROS r on r.CODIGO_MOV=m.CODIGO
                                  inner join T_ARTICULOS a on a.CODIGO = m.CODIGO_ART
                                  inner join T_USUARIOS res on res.LEGAJO = r.RESPONSABLE
                                  full join T_SOLICITANTES sol on sol.LEGAJO = r.SOLICITANTE
                                  where (m.TIPO_MOV = 1 or m.TIPO_MOV=2) AND
                                  (r.Fecha between CONVERT( VARCHAR , '" + dia1.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 ))" +
                                  "Order By r.fecha desc, r.hora desc";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ReporteConsumo(string fecha1, string fecha2)
        {
            DateTime dia1 = Convert.ToDateTime(fecha1);
            DateTime dia2 = Convert.ToDateTime(fecha2);
            DataTable dt = new DataTable();
            string strProc = @" select CONVERT(VARCHAR , r.FECHA , 103) 'Fecha',CONVERT( VARCHAR , r.HORA , 108)  'Hora', m.CODIGO 'N_Movimiento',m.CODIGO_ART 'Cod_Articulo',a.DESCRIPCION 'Descripcion', g.GRUPO 'Grupo',
                                  m.CANTIDAD 'Cantidad',r.RESPONSABLE 'Responsable',r.SOLICITANTE 'Solicitante',r.DESTINO 'Destino'  
                                  from t_movimientos m inner join T_TIPO_MOVIMIENTO tm on tm.ID=m.TIPO_MOV
                                  inner join T_REGISTROS r on r.CODIGO_MOV=m.CODIGO
                                  inner join T_ARTICULOS a on a.CODIGO = m.CODIGO_ART
                                  inner join T_USUARIOS res on res.LEGAJO = r.RESPONSABLE
								  INNER JOIN T_GRUPO_ARTICULOS g on g.ID = a.ID_GRUPO_ART
                                  full join T_SOLICITANTES sol on sol.LEGAJO = r.SOLICITANTE
                                  where (m.TIPO_MOV=2) AND (SUBSTRING(m.CODIGO, 1, 1)<>'A') AND NOT('A'+SUBSTRING(m.CODIGO, 2, 50) in (select CODIGO from T_MOVIMIENTOS where  CODIGO like 'A%')) AND
                                  (r.Fecha between CONVERT( VARCHAR , '" + dia1.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 )) "+
                                  "Order By r.fecha desc, r.hora desc";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ReporteMovimientosPD(string fecha1, string fecha2)
        {
            DateTime dia1 = Convert.ToDateTime(fecha1);
            DateTime dia2 = Convert.ToDateTime(fecha2);
            DataTable dt = new DataTable();
            string strProc = @"  select CONVERT(VARCHAR , r.FECHA , 103) 'Fecha',CONVERT( VARCHAR , r.HORA , 108)  'Hora', m.CODIGO 'N_Movimiento',tm.Movimiento 'Tipo_Mov',r.TARJETA 'Tarjeta',m.CODIGO_ART 'Cod_Articulo',a.DESCRIPCION 'Descripcion', 
                                  m.CANTIDAD 'Cantidad',r.RESPONSABLE 'Responsable',r.SOLICITANTE 'Solicitante' 
                                  from t_movimientos m inner join T_TIPO_MOVIMIENTO tm on tm.ID=m.TIPO_MOV
                                  inner join T_REGISTROS r on r.CODIGO_MOV=m.CODIGO
                                  inner join T_ARTICULOS a on a.CODIGO = m.CODIGO_ART
                                  inner join T_USUARIOS res on res.LEGAJO = r.RESPONSABLE
                                  full join T_SOLICITANTES sol on sol.LEGAJO = r.SOLICITANTE
                                  where (m.TIPO_MOV = 3 or m.TIPO_MOV= 4) AND
                                  (r.Fecha between CONVERT( VARCHAR , '" + dia1.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 ))" +
                                  "Order By r.fecha desc, r.hora desc";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static DataTable ReporteMovimientos(string fecha1, string fecha2)
        {
            DateTime dia1 = Convert.ToDateTime(fecha1);
            DateTime dia2 = Convert.ToDateTime(fecha2);
            DataTable dt = new DataTable();
            string strProc = @"  select CONVERT(VARCHAR , r.FECHA , 103) 'Fecha',CONVERT( VARCHAR , r.HORA , 108)  'Hora', m.CODIGO 'N_Movimiento',tm.Movimiento 'TIPO_MOV',r.DOC_ENTREGA 'Referencia',r.Tarjeta 'TARJETA',m.CODIGO_ART 'Cod_Articulo',a.DESCRIPCION 'Descripcion', 
                                  m.CANTIDAD 'Cantidad',r.RESPONSABLE 'Responsable',r.SOLICITANTE 'Solicitante'  
                                  from t_movimientos m inner join T_TIPO_MOVIMIENTO tm on tm.ID=m.TIPO_MOV
                                  inner join T_REGISTROS r on r.CODIGO_MOV=m.CODIGO
                                  inner join T_ARTICULOS a on a.CODIGO = m.CODIGO_ART
                                  inner join T_USUARIOS res on res.LEGAJO = r.RESPONSABLE
                                  full join T_SOLICITANTES sol on sol.LEGAJO = r.SOLICITANTE
                                  where r.Fecha between CONVERT( VARCHAR , '" + dia1.ToString("dd/MM/yyyy") + "' , 103 ) and  CONVERT( VARCHAR , '" + dia2.ToString("dd/MM/yyyy") + "' , 103 )" +
                                  "Order By r.fecha desc, r.hora desc";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }
        public static Boolean ValidarMovimiento(string Mov)
        {
            DataTable dt = new DataTable();
            Boolean b = false;
            string strProc = "Select * FROM T_MOVIMIENTOS WHERE CODIGO = '" + Mov.Trim() + "'";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }
        public static Boolean ValidarAnulado(string Mov)
        {
            DataTable dt = new DataTable();
            Boolean b = false;
            string strProc = "Select * FROM T_ANULADOS WHERE COD_MOV = '" + Mov.Trim() + "'";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                b = true;
            }
            return b;
        }
        public static void AltaAnulado(string Movimiento)

        {
            string stProc = @"INSERT INTO T_ANULADOS VALUES (@MOVIMIENTO)";
            SqlConnection objConexion = new SqlConnection(Conexion.strConexion);
            SqlCommand objComAgregar = new SqlCommand(stProc, objConexion);
            objComAgregar.Parameters.AddWithValue("@MOVIMIENTO", Movimiento.Trim());
            objComAgregar.CommandType = CommandType.Text;
            objConexion.Open();
            objComAgregar.ExecuteNonQuery();

        }
        public static DataTable ArticulosEnRetiro()
        {
            DataTable dt = new DataTable();
            string strProc = @" select t.CODIGO_MOV 'N_Movimiento',m.CODIGO_ART 'Articulo',a.DESCRIPCION 'Descripcion', s.NOMBRE + ' '+s.APELLIDO 'Solicitante' 
                                  From T_REGISTROS t inner join T_MOVIMIENTOS m on t.CODIGO_MOV=m.CODIGO
                                  inner join T_SOLICITANTES s on t.SOLICITANTE=s.LEGAJO
                                  inner join T_ARTICULOS a on m.CODIGO_ART = a.CODIGO
                                  inner join T_TARJETAS tt on tt.CODIGO_MOV=m.CODIGO";
            SqlDataAdapter objDaTraer = new SqlDataAdapter(strProc, Conexion.strConexion);
            objDaTraer.SelectCommand.CommandType = CommandType.Text;
            objDaTraer.Fill(dt);
            return dt;
        }

    }

}
