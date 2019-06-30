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
            return bd.getTable("SELECT DISTINCT DATEPART(MONTH, Fecha_VENTA) AS MES, DATEPART(YEAR, Fecha_VENTA) AS ANIO FROM VENTAS", "fechas");
        }

        public DataTable getProductosVendidos(int mes, int anio)
        {
            return bd.getTable("SELECT Nombre_PROD, SUM(Cantidad_DETV) AS CantidadVendida FROM PRODUCTOS " +
                                "INNER JOIN DETVENTAS ON(IDProducto = IDProducto_DETV) " +
                                "INNER JOIN VENTAS ON(IDVenta_DETV = IDVenta) " +
                                "WHERE(MONTH(Fecha_VENTA) = '" + mes + "' AND YEAR(Fecha_VENTA) = '" + anio + "') GROUP BY Nombre_PROD", "productosVendidos");
        }

        public DataRow getTotalVentas(int mes, int anio)
        {
            DataTable table = bd.getTable("SELECT SUM(PrecioUnitario_DETV*Cantidad_DETV) AS TOTAL FROM DETVENTAS " +
                                          "INNER JOIN VENTAS ON(IDVenta_DETV = IDVenta) " +
                                          "WHERE(MONTH(Fecha_VENTA) ='" + mes + "' AND YEAR(Fecha_VENTA) = '" + anio + "')", "Total");
            return table.Rows[0];
        }

    }
}
