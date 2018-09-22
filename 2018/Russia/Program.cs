using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercadoLibre.Rusia
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "10 10 9106 137 5339 852 3726 3952 994 210 5304 1471 5990 3581 3266 4392 5290 439 9299 296 9437 479 7 6 8 1 6 7 7 3 7 6";
            string[] separados = input.Split(' ');
            int n = int.Parse(separados[0]);
            int q = int.Parse(separados[1]);

            Dictionary<int, int> diccionario = new Dictionary<int, int>();
            Enrutador[] enrutadores = new Enrutador[n];
            for (int i = 0; i < n; i++)
                enrutadores[i] = new Enrutador();

            for (int i = 2; i < n*2 +2; i += 2)
            {
                int enrutador = int.Parse(separados[i]);
                int radio = int.Parse(separados[i+1]);
                enrutadores[i / 2 - 1].Numero = enrutador;
                enrutadores[i / 2 - 1].Radio = radio;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 6 && j == 5)
                    {
                        int a = 1;
                    }
                    if (i != j)
                    {
                        int left = enrutadores[j].Numero - enrutadores[j].Radio;
                        int right = enrutadores[j].Numero + enrutadores[j].Radio;

                        int myLeft = enrutadores[i].Numero - enrutadores[i].Radio;
                        int myRight = enrutadores[i].Numero + enrutadores[i].Radio;
                        if (myLeft <= left && myRight >= right)
                        {
                            enrutadores[i].Contenidos++;
                        }
                    }
                }
            }
            for (int i = 1; i <= q; i++)
            {
                int consulta = int.Parse(separados[i + 21]);
                Console.Write(enrutadores[consulta-1].Contenidos);
            }
            Console.Read();
        }
    }

    public class Enrutador
    {
        public int Numero;
        public int Radio;
        public int Contenidos;

        public Enrutador()
        {
            Numero = -1;
            Radio = 0;
            Contenidos = 0;
        }
    }
}
