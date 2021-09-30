using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace TDDExample
{
    [ExcludeFromCodeCoverage]
    public class Logger : ILogger
    {
        public void Log(string exception)
        {
            Debug.WriteLine(exception);
        }
    }
}
