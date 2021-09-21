#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#include <windows.h>

typedef int Data;

struct s_node{
    Data data;
    struct s_node* next;
    struct s_node* prev;
};

void list_display(struct s_node* start);
void
color_list_display(struct s_node* start, struct s_node* p_min, struct s_node* p_max);
void
list_display_in_interval(struct s_node* start, struct s_node* last);

void list_init(struct s_node** start, Data data);
void list_init_random(struct s_node** start);
void list_add_elem(struct s_node** start, Data data);
void list_destroy(struct s_node** start);

struct s_node*
list_search_min_value(struct s_node* start, struct s_node* p_min);
struct s_node*
list_search_max_value(struct s_node* start, struct s_node* p_max);

int main(){
    struct s_node* myl, *p_max, *p_min;

    myl = p_max = p_min = NULL;

    list_init_random(&myl);

    //list_add_elem(&myl, 4);
    //list_add_elem(&myl, 5);

    p_min = list_search_min_value(myl, p_min);
    p_max = list_search_max_value(myl, p_max);

    puts("\n\t\t\t\t\t\t Generated list\n");
    color_list_display(myl, p_min, p_max);

    printf("\n\n\t\t\t\t\t min: %d\t\tmax: %d\n", p_min->data, p_max->data);

    puts("\n min->max:");    list_display_in_interval(p_min, p_max);
    puts("\n\n max->min:");  list_display_in_interval(p_max, p_min);

    puts("\n");
    list_destroy(&myl);
    list_display(myl);
}

void
list_init(struct s_node** start, Data data){
    *start = (struct s_node*)malloc(sizeof(struct s_node));
    (*start)->data = data;
    (*start)->next = *start;
    (*start)->prev = *start;
}

void
list_add_elem(struct s_node** start, Data data){
    struct s_node* last = (*start)->prev;
    struct s_node* new_node = (struct s_node*)malloc(sizeof(struct s_node));
    new_node->data = data;
    new_node->next = *start;
    (*start)->prev = new_node;
    new_node->prev = last;
    last->next = new_node;
}

struct s_node*
list_search_min_value(struct s_node* start, struct s_node* p_min){
    struct s_node* tmp = start;
    Data min = tmp->data;
    while (tmp->next != start){
        if(tmp->next->data < min){
            min = tmp->next->data;
            p_min = tmp->next;
        }
        tmp = tmp->next;
    }
    return p_min;
}

struct s_node*
list_search_max_value(struct s_node* start, struct s_node* p_max){
    struct s_node* tmp = start;
    Data max = tmp->data;
    while (tmp->next != start){
        if(tmp->next->data > max){
            max = tmp->next->data;
            p_max = tmp->next;
        }
        tmp = tmp->next;
    }
    return p_max;
}

void
list_destroy(struct s_node** start){
    if(!*start){ puts("\nstart is empty."); return; }
    struct s_node* to_delete = *start, *tmp;
    do{
        tmp = to_delete->next;
        to_delete->next = NULL;
        to_delete->prev = NULL;
        free(to_delete);
        to_delete = tmp;
    }while(to_delete != *start);
    *start = NULL;
    printf("\n List was remove. ");
}

void
list_init_random(struct s_node** start){
    srand(time(0));
    if(*start == NULL) list_init(start, rand());
    for(unsigned short int i = 0; i < 100; ++i){
        list_add_elem(start, rand());
    }
}

void
list_display(struct s_node* start){
    if(start == NULL) { puts("\n List is empty"); return; }
    struct s_node* tmp = start;
    // printf("\n\n Traversal in forward direction \n");
    while (tmp->next != start){
        printf(" %d ", tmp->data);
        tmp = tmp->next;
    }
    printf(" %d ", tmp->data);

/* printf("\n\n Traversal in reverse direction \n");
    struct s_node* last = start->prev;
    tmp = last;
    while (tmp->prev != last){
        printf(" %d ", tmp->data);
        tmp = tmp->prev;
    }
    printf(" %d ", tmp->data); */
}

void
list_display_in_interval(struct s_node* start, struct s_node* last){
    if(start == NULL) { puts("\n List is empty"); return; }
    struct s_node* tmp = start;
    while (tmp != last){
        printf(" %d ", tmp->data);
        tmp = tmp->next;
    }
    printf(" %d ", tmp->data);
}

void
color_list_display(struct s_node* start, struct s_node* p_min, struct s_node* p_max){
    if(start == NULL) { puts("\n List is empty"); return; }
    struct s_node* tmp = start;

    HANDLE hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

    while (tmp->next != start){
        if(tmp->data == p_min->data){
            SetConsoleTextAttribute(hConsole, (WORD) (46));
            printf(" %d ", tmp->data);
            SetConsoleTextAttribute(hConsole, (WORD) (15));
        }else if(tmp->data == p_max->data){
            SetConsoleTextAttribute(hConsole, (WORD) (94));
            printf(" %d ", tmp->data);
            SetConsoleTextAttribute(hConsole, (WORD) (15));
        }else
            printf(" %d ", tmp->data);
        tmp = tmp->next;
    }
}
