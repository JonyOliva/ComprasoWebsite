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
            return bd.getTable("SELECT * FROM PRODUCTOS", "productos");
        }
        public DataTable getListaMarcas(string Cat, string SubCat)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("@IDSubCat", SubCat);
            sqlCommand.Parameters.AddWithValue("@IDCat", Cat);
            DataTable marcas = new DataTable("marcas");
            bd.ExecStoredProcedure(sqlCommand, "spObtenerMarcas", ref marcas);
            return marcas;
        }
        public DataTable getListaCategorias()
        {
            return bd.getTable("SELECT * FROM CATEGORIAS", "categorias");
        }
        public DataTable getListaSubCategorias(string Cat)
        {
            return bd.getTable("SELECT * FROM SUBCATEGORIAS WHERE IDCategoria_SUBCAT='" + Cat + "'", "categorias");
        }
        public Producto getProducto(string IDProducto)
        {
            DataTable data = bd.getTable("SELECT * FROM PRODUCTOS WHERE IDProducto='" + IDProducto + "'", "producto");
            return (Producto)data.Rows[0];
        }

        public DataTable busquedaProductos(string busqueda)
        {
            DataTable tbl = bd.getTable("SELECT Nombre_PROD,Descripcion_PROD,Precio_PROD,Nombre_MARCA,RutaImagen " +
                "FROM PRODUCTOS INNER JOIN MARCAS on IDMarca_prod = IDMarca " +
                "WHERE Nombre_PROD LIKE '%" + busqueda + "%' " +
                "OR Descripcion_PROD LIKE '%" + busqueda + "%' " +
                "OR Nombre_MARCA LIKE'%" + busqueda + "%'", "Productos");
            return tbl;
        }

    }
}
