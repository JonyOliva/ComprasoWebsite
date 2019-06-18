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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InicSec_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/frmLogin.aspx");
        }

        protected void Carrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/frmCarrito.aspx");
        }

        protected void item_Command(object sender, CommandEventArgs e)
        {
            Session["filtroCategoria"] = e.CommandArgument;
            Response.Redirect("/WebForms/frmListaProductos.aspx");
        }

        protected void ejecutarBuscador(object sender, EventArgs e)
        {
            string[] words = txtBuscador.Text.Split();
            Session["Buscador"] = words;
            Response.Redirect("/WebForms/frmListaProductos.aspx");
        }
    }
}