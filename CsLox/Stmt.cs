﻿using System.Collections.Generic;

namespace CsLox
{
    public abstract class Stmt
    {

        public abstract T Accept<T>(IStmtVisitor<T> visitor);
    }

    public class Block : Stmt
    {
        public List<Stmt> Statements { get; }

        public Block(List<Stmt> statements)
        {
            Statements = statements;
        }

        public override T Accept<T>(IStmtVisitor<T> visitor)
        {
            return visitor.VisitBlockStmt(this);
        }
    }

    public class Class : Stmt
    {
        public Token Name { get; }
        public Variable Superclass { get; }
        public List<Function> Methods { get; }

        public Class(Token name, Variable superclass, List<Function> methods)
        {
            Name = name;
            Superclass = superclass;
            Methods = methods;
        }

        public override T Accept<T>(IStmtVisitor<T> visitor)
        {
            return visitor.VisitClassStmt(this);
        }
    }

    public class Break : Stmt
    {
        public Token Keyword { get; }

        public Break(Token keyword)
        {
            Keyword = keyword;
        }

        public override T Accept<T>(IStmtVisitor<T> visitor)
        {
            return visitor.VisitBreakStmt(this);
        }
    }

    public class Expression : Stmt
    {
        public Expr Express { get; }

        public Expression(Expr express)
        {
            Express = express;
        }

        public override T Accept<T>(IStmtVisitor<T> visitor)
        {
            return visitor.VisitExpressionStmt(this);
        }
    }

    public class Function : Stmt
    {
        public Token Name { get; }
        public List<Token> Params { get; }
        public List<Stmt> Body { get; }

        public Function(Token name, List<Token> @params, List<Stmt> body)
        {
            Name = name;
            Params = @params;
            Body = body;
        }

        public override T Accept<T>(IStmtVisitor<T> visitor)
        {
            return visitor.VisitFunctionStmt(this);
        }
    }

    public class If : Stmt
    {
        public Expr Condition { get; }
        public Stmt ThenBranch { get; }
        public Stmt ElseBranch { get; }

        public If(Expr condition, Stmt thenBranch, Stmt elseBranch)
        {
            Condition = condition;
            ThenBranch = thenBranch;
            ElseBranch = elseBranch;
        }

        public override T Accept<T>(IStmtVisitor<T> visitor)
        {
            return visitor.VisitIfStmt(this);
        }
    }

    public class Print : Stmt
    {
        public Expr Expression { get; }

        public Print(Expr expression)
        {
            Expression = expression;
        }

        public override T Accept<T>(IStmtVisitor<T> visitor)
        {
            return visitor.VisitPrintStmt(this);
        }
    }

    public class Return : Stmt
    {
        public Token Keyword { get; }
        public Expr Value { get; }

        public Return(Token keyword, Expr value)
        {
            Keyword = keyword;
            Value = value;
        }

        public override T Accept<T>(IStmtVisitor<T> visitor)
        {
            return visitor.VisitReturnStmt(this);
        }
    }

    public class Var : Stmt
    {
        public Token Name { get; }
        public Expr Initializer { get; }

        public Var(Token name, Expr initializer)
        {
            Name = name;
            Initializer = initializer;
        }

        public override T Accept<T>(IStmtVisitor<T> visitor)
        {
            return visitor.VisitVarStmt(this);
        }
    }

    public class While : Stmt
    {
        public Expr Condition { get; }
        public Stmt Body { get; }

        public While(Expr condition, Stmt body)
        {
            Condition = condition;
            Body = body;
        }

        public override T Accept<T>(IStmtVisitor<T> visitor)
        {
            return visitor.VisitWhileStmt(this);
        }
    }

    public interface IStmtVisitor<T>
    {
        T VisitBlockStmt(Block stmt);
        T VisitClassStmt(Class stmt);
        T VisitBreakStmt(Break stmt);
        T VisitExpressionStmt(Expression stmt);
        T VisitFunctionStmt(Function stmt);
        T VisitIfStmt(If stmt);
        T VisitPrintStmt(Print stmt);
        T VisitReturnStmt(Return stmt);
        T VisitVarStmt(Var stmt);
        T VisitWhileStmt(While stmt);
    }
}
