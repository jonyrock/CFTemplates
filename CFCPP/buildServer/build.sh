#!/bin/bash

work_dir="$(pwd)"
TESTS_FILE_NAME="tests.txt"
cd ..

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
		
		input="$($work_dir/testEnum.exe $TESTS_FILE_NAME i $i)"
		if [[ $? != 0 ]]
		then
			break
		fi
		echo ""
		echo "----TEST $i----"
		$work_dir/testEnum.exe "$TESTS_FILE_NAME" i $i
	
		echo ""
		echo "OUT"
		./a.exe <<< $input
		
		echo ""
		echo ""
		echo "ANSW"
		$work_dir/testEnum.exe "$TESTS_FILE_NAME" o $i
		echo ""
	done
fi
cd "$work_dir"