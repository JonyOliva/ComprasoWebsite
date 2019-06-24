using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class DetalleVentas
    {
        private string IDVenta;
        private string IDProducto;
        private float descuento;
        private int cantidad;
        private float precioUnitario;

        public string IDVenta1 { get => IDVenta; set => IDVenta = value; }
        public string IDProducto1 { get => IDProducto; set => IDProducto = value; }
        public float Descuento { get => descuento; set => descuento = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public float PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
    }
}
