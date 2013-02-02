#!/bin/bash
#wait for trigger
work_port=$RANDOM
let "work_port %= 60000"
let "work_port += 5000"
#echo $work_port > .sessionCfg
for ((; ; ))
do
	python getRequest.py 8777
	echo "#####TEST SESSION STARTED#####"
	./build.sh

done
