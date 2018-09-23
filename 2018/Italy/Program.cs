using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoLibre.Italy
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = System.IO.File.ReadAllText(@"../_docs/Italy/Copia de input013.txt");

            int p = 0;
            int c = 0;
            int m = 0;
            int b = 0;
            int z = 0;

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == 'p')
                    p++;
                if (line[i] == 'c')
                    c++;
                if (line[i] == 'm')
                    m++;
                if (line[i] == 'b')
                    b++;
                if (line[i] == 'z')
                    z++;

            }

            Console.WriteLine(Math.Min(Math.Min(Math.Min(Math.Min(p, c), m), b), z));
        }
    }
}
