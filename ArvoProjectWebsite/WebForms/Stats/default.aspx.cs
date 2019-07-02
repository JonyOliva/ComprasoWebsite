using System;
using System.Collections.Generic;
using System.Data;
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
                rellenarCategorias();
                rellenarEnvios();
            }
        }

        void rellenarFechas()
        {
            gestionVentas gv = new gestionVentas();
            foreach (DateTime item in gv.getFechasVentas())
            {
                ddlFechaVent.Items.Add(item.ToString("MM/yyyy")); //item.Month + "/" + item.Year
                ddlFechaEnv.Items.Add(item.ToString("MM/yyyy"));
                if (ddlAnio.Items.FindByValue(item.Year.ToString()) == null)
                {
                    ddlAnio.Items.Add(item.Year.ToString());
                }
            }
            ddlFechaVent.DataBind();
            ddlFechaEnv.DataBind();
            ddlAnio.DataBind();
        }
                            
        void rellenarVentasPorMes()
        {
            string fecha = ddlFechaVent.SelectedValue;
            gestionVentas gp = new gestionVentas();
            gp.statsCantidadProdVendidos(ChProdVentas.Series[0], fecha);

            float Total = gp.statsTotalEnVentas(fecha);
            lblTotalMes.Text = "El total de ventas del " + fecha + " es de $" + Utilidades.precioaMostar(Total);
        }

        void rellenarIngresosPorAnio()
        {
            int anio = Convert.ToInt32(ddlAnio.SelectedValue);
            gestionVentas gv = new gestionVentas();
            gv.statsIngresos(ChVentasAnio.Series[0], anio.ToString());

            lblTotalAnio.Text = "El total de ingresos del " + anio + " es de $" + Utilidades.precioaMostar(gv.statsTotalEnVentas(anio));
        }

        void rellenarEnvios()
        {
            string fecha = ddlFechaEnv.SelectedValue;
            gestionVentas gv = new gestionVentas();
            gv.statsEnvios(ChEnvios.Series[0], fecha);
        }

        void rellenarCategorias()
        {
            string fecha = ddlFechaVent.SelectedValue;
            gestionVentas gp = new gestionVentas();
            DataTable data = gp.statsCategorias(fecha);
            List<int> cantCats = new List<int>();
            List<string> idcats = new List<string>();
            foreach (DataRow item in data.Rows)
            {
                cantCats.Add((int)item[1]);
                idcats.Add(item[2].ToString());
                ChCategorias.Series[0].Points.AddXY(item[0], item[1]);
            }
            ChSubcategorias.Series[0].Points.Clear();
            var max = cantCats.Max();
            int indice = Array.IndexOf(cantCats.ToArray(), max);
            rellenarSubcategorias(idcats[indice]);
        }

        void rellenarSubcategorias(string idcat)
        {
            string fecha = ddlFechaVent.SelectedValue;
            gestionVentas gp = new gestionVentas();
            foreach (DataRow item in gp.statsSubcategorias(fecha, idcat).Rows)
            {
                ChSubcategorias.Series[0].Points.AddXY(item[0], item[1]);
            }
        }

        protected void ddlFecha_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChProdVentas.Series[0].Points.Clear();
            ChCategorias.Series[0].Points.Clear();
            rellenarVentasPorMes();
            rellenarCategorias();
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChVentasAnio.Series[0].Points.Clear();
            rellenarIngresosPorAnio();
        }

        protected void ddlFechaEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChEnvios.Series[0].Points.Clear();
            rellenarEnvios();
        }
    }
}