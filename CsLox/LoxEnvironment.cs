using CsLox.Exceptions;
using System.Collections.Generic;

namespace CsLox
{
    public class LoxEnvironment
    {
        public LoxEnvironment Enclosing;
        private Dictionary<string, object> values = new Dictionary<string, object>();

        public LoxEnvironment()
        {
            Enclosing = null;
        }

        public LoxEnvironment(LoxEnvironment enclosing)
        {
            this.Enclosing = enclosing;
        }

        public object Get(Token name)
        {
            if (values.TryGetValue(name.Lexeme, out object value))
            {
                return value;
            }

            if (Enclosing != null)
            {
                return Enclosing.Get(name);
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

            if (Enclosing != null)
            {
                Enclosing.Assign(name, value);

                return;
            }

            throw new RuntimeException(name, $"Undefined variable '{name.Lexeme}'.");
        }

        public void Define(string name, object value)
        {
            values[name] = value;
        }

        public LoxEnvironment Ancestor(int distance)
        {
            LoxEnvironment environment = this;
            for (int i = 0; i < distance; i++)
            {
                environment = environment.Enclosing;
            }

            return environment;
        }

        public object GetAt(int distance, string name)
        {
            return Ancestor(distance).values[name];
        }

        public void AssignAt(int distance, Token name, object value)
        {
            Ancestor(distance).values[name.Lexeme] = value;
        }
    }
}
