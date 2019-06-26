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
        public static void cargarCompras(DataTable tblcompras, DataTable tblcarrito)
        {
            for (int i = 0; i < tblcarrito.Rows.Count; i++)
            {
                DataRow row = tblcompras.NewRow();
                string prueba = tblcarrito.Rows[i][4].ToString();
                row["Cantidad"] = int.Parse(prueba);
                row["Producto"] = tblcarrito.Rows[i][0].ToString();
                row["RutaImagen"] = tblcarrito.Rows[i][3].ToString();
                row["IDProducto"] = tblcarrito.Rows[i][5].ToString();
                row["Precio"] = decimal.Parse(tblcarrito.Rows[i][2].ToString());
                row["Subtotal"] =
                    int.Parse(prueba) * decimal.Parse(tblcarrito.Rows[i][2].ToString());
                
                tblcompras.Rows.Add(row);
            }

        }
        public static DataTable crearCompra()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("Producto", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Cantidad", System.Type.GetType("System.Int32")));
            tbl.Columns.Add(new DataColumn("Precio", System.Type.GetType("System.Decimal")));
            tbl.Columns.Add(new DataColumn("IDProducto", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("RutaImagen", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Subtotal", System.Type.GetType("System.Decimal")));
            return tbl;
        }

        public static void añadirCarrito(DataTable tbl, Producto prod)
        {
            DataRow row = tbl.NewRow();
            row["Producto"] = prod.Nombre;
            row["Marca"] = prod.Marca;
            row["Precio"] = prod.Precio;
            row["RutaImagen"] = prod.RutaImagen.Trim();
            row["IDProducto"] = prod.IDProducto;
            row["Cantidad"] = 1;

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

    }
}
