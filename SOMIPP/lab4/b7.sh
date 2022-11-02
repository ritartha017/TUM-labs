#!/bin/bash

ffile='bashhelp'

# -w means that the regex should match a whole word
# -E for indicating the pattern you want to match agains (supports extended regexes# comparing to -e, which not)
# In basic regexes the meta-characters ?, +, {, |, (, and ) lose their 
# special meaning; instead use the backslashed versions \?, \+, \{, \|, \(, and \).
# \w{3,} at least 3 size words
# -nr in numerical order, reverse

awk '{for(i=1;i<=NF;i++) {print $i}}' $ffile    \
	| uniq -c 				\
	| grep -wE '\w{3,}' 			\
	| sort -nr 				\
	| head -5

exit 0
