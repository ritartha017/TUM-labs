//
// Created by _ritarda_ on 06.04.2021.
//
#ifndef LAB6_BINARY_SEARCH_TREE_H
#define LAB6_BINARY_SEARCH_TREE_H

#include "config.h"


struct Node {
    char * name;
    char * address;
    char * phone;
    uint32_t people_num;
    uint8_t rank;

    struct Node *left;
    struct Node *right;
};

char * input(char * text);

void binary_search_tree_insert(char * key, struct Node ** root);

//wrapper fun for fun tree_print_method();
void
binary_search_tree_print(void(*fun) (struct Node * root), struct Node * root);
void in_order(struct Node * root);
void pre_order(struct Node * root);
void post_order(struct Node * root);
void binary_search_tree_print_node(struct Node * root);

void binary_search_tree_modify_node(struct Node ** root);
void binary_search_tree_free(struct Node ** root);

struct Node * binary_search_tree_search(char* key, struct Node * root);

size_t binary_search_tree_size(struct Node * root);
size_t binary_search_tree_height(struct Node * root);



#endif //LAB6_BINARY_SEARCH_TREE_H


