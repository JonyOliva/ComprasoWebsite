using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
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

    }
}
