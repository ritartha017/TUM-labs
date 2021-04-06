//
// Created by _rbx_ on 06.04.2021.
//

#ifndef BST_BST_H
#define BST_BST_H

#include "config.h"

typedef int Data;

struct Node{
    Data data;
    struct Node * left;
    struct Node * right;
};

size_t tree_height(struct Node * tree);
size_t tree_size(struct Node * tree);

//wrapper fun for fun tree_print_method();
void
print(void(*fun)(struct Node * tree), struct Node * tree);

void tree_print_inorder(struct Node * tree);
void tree_print_preorder(struct Node * tree);
void tree_print_postorder(struct Node * tree);

struct Node * tree_add(struct Node * tree, Data data);
struct Node * tree_delete(struct Node *tree, Data data);
struct Node * tree_search(struct Node * tree, Data data);
struct Node * min_value_node(struct Node *tree);
struct Node * tree_destroy(struct Node * tree);

#endif //BST_BST_H
