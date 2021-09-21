//
// Created by _ritarda_ on 19.04.2021.
//

#include <stdio.h>
#include "singly-linked-list.h"

int menu(){
    pause();
    cls();
    printf("\n1. Input new node\n"
           "2. Delete node\n"
           "3. Display nodes\n"
           "4. Find node by rank\n"
           "5. Modify node\n"
           "6. Length of list\n"
           "7. Swap two nodes\n"
           "8. Sort list\n"
           "9. Reverse list\n"
           "10. Free allocated memory\n"
           "0. Exit\n");
    int8_t m;
    scanf("%d", &m);
    return m;
}

char menu_set(){
    pause();
    cls();
    puts("Menu: \n");
    printf("f. Insert at front\n"
           "b. Insert at back\n"
           "r. Insert at a specific position\n"
           "0. Return to menu\n");
    char m;
    scanf("%c", &m);
    return m;
}

char menu_cut(){
    pause();
    cls();
    puts("Menu: \n");
    printf("f. Delete at front\n"
           "b. Delete at back\n"
           "r. Delete at a specific position\n"
           "0. Return to menu\n");
    char m;
    scanf("%c", &m);
    return m;
}

char menu_sort() {
    pause();
    cls();
    puts("Menu: \n");
    printf("1. Sort by name\n"
           "2. Sort by address\n"
           "3. Sort by num of people\n"
           "4. Sort by rank"
           "0. Return to menu\n");
    char m;
    scanf("%c", &m);
    return m;
}