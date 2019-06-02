using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public enum EstadoCompra
    {
        Enproceso,
        Cancelada,
        Enviada,
        Entregado
    }

    public static class Utilidades
    {
        public static string getRandomID(int cantCaracteres, int seed = 0)
        {
            Random rand;
            if (seed == 0)
            {
                rand = new Random();
            }
            else
            {
                rand = new Random(seed);
            }
            char[] ID = new char[cantCaracteres];
            for (int i = 0; i < cantCaracteres; i++)
            {
                ID[i] = (char)rand.Next(48, 58);
            }
            return new String(ID);
        }

        public static string GetStringConectionFromServer()
        {
            return "workstation id=ComprasoBD.mssql.somee.com;packet size=4096;user id=arvo;pwd=arvoadmin;data source=ComprasoBD.mssql.somee.com;persist security info=False;initial catalog=ComprasoBD";
        }

        public static string GetStringConectionLocal()
        {
            return "Data Source = localhost\\sqlexpress; Initial Catalog = BD_COMPRASO; Integrated Security = True";
        }
    }
}
