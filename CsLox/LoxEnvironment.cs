using CsLox.Exceptions;
using System.Collections.Generic;

namespace CsLox
{
    public class LoxEnvironment
    {
        public LoxEnvironment enclosing;
        private Dictionary<string, object> values = new Dictionary<string, object>();

        public LoxEnvironment()
        {
            enclosing = null;
        }

        public LoxEnvironment(LoxEnvironment enclosing)
        {
            this.enclosing = enclosing;
        }

        public object Get(Token name)
        {
            if (values.TryGetValue(name.Lexeme, out object value))
            {
                return value;
            }

            if (enclosing != null)
            {
                return enclosing.Get(name);
            }

            throw new RuntimeException(name, $"Undefined variable '{name.Lexeme}'.");
        }

        public void Assign(Token name, object value)
        {
            if (values.ContainsKey(name.Lexeme))
            {
                values[name.Lexeme] = value;

                return;
            }

            if (enclosing != null)
            {
                enclosing.Assign(name, value);

                return;
            }

            throw new RuntimeException(name, $"Undefined variable '{name.Lexeme}'.");
        }

        public void Define(string name, object value)
        {
            if (values.ContainsKey(name))
            {
                values[name] = value;
            }
            else
            {
                values.Add(name, value);
            }
        }
    }
}
