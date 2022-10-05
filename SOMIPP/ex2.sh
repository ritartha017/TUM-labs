#! /bin/bash

arr=( "$@" )
max=$(printf "%s\n" ${arr[@]} | sort -n | tail -1)
echo $max
