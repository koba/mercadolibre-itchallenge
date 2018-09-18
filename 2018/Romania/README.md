# Romania

El sistema de encriptación RSA, como parte de la fase de generación de claves públicas y privadas, debe generar dos números primos grandes p y q y un número n = p*q que se usará luego para encriptar y desencriptar mensajes (ver https://simple.wikipedia.org/wiki/RSA_algorithm)

Una reconocida empresa de Palermagro decidió realizar su propia implementación de este sistema. Decidieron generar los primos p y q con dos algoritmos diferentes pensando que así obtendrían mayor seguridad.

La ingeniera Melanie S. implementó la siguiente función:

```
def generate_p():
    '''
    algoritmo eficiente, seguro y testeado para generar primos grandes
    '''
    ...
    ...
    return p
```

El ingeniero N. Álvarez, sin muchas ganas de programar, decidió tomar un atajo y programar lo siguiente:

```
def generate_q():
    '''
    genera un primo
    '''
    return 1094782941871623486260250734009229761
```

Has tenido acceso a uno de los mensajes encriptados así como también a un PEM que contiene la clave pública de encriptación. ¿Sos capaz de descubrir el contenido del mensaje original?

[https://s3.amazonaws.com/it.challenge.18/problem20.zip](/2018/_s3/Romania/problem20.zip)

## Solución

0. https://simple.wikipedia.org/wiki/RSA_algorithm

1. Nos dan `q = 1094782941871623486260250734009229761`.

2. De la [*public key*](/2018/_s3/Romania/problem20/id_rsa.pub) se puede obtener `n`. Analizando la llave pública en https://8gwifi.org/PemParserFunctions.jsp obtuvimos la siguiente información:

    ```
    Algo RSA
    Format X.509
    ASN1 Dump
    RSA Public Key [40:dc:a8:a1:af:2b:d1:c2:d6:f0:c3:a0:25:94:bc:3a:c6:97:b1:a8]
                modulus: 8a909ec2d6b3fa235772a083bf1e6dd3a1bfab801ea831530656c46916643b95
        public exponent: 10001
    ```

    `n = 8a909ec2d6b3fa235772a083bf1e6dd3a1bfab801ea831530656c46916643b95`.

3. Ahora que tenemos `q` y `n` podemos despejar `p`:

    `p = n / q = 57248512388615138300979959427360676128469`

4. Teniendo `p` y `q` podemos reconstruir el `keypair`. Sólo nos falta el algoritmo #/ ([Que por suerte encontramos acá](http://www.loyalty.org/~schoen/rsa/private-from-pq.c)):

    ```c
    int main (int argc, char *argv[]) {
        BIGNUM *n = BN_new ();
        BIGNUM *d = BN_new ();
        BIGNUM *e = BN_new ();
        BIGNUM *p = BN_new ();
        BIGNUM *q = BN_new ();
        BIGNUM *p1 = BN_new ();
        BIGNUM *q1 = BN_new ();
        BIGNUM *dmp1 = BN_new ();
        BIGNUM *dmq1 = BN_new ();
        BIGNUM *iqmp = BN_new ();
        BIGNUM *phi = BN_new ();
        BN_CTX *ctx = BN_CTX_new ();
        RSA *key = RSA_new ();

        BN_dec2bn (&e, "65537");

        /* Calculate RSA private key parameters */
        
        BN_mul (n, p, q, ctx);              /* n = p*q */
        BN_sub (p1, p, BN_value_one ());    /* p1 = p-1 */
        BN_sub (q1, q, BN_value_one ());    /* q1 = q-1 */
        BN_mul (phi, p1, q1, ctx);          /* phi(pq) = (p-1)*(q-1) */
        BN_mod_inverse (d, e, phi, ctx);    /* d = e^-1 mod phi */
        BN_mod (dmp1, d, p1, ctx);          /* dmp1 = d mod (p-1) */
        BN_mod (dmq1, d, q1, ctx);          /* dmq1 = d mod (q-1) */
        BN_mod_inverse (iqmp, q, p, ctx);   /* iqmp = q^-1 mod p */

        /* Populate key data structure */
        key->n = n;
        key->e = e;
        key->d = d;
        key->p = p;
        key->q = q;
        key->dmp1 = dmp1;
        key->dmq1 = dmq1;
        key->iqmp = iqmp;

        /* Output the private key in human-readable and PEM forms */
        RSA_print_fp (stdout, key, 5);
        PEM_write_RSAPrivateKey (stdout, key, NULL, NULL, 0, 0, NULL);
    }
    ```
    
    <small>[Código fuente completo](main.c)</small>


5. Compilamos el algoritmo anterior para luego ejecutarlo y obtener la llave privada que guardaremos en el archivo [private.key](private.key):

    ```bash
    gcc main.c -lssl -lcrypto -o main.out -w && ./main.out 57248512388615138300979959427360676128469 1094782941871623486260250734009229761
    ```

6. Por último ejecutamos el siguiente comando para desencriptar el archivo de datos original y obtener la respuesta al desafío:

    ```bash
    $ openssl rsautl -decrypt -inkey private.key -in data -out desencriptado.txt
    ```

    ```bash
    $ cat desencriptado.txt
    3lr5a3star0t0
    ```

## Links y Referencias Útiles

* http://www.loyalty.org/~schoen/rsa
