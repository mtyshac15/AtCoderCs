using AtCoderCs.Training.ATC001;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Tests.Contents.Services;
using Xunit;
using Xunit.Abstractions;

namespace Training.Tests.ABC0001;

[Contest($"ATC", $"001")]
public class Problem : IClassFixture<TestFixture>
{
    private static readonly ContestAttribute _attribute = typeof(Problem).GetCustomAttribute<ContestAttribute>()!;
    private static readonly string _problemFolder = string.Empty;

    private ILogger _logger;
    private TestJudgeService _judgeService;

    public Problem(ITestOutputHelper output, TestFixture fixture)
    {
        _logger = new XunitLogger(output);
        var baseDirectory = fixture.GetBaseDirectory(_attribute.Section, _problemFolder, _attribute.Number);
        _judgeService = new TestJudgeService(_logger, baseDirectory, _attribute.Number);
    }

    [Theory(DisplayName = $"ATC 002")]
    [InlineData($"A", typeof(ProblemA), nameof(ProblemA.Solve))]
    public void Solve(string level, Type problemType, string methodName, double epcilon = 0)
    {
        var results = _judgeService.Solve(level, problemType, methodName);
        _judgeService.Judge(results, epcilon);
    }
}