﻿using System;
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
            return bd.getTable("SELECT * FROM DIRECXUSUARIO WHERE IdUsuario_DIR = '" + IdUsuario+"'", "Direcciones");
        }


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

        public DataTable Compras_x_Usuario(Usuario usu)
        {
            DataTable Tabla = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IdUsuario", usu.IDUsuario);
            bd.ExecStoredProcedure(cmd, "spObtenerComprasUsuario", ref Tabla);
            return Tabla;
        }

        public DataTable Tarjetas_x_Usuario(Usuario usu)
        {
            DataTable Tabla = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@IdUsuario", usu.IDUsuario);
            bd.ExecStoredProcedure(cmd, "spObtenerTarjetasUsuario", ref Tabla);
            return Tabla;
        }

        public DataTable Direcciones_x_Usuario(Usuario usu)
        {
            DataTable Tabla = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("IdUsuario", usu.IDUsuario);
            bd.ExecStoredProcedure(cmd, "spObtenerDireccionesUsuario", ref Tabla);
            return Tabla;
        }

        public bool CancelarCompra(int IdVenta)
        {
            bool eliminada = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("IdVenta", IdVenta);
            eliminada = Convert.ToBoolean(bd.ExecStoredProcedure(cmd, "spCancelarCompra"));
            return eliminada;
        }

        public DataTable CargarTablaCompras(Usuario usu)
        {
            DataTable Tabla;
            Tabla = Compras_x_Usuario(usu);
            Tabla.Columns[7].ColumnName = "Estado ";
            Tabla.Columns.Add("Estado");

            for (int i = 0; i < Tabla.Rows.Count; i++)
            {
                Tabla.Rows[i].SetField(8, (EstadoCompra)Tabla.Rows[i].Field<Byte>(7));
            }
            Tabla.Columns.RemoveAt(7);
            return Tabla;
        }

        public DataTable CargarMdPxUsu(Usuario usu)
        {
            DataTable Tabla;
            Tabla = Tarjetas_x_Usuario(usu);
            Tabla.Columns.RemoveAt(0);
            return Tabla;
        }

        public DataTable CargarDirecciones(Usuario usu)
        {
            DataTable Tabla;
            Tabla = Direcciones_x_Usuario(usu);
            Tabla.Columns.RemoveAt(0);
            return Tabla;
        }

        public bool EliminarMediodePagoxUsu(Usuario usu, string Id)
        {
            bool Eliminado = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("IdUsuario", usu.IDUsuario);
            cmd.Parameters.AddWithValue("IdTarjxU", Id);
            Eliminado = Convert.ToBoolean(bd.ExecStoredProcedure(cmd, "spEliminarMdp"));
            return Eliminado;
        }

        public bool EliminarDireccion (Usuario usu, int CodDireccion)
        {
            bool Eliminado = false;
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("IdUsuario", usu.IDUsuario);
            cmd.Parameters.AddWithValue("CodDireccion", CodDireccion);
            Eliminado = Convert.ToBoolean(bd.ExecStoredProcedure(cmd, "spEliminarDireccion"));
            return Eliminado;
        }

        public DataRow idenvioxUsuario(string codDir)
        {
            DataTable tbl = new DataTable();
            tbl = bd.getTable("SELECT IDEnvio,Costo_ENVIO FROM ENVIOS INNER JOIN DirecxUsuario ON Provincia_DIR =" +
                " Provincia_ENVIO WHERE CodDirreccion = '" + codDir + "'", "Envio");
            return tbl.Rows[0];
        }
    }
}
