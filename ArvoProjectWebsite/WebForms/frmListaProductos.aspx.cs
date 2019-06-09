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
                if (Session["filtroCategoria"] == null)
                {
                    Server.Transfer("/default.aspx");
                }

                llenarFiltroMarcas();
                llenarFiltroSubCats();
                llenarFiltroCats();
                ddlCat.SelectedValue = Session["filtroCategoria"].ToString();
            }
            else
            {
                int opc = ddlOrdenar.SelectedIndex;
                switch (opc)
                {
                    case 1:
                        sqldataProductos.SelectCommand += "ORDER BY Precio_PROD ASC";
                        break;
                    case 2:
                        sqldataProductos.SelectCommand += "ORDER BY Precio_PROD DESC";
                        break;
                }
                lstViewProductos.DataBind();
            }
        }

        protected void InicSec_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/frmLogin.aspx");
        }

        protected void Carrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/frmCarrito.aspx");
        }

        protected void item_Command(object sender, CommandEventArgs e)
        {
            Session["filtroCategoria"] = e.CommandArgument;
            Response.Redirect("/WebForms/frmListaProductos.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCarrito.aspx");
	    }

        void llenarFiltroMarcas()
        {
            gestionProductos gp = new gestionProductos();
            ddlMarcas.DataValueField = "IDMarca";
            ddlMarcas.DataTextField = "Nombre_MARCA";
            ddlMarcas.DataSource = gp.getListaMarcas();
            ddlMarcas.Items.Add(new ListItem("", "-1"));
            ddlMarcas.DataBind();
            ddlMarcas.Items.Insert(0, new ListItem("", "-1"));
        }

        void llenarFiltroSubCats()
        {
            gestionProductos gp = new gestionProductos();
            ddlSubCat.DataValueField = "IDSubCategoria";
            ddlSubCat.DataTextField = "Nombre_SUBCAT";
            ddlSubCat.DataSource = gp.getListaSubCategorias();
            ddlSubCat.Items.Add(new ListItem("", "-1"));
            ddlSubCat.DataBind();
            ddlSubCat.Items.Insert(0, new ListItem("", "-1"));
        }

        void llenarFiltroCats()
        {
            gestionProductos gp = new gestionProductos();
            ddlCat.DataValueField = "IDCategoria";
            ddlCat.DataTextField = "Nombre_CAT";
            ddlCat.DataSource = gp.getListaCategorias();
            ddlCat.DataBind();
            ddlCat.Items.Insert(0, new ListItem("", "-1"));
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

        protected void imgProducto_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("frmProducto.aspx?IDProd=" + e.CommandArgument);
        }

        protected void btnSinFiltro_Click(object sender, EventArgs e)
        {
            ddlCat.SelectedIndex = 0;
            ddlSubCat.SelectedIndex = 0;
            ddlMarcas.SelectedIndex = 0;
        }
    }
}
