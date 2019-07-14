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
           
            
            //if (!IsPostBack)
            //{
            //    if (Application["Usuario"] == null)
            //    {

            //        Response.Write("<script language='javascript'>window.alert('NO TIENE PERMISO PARA INGRESAR');window.location='/default.aspx';</script>");

            //    }

            //    else if (((Usuario)Application["Usuario"]).Admin == false) {

            //        Response.Write("<script language='javascript'>window.alert('NO TIENE PERMISO PARA INGRESAR');window.location='/default.aspx';</script>");

            //    }


            //}

            if (!IsPostBack)
            {
                llenarddlCategorias(ref ddlCategorias);
                llenarFiltroSubCats(ref ddlSubcat);
                llenarddlMarcas(ref ddlMarcas);
                llenarddlCategorias(ref ddlBuscarCat);
                llenarFiltroSubCats(ref ddlBuscarSubcat);
                llenarddlMarcas(ref ddlBuscarMarcas);

            }
            

        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 0;
            cargarGridViewProd();
           

        }
        
        void llenarFiltroSubCats(ref DropDownList ddl)
        {
            if (ddlCategorias.SelectedValue != null)
            {
                gestionProductos gp = new gestionProductos();
                ddl.DataValueField = "IDSubCategoria";
                ddl.DataTextField = "Nombre_SUBCAT";
                ddl.DataSource = gp.getListaSubCategorias(ddlCategorias.SelectedValue);
                ddl.DataBind();
                
                           }
        }

        public void llenarddlCategorias(ref DropDownList ddl)
        {
            gestionProductos gp = new gestionProductos();
                    
            ddl.DataValueField = "IDCategoria";
            ddl.DataTextField = "Nombre_CAT";
            ddl.DataSource = gp.getListaCategorias();
            ddl.DataBind();
            

        }

        public void llenarddlMarcas(ref DropDownList ddl)
        {
            gestionProductos gp = new gestionProductos();
            ddl.DataValueField = "IDMarca";
            ddl.DataTextField = "Nombre_MARCA";
            ddl.DataSource = gp.getListaMarcas();
            ddl.DataBind();


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
            grdProd.DataSource = gp.getListaProductos2();
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

        
        protected void grdProd_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProd.EditIndex = e.NewEditIndex;
            cargarGridViewProd();
            gestionProductos gp = new gestionProductos();
        }

        protected void grdProd_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProd.EditIndex = -1;
            cargarGridViewProd();
        }

        protected void grdProd_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bool s_Activo;
           
            s_Activo = ((CheckBox)grdProd.Rows[e.RowIndex].FindControl("chkActivo2")).Checked;
            String s_IdProd = ((Label)grdProd.Rows[e.RowIndex].FindControl("lblId")).Text;
            String s_Nombre = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtNombre")).Text;
            String s_Marca = ((DropDownList)grdProd.Rows[e.RowIndex].FindControl("ddlMarcasEdit")).SelectedValue;
            String s_Stock = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtStock")).Text;
            String s_Precio = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtPrecio")).Text;
            String s_Descuento = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtDescuento")).Text;
            String s_Descrip = ((TextBox)grdProd.Rows[e.RowIndex].FindControl("txtDescrip")).Text;
            String s_Foto = ((Label)grdProd.Rows[e.RowIndex].FindControl("lblRuta2")).Text;

            Producto prod = new Producto();
            prod.IDProducto = s_IdProd;
            prod.Nombre = s_Nombre;
            prod.Marca = s_Marca;
            prod.Stock = int.Parse(s_Stock);
            prod.Precio = float.Parse(s_Precio);
            prod.Descuento = float.Parse(s_Descuento);
            prod.Descripcion = s_Descrip;
            prod.Activo = s_Activo;

            gestionProductos gp = new gestionProductos();
            gp.actualizarProducto(prod);



            grdProd.EditIndex = -1;
            cargarGridViewProd();
        }

        

               protected void btnAgregar_Click1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdProd.Text)
                       || string.IsNullOrWhiteSpace(txtNombreProd.Text)
                       || string.IsNullOrWhiteSpace(txtPrecio.Text)
                       || string.IsNullOrWhiteSpace(txtStock.Text)
                       || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                
                lblError.Text = "* No pueden quedar campos vacios";
                lblError.Visible = true;
            }
            else if (!Utilidades.validarString(txtPrecio.Text.Trim(), true, false, false) ||
                    !Utilidades.validarString(txtStock.Text.Trim(), true, false, false)
                   ||!Utilidades.validarString(txtDescuento.Text.Trim(), true, false, false))
            {
                lblError.Visible = true;
                lblError.Text = "* Los campos numéricos no pueden contener letras";
            }
            else
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
                lblError.Visible = false;
            }
            
        }

        protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenarFiltroSubCats(ref ddlSubcat);
        }

        protected void grdProd_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProd.PageIndex = e.NewPageIndex;
            cargarGridViewProd();
        }

        protected void grdProd_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    DropDownList ddlSubcat = (DropDownList)e.Row.FindControl("ddlSubcatEdit");
                    DropDownList ddlListCat = (DropDownList)e.Row.FindControl("ddlCatEdit");
                    DropDownList ddlListMarcas = (DropDownList)e.Row.FindControl("ddlMarcasEdit");

                gestionProductos gp = new gestionProductos();
                    llenarddlCategorias(ref ddlListCat);
                    llenarddlMarcas(ref ddlListMarcas);

                    
                    ddlSubcat.DataValueField = "IDSubCategoria";
                    ddlSubcat.DataTextField = "Nombre_SUBCAT";
                    ddlSubcat.DataSource = gp.getListaSubCategorias(ddlListCat.SelectedValue);
                     ddlSubcat.DataBind();

                    DataRowView dr = e.Row.DataItem as DataRowView;
                    ddlListCat.SelectedValue = dr["IDCategoria"].ToString();
                    ddlSubcat.SelectedValue = dr["IDSubCategoria"].ToString();
                    ddlListMarcas.SelectedValue = dr["IDMarca"].ToString();



                }
            }
        }

        protected void btnConfirmar_Command(object sender, CommandEventArgs e)
        {
            gestionUsuarios gu = new gestionUsuarios();
            gu.ProcesarCompra(Convert.ToInt32(e.CommandArgument));
            GridVentas.DataBind();
        }

        protected void btnCancelar_Command(object sender, CommandEventArgs e)
        {
            gestionUsuarios gu = new gestionUsuarios();
            gu.CancelarCompra(Convert.ToInt32(e.CommandArgument));
            GridVentas.DataBind();
        }

        protected void GridVentas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button btnSi = (Button)e.Row.FindControl("btnConfirmar");
            Button btnNo = (Button)e.Row.FindControl("btnCancelar");

            if (btnSi != null)
            {
                if (DataBinder.Eval(e.Row.DataItem, "Estado").ToString() == "0")
                {
                    btnSi.Visible = true;
                    btnNo.Visible = true;
                }
                else
                {
                    btnSi.Visible = false;
                    btnNo.Visible = false;
                }
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void GridMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AgregarMarca_Click(object sender, EventArgs e)
        {
            if (!tblAgregarMarca.Visible)
                tblAgregarMarca.Visible = true;
            else
                tblAgregarMarca.Visible = false;
        }

        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIdMArca.Text)
                       || string.IsNullOrWhiteSpace(txtNombreMarca.Text))
            {
                lblErrorMarca.Text = "* No pueden quedar campos vacios";
                lblErrorMarca.Visible = true; }
            else if (txtIdMArca.Text.Length > 4)
            {
                lblErrorMarca.Text = "* El Id debe tener máximo 4 caracteres";
                lblErrorMarca.Visible = true;
            }
            else
            {
                gestionProductos gp = new gestionProductos();
                gp.insertarMarca(txtIdMArca.Text, txtNombreMarca.Text);
                lblErrorMarca.Visible = false;
                GridMarcas.DataBind();
            }

                        
        }
    }

   

}
    
