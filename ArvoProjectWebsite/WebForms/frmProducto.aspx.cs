using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using CapaLogicadeNegocio;
using System.Data;

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
                if (this.Session["Carrito"] == null)
                {
                    this.Session["Carrito"] = LogicaCarrito.crearTablacarrito();
                }

            }
        }

        protected void lbtnAñadircarr_Command(object sender, CommandEventArgs e)
        {
            gestionProductos gp = new gestionProductos();
            LogicaCarrito.añadirCarrito((DataTable)this.Session["Carrito"]
                , gp.getProducto(e.CommandArgument.ToString()));

            Server.Transfer("/WebForms/frmCarrito.aspx", false);
        }
    }
}