using System.Collections.Generic;
using CsLox.Exceptions;
using CsLox.Interfaces;

namespace CsLox
{
    public class LoxFunction : ILoxCallable
    {
        private Function declaration;
        private LoxEnvironment closure;

        public LoxFunction(Function declaration, LoxEnvironment closure)
        {
            this.closure = closure;
            this.declaration = declaration;
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
                return returnValue.Value;
            }

            return null;
        }

        public override string ToString()
        {
            return $"<fn {declaration.Name.Lexeme}>";
        }
    }
}
