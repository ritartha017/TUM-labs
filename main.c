#include <stdio.h>
#include <stdlib.h>
#include <stdbool.h>

typedef struct s_list t_list;

struct s_list{
    int id;
    char *name;
    t_list *next;
};

void print(t_list *list);

void push_front(t_list **list, int set_id, char* set_name);
void push_back(t_list **list, int set_id, char* set_name);
void push_middle(t_list *list, int set_id, char* set_name, unsigned n);

void delete_front(t_list **list);
void delete_back(t_list **list);
void delete_middle(t_list **list, unsigned n);

void reverse_list(t_list **list);
void sort_id(t_list **list);

t_list* create_node(int set_id, char *set_name);
t_list* get_index(t_list* list, unsigned n);

int swap(t_list **list, int pos1, int pos2);
int count(t_list *list);

int main(){
    t_list *list = create_node(0, "Name0");
    if(list == NULL) { printf("Memory alloc"); return 1;}

    push_front(&list, 3, "Name3");
    push_front(&list, 2, "Name2");
    push_front(&list, 1, "Name1");

    push_middle(list, 100, "INSERT", 5);

    push_back(&list, 4, "Name4");
    push_back(&list, 5, "Name5");
    push_back(&list, 6, "Name6");

    delete_front(&list);
    delete_middle(&list, 2);
    delete_back(&list);
    print(list);

    printf("\n--------------------------\n");

    if (swap(&list, 2, 4) == 0){
        printf("\nData swapped successfully.\n");
        printf("\nData in list after swapping\n\n");
        print(list);
        printf("\n--------------------------\n\n");
    }else{
        printf("Invalid position, please enter position greater than 0 and less than nodes in list.\n");
    }

   // search_id(list, 4);
    sort_id(&list);
    reverse_list(&list);
    print(list);
}

t_list* create_node(int set_id, char *set_name){
    t_list *node = (t_list*)malloc(sizeof(t_list));
    node -> id = set_id;
    node -> name = set_name;
    node -> next = NULL;
    return node;
}

void push_front(t_list **list, int set_id, char* set_name){
    t_list *new_element = create_node(set_id, set_name);

    new_element -> next = *list;
    *list = new_element;
}

void push_back(t_list **list, int set_id, char* set_name){
    t_list *new_element = create_node(set_id, set_name);

    t_list *tmp = *list;
    while(tmp -> next != NULL) tmp = tmp -> next;
    tmp -> next = new_element;
}

void push_middle(t_list *list, int set_id, char* set_name, unsigned n) {
    t_list *tmp = NULL;
    list = get_index(list, --n);
    tmp = create_node(set_id, set_name);
    if(list -> next){
        tmp -> next = list -> next;
    }else{
        tmp->next = NULL;
    }
    list->next = tmp;
}

void delete_front(t_list **list){
    if(*list == NULL){return;}
    t_list *to_delete = *list;
    *list = to_delete -> next;
    free(to_delete);
}

void delete_back(t_list **list){
    //if there is only one item in the list, remove it
    if( (*list)-> next == NULL){
        free(list); return;
    }

    t_list *tmp = *list;
    while(tmp -> next -> next != NULL) {
        tmp = tmp -> next;
    }
    free(tmp->next);
    tmp -> next = NULL;
}

void delete_middle(t_list **list, unsigned n){
    t_list *prev = get_index(*list, n);
    t_list *elem = prev -> next;
    prev-> next = elem -> next;
    free(elem);
}

int swap(t_list **list, int pos1, int pos2){
    t_list *node1, *node2, *prev1, *prev2, *temp;
    int max_pos = (pos1 > pos2) ? pos1 : pos2;
    int total_nodes = count(*list);

    if ((pos1 <= 0 || pos1 > total_nodes) || (pos2 <= 0 || pos2 > total_nodes)){
        return -1;
    }
    if (pos1 == pos2){
        return 1;
    }
    temp  = *list;
    prev1 = NULL;
    prev2 = NULL;

    int i = 1;
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
        // link previous of node1 with node2
        if (prev1 != NULL)
            prev1->next = node2;
        // link previous of node2 with node1
        if (prev2 != NULL)
            prev2->next = node1;
        // swap node1 and node2 by swapping their next node links
        temp        = node1->next;
        node1->next = node2->next;
        node2->next = temp;
        // first element
        if (prev1 == NULL)
            *list = node2;
        else if (prev2 == NULL)
            *list = node1;
    }
    return 0;
}

int count(t_list *list){
    int nodes = 0;
    while (list != NULL){
        nodes++;
        list = list -> next;
    }
    return nodes;
}

void reverse_list(t_list **list){
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

void sort_id(t_list **list){
    int index1, index2;
    const int max = count(*list);
    t_list *tmp;
    bool sort;
    do {
        sort = true;
        tmp = *list;
        while(tmp->next){
            if(tmp->id > tmp->next->id){
                index1 = max - count(tmp) + 1;
                index2 = max - count(tmp->next) + 1;
                swap(list, index1, index2);
                sort = false;
            }else tmp = tmp->next;
        }
    }while(sort == false);
}

t_list* get_index(t_list* list, unsigned n){
    int counter = 0;
    while(counter < n - 1 && list){
        list = list -> next;
        counter++;
    }
    return list;
}

void print(t_list *list){
    t_list *tmp = list;
    while(tmp != NULL){
        printf("id:     %d      name:   %s\n", tmp->id, tmp->name);
        tmp = tmp-> next;
    }
}
