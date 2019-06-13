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

        public DataTable getListaTarjetasxUsuario(string IdUsuario)
        {
            BaseDeDatos bd = new BaseDeDatos(databasePath);
            return bd.getTable("SELECT * FROM TarjetasxUsuario where IDUsuario_TxU =" + IdUsuario, "TarjetasUsuario");
        }

        public DataTable getListaComprasxUsuario(string IdUsuario)
        {
            BaseDeDatos bd = new BaseDeDatos(databasePath);
            return bd.getTable("SELECT * FROM VENTAS WHERE IDUsuario_VENTA = " + IdUsuario, "ComprasUsuario");
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
    }
}
