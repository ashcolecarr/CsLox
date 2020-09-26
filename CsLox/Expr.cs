using System.Collections.Generic;

namespace CsLox
{
    public abstract class Expr
    {

        public abstract T Accept<T>(IExprVisitor<T> visitor);
    }

    public class Assign : Expr
    {
        public Token Name { get; }
        public Expr Value { get; }

        public Assign(Token name, Expr value)
        {
            Name = name;
            Value = value;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitAssignExpr(this);
        }
    }

    public class Binary : Expr
    {
        public Expr Left { get; }
        public Token Operator { get; }
        public Expr Right { get; }

        public Binary(Expr left, Token @operator, Expr right)
        {
            Left = left;
            Operator = @operator;
            Right = right;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitBinaryExpr(this);
        }
    }

    public class Call : Expr
    {
        public Expr Callee { get; }
        public Token Paren { get; }
        public List<Expr> Arguments { get; }

        public Call(Expr callee, Token paren, List<Expr> arguments)
        {
            Callee = callee;
            Paren = paren;
            Arguments = arguments;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitCallExpr(this);
        }
    }

    public class Get : Expr
    {
        public Expr Object { get; }
        public Token Name { get; }

        public Get(Expr @object, Token name)
        {
            Object = @object;
            Name = name;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitGetExpr(this);
        }
    }

    public class Grouping : Expr
    {
        public Expr Expression { get; }

        public Grouping(Expr expression)
        {
            Expression = expression;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitGroupingExpr(this);
        }
    }

    public class Literal : Expr
    {
        public object Value { get; }

        public Literal(object value)
        {
            Value = value;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitLiteralExpr(this);
        }
    }

    public class Logical : Expr
    {
        public Expr Left { get; }
        public Token Operator { get; }
        public Expr Right { get; }

        public Logical(Expr left, Token @operator, Expr right)
        {
            Left = left;
            Operator = @operator;
            Right = right;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitLogicalExpr(this);
        }
    }

    public class Set : Expr
    {
        public Expr Object { get; }
        public Token Name { get; }
        public Expr Value { get; }

        public Set(Expr @object, Token name, Expr value)
        {
            Object = @object;
            Name = name;
            Value = value;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitSetExpr(this);
        }
    }

    public class Ternary : Expr
    {
        public Expr Condition { get; }
        public Expr ThenBranch { get; }
        public Expr ElseBranch { get; }

        public Ternary(Expr condition, Expr thenBranch, Expr elseBranch)
        {
            Condition = condition;
            ThenBranch = thenBranch;
            ElseBranch = elseBranch;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitTernaryExpr(this);
        }
    }

    public class This : Expr
    {
        public Token Keyword { get; }

        public This(Token keyword)
        {
            Keyword = keyword;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitThisExpr(this);
        }
    }

    public class Unary : Expr
    {
        public Token Operator { get; }
        public Expr Right { get; }

        public Unary(Token @operator, Expr right)
        {
            Operator = @operator;
            Right = right;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitUnaryExpr(this);
        }
    }

    public class Variable : Expr
    {
        public Token Name { get; }

        public Variable(Token name)
        {
            Name = name;
        }

        public override T Accept<T>(IExprVisitor<T> visitor)
        {
            return visitor.VisitVariableExpr(this);
        }
    }

    public interface IExprVisitor<T>
    {
        T VisitAssignExpr(Assign expr);
        T VisitBinaryExpr(Binary expr);
        T VisitCallExpr(Call expr);
        T VisitGetExpr(Get expr);
        T VisitGroupingExpr(Grouping expr);
        T VisitLiteralExpr(Literal expr);
        T VisitLogicalExpr(Logical expr);
        T VisitSetExpr(Set expr);
        T VisitTernaryExpr(Ternary expr);
        T VisitThisExpr(This expr);
        T VisitUnaryExpr(Unary expr);
        T VisitVariableExpr(Variable expr);
    }
}
