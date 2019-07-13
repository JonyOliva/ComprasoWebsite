using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaAccesoaDatos;
using Entidad;
using System.Web.UI.DataVisualization.Charting;

namespace CapaLogicadeNegocio
{
    public class gestionProductos
    {
        CADProductos cp;
        public gestionProductos()
        {
            cp = new CADProductos();
        }
        public DataTable getListaProductos()
        {
            return cp.getDataTable();
        }

        public DataTable getListaProductos2()
        {
            return cp.getDataTable2();
        }

        public DataTable getProductos(string nombre = "", string idCategoria = "", string idSubCat = "", string idMarca = "", string ordenarPor = "Precio_PROD ASC")
        {
            return cp.getDataTable(nombre, idCategoria, idSubCat, idMarca, ordenarPor);
        }

        public DataTable getListaMarcas(string Cat, string SubCat)
        {
            return cp.getListaMarcas(Cat, SubCat);
        }

        public DataTable getListaMarcas()
        {
            return cp.getListaMarcas();
        }

        public DataTable getListaCategorias()
        {
            return cp.getListaCategorias();
        }
        public DataTable getListaSubCategorias(string Cat)
        {
            return cp.getListaSubCategorias(Cat);
        }

        public Producto getProducto(string IDProducto)
        {
            DataTable data = cp.getProducto(IDProducto);
            return (Producto)data.Rows[0];
        }

        public int insertarProducto(Producto prod)
        {
            return cp.insertarProducto(prod);
        }

        public bool actualizarProducto(Producto prod)
        {
            return cp.actualizarProducto(prod);
        }

        public string[] Buscar(string[] search)
        {
            List<string> strs = new List<string>();
            foreach (string str in search)
            {
                if (str.Length > 1)
                {
                    strs.Add(str);
                }
            }
            string[] words = strs.ToArray();
            CADProductos gp = new CADProductos();
            DataSet[] datasets = new DataSet[words.Length];
            for (int i = 0; i < datasets.Length; i++)
            {
                datasets[i] = gp.busquedaProductos(words[i]);
            }
            List<string> cats = new List<string>();
            List<string> subcats = new List<string>();
            for (int x = 0; x < datasets.Length; x++)
            {
                foreach (DataRow item in datasets[x].Tables["productos"].Rows)
                {
                    cats.Add(item[0].ToString());
                    subcats.Add(item[1].ToString());
                }
                foreach (DataRow item in datasets[x].Tables["categorias"].Rows)
                {
                    cats.Add(item[0].ToString());
                }
                foreach (DataRow item in datasets[x].Tables["subcategorias"].Rows)
                {
                    subcats.Add(item[0].ToString());
                }
            }

            List<string> filtro = new List<string>();
            if (cats.Count > 1)
            {
                filtro.Add(Utilidades.getMasRepetido(cats.ToArray()));
            }
            else if (cats.Count == 1)
            {
                filtro.Add(cats[0]);
            }

            if (subcats.Count > 1)
            {
                filtro.Add(Utilidades.getMasRepetido(subcats.ToArray()));
            }
            else if (subcats.Count == 1)
            {
                filtro.Add(subcats[0]);
            }

            if (filtro.Count != 0)
            {
                return filtro.ToArray();
            }
            else
            {
                return null;
            }
        }

        public void statsCantidadProdVendidos(Series serie)
        {
            DataTable data = cp.getProductosVendidos();
            for (int i = 0; i < data.Rows.Count; i++)
            {
                serie.Points.AddXY(data.Rows[i][0], data.Rows[i][1]);
            }
        }

        public string getMarca(string idmarca)
        {
            CADProductos cp = new CADProductos();
            DataTable tbl = cp.getMarca(idmarca);
            return tbl.Rows[0]["Nombre_MARCA"].ToString();
        }
    }
}
