using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicadeNegocio;

namespace ArvoProjectWebsite.WebForms
{
    public partial class frmMenuUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gestionUsuarios gUsuario = new gestionUsuarios();
                grdDireccionesMenuUsuarios.DataSource = gUsuario.getListaDirecxUsuario("0000");
                grdDireccionesMenuUsuarios.DataBind();
                grdMdePagoMenuUsuarios.DataSource = gUsuario.getListaTarjetasxUsuario("0000");
                grdMdePagoMenuUsuarios.DataBind();
                //grdComprasMenuUsuarios.DataSource = gUsuario.getListaComprasxUsuario("0000");
                //grdComprasMenuUsuarios.DataBind();
            }
        }
    }
}