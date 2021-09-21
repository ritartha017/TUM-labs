#include <stdio.h>
#include <ctype.h>
#include <inttypes.h>

#include "singly-linked-list.h"

int main(){
    t_list *list = NULL;

    int8_t m;
    char option;

    do{
        m = menu();
        switch(m){
            case 1:
                do{
                    option = tolower(menu_set());
                    switch(option){
                        case 'f': push_front(&list); break;
                        case 'b': push_back(&list); break;
                        case 'r': push_middle(list); break;
                        default: break;
                    }
                }while(option != '0');
                break;
            case 2:
                do{
                    option = tolower(menu_cut());
                    switch(option){
                        case 'f': delete_front(&list); break;
                        case 'b': delete_back(&list); break;
                        case 'r': delete_middle(list); break;
                        default: break;
                    }
                }while(option != '0');
                break;
            case 3:
                print(list);
                break;
            case 4:
                printf("Enter rank: ");
                char rank; fflush(stdin); scanf("%c", &rank);
                find_by_rank(list, rank) ? printf("\nHotel was found\n") : printf("\nHotel wasn't found\n");
                break;
            case 5:
                modify_node(&list);
                break;
            case 6:
                printf("Length: %u", count_nodes(list));
                break;
            case 7:
                printf("Enter indexes [form: index1 index2]: ");
                uint32_t pos1, pos2;
                scanf("%u %u", &pos1, &pos2);
                swap_two_nodes(&list, pos1, pos2);
                break;
            case 8:
                sort_list(&list);
                puts("List was sorted.");
                break;
            case 9:
                reverse_list(&list);
                puts("List was reverse.");
                break;
            case 10:
                remove_list(&list);
                break;
            case 0:
                remove_list(&list); puts("\nProgram exit.\n");
                break;

            default: puts("Incorrect option. Try again.\n");
        }
    }while(m != 0);
}
