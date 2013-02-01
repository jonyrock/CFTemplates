#include <iostream>
#include <string.h>
#include <vector>
#include <stdio.h>
#include <algorithm>

#define REP(i, to) for(int i = 0; i < to; i++)
#define FOR(it,c) for ( __typeof((c).begin()) it=(c).begin(); it!=(c).end(); it++ )
#define vi vector<int>

using namespace std;

int main() {
	
	int n;
	cin >> n;
	
	REP(i, n) {
		int angle = 0;
		cin >> angle;
		if((360 % (180 - angle)) == 0){
			cout << "YES\n";
		} else cout << "NO\n";
	}
		
}






















