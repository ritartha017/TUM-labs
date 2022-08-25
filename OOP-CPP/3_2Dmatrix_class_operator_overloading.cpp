#include <iostream>
#include <cstring>
#include <cmath>

class Matrix {
    int row_n;
    int col_n;
    float* data;
public:
    Matrix();
    Matrix(const int row_n);
    Matrix(const int row_n, const int col_n);
    Matrix(const Matrix &src_matrix);
    Matrix(const int row_n, const int col_n, float* src_matrix);
    ~Matrix() = default;
    
    Matrix operator+(const Matrix other) const;
    Matrix operator-(const Matrix other) const;
    Matrix& operator=(const Matrix other);
    friend std::ostream& operator<<(std::ostream& output, const Matrix other);
    friend std::istream& operator>>(std::istream& input, const Matrix &other);
    friend bool operator==(const Matrix other1, const Matrix other2);
    friend bool operator!=(const Matrix other1, const Matrix other2);
    friend bool operator>(const Matrix other1, const Matrix other2);
    friend bool operator<(const Matrix other1, const Matrix other2);
    float operator[](int idx) const;
    float operator()(const int row, const int col) const;

    void print() const;
    int give_rows() const { return row_n; }
    int give_cols() const { return col_n; }
    float* give_data() const { return data; }
    float give_matrix_norm() const;
};


Matrix::Matrix(): row_n(1), col_n(1), data(0) {}

Matrix::Matrix(const Matrix& src_matrix): row_n(src_matrix.row_n), col_n(src_matrix.col_n) {
    data = new float(row_n * col_n);
    int len = row_n * col_n;
    int i = 0;
    while (i < len) {
        this -> data[i] = src_matrix.data[i];
        i++;
    }
}

Matrix::Matrix(const int row_n): row_n(row_n), col_n(row_n) {
    data = new float[row_n * row_n];
    for (int i = 0; i < row_n; i++)
        for (int j = 0; j < col_n; j++)
            this -> data[i * col_n + j] = 0;
}

Matrix::Matrix(const int row_n, const int col_n): row_n(row_n), col_n(col_n) {
    data = new float[row_n * col_n];
    for (int i = 0; i < row_n; i++)
        for (int j = 0; j < col_n; j++)
            this -> data[i * col_n + j] = 0;
}

Matrix::Matrix(const int row_n, const int col_n, float* src_matrix): row_n(row_n), col_n(col_n) {
    data = new float[row_n * col_n];
    memcpy(data, src_matrix, row_n * col_n * sizeof(int));
}

std::ostream& operator<<(std::ostream &output, const Matrix other) {
    for (int i = 0; i < other.give_rows(); i++)
        for (int j = 0; j < other.give_cols(); j++)
            output << other.data[i * other.give_cols() + j] << " ";
    output << std::endl;
    return output;
}

std::istream& operator>>(std::istream &input, Matrix &other) {
    for (int i = 0; i < other.give_rows(); i++)
        for (int j = 0; j < other.give_cols(); j++)
            input >> other.give_data()[i * other.give_cols() + j];
    return input;
}

Matrix Matrix::operator+(const Matrix other) const {
    Matrix tmp(row_n, col_n);
    if (row_n == other.row_n && col_n == other.col_n) {
        for (int i = 0; i < row_n; i++)
            for (int j = 0; j < col_n; j++)
                tmp.data[i * col_n + j] = data[i * col_n + j] + other[i * col_n + j];
    }
    return tmp;
}

Matrix Matrix::operator-(const Matrix other) const {
    Matrix tmp(row_n, col_n);
    if (row_n == other.row_n && col_n == other.col_n) {
        for (int i = 0; i < row_n; i++)
            for (int j = 0; j < col_n; j++)
                tmp.data[i * col_n + j] = data[i * col_n + j] - other[i * col_n + j];
    }
    return tmp;
}

float Matrix::operator[](int idx) const {
    return data[idx];
}

Matrix& Matrix::operator=(const Matrix other) {
    this -> row_n = other.row_n;
    this -> col_n = other.col_n;
    data = new float[row_n * col_n];
    for (int i = 0; i < row_n; i++)
        for (int j = 0; j < col_n; j++)
            this -> data[i * col_n + j] = other.data[i * col_n + j];
    return *this;
}

bool operator==(const Matrix other1, const Matrix other2) {
    int r1 = other1.row_n, c1 = other1.col_n;
    int is_same = 0;
    if (r1 == other2.row_n && c1 == other2.col_n) {
        is_same = 1;
        for (int i = 0; i < r1; i++)
            for (int j = 0; j < c1; j++)
                if (other1[i * c1 + j] != other2[i * c1 + j])
                    is_same = 0;
    }
    return is_same;
}

bool operator!=(const Matrix other1, const Matrix other2) {
    int r1 = other1.row_n, c1 = other1.col_n;
    int is_diff = 0;
    if (r1 != other2.row_n || c1 != other2.col_n) {
        is_diff = 1;
    } else if (r1 == other2.row_n && c1 == other2.col_n) {
        for (int i = 0; i < r1; i++)
            for (int j = 0; j < c1; j++)
                if (other1[i * c1 + j] != other2[i * c1 + j])
                    is_diff = 1;
    }
    return is_diff;
}

bool operator>(const Matrix other1, const Matrix other2) {
    return other1.give_matrix_norm() > other2.give_matrix_norm();
}

bool operator<(const Matrix other1, const Matrix other2) {
    return other1.give_matrix_norm() < other2.give_matrix_norm();
}

float Matrix::operator()(const int row, const int col) const {
    return data[row * col_n + col];
}

void Matrix::print() const {
    for (int i = 0; i < row_n; i++) {
        for (int j = 0; j < col_n; j++)
            std::cout << this -> data[i * col_n + j] << " ";
        std::cout << std::endl;
    }
    std::cout << std::endl;
}

float Matrix::give_matrix_norm() const {
    float norm = 0;
    for (int i = 0; i < row_n; i++)
        for (int j = 0; j < col_n; j++)
            norm += pow(fabs(this -> data[i * col_n + j]), 2);
    return sqrt(norm);
}

int main() {
    Matrix m00(3); m00.print();
	Matrix m0(3, 2); m0.print();

	float array[] = { 4, 8, 3, 7 };
	Matrix m1(2, 2, array);
	std::cout << " > m1 Matrix:" << std::endl; m1.print();

	float array1[] = { 1, 0, 5, 2 };
	Matrix m2(2, 2, array1);
	std::cout << " > m2 Matrix:" << std::endl;	m2.print();
	
	m2 = m1 + m2;
	std::cout << " >(+) m2 = m1 + m2:" << std::endl; m2.print();
	
	m2 = m1 - m2;
	std::cout << " >(-) m2= m1 - m2:" << std::endl; m2.print();
	
	m0 = m2;
	std::cout << " >(=) m0 = m2:" << std::endl; m0.print();
	
	bool is_same = m2 == m0;
	std::cout << " >(==) m0 == m2:" << is_same << std::endl;
	bool is_diff = m2 != m0;
	std::cout << " >(!=) m0 != m2:" << is_diff << std::endl;
	
	std::cout << " >(>) m1 > m0:" << (m1 > m0) << std::endl;
	std::cout << " >(<) m1 < m0:" << (m1 < m0) << std::endl;
	
	std::cout << " >([]) m0[1][0]:" << m0(1, 0) << std::endl;
	std::cin >> m2;
	std::cout << " >(>>) std::cin >> m2:" << std::endl; m2.print();
	std::cout << " >(<<) std::cout << m2:" << std::endl; std::cout << m2;
	
	return 0;
}
