
#include "config.h"
#include "bst.h"

int main(){
    struct Node * tree = NULL, * found = NULL;
    // print(tree);

    // Data test_data[] = {7, 3, 2, 1, 9, 5, 4, 6, 0, -1, -2, 10};
    Data test_data[] = {7, 3, 9, 2, 5, 8, 1, 4, 6, 1, 2, 3};
    for(size_t i = 0; i < sizeof(test_data)/sizeof(test_data[0]); ++i){
        tree = tree_add(tree, test_data[i]);
        print(tree_print_inorder, tree);
    }

    printf("\nHEIGHT: %u\n", tree_height(tree));

    found = tree_search(tree, 9);
    assert(found->data == 9);

    printf("\nNum of nodes: %u\n", tree_size(tree));

    printf("\nHEIGHT: %u\n", tree_height(tree));

    puts("");
    tree = tree_delete(tree, 9);
    print(tree_print_inorder, tree);

    printf("\nNum of nodes: %u\n", tree_size(tree));

    tree = tree_destroy(tree);
    print(tree_print_inorder, tree);
}
