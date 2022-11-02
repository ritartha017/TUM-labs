#!/bin/bash

# -r Read all files under each directory, recursively, following
# symbolic links only if they are on the command line.

grep ACPI ../root/var/log/ -r > errors.log

# egrep command treats the meta-characters as they are and do not 
# require to be escaped as is the case with grep

# By default, grep displays the entire line which has the matched string,
# -o make the grep to display only the matched string.
# ignore one or more /
egrep "[^/]+$" errors.log -o -i

exit 0
