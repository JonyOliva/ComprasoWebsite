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
            if (lblNocarrito.Visible == true)
                Response.Write("<script language=javascript>alert('No posee productos en el carrito');</script>");

                else if (int.Parse(((TextBox)grdCarrito.Rows[2].FindControl("txtCantidad")).Text) < 1)
                {
                    Response.Write("<script language=javascript>alert('Cantidad no puede ser menor a 1');</script>");
                }
                else
                {
                    Response.Redirect("frmCompra.aspx");
                }
            
        }

        protected void grdCarrito_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                int pos = int.Parse(e.CommandArgument.ToString());
                eliminarprodCarrito(((List<Producto>)this.Session["Carrito"]), pos);
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
            if (this.Session["Carrito"] == null || ((List<Producto>)this.Session["Carrito"]).Count == 0)
            {
                lblNocarrito.Visible = true;
            }
            else
            {
                lblNocarrito.Visible = false;

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

        public void cargarCarrito()
        {
            if(this.Session["Carrito"]!= null)
            { 
                DataTable tbl = new DataTable();
                tbl.Columns.Add(new DataColumn("Producto", System.Type.GetType("System.String")));
                tbl.Columns.Add(new DataColumn("Marca", System.Type.GetType("System.String")));
                tbl.Columns.Add(new DataColumn("Precio", System.Type.GetType("System.Decimal")));
                tbl.Columns.Add(new DataColumn("RutaImagen", System.Type.GetType("System.String")));


                foreach (Producto item in ((List<Producto>)this.Session["Carrito"]))
                {
                    DataRow row = tbl.NewRow();
                    row["Producto"] = item.Nombre;
                    row["Marca"] = item.Marca;
                    row["Precio"] = item.Precio;
                    row["RutaImagen"] = item.RutaImagen;
                    tbl.Rows.Add(row);
                }

                grdCarrito.DataSource = tbl;
            }
        }

        protected void grdCarrito_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[6].Visible = false;
        }
    }
}
