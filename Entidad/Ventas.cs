using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Ventas
    {
        private string nroTarjeta;
        private string IDUsuario;
        private int codDireccion;
        private float descuento;
        private float total;
        private string idEnvio;
        private int estadoEnvio;

        public string NroTarjeta { get => nroTarjeta; set => nroTarjeta = value; }
        public string IDUsuario1 { get => IDUsuario; set => IDUsuario = value; }
        public int CodDireccion { get => codDireccion; set => codDireccion = value; }
        public float Descuento { get => descuento; set => descuento = value; }
        public float Total { get => total; set => total = value; }
        public string IdEnvio { get => idEnvio; set => idEnvio = value; }
        public int EstadoEnvio { get => estadoEnvio; set => estadoEnvio = value; }


    }
}
