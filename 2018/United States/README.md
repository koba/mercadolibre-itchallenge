# 🇺🇸 United States

Dados dos nombres de usuario, el grado de similitud se define como la longitud del prefijo más largo común a ambas cadenas. En este desafío, recibirás una cadena. Debes quebrar la cadena para crear sufijos cada vez más cortos y luego determinar la similitud del sufijo con la cadena original. Haz esto para cada longitud de sufijo desde la longitud de la cadena hasta 0 y acumula los resultados. Por ejemplo, considera la cadena 'ababa'

[https://www.dropbox.com/s/uprg7sgnalepyhu/Cadena%20ejemplo..docx?dl=0](/2018/_docs/United%20States/Cadena%20ejemplo.docx)

Cadena input: [https://www.dropbox.com/s/qdfr7nd22cq8dil/Copia%20de%20input007.txt?dl=0](/2018/_docs/United%20States/Username%20Disparity.txt)

La respuesta a ingresar en el sistema es la respuesta para cada caso de test en el orden en que aparece en el archivo, separando por un espacio.

Sample Input 0

```
1
ababaa 
```

Sample Output 0

```
11
```

## Solución

```c#
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
}
```

<small>[Código fuente completo](Program.cs)</small>

## 👨‍💻👩‍💻 Console

```bash
$ csc Program.cs && mono Program.exe

110
51
119
71
109
21
83
99
2
75
```