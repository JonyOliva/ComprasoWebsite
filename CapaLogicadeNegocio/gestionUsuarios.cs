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
            BaseDeDatos bd = new BaseDeDatos(databasePath);
            return bd.getTable("SELECT * FROM DIRECXUSUARIO WHERE IdUsuario_DIR = "+ IdUsuario, "Direcciones");
        }


        public bool getUsuario(ref Usuario usuario)
        {
            BaseDeDatos bd = new BaseDeDatos(databasePath); 
            DataTable data = bd.getTable("SELECT * FROM USUARIOS WHERE Email_USU='" + usuario.Email + "'", "usuario");
            if(data.Rows.Count > 0)
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
    }
}
