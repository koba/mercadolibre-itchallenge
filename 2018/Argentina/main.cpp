/**
 * Algoritmo para hallar el número N de la secuencia de Jacobsthal % M
 * por Agustín Rodríguez (Koba) - 2018
 * 
 * Adaptado de https://gist.github.com/aadimator/4950f34fb476382a4a49eb86395726ce#file-fibonacci_huge-cpp
 */

#include <iostream>

using namespace std;

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