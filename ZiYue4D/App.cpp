#include <iostream>
#include "AST.h"

int main() {
    lex::file = std::move(new std::ifstream("E:\\ZiYueCommentary\\ZiYue4D\\example.sb"));
    if (!lex::file->good()) return -1;
    auto expr = ast::parse_expr();
    std::cout << expr.get();
}