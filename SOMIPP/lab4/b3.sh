#!/bin/bash

# egrep command treats the meta-characters as they are and
# do not require to be escaped as is the case with grep
egrep 'WW|II' ../root/var/log/Xorg.0.log > full.log

# -n supress the output
sed -n 's/WW/Warning/g' full.log
sed -n 's/II/Information/g' full.log

# -k2 sort a table based on column2
# {,} to indicate the same input and output file
sort -k2 -o full.log{,}
cat full.log

exit 0
