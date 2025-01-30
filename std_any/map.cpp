#include<iostream>
#include<initializer_list>

class BitBool {
private:
    typedef unsigned char byte;

public:
    short bit = 0b00000000;
    BitBool() {
    }

    BitBool(byte init_value) {
        bit = (int)init_value;
    }

    BitBool(std::initializer_list<bool> init_list) {
        if (init_list.size() > 8) throw std::out_of_range("BitBool requires 8 boolean values at maximum!");

        int i = 0;
        short b = 0;
        for (auto it = init_list.begin(); it != init_list.end(); it++) {
            short a = *it << (7 - i);
            b = b | a;
            i++;
        }
        bit = b;
    }

    bool read_bool(int index) {
        return (bit << index) >> 7;
    }

    BitBool& write_bool(int index, bool value) {
        bit = (bit >> index << index) | (value << (7 - index) | (bit << index + 1));
        return *this;
    }
};

std::ostream& operator<<(std::ostream& stream, BitBool& bitbool) {
    for (int i = 0; i < 8; i++) {
        stream << bitbool.read_bool(i);
    }
    return stream;
}

int main() {
    long a = 1145141919810L;
    std::cout << a;
}