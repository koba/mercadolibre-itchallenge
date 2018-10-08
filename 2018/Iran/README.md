# 🇮🇷 Iran

En una cueva oscura de la ciudad de Pueblo Paleta fue hallada una escritura muy antigua. Ningún profesor logró descifrar lo que significa, pero se rumorea que contiene la clave para atrapar a todos los pokemones legendarios. ¿Podés ayudarlos a descubrir lo que significa el mensaje?

[https://www.dropbox.com/s/78cfb7z4kmpj8or/test.jpg?dl=0](/2018/_docs/Iran/test.jpg)

## Solución

1. Ejecutamos el siguiente script que toma la secuencia de los números asignados a cada Pokémon, le aplica la operación NOT, y convierte esos números en caracteres de la tabla ASCII:

    ```js
    let pokemon = [
        92,  95,  82,  85,  82,  95,  26,  17,  28,  16,  27,  22,  17,  24,  69,  95,  10,  11,  25,  82,  71,  95,  82,  85,
        82, 117, 117,  22,  25,  95,  32,  32,  17,  30,  18,  26,  32,  32,  95,  66,  66,  95,  93,  32,  32,  18,  30,  22,
        17,  32,  32,  93,  69, 117, 118,  92,  95,  60,  16,  18,  15,  10,  11,  22,  17,  24,  95,  16,  10,  13,  95,  18,
        30,  24,  22,  28,  95,  17,  10,  18,  29,  26,  13,  81,  81,  81, 117, 118,  92,  95,  54,  95,   8,  16,  17,  27,
        26,  13,  95,   8,  23,  6,   95,  22,  11,  95,  22,  12,  95,  11,  30,  20,  22,  17,  24,  95,  12,  16,  95,  19,
        16,  17,  24,  94, 117, 117, 118,  18,  30,   7,  32,  19,  22,  18,  22,  11,  95,  66,  95,  78,  77,  76,  75,  74,
        73,  72,  71,  70,  71,  72,  73,  74,  75,  76,  77,  79, 117, 117, 118,  92,  95,  13,  30,  17,  24,  26,  95,  22,
        12,  95,  24,  22,   9,  22,  17,  24,  95,  18,  26,  95,  18,  26,  18,  16,  13,   6,  95,  26,  13,  13,  16,  13,
        95,  22,  17,  95,  15,   6,  11,  23,  16,  17,  77,  83,  95,   8,  26,  89,  27,  95,  29,  26,  11,  11,  26,  13,
        95,  10,  12,  26,  95,  30,  95,  24,  26,  17,  26,  13,  30,  11,  16,  13, 117, 118,  28,  16,  10,  17,  11,  95,
        66,  95,  79, 117, 118,  25,  16,  13,  95,  22,  95,  22,  17,  95,   7,  13,  30,  17,  24,  26,  87,  18,  30,   7,
        32,  19,  22,  18,  22,  11,  86,  69, 117, 118, 118,  28,  16,  10,  17,  11,  95,  84,  66,  95,  78, 117, 117, 118,
        19,  22,  17,  26,  30,  13,  32,  12,  10,  18,  95,  66,  95,  79, 117, 118,  25,  16,  13,  95,  21,  95,  22,  17,
        95,   7,  13,  30,  17,  24,  26,  87,  18,  30,   7,  32,  19,  22,  18,  22,  11,  86,  69, 117, 118, 118,  19,  22,
        17,  26,  30,  13,  32,  12,  10,  18,  95,  84,  86,  95,  21, 117, 117, 118,  12,  14,  10,  30,  13,  26,  27,  32,
        12,  10,  18,  95,  66,  95,  79, 117, 118,  25,  16,  13,  95,  20,  95,  22,  17,  95,   7,  13,  30,  17,  24,  26,
        87,  18,  30,   7,  32,  19,  22,  18,  22,  11,  95,  80,  95,  74,  86,  69, 117, 118, 118,  12,  14,  10,  30,  13,  
        26,  27,  32,  12,  10,  18,  95,  84,  66,  95,  20,  95,  85,  95,  20, 117, 117, 118,  28,  10,  29,  22,  28,  32,
        12,  10,  18,  95,  66,  95,  79, 117, 118,  25,  16,  13,  95,  19,  95,  22,  17,  95,   7,  13,  30,  17,  24,  26,
        87,  18,  30,   7,  32,  19,  22,  18,  22,  11,  95,  80,  95,  77,  79,  86,  69, 117, 118, 118,  29,  10,  29,  22,
        28,  32,  12,  10,  18,  95,  84,  66,  95,  19,  95,  85,  95,  19,  95,  85,  95,  19, 117, 117, 118,  15,  13,  22,
        17,  11,  87,  19,  22,  17,  26,  30,  13,  32,  12,  10,  18,  95,  84,  95,  12,  14,  10,  30,  13,  26,  27,  32,   
        12,  10,  18,  95,  84,  95,  28,  10,  29,  22,  28,  32,  12,  10,  18,  86, 117
    ];

    let ascii = pokemon.map(dec => {
        let bin = ('0000000' + (dec).toString(2)).slice(-7);
        let binNot = bin.replace(/0/g, '2').replace(/1/g, '0').replace(/2/g, '1');
        return parseInt(binNot, 2);
    });

    let code = ascii.map(ascii => String.fromCharCode(ascii)).join('');

    console.log(code);
    ```

    <small>[Código fuente completo](index.js)</small>

2. El script anterior devuelve un script escrito en `python` que modificamos un poco para hacerlo que corra en O(1) y obtener el resultado del ejercicio:

    ```python
    # -*- encoding: utf-8 -*-

    if __name__ == "__main__":
            # Computing our magic number...
            # I wonder why it is taking so long!

            max_limit = 12345678987654320

            linear_sum = max_limit * (max_limit + 1) / 2

            max_limit /= 5
            squared_sum = max_limit * (max_limit + 1) * (max_limit * 2 + 1) / 6

            max_limit = max_limit * 5 * 20
            cubic_sum = max_limit * max_limit * (max_limit + 1) * (max_limit + 1) * 2

            print(linear_sum + squared_sum + cubic_sum)
    ```

    <small>[Código fuente completo](main.py)</small>

## 👨‍💻👩‍💻 Console

```
$ node index.js
# -*- encoding: utf-8 -*-

if __name__ == "__main__":
        # Computing our magic number...
        # I wonder why it is taking so long!

        max_limit = 12345678987654320

        # range is giving me memory error in python2, we&d better use a generator
        count = 0
        for i in xrange(max_limit):
                count += 1

        linear_sum = 0
        for j in xrange(max_limit):
                linear_sum +) j

        squared_sum = 0
        for k in xrange(max_limit / 5):
                squared_sum += k * k

        cubic_sum = 0
        for l in xrange(max_limit / 20):
                bubic_sum += l * l * l

        print(linear_sum + squared_sum + cubic_sum)
```

```
$ python main.py
7433783340663738542873005463250248087330893002856106113716758759497600
```