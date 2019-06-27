using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
