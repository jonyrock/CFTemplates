#include <iostream>
#include <string.h>
#include <vector>
#include <stdio.h>
#include <algorithm>
#include <ctype.h>
#include <limits.h>
#include <stdlib.h>
#include <map>
#include <set>
#include <math.h>
#include <stack>
#include <sstream>

#define REP(i, to) for(__typeof(to) i = 0; i < to; i++)
#define DOWNTO(i, to) for(int i = to; i >= 0; i--)
#define FOR(it,c) for ( __typeof((c).begin()) it=(c).begin(); it!=(c).end(); it++ )
#define FORR(it,c) for ( __typeof((c).rbegin()) it=(c).rbegin(); it!=(c).rend(); it++ )
#define ZERO(a) memset((a), 0, sizeof(a))
typedef long long LL;
typedef std::vector<int> VI ;
typedef std::vector<LL> VL ;
typedef std::pair<int, int> PII;
typedef std::pair<LL, LL> PLL;
typedef std::vector<PII> VPII;
typedef std::vector<PLL> VPLL;
template<class T> const T& min(const T& a, const T& b, const T& c) { return min(a, min(b, c));}
template<class T> const T& max(const T& a, const T& b, const T& c) { return max(a, max(b, c)); }
template<class T> std::string toStr(T t);
 
using namespace std;

int stat[10];

int main() {
    
    string s;
    cin >> s;
    long long vb;
    cin >> vb;
    
    cout << toStr(vb+1);
    

}


template<class T>
string toStr(T t){
    std::stringstream strstream;
    string resStr;
    strstream << t;
    strstream >> resStr;
    return resStr;
}



