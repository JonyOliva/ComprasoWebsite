using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    class Usuario
    {
        private string idUsuario;
        private string nombre;
        private string apellido;
        private string dni;
        private string email;
        private string nrocel;
        private string fechaNac;

        public string IDUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }
        public string DNI
        {
            get { return dni; }
            set { dni = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string nroCel
        {
            get { return nrocel; }
            set { nrocel = value; }
        }
        public string FechaNac
        {
            get { return fechaNac; }
            set { fechaNac = value; }
        }
    }
}
