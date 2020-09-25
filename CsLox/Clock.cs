using System;
using System.Collections.Generic;
using CsLox.Interfaces;

namespace CsLox
{
    public class Clock : ILoxCallable
    {
        public int Arity()
        {
            return 0;
        }

        public object Call(Interpreter interpreter, List<object> arguments)
        {
            return (double)(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond);
        }

        public override string ToString()
        {
            return "<native fn>";
        }
    }
}
