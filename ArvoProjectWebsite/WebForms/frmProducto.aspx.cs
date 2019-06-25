using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using CapaLogicadeNegocio;
using System.Data;

namespace ArvoProjectWebsite.WebForms
{
    public partial class frmProducto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string IDProducto = Request.QueryString["IDProd"];
                if (!String.IsNullOrWhiteSpace(IDProducto))
                {
                    gestionProductos gp = new gestionProductos();
                    Producto prodActual = gp.getProducto(IDProducto);
                    btnComprar.CommandArgument = prodActual.IDProducto;

                    lblStock.Text = prodActual.Stock + " unidades disponibles!";
                    lblPrecioFinal.Text = "$" + Utilidades.precioaMostar(Utilidades.getPrecioConDescuento(prodActual.Precio, prodActual.Descuento));
                    lblNomProd.Text = prodActual.Nombre;
                    lblDescrip.Text = prodActual.Descripcion.Trim();
                    imgPrincipal.ImageUrl = prodActual.RutaImagen.Trim();
                    imgPrincipal.DataBind();

                    if(prodActual.Descuento > 0)
                    {
                        lblPrecio.Visible = true;
                        lblPrecio.Text = "Precio anterior $" + prodActual.Precio;
                        lblDesc.Visible = true;
                        lblDesc.Text = prodActual.Descuento + " %OFF!";
                    }
                }
                else
                {
                    Server.Transfer("/default.aspx");
                }
                if (this.Session["Carrito"] == null)
                {
                    this.Session["Carrito"] = crearTablacarrito();
                }

            }
        }

        protected void lbtnAñadircarr_Command(object sender, CommandEventArgs e)
        {
            gestionProductos gp = new gestionProductos();
            añadirCarrito((DataTable)this.Session["Carrito"]
                , gp.getProducto(e.CommandArgument.ToString()));
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

            if (tbl.Rows.Contains(prod.IDProducto))
            {
                foreach (DataRow item in tbl.Rows)
                {
                    if (item[5].ToString() == prod.IDProducto)
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
            DataColumn[] clave = new DataColumn[1];
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