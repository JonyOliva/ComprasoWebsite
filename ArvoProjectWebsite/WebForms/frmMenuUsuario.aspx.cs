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
            lblMenuUsuario.Text = "Direcciones";
            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            Session["Direcciones"] = gestionUsuarios.Direcciones_x_Usuario((Usuario)Application["Usuario"]);
            grdMenuUsuario.DataSource = Session["Direcciones"];
            grdMenuUsuario.DataBind();
        }

        protected void lbtnMdPMenuUsuario_Click(object sender, EventArgs e)
        {
            lblMenuUsuario.Text = "Medios de Pago";
            gestionUsuarios gestionUsuarios = new gestionUsuarios();

            Session["MdP"] = gestionUsuarios.CargarMdPxUsu((Usuario)Application["Usuario"]);
            grdMenuUsuario.DataSource = Session["MdP"];
            grdMenuUsuario.DataBind();
        }

        protected void lbtnComprasMenuUsuario_Click(object sender, EventArgs e)
        {
            lblMenuUsuario.Text = "Compras";

            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            Session["Compras"] = gestionUsuarios.CargarTablaCompras(((Usuario)Application["Usuario"]));
            grdMenuUsuario.DataSource = Session["Compras"];
            grdMenuUsuario.DataBind();
        }



        protected void grdMenuUsuario_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            DataRow row = (DataRow)grdMenuUsuario.SelectedValue;
            if (row[7].ToString() == "Procesando") { }
            else lblDniMenuUsuario.Text = "jajaj";
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
                case "Medios de Pago": gestionUsuarios.EliminarMediodePagoxUsu((Usuario)Application["Usuario"], ((DataTable)Session["MdP"]).Rows[e.RowIndex][1].ToString());
                                       Session["MdP"] = gestionUsuarios.CargarMdPxUsu((Usuario)Application["Usuario"]);
                                       grdMenuUsuario.DataSource = Session["MdP"];
                                       grdMenuUsuario.DataBind();
                    break;
                case "Direcciones": gestionUsuarios.EliminarDireccion((Usuario)Application["Usuario"], (Convert.ToInt32(((DataTable)Session["Direcciones"]).Rows[e.RowIndex][1])));
                                    Session["Direcciones"] = gestionUsuarios.CargarDirecciones((Usuario)Application["Usuario"]);
                                    grdMenuUsuario.DataSource = Session["Direcciones"];
                                    grdMenuUsuario.DataBind();
                    break;
            }
            
        }
    }
}