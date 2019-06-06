using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using CapaLogicadeNegocio;

namespace ArvoProjectWebsite.WebForms
{
    public partial class frmProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string IDProducto = Request.QueryString["IDProd"];
                if (!String.IsNullOrWhiteSpace(IDProducto))
                {
                    gestionProductos gp = new gestionProductos();
                    Producto prodActual = gp.getProducto(IDProducto);
                    lblNomProd.Text = prodActual.Nombre;
                    lblDescrip.Text = prodActual.Descripcion.Trim();
                    imgPrincipal.ImageUrl = prodActual.RutaImagen.Trim();
                    imgPrincipal.DataBind();
                }
            }
        }

    }
}