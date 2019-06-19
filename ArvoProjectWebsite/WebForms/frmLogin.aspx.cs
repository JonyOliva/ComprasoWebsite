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

            Usuario user = new Usuario(txtUsuario.Text.Trim());
            gestionUsuarios gu = new gestionUsuarios();
            if (!String.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                if (gu.getUsuario(ref user))
                {
                    if (!String.IsNullOrWhiteSpace(txtPass.Text))
                    {
                        if (txtPass.Text == user.Password)
                        {
                            Application["Usuario"] = user;
                            if (chrRecordar.Checked)
                            {         
                                HttpCookie ck = new HttpCookie("user");
                                ck.Value = user.Email;
                                ck.Name = "user";
                                ck.Expires = DateTime.Now.AddMinutes(2); //esto es por tema de debug
                                Response.Cookies.Add(ck);
                            }
                            Server.Transfer("/default.aspx");
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
                else
                {
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

        protected void linkRegistrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmSignUp.aspx");
        }

        protected void linkOlvido_Click(object sender, EventArgs e)
        {
            if (MultiView.ActiveViewIndex == 0)
            {
                MultiView.ActiveViewIndex = 1;
            }
            else
            {
                MultiView.ActiveViewIndex = 0;
                txtCuit1SignUp.Text = txtDniSignUp.Text = txtCuit2SignUp.Text = txtEmail.Text = txtFechaSignUp.Text = "";
                lblpass.Visible = false;
            }
        }

        protected void SubmitLossPass_Click(object sender, EventArgs e)
        {
            lblErrorView2.Text = "";

            if (string.IsNullOrWhiteSpace(txtEmail.Text)
               || string.IsNullOrWhiteSpace(txtDniSignUp.Text)
               || string.IsNullOrWhiteSpace(txtCuit1SignUp.Text)
               || string.IsNullOrWhiteSpace(txtCuit2SignUp.Text)
               || string.IsNullOrWhiteSpace(txtFechaSignUp.Text))
            {
                lblErrorView2.Text = "* No pueden quedar campos vacios";
            }
            else if (!Utilidades.validarString(txtDniSignUp.Text.Trim(), true, false, false) ||
                    !Utilidades.validarString(txtCuit1SignUp.Text.Trim(), true, false, false) ||
                    !Utilidades.validarString(txtCuit2SignUp.Text.Trim(), true, false, false))
            {
                lblErrorView2.Text = "* Los campos numéricos no pueden contener letras";
            }
            else
            {
                string cuit = txtCuit1SignUp.Text.Trim() + txtDniSignUp.Text.Trim() + txtCuit2SignUp.Text.Trim();
                gestionUsuarios gu = new gestionUsuarios();
                Usuario user = new Usuario(txtEmail.Text.Trim());
                if (gu.getUsuario(ref user))
                {
                    if(user.IDUsuario == cuit && DateTime.Compare(Convert.ToDateTime(txtFechaSignUp.Text), Convert.ToDateTime(user.FechaNac)) == 0 && user.Email == txtEmail.Text.Trim())
                    {
                        lblpass.Visible = true;
                        lblpass.Text = user.Password;
                        MultiView.ActiveViewIndex = 2;
                    }
                    else
                    {
                        lblErrorView2.Text = "* Los datos ingresados son incorrectos";
                    }

                }
                else
                {
                    lblErrorView2.Text = "* Los datos ingresados son incorrectos";
                }
            }
        }
    }
}