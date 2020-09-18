using CsLox.Enums;
using System;
using System.Collections.Generic;
using System.IO;

namespace CsLox
{
    public class CsLox
    {
        public static bool HadError { get; set; } = false;

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

                    //if (HadError || HadRuntimeError)
                    if (HadError)
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

            Console.WriteLine(new AstPrinter().Print(expression));
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

        private static void Report(int line, string where, string message)
        {
            Console.Error.WriteLine($"[line {line}] Error {where}: {message}");
            HadError = true;
        }
    }
}
