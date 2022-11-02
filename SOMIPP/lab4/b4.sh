#!/bin/bash

# -o says to only output the matching portion
# -h display the matched lines, but do not display the filenames

# paste command is used to merge corresponding lines of given files
# -s merge the files in sequentially manner
# -d delimeter

# email regex
# [A-Z0-9._%+-] match a single character present in the list below
# A-Z a single character in the range between A and Z (case sensitive)
# 0-9 a single character in the range between 0 and 9
# ._%+- a single character in the list ._%+- literally

# [A-Z] any one capital letter.
# {} semnifică repetiții ale unei expresii
grep -i -o -r -h  '[A-Z0-9._%+-]\+@[A-Z0-9.-]\+\.[A-Z]\{2,4\}' ../root/etc \
	| paste -s -d ',' > emails.lst

cat emails.lst

exit 0
