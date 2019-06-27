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
            sesion = new gestorSesion(InicSec, Cuenta, CerrSec);
            if (!IsPostBack)
            {
                sesion.comprobarSesion();
            }

        }

        protected void lnkSeguircom_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this.Page, this.GetType(), "fecha", "fechavto();", true);
            if (LogicaCompra.verificarstringFecha(vencimiento.Value) && vencimiento.Value == "dd/mm/aaaa")
            {
                Response.Write("<script language=javascript>alert('Tarjeta guardada con éxito.');</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('Formato de texto incorrecto.');</script>");
            
            }
            //Response.Redirect("frmListaProductos.aspx");
        }

        protected void lnkComprar_Click(object sender, EventArgs e)
        {
            int pos = actualizarCantidades();
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
                
                this.Session["Compras"] = null;
                if (this.Session["Compras"] == null)
                {
                    this.Session["Compras"] = LogicaCarrito.crearCompra();
                }
                LogicaCarrito.cargarCompras((DataTable)this.Session["Compras"]
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
            string prueba = e.Row.Cells[7].Text;
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                if(prueba != null && prueba != "&nbsp")
                {
                    ((TextBox)e.Row.FindControl("txtCantidad")).Text = 
                        e.Row.Cells[7].Text;
                }
            }
        }

        protected void grdCarrito_Sorting(object sender, GridViewSortEventArgs e)
        {

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
                string texto = ((TextBox)grdCarrito.Rows[i].FindControl("txtCantidad")).Text;
                if (texto == null || Utilidades.validarString(texto, false, true, true))
                {
                    pos++;
                }
                else
                {
                    ((DataTable)this.Session["Carrito"]).Rows[i][4] = int.Parse(texto);
                }

            }
            return pos;
        }

        protected void grdCarrito_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }

        protected void lnkSeguircom_PreRender(object sender, EventArgs e)
        {
        }
    }
}
