using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CapaLogicadeNegocio;
using Entidad;
using System.Data;

namespace ArvoProjectWebsite
{
    public partial class frmListaProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["filtroCategoria"] == null)
                {
                    if (Session["Buscador"] == null)
                    {
                        Server.Transfer("/default.aspx", false);
                    }
                    else
                    {
                        if (!EmpezarBusqueda())
                        {
                            Session["buscadorState"] = "error";
                            Server.Transfer("/default.aspx", false);                            
                            //ERROR NO SE ENCONTRARON RESULTADOS
                        }
                    }
                }
                else
                {
                    llenarFiltroCats();
                    ddlCat.SelectedValue = Session["filtroCategoria"].ToString();
                    llenarFiltroSubCats();
                    llenarFiltroMarcas();
                    btnFiltrar_Click();
                }
               
                if (this.Session["Carrito"] == null)
                {
                    this.Session["Carrito"] = LogicaCarrito.crearTablacarrito();
                }
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Session["filtroCategoria"] = null;
            Session["Buscador"] = null;
        }

        protected void InicSec_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/frmLogin.aspx");
        }

        protected void Carrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/frmCarrito.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCarrito.aspx");
        }

        void llenarFiltroMarcas()
        {
            if (ddlCat.SelectedValue != null && ddlSubCat.SelectedValue != null)
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

        protected void lbtnAñadircarr_Command(object sender, CommandEventArgs e)
        {

            gestionProductos gp = new gestionProductos();
            LogicaCarrito.añadirCarrito((DataTable)this.Session["Carrito"]
                , gp.getProducto(e.CommandArgument.ToString()));
        }

        protected void imgProducto_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("frmProducto.aspx?IDProd=" + e.CommandArgument);
        }

        protected void btnFiltrar_Click()
        {
            gestionProductos gp = new gestionProductos();
            lstViewProductos.DataSource = gp.getProductos("", ddlCat.SelectedValue, ddlSubCat.SelectedValue, ddlMarcas.SelectedValue, ddlOrdenar.SelectedValue);
            lstViewProductos.DataBind();
        }

        protected void ddlCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarFiltroSubCats();
            ddlSubCat.SelectedIndex = 0;
            ddlMarcas.SelectedIndex = 0;
            ddlOrdenar.SelectedIndex = 0;
            btnFiltrar_Click();
        }

        protected void ddlSubCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarFiltroMarcas();
            ddlMarcas.SelectedIndex = 0;
            ddlOrdenar.SelectedIndex = 0;
            btnFiltrar_Click();
        }

        protected void ddlMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOrdenar.SelectedIndex = 0;
            btnFiltrar_Click();
        }

        protected void lstViewProductos_DataBound(object sender, EventArgs e)
        {
            lblCant.Text = lstViewProductos.Items.Count + " resultados";
        }


        protected void ddlOrdenar_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnFiltrar_Click();
        }

        bool EmpezarBusqueda()
        {
            string[] strTemp = (string[])Session["Buscador"];
            gestionProductos gp = new gestionProductos();
            string[] searchResult = gp.Buscar((string[])Session["Buscador"]);
            if (searchResult != null)
            {
                llenarFiltroCats();
                if (searchResult.Length > 1)
                {
                    Session["filtroCategoria"] = ddlCat.SelectedValue = searchResult[0];
                    llenarFiltroSubCats();
                    ddlSubCat.SelectedValue = searchResult[1];
                    llenarFiltroMarcas();
                }
                else
                {
                    Session["filtroCategoria"] = ddlCat.SelectedValue = searchResult[0];
                }
                btnFiltrar_Click();
                return true;
            }
            else
            {
                return false;
            }
        }
        
    }
}
