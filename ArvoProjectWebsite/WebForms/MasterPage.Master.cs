using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using CapaLogicadeNegocio;
using System.Data;

namespace ArvoProjectWebsite.WebForms
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        gestorSesion sesion;

        protected void Page_Load(object sender, EventArgs e)
        {
            sesion = new gestorSesion(InicSec, Cuenta, CerrSec);
            lblBuscador.Visible = false;
            if (!IsPostBack)
            {
                sesion.comprobarSesion();
                if (Session["buscadorState"] != null)
                {
                    lblBuscador.Visible = true;
                    Session["buscadorState"] = null;
                }
            }
        }
        
        protected void Carrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/frmCarrito.aspx");
        }

        protected void item_Command(object sender, CommandEventArgs e)
        {
            Session["filtroCategoria"] = e.CommandArgument;
            Session["Buscador"] = null;
            Server.Transfer("/WebForms/frmListaProductos.aspx", false);
        }

        protected void ejecutarBuscador(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscador.Text))
            {
                string[] words = txtBuscador.Text.Trim().Split();
                Session["Buscador"] = words;
                Response.Redirect("/WebForms/frmListaProductos.aspx");
            }
        }

        protected void btnUser_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "init":
                    Response.Redirect("/WebForms/frmLogin.aspx");
                    break;
                case "acc":
                    Usuario user = (Usuario)Application["Usuario"];
                    if (user.Admin)
                    {
                        Response.Redirect("/WebForms/frmMenuAdmin.aspx");
                    }
                    else
                    {
                        Response.Redirect("/WebForms/frmMenuUsuario.aspx");
                    }
                    break;
                case "close":
                    sesion.cerrarSession();
                    Server.Transfer("/default.aspx", false);
                    break;
            }
        }
    }
}