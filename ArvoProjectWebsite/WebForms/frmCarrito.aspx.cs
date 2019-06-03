using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Entidad;
using CapaLogicadeNegocio;

namespace ArvoProjectWebsite
{
    public partial class frmCarrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            grdCarrito.RowCommand += new GridViewCommandEventHandler(grdCarrito_RowCommand);
            actualizarCarrito();
        }

        protected void lnkSeguircom_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmListaProductos.aspx");
        }

        protected void lnkComprar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCompra.aspx");
        }

        protected void grdCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int pos = int.Parse(e.CommandArgument.ToString());
                eliminarprodCarrito((List<Producto>)this.Session["Carrito"], pos);
                actualizarCarrito();
            }
        }

        protected void grdCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        public void eliminarprodCarrito(List<Producto> prod, int pos)
        {
            if(prod.Count > 0)
                prod.RemoveAt(pos);
            if (prod.Count == 0)
                prod = null;
        }

        public void actualizarCarrito()
        {
            if (this.Session["carrito"] == null || ((List<Producto>)this.Session["carrito"]).Count == 0)
            {
                lblNocarrito.Visible = true;
            }
            else
            {
                lblNocarrito.Visible = false;

            }
            grdCarrito.DataSource = (List<Producto>)this.Session["Carrito"];
            grdCarrito.DataBind();
        }
    }
}
