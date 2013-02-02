#include <iostream>
#include <string.h>
#include <vector>
#include <stdio.h>
#include <stdlib.h>
#include <algorithm>
#include <fstream>

#define REP(i, to) for(int i = 0; i < to; i++)
#define FOR(it,c) for ( __typeof((c).begin()) it=(c).begin(); it!=(c).end(); it++ )
#define vi vector<int>



using namespace std;

string IN_STR("input");
string OUT_STR("output");

#define STRBUF 100000


int main(int count, char** args) {
	
	if(count < 4){
		cout << "[input_file] [i|o] [test index]";
		return -1;
	}
	
	int N = atoi(args[3]);
	
	ifstream rdr;
	rdr.open(args[1]);
	string curStr;
	
	int curTestI = 0;
	bool found = false;
	
	char strBuff[STRBUF];
	
	while(!rdr.eof()){
		rdr.getline(strBuff, STRBUF); curStr = string(strBuff);
		if(curStr == IN_STR) curTestI++;
		if(curTestI == N){ found = true; break;}
	}
	
	if(!found) return 2;
	
	if(string(args[2]) == string("i")) {
		while(!rdr.eof()){
		rdr.getline(strBuff, STRBUF); curStr = string(strBuff);
		if(curStr == IN_STR) return 0;
		if(curStr == OUT_STR) break;
		cout << curStr << "\n";
		}
		return 0;
	}
	
	if(string(args[2])==string("o")) {
		while(!rdr.eof()){
		rdr.getline(strBuff, STRBUF); curStr = string(strBuff);
		if(curStr == OUT_STR) break;
		}
	}
	
	while(!rdr.eof()){
		rdr.getline(strBuff, STRBUF); curStr = string(strBuff);
		if(curStr == IN_STR) return 0;
		if(curStr == OUT_STR) break;
		cout << curStr << "\n";
	}
	
	
	rdr.close();
	
	
}


























