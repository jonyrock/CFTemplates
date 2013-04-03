int pw (ll a, int n){
    int res = 1;
	while ( n ){
		if ( n & 1 )
			res = ( res * a ) % mod;
		a = ( a * a ) % mod;
		n >>= 1;
	}
	return res;
}

int gcd(long long a, long long b) {    
    while(true){
        if(a<b) swap(a,b);
        if(b==0)return a;
        a = a % b;
    }
}
