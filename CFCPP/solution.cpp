#include <iostream>
#include <string.h>
#include <vector>
#include <stdio.h>
#include <algorithm>

#define REP(i, to) for(__typeof(to) i = 0; i < to; i++)
#define DOWNTO(i, to) for(int i = to; i >= 0; i--)
#define FOR(it,c) for ( __typeof((c).begin()) it=(c).begin(); it!=(c).end(); it++ )
#define vi vector<int>

using namespace std;

int main() {
	
	int n;
	cin >> n;
	int a[100010];
	
	REP(i, n) {
		int ss = 0;
		scanf("%d", &ss);
		a[i] = ss;
	}
	
	int m = 1;
	DOWNTO(i, n-2) {
		if(a[i] < a[i+1]) { m++; }
		else break;
	}
	
	cout << (n - m) << endl;
		
}






















