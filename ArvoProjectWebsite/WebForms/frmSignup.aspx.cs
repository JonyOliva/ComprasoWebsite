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
            Usuario usuario = new Usuario();
            gestionUsuarios gUser = new gestionUsuarios();
            bool registrar = true;

            //VALIDAR CAMPOS VACIOS
            if(string.IsNullOrEmpty(txtMailSignUp.Text) || string.IsNullOrEmpty(txtApellidoSignUp.Text) || string.IsNullOrEmpty(txtNombreSignUp.Text) || 
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

                registrar = false;
            }


            //VALIDAR CONTRASEÑAS
            if(txtContraSingUp.Text != txtRepContraSignUp.Text)
            {
                if (string.IsNullOrEmpty(lblContraSignUp.Text)) lblContraSignUp.Text += "*Las contraseñas deben ser iguales.";
                else lblContraSignUp.Text += " Las contraseñas deben ser iguales.";
                if (string.IsNullOrEmpty(lblRepContraSignUp.Text)) lblRepContraSignUp.Text += "*Las contraseñas deben ser iguales.";
                else lblRepContraSignUp.Text += " Las contraseñas deben ser iguales.";

                registrar = false;
            }

            //VALIDAR TELEFONO
            if(!string.IsNullOrEmpty(txtTelefonoSignUp.Text))
            {
                if (Utilidades.ContieneLetras(txtTelefonoSignUp.Text, txtTelefonoSignUp.Text.Length))
                {
                    lblTelefonoSignUp.Text = "*Solo se pueden ingresar números en este campo.";
                    registrar = false;
                }
            }

            //VALIDAR CUIT/DNI
            if (!string.IsNullOrEmpty(txtDniSignUp.Text) && !string.IsNullOrEmpty(txtCuit1SignUp.Text) && !string.IsNullOrEmpty(txtCuit2SignUp.Text))
            {
                if(Utilidades.ContieneLetras(txtDniSignUp.Text, txtDniSignUp.Text.Length))
                {
                    lblCuitSignUp.Text = "*Solo se pueden ingresar números en este campo.";
                    registrar = false;
                }

                if(Utilidades.ContieneLetras(txtCuit1SignUp.Text, txtCuit1SignUp.Text.Length))
                {
                    lblCuitSignUp.Text = "*Solo se pueden ingresar números en este campo.";
                    registrar = false;
                }

                if(Utilidades.ContieneLetras(txtCuit2SignUp.Text, txtCuit2SignUp.Text.Length))
                {
                    lblCuitSignUp.Text = "*Solo se pueden ingresar números en este campo.";
                    registrar = false;
                }
            }

            //VALIDAR NOMBRE
            if(!string.IsNullOrEmpty(txtNombreSignUp.Text))
            {
                if(Utilidades.ContieneNumeros(txtNombreSignUp.Text, txtNombreSignUp.Text.Length))
                {
                    lblNombreSignUp.Text = "*No se pueden ingresar números en este campo.";
                    registrar = false;
                }
            }

            //VALIDAR APELLIDO
            if(!string.IsNullOrEmpty(txtApellidoSignUp.Text))
            {
                if(Utilidades.ContieneNumeros(txtApellidoSignUp.Text, txtApellidoSignUp.Text.Length))
                {
                    lblApellidoSignUp.Text = "*No se pueden ingresar números en este campo.";
                    registrar = false;
                }
            }

            if(registrar)
            {
                usuario.Admin = false;
                usuario.IDUsuario = txtCuit1SignUp.Text + txtDniSignUp.Text + txtCuit2SignUp.Text;
                usuario.Nombre = txtNombreSignUp.Text;
                usuario.Apellido = txtApellidoSignUp.Text;
                usuario.Password = txtContraSingUp.Text;
                usuario.DNI = txtDniSignUp.Text;
                usuario.Email = txtMailSignUp.Text;
                usuario.nroCel = txtTelefonoSignUp.Text;
                usuario.FechaNac = txtFechaSignUp.Text;
                if(gUser.AgregarUsuario(usuario))
                {

                }

            }
        }
    }
}