# Argentina

¡Científicos del centro para el Tratamiento y Control de la Población, hicieron un impresionante descubrimiento! Las alpacas, en lugar de portar un código genético compuesto de bases adenina (A), citosina (C), guanina (G) y timina (T), poseen bases completamente distintas: su ADN está compuesto de bases (A),(C),(L) y (P) donde (L) es lanina y (P) es preciosina. Más aún, los investigadores descubrieron que el código genético de las alpacas es extremadamente estructurado. Este se puede codificar como una secuencia sobre el alfabeto {A,C,L,P} aplicando algunas reglas. 

Partiendo con la letra A la secuencia que describe el ADN puede generarse aplicando N veces el siguiente conjunto de reglas de forma simultánea:

Reemplazar cada ocurrencia de (A) por (AL)
Reemplazar cada ocurrencia de (L) por (PACA)
Reemplazar cada ocurrencia de (P) por (CP)
Reemplazar cada ocurrencia de (C) por (PC)
Por ejemplo, si N = 3 la secuencia obtenida será ALPACACPALPCAL:

A −→ AL −→ ALPACA −→ ALPACACPALPCAL
Los científicos están estudiando la hermosura de las alpacas. Hasta el momento han descubierto que existen M tipos de hermosura distintas. Y más aún, también han logrado relacionar el tipo de hermosura de una alpaca con la cantidad de veces que la subcadena (ALPACA) aparece en su secuencia de ADN. En particular, si (ALPACA) aparece D veces en la secuencia de ADN de una alpaca, entonces su tipo de hermosura está dado por el resto de la división de D por M. ¿Podrías ayudar a nuestros científicos a determinar qué tan bella es una alpaca en particular?
La entrada consiste en una única línea que contiene dos números N y M separados por un espacio, donde N indica el número de iteraciones que describen el ADN de la alpaca (1 ≤ N ≤ 10^15), y M es la cantidad de tipos de hermosura (2 ≤ M ≤ 10^9).

Entrada:
234612846789231 123456789

La respuesta es un único entero conteniendo el tipo de hermosura de la alpaca (D mod M).

## Solución

La respuesta en función de `N` sigue la [secuencia de Jacobsthal](https://oeis.org/A001045).

Para hallar el número `N` de dicha secuencia % `M`, implementamos este algoritmo (Basados en este trabajo https://medium.com/competitive/huge-fibonacci-number-modulo-m-6b4926a5c836):

```cpp
typedef long long ll;

ll get_pisano_period(ll m) {
    ll a = 0, b = 1, c = a * 2 + b;
    for (int i = 0; i < m * m; i++) {
        c = (a * 2 + b) % m;
        a = b;
        b = c;
        if (a == 0 && b == 1) return i + 1;
    }
}

ll get_jacobsthal_huge(ll n, ll m) {
    ll remainder = n % get_pisano_period(m);

    ll first = 0;
    ll second = 1;

    ll res = remainder;

    for (int i = 1; i < remainder; i++) {
        res = (first * 2 + second) % m;
        first = second;
        second = res;
    }

    return res % m;
}

int main() {
    ll n = 234612846789230;
    ll m = 123456789;
    
    cout << get_jacobsthal_huge(n, m) << endl;
}
```

<small>[Código fuente completo](main.cpp)</small>

### Código en Acción

```bash
$ g++ main.cpp -o main.out && ./main.out
118267624
```
