#include <iostream>
#include <cstring>
#include <iterator>

class Cow {
protected:
   static int nextID;
   
public:
    int id;
    int milk_average_amount;
    int age;
    char* name;
    char* breed;
    
    Cow() = default;
    Cow(int milk_average_amount, int age, const char* name, const char* breed) {
        id = ++nextID;
        this-> milk_average_amount = milk_average_amount;
        this-> age = age;
        this->name = new char [strlen(name) + 1];
        strcpy(this->name, name);
        this->breed = new char [strlen(breed) + 1];
        strcpy(this->breed, breed);
    }
   
   void print(){
        std::cout << "Id: "<< id << std::endl;
        std::cout << "AverageAmount: "<< milk_average_amount << std::endl;
        std::cout << "Age: "<< age << std::endl;
        std::cout << "Name: "<< name << std::endl;
        std::cout << "Breed: "<< breed << std::endl << std::endl;
    }
};

int Cow::nextID = 0;

class Herd : public Cow {
    int cow_num;
    int milk_average_amount;
    int total_milk;
    
public:
    Herd() = default;
    void set_milk_average_amount(int amount = 0) { milk_average_amount = amount; }

    float calculate_milk_average_amount(Cow *cows){
        int count = 0;
        for(int i = 0; i < Cow::nextID; i++ )
            count += cows[i].milk_average_amount;
        milk_average_amount = count;
    return float(count)/Cow::nextID;
    }
    
    int calculate_total_milk(Cow *cows){
        int count = 0;
        for(int i = 0; i < Cow::nextID; i++ )
            count += cows[i].milk_average_amount;
        total_milk = count;
    return count;
    }

    void print() { std::cout << "CowNum:" << Cow::nextID << std::endl; }
};
    
int main() {
    Cow a0(1, 1, "Cow0", "CowCow");
    a0.print();
    
    Cow a(2, 3, "Cow1", "Cowik1");
    a.print();
    
    Cow a2(2, 2, "Cow2", "Cowik2");
    a2.print();
    
    Herd h1;
    h1.print();
    
    Cow cows[] = {a0, a, a2};
    std::cout << "Average amount of milk in herd: " << h1.calculate_milk_average_amount(cows) << "(L)" << std::endl;
    std::cout << "Total milk in herd: " << h1.calculate_total_milk(cows) << "(L)";
}
