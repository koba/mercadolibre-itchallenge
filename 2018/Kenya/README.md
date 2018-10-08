# 🇰🇪 Kenya

Una caja que contiene N medallas fue encontrada en una excavación. Cada medalla está compuesta por diversas piedras y cada piedra está representada por una letra minúscula de la 'a' a 'z'. Una piedra puede estar presente varias veces en una medalla y una piedra pasa a ser llamada especial si está presente al menos una vez en cada medalla.

Dada una lista de N de medallas con sus piedras, muestra el cuadrado de la cantidad de piedras especiales que se repiten más de dos veces en una medalla.

Entrada

La primera línea consiste de N, el número de medallas. Cada una de las proximas N líneas contienen una secuencia de letras minúsculas con las piedras de cada medalla

```
5 
abcdefgggghijlmmmnopppqqqqrrr 
abcdefggghijlmmnopppqqqqrrr 
abcdefggggghijlmmmnopppqqqqrrr 
abcdefggggghijlmmmnopppqqqqrrr 
abcdefggggghijlmmmnopppqqqqrrr
```

## Solución

```js
let medals = ['abcdefgggghijlmmmnopppqqqqrrr', 'abcdefggghijlmmnopppqqqqrrr', 'abcdefggggghijlmmmnopppqqqqrrr', 'abcdefggggghijlmmmnopppqqqqrrr', 'abcdefggggghijlmmmnopppqqqqrrr'];
let stoness = [];

medals.forEach(medal => {
    let stonesc = {};
    medal.split('').forEach(stone => {
        if (stoness.indexOf(stone) >= 0) return;
        if (!stonesc[stone]) stonesc[stone] = 1; else stonesc[stone]++;
        if (stonesc[stone] > 2) stoness.push(stone);
    });
});

stoness.forEach((stone, i) => {
    medals.forEach(medal => {
        let o = medal.match(new RegExp(stone, 'g'));
        if (!o || o.length <= 2) {
            stoness.splice(i, 1);
        }
    });
});

console.log(stoness.length * stoness.length);
```

## 👨‍💻👩‍💻 Console

```
$ node index.js
16
```