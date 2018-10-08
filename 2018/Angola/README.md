# 🇦🇴 Angola

Tienes 4 tipos de bloques Lego™, de tamaños (1 x 1 x 1), (1 x 1 x 2), (1 x 1 x 3) y (1 x 1 x 4). Suponé que tienes un número infinito de bloques de cada tipo. Para abreviar, podemos llamar a estos tipos, respectivamente, bloque 1, bloque 2, bloque 3 y bloque 4, o incluso (1), (2), (3) y (4).

Usando estos bloques, deseas hacer una pared de altura N y ancho M. La pared debe ser una estructura sólida continua sin agujeros. La pared debe estar conectada estructuralmente, por lo que no debe existir una vertical recta que permita que la pared se separe en dos sin cortar uno o más ladrillos.

Input (entrada):

La primera línea contiene el número de casos de prueba T. Siguen los casos de prueba T. Cada caso contiene dos enteros, N y M. 

[https://www.dropbox.com/s/h2brnoa5bg57zve/input%20Lego.txt?dl=0](/2018/_docs/Angola/input%20Lego.txt)
 
Output (salida):

Una sola línea que contiene la cantidad de formas de construir el muro.

Como los números pueden ser muy grandes, puedes aplicar modulo 1.000.000.007 a la salida.
 
Restricciones:

1 ≤ T ≤ 100

1 ≤ N,M ≤ 1000
 
Sample Input:

```
4
2 2
3 2
2 3
4 4
```

Sample Output:

```
3793375
```

## Solución

```java
static final long MODULO = 1000000007;
    
static long[] cache;

public static long pow(long x, long n, long p) {
    long result = 1;
    while (n > 0) {
        if ((n & 1) == 1) {
            result = (result * x) % p;
        }

        x = (x * x) % p;
        n = n >> 1;
    }

    return result;
}

private static long solveSingleRow(int width) {
    if (width == 0) {
        return 1;
    } else if (width < 0) {
        return 0;
    } else {
        if (cache[width] == -1) {
            cache[width] = (solveSingleRow(width - 1) + solveSingleRow(width - 2) + solveSingleRow(width - 3) + solveSingleRow(width - 4)) % MODULO;
        }
        return cache[width];
    }
}

private static long[][] solve(int height, int width) {
    long[][] a = new long[height + 1][width + 1];
    long[][] s = new long[height + 1][width + 1];

    cache = new long[width + 1];

    for (int w = 0; w <= width; w++) {
        cache[w] = -1;
    }

    for (int w = 1; w <= Math.min(width, 4); w++) {
        s[1][w] = 1;
    }

    for (int h = 1; h <= height; h++) {
        for (int w = 1; w <= width; w++) {
            long oneRow = solveSingleRow(w);
            a[h][w] = pow(oneRow, h, MODULO);
        }

        for (int w = 1; w <= width; w++) {
            long bad = 0;
            for (int l = 1; l <= w - 1; l++) {
                bad += ((s[h][l] * a[h][w - l]) % MODULO);
                bad = bad % MODULO;
            }

            s[h][w] = (a[h][w] - bad) % MODULO;
        }

    }
    
    return s;
}
```

## 👨‍💻👩‍💻 Console

```
$ javac Angola.java && java Angola

57267904814451331745189893695973964359505292661965474662063971797548757270907651050178863733364091715091360372145697643264311638434328712077320151330417298714531089118202970462983220677193571818987069148643988771997254871263377607061824810806355659733038793657267433102465900099468172398832751329987633579179571142862266133245061541847350948618985523661934450639742237697983482725374111330223916797028543830748439267126707162675285537288389498627341941393357756779929824579089988051381574322791720278523662334261709401156904434073546397524632728997161268586386854505786752064596132778826456257830169939392737185799538337178915543094575578255615121402030795364489417433176092853213409139334842923006057725738646825727705627712683131231224119442455404157566030518231798336611599203392554312679819153304352460636234662250474840732178557502371511674648132455344260125943890882163365827973107327749
```