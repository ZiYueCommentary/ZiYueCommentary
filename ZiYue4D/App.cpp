#include <iostream>
#include "Lex.h"

int main() {
    lex::file = new std::ifstream("E:\\ZiYueCommentary\\ZiYue4D\\example.sb");
    if (!lex::file->good()) return -1;
    int token;
    while ((token = lex::get_token()) != TOKEN_EOF) {
        std::cout << token;
        if (token == TOKEN_IDENT) std::cout << lex::identifier;
        if (token == TOKEN_INTEGER) std::cout << lex::int_value;
        if (token == TOKEN_FLOAT) std::cout << lex::float_value;
        if (token == TOKEN_STRING) std::cout << lex::string_value;
        std::cout << "\n";
    }
}