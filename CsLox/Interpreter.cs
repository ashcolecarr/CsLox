using CsLox.Enums;
using CsLox.Exceptions;
using System;

namespace CsLox
{
    public class Interpreter : IExprVisitor<object>
    {
        public void Interpret(Expr expression)
        {
            try
            {
                object value = Evaluate(expression);
                Console.WriteLine(Stringify(value));
            }
            catch (RuntimeException re)
            {
                CsLox.RuntimeError(re);
            }
        }
        private object Evaluate(Expr expr)
        {
            return expr.Accept(this);
        }

        public object VisitBinaryExpr(Binary expr)
        {
            object left = Evaluate(expr.Left);
            object right = Evaluate(expr.Right);

            switch (expr.Operator.Type)
            {
                case TokenType.GREATER:
                    CheckNumberOperands(expr.Operator, left, right);
                    return (double)left > (double)right;
                case TokenType.GREATER_EQUAL:
                    CheckNumberOperands(expr.Operator, left, right);
                    return (double)left >= (double)right;
                case TokenType.LESS:
                    CheckNumberOperands(expr.Operator, left, right);
                    return (double)left < (double)right;
                case TokenType.LESS_EQUAL:
                    CheckNumberOperands(expr.Operator, left, right);
                    return (double)left <= (double)right;
                case TokenType.BANG_EQUAL:
                    return !IsEqual(left, right);
                case TokenType.EQUAL_EQUAL:
                    return IsEqual(left, right);
                case TokenType.MINUS:
                    CheckNumberOperands(expr.Operator, left, right);
                    return (double)left - (double)right;
                case TokenType.PLUS:
                    if (left.GetType() == typeof(double) && right.GetType() == typeof(double))
                    {
                        return (double)left + (double)right;
                    }

                    if (left.GetType() == typeof(string) && right.GetType() == typeof(string))
                    {
                        return (string)left + (string)right;
                    }

                    if (left.GetType() == typeof(string))
                    {
                        return (string)left + right.ToString();
                    }

                    if (right.GetType() == typeof(string))
                    {
                        return left.ToString() + (string)right;
                    }

                    throw new RuntimeException(expr.Operator, "Operands must be two numbers or two strings.");
                case TokenType.SLASH:
                    CheckNumberOperands(expr.Operator, left, right);
                    if (Math.Abs((double)right) < double.Epsilon)
                    {
                        throw new RuntimeException(expr.Operator, "Cannot divide by zero.");
                    }
                    return (double)left / (double)right;
                case TokenType.STAR:
                    CheckNumberOperands(expr.Operator, left, right);
                    return (double)left * (double)right;
            }

            // Unreachable.
            return null;
        }

        public object VisitGroupingExpr(Grouping expr)
        {
            return Evaluate(expr.Expression);
        }

        public object VisitLiteralExpr(Literal expr)
        {
            return expr.Value;
        }

        public object VisitUnaryExpr(Unary expr)
        {
            object right = Evaluate(expr.Right);

            switch (expr.Operator.Type)
            {
                case TokenType.BANG:
                    return !IsTruthy(right);
                case TokenType.MINUS:
                    CheckNumberOperand(expr.Operator, right);
                    return -(double)right;
            }

            // Unreachable.
            return null;
        }

        private void CheckNumberOperand(Token @operator, object operand)
        {
            if (operand.GetType() == typeof(double))
            {
                return;
            }

            throw new RuntimeException(@operator, "Operand must be a number.");
        }

        private void CheckNumberOperands(Token @operator, object left, object right)
        {
            if (left.GetType() == typeof(double) && right.GetType() == typeof(double))
            {
                return;
            }

            throw new RuntimeException(@operator, "Operands must be numbers");
        }

        private bool IsTruthy(object @object)
        {
            if (@object == null)
            {
                return false;
            }

            if (@object.GetType() == typeof(bool))
            {
                return (bool)@object;
            }

            return true;
        }

        private bool IsEqual(object a, object b)
        {
            // nil is only equal to nil.
            if (a == null && b == null)
            {
                return true;
            }

            if (a == null)
            {
                return false;
            }

            return a.Equals(b);
        }

        private string Stringify(object @object)
        {
            if (@object == null)
            {
                return "nil";
            }

            if (@object.GetType() == typeof(double))
            {
                string text = @object.ToString();
                if (text.EndsWith(".0"))
                {
                    text = text.Substring(0, text.Length - 2); 
                }

                return text;
            }

            return @object.ToString();
        }
    }
}
