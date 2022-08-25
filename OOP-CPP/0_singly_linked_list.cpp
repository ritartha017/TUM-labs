#include <iostream>

class node {
    public:
    std::string data;
    node* next;
 };

class LList {
    node* head;

    public:
    LList();
    ~LList() = default;
    
    void list_create();
    void list_display();

    void list_push_front(std::string value);
    void list_push_end(std::string value);

    void list_pop_front();
    void list_pop_end();
};

LList::LList() {
    head = NULL;
}

void LList::list_push_front(std::string value) {
    node* tmp = new node;
    tmp->data = value;
    tmp->next = head;
    head = tmp;
}

void LList::list_push_end(std::string value) {
    node* tmp;
    tmp = head;
    while(tmp->next != NULL) {
        tmp = tmp->next;
    }
    node* n = new node;
    n->data = value;
    n->next = NULL;
    tmp->next = n;
}

void LList::list_pop_front() {
    node* tmp = this->head;
    this->head = tmp->next;
}

void LList::list_pop_end() {
    node* tmp = this->head;
    while(tmp->next->next != NULL) {
        tmp = tmp->next;
    }
    tmp->next = NULL;
}

void LList::list_create() {
    node* newl = NULL, *end = newl;
    std::string data;
    while(1) {
        char k;
        std::cout << "\n\nEnter E to terminate or A to add: \n";
        std::cin >> k;
        if(k == 'E') {
            break;
        } else {
            std::cout << "\nEnter data: ";
            std::cin >> data;
            newl = new node;
            newl->data = data;
            if(head == NULL) {
                newl->next = NULL;
                head = newl; 
                std::cout << "\nNODE WAS CREATED.\n";
                end = newl;
            } else {
                end->next = newl;
                end = newl;
                end->next = NULL;
                std::cout << "\nNODE WAS CREATED.\n";
            }
        }
    }
}

void LList::list_display() {
    node* tmp = head;
    while(tmp != NULL) {
        std::cout << tmp->data;
        if(tmp->next != NULL) {
            std::cout << "==>";
        }
        tmp = tmp->next;
    }
}

int main() {
    LList list;
    list.list_create();
    //list.list_pop_end();
    list.list_display();

    return 0;
}
