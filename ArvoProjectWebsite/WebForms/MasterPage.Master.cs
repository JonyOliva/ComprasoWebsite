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
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["user"] != null)
                {
                    string user = Request.Cookies["user"].Value;
                    cargarUsuario(user);
                }
                if (Application["Usuario"] != null)
                {
                    Usuario user = (Usuario)Application["Usuario"];
                    Cuenta.Text += user.Nombre;
                    Cuenta.Visible = true;
                    InicSec.Visible = false;
                }
                else
                {
                    InicSec.Visible = true;
                    Cuenta.Visible = false;
                }
            }
        }

        void cargarUsuario(string strEmail)
        {
            gestionUsuarios gu = new gestionUsuarios();
            Usuario us = new Usuario(strEmail);
            if (gu.getUsuario(ref us))
            {
                Application["Usuario"] = us;
            }
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

        protected void ejecutarBuscador(object sender, EventArgs e)
        {
            string[] words = txtBuscador.Text.Split();
            Session["Buscador"] = words;
            Response.Redirect("/WebForms/frmListaProductos.aspx");
        }

        protected void btnUser_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandName == "init")
            {
                Response.Redirect("/WebForms/frmLogin.aspx");
            }
            else
            {
                Response.Redirect("/WebForms/frmMenuUsuario.aspx");
            }
        }
    }
}