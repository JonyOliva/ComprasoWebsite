using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicadeNegocio;
using Entidad;

namespace ArvoProjectWebsite.WebForms
{
    public partial class frmMenuUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void lbtnDireccionesMenuUsuario_Click(object sender, EventArgs e)
        {
            lblMenuUsuario.Text = "Direcciones";
            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            //gestionUsuarios.getListaDirecxUsuario(((Usuario)this.Application["Usuario"]).IDUsuario);
            grdMenuUsuario.DataSource = gestionUsuarios.getListaDirecxUsuario("0000");
            grdMenuUsuario.DataBind();
        }

        protected void lbtnMdPMenuUsuario_Click(object sender, EventArgs e)
        {
            lblMenuUsuario.Text = "Medios de Pago";
            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            grdMenuUsuario.DataSource = gestionUsuarios.getListaTarjetasxUsuario("0000");
            grdMenuUsuario.DataBind();
        }

        protected void lbtnComprasMenuUsuario_Click(object sender, EventArgs e)
        {
            lblMenuUsuario.Text = "COMPRAS";
            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            grdMenuUsuario.DataSource = gestionUsuarios.getListaComprasxUsuario("0000");
            grdMenuUsuario.DataBind();
        }

        protected void grdMenuUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void grdMenuUsuario_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void grdMenuUsuario_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }
    }
}