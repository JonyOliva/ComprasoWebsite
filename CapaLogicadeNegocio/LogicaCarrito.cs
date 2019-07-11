using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaAccesoaDatos;
using Entidad;

namespace CapaLogicadeNegocio
{
    public static class LogicaCarrito
    {
        public static void añadirCarrito(DataTable tbl, Producto prod)
        {
            gestionProductos gp = new gestionProductos();
            DataRow row = tbl.NewRow();
            row["Producto"] = prod.Nombre;
            row["Marca"] = gp.getMarca(prod.Marca);
            row["RutaImagen"] = prod.RutaImagen.Trim();
            row["IDProducto"] = prod.IDProducto;
            row["Cantidad"] = 1;
            row["Stock"] = prod.Stock;
            row["Precio"] =Utilidades.getPrecioConDescuento(prod.Precio,prod.Descuento);
            if (tbl.Rows.Contains(prod.IDProducto))
            {
                foreach (DataRow item in tbl.Rows)
                {
                    if (item[5].ToString() == prod.IDProducto)
                    {
                        int cant = int.Parse(item[4].ToString());
                        cant += 1;
                        item[4] = cant;
                    }
                }
            }
            else
            {
                tbl.Rows.Add(row);
            }
        }

        public static DataTable crearTablacarrito()
        {
            DataTable tbl = new DataTable();
            DataColumn[] clave = new DataColumn[1];
            DataColumn columna;
            tbl.Columns.Add(new DataColumn("Producto", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Marca", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Precio", System.Type.GetType("System.Decimal")));
            tbl.Columns.Add(new DataColumn("RutaImagen", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Cantidad", System.Type.GetType("System.Int32")));
            columna = new DataColumn("IDProducto", System.Type.GetType("System.String"));
            tbl.Columns.Add(columna);
            tbl.Columns.Add(new DataColumn("Stock", System.Type.GetType("System.Int32")));
            clave[0] = columna;
            tbl.PrimaryKey = clave;
            return tbl;
        }

        public static DataTable getEnvios()
        {
            DataTable tbl = new DataTable();
            CADVentas cv = new CADVentas();
            tbl = cv.getEnvios();
            return tbl;
        }

        public static float getPrecioenvio(string idenvio)
        {
            float precio;
            CADVentas cv = new CADVentas();
            precio = float.Parse(cv.getEnvio(idenvio).Rows[0]["Costo_ENVIO"].ToString());
            return precio;
        }
    }
}
