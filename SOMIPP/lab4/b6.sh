#!/bin/bash

# <() process substitution - gnu.org/software/bash/manual/html_node/Process-Substitution.html#Process-Substitution
# provides a way to pass the output of a command (cut)
# to another command when using a pipe (|) is not possible

# <() basically, creates a special type of file called a "named pipe,"
# then redirects the output of the command to be the named pipe.
# So for eg, suppose you want to page through a list of files in an
# extra-big directory. You could do this:

# 	ls /usr/bin | more
# or this:
# 	more <( ls /usr/bin )
# but not this:
# 	more $(ls /usr/bin )

# f stands for field

paste -d: \
	<(cut -d':' -f1 ../root/etc/passwd) \
	<(cut -d':' -f3 ../root/etc/passwd | sort -n)

exit 0
