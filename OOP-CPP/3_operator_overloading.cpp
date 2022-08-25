#include <iostream>

class BigNum {
    long long _num;
public:
    explicit BigNum(long long num = 0) { _num = num; }
    const BigNum operator+(const BigNum other) const;
    const BigNum operator+(long other) const;
    const BigNum operator*(const BigNum other) const;
    const BigNum operator*(long other) const;
    
    BigNum operator++();
    BigNum  operator++(int);
    BigNum operator--();
    BigNum  operator--(int);

    friend BigNum operator-(const BigNum other1, const BigNum other2);
    friend BigNum operator-(const BigNum other1, long other2);
    friend BigNum operator-(long other1, const BigNum other2);
    friend BigNum operator/(const BigNum other1, const BigNum other2);
    friend BigNum operator/(long other1, const BigNum other2);
    friend BigNum operator/(const BigNum other1, long other2);

    int num() { return _num; }
};

const BigNum BigNum::operator+(const BigNum other) const {
    return BigNum(_num + other._num);
}

const BigNum BigNum::operator+(long other) const {
    return BigNum(_num + other);
}

const BigNum BigNum::operator*(const BigNum other) const {
    return BigNum(_num * other._num);
}

const BigNum BigNum::operator*(long other) const {
    return BigNum(_num * other);
}

BigNum BigNum::operator++() {
    _num++;
    return *this;
}

BigNum BigNum::operator++(int) {
   BigNum tmp = *this;
   ++_num;
   return tmp;
}

BigNum BigNum::operator--() {
    _num--;
    return *this;
}

BigNum BigNum::operator--(int) {
   BigNum tmp = *this;
   --_num;
   return tmp;
}

BigNum operator-(const BigNum other1, const BigNum other2) {
    return BigNum(other1._num - other2._num);
}

BigNum operator-(const BigNum other1, long other2) {
    return BigNum(other1._num - other2);    
}

BigNum operator-(long other1, const BigNum other2) {
    return BigNum(other1 - other2._num);
}

BigNum operator/(const BigNum other1, const BigNum other2) {
    return BigNum(other1._num / other2._num);
}

BigNum operator/(long other1, const BigNum other2) {
    return BigNum(other1 / other2._num);
}

BigNum operator/(const BigNum other1, long other2){
    return BigNum(other1._num / other2);
}

int main() {
    BigNum n(5), n0(5);
    std::cout << "Initial n & n0 = " << n.num() << " " << n0.num() << std::endl;

    BigNum r0 = n + n0;
    std::cout << "r0 = n + n0 = " << r0.num() << std::endl ;
    BigNum r1 = n * n0;
    std::cout << "r1 = n * n0 = " << r1.num() << std::endl;
    BigNum r2 = n - n0;
    std::cout << "r2 = n - n0 = " << r2.num() << std::endl;
    BigNum r3(r0/n0);
    std::cout << "r3 = r0 / n0 = " << r3.num() << std::endl;

    BigNum r4 = ++r3;
    std::cout << "++r3 = " << r4.num() << std::endl;
    BigNum r5 = r3++;
    std::cout << "r3++ = " << r5.num() << std::endl;
    std::cout << "r3 = " << r3.num() << std::endl;
    BigNum r6 = --r3;
    std::cout << "--r3 = " << r6.num() << std::endl;
    BigNum r7 = r3++;
    std::cout << "r3-- = " << r7.num() << std::endl;
    std::cout << "r3 = " << r3.num() << std::endl << std::endl;

    BigNum wlong(9);
    BigNum r8 = wlong + 1;
    std::cout << "r8 = BigNum wlong(9) + 1 = " << r8.num() << std::endl;
    BigNum r9 = r8 * 2;
    std::cout << "r9 = r8 * 2 = " << r9.num() << std::endl;
    BigNum r10 = wlong - 1;
    std::cout << "r10 = BigNum wlong(9) - 1 = " << r10.num() << std::endl;
    BigNum r11 = r9 / 10;
    std::cout << "r11 = r9 / 10 = " << r11.num() << std::endl;
    
    return 0;
}
