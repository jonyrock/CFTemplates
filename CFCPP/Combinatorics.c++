long long chooseCash[1001][1001]; // before use!!!!! memset((chooseCash), 0, sizeof(chooseCash));
long long mod = 1000000007;
long long choose(long long n, long long k) {
    if (k > n) return 0;
    if (k < 0) return 0;
    if (k == n) return 1;
    if (chooseCash[n][k] != 0)
        return chooseCash[n][k];
    long long left = choose(n - 1, k - 1);
    chooseCash[n - 1][k - 1] = left;
    long long right = choose(n - 1, k) % mod;
    chooseCash[n - 1][k] = right;
    return (left + right) % mod;
}
