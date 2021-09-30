using System;
using System.Diagnostics.CodeAnalysis;

namespace TDDExample
{
    [ExcludeFromCodeCoverage]
    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message)
            : base(message)
        {
        }
    }
}
