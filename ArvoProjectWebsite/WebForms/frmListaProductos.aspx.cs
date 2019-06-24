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
                    btnFiltrar_Click(new object(), new EventArgs());
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
            //Response.Redirect("/WebForms/frmLogin.aspx");
        }

        protected void Carrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("/WebForms/frmCarrito.aspx");
        }

        protected void item_Command(object sender, CommandEventArgs e)
        {
            //Session["filtroCategoria"] = e.CommandArgument;
            //Response.Redirect("/WebForms/frmListaProductos.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //Response.Redirect("frmCarrito.aspx");
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
        }

        protected void imgProducto_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("frmProducto.aspx?IDProd=" + e.CommandArgument);
            //Server.Transfer("frmProducto.aspx?IDProd=" + e.CommandArgument, false);
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

        string[] EmpezarBusqueda()
        {
            string[] words = (string[])Session["Buscador"];
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
            row["IDProducto"] = prod.IDProducto;
            row["Cantidad"] = 1;
            
                if(!tbl.Rows.Contains(prod.IDProducto))
                    tbl.Rows.Add(row);
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

    }
}
