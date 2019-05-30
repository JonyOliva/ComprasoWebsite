using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicadeNegocio;
using Entidad;

namespace ArvoProjectWebsite
{
    public partial class frmProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Response.Redirect("frmProducto.aspx?IDProd=" + IDProducto); asi se llama a este form
            if (!IsPostBack)
            {
                string IDProducto = Request.QueryString["IDProd"];
                if (!String.IsNullOrWhiteSpace(IDProducto))
                {
                    gestionProductos gp = new gestionProductos();
                    //Producto prodActual = gp.getProducto(IDProducto);
                    //lblContainer.Text = prodActual.Nombre + " " + prodActual.Precio;
                }
            }
        }
    }
}