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
    public class gestionUsuarios
    {

        string databasePath = Utilidades.GetStringConectionLocal();
        BaseDeDatos bd;
        public gestionUsuarios()
        {
            bd = new BaseDeDatos(databasePath);
        }

        public DataTable getListaDirecxUsuario(string IdUsuario)
        {
            BaseDeDatos bd = new BaseDeDatos(Utilidades.GetStringConectionLocal());
            return bd.getTable("SELECT * FROM DIRECXUSUARIO WHERE IdUsuario_DIR = "+ IdUsuario, "Direcciones");
        }

        public DataTable getListaTarjetasxUsuario(string IdUsuario)
        {
            BaseDeDatos bd = new BaseDeDatos(Utilidades.GetStringConectionLocal());
            return bd.getTable("SELECT * FROM TarjetasxUsuario where IDUsuario_TxU =" + IdUsuario, "TarjetasUsuario");
        }

        public DataTable getListaComprasxUsuario(string IdUsuario)
        {
            BaseDeDatos bd = new BaseDeDatos(Utilidades.GetStringConectionLocal());
            return bd.getTable("select RutaImagen,IDProducto_DETV,Cantidad_DETV, PrecioUnitario_DETV, Descuento_DETV,IDVenta ,Total_VENTA  from VENTAS" +
                " inner join DETVENTAS on IDVenta = IDVenta_DETV inner join PRODUCTOS on IDProducto_DETV = IDProducto where IDUsuario_VENTA = " + IdUsuario,
                "ComprasUsuario");
        }
    }
}
