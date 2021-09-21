
#include "binary-search-tree.h"

static inline void menu();

static inline void menu() {
    printf("\n\n\t\t{Menu}\n");
    printf("-------------------------------------\n");
    printf("Press 'p' to print the tree inorder\n");
    printf("Press '[' to print the tree inorder\n");
    printf("Press ']' to print the tree inorder\n");
    printf("-------------------------------------");
    printf("\nPress 'i' to insert an element\n");
    printf("Press 's' to search for an element\n");
    printf("Press 'd' to destroy current tree\n");
    printf("Press 'h' to print the tree height\n");
    printf("Press 'n' to print the tree size\n");
    printf("Press 'm' to modify node data\n");
    printf("Press 'q' to quit\n\n");
}

int main() {


    struct Node *root = NULL, *found = NULL;
    char *value = NULL;
    char option = 'x';

    while( option != 'q' ) {

        menu();
        scanf("%c", &option);// = getch();

        if( option == 'i') {
            value = input("\tName\t");
            binary_search_tree_insert(value, &root);
            free(value);
        }
        else if( option == 's' ) {
            value = input("Please enter a string");
            found = binary_search_tree_search(value, root);
            free(value);
            if( found != NULL) binary_search_tree_print(binary_search_tree_print_node, found);
        }

        else if( option == 'p' ) {
            binary_search_tree_print(in_order, root);
        }
        else if(option == '['){
            binary_search_tree_print(pre_order, root);
        }
        else if(option == ']'){
            binary_search_tree_print(post_order, root);
        }

        else if( option == 'd' ) {
            binary_search_tree_free(&root);
            printf("Tree destroyed");
            root = NULL;
            found = NULL;
        }
        else if( option == 'q' ) {
            printf("Quitting");
        }
        else if( option == 'm') {
            binary_search_tree_modify_node(&root);
        }
        else if(option == 'n') {
            printf("Tree size: %u", binary_search_tree_size(root));
        }
        else if(option == 'h'){
            printf("Tree height: %u", binary_search_tree_height(root));
        }
    }

    return 0;
}

