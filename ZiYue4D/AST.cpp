#include "AST.h"

namespace ast {
    int get_next_token() {
        curr_token = ::lex::get_token();
        return curr_token;
    }

    int get_binop_priority() {
        if (binop_priority.contains(curr_token)) {
            return binop_priority.at(curr_token);
        }
        else {
            return -1;
        }
    }

    std::unique_ptr<ExprAST> parse_primary() {
        switch (curr_token) {
        case TOKEN_INTEGER:
            return parse_integer_expr();
        case TOKEN_FLOAT:
            return parse_float_expr();
        case TOKEN_STRING:
            return parse_string_expr();
        default:
            return nullptr;
        }
    }

    std::unique_ptr<ExprAST> parse_integer_expr() {
        std::unique_ptr<ExprAST> expr = std::make_unique<IntegerExprAST>(::lex::int_value);
        get_next_token();
        return std::move(expr);
    }

    std::unique_ptr<ExprAST> parse_float_expr()
    {
        std::unique_ptr<ExprAST> expr = std::make_unique<FloatExprAST>(::lex::float_value);
        get_next_token();
        return std::move(expr);
    }

    std::unique_ptr<ExprAST> parse_string_expr()
    {
        std::unique_ptr<ExprAST> expr = std::make_unique<StringExprAST>(::lex::string_value);
        get_next_token();
        return std::move(expr);
    }

    std::unique_ptr<ExprAST> parse_unary()
    {
        if (!isascii(curr_token) || curr_token == '(' || curr_token == ')') {
            return parse_primary();
        }

        int op = curr_token;
        get_next_token();
        if (std::unique_ptr<ExprAST> oparg = parse_unary()) {
            return std::make_unique<UnaryExprAST>(op, std::move(oparg));
        }
        return nullptr;
    }

    std::unique_ptr<ExprAST> parse_binop_rhs(int expr_priorty, std::unique_ptr<ExprAST> lhs)
    {
        for (;;) {
            int curr_binop_priority = get_binop_priority();
            if (curr_binop_priority < expr_priorty) {
                return lhs;
            }

            int curr_binop = curr_token;
            get_next_token();

            std::unique_ptr<ExprAST> rhs = parse_unary();
            if (rhs == nullptr) return nullptr;

            int next_binop_priority = get_binop_priority();
            if (curr_binop_priority < next_binop_priority) {
                rhs = parse_binop_rhs(curr_binop_priority + 1, std::move(rhs)); // 优先算左边的式子
                if (rhs == nullptr) return nullptr;
            }

            lhs = std::make_unique<BinaryExprAST>(curr_binop, std::move(lhs), std::move(rhs));
        }
    }

    std::unique_ptr<PrototypeAST> parse_prototype() {
        std::string identifier = lex::identifier;
        get_next_token();
        std::vector<Identifier> args;
        while (get_next_token() == TOKEN_IDENT) {
            std::string name = lex::identifier;
            int type = get_next_token();
            if (type == ',') {
                args.push_back({ name, TOKEN_TYPE_INT });
                continue;
            }
            if (type == TOKEN_TYPE_INT || type == TOKEN_TYPE_FLOAT || type == TOKEN_TYPE_STRING) {
                args.push_back({ name, (Token)type });
                continue;
            }
            throw std::exception("Invalid statement.");
        }
        get_next_token();
        return std::make_unique<PrototypeAST>(identifier, args);
    }

    std::unique_ptr<ExprAST> parse_expr()
    {
        std::unique_ptr<ExprAST> lhs = parse_unary();
        if (lhs == nullptr) return nullptr;
        return parse_binop_rhs(0, std::move(lhs)); // 这个不需要 std::move
    }
}