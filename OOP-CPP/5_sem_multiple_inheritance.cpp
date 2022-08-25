#include <iostream>

class Apartment {
    int floor;
protected:
    class Room {
        float area;
    public:
        Room() = default;
        Room(float area){this->area = area;};
        virtual ~Room() {}
        void _setArea(float area){ this->area = area; };
        float _getArea(){ return this->area; };
        friend std::ostream& operator<<(std::ostream& output, const Room room) {
            output << room.area;
            return output;
        }
    };
    Room unit;
    Room kitchen;
public:
    Apartment() = default;
    Apartment(int floor, float v1, float v2):unit(v1), kitchen(v2){
        this->floor = floor;
    }
    virtual ~Apartment() {}
    void pp_print() { std::cout  << "Floor: " << this->floor << std::endl
                                 << "Room: "  << unit << std::endl
                                 << "Kitchen: " << kitchen << std::endl << std::endl;}
};

class ApartmentWAddress:protected Apartment {
    std::string address;
public:
    ApartmentWAddress() = default;
    ApartmentWAddress(std::string address, float supr, float v1, float v2)
                        :Apartment::Apartment(supr, v1, v2){this->address = address;};
    void pp_print(){ std::cout<< "Address: " << this->address << std::endl; Apartment::pp_print(); }
};

int main() {
    std::cout << "Run..." << std::endl << std::endl;

    Apartment a(20, 30, 40);
    a.pp_print();

    ApartmentWAddress b("Unknown", 44, 44, 44);
    b.pp_print();

 return 0;
}