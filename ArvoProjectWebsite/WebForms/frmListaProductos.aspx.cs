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
                llenarFiltroCats();
                ddlCat.SelectedValue = Session["filtroCategoria"].ToString();
                llenarFiltroSubCats();
                llenarFiltroMarcas();
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
            if(ddlCat.SelectedValue != null && ddlSubCat.SelectedValue != null)
            {
                gestionProductos gp = new gestionProductos();
                ddlMarcas.DataValueField = "IDMarca";
                ddlMarcas.DataTextField = "Nombre_MARCA";
                ddlMarcas.DataSource = gp.getListaMarcas(ddlCat.SelectedValue, ddlSubCat.SelectedValue);
                ddlMarcas.DataBind();
                ddlMarcas.Items.Insert(0, new ListItem("", null));
            }
        }

        void llenarFiltroSubCats()
        {
            if (ddlCat.SelectedValue != null)
            {
                gestionProductos gp = new gestionProductos();
                ddlSubCat.DataValueField = "IDSubCategoria";
                ddlSubCat.DataTextField = "Nombre_SUBCAT";
                ddlSubCat.DataSource = gp.getListaSubCategorias(ddlCat.SelectedValue);
                ddlSubCat.DataBind();
                ddlSubCat.Items.Insert(0, new ListItem("", null));
            }
        }

        void llenarFiltroCats()
        {
            gestionProductos gp = new gestionProductos();
            ddlCat.DataValueField = "IDCategoria";
            ddlCat.DataTextField = "Nombre_CAT";
            ddlCat.DataSource = gp.getListaCategorias();
            ddlCat.DataBind();
            ddlCat.Items.Insert(0, new ListItem("", null));
        }

        void OrdenarLista()
        {
            int opc = ddlOrdenar.SelectedIndex;
            switch (opc)
            {
                case 1:
                    sqldataProductos.SelectCommand += " ORDER BY Precio_PROD ASC";
                    break;
                case 2:
                    sqldataProductos.SelectCommand += " ORDER BY Precio_PROD DESC";
                    break;
            }
        }

        void filtrarxCategoria()
        {
            if (!string.IsNullOrEmpty(ddlCat.SelectedValue))
            {
                sqldataProductos.SelectCommand += " AND IDCategoria_PROD='" + ddlCat.SelectedValue + "'";
            }
        }

        void filtrarxSubcategoria()
        {
            if(!string.IsNullOrEmpty(ddlSubCat.SelectedValue))
            {
                sqldataProductos.SelectCommand += " AND IDSubCategoria_PROD='" + ddlSubCat.SelectedValue + "'";
            }
        }

        void filtrarxMarca()
        {
            if (!string.IsNullOrEmpty(ddlMarcas.SelectedValue))
            {
                sqldataProductos.SelectCommand += " AND IDMarca_PROD='" + ddlMarcas.SelectedValue + "'";
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

        protected void imgProducto_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("frmProducto.aspx?IDProd=" + e.CommandArgument);
        }

        protected void btnSinFiltro_Click(object sender, EventArgs e)
        {
            Session["filtroCategoria"] = null;
            sqldataProductos.SelectCommand = "SELECT[IDProducto], [Nombre_PROD], [RutaImagen], [Descuento_PROD], [Precio_PROD] FROM[PRODUCTOS] WHERE([ACTIVO] = @ACTIVO)";
            ddlCat.SelectedIndex = 0;
            ddlSubCat.SelectedIndex = 0;
            ddlMarcas.SelectedIndex = 0;
            ddlOrdenar.SelectedIndex = 0;
            lstViewProductos.DataBind();
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            sqldataProductos.SelectCommand = "SELECT[IDProducto], [Nombre_PROD], [RutaImagen], [Descuento_PROD], [Precio_PROD] FROM[PRODUCTOS] WHERE([ACTIVO] = @ACTIVO)";
            ddlOrdenar.SelectedIndex = 0;

            filtrarxCategoria();
            filtrarxSubcategoria();
            filtrarxMarca();
            ViewState["filtro"] = sqldataProductos.SelectCommand;
            lstViewProductos.DataBind();
        }

        protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarFiltroSubCats();
        }

        protected void ddlSubCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarFiltroMarcas();
        }

        protected void lstViewProductos_DataBound(object sender, EventArgs e)
        {
            lblCant.Text = lstViewProductos.Items.Count + " resultados";
        }

        protected void ddlOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ViewState["filtro"] != null)
            {
                sqldataProductos.SelectCommand = ViewState["filtro"].ToString();
            }
            OrdenarLista();
            lstViewProductos.DataBind();
        }
    }
}
