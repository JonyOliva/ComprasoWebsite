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
                    btnComprar.CommandArgument = prodActual.IDProducto;

                    lblStock.Text = prodActual.Stock + " unidades disponibles!";
                    lblPrecioFinal.Text = "$" + Utilidades.precioaMostar(Utilidades.getPrecioConDescuento(prodActual.Precio, prodActual.Descuento));
                    lblNomProd.Text = prodActual.Nombre;
                    lblDescrip.Text = prodActual.Descripcion.Trim();
                    imgPrincipal.ImageUrl = prodActual.RutaImagen.Trim();
                    imgPrincipal.DataBind();

                    if(prodActual.Descuento > 0)
                    {
                        lblPrecio.Visible = true;
                        lblPrecio.Text = "Precio anterior $" + prodActual.Precio;
                        lblDesc.Visible = true;
                        lblDesc.Text = prodActual.Descuento + " %OFF!";
                    }
                }
                else
                {
                    Server.Transfer("/default.aspx");
                }
                
            }
        }

        protected void lbtnAñadircarr_Command(object sender, CommandEventArgs e)
        {
            List<Producto> carrito = new List<Producto>();
            gestionProductos gp = new gestionProductos();
            if (this.Session["Carrito"] != null)
            {
                carrito = (List<Producto>)this.Session["Carrito"];
                carrito.Add(gp.getProducto(e.CommandArgument.ToString()));
                this.Session["Carrito"] = carrito;
            }
            else
            {

                carrito.Add(gp.getProducto(e.CommandArgument.ToString()));
                this.Session["Carrito"] = carrito;
            }
        }
    }
}