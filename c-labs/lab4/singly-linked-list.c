//
// Created by _ritarda_ on 19.04.2021.
//

#include <stdio.h>
#include <stdlib.h>

#include <stdbool.h>
#include <time.h>
#include <string.h>
#include <inttypes.h>

#include "singly-linked-list.h"

t_list *
create_node(){
    t_list *node = (t_list*)malloc(sizeof(t_list));

    fflush(stdin);
    printf("Name: ");
    scanf("%[^\n]%*c", node->name);

    printf("Address: ");
    scanf("%[^\n]%*c", node->address);

    printf("Phone: ");
    scanf("%[^\n]%*c", node->phone);

    printf("Rank: ");
    scanf("%c", &node -> rank);

    printf("People num: ");
    scanf("%u", &node -> people_num);

    fflush(stdin);

    node->next = NULL;
    return node;
}

void
push_front(t_list **list){
    if(*list == NULL){ *list = create_node(); return;}
    t_list *new_element = create_node();

    new_element -> next = *list;
    *list = new_element;
}

void
push_back(t_list **list){
    t_list *new_element = create_node();

    t_list *tmp = *list;
    while(tmp -> next != NULL) tmp = tmp -> next;
    tmp -> next = new_element;
}

void
print(t_list *list){
    if(list == NULL){ puts("The list is empty."); return; }
    t_list *tmp = list;
    int32_t counter = 1;

    struct tm *local;
    time_t t = time(NULL);
    local = localtime(&t);
    printf("\n\t\t\t\t\tList of hotels on %s\n"
           "-------------------------------------------------------------------------------------------------------------------------------------\n"
           "|  Nr  | \tHotel name\t\t| \t\tAddress\t\t\t|   Telephone   |  Rank |  People  |     pAddress   |\n"
           "|------|--------------------------------|---------------------------------------|---------------|-------|----------|----------------|\n",
           asctime(local));
    while(tmp != NULL){
        printf("| %3d  | %-30s | %-37s | %-13s | %-3c   | %-5u    |   0x%p   |\n",
               counter, tmp->name, tmp->address, tmp->phone, tmp->rank, tmp->people_num, (void *)tmp);
        tmp = tmp -> next;
        ++counter;
    }
}

void
push_middle(t_list *list) {
    uint32_t num;
    printf("Enter No. of place: ");
    scanf("%u", &num);
    t_list *tmp = NULL;
    list = get_index(list, --num);
    tmp = create_node();
        if(list -> next){
            tmp -> next = list -> next;
        }else{
            tmp->next = NULL;
        }
    list->next = tmp;
}

static
inline t_list* get_index(t_list* list, uint32_t n){
    int32_t counter = 0;
    while(counter < n - 1 && list){
        list = list -> next;
        counter++;
    }
    return list;
}

void
delete_front(t_list **list){
    if(*list == NULL){ return; }
    t_list *to_delete = *list;
    *list = to_delete -> next;
    free(to_delete);
}

void
delete_back(t_list **list){
    if( (*list)-> next == NULL){
        free(list); 
        return;
    }
    t_list *tmp = *list;
    while(tmp -> next -> next != NULL) {
        tmp = tmp -> next;
    }
    free(tmp->next);
    tmp -> next = NULL;
}

void
delete_middle(t_list *list){
    uint32_t n;
    printf("Enter No. of hotel: ");
    scanf("%u", &n);

    t_list *prev = get_index(list, --n);
    t_list *elem = prev -> next;
    prev-> next = elem -> next;
    free(elem);
}

int
swap_two_nodes(t_list **list, unsigned pos1, unsigned pos2){
    if(*list == NULL){ puts("The list is empty"); return 1; }
    t_list *node1, *node2, *prev1, *prev2, *temp;
    int32_t max_pos = (pos1 > pos2) ? pos1 : pos2;
    if (pos1 == pos2){ return 1; }
    temp  = *list;
    prev1 = prev2 = NULL;
    int32_t i = 1;
    while (temp != NULL && (i <= max_pos)){
        if (i == pos1 - 1)
            prev1 = temp;
        if (i == pos1)
            node1 = temp;
        if (i == pos2 - 1)
            prev2 = temp;
        if (i == pos2)
            node2 = temp;
        temp = temp->next;
        i++;
    }
    if (node1 != NULL && node2 != NULL){
        if (prev1 != NULL)
            prev1->next = node2;
        if (prev2 != NULL)
            prev2->next = node1;
        temp        = node1->next;
        node1->next = node2->next;
        node2->next = temp;
        if (prev1 == NULL)
            *list = node2;
        else if (prev2 == NULL)
            *list = node1;
    }
    return 0;
}

uint32_t
count_nodes(t_list *list){
    int32_t nodes = 0;
    while (list != NULL){
        ++nodes;
        list = list -> next;
    }
    return nodes;
}

void
reverse_list(t_list **list){
    if(*list == NULL){ puts("The list is empty"); return; }
    
    t_list *last = NULL;
    t_list *head = *list;
    t_list *next;
  
    while( head != NULL){
        next = head->next;
        head ->next = last;
        last = head;
        head = next;
    }
    *list = last;
}

void
sort_list(t_list** list){
    if(*list == NULL){ puts("The list is empty"); return; }

    t_list *tmp;
    bool sort;

    char option = menu_sort();
    int32_t index, max = count_nodes(*list);

    do{
        sort = true;
        tmp = *list;
        while(tmp->next){
            if( option == '1' && strcmp(tmp->name, tmp->next->name) > 0 ||
                option == '2' && strcmp(tmp->address, tmp->next->address) > 0 ||
                option == '3' && tmp->people_num > tmp->next->people_num ||
                option == '4' && tmp->rank > tmp->next->rank){

                index = max - count_nodes(tmp) + 1;
                swap_two_nodes(list, index, index + 1);
                sort = false;
            }else tmp = tmp->next;
        }
    }while(sort == false);
}

bool
find_by_rank(t_list *list, char rank){
    t_list *tmp = list;
    bool found = false;

    while(tmp != NULL){
        if(tmp->rank == rank){
            found = true;
            printf("\n| %-30s | %-37s | %-13s | %4c | %5u | %3p |\n",
                   tmp->name, tmp->address, tmp->phone, tmp->rank, tmp->people_num, tmp);
        }
        tmp = tmp -> next;
    }
    return found;
}

void
modify_node(t_list **list){
    if(!*list){ puts("The list is empty"); return; }

    int32_t to_modify;
    t_list *node;

    printf("No. of elem: "); scanf("%u", &to_modify);

    node = get_index(*list, to_modify);

    fflush(stdin);
    printf("Name: ");
    scanf("%[^\n]%*c", node->name);
    printf("Address: ");
    scanf("%[^\n]%*c", node->address);
    printf("Phone: ");
    scanf("%[^\n]%*c", node->phone);
    printf("Rank: ");
    scanf("%c", &node -> rank);
    printf("People num: ");
    scanf("%u", &node -> people_num);
    fflush(stdin);
}

void
remove_list(t_list **list){
    t_list *to_delete = *list, *tmp;
    if(!to_delete){ puts("The list is empty."); return; }

    while(to_delete){
        tmp = to_delete->next;
        to_delete->next = NULL;
        free(to_delete);
        to_delete = tmp;
    }
    *list = NULL;
    printf("The list was remove.\n");
}
