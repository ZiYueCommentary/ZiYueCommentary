#pragma once

// ´Ê·¨·ÖÎöÆ÷
#include <vector>
#include <string>
#include <fstream>
#include "Token.h"

namespace lex {
    static std::ifstream* file = nullptr;
    static std::string identifier = "";
    static int int_value = -1;
    static float float_value = -1.0f;
    static std::string string_value = "";

    static int get_token() {
        static int last_char = ' ';
        while (isspace(last_char)) last_char = file->get();
        if (last_char == '%') { last_char = file->get(); return TOKEN_TYPE_INT; }
        if (last_char == '#') { last_char = file->get(); return TOKEN_TYPE_FLOAT; }
        if (last_char == '$') { last_char = file->get(); return TOKEN_TYPE_STRING; }

        if (last_char == '\"') {
            while ((last_char = file->get()) != '\"') string_value += last_char;
            last_char = file->get();
            return TOKEN_STRING;
        }

        if (isalpha(last_char)) {
            identifier = last_char;
            while (isalnum(last_char = file->get())) identifier += last_char;
            if (identifier == "Function") {
                return TOKEN_FUNCTION;
            }
            else if (identifier == "Native") {
                return TOKEN_NATIVE;
            }
            else if (identifier == "End") {
                return TOKEN_END;
            }
            else {
                return TOKEN_IDENT;
            }
        }

        if (isdigit(last_char) || last_char == '.') {
            std::string number;
            Token type = TOKEN_INTEGER;
            do {
                number += last_char;
                if (last_char == '.') type = TOKEN_FLOAT;
                last_char = file->get();
            } while (isdigit(last_char) || last_char == '.');
            if (number == "...") return TOKEN_INF_ARGS;
            if (type == TOKEN_INTEGER) {
                int_value = atoi(number.c_str());
            }
            else {
                float_value = strtof(number.c_str(), nullptr);
            }
            return type;
        }

        if (last_char == ';') {
            do {
                last_char = file->get();
            } while (last_char != EOF && last_char != '\n' && last_char != '\r');
            if (last_char != EOF) return get_token();
        }

        if (last_char == EOF) return TOKEN_EOF;

        int curr_char = last_char;
        last_char = file->get();
        return curr_char;
    }
}