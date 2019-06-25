using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicadeNegocio;
using Entidad;
using System.Data.SqlClient;
using System.Data;

namespace ArvoProjectWebsite
{
    public partial class frmMenuAdmin : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                if (!((Usuario)Application["Usuario"]).Admin)
                {

                    Response.Write("<script language='javascript'>window.alert('NO TIENE PERMISO PARA INGRESAR');window.location='/default.aspx';</script>");

                }


            }

            if (!IsPostBack)
            {
                llenarddl2();
                llenarFiltroSubCats();
            }
            llenarddlMarcas();
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 0;
            cargarGridViewProd();
           

        }

        void llenarFiltroSubCats()
        {
            if (ddlCategorias.SelectedValue != null)
            {
                gestionProductos gp = new gestionProductos();
                ddlSubcat.DataValueField = "IDSubCategoria";
                ddlSubcat.DataTextField = "Nombre_SUBCAT";
                ddlSubcat.DataSource = gp.getListaSubCategorias(ddlCategorias.SelectedValue);
                ddlSubcat.DataBind();
                           }
        }

        public void llenarddl2()
        {
            gestionProductos gp = new gestionProductos();

               
       
            ddlCategorias.DataValueField = "IDCategoria";
            ddlCategorias.DataTextField = "Nombre_CAT";
            ddlCategorias.DataSource = gp.getListaCategorias();
            ddlCategorias.DataBind();
            

        }

        public void llenarddlMarcas()
        {
            gestionProductos gp = new gestionProductos();
             ddlMarcas.DataValueField = "IDMarca";
            ddlMarcas.DataTextField = "Nombre_MARCA";
            ddlMarcas.DataSource = gp.getListaMarcas();
            ddlMarcas.DataBind();


        }



        protected void btnMarcas_Click(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 1;
        }

        protected void btnVentas_Click(object sender, EventArgs e)
        {
            
            MultiViewAdmin.ActiveViewIndex = 2;
            
        }
        public void cargarGridViewProd()
        {
            gestionProductos gp = new gestionProductos();
            grdProd.DataSource = gp.getListaProductos();
            grdProd.DataBind();
        }

        private void Estados()
        {
            
           Enum.GetNames(typeof(EstadoCompra));
                      
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (!AgregarProducto.Visible)
                AgregarProducto.Visible = true;
            else
                AgregarProducto.Visible = false;
        }

        protected void GridProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProd.EditIndex = e.NewEditIndex;

        }

        protected void GridProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool s_Activo;
            String s_IdProd = ((Label)grdProd.Rows[e.RowIndex].FindControl("lblID2")).Text;
            String s_Nombre = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtNombre")).Text;
            String s_Stock = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtStock")).Text;
            String s_Precio = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtPrecio")).Text;
            String s_Descuento = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtDescuento")).Text;
            String s_Descrip = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtDescrip")).Text;
            if (!chkActivo.Checked)
            {
                s_Activo = true;
            }
            else { s_Activo = false; }
            String s_Foto = ((Label)grdProd.Rows[e.RowIndex].FindControl("lblRuta2")).Text;

            Producto prod = new Producto();
            prod.IDProducto = s_IdProd;
            prod.Nombre = s_Nombre;
            prod.Stock = int.Parse(s_Stock);
            prod.Precio = float.Parse(s_Precio);
            prod.Descuento = float.Parse(s_Descuento);
            prod.Descripcion = s_Descrip;
            prod.Activo = s_Activo;

            gestionProductos gp = new gestionProductos();
            gp.ActualizarProducto(prod);



            grdProd.EditIndex = -1;
        }

        protected void grdProd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProd.EditIndex = e.NewEditIndex;
            cargarGridViewProd();
        }

        protected void grdProd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProd.EditIndex = -1;
            cargarGridViewProd();
        }

        protected void grdProd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool s_Activo;
            String s_IdProd = ((Label)grdProd.Rows[e.RowIndex].FindControl("lblId")).Text;
            String s_Nombre = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtNombre")).Text;
            String s_Stock = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtStock")).Text;
            String s_Precio = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtPrecio")).Text;
            String s_Descuento = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtDescuento")).Text;
            String s_Descrip = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtDescrip")).Text;
            if (chkActivo.Checked == true)
            {
                s_Activo = true;
            }
            else
            {
                s_Activo = false;
            }
            String s_Foto = ((Label)grdProd.Rows[e.RowIndex].FindControl("lblRuta2")).Text;

            Producto prod = new Producto();
            prod.IDProducto = s_IdProd;
            prod.Nombre = s_Nombre;
            prod.Stock = int.Parse(s_Stock);
            prod.Precio = float.Parse(s_Precio);
            prod.Descuento = float.Parse(s_Descuento);
            prod.Descripcion = s_Descrip;
            prod.Activo = s_Activo;

            gestionProductos gp = new gestionProductos();
            gp.ActualizarProducto(prod);



            grdProd.EditIndex = -1;
            cargarGridViewProd();
        }

        

               protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            Producto prod = new Producto();
            gestionProductos gp = new gestionProductos();
            prod.Activo = true;
            prod.IDProducto = txtIdProd.Text.Trim();
            prod.Nombre = txtNombreProd.Text.Trim();
            prod.Precio = float.Parse(txtPrecio.Text);
            prod.Stock = int.Parse(txtStock.Text);
            prod.Categoria = ddlCategorias.SelectedValue;
            prod.SubCategoria = ddlSubcat.SelectedValue;
            prod.Marca = ddlMarcas.SelectedValue;
            prod.Descripcion = txtDescripcion.Text.Trim();
            gp.insertarProducto(prod);
            
            
            Server.Transfer("/WebForms/frmMenuAdmin.aspx", false);
                    }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarFiltroSubCats();
        }
    }

   

}
    
