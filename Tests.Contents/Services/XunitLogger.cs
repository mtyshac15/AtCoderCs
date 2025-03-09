using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace Tests.Contents.Services;

public class XunitLogger : ILogger
{
    private ITestOutputHelper _output;
    private string _categoryName;

    public XunitLogger(ITestOutputHelper output, string categoryName = "")
    {
        _output = output;
        _categoryName = categoryName;
    }

    public IDisposable BeginScope<TState>(TState state) where TState : notnull
    {
        throw new NotImplementedException();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        _output.WriteLine($"{_categoryName} [{eventId}] {formatter(state, exception)}");

        if (exception is not null)
        {
            _output.WriteLine(exception.ToString());
        }
    }
}
