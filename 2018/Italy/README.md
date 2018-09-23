# 🇮🇹 Italy

La Escuela de Idiomas y Ciencias enseña cinco materias: Física, Química, Matemáticas, Botánica y Zoología. Cada estudiante es experto en una materia. Las habilidades de los alumnos se describen mediante una string de las habilidades citadas que consta de las letras p, c, m, b y z solamente. Cada carácter describe la habilidad de un estudiante de la siguiente manera:

```
p → Física.
c → Química.
m → Matemáticas.
b → Botánica.
z → Zoología.
```

Tu tarea es determinar el número total de diferentes equipos que satisfacen las siguientes restricciones:
 
Un equipo consiste en un grupo de exactamente cinco estudiantes.

Cada estudiante es experto en una materia diferente.

Un estudiante puede estar solo en un equipo.
 
Por ejemplo, si la cadena de habilidades es pcmbzpcmbz, entonces hay dos equipos posibles que se pueden formar a la vez: habilidades [0-4] y habilidades [5-9]. No es importante determinar las permutaciones, ya que siempre estaremos limitados a dos equipos con 10 estudiantes.
 
Se le proporciona un archivo con la entrada [https://www.dropbox.com/s/3neyzkiomsb7eh8/Copia%20de%20input013.txt?dl=0](/2018/_docs/Italy/Copia%20de%20input013.txt)
 
Restricciones 

5 ≤ n ≤ 5 × 105

skills[i] ∈ {p,c,m,b,z}
 
Sample Input 0 pcmbz

Sample Output 0 1

## Solución 

```c#
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
```

<small>[Código fuente completo](Program.cs)</small>

## 👨‍💻👩‍💻 Output

```bash
$ csc Program.cs && mono Program.exe

50334
```
