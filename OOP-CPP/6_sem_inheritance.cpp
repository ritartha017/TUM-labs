// Să se creeze, o ierarhie de moştenire: animale - mamifere, reptile – ornitorinc.

// animals
// mammals
// reptiles
// platypus(ornitorinc)

#include <iostream>

class Animal{
public:
    int years;
    Animal(int years){this->years = years; std::cout << "Animal\n"; }
};

class Mammal: virtual public Animal{
public:
    Mammal(int years):Animal(years){ std::cout << "Mammal\n"; }
};

class Reptile: virtual public Animal{
public:
    Reptile(int years):Animal(years){ std::cout << "Reptile\n"; }
};

class Platypus: public Mammal, public Reptile{
public:
    Platypus(int years):Animal(years), Mammal(years), Reptile(years) { std::cout << "Platypus\n"; }
};

int main() {
	std::cout << "Ok\n";
	Platypus p1(4);
}