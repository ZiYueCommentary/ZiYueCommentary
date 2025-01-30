#pragma once

#include <memory>
#include <unordered_map>
#include "Lex.h"

namespace ast {
    const std::unordered_map<char, int> binop_priority = {
        {'<',1},{'>',1},
        {'+',2 },{'-',2},
        {'*',3},{'/',3}
    };

    struct Identifier {
        std::string name;
        Token type;
    };

    class ExprAST {
    public:
        virtual ~ExprAST() {}
    };

    class IntegerExprAST : public ExprAST {
    public:
        IntegerExprAST(int value) : value(value) {

        }

    private:
        int value;
    };

    class FloatExprAST : public ExprAST {
    public:
        FloatExprAST(float value) : value(value) {

        }

    private:
        float value;
    };

    class StringExprAST : public ExprAST {
    public:
        StringExprAST(std::string&& string) : string(std::move(string)) {

        }

    private:
        std::string string;
    };

    class VariableExprAST : public ExprAST {
    public:
        VariableExprAST(std::string&& name) : name(std::move(name)) {

        }

    private:
        std::string name;
    };

    class UnaryExprAST : public ExprAST {
    public:
        UnaryExprAST(int op, std::unique_ptr<ExprAST> rhs) : op(op), rhs(std::move(rhs)) {

        }

    private:
        int op;
        std::unique_ptr<ExprAST> rhs;
    };

    class BinaryExprAST : public ExprAST {
    public:
        BinaryExprAST(int op, std::unique_ptr<ExprAST> lhs, std::unique_ptr<ExprAST> rhs) : op(op), lhs(std::move(lhs)), rhs(std::move(rhs)) {

        }

    private:
        int op;
        std::unique_ptr<ExprAST> lhs;
        std::unique_ptr<ExprAST> rhs;
    };

    class CallExprAST : public ExprAST {
    public:
        CallExprAST(std::string&& func, std::vector<std::unique_ptr<ExprAST>> args) : func(std::move(func)), args(std::move(args)) {

        }

    private:
        std::string func;
        std::vector<std::unique_ptr<ExprAST>> args
    };

    class PrototypeAST {
    public:
        PrototypeAST(std::string&& name, std::vector<Identifier>&& args) : name(std::move(name)), args(std::move(args)) {
            // 构造可能需要 std::move，但是构造需要 std::move 有点不可能
        }

    private:
        std::string name;
        std::vector<Identifier> args;
    };

    class FunctionAST {
    public:
        FunctionAST(std::unique_ptr<PrototypeAST> proto, std::unique_ptr<ExprAST> body) : proto(std::move(proto)), body(std::move(body)) {

        }

    private:
        std::unique_ptr<PrototypeAST> proto;
        std::unique_ptr<ExprAST> body;
    };

    int curr_token;

    int get_next_token();
    int get_binop_priority();

    std::unique_ptr<ExprAST> parse_primary();
    std::unique_ptr<ExprAST> parse_integer_expr();
    std::unique_ptr<ExprAST> parse_float_expr();
    std::unique_ptr<ExprAST> parse_string_expr();
    std::unique_ptr<ExprAST> parse_unary();
    std::unique_ptr<ExprAST> parse_binop_rhs(int expr_priorty, std::unique_ptr<ExprAST> lhs);
    std::unique_ptr<PrototypeAST> parse_prototype();
    std::unique_ptr<ExprAST> parse_expr();
}