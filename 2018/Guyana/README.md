# 🇬🇾 Guyana

Ximena, Oscar y Raúl son tres amigos a los que les gusta la criptografía.
Recientemente aprendieron un sencillo método de cifrado y decidieron utilizarlo para compartir archivos de manera segura. Desafortunadamente olvidaron la clave de encriptación que usaron: sólo recuerdan que era un número entero entre 0 y 255.
Podés ayudarlos a recuperar el mensaje original?

[https://s3.amazonaws.com/it.challenge.18/secreto.pdf](/2018/_docs/Guyana/secreto.pdf)

## Solución

El nombre de los amigos (**X**imena, **O**scar y **R**aúl) nos cuenta de forma implícita qué método de cifrado utilizaron. Con ese dato lo único que restaba hacer era intentar desencriptar el archivo utilizando el método **XOR** con un número entre `0` y `255` como key. Para eso implementamos este algoritmo:

```js
const fs = require('fs');

const xorCrypt = function (input, key) {
    var output = new Uint8Array(input.length);

    for (var i = 0; i < input.length; ++i) {
        output[i] = key ^ input[i];
    }

    return output;
}

const encrypted = fs.readFileSync('./secreto.pdf');

if (!fs.existsSync('./output')) {
    fs.mkdirSync('./output');
}

for (var i = 0; i <= 255; i++) {
    var decrypted = xorCrypt(encrypted, i);
    fs.writeFileSync(`./output/${i}.pdf`, decrypted);
}
```

<small>[Código fuente completo](main.cpp)</small>

## Repuesta

En el [archivo desencriptado](desencriptado.pdf) encontramos la respuesta al acertijo: 

```
eXtraORdinario!
```
