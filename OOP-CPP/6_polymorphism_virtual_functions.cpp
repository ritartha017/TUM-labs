// Creaţi clasa abstractă de bază Figure cu funcţia virtuală - perimetru. Creaţi clasele
// derivate - Rectangle, Circle, Triangle, Rhomb în care funcţia dată este predefinită. În funcţia
// main determinaţi masivul de pointeri la clasa abstractă, căreia i se atribuie adresele obiectelor diferitor obiecte.

#include <iostream>
#include <cmath>

#ifndef M_PI
	#define M_PI (3.14159265358979323846)
#endif

class Figure{
public:
	virtual double getPerimeter() = 0;
};

class Rectangle : public Figure{
	double length, weight;
public:
	Rectangle(double length, double weight){
		this->length = length;
		this->weight = weight;
	}
	double getPerimeter() override { return (length + weight) * 2.; }
};

class Circle : public Figure {
	double radius;
public:
	Circle(double radius) { this->radius = radius; }
    double getPerimeter() override { return (2 * M_PI * radius); }
};

class Triangle : public Figure {
	double side1, side2, base;
public:
	Triangle(double side1, double base, double side2) {
		this->side1 = side1;
		this->base = base;
		this->side2 = side2;
	}
    double getPerimeter() override { return (side1 + base + side2); }
};

class Rhomb : public Figure {
	int side;
public:
	Rhomb(double side) { this->side = side; }
    double getPerimeter() override { return 4*side; }
};

int main() {
	Figure *obj[4];

	Figure *f0 = new Rectangle(5., 5.);
	std::cout << "Perimeter of Rectangle: " << f0->getPerimeter() << std::endl;

	Figure *f1 = new Circle(5.);
	std::cout << "Perimeter of Circle:\t" << f1->getPerimeter() << std::endl;

	Figure *f2 = new Triangle(5., 5., 5.);
	std::cout << "Perimeter of Triangle:\t" << f2->getPerimeter() << std::endl;

	Figure *f3 = new Rhomb(5.);
	std::cout << "Perimeter of Rhomb:\t" << f3->getPerimeter() << std::endl;

	obj[0] = f0;
	obj[1] = f1;
	obj[2] = f2;
	obj[3] = f3;

	std::cout << "\nPerimeters:\n";
	for (int i : {0, 1, 2, 3} ) {
		std:: cout << obj[i]->getPerimeter() << std::endl;
	}
}