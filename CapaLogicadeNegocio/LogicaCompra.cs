using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Data;
using System.Data.SqlClient;
using CapaAccesoaDatos;

namespace CapaLogicadeNegocio
{
    public static class LogicaCompra
    {
        public static bool verificarTexto(string txt)
        {
            bool bandera = true;
            if(!Utilidades.validarString(txt,true,false,false))
            {
                bandera = false;
            }
            return bandera;
        }

        public static bool verificarTarjeta(string txt)
        {
            if (Utilidades.validarString(txt, true, false, false) && 
                            txt.Length == 16 && txt != string.Empty)
                return true;
            else return false;
        }

        public static DataTable rellenarMetodos()
        {
            gestionMetodoPago mp = new gestionMetodoPago();
            DataTable tbl = new DataTable();
            tbl = mp.getTarjetas();
            return tbl;
        }

        public static DataTable rellenarCuotas(string index)
        {
            gestionMetodoPago mp = new gestionMetodoPago();
            DataTable tbl = new DataTable();
            tbl = mp.getMetodosdepago(index);
            return tbl;
        }

        public static DataTable rellenarDirecciones(string id)
        {
            gestionUsuarios gu = new gestionUsuarios();
            DataTable tbl = new DataTable();
            tbl = gu.getListaDirecxUsuario(id);
            return tbl;
        }

        public static bool insertarDetVenta(DataRow row)
        {
            DetalleVentas detVenta = new DetalleVentas();
            gestionVentas gv = new gestionVentas();
            gestionProductos gp = new gestionProductos();
            detVenta.Cantidad = int.Parse(row[1].ToString());
            detVenta.IDProducto1 = row[3].ToString();
            detVenta.PrecioUnitario = float.Parse(row[2].ToString());
            detVenta.Descuento = gp.getProducto(row[3].ToString()).Descuento;
            detVenta.IDVenta1 = (gv.recuperarIdventa()).ToString();
            
            bool inserto = gv.insertarDetalleventas(detVenta);

            return inserto;
        }

        public static bool insertarVenta(Ventas vent)
        {
            gestionVentas gv = new gestionVentas();
            bool inserto = gv.insertarVenta(vent);
            return inserto;
        }

        public static DataRow recuperarEnvio(string iddir)
        {
            gestionUsuarios gu = new gestionUsuarios();
            return gu.idenvioxUsuario(iddir);
        }

        public static float costoTotal(float totalProd, float interes, float costoEnvio)
        {
            float suma = 0;
            suma += totalProd;
            if(interes != 0)
              suma *= interes;
            suma += costoEnvio;
            return suma;
        }

        public static float getInteres(string id)
        {
            gestionMetodoPago gmp = new gestionMetodoPago();
            float interes = float.Parse(gmp.getInteres(id)[0].ToString());
            return interes;
        }

        public static DataTable rellenarxNrotarjeta(Usuario us)
        {
            gestionUsuarios gu = new gestionUsuarios();
            DataTable tbl = new DataTable();
            tbl = gu.Tarjetas_x_Usuario(us);
            return tbl;
        }

        public static DataTable tarjxUsu(Usuario usu)
        {
            gestionUsuarios gu = new gestionUsuarios();
            return gu.Tarjetas_x_Usuario(usu);
        }
    }
}
