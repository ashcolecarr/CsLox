using System;
using System.Collections.Generic;
using CsLox.Interfaces;

namespace CsLox.NativeFunctions
{
    public class Power : ILoxCallable
    {
        public int Arity()
        {
            return 2;
        }

        public object Call(Interpreter interpreter, List<object> arguments)
        {
            double @base = (double)arguments[0];
            double power = (double)arguments[1];

            return Math.Pow(@base, power);
        }

        public override string ToString()
        {
            return "<native fn>";
        }
    }
}
