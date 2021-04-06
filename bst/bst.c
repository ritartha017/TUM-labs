//
// Created by _ritarda_ on 06.04.2021.
//

#include "bst.h"

void print( void (*fun)(), struct Node * tree){
    if(tree == NULL) printf("\nTree is empty");
    fun(tree);
    printf("\n");
}

//inorder traversal
void tree_print_inorder(struct Node * tree){
    if(tree == NULL) return;
    tree_print_inorder(tree->left);
    printf("%d ", tree->data);
    tree_print_inorder(tree->right);
}

//preorder traversal
void tree_print_preorder(struct Node * tree){
    if(tree == NULL) return;
    printf("%d ", tree->data);
    tree_print_preorder(tree->left);
    tree_print_preorder(tree->right);
}

//postorder traversal
void tree_print_postorder(struct Node * tree){
    if(tree == NULL) return;
    tree_print_postorder(tree->left);
    tree_print_postorder(tree->right);
    printf("%d ", tree->data);
}

struct Node * tree_init(int data, struct Node * left, struct Node * right){
    struct Node * t = (struct Node*)malloc(sizeof(struct Node));
    t->data = data;
    t->left = left;
    t->right = right;
    return t;
}

struct Node * tree_add(struct Node * tree, Data data){
    if(tree == NULL){
        tree = tree_init(data, NULL, NULL);
    }
    else{
        if(data <= tree->data){
            tree->left = tree_add(tree->left, data);
        }else if(data > tree->data){
            tree->right = tree_add(tree->right, data);
        }
    }
    return tree;
}

struct Node * tree_destroy(struct Node * tree){
    if(tree == NULL) return NULL;
    tree_destroy(tree->left);
    tree_destroy(tree->right);
    free(tree);
    tree = NULL;
    return tree;
}

struct Node * tree_delete(struct Node *tree, Data data){
    if (tree == NULL) return tree;

    if (data < tree->data)
        tree->left = tree_delete(tree->left, data);
    else if (data > tree->data)
        tree->right = tree_delete(tree->right, data);

    else{
        // if the node is with only one child or no child
        if (tree->left == NULL){
            struct Node *temp = tree->right;
            free(tree);
            return temp;
        } else if (tree->right == NULL){
            struct Node *temp = tree->left;
            free(tree);
            return temp;
        }

        // if the node has two children
        struct Node *temp = min_value_node(tree->right);

        tree->data = temp->data;
        tree->right = tree_delete(tree->right, temp->data);
    }
    return tree;
}

// find the inorder successor
struct Node * min_value_node(struct Node *tree){
    struct Node *current = tree;

    // find the leftmost leaf
    while (current && current->left != NULL)
        current = current->left;

    return current;
}


struct Node * tree_search(struct Node * tree, Data data){
    if(tree == NULL) return NULL;

    if(data == tree->data){
        return tree;
    }
    if(data < tree->data){
        tree_search(tree->left, data);
    }
    if(data > tree->data){
        tree_search(tree->right, data);
    }
}

size_t tree_height(struct Node * tree){
    if(tree == NULL){
        return 0;
    }
    else{
        size_t lt_height = tree_height(tree->left);
        size_t rt_height = tree_height(tree->right);

        if(lt_height >= rt_height)
            return lt_height + 1;
        else
            return rt_height + 1;
    }
}

size_t tree_size(struct Node * tree){
    if(tree ==  NULL){
        return 0;
    }else{
        return tree_size(tree->left) + 1 + tree_size(tree->right);
    }
}
