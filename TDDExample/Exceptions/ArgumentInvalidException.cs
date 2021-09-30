using System;
using System.Diagnostics.CodeAnalysis;

namespace TDDExample
{
    [ExcludeFromCodeCoverage]
    public class ArgumentInvalidException : Exception
    {
        public ArgumentInvalidException(string message)
            : base(message)
        {
        }
    }
}
