using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Entidad;

namespace CapaLogicadeNegocio
{
    public class gestorSesion
    {
        LinkButton lkCniciar;
        LinkButton lkCuenta;
        LinkButton lkCerrar;

        public gestorSesion(LinkButton _lkIniciar, LinkButton _lkCuenta, LinkButton _lkCerrar)
        {
            lkCniciar = _lkIniciar;
            lkCuenta = _lkCuenta;
            lkCerrar = _lkCerrar;
        }

        public void comprobarSesion()
        {
            if (HttpContext.Current.Application["Usuario"] == null)
            {
                if (HttpContext.Current.Request.Cookies["user"] != null)
                {
                    string userData = HttpContext.Current.Request.Cookies["user"].Value;
                    obtenerUsuario(userData);
                    cargarUsuario();
                }
                else
                {
                    lkCniciar.Visible = true;
                    lkCuenta.Visible = false;
                    lkCerrar.Visible = false;
                }
            }
            else
            {
                cargarUsuario();
            }
        }

        void cargarUsuario()
        {
            Usuario user = (Usuario)HttpContext.Current.Application["Usuario"];
            lkCuenta.Text += user.Nombre;
            lkCuenta.Visible = true;
            lkCniciar.Visible = false;
            lkCerrar.Visible = true;
        }

        public void cerrarSession()
        {
            if (HttpContext.Current.Request.Cookies["user"] != null)
            {
                HttpCookie ck = new HttpCookie("user");
                ck.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(ck);
            }
            HttpContext.Current.Application["Usuario"] = null;
            lkCniciar.Visible = true;
            lkCuenta.Visible = false;
            lkCerrar.Visible = false;
        }

        void obtenerUsuario(string strEmail)
        {
            gestionUsuarios gu = new gestionUsuarios();
            Usuario us = new Usuario(strEmail);
            if (gu.getUsuario(ref us))
            {
                HttpContext.Current.Application["Usuario"] = us;
            }
            lkCniciar.Visible = true;
            lkCuenta.Visible = false;
            lkCerrar.Visible = false;
        }
    }
}
