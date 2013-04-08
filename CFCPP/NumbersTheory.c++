template<class T>
T modPow(T x, T m, T p) {
    T tail = 1;
    while (m > 0) {
        if ((m & 1) == 1)
            tail = (tail * x) % p;
        x = (x * x) % p;
        m >>= 1;
    }

    return tail;
}

template<class T>
T gcd(T a, T b) {
    while (true) {
        if (a < b) swap(a, b);
        if (b == 0)return a;
        a = a % b;
    }
}

template<class T>
T lcm(T a, T b) {
    T g = gcd(a, b);
    return (a / g) * b;
}
