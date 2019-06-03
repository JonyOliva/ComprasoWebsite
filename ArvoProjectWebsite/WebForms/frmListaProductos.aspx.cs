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
                llenarFiltroMarcas();
                llenarFiltroCategorias();
                llenarFiltroSubCats();
            }
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCarrito.aspx");
	    }

        void llenarFiltroMarcas()
        {
            gestionProductos gp = new gestionProductos();
            rblMarcas.DataValueField = "IDMarca";
            rblMarcas.DataTextField = "Nombre_MARCA";
            rblMarcas.DataSource = gp.getListaMarcas();
            rblMarcas.DataBind();
        }
        void llenarFiltroCategorias()
        {
            gestionProductos gp = new gestionProductos();
            rblCat.DataValueField = "IDCategoria";
            rblCat.DataTextField = "Nombre_CAT";
            rblCat.DataSource = gp.getListaCategorias();
            rblCat.DataBind();
        }
        void llenarFiltroSubCats()
        {
            gestionProductos gp = new gestionProductos();
            rblSubCat.DataValueField = "IDSubCategoria";
            rblSubCat.DataTextField = "Nombre_SUBCAT";
            rblSubCat.DataSource = gp.getListaSubCategorias();
            rblSubCat.DataBind();
        }
    }
}
