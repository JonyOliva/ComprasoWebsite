using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaLogicadeNegocio;
using Entidad;
using System.Data.SqlClient;
using System.Data;

namespace ArvoProjectWebsite.WebForms
{
    public partial class frmMenuUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            //Usuario usu = new Usuario();
            //usu.IDUsuario = "0000";
            //Application["Usuario"] = usu;

            lblDniMenuUsuario.Text = ((Usuario)Application["Usuario"]).DNI;
            lblMailMenuUsuario.Text = ((Usuario)Application["Usuario"]).Email;
            lblNombreMenuUsuario.Text = ((Usuario)Application["Usuario"]).Apellido + " " + ((Usuario)Application["Usuario"]).Nombre;

            grdMenuUsuario.Visible = true;
            
            ddlCampo2.Visible = false;
            lblCampo2.Visible = false;
            lblCampo1.Visible = false;
            lblCampo3.Visible = false;
            lblCampo4.Visible = false;
            lblSeparadorVenc.Visible = false;
            txtCampo1.Visible = false;
            txtCampo3.Visible = false;
            txtCampo4.Visible = false;;
            txtCampo4b.Visible = false;
            lbtnAceptar.Visible = false;
            lblValidarTarjeta.Visible = false;
            lblValidarUsuario.Visible = false;
            lblValidarVencimiento.Visible = false;
            lbtnAgregarMenuUsuario.Visible = true;




            if (!IsPostBack)
            {
                
            }
        }

        protected void lbtnDireccionesMenuUsuario_Click(object sender, EventArgs e)
        {
            lblMenuUsuario.Text = "Direcciones";
            lbtnAgregarMenuUsuario.Visible = true;
            gestionUsuarios gestionUsuarios = new gestionUsuarios();

            Session["Direcciones"] = gestionUsuarios.CargarDirecciones((Usuario)Application["Usuario"]);
            grdMenuUsuario.DataSource = Session["Direcciones"];
            grdMenuUsuario.DataBind();

            DataTable Tabla = gestionUsuarios.getDropDrownUsuario("Provincias");
                //ddlCampo2.Visible = true;
                ddlCampo2.DataSource = Tabla;
                ddlCampo2.DataTextField = "Provincia_ENVIO";
                ddlCampo2.DataValueField = null;
                ddlCampo2.DataBind();
        }

        protected void lbtnMdPMenuUsuario_Click(object sender, EventArgs e)
        {
            lblMenuUsuario.Text = "Medios de Pago";
            lbtnAgregarMenuUsuario.Visible = true;
            gestionUsuarios gestionUsuarios = new gestionUsuarios();

            Session["MdP"] = gestionUsuarios.CargarMdPxUsu((Usuario)Application["Usuario"]);
            grdMenuUsuario.DataSource = Session["MdP"];
            grdMenuUsuario.DataBind();

            DataTable Tabla = gestionUsuarios.getDropDrownUsuario("Tarjetas");
            ddlCampo2.DataSource = Tabla;
            ddlCampo2.DataTextField = "Nombre_TARJ";
            ddlCampo2.DataValueField = "IDTarjeta_TARJ";
            ddlCampo2.DataBind();
        }

        protected void lbtnComprasMenuUsuario_Click(object sender, EventArgs e)
        {
            lblMenuUsuario.Text = "Compras";
            lbtnAgregarMenuUsuario.Visible = false;

            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            Session["Compras"] = gestionUsuarios.CargarTablaCompras(((Usuario)Application["Usuario"]));
            grdMenuUsuario.DataSource = Session["Compras"];
            grdMenuUsuario.DataBind();
        }



        protected void grdMenuUsuario_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {
            DataRow row = (DataRow)grdMenuUsuario.SelectedValue;
            if (row[7].ToString() == "Procesando") { }
            else lblDniMenuUsuario.Text = "jajaj";
        }



        protected void grdMenuUsuario_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            gestionUsuarios gestionUsuarios = new gestionUsuarios();

            switch(lblMenuUsuario.Text)
            {
                case "Compras":
                    if (((DataTable)Session["Compras"]).Rows[e.RowIndex][7].ToString() == "Procesando")
                    {
                        gestionUsuarios.CancelarCompra((int)((DataTable)Session["Compras"]).Rows[e.RowIndex][0]);
                        Session["Compras"] = gestionUsuarios.CargarTablaCompras((Usuario)Application["Usuario"]);
                        grdMenuUsuario.DataSource = Session["Compras"];
                        grdMenuUsuario.DataBind();

                    }
                    else
                    {
                        lblDniMenuUsuario.Text = ((DataTable)Session["Compras"]).Rows[e.RowIndex][7].ToString();
                    }
                    break;
                case "Medios de Pago":
                                       Session["MdP"] = gestionUsuarios.CargarMdPxUsu((Usuario)Application["Usuario"]);
                                       gestionUsuarios.EliminarMediodePagoxUsu((Usuario)Application["Usuario"], ((DataTable)Session["MdP"]).Rows[e.RowIndex][1].ToString());
                                       Session["MdP"] = gestionUsuarios.CargarMdPxUsu((Usuario)Application["Usuario"]);
                                       grdMenuUsuario.DataSource = Session["MdP"];
                                       grdMenuUsuario.DataBind();
                    break;
                case "Direcciones":
                                    Session["Direcciones"] = gestionUsuarios.CargarDirecciones((Usuario)Application["Usuario"]);
                                    gestionUsuarios.EliminarDireccion((Usuario)Application["Usuario"], (Convert.ToInt32(((DataTable)Session["Direcciones"]).Rows[e.RowIndex][0])));
                                    Session["Direcciones"] = gestionUsuarios.CargarDirecciones((Usuario)Application["Usuario"]);
                                    grdMenuUsuario.DataSource = Session["Direcciones"];
                                    grdMenuUsuario.DataBind();
                    break;
            }
            
        }

        protected void lbtnAgregarMenuUsuario_Click(object sender, EventArgs e)
        {
            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            txtCampo1.Text = "";
            txtCampo3.Text = "";
            txtCampo4.Text = "";
            txtCampo4b.Text = "";
            if (lblMenuUsuario.Text == "Direcciones")
            {
                lbtnAgregarMenuUsuario.Visible = false;
                lblCampo1.Visible = true;
                lblCampo2.Visible = true;
                grdMenuUsuario.Visible = false;
                lblCampo1.Text = "Calle y Número: ";
                txtCampo1.Visible = true;
                txtCampo1.MaxLength = 30;
                lblCampo2.Text = "Provincia: ";
                //DataTable Tabla = gestionUsuarios.getDropDrownUsuario("Provincias");
                ddlCampo2.Visible = true;
                //ddlCampo2.DataSource = Tabla;
                //ddlCampo2.DataTextField = "Provincia_ENVIO";
                //ddlCampo2.DataValueField = null;
                //ddlCampo2.DataBind();
                lbtnAceptar.Visible = true;
                
            }
            else if(lblMenuUsuario.Text == "Medios de Pago")
            {
                lbtnAgregarMenuUsuario.Visible = false;
                lblCampo1.Visible = true;
                lblCampo2.Visible = true;
                lblCampo3.Visible = true;
                lblCampo4.Visible = true;
                ddlCampo2.Visible = true;
                grdMenuUsuario.Visible = false;
                lblCampo1.Text = "Número de tarjeta: ";
                txtCampo1.Visible = true;
                txtCampo1.MaxLength = 16;
                txtCampo3.Visible = true;
                lblCampo2.Text = "Tarjeta: ";
                lblCampo3.Text = "Titular: ";
                //DataTable Tabla = gestionUsuarios.getDropDrownUsuario("Tarjetas");
                //ddlCampo2.DataSource = Tabla;
                //ddlCampo2.DataTextField = "Nombre_TARJ";
                //ddlCampo2.DataValueField = "IDTarjeta_TARJ";
                //ddlCampo2.DataBind();
                lblSeparadorVenc.Visible = true;
                lblCampo4.Text = "Vencimiento: ";
                txtCampo4.Visible = true;
                txtCampo4b.Visible = true;
                lbtnAceptar.Visible = true;
            }
        }

        protected void lbtnAceptar_Click(object sender, EventArgs e)
        {
            gestionUsuarios gestionUsuarios = new gestionUsuarios();
            Usuario usu = (Usuario)Application["Usuario"];
            lbtnAgregarMenuUsuario.Visible = true;
            bool guardar = true;
            if (lblMenuUsuario.Text == "Direcciones")
            {
                gestionUsuarios.AgregarDireccion(usu.IDUsuario, ddlCampo2.Text, txtCampo1.Text);
                Session["Direcciones"] = gestionUsuarios.Direcciones_x_Usuario((Usuario)Application["Usuario"]);
                grdMenuUsuario.DataSource = Session["Direcciones"];
                grdMenuUsuario.DataBind();
                
            }
            else if (lblMenuUsuario.Text == "Medios de Pago")
            {
                if (Utilidades.ContieneLetras(txtCampo1.Text, txtCampo1.Text.Length))
                {
                    lblValidarTarjeta.Text = "No se pueden ingresar letras en el Número de Tarjeta.";
                    lblValidarTarjeta.Visible = true;
                    guardar = false;
                }

                if (Utilidades.ContieneNumeros(txtCampo3.Text, txtCampo3.Text.Length))
                {
                    lblValidarUsuario.Text = "No se pueden ingresar números en el Titular";
                    lblValidarUsuario.Visible = true;
                    guardar = false;
                }
                if (Utilidades.ContieneLetras(txtCampo4.Text, txtCampo4.Text.Length) || Utilidades.ContieneLetras(txtCampo4b.Text, txtCampo4b.Text.Length))
                {
                    lblValidarVencimiento.Text = "No se pueden ingresar letras en la Fecha de Vencimiento. ";
                    lblValidarVencimiento.Visible = true;
                    guardar = false;
                }
                if (txtCampo4.Text.Length == 1) txtCampo4.Text = "0" + txtCampo4.Text;
                if(txtCampo4b.Text.Length <4)
                {
                    lblValidarVencimiento.Text += "El año debe ser de 4 dígitos.";
                    guardar = false;
                }

                if (guardar)
                {
                    string vencimiento = txtCampo4b.Text + txtCampo4.Text + "01";
                    //DateTime fecha = Convert.ToDateTime(vencimiento);
                    //vencimiento = fecha.ToString("yyyy-MM-dd");
                    string error = gestionUsuarios.AgregarMdP(usu.IDUsuario, txtCampo1.Text, ddlCampo2.SelectedValue, txtCampo3.Text, vencimiento);
                    Session["MdP"] = gestionUsuarios.CargarMdPxUsu(usu);
                    grdMenuUsuario.DataSource = Session["MdP"];
                    grdMenuUsuario.DataBind();
                    //lbtnAgregarMenuUsuario.Text = error;
                    
                }
            }
            lbtnAgregarMenuUsuario.Visible = true;
            //txtCampo1.Text = "";
            //txtCampo3.Text = "";
            //txtCampo4.Text = "";
            //txtCampo4b.Text = "";
        }
    }
}