using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoLibre.Kasakhstan
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = File.ReadAllText(@"../_docs/Kazakhstan/roulette.txt");

            int from = 299053 + 500000;
            int to = from + 2976;
            string result = "";
            for (int i = 299053 + 500000; i < to; i++)
            {
                result += line[i];
            }
            Console.WriteLine(result);
        }

        private static char ObtenerMenor(string line)
        {
            char menor = line[0];
            for (int i = 0; i < 1000000; i++)
            {
                if (line[i] < menor)
                    menor = line[i];
            }

            return menor;
        }

        private static int ObtenerPosicion(string line)
        {
            string buscado = "+++LrYpjv";
            int posicion = 0;
            int i = 0;
            bool encontrado = false;
            while (i<100000 && encontrado)
            {
                if (buscado[0] == 'v')
                {
                    encontrado = true;
                    posicion = i - 9;
                }
                else if (line[i] == buscado[0])
                    buscado = buscado.Substring(1);
            }

            return posicion;
        }
    }
}
