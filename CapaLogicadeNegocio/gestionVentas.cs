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
    public class gestionVentas
    {
        string databasePath = Utilidades.GetStringConectionLocal();
        BaseDeDatos bd;
        public gestionVentas()
        {
            bd = new BaseDeDatos(databasePath);
        }

        public void insertarVenta(Ventas venta)
        {
            SqlCommand cm = new SqlCommand();
            cm.Parameters.AddWithValue("@NroTarjeta", venta.NroTarjeta);
            cm.Parameters.AddWithValue("IDUsuario", venta.IDUsuario1);
            cm.Parameters.AddWithValue("@CodDireccion", venta.CodDireccion);
            cm.Parameters.AddWithValue("@Descuento", venta.Descuento);
            cm.Parameters.AddWithValue("@Total", venta.Total);
            cm.Parameters.AddWithValue("@IDEnvio", venta.IdEnvio);
            cm.Parameters.AddWithValue("@Estado", venta.EstadoEnvio);
            bd.ExecStoredProcedure(cm, "spAgregarVenta");

        }

        public void insertarDetalleventas(DetalleVentas detVenta)
        {
            SqlCommand cm = new SqlCommand();
            cm.Parameters.AddWithValue("@IDProducto", detVenta.IDProducto1);
            cm.Parameters.AddWithValue("@IDVenta", detVenta.IDVenta1);
            cm.Parameters.AddWithValue("@Cantidad", detVenta.Cantidad);
            cm.Parameters.AddWithValue("@Descuento",detVenta.Descuento);
            cm.Parameters.AddWithValue("@PrecioUni", detVenta.PrecioUnitario);
            bd.ExecStoredProcedure(cm, "spAgregarDetVenta");
        }

        public int recuperarIdventa()
        {
            DataTable tbl = new DataTable();
            tbl = bd.getTable("SELECT * FROM VENTAS","Ventas");
            return tbl.Rows.Count;
        }
    }
}
