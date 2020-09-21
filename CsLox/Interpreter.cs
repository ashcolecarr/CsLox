using CsLox.Enums;
using CsLox.Exceptions;
using System;
using System.Collections.Generic;

namespace CsLox
{
    public class Interpreter : IExprVisitor<object>, IStmtVisitor<object>
    {
        private LoxEnvironment environment = new LoxEnvironment();

        public void Interpret(List<Stmt> statements)
        {
            try
            {
                foreach (Stmt statement in statements)
                {
                    Execute(statement);
                }
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

        private void Execute(Stmt stmt)
        {
            stmt.Accept(this);
        }

        public void ExecuteBlock(List<Stmt> statements, LoxEnvironment environment)
        {
            LoxEnvironment previous = this.environment;
            try
            {
                this.environment = environment;

                foreach (Stmt statement in statements)
                {
                    Execute(statement);
                }
            }
            finally
            {
                this.environment = previous;
            }
        }

        public object VisitBlockStmt(Block stmt)
        {
            ExecuteBlock(stmt.Statements, new LoxEnvironment(environment));

            return null;
        }

        public object VisitExpressionStmt(Expression stmt)
        {
            Evaluate(stmt.Express);

            return null;
        }

        public object VisitPrintStmt(Print stmt)
        {
            object value = Evaluate(stmt.Expression);
            Console.WriteLine(Stringify(value));

            return null;
        }

        public object VisitVarStmt(Var stmt)
        {
            object value = null;
            if (stmt.Initializer != null)
            {
                value = Evaluate(stmt.Initializer);
            }

            environment.Define(stmt.Name.Lexeme, value);

            return null;
        }

        public object VisitAssignExpr(Assign expr)
        {
            object value = Evaluate(expr.Value);
            environment.Assign(expr.Name, value);

            return value;
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

        public object VisitVariableExpr(Variable expr)
        {
            return environment.Get(expr.Name);
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

            throw new RuntimeException(@operator, "Operands must be numbers.");
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
