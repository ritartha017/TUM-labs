//
// Created by _ritarda_ on 19.04.2021.
//

#ifndef LAB4_LION_SINGLY_LINKED_LIST_H
#define LAB4_LION_SINGLY_LINKED_LIST_H

#include <inttypes.h>
#include <stdbool.h>

typedef struct s_list t_list;

struct s_list{
    char name[50];
    char address[50];
    char phone[9];
    char rank;
    uint32_t people_num;
    t_list *next;
};

// sys-f //
void pause(void);
void cls(void);

// operations with LL //
t_list* create_node();
void push_front(t_list **list);
void push_back(t_list **list);
void push_middle(t_list *list);

void delete_front(t_list **list);
void delete_back(t_list **list);
void delete_middle(t_list *list);

void modify_node(t_list **list);
int swap_two_nodes(t_list **list, uint32_t pos1, uint32_t pos2);
void reverse_list(t_list **list);
void sort_list(t_list** list);

void remove_list(t_list **list);

// doesn't change the content //
void print(t_list *list);
uint32_t count_nodes(t_list *list);

static inline t_list* get_index(t_list* list, uint32_t n);
bool find_by_rank(t_list *list, char rank);

// menus //
int menu();
char menu_set();
char menu_cut();
char menu_sort();

#endif //LAB4_LION_SINGLY_LINKED_LIST_H
