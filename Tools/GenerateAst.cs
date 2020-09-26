using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tools
{
    public class GenerateAst
    {
        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: generateast <output directory>");
                Environment.Exit(1);
            }

            string outputDir = args[0];

            DefineAst(outputDir, "Expr", new List<string>
            {
                "Assign   : Token name, Expr value", 
                "Binary   : Expr left, Token @operator, Expr right",
                "Call     : Expr callee, Token paren, List<Expr> arguments",
                "Get      : Expr @object, Token name",
                "Grouping : Expr expression",
                "Literal  : object value",
                "Logical  : Expr left, Token @operator, Expr right",
                "Set      : Expr @object, Token name, Expr value",
                "Super    : Token keyword, Token method",
                "Ternary  : Expr condition, Expr thenBranch, Expr elseBranch",
                "This     : Token keyword",
                "Unary    : Token @operator, Expr right",
                "Variable : Token name"
            });

            DefineAst(outputDir, "Stmt", new List<string>
            {
                "Block      : List<Stmt> statements",
                "Class      : Token name, Variable superclass, List<Function> methods",
                "Break      : Token keyword",
                "Expression : Expr express",
                "Function   : Token name, List<Token> @params, List<Stmt> body",
                "If         : Expr condition, Stmt thenBranch, Stmt elseBranch",
                "Print      : Expr expression",
                "Return     : Token keyword, Expr value",
                "Var        : Token name, Expr initializer",
                "While      : Expr condition, Stmt body"
            });
        }

        private static void DefineAst(string outputDir, string baseName, List<string> types)
        {
            string path = $"{outputDir}/{baseName}.cs";
            using (StreamWriter file = new StreamWriter(path, false, Encoding.UTF8))
            {
                file.WriteLine("using System.Collections.Generic;");
                file.WriteLine();
                file.WriteLine("namespace CsLox");
                file.WriteLine("{");

                file.WriteLine($"    public abstract class {baseName}");
                file.WriteLine("    {");

                // The base accept() method.
                file.WriteLine();
                file.WriteLine($"        public abstract T Accept<T>(I{baseName}Visitor<T> visitor);");

                file.WriteLine("    }");
                file.WriteLine();

                // The AST classes.
                foreach (string type in types)
                {
                    string className = type.Split(':')[0].Trim();
                    string fields = type.Split(':')[1].Trim();
                    DefineType(file, baseName, className, fields);
                }


                DefineVisitor(file, baseName, types);

                file.WriteLine("}");
            }
        }

        private static void DefineVisitor(StreamWriter file, string baseName, List<string> types)
        {
            file.WriteLine($"    public interface I{baseName}Visitor<T>");
            file.WriteLine("    {");

            foreach (string type in types)
            {
                string typeName = type.Split(':')[0].Trim();
                file.WriteLine($"        T Visit{typeName}{baseName}({typeName} {baseName.ToLower()});");
            }

            file.WriteLine("    }");
        }

        private static void DefineType(StreamWriter file, string baseName, string className, string fieldList)
        {
            file.WriteLine($"    public class {className} : {baseName}");
            file.WriteLine("    {");

            // Fields.
            string[] fields = fieldList.Split(new string[] { ", " }, StringSplitOptions.None);
            foreach (string field in fields)
            {
                if (!string.IsNullOrWhiteSpace(field))
                {
                    string fieldType = field.Split(' ')[0];
                    string fieldName = field.Split(' ')[1];
                    if (fieldName[0] == '@')
                    {
                        file.WriteLine($"        public {fieldType} {fieldName.Substring(1, 1).ToUpper()}{fieldName.Substring(2)} {{ get; }}");
                    }
                    else
                    {
                        file.WriteLine($"        public {fieldType} {fieldName.Substring(0, 1).ToUpper()}{fieldName.Substring(1)} {{ get; }}");
                    }
                }
            }
            file.WriteLine();

            // Constructor.
            file.WriteLine($"        public {className}({fieldList})");
            file.WriteLine("        {");

            // Store parameters in fields.
            foreach (string field in fields)
            {
                if (!string.IsNullOrWhiteSpace(field))
                {
                    string name = field.Split(' ')[1];
                    if (name[0] == '@')
                    {
                        file.WriteLine($"            {name.Substring(1, 1).ToUpper()}{name.Substring(2)} = {name};");
                    }
                    else
                    {
                        file.WriteLine($"            {name.Substring(0, 1).ToUpper()}{name.Substring(1)} = {name};");
                    }
                }
            }
            file.WriteLine("        }");

            // Visitor pattern.
            file.WriteLine();
            file.WriteLine($"        public override T Accept<T>(I{baseName}Visitor<T> visitor)");
            file.WriteLine("        {");
            file.WriteLine($"            return visitor.Visit{className}{baseName}(this);");
            file.WriteLine("        }");

            file.WriteLine("    }");
            file.WriteLine();
        }
    }
}
