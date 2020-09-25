using System.Collections.Generic;

namespace CsLox.Interfaces
{
    public interface ILoxCallable
    {
        int Arity();
        object Call(Interpreter interpreter, List<object> arguments);
    }
}
