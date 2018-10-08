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
```

<small>[Código fuente completo](Program.cs)</small>

## 👨‍💻👩‍💻 Console

```bash
$ csc Program.cs && mono Program.exe

PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+CjwhLS0gQ3JlYXRlZCB3aXRoIElua3NjYXBlIChodHRwOi8vd3d3Lmlua3NjYXBlLm9yZy8pIC0tPgoKPHN2ZwogICB4bWxuczpkYz0iaHR0cDovL3B1cmwub3JnL2RjL2VsZW1lbnRzLzEuMS8iCiAgIHhtbG5zOmNjPSJodHRwOi8vY3JlYXRpdmVjb21tb25zLm9yZy9ucyMiCiAgIHhtbG5zOnJkZj0iaHR0cDovL3d3dy53My5vcmcvMTk5OS8wMi8yMi1yZGYtc3ludGF4LW5zIyIKICAgeG1sbnM6c3ZnPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIKICAgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIgogICB4bWxuczpzb2RpcG9kaT0iaHR0cDovL3NvZGlwb2RpLnNvdXJjZWZvcmdlLm5ldC9EVEQvc29kaXBvZGktMC5kdGQiCiAgIHhtbG5zOmlua3NjYXBlPSJodHRwOi8vd3d3Lmlua3NjYXBlLm9yZy9uYW1lc3BhY2VzL2lua3NjYXBlIgogICB3aWR0aD0iMjk3bW0iCiAgIGhlaWdodD0iMjEwbW0iCiAgIHZpZXdCb3g9IjAgMCAyOTcgMjEwIgogICB2ZXJzaW9uPSIxLjEiCiAgIGlkPSJzdmczNzE5IgogICBpbmtzY2FwZTp2ZXJzaW9uPSIwLjkyLjMgKDI0MDU1NDYsIDIwMTgtMDMtMTEpIgogICBzb2RpcG9kaTpkb2NuYW1lPSJmbGFnLnN2ZyI+CiAgPGRlZnMKICAgICBpZD0iZGVmczM3MTMiIC8+CiAgPHNvZGlwb2RpOm5hbWVkdmlldwogICAgIGlkPSJiYXNlIgogICAgIHBhZ2Vjb2xvcj0iI2ZmZmZmZiIKICAgICBib3JkZXJjb2xvcj0iIzY2NjY2NiIKICAgICBib3JkZXJvcGFjaXR5PSIxLjAiCiAgICAgaW5rc2NhcGU6cGFnZW9wYWNpdHk9IjAuMCIKICAgICBpbmtzY2FwZTpwYWdlc2hhZG93PSIyIgogICAgIGlua3NjYXBlOnpvb209IjAuMzUiCiAgICAgaW5rc2NhcGU6Y3g9IjYwIgogICAgIGlua3NjYXBlOmN5PSI1NjAiCiAgICAgaW5rc2NhcGU6ZG9jdW1lbnQtdW5pdHM9Im1tIgogICAgIGlua3NjYXBlOmN1cnJlbnQtbGF5ZXI9ImxheWVyMSIKICAgICBzaG93Z3JpZD0iZmFsc2UiCiAgICAgaW5rc2NhcGU6d2luZG93LXdpZHRoPSIxODUzIgogICAgIGlua3NjYXBlOndpbmRvdy1oZWlnaHQ9IjEwMjUiCiAgICAgaW5rc2NhcGU6d2luZG93LXg9IjY3IgogICAgIGlua3NjYXBlOndpbmRvdy15PSIyNyIKICAgICBpbmtzY2FwZTp3aW5kb3ctbWF4aW1pemVkPSIxIiAvPgogIDxtZXRhZGF0YQogICAgIGlkPSJtZXRhZGF0YTM3MTYiPgogICAgPHJkZjpSREY+CiAgICAgIDxjYzpXb3JrCiAgICAgICAgIHJkZjphYm91dD0iIj4KICAgICAgICA8ZGM6Zm9ybWF0PmltYWdlL3N2Zyt4bWw8L2RjOmZvcm1hdD4KICAgICAgICA8ZGM6dHlwZQogICAgICAgICAgIHJkZjpyZXNvdXJjZT0iaHR0cDovL3B1cmwub3JnL2RjL2RjbWl0eXBlL1N0aWxsSW1hZ2UiIC8+CiAgICAgICAgPGRjOnRpdGxlIC8+CiAgICAgIDwvY2M6V29yaz4KICAgIDwvcmRmOlJERj4KICA8L21ldGFkYXRhPgogIDxnCiAgICAgaW5rc2NhcGU6bGFiZWw9IkxheWVyIDEiCiAgICAgaW5rc2NhcGU6Z3JvdXBtb2RlPSJsYXllciIKICAgICBpZD0ibGF5ZXIxIgogICAgIHRyYW5zZm9ybT0idHJhbnNsYXRlKDAsLTg3KSI+CiAgICA8dGV4dAogICAgICAgeG1sOnNwYWNlPSJwcmVzZXJ2ZSIKICAgICAgIHN0eWxlPSJmb250LXN0eWxlOm5vcm1hbDtmb250LXdlaWdodDpub3JtYWw7Zm9udC1zaXplOjQyLjMzMzMzMjA2cHg7bGluZS1oZWlnaHQ6MS4yNTtmb250LWZhbWlseTpzYW5zLXNlcmlmO2xldHRlci1zcGFjaW5nOjBweDt3b3JkLXNwYWNpbmc6MHB4O2ZpbGw6IzAwMDAwMDtmaWxsLW9wYWNpdHk6MTtzdHJva2U6bm9uZTtzdHJva2Utd2lkdGg6MC4yNjQ1ODMzMiIKICAgICAgIHg9IjIxLjE2NjU5MiIKICAgICAgIHk9IjIwOC45NjcwMSIKICAgICAgIGlkPSJ0ZXh0ODgiPjx0c3BhbgogICAgICAgICBzb2RpcG9kaTpyb2xlPSJsaW5lIgogICAgICAgICB4PSIyMS4xNjY1OTIiCiAgICAgICAgIHk9IjIwOC45NjcwMSIKICAgICAgICAgaWQ9InRzcGFuODYiCiAgICAgICAgIHN0eWxlPSJzdHJva2Utd2lkdGg6MC4yNjQ1ODMzMiI+PHRzcGFuCiAgICAgICAgICAgeD0iMjEuMTY2NTkyIgogICAgICAgICAgIHk9IjIwOC45NjcwMSIKICAgICAgICAgICBpZD0idHNwYW44NCIKICAgICAgICAgICBzdHlsZT0ic3Ryb2tlLXdpZHRoOjAuMjY0NTgzMzIiPnYzY3QwcjF6YWQwPC90c3Bhbj48L3RzcGFuPjwvdGV4dD4KICA8L2c+Cjwvc3ZnPgo=
```

Base64 decode:

```xml
<?xml version="1.0" encoding="UTF-8" standalone="no"?>
<!-- Created with Inkscape (http://www.inkscape.org/) -->

<svg
   xmlns:dc="http://purl.org/dc/elements/1.1/"
   xmlns:cc="http://creativecommons.org/ns#"
   xmlns:rdf="http://www.w3.org/1999/02/22-rdf-syntax-ns#"
   xmlns:svg="http://www.w3.org/2000/svg"
   xmlns="http://www.w3.org/2000/svg"
   xmlns:sodipodi="http://sodipodi.sourceforge.net/DTD/sodipodi-0.dtd"
   xmlns:inkscape="http://www.inkscape.org/namespaces/inkscape"
   width="297mm"
   height="210mm"
   viewBox="0 0 297 210"
   version="1.1"
   id="svg3719"
   inkscape:version="0.92.3 (2405546, 2018-03-11)"
   sodipodi:docname="flag.svg">
  <defs
     id="defs3713" />
  <sodipodi:namedview
     id="base"
     pagecolor="#ffffff"
     bordercolor="#666666"
     borderopacity="1.0"
     inkscape:pageopacity="0.0"
     inkscape:pageshadow="2"
     inkscape:zoom="0.35"
     inkscape:cx="60"
     inkscape:cy="560"
     inkscape:document-units="mm"
     inkscape:current-layer="layer1"
     showgrid="false"
     inkscape:window-width="1853"
     inkscape:window-height="1025"
     inkscape:window-x="67"
     inkscape:window-y="27"
     inkscape:window-maximized="1" />
  <metadata
     id="metadata3716">
    <rdf:RDF>
      <cc:Work
         rdf:about="">
        <dc:format>image/svg+xml</dc:format>
        <dc:type
           rdf:resource="http://purl.org/dc/dcmitype/StillImage" />
        <dc:title />
      </cc:Work>
    </rdf:RDF>
  </metadata>
  <g
     inkscape:label="Layer 1"
     inkscape:groupmode="layer"
     id="layer1"
     transform="translate(0,-87)">
    <text
       xml:space="preserve"
       style="font-style:normal;font-weight:normal;font-size:42.33333206px;line-height:1.25;font-family:sans-serif;letter-spacing:0px;word-spacing:0px;fill:#000000;fill-opacity:1;stroke:none;stroke-width:0.26458332"
       x="21.166592"
       y="208.96701"
       id="text88"><tspan
         sodipodi:role="line"
         x="21.166592"
         y="208.96701"
         id="tspan86"
         style="stroke-width:0.26458332"><tspan
           x="21.166592"
           y="208.96701"
           id="tspan84"
           style="stroke-width:0.26458332">v3ct0r1zad0</tspan></tspan></text>
  </g>
</svg>
```

Respuesta:

```
v3ct0r1zad0
```