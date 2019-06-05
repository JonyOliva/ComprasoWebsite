using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using CapaLogicadeNegocio;

namespace ArvoProjectWebsite.WebForms
{
    public partial class frmCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            llenarTarjetas();
            llenarCuotas();
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
    }
}