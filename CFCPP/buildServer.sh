#!/bin/bash
cd "C:\codeforces\CFCPP"
#wait for trigger

for ((; ; ))
do
	
	python getRequest.py 8999
	echo "#####TEST SESSION STARTED#####"
	./build.sh

done
