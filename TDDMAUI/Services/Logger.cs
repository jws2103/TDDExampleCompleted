using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace TDDMAUI.Services;

[ExcludeFromCodeCoverage]
public class Logger : Interfaces.ILogger
{
    public void Log(string exception)
    {
        Debug.WriteLine(exception);
    }
}