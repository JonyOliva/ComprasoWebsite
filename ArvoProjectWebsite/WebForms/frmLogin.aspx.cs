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

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblError.Text = "";
            lblAst1.Visible = false;
            lblAst2.Visible = false;

            Usuario user = new Usuario();
            user.Email = txtUsuario.Text.Trim();
            gestionUsuarios gu = new gestionUsuarios();
            if (!String.IsNullOrWhiteSpace(txtUsuario.Text)) {
                if (gu.getUsuario(ref user))
                {
                    //Response.Write(user.IDUsuario + user.Apellido);
                    if (!String.IsNullOrWhiteSpace(txtPass.Text))
                    {
                        if (txtPass.Text == user.Password)
                        {
                            Application["Usuario"] = user;
                            Server.Transfer("/WebForms/default.aspx");
                        }
                        else
                        {
                            lblError.Text = "* Los datos ingresados son incorrectos";
                            txtPass.Text = "";
                        }
                    }
                    else
                    {
                        lblError.Text = "* No pueden quedar campos vacios";
                        lblAst2.Visible = true;
                    }
                }
                else {
                    lblError.Text = "* No existe ningún usuario con el email ingresado";
                }
            }
            else
            {
                lblAst1.Visible = true;
                if (String.IsNullOrWhiteSpace(txtPass.Text))
                {
                    lblAst2.Visible = true;
                }
                lblError.Text = "* No pueden quedar campos vacios";
            }
        }
    }
}