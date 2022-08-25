#include <iostream>

class Human {
protected:
    std::string name;
    int age;
    int weight;
    
public:
    Human() : name("Empty"), age(0), weight(0) {}
    Human(std::string name, int age, int weight) : name(name), age(age), weight(weight) {}
    Human(const Human& M) : name(M.name), age(M.age), weight(M.weight){}
    ~Human() = default;
    
    Human& operator=(const Human other){
        this -> name = other.name;
        this -> age = other.age;
        this -> weight = other.weight;
        return *this;
    }

    void print(){
        std::cout << "Name: "<< name << std::endl;
        std::cout << "Age: "<< age << std::endl;
        std::cout << "Weight: "<< weight << std::endl;
    }
    
    void pp_print(){
       print();
       std:: cout << std::endl;
    }
};

class Magnate: public Human {
    int passport_number;
public:
    Magnate() = default;
    Magnate(int pass_number, std::string name, int age, int weight) : Human::Human(name, age, weight) {
        this-> passport_number = pass_number;
    }
    ~Magnate() = default;
    
    friend std::ostream& operator<<(std::ostream& output, const Magnate other){
        output << other.name;
        return output;
    }
    
    void set_age(int age){ this -> age = age ;}
    void set_pass_name(std::string name){ this -> name = name;}
    
    void print(){
        Human::print();
        std::cout << "PassNumber: "<< passport_number << std::endl<< std::endl;
    }
};

int main() {
    std::cout << "> Default constructor:\n";
    Human h0; h0.pp_print();
    
    std::cout << "> Parametrized constructor:\n";
    Human h1("Vladislav", 21, 75);
    h1.pp_print();
    Human h2("Ion", 5, 3);
    h2.pp_print();
    
    std::cout << "> h1 = h2:" << std::endl;
    h1=h2;
    h1.pp_print();
    
    Magnate m1(88888, "Nume1", 17, 70);
    m1.print();
    
    std::cout << "> Operator \"<<\" : " << m1 << std::endl << std::endl;
    m1.set_age(18);
    m1.print();

  return 0;
}
