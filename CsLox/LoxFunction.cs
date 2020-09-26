using System.Collections.Generic;
using CsLox.Exceptions;
using CsLox.Interfaces;

namespace CsLox
{
    public class LoxFunction : ILoxCallable
    {
        private Function declaration;
        private LoxEnvironment closure;
        private bool isInitializer;

        public LoxFunction(Function declaration, LoxEnvironment closure, bool isInitializer)
        {
            this.isInitializer = isInitializer;
            this.closure = closure;
            this.declaration = declaration;
        }

        public LoxFunction Bind(LoxInstance instance)
        {
            LoxEnvironment environment = new LoxEnvironment(closure);
            environment.Define("this", instance);

            return new LoxFunction(declaration, environment, isInitializer);
        }

        public int Arity()
        {
            return declaration.Params.Count;
        }

        public object Call(Interpreter interpreter, List<object> arguments)
        {
            LoxEnvironment environment = new LoxEnvironment(closure);
            for (int i = 0; i < declaration.Params.Count; i++)
            {
                environment.Define(declaration.Params[i].Lexeme, arguments[i]);
            }

            try
            {
                interpreter.ExecuteBlock(declaration.Body, environment);
            }
            catch (ReturnException returnValue)
            {
                if (isInitializer)
                {
                    return closure.GetAt(0, "this");
                }

                return returnValue.Value;
            }

            if (isInitializer)
            {
                return closure.GetAt(0, "this");
            }

            return null;
        }

        public override string ToString()
        {
            return $"<fn {declaration.Name.Lexeme}>";
        }
    }
}
