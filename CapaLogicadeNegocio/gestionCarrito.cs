using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace CapaLogicadeNegocio
{
    public class gestionCarrito
    {
        public void agregarCarrito(DataTable tbl, string idprod)
        {
            gestionProductos gp = new gestionProductos();
            tbl.ImportRow(gp.getrowProducto(idprod));
        }
    }
}