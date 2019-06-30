using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public enum EstadoCompra
    {
        Procesando,
        Cancelado,
        Enviado,
        Entregado
    }

    public static class Utilidades
    {
        
        public static string GetStringConectionFromServer()
        {
            return "workstation id=ComprasoBD.mssql.somee.com;packet size=4096;user id=arvo;pwd=arvoadmin;data source=ComprasoBD.mssql.somee.com;persist security info=False;initial catalog=ComprasoBD";
        }

        public static string GetStringConectionLocal()
        {
            return "Data Source = localhost\\sqlexpress; Initial Catalog = BD_COMPRASO; Integrated Security = True";
        }

        public static float getPrecioConDescuento(object _precio, object _descuento)
        {
            float precio = Convert.ToSingle(_precio);
            float descuento = Convert.ToSingle(_descuento);
            if(descuento == 0){
                return precio;
            }
            return precio * ((100 - descuento)/100);
        }

        public static string precioaMostar(object _precio) //todo este quilombo es para que el precio salga con los puntos de miles jaja
        {
            string precio = Convert.ToInt32(_precio).ToString();
            string pMostrar = string.Empty;
            int c = 0;
            int pos = precio.Length % 3;
            int pointcant = (precio.Length / 3) - 1;
            for (int i = 0; i < precio.Length; i++)
            {
                if(i == pos && pos != 0)
                {
                    pMostrar += ".";
                }
                if (i > pos)
                {
                    c++;
                    if (c == 3)
                    {
                        pMostrar += ".";
                        c = 0;
                    }
                }
                pMostrar += precio[i];
            }
            return pMostrar;
        }

        public static string obtenerNombreMesNumero(int nroMes)
        {
            try
            {
                DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
                string nombreMes = formatoFecha.GetMonthName(nroMes);
                return nombreMes;
            }
            catch
            {
                return "Desconocido";
            }
        }

        public static bool soloLetras(string str)
        {
            foreach (char ch in str)
            {
                if (!char.IsLetter(ch))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool validarString(string str, bool permitirNumeros, bool permitirLetras, bool permitirEspeciales) //si la cadena esta entre los parametros dados la func retorna true
        {
            foreach (char ch in str)
            {
                if (!((char.IsLetter(ch) && permitirLetras) || (char.IsNumber(ch) && permitirNumeros) || (char.IsSymbol(ch) && permitirEspeciales)))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool ContieneNumeros(string cadena, int cantidad)
        {
            for(int i = 0; i < cantidad; i++)
            {
                if (cadena[i] > 47 && cadena[i] < 58) return true;
            }

            return false;
        }

        public static bool ContieneLetras(string cadena, int cantidad)
        {
            for(int i = 0; i < cantidad; i++)
            {
                if (cadena[i] < 47 || cadena[i] > 58) return true;
            }

            return false;
        }

        public static string ObtenerEstadoEnvio (Byte a)
        {
            return "jaja";
        }

        public static string getMasRepetido(string[] strs)
        {
            List<int> count = new List<int>();
            List<string> dat = new List<string>();
            int c = 0;
            for (int i = 0; i < strs.Length; i++)
            {
                if (!dat.Contains(strs[i]))
                {
                    for (int x = 0; x < strs.Length; x++)
                    {
                        if (strs[i] == strs[x] && i != x)
                        {
                            c++;
                        }
                    }
                    dat.Add(strs[i]);
                    count.Add(c);
                    c = 0;
                }
            }

            if(count.Count == 1)
            {
                return dat[0];
            }
            else
            {
                int max = 0;
                for (int i = 1; i < count.Count; i++)
                {
                    if(count[i] > count[max])
                    {
                        max = i;
                    }
                }
                return dat[max];
            }
        }
    }
}
