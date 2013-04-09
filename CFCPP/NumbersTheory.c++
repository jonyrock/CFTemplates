long long modPow(long long x, long long m, long long p) {
    long long tail = 1;
    x = x % p;
    while (m > 0) {
        if ((m & 1) == 1)
            tail = (tail * x) % p;
        x = (x * x) % p;
        m >>= 1;
    }

    return tail;
}

long long gcd(long long a, long long b) {
    while (true) {
        if (a < b) swap(a, b);
        if (b == 0)return a;
        a = a % b;
    }
}


long long lcm(long long a, long long b) {
    T g = gcd(a, b);
    return (a / g) * b;
}
