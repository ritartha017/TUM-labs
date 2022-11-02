#! /bin/bash

CURRENT=`pwd`
BASENAME=`basename "$CURRENT"`

if [ "$BASENAME" = "lab3" ];then
	echo "$CURRENT"
	exit 0
else
	echo "The script was runned from the wrong path"
	exit 0
fi
echo "$CURRENT"
