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

                List<string> filtro = new List<string>();
                if (Session["filtroCategoria"] == null)
                {
                    if (Session["Buscador"] == null)
                    {
                        Server.Transfer("/default.aspx", false);
                    }
                    else
                    {
                        string[] tempStr = EmpezarBusqueda();
                        if (tempStr != null)
                        {
                            filtro.AddRange(tempStr);
                        }
                        else
                        {
                            Session["buscadorState"] = "error";
                            Server.Transfer("/default.aspx", false);                            
                            //ERROR NO SE ENCONTRARON RESULTADOS
                        }
                    }
                }
                llenarFiltroCats();
                if (filtro.Count == 0)
                {
                    ddlCat.SelectedValue = Session["filtroCategoria"].ToString();
                }
                else
                {
                    Session["filtroCategoria"] = ddlCat.SelectedValue = filtro[0];
                }
                llenarFiltroSubCats();
                llenarFiltroMarcas();

                if (filtro.Count > 1)
                {
                    ddlSubCat.SelectedValue = filtro[1];
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

        string[] EmpezarBusqueda()
        {
            string[] strTemp = (string[])Session["Buscador"];
            List<string> strs = new List<string>();
            foreach (string str in strTemp)
            {
                if(str.Length > 1)
                {
                    strs.Add(str);
                }
            }
            string[] words = strs.ToArray();
            gestionProductos gp = new gestionProductos();
            DataSet[] datasets = new DataSet[words.Length];
            for (int i = 0; i < datasets.Length; i++)
            {
                datasets[i] = gp.busquedaProductos(words[i]);
            }
            List<string> cats = new List<string>();
            List<string> subcats = new List<string>();
            for (int x = 0; x < datasets.Length; x++)
            {
                foreach (DataRow item in datasets[x].Tables["productos"].Rows)
                {
                    cats.Add(item[0].ToString());
                    subcats.Add(item[1].ToString());
                }
                foreach (DataRow item in datasets[x].Tables["categorias"].Rows)
                {
                    cats.Add(item[0].ToString());
                }
                foreach (DataRow item in datasets[x].Tables["subcategorias"].Rows)
                {
                    subcats.Add(item[0].ToString());
                }
            }

            List<string> filtro = new List<string>();
            if (cats.Count > 1)
            {
                filtro.Add(Utilidades.getMasRepetido(cats.ToArray()));
            }
            else if (cats.Count == 1)
            {
                filtro.Add(cats[0]);
            }

            if (subcats.Count > 1)
            {
                filtro.Add(Utilidades.getMasRepetido(subcats.ToArray()));
            }
            else if (subcats.Count == 1)
            {
                filtro.Add(subcats[0]);
            }

            if (filtro.Count != 0)
            {
                return filtro.ToArray();
            }
            else
            {
                return null;
            }

        }

        public void añadirCarrito(DataTable tbl, Producto prod)
        {
            DataRow row = tbl.NewRow();
            row["Producto"] = prod.Nombre;
            row["Marca"] = prod.Marca;
            row["Precio"] = prod.Precio;
            row["RutaImagen"] = prod.RutaImagen.Trim();
            tbl.Rows.Add(row);
        }

        public DataTable crearTablacarrito()
        {
            DataTable tbl = new DataTable();
            tbl.Columns.Add(new DataColumn("Producto", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Marca", System.Type.GetType("System.String")));
            tbl.Columns.Add(new DataColumn("Precio", System.Type.GetType("System.Decimal")));
            tbl.Columns.Add(new DataColumn("RutaImagen", System.Type.GetType("System.String")));

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
