using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidad;
using CapaAccesoaDatos;

namespace CapaLogicadeNegocio
{
    public class CADVentas  
    {
        string databasePath = Utilidades.GetStringConectionLocal();
        BaseDeDatos bd;
        public CADVentas()
        {
            bd = new BaseDeDatos(databasePath);
        }

        public bool insertarVenta(Ventas venta)
        {
            SqlCommand cm = new SqlCommand();
            cm.Parameters.AddWithValue("@NroTarjeta", venta.NroTarjeta);
            cm.Parameters.AddWithValue("IDUsuario", venta.IDUsuario1);
            cm.Parameters.AddWithValue("@CodDireccion", venta.CodDireccion);
            cm.Parameters.AddWithValue("@Descuento", venta.Descuento);
            cm.Parameters.AddWithValue("@Total", venta.Total);
            cm.Parameters.AddWithValue("@IDEnvio", venta.IdEnvio);
            cm.Parameters.AddWithValue("@Estado", venta.EstadoEnvio);

            if (bd.ExecStoredProcedure(cm, "spAgregarVenta") != 0)
            {
                return true;
            }
            else return false;
                

        }
        public DataTable getListaVentas()
        {
            return bd.getTable("SELECT * FROM VENTAS", "ventas");
        }


        public bool insertarDetalleventas(DetalleVentas detVenta)
        {
            SqlCommand cm = new SqlCommand();
            cm.Parameters.AddWithValue("@IDProducto", detVenta.IDProducto1);
            cm.Parameters.AddWithValue("@IDVenta", detVenta.IDVenta1);
            cm.Parameters.AddWithValue("@Cantidad", detVenta.Cantidad);
            cm.Parameters.AddWithValue("@Descuento",detVenta.Descuento);
            cm.Parameters.AddWithValue("@PrecioUni", detVenta.PrecioUnitario);
            if (bd.ExecStoredProcedure(cm, "spAgregarDetVenta") != 0)
            {
                return true;
            }
            else return false;
           
        }

        public int recuperarIdventa()
        {
            DataTable tbl = new DataTable();
            tbl = bd.getTable("SELECT * FROM VENTAS","Ventas");
            return tbl.Rows.Count;
        }

        public DataTable getFechasVentas()
        {
            return bd.getTable("SELECT DISTINCT DATEPART(MONTH, Fecha_VENTA) AS MES, DATEPART(YEAR, Fecha_VENTA) AS ANIO FROM VENTAS WHERE (Estado != 1)", "fechas");
        }

        public DataTable getProductosVendidos(int mes, int anio)
        {
            return bd.getTable("SELECT Nombre_PROD, SUM(Cantidad_DETV) AS CantidadVendida FROM PRODUCTOS " +
                                "INNER JOIN DETVENTAS ON(IDProducto = IDProducto_DETV) " +
                                "INNER JOIN VENTAS ON(IDVenta_DETV = IDVenta) " +
                                "WHERE(MONTH(Fecha_VENTA) = '" + mes + "' AND YEAR(Fecha_VENTA) = '" + anio + "') AND (Estado != 1) GROUP BY Nombre_PROD", "productosVendidos");
        }

        public DataRow getTotalVentas(int mes, int anio)
        {
            DataTable table = bd.getTable($"SELECT SUM(Total_VENTA) AS TOTAL FROM VENTAS WHERE(MONTH(Fecha_VENTA) = '{mes}' AND YEAR(Fecha_VENTA) = '{anio}') AND (Estado != 1)", "Total");
            return table.Rows[0];
        }

        public DataTable getEnviosProvs(int mes, int anio)
        {
            return bd.getTable($"SELECT Provincia_ENVIO, COUNT(IDEnvio_VENTA) FROM VENTAS INNER JOIN ENVIOS ON(IDEnvio_VENTA = IDEnvio) WHERE(MONTH(Fecha_Venta) = '{mes}' AND YEAR(Fecha_Venta) = '{anio}') AND (Estado != 1) GROUP BY Provincia_ENVIO", "enviosxmes");
        }

        public DataTable getCantVentasPorCategorias(int mes, int anio)
        {
            return bd.getTable("SELECT Nombre_CAT, SUM(Cantidad_DETV) AS UnidadesVendidas, IDCategoria FROM DETVENTAS " +
                               "INNER JOIN PRODUCTOS ON(IDProducto_DETV = IDProducto) "+
                               "INNER JOIN VENTAS ON(IDVenta_DETV = IDVenta) " +
                               "INNER JOIN CATEGORIAS ON(IDCategoria_PROD = IDCategoria) " +
                               "WHERE(MONTH(Fecha_Venta) = '" + mes + "' AND YEAR(Fecha_Venta) = '" + anio + "') AND (Estado != 1) GROUP BY Nombre_CAT, IDCategoria", "CantProdsxCats");
        }

        public DataTable getCantVentasPorSubcategoria(int mes, int anio, string categoria)
        {
            return bd.getTable("SELECT Nombre_SUBCAT, SUM(Cantidad_DETV) AS UnidadesVendidas FROM DETVENTAS " +
                               "INNER JOIN PRODUCTOS ON(IDProducto_DETV = IDProducto) " +
                               "INNER JOIN VENTAS ON(IDVenta_DETV = IDVenta) " +
                               "INNER JOIN SUBCATEGORIAS ON(IDSubCategoria_PROD = IDSubCategoria) " +
                               "WHERE(MONTH(Fecha_Venta) = '" + mes + "' AND YEAR(Fecha_Venta) = '" + anio + "') AND (IDCategoria_PROD = '" + categoria + "') AND (Estado != 1) GROUP BY Nombre_SUBCAT", "pffqueweapesada");
        }

        public DataTable getEnvios()
        {
            return bd.getTable("SELECT * FROM ENVIOS", "ENVIOS");
        }

        public DataTable getEnvio(string idenvio)
        {
            return bd.getTable("SELECT * FROM ENVIOS WHERE IDEnvio = '"+idenvio+"'", "ENVIOS");
        }

        public DataTable getVentasPorEstado(int estado)
        {
            return bd.getTable("SELECT * FROM VENTAS WHERE Estado = '" + estado + "' ORDER BY Fecha_VENTA DESC", "VENTAS");
        }


    }
}
