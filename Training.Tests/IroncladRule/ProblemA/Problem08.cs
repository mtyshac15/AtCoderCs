using AtCoderCs.Training.A08;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Tests.Contents.Services;
using Xunit;
using Xunit.Abstractions;

namespace AtCoderCs.Training.Tests.A08;


[Contest($"IroncladRule", $"")]
public class Problem : IClassFixture<TestFixture>
{
    private static readonly ContestAttribute _attribute = typeof(Problem).GetCustomAttribute<ContestAttribute>();
    private static readonly string _problemFolder = $"ProblemA";

    private ILogger _logger;
    private TestJudgeService _judgeService;

    public Problem(ITestOutputHelper output, TestFixture fixture)
    {
        _logger = new XunitLogger(output);
        var baseDirectory = fixture.GetBaseDirectory(_attribute.Section, _problemFolder, _attribute.Number);
        _judgeService = new TestJudgeService(_logger, baseDirectory, _attribute.Number);
    }

#if DEBUG
    [Theory(DisplayName = $"IroncladRule 08")]
    [InlineData($"08", typeof(ProblemA), nameof(ProblemA.Solve))]
    public void Solve(string level, Type problemType, string methodName, double epcilon = 0)
    {
        var results = _judgeService.Solve(level, problemType, methodName);
        _judgeService.Judge(results, epcilon);
    }
#endif
}