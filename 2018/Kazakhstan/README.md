# 🇰🇿 Kazakhstan

Las ruletas con mensaje son un complicado esfuerzo de criptógrafos amateur para transmitir mensajes de manera trabajosa y cuya efectividad es absolutamente dudosa.

Son ruletas divididas en una cantidad par de sectores y en las que cada sector contiene algún carácter ASCII. En la parte superior hay un marcador llamado ORDEN y en la parte INFERIOR hay un marcador llamado MENSAJE. 

El protocolo determina que se lee comenzando en el sector marcado por ORDEN y en sentido horario todas las letras de la ruleta. Por ejemplo, en la siguiente posición inicial se puede leer la palabra BANANA

[https://www.dropbox.com/s/kskiiv2vxv8t5a7/banana.jpg?dl=0](/2018/_docs/Kazakhstan/banana.jpg)

Luego la ruleta comienza a girar y se irán mostrando sucesivamente las siguientes palabras:

```
BANANA
ANANAB
NANABA
ANABAN
NABANA
ABANAN
```

En el momento en el que la palabra leída desde la posición ORDEN es la mínima lexicográfica (la que aparecería primero en un diccionario), se podrá leer a partir de la posición MENSAJE un mensaje oculto de una longitud acordada previamente. 

En el ejemplo anterior, el momento en que se muestra el mensaje es cuando desde ORDEN se lee la palabra ABANAN, como se muestra en la siguiente imagen.

[https://www.dropbox.com/s/os05nkcxcezb7i6/abanan.jpg?dl=0](/2018/_docs/Kazakhstan/abanan.jpg)


Si la longitud acordada era 2, el mensaje oculto sería NA

Hemos descubierto una ruleta increíblemente grande. Contiene exactamente un millón de letras. Sabemos también que el mensaje cifrado que encontraremos allí tiene una longitud de 2976. El contenido de la ruleta en su estado inicial está dado en el archivo roulette.txt

[https://www.dropbox.com/s/4wec7pfsvvl5tt3/roulette.txt?dl=0](/2018/_docs/Kazakhstan/roulette.txt)

¿Podés ayudarnos a descubrirlo?

Aclaración: Para realizar la comparación "alfabética" de símbolos en el archivo deben utilizarse sus valores ASCII. 

## Solución 

```c#
static void Main(string[] args)
{
    string line = File.ReadAllText(@"C:\Users\Tonga\Downloads\roulette.txt");

    int from = 299053 + 500000;
    int to = from + 2976;
    string result = "";
    for (int i = 299053 + 500000; i < to; i++)
    {
        result += line[i];
    }
    Console.Write(result);
    Console.Read();
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
```

<small>[Código fuente completo](Program.cs)</small>