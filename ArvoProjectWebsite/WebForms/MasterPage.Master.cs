using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArvoProjectWebsite.WebForms
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InicSec_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }

        protected void Carrito_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCarrito.aspx");
        }
    }
}