using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Producto
    {
        private string idProducto;
        private string nombre;
        private string categoria;
        private string subCategoria;
        private string marca;
        private string descripcion;
        private float precio;
        private int stock;
        private float descuento;
        private string rutaimagen;
        private bool activo;

        public string IDProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Categoria
        {
            get { return categoria; }
            set { categoria = value; }
        }

        public string SubCategoria
        {
            get { return subCategoria; }
            set { subCategoria = value; }
        }

        public string Marca
        {
            get { return marca; }
            set { marca = value; }
        }

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        public float Precio
        {
            get { return precio; }
            set {
                if(value > 0)
                    precio = value;
            }
        }

        public int Stock
        {
            get { return stock; }
            set {
                if (value > 0)
                    stock = value;
            }
        }

        public float Descuento
        {
            get { return descuento; }
            set { descuento = value; }
        }

        public string RutaImagen
        {
            get { return rutaimagen; }
            set { rutaimagen = value; }
        }

        public bool Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public static explicit operator Producto(DataRow v)
        {
            Producto producto = new Producto();
            producto.IDProducto = v["IDProducto"].ToString();
            producto.Nombre = v["Nombre_PROD"].ToString();
            producto.Categoria = v["IDCategoria_PROD"].ToString();
            producto.SubCategoria = v["IDSubCategoria_PROD"].ToString();
            producto.Marca = v["IDMarca_PROD"].ToString();
            producto.Descripcion = v["Descripcion_PROD"].ToString();
            producto.Stock = Convert.ToInt32(v["Stock_PROD"]);
            producto.Precio = Convert.ToSingle(v["Precio_PROD"]);
            producto.Descuento = Convert.ToSingle(v["Descuento_PROD"]);
            producto.RutaImagen = v["RutaImagen"].ToString();
            producto.Activo = Convert.ToBoolean(v["ACTIVO"]);

            return producto;
        }
    }
}
