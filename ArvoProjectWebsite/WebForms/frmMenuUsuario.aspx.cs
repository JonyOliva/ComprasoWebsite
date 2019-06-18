using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicadeNegocio;
using Entidad;
using System.Data.SqlClient;
using System.Data;

namespace ArvoProjectWebsite.WebForms
{
    public partial class frmMenuUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            usu.Email = "CLAUDIO@ARVO.CF";
            gestionUsuarios.getUsuario(ref usu);
            Application["Usuario"] = usu;

            lblDniMenuUsuario.Text = ((Usuario)Application["Usuario"]).DNI;
            lblMailMenuUsuario.Text = ((Usuario)Application["Usuario"]).Email;
            lblNombreMenuUsuario.Text = ((Usuario)Application["Usuario"]).Apellido + " " + ((Usuario)Application["Usuario"]).Nombre;

            if (!IsPostBack)
            {

            }
        }

        protected void lbtnDireccionesMenuUsuario_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            usu.IDUsuario = "0000";
            Application["Usuario"] = usu;

            lblMenuUsuario.Text = "Direcciones";
            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            DataTable Tabla = gestionUsuarios.Direcciones_x_Usuario((Usuario)Application["Usuario"]);
            grdMenuUsuario.DataSource = Tabla;
            Session["Direcciones"] = Tabla;
            grdMenuUsuario.DataBind();
        }

        protected void lbtnMdPMenuUsuario_Click(object sender, EventArgs e)
        {
            
            Usuario usu = new Usuario();
            usu.IDUsuario = "0000";
            Application["Usuario"] = usu;

            lblMenuUsuario.Text = "Medios de Pago";
            gestionUsuarios gestionUsuarios = new gestionUsuarios();

            DataTable Tabla = gestionUsuarios.Tarjetas_x_Usuario((Usuario)Application["Usuario"]);
            grdMenuUsuario.DataSource = Tabla;
            Session["MdP"] = Tabla;
            grdMenuUsuario.DataBind();
        }

        protected void lbtnComprasMenuUsuario_Click(object sender, EventArgs e)
        {
            Usuario usu = new Usuario();
            usu.IDUsuario = "0000";
            Application["Usuario"] = usu;

            lblMenuUsuario.Text = "Compras";

            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            DataTable Tabla = new DataTable();
            Tabla = gestionUsuarios.CargarTablaCompras(((Usuario)Application["Usuario"]));
    
            Session["Compras"] = Tabla;
            grdMenuUsuario.DataSource = Session["Compras"];
            grdMenuUsuario.DataBind();
        }

        protected void grdMenuUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }

        protected void grdMenuUsuario_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            DataRow row = (DataRow)grdMenuUsuario.SelectedValue;
            if (row[7].ToString() == "Procesando") { }
            else lblDniMenuUsuario.Text = "jajaj";
        }

        protected void grdMenuUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdMenuUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gestionUsuarios gestionUsuarios = new gestionUsuarios();

            switch(lblMenuUsuario.Text)
            {
                case "Compras":
                    if (((DataTable)Session["Compras"]).Rows[e.RowIndex][7].ToString() == "Procesando")
                    {
                        gestionUsuarios.CancelarCompra((int)((DataTable)Session["Compras"]).Rows[e.RowIndex][0]);
                        Session["Compras"] = gestionUsuarios.CargarTablaCompras((Usuario)Application["Usuario"]);
                        grdMenuUsuario.DataSource = Session["Compras"];
                        grdMenuUsuario.DataBind();

                    }
                    else
                    {
                        lblDniMenuUsuario.Text = ((DataTable)Session["Compras"]).Rows[e.RowIndex][7].ToString();
                    }
                    break;
                case "Medios de Pago":
                    break;
                case "Direcciones":
                    break;
            }
            
        }
    }
}