#!/bin/bash

path='../root/bin'

# -e means enable interpretation of backslash escapes
# wc word count
# -l prints the number of lines from a given file
echo -e "sh scripts ->\t \
	$(grep -r '^#!/bin/sh$' ${path} | wc -l)"

echo "bash scripts -> \
	$(grep -r '^#!/bin/bash$' ${path} | wc -l)"

echo "perl scripts -> \
	$(grep -r '^#!/usr/bin/perl$' ${path} | wc -l)"

echo -e "tcl scripts ->\t \
	$(grep -r '^#!/usr/bin/tcl$' ${path} | wc -l)"

exit 0
