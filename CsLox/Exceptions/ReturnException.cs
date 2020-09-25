using System;

namespace CsLox.Exceptions
{
    public class ReturnException : Exception
    {
        public object Value { get; set; }

        public ReturnException(object value) : base()
        {
            this.Value = value;
        }
    }
}
