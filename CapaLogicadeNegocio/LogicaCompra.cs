using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Data;
using System.Data.SqlClient;
using CapaAccesoaDatos;
using System.Globalization;

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
            CADMetodopago mp = new CADMetodopago();
            DataTable tbl = new DataTable();
            tbl = mp.getTarjetas();
            return tbl;
        }

        public static DataTable rellenarCuotas(string index)
        {
            CADMetodopago mp = new CADMetodopago();
            DataTable tbl = new DataTable();
            tbl = mp.getMetodosdepago(index);
            return tbl;
        }

        public static DataTable rellenarDirecciones(string id)
        {
            CADUsuarios gu = new CADUsuarios();
            DataTable tbl = new DataTable();
            tbl = gu.getListaDirecxUsuarioCAD(id);
            return tbl;
        }

        public static bool insertarDetVenta(DataRow row)
        {
            DetalleVentas detVenta = new DetalleVentas();
            CADVentas gv = new CADVentas();
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
            CADVentas gv = new CADVentas();
            bool inserto = gv.insertarVenta(vent);
            return inserto;
        }

        public static DataRow recuperarEnvio(string iddir)
        {
            CADUsuarios gu = new CADUsuarios();
            return gu.idenvioxUsuarioCAD(iddir);
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
            CADMetodopago gmp = new CADMetodopago();
            float interes = float.Parse(gmp.getInteres(id)[0].ToString());
            return interes;
        }

        public static DataTable rellenarxNrotarjeta(Usuario us)
        {
            CADUsuarios gu = new CADUsuarios();
            DataTable tbl = new DataTable();
            tbl = gu.Tarjetas_x_UsuarioCAD(us);
            return tbl;
        }

        public static DataTable tarjxUsu(Usuario usu)
        {
            CADUsuarios gu = new CADUsuarios();
            return gu.Tarjetas_x_UsuarioCAD(usu);
        }

        public static bool verificarstringFecha(string txt)
        {
            DateTime dt;
            if(DateTime.TryParseExact(txt,"d/M/yyyy",CultureInfo.InvariantCulture,DateTimeStyles.None,out dt))
            {
                if(dt> DateTime.Today)
                   return true;
            }
            return false;
        }

        public static bool agregarMetodopago(string idusuario,string nrotar, string idtar, string titular, string vencimiento)
        {
            CADUsuarios gu = new CADUsuarios();
            gu.AgregarMdPCAD(idusuario,nrotar,idtar,titular,vencimiento);
            return true;
        }

        public static string tipoTarjeta(string numero)
        {
            CADMetodopago gmp = new CADMetodopago();
            string idtar = gmp.getTipotarjeta(numero).Rows[0]["IDTarjeta_TxU"].ToString();
            return idtar;
        }
        
        public static void cargarCompras(DataTable tblcompras, DataTable tblcarrito)
        {
            for (int i = 0; i < tblcarrito.Rows.Count; i++)
            {
                DataRow row = tblcompras.NewRow();
                string prueba = tblcarrito.Rows[i][4].ToString();
                row["Cantidad"] = int.Parse(prueba);
                row["Producto"] = tblcarrito.Rows[i][0].ToString();
                row["RutaImagen"] = tblcarrito.Rows[i][3].ToString();
                row["IDProducto"] = tblcarrito.Rows[i][5].ToString();
                row["Precio"] = decimal.Parse(tblcarrito.Rows[i][2].ToString());
                row["Subtotal"] =
                    int.Parse(prueba) * decimal.Parse(tblcarrito.Rows[i][2].ToString());

                tblcompras.Rows.Add(row);
            }

        }
        public static DataTable crearCompra()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("Producto", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Cantidad", System.Type.GetType("System.Int32")));
            tbl.Columns.Add(new DataColumn("Precio", System.Type.GetType("System.Decimal")));
            tbl.Columns.Add(new DataColumn("IDProducto", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("RutaImagen", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Subtotal", System.Type.GetType("System.Decimal")));
            return tbl;
        }

    }
}
