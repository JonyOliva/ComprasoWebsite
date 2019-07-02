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
                //ddlFechaVent.Items.Add(item.ToString("MM/yyyy")); //item.Month + "/" + item.Year
                //ddlFechaEnv.Items.Add(item.ToString("MM/yyyy"));
                if (ddlAnio.Items.FindByValue(item.Year.ToString()) == null)
                {
                    ddlAnio.Items.Add(item.Year.ToString());
                }
                if (ddlEnviosAnio.Items.FindByValue(item.Year.ToString()) == null)
                {
                    ddlEnviosAnio.Items.Add(item.Year.ToString());
                }
                if (ddlVentAnio.Items.FindByValue(item.Year.ToString()) == null)
                {
                    ddlVentAnio.Items.Add(item.Year.ToString());
                }
            }
            cargarFechaMeses(ddlEnviosMes.Items, ddlEnviosAnio.SelectedValue);
            cargarFechaMeses(ddlVentMes.Items, ddlVentAnio.SelectedValue);
        }

        void cargarFechaMeses(ListItemCollection items, string _anio)
        {
            items.Clear();
            int anio = Convert.ToInt32(_anio);
            gestionVentas gv = new gestionVentas();
            foreach (DateTime item in gv.getFechasVentas())
            {
                if(item.Year == anio)
                {
                    items.Add(item.Month.ToString());
                }
            }
        }

        void rellenarVentasPorMes()
        {
            string fecha = ddlVentMes.SelectedValue + "/" + ddlVentAnio.SelectedValue;
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
            if(ddlEnviosMes.SelectedValue == null)
            {
                cargarFechaMeses(ddlEnviosMes.Items, ddlEnviosAnio.SelectedValue);
            }
            string fecha = ddlEnviosMes.SelectedValue + "/" + ddlVentAnio.SelectedValue;
            gestionVentas gv = new gestionVentas();
            gv.statsEnvios(ChEnvios.Series[0], fecha);
        }

        void rellenarCategorias()
        {
            string fecha = ddlVentMes.SelectedValue + "/" + ddlVentAnio.SelectedValue;
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
            string fecha = ddlVentMes.SelectedValue + "/" + ddlVentAnio.SelectedValue;
            gestionVentas gp = new gestionVentas();
            foreach (DataRow item in gp.statsSubcategorias(fecha, idcat).Rows)
            {
                ChSubcategorias.Series[0].Points.AddXY(item[0], item[1]);
            }
        }

        protected void ddlFechaEnv_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChEnvios.Series[0].Points.Clear();
            rellenarEnvios();
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChVentasAnio.Series[0].Points.Clear();
            rellenarIngresosPorAnio();
        }

        protected void ddlVentMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChProdVentas.Series[0].Points.Clear();
            ChCategorias.Series[0].Points.Clear();
            rellenarVentasPorMes();
            rellenarCategorias();
        }

        protected void ddlVentAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarFechaMeses(ddlVentMes.Items, ddlVentAnio.SelectedValue);
            ddlVentMes_SelectedIndexChanged(new object(), new EventArgs());
        }

        protected void ddlEnviosAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarFechaMeses(ddlEnviosMes.Items, ddlEnviosAnio.SelectedValue);
            ddlFechaEnv_SelectedIndexChanged(new object(), new EventArgs());
        }
    }
}