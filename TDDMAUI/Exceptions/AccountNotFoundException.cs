using System.Diagnostics.CodeAnalysis;

namespace TDDMAUI.Exceptions
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
