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
        gestorSesion sesion;

        protected void Page_Load(object sender, EventArgs e)
        {
            sesion = new gestorSesion(InicSec, Cuenta, CerrSec);

            if (!IsPostBack)
            {
                sesion.comprobarSesion();
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
                    this.Session["Carrito"] = crearTablacarrito();
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

        protected void item_Command(object sender, CommandEventArgs e)
        {
            Session["filtroCategoria"] = e.CommandArgument;
            Session["Buscador"] = null;
            Server.Transfer("/WebForms/frmListaProductos.aspx", false);
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
            if (!string.IsNullOrEmpty(ddlSubCat.SelectedValue))
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

            gestionProductos gp = new gestionProductos();
            añadirCarrito((DataTable)this.Session["Carrito"]
                , gp.getProducto(e.CommandArgument.ToString()));

            btnFiltrar_Click();
        }

        protected void imgProducto_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("frmProducto.aspx?IDProd=" + e.CommandArgument);
        }

        protected void btnSinFiltro_Click(object sender, EventArgs e)
        {
            sqldataProductos.SelectCommand = "SELECT[IDProducto], [Nombre_PROD], [RutaImagen], [Descuento_PROD], [Precio_PROD] FROM[PRODUCTOS] WHERE([ACTIVO] = @ACTIVO)";
            ddlCat.SelectedIndex = 0;
            ddlSubCat.SelectedIndex = 0;
            ddlMarcas.SelectedIndex = 0;
            ddlOrdenar.SelectedIndex = 0;
            lstViewProductos.DataBind();
        }

        protected void btnFiltrar_Click()
        {
            sqldataProductos.SelectCommand = "SELECT[IDProducto], [Nombre_PROD], [RutaImagen], [Descuento_PROD], [Precio_PROD] FROM[PRODUCTOS] WHERE([ACTIVO] = @ACTIVO)";

            filtrarxCategoria();
            filtrarxSubcategoria();
            filtrarxMarca();
            ViewState["filtro"] = sqldataProductos.SelectCommand;
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
            if (ViewState["filtro"] != null)
            {
                sqldataProductos.SelectCommand = ViewState["filtro"].ToString();
            }
            btnFiltrar_Click();
            OrdenarLista();
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

        public void añadirCarrito(DataTable tbl, Producto prod)
        {
            DataRow row = tbl.NewRow();
            row["Producto"] = prod.Nombre;
            row["Marca"] = prod.Marca;
            row["Precio"] = prod.Precio;
            row["RutaImagen"] = prod.RutaImagen.Trim();
            row["IDProducto"] = prod.IDProducto;
            row["Cantidad"] = 1;
            
            if(tbl.Rows.Contains(prod.IDProducto))
            {
                foreach (DataRow item in tbl.Rows)
                {
                    if(item[5].ToString() == prod.IDProducto)
                    {
                        int cant = int.Parse(item[4].ToString());
                        cant += 1;
                        item[4] = cant;
                    }
                }
            }
            else
            {
                tbl.Rows.Add(row);
            }
                    
        }

        public DataTable crearTablacarrito()
        {
            DataTable tbl = new DataTable();
            DataColumn[] clave= new DataColumn[1];
            DataColumn columna;
            tbl.Columns.Add(new DataColumn("Producto", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Marca", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Precio", System.Type.GetType("System.Decimal")));
            tbl.Columns.Add(new DataColumn("RutaImagen", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Cantidad", System.Type.GetType("System.Int32")));
            columna = new DataColumn("IDProducto", System.Type.GetType("System.String"));
            tbl.Columns.Add(columna);
            clave[0] = columna;
            tbl.PrimaryKey = clave;
            return tbl;
        }

        protected void btnUser_Command(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "init":
                    Response.Redirect("/WebForms/frmLogin.aspx");
                    break;
                case "acc":
                    Usuario user = (Usuario)Application["Usuario"];
                    if (user.Admin)
                    {
                        Response.Redirect("/WebForms/frmMenuAdmin.aspx");
                    }
                    else
                    {
                        Response.Redirect("/WebForms/frmMenuUsuario.aspx");
                    }
                    break;
                case "close":
                    sesion.cerrarSession();
                    Server.Transfer("/default.aspx", false);
                    break;
            }
        }

        protected void ejecutarBuscador(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscador.Text))
            {
                string[] words = txtBuscador.Text.Trim().Split();
                Session["filtroCategoria"] = null;
                Session["Buscador"] = words;
                Server.Transfer("/WebForms/frmListaProductos.aspx", false);
            }
        }

    }
}
