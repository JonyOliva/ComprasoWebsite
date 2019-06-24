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
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarTarjetas();
            llenarCuotas();
            llenarDirecciones();
            grdCompra.DataSource = (DataTable)this.Session["Compras"];
            grdCompra.DataBind();
        }

        protected void ddlMetodopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCuotas();
        }

        public void llenarTarjetas()
        {
            gestionMetodoPago mp = new gestionMetodoPago();
            DataTable tbl = new DataTable();
            tbl = mp.getTarjetas();
            ddlMetodopago.DataSource = tbl;
            ddlMetodopago.DataTextField = "Nombre_TARJ";
            ddlMetodopago.DataValueField = "IDTarjeta_TARJ";
            ddlMetodopago.DataBind();
        }

        public void llenarCuotas()
        {
            gestionMetodoPago mp = new gestionMetodoPago();
            DataTable tbl = new DataTable();
            tbl = mp.getMetodosdepago(ddlMetodopago.SelectedValue.ToString());
            ddlCuotas.DataSource = tbl;
            ddlCuotas.DataTextField = "Metodo";
            ddlCuotas.DataValueField = "IDCuota_CUO";
            ddlCuotas.DataBind();
        }
         protected void llenarDirecciones()
        {
            gestionUsuarios gu = new gestionUsuarios();
            DataTable tbl = new DataTable();
            if(this.Application["Usuario"] != null)
            {
                string id = ((Usuario)this.Application["Usuario"]).IDUsuario;
                tbl = gu.getListaDirecxUsuario(id);
                ddlDireccion.DataSource = tbl;
                ddlDireccion.DataValueField = "CodDirreccion";
                ddlDireccion.DataTextField = "Direccion_DIR";
                ddlDireccion.SelectedIndex = 0;
                ddlDireccion.DataBind();
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[5].Visible = false;
            e.Row.Cells[6].Visible = false;
            e.Row.Cells[7].Visible = false;
            grdCompra.Columns[1].FooterText = "Total: $" + sumaTotal().ToString();

        }

        protected void txtNrotarjeta_TextChanged(object sender, EventArgs e)
        {
            if(Utilidades.validarString(txtNrotarjeta.Text,false,true,true) || txtNrotarjeta.Text == null)
            {
                txtNrotarjeta.Text = "0";
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
            detalleVenta();
            registroVenta();
            this.Session.Abandon();
            Response.Redirect("default.aspx");
        }

        protected void detalleVenta()
        {
            DetalleVentas detVenta = new DetalleVentas();
            gestionVentas gv = new gestionVentas();
            gestionProductos gp = new gestionProductos();
            foreach (DataRow item in ((DataTable)this.Session["Compras"]).Rows)
            {
                detVenta.Cantidad = int.Parse(item[1].ToString());
                detVenta.IDProducto1 = item[3].ToString();
                detVenta.PrecioUnitario = float.Parse(item[2].ToString());
                detVenta.Descuento = gp.getProducto(item[3].ToString()).Descuento;
                detVenta.IDVenta1 = (gv.recuperarIdventa()+1).ToString();
                gv.insertarDetalleventas(detVenta);
            }

        }

        protected void registroVenta()
        {
            Ventas venta = new Ventas();
            gestionVentas gv = new gestionVentas();
            gestionUsuarios gu = new gestionUsuarios();
            venta.IDUsuario1 = ((Usuario)this.Application["Usuario"]).IDUsuario;
            venta.CodDireccion = int.Parse(ddlDireccion.SelectedValue.ToString());
            venta.NroTarjeta = txtNrotarjeta.Text;
            venta.Total = sumaTotal();
            venta.IdEnvio = gu.idenvioxUsuario(ddlDireccion.SelectedValue)[0].ToString();
            venta.EstadoEnvio = 1;
            venta.Descuento = 0;
            gv.insertarVenta(venta);
        }

        protected void ddlDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            gestionUsuarios gu = new gestionUsuarios();
            lblPrecioEnvio.Text = gu.idenvioxUsuario(ddlDireccion.SelectedValue)[1].ToString();
            
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx");
        }
    }
}