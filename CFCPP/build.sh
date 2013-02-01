#!/bin/bash
cd "C:\codeforces\CFCPP"
if [ -e "a.exe" ] 
then 
	rm "a.exe"	
fi
#compile
g++ solution.cpp
#testing
if [ -e "a.exe" ] 
then
	for (( i=1; ; i++ ))
	do
		input="$(./testEnum.exe input.txt i $i)"
		if [[ $? != 0 ]]
		then
			break
		fi
		echo ""
		echo "----TEST $i----"
		./testEnum.exe input.txt i $i
	
		echo ""
		echo "OUT"
		./a.exe <<< $input
		
		echo ""
		echo ""
		echo "ANSW"
		./testEnum.exe input.txt o $i
		echo ""
	done
fi
