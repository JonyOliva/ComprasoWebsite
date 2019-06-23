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
        gestorSesion sesion;
        protected void Page_Load(object sender, EventArgs e)
        {
            sesion = new gestorSesion(InicSec, Cuenta, CerrSec);
            if (!IsPostBack)
            {
                sesion.comprobarSesion();
            }

            grdCarrito.RowCommand += new GridViewCommandEventHandler(grdCarrito_RowCommand);
            actualizarCarrito();
        }

        protected void lnkSeguircom_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmListaProductos.aspx"); 
        }

        protected void lnkComprar_Click(object sender, EventArgs e)
        {
            if (lblNocarrito.Visible == true)
            { 
                Response.Write("<script language=javascript>alert('No posee productos en el carrito');</script>");
            }
                

                else if (int.Parse(((TextBox)grdCarrito.Rows[2].FindControl("txtCantidad")).Text) < 1)
                {
                    Response.Write("<script language=javascript>alert('Cantidad no puede ser menor a 1');</script>");
                }
                else
                {
                    this.Session.Abandon();
                    Response.Redirect("frmCompra.aspx");
                }
            
        }

        protected void grdCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           
        }

        protected void grdCarrito_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
                int pos = e.RowIndex;
                eliminarprodCarrito((DataTable)this.Session["Carrito"], pos);
                actualizarCarrito();
        }

        public void eliminarprodCarrito(DataTable tbl, int pos)
        {
            if(pos < tbl.Rows.Count && pos >= 0)
                tbl.Rows.RemoveAt(pos);
            if (tbl.Rows.Count == 0)
                tbl = null;
        }

        public void actualizarCarrito()
        {
            if (this.Session["Carrito"] == null || ((DataTable)this.Session["Carrito"]).Rows.Count == 0)
            {
                lblNocarrito.Visible = true;
                lnkComprar.Enabled = false;
            }
            else
            {
                lblNocarrito.Visible = false;
                lnkComprar.Enabled = true;

            }
            cargarCarrito();
            grdCarrito.DataBind();
        }

        protected void InicSec_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }

        protected void Carrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCarrito.aspx");
        }

        protected void btnUser_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "init":
                    Response.Redirect("/WebForms/frmLogin.aspx");
                    break;
                case "acc":
                    Response.Redirect("/WebForms/frmMenuUsuario.aspx");
                    break;
                case "close":
                    sesion.cerrarSession();
                    break;
            }
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

        public void cargarCarrito()
        {
            grdCarrito.DataSource = (DataTable)this.Session["Carrito"];
        }

        protected void grdCarrito_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[6].Visible = false;
        }

        protected void grdCarrito_Sorting(object sender, GridViewSortEventArgs e)
        {

        }
        
    }
}
