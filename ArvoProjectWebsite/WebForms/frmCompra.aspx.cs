using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CapaLogicadeNegocio;
using Entidad;

namespace ArvoProjectWebsite.WebForms
{
    public partial class frmCompra : System.Web.UI.Page
    {
        LogicaCompra lc = new LogicaCompra();
        float
            suma=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            suma = 0;
            if(this.Application["Usuario"] == null)
            {
                Response.Redirect("frmLogin.aspx");
            }
            grdCompra.DataSource = (DataTable)this.Session["Compras"];
            grdCompra.DataBind();
            if(!IsPostBack)
            {
                llenarTarjetas();
                llenarCuotas();
                llenarDirecciones();
                lblPrecioEnvio.Text ="$" + (lc.recuperarEnvio(ddlDireccion.SelectedValue)[1]).ToString();
                lblError.Visible = false;
            }
            if(IsPostBack)
            {

            }
            
            lblCostoTotal.Text ="$ "+ lc.costoTotal(suma, lc.getInteres(ddlCuotas.SelectedValue)
                ,float.Parse(lc.recuperarEnvio(ddlDireccion.SelectedValue)[1].ToString())).ToString();
            
        }

        protected void ddlMetodopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCuotas();
        }

        public void llenarTarjetas()
        {
            ddlMetodopago.DataSource = lc.rellenarMetodos();
            ddlMetodopago.DataTextField = "Nombre_TARJ";
            ddlMetodopago.DataValueField = "IDTarjeta_TARJ";
            ddlMetodopago.DataBind();
        }

        public void llenarCuotas()
        {
            string index = ddlMetodopago.SelectedValue.ToString();
            ddlCuotas.DataSource = lc.rellenarCuotas(index);
            ddlCuotas.DataTextField = "Metodo";
            ddlCuotas.DataValueField = "IDCuota_CUO";
            ddlCuotas.DataBind();
        }
         protected void llenarDirecciones()
        {
            if(this.Application["Usuario"] != null)
            {
                string id = ((Usuario)this.Application["Usuario"]).IDUsuario;
                ddlDireccion.DataSource = lc.rellenarDirecciones(id);
                ddlDireccion.DataValueField = "CodDirreccion";
                ddlDireccion.DataTextField = "Direccion_DIR";
                ddlDireccion.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            if (e.Row.Cells[1].Text != null && e.Row.Cells[1].Text != "Total: $" + suma.ToString() &&
                e.Row.Cells[1].Text != "Total:" && e.Row.Cells[1].Text != "Subtotal")
            {
                string prueba = e.Row.Cells[1].Text;
                suma += float.Parse(e.Row.Cells[1].Text);
            }
                
            grdCompra.Columns[1].FooterText = "Total: $" + suma.ToString();
        }

        protected void txtNrotarjeta_TextChanged(object sender, EventArgs e)
        {
            if (!lc.verificarTarjeta(txtNrotarjeta.Text) || txtNrotarjeta.Text == string.Empty)
            {
                lblError.Visible = true;
            }
            else
            {
                lblError.Visible = false;
            }
        }

        protected float sumaTotal ()
        {
            float suma = 0;
            foreach (GridViewRow item in grdCompra.Rows)
            {
                string prueba = item.Cells[1].Text;
                suma += float.Parse(prueba);
            }
            return suma;
        }

        protected void lbtnComprar_Click(object sender, EventArgs e)
        {
            
            if(lblError.Visible == false && txtNrotarjeta.Text != string.Empty)
            {
                registroVenta();
                detalleVenta();
                this.Session.Abandon();
                Response.Redirect("/default.aspx");
            }
            else
            {
                lblError.Visible = true;
            }
            
        }

        protected void detalleVenta()
        {
            foreach (DataRow item in ((DataTable)this.Session["Compras"]).Rows)
            {
                lc.insertarDetVenta(item);
            }
        }

        protected void registroVenta()
        {
            Ventas venta = new Ventas();
            venta.IDUsuario1 = ((Usuario)this.Application["Usuario"]).IDUsuario;
            venta.CodDireccion = int.Parse(ddlDireccion.SelectedValue.ToString());
            venta.NroTarjeta = txtNrotarjeta.Text;
            venta.Total = sumaTotal();
            venta.IdEnvio = lc.recuperarEnvio(ddlDireccion.SelectedValue)[0].ToString();
            venta.EstadoEnvio = 0;
            venta.Descuento = 0;

            lc.insertarVenta(venta);
        }

        protected void ddlDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblPrecioEnvio.Text ="$ "+ lc.recuperarEnvio(ddlDireccion.SelectedValue)[1].ToString();
            lblPrecioEnvio.DataBind();
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/default.aspx");
        }

        protected void grdCompra_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }
    }
}