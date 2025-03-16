using AtCoderCs.Training.Typical.Problem004;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Tests.Contents.Services;
using Xunit;
using Xunit.Abstractions;

namespace AtCoderCs.Training.Typical.Tests.Problem004;

[Contest($"TypicalProblem90", $"004")]
public class TestProblem : IClassFixture<TestFixture>
{
    private static readonly ContestAttribute _attribute = typeof(TestProblem).GetCustomAttribute<ContestAttribute>();
    private static readonly string _problemFolder = $"001_010";

    private ILogger _logger;
    private TestJudgeService _judgeService;

    public TestProblem(ITestOutputHelper output, TestFixture fixture)
    {
        _logger = new XunitLogger(output);
        var baseDirectory = fixture.GetBaseDirectory(_attribute.Section, _problemFolder, _attribute.Number);
        _judgeService = new TestJudgeService(_logger, baseDirectory, _attribute.Number);
    }

    [Theory(DisplayName = $"ABC 004")]
    [InlineData($"", typeof(Problem), nameof(Problem.Solve))]
    public void Solve(string level, Type problemType, string methodName, double epcilon = 0)
    {
        var results = _judgeService.Solve(level, problemType, methodName);
        _judgeService.Judge(results, epcilon);
    }
}