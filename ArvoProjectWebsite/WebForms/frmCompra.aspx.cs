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
        float suma=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            suma = 0;
            grdCompra.DataSource = (DataTable)this.Session["Compras"];
            grdCompra.DataBind();
            if(this.Application["Usuario"] == null)
            {
                Response.Redirect("frmLogin.aspx");
            }
            
            if(!IsPostBack)
            {
                iniciarMensajeserror();
                rellenarTarxusu();
                llenarTarjetas();
                llenarCuotas();
                llenarDirecciones();
            }
            if(IsPostBack)
            {
                habilitarTxttarjeta();
                validacionesBtnCompras();
            }
            mostrarPrecioenvio();
            mostrarCostototal();
        }

        protected void ddlMetodopago_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarCuotas();
        }

        public void llenarTarjetas()
        {
            ddlMetodopago.DataSource = LogicaCompra.rellenarMetodos();
            ddlMetodopago.Items.Insert(0, "<Seleccione tarjeta>");
            ddlMetodopago.AppendDataBoundItems = true;
            ddlMetodopago.DataTextField = "Nombre_TARJ";
            ddlMetodopago.DataValueField = "IDTarjeta_TARJ";
            ddlMetodopago.DataBind();
            ddlMetodopago.SelectedIndex = 0;
            if(ddlIndextarxus())
            {
                ddlMetodopago.SelectedValue = ddlTarxu.SelectedValue;
                ddlMetodopago.Enabled = false;
            }
            else
            {
                ddlMetodopago.Enabled = true;
            }

        }

        public void llenarCuotas()
        {
            if(ddlIndexmetodos())
            {
                string index = ddlMetodopago.SelectedValue.ToString();
                ddlCuotas.Items.Clear();
                ddlCuotas.DataSource = LogicaCompra.rellenarCuotas(index);
                ddlCuotas.Items.Insert(0, "<Seleccione cuotas>");
                ddlCuotas.AppendDataBoundItems = true;
                ddlCuotas.DataTextField = "Metodo";
                ddlCuotas.DataValueField = "IDCuota_CUO";
                ddlCuotas.DataBind();
            }
        }
         protected void llenarDirecciones()
        {
            if(this.Application["Usuario"] != null)
            {
                string id = ((Usuario)this.Application["Usuario"]).IDUsuario;
                ddlDireccion.DataSource = LogicaCompra.rellenarDirecciones(id);
                ddlDireccion.DataValueField = "CodDirreccion";
                ddlDireccion.DataTextField = "Direccion_DIR";
                ddlDireccion.Items.Insert(0, "<Seleccione Direccion>");
                ddlDireccion.AppendDataBoundItems = true;
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
            if (txtNrotarjeta.Text == string.Empty)
            {
                ddlTarxu.Enabled = true;
            }
            else
            {
                ddlTarxu.Enabled = false;
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
            if(validacionesBtnCompras())
            {
                registroVenta();
                detalleVenta();
                this.Session.Abandon();
                Response.Redirect("/default.aspx");
            }
        }

        protected void detalleVenta()
        {
            foreach (DataRow item in ((DataTable)this.Session["Compras"]).Rows)
            {
                LogicaCompra.insertarDetVenta(item);
            }
        }

        protected void registroVenta()
        {
            if(ddlIndexdireccion() && ddlIndexcuotas())
            {
                Ventas venta = new Ventas();
                venta.IDUsuario1 = ((Usuario)this.Application["Usuario"]).IDUsuario;
                venta.CodDireccion = int.Parse(ddlDireccion.SelectedValue.ToString());
                venta.Total = LogicaCompra.costoTotal(suma, LogicaCompra.getInteres(ddlCuotas.SelectedValue),
                    float.Parse(LogicaCompra.recuperarEnvio(ddlDireccion.SelectedValue)[1].ToString()));
                venta.IdEnvio = LogicaCompra.recuperarEnvio(ddlDireccion.SelectedValue)[0].ToString();
                venta.EstadoEnvio = 0;
                venta.Descuento = 0;
                if (ddlIndextarxus())
                    venta.NroTarjeta = ddlTarxu.Text;
                else if (txtNrotarjeta.Text != string.Empty)
                    venta.NroTarjeta = txtNrotarjeta.Text;

                LogicaCompra.insertarVenta(venta);
            }
        }

        protected void ddlDireccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            mostrarPrecioenvio();
        }

        protected void lbtnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/default.aspx");
        }

        protected void grdCompra_RowCreated(object sender, GridViewRowEventArgs e)
        {

        }
        protected bool rellenarTarxusu()
        {
            DataTable tbl = new DataTable();
            tbl = LogicaCompra.tarjxUsu((Usuario)this.Application["Usuario"]);
            if (tbl.Rows.Count > 0)
            {
                ddlTarxu.Items.Insert(0, "<Seleccione tarjeta>");
                ddlTarxu.AppendDataBoundItems = true;
                ddlTarxu.DataSource = tbl;
                ddlTarxu.DataTextField = "Nro Tarjeta";
                ddlTarxu.DataValueField = "Codigo";
                ddlTarxu.SelectedIndex = 0;
                ddlTarxu.DataBind();
                return true;
            }
            else
            {
                ddlTarxu.Visible = false;
                return false;
            }
        }

        protected void habilitarTxttarjeta()
        {
            if(ddlTarxu.SelectedIndex == 0 )
            {
                txtNrotarjeta.Enabled = true;
            }
            else
            {
                txtNrotarjeta.Enabled = false;
            }
        }

        protected void txtNrotarjeta_Load(object sender, EventArgs e)
        {

        }

        protected bool validacionesBtnCompras()
        {
            bool bandera = true;
            if (!ddlIndexmetodos())
            {
                bandera = false;
                lblErrormetodo.Visible = true;
            }
            else lblErrormetodo.Visible = false;
            if (!ddlIndexcuotas())
            {
                bandera = false;
                lblErrorncuota.Visible = true;
            }
            else lblErrorncuota.Visible = false;
            if(!ddlIndextarxus() && txtNrotarjeta.Text == string.Empty)
            {
                bandera = false;
                lblErrorntartarus.Visible = true;
                lblErrorntar.Visible = true;
            }
            else
            {
                lblErrorntar.Visible = false;
                lblErrorntartarus.Visible = false;
            }
            if(!ddlIndexdireccion())
            {
                bandera = false;
                lblErrorDire.Visible = true;
            }
            else lblErrorDire.Visible = false;
            if (LogicaCompra.verificarTarjeta(txtNrotarjeta.Text))
            {
                lblErrorntar.Visible = false;
            }
            else lblErrorntar.Visible = true;
            if(ddlIndextarxus() && txtNrotarjeta.Text == string.Empty)
            {
                lblErrorntar.Visible = false;
            }else lblErrorntar.Visible = true;
            
            return bandera;
        }

        protected void iniciarMensajeserror()
        {
            lblErrorntartarus.Visible = false;
            lblErrorncuota.Visible = false;
            lblErrorntar.Visible = false;
            lblErrorDire.Visible = false;
            lblErrormetodo.Visible = false;
        }

        protected void ddlTarxu_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMetodopago.SelectedValue = ddlTarxu.SelectedValue;
            llenarCuotas();
            ddlMetodopago.DataBind();
        }

        protected bool ddlIndexcuotas()
        {
            if (ddlCuotas.SelectedIndex != 0)
                return true;
            else return false;
        }
        protected bool ddlIndexmetodos()
        {
            if (ddlMetodopago.SelectedIndex != 0)
                return true;
            else return false;
        }
        protected bool ddlIndextarxus()
        {
            if (ddlTarxu.SelectedIndex != 0)
                return true;
            else return false;
        }
        protected bool ddlIndexdireccion()
        {
            if (ddlDireccion.SelectedIndex != 0)
                return true;
            else return false;
        }

        protected void mostrarCostototal()
        {
            if (ddlIndexcuotas() && ddlIndexdireccion())
            {
                lblCostoTotal.Text = "$ " + LogicaCompra.costoTotal(suma, LogicaCompra.getInteres(ddlCuotas.SelectedValue)
                    , float.Parse(LogicaCompra.recuperarEnvio(ddlDireccion.SelectedValue)[1].ToString())).ToString();
            }
        }

        protected void mostrarPrecioenvio()
        {
            if (ddlIndexcuotas() && ddlIndexdireccion())
            {
                lblPrecioEnvio.Text = "$ " + LogicaCompra.recuperarEnvio(ddlDireccion.SelectedValue)[1].ToString();
                lblPrecioEnvio.DataBind();
            }
        }
    
    }
}