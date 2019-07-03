using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace CapaAccesoaDatos
{
    public class CADUsuarios
    {
        string databasePath = Entidad.Utilidades.GetStringConectionLocal();
        BaseDeDatos bd;
        public CADUsuarios()
        {
            bd = new BaseDeDatos(databasePath);
        }

        public DataTable getDropDrownUsuarioCAD(string a)
        {
            if (a == "Provincias") return bd.getTable("SELECT Provincia_ENVIO FROM ENVIOS", "Provincias");
            else if (a == "Tarjetas") return bd.getTable("SELECT IDTarjeta_TARJ, Nombre_TARJ FROM TARJETAS", "Tarjetas");
            return bd.getTable("SELECT Provincia_ENVIO FROM ENVIOS", "Provincias");
        }

        public DataTable getListaDirecxUsuarioCAD(string id)
        {
            return bd.getTable("SELECT * FROM DIRECXUSUARIO WHERE IDUsuario_DIR = " + id, "Direcxusuario");
        }

        public int AgregarUsuarioCAD(Usuario usu)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IdUsuario", usu.IDUsuario);
            cmd.Parameters.AddWithValue("@NombreUsuario", usu.Nombre);
            cmd.Parameters.AddWithValue("@ApellidoUsuario", usu.Apellido);
            cmd.Parameters.AddWithValue("@Password", usu.Password);
            cmd.Parameters.AddWithValue("@DniUsuario", usu.DNI);
            cmd.Parameters.AddWithValue("EmailUsuario", usu.Email);
            cmd.Parameters.AddWithValue("@NroTelefono", usu.nroCel);
            cmd.Parameters.AddWithValue("@FechaNacUsuario", usu.FechaNac);

            int resp = bd.ExecStoredProcedure(cmd, "spAgregarUsuario");
            return resp;
        }

        public DataTable Compras_x_UsuarioCAD(Usuario usu)
        {
            DataTable Tabla = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IdUsuario", usu.IDUsuario);
            bd.ExecStoredProcedure(cmd, "spObtenerComprasUsuario", ref Tabla);
            return Tabla;
        }

        public DataTable Tarjetas_x_UsuarioCAD(Usuario usu)
        {
            DataTable Tabla = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IdUsuario", usu.IDUsuario);
            bd.ExecStoredProcedure(cmd, "spObtenerTarjetasUsuario", ref Tabla);
            return Tabla;
        }

        public DataTable Direcciones_x_UsuarioCAD(Usuario usu)
        {
            DataTable Tabla = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("IdUsuario", usu.IDUsuario);
            bd.ExecStoredProcedure(cmd, "spObtenerDireccionesUsuario", ref Tabla);
            return Tabla;
        }

        public bool CancelarCompraCAD(int IdVenta)
        {
            bool eliminada = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("IdVenta", IdVenta);
            eliminada = Convert.ToBoolean(bd.ExecStoredProcedure(cmd, "spCancelarCompra"));
            return eliminada;
        }

        public bool EliminarMediodePagoxUsuCAD(Usuario usu, string Id, string NumTarj)
        {
            bool Eliminado = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("IdUsuario", usu.IDUsuario);
            cmd.Parameters.AddWithValue("IdTarjxU", Id);
            cmd.Parameters.AddWithValue("NroTarjeta", NumTarj);
            Eliminado = Convert.ToBoolean(bd.ExecStoredProcedure(cmd, "spEliminarMdp"));
            return Eliminado;
        }

        public bool EliminarDireccionCAD(Usuario usu, int CodDireccion)
        {
            bool Eliminado = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("IdUsuario", usu.IDUsuario);
            cmd.Parameters.AddWithValue("CodDireccion", CodDireccion);
            Eliminado = Convert.ToBoolean(bd.ExecStoredProcedure(cmd, "spEliminarDireccion"));
            return Eliminado;
        }

        public void AgregarDireccionCAD(string id, string provincia, string direccion)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("IdUsuario", id);
            cmd.Parameters.AddWithValue("Provincia", provincia);
            cmd.Parameters.AddWithValue("Direccion", direccion);
            bd.ExecStoredProcedure(cmd, "spAgregarDireccion");
        }

        public string AgregarMdPCAD(string id, string tarjeta, string codtarj, string titular, string vencimiento)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("IdUsuario", id);
            cmd.Parameters.AddWithValue("NroTarjeta", tarjeta);
            cmd.Parameters.AddWithValue("IdTarj", codtarj);
            cmd.Parameters.AddWithValue("Titular", titular);
            cmd.Parameters.AddWithValue("Venc", vencimiento);
            try
            {
                return bd.ExecStoredProcedure(cmd, "spAgregarMdP").ToString();
            }
            catch (Exception ex)
            {
                return ex.HelpLink;
            }
        }

        public int ValidarCUITyMailCAD(string cuit, string mail)
        {
            DataTable Tabla = new DataTable();
            cuit.Trim();
            int respuesta = 0;
            bool paso = false;
            Tabla = bd.getTable("SELECT * FROM USUARIOS WHERE IDUsuario = '" + cuit + "'", "UsuarioCuit");
            if (Tabla.Rows.Count >= 1)
            {
                respuesta = 2;
                paso = true;
            }
            Tabla = bd.getTable("SELECT * FROM USUARIOS WHERE Email_USU = '" + mail + "'", "UsuarioMail");
            if (Tabla.Rows.Count >= 1)
            {
                if (paso)
                {
                    respuesta = 3;
                }
                else respuesta = 1;
            }
            return respuesta;
        }

        public DataRow idenvioxUsuarioCAD(string codDir)
        {
            DataTable tbl = new DataTable();
            tbl = bd.getTable("SELECT IDEnvio,Costo_ENVIO FROM ENVIOS INNER JOIN DirecxUsuario ON Provincia_DIR =" +
                " Provincia_ENVIO WHERE CodDirreccion = '" + codDir + "'", "Envio");
            return tbl.Rows[0];
        }

        public DataTable ObtenerDetalleVentaCAD(int id)
        {
            return bd.getTable("SELECT IDVENTA_DETV as 'ID Venta', IDPRODUCTO_DETV as 'Cod.Producto', NOMBRE_PROD as 'Producto'," +
                " DESCUENTO_DETV as 'Descuento', CANTIDAD_DETV as 'Cantidad', PRECIOUNITARIO_DETV as 'Precio Unitario'" +
                " FROM DETVENTAS INNER JOIN PRODUCTOS ON IDPRODUCTO_DETV = IDPRODUCTO WHERE IDVENTA_DETV = " + id, "DetalleVentas");
        }
    }
}
