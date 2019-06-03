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
    public partial class frmListaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e) //ESTE FORM SE CONECTA CON LA BD DEL SERVIDOR
        {
            if (!IsPostBack)
            {
                
            }
        }
        //void botom_carrito(string idproducto) //BOTO DE AÑADIR AL CARRITO
        //{
        //    List<Producto> carrito = new List<Producto>();
        //    gestionProductos gp = new gestionProductos();
        //    if (this.Session["Carrito"] != null)
        //    {
        //        carrito = (List<Producto>)this.Session["Carrito"];
        //        carrito.Add(gp.getProducto(idproducto));
        //        this.Session["Carrito"] = carrito;
        //    }
        //    else
        //    {
        //        carrito.Add(gp.getProducto(idproducto));
        //        this.Session["Carrito"] = carrito;
        //    }
        //}
    }
}
