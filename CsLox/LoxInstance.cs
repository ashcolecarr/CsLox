using CsLox.Exceptions;
using System.Collections.Generic;

namespace CsLox
{
    public class LoxInstance
    {
        private LoxClass @class;
        private Dictionary<string, object> fields = new Dictionary<string, object>();

        public LoxInstance(LoxClass @class)
        {
            this.@class = @class;
        }

        public object Get(Token name)
        {
            if (fields.TryGetValue(name.Lexeme, out object value))
            {
                return value;
            }

            LoxFunction method = @class.FindMethod(name.Lexeme);
            if (method != null)
            {
                return method.Bind(this);
            }

            throw new RuntimeException(name, $"Undefined property '{name.Lexeme}'.");
        }

        public void Set(Token name, object value)
        {
            fields[name.Lexeme] = value;
        }

        public override string ToString()
        {
            return $"{@class.Name} instance";
        }
    }
}
