﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Producto
    {
        private string idProducto;
        private string categoria;
        private string subCategoria;
        private string marca;
        private string descripcion;
        private float precio;
        private int stock;
        private bool descuentp;

        public string IDProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
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

        public bool Descuento
        {
            get { return descuentp; }
            set { descuentp = value; }
        }
    }
}