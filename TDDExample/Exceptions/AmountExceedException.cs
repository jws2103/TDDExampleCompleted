using System;
using System.Diagnostics.CodeAnalysis;

namespace TDDExample
{
    [ExcludeFromCodeCoverage]
    public class AmountExceedException : Exception
    {
        public AmountExceedException(string message)
            : base(message)
        {
        }
    }
}
