using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidad;
using CapaAccesoaDatos;

namespace CapaLogicadeNegocio
{
    public class gestionUsuarios
    {

        string databasePath = Utilidades.GetStringConectionLocal();
        BaseDeDatos bd;
        CADUsuarios cadu;
        public gestionUsuarios()
        {
            bd = new BaseDeDatos(databasePath);
            cadu = new CADUsuarios();
        }

        public DataTable getDropDrownUsuario(string a)
        {
             return cadu.getDropDrownUsuarioCAD(a);
        }

        //public DataTable getListaDirecxUsuario(string id)
        //{
        //    return bd.getTable("SELECT * FROM DIRECXUSUARIO WHERE IDUsuario_DIR = " + id, "Direcxusuario");
        //}

        public bool getUsuario(ref Usuario usuario)
        {
            DataTable data = bd.getTable("SELECT * FROM USUARIOS WHERE Email_USU='" + usuario.Email + "'", "usuario");
            if (data.Rows.Count > 0)
            {
                usuario.IDUsuario = data.Rows[0]["IDUsuario"].ToString().Trim();
                usuario.Password = data.Rows[0]["Password_USU"].ToString().Trim();
                usuario.Admin = Convert.ToBoolean(data.Rows[0]["Admin_USU"]);
                usuario.Nombre = data.Rows[0]["Nombre_USU"].ToString().Trim();
                usuario.Apellido = data.Rows[0]["Apellido_USU"].ToString().Trim();
                usuario.nroCel = data.Rows[0]["nroCel_USU"].ToString().Trim();
                usuario.FechaNac = data.Rows[0]["FechaNac_USU"].ToString().Trim();
                usuario.DNI = data.Rows[0]["DNI_Usu"].ToString().Trim();
                return true;
            }
            return false;
        }

        public int AgregarUsuario(Usuario usu)
        {
            return cadu.AgregarUsuarioCAD(usu);
        }

        //public DataTable Compras_x_Usuario(Usuario usu)
        //{
        //    DataTable Tabla = new DataTable();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.AddWithValue("@IdUsuario", usu.IDUsuario);
        //    bd.ExecStoredProcedure(cmd, "spObtenerComprasUsuario", ref Tabla);
        //    return Tabla;
        //}

        //public DataTable Tarjetas_x_Usuario(Usuario usu)
        //{
        //    DataTable Tabla = new DataTable();
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.Parameters.AddWithValue("@IdUsuario", usu.IDUsuario);
        //    bd.ExecStoredProcedure(cmd, "spObtenerTarjetasUsuario", ref Tabla);
        //    return Tabla;
        //}

        public DataTable Direcciones_x_Usuario(Usuario usu)
        {
            return cadu.Direcciones_x_UsuarioCAD(usu);
        }

        public bool CancelarCompra(int IdVenta)
        {
            return cadu.CancelarCompraCAD(IdVenta);
        }

        public DataTable CargarTablaCompras(Usuario usu)
        {
            DataTable Tabla;
            Tabla = cadu.Compras_x_UsuarioCAD(usu);
            Tabla.Columns[8].ColumnName = "Estado ";
            Tabla.Columns.Add("Estado");

            for (int i = 0; i < Tabla.Rows.Count; i++)
            {
                Tabla.Rows[i].SetField(9, (EstadoCompra)Tabla.Rows[i].Field<Byte>(8));
            }
            Tabla.Columns.RemoveAt(8);
            return Tabla;
        }

        public DataTable CargarMdPxUsu(Usuario usu)
        {
            DataTable Tabla;
            Tabla = cadu.Tarjetas_x_UsuarioCAD(usu);
            Tabla.Columns.RemoveAt(0);
            return Tabla;
        }

        public DataTable CargarDirecciones(Usuario usu)
        {
            DataTable Tabla;
            Tabla = cadu.Direcciones_x_UsuarioCAD(usu);
            //Tabla = Direcciones_x_Usuario(usu);
            Tabla.Columns.RemoveAt(0);
            return Tabla;
        }

        public bool EliminarMediodePagoxUsu(Usuario usu, string Id, string NumTarj)
        {
            return cadu.EliminarMediodePagoxUsuCAD(usu, Id, NumTarj);
        }

        public bool EliminarDireccion(Usuario usu, int CodDireccion)
        {
            return cadu.EliminarDireccionCAD(usu, CodDireccion);
        }


        public DataRow idenvioxUsuario(string codDir)
        {
            return cadu.idenvioxUsuarioCAD(codDir);
        }

        public void AgregarDireccion(string id, string provincia, string direccion)
        {
            cadu.AgregarDireccionCAD(id, provincia, direccion);
        }

        public string AgregarMdP(string id, string tarjeta, string codtarj, string titular, string vencimiento)
        {
            return cadu.AgregarMdPCAD(id, tarjeta, codtarj, titular, vencimiento);
        }



        public int ValidarCUITyMail(string cuit, string mail)
        {
            cuit.Trim();
            return cadu.ValidarCUITyMailCAD(cuit, mail);
        }

        public DataTable ObtenerDetalleVenta(int id)
        {
            return cadu.ObtenerDetalleVentaCAD(id);
        }



    }
}
