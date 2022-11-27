#include <iostream>
using namespace std;

void foo() {
	cout << "hello!";
}

int main() {
	int add;
	cout << &foo << endl;
	cin >> add;
	void* func = (void*)add;

}