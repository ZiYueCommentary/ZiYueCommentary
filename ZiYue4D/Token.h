#pragma once

#include <unordered_map>

enum Token
{
    TOKEN_EOF = -1,
    TOKEN_FUNCTION = -2,
    TOKEN_END = -3,
    TOKEN_IDENT = -4,
    TOKEN_INTEGER = -5,
    TOKEN_FLOAT = -6,
    TOKEN_STRING = -7,
    TOKEN_TYPE_STRING = -8,
    TOKEN_TYPE_INT = -9,
    TOKEN_TYPE_FLOAT = -10
};

const std::unordered_map<std::string, Token> keywords = {
    {"function", TOKEN_FUNCTION},
    {"end", TOKEN_END}
};

