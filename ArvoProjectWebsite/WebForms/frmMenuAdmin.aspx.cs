using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ArvoProjectWebsite
{
    public partial class frmMenuAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 0;
        }

        protected void btnMarcas_Click(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 1;
        }

        protected void btnVentas_Click(object sender, EventArgs e)
        {
            MultiViewAdmin.ActiveViewIndex = 2;
        }
    }
}