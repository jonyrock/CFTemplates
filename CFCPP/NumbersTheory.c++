int gcd(long long a, long long b) {    
    while(true){
        if(a<b) swap(a,b);
        if(b==0)return a;
        a = a % b;
    }
}
