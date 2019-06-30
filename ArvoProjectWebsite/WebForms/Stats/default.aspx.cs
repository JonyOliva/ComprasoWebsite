using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicadeNegocio;
using Entidad;

namespace ArvoProjectWebsite.WebForms.Reportes
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rellenarFechas();
                rellenarIngresosPorAnio();
                rellenarVentasPorMes();
            }
        }

        void rellenarFechas()
        {
            gestionVentas gv = new gestionVentas();
            foreach (DateTime item in gv.getFechasVentas())
            {
                ddlFecha.Items.Add(item.Month + "/" + item.Year);
                if (ddlAnio.Items.FindByValue(item.Year.ToString()) == null)
                {
                    ddlAnio.Items.Add(item.Year.ToString());
                }
            }
            ddlFecha.DataBind();


        }
                            
        void rellenarVentasPorMes()
        {
            string fecha = ddlFecha.SelectedValue;
            gestionVentas gp = new gestionVentas();
            gp.statsCantidadProdVendidos(StatsProdVentas.Series[0], fecha);

            float Total = gp.statsTotalEnVentas(fecha);
            lblTotalMes.Text = "El total de ventas del " + fecha + " es de $" + Utilidades.precioaMostar(Total);
        }

        void rellenarIngresosPorAnio()
        {
            int anio = Convert.ToInt32(ddlAnio.SelectedValue);
            gestionVentas gv = new gestionVentas();
            gv.statsIngresos(StatsVentasAnio.Series[0], anio.ToString());

            lblTotalAnio.Text = "El total de ingresos del " + anio + " es de $" + Utilidades.precioaMostar(gv.statsTotalEnVentas(anio));
        }

        protected void ddlFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            rellenarVentasPorMes();
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            rellenarIngresosPorAnio();
        }
    }
}