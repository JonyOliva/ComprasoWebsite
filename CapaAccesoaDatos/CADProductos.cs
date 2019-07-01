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

        private void ArmarParametrosProductos(ref SqlCommand Comando, Producto prod)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdProd", SqlDbType.Char, 4);
            SqlParametros.Value = prod.IDProducto;
            SqlParametros = Comando.Parameters.Add("@NombreProd", SqlDbType.Char, 30);
            SqlParametros.Value = prod.Nombre;
            SqlParametros = Comando.Parameters.Add("@Descripcion", SqlDbType.Char, 1000);
            SqlParametros.Value = prod.Descripcion;
            SqlParametros = Comando.Parameters.Add("@Stock", SqlDbType.Int);
            SqlParametros.Value = prod.Stock;
            SqlParametros = Comando.Parameters.Add("@Precio", SqlDbType.Money);
            SqlParametros.Value = prod.Precio;
            SqlParametros = Comando.Parameters.Add("@Descuento", SqlDbType.Float);
            SqlParametros.Value = prod.Descuento;
            SqlParametros = Comando.Parameters.Add("@ACTIVO", SqlDbType.Bit);
            SqlParametros.Value = prod.Activo;
        }

        public int insertarProducto(Producto prod)
        {
            SqlCommand cm = new SqlCommand();
            ArmarParametrosProductos(ref cm, prod);
            return bd.ExecStoredProcedure(cm, "spAgregarProducto");
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
