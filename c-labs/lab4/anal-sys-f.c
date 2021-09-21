//
// Created by _ritarda_ on 19.04.2021.
//

#include <stdio.h>
#include <conio.h> //getch

#include "singly-linked-list.h"

void pause(void){
    int ch;
    while ((ch = getchar()) != '\n' && ch != -1); // -1 || EOF
    printf("Press any key to continue.. ");
    getch();
}

void cls(void){
    for (unsigned short int n = 0; n < 10; ++n)
        printf("\e[1;1H\e[2J");
}
