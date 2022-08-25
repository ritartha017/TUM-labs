#include <iostream>

class Furniture{
public:
    int price;
    Furniture(int price){this->price = price;}
};

class Bed: virtual public Furniture{
public:
    Bed(int price):Furniture(price){}
};

class Sofa: virtual public Furniture{
public:
    Sofa(int price):Furniture(price){}
};

class SofaCumBed: public Bed, public Sofa{
public:
    SofaCumBed(int price):Furniture(price), Bed(price), Sofa(price) {}
};

int main() {}