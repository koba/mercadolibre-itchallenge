# 🇷🇺 Russia

Los vecinos de Calle Larga están preocupados porque la calidad de su conexión Wi-Fi ha empeorado considerablemente en los últimos años y debido a esto no pueden ver Game of Thrones tranquilamente.

Cada una de las casas en la calle posee un enrutador cuyas características determinan el alcance de su señal. La señal de cada enrutador corresponde a un círculo determinado por un radio r. Cuando dos señales se intersectan se produce interferencia lo que degrada considerablemente la conexión.

En la última reunión de la junta de vecinos, la comunidad determinó que la única solución para su problema era compartir la conexión a internet entre algunos vecinos para así poder prescindir de algunos enrutadores. Lamentablemente, la comisión encargada de poner el plan en marcha está teniendo problemas para evaluar qué enrutadores son mejores candidatos para ser mantenidos. Específicamente, dado un enrutador les gustaría determinar la cantidad de señales que este contiene completamente. Si la señal de un enrutador contiene completamente la señal de muchos enrutadores entonces este es un buen candidato para ser mantenido.

La entrada contiene una sola línea con enteros separados por un espacio en blanco. Los dos primeros enteros N y Q (0 ≤ N ≤ 2 × 10^5, 0 ≤ Q ≤ 5 × 10^4) corresponden respectivamente a la cantidad total de enrutadores y la cantidad de enrutadores por los cuales se hará una consulta. Cada uno de los siguientes N pares de números describe un enrutador. El par i-ésimo describe el enrutador i con dos enteros p y r (0 ≤ p ≤ 10^9, 0 < r ≤ 10^9) que representan respectivamente la posición del enrutador en la calle y el radio de alcance de su señal. No habrá dos enrutadores en la misma posición. Los siguientes Q enteros contienen la descripción de una consulta. Cada consulta está descrita con un entero i (1 ≤ q ≤ N) indicando que se desea determinar la cantidad de señales que están completamente contenidas en la señal del enrutador i.

Por cada consulta debe imprimirse un entero. Cada entero debe corresponder a la cantidad de señales que están contenidas completamente en la señal del enrutador de la consulta.

Se deberá ingresar la concatenación de todos los casos de prueba en orden, sin espacios.

Entrada
```
10 10 9106 137 5339 852 3726 3952 994 210 5304 1471 5990 3581 3266 4392 5290 439 9299 296 9437 479 7 6 8 1 6 7 7 3 7 6
```

## Solución

```c#
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
}
```

<small>[Código fuente completo](Program.cs)</small>

## 👨‍💻👩‍💻 Output

```bash
$ csc Program.cs && mono Program.exe
4400444444
```
