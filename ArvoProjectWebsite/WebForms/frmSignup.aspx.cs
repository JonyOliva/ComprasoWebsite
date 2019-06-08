using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            }

            if(txtContraSingUp.Text != txtRepContraSignUp.Text)
            {
                if (string.IsNullOrEmpty(lblContraSignUp.Text)) lblContraSignUp.Text += "*Las contraseñas deben ser iguales.";
                else lblContraSignUp.Text += " Las contraseñas deben ser iguales.";
                if (string.IsNullOrEmpty(lblRepContraSignUp.Text)) lblRepContraSignUp.Text += "*Las contraseñas deben ser iguales.";
                else lblRepContraSignUp.Text += " Las contraseñas deben ser iguales.";

            }

            if(!string.IsNullOrEmpty(txtTelefonoSignUp.Text))
            {
                for(int i = 0; i < txtTelefonoSignUp.Text.Length; i++)
                {
                    if(txtTelefonoSignUp.Text[i] > 57 || txtTelefonoSignUp.Text[i] < 48)
                    {
                        if (string.IsNullOrEmpty(lblTelefonoSignUp.Text)) lblTelefonoSignUp.Text = "*Solo se pueden ingresar números en este campo.";

                    }
                }
            }

            if (!string.IsNullOrEmpty(txtDniSignUp.Text) && !string.IsNullOrEmpty(txtCuit1SignUp.Text) && !string.IsNullOrEmpty(txtCuit2SignUp.Text))
            {
                for (int i = 0; i < txtDniSignUp.Text.Length; i++)
                {
                    if (txtDniSignUp.Text[i] > 57 || txtDniSignUp.Text[i] < 48)
                    {
                        if (string.IsNullOrEmpty(lblCuitSignUp.Text)) lblCuitSignUp.Text = "*Solo se pueden ingresar números en este campo.";

                    }
                }

                for (int i = 0; i < txtCuit1SignUp.Text.Length; i++)
                {
                    if (txtCuit1SignUp.Text[i] > 57 || txtCuit1SignUp.Text[i] < 48)
                    {
                        if (string.IsNullOrEmpty(lblCuitSignUp.Text)) lblCuitSignUp.Text = "*Solo se pueden ingresar números en este campo.";

                    }
                }

                for (int i = 0; i < txtCuit2SignUp.Text.Length; i++)
                {
                    if (txtCuit2SignUp.Text[i] > 57 || txtCuit2SignUp.Text[i] < 48)
                    {
                        if (string.IsNullOrEmpty(lblCuitSignUp.Text)) lblCuitSignUp.Text = "*Solo se pueden ingresar números en este campo.";

                    }
                }
            }
        }
    }
}