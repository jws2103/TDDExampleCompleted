using System.Diagnostics.CodeAnalysis;

namespace TDDMAUI.Exceptions
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
