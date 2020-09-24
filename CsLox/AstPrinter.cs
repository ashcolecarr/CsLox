﻿using System.Text;

namespace CsLox
{
    public class AstPrinter : IExprVisitor<string>
    {
        public string Print(Expr expr)
        {
            return expr.Accept(this);
        }

        public string VisitAssignExpr(Assign expr)
        {
            throw new System.NotImplementedException();
        }

        public string VisitBinaryExpr(Binary expr)
        {
            return Parenthesize(expr.Operator.Lexeme, expr.Left, expr.Right);
        }

        public string VisitGroupingExpr(Grouping expr)
        {
            return Parenthesize("group", expr.Expression);
        }

        public string VisitLiteralExpr(Literal expr)
        {
            if (expr.Value == null)
            {
                return "nil";
            }

            return expr.Value.ToString();
        }

        public string VisitLogicalExpr(Logical expr)
        {
            throw new System.NotImplementedException();
        }

        public string VisitUnaryExpr(Unary expr)
        {
            return Parenthesize(expr.Operator.Lexeme, expr.Right);
        }

        public string VisitVariableExpr(Variable expr)
        {
            throw new System.NotImplementedException();
        }

        private string Parenthesize(string name, params Expr[] exprs)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("(").Append(name);
            foreach (Expr expr in exprs)
            {
                builder.Append(" ");
                builder.Append(expr.Accept(this));
            }
            builder.Append(")");

            return builder.ToString();
        }
    }
}