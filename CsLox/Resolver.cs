using CsLox.Enums;
using System.Collections.Generic;
using System.Linq;

namespace CsLox
{
    public class Resolver : IExprVisitor<object>, IStmtVisitor<object>
    {
        private Interpreter interpreter;
        private Stack<Dictionary<string, bool>> scopes = new Stack<Dictionary<string, bool>>();
        private FunctionType currentFunction = FunctionType.NONE;

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

        public object VisitBlockStmt(Block stmt)
        {
            BeginScope();
            Resolve(stmt.Statements);
            EndScope();

            return null;
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

        public object VisitBreakStmt(Break stmt)
        {
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
            Resolve(stmt.Condition);
            Resolve(stmt.Body);

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

        public object VisitTernaryExpr(Ternary expr)
        {
            Resolve(expr.Condition);
            Resolve(expr.ThenBranch);
            Resolve(expr.ElseBranch);

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
