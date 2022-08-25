// VariantaF 6
// b) Să se creeze clasa Matrix – matrice. Clasa conţine pointer, numărul de rînduri şi de 
// coloane şi o variabilă – codul erorii. Să se definească constructorul fără parametri (constructorul implicit), 
// constructorul cu un parametru – matrice pătrată şi constructorul cu doi parametri – matrice dreptunghiulară ş. a. Să se 
// definească funcţiile membru de acces: returnarea şi setarea valorii elementului (i,j). Să se definească funcţiile de adunare şi 
// scădere a două matrice; înmulţirea unei matrice cu alta; înmulţirea unei matrice cu un număr. Să se testeze funcţionarea clasei.
#include <iostream>
#include <cstdlib>
#include <cstring>

class Matrix {
    int x;          // columns
    int y;          // rows
    int code_error; // code_error num
    int **p;
public:
    Matrix();
    Matrix(int x1);
    Matrix(int x1, int y1);
    Matrix(const Matrix&);
    ~Matrix();

    int _x () { return this->x; }
    int _y () { return this->y; }

    int get(int i, int j) { return this->p[i][j]; }
    void set (int i, int j, int value) { this->p[i][j] = value; }
    void matrix_set_size(int n, int m);
    void matrix_init_values();
    int matrix_is_empty();
    void matrix_pp_print();
};

Matrix::Matrix() : x(0), y(0), code_error(0) {}

Matrix::Matrix(int x1) : x(x1), y(x1), code_error(0) {
    this->p = NULL;
}

Matrix::Matrix(int x1, int y1) : x(x1), y(y1), code_error(0) {
    this->p = NULL;
}

Matrix::Matrix(const Matrix& M) : x(M.x), y(M.y), code_error(M. code_error) {
    this->matrix_set_size (x, y);
    this->p = p = new int *[x];
    for (int i = 0; i < y; i++)
        p[i] = new int[x];
    for (int i = 0; i < y; i++)
        for (int j = 0; j < x; j++)
            this->p[i][j] = M.p[i][j];
}

Matrix::~Matrix() {
    for (int i = 0; i < x; i++)
        delete[]p[i];
    delete p;
}

void Matrix::matrix_set_size(int n, int m) {
    this->x = n,
    this->y = m;
    this->p = new int*[x];
    for (int i = 0; i < y; i++)
        p[i] = new int[x];
    for (int i = 0; i < y; i++)
        for (int j = 0; j < x; j++)
            this->p[i][j] = 0;
}

void Matrix::matrix_init_values() {
    int val = 0;
    for (int i = 0; i < this->x; i++)
        for (int j = 0; j < this->y; j++){
            std::cout << "Elem" << "[" << i << j << "]" << "="; std::cin >> val;
            this->p[i][j] = val;
        }
}

int Matrix::matrix_is_empty() {
    if (this->x > 0 && this->y > 0)
        return 1;
    else return 0;
}

void Matrix::matrix_pp_print() {
    for (int i = 0; i < _y (); i++){
        for (int j = 0; j < _x (); j++)
            std::cout << get(i, j) << "\t";
        std::cout << std::endl;
    }
}

void add_matrix(Matrix * matrix1, Matrix * matrix2) {
    if(matrix1->_x() == matrix2->_x() && matrix1->_y() == matrix2->_y()){
        for (int i = 0; i < matrix1->_y (); i++){
            for (int j = 0; j < matrix1->_x (); j++)
                std::cout << (matrix1->get(i, j) + matrix2->get(i, j)) << "\t";
                std::cout << std::endl;
        }
    } else std::cout << "Num of rows and columns should be <=>.";
}

void substract_matrix(Matrix * matrix1, Matrix * matrix2) {
    if(matrix1->_x() == matrix2->_x() && matrix1->_y() == matrix2->_y()){
        for (int i = 0; i < matrix1->_y (); i++){
            for (int j = 0; j < matrix1->_x (); j++)
                std::cout << (matrix1->get(i, j) - matrix2->get(i, j)) << "\t";
                std::cout << std::endl;
        }
    } else std::cout << "Num of rows and columns should be <=>.";
}

void multiplicate(Matrix * matrix1, Matrix * matrix2) {
    int sum;
    if (matrix1->_x () == matrix2->_y ()){
        for (int i = 0; i < matrix1->_y (); i++){
            for (int j = 0; j < matrix1->_x (); j++){
            sum = 0;
                for (int k = 0; k < matrix1->_x (); k++)
                    sum += matrix1->get(i, k) * matrix2->get(k, j);
                std::cout << sum << "\t";
            } std::cout << std::endl;
        }
    } else std::cout << "Num of rows and columns should be <=>.";
}

void multiplix_with_num(Matrix *M, int nr) {
    for(int i=0; i<M->_y(); i++) {
        for(int j=0; j<M->_x(); j++)
            std::cout << M->get(i, j)*nr << "\t";
    std::cout << std::endl;
    }
}

int main() {
    Matrix m, m1;
    std::cout << "Set matrix 1: \n";
    m.matrix_set_size(2, 2);  m.matrix_init_values();
    
    std::cout << "Set matrix 2: \n";
    m1.matrix_set_size(2, 2); m1.matrix_init_values();
    add_matrix(&m, &m1);

    std::cout<<"Matrix 3: \n";
    Matrix m3 = m, m11(m);
    m3.matrix_pp_print();

    return 0;
}
