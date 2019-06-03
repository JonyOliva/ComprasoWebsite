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
            if (!IsPostBack)
            {
                grdCarrito.RowCommand += new GridViewCommandEventHandler(grdCarrito_RowCommand);

                DataTable tbl = new DataTable();
                string idprod = "P001";
                gestionCarrito gc = new gestionCarrito();
                gc.agregarCarrito(tbl, idprod);
                this.Session["Carrito"] = tbl;
                
                //List<Producto> carrito = new List<Producto>(); HAY QUE PROBAR ESTA WEA FACU
                //if(this.Session["Carrito"] != null)
                //{
                //    carrito = (List<Producto>)this.Session["Carrito"];
                //    grdCarrito.DataSource = carrito;
                //}
                //else
                //{
                 //   Server.Transfer("/WebForms/default.aspx");
                    //NO HAY CARRITO BOLUDO
                //}
                
                grdCarrito.DataSource = (DataTable)this.Session["Carrito"];
                if (this.Session["Carrito"] != null)
                    lblNocarrito.Visible = false;
                grdCarrito.DataBind();
            }
            if (IsPostBack)
            {
                if (((DataTable)this.Session["Carrito"]).Rows.Count == 0 || this.Session["Carrito"] == null)
                    lblNocarrito.Visible = false;
                grdCarrito.DataSource = (DataTable)this.Session["Carrito"];
                grdCarrito.DataBind();
            }
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
            if (e.CommandName == "Select")
            {
                int pos = int.Parse(e.CommandArgument.ToString());
                ((DataTable)this.Session["Carrito"]).Rows.RemoveAt(pos);
                if (((DataTable)this.Session["Carrito"]).Rows.Count == 0)
                    this.Session["Carrito"] = null;
                grdCarrito.DataBind();
            }
        }

        protected void grdCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}
