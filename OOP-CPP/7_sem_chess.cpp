// Problema celor n regine(dame) Se cere sa se genereze toate posibilitatile deasezare a n dame pe o tabla
// de sah de dimensiune n*n, astfel in cat sa nu se ‘atace’ reciproc. Dupa cum stim, rezolvarea problemei difera
// de generarea permutarilor doar printr-o singura metoda : e_valid(). Atunci, vom redefini aceasta metoda
// din clasa permut, pentru a putea obtine solutia dorita

// e_valid() = is_valid()
#include <iostream>

class BoardPermutations {
public:
	BoardPermutations(int n){ this->n = n; }
protected:
	int n, m[27];
	char c[27] = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	bool is_valid() {											// Polymorphic function !!
		return true;
	}
};

class Queen:protected BoardPermutations {
public:
	Queen(int n):BoardPermutations(n){ this->n = n; }
private:
	void loop(int i, int j) {
		if (j < n) {
			if (is_valid(i, j, i - 1)) {
				m[i] = j;
				solve(i + 1);
			}
			loop(i, j + 1);
		}
	}
	bool is_valid(int i, int j, int k) {                           //Polymorphic function !!
		return k < 0 || m[k] != j && (i - k) != (j - m[k])
				&& (i - k) != (m[k] - j) && is_valid(i, j, k - 1);
	}
public:
	void show(int i) {
		if (i < n) {
			std::cout << c[i] << m[i] + 1 << " ";
			show(i + 1);
		}
		else std::cout << "\n";
	}
	void solve(int i) {
		if (i < n) loop(i, 0);
		else show(0);
	}
};

int main() {
	int n;
	std::cout << "Enter the queens number:\n";
	std::cin >> n;
	Queen q(n);
	q.solve(0);
}