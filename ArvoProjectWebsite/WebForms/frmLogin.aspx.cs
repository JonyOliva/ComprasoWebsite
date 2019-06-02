using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using CapaLogicadeNegocio;

namespace ArvoProjectWebsite
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblAst1.Visible = false;
            lblAst2.Visible = false;
            lblError.Visible = false;

            Usuario user = new Usuario();
            user.Email = txtUsuario.Text.Trim();
            user.DNI = txtPass.Text.Trim();
            gestionUsuarios gu = new gestionUsuarios();
            if(gu.getUsuario(ref user))
            {
                //Response.Write(user.IDUsuario + user.Apellido);
                Application["Usuario"] = user;
                Server.Transfer("/WebForms/default.aspx");
            }
            else{
                if (String.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    lblAst1.Visible = true;
                }
                if (String.IsNullOrWhiteSpace(txtPass.Text))
                {
                    lblAst2.Visible = true;
                }
                lblError.Visible = true;
                txtPass.Text = "";
            }

        }
    }
}