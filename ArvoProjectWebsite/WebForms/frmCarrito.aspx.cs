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
            if (!IsPostBack)
                actualizarCarrito();

            if (this.Session["Compras"] == null)
            {
                this.Session["Compras"] = crearCompra();
            }

            sesion = new gestorSesion(InicSec, Cuenta, CerrSec);
            if (!IsPostBack)
            {
                sesion.comprobarSesion();
            }

        }

        protected void lnkSeguircom_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmListaProductos.aspx");
        }

        protected void lnkComprar_Click(object sender, EventArgs e)
        {
            int pos = actualizarCantidades();
            //for (int i = 0; i < grdCarrito.Rows.Count; i++)
            //{
            //    ((TextBox)grdCarrito.Rows[i].FindControl("txtCantidad")).DataBind();
            //    if (((TextBox)grdCarrito.Rows[i].FindControl("txtCantidad")).Text != null &&
            //        ((TextBox)grdCarrito.Rows[i].FindControl("txtCantidad")).Text != string.Empty)
            //    {
            //        string prueba = ((TextBox)grdCarrito.Rows[i].FindControl("txtCantidad")).Text;
            //        int cant = int.Parse(prueba);
            //        if (cant < 1 || Utilidades.validarString(prueba, false, true, true))
            //            pos++;

            //        ((DataTable)this.Session["Carrito"]).Rows[i][4] = cant;
            //    }

            //}
            if (grdCarrito == null)
            {
                Response.Write("<script language=javascript>alert('No posee productos en el carrito');</script>");
            }
            else if (pos != 0)
            {
                Response.Write("<script language=javascript>alert('Valor incorrecto en campo cantidad');</script>");
            }
            else
            {
                cargarCompras((DataTable)this.Session["Compras"]
                        , (DataTable)this.Session["Carrito"]);
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
            DataTable tblcompras = new DataTable();
            tblcompras = (DataTable)this.Session["Compras"];
            if (pos < tbl.Rows.Count && pos >= 0)
            {
                tbl.Rows.RemoveAt(pos);
                if(tbl.Rows.Count != 0)
                    tblcompras.Rows.RemoveAt(pos);
            }

            if (tbl.Rows.Count == 0)
            {
                tbl = null;
                this.Session["Compras"] = null;
            }

        }

        public void actualizarCarrito()
        {
            if (this.Session["Carrito"] == null || ((DataTable)this.Session["Carrito"]).Rows.Count == 0)
            {
                lnkComprar.Enabled = false;
                lblNocarrito.Visible = true;
            }
            else
            {
                lnkComprar.Enabled = true;
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

        protected void item_Command(object sender, CommandEventArgs e)
        {
            Session["filtroCategoria"] = e.CommandArgument;
            Response.Redirect("/WebForms/frmListaProductos.aspx");
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

        public void cargarCarrito()
        {
            grdCarrito.DataSource = (DataTable)this.Session["Carrito"];
        }

        protected void grdCarrito_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            e.Row.Cells[8].Visible = false;
        }

        protected void grdCarrito_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void cargarCompras(DataTable tblcompras, DataTable tblcarrito)
        {
            for (int i = 0; i < grdCarrito.Rows.Count; i++)
            {
                DataRow row = tblcompras.NewRow();
                string prueba = tblcarrito.Rows[i][4].ToString();
                row["Cantidad"] = int.Parse(prueba);
                row["Producto"] = tblcarrito.Rows[i][0].ToString();
                row["RutaImagen"] = tblcarrito.Rows[i][3].ToString();
                row["IDProducto"] = tblcarrito.Rows[i][5].ToString();
                row["Precio"] = decimal.Parse(tblcarrito.Rows[i][2].ToString());
                row["Subtotal"] = 
                    int.Parse(prueba) * decimal.Parse(tblcarrito.Rows[i][2].ToString());


                tblcompras.Rows.Add(row);
            }

        }

        protected DataTable crearCompra()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("Producto", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Cantidad", System.Type.GetType("System.Int32")));
            tbl.Columns.Add(new DataColumn("Precio", System.Type.GetType("System.Decimal")));
            tbl.Columns.Add(new DataColumn("IDProducto", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("RutaImagen", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Subtotal", System.Type.GetType("System.Decimal")));
            return tbl;
        }

        protected void grdCarrito_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void grdCarrito_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void grdCarrito_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected int actualizarCantidades()
        {
            int pos = 0;
            for (int i = 0; i < grdCarrito.Rows.Count; i++)
            {
                ((TextBox)grdCarrito.Rows[i].FindControl("txtCantidad")).DataBind();
                if (((TextBox)grdCarrito.Rows[i].FindControl("txtCantidad")).Text != null &&
                    ((TextBox)grdCarrito.Rows[i].FindControl("txtCantidad")).Text != string.Empty)
                {
                    string prueba = ((TextBox)grdCarrito.Rows[i].FindControl("txtCantidad")).Text;
                    int cant = int.Parse(prueba);
                    if (cant < 1 || Utilidades.validarString(prueba, false, true, true))
                        pos++;

                    ((DataTable)this.Session["Carrito"]).Rows[i][4] = cant;
                }

            }
            return pos;
        }
        
    }
}
