using System.Diagnostics.CodeAnalysis;

namespace TDDMAUI.Exceptions
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
