// Varianta 6
// а) Să se creeze clasa Image – imagine, care conţine următoarea informaţie: denumirea fişierului, formatul de 
// compresie, dimensiunile imaginii, dimensiunea în octeţi, compresia (în %). Să se definească toţi constructorii. 
// Constructorul de schimbare a tipului are ca parametru denumirea fişierului. Să se definească funcţiile de modificare a 
// denumirii de fişier, a formatului, a dimensiunii ş. a.

#include <iostream>

class Image{
public:
    Image() = default;
    Image(int size_in_bits, int percent_compres, std::string filename, std::string compres_format);
    Image(const Image&, std::string fname);
    ~Image() = default;
    
    void print();
    void set_new_size(int size);
    void set_new_percent_compres(int percent);
    void set_new_filename(std::string new_name);
    void set_new_compres_format(std::string format);
private:
    int size_in_bits, percent_compres;
    std::string filename, compres_format;
};

void Image::print(){
    std::cout << "Size: " << size_in_bits << "B" << std::endl
         << "Name: " << filename     << std::endl
         << "Format: " << compres_format << std::endl
         << "Format(percents): " << percent_compres << "%" << std::endl;
}

Image::Image(int size_in_bits, int percent_compres, std::string filename, std::string compres_format){
    this->size_in_bits = size_in_bits;
    this->filename = filename;
    this->compres_format = compres_format;
    this->percent_compres = percent_compres;
}

Image::Image(const Image& i, std::string fname) : size_in_bits(i.size_in_bits),
        compres_format(i.compres_format), percent_compres(i.percent_compres){
    filename = fname;
}

void Image::set_new_size(int size){
    this->size_in_bits = size;
}

void Image::set_new_percent_compres(int percent){
    this->percent_compres = percent;
}

void Image::set_new_filename(std::string new_name){
    this->filename = new_name;
}

void Image::set_new_compres_format(std::string format){
    this->compres_format = format;
}

int main(){
    Image i(16, 64, "Name1", ".png");
    i.print();
    std::cout << std::endl;
    
    Image i2(i, "Name2");
    i2.print();

    return 0;
}
