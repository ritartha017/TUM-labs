#! /bin/bash

input_num=0

while true
do
        read number
	let input_num=input_num+1
	if [ $((number%2)) -eq 0 ]; then
                break
        fi
done

echo \$input_num
echo "You entered $input_num numbers."

exit 0
