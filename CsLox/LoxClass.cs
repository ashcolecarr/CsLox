using System.Collections.Generic;
using CsLox.Interfaces;

namespace CsLox
{
    public class LoxClass : ILoxCallable
    {
        public string Name { get; set; }
        private Dictionary<string, LoxFunction> methods;

        public LoxClass(string name, Dictionary<string, LoxFunction> methods)
        {
            Name = name;
            this.methods = methods;
        }

        public LoxFunction FindMethod(string name)
        {
            if (methods.TryGetValue(name, out LoxFunction method))
            {
                return method;
            }

            return null;
        }

        public int Arity()
        {
            LoxFunction initializer = FindMethod("init");
            if (initializer == null)
            {
                return 0;
            }

            return initializer.Arity();
        }

        public object Call(Interpreter interpreter, List<object> arguments)
        {
            LoxInstance instance = new LoxInstance(this);
            LoxFunction initializer = FindMethod("init");
            if (initializer != null)
            {
                initializer.Bind(instance).Call(interpreter, arguments);
            }

            return instance;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
