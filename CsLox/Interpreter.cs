﻿using CsLox.Enums;
using CsLox.Exceptions;
using CsLox.Interfaces;
using CsLox.NativeFunctions;
using System;
using System.Collections.Generic;

namespace CsLox
{
    public class Interpreter : IExprVisitor<object>, IStmtVisitor<object>
    {
        public LoxEnvironment Globals = new LoxEnvironment();
        private LoxEnvironment environment;
        private Dictionary<Expr, int> locals = new Dictionary<Expr, int>();

        public Interpreter()
        {
            Globals.Define("clock", new Clock());
            Globals.Define("power", new Power());
            environment = Globals;
        }

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

        public void Resolve(Expr expr, int depth)
        {
            if (locals.ContainsKey(expr))
            {
                locals[expr] = depth;
            }
            else
            {
                locals.Add(expr, depth);
            }
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

        public object VisitBreakStmt(Break stmt)
        {
            throw new BreakException();
        }

        public object VisitClassStmt(Class stmt)
        {
            object superclass = null;
            if (stmt.Superclass != null)
            {
                superclass = Evaluate(stmt.Superclass);
                if (!(superclass is LoxClass))
                {
                    throw new RuntimeException(stmt.Superclass.Name, "Superclass must be a class.");
                }
            }

            environment.Define(stmt.Name.Lexeme, null);

            if (stmt.Superclass != null)
            {
                environment = new LoxEnvironment(environment);
                environment.Define("super", superclass);
            }

            Dictionary<string, LoxFunction> methods = new Dictionary<string, LoxFunction>();
            foreach (Function method in stmt.Methods)
            {
                LoxFunction function = new LoxFunction(method, environment, method.Name.Lexeme.Equals("init"));
                methods.Add(method.Name.Lexeme, function);
            }

            LoxClass @class = new LoxClass(stmt.Name.Lexeme, (LoxClass)superclass, methods);

            if (superclass != null)
            {
                environment = environment.Enclosing;
            }

            environment.Assign(stmt.Name, @class);

            return null;
        }

        public object VisitExpressionStmt(Expression stmt)
        {
            object value = Evaluate(stmt.Express);
            if (stmt.Express is Binary || stmt.Express is Unary || stmt.Express is Ternary)
            {
                Console.WriteLine(Stringify(value));
            }

            return null;
        }

        public object VisitFunctionStmt(Function stmt)
        {
            LoxFunction function = new LoxFunction(stmt, environment, false);
            environment.Define(stmt.Name.Lexeme, function);

            return null;
        }

        public object VisitIfStmt(If stmt)
        {
            if (IsTruthy(Evaluate(stmt.Condition)))
            {
                Execute(stmt.ThenBranch);
            }
            else if (stmt.ElseBranch != null)
            {
                Execute(stmt.ElseBranch);
            }

            return null;
        }

        public object VisitPrintStmt(Print stmt)
        {
            object value = Evaluate(stmt.Expression);
            Console.WriteLine(Stringify(value));

            return null;
        }

        public object VisitReturnStmt(Return stmt)
        {
            object value = null;
            if (stmt.Value != null)
            {
                value = Evaluate(stmt.Value);
            }

            throw new ReturnException(value);
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

        public object VisitWhileStmt(While stmt)
        {
            while (IsTruthy(Evaluate(stmt.Condition)))
            {
                try
                {
                    Execute(stmt.Body);
                }
                catch (BreakException)
                {
                    break;
                }
            }

            return null;
        }

        public object VisitAssignExpr(Assign expr)
        {
            object value = Evaluate(expr.Value);

            if (locals.TryGetValue(expr, out int distance))
            {
                environment.AssignAt(distance, expr.Name, value);
            }
            else
            {
                Globals.Assign(expr.Name, value);
            }

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
                    if (left == null)
                    {
                        throw new RuntimeException(expr.Operator, "Left-hand operand cannot be nil.");
                    }

                    if (right == null)
                    {
                        throw new RuntimeException(expr.Operator, "Right-hand operand cannot be nil.");
                    }

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
                case TokenType.PERCENT:
                    CheckNumberOperands(expr.Operator, left, right);
                    return (double)left % (double)right;
            }

            // Unreachable.
            return null;
        }

        public object VisitCallExpr(Call expr)
        {
            object callee = Evaluate(expr.Callee);

            List<object> arguments = new List<object>();
            foreach (Expr argument in expr.Arguments)
            {
                arguments.Add(Evaluate(argument));
            }

            ILoxCallable function = (ILoxCallable)callee;
            if (arguments.Count != function.Arity())
            {
                throw new RuntimeException(expr.Paren, $"Expected {function.Arity()} arguments but got {arguments.Count}.");
            }

            return function.Call(this, arguments);
        }

        public object VisitGetExpr(Get expr)
        {
            object @object = Evaluate(expr.Object);
            if (@object is LoxInstance)
            {
                return ((LoxInstance)@object).Get(expr.Name);
            }

            throw new RuntimeException(expr.Name, "Only instances have properties.");
        }

        public object VisitGroupingExpr(Grouping expr)
        {
            return Evaluate(expr.Expression);
        }

        public object VisitLiteralExpr(Literal expr)
        {
            return expr.Value;
        }

        public object VisitLogicalExpr(Logical expr)
        {
            object left = Evaluate(expr.Left);

            if (expr.Operator.Type == TokenType.OR)
            {
                if (IsTruthy(left))
                {
                    return left;
                }
            }
            else
            {
                if (!IsTruthy(left))
                {
                    return left;
                }
            }

            return Evaluate(expr.Right);
        }

        public object VisitSetExpr(Set expr)
        {
            object @object = Evaluate(expr.Object);
            if (!(@object is LoxInstance))
            {
                throw new RuntimeException(expr.Name, "Only instances have fields.");
            }

            object value = Evaluate(expr.Value);
            ((LoxInstance)@object).Set(expr.Name, value);

            return value;
        }

        public object VisitSuperExpr(Super expr)
        {
            int distance = locals[expr];
            LoxClass superclass = (LoxClass)environment.GetAt(distance, "super");

            // "this" is always one level nearer than "super"'s environment.
            LoxInstance @object = (LoxInstance)environment.GetAt(distance - 1, "this");

            LoxFunction method = superclass.FindMethod(expr.Method.Lexeme);
            if (method == null)
            {
                throw new RuntimeException(expr.Method, $"Undefined property '{expr.Method.Lexeme}'.");
            }

            return method.Bind(@object);
        }

        public object VisitThisExpr(This expr)
        {
            return LookUpVariable(expr.Keyword, expr);
        }

        public object VisitTernaryExpr(Ternary expr)
        {
            if (IsTruthy(Evaluate(expr.Condition)))
            {
                return Evaluate(expr.ThenBranch);
            }
            else
            {
                return Evaluate(expr.ElseBranch);
            }
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
            return LookUpVariable(expr.Name, expr);
        }

        private object LookUpVariable(Token name, Expr expr)
        {
            if (locals.TryGetValue(expr, out int distance))
            {
                return environment.GetAt(distance, name.Lexeme);
            }
            else
            {
                return Globals.Get(name);
            }
        }

        private void CheckNumberOperand(Token @operator, object operand)
        {
            if (operand == null)
            {
                throw new RuntimeException(@operator, "Operand must be a number.");
            }

            if (operand.GetType() == typeof(double))
            {
                return;
            }

            throw new RuntimeException(@operator, "Operand must be a number.");
        }

        private void CheckNumberOperands(Token @operator, object left, object right)
        {
            if (left == null || right == null)
            {
                throw new RuntimeException(@operator, "Operands must be numbers.");
            }

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
