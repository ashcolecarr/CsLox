﻿using CsLox.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CsLox
{
    public class Resolver : IExprVisitor<object>, IStmtVisitor<object>
    {
        private Interpreter interpreter;
        private Stack<Dictionary<string, bool>> scopes = new Stack<Dictionary<string, bool>>();
        private FunctionType currentFunction = FunctionType.NONE;
        private ClassType currentClass = ClassType.NONE;
        private LoopType currentLoop = LoopType.NONE;

        public Resolver(Interpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void Resolve(List<Stmt> statements)
        {
            foreach (Stmt statement in statements)
            {
                Resolve(statement);
            }
        }

        private void Resolve(Stmt stmt)
        {
            stmt.Accept(this);
        }

        private void Resolve(Expr expr)
        {
            expr.Accept(this);
        }

        private void ResolveFunction(Function function, FunctionType type)
        {
            FunctionType enclosingFunction = currentFunction;
            currentFunction = type;

            BeginScope();
            foreach (Token param in function.Params)
            {
                Declare(param);
                Define(param);
            }

            Resolve(function.Body);
            EndScope();

            currentFunction = enclosingFunction;
        }

        private void BeginScope()
        {
            scopes.Push(new Dictionary<string, bool>());
        }

        private void EndScope()
        {
            scopes.Pop();
        }

        private void Declare(Token name)
        {
            if (scopes.Count == 0)
            {
                return;
            }

            Dictionary<string, bool> scope = scopes.Peek();
            if (scope.ContainsKey(name.Lexeme))
            {
                CsLox.Error(name, "Variable with this name already declared in this scope.");
            }

            scope[name.Lexeme] = false;
        }

        private void Define(Token name)
        {
            if (scopes.Count == 0)
            {
                return;
            }

            if (scopes.Peek().ContainsKey(name.Lexeme))
            {
                scopes.Peek()[name.Lexeme] = true;
            }
        }

        private void ResolveLocal(Expr expr, Token name)
        {
            for (int i = 0; i < scopes.Count; i++)
            {
                if (scopes.ElementAt(i).ContainsKey(name.Lexeme))
                {
                    interpreter.Resolve(expr, i);

                    return;
                }
            }

            // Not found. Assume it is global.
        }

        public object VisitBlockStmt(Block stmt)
        {
            BeginScope();
            Resolve(stmt.Statements);
            EndScope();

            return null;
        }

        public object VisitBreakStmt(Break stmt)
        {
            if (currentLoop == LoopType.NONE)
            {
                CsLox.Error(stmt.Keyword, "Break statement must be inside a loop.");
            }

            return null;
        }

        public object VisitClassStmt(Class stmt)
        {
            ClassType enclosingClass = currentClass;
            currentClass = ClassType.CLASS;

            Declare(stmt.Name);
            Define(stmt.Name);

            if (stmt.Superclass != null && stmt.Name.Lexeme.Equals(stmt.Superclass.Name.Lexeme))
            {
                CsLox.Error(stmt.Superclass.Name, "A class cannot inherit from itself.");
            }

            if (stmt.Superclass != null)
            {
                currentClass = ClassType.SUBCLASS;
                Resolve(stmt.Superclass);
                BeginScope();
                scopes.Peek()["super"] = true;
            }

            BeginScope();
            scopes.Peek()["this"] = true;

            foreach (Function method in stmt.Methods)
            {
                FunctionType declaration = FunctionType.METHOD;
                if (method.Name.Lexeme.Equals("init"))
                {
                    declaration = FunctionType.INITIALIZER;
                }
                ResolveFunction(method, declaration);
            }

            EndScope();

            if (stmt.Superclass != null)
            {
                EndScope();
            }

            currentClass = enclosingClass;

            return null;
        }

        public object VisitExpressionStmt(Expression stmt)
        {
            Resolve(stmt.Express);

            return null;
        }

        public object VisitFunctionStmt(Function stmt)
        {
            Declare(stmt.Name);
            Define(stmt.Name);

            ResolveFunction(stmt, FunctionType.FUNCTION);

            return null;
        }

        public object VisitIfStmt(If stmt)
        {
            Resolve(stmt.Condition);
            Resolve(stmt.ThenBranch);
            if (stmt.ElseBranch != null)
            {
                Resolve(stmt.ElseBranch);
            }

            return null;
        }

        public object VisitPrintStmt(Print stmt)
        {
            Resolve(stmt.Expression);

            return null;
        }

        public object VisitReturnStmt(Return stmt)
        {
            if (currentFunction == FunctionType.NONE)
            {
                CsLox.Error(stmt.Keyword, "Cannot return from top-level code.");
            }

            if (stmt.Value != null)
            {
                if (currentFunction == FunctionType.INITIALIZER)
                {
                    CsLox.Error(stmt.Keyword, "Cannot return a value from an initializer.");
                }
                Resolve(stmt.Value);
            }

            return null;
        }

        public object VisitVarStmt(Var stmt)
        {
            Declare(stmt.Name);
            if (stmt.Initializer != null)
            {
                Resolve(stmt.Initializer);
            }
            Define(stmt.Name);

            return null;
        }

        public object VisitWhileStmt(While stmt)
        {
            LoopType enclosingLoop = currentLoop;
            currentLoop = LoopType.WHILE;
            Resolve(stmt.Condition);
            Resolve(stmt.Body);
            currentLoop = enclosingLoop;

            return null;
        }

        public object VisitAssignExpr(Assign expr)
        {
            Resolve(expr.Value);
            ResolveLocal(expr, expr.Name);

            return null;
        }

        public object VisitBinaryExpr(Binary expr)
        {
            Resolve(expr.Left);
            Resolve(expr.Right);

            return null;
        }

        public object VisitCallExpr(Call expr)
        {
            Resolve(expr.Callee);

            foreach (Expr argument in expr.Arguments)
            {
                Resolve(argument);
            }

            return null;
        }

        public object VisitGetExpr(Get expr)
        {
            Resolve(expr.Object);

            return null;
        }

        public object VisitGroupingExpr(Grouping expr)
        {
            Resolve(expr.Expression);

            return null;
        }

        public object VisitLiteralExpr(Literal expr)
        {
            return null;
        }

        public object VisitLogicalExpr(Logical expr)
        {
            Resolve(expr.Left);
            Resolve(expr.Right);

            return null;
        }

        public object VisitSetExpr(Set expr)
        {
            Resolve(expr.Value);
            Resolve(expr.Object);

            return null;
        }

        public object VisitSuperExpr(Super expr)
        {
            if (currentClass == ClassType.NONE)
            {
                CsLox.Error(expr.Keyword, "Cannot use 'super' outside of a class.");
            }
            else if (currentClass != ClassType.SUBCLASS)
            {
                CsLox.Error(expr.Keyword, "Cannot use 'super' in a class with no superclass.");
            }

            ResolveLocal(expr, expr.Keyword);

            return null;
        }

        public object VisitTernaryExpr(Ternary expr)
        {
            Resolve(expr.Condition);
            Resolve(expr.ThenBranch);
            Resolve(expr.ElseBranch);

            return null;
        }

        public object VisitThisExpr(This expr)
        {
            if (currentClass == ClassType.NONE)
            {
                CsLox.Error(expr.Keyword, "Cannot use 'this' outside of a class.");
            }
            ResolveLocal(expr, expr.Keyword);

            return null;
        }

        public object VisitUnaryExpr(Unary expr)
        {
            Resolve(expr.Right);

            return null;
        }

        public object VisitVariableExpr(Variable expr)
        {
            if (scopes.Count > 0 && scopes.Peek().TryGetValue(expr.Name.Lexeme, out bool value))
            {
                if (!value)
                {
                    CsLox.Error(expr.Name, "Cannot read local variable in its own initializer.");
                }
            }

            ResolveLocal(expr, expr.Name);

            return null;
        }
    }
}
