#! /bin/bash

input=""
while true
do
	read characters
	input+=" $characters"
	if [ "$characters" = "q" ]; then
		break
	fi
done

echo $input

