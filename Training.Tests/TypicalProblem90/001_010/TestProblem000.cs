using Microsoft.Extensions.Logging;
using System.Reflection;
using Tests.Contents.Services;
using Xunit;
using Xunit.Abstractions;

namespace AtCoderCs.Training.Typical.Tests.Problem000;

[Contest($"TypicalProblem90", $"000")]
public class TestProblem
{
    private static readonly ContestAttribute _attribute = typeof(TestProblem).GetCustomAttribute<ContestAttribute>();
    private static readonly string _problemFolder = Path.Combine($"000_000", "000_000");

    private ILogger _logger;
    private TestJudgeService _judgeService;

    public TestProblem(ITestOutputHelper output, TestFixture fixture)
    {
        _logger = new XunitLogger(output);
        var baseDirectory = fixture.GetBaseDirectory(_attribute.Section, _problemFolder, _attribute.Number);
        _judgeService = new TestJudgeService(_logger, baseDirectory, _attribute.Number);
    }

    public void Solve(string level, Type problemType, string methodName, double epcilon = 0)
    {
        var results = _judgeService.Solve(level, problemType, methodName);
        _judgeService.Judge(results, epcilon);
    }
}