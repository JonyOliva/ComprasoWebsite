using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicadeNegocio;

namespace ArvoProjectWebsite.WebForms.Reportes
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                gestionVentas gv = new gestionVentas();
                ddlFecha.DataValueField = "Fecha_Venta";
                ddlFecha.DataSource = gv.getFechasVentas();
                ddlFecha.DataBind();
            }
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            MultiViewStats.ActiveViewIndex = 0;
            gestionProductos gp = new gestionProductos();
            gp.statsCantidadProdVendidos(StatsProdVentas.Series[0]);

        }
    }
}