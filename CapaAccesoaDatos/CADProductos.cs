using System.Data;
using System.Data.SqlClient;
using Entidad;
using System;

namespace CapaAccesoaDatos
{
    public class CADProductos
    {
        string databasePath = Entidad.Utilidades.GetStringConectionLocal();
        BaseDeDatos bd;
        public CADProductos()
        {
            bd = new BaseDeDatos(databasePath);
        }

        public DataTable getDataTable()
        {
            return bd.getTable("SELECT * FROM PRODUCTOS", "productos");
        }

        public DataTable getDataTable2()
        {
            return bd.getTable("SELECT * FROM PRODUCTOS inner join MARCAS on IDMarca_PROD = IDMarca INNER JOIN CATEGORIAS ON IDCategoria_PROD = IDCategoria INNER JOIN SUBCATEGORIAS ON IDSubCategoria_PROD = IDSubCategoria",
                "productos");
        }

        public DataTable getDataTable(string nombre = "", string idCategoria = "", string idSubCat = "", string idMarca = "", string ordenarPor = "Precio_PROD ASC")
        {
            string selectCommand = "SELECT * FROM PRODUCTOS WHERE (ACTIVO = 1)";
            if (!string.IsNullOrEmpty(nombre))
            {
                selectCommand += " AND Nombre_PROD LIKE '%" + nombre + "%'";
            }
            if (!string.IsNullOrEmpty(idCategoria))
            {
                selectCommand += " AND IDCategoria_PROD='" + idCategoria + "'";
            }
            if (!string.IsNullOrEmpty(idSubCat))
            {
                selectCommand += " AND IDSubCategoria_PROD='" + idSubCat + "'";
            }
            if (!string.IsNullOrEmpty(idMarca))
            {
                selectCommand += " AND IDMarca_PROD='" + idMarca + "'";
            }
            if (!string.IsNullOrEmpty(ordenarPor))
            {
                selectCommand += " ORDER BY "+ordenarPor;
            }
            return bd.getTable(selectCommand, "productosFiltrados");
        }

        public DataTable getProductosVendidos()
        {
            return bd.getTable("SELECT Nombre_PROD, SUM(Cantidad_DETV) AS CantidadVendida FROM PRODUCTOS " +
                "INNER JOIN DETVENTAS ON(IDProducto = IDProducto_DETV) GROUP BY Nombre_PROD", "productosVendidos");
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

        public DataTable getListaMarcas()
        {
            return bd.getTable("SELECT * FROM MARCAS", "marcas");
        }

        public DataTable getListaCategorias()
        {
            return bd.getTable("SELECT * FROM CATEGORIAS", "categorias");
        }

        public DataTable getListaSubCategorias(string Cat)
        {
            return bd.getTable("SELECT * FROM SUBCATEGORIAS WHERE IDCategoria_SUBCAT='" + Cat + "'", "categorias");
        }

        public DataTable getProducto(string IDProducto)
        {
            return bd.getTable("SELECT * FROM PRODUCTOS WHERE IDProducto='" + IDProducto + "'", "producto");
        }

        public DataSet busquedaProductos(string srtSearch)
        {
            DataSet busqueda = new DataSet();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Parameters.AddWithValue("@aBuscar", srtSearch);
            DataTable fromProds = new DataTable("productos");
            bd.ExecStoredProcedure(sqlCommand, "Buscador", ref fromProds);
            DataTable fromCats, fromSubCats;
            fromCats = bd.getTable("SELECT IDCategoria FROM CATEGORIAS WHERE Nombre_CAT LIKE '%" + srtSearch + "%'", "categorias");
            string selectSubCats = "SELECT IDSubCategoria FROM SUBCATEGORIAS WHERE (Nombre_SUBCAT LIKE '%" + srtSearch + "%')";
            if (fromCats.Rows.Count > 0)
            {
                selectSubCats += " AND (";
                for (int i = 0; i < fromCats.Rows.Count; i++)
                {
                    selectSubCats += "IDCategoria_SUBCAT='" + fromCats.Rows[i][0] + "'";
                    if (!(i <= fromCats.Rows.Count - 1))
                    {
                        selectSubCats += " OR ";
                    }
                }
                selectSubCats += ")";
            }
            fromSubCats = bd.getTable(selectSubCats, "subcategorias");
            busqueda.Tables.Add(fromProds);
            busqueda.Tables.Add(fromCats);
            busqueda.Tables.Add(fromSubCats);
            return busqueda;
        }

        private void ArmarParametrosProductos(ref SqlCommand cm, Producto prod)
        {
            
            
            cm.Parameters.AddWithValue("@IDProducto", prod.IDProducto);
            cm.Parameters.AddWithValue("@Nombre_PROD", prod.Nombre);
            cm.Parameters.AddWithValue("@Descripcion_PROD", prod.Descripcion);
            cm.Parameters.AddWithValue("@IdCategoria_PROD", prod.Categoria);
            cm.Parameters.AddWithValue("@IdSubCategoria_PROD", prod.SubCategoria);
            cm.Parameters.AddWithValue("@IDMarca_PROD", prod.Marca);
            cm.Parameters.AddWithValue("@Stock_PROD", prod.Stock);
            cm.Parameters.AddWithValue("@Precio_PROD", prod.Precio);
            cm.Parameters.AddWithValue("@Descuento_PROD", prod.Descuento);
            cm.Parameters.AddWithValue("@ACTIVO", prod.Activo);

        }

        public int insertarProducto(Producto prod)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosProductos(ref Comando, prod);
            return bd.ExecStoredProcedure(Comando, "spAgregarProducto");
        }

        public bool actualizarProducto(Producto prod)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosProductos(ref Comando, prod);
            int afectadas = bd.ExecStoredProcedure(Comando, "ActualizarProd");
            return Convert.ToBoolean(afectadas);
        }

        public DataTable getMarca(string IDMarca)
        {
            return bd.getTable("SELECT Nombre_MARCA FROM MARCAS WHERE IDMarca = '"+IDMarca+"'"
                ,"Marca");
        }

    }
}
