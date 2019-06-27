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
        

        public Producto getProducto(string IDProducto)
        {
            DataTable data = bd.getTable("SELECT * FROM PRODUCTOS WHERE IDProducto='" + IDProducto + "'", "producto");
            return (Producto)data.Rows[0];
        }

        private void ArmarParametrosProductos(ref SqlCommand Comando, Producto prod)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IdProd", SqlDbType.Char,4);
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

        public void insertarProducto(Producto prod)
        {
            SqlCommand cm = new SqlCommand();
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
            bd.ExecStoredProcedure(cm, "spAgregarProducto");

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

    }

    
}
