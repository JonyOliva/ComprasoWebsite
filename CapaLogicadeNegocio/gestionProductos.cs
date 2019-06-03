using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaAccesoaDatos;
using Entidad;

namespace CapaLogicadeNegocio
{
    public class gestionProductos
    {
        string databasePath = Utilidades.GetStringConectionLocal();
        BaseDeDatos bd;
        public gestionProductos()
        {
            bd = new BaseDeDatos(databasePath);
        }
        public bool eliminarProducto(Producto prod)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IDProducto", prod.IDProducto);
            cmd.Parameters.AddWithValue("@Nombre", prod.Nombre);
            cmd.Parameters.AddWithValue("@Cat", prod.Categoria);
            cmd.Parameters.AddWithValue("@SubCat", prod.SubCategoria);
            cmd.Parameters.AddWithValue("@Marca", prod.Marca);
            cmd.Parameters.AddWithValue("@Descrip", prod.Descripcion);
            cmd.Parameters.AddWithValue("@Stock", prod.Stock);
            cmd.Parameters.AddWithValue("@Descuento", prod.Descuento);

            int resp = bd.ExecStoredProcedure(cmd, "spEliminarProducto");
            return Convert.ToBoolean(resp);
        }
        public DataTable getListaProductos()
        {
            BaseDeDatos bd = new BaseDeDatos(Utilidades.GetStringConectionLocal());
            return bd.getTable("SELECT * FROM PRODUCTOS", "productos");
        }
        public Producto getProducto(string IDProducto)
        {
            BaseDeDatos bd = new BaseDeDatos(databasePath);
            DataTable data = bd.getTable("SELECT * FROM PRODUCTOS WHERE IDProducto='" + IDProducto + "'", "producto");
            return (Producto)data.Rows[0];
        }

        public DataRow getrowProducto(string idprod)//no se si anda
        {
            BaseDeDatos bd = new BaseDeDatos(Utilidades.GetStringConectionLocal());
            return bd.getTable("Select Nombre_PROD, Precio_PROD, RutaImagen from PRODUCTOS " +
               "where IDProducto = '" + idprod + "'", "Producto").Rows[0];
        }

        public void agregarProductoCarrito(DataTable tbl, Producto prod)
        {

        }
    }
}
