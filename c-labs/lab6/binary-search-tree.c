//
// Created by _ritarda_ on 06.04.2021.
//
#include "binary-search-tree.h"

static void binary_search_tree_init_struct(struct Node *);

static void binary_search_tree_init_struct(struct Node * root) {
    char* set = NULL;
    set = input("\tAddress ");
    (root)->address = strdup(set);

    set = input("\tPhone\t");
    (root)->phone   = strdup(set);
    free(set);

    printf("\tGuests  : ");
    scanf("%u", &(root)->people_num);

    printf("\tRank\t: ");
    scanf("%u", &(root)->rank);
}


static void binary_search_tree_init(char *, struct Node **);

static void binary_search_tree_init(char * key, struct Node ** root) {
    *root = (struct Node*) malloc(sizeof(struct Node));

    (*root)->name = strdup(key);
    binary_search_tree_init_struct(*root);

    (*root)->left  = NULL;
    (*root)->right = NULL;
}


static void __bst_insert(char*, struct Node**);

static void __bst_insert(char * key, struct Node ** root) {
    int res;
    if( *root == NULL ) {
        binary_search_tree_init(key, root);
    } else {
        res = strcasecmp(key, (*root)->name);
        if( res < 0) {
            __bst_insert( key, &(*root)->left);
        }
        else if( res > 0) {
            __bst_insert( key, &(*root)->right);
        } else
            printf ("Key '%s' already in tree\n", key);
    }
}

void binary_search_tree_insert(char * key, struct Node ** root) {
    __bst_insert(key, root);
}



static inline char * __inpt();
static inline char *__inpt()
{
    static char buffer[32] = {0};
    scanf(" %[^\n]", buffer);
    return strdup(buffer);
}

char *input(char *text)
{
    printf("%s: ", text);
    return __inpt();
}


void binary_search_tree_print(void (*fun) (), struct Node * root) {
    if (root == NULL){
        printf("\nTree is empty");
        return;
    }
    puts("\t\t { List of hotels } \n");
    fun(root);
}

void in_order(struct Node * root) {
    if( root != NULL ) {
        in_order(root->left);
        printf("\tName\t: %s\n\tAddress : %s\n\tPhone\t: +971-%s\n\tGuests\t: %u\n\tRank\t: %u\n\n",
               root->name, root->address, root->phone, root->people_num, (unsigned)root->rank);
        in_order(root->right);
    }
}

void pre_order(struct Node * root) {
    if( root != NULL ) {
        printf("\tName\t: %s\n\tAddress : %s\n\tPhone\t: +971-%s\n\tGuests\t: %u\n\tRank\t: %u\n\n",
               root->name, root->address, root->phone, root->people_num, (unsigned)root->rank);
        in_order(root->left);
        in_order(root->right);
    }
}

void post_order(struct Node * root) {
    if( root != NULL ) {
        in_order(root->left);
        in_order(root->right);
        printf("\tName\t: %s\n\tAddress : %s\n\tPhone\t: +971-%s\n\tGuests\t: %u\n\tRank\t: %u\n\n",
               root->name, root->address, root->phone, root->people_num, (unsigned)root->rank);
    }
}

void binary_search_tree_print_node(struct Node * root) {
    printf("\tName\t: %s\n\tAddress : %s\n\tPhone\t: +971-%s\n\tGuests\t: %u\n\tRank\t: %u\n\n",
           root->name, root->address, root->phone, root->people_num, (unsigned)root->rank);
}



static struct Node * __bst_search(char*, struct Node *);

static struct Node * __bst_search(char* key, struct Node * root) {
    int res;
    if(root != NULL) {
        res = strcasecmp(key, root->name);
        if( res < 0) {
            __bst_search( key, root->left);
        }
        else if( res > 0) {
            __bst_search( key, root->right);
        } else {
            printf("\n'%s' found!\n", key);
            return root;
        }
    }
    else {
		printf("\nNot in tree\n");
		return NULL;
	}
}

struct Node * binary_search_tree_search(char* key, struct Node * root) {
    return __bst_search(key, root);
}


void binary_search_tree_modify_node(struct Node ** root) {
    struct Node * found;
    char* value = input("Please enter a string");
    found = __bst_search(value, *root);
    free(value);

    if (found != NULL){
        value = input("\tName\t");
        found->name = strdup(value);
        binary_search_tree_init_struct(found);
    }
}


static size_t __bst_size(struct Node *);

static size_t __bst_size(struct Node * root) {
    if (root == NULL) {
        return 0;
    } else {
        return __bst_size(root->left) + 1 + __bst_size(root->right);
    }
}

size_t binary_search_tree_size(struct Node * root){
    return __bst_size(root);
}


static size_t __bst_height(struct Node *);

static size_t __bst_height(struct Node * root) {
    if (root == NULL) {
        return 0;
    } else {
        size_t lt_height = __bst_height(root->left);
        size_t rt_height = __bst_height(root->right);

        if (lt_height >= rt_height)
            return lt_height + 1;
        else
            return rt_height + 1;
    }
}

size_t binary_search_tree_height(struct Node * root) {
    return __bst_height(root);
}


static void __bst_free(struct Node **);
static void __bst_free(struct Node ** root) {
    if( *root == NULL ) {
        return;
    }
    __bst_free(&(*root)->left);
    __bst_free(&(*root)->right);
    free( (*root)->name);
    free( (*root)->address);
    free( (*root)->phone);
    free (*root) ;
}

void binary_search_tree_free(struct Node ** root){
    __bst_free(root);
}

