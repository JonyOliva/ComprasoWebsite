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
                rellenarFechas();
            }
        }

        void rellenarFechas()
        {
            gestionVentas gv = new gestionVentas();
            foreach (DateTime item in gv.getFechasVentas())
            {
                ddlFecha.Items.Add(item.Month + "/" + item.Year);
            }
            ddlFecha.DataBind();
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            MultiViewStats.ActiveViewIndex = 0;
            gestionProductos gp = new gestionProductos();
            gp.statsCantidadProdVendidos(StatsProdVentas.Series[0]);
        }
    }
}