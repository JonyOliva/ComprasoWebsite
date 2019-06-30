using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidad;
using CapaAccesoaDatos;
using System.Web.UI.DataVisualization.Charting;

namespace CapaLogicadeNegocio
{
    public class gestionVentas
    {
        string databasePath = Utilidades.GetStringConectionLocal();
        BaseDeDatos bd;
        CADVentas cv;
        public gestionVentas()
        {
            bd = new BaseDeDatos(databasePath);
            cv = new CADVentas();
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

        public DateTime[] getFechasVentas()
        {
            DataTable data = cv.getFechasVentas();
            DateTime[] dates = new DateTime[data.Rows.Count];
            for (int i = 0; i < data.Rows.Count; i++)
            {
                dates[i] = new DateTime(Convert.ToInt32(data.Rows[i][1]), Convert.ToInt32(data.Rows[i][0]), 1);
            }
            return dates;
        }

        public void statsCantidadProdVendidos(Series serie, string fecha)
        {
            DateTime date = DateTime.Parse(fecha);
            DataTable data = cv.getProductosVendidos(date.Month, date.Year);
            for (int i = 0; i < data.Rows.Count; i++)
            {
                serie.Points.AddXY(data.Rows[i][0], data.Rows[i][1]);
            }
        }

        public float statsTotalEnVentas(string fecha)
        {
            DateTime date = DateTime.Parse(fecha);
            DataRow dr = cv.getTotalVentas(date.Month, date.Year);
            return Convert.ToSingle(dr[0]);
        }

        public float statsTotalEnVentas(int anio)
        {
            float totalAnio = 0;
            for (int i = 1; i <= 12; i++)
            {
                object obj = cv.getTotalVentas(i, anio)[0];
                if (obj != DBNull.Value)
                {
                    totalAnio += Convert.ToSingle(obj);
                }
            }
            return totalAnio;
        }

        public void statsIngresos(Series serie, string anio)
        {
            int year = Convert.ToInt32(anio);
            for (int i = 1; i <= 12; i++)
            {
                serie.Points.AddXY(Utilidades.obtenerNombreMesNumero(i), cv.getTotalVentas(i, year)[0]);
            }
        }
        
    }
}
