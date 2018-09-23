using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mercadolibre.USA
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"../_docs/United States/Username Disparity.txt");
            int totalLines = int.Parse(lines[0]);
            

            for (int i = 1; i <= totalLines; i++)   //recorro todas las lineas
            {
                int result = 0;
                string line = lines[i];
                string sufijo = string.Copy(line);
                result += line.Length;

                for (int j = 0; j < line.Length; j++)
                {
                    sufijo = sufijo.Substring(1);
                    string auxSufijo = string.Copy(sufijo);
                    string auxLine = string.Copy(line);

                    bool next = true;

                    while (!string.IsNullOrEmpty(auxSufijo) && !string.IsNullOrEmpty(auxLine) && next)
                    {
                        if (auxSufijo[0] == auxLine[0])
                        {
                            auxLine = auxLine.Substring(1);
                            auxSufijo = auxSufijo.Substring(1);
                            result += 1;
                        }
                        else
                            next = false;
                    }
                }
                Console.WriteLine(result);
            }

            Console.WriteLine("final");
        }
    }
}
