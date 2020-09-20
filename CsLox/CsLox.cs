using CsLox.Enums;
using CsLox.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;

namespace CsLox
{
    public class CsLox
    {
        public static bool HadError { get; set; } = false;
        public static bool HadRuntimeError { get; set; } = false;

        private static Interpreter interpreter = new Interpreter();

        public static void Main(string[] args)
        {
            if (args.Length > 1)
            {
                Console.WriteLine("Usage: cslox [script]");
                Environment.Exit(1);
            }
            else if (args.Length == 1)
            {
                RunFile(args[0]);
            }
            else
            {
                RunPrompt();
            }
        }

        private static void RunFile(string path)
        {
            try
            {
                if (!Path.GetExtension(path).Equals(".lox"))
                {
                    Console.WriteLine("Only files with a \".lox\" extension can be read.");
                    Environment.Exit(1);
                }

                using (StreamReader sr = new StreamReader(path))
                {
                    Run(sr.ReadToEnd());

                    if (HadError || HadRuntimeError)
                    {
                        Environment.Exit(1);
                    }
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine("The file could not be read: ");
                Console.Error.WriteLine(e.Message);
            }
        }

        private static void RunPrompt()
        {
            while (true)
            {
                Console.Write("> ");
                String line = Console.ReadLine();
                if (String.IsNullOrWhiteSpace(line))
                {
                    break;
                }

                Run(line);
                HadError = false;
            }
        }

        private static void Run(string source)
        {
            Scanner scanner = new Scanner(source);
            List<Token> tokens = scanner.ScanTokens();
            Parser parser = new Parser(tokens);
            Expr expression = parser.Parse();

            // Stop if there was a syntax error.
            if (HadError)
            {
                return;
            }

            interpreter.Interpret(expression);
        }

        public static void Error(int line, string message)
        {
            Report(line, string.Empty, message);
        }

        public static void Error(Token token, string message)
        {
            if (token.Type == TokenType.EOF)
            {
                Report(token.Line, " at end", message);
            }
            else
            {
                Report(token.Line, $" at '{token.Lexeme}'", message);
            }
        }

        public static void RuntimeError(RuntimeException error)
        {
            Console.Error.WriteLine($"{error.Message}\n[line {error.Token.Line}]");
            HadRuntimeError = true;
        }

        private static void Report(int line, string where, string message)
        {
            Console.Error.WriteLine($"[line {line}] Error {where}: {message}");
            HadError = true;
        }
    }
}
