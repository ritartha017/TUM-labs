#! /bin/bash

PS3='Enter your choice: '
options=("Launch vim" "Launch vi" "Launch Firefox" "Quite menu")

select opt in "${options[@]}"

do
	case $opt in
		"Launch vim") vim;;
		"Launch vi") vi;;
		"Launch Firefox") start firefox;;
		"Quite menu") break;;
		*) echo "Invalid option";;
	esac
done

exit 0
