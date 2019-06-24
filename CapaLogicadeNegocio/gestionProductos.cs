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

        private void ArmarParametrosProductos(ref SqlCommand Comando, Producto prod)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDProducto", SqlDbType.Char,4);
            SqlParametros.Value = prod.IDProducto;
            SqlParametros = Comando.Parameters.Add("@Nombre_PROD", SqlDbType.Char, 30);
            SqlParametros.Value = prod.Nombre;
            SqlParametros = Comando.Parameters.Add("@Descripcion_PROD", SqlDbType.Char, 1000);
            SqlParametros.Value = prod.Descripcion;
            SqlParametros = Comando.Parameters.Add("@Stock_PROD", SqlDbType.Int);
            SqlParametros.Value = prod.Stock;
            SqlParametros = Comando.Parameters.Add("@Precio_PROD", SqlDbType.Money);
            SqlParametros.Value = prod.Precio;
            SqlParametros = Comando.Parameters.Add("@Descuento_PROD", SqlDbType.Float);
            SqlParametros.Value = prod.Descuento;
            SqlParametros = Comando.Parameters.Add("@ACTIVO", SqlDbType.Bit);
            SqlParametros.Value = prod.Activo;

            
        }


        public bool ActualizarProducto(Producto prod)
        {
            SqlCommand Comando = new SqlCommand();
            ArmarParametrosProductos(ref Comando, prod);
            BaseDeDatos bd = bd = new BaseDeDatos(databasePath);
            int FilasInsertadas = bd.ExecStoredProcedure(Comando, "ActualizarProd");
            if (FilasInsertadas == 1)
                return true;
            else
                return false;
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

    }

    
}
