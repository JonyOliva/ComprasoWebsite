using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidad;
using CapaLogicadeNegocio;

namespace ArvoProjectWebsite.WebForms
{
    public partial class frmSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMailSignUp.Text = "";
            lblApellidoSignUp.Text = "";
            lblNombreSignUp.Text = "";
            lblContraSignUp.Text = "";
            lblRepContraSignUp.Text = "";
            lblCuitSignUp.Text = "";
            lblFechaSignUp.Text = "";
            lblTelefonoSignUp.Text = "";
            
        }

        protected void btnRegistrarSignUp_Click(object sender, EventArgs e)
        {
            bool guardar = true;
            gestionUsuarios gu = new gestionUsuarios();

            ///VALIDAR VACIOS
            if (string.IsNullOrEmpty(txtMailSignUp.Text) || string.IsNullOrEmpty(txtApellidoSignUp.Text) || string.IsNullOrEmpty(txtNombreSignUp.Text) || 
                string.IsNullOrEmpty(txtContraSingUp.Text) || string.IsNullOrEmpty(txtRepContraSignUp.Text) || string.IsNullOrEmpty(txtCuit1SignUp.Text) ||
                string.IsNullOrEmpty(txtCuit2SignUp.Text) || string.IsNullOrEmpty(txtDniSignUp.Text) || string.IsNullOrEmpty(txtTelefonoSignUp.Text) ||
                string.IsNullOrEmpty(txtFechaSignUp.Text))
            {
                if (string.IsNullOrEmpty(txtMailSignUp.Text)) lblMailSignUp.Text = "*El campo no puede estar vacío.";
                if (string.IsNullOrEmpty(txtApellidoSignUp.Text)) lblApellidoSignUp.Text = "*El campo no puede estar vacío.";
                if (string.IsNullOrEmpty(txtNombreSignUp.Text)) lblNombreSignUp.Text = "*El campo no puede estar vacío.";
                if (string.IsNullOrEmpty(txtContraSingUp.Text)) lblContraSignUp.Text = "*El campo no puede estar vacío.";
                if (string.IsNullOrEmpty(txtRepContraSignUp.Text)) lblRepContraSignUp.Text = "*El campo no puede estar vacío.";
                if (string.IsNullOrEmpty(txtCuit1SignUp.Text) || 
                    string.IsNullOrEmpty(txtDniSignUp.Text) || string.IsNullOrEmpty(txtCuit2SignUp.Text) )lblCuitSignUp.Text = "*El campo no puede estar vacío.";
                if (string.IsNullOrEmpty(txtTelefonoSignUp.Text)) lblTelefonoSignUp.Text = "*El campo no puede estar vacío.";
                if (string.IsNullOrEmpty(txtFechaSignUp.Text)) lblFechaSignUp.Text = "*El campo no puede estar vacío.";

                guardar = false;
            }

            ///VALIDAR NOMBRE Y APELLIDO
            if(!string.IsNullOrEmpty(txtApellidoSignUp.Text))
            {
                if(Utilidades.ContieneNumeros(txtApellidoSignUp.Text, txtApellidoSignUp.Text.Length))
                {
                    lblApellidoSignUp.Text = "*Solo se pueden ingresar letras en este campo.";
                    guardar = false;
                }
            }

            if(!string.IsNullOrEmpty(txtNombreSignUp.Text))
            {
                if(Utilidades.ContieneNumeros(txtNombreSignUp.Text, txtNombreSignUp.Text.Length))
                {
                    lblNombreSignUp.Text = "*Solo se pueden ingresar letras en este campo.";
                    guardar = false;
                }
            }

            ///VALIDAR CONTRASEÑA
            if(txtContraSingUp.Text != txtRepContraSignUp.Text)
            {
                if (string.IsNullOrEmpty(lblContraSignUp.Text)) lblContraSignUp.Text += "*Las contraseñas deben ser iguales.";
                else lblContraSignUp.Text += " Las contraseñas deben ser iguales.";
                if (string.IsNullOrEmpty(lblRepContraSignUp.Text)) lblRepContraSignUp.Text += "*Las contraseñas deben ser iguales.";
                else lblRepContraSignUp.Text += " Las contraseñas deben ser iguales.";

                guardar = false;
            }

            if(txtContraSingUp.Text.Length < 6)
            {
                if (!string.IsNullOrEmpty(txtContraSingUp.Text)) lblContraSignUp.Text += " La contraseña debe tener un largo mínimo de 6 carácteres.";
                guardar = false;
            }
            if(txtRepContraSignUp.Text.Length < 6)
            {
                if(!string.IsNullOrEmpty(txtRepContraSignUp.Text)) lblRepContraSignUp.Text += " La contraseña debe tener un largo mínimo de 6 carácteres.";
                guardar = false;
            }

            ///VALIDAR TELEFONO
            if(!string.IsNullOrEmpty(txtTelefonoSignUp.Text))
            {
               
                if (Utilidades.ContieneLetras(txtTelefonoSignUp.Text, txtTelefonoSignUp.Text.Length))
                {
                    lblTelefonoSignUp.Text = "*Solo se pueden ingresar números en este campo.";
                    guardar = false;
                }
            }

            ///VALIDAR DNI Y CUIT
            if (!string.IsNullOrEmpty(txtDniSignUp.Text) && !string.IsNullOrEmpty(txtCuit1SignUp.Text) && !string.IsNullOrEmpty(txtCuit2SignUp.Text))
            {
               
                if(Utilidades.ContieneLetras(txtDniSignUp.Text, txtDniSignUp.Text.Length))
                {
                    if (string.IsNullOrEmpty(lblCuitSignUp.Text)) lblCuitSignUp.Text = "*Solo se pueden ingresar números en este campo.";
                    guardar = false;
                }

                
                if(Utilidades.ContieneLetras(txtCuit1SignUp.Text, txtCuit1SignUp.Text.Length))
                {
                    if (string.IsNullOrEmpty(lblCuitSignUp.Text)) lblCuitSignUp.Text = "Solo se pueden ingresar números en este campo.";
                    guardar = false;
                }

                if(Utilidades.ContieneLetras(txtCuit2SignUp.Text, txtCuit2SignUp.Text.Length))
                {
                    if (string.IsNullOrEmpty(lblCuitSignUp.Text)) lblCuitSignUp.Text = "Solo se pueden ingresar números en este campo.";
                    guardar = false;
                }
            }

            ///VALIDAR CUIT Y MAIL EXISTENTE
            switch (gu.ValidarCUITyMail(txtCuit1SignUp.Text + txtDniSignUp.Text + txtCuit2SignUp.Text, txtMailSignUp.Text))
            {
                case 1:
                    lblMailSignUp.Text = "El mail  ya está registrado.";
                    break;
                case 2:
                    lblCuitSignUp.Text = "El CUIT ya está registrado";
                    break;
                case 3:
                    lblMailSignUp.Text = "El mail  ya está registrado.";
                    lblCuitSignUp.Text = "El CUIT ya está registrado";
                    break;
                default:
                    break;
            }



            if (guardar)
            {
                gestionUsuarios gestionUsuarios = new gestionUsuarios();
                Usuario usuario = new Usuario();
                usuario.IDUsuario = txtCuit1SignUp.Text + txtDniSignUp.Text + txtCuit2SignUp.Text;
                usuario.Admin = false;
                usuario.Nombre = txtNombreSignUp.Text;
                usuario.Apellido = txtApellidoSignUp.Text;
                usuario.DNI = txtDniSignUp.Text;
                usuario.Email = txtMailSignUp.Text;
                usuario.Password = txtContraSingUp.Text;
                usuario.nroCel = txtTelefonoSignUp.Text;
                usuario.FechaNac = txtFechaSignUp.Text;

                gestionUsuarios.AgregarUsuario(usuario);

                Response.Redirect("frmLogin.aspx");
                
                //if (gestionUsuarios.AgregarUsuario(usuario).ToString() == "2627" )
                //{
                //    lblMailSignUp.Text = "El mail puede ya estar registrado.";
                //    lblCuitSignUp.Text = "El CUIT ya puede estar registrado"; //ya existe un usuario con los datos ingresados
                //}
                
            }
        }
    }
}