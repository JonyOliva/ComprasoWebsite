using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaAccesoaDatos;
using System.Data;
using Entidad;

namespace CapaLogicadeNegocio
{
    public class gestionMetodoPago
    {
        public DataTable getMetodosdepago(string id)
        {
            BaseDeDatos bd = new BaseDeDatos(Utilidades.GetStringConectionLocal());
            DataTable tbl = new DataTable();
            tbl = bd.getTable("select IDCuota_CUO,RTRIM(CONVERT(char,Cantidad_CUO))+'  Cuotas, Interes ' +" +
                " CONVERT(char,Interes_CUO) as 'Metodo' from TARJETAS inner join CuotasxTarjetas on" +
                " IDTarjeta_TARJ = IDTarjeta_CxT inner join" +
                " CUOTAS ON IDCuota_CUO = IDCuota_CxT WHERE IDTarjeta_TARJ = '"+id+"'", "MetodosDePago");
            return tbl;
        }

        public DataRow getInteres(string id)
        {
            BaseDeDatos bd = new BaseDeDatos(Utilidades.GetStringConectionLocal());
            DataTable tbl = new DataTable();
            tbl = bd.getTable("SELECT INTERES_CUO FROM CUOTAS WHERE IDCuota_CUO = '" + id + "'", "Interes");
            return tbl.Rows[0];
        }

        public DataTable getTarjetas()
        {
            BaseDeDatos bd = new BaseDeDatos(Utilidades.GetStringConectionLocal());
            DataTable tbl = new DataTable();
            tbl = bd.getTable("select * from TARJETAS", "MetodosDePago");
            return tbl;
        }

        public DataTable getTipotarjeta(string idus)
        {
            DataTable tbl = new DataTable();
            BaseDeDatos bd = new BaseDeDatos(Utilidades.GetStringConectionLocal());
            tbl = bd.getTable("SELECT * FROM TarjetasxUsuario WHERE IDUsuario_TxU = '" + idus + "'", "Tarjeta");
            return tbl;
        }
        
    }
}
